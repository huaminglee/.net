<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PurviewInfo.aspx.cs" Inherits="SysManege_PurviewInfo" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>查看权限信息</title>
    <link rel="stylesheet" type="text/css" href="/CSS/MainBoard.css" />
    <link rel="stylesheet" type="text/css" href="/CSS/PurTree.css" />
    <script type="text/javascript" src="/jquery/1.8.3/jquery-1.8.2.min.js"></script>
    <script type="text/javascript" src="/Script/layer/layer.min.js"></script>
</head>
<body>
    <form id="pFrom" runat="server">
        <div class="Form_ViewInfo left">
        <table class="Form_Main" cellpadding="0px" cellspacing="0px">
            <tr>
                <td>上级权限</td>
                <td>
                    <asp:Label ID="lblParent_Name" runat="server" Text="无"></asp:Label></td>
            </tr>
            <tr>
                <td>权限名称</td>
                <td>
                    <asp:Label ID="txtRIGHT_NAME" runat="server" ></asp:Label></td>
            </tr>
            <tr>
                <td>权限编码</td>
                <td>
                    <asp:Label ID="txtRIGHT_CODE" runat="server"></asp:Label></td>
            </tr>
            <tr>
                <td>权限排序</td>
                <td>
                    <asp:Label ID="txtSORT_NUM" runat="server" ></asp:Label></td>
            </tr>
            <tr>
                <td>描述</td>
                <td>
                    <asp:Label ID="txtRIGHT_DESC" runat="server" ></asp:Label></td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
