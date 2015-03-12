var allUsers = null;//所有用户
var members = null;//所有成员
var userParam = "";
var deptId = "";
var userBaseInfoService = new UserBaseInfoService();

//获取部门列表
function initDeptTree(parent) {
    userBaseInfoService.GetDeptList(parent,
       function (data, status) {
           var objTemp = $.parseJSON(data);//转换出总条数
           obj = objTemp._Items;//转换出数据源
           var curtotalNum = obj.length;//总条数
           if (curtotalNum > 0) {
               $.each(obj, function (i) {
                   var node = "{\"id\":" + obj[i].SID + ",\"pId\": " + obj[i].ParentID + ",\"name\": \"" + obj[i].LoginID + "\",\"isAddState\":false}";
                   zNodes.push($.parseJSON(node));
               });
           }
           else {
               zNodes = null;
           }
           $.fn.zTree.init($("#treeDemo"), setting, zNodes);
       });
}
//新增部门
function addDept(treeNode, deptID, detail) {
    var parentId = "";
    if (treeNode.getParentNode()) {
        parentId = treeNode.getParentNode().name;
    }
    var deptinfo = new BaseDeptInfo();
    deptinfo.LoginID = deptID;
    deptinfo.FullName = deptID
    deptinfo.Detail = detail;
    var deptJson = JSON.stringify(deptinfo);
    userBaseInfoService.AddDept(parentId, deptJson, 1,
           function (data, status) {
               var code = parseInt(data);
               if (code == 1) {
                   layer.tips("添加 " + deptID + " 失败", $("#" + treeNode.tId + "_span"), {
                       guide: 1,
                       time: 2,
                       style: ['background-color:#F26C4F; color:#fff'],
                       maxWidth: 150
                   });
                  
               }
               else if (code == -35) {
                   layer.tips(deptID + " 已存在", $("#" + treeNode.tId + "_span"), {
                       guide: 1,
                       time: 2,
                       style: ['background-color:#F26C4F; color:#fff'],
                       maxWidth: 150
                   });
               }
               else {
                   treeNode.id = code;
                   treeNode.name = deptID;
                   treeNode.isAddState = false;
                   var zTree = $.fn.zTree.getZTreeObj("treeDemo");
                   var checkTypeFlag = $("#callbackTrigger").attr("checked");
                   zTree.updateNode(treeNode, checkTypeFlag);
                   zTree.refresh();
                   layer.tips("添加 " + deptID + " 成功", $("#" + treeNode.tId + "_span"), {
                       guide: 1,
                       time: 2,
                       style: ['background-color:green; color:#fff'],
                       maxWidth: 150
                   });
               }
           });
}
//修改部门名称
function editDept(treeNode, deptID, detail) {
    var deptinfo = new BaseDeptInfo();
    deptinfo.SID = treeNode.id;
    deptinfo.LoginID = deptID;
    deptinfo.FullName = deptID
    deptinfo.Detail = detail;
    var deptJson = JSON.stringify(deptinfo);
    userBaseInfoService.UpdateDeptInfo(deptJson, 1,
        function (data, status) {
            var code = parseInt(data);
            if (code == 1) {
                layer.tips("修改失败", $("#" + treeNode.tId + "_span"), {
                    guide: 1,
                    time: 2,
                    style: ['background-color:#F26C4F; color:#fff'],
                    maxWidth: 150
                });
            }
            else if (code == -35) {
                layer.tips(deptID + " 已存在", $("#" + treeNode.tId + "_span"), {
                    guide: 1,
                    time: 2,
                    style: ['background-color:#F26C4F; color:#fff'],
                    maxWidth: 150
                });
            }
            else {
                treeNode.name = deptID;
                var zTree = $.fn.zTree.getZTreeObj("treeDemo");
                var checkTypeFlag = $("#callbackTrigger").attr("checked");
                zTree.updateNode(treeNode, checkTypeFlag);
                zTree.refresh();
                layer.tips("修改成功", $("#" + treeNode.tId + "_span"), {
                    guide: 1,
                    time: 2,
                    style: ['background-color:green; color:#fff'],
                    maxWidth: 150
                });
            }
        });
}
//删除部门
function delDept(zTree){
    nodes = zTree.getSelectedNodes(),
    treeNode = nodes[0];
    if (nodes.length == 0) {
        alert("请先选择一个节点");
        return;
    }
    else if (treeNode.id==0) {
        return;
    }
    var callbackFlag = $("#callbackTrigger").attr("checked");
    if (confirm("确认删除 " + treeNode.name + " 吗？")) {
        userBaseInfoService.DelDept(treeNode.name, 1,
        function (data, status) {
            var code = parseInt(data);
            if (code == 0) {
                zTree.removeNode(treeNode, callbackFlag);
            }
            else if (code == -48) {
                layer.tips(treeNode.name + " 下存在子部门，不能被删除", $("#" + treeNode.tId + "_span"), {
                    guide: 1,
                    time: 2,
                    style: ['background-color:#F26C4F; color:#fff'],
                    maxWidth: 400
                });
            }
            else {
                layer.tips(treeNode.name + " 删除失败", $("#" + treeNode.tId + "_span"), {
                    guide: 1,
                    time: 2,
                    style: ['background-color:#F26C4F; color:#fff'],
                    maxWidth: 150
                });
            }
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
    userBaseInfoService.GetDeptUsers(deptId, 0,
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
    if (allUsers != null) {
        obj = allUsers._Items;//转换出数据源
    }
    if (members != null) {
        //不存在成员列表才添加
        if (!isRepeat(obj[i], members._Items)) {
            members._Items.unshift(obj[i]);
        }
        //重新绘制成员列表
        initMemberList();
    }
}
//删除成员
function removeMember(i) {
    if (members != null) {
        members._Items.splice(i, 1);//删除指定下标元素
        //重新绘制成员列表
        initMemberList();
    }
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
function saveMember() {
    if (members!=null) {
        //取出用户ID列表字符串
        var uIDs = getMemberIds();
        $("#saveUpdateBtn").button('loading');
        userBaseInfoService.UpdateDeptUsers(deptId, uIDs,
            function (data, status) {
                var code = parseInt(data);
                if (code == 1) {
                    alert("保存成功！");
                }
                else {
                    alert("保存失败！");
                }
                $("#saveUpdateBtn").button('reset');
            });
    }
    else {
        alert("请先选择一个部门");
    }
}
//判断是否有相同元素
function isRepeat(obj, arry) {
    for (var i in arry) {
        if (obj.NickName == arry[i].NickName)
            return true;
    }
    return false;
}