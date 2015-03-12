<%@ Page Language="C#" AutoEventWireup="true" CodeFile="msgInfo.aspx.cs" Inherits="Archive_msgInfo" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge,chrome=1" />
    <!-- 移动设备优先 -->
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>查看公告</title>
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
            text-indent:2em;
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
                    <asp:Label runat="server" ID="lbTopTitle" Text="成都市水务局公告消息笺"></asp:Label>
                </div>
                <div class="con_b">
                    <table class="main_msgList" cellspacing="1" cellpadding="1" style="text-align: center" border="0">
                        <tr>
                            <td class="con_item" style="width: 80px; text-align: right;"><span>发送人</span></td>
                            <td class="con_item_left" style="width: 720px; text-align: left;">
                                <p> <asp:Label runat="server" ID="lbl_sendName"></asp:Label></p>
                            </td>
                        </tr> 
                        <tr>
                            <td class="con_item" style="width: 80px; text-align: right;"><span>发送时间</span></td>
                            <td class="con_item_left" style="width: 720px; text-align: left;">
                                <p> <asp:Label runat="server" ID="lbl_sendTime"></asp:Label></p>
                            </td>
                        </tr>
                        <tr>
                            <td class="con_item" style="width: 80px; text-align: right;"><span>主题</span></td>
                            <td class="con_item_left" style="width: 720px; text-align: left;">
                                <p> <asp:Label runat="server" ID="title"></asp:Label></p>
                            </td>
                        </tr>
                        <tr>
                            <td class="con_item" style="width: 80px; text-align: right;"><span>内容</span></td>
                            <td class="con_item_left" style="width: 720px; text-align:left;">
                                <p>
                                    <asp:Label runat="server" ID="txtContent"></asp:Label>
                                </p>
                            </td>
                        </tr>
                        <tr runat="server" id="tr_showList" visible="false">
                            <td class="con_item"></td>
                            <td class="con_item">
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
                    <input type="button" id="btnReturn" class="btn_back con_oper_btn let6" value="关闭" onclick="window.parent.layer.closeAll();" />
                </div>
            </div>
        </div>
    </form>
</body>
</html>
