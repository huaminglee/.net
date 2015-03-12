<%@ Page Language="vb" AutoEventWireup="false" Theme ="Default"  CodeBehind="GMPCSIMoudle.aspx.vb"
    Inherits="CMCFileManage.GMPCSIMoudle" %>

<%@ Register src="../UCtl/CtlGMPCSIMoudle.ascx" tagname="CtlGMPCSIMoudle" tagprefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="Styles/CSIStyles.css" type="text/css" rel="stylesheet" />
    <link href="../CSS/newaction.css" rel="stylesheet" type="text/css" />

    <script type="text/javascript" src="Scripts/CSIScript.js"></script>

</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table width="100%" class="TableStyle" height="100%" align="center">
            <tr>
                <td  valign="top">
                    
                    <uc1:CtlGMPCSIMoudle ID="CtlGMPCSIMoudle1" runat="server" />
                    
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
