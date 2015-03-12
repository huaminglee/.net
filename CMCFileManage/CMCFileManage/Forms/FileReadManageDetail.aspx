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
        .cssvisible
        {
            display: inline;
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
<body scroll="Auto">
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <table width="100%">
        <tr>
            <td>
                <asp:Image ID="Image5" runat="server" ImageUrl="../Images/blank.jpg" />
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
                                    <td bgcolor="#E4F1FA" height="50">
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
                                                        <asp:TextBox ID="TXTzhuguan" Enabled ="false"  runat="server"></asp:TextBox>
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
                                        <td bgcolor="#E4F1FA" height="50">
                                            <asp:Image ID="Image2" runat="server" ImageUrl="~/Images/ico/baseinfo.png" />
                                            <asp:Label ID="Label2" runat="server" Text="文件調閱個數:&nbsp;&nbsp;" Font-Bold="True"
                                                Font-Size="14px"></asp:Label>
                                            <asp:Label ID="LbFileCount" runat="server" Text="0" ForeColor="Red"></asp:Label>
                                            &nbsp;(最大10)
                                            <asp:HiddenField ID="HiddenFileCount" Value="1" runat="server" />
                                            <div id ="divaddf" runat ="server" >
                                            <a href="#"   onclick="GetFileDialog('#FileDialog', '#FileInfo', 'DropDownList1')"
                                                class="easyui-linkbutton" plain="true" iconcls="icon-add">點我添加 </a>
                                                </div>
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
                            <asp:TextBox ID="txtFilename1" width="90%" runat="server" ReadOnly="true"></asp:TextBox>
                            <asp:HiddenField ID="HiddenFileName1"  runat="server" />
                        </td>
                        <td>
                            <asp:DropDownList ID="DPLReadType1" onchange="ReadTypechange('DPLReadType1',1)" runat="server">
                                <asp:ListItem Text="電子原檔" Value="電子原檔"></asp:ListItem>
                                <asp:ListItem Text="開放系統閱讀權限" Value="開放系統閱讀權限"></asp:ListItem>
                                <asp:ListItem Text="受控紙檔" Value="受控紙檔"></asp:ListItem>
                                <asp:ListItem Text="非受控紙檔" Value="非受控紙檔"></asp:ListItem>
                                <asp:ListItem Text="非受控/PDF檔" Value="非受控/PDF檔"></asp:ListItem>
                                <asp:ListItem Text="其它" Value="其它"></asp:ListItem>
                            </asp:DropDownList>
                            <div id="fenshu1" runat="server" class="cssnovisible">
                                X<asp:TextBox ID="TxtFenshu1" Width="50px" runat="server"></asp:TextBox>
                                份
                            </div>
                            <div id="shuoming1" runat="server" class="cssnovisible">
                                請說明<asp:TextBox ID="Txtshuoming1" runat="server"></asp:TextBox>
                            </div>
                        </td>
                        <td>
                            <asp:TextBox ID="TxtRemark1" runat="server"></asp:TextBox>
                            <img id="delete1" alt="刪除" src="../Images/Delete.gif" onclick="deletecur(1)" style="display: none" />
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
                            <asp:TextBox ID="txtFilename2" width="90%" runat="server" ReadOnly="true"></asp:TextBox>
                            <asp:HiddenField ID="HiddenFileName2"  runat="server" />
                        </td>
                        <td>
                            <asp:DropDownList ID="DPLReadType2" onchange="ReadTypechange('DPLReadType2',2)" runat="server">
                                <asp:ListItem Text="電子原檔" Value="電子原檔"></asp:ListItem>
                                <asp:ListItem Text="開放系統閱讀權限" Value="開放系統閱讀權限"></asp:ListItem>
                                <asp:ListItem Text="受控紙檔" Value="受控紙檔"></asp:ListItem>
                                <asp:ListItem Text="非受控紙檔" Value="非受控紙檔"></asp:ListItem>
                                <asp:ListItem Text="非受控/PDF檔" Value="非受控/PDF檔"></asp:ListItem>
                                <asp:ListItem Text="其它" Value="其它"></asp:ListItem>
                            </asp:DropDownList>
                            <div id="fenshu2" runat="server" class="cssnovisible">
                                X<asp:TextBox ID="TxtFenshu2" Width="50px" runat="server"></asp:TextBox>
                                份
                            </div>
                            <div id="shuoming2" runat="server" class="cssnovisible">
                                請說明<asp:TextBox ID="Txtshuoming2"  runat="server"></asp:TextBox>
                            </div>
                        </td>
                        <td>
                            <asp:TextBox ID="TxtRemark2" runat="server"></asp:TextBox>
                            <img id="delete2" alt="刪除" src="../Images/Delete.gif" onclick="deletecur(2)" style="display: none" />
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
                            <asp:TextBox ID="txtFilename3" width="90%" runat="server" ReadOnly="true"></asp:TextBox>
                            <asp:HiddenField ID="HiddenFileName3"  runat="server" />
                        </td>
                        <td>
                            <asp:DropDownList ID="DPLReadType3" onchange="ReadTypechange('DPLReadType3',3)" runat="server">
                                <asp:ListItem Text="電子原檔" Value="電子原檔"></asp:ListItem>
                                <asp:ListItem Text="開放系統閱讀權限" Value="開放系統閱讀權限"></asp:ListItem>
                                <asp:ListItem Text="受控紙檔" Value="受控紙檔"></asp:ListItem>
                                <asp:ListItem Text="非受控紙檔" Value="非受控紙檔"></asp:ListItem>
                                <asp:ListItem Text="非受控/PDF檔" Value="非受控/PDF檔"></asp:ListItem>
                                <asp:ListItem Text="其它" Value="其它"></asp:ListItem>
                            </asp:DropDownList>
                            <div id="fenshu3" runat="server" class="cssnovisible">
                                X<asp:TextBox ID="TxtFenshu3" Width="50px" runat="server"></asp:TextBox>
                                份
                            </div>
                            <div id="shuoming3" runat="server" class="cssnovisible">
                                請說明<asp:TextBox ID="Txtshuoming3" runat="server"></asp:TextBox>
                            </div>
                        </td>
                        <td>
                            <asp:TextBox ID="TxtRemark3" runat="server"></asp:TextBox>
                            <img id="delete3" alt="刪除" src="../Images/Delete.gif" onclick="deletecur(3)" style="display: none" />
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
                            <asp:TextBox ID="txtFilename4" width="90%" runat="server" ReadOnly="true"></asp:TextBox>
                            <asp:HiddenField ID="HiddenFileName4" runat="server" />
                        </td>
                        <td>
                            <asp:DropDownList ID="DPLReadType4" onchange="ReadTypechange('DPLReadType4',4)" runat="server">
                                <asp:ListItem Text="電子原檔" Value="電子原檔"></asp:ListItem>
                                <asp:ListItem Text="開放系統閱讀權限" Value="開放系統閱讀權限"></asp:ListItem>
                                <asp:ListItem Text="受控紙檔" Value="受控紙檔"></asp:ListItem>
                                <asp:ListItem Text="非受控紙檔" Value="非受控紙檔"></asp:ListItem>
                                <asp:ListItem Text="非受控/PDF檔" Value="非受控/PDF檔"></asp:ListItem>
                                <asp:ListItem Text="其它" Value="其它"></asp:ListItem>
                            </asp:DropDownList>
                            <div id="fenshu4" runat="server" class="cssnovisible">
                                X<asp:TextBox ID="TxtFenshu4" Width="50px" runat="server"></asp:TextBox>
                                份
                            </div>
                            <div id="shuoming4" runat="server" class="cssnovisible">
                                請說明<asp:TextBox ID="Txtshuoming4" runat="server"></asp:TextBox>
                            </div>
                        </td>
                        <td>
                            <asp:TextBox ID="TxtRemark4" runat="server"></asp:TextBox>
                            <img id="delete4" alt="刪除" src="../Images/Delete.gif" onclick="deletecur(4)" style="display: none" />
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
                            <asp:TextBox ID="txtFilename5" width="90%" runat="server" ReadOnly="true"></asp:TextBox>
                            <asp:HiddenField ID="HiddenFileName5" runat="server" />
                        </td>
                        <td>
                            <asp:DropDownList ID="DPLReadType5" onchange="ReadTypechange('DPLReadType5',5)" runat="server">
                                <asp:ListItem Text="電子原檔" Value="電子原檔"></asp:ListItem>
                                <asp:ListItem Text="開放系統閱讀權限" Value="開放系統閱讀權限"></asp:ListItem>
                                <asp:ListItem Text="受控紙檔" Value="受控紙檔"></asp:ListItem>
                                <asp:ListItem Text="非受控紙檔" Value="非受控紙檔"></asp:ListItem>
                                <asp:ListItem Text="非受控/PDF檔" Value="非受控/PDF檔"></asp:ListItem>
                                <asp:ListItem Text="其它" Value="其它"></asp:ListItem>
                            </asp:DropDownList>
                            <div id="fenshu5" runat="server" class="cssnovisible">
                                X<asp:TextBox ID="TxtFenshu5" Width="50px" runat="server"></asp:TextBox>
                                份
                            </div>
                            <div id="shuoming5" runat="server" class="cssnovisible">
                                請說明<asp:TextBox ID="Txtshuoming5" runat="server"></asp:TextBox>
                            </div>
                        </td>
                        <td>
                            <asp:TextBox ID="TxtRemark5" runat="server"></asp:TextBox>
                            <img id="delete5" alt="刪除" src="../Images/Delete.gif" onclick="deletecur(5)" style="display: none" />
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
                            <asp:TextBox ID="txtFilename6" width="90%" runat="server" ReadOnly="true"></asp:TextBox>
                            <asp:HiddenField ID="HiddenFileName6" runat="server" />
                        </td>
                        <td>
                            <asp:DropDownList ID="DPLReadType6" onchange="ReadTypechange('DPLReadType6',6)" runat="server">
                                <asp:ListItem Text="電子原檔" Value="電子原檔"></asp:ListItem>
                                <asp:ListItem Text="開放系統閱讀權限" Value="開放系統閱讀權限"></asp:ListItem>
                                <asp:ListItem Text="受控紙檔" Value="受控紙檔"></asp:ListItem>
                                <asp:ListItem Text="非受控紙檔" Value="非受控紙檔"></asp:ListItem>
                                <asp:ListItem Text="非受控/PDF檔" Value="非受控/PDF檔"></asp:ListItem>
                                <asp:ListItem Text="其它" Value="其它"></asp:ListItem>
                            </asp:DropDownList>
                            <div id="fenshu6" runat="server" class="cssnovisible">
                                X<asp:TextBox ID="TxtFenshu6" Width="50px" runat="server"></asp:TextBox>
                                份
                            </div>
                            <div id="shuoming6" runat="server" class="cssnovisible">
                                請說明<asp:TextBox ID="Txtshuoming6" runat="server"></asp:TextBox>
                            </div>
                        </td>
                        <td>
                            <asp:TextBox ID="TxtRemark6" runat="server"></asp:TextBox>
                            <img id="delete6" alt="刪除" src="../Images/Delete.gif" onclick="deletecur(6)" style="display: none" />
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
                            <asp:TextBox ID="txtFilename7" width="90%" runat="server" ReadOnly="true"></asp:TextBox>
                            <asp:HiddenField ID="HiddenFileName7" runat="server" />
                        </td>
                        <td>
                            <asp:DropDownList ID="DPLReadType7" onchange="ReadTypechange('DPLReadType7',7)" runat="server">
                                <asp:ListItem Text="電子原檔" Value="電子原檔"></asp:ListItem>
                                <asp:ListItem Text="開放系統閱讀權限" Value="開放系統閱讀權限"></asp:ListItem>
                                <asp:ListItem Text="受控紙檔" Value="受控紙檔"></asp:ListItem>
                                <asp:ListItem Text="非受控紙檔" Value="非受控紙檔"></asp:ListItem>
                                <asp:ListItem Text="非受控/PDF檔" Value="非受控/PDF檔"></asp:ListItem>
                                <asp:ListItem Text="其它" Value="其它"></asp:ListItem>
                            </asp:DropDownList>
                            <div id="fenshu7" runat="server" class="cssnovisible">
                                X<asp:TextBox ID="TxtFenshu7" Width="50px" runat="server"></asp:TextBox>
                                份
                            </div>
                            <div id="shuoming7" runat="server" class="cssnovisible">
                                請說明<asp:TextBox ID="Txtshuoming7" runat="server"></asp:TextBox>
                            </div>
                        </td>
                        <td>
                            <asp:TextBox ID="TxtRemark7" runat="server"></asp:TextBox>
                            <img id="delete7" alt="刪除" src="../Images/Delete.gif" onclick="deletecur(7)" style="display: none" />
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
                            <asp:TextBox ID="txtFilename8" width="90%" runat="server" ReadOnly="true"></asp:TextBox>
                            <asp:HiddenField ID="HiddenFileName8" runat="server" />
                        </td>
                        <td>
                            <asp:DropDownList ID="DPLReadType8" onchange="ReadTypechange('DPLReadType8',8)" runat="server">
                                <asp:ListItem Text="電子原檔" Value="電子原檔"></asp:ListItem>
                                <asp:ListItem Text="開放系統閱讀權限" Value="開放系統閱讀權限"></asp:ListItem>
                                <asp:ListItem Text="受控紙檔" Value="受控紙檔"></asp:ListItem>
                                <asp:ListItem Text="非受控紙檔" Value="非受控紙檔"></asp:ListItem>
                                <asp:ListItem Text="非受控/PDF檔" Value="非受控/PDF檔"></asp:ListItem>
                                <asp:ListItem Text="其它" Value="其它"></asp:ListItem>
                            </asp:DropDownList>
                            <div id="fenshu8" runat="server" class="cssnovisible">
                                X<asp:TextBox ID="TxtFenshu8" Width="50px" runat="server"></asp:TextBox>
                                份
                            </div>
                            <div id="shuoming8" runat="server" class="cssnovisible">
                                請說明<asp:TextBox ID="Txtshuoming8" runat="server"></asp:TextBox>
                            </div>
                        </td>
                        <td>
                            <asp:TextBox ID="TxtRemark8" runat="server"></asp:TextBox>
                            <img id="delete8" alt="刪除" src="../Images/Delete.gif" onclick="deletecur(8)" style="display: none" />
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
                            <asp:TextBox ID="txtFilename9" width="90%" runat="server" ReadOnly="true"></asp:TextBox>
                            <asp:HiddenField ID="HiddenFileName9" runat="server" />
                        </td>
                        <td>
                            <asp:DropDownList ID="DPLReadType9" onchange="ReadTypechange('DPLReadType9',9)" runat="server">
                                <asp:ListItem Text="電子原檔" Value="電子原檔"></asp:ListItem>
                                <asp:ListItem Text="開放系統閱讀權限" Value="開放系統閱讀權限"></asp:ListItem>
                                <asp:ListItem Text="受控紙檔" Value="受控紙檔"></asp:ListItem>
                                <asp:ListItem Text="非受控紙檔" Value="非受控紙檔"></asp:ListItem>
                                <asp:ListItem Text="非受控/PDF檔" Value="非受控/PDF檔"></asp:ListItem>
                                <asp:ListItem Text="其它" Value="其它"></asp:ListItem>
                            </asp:DropDownList>
                            <div id="fenshu9" runat="server" class="cssnovisible">
                                X<asp:TextBox ID="TxtFenshu9" Width="50px" runat="server"></asp:TextBox>
                                份
                            </div>
                            <div id="shuoming9" runat="server" class="cssnovisible">
                                請說明<asp:TextBox ID="Txtshuoming9" runat="server"></asp:TextBox>
                            </div>
                        </td>
                        <td>
                            <asp:TextBox ID="TxtRemark9" runat="server"></asp:TextBox>
                            <img id="delete9" alt="刪除" src="../Images/Delete.gif" onclick="deletecur(9)" style="display: none" />
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
                            <asp:TextBox ID="txtFilename10" width="90%" runat="server" ReadOnly="true"></asp:TextBox>
                            <asp:HiddenField ID="HiddenFileName10" runat="server" />
                        </td>
                        <td>
                            <asp:DropDownList ID="DPLReadType10" onchange="ReadTypechange('DPLReadType10',10)"
                                runat="server">
                                <asp:ListItem Text="電子原檔" Value="電子原檔"></asp:ListItem>
                                <asp:ListItem Text="開放系統閱讀權限" Value="開放系統閱讀權限"></asp:ListItem>
                                <asp:ListItem Text="受控紙檔" Value="受控紙檔"></asp:ListItem>
                                <asp:ListItem Text="非受控紙檔" Value="非受控紙檔"></asp:ListItem>
                                <asp:ListItem Text="非受控/PDF檔" Value="非受控/PDF檔"></asp:ListItem>
                                <asp:ListItem Text="其它" Value="其它"></asp:ListItem>
                            </asp:DropDownList>
                            <div id="fenshu10" runat="server" class="cssnovisible">
                                X<asp:TextBox ID="TxtFenshu10" Width="50px" runat="server"></asp:TextBox>
                                份
                            </div>
                            <div id="shuoming10" runat="server" class="cssnovisible">
                                請說明<asp:TextBox ID="Txtshuoming10" runat="server"></asp:TextBox>
                            </div>
                        </td>
                        <td>
                            <asp:TextBox ID="TxtRemark10" runat="server"></asp:TextBox>
                            <img id="delete10" alt="刪除" src="../Images/Delete.gif" onclick="deletecur(10)" style="display: none" />
                        </td>
                    </tr>
                </table>
                <div style="clear: both; height: 30px;">
                </div>
                <div id="cb" runat="server">
                    <table width="100%" border="1" cellspacing="0" cellpadding="0" bordercolor="#000000"
                        bordercolordark="#FFFFFF"">
                        <tr>
                            <td colspan="6" width="20%" bgcolor="#E4F1FA" height="50">
                                <asp:Image ID="Image3" runat="server" ImageUrl="~/Images/ico/applyinfo.png" />
                                <asp:Label ID="Label3" runat="server" Text="承辦單位填寫,僅限於品保文件類，質量負責人批准，品保承辦" Font-Bold="True"
                                    Font-Size="14px"></asp:Label>
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
                                <asp:TextBox ID="TxtcbRemark0" Enabled="False" runat="server" Width="80%"></asp:TextBox>
                            </td>
                        </tr>
                    </table>
                    <asp:Label ID="Label5" runat="server" Text="備註：文件/資料調用範圍僅適用於本中心內部，鑒於資訊管控原因不對外交流（第三方認可除外）"></asp:Label>
                </div>
                <div style="clear: both; height: 30px;">
                </div>
                <div>
                    <table width="100%" border="1" cellspacing="0" cellpadding="0" bordercolor="#000000"
                        bordercolordark="#FFFFFF"">
                        <tr>
                            <td bgcolor="#E4F1FA" height="50">
                                <asp:Image ID="Image4" runat="server" ImageUrl="~/Images/ico/history.png" />
                                <asp:Label ID="Label4" runat="server" Text="簽核歷史" Font-Bold="True" Font-Size="14px"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <uc2:ctlWFHistory ID="ctlWFHistory1" runat="server" />
                            </td>
                        </tr>
                    </table>
                    
                </div>
                <div style="display: none;">
                    <asp:HiddenField ID="hidExpenseCode" runat="server" Value="" />
                    <asp:HiddenField ID="hidfilnum" runat="server" Value="1" />
                    <asp:HiddenField ID="HidIsFlow" runat="server" Value="0" />
                </div>
                <div id="FileDialog" iconcls="icon-save" closed="true" title="請選擇文件" runat="server">
                    <div id="FileInfo" toolbar="#dlg-toolbar">
                    </div>
                    <div id="dlg-toolbar" style="display: none;">
                        <table cellpadding="0" cellspacing="0" style="width: 100%">
                            <tr>
                                <td style="width: 100%; text-align: right;" style="padding-left: 2px">
                                    <asp:Label ID="Label22" runat="server" Text=" "></asp:Label>
                                </td>
                                <td style="text-align: right; padding-right: 2px">
                                    <input class="easyui-searchbox" searcher="selectcustomer"></input>
                                </td>
                            </tr>
                        </table>
                    </div>
                </div>
            </td>
        </tr>
    </table>
    </form>
</body>
</html>
