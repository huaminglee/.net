<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="UcWorkWaitFor.ascx.vb"
    Inherits="CMCFileManage.UcWorkWaitFor" %>

<div>
    <table border="0.3" width="100%">
        <tr>
            <td>
                <div>
               
                    <asp:Label ID="LbWorkCount" runat="server" Text=""></asp:Label>
                </div>
            </td>
        </tr>
        <tr>
            <td>
                <asp:DataList ID="DataList1" runat="server" Width="100%">
                    <ItemTemplate>
                        <table width="100%" onmouseover="c=this.style.backgroundColor;this.style.backgroundColor='#91D3F6';this.style.color='#FFFFFF';"
                            onmouseout="this.style.backgroundColor=c;this.style.color='#000000';">
                            <tr>
                                <td height="30px">
                                    <a id="eflowhrf" runat ="server"  href='<%# DataBinder.Eval(Container,"DataItem.SysUrl").ToString() %>' target="_parent">
                                        <asp:Label ID="LbURL" Visible="false" runat="server" Text='<%# DataBinder.Eval(Container,"DataItem.SysUrl").ToString() %>'></asp:Label>
                                        站點：
                                        <%#Eval("StateName")%>
                                        <asp:Label ID="Label2" runat="server" Text="申請人："></asp:Label><asp:Label ID="LbApplyPerson" runat="server" Text="" ForeColor="#000000"></asp:Label>
                                       <asp:Label ID="Label1" runat="server" Text="實驗室："></asp:Label><asp:Label ID="LbDept" runat="server" Text="" ForeColor="#000000"></asp:Label>

                                        <asp:Label ID="LbCreateTime" runat="server" Visible="false" Text='<%# DataBinder.Eval(Container, "DataItem.RecordCreateTime","{0:yyyy-MM-dd HH:mm}") %>'></asp:Label>
                                        
                                        停留時間:<asp:Label ID="LbWaitTime" runat="server" Text="" ForeColor="#CC6600"></asp:Label>小時
                                </td>
                            </tr>
                        </table>
                        </a>
                    </ItemTemplate>
                </asp:DataList>
            </td>
        </tr>
    </table>
</div>
