<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="leftn.aspx.vb" Inherits="CMCFileManage.leftn" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
   <title></title>
    <link href="Newstyle/css/left_css.css" rel="stylesheet" type="text/css" />

    <script language="JavaScript">
function showsubmenu(sid)
{
whichEl = eval("submenu" + sid);
if (whichEl.style.display == "none")
{
eval("submenu" + sid + ".style.display=\"\";");
}
else
{
eval("submenu" + sid + ".style.display=\"none\";");
}
}
    </script>

    <style type="text/css">
        .style11
        {
            width: 100%;
        }
    </style>
</head>
<body bgcolor="16ACFF" style="width: 180px; padding: 0px; margin: 0px">
    <form id="form1" runat="server">
    <table width="98%" border="0" cellpadding="0" cellspacing="0" background="Newstyle/tablemde.jpg">
        <tr>
            <td height="5" background="Images/tableline_top.jpg" bgcolor="#16ACFF">
            </td>
        </tr>
        <tr>
            <td>
                <table width="97%" border="0" align="right" cellpadding="0" cellspacing="0" class="leftframetable">
                    <tr>
                        <td height="25" style="background:url(Images/left_tt.gif) no-repeat">
                             
                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                <tr>
                                    <td width="20">
                                        &nbsp;</td>
                                    <td style="CURSOR: hand" onclick=showsubmenu(1); height=25>
                                        文件變更申請</td>
                                </tr>
                            </table>
                             
                        </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td height="5" background="Images/tableline_bottom.jpg" bgcolor="#9BC2ED">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td height="5" background="Images/tableline_top.jpg" bgcolor="#16ACFF">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td height="5" background="Images/tableline_bottom.jpg" bgcolor="#9BC2ED">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td height="5" background="Images/tableline_top.jpg" bgcolor="#16ACFF">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td height="5" background="Images/tableline_bottom.jpg" bgcolor="#9BC2ED">
                &nbsp;
            </td>
        </tr>
    </table>
    </form>
</body>
</html>
