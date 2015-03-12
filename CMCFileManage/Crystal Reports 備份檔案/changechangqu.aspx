<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="changechangqu.aspx.vb" Inherits="CMCFileManage.changechangqu" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
    <link href="../CSS/newaction.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <table width="100%" border="1" cellspacing="0" cellpadding="0" bordercolor="#000000"
            bordercolordark="#FFFFFF">
            <tr align="center">
                <td>
                    <asp:Button ID="ButtonLH" class="button" runat="server" Text="龍華" 
                    Height="30px" /></td>
                <td>
                    <asp:Button ID="ButtonGL" class="button" runat="server" Text="觀瀾" 
                    Height="30px" /></td>
                <td>
                   <asp:Button ID="ButtonWH" class="button" runat="server" Text="武漢" 
                    Height="30px" /></td>
                <td>
                   <asp:Button ID="ButtonYT" class="button" runat="server" Text="煙台" 
                    Height="30px" /></td>
            </tr>
            <tr align="center">
                <td>
                    <asp:Button ID="ButtonWSJ" class="button" runat="server" Text="吳淞江" 
                    Height="30px" /></td>
                <td>
                   <asp:Button ID="ButtonCQ" class="button" runat="server" Text="重慶" 
                    Height="30px" /></td>
                <td>
                   <asp:Button ID="ButtonCD" class="button" runat="server" Text="成都" 
                    Height="30px" /></td>
                <td>
                   <asp:Button ID="ButtonZZ" class="button" runat="server" Text="鄭州" 
                    Height="30px" /></td>
            </tr>
        </table>
    
    </div>
    </form>
</body>
</html>
