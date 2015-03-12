<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Main_Frame.aspx.cs" Inherits="Archive_Main_Frame" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge,chrome=1" />
    <!-- 移动设备优先 -->
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>待处理公文</title>
    <!-- 最新 Bootstrap 核心 CSS 文件 -->
    <link href="/bootstrap/3.2.0/css/bootstrap.min.css" rel="stylesheet" />
    <link href="/css/html5_layout.css" rel="stylesheet" />
    <link href="/css/aspnetpager.css?t=" <%=t_rand %> rel="stylesheet"/>
    <link href="/css/Sys.css" rel="stylesheet" />
    <link href="/easyui/1.3.6/themes/bootstrap/easyui.css" rel="stylesheet" />
    <link href="/easyui/1.3.6/themes/icon.css" rel="stylesheet" />
    <!-- 兼容Html5和Css3 -->
    <!--[if lt IE 9]>
        <script src="/Script/html5shiv/3.7.2/html5shiv.min.js"></script>
        <script src="/Script/respond.js/1.4.2/respond.min.js"></script>
    <![endif]-->
    <script src="/jquery/1.9.1/jquery.min.js"></script>
    <script src="/easyui/1.3.6/jquery.easyui.min.js"></script>
    <script src="/Script/layer/layer.min.js"></script>
    <script src="/Script/swfupload/swfupload.js"></script>
    <script src="/Script/common.js?t=" <%=t_rand %>></script>
</head>
<body>
    <form id="nForm" runat="server">
        <asp:ScriptManager runat="server" ID="ScriptManager"></asp:ScriptManager>
        <%--<asp:UpdatePanel runat="server" ID="UpdatePanel">
            <ContentTemplate>--%>
                <asp:Panel ID="nPanel" runat="server"></asp:Panel>
            <%--</ContentTemplate>
        </asp:UpdatePanel>--%>
    </form>
</body>
</html>