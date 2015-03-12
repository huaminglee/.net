<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="UCtlUserInfo.ascx.vb"
    Inherits="CMCFileManage.UCtlUserInfo" %>
<div class="title1" onclick="Expand('detail')">
    <img src="~/Images/Login/Friend.gif" alt="用戶信息" runat="server" id="imgTitle" />
    <div class="div1">
        用戶信息</div>
</div>
<div id="detail" class="detail">
    <img src="~/Images/UserInfo/AuditMan.gif" alt="用戶信息" runat="server" id="imgT" />
    <div>
        <ul>
            <li>
                <asp:Label ID="LabName" runat="server"></asp:Label>
            </li>
        </ul>
        <li>
            <asp:LinkButton ID="Lnk" runat="server"></asp:LinkButton>
        </li>
        <li>
            <asp:LinkButton ID="LnkLogIO" runat="server"></asp:LinkButton>
        </li>
    </div>
</div>
