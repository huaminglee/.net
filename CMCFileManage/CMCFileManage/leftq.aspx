<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="leftq.aspx.vb" Inherits="CMCFileManage.leftq" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="Newstyle/css/left_css.css" rel="stylesheet" type="text/css" />
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

    <script language="JavaScript" type="text/javascript">
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
            for (i = 1; i <= 19; i++) {
                if (document.getElementById('item' + i)) document.getElementById('item' + i).className = 'item';
            }
            document.getElementById('item' + itemnum).className = 'itemsel';
        }
    </script>

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
                                    </td>
                                    <td style="cursor: hand" onclick="showsubmenu(1);" height="25">
                                        文件變更申請
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <table id="submenu1" cellspacing="0" cellpadding="0" width="100%" border="0">
                                <tr id="qa1" runat="server">
                                    <td width="2%">
                                        <img src="Newstyle/closed.gif" />
                                    </td>
                                    <td height="23">
                                        <a id="item1" onclick="changeSel(1)" href="Forms/AddQCFileList.aspx?Type=0" target="MainFrame">
                                            新版發行</a>
                                    </td>
                                </tr>
                                <tr id="qa2" runat="server">
                                    <td>
                                        <img src="Newstyle/closed.gif" />
                                    </td>
                                    <td height="23">
                                        <a id="item2" onclick="changeSel(2)" href="Forms/AddQCFileList.aspx?Type=1" target="MainFrame">
                                            舊版變更</a>
                                    </td>
                                </tr>
                                <tr id="qa3" runat="server">
                                    <td>
                                        <img src="Newstyle/closed.gif" />
                                    </td>
                                    <td height="23">
                                        <a id="item3" onclick="changeSel(3)" href="Forms/AddQCFileList.aspx?Type=3" target="MainFrame">
                                            文件作廢</a>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <img src="Newstyle/closed.gif" />
                                    </td>
                                    <td height="23">
                                        <a id="item4" onclick="changeSel(4)" href="Forms/AddQCFileList.aspx?Type=2" target="MainFrame">
                                            文件變更申請</a>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <img src="Newstyle/closed.gif" />
                                    </td>
                                    <td height="23">
                                        <a id="item5" onclick="changeSel(5)" href="Forms/FileDeleteApplyList.aspx" target="MainFrame">
                                            文件刪除申請</a>
                                    </td>
                                </tr>
                                <tr id="qa4" runat="server">
                                    <td>
                                        <img src="Newstyle/closed.gif" />
                                    </td>
                                    <td height="23">
                                        <a id="item6" onclick="changeSel(6)" href="Forms/QCFileList.aspx?Type=3" target="MainFrame">
                                            作廢文件</a>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td height="5" background="Newstyle/tableline_bottom.jpg" bgcolor="#9BC2ED">
            </td>
        </tr>
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
                                    </td>
                                    <td style="cursor: hand" onclick="showsubmenu(2);" height="25">
                                        文件管理
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <table id="submenu2" cellspacing="0" cellpadding="0" width="100%" border="0">
                                <tr>
                                    <td width="2%">
                                        <img src="Newstyle/closed.gif" />
                                    </td>
                                    <td height="23">
                                        <a id="item7" onclick="changeSel(7)" class="itemsel" href="Forms/QCFileList.aspx?Type=0"
                                            target="MainFrame">品質文件(一階/二階)</a>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <img src="Newstyle/closed.gif" />
                                    </td>
                                    <td height="23">
                                        <a id="item8" onclick="changeSel(8)" href="Forms/QCFileList.aspx?Type=1" target="MainFrame">
                                            檢測/校準規程(三階)</a>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <img src="Newstyle/closed.gif" />
                                    </td>
                                    <td height="23">
                                        <a id="item9" onclick="changeSel(9)" href="Forms/QCFileList.aspx?Type=2" target="MainFrame">
                                            表單（四階）</a>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <img src="Newstyle/closed.gif" />
                                    </td>
                                    <td height="23">
                                        <a id="item10" onclick="changeSel(10)" href="Forms/OutFileList.aspx?Type=5" target="MainFrame">
                                            外來文件</a>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <img src="Newstyle/closed.gif" />
                                    </td>
                                    <td height="23">
                                        <a id="item11" onclick="changeSel(11)" href="Forms/OtherFileList.aspx" target="MainFrame">
                                            測試標準</a>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <img src="Newstyle/closed.gif" />
                                    </td>
                                    <td height="23">
                                        <a id="item12" onclick="changeSel(12)" href="Forms/StandardSearchManageList.aspx"
                                            target="MainFrame">標準查詢記錄</a>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <img src="Newstyle/closed.gif" />
                                    </td>
                                    <td height="23">
                                        <a id="item13" onclick="changeSel(13)" href="Forms/OutFileList.aspx?Type=2" target="MainFrame">
                                            客戶規格/測試計劃</a>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <img src="Newstyle/closed.gif" />
                                    </td>
                                    <td height="23">
                                        <a id="item14" onclick="changeSel(14)" href="Forms/OutFileList.aspx?Type=3" target="MainFrame">
                                            測試校準軟體</a>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <img src="Newstyle/closed.gif" />
                                    </td>
                                    <td height="23">
                                        <a id="item15" onclick="changeSel(15)" href="Forms/OutFileList.aspx?Type=4" target="MainFrame">
                                            說明書</a>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <img src="Newstyle/closed.gif" />
                                    </td>
                                    <td height="23">
                                        <a id="item16" onclick="changeSel(16)" href="Forms/EquipManageList.aspx" target="MainFrame">
                                            帶附件設備清單</a>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <img src="Newstyle/closed.gif" />
                                    </td>
                                    <td height="23">
                                        <a id="item17" onclick="changeSel(17)" href="Forms/EquipFileList.aspx" target="MainFrame">
                                            設備清單附件</a>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <img src="Newstyle/closed.gif" />
                                    </td>
                                    <td height="23">
                                        <a id="item18" onclick="changeSel(18)" href="Forms/FileReadManageList.aspx" target="MainFrame">
                                            文件調閱申請</a>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td height="5" background="Newstyle/tableline_bottom.jpg" bgcolor="#9BC2ED">
            </td>
        </tr>
        <tr>
            <td height="5" background="Newstyle/tableline_top.jpg" bgcolor="#16ACFF">
            </td>
        </tr>
        <tr id="qa5" runat="server">
            <td>
                <table width="97%" border="0" align="right" cellpadding="0" cellspacing="0" class="leftframetable">
                    <tr>
                        <td height="25" style="background: url(Newstyle/left_tt.gif) no-repeat">
                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                <tr>
                                    <td width="20">
                                    </td>
                                    <td style="cursor: hand" onclick="showsubmenu(3);" height="25">
                                        系統資訊
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <table id="submenu3" cellspacing="0" cellpadding="0" width="100%" border="0">
                                <tr>
                                    <td width="2%">
                                        <img src="Newstyle/closed.gif" />
                                    </td>
                                    <td height="23">
                                        <a id="item19" onclick="changeSel(19)" href="Forms/Inteauditperson.aspx" target="MainFrame">
                                            內審人員指定</a>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td height="5" background="Newstyle/tableline_bottom.jpg" bgcolor="#9BC2ED">
            </td>
        </tr>
    </table>
    </form>
</body>
</html>
