<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="GridCategory.ascx.vb"
    Inherits="CMCFileManage.GridCategory" %>
<%@ Register Src="GridFile.ascx" TagName="GridFile" TagPrefix="uc1" %>
<div>
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" Width="100%">
        <Columns>
            <asp:TemplateField HeaderText="文件類別" ItemStyle-Width="100px">
                <ItemTemplate>
                    <asp:Image ID="Image1" style="cursor:hand;" runat="server" ImageUrl="../Images/addGrid.png" />
                    <asp:Label ID="LbCategory" runat="server" Text='<%#DataBinder.Eval(Container,"DataItem.FileCategory")%>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField>
                <ItemTemplate>
                    <uc1:GridFile ID="GridFile1" runat="server" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="Nums" HeaderText="數量" ItemStyle-HorizontalAlign="Right"
                ItemStyle-Width="50px" FooterStyle-HorizontalAlign="Right">
                <FooterStyle HorizontalAlign="Right"></FooterStyle>
                <ItemStyle HorizontalAlign="Right" Width="50px"></ItemStyle>
            </asp:BoundField>
        </Columns>
    </asp:GridView>
    <asp:Button ID="Button1" style="display:none " runat="server" Text="Button" />
</div>
