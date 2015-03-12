<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Top.aspx.vb" Inherits="CMCFileManage.Top" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="Newstyle/css/top_css.css" rel="stylesheet" type="text/css" />

    <script language="javascript">
<!--
        var displayBar = true;

function switchBar(obj){
	if (displayBar)
	{
	    var parentwin = window.parent ;
	    var leftiframe = parentwin.document .getElementById("leftiframe");
	    leftiframe.style.display = "none";
		displayBar=false;
		obj.title="打开左边管理菜单";
	}
	else {
	    var parentwin = window.parent;
	    var leftiframe = parentwin.document.getElementById("leftiframe");
	    leftiframe.style.display = "inline";
		displayBar=true;
		obj.title="关闭左边管理菜单";
	}
}
function showleftq() {
    var parentwin = window.parent;
    var leftiframe = parentwin.document.getElementById("leftiframe");
    leftiframe.src = "leftq.aspx";
}
function showlefts() {
    var parentwin = window.parent;
    var leftiframe = parentwin.document.getElementById("leftiframe");
    leftiframe.src = "lefts.aspx";
}
function showlefti() {
    var parentwin = window.parent;
    var leftiframe = parentwin.document.getElementById("leftiframe");
    leftiframe.src = "lefti.aspx";
}
function showleftc() {
    var parentwin = window.parent;
    var leftiframe = parentwin.document.getElementById("leftiframe");
    leftiframe.src = "leftc.aspx";
}
function showleftn() {
    var parentwin = window.parent;
    var leftiframe = parentwin.document.getElementById("leftiframe");
    leftiframe.src = "leftn.aspx";
}
//-->
    </script>

</head>
<body bgcolor="#03A8F6">
    <form id="form1" runat="server">
    <table width="100%" border="0" cellpadding="0" cellspacing="0">
        <tr>
            <td width="194" height="60" align="center" background="Newstyle/top_logo.jpg">
            </td>
            <td align="center" style="background: url(Newstyle/top_bg.jpg) no-repeat">
                <table cellspacing="0" cellpadding="0" border="0" width="100%" height="33">
                    <tbody>
                        <tr>
                            <td width="30" align="left">
                                <img onclick="switchBar(this)" height="15" alt="关闭左边管理菜单" src="Newstyle/on-of.gif"
                                    width="15" border="0" />
                            </td>
                            <td width="320" align="left">
                                <span class="top_link">┆</span>
                                <asp:LinkButton ID="Linkout" runat="server">退出登陸</asp:LinkButton><span class="top_link">┆</span> 
                            </td>
                            <td width="80" align="right" nowrap="nowrap" class="topbar">
                                &nbsp;</td>
                            <td class="topbar">
                                <a href="index.aspx" target="MainFrame">
                                    <img title="返回首页" height="23" src="Newstyle/home.gif" width="33" border="0" /></a>&nbsp;
                            </td>
                        </tr>
                    </tbody>
                </table>
                <table height="26" border="0" align="left" cellpadding="0" cellspacing="0" class="subbg"
                    name="t1">
                    <tbody>
                        <tr align="middle">
                            <td width="200" height="26" align="center" valign="middle" >
                                <a href="#" onclick ="showleftq()"  class="STYLE2">Total Quality Document</a>
                            </td>
                            <td align="center" class="topbar">
                                <span class="STYLE2"></span>
                            </td>
                            <td width="71" align="center" valign="middle" >
                                <a href="#" onclick ="showlefts()"  class="STYLE2">Supplier</a>
                            </td>
                            <td align="center" class="topbar">
                                <span class="STYLE2"></span>
                            </td>
                            <td width="250" align="center" valign="middle" >
                                <a href="#" onclick ="showlefti()">Internal Audit & Management Reviews</a>
                            </td>
                            <td align="center" class="topbar">
                                <span class="STYLE2"></span>
                            </td>
                            <td width="71" align="center" valign="middle" >
                                <a href="#" onclick ="showleftc()" class="STYLE3">Complaints</a>
                            </td>
                            <td align="center" class="topbar">
                                <span class="STYLE2"></span>
                            </td>
                            <td width="71" align="center" valign="middle" 
                                 style="width: 142px">
                                <a href="#" onclick ="showleftn()" class="STYLE2">Note</a>
                            </td>
                        </tr>
                    </tbody>
                </table>
            </td>
        </tr>
        <tr height="6">
            <td bgcolor="#1F3A65" background="Newstyle/top_bg.jpg">
            </td>
        </tr>
    </table>
    </form>
</body>
</html>
