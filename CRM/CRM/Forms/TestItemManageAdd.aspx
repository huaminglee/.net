<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="TestItemManageAdd.aspx.vb"
    Inherits="CRM.TestItemManageAdd" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../NewScript/themes/Default/easyui.css" rel="stylesheet" type="text/css" />
    <link href="../CSS/newaction.css" rel="stylesheet" type="text/css" />

    <script src="../NewScript/jquery-1.7.2.min.js" type="text/javascript"></script>

    <script src="../NewScript/jquery.easyui.min.js" type="text/javascript"></script>

</head>
<body>
    <form id="form1" runat="server">
    <div align="center">
        添加測試項目
        <table width="100%" border="1" cellpadding="0" cellspacing="0" bordercolordark="#FFFFFF"
            bordercolor="#999999">
            <tr>
                <td colspan="2" align="left">
                    測試項目名：<asp:TextBox ID="TxtSearchItemName" runat="server"></asp:TextBox>
                    <asp:Button ID="BtnSearch" class="button" runat="server" Text="查詢" />
                </td>
            </tr>
            <tr>
                <td colspan="2" align="left">
                    <asp:CheckBox ID="CheckBox1" runat="server" Text="手動輸入" AutoPostBack="True" />
                    <asp:Label ID="Label1" runat="server" 
                        Text="（注：勾選后可以手動輸入測試項目，但是包含此測試項目的報價單將無法自動向測試申請系統中拋數據！）" ForeColor="#33CC33"></asp:Label>
                </td>
            </tr>
            <tr>
                <td align="left" colspan="2">
                    服 務 類 別 ：<asp:DropDownList ID="DPLlabserviceName" runat="server" 
                        Width="155px">
                    </asp:DropDownList>
                    測試項目：<asp:TextBox ID="TxtTestItemName" runat="server"></asp:TextBox>
                    <asp:HiddenField ID="HiddenTestItemPKID" Value="0" runat="server" />
                </td>
            </tr>
            <tr>
                <td align="left" colspan="2">
                    牌價基本金：<asp:TextBox ID="TxtPJbasic" Text="0" class="easyui-numberbox" data-options="min:0,required:true,precision:0"
                        runat="server"></asp:TextBox>
                    牌價單價：<asp:TextBox ID="TxtPJunit" Text="0" class="easyui-numberbox" data-options="min:0,required:true,precision:0"
                        runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td align="left" colspan="2">
                    成本價單價：<asp:TextBox ID="TxtCBunit" Text="0" class="easyui-numberbox" data-options="min:0,required:true,precision:0"
                        runat="server"></asp:TextBox>
                    計價單位：<asp:TextBox ID="Txtdanwei" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td align="right">
                    <asp:Button ID="BtnCancel" class="button" runat="server" Text="取消" />
                </td>
                <td>
                    <asp:Button ID="BtnSave" class="button" runat="server" Text="添加" />
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
