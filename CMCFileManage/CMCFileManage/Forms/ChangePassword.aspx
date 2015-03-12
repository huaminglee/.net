<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="ChangePassword.aspx.vb" Inherits="CMCFileManage.ChangePassword" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>修改密碼</title>
    <link href="../CSS/newaction.css" rel="stylesheet" type="text/css" />
    <script language ="javascript" type ="text/javascript" >
        function closewin() {
            window.opener = null; window.close();
        }
    </script>
    </head>
<body >
    <form id="form1" runat="server" defaultbutton="BtnSave">
    <div>
    
        <table width ="100%" >
            <tr bgcolor="#B7B7B7">
                <td align="right" height="40" >
                    <asp:Label ID="Label2" runat="server" Text="帳號"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
                </td>
            </tr>
            <tr>
                <td align="right" >
                    &nbsp;原密碼</td>
                <td>
                    <asp:TextBox ID="TxtOldPass" runat="server" TextMode="Password"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                        ControlToValidate="TxtOldPass" ErrorMessage="*"></asp:RequiredFieldValidator>
                    <asp:Label ID="LbError" Visible ="false"  runat="server" ForeColor="Red" Text="密碼錯誤"></asp:Label>
                </td>
            </tr>
            <tr>
                <td align="right">
                    新密碼</td>
                <td>
                    <asp:TextBox ID="TxtNewPass" runat="server" TextMode="Password"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                        ControlToValidate="TxtNewPass" ErrorMessage="*"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td align="right">
                    確認新密碼</td>
                <td>
                    <asp:TextBox ID="TxtConfirmNewPass" runat="server" TextMode="Password"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                        ControlToValidate="TxtConfirmNewPass" ErrorMessage="*"></asp:RequiredFieldValidator>
                    <asp:CompareValidator ID="CompareValidator1" runat="server" 
                        ControlToCompare="TxtNewPass" ControlToValidate="TxtConfirmNewPass" 
                        ErrorMessage="兩次輸入不一致"></asp:CompareValidator>
                </td>
            </tr>
            <tr>
                <td align="right">
                    &nbsp;</td>
                <td>
                    <asp:Button ID="BtnSave" class="button" runat="server" Text="保存" />
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <input type="button" class="button" onclick ="closewin()" value ="取消" />
                    
                </td>
            </tr>
        </table>
    
    </div>
    </form>
</body>
</html>
