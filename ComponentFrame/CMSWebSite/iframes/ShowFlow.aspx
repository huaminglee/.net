<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ShowFlow.aspx.cs" Inherits="iframes_ShowFlow" %>

<%@ Register src="../UserControl/FlowDiagram.ascx" tagname="FlowDiagram" tagprefix="uc1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <uc1:FlowDiagram ID="FlowDiagram1" runat="server" />
         
    <div>
    
    </div>
    </form>
</body>
</html>
