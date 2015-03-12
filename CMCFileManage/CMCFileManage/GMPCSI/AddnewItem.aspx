<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="AddnewItem.aspx.vb" Inherits="CMCFileManage.AddnewItem" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../CSS/newaction.css" rel="stylesheet" type="text/css" />
</head>
<body  >
    <form id="form1" runat="server">
    <div align="left">
        <table width="350px">
            <tr>
                <td>
                    調查項目
                </td>
                <td>
                    <asp:TextBox ID="TxtItem" runat="server" Width="250px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;
                </td>
                <td>
                    <asp:Button ID="BtnSave" class="button" runat="server" Text="確定" />
                    &nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Button ID="BtnCancel" class="button" runat="server" Text="取消" />
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
