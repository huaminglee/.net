<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Default.aspx.vb" Inherits="CMCFileManage._Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>品質管理系統</title>

    <script src="NewScript/jquery-1.7.2.min.js" type="text/javascript"></script>

    <script src="NewScript/Ifream.js" type="text/javascript"></script>

</head>
<body style="padding: 0px; margin: 0px">
    <form id="form1" runat="server">
    <div id="top" style="width: 100%">
        <iframe id="topiframe" src="top.aspx" noresize="noresize" frameborder="0" name="topFrame"
            marginwidth="0" marginheight="0" scrolling="no" width="100%"></iframe>
    </div>
    <div id="left" style="float: left">
        <iframe id="leftiframe" src="leftq.aspx" name="leftFrame" noresize="noresize" marginwidth="0"
            marginheight="0" frameborder="0" width="180px"  scrolling="auto">
        </iframe>
    </div>
    <div id="right" style="float: right">
        <iframe id="rightiframe" src="index.aspx" name="MainFrame" marginwidth="0" marginheight="0"
            frameborder="0" scrolling="yes"></iframe>
    </div>
    <div style="display: none">
        <asp:HiddenField ID="HidInitUrl" runat="server" />
        <asp:HiddenField ID="HidInitTitle" runat="server" />
    </div>
    </form>
</body>
</html>
