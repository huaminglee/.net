<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="AddFileShareList.aspx.vb"
    Inherits="CRM.AddFileShareList" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<%@ Register Assembly="eFlowWebControl" Namespace="eFlowWebControl" TagPrefix="cc1" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../CSS/newaction.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div id="search">
        <ul class="searchli">
            <li>
                <asp:TextBox ID="TxtSearchCondition" class="text-input" runat="server" Width="500px"></asp:TextBox></li>
            <asp:RadioButtonList ID="RadioButtonList1" runat="server" RepeatDirection="Horizontal"
                RepeatLayout="Flow" AutoPostBack="True">
                <asp:ListItem>待送审</asp:ListItem>
                <asp:ListItem Selected="True">待审核</asp:ListItem>
                <asp:ListItem>已核准</asp:ListItem>
            </asp:RadioButtonList>
            <asp:Button ID="Button1" class="button" runat="server" Text="搜尋" Height="30px" />
        </ul>
    </div>
    <div style="clear: both">
    </div>
    <div id="emptyinfo" runat="server" visible="false" style="width: 100%; height: 30px;
        background-color: #DBE3FF; line-height: 30px; overflow: hidden;">
        <asp:Image ID="Image1" runat="server" ImageUrl="~/Images/Icons/information.png" />
        &nbsp;&nbsp;&nbsp; 沒有找到相關記錄，請嘗試其他選項。</div>
    <div>
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" Width="100%">
            <Columns>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:Label ID="LblNo" Width="30px" runat="server" Text="<%# Container.DataItemIndex+1+PageSize*(PageIndex-1)%>"></asp:Label>
                        <asp:Label ID="lbPKID" runat="server" Text='<%# DataBinder.Eval(Container,"DataItem.PKID").ToString() %>'
                            Visible="False"></asp:Label>
                        <asp:Label ID="LbCustomerPKID" Visible ="false"  runat="server" Text='<%# DataBinder.Eval(Container,"DataItem.CustomerPKID").ToString() %>'></asp:Label>
                        <asp:Label ID="lblDocUniqueID" runat="server" Text='<%# DataBinder.Eval(Container,"DataItem.eFlowDocID").ToString() %>'
                            Visible="False"></asp:Label>
                        <asp:HyperLink ID="HLDetail" Target="_self" runat="server" ToolTip="編輯" ImageUrl="../Images/ico/pen.png">查看</asp:HyperLink>&nbsp;&nbsp;
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="CustomerName" HeaderText="客户" />
                <asp:BoundField DataField="UploadUserSID" HeaderText="上传者" />
                <asp:BoundField DataField="RecordCreated" DataFormatString="{0:yyyy-MM-dd}" HeaderText="时间" />
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:ImageButton ID="BtnDelete" runat="server" ToolTip="刪除" ImageUrl="../Images/ico/trash.png"
                            CommandName="Delete"></asp:ImageButton>
                    </ItemTemplate>
                </asp:TemplateField>
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
