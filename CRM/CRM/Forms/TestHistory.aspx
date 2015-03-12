<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="TestHistory.aspx.vb" Inherits="CRM.TestHistory" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div style="height: 100%">
        <table width="100%">
            <tr>
                <td>
                    <div id="emptyinfo" runat="server" visible="false" style="width: 100%; height: 30px;
                        background-color: #DBE3FF; line-height: 30px; overflow: hidden;">
                        <asp:Image ID="Image1" runat="server" ImageUrl="~/Images/Icons/information.png" />
                        &nbsp;&nbsp;&nbsp; 沒有找到相關記錄，請嘗試其他選項。</div>
                    <div style="height: 350px; overflow: scroll; width: 100%;">
                        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" Width="100%">
                            <EmptyDataRowStyle Font-Size="14pt" ForeColor="#993333" Height="30px" />
                            <Columns>
                                <asp:BoundField DataField="TestItemName" Visible="false" HeaderText="測試項目" />
                                <asp:BoundField DataField="QuotationNO" HeaderText="單號" />
                                <asp:BoundField DataField="QuotaerName" HeaderText="報價人" />
                                <asp:BoundField DataField="CustomerName" HeaderText="客戶" />
                                <asp:BoundField DataField="Numbers" HeaderText="數量" />
                                <asp:BoundField DataField="Paijiadanjia" HeaderText="牌價" ItemStyle-ForeColor="#009933">
                                    <ItemStyle ForeColor="#009933"></ItemStyle>
                                </asp:BoundField>
                                <asp:BoundField DataField="Shijidanjia" HeaderText="報價" ItemStyle-ForeColor="#FF3300">
                                    <ItemStyle ForeColor="#FF3300"></ItemStyle>
                                </asp:BoundField>
                                <asp:BoundField DataField="QuoteDate" DataFormatString="{0:yyyy-MM-dd}" HeaderText="時間" />
                            </Columns>
                            <SelectedRowStyle BackColor="Yellow" />
                        </asp:GridView>
                    </div>
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
