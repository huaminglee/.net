var datalist, obj, strTable = "", pageSize = 10, currentPage = 1, totalNum = 0;
var uId = "", updatelist = "";
var paramStr = null;
var userBaseInfoService = new UserBaseInfoService();

$(function () {
    initlist();
});
//初始化分页
function initlist() {
    userBaseInfoService.QueryUserCount(paramStr, 1, 0,
        function (data, status) {
            totalNum = data;
            if (totalNum > 0) {
                pageList(paramStr, currentPage, pageSize, true);
            }
            else {
                $("#tb_userlist").html("");
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
            pageList( paramStr, page, pageSize, false)
            return true;//必写！否则点击下一页时无效！
        }
    });
}
//查询分页
function querylist() {
    paramStr = $("#name_search").val();
    initlist();
}
//分页查询用户信息
function pageList(queryStr, pageIndex, pageSize, isPage) {
    userBaseInfoService.GetUserList(queryStr, (pageIndex - 1) * pageSize, pageSize, 1, 0,
          function (data, status) {
              datalist = $.parseJSON(data);//转换出总条数
              var curtotalNum = datalist._Items.length;//总条数
              if (curtotalNum > 0) {
                  obj = datalist._Items;//转换出数据源
                  $.each(obj, function (i) {
                      strTable += "<tr>" +
                          "<td style='width:3%;text-align:center'><input type='checkbox' id='checkboxitem'></td>" +
                          "<td style='width:5%;text-align:center'>" + (((pageIndex - 1) * pageSize) + (i + 1)) + "</td>" +
                          "<td style='width:12%;text-align:center'>" + obj[i].NickName + "</td>" +
                          "<td style='width:12%;text-align:center'>" + (obj[i].FullName == null ? "" : obj[i].FullName) + "</td>" +
                          "<td style='width:20%;text-align:center'>" + (obj[i].Unit == null ? "" : obj[i].Unit) + "</td>" +
                          "<td style='width:14%;text-align:center'>" + (obj[i].Tel1 == null ? "" : obj[i].Tel1) + "</td>" +
                          "<td style='width:14%;text-align:center'>" + (obj[i].Mob1 == null ? "" : obj[i].Mob1) + "</td>" +
                          "<td style='width:20%;text-align:center'>" + (obj[i].Detail == null ? "" : obj[i].Detail) + "</td>" +
                          + "</tr>";
                  });
                  $("#tb_userlist").html(strTable);
                  strTable = "";
                  if (isPage) {
                      pagination();//分页
                  }
              }
              else {
                  $("#tb_userlist").html(strTable);
              }
          });
}
//弹出确认对话框
function confirmDialog(list) {
    layer.confirm('确认要删除该用户，删除后无法恢复', function (index) {
        layer.closeAll();
        DeleteList(list);
    });
}
//编辑用户
function edit() {
    //检查选择情况
    if (!checkItem()) {
        alert("请先选择");
    }
    else {
        var code_Values = document.all['checkboxitem'];
        if (code_Values.length) {
            for (var i = 0; i < code_Values.length; i++) {
                if (code_Values[i].checked) {
                    uId = datalist._Items[i].NickName;
                    break;
                }
            }
        }
        else {
            uId = datalist._Items[0].NickName;
        }
        //弹出编辑对话框
        modalEditUser();
    }
}
//设置密码
function setPass() {
    var arrayObj = new Array();　//创建一个数组
    //检查选择情况
    if (!checkItem()) {
        alert("请先选择");
    }
    else {
        var code_Values = document.all['checkboxitem'];
        if (code_Values.length) {
            for (var i = 0; i < code_Values.length; i++) {
                if (code_Values[i].checked) {
                    arrayObj.push(datalist._Items[i].NickName);
                }
            }
        }
        else {
            arrayObj.push(datalist._Items[0].NickName);
        }
        //将数组转换成字符串，以","隔开
        updatelist = arrayObj.join(",");
        //弹出设置密码对话框
        modalSetPass();
    }
}
//删除列表项
function deletelist() {
    var deletelist;
    var arrayObj = new Array();　//创建一个数组
    //检查选择情况
    if (!checkItem()) {
        alert("请先选择");
    }
    else {
        var code_Values = document.all['checkboxitem'];
        if (code_Values.length) {
            for (var i = 0; i < code_Values.length; i++) {
                if (code_Values[i].checked) {
                    arrayObj.push(datalist._Items[i].NickName);
                }
            }
        }
        else {
            arrayObj.push(datalist._Items[0].NickName);
        }
        //将数组转换成字符串，以","隔开
        deletelist = arrayObj.join(",");
        //弹出确认删除对话框
        confirmDialog(deletelist);
    }
}
//弹出添加用户对话框
function add() {
    $("#loginId").val("");
    $("#password").val("");
    $("#rePassword").val("");
    $("#fullName").val("");
    $("#remark").val("");
    $("#addUser").modal("show");
}
//添加用户
function addUser() {
    var userName = $("#loginId").val();
    var password = $("#password").val();
    var repassword = $("#rePassword").val();
    var fullName = $("#fullName").val();
    var remark = $("#remark").val();

    if (userName == null || userName=="") {
        layer.tips('用户名不能为空', $("#loginId"), {
            guide: 2,
            time: 2,
            style: ['background-color:#F26C4F; color:#fff', '#F26C4F'],
            maxWidth: 150
        });
    }
    else if (password != repassword) {
        layer.tips('两次输入的密码不一致', $("#rePassword"), {
            guide: 2,
            time: 2,
            style: ['background-color:#F26C4F; color:#fff', '#F26C4F'],
            maxWidth: 150
        });
    }
    else {
        $("#addBtn").button('loading');
        userBaseInfoService.AddUser(userName, password, fullName, remark,
            function (data, status) {
                if (data == "0") {
                    $("#addUser").modal("toggle");
                    alert("添加成功");
                }
                else if (data == "-5") {
                    alert("该用户名已被使用");
                }
                else {
                    alert("添加失败");
                }
                $("#addBtn").button('reset');
            });
    }
}
//弹出编辑用户对话框
function modalEditUser() {
    //根据账号获取对应用户信息
    userBaseInfoService.GetUserInfo(1, uId,
        function (data) {
            var userInfo = $.parseJSON(data); //转换为对象
            $("#fullName2").val(userInfo.FullName);
            $("#detail2").val(userInfo.Detail);
            userInfo.UStatus & 8 ? $("#isStop").attr("checked", true) : $("#isStop").attr("checked", false);
            $("#unitName").val(userInfo.Unit);
            $("#address").val(userInfo.Addr);
            $("#dept").val(userInfo.Dept);
            $("#job").val(userInfo.Job);
            $("#chief").val(userInfo.Chief);
            $("#contact").val(userInfo.Contact);
            $("#tel").val(userInfo.Tel1);
            $("#mob").val(userInfo.Mob1);
            $("#idcard").val(userInfo.IDCard);
            $("#imcode").val(userInfo.IMCode);
            $("#fax").val(userInfo.Fax);
            $("#zip").val(userInfo.Zip);
            $("#email").val(userInfo.EMail);
            $("#weburl").val(userInfo.WebURL);
            $("#remark").val(userInfo.Memo);
        });
    $('#userTab a:first').tab('show');//初始化显示哪个tab

    $('#userTab a').click(function (e) {
        e.preventDefault();//阻止a链接的跳转行为
        $(this).tab('show');//显示当前选中的链接及关联的content
    })
    $("#userId").html(uId);
    $("#editUser").modal("show");
}
//编辑用户
function editUser() {
    var baseUser = new BaseUserInfo();
    baseUser.FullName = $("#fullName2").val();
    baseUser.Detail =  $("#detail2").val();
    baseUser.IsLocked = $("#isStop").is(":checked");
    baseUser.Unit = $("#unitName").val();
    baseUser.Addr = $("#address").val();
    baseUser.Dept = $("#dept").val();
    baseUser.Job = $("#job").val();
    baseUser.Chief = $("#chief").val();
    baseUser.Contact = $("#contact").val();
    baseUser.Tel = $("#tel").val();
    baseUser.Mob = $("#mob").val();
    baseUser.IDCard = $("#idcard").val();
    baseUser.IMCode = $("#imcode").val();
    baseUser.Fax = $("#fax").val();
    baseUser.Zip = $("#zip").val();
    baseUser.EMail = $("#email").val();
    baseUser.WebUrl = $("#weburl").val();
    baseUser.Memo = $("#remark").val();

    var userJson = JSON.stringify(baseUser);
    $("#editBtn").button('loading');
    //提交修改
    userBaseInfoService.UpdateUserInfo(uId, userJson,
        function (data, status) {
            var code = parseInt(data);
            if (code == 1) {
                $("#editUser").modal("toggle");
                alert("修改成功！");
            }
            else {
                alert("编辑失败！");
            }
            $("#editBtn").button('reset');
        });
}
//弹出设置密码对话框
function modalSetPass() {
    $("#newPass").val("");
    $("#reNewPass").val("");
    $("#setPass").modal("show");
}
//设置用户密码
function setUserPass() {
    var newpass = $("#newPass").val();
    var renewpass = $("#reNewPass").val();
    if (newpass == "") {
        layer.tips('请输入新密码', $("#newPass"), {
            guide: 2,
            time: 2,
            style: ['background-color:#F26C4F; color:#fff', '#F26C4F'],
            maxWidth: 150
        });
    }
    else if (renewpass != newpass) {
        layer.tips('两次输入的密码不一致', $("#reNewPass"), {
            guide: 2,
            time: 2,
            style: ['background-color:#F26C4F; color:#fff', '#F26C4F'],
            maxWidth: 150
        });
    }
    else {
        $("#setpassbtn").button('loading');
        //提交修改
        userBaseInfoService.SetUserPass(updatelist, newpass,
             function (data, status) {
                    var code = parseInt(data);
                    if (code == 1) {
                        $("#setPass").modal("toggle");
                        alert("设置成功！");
                    }
                    else {
                        alert("设置失败！");
                    }
                    $("#setpassbtn").button('reset');
                });
    }
}
//删除列表
function DeleteList(list) {
    userBaseInfoService.DelUserList(list,
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