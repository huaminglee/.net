<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="CustomerVisitDetail.aspx.vb"
    Inherits="CRM.CustomerVisitDetail" %>

<%@ Register Src="../EFlowNet/Doc/Modules/CtlWFActionList.ascx" TagName="CtlWFActionList"
    TagPrefix="uc1" %>
<%@ Register Src="../EFlowNet/Doc/Modules/ctlWFHistory.ascx" TagName="ctlWFHistory"
    TagPrefix="uc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../IconsThemes/icon.css" rel="Stylesheet" type="text/css" />
    <link href="../NewScript/themes/Default/easyui.css" rel="Stylesheet" type="text/css" />

    <script src="../NewScript/jquery-1.7.2.min.js" type="text/javascript"></script>

    <script type="text/javascript" src="../NewScript/plugins/jquery.bgiframe.js"></script>

    <script src="../NewScript/jquery.easyui.min.js" type="text/javascript"></script>

    <script type="text/javascript" src="../NewScript/plugins/jquery.toggleLoading.js"></script>

    <script type="text/javascript" src="../NewScript/datagrid-detailview.js"></script>

    <script type="text/javascript" src="../NewScript/datagrid-groupview.js"></script>

    <script src="../NewScript/My97DatePicker/WdatePicker.js" type="text/javascript"></script>

    <script src="CustomerVisits.js" type="text/javascript"></script>

    <style type="text/css">
        .txtbottline
        {
            border-top-style: none;
            border-right-style: none;
            border-left-style: none;
            border-bottom-style: solid;
            border-width: 1px;
        }
        </style>
</head>
<body>
    <form id="form1" runat="server">
    <div align="center" style="font-size: 20px">
        客戶拜訪/交際回饋表</div>
    <div>
        <uc1:CtlWFActionList ID="CtlWFActionList1" runat="server" />
         <asp:LinkButton ID="LinkExport" class="easyui-linkbutton" iconcls="icon-print"
                        runat="server">匯出</asp:LinkButton>
    </div>
    <div style="clear: both">
    </div>
    <div>
        <table width="100%">
            <tr>
                <td>
                    業務員：<asp:TextBox ID="TxtQuoter" runat="server" class="txtbottline"></asp:TextBox>
                </td>
                <td>
                    拜訪日期：<asp:TextBox ID="TxtVisitDate" runat="server" class="txtbottline"></asp:TextBox>
                </td>
                <td>
                    是否首次拜訪：<asp:RadioButtonList ID="RdoIsfirst" runat="server" 
                        RepeatDirection="Horizontal" RepeatLayout="Flow">
                        <asp:ListItem Value="1">是</asp:ListItem>
                        <asp:ListItem Selected="True" Value="0">否</asp:ListItem>
                    </asp:RadioButtonList>
                </td>
            </tr>
        </table>
    </div>
    <div>
        <table width="100%" border="1" cellpadding="0" cellspacing="0" bordercolordark="#FFFFFF"
            bordercolor="#000000">
            <tr>
                <td colspan="4" align="center" style="font-weight: bold; font-size: 14px">
                    公司基本信息
                </td>
            </tr>
            <tr>
                <td>
                    公司名稱
                </td>
                <td>
                    &nbsp;
                    <asp:TextBox ID="TxtCustomerName" runat="server" Width="308px"></asp:TextBox>
                    <asp:Label ID="LbCustomerName" runat="server" Text=""></asp:Label>
                </td>
                <td>
                    客戶來源
                </td>
                <td>
                    &nbsp;
                    <asp:TextBox ID="TxtCustomerSources" runat="server" Width="229px"></asp:TextBox>
                    <asp:Label ID="LbCustomerSources" runat="server" Text=""></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    公司規模 (人員、營業額等)
                </td>
                <td>
                    &nbsp;
                    <asp:TextBox ID="TxtCustomerScale" runat="server"></asp:TextBox>
                    <asp:Label ID="LbCustomerScale" runat="server" Text=""></asp:Label>
                </td>
                <td>
                    公司性質
                </td>
                <td>
                    &nbsp;
                    <asp:TextBox ID="TxtCustomerNature" runat="server"></asp:TextBox>
                    <asp:Label ID="LbCustomerNature" runat="server" Text=""></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    產品範圍
                </td>
                <td>
                    &nbsp;
                    <asp:TextBox ID="TxtProductRange" runat="server"></asp:TextBox>
                    <asp:Label ID="LbProductRange" runat="server" Text=""></asp:Label>
                </td>
                <td>
                    年委外測試金額
                </td>
                <td>
                    &nbsp;
                    <asp:TextBox ID="TxtTestAmountPerYeay" Text="0" class="easyui-numberbox" data-options="min:0,required:true,precision:2"  runat="server"></asp:TextBox>
                    <asp:Label ID="LbTestAmountPerYeay" runat="server" Text=""></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    現合作機構
                </td>
                <td>
                    &nbsp;
                    <asp:TextBox ID="TxtCooperationAgen" runat="server"></asp:TextBox>
                    <asp:Label ID="LbCooperationAgen" runat="server" Text=""></asp:Label>
                </td>
                <td>
                    付款方式
                </td>
                <td>
                    &nbsp;
                    <asp:DropDownList ID="DPLTypeofPay" runat="server"
                        Width="205px">
                        <asp:ListItem Value="1">預付款</asp:ListItem>
                        <asp:ListItem Value="2">月結</asp:ListItem>
                    </asp:DropDownList>
                    <asp:Label ID="LbTypeofPay" runat="server" Text=""></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    可合作項目
                </td>
                <td colspan="3">
                    &nbsp;
                    <asp:TextBox ID="TxtCooperationProj" runat="server" Width="500px"></asp:TextBox>
                    <asp:Label ID="LbtCooperationProj" runat="server" Text=""></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    公司地址
                </td>
                <td colspan="3">
                    &nbsp;
                    <asp:TextBox ID="TxtCustomerAddress" runat="server" Width="500px"></asp:TextBox>
                    <asp:Label ID="LbCustomerAddress" runat="server" Text=""></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    備註
                </td>
                <td colspan="3">
                    &nbsp;
                    <asp:TextBox ID="Txtremark" runat="server" Width="500px"></asp:TextBox>
                    <asp:Label ID="Lbremark" runat="server" Text=""></asp:Label>
                </td>
            </tr>
        </table>
    </div>
    <div style="clear: both; height: 30px;">
    </div>
    <div>
        <table width="100%" border="1" cellpadding="0" cellspacing="0" bordercolordark="#FFFFFF"
            bordercolor="#000000">
            <tr>
                <td align="center" style="font-weight: bold; font-size: 14px">
                    客戶基本信息
                </td>
            </tr>
            <tr>
                <td>
                    <div id="divsampleadd">
                        <table id="SampleTable" parent="1" fitcolumns="false" style="height: auto" singleselect="true"
                            idfield="SamplePKID">
                        </table>
                        <div id="SampleButtons" style="display: none;">
                            <a href="#" class="easyui-linkbutton" iconcls="icon-add" id="btnAdd" plain="true"
                                onclick="AddSample()">添加客戶</a> <a href="#" class="easyui-linkbutton" iconcls="icon-cut"
                                    disabled="true" id="btnDelete" plain="true" onclick="DeleteSample()">刪除客戶</a>
                            <a href="#" class="easyui-linkbutton" iconcls="icon-save" disabled="true" id="btnSave"
                                plain="true" onclick="SaveSample(0)">保存</a> <a href="#" class="easyui-linkbutton"
                                    iconcls="icon-undo" disabled="true" id="btnCancel" plain="true" onclick="CencelSample()">
                                    取消編輯</a>
                        </div>
                    </div>
                </td>
            </tr>
        </table>
    </div>
     <div style="clear: both; height: 30px;">
    </div>
    <div>
    
        <table width="100%" border="1" cellpadding="0" cellspacing="0" bordercolordark="#FFFFFF"
            bordercolor="#000000">
            <tr>
                <td colspan="2" align="center" style="font-weight: bold; font-size: 14px">
                    交談記錄</td>
            </tr>
            <tr>
                <td width="120px" >
                    交談事項</td>
                <td>
                    <asp:TextBox ID="TxtConversationmatters" runat="server" Height="112px" TextMode="MultiLine" 
                        Width="90%"></asp:TextBox>
                    <asp:Label ID="LbConversationmatters" runat="server" Text=""></asp:Label>
                </td>
            </tr>
            <tr>
                <td width="120px" >
                    結果</td>
                <td>
                    <asp:TextBox ID="TxtResult" runat="server" Height="112px" TextMode="MultiLine" 
                        Width="90%"></asp:TextBox>
                    <asp:Label ID="LbResult" runat="server" Text=""></asp:Label>
                </td>
            </tr>
            <tr>
                <td width="120px" >
                    待追蹤事項</td>
                <td>
                    <asp:TextBox ID="TxtMattertracked" runat="server" Height="112px" TextMode="MultiLine" 
                        Width="90%"></asp:TextBox>
                    <asp:Label ID="LbMattertracked" runat="server" Text=""></asp:Label>
                </td>
            </tr>
        </table>
    
    </div>
    <div style ="display :none ">
        <asp:HiddenField ID="HiddenCustomerPKID" Value ="0" runat="server" />
        <asp:HiddenField ID="HiddenCanAdd" Value ="True" runat="server" />
        <asp:HiddenField ID="HiddenPKID" Value ="0" runat="server" />
    </div>
    </form>
</body>
</html>
