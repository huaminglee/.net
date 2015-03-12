<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="dlgAduitAdvice.aspx.vb"
    Inherits="eWorkFlow.eFlowDoc.dlgAduitAdvice" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <base target="_self" />
    <meta http-equiv="pragma" content="no-cache">
    <meta http-equiv="Cache-Control" content="no-cache, must-revalidate">
    <title>办理意见</title>
</head>
<body style="margin: 0px; background: url(../../Images/FormCorner_small.gif) no-repeat right bottom"
    bgcolor="#E3E3E3">
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
        <Scripts>
            <asp:ScriptReference Path="~/EFlowNet/Doc/JS/WinHelper.js" />
        </Scripts>
    </asp:ScriptManager>
    <table border="0" cellpadding="0" cellspacing="0" width="100%">
        <tr style="background-color: #999999; height: 60px">
            <td width="60" nowrap>
                <asp:Image ID="Image2" runat="server" ImageUrl="~/EFlowNet/Doc/Images/Edit.png" />
            </td>
            <td align="left" width="100%">
                <span style="font-size: 12pt; font-weight: bold">編輯办理意见條件</span>
            </td>
        </tr>
        <tr>
            <td align="center" colspan="2">
                <asp:TextBox ID="txtAduitAdvice" Width="250px" CssClass="MulitiText" runat="server"
                    TextMode="MultiLine" Rows="5"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td align="center" colspan="2" width="100%">
                <asp:Button ID="BtnSave" runat="server" Text="保存" />&nbsp;
                <input type="button" value="关闭" onclick="window.returnValue=null;closeSelf();" />
            </td>
        </tr>
    </table>
    </form>
</body>
</html>
