var datalist, obj, strTable = "", pageSize = 10, currentPage = 1, totalNum = 0;
var allUsers;//所有用户
var members;//所有成员
var paramStr = null
var userParam = "";
var roleName = "";
var userBaseInfoService = new UserBaseInfoService();

$(function () {
    initlist();
});
//初始化分页
function initlist() {
    userBaseInfoService.QueryRoleCount(paramStr, 0,
        function (data, status) {
            totalNum = data;
            if (totalNum > 0) {
                pageList(paramStr, currentPage, pageSize, true);
            }
            else {
                $("#tb_rolelist").html("");
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
            pageList(paramStr, page, pageSize, false)
            return true;//必写！否则点击下一页时无效！
        }
    });
}
//查询分页
function querylist() {
    paramStr = $("#name_search").val();
    initlist();
}

//分页查询角色信息
function pageList(queryStr, pageIndex, pageSize, isPage) {
    userBaseInfoService.GetRoleList(queryStr, (pageIndex - 1) * pageSize, pageSize, 0,
        function (data, status) {
            datalist = $.parseJSON(data);//转换出总条数
            var curtotalNum = datalist._Items.length;//总条数
            if (curtotalNum > 0) {
                obj = datalist._Items;//转换出数据源
                $.each(obj, function (i) {
                    strTable += "<tr>" +
                        "<td style='width:5%;text-align:center'><input type='checkbox' id='checkboxitem'></td>" +
                        "<td style='width:10%;text-align:center'>" + (((pageIndex - 1) * pageSize) + (i + 1)) + "</td>" +
                        "<td style='width:35%;text-align:center'>" + obj[i].LoginID + "</td>" +
                        "<td style='width:50%;text-align:center'>" + (obj[i].Detail == null ? "" : obj[i].Detail) + "</td>" +
                        + "</tr>";
                });
                $("#tb_rolelist").html(strTable);
                strTable = "";
                if (isPage) {
                    pagination();//分页
                }
            }
            else {
                $("#tb_rolelist").html(strTable);
            }
        });
}

//弹出添加角色对话框
function add() {
    $("#roleName").val("");
    $("#remark").val("");
    $("#addRole").modal("show");
}
//添加角色
function addRole() {
    var roleName = $("#roleName").val();
    var remark = $("#remark").val();

    if (roleName == null || roleName == "") {
        layer.tips('角色名不能为空', $("#roleName"), {
            guide: 2,
            time: 2,
            style: ['background-color:#F26C4F; color:#fff', '#F26C4F'],
            maxWidth: 150
        });
    }
    else {
        $("#addBtn").button('loading');
        userBaseInfoService.AddRole(roleName, remark, 0,
            function (data, status) {
                if (data == "0") {
                    //重新刷新列表
                    initlist();
                    $("#addRole").modal("toggle");
                }
                else if (data == "-35") {
                    alert("该角色名已被使用");
                }
                else {
                    alert("添加失败");
                }
                $("#addBtn").button('reset');
            });
    }
}
//编辑角色
function edit() {
    var roleName;
    var roleDetail;
    //检查选择情况
    if (!checkItem()) {
        alert("请先选择");
    }
    else {
        var code_Values = document.all['checkboxitem'];
        if (code_Values.length) {
            for (var i = 0; i < code_Values.length; i++) {
                if (code_Values[i].checked) {
                    roleName = datalist._Items[i].LoginID;
                    roleDetail = datalist._Items[i].Detail;
                    break;
                }
            }
        }
        else {
            roleName = datalist._Items[0].LoginID;
            roleDetail = datalist._Items[0].Detail;
        }
        //弹出编辑对话框
        modalEditRole(roleName, roleDetail);
    }
}
//弹出编辑角色对话框
function modalEditRole(name,detail) {
    $("#roleName2").html(name);
    $("#detail").val(detail);
    $("#editRole").modal("show");
}
//编辑角色
function editRole() {
    var rolename = $("#roleName2").html();
    var detail = $("#detail").val();
    $("#editBtn").button('loading');
    //提交修改
    userBaseInfoService.UpdateRoleInfo(rolename, detail,
        function (data, status) {
            var code = parseInt(data);
            if (code == 0) {
                //重新刷新列表
                initlist();
                $("#editRole").modal("toggle");
            }
            else {
                alert("修改失败！");
            }
            $("#editBtn").button('reset');
        });
}
//删除角色
function del() {
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
                    arrayObj.push(datalist._Items[i].LoginID);
                }
            }
        }
        else {
            arrayObj.push(datalist._Items[0].LoginID);
        }
        //将数组转换成字符串，以","隔开
        deletelist = arrayObj.join(",");
        //弹出确认对话框
        layer.confirm('确认要删除该角色吗？', function (index) {
            layer.closeAll();
            userBaseInfoService.DelRole(deletelist, 0,
                function (data, status) {
                    if (data == '"ok"') {
                        //重新刷新列表
                        initlist();
                    }
                    else {
                        alert("删除失败！");
                    }
                });
        });
    }
}
//新增成员
function addMember() {
    //检查选择情况
    if (!checkItem()) {
        alert("请先选择");
    }
    else {
        var code_Values = document.all['checkboxitem'];
        if (code_Values.length) {
            for (var i = 0; i < code_Values.length; i++) {
                if (code_Values[i].checked) {
                    roleName = datalist._Items[i].LoginID;
                    break;
                }
            }
        }
        else {
            roleName = datalist._Items[0].LoginID;
        }
        //弹出成员列表对话框
        modalAllMembers();
    }
}
//弹出成员列表对话框
function modalAllMembers() {
    //初始化所有用户
    $("#userparam").val("");
    queryUsers();
    //初始化成员列表
    getAllMembers();
    $("#addMembers").modal("show");
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
            listStr += "<a href='#' class='list-group-item'><span class='glyphicon glyphicon-plus pull-right' onclick='addUserToMember(" + i + ")'></span>" + (obj[i].NickName + (obj[i].FullName == null ? "  " : "  (" + obj[i].FullName + ")")) + "</a>";
        });
        $("#tb_userlist").html(listStr);
    }
    else {
        $("#tb_userlist").html(listStr);
    }
}
//获取所有成员
function getAllMembers() {
    $("#tb_memberlist").html("<img src='/Image/loading.gif' style='margin-left: 190px; margin-top: 160px;' />");
    userBaseInfoService.GetRoleUsers(roleName, 0,
        function (data, status) {
            if (data != null && data != "") {
                members = $.parseJSON(data);//转换出总条数
                //初始化成员列表
                initMemberList();
            }
            else {
                $("#tb_memberlist").html("");
            }
        });
}
//初始化成员列表
function initMemberList() {
    var listStr = "";
    var curtotalNum = members._Items.length;//总条数
    if (curtotalNum > 0) {
        obj = members._Items;//转换出数据源
        $.each(obj, function (i) {
            listStr += "<a href='#' class='list-group-item'><span class='glyphicon glyphicon-remove pull-right' onclick='removeMember(" + i + ")'></span>" + (obj[i].NickName + (obj[i].FullName == null ? "  " : "  (" + obj[i].FullName + ")")) + "</a>";
        });
        $("#tb_memberlist").html(listStr);
    }
    else {
        $("#tb_memberlist").html(listStr);
    }
}
//添加用户到成员
function addUserToMember(i) {
    obj = allUsers._Items;//转换出数据源
    //不存在成员列表才添加
    if (!isRepeat(obj[i], members._Items)) {
        members._Items.unshift(obj[i]);
    }
    //重新绘制成员列表
    initMemberList();
}
//删除成员
function removeMember(i) {
    members._Items.splice(i,1);//删除指定下标元素
    //重新绘制成员列表
    initMemberList();
}
//获取成员SID字符串
function getMemberIds() {
    var uIDs = "";
    var arrayObj = new Array();　//创建一个数组

    obj = members._Items;//转换出数据源
    $.each(obj, function (i) {
        arrayObj.push(obj[i].SID);
    });
    //将数组转换成字符串，以","隔开
    uIDs = arrayObj.join(",");
    //返回结果
    return uIDs;
}
//保存修改结果
function saveUpdate() {
    //取出用户ID列表字符串
    var uIDs = getMemberIds();
    $("#updateBtn").button('loading');
    userBaseInfoService.UpdateRolesUsers(roleName, uIDs,
        function (data, status) {
            var code = parseInt(data);
            if (code == 1) {
                $("#addMembers").modal("toggle");
                alert("修改成功！");
            }
            else {
                alert("修改失败！");
            }
            $("#updateBtn").button('reset');
        });
}
//判断是否有相同元素
function isRepeat(obj,arry)
{
    for (var i in arry) {
        if(obj.NickName==arry[i].NickName) 
            return true;
    }
    return false;
}