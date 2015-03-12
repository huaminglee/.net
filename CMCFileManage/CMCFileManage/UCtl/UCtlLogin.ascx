<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="UCtlLogin.ascx.vb"
    Inherits="CMCFileManage.UCtlLogin" %>
<div>
    <ul>
        <li>
            <img src="~/Images/Login/62.gif" runat="server" id="img3">
            <asp:Label ID="Label1" runat="server" CssClass="LogTt">用戶登錄</asp:Label>
        </li>
    </ul>
    <ul>
        <li style="width: 100%">
            <div style="background-image: url('Images/Login/title_line.gif'); height: 20px">
            </div>
        </li>
    </ul>
    <ul>
        <li>
            <img src="Images/Login/Friend.gif" id="img1">
            <asp:Label ID="UserNameLabel" runat="server" AssociatedControlID="UserName">用戶名:</asp:Label></li>
        <li>
            <asp:TextBox ID="UserName" runat="server" Width="140px"></asp:TextBox>
            <asp:RequiredFieldValidator ID="UserNameRequired" runat="server" ControlToValidate="UserName"
                ErrorMessage="必須提供使用者名稱。" ToolTip="必須提供使用者名稱。" ValidationGroup="ctl00$Login1">*</asp:RequiredFieldValidator>
        </li>
    </ul>
    <ul>
        <li>
            <img src="Images/Login/Audit.gif" id="img2">&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="PasswordLabel" runat="server" AssociatedControlID="Password">密碼:</asp:Label>
        </li>
        <li>
            <asp:TextBox ID="Password" runat="server" TextMode="Password" Width="140px"></asp:TextBox>
            <asp:RequiredFieldValidator ID="PasswordRequired" runat="server" ControlToValidate="Password"
                ErrorMessage="必須提供密碼。" ToolTip="必須提供密碼。" ValidationGroup="ctl00$Login1">*</asp:RequiredFieldValidator>
        </li>
    </ul>
    <ul>
        <li style="width: 150px">
            <asp:CheckBox ID="RememberMe" runat="server" Text="記憶密碼供下次使用。" />
        </li>
        <li>
            <asp:Button ID="LoginButton" runat="server" CommandName="Login" Text="登入" ValidationGroup="ctl00$Login1" />
        </li>
    </ul>
    <ul>
        <li>
            <asp:Literal ID="FailureText" runat="server" EnableViewState="False"></asp:Literal>
        </li>
    </ul>
</div>
