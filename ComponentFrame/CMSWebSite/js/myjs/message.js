//发送消息
function SendMsg() {
    var receiver = $("#receiver").val();
    var content = $("#content").val();
    
    var $btn = $("#sendButton");

    if (receiver == null || receiver == "" || receiver == undefined) {
        layer.tips('你还没有选择接收人!', $("#receiver"), {
            guide: 2,
            time: 2,
            style: ['background-color:#F26C4F; color:#fff', '#F26C4F'],
            maxWidth: 150
        });
    }
    else if (content == null || content == "" || content == undefined) {
        layer.tips('你还没有写消息内容!', $("#content"), {
            guide: 2,
            time: 2,
            style: ['background-color:#F26C4F; color:#fff', '#F26C4F'],
            maxWidth: 150
        });
    }
    else {
        $btn.button('loading');
        var messageService = new MessageService();
        messageService.SendMessage(receiver, content,
            function (data, status) {
                if (data == "0") {
                    $("#receiver").val("");
                    $("#content").val("")
                    alert("发送成功！");
                }
                else {
                    alert("发送失败！");
                }
                $btn.button('reset');
            });
    }
}
//查询用户列表
function queryUsers() {
    userParam = $("#userparam").val();
    //获取用户列表
    getAllUsers();
}

//获取所有用户
function getAllUsers() {
    $("#tb_userlist").html("<img src='/Image/loading.gif' style='margin-left: 190px; margin-top: 120px;' />");
    var userBaseInfoService = new UserBaseInfoService();
    userBaseInfoService.GetUserList(userParam, 0, -1, 1, 0,
        function (data, status) {
            if (data != null && data != "") {
                allUsers = $.parseJSON(data);//转换出总条数
                //初始化用户列表
                initUserList();
            }
            else {
                $("#tb_userlist").html(data);
            }
        });
}
//初始化用户列表
function initUserList() {
    var listStr = "";
    var curtotalNum = allUsers._Items.length;//总条数
    if (curtotalNum > 0) {
        obj = allUsers._Items;//转换出数据源
        $.each(obj, function (i) {
            listStr += "<a href='#' class='list-group-item'><span class='glyphicon glyphicon-plus pull-right' onclick='addUserToMember(\"" + obj[i].NickName + "\")'></span>" + (obj[i].NickName + (obj[i].FullName == null ? "  " : "  (" + obj[i].FullName + ")")) + "</a>";
        });
        $("#tb_userlist").html(listStr);
    }
    else {
        $("#tb_userlist").html(listStr);
    }
}
//添加用户到接收成员
function addUserToMember(uId) {
    //获取已选成员
    allReceiver = $("#receiver").val();
    obj = allUsers._Items;//转换出数据源
    var receivers = new Array();
    //不存在成员列表才添加
    if (allReceiver != null && allReceiver != "") {
        if (allReceiver.indexOf(",") > 0) {
            receivers = allReceiver.split(",");
        }
        else {
            receivers.push(allReceiver);
        }
    }
    if (!contains(uId, receivers)) {
        receivers.push(uId);
    }
    //重新组合字符串
    allReceiver = receivers.join(",");
    //界面重新赋值
    $("#receiver").val(allReceiver);
}
function contains(value, array) {
    for (var i = 0; i < array.length; i++) {  
        if (array[i] == value) {
            return true;  
            }  
        }     
    return false;  
}
//初始化分页
function initlist() {
    messageService.QueryMessageCount(State,
       function (data, status) {
           totalNum = data;
           if (totalNum > 0) {
               pageList(State, currentPage, pageSize, true);
           }
       });
}


/***分页***/
function pagination() {
    $("#pagination").pagination({
        total: totalNum,
        pageSize: pageSize,
        pageNumber: 1,//初始化当前页
        //点击分页按钮触发
        onSelectPage: function (page, pageSize) {
            pageList(State, page, pageSize, false)
            return true;//必写！否则点击下一页时无效！
        }
    });
}
//标记列表项
function marklist(state) {
    var marklist;
    var arrayObj = new Array();　//创建一个数组
    //检查选择情况
    if (!checkItem()) {
        alert("您还未选择要标记的项!");
    }
    else {
        var code_Values = document.all['checkboxitem'];
        if (code_Values.length) {
            for (var i = 0; i < code_Values.length; i++) {
                if (code_Values[i].checked) {
                    arrayObj.push(datalist._Items[i].Guid);
                }
            }
        }
        else {
            arrayObj.push(datalist._Items[0].Guid);
        }
        //将数组转换成字符串，以","隔开
        marklist = arrayObj.join(",");
        //执行标记行
        MarkList(marklist, state);
    }
}
//删除列表项
function deletelist() {
    var deletelist;
    var arrayObj = new Array();　//创建一个数组
    //检查选择情况
    if (!checkItem()) {
        alert("您还未选择删除项!");
    }
    else {
        var code_Values = document.all['checkboxitem'];
        if (code_Values.length) {
            for (var i = 0; i < code_Values.length; i++) {
                if (code_Values[i].checked) {
                    arrayObj.push(datalist._Items[i].Guid);
                }
            }
        }
        else {
            arrayObj.push(datalist._Items[0].Guid);
        }
        //将数组转换成字符串，以","隔开
        deletelist = arrayObj.join(",");
        //执行删除
        DeleteList(deletelist);
    }
}
//分页查询我的消息
function pageList(State, pageIndex, pageSize, isPage) {
    messageService.QueryMessagePageList(State, pageIndex, pageSize,
        function (data, status) {
            datalist = $.parseJSON(data);//转换出总条数
            var curtotalNum = datalist._Items.length;//总条数
            var contentStr;
            if (curtotalNum > 0) {
                obj = datalist._Items;//转换出数据源
                $.each(obj, function (i) {
                    contentStr = obj[i].MessageContent.length < 40 ? obj[i].MessageContent : (obj[i].MessageContent.substring(0, 40) + "...");
                    strTable += "<tr>" +
                        "<td style='width:2%;text-align:center'><input type='checkbox' id='checkboxitem'></td>" +
                        "<td style='width:5%;text-align:center' onclick=layerMessage('"+ obj[i].Guid + "','" + obj[i].Sender + "','" + obj[i].State + "')>" + (((pageIndex - 1) * pageSize) + (i + 1)) + "</td>" +
                        "<td style='width:70%;text-align:left' onclick=layerMessage('" + obj[i].Guid + "','" + obj[i].Sender + "','" + obj[i].State + "')><a href='#' title='" + obj[i].MessageContent + "'>"
                        + (obj[i].State == 1 ? ("<b>" + contentStr + "</b>") : contentStr)
                        + "</a></td>" +
                        "<td style='width:10%;text-align:center' onclick=layerMessage('" + obj[i].Guid + "','" + obj[i].Sender + "','" + obj[i].State + "')>" + obj[i].Sender + "</td>" +
                        "<td style='width:13%;text-align:center' onclick=layerMessage('" + obj[i].Guid + "','" + obj[i].Sender + "','" + obj[i].State + "')>" + timeFormatter(obj[i].CreateDate) + "</td>" +
                        + "</tr>";
                });
                $("#tb_messagelist").html(strTable);
                strTable = "";
                if (isPage) {
                    pagination();//分页
                }
            }
            else {
                $("#tb_messagelist").html(strTable);
            }
        });
}

//标记消息
function MarkMsg(guid, state) {
    messageService.MarkMessage(guid, state,
        function (data, status) {
            if (data == '"ok"') {
                //重新刷新列表
                initlist();
            }
        });
}
//标记列表
function MarkList(listStr, state) {
    messageService.MarkMessageList(listStr, state,
         function (data, status) {
             if (data=='"ok"') {
                 //重新刷新列表
                 initlist();
             }
             else {
                 alert("标记失败！");
             }
         });
}

//删除消息
function DeleteList(listStr) {
    messageService.DeleteMessageList(listStr,
         function (data, status) {
             if (data == '"ok"') {
                 //重新刷新列表
                 initlist();
             }
             else {
                 alert("删除失败！");
             }
         });
}
//弹出消息对话层
function layerMessage(guid, sender, state) {
    //将未阅读消息标记为阅读
    if (state==1) {
        //先去更改消息状态为已阅读
        MarkMsg(guid, 0);
    }
    
    //然后弹出消息对话层
    $.layer({
        type: 2,
        shadeClose: true,
        title: sender,
        closeBtn: [0, true],
        maxmin: true,
        fix: false,
        border: [0],
        offset: ['20px', ''],
        area: ['622px', '486px'],
        iframe: {
            src: 'MessageInfo.html?Guid='+guid
        }
    });
}
//初始化消息对话框
function initMessageLay(guid) {
    messageService.GetMessage(guid,
         function (data, status) {
             var msgObj = $.parseJSON(data);//转换出对象
             var msgLiStr;
             if (msgObj != null && msgObj != undefined) {
                 sender = msgObj.Sender;
                 userMsg = msgObj.MessageContent;
                 msgLiStr = "<li>" +
                        "<div class = 'layim_chatuser'>"+
                        "<span class='layim_chattime'>" + timeFormatter(msgObj.CreateDate) + "</span>" +
                        "<span class='layim_chatname'>" + sender + " </span>" +
                        "</div><div class='layim_chatsay'>" + userMsg + "<em class='layim_zero'></em></div>" +
                        "</li>";
             }
             $("#layim_chatthis").html(msgLiStr);
         });
}
//回复消息
function BackMsg() {
    var msgStr = $("#msg_content").val();
    var $btn = $("#replybtn");
    var msgLiStr;
    var myDate = new Date();

    if (msgStr == null || msgStr == "" || msgStr == undefined) {
        layer.tips('你不说点什么吗？', $("#msg_content"), {
            guide: 2,
            time: 2,
            style: ['background-color:#F26C4F; color:#fff', '#F26C4F'],
            maxWidth: 150
        });
    }
    else {
        $btn.button('loading');
        messageService.SendMessage(sender, msgStr,
             function (data, status) {
                 if (data == "0") {
                     msgLiStr = "<li class='layim_chateme'>" +
                        "<div class = 'layim_chatuser'>" +
                        "<span class='layim_chattime'>" + myDate.toLocaleString() + "</span>" +
                        "<span class='layim_chatname'>我</span>" +
                        "</div><div class='layim_chatsay'>" + msgStr + "<em class='layim_zero'></em></div>" +
                        "</li>";
                     $("#layim_chatthis").append(msgLiStr);
                     $("#layim_chatthis").scrollTop($("#layim_chatthis")[0].scrollHeight);
                     $("#msg_content").val("");
                 }
                 else {
                     alert("发送失败！");
                 }
                 $btn.button('reset');
             });
    }
}

//转发
function forwarMessage() {
    sessionStorage.setItem("Content", userMsg);
    window.parent.location.href = "SendMessage.html" ;
}