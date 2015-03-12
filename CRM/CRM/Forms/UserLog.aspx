<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="UserLog.aspx.vb" Inherits="CRM.UserLog" %>

<%@ Register src="../UCtl/UcLog.ascx" tagname="UcLog" tagprefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
    <link href="../IconsThemes/icon.css" rel="stylesheet" type="text/css" />
    <link href="../NewScript/themes/Default/easyui.css" rel="stylesheet" type="text/css" />

    <script type="text/javascript" src="../NewScript/jquery-1.7.2.min.js"></script>

    <script src="../NewScript/jquery.easyui.min.js" type="text/javascript"></script>

</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <uc1:UcLog ID="UcLog1" runat="server" />
    
    </div>
    </form>
</body>
</html>
