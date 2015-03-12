<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="GridPersonDept.ascx.vb" Inherits="CMCFileManage.GridPersonDept" %>
<%@ Register src="GridPerson.ascx" tagname="GridPerson" tagprefix="uc1" %>
<%@ Register src="GridErropreport.ascx" tagname="GridErropreport" tagprefix="uc2" %>
<div>
     
            <div>
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" Width="100%">
                    <Columns>
                        <asp:TemplateField HeaderText="實驗室" ItemStyle-Width="150px">
                            <ItemTemplate>
                                <asp:Image ID="Image1" style="cursor:hand;" runat="server" ImageUrl="../Images/addGrid.png" />
                                <asp:Label ID="LbDept" runat="server" Text='<%#DataBinder.Eval(Container,"DataItem.Dept")%>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <uc1:GridPerson ID="GridPerson1" runat="server" />
                                <uc2:GridErropreport ID="GridErropreport1" runat="server" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="Nums" HeaderText="數量" HeaderStyle-HorizontalAlign="Right"
                            ItemStyle-HorizontalAlign="Right" ItemStyle-Width="50px" />
                    </Columns>
                </asp:GridView>
            </div>
            
            <div style="display: none">
                <asp:Button ID="Button1" runat="server" Text="Button" />
            </div>
       
</div>




