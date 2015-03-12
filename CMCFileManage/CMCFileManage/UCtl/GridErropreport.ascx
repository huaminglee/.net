<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="GridErropreport.ascx.vb" Inherits="CMCFileManage.GridErropreport" %>
<div>
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
        Width="100%">
        <Columns>
                <asp:TemplateField Visible ="false" >
                    <ItemTemplate>
                      
                        <asp:Label ID="LblPKID" runat="server" Text='<%# DataBinder.Eval(Container,"DataItem.PKID").ToString() %>'
                            Visible="False"></asp:Label>
                        <asp:HyperLink ID="HLDetail" Target="MainFrame" runat="server" ToolTip="編輯" ImageUrl="~/Images/edit.gif">查看</asp:HyperLink>
                    </ItemTemplate>
                    <HeaderStyle HorizontalAlign="Left" />
                    <ItemStyle HorizontalAlign="Left" />
                </asp:TemplateField>
              
                <asp:BoundField DataField="ReportBH" HeaderText="記錄編號" HeaderStyle-HorizontalAlign="Left"
                    ItemStyle-HorizontalAlign="Left" />
                <asp:TemplateField HeaderText="審核日期" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                    <ItemTemplate>
                        <asp:Label ID="LblReportTime" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.ReportDate","{0:yyyy-MM-dd}") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="完成日期" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                    <ItemTemplate>
                        <asp:Label ID="LblFinishTime" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.FinishTime","{0:yyyy-MM-dd}") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="缺失類型" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                    <ItemTemplate>
                        <asp:Label ID="LbType" Visible="false" runat="server" Text='<%# DataBinder.Eval(Container,"DataItem.AppSec").tostring() %>'>
                        </asp:Label><asp:Label ID="LbTypeShow" runat="server" Text=""></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="驗證結果" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                    <ItemTemplate>
                        <asp:Label ID="LbResult" runat="server" Text='<%# DataBinder.Eval(Container,"DataItem.VertifyResult").tostring() %>'
                            Visible="false"></asp:Label><asp:Label ID="LbresultShow" runat="server" Text=""></asp:Label>
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