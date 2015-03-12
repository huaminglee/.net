<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="QuotationInvoid.aspx.vb"
    Inherits="CRM.QuotationInvoid" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../CSS/newaction.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table width="100%">
            <tr>
                <td colspan="2">
                    請輸入異常結案原因<asp:TextBox ID="TxtReason" runat="server" Height="100px" TextMode="MultiLine"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                        ControlToValidate="TxtReason" ErrorMessage="原因不能為空！"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;</td>
                <td>
                    <asp:Button ID="BtnSave" class="button" runat="server" Text="送審" />
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
