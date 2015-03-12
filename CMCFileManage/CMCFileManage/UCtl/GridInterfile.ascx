<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="GridInterfile.ascx.vb"
    Inherits="CMCFileManage.GridInterfile" %>
<div>
    <asp:GridView ID="GridView1" runat="server" Width="100%" AutoGenerateColumns="False">
        <Columns>
            <asp:TemplateField HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                <HeaderStyle HorizontalAlign="Left" />
                <ItemStyle HorizontalAlign="Left" />
                <ItemTemplate>
                    <asp:Label ID="LblPKID" runat="server" Text='<%# DataBinder.Eval(Container,"DataItem.PKID").ToString() %>'
                        Visible="False"></asp:Label>
                    <asp:HyperLink ID="HLDetail" Visible="false" Target="MainFrame" runat="server" ToolTip="編輯"
                        ImageUrl="~/Images/edit.gif">查看</asp:HyperLink>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="RecordNO" HeaderText="記錄編號" HeaderStyle-HorizontalAlign="Left"
                ItemStyle-HorizontalAlign="Left">
                <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                <ItemStyle HorizontalAlign="Left"></ItemStyle>
            </asp:BoundField>
            <asp:BoundField DataField="Name" HeaderText="名稱" HeaderStyle-HorizontalAlign="Left"
                ItemStyle-HorizontalAlign="Left">
                <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                <ItemStyle HorizontalAlign="Left"></ItemStyle>
            </asp:BoundField>
            <asp:TemplateField HeaderText="制定日期" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                <ItemTemplate>
                    <asp:Label ID="LblApplyTime" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.FormulDate","{0:yyyy-MM-dd}") %>'></asp:Label>
                </ItemTemplate>
                <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                <ItemStyle HorizontalAlign="Left"></ItemStyle>
            </asp:TemplateField>
            <asp:TemplateField HeaderStyle-HorizontalAlign="Left" Visible="false" ItemStyle-HorizontalAlign="Left">
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
