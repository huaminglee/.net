<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ShowMeetRead.aspx.cs" Inherits="SysManege_ShowMeetRead" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge,chrome=1" />
    <!-- 移动设备优先 -->
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>查看会议通知接收状态</title> 
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
            text-indent: 2em;
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
                <div class="con_b">
                    <table class="main_msgList" cellspacing="1" cellpadding="1" style="text-align: center" border="0">
                        <tr>
                            <td class="con_item" style="width:10%; text-align:right;"><span>未读人员:</span></td>
                            <td class="con_item_left" style="width: 720px; text-align: left;">
                                <p>
                                    <asp:Label runat="server" ID="txtUserNames"></asp:Label>
                                </p>
                            </td>
                        </tr>
                        <tr id="tr_showList">
                            <td class="con_item" style="width:10%; text-align:right;"><span>已读人员:</span></td>
                            <td class="con_item">
                                <table class="main_tabList">
                                    <asp:Repeater ID="rpt_UserList" runat="server">
                                        <HeaderTemplate>
                                            <tr>
                                                <th style="width: 50%;">接收人</th>
                                                <th style="width: 50%;">阅读时间</th>
                                            </tr>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <tr>
                                                <td><%# GetUserName((decimal)Eval("RECEIVER_ID")) %></td>
                                                <td><%# Eval("READ_TIME") %></td>
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