<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="ErrorReportDetail.aspx.vb"
    Inherits="CMCFileManage.ErrorReportDetail" %>

<%@ Register Src="../UCtl/UcFileDetail.ascx" TagName="UcFileDetail" TagPrefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../IconsThemes/icon.css" rel="stylesheet" type="text/css" />
    <link href="../NewScript/themes/Default/easyui.css" rel="stylesheet" type="text/css" />

    <script src="../NewScript/jquery-1.7.2.min.js" type="text/javascript"></script>

    <script src="../NewScript/jquery.easyui.min.js" type="text/javascript"></script>

    <script src="../NewScript/easyloader.js" type="text/javascript"></script>

    <script src="ErrorReport.js" type="text/javascript"></script>

    <script type="text/javascript" src="../NewScript/My97DatePicker/WdatePicker.js"></script>

</head>
<body scroll="Auto">
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <table width="100%">
        <tr>
            <td>
                <asp:Image ID="Image3" runat="server" ImageUrl="../Images/blank.jpg" />
                <div style="float: left">
                    <asp:LinkButton ID="LinkEdit" class="easyui-linkbutton" plain="true" iconCls="icon-edit"
                        runat="server">編輯</asp:LinkButton>
                    <asp:LinkButton ID="LinkSave" Visible="false" class="easyui-linkbutton" plain="true"
                        iconCls="icon-save" runat="server">保存</asp:LinkButton>
                    <asp:LinkButton ID="LinkLeave" class="easyui-linkbutton" plain="true" iconCls="icon-back"
                        runat="server">離開</asp:LinkButton>
                </div>
                <div style="clear: both">
                </div>
                <div align="center" style="color: #0066FF; font-size: 20px; font-family: 標楷體">
                    <asp:Label ID="Label1" runat="server" Text="偏差報告"></asp:Label>
                </div>
                <div>
                    <table width="100%">
                        <tr>
                            <td width="33%">
                                區域
                                <asp:TextBox ID="TxtQulocation" runat="server"></asp:TextBox>
                                <asp:HiddenField ID="HidQulocation" runat="server" />
                            </td>
                            <td width="33%">
                                部門<asp:DropDownList ID="DPLDept" runat="server">
                                </asp:DropDownList>
                            </td>
                            <td>
                                編號<asp:TextBox ID="TxtBH" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                    </table>
                </div>
                <div>
                    <table width="100%" border="1" cellspacing="0" cellpadding="0" bordercolor="#000000"
                        bordercolordark="#FFFFFF">
                        <tr>
                            <td bgcolor="#E5E5E5">
                                審核者
                            </td>
                            <td style="margin-left: 40px">
                                <asp:TextBox ID="TxtAduiter" runat="server"></asp:TextBox>
                            </td>
                            <td bgcolor="#E5E5E5">
                                陪同人員
                            </td>
                            <td>
                                <asp:TextBox ID="TxtFolwer" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td bgcolor="#E5E5E5">
                                規格題目
                            </td>
                            <td style="margin-left: 40px">
                                <asp:TextBox ID="TxtSpecTitle" runat="server"></asp:TextBox>
                            </td>
                            <td bgcolor="#E5E5E5">
                                規格編號版本
                            </td>
                            <td>
                                <asp:TextBox ID="TxtSpecVersion" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td bgcolor="#E5E5E5">
                                日期
                            </td>
                            <td>
                                <asp:TextBox ID="TxtReportTime" class="easyui-validatebox" required="true" runat="server"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                                    ControlToValidate="TxtReportTime" ErrorMessage="日期不允許為空"></asp:RequiredFieldValidator>
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td>
                                應用規格（包括段落，內容）
                            </td>
                            <td colspan="3">
                                <asp:RadioButtonList ID="RDOAppsec" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow">
                                    <asp:ListItem Value="1" Selected="True">主要缺失</asp:ListItem>
                                    <asp:ListItem Value="2">次要缺失</asp:ListItem>
                                    <asp:ListItem Value="3">建議觀察</asp:ListItem>
                                </asp:RadioButtonList>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="4">
                                <asp:TextBox ID="TxtDescription" runat="server" Width="99%"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="4">
                                審核發現(包括審核位置，操作員姓名，被審核者確認等)<br />
                                <asp:TextBox ID="TxtFindOut" runat="server" Width="99%"></asp:TextBox>
                                <uc1:UcFileDetail ID="UcFileDetail1" runat="server" />
                                <uc1:UcFileDetail ID="UcFileDetail4" runat="server" />
                            </td>
                        </tr>
                        <tr>
                            <td colspan="4">
                                根本原因和改正/預防措施<br />
                                <asp:TextBox ID="TxtReason" runat="server" Width="99%"></asp:TextBox>
                                <uc1:UcFileDetail ID="UcFileDetail2" runat="server" />
                                <uc1:UcFileDetail ID="UcFileDetail5" runat="server" />
                            </td>
                        </tr>
                        <tr>
                            <td bgcolor="#E5E5E5">
                                完成日期
                            </td>
                            <td>
                                <asp:TextBox ID="TxtFinishTime" runat="server" class="easyui-validatebox" required="true"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                                    ControlToValidate="TxtFinishTime" ErrorMessage="日期不允許為空"></asp:RequiredFieldValidator>
                            </td>
                            <td bgcolor="#E5E5E5">
                                預備
                            </td>
                            <td>
                                <asp:TextBox ID="TxtReady" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td bgcolor="#E5E5E5">
                                核准（主管）
                            </td>
                            <td style="margin-left: 40px">
                                <asp:TextBox ID="TxtApprovedzg" runat="server"></asp:TextBox>
                            </td>
                            <td bgcolor="#E5E5E5">
                                審核
                            </td>
                            <td>
                                <asp:TextBox ID="TxtFinishAduit" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="4">
                                驗證結果<asp:RadioButtonList ID="RDOVertifyResult" runat="server" RepeatDirection="Horizontal"
                                    RepeatLayout="Flow">
                                    <asp:ListItem Value="1" Selected="True">已結案</asp:ListItem>
                                    <asp:ListItem Value="2">未結案</asp:ListItem>
                                </asp:RadioButtonList>
                                <br />
                                <asp:TextBox ID="TxtResult" runat="server" Width="99%"></asp:TextBox>
                                <br />
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <uc1:UcFileDetail ID="UcFileDetail3" runat="server" />
                                <uc1:UcFileDetail ID="UcFileDetail6" runat="server" />
                            </td>
                            <td colspan="2">
                                完成日期<asp:TextBox ID="TxtYzFinishdate" runat="server" class="easyui-validatebox" required="true"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                                    ControlToValidate="TxtYzFinishdate" ErrorMessage="日期不允許為空"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td bgcolor="#E5E5E5">
                                核准人
                            </td>
                            <td>
                                <asp:TextBox ID="TxtApproved" runat="server"></asp:TextBox>
                            </td>
                            <td bgcolor="#E5E5E5">
                                驗證人
                            </td>
                            <td>
                                <asp:TextBox ID="TxtVertigyer" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                    </table>
                </div>
            </td>
        </tr>
    </table>
    </form>
</body>
</html>
