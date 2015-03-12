<%@ Page Language="C#" AutoEventWireup="true" CodeFile="rPrint.aspx.cs" Inherits="Risk_rPrint" %>

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
                        <asp:Label runat="server" ID="lbTopTitle" Text="成都市水务局风险处置处理单"></asp:Label>
                    </td>
                </tr>
            </table>

            <table style="width: 640px; height: auto; border-collapse: collapse;" cellpadding="0px" cellspacing="0px"
                id="main_tabList" class="main_tabList">
                <tr>
                    <td class="con_item" style="text-align: right;">
                        <span class="">风险等级</span>
                    </td>
                    <td class="con_item_left">
                        <asp:Label ID="dplUrgency" runat="server">
                        </asp:Label>
                    </td>
                    <td class="con_item" style="text-align: right;">
                        <span class="">业务类型</span>
                    </td>
                    <td class="con_item_left">
                        <asp:Label ID="dplBusinessType" runat="server" CssClass="ddlinput" Height="30px" Width="140px">
                        </asp:Label>
                    </td>

                </tr>
                <tr>
                    <td class="con_item" style="text-align: right;">
                        <span class="">业务件号</span></td>
                    <td class="con_item_left" colspan="1">
                        <asp:Label ID="txtBusinessNum" Height="30px" Width="152px" runat="server" CssClass="input"></asp:Label>
                    </td>
                    <td class="con_item" style="text-align: right;">
                        <span>办理时间</span>
                    </td>
                    <td class="con_item_left">
                        <asp:Label runat="server" ID="txtHandleDate"></asp:Label>
                        &nbsp;</td>
                </tr>
                <tr>

                    <td class="con_item" style="text-align: right;">
                        <span class="">办理人员</span></td>
                    <td class="con_item_left" colspan="1">
                        <asp:Label runat="server" ID="txtUserName"></asp:Label>
                    </td>
                    <td class="con_item" style="text-align: right;">
                        <span>所在部门</span></td>
                    <td class="con_item_left">
                        <asp:Label runat="server" ID="dplDeptName"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="con_item" style="text-align: right;">
                        <span>标题</span>
                    </td>
                    <td class="con_item_left" colspan="3">
                        <asp:Label ID="txtTitle" runat="server"></asp:Label>
                    </td>
                </tr>
                <asp:Literal ID="ShowOpList" runat="server" EnableViewState="False"></asp:Literal>
                <tr>
                    <td class="con_item" style="text-align: right;">
                        <span>备注</span>
                    </td>
                    <td class="con_item_left" colspan="3">
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
                        <input type="button" id="btnPrint" value="打印" class="btn_Print" onclick="window.print(); return false;" />
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
