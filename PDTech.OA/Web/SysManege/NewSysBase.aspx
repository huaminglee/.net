<%@ Page Language="C#" AutoEventWireup="true" CodeFile="NewSysBase.aspx.cs" Inherits="SysManege_NewSysBase" %>

<!DOCTYPE html>


<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
<meta http-equiv="X-UA-Compatible" content="IE=EmulateIE8" />
    <title>新增基础数据</title>
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
                    <td>数据类型</td>
                    <td>
                        <asp:Label ID="lblSysType" runat="server" Text=""></asp:Label></td>
                    <td class="ImpTips"></td>
                </tr>
                <tr>
                    <td>单位名称</td>
                    <td>
                        <asp:TextBox ID="txtName" runat="server" CssClass="input inpute" MaxLength="30"></asp:TextBox></td>
                    <td class="ImpTips">*</td>
                </tr>
                <tr>
                    <td>单位简称</td>
                    <td>
                        <asp:TextBox ID="txtName_Jc" runat="server" CssClass="input inpute" MaxLength="30"></asp:TextBox></td>
                    <td class="ImpTips"></td>
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
