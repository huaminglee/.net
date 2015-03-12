<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="CtlHRMutilElement.ascx.vb"
    Inherits="eWorkFlow.eFlowDoc.CtlHRMutilElement" %>
<table width="100%" border="0" cellpadding="0" cellspacing="0">
    <tr>
        <td nowrap>
            <asp:DropDownList ID="DDLElementType" runat="server" Width="150px">
            </asp:DropDownList>
        </td>
        <td width="100%">
            <asp:Image ID="ImgForAdd" runat="server" ImageUrl="~/EFlowNet/Doc/Images/add.gif" Style="cursor: pointer;" />
        </td>
    </tr>
    <tr>
        <td nowrap valign="top">
            <asp:ListBox ID="LstMemberList" runat="server" Height="100px" Width="150px"></asp:ListBox>
        </td>
        <td width="100%" valign="top">
            <asp:Image ID="ImgForDelete" runat="server" ImageUrl="~/EFlowNet/Doc/Images/Discard.gif" Style="cursor: pointer;" />
            <asp:HiddenField ID="hiddenList" runat="server" />
            <asp:HiddenField ID="HiddenForDDLSelectValue" runat="server" />
            <asp:HiddenField ID="HiddenSelected" runat="server" />
        </td>
    </tr>
</table>
