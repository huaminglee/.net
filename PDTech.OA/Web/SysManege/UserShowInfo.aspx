<%@ Page Language="C#" AutoEventWireup="true" CodeFile="UserShowInfo.aspx.cs" Inherits="UserShowInfo" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
      <title>用户详细信息</title>
    <link rel="stylesheet" type="text/css" href="/CSS/MainBord.css" />
    <link rel="stylesheet" type="text/css" href="/CSS/MainBoard.css" />
    <script type="text/javascript" src="/jquery/1.8.3/jquery-1.8.2.min.js"></script>
    <script type="text/javascript" src="/Script/layer/layer.min.js"></script>
    <script type="text/javascript" src="/Script/common.js"></script>
</head>
<body>
    <form id="uForm" runat="server">
        <div class="NewDept">
            <table class="Form_Main" cellpadding="0px" cellspacing="0px">
                <tr>
                    <td>部门名称</td>
                    <td>
                        <asp:Label ID="lblDeptName" runat="server" Text=""></asp:Label>
                        </td>
                </tr>
                <tr>
                    <td>登录帐号</td>
                    <td>
                        <asp:Label ID="txtLoginName" runat="server" Text=""></asp:Label></td>
                   
                </tr>
                <tr>
                    <td>姓名</td>
                    <td>
                        <asp:Label ID="txtFullName" runat="server" Text=""></asp:Label></td>
                </tr>
                <tr>
                    <td>电话号码</td>
                    <td>
                        <asp:Label ID="txtPhone" runat="server" Text=""></asp:Label></td>
                </tr>
                <tr>
                    <td>手机号码</td>
                    <td>
                        <asp:Label ID="txtMobile" runat="server" Text=""></asp:Label></td>
                </tr>
                <tr>
                    <td>职务</td>
                    <td>
                        <asp:Label ID="txtDutyInfo" runat="server" Text=""></asp:Label></td>
                </tr>
                <tr>
                    <td>显示名称</td>
                    <td>
                        <asp:Label ID="txtPublicName" runat="server" Text=""></asp:Label></td>
                </tr>
                <tr>
                    <td>邮箱</td>
                    <td>
                        <asp:Label ID="txtEMaile" runat="server" Text=""></asp:Label></td>
                </tr>
                <tr>
                    <td>备注</td>
                    <td>
                        <asp:Label ID="txtRemark" runat="server" Text=""></asp:Label></td>
                </tr>
                <tr>
                    <td>用户排序</td>
                    <td>
                        <asp:Label ID="txtSort" runat="server" Text=""></asp:Label></td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
