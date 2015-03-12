<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="GridStandartZT.ascx.vb" Inherits="CMCFileManage.GridStandartZT" %>
<%@ Register src="GridStandardZZ.ascx" tagname="GridStandardZZ" tagprefix="uc1" %>
<div>
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" Width="100%">
        <Columns>
            <asp:TemplateField HeaderText="狀態" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left"
                ItemStyle-Width="100px">
                <ItemTemplate>
                    <asp:Image ID="Image1" Style="cursor: hand;" runat="server" ImageUrl="../Images/addGrid.png" />
                    <asp:Label ID="LbZT" Visible ="false"  runat="server" Text='<%#DataBinder.Eval(Container,"DataItem.StandardStatus")%>'></asp:Label>
                    <asp:Label ID="Lbztshow" runat="server" Text=""></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField>
                <ItemTemplate>
                 <uc1:GridStandardZZ ID="GridStandardZZ1" runat="server" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="Nums" HeaderText="數量" HeaderStyle-HorizontalAlign="Right"
                ItemStyle-HorizontalAlign="Right" ItemStyle-Width="50px" />
        </Columns>
    </asp:GridView>
</div>
<asp:Button ID="Button1" Style="display: none" runat="server" Text="Button" />


