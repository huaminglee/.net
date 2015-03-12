<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Archive_Print.aspx.cs" Inherits="Admin_Archive_Print" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>打印公文办理信息</title>
    <link rel="stylesheet" href="/CSS/public.css?t=<%=t_rand %>" type="text/css" />
    <link href="/CSS/Print_List.css?t=<%=t_rand %>" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="pForm" runat="server">
        <div id="Print_Main" class="Print_Main">
            <table width="640px" cellspacing="1" cellpadding="1" border="0px" bordercolor="#E3E3E3"
                id="Table1" style="background-color: #ffffff">
                <tr>
                    <td colspan="5" height="50px" class="microTitle">
                        <asp:Label runat="server" ID="lbTopTitle" Text="成都市水务局人大建议、政协提案拟办单"></asp:Label>
                    </td>
                </tr>
            </table>
            
            <table style="width: 640px; height:auto; border-collapse: collapse;" cellpadding="0px" cellspacing="0px"
                id="main_tabList" class="main_tabList">
                <tr>
                    <td style="width: 18%;" class="MCTableTr_Left">公文序号：
                    </td>
                    <td width="32%" class="MCTableTr_Right" style="background-color: #f6f6f6">
                        <asp:Label ID="txtArchiveNo" runat="server"></asp:Label>
                    </td>
                    <td class="MCTableTr_Left" style="width: 18%">是否涉密：
                    </td>
                    <td class="MCTableTr_Right" style="background-color: #f6f6f6; width: 32%">
                        <asp:Label runat="server" ID="lbSecret"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="MCTableTr_Left">收文日期：
                    </td>
                    <td class="MCTableTr_Right" style="background-color: #f6f6f6">
                        <asp:Label runat="server" ID="pdtInComingDate"></asp:Label>
                    </td>
                    <td class="MCTableTr_Left">文件编号：
                    </td>
                    <td class="MCTableTr_Right" style="background-color: #f6f6f6">
                        <asp:Label ID="txtDocNo" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="MCTableTr_Left">来文单位：
                    </td>
                    <td colspan="3" class="MCTableTr_Right" style="background-color: #f6f6f6">
                        <asp:Label ID="txtSendUnit" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="MCTableTr_Left">文种：
                    </td>
                    <td colspan="3" class="MCTableTr_Right" style="background-color: #f6f6f6">
                        <asp:Label ID="txtDocType" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="MCTableTr_Left">标题：
                    </td>
                    <td colspan="3" class="MCTableTr_Right" style="background-color: #f6f6f6">
                        <asp:Label ID="txtTitle" runat="server"></asp:Label>
                    </td>
                </tr>
                <asp:Literal ID="ShowOpList" Runat="server" EnableViewState="False"></asp:Literal>
                <tr>
                    <td class="MCTableTr_Left">备注：
                    </td>
                    <td colspan="3" class="MCTableTr_Right" style="background-color: #f6f6f6">
                        <asp:Label ID="txtRemark" runat="server"></asp:Label>
                    </td>
                </tr>
            </table>

            <table style="width: 640px; border-collapse: collapse; padding-right: 0px; margin-top: 4px; margin-bottom: 20px"
                cellspacing="0" cellpadding="0" border="0px" class="noprint"
                bgcolor="#ffffff" id="Table2" height="50px">
                <tr>
                    <td style="padding-top: 2px;" width="65px" runat="server" id="tdAttach"></td>
                    <td align="center" valign="middle" style="padding-bottom: 3px">
                        <input type="button" id="btnPrint" value="打印" class="btn_Print" onclick="window.print(); return false;"/>
                        &nbsp;
                        <input type="button" id="btnReturn" class="btn_back con_oper_btn" value="返回" onclick="window.history.go(-1);" />
                    </td>
                    <td align="right" width="3%"></td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
