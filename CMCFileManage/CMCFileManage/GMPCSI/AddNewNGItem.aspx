<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="AddNewNGItem.aspx.vb" Inherits="CMCFileManage.AddNewNGItem" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
    <link href="../CSS/newaction.css" rel="stylesheet" type="text/css" />
</head>
<body  > 
    <form id="form1" runat="server">
    <div>
    
        <table width="350px">
            <tr>
                <td>
                    不滿意原因</td>
                <td>
                    <asp:TextBox ID="TextBox1"  runat="server" Width="200px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    是否可自定義輸入</td>
                <td>
                    <asp:CheckBox ID="Chbistextbox"  runat="server" />
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;</td>
                <td>
                    <asp:Button ID="BtnOK" runat="server" class="button" Text="確認" />
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Button ID="BtnCancel" runat="server" class="button" Text="取消" />
                </td>
            </tr>
        </table>
    
    </div>
    </form>
</body>
</html>
