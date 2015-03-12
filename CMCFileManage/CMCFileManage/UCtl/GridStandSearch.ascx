<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="GridStandSearch.ascx.vb" Inherits="CMCFileManage.GridStandSearch" %>
<div>
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
        Width="100%">
         <Columns>
                <asp:TemplateField Visible ="false" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                    <ItemTemplate>
                        <asp:Label ID="LblPKID" runat="server" Text='<%# DataBinder.Eval(Container,"DataItem.PKID").ToString() %>'
                            Visible="False"></asp:Label>
                        <asp:HyperLink ID="HLDetail" Visible ="false"  Target="MainFrame" runat="server" ToolTip="編輯" ImageUrl="~/Images/edit.gif">查看</asp:HyperLink>
                    </ItemTemplate>
                    <HeaderStyle HorizontalAlign="Left" />
                    <ItemStyle HorizontalAlign="Left" />
                </asp:TemplateField>
                <asp:BoundField DataField="SearchJD" HeaderText="季度" HeaderStyle-HorizontalAlign="Left"
                    ItemStyle-HorizontalAlign="Left" />
                <asp:TemplateField HeaderText="生效時間" SortExpression="EffectDate" HeaderStyle-HorizontalAlign="Left"
                    ItemStyle-HorizontalAlign="Left">
                    <ItemTemplate>
                        <asp:Label ID="LblApplyTime" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.SearchTime","{0:yyyy-MM-dd}") %>'></asp:Label>
                    </ItemTemplate>
                    <HeaderStyle Wrap="False" />
                    <HeaderStyle HorizontalAlign="Left" />
                </asp:TemplateField>
                <asp:BoundField DataField="SearchUser" HeaderText="查新人" HeaderStyle-HorizontalAlign="Left"
                    ItemStyle-HorizontalAlign="Left" />
                <asp:BoundField DataField="Remark" HeaderText="備註" HeaderStyle-HorizontalAlign="Left"
                    ItemStyle-HorizontalAlign="Left" />
                <asp:TemplateField HeaderStyle-HorizontalAlign="Left" Visible =false  ItemStyle-HorizontalAlign="Left">
                    <ItemTemplate>
                        <asp:ImageButton ID="BtnDelete" runat="server" ImageUrl="~/Images/Delete.gif"
                            CommandName="Delete"></asp:ImageButton>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
    </asp:GridView>
</div>