<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="GridOutFile.ascx.vb"
    Inherits="CMCFileManage.GridOutFile" %>
<div>
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" Width="100%">
        <Columns>
            <asp:TemplateField Visible ="false" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                <ItemTemplate>
                    <asp:Label ID="LblPKID" runat="server" Text='<%# DataBinder.Eval(Container,"DataItem.PKID").ToString() %>'
                        Visible="False"></asp:Label>
                    <asp:Label ID="lblDocUniqueID" runat="server" Text='<%# DataBinder.Eval(Container,"DataItem.eFlowDocID").ToString() %>'
                        Visible="False"></asp:Label>
                    <asp:HyperLink ID="HLDetail" Visible ="false"  Target="MainFrame" runat="server" ToolTip="查看" ImageUrl="~/Images/edit.gif">查看</asp:HyperLink>
                </ItemTemplate>
                <HeaderStyle HorizontalAlign="Left" />
                <ItemStyle HorizontalAlign="Left" />
            </asp:TemplateField>
            <asp:BoundField DataField="FileName" HeaderText="文件名" HeaderStyle-HorizontalAlign="Left"
                ItemStyle-HorizontalAlign="NotSet" ItemStyle-Width="350px">
                <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                <ItemStyle HorizontalAlign="Left"></ItemStyle>
            </asp:BoundField>
            <asp:BoundField DataField="FileBH" HeaderText="文件號碼" HeaderStyle-HorizontalAlign="Left"
                ItemStyle-HorizontalAlign="Left">
                <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                <ItemStyle HorizontalAlign="Left"></ItemStyle>
            </asp:BoundField>
            <asp:BoundField DataField="FileVersion" HeaderText="REV" HeaderStyle-HorizontalAlign="Left"
                ItemStyle-HorizontalAlign="Left">
                <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                <ItemStyle HorizontalAlign="Left"></ItemStyle>
            </asp:BoundField>
            <asp:BoundField DataField="FilePageNum" HeaderText="張數" HeaderStyle-HorizontalAlign="Left"
                ItemStyle-HorizontalAlign="Left">
                <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                <ItemStyle HorizontalAlign="Left"></ItemStyle>
            </asp:BoundField>
            <asp:BoundField DataField="FileNum" HeaderText="份數" HeaderStyle-HorizontalAlign="Left"
                ItemStyle-HorizontalAlign="Left">
                <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                <ItemStyle HorizontalAlign="Left"></ItemStyle>
            </asp:BoundField>
            <asp:BoundField DataField="FileSource" HeaderText="文件來源" HeaderStyle-HorizontalAlign="Left"
                ItemStyle-HorizontalAlign="Left">
                <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                <ItemStyle HorizontalAlign="Left"></ItemStyle>
            </asp:BoundField>
            <asp:BoundField DataField="BackAddress" HeaderText="備份地址" HeaderStyle-HorizontalAlign="Left"
                ItemStyle-HorizontalAlign="Left">
                <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                <ItemStyle HorizontalAlign="Left"></ItemStyle>
            </asp:BoundField>
            <asp:BoundField DataField="BuyTime" HeaderText="購買時間" HeaderStyle-HorizontalAlign="Left"
                ItemStyle-HorizontalAlign="Left">
                <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                <ItemStyle HorizontalAlign="Left"></ItemStyle>
            </asp:BoundField>
            <asp:BoundField DataField="UseFor" HeaderText="用途" HeaderStyle-HorizontalAlign="Left"
                ItemStyle-HorizontalAlign="Left">
                <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                <ItemStyle HorizontalAlign="Left"></ItemStyle>
            </asp:BoundField>
            <asp:BoundField DataField="UseForEquip" HeaderText="適用設備" HeaderStyle-HorizontalAlign="Left"
                ItemStyle-HorizontalAlign="Left">
                <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                <ItemStyle HorizontalAlign="Left"></ItemStyle>
            </asp:BoundField>
            <asp:BoundField DataField="Remark" HeaderText="備註" HeaderStyle-HorizontalAlign="Left"
                ItemStyle-HorizontalAlign="Left">
                <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                <ItemStyle HorizontalAlign="Left"></ItemStyle>
            </asp:BoundField>
            <asp:TemplateField HeaderStyle-HorizontalAlign="Left" Visible ="false" ItemStyle-HorizontalAlign="Left">
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
