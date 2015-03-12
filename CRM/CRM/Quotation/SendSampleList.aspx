<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="SendSampleList.aspx.vb" Inherits="CRM.SendSampleList" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<%@ Register Assembly="eFlowWebControl" Namespace="eFlowWebControl" TagPrefix="cc1" %>
<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
    <link href="../CSS/newaction.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server" defaultbutton ="Button1">
     <div id="search">
        <ul class="searchli">
            <li>
                <asp:TextBox ID="TxtSearchCondition" class="text-input" runat="server" Width="500px"></asp:TextBox></li>
            <li>
             
                <asp:Button ID="Button1" class="button" runat="server" Text="搜尋" Height="30px" />
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
        
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
                Width="100%">
                <RowStyle HorizontalAlign="Left" />
                <Columns>
                 <asp:TemplateField HeaderStyle-HorizontalAlign="Left">
                    <ItemTemplate>
                        <asp:Label ID="LblNo" Width="30px" runat="server" Text="<%# Container.DataItemIndex+1+PageSize*(PageIndex-1)%>"></asp:Label>
                        <asp:Label ID="lbPKID" runat="server" Text='<%# DataBinder.Eval(Container,"DataItem.PKID").ToString() %>'
                            Visible="False"></asp:Label>
                      
                        <asp:HyperLink ID="HLDetail" Visible ="false"  Target="_self" runat="server" ToolTip="編輯" ImageUrl="../Images/ico/pen.png">查看</asp:HyperLink>&nbsp;&nbsp;
                       
                    </ItemTemplate>
                    <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                    
                </asp:TemplateField>
                    <asp:BoundField DataField="QuotationNO" 
                        HeaderText="報價單號" />
                    <asp:BoundField DataField="CustomerName" HeaderText="客戶" ItemStyle-Width="200px" />
                    <asp:BoundField DataField="ContactName" HeaderText="收件人">
                    </asp:BoundField>
                    <asp:BoundField DataField="Address" HeaderText="地址" ItemStyle-Width="300px" />
                    <asp:BoundField DataField="TestNos" HeaderText="測試編號" ItemStyle-Width="100px" />
                    <asp:BoundField DataField="Sample" HeaderText="樣品">
                    <ItemStyle Width="150px" />
                    </asp:BoundField>
                    <asp:BoundField DataField="QuotaerName" HeaderText="業務員" />
                </Columns>
                <HeaderStyle HorizontalAlign="Left" />
            </asp:GridView>
        
        </div>
     <div class="Pager">
        <cc1:PagerControl ID="PagerControl1" Visible="false" runat="server" SkinID="PagerControlSkin">
        </cc1:PagerControl>
    </div>
    
    </form>
</body>
</html>
