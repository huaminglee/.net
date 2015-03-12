<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Moreszyd.aspx.cs" Inherits="Archive_Moreszyd" %>

<%@ Register src="UserControls/ucTioblist.ascx" tagname="ucTioblist" tagprefix="uc1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>三重一大</title>
     <!-- 最新 Bootstrap 核心 CSS 文件 -->
    <link href="/easyui/1.3.6/themes/bootstrap/easyui.css" rel="stylesheet" />
    <link href="/easyui/1.3.6/themes/icon.css" rel="stylesheet" />
    <link href="/bootstrap/3.2.0/css/bootstrap.min.css" rel="stylesheet" />
    <link href="/css/html5_layout.css" rel="stylesheet" />
    <!-- jQuery文件务必在bootstrap.min.js 之前引入 -->
    <script src="/jquery/1.9.1/jquery.min.js"></script>
    <script src="/easyui/1.3.6/jquery.easyui.min.js"></script>
    <!-- 最新 Bootstrap 核心 JavaScript 文件 -->
    <script src="/bootstrap/3.2.0/js/bootstrap.min.js"></script>
    <script src="/Script/layer/layer.min.js"></script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <uc1:ucTioblist ID="ucTioblist1" runat="server" />
    
    </div>
    </form>
</body>
</html>
