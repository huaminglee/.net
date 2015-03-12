<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ShowRoleInfo.aspx.cs" Inherits="SysManege_ShowRoleInfo" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=EmulateIE8" />
    <title>角色信息</title>
    <link rel="stylesheet" type="text/css" href="/CSS/MainBord.css" />
    <link rel="stylesheet" type="text/css" href="/CSS/MainBoard.css" />
    <script type="text/javascript" src="/jquery/1.8.3/jquery-1.8.2.min.js"></script>
    <script type="text/javascript" src="/Script/layer/layer.min.js"></script>
    <script type="text/javascript" src="/Script/common.js"></script>
</head>
<body>
    <form id="uFrom" runat="server">
        <div class="NewDept">
            <table class="Form_Main" cellpadding="0px" cellspacing="0px" style="height:80px;">
                <tr>
                    <td>角色名称</td>
                    <td>
                        <asp:Label ID="txtrName" runat="server"></asp:Label></td>
                </tr>
                <tr runat="server" id="tr_Pwd">
                    <td>角色描述</td>
                    <td>
                        <asp:Label ID="txtReMark" runat="server"></asp:Label></td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>