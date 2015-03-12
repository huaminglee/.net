<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="UCtlMenu.ascx.vb" Inherits="CRM.UCtlMenu" %>
<table cellpadding="0" cellspacing="0" border="0" width="100%">
    <tr>
        <td>
            <asp:Menu ID="Menu1" runat="server">
            </asp:Menu>
        </td>
        <td class="Menuinfo">
            <asp:Label ID="LabName" runat="server"></asp:Label>
            &nbsp;
            <asp:LinkButton ID="Lnk" runat="server"></asp:LinkButton>
            &nbsp;
            <asp:LinkButton ID="LnkLogIO" runat="server"></asp:LinkButton>
        </td>
    </tr>
</table>
