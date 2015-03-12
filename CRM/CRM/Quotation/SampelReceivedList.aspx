<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="SampelReceivedList.aspx.vb" Inherits="CRM.SampelReceivedList" %>

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
                      
                        <asp:HyperLink ID="HLDetail" Target="_self" runat="server" ToolTip="編輯" ImageUrl="../Images/ico/pen.png">查看</asp:HyperLink>&nbsp;&nbsp;
                       
                    </ItemTemplate>
                    <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                    <ItemStyle Width="150px"></ItemStyle>
                </asp:TemplateField>
                    <asp:BoundField DataField="CustomerName" HeaderText="客戶" />
                    <asp:BoundField DataField="SampleName" HeaderText="樣品">
                    <ItemStyle Width="150px" />
                    </asp:BoundField>
                    <asp:BoundField DataField="InformUser" HeaderText="業務員" />
                    <asp:BoundField DataField="AcceptUser" HeaderText="收件人員" />
                    <asp:BoundField DataField="ReachTime" DataFormatString="{0:yyyy-MM-dd}" 
                        HeaderText="收件時間" />
                    <asp:BoundField DataField="Remark" HeaderText="備註">
                    <ItemStyle Width="150px" />
                    </asp:BoundField>
                    <asp:TemplateField>
                    <ItemTemplate>
                        <asp:ImageButton ID="BtnDelete" runat="server" ToolTip="刪除" ImageUrl="../Images/ico/trash.png"
                            CommandName="Delete"></asp:ImageButton>
                    </ItemTemplate>
                    </asp:TemplateField>
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
