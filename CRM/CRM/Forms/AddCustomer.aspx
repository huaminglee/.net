<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="AddCustomer.aspx.vb" Inherits="CRM.AddCustomer" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
     <script src="../NewScript/UIHelper.js" type="text/javascript"></script>
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
                <asp:BoundField DataField="CustomerName" HeaderText="客戶名稱" />
                <asp:BoundField DataField="CustomerID" HeaderText="客戶編號" />
                <asp:BoundField DataField="Industry" HeaderText="行業" />
            </Columns>
        </asp:GridView>
    
    </div>
    <div align="center">
        <asp:Button ID="BtnSave" runat="server" Text="保存" style="height: 21px" />&nbsp;&nbsp;&nbsp; <asp:Button ID="BtnCancel"
            runat="server" Text="取消" />
    </div>
    </form>
</body>
</html>
