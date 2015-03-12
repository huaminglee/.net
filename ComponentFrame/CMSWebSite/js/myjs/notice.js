//初始化公告栏
function InitNotices(count) {
    //实例化公告服务对象
    var noticeService = new NoticeService();
    //获取公告列表
    noticeService.QueryNoticeList(count,
        function (data, status) {
            var strTable = "";
            var objTemp = $.parseJSON(data);//转换出总条数
            var curtotalNum = objTemp._Items.length;//总条数
            if (curtotalNum > 0) {
                obj = objTemp._Items;//转换出数据源
                $.each(obj, function (i) {
                    strTable += "<tr style='height:25px'>" +
                        "<td style='width:70%;padding-left:10px'><a href='#' title='" + obj[i].Title + "' data-target='/iframes/notice/NoticeBrowse.html?Guid=" + obj[i].Guid + "' data-model='container'>" +
                        (obj[i].Title.length < 30 ? obj[i].Title : (obj[i].Title.substring(0, 30) + "...")) + "</a></td>" +
                        "<td style='text-align:right;padding-right:10px'>" + timeFormatter(obj[i].CreateDate) + "</td>" +
                        + "</tr>";
                });
                $("#tb_noticelist").html(strTable);
            }
            else {
                $("#tb_noticelist").html(strTable);
            }
        });
}
//发布公告
function AddNotice() {
    var noticeService = new NoticeService();

    var author = noticeService.loginResult.FullName;

    var title = $("#title").val();
    var content = $("#content").val();
    var $btn = $("#sendButton").button('loading');
    if (title == null || title=="") {
        alert("标题不能为空！");
    }
    else if (content == null || content == "") {
        alert("内容不能为空！");
    }
    else {
        //发布公告
        noticeService.Announcement(title, content, author,
            function (data, status) {
                var code = parseInt(data);
                if (code == 1) {
                    alert("此标题已存在！");
                }
                else if (code == -1) {
                    alert("发布失败！");
                }
                else {
                    window.location.href = "NoticeManage.html";
                }
                $btn.button('reset');
            });
    }
}


//获取详情
function GetNoticeDetail(guid) {
    var noticeService = new NoticeService();
    var reg = /(http:\/\/[\w.\/]+)(?![^<]+>)/gi;
    noticeService.GetNotice(guid,
          function (data, status) {
              var notice = $.parseJSON(data); //转换为对象
              $("#tilte").html(notice.Title);
              $("#author").text("发布人：" + notice.Author);
              $("#createtime").text(timeFormatter(notice.CreateDate));
              $("#content").html(replaceReg(reg, notice.Content));
          });
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
//删除列表
function DeleteList(listStr) {
    noticeService.DeleteNoticeList(listStr,
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
//初始化分页
function initlist() {
    noticeService.QueryNoticeCount(paramStr,
          function (data, status) {
              totalNum = data;
              if (totalNum > 0) {
                  pageList(currentPage, pageSize, true);
              }
              else {
                  $("#tb_noticelist").html("");
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
            pageList(page, pageSize, false)
            return true;//必写！否则点击下一页时无效！
        }
    });
}

//查询分页
function querylist() {
    paramStr = $("#title_search").val();
    initlist();
}

//分页查询公告消息
function pageList(pageIndex, pageSize, isPage) {
    noticeService.QueryNoticePageList(paramStr, pageIndex, pageSize,
        function (data, status) {
            datalist = $.parseJSON(data);//转换出总条数
            var curtotalNum = datalist._Items.length;//总条数
            if (curtotalNum > 0) {
                obj = datalist._Items;//转换出数据源
                $.each(obj, function (i) {
                    if (flag == "querylist") {
                        strTable += "<tr>" +
                        "<td style='width:2%;text-align:center'><input type='checkbox' id='checkboxitem'></td>" +
                        "<td style='width:3%;text-align:center'>" + (((pageIndex - 1) * pageSize) + (i + 1)) + "</td>" +
                        "<td style='width:30%;text-align:left'><a href='#' title='" + obj[i].Title + "' data-target='/iframes/notice/NoticeBrowse.html?Guid=" + obj[i].Guid + "' data-model='self'>" + (obj[i].Title.length < 30 ? obj[i].Title : (obj[i].Title.substring(0, 30) + "...")) + "</a></td>" +
                        "<td style='width:50%;text-align:left'><a href='#' title='" + obj[i].Content + "' data-target='/iframes/notice/NoticeBrowse.html?Guid=" + obj[i].Guid + "' data-model='self'>" + (obj[i].Content.length < 40 ? obj[i].Content : (obj[i].Content.substring(0, 40) + "...")) + "</a></td>" +
                        "<td style='width:15%;text-align:center'>" + timeFormatter(obj[i].CreateDate) + "</td>" +
                        + "</tr>";
                    }
                    else {
                        strTable += "<tr>" +
                        "<td style='width:5%;text-align:center'>" + (((pageIndex - 1) * pageSize) + (i + 1)) + "</td>" +
                        "<td style='width:80%;text-align:left'><a href='#' title='" + obj[i].Title + "' data-target='/iframes/notice/NoticeBrowse.html?Guid=" + obj[i].Guid + "' data-model='self'>" + (obj[i].Title.length < 100 ? obj[i].Title : (obj[i].Title.substring(0, 100) + "...")) + "</a></td>" +
                        "<td style='width:15%;text-align:center'>" + timeFormatter(obj[i].CreateDate) + "</td>" +
                        + "</tr>";
                    }
                      
                });
                $("#tb_noticelist").html(strTable);
                strTable = "";
                if (isPage) {
                    pagination();//分页
                }
            }
            else {
                $("#tb_noticelist").html(strTable);
            }
        });
}

