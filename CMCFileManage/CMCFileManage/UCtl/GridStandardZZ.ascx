<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="GridStandardZZ.ascx.vb" Inherits="CMCFileManage.GridStandardZZ" %>
<%@ Register src="GridOtherFile.ascx" tagname="GridOtherFile" tagprefix="uc1" %>
<div>
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" Width="100%">
        <Columns>
            <asp:TemplateField HeaderText="組織" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left"
                ItemStyle-Width="100px">
                <ItemTemplate>
                    <asp:Image ID="Image1" Style="cursor: hand;" runat="server" ImageUrl="../Images/addGrid.png" />
                    <asp:Label ID="LbZZ" runat="server" Text='<%#DataBinder.Eval(Container,"DataItem.StandardOrganize")%>'></asp:Label>
                   
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField>
                <ItemTemplate>
               <uc1:GridOtherFile ID="GridOtherFile1" runat="server" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="Nums" HeaderText="數量" HeaderStyle-HorizontalAlign="Right"
                ItemStyle-HorizontalAlign="Right" ItemStyle-Width="50px" />
        </Columns>
    </asp:GridView>
</div>
<asp:Button ID="Button1" Style="display: none" runat="server" Text="Button" />

