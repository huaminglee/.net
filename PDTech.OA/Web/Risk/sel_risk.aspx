 <%@ Page Language="C#" AutoEventWireup="true" CodeFile="sel_risk.aspx.cs" Inherits="Risk_sel_risk" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge,chrome=1" />
    <!-- 移动设备优先 -->
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>新增风险处置单</title>
    <!-- 最新 Bootstrap 核心 CSS 文件 -->
    <link href="/bootstrap/3.2.0/css/bootstrap.min.css" rel="stylesheet" />
    <link rel="stylesheet" href="/CSS/public.css?t=" <%=t_rand %> />
    <link rel="stylesheet" href="/CSS/detail.css?t=" <%=t_rand %> />
    <script type="text/javascript" src="/jquery/1.8.3/jquery-1.8.2.min.js"></script>
    <script type="text/javascript" src="/Script/layer/layer.min.js"></script>
    <script type="text/javascript" src="/Script/My97DatePicker/WdatePicker.js"></script>
   
    <script type="text/javascript" src="/Script/handlers.js"></script>
    <script type="text/javascript" src="/Script/common.js"></script>
    <style type="text/css">
        .let2
        {
            letter-spacing: 2px;
        }

        .let6
        {
            letter-spacing: 6px;
        }
    </style>
</head>
<body>
    <form id="nForm" runat="server">
        <asp:ScriptManager ID="ScriptManager" runat="server">
        </asp:ScriptManager>
        <div class="main">
            <div class="content">
                <div class="container-fluid text-center thisPadding">
                    <h3>成都市水务局风险处置处理单</h3>
                    <hr />
                </div>
                <div class="con_b">
                    <table class="main_List" cellspacing="1" cellpadding="1" style="text-align: center" border="0">
                        <tr>
                            <td class="con_item" style="text-align:right;">
                                <span class="">风险等级</span>
                            </td>
                            <td class="con_item_left">
                                <asp:DropDownList ID="dplUrgency" runat="server"  CssClass="ddlinput input152">
                                </asp:DropDownList>
                            </td>
                            <td class="con_item" style="text-align:right;">
                                <span class="">业务类型</span>
                            </td>
                            <td class="con_item_left">
                                <asp:DropDownList ID="dplBusinessType" runat="server" CssClass="ddlinput input140">
                                </asp:DropDownList>
                            </td>

                        </tr>
                        <tr>
                            <td class="con_item" style="text-align:right;">
                                <span class="">业务件号</span></td>
                            <td class="con_item_left" colspan="1">
                                <asp:TextBox ID="txtBusinessNum" runat="server" CssClass="input input152"></asp:TextBox>
                                <asp:HyperLink ID="lbtnUrl" runat="server" Visible="false" ForeColor="blue"></asp:HyperLink>
                            </td>
                            <td class="con_item" style="text-align: right;">
                                <span>办理时间</span>
                            </td>
                            <td class="con_item_left">
                                <input type="text" id="txtHandleDate" runat="server" class="input input140" />
                                &nbsp;</td>
                        </tr>
                        <tr>

                            <td class="con_item" style="text-align:right;">
                                <span class="">责任人</span></td>
                            <td class="con_item_left" colspan="1">
                                <input type="text" runat="server" id="txtUserName" class="input input152" />
                            </td>
                            <td class="con_item" style="text-align: right;">
                                <span>所在部门</span></td>
                            <td class="con_item_left">
                                <asp:DropDownList runat="server" ID="dplDeptList" CssClass="ddlinput input140"></asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td class="con_item" style="text-align: right;">
                                <span>风险类别</span></td>
                            <td class="con_item_left" colspan="1">
                                <asp:DropDownList ID="dplRiskList" runat="server" CssClass="ddlinput input152">
                                </asp:DropDownList>
                            </td>
                            <td class="con_item" style="text-align: right;"><span>风险编号</span></td>
                            <td class="con_item_left"><input type="text" runat="server" id="txtSeqNum" class="input input140"/></td>
                        </tr>
                        <tr>
                            <td class="con_item" style="text-align:right;">
                                <span>标题</span>
                            </td>
                            <td class="con_item_left" colspan="3">
                                <asp:TextBox ID="txtTitle" runat="server" CssClass="input input724" MaxLength="50"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="con_item" style="text-align:right;">
                                <span>备注</span>
                            </td>
                            <td class="con_item_left" colspan="3">
                                <asp:TextBox ID="txtRemark" runat="server"  TextMode="MultiLine" CssClass="inputArea" MaxLength="999"></asp:TextBox>
                            </td>
                        </tr>
                        <tr runat="server" id="tr_showList" visible="false">
                            <td class="con_item"></td>
                            <td class="con_item" colspan="3">
                                <table class="GridTitleCss">
                                     <tr>
                                        <th style="width: 40%;">附件名称</th>
                                        <th style="width: 20%;">上传人员</th>
                                        <th style="width: 20%;">上传时间</th>
                                        <th style="width: 20%;" colspan="2">操作</th>
                                    </tr>
                                    <asp:Repeater ID="rpt_AttachmentList" runat="server" OnItemDataBound="rpt_AttachmentList_ItemDataBound">
                                        <ItemTemplate>
                                            <tr>
                                                <td>
                                                    <img src="../images/attachlogo.jpg" /><%# Eval("FILE_NAME") %></td>
                                                <td>
                                                    <%# Eval("FULL_NAME") %>
                                                </td>
                                                <td>
                                                    <%#AidHelp.ShortTime(Eval("CREATE_TIME")) %>
                                                </td>
                                                <td>
                                                    <asp:Label ID="lblPath" runat="server" Visible="false" Text='<%# Eval("FILE_PATH") %>'></asp:Label>
                                                    <asp:HyperLink runat="server" ID="hlDown" ForeColor="#215493" Font-Underline="false" Text="下载"></asp:HyperLink></td>
                                                <td>
                                                    <asp:LinkButton ID="lbDel" runat="server" CommandName="DelItem" ForeColor="#215493" Font-Underline="false" CommandArgument='<%# Eval("ATTACHMENT_FILE_ID") %>'>删除</asp:LinkButton></td>

                                            </tr>
                                        </ItemTemplate>
                                    </asp:Repeater>
                                </table>
                            </td>
                        </tr>

                    </table>
                </div>
                <div class="con_oper">
                    &nbsp;&nbsp;
                   
                    <input type="button" runat="server" id="btnProcess" onclick='ShowTheProcess()' value="办理流程" class="btn_Process con_oper_btn let2" />
                    <input type="button" id="btnReturn" class="btn_back con_oper_btn let6" value="关闭" onclick="CloseAllFrame();" />
                </div>
            </div>
        </div>
        <asp:UpdatePanel runat="server" ID="UpdatePanel">
            <ContentTemplate>
            </ContentTemplate>
        </asp:UpdatePanel>
        <div class="fieldset flash" id="fsUploadProgress">
            <span class="legend"></span>
        </div>
        <span class="uploadprogressbar" id="ID_uploadprogressbar"></span>
        <div id="divFileProgressContainer" style="height: 3px; display: none;">
        </div>
        <div id="thumbnails">
        </div>
        <script type="text/javascript">
            //查看流程
            function ShowTheProcess() {
                var arid =<%=arId%>
                window.location.href = "FortheProcess.aspx?ArId=" + arid;
            }
            function hideAtt() {
                $("#tr_Att").hide();
            }
            ///页面卸载的时候执行
            function CloseAllFrame() {
                window.parent.layer.closeAll();
            }
        </script>
    </form>
</body>
</html>
