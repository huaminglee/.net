<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="ReconcieldDetail.aspx.vb" Inherits="CRM.ReconcieldDetail" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Button ID="BtnGetReconcield" runat="server" Text="生成對帳單" /></div>
    <div>
    
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
            Width="100%">
        </asp:GridView>
    
    </div>
    </form>
</body>
</html>
