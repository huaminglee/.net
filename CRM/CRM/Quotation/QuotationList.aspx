<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="QuotationList.aspx.vb"
    Inherits="CRM.QuotationList" %>

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
            <li>
                <asp:RadioButtonList ID="RadioButtonList1" runat="server" Visible="false" RepeatDirection="Horizontal"
                    RepeatLayout="Flow">
                    <asp:ListItem Selected="True" Value="1">全部</asp:ListItem>
                    <asp:ListItem Value="2">正常結案</asp:ListItem>
                    <asp:ListItem Value="3">異常結案</asp:ListItem>
                </asp:RadioButtonList>
                <asp:RadioButtonList ID="RadioButtonList2" runat="server" Visible="false" RepeatDirection="Horizontal"
                    RepeatLayout="Flow">
                    <asp:ListItem Selected="True" Value="1">待處理</asp:ListItem>
                    <asp:ListItem Value="2">已核准</asp:ListItem>
                    <asp:ListItem Value="3">已駁回</asp:ListItem>
                </asp:RadioButtonList>
                <asp:Button ID="Button1" class="button" runat="server" Text="搜尋" Height="30px" />
                &nbsp;<asp:Button ID="BtnExcel" Visible="false" class="button" runat="server" Text="導出"
                    Height="30px" /></li>
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
                <asp:TemplateField HeaderStyle-HorizontalAlign="Left">
                    <ItemTemplate>
                        <asp:Label ID="LblNo" Width="30px" runat="server" Text="<%# Container.DataItemIndex+1+PageSize*(PageIndex-1)%>"></asp:Label>
                        <asp:Label ID="lbPKID" runat="server" Text='<%# DataBinder.Eval(Container,"DataItem.PKID").ToString() %>'
                            Visible="False"></asp:Label>
                        <asp:Label ID="lblDocUniqueID" runat="server" Text='<%# DataBinder.Eval(Container,"DataItem.eFlowDocID").ToString() %>'
                            Visible="False"></asp:Label>
                        <asp:HyperLink ID="HLDetail" Target="_self" runat="server" ToolTip="編輯" ImageUrl="../Images/ico/pen.png">查看</asp:HyperLink>&nbsp;&nbsp;
                        <asp:HyperLink ID="HLCopy" Target="_self" Style="display: none" runat="server" ToolTip="快速生成申請單"
                            ImageUrl="../Images/ico/new_window.png">快速生成</asp:HyperLink>
                        <asp:Image ID="iMGTimeOut" Visible="false" ToolTip="超希望完成日期時間" runat="server" ImageUrl="../Images/ico/warning.png" /><asp:Label
                            ID="LbTimeOut" runat="server" Text=""></asp:Label>
                    </ItemTemplate>
                    <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                    <ItemStyle Width="150px"></ItemStyle>
                </asp:TemplateField>
                <asp:TemplateField Visible="false" HeaderText="當前狀態" SortExpression="StateName" HeaderStyle-HorizontalAlign="Left"
                    ItemStyle-HorizontalAlign="Left">
                    <ItemTemplate>
                        <asp:Label ID="LbCurrentState" runat="server" Text='<%# DataBinder.Eval(Container,"DataItem.StateName").ToString() %>'></asp:Label>
                    </ItemTemplate>
                    <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                    <ItemStyle HorizontalAlign="Left"></ItemStyle>
                </asp:TemplateField>
                <asp:BoundField DataField="QuotationNO" HeaderText="報價單號" SortExpression="QuotationNO"
                    HeaderStyle-HorizontalAlign="Left">
                    <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                </asp:BoundField>
                <asp:BoundField DataField="QuotaerName" HeaderText="報價人" HeaderStyle-HorizontalAlign="Left">
                    <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                </asp:BoundField>
                <asp:BoundField DataField="QuoteDate" HeaderText="報價日期" SortExpression="QuoteDate"
                    DataFormatString="{0:yy-MM-dd}" HeaderStyle-HorizontalAlign="Left">
                    <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                </asp:BoundField>
                <asp:BoundField DataField="CustomerName" HeaderText="客戶名稱" SortExpression="CustomerName"
                    HeaderStyle-HorizontalAlign="Left">
                    <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                </asp:BoundField>
                <asp:BoundField DataField="Sample" HeaderText="樣品名" />
                <asp:BoundField DataField="HopeFinishDATE" HeaderText="希望完成時間" DataFormatString="{0:yy-MM-dd}"
                    HeaderStyle-HorizontalAlign="Left">
                    <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                </asp:BoundField>
                <asp:BoundField DataField="FinishTime" HeaderText="結案時間" Visible="false" DataFormatString="{0:yy-MM-dd}"
                    HeaderStyle-HorizontalAlign="Left">
                    <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                </asp:BoundField>
                <asp:TemplateField Visible="false">
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
