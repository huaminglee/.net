<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="GridImportant.ascx.vb" Inherits="CMCFileManage.GridImportant" %>
<div>
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
        Width="100%">
        <Columns>
                <asp:TemplateField Visible ="false">
                    <ItemTemplate>
                        <asp:Label ID="LblPKID" runat="server" Text='<%# DataBinder.Eval(Container,"DataItem.PKID").ToString() %>'
                            Visible="False"></asp:Label>
                        <asp:HyperLink ID="HLDetail" Visible ="false"  Target="MainFrame" runat="server" ToolTip="查看" ImageUrl="~/Images/edit.gif">查看</asp:HyperLink>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="GoodsName" HeaderText="品名" />
                <asp:BoundField DataField="Standars" HeaderText="規格型號" />
                <asp:BoundField DataField="Brands" HeaderText="廠牌" />
                <asp:BoundField DataField="Supplier" HeaderText="供應商" />
                <asp:BoundField DataField="TecRequir" HeaderText="技術規格" />
                <asp:TemplateField Visible ="false" >
                    <ItemTemplate>
                        <asp:ImageButton ID="BtnDelete" runat="server" ImageUrl="~/Images/Delete.gif" CommandName="Delete">
                        </asp:ImageButton>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
    </asp:GridView>
</div>