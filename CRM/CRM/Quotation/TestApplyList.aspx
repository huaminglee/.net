<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="TestApplyList.aspx.vb" Inherits="CRM.TestApplyList" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<%@ Register Assembly="eFlowWebControl" Namespace="eFlowWebControl" TagPrefix="cc1" %>
<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
            Width="100%" EmptyDataText="無相關數據">
            <EmptyDataRowStyle ForeColor="Red" />
            <Columns>
                <asp:TemplateField>
                 <ItemTemplate>
                        <asp:Label ID="LblNo" Width="30px" runat="server" Text="<%# Container.DataItemIndex+1+PageSize*(PageIndex-1)%>"></asp:Label>
                        <asp:Label ID="lbPKID" runat="server" Text='<%# DataBinder.Eval(Container,"DataItem.ApplyPKID").ToString() %>'
                            Visible="False"></asp:Label>
                        <asp:Label ID="lblDocUniqueID" runat="server" Text='<%# DataBinder.Eval(Container,"DataItem.eFlowDocID").ToString() %>'
                            Visible="False"></asp:Label>
                        <asp:HyperLink ID="HLDetail" Target="_self" runat="server" ToolTip="編輯" ImageUrl="~/Images/edit.gif">查看</asp:HyperLink>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="CustomerName" HeaderText="客戶名" />
                <asp:BoundField DataField="QuotationNO" HeaderText="報價單號" />
                <asp:BoundField DataField="TestNO" HeaderText="申請單號" />
                <asp:BoundField DataField="LaboratoryServices" HeaderText="服務類別" />
                <asp:BoundField DataField="TestItems" HeaderText="測試項目" />
                <asp:BoundField DataField="SampleS" HeaderText="樣品名稱" />
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
