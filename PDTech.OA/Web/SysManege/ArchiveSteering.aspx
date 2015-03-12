<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ArchiveSteering.aspx.cs" Inherits="SysManege_ArchiveSteering" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge,chrome=1" />
    <!-- 移动设备优先 -->
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>新工作普通办件</title>
    <!-- 最新 Bootstrap 核心 CSS 文件 -->
    <link href="/bootstrap/3.2.0/css/bootstrap.min.css" rel="stylesheet" />
    <link href="/easyui/1.3.6/themes/bootstrap/easyui.css" rel="stylesheet" />
    <!-- EasyUI ICON图标 CSS 文件 -->
    <link rel="stylesheet" type="text/css" href="/CSS/public.css?t=<%=t_rand %>" />
    <link href='/CSS/Recipient.css?t=' <%=t_rand %> rel="stylesheet" />
    <!-- 最新 EasyUI 核心 CSS 文件 -->
    <link href="/easyui/1.3.6/themes/icon.css?t=<%=t_rand %>" rel="stylesheet" />
    <script src="/jquery/1.8.3/jquery-1.8.2.min.js" type="text/javascript"></script>
    <script src="/easyui/1.3.6/jquery.easyui.min.js" type="text/javascript"></script>
    <script type="text/javascript" src="/Script/layer/layer.min.js"></script>
    <script type="text/javascript" src="/Script/My97DatePicker/WdatePicker.js"></script>
</head>
<body>
    <form id="nForm" runat="server">

        <div class="Main_Body_u">
            <div class="con_t">
                <div class="con_tips_t">
                    <asp:Label ID="lbTitle" runat="server" Text="工作流程转向" Font-Size="18px"></asp:Label>
                </div>
                <table cellspacing="1" cellpadding="1" class="main_List">
                    <tr>
                        <td style="text-align: right;"><span>工作流程:&emsp;</span></td>
                        <td style="text-align: left;"><span>&emsp;<asp:Label ID="lbType" runat="server" Text=""></asp:Label></span></td>

                    </tr>
                    <tr>
                        <td style="text-align: right;"><span>当前办理人员:&emsp;</span></td>
                        <td style="text-align: left;"><span>&emsp;<asp:Label ID="lbUser" runat="server" Text=""></asp:Label></span></td>
                    </tr>
                    <tr>
                        <td style="text-align: right;"><span>选择业务步骤:&emsp;</span></td>
                        <td style="text-align: left;"><span>&emsp;<asp:DropDownList ID="dplStemp" runat="server" OnSelectedIndexChanged="dplStemp_SelectedIndexChanged" AutoPostBack="True" Height="30px"></asp:DropDownList></span></td>
                    </tr>
                </table>
            </div>
            <div class="con_h_s">
                <div class="con_r_s"><span>人员列表</span></div>
                <div class="con_r_r"><span>接收人员</span></div>
            </div>
            <div class="con_c_s">
                <div class="con_c_tree">
                    <div class="con_sel">
                        <span>
                            <asp:TextBox runat="server" ID="txtuName" CssClass="input input120"></asp:TextBox></span>
                        <span>
                            <input type="button" id="btnSearch" class="btn btn_four" value="人员查询" /></span>
                    </div>
                    <div class="easyui-panel" style="border: none; height: 310px;" id="treeList">
                        <ul id="tt" class="easyui-tree" data-options="animate:true,cascadeCheck:false,lines:true">
                        </ul>
                    </div>
                </div>
                <div class="con_c_selected">
                    <div id="yxry" class="con_person_s"></div>
                    <div class="con_r_b"><span>跳转原因</span></div>
                    <div class="con_remark">
                        <span>
                            <asp:TextBox runat="server" ID="txtRemark" TextMode="MultiLine" CssClass="inputArea240_130" Style="resize: none;"></asp:TextBox>
                        </span>
                    </div>
                </div>

            </div>
            <div class="con_btn_b">
                <asp:Button ID="btnSubmit" runat="server" CssClass="btn_submit con_oper_btn" OnClick="btnSubmit_Click" Text="提交" />&nbsp;&nbsp;
                <input type="button" id="btnReturn" class="btn_back con_oper_btn" value="关闭" onclick="window.parent.layer.closeAll();" />
            </div>
        </div>
        <asp:HiddenField runat="server" ID="hidUserList" />
        <asp:HiddenField runat="server" ID="hidStemp" />
        <script type="text/javascript">
            //获取当前窗口索引以便执行layer.close方法（"window.name"是固定写法，不是某个控件的ID，官方demo有错误）
            var valArr = [], returnVal = [];
            var val, nodes;
            $(function () {
                $("#tt").tree({
                    onClick: function (node) {
                        if (node.status == "person") {
                            valArr[0] = node.id;
                            /***进行分配***/
                            $("#yxry").clearQueue();
                            $("#yxry").html("<a class='btn-default btn-block'>" + node.text + "<button id='" + node.id + "' name='" + node.status + "' type='button' class='close' title='关闭' onclick='mbtnClose(this);'><span aria-hidden='true'>&times;</span><span class='sr-only'>Close</span></button></a>");
                        }
                        else if (node.status == "department" && node.duid != null && node.duid.length > 0) {
                            valArr[0] = node.duid;
                            /***进行分配***/
                            $("#yxry").clearQueue();
                            $("#yxry").html("<a class='btn-default btn-block'>" + node.text + "<button id='" + node.duid + "' name='" + node.status + "' type='button' class='close' title='关闭' onclick='mbtnClose(this);'><span aria-hidden='true'>&times;</span><span class='sr-only'>Close</span></button></a>");
                        }
                        else if (node.status == "department" && (node.duid == null || node.duid == "undefined" || node.duid.length == 0)) {
                            layer.alert("此部门没有指定接收人员!", 8);
                        }
                        $("#hidUserList").val(valArr.join(","));
                    },
                    method: 'get',
                    url: "/Ajax/Public_Treeo.ashx?pageState=gwry&txt_name=" + $.trim($("#txtuName").val()) + "&stemp=" + $("#hidStemp").val() + ""
                });

                /***查询***/
                $("#btnSearch").click(function () {
                    $("#tt").tree({
                        method: 'get',
                        url: "/Ajax/Public_Treeo.ashx?pageState=gwry&txt_name=" + $("#txtuName").val() + "&stemp=" + $("#hidStemp").val() + ""
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
            ///
            function onRefresh() {
                $("#tt").tree({
                    method: 'get',
                    url: "/Ajax/Public_Treeo.ashx?pageState=gwry&txt_name=" + $("#txtuName").val() + "&stemp=" + $("#hidStemp").val() + ""
                });
                $("#yxry").html("");
            }
        </script>
    </form>
</body>
</html>
