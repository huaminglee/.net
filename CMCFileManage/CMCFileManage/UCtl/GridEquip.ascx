<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="GridEquip.ascx.vb" Inherits="CMCFileManage.GridEquip" %>
<div>
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
        Width="100%">
        <Columns>
                <asp:TemplateField Visible ="false" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                    <ItemTemplate>
                        <asp:Label ID="LblPKID" runat="server" Text='<%# DataBinder.Eval(Container,"DataItem.PKID").ToString() %>'
                            Visible="False"></asp:Label>
                        <asp:Label ID="lblDocUniqueID" runat="server" Text='<%# DataBinder.Eval(Container,"DataItem.eFlowDocID").ToString() %>'
                            Visible="False"></asp:Label>
                        <asp:HyperLink ID="HLDetail" Visible ="false"  Target="MainFrame" runat="server" ToolTip="編輯" ImageUrl="~/Images/edit.gif">查看</asp:HyperLink>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField HeaderText="設備名稱" DataField="EquipName" HeaderStyle-HorizontalAlign="Left"
                    ItemStyle-HorizontalAlign="Left" />
                <asp:BoundField HeaderText="管制號碼" DataField="ControlNO" HeaderStyle-HorizontalAlign="Left"
                    ItemStyle-HorizontalAlign="Left" />
                <asp:TemplateField HeaderText="儀器型號">
                    <ItemTemplate>
                        <asp:Label ID="LbEquipModel" runat="server" Text='<%# DataBinder.Eval(Container,"DataItem.EquipModel").ToString() %>'></asp:Label>
                    </ItemTemplate>
                    <HeaderStyle HorizontalAlign="Left" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="主要規格">
                    <ItemTemplate>
                        <asp:Label ID="LbSpecification" runat="server" Text='<%# DataBinder.Eval(Container,"DataItem.Specification").ToString() %>'></asp:Label>
                    </ItemTemplate>
                    <HeaderStyle HorizontalAlign="Left" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="有無附件" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                    <ItemTemplate>
                        <asp:Label ID="LbisHasDetail" runat="server" Text='<%# DataBinder.Eval(Container,"DataItem.IsHasDetail").ToString() %>'
                            Visible="False"></asp:Label>
                        <asp:Label ID="LbshowisHasDetail" runat="server" Text=""></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField Visible ="false" >
                    <ItemTemplate>
                        <asp:ImageButton ID="BtnDelete" runat="server" ImageUrl="~/Images/Delete.gif"
                            CommandName="Delete"></asp:ImageButton>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
    </asp:GridView>
</div>