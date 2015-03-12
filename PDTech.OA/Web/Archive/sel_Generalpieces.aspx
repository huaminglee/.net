<%@ Page Language="C#" AutoEventWireup="true" CodeFile="sel_Generalpieces.aspx.cs" Inherits="Archive_sel_Generalpieces" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge,chrome=1" />
    <!-- 移动设备优先 -->
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>新工作一般阅件</title>
    <!-- 最新 Bootstrap 核心 CSS 文件 -->
    <link href="/bootstrap/3.2.0/css/bootstrap.min.css" rel="stylesheet" />
    <link rel="stylesheet" href="/CSS/public.css?t=" <%=t_rand %> />
    <link rel="stylesheet" href="/CSS/detail.css?t=" <%=t_rand %> />
    <script type="text/javascript" src="/jquery/1.8.3/jquery-1.8.2.min.js"></script>
    <script type="text/javascript" src="/Script/layer/layer.min.js"></script>
    <script type="text/javascript" src="/Script/handlers.js"></script>

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
                    <%--<span runat="server" id="tipInfo"></span>--%>
                    <h3 id="title" runat="server"></h3>
                    <hr />
                </div>
                <div class="con_b">
                    <table class="main_List" width="99%"  cellspacing="1" cellpadding="1" style="text-align: center" border="0">
                        <tr>
                            <td class="con_item" style="text-align: right;width:15%;">
                                <img src="/images/info.png" alt="" />
                                <a runat="server" id="aSendUnit" style="cursor: pointer; text-decoration: none;" onclick="">来文单位:</a>
                            </td>
                            <td class="con_item_left">
                                <asp:Label runat="server" ID="txtSendUnit"></asp:Label>
                                &nbsp;</td>
                            <td class="con_item" style="text-align: right; width: 20%;">
                                <span class="">收文日期:</span>
                            </td>
                            <td class="con_item_left" style="width: 40%;">
                                <asp:Label ID="pdtInComingDate" runat="server"></asp:Label>
                            </td>
                        </tr>
                         <tr>
                            <td class="con_item" style="text-align: right;">
                                <span class="">来文字号</span></td>
                            <td class="con_item_left" colspan="1">
                                <asp:Label ID="txtDispath" runat="server" ></asp:Label>
                            </td>
                            <td class="con_item" style="text-align: right;">
                               <span>收文编号</span>
                            </td>
                            <td class="con_item_left">
                                <asp:Label ID="txtRecNum" runat="server"></asp:Label>
                            </td>

                        </tr>
                        <tr>
                            <td class="con_item" style="text-align: right; width: 10%;">
                                <span class="">紧急程度:</span>
                            </td>
                            <td class="con_item_left" style="width: 40%;">
                                <asp:Label runat="server" ID="dplUrgency"></asp:Label>
                            </td>
                             <td class="con_item" style="text-align: right;">
                                <span class="">“三重一大”公示:</span></td>
                            <td class="con_item_left" colspan="1">
                                <asp:Label runat="server" ID="dplSzyd"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="con_item" style="text-align: right;">
                                <span>来文标题:</span>
                            </td>
                            <td class="con_item_left" colspan="3">
                                <asp:Label ID="txtTitle" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="con_item" style="text-align: right;">
                                <span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;备注:</span>
                            </td>
                            <td class="con_item_left" colspan="3">
                                <asp:Label ID="txtRemark" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="4">
                                 <asp:Literal ID="ShowOpList" runat="server" EnableViewState="False"></asp:Literal>
                            </td>
                        </tr>
                        <tr runat="server" id="tr_showList" visible="false">
                            <td class="con_item"></td>
                            <td class="con_item" colspan="3" style="width: 726px">
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
                                                    <%# AidHelp.ShortTime(Eval("CREATE_TIME")) %>
                                                </td>
                                                <td>
                                                    <asp:Label ID="lblPath" runat="server" Visible="false" Text='<%# Eval("FILE_PATH") %>'></asp:Label>
                                                    <asp:HyperLink runat="server" ID="hlDown" ForeColor="#215493" Font-Underline="false" Text="下载"></asp:HyperLink></td>
                                            </tr>
                                        </ItemTemplate>
                                    </asp:Repeater>
                                </table>
                            </td>
                        </tr>

                    </table>
                </div>
                <div class="con_oper">
                    <input type="button" runat="server" id="btnProcess" onclick='ShowTheProcess()' value="办理流程" class="btn_Process con_oper_btn let2" />
                    <input type="button" id="btnReturn" class="btn_back con_oper_btn let6" value="关闭" onclick="window.parent.layer.closeAll();" />
                </div>
            </div>
        </div>
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
        </script>
    </form>
</body>
</html>
