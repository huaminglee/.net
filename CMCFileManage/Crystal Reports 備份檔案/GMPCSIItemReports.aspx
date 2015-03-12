<%@ Page Language="vb" AutoEventWireup="false" Theme ="Default"  CodeBehind="GMPCSIItemReports.aspx.vb"
    Inherits="CMCFileManage.GMPCSIItemReports" %>

<%@ Register src="../UCtl/CtlGMPCSIItemReports.ascx" tagname="CtlGMPCSIItemReports" tagprefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="Styles/CSIStyles.css" type="text/css" rel="stylesheet" />

    <script type="text/javascript" src="Scripts/CSIScript.js"></script>

</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <%--<asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate >--%>
    <div>
        <table width="100%" class="TableStyle" height="100%" align="center" border="1" cellspacing="0"
            cellpadding="0">
            <tr>
                <td  valign="top" height="100%">
                   
                    <uc1:CtlGMPCSIItemReports ID="CtlGMPCSIItemReports1" runat="server" />
                   
                </td>
            </tr>
            <tr>
                <td>
                   
                    &nbsp;</td>
            </tr>
        </table>
    </div>
   <%-- </ContentTemplate>
    </asp:UpdatePanel>--%>
    </form>
</body>
</html>
