<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Main_Frame.aspx.cs" Inherits="Approve_Main_Frame" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>iFrame</title>
    <link rel="stylesheet" type="text/css" href="/CSS/Sys.css?t=" <%=t_rand %> />
    <link rel="stylesheet" type="text/css" href="/CSS/aspnetpager.css?t=" <%=t_rand %> />
    <script type="text/javascript" src="/jquery/1.8.3/jquery-1.8.2.min.js"></script>
    <script type="text/javascript" src="/Script/layer/layer.min.js"></script>
    <script type="text/javascript" src="/Script/swfupload/swfupload.js"></script>
    <script type="text/javascript" src="/Script/common.js?t=" <%=t_rand %>></script>
</head>
<body>
    <form id="nForm" runat="server">
        <asp:ScriptManager runat="server" ID="ScriptManager"></asp:ScriptManager>
        <asp:UpdatePanel runat="server" ID="UpdatePanel">
            <ContentTemplate>
                <asp:Panel ID="nPanel" runat="server"></asp:Panel>
            </ContentTemplate>
        </asp:UpdatePanel>
    </form>
</body>
</html>