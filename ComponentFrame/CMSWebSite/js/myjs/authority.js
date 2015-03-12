var allRoles;
var allUsers;
var curUsers={ "MaxID": 0, "_Items": [{"SID":0}]};
var curRoles = { "MaxID": 0, "_Items": [{"SID":0}]};
var actid;
var userBaseInfoService = new UserBaseInfoService();

function GetRightsList() {
    var zNodes = [];
    userBaseInfoService.GetRighstList(1, 0, 0, -1, 0,
      function (data, status) {
          var objTemp = $.parseJSON(data);//转换出总条数
          obj = objTemp._Items;//转换出数据源
          var curtotalNum = obj.length;//总条数
          if (curtotalNum > 0) {
              $.each(obj, function (i) {
                  var icoopen, icoclose;

                  icoopen = "/App_Resources/zTree_v3/css/zTreeStyle/img/diy/1_open.png";
                  icoclose = "/App_Resources/zTree_v3/css/zTreeStyle/img/diy/1_close.png";
                  var node = "{\"id\":" + obj[i].ActID + ",\"pId\": " + obj[i].ParentID + ",\"name\": \"" + obj[i].Detail + "\",\"iconOpen\":\"" + icoopen + "\",\"iconClose\":\"" + icoclose + "\",\"isnewadd\":0}";
                  zNodes.push($.parseJSON(node));
              });
              $.fn.zTree.init($("#treeDemo"), setting, zNodes);
          }
          else {
              zNodes = null;
          }
      });
}
function getAllUsers(userParam) {
    $("#tb_userlist").html("<img src='/Image/loading.gif' style='margin-left: 190px; margin-top: 120px;' />");
    userBaseInfoService.GetAllUserandRoleList(userParam,
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
            listStr += "<a href='#' class='list-group-item'><span class='glyphicon glyphicon-plus pull-right' onclick='addUserToMember(" + i + ")'></span>" + (obj[i].LoginID + (obj[i].FullName == null ? "  " : "  (" + obj[i].FullName + ")")) + "</a>";
        });
        $("#tb_userlist").html(listStr);
    }
    else {
        $("#tb_userlist").html(listStr);
    }
}
function getAllRoles(RoleParam) {
    $("#tb_userlist").html("<img src='/Image/loading.gif' style='margin-left: 190px; margin-top: 120px;' />");
    userBaseInfoService.GetRoleList(RoleParam, 0, -1, 0,
        function (data, status) {
            if (data != null && data != "") {
                allRoles = $.parseJSON(data);//转换出总条数
                //初始化用户列表
                initRoleList();
            }
            else {
                $("#tb_rolelist").html(data);
            }
        });
}
//初始化用户列表
function initRoleList() {
    var listStr = "";
    var curtotalNum = allRoles._Items.length;//总条数
    if (curtotalNum > 0) {
        obj = allRoles._Items;//转换出数据源
        $.each(obj, function (i) {
            
            listStr += "<a href='#' class='list-group-item'><span class='glyphicon glyphicon-plus pull-right' onclick='addRoleToMember(" + i + ")'></span>" + (obj[i].LoginID + (obj[i].Detail == null ? "  " : "(" + obj[i].Detail + ")")) + "</a>";
            });
        $("#tb_rolelist").html(listStr);
    }
    else {
        $("#tb_rolelist").html(listStr);
    }
}
//添加用户到成员
function addUserToMember(i) {
    obj = allUsers._Items;//转换出数据源
    //不存在成员列表才添加
    if (!isRepeat(obj[i], curUsers._Items)) {
        curUsers._Items.unshift(obj[i]);
    }
    //重新绘制成员列表
    afteradduser();
}
//添加角色到成员
function addRoleToMember(i) {
    obj = allRoles._Items;//转换出数据源
    //不存在成员列表才添加
    if (!isRepeat(obj[i], curRoles._Items)) {
        curRoles._Items.unshift(obj[i]);
    }
    //重新绘制成员列表
    afteraddrole();
}
//删除成员
function removeUser(i) {
    curUsers._Items.splice(i, 1);//删除指定下标元素
    //重新绘制成员列表
    initMemberList();
}
function removeRole(i) {
    curRoles._Items.splice(i, 1);//删除指定下标元素
    //重新绘制成员列表
    initMemberList();
}
//获取成员SID字符串
function getMemberIds() {
    var uIDs = "";
    var arrayObj = new Array();　//创建一个数组

    obj = curUsers._Items;//转换出数据源
    $.each(obj, function (i) {
        if (obj[i].SID != "0") {
            arrayObj.push(obj[i].SID);
        }
    });
    obj2 = curRoles._Items;//转换出数据源
    $.each(obj2, function (i) {
        if (obj2[i].SID != "0") {
            arrayObj.push(obj2[i].SID);
        }
    });
    //将数组转换成字符串，以","隔开
    uIDs = arrayObj.join(",");
    //返回结果
    return uIDs;
}
//保存修改结果
function saveUpdate() {
    if(actid!=undefined){
    //取出用户ID列表字符串
    var uIDs = getMemberIds();
    $("#updateBtn").button('loading');
    userBaseInfoService.UpdateRightUsers(actid, uIDs,
        function (data, status) {
            var code = parseInt(data);
            if (code == 1) {
                $("#addMembers").modal("toggle");
                curRoles = { "MaxID": 0, "_Items": [{ "SID": 0 }] };
                alert("保存成功");
            }
            else {
                alert("保存失败");
            }
            $("#updateBtn").button('reset');
        });
    }
    else {
        alert("请先选择一个节点");
    }
}
//判断是否有相同元素
function isRepeat(obj, arry) {
    for (var i in arry) {
        if (obj.SID == arry[i].SID)
            return true;
    }
    return false;
}
function GetRightUsers(ActID) {
    userBaseInfoService.GetRightsUsers(ActID, 0,
      function (data, status) {
          var listStr = "";
          if (data != "") {
              curUsers = $.parseJSON(data);//转换出总条数
              obj = curUsers._Items;//转换出数据源
              
              var curtotalNum = obj.length;//总条数
              if (curtotalNum > 0) {
                  $.each(obj, function (i) {
                      listStr += "<a href='#' class='list-group-item'><span class='glyphicon glyphicon-remove pull-right' onclick='removeUser(" + i + ")'></span>" + obj[i].LoginID + "(" + obj[i].FullName + ")" + "</a>";
                  });
              }
          }        

          $("#rightusers").html(listStr);

      });
}
function afteradduser() {
    var listStr = "";
    var curtotalNum = curUsers._Items.length;//人员总条数
    if (curtotalNum > 0) {
        obj = curUsers._Items;//转换出数据源
        $.each(obj, function (i) {
            if (obj[i].SID != "0") {
                listStr += "<a href='#' class='list-group-item'><span class='glyphicon glyphicon-remove pull-right' onclick='removeUser(" + i + ")'></span>" + obj[i].LoginID + "(" + obj[i].FullName + ")" + "</a>";
            }
            });
    }    
    $("#rightusers").html(listStr);
}
function afteraddrole() {
    var listStr = "";

    var curtotalNum = curRoles._Items.length;//角色总条数
    if (curtotalNum > 0) {
        obj = curRoles._Items;//转换出数据源
        $.each(obj, function (i) {
            if (obj[i].SID != "0") {
                listStr += "<a href='#' class='list-group-item'><span class='glyphicon glyphicon-remove pull-right' onclick='removeRole(" + i + ")'></span>" + obj[i].LoginID + "(" + obj[i].Detail + ")" + "</a>";
            }
        });
    }
    var curtotalNum = curUsers._Items.length;//人员总条数
    if (curtotalNum > 0) {
        obj = curUsers._Items;//转换出数据源
        $.each(obj, function (i) {
            if (obj[i].SID != "0") {
                listStr += "<a href='#' class='list-group-item'><span class='glyphicon glyphicon-remove pull-right' onclick='removeUser(" + i + ")'></span>" + obj[i].NickName + "(" + obj[i].FullName + ")" + "</a>";
            }
            });
    }
    $("#rightusers").html(listStr);
}
function initMemberList() {
    var listStr = "";
    var curtotalNum = curUsers._Items.length;//人员总条数
    if (curtotalNum > 0) {
        obj = curUsers._Items;//转换出数据源
        $.each(obj, function (i) {
            if (obj[i].SID != "0") {
                listStr += "<a href='#' class='list-group-item'><span class='glyphicon glyphicon-remove pull-right' onclick='removeUser(" + i + ")'></span>" + obj[i].LoginID + "(" + obj[i].FullName + ")" + "</a>";
            }
            });
    }
    $("#rightusers").html(listStr);
}
function insertright(pid, rightsname, treeNode) {
    userBaseInfoService.AddRights(pid, 0, 1, rightsname, "",
      function (data, status) {
          var listStr = "";
          if (data == "-43") {
              layer.tips('保存失败,权限名已存在', $("[title='" + rightsname + "']"), {
                  guide: 1,
                  time: 2,
                  style: ['background-color:red; color:#fff'],
                  maxWidth: 150
              });
              var zTree = $.fn.zTree.getZTreeObj("treeDemo");
              zTree.removeNode(treeNode, true);
              
          }
          else if (data <= "0") {
              layer.tips('保存失败', $("[title='" + rightsname + "']"), {
                  guide: 1,
                  time: 2,
                  style: ['background-color:red; color:#fff'],
                  maxWidth: 150
              });
              var zTree = $.fn.zTree.getZTreeObj("treeDemo");
              zTree.removeNode(treeNode, true);
          }
          else {
              layer.tips('保存成功', $("[title='" + rightsname + "']"), {
                  guide: 1,
                  time: 2,
                  style: ['background-color:green; color:#fff'],
                  maxWidth: 150
              });
              treeNode.id = data;
              treeNode.isnewadd = 0;
              
              var sObj = $.fn.zTree.getZTreeObj("treeDemo");
              sObj.updateNode(treeNode);
          }
                   
      });
}
function deleright(rightsname) {
    userBaseInfoService.DelRights(rightsname, 0,
      function (data, status) {
          var listStr = "";
          if (data != "0") {
              alert("删除成功");
              //GetRightsList();
          }
          else {
              alert("删除失败");
          }

      });
}
function updateright(rightname, rightid, oldname, treeNode) {
    var baseright = new BaseRightsInfo();
    baseright.ActID = rightid;
    baseright.Detail = rightname;
    var rightjson = JSON.stringify(baseright);
    userBaseInfoService.UpdateRightsInfo(rightid, rightjson, 0,
        function (data, status) {
            var code = parseInt(data);
            if (code == -47) {
                layer.tips('修改失败,名称已存在', $("[title='" + rightname + "']"), {
                    guide: 1,
                    time: 2,
                    style: ['background-color:red; color:#fff'],
                    maxWidth: 150
                });
                var sObj = $.fn.zTree.getZTreeObj("treeDemo");
                treeNode.name = oldname;
                sObj.updateNode(treeNode);
            }
            else if (code == 1) {                 
                layer.tips('修改成功', $("[title='" + rightname + "']"), {
                    guide: 1,
                    time: 2,
                    style: ['background-color:green; color:#fff'],
                    maxWidth: 150
                });
            }
            else {
                layer.tips('修改失败', $("[title='" + rightname + "']"), {
                    guide: 1,
                    time: 2,
                    style: ['background-color:red; color:#fff'],
                    maxWidth: 150
                });
                var sObj = $.fn.zTree.getZTreeObj("treeDemo");
                treeNode.name = oldname;
                sObj.updateNode(treeNode);
            }             
        });
}