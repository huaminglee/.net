<%@ Page Language="C#" AutoEventWireup="true" CodeFile="RollNewsDetail.aspx.cs" Inherits="Admin_RollNewsDetail" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge,chrome=1" />
    <!-- 移动设备优先 -->
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>查看新闻</title>
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
                <div class="con_h1">
                    <asp:Label runat="server" ID="lbTitle"></asp:Label>
                </div>
                <div style="margin: 0 auto; width:800px; text-align:center; border-bottom: 1px solid #e1e6ea;">
                    <asp:Label runat="server" ID="lbCreateTime" ></asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Label runat="server" ID="lbCreator" ></asp:Label>
                </div>
                <div class="con_b">
                    <p>
                        <asp:Label runat="server" ID="lbContent" Font-Size="Medium"></asp:Label>
                    </p>
                </div>
                <div class="con_oper">
                    <input type="button" id="btnReturn" class="btn_back con_oper_btn let6" value="关闭" onclick="window.parent.layer.closeAll();" />
                </div>
            </div>
        </div>
    </form>
</body>
</html>
