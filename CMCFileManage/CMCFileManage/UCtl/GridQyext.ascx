<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="GridQyext.ascx.vb" Inherits="CMCFileManage.GridQyext" %>
<%@ Register src="GridErropreport.ascx" tagname="GridErropreport" tagprefix="uc1" %>
<%@ Register src="GridImportant.ascx" tagname="GridImportant" tagprefix="uc2" %>
<div>
 <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" Width="100%">
        <Columns>
            <asp:TemplateField HeaderText="區域" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left"
                ItemStyle-Width="100px">
                <ItemTemplate>
                    <asp:Image ID="Image1" Style="cursor: hand;" runat="server" ImageUrl="../Images/addGrid.png" />
                    <asp:Label ID="LbQy" runat="server" Text='<%#DataBinder.Eval(Container,"DataItem.Qulocation")%>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField>
                <ItemTemplate>
                <uc1:GridErropreport ID="GridErropreport1" runat="server" />
                <uc2:GridImportant ID="GridImportant1" runat="server" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="Nums" HeaderText="數量" HeaderStyle-HorizontalAlign="Right"
                ItemStyle-HorizontalAlign="Right" ItemStyle-Width="50px" />
        </Columns>
    </asp:GridView>
    <asp:Button ID="Button1" Style="display: none" runat="server" Text="Button" />
</div>




