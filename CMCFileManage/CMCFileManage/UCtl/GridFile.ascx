<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="GridFile.ascx.vb" Inherits="CMCFileManage.GridFile" %>
<div>
    
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" Width="100%">
                <Columns>
                    <asp:TemplateField Visible ="false">
                        <ItemTemplate >
                            <asp:Label ID="LblPKID" runat="server" Text='<%# DataBinder.Eval(Container,"DataItem.PKID").ToString() %>'
                                Visible="False"></asp:Label>
                            <asp:Label ID="lblDocUniqueID" runat="server" Text='<%# DataBinder.Eval(Container,"DataItem.eFlowDocID").ToString() %>'
                                Visible="False"></asp:Label>
                            <asp:HyperLink ID="HLDetail" Visible ="false"  Target="MainFrame" runat="server" ToolTip="編輯" ImageUrl="~/Images/edit.gif">查看</asp:HyperLink>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="FileName" HeaderText="文件名" ItemStyle-Width="350px" />
                    <asp:BoundField DataField="FileBH" HeaderText="文件號碼" />
                    <asp:BoundField DataField="RecordNO" HeaderText="變更號碼" />
                    <asp:BoundField DataField="FileVersion" HeaderText="REV" />
                    <asp:BoundField DataField="ToTalPage" HeaderText="頁數" />
                    <asp:BoundField DataField="EffectDate" HeaderText="生效時間" />
                     <asp:TemplateField Visible="false">
                    <ItemTemplate>
                        <asp:ImageButton ID="BtnDelete" runat="server" ImageUrl="~/Images/Delete.gif" CommandName="Delete">
                        </asp:ImageButton>
                    </ItemTemplate>
                </asp:TemplateField>
                </Columns>
            </asp:GridView>
       
</div>
