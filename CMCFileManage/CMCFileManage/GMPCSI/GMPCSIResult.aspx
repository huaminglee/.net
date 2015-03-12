<%@ Page Language="vb" AutoEventWireup="false" Theme ="Default"  CodeBehind="GMPCSIResult.aspx.vb"
    Inherits="CMCFileManage.GMPCSIResult" %>

<%@ Register src="../UCtl/CtlGMPCSIResult.ascx" tagname="CtlGMPCSIResult" tagprefix="uc1" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="Styles/CSIStyles.css" type="text/css" rel="stylesheet" />

    <script type="text/javascript" src="Scripts/CSIScript.js"></script>

</head>
<body scroll="Auto">
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
   
    <div>
        <table width="100%" class="TableStyle" height="100%" align="center" border="1" cellspacing="0"
            cellpadding="0">
            <tr>
                <td nowrap height="100%" valign="top">
                    
                    <uc1:CtlGMPCSIResult ID="CtlGMPCSIResult1" runat="server" />
                    
                </td>
            </tr>
            <tr>
                <td>
                   
                    &nbsp;</td>
            </tr>
        </table>
    </div>
   
    </form>
</body>
</html>
