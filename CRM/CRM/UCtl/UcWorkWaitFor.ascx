<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="UcWorkWaitFor.ascx.vb"
    Inherits="CRM.UcWorkWaitFor" %>

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
                        <table width="100%" onmouseover="c=this.style.backgroundColor;this.style.backgroundColor='#79B900'"
                            onmouseout="this.style.backgroundColor=c">
                            <tr>
                                <td height="30px">
                                    <a id="eflowhrf" runat ="server"  href='<%# DataBinder.Eval(Container,"DataItem.SysUrl").ToString() %>' target="_parent">
                                        <asp:Label ID="LbURL" Visible="false" runat="server" Text='<%# DataBinder.Eval(Container,"DataItem.SysUrl").ToString() %>'></asp:Label>
                                        流程：
                                        <%#Eval("StateName")%>
                                        單號：<asp:Label ID="LbNo" runat="server" Text="" ForeColor="#993333"></asp:Label>
                                        客戶：<asp:Label ID="LBCustomerName" runat="server" Text="" ForeColor="#993333"></asp:Label>
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
