<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="GridEquipFile.ascx.vb"
    Inherits="CMCFileManage.GridEquipFile" %>
<div>
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" Width="100%">
        <Columns>
            <asp:TemplateField HeaderStyle-HorizontalAlign="Left" Visible ="false"  ItemStyle-HorizontalAlign="Left">
                <ItemTemplate>
                    <asp:Label ID="LblPKID" runat="server" Text='<%# DataBinder.Eval(Container,"DataItem.PKID").ToString() %>'
                        Visible="False"></asp:Label>
                    <asp:Label ID="lblDocUniqueID" runat="server" Text='<%# DataBinder.Eval(Container,"DataItem.eFlowDocID").ToString() %>'
                        Visible="False"></asp:Label>
                    <asp:HyperLink ID="HLDetail" Target="MainFrame" runat="server" ToolTip="編輯" ImageUrl="~/Images/edit.gif">查看</asp:HyperLink>
                </ItemTemplate>
                <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                <ItemStyle HorizontalAlign="Left"></ItemStyle>
            </asp:TemplateField>
            <asp:BoundField HeaderText="設備名稱" DataField="EquipName" ItemStyle-HorizontalAlign="Left"
                HeaderStyle-HorizontalAlign="Left">
                <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                <ItemStyle HorizontalAlign="Left"></ItemStyle>
            </asp:BoundField>
            <asp:BoundField HeaderText="附件名" DataField="DetailName" ItemStyle-HorizontalAlign="Left"
                HeaderStyle-HorizontalAlign="Left">
                <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                <ItemStyle HorizontalAlign="Left"></ItemStyle>
            </asp:BoundField>
            <asp:BoundField HeaderText="管制號碼" DataField="ControlNO" ItemStyle-HorizontalAlign="Left"
                HeaderStyle-HorizontalAlign="Left">
                <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                <ItemStyle HorizontalAlign="Left"></ItemStyle>
            </asp:BoundField>
            <asp:BoundField HeaderText="儀器型號" DataField="EquipModel" ItemStyle-HorizontalAlign="Left"
                HeaderStyle-HorizontalAlign="Left">
                <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                <ItemStyle HorizontalAlign="Left"></ItemStyle>
            </asp:BoundField>
            <asp:BoundField HeaderText="數量" DataField="EquipNum" ItemStyle-HorizontalAlign="Left"
                HeaderStyle-HorizontalAlign="Left">
                <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                <ItemStyle HorizontalAlign="Left"></ItemStyle>
            </asp:BoundField>
            <asp:BoundField DataField="ManuFacturer" HeaderText="廠商" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left" />
            <asp:BoundField DataField="MainSpecification" HeaderText="規格" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left"/>
            <asp:BoundField DataField="EquipLocation" HeaderText="地點" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left"/>
            <asp:BoundField DataField="KeepUser" HeaderText="保管人" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left"/>
            <asp:BoundField DataField="Extend1" HeaderText="備註" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left"/>
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
