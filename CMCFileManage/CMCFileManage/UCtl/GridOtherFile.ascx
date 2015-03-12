<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="GridOtherFile.ascx.vb"
    Inherits="CMCFileManage.GridOtherFile" %>
<div>
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" Width="100%">
        <Columns>
            <asp:TemplateField Visible ="false" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                <ItemTemplate>
                    <asp:Label ID="LblPKID" runat="server" Text='<%# DataBinder.Eval(Container,"DataItem.PKID").ToString() %>'
                        Visible="False"></asp:Label>
                    <asp:HyperLink ID="HLDetail" Visible ="false"  Target="MainFrame" runat="server" ToolTip="查看" ImageUrl="~/Images/edit.gif">查看</asp:HyperLink>
                </ItemTemplate>
                <HeaderStyle HorizontalAlign="Left" />
                <ItemStyle HorizontalAlign="Left" />
            </asp:TemplateField>
            <asp:BoundField DataField="StandardName" HeaderText="標準名稱" HeaderStyle-HorizontalAlign="Left"
                ItemStyle-HorizontalAlign="Left" ItemStyle-Width="350px" ItemStyle-VerticalAlign="Top">
                <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                <ItemStyle HorizontalAlign="Left"></ItemStyle>
            </asp:BoundField>
            <asp:BoundField DataField="StandardNumber" HeaderText="標準號碼" HeaderStyle-HorizontalAlign="Left"
                ItemStyle-HorizontalAlign="Left">
                <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                <ItemStyle HorizontalAlign="Left"></ItemStyle>
            </asp:BoundField>
            <asp:BoundField DataField="StandardVersion" HeaderText="REV" HeaderStyle-HorizontalAlign="Left"
                ItemStyle-HorizontalAlign="Left">
                <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                <ItemStyle HorizontalAlign="Left"></ItemStyle>
            </asp:BoundField>
           <%-- <asp:TemplateField HeaderText="狀態" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                <ItemTemplate>
                    <asp:Label ID="LbFileStatusnum" Visible="false" runat="server" Text='<%# DataBinder.Eval(Container,"DataItem.StandardStatus").ToString() %>'></asp:Label>
                    <asp:Label ID="LbFileStatus" runat="server" Text=""></asp:Label>
                </ItemTemplate>
                <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                <ItemStyle HorizontalAlign="Left"></ItemStyle>
            </asp:TemplateField>
            <asp:BoundField DataField="StandardOrganize" HeaderText="標準組織" HeaderStyle-HorizontalAlign="Left"
                ItemStyle-HorizontalAlign="Left">
                <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                <ItemStyle HorizontalAlign="Left"></ItemStyle>
            </asp:BoundField>--%>
            <asp:TemplateField HeaderStyle-HorizontalAlign="Left" Visible ="false"  ItemStyle-HorizontalAlign="Left">
                <ItemTemplate>
                    <asp:ImageButton ID="BtnDelete" runat="server" ImageUrl="~/Images/Delete.gif" CommandName="Delete">
                    </asp:ImageButton>
                </ItemTemplate>
                <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                <ItemStyle HorizontalAlign="Left"></ItemStyle>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
</div>
