<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SelectHUser.aspx.cs" Inherits="Meeting_SelectHUser" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <link href="/bootstrap/3.2.0/css/bootstrap.min.css" rel="stylesheet" />
    <link href="/easyui/1.3.6/themes/bootstrap/easyui.css" rel="stylesheet" />
    <!-- EasyUI ICON图标 CSS 文件 -->
    <link rel="stylesheet" type="text/css" href="/CSS/public.css?t=<%=t_rand %>" />
    <link href='/CSS/userTree.css?t=' <%=t_rand %> rel="stylesheet" />
    <!-- 最新 EasyUI 核心 CSS 文件 -->
    <link href="/easyui/1.3.6/themes/icon.css?t=<%=t_rand %>" rel="stylesheet" />
    <script src="/jquery/1.8.3/jquery-1.8.2.min.js" type="text/javascript"></script>
    <script src="/easyui/1.3.6/jquery.easyui.min.js" type="text/javascript"></script>
    <script type="text/javascript" src="/Script/layer/layer.min.js"></script>
    <script type="text/javascript" src="/Script/My97DatePicker/WdatePicker.js"></script>
</head>
<body>
    <form id="rForm" runat="server">
        <div class="Main_Body">
            <div class="con_h">
                <div class="con_p"><span>人员列表</span></div>
                <div class="con_r"><span>接收人员</span></div>
            </div>
            <div class="con_s">
                <div class="con_Query">
                    <input type="text" id="txtPersonName" class="input inpute" />
                    <input type="button" id="btnSearch" class="btn btn_four" value="人员查询" />&nbsp;
                </div>
                <div class="con_temp">
                    <span>
                        <input type="button" id="btnSave" class="btn btn_four" value="保存模板" onclick="saveTemp();" /></span>
                    <input type="button" id="btnRead" class="btn btn_four" value="模板读入" onclick="showTempList();" />
                </div>
            </div>
            <div class="con_c">
                <div class="con_tree">
                    <div class="easyui-panel" style="border: none;height: 320px; " id="treeList">
                        <ul id="tt" class="easyui-tree" data-options="animate:true,cascadeCheck:false,lines:true">
                        </ul>
                    </div>
                </div>
                <div class="con_say">
                    <div id="yxry" class="con_person"></div>
                </div>
            </div>
            <div class="con_btn">
                <input type="button" id="btnSubmit" class="btn_submit con_oper_btn" value="提交" onclick="OnOK();"/>
                <input type="button" id="btnReturn" class="btn_back con_oper_btn" value="关闭" onclick="window.parent.doRefresh(); window.parent.layer.closeAll();" />
                <asp:HiddenField runat="server" ID="hidUserList" />
                <asp:HiddenField runat="server" ID="hidName" />
            </div>
        </div>
        <script>
            //获取当前窗口索引以便执行layer.close方法（"window.name"是固定写法，不是某个控件的ID，官方demo有错误）
            var valArr = [], returnVal = [];
            var val, nodes;
            $(function () {
                $("#tt").tree({
                    onClick: function (node) {
                        if (node.status == "person") {
                            valArr[0] = node.id;
                            returnVal[0] = node.text;
                            /***进行分配***/
                            $("#yxry").clearQueue();
                            $("#yxry").html("<a class='btn-default btn-block'>" + node.text + "<button id='" + node.id + "' name='" + node.status + "' type='button' class='close' title='关闭' onclick='mbtnClose(this);'><span aria-hidden='true'>&times;</span><span class='sr-only'>Close</span></button></a>");
                        }
                        else if (node.status == "department" && node.duid == null && node.duid.length > 0) {
                            valArr[0] = node.duid;
                            returnVal[0] = node.text;
                            /***进行分配***/
                            $("#yxry").clearQueue();
                            $("#yxry").html("<a class='btn-default btn-block'>" + node.text + "<button id='" + node.duid + "' name='" + node.status + "' type='button' class='close' title='关闭' onclick='mbtnClose(this);'><span aria-hidden='true'>&times;</span><span class='sr-only'>Close</span></button></a>");
                        }
                        else if (node.status == "department" && (node.duid == null || node.duid == "undefined" || node.duid.length == 0)) {
                            layer.alert("此部门没有指定接收人员!", 8);
                        }
                        
                        $("#hidUserList").val(valArr.join(","));
                        $("#hidName").val(returnVal.join(","))
                    },
                    method: 'get',
                    url: "/Ajax/Public_Tree.ashx?pageState=gwry&txt_name=" + encodeURIComponent($.trim($("#txtPersonName").val())) + "&action=Msg" + ""
                });

                /***查询***/
                $("#btnSearch").click(function () {
                    $("#tt").tree({
                        method: 'get',
                        url: "/Ajax/Public_Tree.ashx?pageState=gwry&txt_name=" + encodeURIComponent($.trim($("#txtPersonName").val())) + "&action=Msg" + ""
                    });
                    $("#yxry").html("");
                });
            })

            /***每个已选人员的关闭***/
            function mbtnClose(e) {
                $(e).parent("a").remove();
                valArr.splice(valArr.indexOf(e.id), 1);
                $("#hidUserList").val("");
                $("#hidUserList").val(valArr.join(","));
            }
            function hidTree() {
                $("#treeList").hide();
            }
            function OnOK() {
                //alert("_" + $("#hidName").val());
                window.parent.setHUser($("#hidUserList").val(), $("#hidName").val());
            }
            ///判断数组中是否存在该数据  存在返回true 否则返回false
            function contains(arr, obj) {
                for (var i = 0; i < arr.length; i++) {
                    if (arr[i] === obj) {
                        return true;
                    }
                }
                return false;
            }
            ///存入模板
            function saveTemp() {
                if ($("#hidUserList").val().length > 0) {
                    $.layer({
                        type: 2,
                        title: '新增模板',
                        iframe: { src: '/Archive/AddTemp.aspx?uIds=' + $("#hidUserList").val() },
                        maxmin: true,
                        area: ['410px', '130px'],
                        border: [1, 0.2, '#000', true],
                        offset: ['20px', '']
                    });
                }
                else {
                    layer.alert("请选择接收人员");
                }
            }
            ///弹出模板
            function showTempList() {
                $.layer({
                    type: 2,
                    title: '接收人员模板',
                    iframe: { src: '/Archive/selTempList.aspx?code=' + $("#hidCode").val() + "" },
                    maxmin: true,
                    area: ['510px', '530px'],
                    border: [1, 0.2, '#000', true],
                    offset: ['20px', '']
                });
            }
        </script>
        <script type="text/javascript">
            var arrId = [], arrName = [];
            function ShowTemp(ids, names) {
                arrId = ids.split(',');
                arrName = names.split(',');
                $("#hidUserList").val(ids);
                $("#hidName").val(names);
                for (var i = 0; i < arrName.length; i++) {
                    $("#yxry").append("<a class='btn-default btn-block'>" + arrName[i] + "<button id='" + arrId[i] + "' name='person' type='button' class='close' title='关闭' onclick='mbtnClose(this);'><span aria-hidden='true'>&times;</span><span class='sr-only'>Close</span></button></a>");
                }
                layer.closeAll();
            }
        </script>
    </form>
</body>
</html>
