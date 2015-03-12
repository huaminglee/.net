<%@ Page Language="vb" AutoEventWireup="false" Theme ="Default"  CodeBehind="TestItemManage.aspx.vb"
    Inherits="CRM.TestItemManage" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../CSS/newaction.css" rel="stylesheet" type="text/css" />
    <script language ="javascript" type ="text/javascript" >
        function utree() {
            document.getElementById("btnrefresh").click();
        }
        function addtestitem() {
            window.open("../Forms/TestItemManageAdd.aspx", "_blank", "width=500,height=650,left=400,top=150,resizable=no,scrollbars=yes");
        }
    </script>
    </head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:DropDownList ID="DPLcq" runat="server" AutoPostBack="True" Width="300px">
          <asp:ListItem Value="LH">龍華檢測中心</asp:ListItem>
            <asp:ListItem Value="WH">武漢檢測中心</asp:ListItem>
            <asp:ListItem Value="CD">成都檢測中心</asp:ListItem>
           <asp:ListItem Value="CQ">重慶檢測中心</asp:ListItem> 
           <asp:ListItem Value="ZZ">鄭州檢測中心</asp:ListItem>
            <asp:ListItem Value="YT">煙台檢測中心</asp:ListItem>
            <asp:ListItem Value="WSJ">吳淞江檢測中心</asp:ListItem>
             <asp:ListItem Value="NN">南寧檢測中心</asp:ListItem>
        </asp:DropDownList>
    </div>
    <div style ="clear :both "></div>
    <div>
        <asp:FileUpload ID="FileUpload"    runat="server" />
        <asp:Button ID="BtnExcel" class="button"  runat="server" Text="導入" />
        <asp:Label ID="LblMsg" runat="server" Text=""></asp:Label>
        <a href ="../TempUploadFiles/匯入測試項目模板.xls" class="button" >下載模板</a>
        <asp:Button ID="btnrefresh" style="display :none " runat="server" Text="Button" />
        <input type ="button" class="button" onclick ="addtestitem()" value="添加測試項目" />
        <asp:Button ID="btnExcelout" class="button" runat="server" Text="導出" />
    </div>
    <div style ="clear :both "></div>
    <div style ="float :left; width: 20%;">
        <asp:TreeView ID="TreeView1" runat="server">
            <SelectedNodeStyle BackColor="Gray" />
            
        </asp:TreeView>
    </div>
    <div style ="float :right; width: 79%;">
    <div>
    
        <table width ="100%" >
            <tr>
                <td align="right">
                    測試類別</td>
                <td>
                    <asp:Label ID="LbTestService" runat="server" Font-Bold="True" 
                        ForeColor="#33CC33"></asp:Label>
                </td>
                <td align="right">
                    測試項目</td>
                <td>
                    <asp:Label ID="LbItemname" runat="server" Font-Bold="True" ForeColor="#33CC33"></asp:Label>
                </td>
                <td>
                    <asp:Button ID="Button1" class="button" runat="server" Text="保存" />
                </td>
            </tr>
        </table>
    
    </div>
    <div>
    <table width ="100%" border ="1" cellpadding ="0" cellspacing ="0" bordercolor="#ffffff" bordercolordark="#999999" >
        <tr>
            <td>
                成本價</td>
            <td align="right">
                基本金</td>
            <td>
                <asp:TextBox ID="TxtCBbootfee" Text ="0" runat="server" Width="80px"></asp:TextBox>
                RMB</td>
            <td align="right">
                單位收費</td>
            <td>
                <asp:TextBox ID="TxtCBunitfee" Text ="0" runat="server" Width="80px"></asp:TextBox>
                RMB</td>
        </tr>
        <tr visible ="false" >
            <td>
                對外底價</td>
            <td align="right">
                基本金</td>
            <td>
                <asp:TextBox ID="TxtDWDJbootfee" Text ="0" runat="server" Width="80px"></asp:TextBox>
                RMB</td>
            <td align="right">
                單位收費</td>
            <td>
                <asp:TextBox ID="TxtDWDJunitfee" Text ="0" runat="server" Width="80px"></asp:TextBox>
                RMB</td>
        </tr>
        <tr>
            <td>
                對外牌價</td>
            <td align="right">
                基本金</td>
            <td>
                <asp:TextBox ID="TxtDWPJbootfee"  Text ="0" runat="server" Width="80px"></asp:TextBox>
                RMB</td>
            <td align="right">
                單位收費</td>
            <td>
                <asp:TextBox ID="TxtDWPJunitfee" Text ="0" runat="server" Width="80px"></asp:TextBox>
                RMB</td>
        </tr>
        <tr>
            <td>
                計價單位</td>
            <td align="left" colspan="4">
                <asp:TextBox ID="TxtUnit" runat="server"></asp:TextBox>
            </td>
        </tr>
    </table>
        
    </div>
    </div>
    
    </form>
</body>
</html>
