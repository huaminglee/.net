<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="GridDeptOutfile.ascx.vb" Inherits="CMCFileManage.GridDeptOutfile" %>
<%@ Register src="GridQy.ascx" tagname="GridQy" tagprefix="uc1" %>
<div>
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" Width="100%">
                    <Columns>
                        <asp:TemplateField HeaderText="實驗室" ItemStyle-Width="150px">
                            <ItemTemplate>
                                <asp:Image ID="Image1" style="cursor:hand;" runat="server" ImageUrl="../Images/addGrid.png" />
                                <asp:Label ID="LbDept" runat="server" Text='<%#DataBinder.Eval(Container,"DataItem.ApplyDept")%>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <ItemTemplate>
                              <uc1:GridQy ID="GridQy1" runat="server" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="Nums" HeaderText="數量" HeaderStyle-HorizontalAlign="Right"
                            ItemStyle-HorizontalAlign="Right" ItemStyle-Width="50px" />
                    </Columns>
                </asp:GridView>
</div>


