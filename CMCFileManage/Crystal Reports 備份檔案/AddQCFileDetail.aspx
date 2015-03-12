<%@ Page Language="vb" AutoEventWireup="false" EnableEventValidation ="false"   Theme="Default" CodeBehind="AddQCFileDetail.aspx.vb"
    Inherits="CMCFileManage.AddQCFileDetail" %>

<%@ Register Src="../UCtl/UcFileDetail.ascx" TagName="UcFileDetail" TagPrefix="uc1" %>
<%@ Register Src="../EFlowNet/Doc/Modules/ctlWFHistory.ascx" TagName="ctlWFHistory"
    TagPrefix="uc2" %>
<%@ Register Src="../EFlowNet/Doc/Modules/CtlWFActionList.ascx" TagName="CtlWFActionList"
    TagPrefix="uc3" %>
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
            display: inline-table;
        }
    </style>
    <link href="../CSS/AddQCFileDetail.css" rel="stylesheet" type="text/css" />
    <link href="../IconsThemes/icon.css" rel="stylesheet" type="text/css" />
    <link href="../NewScript/themes/Default/easyui.css" rel="stylesheet" type="text/css" />

    <script src="../NewScript/jquery-1.7.2.min.js" type="text/javascript"></script>

    <script src="../NewScript/plugins/jquery.bgiframe.js" type="text/javascript"></script>

    <script src="../NewScript/jquery.easyui.min.js" type="text/javascript"></script>

    <script src="../NewScript/easyloader.js" type="text/javascript"></script>

    <script src="../NewScript/easyui-lang-zh_TW.js" type="text/javascript"></script>

    <script src="../NewScript/plugins/jquery.toggleLoading.js" type="text/javascript"></script>

    <script src="../NewScript/UIHelper.js" type="text/javascript"></script>

    <script src="../NewScript/My97DatePicker/WdatePicker.js" type="text/javascript"></script>

    <script src="AddQCfileShow.js" type="text/javascript"></script>

    <%--<script src="gobacktotop.js" type="text/javascript"></script>--%>
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div align="center">
        <asp:LinkButton ID="LinkFile" class="easyui-linkbutton" Visible="false" iconCls="icon-Manage"
            runat="server">文件電子檔</asp:LinkButton>
        <a href="javascript:void(0)" class="easyui-linkbutton" runat="server" iconcls="icon-print"
            onclick="doPrint()">紙檔列印</a>
        <uc3:CtlWFActionList ID="CtlWFActionList1" runat="server" />
    </div>
    <div style="clear: both">
    </div>
    <!--startprint-->
    <%-- <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>--%>
    <div style="font-size: 20px; color: #0066FF; font-family: 標楷體;" align="center">
        <asp:Label ID="LBtitle" runat="server" Text="文件新版發行通知單"></asp:Label>
    </div>
    <div style="height: 30px">
    </div>
    <div id="sqz" runat="server" align="center" style="width: 100%">
        <table width="100%">
            <tr>
                <td align="left">
                    文件變更號 :
                    <asp:Label ID="LbFileChangeNO" runat="server"></asp:Label>
                </td>
                <td>
                    <table>
                        <tr>
                            <td>
                                適用範圍
                            </td>
                            <td>
                                <asp:Repeater ID="Repeater1" runat="server">
                                    <ItemTemplate>
                                        <asp:CheckBox ID="CKBcq" Text='<%# DataBinder.Eval(Container.DataItem,"ParameterValue1") %> '
                                            runat="server" />
                                    </ItemTemplate>
                                    <AlternatingItemTemplate>
                                        <asp:CheckBox ID="CKBcq" Text='<%# DataBinder.Eval(Container.DataItem,"ParameterValue1") %> '
                                            runat="server" />
                                    </AlternatingItemTemplate>
                                </asp:Repeater>
                            </td>
                        </tr>
                    </table>
                </td>
                <td align="right">
                    生效日期:
                    <asp:Label ID="LbEffectDate" runat="server" Text=""></asp:Label>
                </td>
            </tr>
        </table>
    </div>
    <div id="tartx" align="center" style="width: 100%">
        <table width="100%" style="height: 500px" border="1" cellspacing="0" cellpadding="0"
            bordercolor="#000000" bordercolordark="#FFFFFF">
            <tr>
                <td rowspan="12" style="width: 70px" align="center">
                    <asp:Label ID="Label4" runat="server" Text="本欄由提案人填寫" Width="12px"></asp:Label>
                </td>
                <td>
                    提案單位:
                </td>
                <td align="left">
                    <asp:DropDownList ID="DPLApplyDepth" onchange="deptchange()" runat="server" 
                        Width="155px">
                    </asp:DropDownList>
                    <asp:Label ID="LbApplyDept" Style="display: none" runat="server" Text=""></asp:Label>
                    <asp:HiddenField ID="HidApplyDeptText" runat="server" Value="品保課" />
                    <asp:HiddenField ID="HidApplyDeptValue" runat="server" Value="0" />
                </td>
                <td width="16%">
                    提案人:
                </td>
                <td align="left">
                    <asp:TextBox ID="TxtApplyUser" runat="server"></asp:TextBox>
                    <asp:Label ID="LbApplyuser" Style="display: none" runat="server" Text=""></asp:Label>
                    <asp:HiddenField ID="HidApplyUser" runat="server" />
                </td>
                <td>
                    提案日期:
                </td>
                <td align="left">
                    <asp:TextBox ID="TxtApplyDate" runat="server"></asp:TextBox>
                    <asp:Label ID="LbApplyDate" Style="display: none" runat="server" Text=""></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    版次:
                </td>
                <td align="left">
                    <asp:TextBox ID="TxtFileVersion" Width="150px" runat="server"></asp:TextBox>
                    <asp:Label ID="LbFileVersion" Style="display: none" runat="server" Text=""></asp:Label>
                </td>
                <td>
                    總頁數:
                </td>
                <td align="left">
                    <asp:TextBox ID="TxtToTalPage" Text="0" class="easyui-numberbox" data-options="min:0,max:1000,required:true,precision:0"
                        runat="server"></asp:TextBox>
                    <asp:Label ID="LbTotalPage" Style="display: none" runat="server" Text=""></asp:Label>
                </td>
                <td>
                    文件名稱:
                </td>
                <td align="left">
                    <asp:TextBox ID="TxtFileName" runat="server"></asp:TextBox>
                    <asp:HiddenField ID="HIDFilename" runat="server" />
                    <asp:Label ID="LbFileName" Style="display: none" runat="server" Text=""></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    文件階層:
                </td>
                <td align="left">
                    <asp:DropDownList ID="DPLFileLayer" Width="155px" onchange="dpllayerchange()" runat="server" AutoPostBack="false">
                        <asp:ListItem>QM</asp:ListItem>
                        <asp:ListItem>QP</asp:ListItem>
                        <asp:ListItem>WI</asp:ListItem>
                        <asp:ListItem>QF</asp:ListItem>
                    </asp:DropDownList>
                    
                    <asp:HiddenField ID="HidFileLayer" runat="server" Value="QM" />
                    <asp:Label ID="LbFileLayer" Style="display: none" runat="server" Text=""></asp:Label>
                </td>
                <td>
                    <asp:Label ID="Lbfilecate" runat="server" Text="文件類別:" class="cssnovisible"></asp:Label>
                    &nbsp;
                </td>
                <td align="left">
                    <asp:DropDownList ID="DPLFileCategory" runat="server" onchange="filecategorychange()"
                        class="cssnovisible" AutoPostBack="false">
                        <asp:ListItem Value="1">校準程序</asp:ListItem>
                        <asp:ListItem Value="2">操作規範</asp:ListItem>
                        <asp:ListItem Value="3">作業規範</asp:ListItem>
                        <asp:ListItem Value="4">管理要求</asp:ListItem>
                        <asp:ListItem Value="5">技術要求</asp:ListItem>
                        <asp:ListItem Value="6">其他</asp:ListItem>
                        <asp:ListItem Selected="True"> </asp:ListItem>
                    </asp:DropDownList>
                    <asp:HiddenField ID="HidFileCategoryText" runat="server" Value="" />
                    <asp:HiddenField ID="HidFileCategoryValue" runat="server" Value="" />
                    <asp:Label ID="LbFileCategory" Style="display: none" runat="server" Text=""></asp:Label>
                    &nbsp;
                </td>
                <td>
                    <asp:Label ID="LbIso" runat="server" Text="ISO條款:" class="cssnovisible"></asp:Label>
                    &nbsp;
                </td>
                <td align="left">
                    <asp:DropDownList ID="DPLiso" runat="server" onchange="isochange()" AutoPostBack="false"
                        class="cssnovisible">
                        <asp:ListItem>401</asp:ListItem>
                        <asp:ListItem>402</asp:ListItem>
                        <asp:ListItem>403</asp:ListItem>
                        <asp:ListItem>404</asp:ListItem>
                        <asp:ListItem>405</asp:ListItem>
                        <asp:ListItem>406</asp:ListItem>
                        <asp:ListItem>407</asp:ListItem>
                        <asp:ListItem>408</asp:ListItem>
                        <asp:ListItem>409</asp:ListItem>
                        <asp:ListItem>410</asp:ListItem>
                        <asp:ListItem>501</asp:ListItem>
                        <asp:ListItem>502</asp:ListItem>
                        <asp:ListItem>503</asp:ListItem>
                        <asp:ListItem>504</asp:ListItem>
                        <asp:ListItem>505</asp:ListItem>
                        <asp:ListItem>506</asp:ListItem>
                        <asp:ListItem>507</asp:ListItem>
                        <asp:ListItem>508</asp:ListItem>
                        <asp:ListItem>509</asp:ListItem>
                        <asp:ListItem>510</asp:ListItem>
                        <asp:ListItem Selected="True"> </asp:ListItem>
                    </asp:DropDownList>
                    <asp:HiddenField ID="HidISO" runat="server" Value="" />
                    <asp:Label ID="LbIsovalue" Style="display: none" runat="server" Text=""></asp:Label>
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td>
                    文件編號:
                </td>
                <td align="left">
                    <asp:TextBox ID="LBFileNo" Width="150px" runat="server"></asp:TextBox>
                    <asp:Label ID="LbFileNOvalue" Style="display: none" runat="server" Text=""></asp:Label>
                    <asp:HiddenField ID="HidFileBH" runat="server" />
                    &nbsp;
                </td>
                <td>
                    變更原因:
                </td>
                <td align="left" colspan="3">
                    <asp:TextBox ID="TxtChangeReason" runat="server"></asp:TextBox>
                    <asp:Label ID="LbChangeReason" Style="display: none" runat="server" Text=""></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    變更前說明:
                </td>
                <td align="left" colspan="2">
                    <asp:TextBox ID="TxtChangePreDes" runat="server" TextMode="MultiLine"></asp:TextBox>
                    <asp:Label ID="LbChangePreDes" Style="display: none" runat="server" Text=""></asp:Label>
                </td>
                <td>
                    變更后說明:
                </td>
                <td align="left" colspan="2">
                    <asp:TextBox ID="TxtChangeBehDes" runat="server" TextMode="MultiLine"></asp:TextBox>
                    <asp:Label ID="LbChangeBehDes" Style="display: none" runat="server" Text=""></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    實驗室技術負責人:
                </td>
                <td colspan="5" align="left">
                    <asp:DropDownList ID="DPLLabTechniqueCharge" onchange="LabTechniqueChargeCHANGE()"
                        runat="server">
                    </asp:DropDownList>
                    <asp:HiddenField ID="HidLabTechniqueCharge" runat="server" />
                    <asp:Label ID="LbLabTechniqueCharge" Style="display: none" runat="server" Text=""></asp:Label>
                </td>
            </tr>
            <tr>
                <td align="left" colspan="6">
                    會簽方式：
                </td>
            </tr>
            <tr>
                <td align="left" colspan="2" width="31%">
                    <asp:CheckBox ID="CHBPaper" onclick="huiqianchange('CHBPaper','shumianjilu')" runat="server"
                        Text="書面會簽" />
                    <div id="shumianjilu" runat="server" class="cssnovisible" style="float: right">
                        <uc1:UcFileDetail ID="UcFileDetail4" runat="server" />
                    </div>
                </td>
                <td align="left" width="31%" colspan="2">
                    <asp:CheckBox ID="CKBMeeting" onclick="huiqianchange('CKBMeeting','huiyijilu')" runat="server"
                        Text="會議研討" />
                    <div id="huiyijilu" runat="server" class="cssnovisible" style="float: right">
                        <uc1:UcFileDetail ID="UcFileDetail5" class="cssnovisible" runat="server" />
                    </div>
                </td>
                <td align="left" width="31%" colspan="2">
                    <asp:CheckBox ID="CHBNone" runat="server" Text="無需會簽" />
                </td>
            </tr>
            <tr>
                <td align="left" colspan="3">
                    <div style="float: left">
                        <asp:Label ID="LBFF1" runat="server" Text="分發單位:"></asp:Label></div>
                    <div style="float: right;" align="left">
                        <asp:Label ID="LBZD1" runat="server" Text="發行紙檔份數"></asp:Label></div>
                </td>
                <td align="left" colspan="3">
                    <div style="float: left">
                        <asp:Label ID="LBFF2" runat="server" Text="分發單位:"></asp:Label></div>
                    <div style="float: right;" align="left">
                        <asp:Label ID="LBZD2" runat="server" Text="發行紙檔份數"></asp:Label></div>
                </td>
            </tr>
            <tr>
                <td colspan="6" valign="top">
                    <asp:HiddenField ID="Hidfenfadanwei" runat="server" Value="0" />
                    <table width="100%">
                        <asp:Repeater ID="Repeater2" runat="server">
                            <ItemTemplate>
                                <td align="left" width="50%">
                                    <asp:CheckBox ID="CHBdept" onclick="checkchange(this)" Text='<%# DataBinder.Eval(Container.DataItem,"ParameterText") %> '
                                        runat="server" />
                                    <div id="divzdnums" runat="server" style="float: right" class="cssnovisible">
                                        <asp:TextBox ID="TxtzdNums" Width="20px" class="easyui-numberbox" data-options="min:0,max:100,required:true,precision:0"
                                            Text="0" runat="server"></asp:TextBox>
                                    </div>
                                </td>
                            </ItemTemplate>
                        </asp:Repeater>
                    </table>
                </td>
            </tr>
            <tr>
                <td>
                    是否教育訓練:
                </td>
                <td align="left">
                    <asp:RadioButtonList ID="RdBIsTeach" onclick="isteachchange()" runat="server" RepeatDirection="Horizontal">
                        <asp:ListItem Value="1">是</asp:ListItem>
                        <asp:ListItem Value="0" Selected="True">否</asp:ListItem>
                    </asp:RadioButtonList>
                    <asp:HiddenField ID="HidIsteach" runat="server" Value="0" />
                </td>
                <td class="style11">
                    負責訓練單位:
                </td>
                <td align="left">
                    <asp:TextBox ID="TxtTeachDept" Width="100px" runat="server" class="cssnovisible"></asp:TextBox>
                    &nbsp;
                </td>
                <td align="center">
                    共發行紙檔文件份數:
                </td>
                <td align="left">
                    <asp:TextBox ID="LbPaperNum" runat="server"></asp:TextBox>
                    <asp:Label ID="LbPaperNumValue" Style="display: none" runat="server" Text=""></asp:Label>
                    &nbsp;
                </td>
            </tr>
            <tr id="print2">
                <td>
                    上傳文件（World/Excel）
                </td>
                <td align="left" colspan="5">
                    <uc1:UcFileDetail ID="UcFileDetail1" runat="server" CanDownLoad="True" CanRemove="True" />
                </td>
            </tr>
        </table>
    </div>
    <div id="kg1" style="height: 30px">
    </div>
    <div id="pb1" runat="server" align="center" style="width: 100%">
        <table width="100%" border="1" cellspacing="0" cellpadding="0" bordercolor="#000000"
            bordercolordark="#FFFFFF" style="height: 50px">
            <tr>
                <td rowspan="2" style="width: 63px" align="center">
                    <asp:Label ID="Label3" runat="server" Text="核定" Width="12px"></asp:Label>
                </td>
                <td style="width: 182px">
                    中心技術負責人
                </td>
                <td align="left" style="width: 303px">
                    &nbsp;&nbsp;
                    <asp:Image ID="ImgCenterTechniqueCharge" runat="server" Height="30px" Visible="False"
                        Width="80px" />
                </td>
                <td style="width: 150px">
                    中心質量負責人
                </td>
                <td align="left" style="width: 325px">
                    &nbsp;&nbsp;
                    <asp:Image ID="ImgCenterQuantityCharge" runat="server" Height="30px" Visible="False"
                        Width="80px" />
                </td>
            </tr>
            <tr>
                <td>
                    最高管理者核定
                </td>
                <td align="left" colspan="3">
                    &nbsp;&nbsp;
                    <asp:Image ID="ImgHighManager" runat="server" Height="30px" Visible="False" Width="80px" />
                </td>
            </tr>
            <tr id="fd1">
                <td>
                    附檔
                </td>
                <td>
                    PDF檔
                </td>
                <td align="left">
                    &nbsp;
                    <uc1:UcFileDetail ID="UcFileDetail3" runat="server" />
                </td>
                <td>
                    品保結案
                </td>
                <td align="left">
                    <asp:Label ID="lbQualityFinishUser" runat="server"></asp:Label>
                    &nbsp;
                </td>
            </tr>
        </table>
    </div>
    <div id="kg2" style="clear: both; height: 30px;">
    </div>
    <div id="hs" runat="server" style="width: 100%; display: none">
        <table width="100%" border="1" cellspacing="0" cellpadding="0" bordercolor="#000000"
            bordercolordark="#FFFFFF">
            <tr>
                <td rowspan="2" style="width: 63px" align="center">
                    <asp:Label ID="Label1" runat="server" Text="本欄由品保填寫" Width="12px"></asp:Label>
                </td>
                <td style="width: 480px">
                    <div style="float: left">
                        回收單位:</div>
                    <div style="float: right;" align="left">
                        回收紙檔份數</div>
                </td>
                <td style="width: 480px">
                    <div style="float: left">
                        回收單位:</div>
                    <div style="float: right;" align="left">
                        回收紙檔份數</div>
                </td>
            </tr>
            <tr>
                <td valign="top" colspan="2">
                    <table width="100%">
                        <asp:HiddenField ID="Hidhuishoudanwei" runat="server" Value="0" />
                        <asp:Repeater ID="Repeater3" runat="server">
                            <ItemTemplate>
                                <td align="left" width="50%">
                                    <asp:CheckBox ID="CHBdept" onclick="hscheckchange(this)" Text='<%# DataBinder.Eval(Container.DataItem,"ParameterText") %> '
                                        runat="server" />
                                    <div id="divzdnums" runat="server" style="float: right" class="cssnovisible">
                                        <asp:TextBox ID="TxtzdNums" Width="20px" class="easyui-numberbox" data-options="min:0,max:100,required:true,precision:0"
                                            Text="0" runat="server"></asp:TextBox>
                                    </div>
                                </td>
                            </ItemTemplate>
                        </asp:Repeater>
                    </table>
                </td>
            </tr>
        </table>
    </div>
    <%--</ContentTemplate>
        </asp:UpdatePanel>--%>
    <!--endprint-->
    <div style="height: 30px; width: 100%">
    </div>
    <div align="center" style="width: 100%">
        <uc2:ctlWFHistory ID="ctlWFHistory1" runat="server" />
    </div>
    <div style="display: none">
        <asp:HiddenField ID="Hiddenischange" Value="0" runat="server" />
        <asp:HiddenField ID="HidIsNewDoc" runat="server" Value="0" />
        <asp:HiddenField ID="Image1" runat="server" Value="1" />
        <asp:HiddenField ID="Image2" runat="server" Value="1" />
        <asp:HiddenField ID="Image3" runat="server" Value="1" />
        <asp:HiddenField ID="HidRecordType" runat="server" Value="1" />
        <asp:HiddenField ID="HidisConfirm" runat="server" Value="1" />
        <asp:HiddenField ID="HidApplyPKID" runat="server" Value="0" />
    </div>
    </form>
</body>
</html>
