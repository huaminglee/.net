<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="InternalAuditDetail.aspx.vb" Inherits="CMCFileManage.InternalAuditDetail" %>

<%@ Register src="../UCtl/UcFileDetail.ascx" tagname="UcFileDetail" tagprefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
    <link href="../NewScript/themes/Default/easyui.css" rel="stylesheet" type="text/css" />
    <link href="../IconsThemes/icon.css" rel="stylesheet" type="text/css" />

    <script src="../NewScript/jquery-1.7.2.min.js" type="text/javascript"></script>

    <script src="../NewScript/jquery.easyui.min.js" type="text/javascript"></script>

    <script src="../NewScript/easyloader.js" type="text/javascript"></script>

    <script src="../NewScript/My97DatePicker/WdatePicker.js" type="text/javascript"></script>

    </head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div style="float: left; height: 12px;">
        <asp:LinkButton ID="LinkEdit" class="easyui-linkbutton" plain="true" iconCls="icon-edit"
            runat="server">編輯</asp:LinkButton>
        <asp:LinkButton ID="LinkSave" Visible="false" class="easyui-linkbutton" plain="true"
            iconCls="icon-save" runat="server">保存</asp:LinkButton>
        <asp:LinkButton ID="LinkLeave" class="easyui-linkbutton" plain="true" iconCls="icon-back"
            runat="server">離開</asp:LinkButton>
    </div>
    <div style="clear: both">
    </div>
    <div align="center" style="color: #0066FF; font-size: 20px; font-family: 標楷體">
        <asp:Label ID="LBTitle" runat="server" Text=""></asp:Label>
        <hr />
    </div>
    <div>
        <asp:Label ID="LbRecordNO" runat="server" Text=""></asp:Label></div>
    <div>
    
        <table border="1" cellspacing="0" cellpadding="0" bordercolor="#000000"
            bordercolordark="#FFFFFF" align="left" width="400px">
            <tr>
                <td bgcolor="#E5E5E5">
                    報告日期</td>
                <td>
                    <asp:TextBox ID="TXTdate" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td bgcolor="#E5E5E5">
                    名稱</td>
                <td>
                    <asp:TextBox ID="TXTname" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td bgcolor="#E5E5E5">
                    製作人</td>
                <td>
                    <asp:TextBox ID="TXTUser" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td bgcolor="#E5E5E5">
                    製作單位</td>
                <td>
                    <asp:DropDownList ID="DPLDept" runat="server" Width="153px">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr id="qulocation" runat ="server" >
                <td bgcolor="#E5E5E5">
                    區域</td>
                <td>
                    <asp:DropDownList ID="DPLqyulocation" runat="server" Width="153px">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td bgcolor="#E5E5E5">
                    內容</td>
                <td>
                    <uc1:UcFileDetail ID="UcFileDetail1" runat="server" />
                </td>
            </tr>
        </table>
    
    </div>
    </form>
</body>
</html>
