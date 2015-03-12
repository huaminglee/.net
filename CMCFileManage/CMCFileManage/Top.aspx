<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Top.aspx.vb" Inherits="CMCFileManage.Top" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="Newstyle/css/top_css.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        div.item
        {
            text-align: center;
            height: 26px;
            line-height: 28px;
        }
        .itemsel
        {
            text-align: center;
            background: #91D3F6;
            color: #ffffff;
            border-left: 1px solid #c5f097;
            border-right: 1px solid #c5f097;
            border-top: 1px solid #c5f097;
            height: 26px;
            line-height: 28px;
        }
        *html .itemsel
        {
            height: 26px;
            line-height: 26px;
        }
        a:link, a:visited
        {
            text-decoration: underline;
        }
        .item a:link, .item a:visited
        {
            font-size: 12px;
            color: #ffffff;
            text-decoration: none;
            font-weight: bold;
        }
        .item a:hover
        {
            color: #1E5494;
            font-weight: bold;
            border-bottom: 2px solid #E9FC65;
        }
        .itemsel a:link, .itemsel a:visited
        {
            font-size: 12px;
            color: #000000;
            text-decoration: none;
            font-weight: bold;
        }
        .itemsel a:hover
        {
            color: #000000;
            border-bottom: 2px solid #E9FC65;
        }
    </style>

    <script src="NewScript/jquery-1.7.2.min.js" type="text/javascript"></script>

    <script language="javascript" type="text/javascript">
<!--
        var displayBar = true;
        var preFrameW = '206,*';
        var FrameHide = 0;
        var curStyle = 1;
        var totalItem = 5;

        function switchBar(obj) {
            if (displayBar) {
                var parentwin = window.parent;
                var leftiframe = parentwin.document.getElementById("leftiframe");
                var rightiframe = parentwin.document.getElementById("rightiframe");
                var topiframe = parentwin.document.getElementById("topiframe");
                var curwidth = parseInt(rightiframe.width) + parseInt(leftiframe.width);
                leftiframe.style.display = "none";
                rightiframe.width = curwidth;
                topiframe.width = curwidth;
                displayBar = false;
                obj.title = "打开左边管理菜单";
            }
            else {
                var parentwin = window.parent;
                var leftiframe = parentwin.document.getElementById("leftiframe");
                var rightiframe = parentwin.document.getElementById("rightiframe");
                leftiframe.style.display = "inline";
                rightiframe.width = parseInt ( rightiframe.width) -parseInt ( leftiframe .width);
                displayBar = true;
                obj.title = "关闭左边管理菜单";
            }
        }
        function showleftq() {
            var parentwin = window.parent;
            var leftiframe = parentwin.document.getElementById("leftiframe");
            var rightiframe = parentwin.document.getElementById("rightiframe");
            leftiframe.src = "leftq.aspx";
            rightiframe.src = 'Forms/QCFileList.aspx?Type=0';
            changeSel(1);
        }
        function showlefts() {
            var parentwin = window.parent;
            var leftiframe = parentwin.document.getElementById("leftiframe");
            var rightiframe = parentwin.document.getElementById("rightiframe");
            leftiframe.src = "lefts.aspx";
            rightiframe.src = 'Suppliers/SuppliersList.aspx?Type=1';
            changeSel(2);
        }
        function showlefti() {
            var parentwin = window.parent;
            var leftiframe = parentwin.document.getElementById("leftiframe");
            var rightiframe = parentwin.document.getElementById("rightiframe");
            leftiframe.src = "lefti.aspx";
            rightiframe.src = 'Forms/InternalAuditList.aspx?Type=1';
            changeSel(3);
        }
        function showleftc() {
            var parentwin = window.parent;
            var leftiframe = parentwin.document.getElementById("leftiframe");
            var rightiframe = parentwin.document.getElementById("rightiframe");
            leftiframe.src = "leftc.aspx";
            rightiframe.src = 'Forms/ComplaintsList.aspx';
            changeSel(4);
        }
        function showleftn() {
            var parentwin = window.parent;
            var leftiframe = parentwin.document.getElementById("leftiframe");
            var rightiframe = parentwin.document.getElementById("rightiframe");
            leftiframe.src = "leftn.aspx";
            rightiframe.src = 'Gonggao/SysNewsList.aspx';
            changeSel(5);
        }
        function ChangeMenu(way) {
            var addwidth = 10;
            var fcol = top.document.all.btFrame.cols;
            if (way == 1) addwidth = 10;
            else if (way == -1) addwidth = -10;
            else if (way == 0) {
                if (FrameHide == 0) {
                    preFrameW = top.document.all.btFrame.cols;
                    top.document.all.btFrame.cols = '0,*';
                    FrameHide = 1;
                    return;
                } else {
                    top.document.all.btFrame.cols = preFrameW;
                    FrameHide = 0;
                    return;
                }
            }
            fcols = fcol.split(',');
            fcols[0] = parseInt(fcols[0]) + addwidth;
            top.document.all.btFrame.cols = fcols[0] + ',*';
        }


        function mv(selobj, moveout, itemnum) {
            if (itemnum == curStyle) return false;
            if (moveout == 'move') selobj.className = 'itemsel';
            if (moveout == 'o') selobj.className = 'item';
            return true;
        }

        function changeSel(itemnum) {
            curStyle = itemnum;
            for (i = 1; i <= totalItem; i++) {
                if (document.getElementById('item' + i)) document.getElementById('item' + i).className = 'item';
            }
            document.getElementById('item' + itemnum).className = 'itemsel';
        }
        function resetpassword() {
            window.open("/Cmcfilemanage/Forms/ChangePassword.aspx",
		"",
		"width=320,height=180,left=400,top=380,resizable=no");
        }
//-->
    </script>

</head>
<body bgcolor="#03A8F6" style="height: 65px">
    <form id="form1" runat="server">
    <table width="100%">
        <tr>
            <td>
                <asp:Image ID="Image3" runat="server" ImageUrl="Images/blank.jpg" />
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
                                            <asp:Label ID="LbQy" runat="server" Text=""></asp:Label>
                                            <span class="top_link">┆</span>
                                            <asp:Label ID="LbUserName" runat="server"></asp:Label>
                                            <span class="top_link">┆</span>
                                            <asp:LinkButton ID="Linkout" runat="server">退出登陸</asp:LinkButton><span class="top_link">┆</span>
                                            
                                            <a href ="#" onclick ="resetpassword()" style="font-size: 12px">修改密碼</a><span class="top_link">┆</span>
                                            
                                            <asp:LinkButton ID="LinkUserinfo" runat="server">個人資料修改</asp:LinkButton>
                                        </td>
                                        <td width="80" align="right" nowrap="nowrap" class="topbar">
                                            &nbsp;
                                        </td>
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
                                        <td width="200" height="26" align="center" valign="middle">
                                            <div class='itemsel' id='item1' onmousemove="mv(this,'move',1);" onmouseout="mv(this,'o',1);">
                                                <a href="#" onclick="showleftq()" class="STYLE2">全球文件管理系統</a></div>
                                        </td>
                                        <td align="center" class="topbar">
                                            <span class="STYLE2"></span>
                                        </td>
                                        <td width="140" align="center" valign="middle">
                                            <div class='item' id='item2' onmousemove="mv(this,'move',2);" onmouseout="mv(this,'o',2);">
                                                <a href="#" onclick="showlefts()" class="STYLE2">供應商質量管理</a></div>
                                        </td>
                                        <td align="center" class="topbar">
                                            <span class="STYLE2"></span>
                                        </td>
                                        <td width="150" align="center" valign="middle">
                                            <div class='item' id='item3' onmousemove="mv(this,'move',3);" onmouseout="mv(this,'o',3);">
                                                <a href="#" onclick="showlefti()">內審&管理評審</a></div>
                                        </td>
                                        <td align="center" class="topbar">
                                            <span class="STYLE2"></span>
                                        </td>
                                        <td width="71" align="center" valign="middle">
                                            <div class='item' id='item4' onmousemove="mv(this,'move',4);" onmouseout="mv(this,'o',4);">
                                                <a href="#" onclick="showleftc()" class="STYLE3">投訴</a></div>
                                        </td>
                                        <td align="center" class="topbar">
                                            <span class="STYLE2"></span>
                                        </td>
                                        <td width="71" align="center" valign="middle" style="width: 142px">
                                            <div class='item' id='item5' onmousemove="mv(this,'move',5);" onmouseout="mv(this,'o',5);">
                                                <a href="#" onclick="showleftn()" class="STYLE2">相關公告</a></div>
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
            </td>
        </tr>
    </table>
    </form>
</body>
</html>
