<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="ComplaintsDetail.aspx.vb"
    Inherits="CMCFileManage.ComplaintsDetail" %>

<%@ Register Src="../UCtl/UcFileDetail.ascx" TagName="UcFileDetail" TagPrefix="uc1" %>
<%@ Register Src="../EFlowNet/Doc/Modules/CtlWFActionList.ascx" TagName="CtlWFActionList"
    TagPrefix="uc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../IconsThemes/icon.css" rel="stylesheet" type="text/css" />
    <link href="../NewScript/themes/Default/easyui.css" rel="stylesheet" type="text/css" />
    <script src="../NewScript/jquery-1.7.2.min.js" type="text/javascript"></script>

    <script src="../NewScript/jquery.easyui.min.js" type="text/javascript"></script>

    <script src="../NewScript/easyloader.js" type="text/javascript"></script>

    <script src="../NewScript/plugins/jquery.bgiframe.js" type="text/javascript"></script>

    <script src="../NewScript/plugins/jquery.toggleLoading.js" type="text/javascript"></script>

    <script src="../NewScript/My97DatePicker/WdatePicker.js" type="text/javascript"></script>

</head>
<body scroll="Auto">
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <table width ="100%" ><tr><td> <asp:Image ID="Image3" runat="server" ImageUrl="../Images/blank.jpg" />
    <div align="center">
        <asp:Label ID="LbTitle" runat="server" Font-Size="20px">華南檢測中心客戶投訴受理及處理報告單</asp:Label>
    </div>
     <div>
        <uc2:CtlWFActionList ID="CtlWFActionList1" runat="server" />
    </div>
    <div>
        <table width="100%">
            <tr>
                <td>
                    區域：<asp:DropDownList ID="DPLQuLocation" runat="server" Width="155px">
                    </asp:DropDownList>
                </td>
                <td align="right">
                    編號：<asp:Label ID="LbRecordNO" runat="server" Text="Label"></asp:Label>
                </td>
            </tr>
        </table>
    </div>
    
    <div>
        <table width="100%" border="1" cellpadding="0" cellspacing="0" bordercolor="#000000"
            bordercolordark="#FFFFFF">
            <tr>
                <td width="25%">
                    投訴單位
                </td>
                <td style="margin-left: 40px" width="25%">
                    <asp:TextBox ID="TxtComplaintsDept" runat="server"></asp:TextBox>
                </td>
                <td width="25%">
                    投訴人
                </td>
                <td width="25%">
                    <asp:TextBox ID="TxtComplaintsPerson" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    投訴人職務
                </td>
                <td>
                    <asp:TextBox ID="TxtComplaintsPosition" runat="server"></asp:TextBox>
                </td>
                <td>
                    被投訴單位
                </td>
                <td>
                    <asp:DropDownList ID="DPLBeComplaintsDept" runat="server" Width="155px">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>
                    投訴時間
                </td>
                <td>
                    <asp:TextBox ID="TxtComplaintsDate" runat="server"></asp:TextBox>
                </td>
                <td>
                    希望完成時間
                </td>
                <td>
                    <asp:TextBox ID="TxtHopeFinishTime" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    電話
                </td>
                <td style="margin-left: 40px">
                    <asp:TextBox ID="TxtPhone" runat="server"></asp:TextBox>
                </td>
                <td>
                    Email
                </td>
                <td>
                    <asp:TextBox ID="TxtEmail" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    投訴事項簡述
                </td>
                <td colspan="3">
                    <asp:TextBox ID="TxtComplaintsDesc" runat="server" Width="85%"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    投訴事項
                </td>
                <td>
                    <asp:TextBox ID="TxtComplaintsDetailed" runat="server"></asp:TextBox>
                </td>
                <td colspan="2">
                    <uc1:UcFileDetail ID="UcFileDetail1" runat="server" />
                     <uc1:UcFileDetail ID="UcFileDetail6" runat="server" />
                </td>
            </tr>
            <tr id="cb1" runat ="server"  >
                <td>
                    調查結果
                </td>
                <td>
                    <asp:TextBox ID="TxtFindings" runat="server"></asp:TextBox>
                </td>
                <td colspan="2">
                    <uc1:UcFileDetail ID="UcFileDetail2" runat="server" />
                     <uc1:UcFileDetail ID="UcFileDetail7" runat="server" />
                </td>
            </tr>
            <tr id ="cb2" runat ="server" >
                <td>
                    原因分析
                </td>
                <td>
                    <asp:TextBox ID="TxtReasons" runat="server"></asp:TextBox>
                </td>
                <td colspan="2">
                    <uc1:UcFileDetail ID="UcFileDetail3" runat="server" />
                     <uc1:UcFileDetail ID="UcFileDetail8" runat="server" />
                </td>
            </tr>
            <tr id ="cb3" runat ="server" >
                <td>
                    改善對策
                </td>
                <td>
                    <asp:TextBox ID="TxtImprove" runat="server"></asp:TextBox>
                </td>
                <td colspan="2">
                    <uc1:UcFileDetail ID="UcFileDetail4" runat="server" />
                     <uc1:UcFileDetail ID="UcFileDetail9" runat="server" />
                </td>
            </tr>
            <tr id ="cb4" runat ="server" >
                <td>
                    處理情況
                </td>
                <td>
                    <asp:TextBox ID="TxtHinding" runat="server"></asp:TextBox>
                </td>
                <td colspan="2">
                    <uc1:UcFileDetail ID="UcFileDetail5" runat="server" />
                     <uc1:UcFileDetail ID="UcFileDetail10" runat="server" />
                </td>
            </tr>
            <tr id ="cb6" runat ="server" >
                <td>
                    是否結案</td>
                <td colspan="3">
                    <asp:RadioButtonList ID="RdoIsfinished" runat="server" 
                        RepeatDirection="Horizontal" RepeatLayout="Flow" >
                        <asp:ListItem Selected="True" Value="0">未結案</asp:ListItem>
                        <asp:ListItem Value="1">已結案</asp:ListItem>
                    </asp:RadioButtonList>
                </td>
            </tr>
            <tr id ="cb5" runat ="server" >
                <td>
                    核准
                </td>
                <td>
                    <asp:TextBox ID="TxtApproved" runat="server"></asp:TextBox>
                    
                </td>
                <td>
                    承辦
                </td>
                <td>
                    <asp:TextBox ID="TxtUnderTake" runat="server"></asp:TextBox>
                </td>
            </tr>
        </table>
    </div>
    </td> </tr> </table> 
    </form>
</body>
</html>
