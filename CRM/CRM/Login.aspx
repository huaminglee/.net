<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Login.aspx.vb" Inherits="CRM.Login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="Shortcut Icon" href="favicon.ico" />
    <title>登入</title>
    <object id="Signer" classid="clsid:EDAD2404-CEE0-4495-8D17-8DF60B32917E" codebase="SignGadget.msi#version=1,0,1">
    </object>
    <link href="CSS/reset.css" rel="stylesheet" type="text/css" />
    <link href="CSS/style.css" rel="stylesheet" type="text/css" />
    <link href="CSS/invalid.css" rel="stylesheet" type="text/css" />

    <script src="NewScript/jquery-1.7.2.min.js" type="text/javascript"></script>

    <script src="Scripts/LoginRegister.js" type="text/javascript"></script>

    <script type="text/javascript" language="javascript">
        if (window != top)
            top.location.href = "Login.aspx";



        function ChangeHumanIDToUpCase() {
            var HumanID = document.all["TxtUserName"].value;
            document.all["TxtUserName"].value = HumanID.toUpperCase();
        }
        
    </script>

</head>
<body id="login">
    <form id="form1" runat="server">
    <div id="login-wrapper" class="png_bg">
        <div id="login-top">
            <h1>
                客戶關係管理</h1>
            <!-- Logo (221px width) -->
            <img id="logo" src="images/logo.gif" alt="客戶關係管理" />
        </div>
        <!-- End #logn-top -->
        <div id="login-content">
            <table width="100%" style="margin: 0px auto auto auto" >
                <tr>
                    <td colspan="2">
                        <div id="wronginfo" runat="server" visible="false" style="width: 100%; height: 40px;
                            background-color: #000000; line-height: 30px; overflow: hidden;" align="center">
                            <asp:Image ID="Image1" runat="server" ImageUrl="~/Images/Icons/information.png" />
                            <asp:Label ID="LError" runat="server" Text="用戶名或密碼錯誤。"></asp:Label>
                            &nbsp;&nbsp;&nbsp;
                        </div>
                    </td>
                </tr>
                <tr>
                    <td align="left">
                        <asp:Label ID="Label1" runat="server" Text="帳 號:" Font-Size="14px"></asp:Label>
                    </td>
                    <td height="50" align="left">
                        <asp:TextBox ID="TxtUserName" onkeyup="ChangeHumanIDToUpCase()" class="text-input"
                            runat="server" Width="200px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td align="left">
                        <asp:Label ID="Label2" runat="server" Text="密 碼:" Font-Size="14px"></asp:Label>
                    </td>
                    <td height="50" width="230" align="left">
                        <asp:TextBox ID="TxtPassword" class="text-input" runat="server" TextMode="Password"
                            Width="200px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        &nbsp;
                    </td>
                    <td valign="middle">
                        <asp:CheckBox ID="chkRem" class="chklabel" Style="float: left; display: none" runat="server"
                            ForeColor="White" Text="記住登陸" />
                        <input type="button" onclick="CALogin()" value="證書登陸" class="button" style=" float :right; width: 80px;
                            height: 30px; margin-right: 20px;" /><asp:Button ID="Button1" Style="float: left; "  
                                Height="30px" class="button" runat="server" Text="登陸" Width="80px"  />
                    </td>
                </tr>
            </table>
        </div>
        <!-- End #login-content -->
    </div>
    <asp:HiddenField ID="HidUsername" runat="server" />
    <asp:HiddenField ID="HidEmail" runat="server" />
    </form>
</body>
</html>
