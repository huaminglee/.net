<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="leftn.aspx.vb" Inherits="CMCFileManage.leftn" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="Newstyle/css/left_css.css" rel="stylesheet" type="text/css" />

    <script language="JavaScript">
        function showsubmenu(sid) {
            whichEl = eval("submenu" + sid);
            if (whichEl.style.display == "none") {
                eval("submenu" + sid + ".style.display=\"\";");
            }
            else {
                eval("submenu" + sid + ".style.display=\"none\";");
            }
        }
        function changeSel(itemnum) {
            for (i = 1; i <= 1; i++) {
                if (document.getElementById('item' + i)) document.getElementById('item' + i).className = 'item';
            }
            document.getElementById('item' + itemnum).className = 'itemsel';
        }
    </script>

    <style type="text/css">
         .item
        {
            text-align: center;
        }
        .itemsel
        {
            text-align: center;
            background: #91D3F6;
            color: #ffffff;
            border-left: 1px solid #c5f097;
            border-right: 1px solid #c5f097;
            border-top: 1px solid #c5f097;
        }
    </style>
</head>
<body bgcolor="16ACFF" style="width: 180px; padding: 0px; margin: 0px">
    <form id="form1" runat="server">
    <table width="98%" border="0" cellpadding="0" cellspacing="0" background="Newstyle/tablemde.jpg">
        <tr>
            <td height="5" background="Newstyle/tableline_top.jpg" bgcolor="#16ACFF">
            </td>
        </tr>
        <tr>
            <td>
                <table width="97%" border="0" align="right" cellpadding="0" cellspacing="0" class="leftframetable">
                    <tr>
                        <td height="25" style="background: url(Newstyle/left_tt.gif) no-repeat">
                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                <tr>
                                    <td width="20">
                                        &nbsp;
                                    </td>
                                    <td style="cursor: hand" onclick="showsubmenu(1);" height="25">
                                        相關公告
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <table id="submenu1" cellspacing="0" cellpadding="0" width="100%" border="0">
                                <tr>
                                    <td width="2%">
                                        <img src="Newstyle/closed.gif" />
                                    </td>
                                    <td height="23">
                                        <a id="item1" onclick="changeSel(1)" class="itemsel" href="Gonggao/SysNewsList.aspx" target="MainFrame">系統公告</a>
                                    </td>
                                </tr>
                                <tr>
                                     <td width="2%">
                                        <img src="Newstyle/closed.gif" />
                                    </td>
                                    <td height="23">
                                        <a id="item2" onclick="changeSel(2)"  href="Forms/PersonTecFileList.aspx" target="MainFrame">人員技術檔案</a>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
       
    </table>
    </form>
</body>
</html>
