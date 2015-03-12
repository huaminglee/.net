<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="BusOppList.aspx.vb" Inherits="CRM.BusOppList" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<%@ Register Assembly="eFlowWebControl" Namespace="eFlowWebControl" TagPrefix="cc1" %>

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
     <link href="../CSS/newaction.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:TextBox ID="TxtSearchCondition" Width="400px" runat="server"></asp:TextBox><asp:Button
            ID="BtnSearch" runat="server" class="button" Text="搜尋" />
        &nbsp;
        <a class="button" href="../Forms/BusOppDetail.aspx">新增</a>
    </div>
    <div>
    
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
            Width="100%">
            <Columns>
                <asp:TemplateField><ItemTemplate>
                        <asp:Label ID="LblNo" Width="30px" runat="server" Text="<%# Container.DataItemIndex+1+PageSize*(PageIndex-1)%>"></asp:Label>
                        <asp:HyperLink ID="HLDetail" Target="_self" runat="server" ToolTip="編輯" ImageUrl="../Images/ico/pen.png">查看</asp:HyperLink>&nbsp;&nbsp;
                    </ItemTemplate></asp:TemplateField>
                <asp:BoundField DataField="OpportName" HeaderText="業務機會名" />
                <asp:BoundField DataField="Category" HeaderText="階段" />
                <asp:BoundField DataField="Type" HeaderText="類型" />
                <asp:BoundField DataField="Possibility" HeaderText="可能性" />
                <asp:TemplateField><ItemTemplate>
                                    <asp:ImageButton ID="BtnDelete" runat="server" ToolTip="刪除" ImageUrl="../Images/ico/trash.png"
                                        CommandName="Delete"></asp:ImageButton>
                                </ItemTemplate></asp:TemplateField>
            </Columns>
        </asp:GridView>
    
    </div>
    <div class="Pager">
        <cc1:PagerControl ID="PagerControl1" Visible="false" runat="server" SkinID="PagerControlSkin">
        </cc1:PagerControl>
    </div>
    <div id="emptyinfo" runat="server" visible="false" style="width: 100%; height: 30px;
        background-color: #DBE3FF; line-height: 30px; overflow: hidden;">
        <asp:Image ID="Image1" runat="server" ImageUrl="~/Images/Icons/information.png" />
        &nbsp;&nbsp;&nbsp; 沒有找到相關記錄，請嘗試其他選項。</div>
    </form>
</body>
</html>
