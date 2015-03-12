<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="FileReadManageDetail.aspx.vb"
    Inherits="CMCFileManage.FileReadManageDetail" %>

<%@ Register Src="../EFlowNet/Doc/Modules/CtlWFActionList.ascx" TagName="CtlWFActionList"
    TagPrefix="uc1" %>
<%@ Register Src="../EFlowNet/Doc/Modules/ctlWFHistory.ascx" TagName="ctlWFHistory"
    TagPrefix="uc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .cssnovisible
        {
            display: none;
        }
        .style11
        {
            width: 100%;
        }
    </style>
    <link href="../IconsThemes/icon.css" rel="stylesheet" type="text/css" />
    <link href="../NewScript/themes/Default/easyui.css" rel="stylesheet" type="text/css" />

    <script src="../NewScript/jquery-1.7.2.min.js" type="text/javascript"></script>

    <script src="../NewScript/jquery.easyui.min.js" type="text/javascript"></script>

    <script src="../NewScript/plugins/jquery.bgiframe.js" type="text/javascript"></script>

    <script src="../NewScript/plugins/jquery.toggleLoading.js" type="text/javascript"></script>

    <script src="../NewScript/easyloader.js" type="text/javascript"></script>

    <script src="../NewScript/My97DatePicker/WdatePicker.js" type="text/javascript"></script>

    <script src="FileReadManage.js" type="text/javascript"></script>

</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div align="center" style="width: 100%">
        <uc1:CtlWFActionList ID="CtlWFActionList1" runat="server" />
    </div>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div style="clear: both">
            </div>
            <div style="font-size: 20px; color: #0066FF; font-family: 標楷體;" align="center">
                <asp:Label ID="LBtitle" runat="server" Text="文件調閱申請單"></asp:Label>
            </div>
            <div id="sq" runat="server">
                <table width="100%" border="1" cellpadding="0" cellspacing="0" bordercolordark="#FFFFFF"
                    bordercolor="#999999">
                    <tr>
                        <td bgcolor="#E6E6E6" height="50">
                            <asp:Image ID="Image1" runat="server" ImageUrl="~/Images/ico/personal.png" />
                            <asp:Label ID="Label1" runat="server" Text="申請基本信息" Font-Bold="True" Font-Size="14px"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <div>
                                <table width="100%">
                                    <tr>
                                        <td>
                                            申請人
                                        </td>
                                        <td>
                                            <asp:TextBox ID="TxtApplyer" runat="server"></asp:TextBox>
                                        </td>
                                        <td>
                                            所屬單位
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="DPLDept" runat="server">
                                            </asp:DropDownList>
                                        </td>
                                        <td>
                                            申請日期
                                        </td>
                                        <td>
                                            <asp:TextBox ID="TXTApplydate" runat="server"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            使用人或單位
                                        </td>
                                        <td>
                                            <asp:TextBox ID="TXTUser" runat="server"></asp:TextBox>
                                        </td>
                                        <td>
                                            主管審核
                                        </td>
                                        <td>
                                            <asp:TextBox ID="TXTzhuguan" runat="server"></asp:TextBox>
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
                                            備註
                                        </td>
                                        <td>
                                            <asp:TextBox ID="TXTRemark" runat="server"></asp:TextBox>
                                        </td>
                                        <td>
                                            &nbsp;
                                        </td>
                                        <td>
                                            &nbsp;
                                        </td>
                                        <td>
                                            &nbsp;
                                        </td>
                                        <td>
                                            &nbsp;
                                        </td>
                                    </tr>
                                </table>
                            </div>
                        </td>
                    </tr>
                </table>
                <div>
                    <table width="100%" border="1" cellpadding="0" cellspacing="0" bordercolordark="#FFFFFF"
                        bordercolor="#999999">
                        <tr>
                            <td bgcolor="#E6E6E6" height="50">
                                <asp:Image ID="Image2" runat="server" ImageUrl="~/Images/ico/baseinfo.png" />
                                <asp:Label ID="Label2" runat="server" Text="文件調閱個數:&nbsp;&nbsp;" Font-Bold="True"
                                    Font-Size="14px"></asp:Label>
                                <asp:Label ID="LbFileCount" runat="server" Text="0" ForeColor="Red"></asp:Label>
                                <asp:HiddenField ID="HiddenFileCount" Value="1" runat="server" />
                                <a href="#" onclick="GetFileDialog('#FileDialog', '#FileInfo', 'DropDownList1')"
                                    class="easyui-linkbutton" plain="true" iconcls="icon-add">點我添加 </a>
                            </td>
                        </tr>
                    </table>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
    <table width="100%" border="1" cellspacing="0" cellpadding="0" bordercolor="#000000"
        bordercolordark="#FFFFFF">
        <tr>
            <td>
                序號
            </td>
            <td>
                文件編號
            </td>
            <td>
                文件名
            </td>
            <td>
                調閱方式
            </td>
            <td>
                用途說明
            </td>
        </tr>
        <tr id="file1" runat="server" class="cssnovisible">
            <td>
                1
            </td>
            <td>
                <input id="FileBH1" runat="server" readonly="readonly" style="width: 100px;" />
                <input id="HiddenFileBH1" runat="server" type="hidden" />
            </td>
            <td>
                <asp:TextBox ID="txtFilename1" runat="server" ReadOnly="true"></asp:TextBox>
                <asp:HiddenField ID="HiddenFileName1" runat="server" />
            </td>
            <td>
                <asp:DropDownList ID="DPLReadType1" runat="server">
                    <asp:ListItem Text="電子原檔" Value="電子原檔"></asp:ListItem>
                    <asp:ListItem Text="開放系統閱讀權限" Value="開放系統閱讀權限"></asp:ListItem>
                    <asp:ListItem Text="受控紙檔" Value="受控紙檔"></asp:ListItem>
                    <asp:ListItem Text="非受控紙檔" Value="非受控紙檔"></asp:ListItem>
                    <asp:ListItem Text="非受控/PDF檔" Value="非受控/PDF檔"></asp:ListItem>
                </asp:DropDownList>
            </td>
            <td>
                <asp:TextBox ID="TxtRemark1" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr id="file2" runat="server" class="cssnovisible">
            <td>
                2
            </td>
            <td>
                <input id="FileBH2" runat="server" readonly="readonly" style="width: 100px;" />
                <input id="HiddenFileBH2" runat="server" type="hidden" />
            </td>
            <td>
                <asp:TextBox ID="txtFilename2" runat="server" ReadOnly="true"></asp:TextBox>
                <asp:HiddenField ID="HiddenFileName2" runat="server" />
            </td>
            <td>
                <asp:DropDownList ID="DPLReadType2" runat="server">
                    <asp:ListItem Text="電子原檔" Value="電子原檔"></asp:ListItem>
                    <asp:ListItem Text="開放系統閱讀權限" Value="開放系統閱讀權限"></asp:ListItem>
                    <asp:ListItem Text="受控紙檔" Value="受控紙檔"></asp:ListItem>
                    <asp:ListItem Text="非受控紙檔" Value="非受控紙檔"></asp:ListItem>
                    <asp:ListItem Text="非受控/PDF檔" Value="非受控/PDF檔"></asp:ListItem>
                </asp:DropDownList>
            </td>
            <td>
                <asp:TextBox ID="TxtRemark2" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr id="file3" runat="server" class="cssnovisible">
            <td>
                3
            </td>
            <td>
                <input id="FileBH3" runat="server" readonly="readonly" style="width: 100px;" />
                <input id="HiddenFileBH3" runat="server" type="hidden" />
            </td>
            <td>
                <asp:TextBox ID="txtFilename3" runat="server" ReadOnly="true"></asp:TextBox>
                <asp:HiddenField ID="HiddenFileName3" runat="server" />
            </td>
            <td>
                <asp:DropDownList ID="DPLReadType3" runat="server">
                    <asp:ListItem Text="電子原檔" Value="電子原檔"></asp:ListItem>
                    <asp:ListItem Text="開放系統閱讀權限" Value="開放系統閱讀權限"></asp:ListItem>
                    <asp:ListItem Text="受控紙檔" Value="受控紙檔"></asp:ListItem>
                    <asp:ListItem Text="非受控紙檔" Value="非受控紙檔"></asp:ListItem>
                    <asp:ListItem Text="非受控/PDF檔" Value="非受控/PDF檔"></asp:ListItem>
                </asp:DropDownList>
            </td>
            <td>
                <asp:TextBox ID="TxtRemark3" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr id="file4" runat="server" class="cssnovisible">
            <td>
                4
            </td>
            <td>
                <input id="FileBH4" runat="server" readonly="readonly" style="width: 100px;" />
                <input id="HiddenFileBH4" runat="server" type="hidden" />
            </td>
            <td>
                <asp:TextBox ID="txtFilename4" runat="server" ReadOnly="true"></asp:TextBox>
                <asp:HiddenField ID="HiddenFileName4" runat="server" />
            </td>
            <td>
                <asp:DropDownList ID="DPLReadType4" runat="server">
                    <asp:ListItem Text="電子原檔" Value="電子原檔"></asp:ListItem>
                    <asp:ListItem Text="開放系統閱讀權限" Value="開放系統閱讀權限"></asp:ListItem>
                    <asp:ListItem Text="受控紙檔" Value="受控紙檔"></asp:ListItem>
                    <asp:ListItem Text="非受控紙檔" Value="非受控紙檔"></asp:ListItem>
                    <asp:ListItem Text="非受控/PDF檔" Value="非受控/PDF檔"></asp:ListItem>
                </asp:DropDownList>
            </td>
            <td>
                <asp:TextBox ID="TxtRemark4" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr id="file5" runat="server" class="cssnovisible">
            <td>
                5
            </td>
            <td>
                <input id="FileBH5" runat="server" readonly="readonly" style="width: 100px;" />
                <input id="HiddenFileBH5" runat="server" type="hidden" />
            </td>
            <td>
                <asp:TextBox ID="txtFilename5" runat="server" ReadOnly="true"></asp:TextBox>
                <asp:HiddenField ID="HiddenFileName5" runat="server" />
            </td>
            <td>
                <asp:DropDownList ID="DPLReadType5" runat="server">
                    <asp:ListItem Text="電子原檔" Value="電子原檔"></asp:ListItem>
                    <asp:ListItem Text="開放系統閱讀權限" Value="開放系統閱讀權限"></asp:ListItem>
                    <asp:ListItem Text="受控紙檔" Value="受控紙檔"></asp:ListItem>
                    <asp:ListItem Text="非受控紙檔" Value="非受控紙檔"></asp:ListItem>
                    <asp:ListItem Text="非受控/PDF檔" Value="非受控/PDF檔"></asp:ListItem>
                </asp:DropDownList>
            </td>
            <td>
                <asp:TextBox ID="TxtRemark5" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr id="file6" runat="server" class="cssnovisible">
            <td>
                6
            </td>
            <td>
                <input id="FileBH6" runat="server" readonly="readonly" style="width: 100px;" />
                <input id="HiddenFileBH6" runat="server" type="hidden" />
            </td>
            <td>
                <asp:TextBox ID="txtFilename6" runat="server" ReadOnly="true"></asp:TextBox>
                <asp:HiddenField ID="HiddenFileName6" runat="server" />
            </td>
            <td>
                <asp:DropDownList ID="DPLReadType6" runat="server">
                    <asp:ListItem Text="電子原檔" Value="電子原檔"></asp:ListItem>
                    <asp:ListItem Text="開放系統閱讀權限" Value="開放系統閱讀權限"></asp:ListItem>
                    <asp:ListItem Text="受控紙檔" Value="受控紙檔"></asp:ListItem>
                    <asp:ListItem Text="非受控紙檔" Value="非受控紙檔"></asp:ListItem>
                    <asp:ListItem Text="非受控/PDF檔" Value="非受控/PDF檔"></asp:ListItem>
                </asp:DropDownList>
            </td>
            <td>
                <asp:TextBox ID="TxtRemark6" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr id="file7" runat="server" class="cssnovisible">
            <td>
                7
            </td>
            <td>
                <input id="FileBH7" runat="server" readonly="readonly" style="width: 100px;" />
                <input id="HiddenFileBH7" runat="server" type="hidden" />
            </td>
            <td>
                <asp:TextBox ID="txtFilename7" runat="server" ReadOnly="true"></asp:TextBox>
                <asp:HiddenField ID="HiddenFileName7" runat="server" />
            </td>
            <td>
                <asp:DropDownList ID="DPLReadType7" runat="server">
                    <asp:ListItem Text="電子原檔" Value="電子原檔"></asp:ListItem>
                    <asp:ListItem Text="開放系統閱讀權限" Value="開放系統閱讀權限"></asp:ListItem>
                    <asp:ListItem Text="受控紙檔" Value="受控紙檔"></asp:ListItem>
                    <asp:ListItem Text="非受控紙檔" Value="非受控紙檔"></asp:ListItem>
                    <asp:ListItem Text="非受控/PDF檔" Value="非受控/PDF檔"></asp:ListItem>
                </asp:DropDownList>
            </td>
            <td>
                <asp:TextBox ID="TxtRemark7" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr id="file8" runat="server" class="cssnovisible">
            <td>
                8
            </td>
            <td>
                <input id="FileBH8" runat="server" readonly="readonly" style="width: 100px;" />
                <input id="HiddenFileBH8" runat="server" type="hidden" />
            </td>
            <td>
                <asp:TextBox ID="txtFilename8" runat="server" ReadOnly="true"></asp:TextBox>
                <asp:HiddenField ID="HiddenFileName8" runat="server" />
            </td>
            <td>
                <asp:DropDownList ID="DPLReadType8" runat="server">
                    <asp:ListItem Text="電子原檔" Value="電子原檔"></asp:ListItem>
                    <asp:ListItem Text="開放系統閱讀權限" Value="開放系統閱讀權限"></asp:ListItem>
                    <asp:ListItem Text="受控紙檔" Value="受控紙檔"></asp:ListItem>
                    <asp:ListItem Text="非受控紙檔" Value="非受控紙檔"></asp:ListItem>
                    <asp:ListItem Text="非受控/PDF檔" Value="非受控/PDF檔"></asp:ListItem>
                </asp:DropDownList>
            </td>
            <td>
                <asp:TextBox ID="TxtRemark8" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr id="file9" runat="server" class="cssnovisible">
            <td>
                9
            </td>
            <td>
                <input id="FileBH9" runat="server" readonly="readonly" style="width: 100px;" />
                <input id="HiddenFileBH9" runat="server" type="hidden" />
            </td>
            <td>
                <asp:TextBox ID="txtFilename9" runat="server" ReadOnly="true"></asp:TextBox>
                <asp:HiddenField ID="HiddenFileName9" runat="server" />
            </td>
            <td>
                <asp:DropDownList ID="DPLReadType9" runat="server">
                    <asp:ListItem Text="電子原檔" Value="電子原檔"></asp:ListItem>
                    <asp:ListItem Text="開放系統閱讀權限" Value="開放系統閱讀權限"></asp:ListItem>
                    <asp:ListItem Text="受控紙檔" Value="受控紙檔"></asp:ListItem>
                    <asp:ListItem Text="非受控紙檔" Value="非受控紙檔"></asp:ListItem>
                    <asp:ListItem Text="非受控/PDF檔" Value="非受控/PDF檔"></asp:ListItem>
                </asp:DropDownList>
            </td>
            <td>
                <asp:TextBox ID="TxtRemark9" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr id="file10" runat="server" class="cssnovisible">
            <td>
                10
            </td>
            <td>
                <input id="FileBH10" runat="server" readonly="readonly" style="width: 100px;" />
                <input id="HiddenFileBH10" runat="server" type="hidden" />
            </td>
            <td>
                <asp:TextBox ID="txtFilename10" runat="server" ReadOnly="true"></asp:TextBox>
                <asp:HiddenField ID="HiddenFileName10" runat="server" />
            </td>
            <td>
                <asp:DropDownList ID="DPLReadType10" runat="server">
                    <asp:ListItem Text="電子原檔" Value="電子原檔"></asp:ListItem>
                    <asp:ListItem Text="開放系統閱讀權限" Value="開放系統閱讀權限"></asp:ListItem>
                    <asp:ListItem Text="受控紙檔" Value="受控紙檔"></asp:ListItem>
                    <asp:ListItem Text="非受控紙檔" Value="非受控紙檔"></asp:ListItem>
                    <asp:ListItem Text="非受控/PDF檔" Value="非受控/PDF檔"></asp:ListItem>
                </asp:DropDownList>
            </td>
            <td>
                <asp:TextBox ID="TxtRemark10" runat="server"></asp:TextBox>
            </td>
        </tr>
    </table>
    <div style="clear: both; height: 30px;">
    </div>
    <div id="cb" runat="server">
        <table width="100%" border="1" cellspacing="0" cellpadding="0" bordercolor="#000000"
            bordercolordark="#FFFFFF"">
            <tr>
                <td colspan="6" width="20%" bgcolor="#E6E6E6" height="50">
                    <asp:Image ID="Image3" runat="server" ImageUrl="~/Images/ico/applyinfo.png" />
                    <asp:Label ID="Label3" runat="server" Text="承辦單位填寫" Font-Bold="True" Font-Size="14px"></asp:Label>
                </td>
            </tr>
            <tr>
                <td bgcolor="#E5E5E5">
                    批准
                </td>
                <td colspan="3" width="40%">
                    <asp:Label ID="LBpizhun0" runat="server"></asp:Label>
                    &nbsp;
                </td>
                <td bgcolor="#E5E5E5" width="20%">
                    批准日期
                </td>
                <td width="20%">
                    <asp:Label ID="LBpizhunDate0" runat="server"></asp:Label>
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td bgcolor="#E5E5E5" rowspan="2">
                    紙檔文件處理
                </td>
                <td colspan="3">
                    <asp:CheckBox ID="CHBsk" runat="server" Text="受控" Enabled="False" />
                    &nbsp;&nbsp;&nbsp; 份數<asp:TextBox ID="Txtsknum" class="easyui-numberbox" data-options="min:0,max:1000,precision:0"
                        runat="server" Width="50px" Enabled="False"></asp:TextBox>
                </td>
                <td bgcolor="#E5E5E5" rowspan="2">
                    申請人簽收/日期
                </td>
                <td rowspan="2">
                    <asp:Label ID="LBApplyuerqianshou" runat="server"></asp:Label>
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:CheckBox ID="CHBfsk" Enabled="False" runat="server" Text="非受控" />
                    份數<asp:TextBox ID="TXTfsknum" Enabled="False" class="easyui-numberbox" data-options="min:0,max:1000,precision:0"
                        runat="server" Width="50px"></asp:TextBox>
                </td>
                <td>
                    <asp:CheckBox ID="CHBneedBack" Enabled="False" runat="server" Text="需否歸還" />
                </td>
            </tr>
            <tr>
                <td bgcolor="#E5E5E5">
                    承辦人
                </td>
                <td width="15%">
                    <asp:Label ID="LBchengbanUser" runat="server"></asp:Label>
                    &nbsp;
                </td>
                <td bgcolor="#E5E5E5" width="10%">
                    承辦日期
                </td>
                <td width="15%">
                    <asp:Label ID="LBchengbandate" runat="server"></asp:Label>
                    &nbsp;
                </td>
                <td bgcolor="#E5E5E5">
                    承辦人簽收/日期
                </td>
                <td>
                    <asp:Label ID="LBChengbanqianshou" runat="server"></asp:Label>
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td bgcolor="#E5E5E5">
                    備註
                </td>
                <td colspan="5">
                    <asp:TextBox ID="TxtcbRemark0" Enabled="False" runat="server"></asp:TextBox>
                </td>
            </tr>
        </table>
    </div>
    <div style="clear: both; height: 30px;">
    </div>
    <div>
        <table width="100%" border="1" cellspacing="0" cellpadding="0" bordercolor="#000000"
            bordercolordark="#FFFFFF"">
            <tr>
                <td bgcolor="#E6E6E6" height="50">
                    <asp:Image ID="Image4" runat="server" ImageUrl="~/Images/ico/history.png" />
                    <asp:Label ID="Label4" runat="server" Text="簽核歷史" Font-Bold="True" Font-Size="14px"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;
                </td>
            </tr>
        </table>
        <uc2:ctlWFHistory ID="ctlWFHistory1" runat="server" />
    </div>
    <div style="display: none;">
        <asp:HiddenField ID="hidExpenseCode" runat="server" Value="" />
        <asp:HiddenField ID="hidfilnum" runat="server" Value="1" />
        <asp:HiddenField ID="HidIsFlow" runat="server" Value="1" />
    </div>
    <div id="FileDialog" iconcls="icon-save" closed="true" title="請選擇文件" runat="server">
        <div id="FileInfo" toolbar="#dlg-toolbar">
        </div>
        <div id="dlg-toolbar" style="display: none;">
            <table cellpadding="0" cellspacing="0" style="width: 100%">
                <tr>
                    <td style="width: 100%; text-align: right;" style="padding-left: 2px">
                        <asp:Label ID="Label22" runat="server" Text="文件名"></asp:Label>
                    </td>
                    <td style="text-align: right; padding-right: 2px">
                        <input class="easyui-searchbox" searcher="selectcustomer"></input>
                    </td>
                </tr>
            </table>
        </div>
    </div>
    </form>
</body>
</html>
