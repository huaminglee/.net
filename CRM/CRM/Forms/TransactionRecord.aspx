<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="TransactionRecord.aspx.vb"
    Inherits="CRM.TransactionRecord" %>

<%@ Register Assembly="eFlowWebControl" Namespace="eFlowWebControl" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../CSS/newaction.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table width="100%" border="1" cellpadding="0" cellspacing="0" bordercolordark="#FFFFFF"
            bordercolor="#999999">
            <tr>
                <td bgcolor="#E6E6E6" height="50">
                    <asp:Image ID="Image1" runat="server" ImageUrl="~/Images/ico/pay.png" />
                    <asp:Label ID="Label8" runat="server" Text="交易統計" Font-Bold="True" Font-Size="14px"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <table class="style1">
                        <tr>
                            <td>
                                報價單統計：<asp:Label ID="LbQuotationNums" runat="server" Font-Bold="True" 
                                    Font-Size="14px" ForeColor="#00CC00"></asp:Label>
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                測試樣品統計：<asp:Label ID="LbSamoleNums" runat="server" Font-Bold="True" 
                                    Font-Size="14px" ForeColor="#00CC00"></asp:Label>
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                測試項目統計：<asp:Label ID="LbTestItemNums" runat="server" Font-Bold="True" 
                                    Font-Size="14px" ForeColor="#00CC00"></asp:Label>
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                總交易額：<asp:Label ID="LbTotalMoney" runat="server" Font-Bold="True" 
                                    Font-Size="14px" ForeColor="#00CC00"></asp:Label>
                            </td>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </div>
    <div>
        <table width="100%" border="1" cellpadding="0" cellspacing="0" bordercolordark="#FFFFFF"
            bordercolor="#999999">
            <tr>
                <td bgcolor="#E6E6E6" height="50">
                    <asp:Image ID="Image2" runat="server" ImageUrl="~/Images/ico/applyinfo.png" />
                    <asp:Label ID="Label1" runat="server" Text="交易明細" Font-Bold="True" Font-Size="14px"></asp:Label>
                    
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    
                    <asp:TextBox ID="TxtSearchCondition" runat="server" Width="200px"></asp:TextBox>
                    <asp:Button ID="Button1" class="button" runat="server" Text="搜尋" />
                     &nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Button ID="BtnBack" class="button" runat="server" Text="返回" />
                    
                </td>
            </tr>
            <tr>
                <td>
                    <div id="emptyinfo" runat="server" visible="false" style="width: 100%; height: 30px;
                        background-color: #DBE3FF; line-height: 30px; overflow: hidden;">
                        <asp:Image ID="Image3" runat="server" ImageUrl="~/Images/Icons/information.png" />
                        &nbsp;&nbsp;&nbsp; 沒有找到相關記錄，請嘗試其他選項。</div>
                    <div>
                        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" Width="100%">
                            <Columns>
                                <asp:TemplateField ItemStyle-Width="100px">
                                    <ItemTemplate>
                                        <asp:Label ID="LblNo" Width="30px" runat="server" Text="<%# Container.DataItemIndex+1+PageSize*(PageIndex-1)%>">
                                        </asp:Label>
                                        <asp:Label ID="lbPKID" runat="server" Text='<%# DataBinder.Eval(Container,"DataItem.PKID").ToString() %>'
                                            Visible="False"></asp:Label>
                                        <asp:Label ID="lblDocUniqueID" runat="server" Text='<%# DataBinder.Eval(Container,"DataItem.eFlowDocID").ToString() %>'
                                            Visible="False"></asp:Label>
                                        <asp:HyperLink ID="HLDetail" Target="_self" runat="server" ToolTip="編輯" ImageUrl="../Images/ico/pen.png">查看</asp:HyperLink>
                                        &nbsp;&nbsp;
                                        <asp:HyperLink ID="HLCopy" Target="_self" style="display :none" runat="server" ToolTip="快速生成申請單" ImageUrl="../Images/ico/new_window.png" >快速生成</asp:HyperLink>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                                </asp:TemplateField>
                                <asp:BoundField DataField="QuotationNO" HeaderText="報價單號" HeaderStyle-HorizontalAlign="Left" />
                                <asp:BoundField DataField="ServiceType" HeaderText="服務類別" HeaderStyle-HorizontalAlign="Left" />
                                <asp:BoundField DataField="TestItemName" HeaderText="測試項目" HeaderStyle-HorizontalAlign="Left" />
                                <asp:BoundField DataField="Numbers" HeaderText="數量" HeaderStyle-HorizontalAlign="Left" />
                                <asp:BoundField DataField="Paijiadanjia" Visible ="false"  HeaderText="牌價" ItemStyle-ForeColor="#009933"
                                    HeaderStyle-HorizontalAlign="Left" />
                                <asp:BoundField DataField="Shijidanjia" HeaderText="報價" ItemStyle-ForeColor="#FF3300"
                                    HeaderStyle-HorizontalAlign="Left" />
                                <asp:BoundField DataField="RecordCreated" DataFormatString="{0:yyyy-MM-dd}" HeaderText="時間"
                                    HeaderStyle-HorizontalAlign="Left" />
                            </Columns>
                        </asp:GridView>
                    </div>
                    <div class="Pager">
                        <cc1:PagerControl ID="PagerControl1" Visible="false" runat="server" SkinID="PagerControlSkin">
                        </cc1:PagerControl>
                    </div>
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
