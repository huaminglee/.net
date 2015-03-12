<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="FrmSelectMember.aspx.vb" Inherits="eWorkFlow.eFlowDoc.FrmSelectMember" %>

<%@ Register Src="~/EFlowNet/Doc/Modules/CtlMemberSelect.ascx" TagName="CtlMemberSelect" TagPrefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<base target="_self" />
    <title>選取項目</title>
    <link id="css1" rel="stylesheet" type="text/css" runat="server" href="~/EFlowNet/Doc/CSS/tabStyle.css" />
    <link id="css2" rel="stylesheet" type="text/css" runat="server" href="~/EFlowNet/Doc/CSS/multiPage.css" />
    <link id="css3" rel="stylesheet" type="text/css" runat="server" href="~/EFlowNet/Doc/CSS/GridViewLock.css" />
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
        <Scripts>
            <asp:ScriptReference Path="~/EFlowNet/Doc/JS/WinHelper.js" />
            <asp:ScriptReference Path="~/EFlowNet/Doc/JS/UIHelper.js" />
        </Scripts>
    </asp:ScriptManager>
    <uc1:CtlMemberSelect ID="CtlMemberSelect1" runat="server" />
    </form>
</body>
</html>
