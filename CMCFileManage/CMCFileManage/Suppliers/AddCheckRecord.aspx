<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="AddCheckRecord.aspx.vb" Inherits="CMCFileManage.AddCheckRecord" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
    <link href="../CSS/newaction.css" rel="stylesheet" type="text/css" />

    <script src="../NewScript/My97DatePicker/WdatePicker.js" type="text/javascript"></script>
    
    </head>
<body > 
    <form id="form1" runat="server">
    <div>
    
        <table border="1" cellspacing="0" cellpadding="0" bordercolor="#000000" bordercolordark="#FFFFFF"
            align="left" width="100%">
            <tr>
                <td  height="50" align="right" bgcolor="#009933" 
                    style="color: #FFFFFF; font-weight: bold" nowrap="nowrap">
                    檢查日期</td>
                <td colspan="4" class="style11">
                    <asp:TextBox ID="TxtCheckDate" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td align="right" bgcolor="#009933" style="color: #FFFFFF; font-weight: bold" nowrap="nowrap">
                    檢查內容</td>
                <td align="center" height="50">
                    品質<asp:RadioButtonList ID="RdoQuality" runat="server" 
                        RepeatDirection="Horizontal" RepeatLayout="Flow">
                        <asp:ListItem Value="1" Selected="True">OK</asp:ListItem>
                        <asp:ListItem Value="0">NG</asp:ListItem>
                    </asp:RadioButtonList>
                </td>
                <td align="center">
                    服務<asp:RadioButtonList ID="RdoService" runat="server" 
                        RepeatDirection="Horizontal" RepeatLayout="Flow">
                        <asp:ListItem Value="1" Selected="True">OK</asp:ListItem>
                        <asp:ListItem Value="0">NG</asp:ListItem>
                    </asp:RadioButtonList>
                </td>
                <td align="center">
                    交貨<asp:RadioButtonList ID="RdoDelivery" runat="server" 
                        RepeatDirection="Horizontal" RepeatLayout="Flow">
                        <asp:ListItem Value="1" Selected="True">OK</asp:ListItem>
                        <asp:ListItem Value="0">NG</asp:ListItem>
                    </asp:RadioButtonList>
                </td>
                <td align="left">
                    其他<asp:TextBox ID="TxtOthers" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td align="right" height="50" bgcolor="#009933" 
                    style="color: #FFFFFF; font-weight: bold" nowrap="nowrap">
                    合格判定</td>
                <td align="center" >
                    <asp:RadioButtonList ID="RdoISok" runat="server" 
                        RepeatDirection="Horizontal" RepeatLayout="Flow">
                        <asp:ListItem Value="1" Selected="True">OK</asp:ListItem>
                        <asp:ListItem Value="0">NG</asp:ListItem>
                    </asp:RadioButtonList>
                </td>
                <td align="center">
                    考評人</td>
                <td align="center">
                    <asp:TextBox ID="TxtCheckPerson" runat="server" Width="70px"></asp:TextBox>
                </td>
                <td align="left">
                    備註<asp:TextBox ID="TxtRemark" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;</td>
                <td>
                    <asp:Button ID="BtnSave" class="button" runat="server" Text="保存" />
                </td>
                <td>
                    <asp:Button ID="BtnCancel" class="button" runat="server" Text="取消" />
                </td>
                <td colspan="2">
                    &nbsp;</td>
            </tr>
        </table>
    
    </div>
    </form>
</body>
</html>
