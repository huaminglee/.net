<%@ Page Language="vb" AutoEventWireup="false" Theme="Default" CodeBehind="GMPCSIList.aspx.vb"
    Inherits="CRM.GMPCSIList" %>

<%@ Register Assembly="eFlowWebControl" Namespace="eFlowWebControl" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" Width="100%"
            EmptyDataText="無數據">
            <Columns>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:Label ID="LblNo" Width="30px" runat="server" Text="<%# Container.DataItemIndex+1+PageSize*(PageIndex-1)%>"></asp:Label>
                        <asp:Label ID="LbResultPKID" Visible="false" runat="server" Text='<%# DataBinder.Eval(Container,"DataItem.ResultPKID") %>'></asp:Label>
                        <asp:Label ID="LbCSITime" Visible="false" runat="server" Text='<%# DataBinder.Eval(Container,"DataItem.CSITime") %>'></asp:Label>
                        <asp:Label ID="LbDeptPKID" Visible="false" runat="server" Text='<%# DataBinder.Eval(Container,"DataItem.DeptPKID") %>'></asp:Label>
                        <asp:HyperLink ID="HLDetail" Target="_self" runat="server" ToolTip="編輯" ImageUrl="~/Images/edit.gif">查看</asp:HyperLink>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="DeptName" HeaderText="調查單位" HeaderStyle-HorizontalAlign="Left" />
                <asp:BoundField DataField="SubmitMan" HeaderText="提交人" HeaderStyle-HorizontalAlign="Left" />
                <asp:BoundField DataField="SubmitTime" HeaderText="提交時間" HeaderStyle-HorizontalAlign="Left" />
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
