<%@ Page Language="C#" AutoEventWireup="true" CodeFile="EdayQuestionDetail.aspx.cs" Inherits="IncorruptEdu_EdayQuestionDetail" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge,chrome=1" />
    <!-- 移动设备优先 -->
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>查看详细</title>
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
                    <asp:Label runat="server" ID="lbTopTitle" Text="成都市水务局每日一题详细"></asp:Label>
                </div>
                <div class="con_b">
                    <table class="main_msgList" cellspacing="1" cellpadding="1" style="text-align: center" border="0">
                        <tr>
                            <td style="text-align: right;"><span>题目</span></td>
                            <td class="con_item_left" style="width: 650px; text-align: left;">
                                <p> <asp:Label runat="server" ID="lbTitle"></asp:Label></p>
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: right;"><span>内容</span></td>
                            <td class="con_item_left" style="width: 650px; text-align: left;">
                                <p> <asp:Label runat="server" ID="lbOptionA"></asp:Label></p>
                                <p> <asp:Label runat="server" ID="lbOptionB"></asp:Label></p>
                                <p> <asp:Label runat="server" ID="lbOptionC"></asp:Label></p>
                                <p> <asp:Label runat="server" ID="lbOptionD"></asp:Label></p>
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: right;"><span>选择答案</span></td>
                            <td class="con_item_left" style="width: 650px; text-align: left;">
                                <p> <asp:Label runat="server" ID="lbSelected"></asp:Label></p>
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: right;"><span>正确答案</span></td>
                            <td class="con_item_left" style="width: 650px; text-align: left;">
                                <p> <asp:Label runat="server" ID="lbAnswer" ForeColor="Red"></asp:Label></p>
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: right;"><span>得分</span></td>
                            <td class="con_item_left" style="width: 650px; text-align: left;">
                                <p> <asp:Label runat="server" ID="lbScore"></asp:Label></p>
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: right;"><span>答题时间</span></td>
                            <td class="con_item_left" style="width: 650px; text-align: left;">
                                <p> <asp:Label runat="server" ID="lbSelectedTime"></asp:Label></p>
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
