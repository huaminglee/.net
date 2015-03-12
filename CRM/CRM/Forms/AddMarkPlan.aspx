<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="AddMarkPlan.aspx.vb" Inherits="CRM.AddMarkPlan" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
            Width="100%">
            <Columns>
                <asp:TemplateField><ItemTemplate > 
                    <asp:CheckBox ID="CheckBox1" onclick ="SelectSingleCheckBoxClick(window.event);"  runat="server" />
                </ItemTemplate></asp:TemplateField>
                <asp:BoundField DataField="MarkPlanName" HeaderText="營銷活動名" />
                <asp:BoundField DataField="Category" HeaderText="狀態" />
                <asp:BoundField DataField="Type" HeaderText="類別" />
            </Columns>
        </asp:GridView>
    
    </div>
   <div align="center">
        <asp:Button ID="BtnSave" runat="server" Text="保存" />&nbsp;&nbsp;&nbsp; 
        <asp:Button ID="BtnCancel"
            runat="server" Text="取消" style="height: 21px" />
    </div>
    </form>
</body>
</html>
