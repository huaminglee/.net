<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ViewMeeting.aspx.cs" Inherits="Meeting_ViewMeeting" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge,chrome=1" />
    <!-- 移动设备优先 -->
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>查看会议</title>
    <!-- 最新 Bootstrap 核心 CSS 文件 -->
    <link rel="stylesheet" type="text/css" href="/CSS/public.css?t=" <%=t_rand %> />
    <link rel="stylesheet" type="text/css" href="/CSS/detail.css?t=" <%=t_rand %> />
    <style type="text/css">
        .let2
        {
            letter-spacing: 2px;
        }

        .let6
        {
            letter-spacing: 6px;
        }
        p
        {
            padding-left:2em;
        }
        .auto-style1 {
            width: 187px;
        }
    </style>
    <script type="text/javascript" src="/jquery/1.8.3/jquery-1.8.2.min.js"></script>
    <script type="text/javascript" src="/Script/layer/layer.min.js"></script>
</head>
<body>
    <form id="mForm" runat="server">
        <asp:ScriptManager runat="server" ID="ScriptManager"></asp:ScriptManager>
        <div class="main">
            <div class="content">
                <div class="con_h">
                    <asp:Label runat="server" ID="lbTopTitle" Text="成都市水务局会议通知"></asp:Label>
                </div>
                <div class="con_b">
                    <table class="main_msgList" cellspacing="1" cellpadding="1" style="text-align: center" border="0">
                        <tr>
                            <td style="text-align: right;"><span>会议名称</span></td>
                            <td class="con_item_left" style="width: 650px; text-align: left;">
                                <p> <asp:Label runat="server" ID="lbTitle"></asp:Label></p>
                            </td>
                        </tr>
                        <tr>
                            <td style=" text-align: right;"><span>会议内容</span></td>
                            <td class="con_item_left" style="width: 650px; text-align:left;">
                                <p>
                                    <%--<asp:TextBox runat="server" ID="txtContent" Width="100%" ReadOnly="true" Style="resize: none;" TextMode="MultiLine" Height="120px" MaxLength="1000"></asp:TextBox>--%>
                                    <asp:Label runat="server" ID="txtContent"></asp:Label>
                                </p>
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: right;"><span>会议地点</span></td>
                            <td class="con_item_left" style="width: 650px; text-align: left;">
                                <p> <asp:Label runat="server" ID="lbLocation"></asp:Label></p>
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: right;"><span>开始时间</span></td>
                            <td class="con_item_left" style="width: 650px; text-align: left;">
                                <p> <asp:Label runat="server" ID="lbStartTime"></asp:Label></p>
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: right;"><span>结束时间</span></td>
                            <td class="con_item_left" style="width: 650px; text-align: left;">
                                <p> <asp:Label runat="server" ID="lbEndTime"></asp:Label></p>
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: right;"><span>承办部门</span></td>
                            <td class="con_item_left" style="width: 650px; text-align: left;">
                                <p> <asp:Label runat="server" ID="lbDepartment"></asp:Label></p>
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: right;"><span>主持人</span></td>
                            <td class="con_item_left" style="width: 650px; text-align: left;">
                                <p> <asp:Label runat="server" ID="lbHostUser"></asp:Label></p>
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: right;"><span>参会人员</span></td>
                            <td class="con_item_left" style="width: 650px; text-align: left;">
                                <p> <asp:Label runat="server" ID="lbReceiver"></asp:Label></p>
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: right;"><span>非本局参会人员</span></td>
                            <td class="con_item_left" style="width: 650px; text-align: left;">
                                <p> <asp:Label runat="server" ID="lbOtherUser"></asp:Label></p>
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: right;"><span>备注</span></td>
                            <td class="con_item_left" style="width: 650px; text-align: left;">
                                <p> 
                                    <%--<asp:TextBox runat="server" ID="txtRemark" Width="100%" ReadOnly="true" Style="resize: none;" TextMode="MultiLine" Height="120px" MaxLength="1000"></asp:TextBox>--%>
                                    <asp:Label runat="server" ID="txtRemark"></asp:Label>
                                </p>
                            </td>
                        </tr>
                        <tr runat="server" id="tr_showList" visible="false">
                            <td style="text-align: right;"></td>
                            <td class="con_item" style="padding-left:30px;">
                                <table class="GridTitleCss" style="width: 100%; ">
                                     <tr>
                                        <th style="width: 40%;">附件名称</th>
                                        <th style="width: 20%;">上传人员</th>
                                        <th style="width: 20%;">上传时间</th>
                                        <th style="width: 20%;" colspan="1">操作</th>
                                    </tr>
                                    <asp:Repeater ID="rpt_AttachmentList" runat="server" OnItemDataBound="rpt_AttachmentList_ItemDataBound">
                                        <ItemTemplate>
                                            <tr>
                                                <td >
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
                    <input type="button" id="btnReturn" class="btn_back con_oper_btn let6" value="关闭" onclick="window.parent.layer.closeAll();" />
                </div>
            </div>
        </div>
    </form>
</body>
</html>