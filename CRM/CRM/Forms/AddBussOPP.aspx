<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="AddBussOPP.aspx.vb" Inherits="CRM.AddBussOPP" %>

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
                <asp:TemplateField>
                <ItemTemplate > 
                    <asp:CheckBox ID="CheckBox1" onclick ="SelectSingleCheckBoxClick(window.event);"  runat="server" />
                </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="OpportName" HeaderText="業務機會名" />
                <asp:BoundField DataField="OppOwoner" HeaderText="業務機會所有人" />
                <asp:BoundField DataField="CustomerName" HeaderText="客戶名" />
                <asp:BoundField DataField="Category" HeaderText="階段" />
                <asp:BoundField DataField="Possibility" HeaderText="可能性" />
            </Columns>
        </asp:GridView>
    </div>
    <div align="center">
        <asp:Button ID="BtnSave" runat="server" Text="保存" />&nbsp;&nbsp;&nbsp; <asp:Button ID="BtnCancel"
            runat="server" Text="取消" />
    </div>
    </form>
</body>
</html>
