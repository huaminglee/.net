<%@ Page Language="C#" AutoEventWireup="true" CodeFile="NewRoleInfo.aspx.cs" Inherits="SysManege_NewRoleInfo" %>

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
            <table class="Form_Main" cellpadding="0px" cellspacing="0px" style="height:155px;">
                <tr>
                    <td>角色名称</td>
                    <td>
                        <asp:TextBox ID="txtrName" runat="server" CssClass="input inpute" MaxLength="50"></asp:TextBox></td>
                    <td class="ImpTips">*</td>
                </tr>
                <tr runat="server" id="tr_Pwd">
                    <td>角色描述</td>
                    <td>
                        <asp:TextBox ID="txtReMark" runat="server" TextMode="MultiLine" CssClass="input inpute" MaxLength="249" Height="100"></asp:TextBox></td>
                    <td class="ImpTips">*</td>
                </tr>
                <tr>
                    <td colspan="3">
                        <div class="Form_Main_Btnpanel">
                            <asp:Button ID="btnSave" runat="server" Text="保存" CssClass="subBtn" OnClick="btnSave_Click" />
                        </div>
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
