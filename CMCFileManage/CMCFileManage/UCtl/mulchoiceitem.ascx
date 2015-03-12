<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="mulchoiceitem.ascx.vb"
    Inherits="CMCFileManage.mulchoiceitem" %>
<asp:DataList ID="DataList1" runat="server" HorizontalAlign="Left" 
    RepeatColumns="7">
    <ItemTemplate>
        <asp:CheckBox ID="chkNgReason" runat="server" />
        <asp:Label ID="lblNGItemName" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.NGItemName") %>'>
        </asp:Label>
        <asp:Label ID="lblIsWithTextBox" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.IsWithTextBox") %>'
            Visible="False">
        </asp:Label>
        <asp:Label ID="lblPKID" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.PKID") %>'
            Visible="False">
        </asp:Label>
        <asp:TextBox ID="TxtRemark" Visible="false" runat="server"></asp:TextBox>
    </ItemTemplate>
</asp:DataList>
