<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="dlgFileDetail.aspx.vb"
    Inherits="eWorkFlow.eFlowDoc.dlgFileDetail" %>
<%@ Register Src="~/EFlowNet/Doc/Modules/UcFileDetail.ascx" TagName="UcFileDetail" TagPrefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <base target="_self" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
        <Scripts>
            <asp:ScriptReference Path="~/EFlowNet/Doc/JS/WinHelper.js" />
        </Scripts>
    </asp:ScriptManager>
    <div>
        <uc1:UcFileDetail ID="UcFileDetail1" runat="server"   />
         <input type="button" value="关闭" onclick="window.returnValue='';closeSelf();">
    </div>
    </form>
</body>
</html>
