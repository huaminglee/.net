<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="UseStatistics.aspx.vb" Inherits="CRM.UseStatistics" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
     <script src="../NewScript/My97DatePicker/WdatePicker.js" type="text/javascript"></script>
    <script language ="javascript" type ="text/javascript" >
        function btnnosee() {
            document.getElementById("Button1").style.display = "none";
            document.getElementById("Label1").style.display = "inline";
            
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        開始時間：<asp:TextBox ID="Txtbegintime" runat="server"></asp:TextBox>
&nbsp;結束時間：<asp:TextBox ID="Txtendtime" runat="server"></asp:TextBox>
    
        <asp:Button ID="Button1" runat="server" Text="統計各廠區使用情況" />
        <asp:Label ID="Label1" style="display :none " runat="server" Text="此項查詢耗時較長，請耐心等待..." Font-Size="14px"></asp:Label>
    
    </div>
    <div>
    
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
            Width="100%">
            <RowStyle HorizontalAlign="Center" />
            <Columns>
                <asp:BoundField DataField="cq" HeaderText="廠區" />
                <asp:BoundField DataField="quonums" HeaderText="填單數" />
                <asp:BoundField DataField="lognums" HeaderText="登陸數" />
            </Columns>
            <HeaderStyle HorizontalAlign="Center" />
        </asp:GridView>
    
    </div>
    </form>
</body>
</html>
