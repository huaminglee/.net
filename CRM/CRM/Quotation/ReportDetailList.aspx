<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="ReportDetailList.aspx.vb"
    Inherits="CRM.ReportDetailList" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<%@ Register Assembly="eFlowWebControl" Namespace="eFlowWebControl" TagPrefix="cc1" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../CSS/newaction.css" rel="stylesheet" type="text/css" />

    <script src="../NewScript/UIHelper.js" type="text/javascript"></script>

</head>
<body>
    <form id="form1" runat="server">
    <div id="search">
        <ul class="searchli">
            <li>
                <asp:TextBox ID="TxtSearchCondition" class="text-input" runat="server" Width="500px"></asp:TextBox></li>
            <li>
                
                <asp:Button ID="Button1" class="button" runat="server" Text="搜尋" Height="30px" />
                <asp:Button ID="BtnSendSample" Visible="false" class="button" Height="30px" runat="server" Text="已寄樣品" />
                <asp:Button ID="BtnSendInvoice" Visible="false" class="button" Height="30px" runat="server" Text="已寄發票" />
                <asp:Button ID="BtnDoInvoice" Visible="false" class="button" Height="30px" runat="server" Text="已開發票" />
            </li>
        </ul>
    </div>
    <div style="clear: both">
    </div>
    <div id="emptyinfo" runat="server" visible="false" style="width: 100%; height: 30px;
        background-color: #DBE3FF; line-height: 30px; overflow: hidden;">
        <asp:Image ID="Image1" runat="server" ImageUrl="~/Images/Icons/information.png" />
        &nbsp;&nbsp;&nbsp; 沒有找到相關記錄，請嘗試其他選項。</div>
    <div>
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" Width="100%"
            AllowSorting="True">
            <EmptyDataRowStyle Font-Size="12px" ForeColor="Red" />
            <Columns>
                <asp:TemplateField HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                    <ItemTemplate>
                       
                        <asp:CheckBox ID="ChkSelect" class="chkselect" runat="server" onclick="SelectSingleCheckBoxClick(window.event);" />
                        <asp:Label ID="LblNo" Width="30px" runat="server" Text="<%# Container.DataItemIndex+1+PageSize*(PageIndex-1)%>"></asp:Label>
                        <asp:Label ID="lbPKID" runat="server" Text='<%# DataBinder.Eval(Container,"DataItem.PKID").ToString() %>'
                            Visible="False"></asp:Label>
                             
                            
                        <asp:Label ID="lblDocUniqueID" runat="server" Text='<%# DataBinder.Eval(Container,"DataItem.eFlowDocID").ToString() %>'
                            Visible="False"></asp:Label>
                        <asp:HyperLink ID="HLDetail" Target="_self" runat="server" ToolTip="編輯" ImageUrl="../Images/ico/pen.png">查看</asp:HyperLink>
                         <asp:Image ID="iMGTimeOut" Visible ="false"  runat="server" ImageUrl="../Images/ico/warning.png" /><asp:Label ID="LbTimeOut" runat="server" Text=""></asp:Label>
                        
                    </ItemTemplate>
                    <HeaderTemplate>
                        <asp:CheckBox ID="CheckAll" Text="全選" onclick="CheckChanged()" runat="server" />
                    </HeaderTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="QuotationNO" HeaderText="報價單號" SortExpression="QuotationNO"
                    HeaderStyle-HorizontalAlign="Left">
                    <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                </asp:BoundField>
                 <asp:BoundField DataField="StateName" Visible ="false"  HeaderText="當前狀態" />
                <asp:BoundField DataField="QuotaerName" HeaderText="報價人" SortExpression="QuotaerName"
                    HeaderStyle-HorizontalAlign="Left">
                    <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                </asp:BoundField>
                <asp:BoundField DataField="CustomerName" HeaderText="公司名稱" SortExpression="CustomerName"
                    HeaderStyle-HorizontalAlign="Left">
                    <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                </asp:BoundField>
                <asp:BoundField DataField="ContactName" HeaderText="聯繫人" SortExpression="ContactName"
                    HeaderStyle-HorizontalAlign="Left">
                    <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                </asp:BoundField>
                <asp:BoundField  DataField="QuoteDate" HeaderText="報價日期" SortExpression="QuoteDate"
                    HeaderStyle-HorizontalAlign="Left" DataFormatString="{0:yy-MM-dd}">
                    <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                </asp:BoundField>
            </Columns>
        </asp:GridView>
    </div>
    <div class="Pager">
        <cc1:PagerControl ID="PagerControl1" Visible="false" runat="server" SkinID="PagerControlSkin">
        </cc1:PagerControl>
    </div>
    </form>
</body>
</html>
