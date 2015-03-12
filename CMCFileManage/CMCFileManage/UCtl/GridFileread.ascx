<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="GridFileread.ascx.vb"
    Inherits="CMCFileManage.GridFileread" %>
<div>
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" Width="100%">
        <Columns>
            <asp:BoundField HeaderText="實驗室" DataField="ReadDept" HeaderStyle-HorizontalAlign="Left"
                ItemStyle-HorizontalAlign="Left">
                <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                <ItemStyle HorizontalAlign="Left"></ItemStyle>
            </asp:BoundField>
            <asp:BoundField HeaderText="申請人" DataField="ApplyUser" ItemStyle-HorizontalAlign="Left"
                HeaderStyle-HorizontalAlign="Left">
                <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                <ItemStyle HorizontalAlign="Left"></ItemStyle>
            </asp:BoundField>
            <asp:TemplateField HeaderText="申請時間">
                <HeaderStyle HorizontalAlign="Left" />
                <ItemStyle HorizontalAlign="Left" />
                <ItemTemplate>
                 <asp:Label ID="lblDocUniqueID" runat="server" Text='<%# DataBinder.Eval(Container,"DataItem.eFlowDocID").ToString() %>'
                                Visible="False"></asp:Label>
                    <asp:Label ID="LblApplyTime" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.ApplyTime","{0:yyyy-MM-dd}") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="文件名稱">
                <HeaderStyle HorizontalAlign="Left" />
                <ItemStyle HorizontalAlign="Left" />
                <ItemTemplate>
                    <asp:Label ID="LbFileName" runat="server" Text='<%# DataBinder.Eval(Container,"DataItem.FileName").ToString() %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="文件號碼">
                <HeaderStyle HorizontalAlign="Left" />
                <ItemStyle HorizontalAlign="Left" />
                <ItemTemplate>
                    <asp:Label ID="LbFileBH" runat="server" Text='<%# DataBinder.Eval(Container,"DataItem.FileBH").ToString() %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField Visible="false" >
                <ItemTemplate>
                    <asp:ImageButton ID="BtnDelete" runat="server" ImageUrl="~/Images/Delete.gif" CommandName="Delete">
                    </asp:ImageButton>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
</div>
