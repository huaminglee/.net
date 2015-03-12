<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ProjectItem_Print.aspx.cs" Inherits="Admin_ProjectItem_Print" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>打印水务工程项目</title>
    <link rel="stylesheet" href="/CSS/public.css?t=<%=t_rand %>" type="text/css" />
    <link href="/CSS/Print_List.css?t=<%=t_rand %>" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
        <div id="Print_Main" class="Print_Main">
            <table width="640px" cellspacing="1" cellpadding="1" border="0px" bordercolor="#E3E3E3"
                id="Table1" style="background-color: #ffffff">
                <tr>
                    <td colspan="5" height="50px" class="microTitle">
                        <asp:Label runat="server" ID="lbTopTitle" Text="水务工程项目--"></asp:Label>
                    </td>
                </tr>
            </table>

            <table style="width: 640px; height: auto; border-collapse: collapse;" cellpadding="0px" cellspacing="0px"
                id="main_tabList" class="main_tabList">
                <tr>
                    <td style="width: 18%;" class="MCTableTr_Left">资金总额
                    </td>
                    <td width="32%" class="MCTableTr_Right" style="background-color: #f6f6f6">
                        <asp:Label ID="txtMoneyTotal" runat="server"></asp:Label>
                    </td>
                    <td class="MCTableTr_Left" style="width: 18%">资金来源
                    </td>
                    <td class="MCTableTr_Right" style="background-color: #f6f6f6; width: 32%">
                        <asp:Label runat="server" ID="txtMoneySource"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="MCTableTr_Left" style="width: 18%"><span>项目业主</span></td>
                    <td width="32%" class="MCTableTr_Right" style="background-color: #f6f6f6">
                        <asp:Label ID="txtHostUnit" runat="server" class="input input152" />
                    </td>
                    <td class="MCTableTr_Left" style="width: 18%"><span>项目层级</span></td>
                    <td width="32%" class="MCTableTr_Right" style="background-color: #f6f6f6">
                        <asp:Label ID="txtOrgUnit" runat="server" >
                        </asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="MCTableTr_Left" style="width: 18%"><span>项目类别</span></td>
                    <td width="32%" class="MCTableTr_Right" style="background-color: #f6f6f6">
                        <asp:Label ID="txtProjectBasis" runat="server" class="input input152" /></td>
                    <td class="MCTableTr_Left" style="width: 18%"><span>备案处室</span></td>
                    <td width="32%" class="MCTableTr_Right" style="background-color: #f6f6f6">
                        <asp:Label ID="txtFILE_DEPT" Enabled="false" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td class="MCTableTr_Left" style="width: 18%"><span>牵头处室</span></td>
                    <td width="32%" class="MCTableTr_Right" style="background-color: #f6f6f6">
                        <asp:Label runat="server" ID="txtRESPONSE_DEPT" CssClass="ddlinput inputp" />

                    </td>
                    <td class="MCTableTr_Left" style="width: 18%"><span>备案时间</span></td>
                    <td width="32%" class="MCTableTr_Right" style="background-color: #f6f6f6">
                        <asp:Label ID="txtsTime" runat="server" class="input input140" onfocus="WdatePicker({isShowClear:false,readOnly:true})" />
                    </td>
                </tr>

                <tr>
                    <td class="MCTableTr_Left" style="width: 18%">
                        <span>标题</span>
                    </td>
                    <td class="MCTableTr_Right" colspan="3" style="background-color: #f6f6f6">
                        <asp:Label ID="txtTitle" runat="server" CssClass="input input664" MaxLength="50"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="MCTableTr_Left" style="width: 18%">
                        <span>备注</span>
                    </td>
                    <td class="MCTableTr_Right" colspan="3" style="background-color: #f6f6f6">
                        <asp:Label ID="txtRemark" runat="server" TextMode="MultiLine" CssClass="inputArea664" MaxLength="999"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td colspan="4">
                        办理流程
                    </td>
                </tr>
                <tr>
                    
                    <td colspan="4">
                        <asp:Literal ID="ShowOpList" runat="server" EnableViewState="False"></asp:Literal>
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
