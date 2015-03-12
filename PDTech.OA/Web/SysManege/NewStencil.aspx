<%@ Page Language="C#" AutoEventWireup="true" CodeFile="NewStencil.aspx.cs" Inherits="SysManege_NewStencil" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
<meta http-equiv="X-UA-Compatible" content="IE=EmulateIE8" />
    <title>新增或编辑模板信息</title>
    <link rel="stylesheet" type="text/css" href="/CSS/MainBord.css" />
    <link rel="stylesheet" type="text/css" href="/CSS/MainBoard.css" />
    <script type="text/javascript" src="/jquery/1.8.3/jquery-1.8.2.min.js"></script>
    <script type="text/javascript" src="/Script/layer/layer.min.js"></script>
    <script type="text/javascript" src="/Script/common.js"></script>
</head>
<body>
    <form id="nForm" runat="server">
        <div class="NewDept">
            <table class="Form_Main" cellpadding="0px" cellspacing="0px">
                <tr>
                    <td>模板简称</td>
                    <td>
                        <asp:TextBox ID="txtName" runat="server" CssClass="input inpute" MaxLength="30"></asp:TextBox></td>
                    <td class="ImpTips">*</td>
                </tr>
                <tr>
                    <td>模板内容</td>
                    <td>
                        <asp:TextBox ID="txtComtent" runat="server" CssClass="input inpute" MaxLength="150" TextMode="MultiLine" Height="68"></asp:TextBox></td>
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
