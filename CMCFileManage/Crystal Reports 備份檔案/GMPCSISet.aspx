<%@ Page Language="vb" AutoEventWireup="false" Theme="Default" CodeBehind="GMPCSISet.aspx.vb"
    Inherits="CMCFileManage.GMPCSISet" %>

<%@ Register Src="../UCtl/CtlGMPCSISet.ascx" TagName="CtlGMPCSISet" TagPrefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="Styles/CSIStyles.css" type="text/css" rel="stylesheet" />
    <link href="../CSS/newaction.css" rel="stylesheet" type="text/css" />

    <script src="Scripts/CSIScript.js" type="text/javascript"></script>

    <script src="../NewScript/My97DatePicker/WdatePicker.js" type="text/javascript"></script>

</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table width="100%" class="TableStyle" align="center" height="100%" border="1" cellspacing="0"
            cellpadding="0">
            <tr>
                <td height="100%" valign="top">
                    <uc1:CtlGMPCSISet ID="CtlGMPCSISet1" runat="server" />
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
