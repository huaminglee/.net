<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="CtlHRSingleElement.ascx.vb"
    Inherits="eWorkFlow.eFlowDoc.CtlHRSingleElement" %>
<table>
    <tr>
        <td>
            <asp:TextBox ID="TxtSelectedMember" runat="server" Width="100px" 
                ReadOnly="True"></asp:TextBox>
        </td>
        <td>
            <asp:Image ID="ImgAdd" runat="server" ImageUrl="~/EFlowNet/Doc/Images/view.gif" />
             <asp:Image ID="ImgReset" runat="server" ImageUrl="~/EFlowNet/Doc/Images/reset.gif" />
        </td>
    </tr>
</table>
<asp:HiddenField ID="hiddenElementIDList" runat="server" />
