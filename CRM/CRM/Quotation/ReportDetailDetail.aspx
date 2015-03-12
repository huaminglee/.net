<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="ReportDetailDetail.aspx.vb"
    Inherits="CRM.ReportDetailDetail" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<%@ Register Src="../EFlowNet/Doc/Modules/CtlWFActionList.ascx" TagName="CtlWFActionList"
    TagPrefix="uc1" %>
<%@ Register Src="../EFlowNet/Doc/Modules/ctlWFHistory.ascx" TagName="ctlWFHistory"
    TagPrefix="uc2" %>
<%@ Register Src="../UCtl/UcFileDetail.ascx" TagName="UcFileDetail" TagPrefix="uc3" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../IconsThemes/icon.css" rel="Stylesheet" type="text/css" />
    <link href="../NewScript/themes/Default/easyui.css" rel="Stylesheet" type="text/css" />

    <script src="../NewScript/jquery-1.7.2.min.js" type="text/javascript"></script>

    <script src="../NewScript/jquery.easyui.min.js" type="text/javascript"></script>

    <script src="../NewScript/plugins/jquery.bgiframe.js" type="text/javascript"></script>

    <script type="text/javascript" src="../NewScript/datagrid-detailview.js"></script>

    <script type="text/javascript" src="../NewScript/datagrid-groupview.js"></script>

    <script type="text/javascript" src="../NewScript/uploadScript/swfobject.js"></script>

    <script type="text/javascript" src="../NewScript/uploadScript/jquery.uploadify.min.js"></script>

    <script src="../NewScript/plugins/jquery.toggleLoading.js" type="text/javascript"></script>

    <script src="Report.js" type="text/javascript"></script>

    <script language="javascript" type="text/javascript">
        function showinvolid() {
            var DetailPKID = document.getElementById("HiddenReportDetailPKID").value;
            var QuotationPKID = document.getElementById("HiddenQuotationPKID").value;
            window.open('/CRM/Quotation/QuotationInvoid.aspx?DetailPKID=' + DetailPKID + '&QuotationPKID=' + QuotationPKID,
		'popupcal',
		'width=320,height=190,left=400,top=380');
        }
        function thisclose() {
            document.getElementById('Button1').click();
        }
        function tecsupportchange() {
            var ddl = document.getElementById("DPLtecsupport");
            var index = document.getElementById("DPLtecsupport").selectedIndex;
            if (index != -1) {
                document.getElementById("HiddenTecSupport").value = ddl.options[index].value;

            }

        }
           
    </script>
    <style type="text/css">
        UL
        {
            clear: both;
            padding-right: 0px;
            padding-left: 0px;
            padding-bottom: 0px;
            margin: 0px;
            list-style-type: none;
            padding-top: 2px;
        }
        LI
        {
            padding-right: 0px;
            display: block;
            padding-left: 0px;
            float: left;
            padding-bottom: 0px;
            margin: 0px;
            line-height: 20px;
            padding-top: 0px;
            height: auto;
        }
    </style>

</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div>
        <table width="100%">
            <tr>
                <td width="80%">
                    <uc1:CtlWFActionList ID="CtlWFActionList1" runat="server" />
                </td>
                <td>
                    <asp:LinkButton ID="LinkDirect" Visible="false" class="easyui-linkbutton" iconcls="icon-ok"
                        runat="server">測試已完成</asp:LinkButton>
                    <asp:LinkButton ID="LinkSendsample" Visible="false" class="easyui-linkbutton" iconcls="icon-Approve"
                        runat="server">已寄樣品</asp:LinkButton>
                    <asp:LinkButton ID="LinkDoinvoice" Visible="false" class="easyui-linkbutton" iconcls="icon-Approve"
                        runat="server">已開發票</asp:LinkButton>
                    <asp:LinkButton ID="LinkSendinvoice" Visible="false" class="easyui-linkbutton" iconcls="icon-Approve"
                        runat="server">已寄發票</asp:LinkButton>
                    <asp:LinkButton ID="LinkQuotation" class="easyui-linkbutton" iconcls="icon-Approve"
                        runat="server">對應報價單</asp:LinkButton>
                    <a id="quoinvalid" runat="server" visible="false" onclick="showinvolid()" class="easyui-linkbutton"
                        iconcls="icon-cancel">測試異常處理</a>
                </td>
            </tr>
        </table>
    </div>
    <div style="clear: both">
    </div>
    <div id="DivQuotationInfo">
        <table width="100%" border="1" cellpadding="0" cellspacing="0" bordercolordark="#FFFFFF"
            bordercolor="#999999">
            <tr>
                <td colspan="8" bgcolor="#E6E6E6" height="50" align="left" valign="middle">
                    <asp:Image ID="Image1" runat="server" Style="vertical-align: middle" ImageUrl="~/Images/ico/baseinfo.png" />
                    <asp:Label ID="Label8" runat="server" Text="報價單基本信息" Font-Bold="True" Font-Size="14px"></asp:Label>
                    &nbsp;&nbsp;&nbsp;&nbsp; 技術客服：<asp:Label ID="LbTecSupport" runat="server" Text=""></asp:Label>
                    <asp:DropDownList ID="DPLtecsupport" Visible="false" onchange="tecsupportchange()"
                        runat="server">
                    </asp:DropDownList>
                    <asp:Button ID="BtnUptec" runat="server" Visible="false" Text="更新技術客服并發郵件" />
                    <asp:Label ID="LBinfo" runat="server" Text=""></asp:Label>
                    <asp:Label ID="LbIsSendMail" runat="server" Visible="false" Text="是否郵件通知客戶"></asp:Label>
                    <asp:RadioButtonList ID="RdoInsendmail" runat="server" Visible="false" RepeatDirection="Horizontal"
                        RepeatLayout="Flow">
                        <asp:ListItem Selected="True" Value="1">通知</asp:ListItem>
                        <asp:ListItem Value="0">不通知</asp:ListItem>
                    </asp:RadioButtonList>
                    <asp:HiddenField ID="HiddenTecSupport" runat="server" />
                </td>
            </tr>
            <tr>
                <td>
                    報價單號
                </td>
                <td style="margin-left: 40px">
                    <asp:Label ID="LbQuotationNO" runat="server" Text=""></asp:Label>
                </td>
                <td>
                    測試類型
                </td>
                <td>
                    <asp:Label ID="LbTestCategory" runat="server" Text=""></asp:Label>
                    <asp:HiddenField ID="HiddenTestCategory" runat="server" />
                </td>
                <td colspan="4">
                    &nbsp;<%-- <asp:DataList ID="DataList1" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow">
                        <ItemTemplate>
                            <asp:LinkButton ID="LinkButton1" runat="server" Text='<%#Container.DataItem%>'></asp:LinkButton>
                            &nbsp;
                        </ItemTemplate>
                    </asp:DataList>--%>
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td>
                    報價人
                </td>
                <td>
                    <asp:Label ID="LbQuoterName" runat="server" Text=""></asp:Label>
                    <asp:HiddenField ID="HiddenQuoterPKID" Value="0" runat="server" />
                </td>
                <td>
                    報價日期
                </td>
                <td>
                    <asp:Label ID="LbQuoterDate" runat="server" Text=""></asp:Label>
                </td>
                <td>
                    電話
                </td>
                <td>
                    <asp:Label ID="LbQuotaterPhone" runat="server" Text=""></asp:Label>
                </td>
                <td>
                    Email
                </td>
                <td>
                    <asp:Label ID="LbQuotaterEmail" runat="server" Text=""></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    公司名稱
                </td>
                <td>
                    <asp:Label ID="LbCustomerName" runat="server" Text=""></asp:Label>
                </td>
                <td>
                    聯繫人
                </td>
                <td>
                    <asp:Label ID="LbContactName" runat="server" Text=""></asp:Label>
                    <asp:HiddenField ID="HiddenContactID" runat="server" />
                </td>
                <td>
                    電話
                </td>
                <td>
                    <asp:Label ID="ContactPhone" runat="server" Text=""></asp:Label>
                </td>
                <td>
                    Email
                </td>
                <td>
                    <asp:Label ID="LbContactEmail" runat="server" Text=""></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    客戶等級
                </td>
                <td>
                    <asp:Label ID="LbCustomerGrade" runat="server"></asp:Label>
                </td>
                <td>
                    付款方式
                </td>
                <td>
                    <asp:Label ID="LbTypeOfPay" runat="server"></asp:Label>
                    <asp:HiddenField ID="HiddenTypeofPay" runat="server" />
                </td>
                <td>
                    測試歷史
                </td>
                <td>
                    <asp:Label ID="LbCusHistory" runat="server"></asp:Label>
                </td>
                <td>
                    樣品取回
                </td>
                <td>
                    <asp:Label ID="LbIsback" runat="server" Text=""></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    期望完成日期
                </td>
                <td>
                    <asp:Label ID="LbHopefinishdate" runat="server" Text=""></asp:Label>
                </td>
                <td>
                    <asp:Label ID="LbPajiashow" runat="server" Text="牌價"></asp:Label>
                    &nbsp;
                </td>
                <td>
                    <asp:Label ID="LbPaijia" runat="server" Text=""></asp:Label>
                    &nbsp;
                </td>
                <td>
                    當前報價
                </td>
                <td>
                    <asp:Label ID="LbShijibaojia" runat="server" Text=""></asp:Label>
                </td>
                <td>
                    <asp:Label ID="Label3" runat="server" Text="應收金額"></asp:Label>
                    &nbsp;
                </td>
                <td>
                    <asp:Label ID="LbYinshoumoney" runat="server"></asp:Label>
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td>
                    郵寄地址
                </td>
                <td>
                    <asp:Label ID="LbCustomerAddress" runat="server" Text=""></asp:Label>
                    &nbsp;
                </td>
                <td>
                    寄樣品時間
                </td>
                <td>
                    <asp:Label ID="LbSendSampleDate" runat="server" Text=""></asp:Label>
                </td>
                <td>
                    開發票時間
                </td>
                <td>
                    <asp:Label ID="LbDOinvoiceDate" runat="server" Text=""></asp:Label>
                </td>
                <td>
                    寄發票時間
                </td>
                <td>
                    <asp:Label ID="LbSendInvoicedate" runat="server" Text=""></asp:Label>
                </td>
            </tr>
        </table>
    </div>
    <div style="clear: both">
    </div>
    <br />
    <div id="DivTestApplyinfo" runat="server">
        <table width="100%" border="1" cellpadding="0" cellspacing="0" bordercolordark="#FFFFFF"
            bordercolor="#999999">
            <tr>
                <td bgcolor="#E6E6E6" height="50">
                    <asp:Image ID="Image8" runat="server" Style="vertical-align: middle" ImageUrl="../Images/ico/applyinfo.png" />
                    <asp:Label ID="Label2" runat="server" Text="申 請 單 列 表" Font-Bold="True" Font-Size="14px"></asp:Label>
                </td>
            </tr>
            <tr id="TestApplyInfo" runat="server">
                <td>
                    <div>
                        <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" Width="100%">
                            <Columns>
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <asp:Label ID="lbPKID" runat="server" Text='<%# DataBinder.Eval(Container,"DataItem.ApplyPKID").ToString() %>'
                                            Visible="False"></asp:Label>
                                        <asp:Label ID="lblDocUniqueID" runat="server" Text='<%# DataBinder.Eval(Container,"DataItem.eFlowDocID").ToString() %>'
                                            Visible="False"></asp:Label>
                                        <asp:HyperLink ID="HLDetail" Target="_self" runat="server" ToolTip="編輯" ImageUrl="../Images/ico/pen.png">查看</asp:HyperLink>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField HeaderText="當前狀態" DataField="當前狀態" HeaderStyle-HorizontalAlign="Left" />
                                <asp:BoundField DataField="SampleS" HeaderText="樣品名稱" HeaderStyle-HorizontalAlign="Left" />
                                <asp:BoundField DataField="TestNO" HeaderText="申請單號" HeaderStyle-HorizontalAlign="Left" />
                                <asp:BoundField DataField="LaboratoryServices" HeaderText="服務類別" HeaderStyle-HorizontalAlign="Left" />
                                <asp:BoundField DataField="TestItems" HeaderText="測試項目" HeaderStyle-HorizontalAlign="Left" />
                            </Columns>
                        </asp:GridView>
                    </div>
                </td>
            </tr>
        </table>
    </div>
    <br />
    <div id="DivTestApplyNo" runat="server">
        <table id="tabletestno" width="100%" border="1" cellpadding="0" cellspacing="0" bordercolordark="#FFFFFF"
            bordercolor="#999999">
            <tr>
                <td bgcolor="#E6E6E6" height="50" width="48%">
                    <asp:Image ID="Image7" runat="server" Style="vertical-align: middle" ImageUrl="~/Images/ico/testbh.png" />
                    <asp:Label ID="Label4" runat="server" Text="填寫測試編號" Font-Bold="True" Font-Size="14px"></asp:Label>
                    <asp:Button ID="BtnUpTestNO" Visible="false" runat="server" Text="更新測試編號" />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Repeater ID="Repeater1" runat="server">
                        <ItemTemplate>
                            <table>
                                <tr>
                                    <td>
                                        <asp:Label ID="LbServiceType" runat="server" Text="服務類別: "></asp:Label>
                                        <asp:Label ID="LbTestItem" Width="100px" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"ServiceType") %>'></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="Label10" runat="server" Text="測試編號: "></asp:Label>
                                        <asp:TextBox ID="TxtTestNo" runat="server" name="testno" Text='<%# DataBinder.Eval(Container.DataItem,"Extend07") %>'></asp:TextBox>
                                    </td>
                                </tr>
                            </table>
                        </ItemTemplate>
                        <AlternatingItemTemplate>
                            <table>
                                <tr>
                                    <td>
                                        <asp:Label ID="LbServiceType" runat="server" Text="服務類別: "></asp:Label>
                                        <%-- <asp:Label ID="LbItempkid" runat="server" Visible="false" Text='<%# DataBinder.Eval(Container.DataItem,"PKID") %>'></asp:Label>--%>
                                        <asp:Label ID="LbTestItem" Width="100px" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"ServiceType") %>'></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="Label10" runat="server" Text="測試編號: "></asp:Label>
                                        <asp:TextBox ID="TxtTestNo" runat="server" name="testno" Text='<%# DataBinder.Eval(Container.DataItem,"Extend07") %>'></asp:TextBox>
                                    </td>
                                </tr>
                            </table>
                        </AlternatingItemTemplate>
                    </asp:Repeater>
                    &nbsp;
                </td>
            </tr>
        </table>
    </div>
    <div id="quotestremark">
        <table width="100%" border="1" cellpadding="0" cellspacing="0" bordercolordark="#FFFFFF"
            bordercolor="#999999">
            <tr>
                <td colspan="3" bgcolor="#E6E6E6">
                    <asp:Image ID="Image9" runat="server" Style="vertical-align: middle" ImageUrl="~/Images/ico/tip.png" />
                    <asp:Label ID="Label11" runat="server" Text="測試要求及說明" Font-Bold="True" Font-Size="14px"></asp:Label>
                </td>
            </tr>
            <tr>
                <td width="40%">
                    <asp:TextBox ID="TxtTestRemark" runat="server" Height="50px" TextMode="MultiLine"
                        Width="366px"></asp:TextBox>
                </td>
                <td width="30%" valign="top">
                    修改記錄：<br />
                    <asp:Label ID="LbTestremarkchage" runat="server" Text=""></asp:Label>
                </td>
                <td>
                    <uc3:UcFileDetail ID="UcFileDetail1" runat="server" />
                </td>
            </tr>
        </table>
    </div>
   <div id="div1" runat="server">
        <table width="100%" border="1" cellpadding="0" cellspacing="0" bordercolordark="#FFFFFF"
            bordercolor="#999999">
            <tr>
                <td bgcolor="#E6E6E6" height="50" width="50%" style="width: 100%">
                    <asp:Image ID="Image2" runat="server" Style="vertical-align: middle" ImageUrl="~/Images/ico/report.png" />
                    <asp:Label ID="Label5" runat="server" Text="報告信息" Font-Bold="True" Font-Size="14px"></asp:Label>
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td>
                    <div title="附件信息" id="FileTab" iconcls="icon-save" style="padding: 10px;">
                        <table id="Filetable">
                        </table>
                        <div id="fileQueue">
                        </div>
                        <div id="DivFileDesc" style="display: none">
                            <ul>
                                <li>文件描述</li>
                                <li style="width: 400px">
                                    <input id="TxtFileDesc" style="width: 400px" type="text" /></li>
                            </ul>
                        </div>
                    </div>
                    <div id="FileButtons" style="display: none">
                        <ul>
                            <li>
                                <input type="file" name="File1" id="FileInfo" />
                            </li>
                            <li><a href="#" class="easyui-linkbutton" iconcls="icon-upload" disabled="true" id="BtnFileUpload"
                                style="top: 10px" onclick="UploadFile();">上傳</a> <a href="#" class="easyui-linkbutton"
                                    iconcls="icon-download" onclick="Download('Filetable');">下載</a> <a href="#" class="easyui-linkbutton"
                                        id="BtnFileDelete" disabled="true" iconcls="icon-cut" onclick="DeleteFile();">Delete</a>
                            </li>
                        </ul>
                    </div>
                    <div id="FileButtonsDoenload" style="display: none">
                        <a href="#" class="easyui-linkbutton" iconcls="icon-download" onclick="Download('Filetable');">
                            下載</a>
                    </div>
                    <%-- <uc3:UcFileDetail ID="UcFileDetail5" runat="server" />--%>
                    &nbsp;
                </td>
            </tr>
        </table>
    </div>
    <div>
    
        <table width="100%" border="1" cellpadding="0" cellspacing="0" bordercolordark="#FFFFFF"
            bordercolor="#999999">
            <tr>
                <td bgcolor="#E6E6E6" height="50" width="50%">
                     <asp:Image ID="Image3" runat="server" Style="vertical-align: middle" ImageUrl="~/Images/ico/pay.png" />
                    <asp:Label ID="Label6" runat="server" Text="付款憑證" Font-Bold="True" Font-Size="14px"></asp:Label></td>
            </tr>
            <tr>
                <td>
                     <uc3:UcFileDetail ID="UcFileDetail2" runat="server" /></td>
            </tr>
        </table>
    
    </div>
    <div id="div2" runat="server">
        <table width="100%" border="1" cellpadding="0" cellspacing="0" bordercolordark="#FFFFFF"
            bordercolor="#999999">
            <tr>
                <td bgcolor="#E6E6E6" height="50" style="width: 99%">
                    &nbsp;
                    <asp:Image ID="Image5" runat="server" Style="vertical-align: middle" ImageUrl="~/Images/ico/topdf.png" />
                    <asp:Label ID="Label9" runat="server" Text="客戶回傳的報價單" Font-Bold="True" Font-Size="14px"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;
                    <asp:Label ID="LbCushui" runat="server" Text=""></asp:Label>
                    <uc3:UcFileDetail ID="UcFileDetail4" runat="server" />
                </td>
            </tr>
        </table>
    </div>
    <br />
    <div style="clear: both">
    </div>
    <div id="div3" runat="server">
        <table width="100%" border="1" cellpadding="0" cellspacing="0" bordercolordark="#FFFFFF"
            bordercolor="#999999">
            <tr>
                <td bgcolor="#E6E6E6" height="50">
                    <asp:Image ID="Image6" runat="server" Style="vertical-align: middle" ImageUrl="~/Images/ico/history.png" />
                    <asp:Label ID="Label1" runat="server" Text="簽核歷史" Font-Bold="True" Font-Size="14px"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <uc2:ctlWFHistory ID="ctlWFHistory1" runat="server" />
                </td>
            </tr>
        </table>
    </div>
    <div style="display: none">
        <asp:Button ID="Button1" runat="server" Text="Button" Style="height: 21px" />
        <asp:HiddenField ID="HiddenReportDetailPKID" Value="0" runat="server" />
        <asp:HiddenField ID="HiddenQuotationPKID" Value="0" runat="server" />
        <asp:ImageButton ID="ImageTestDown" OnInit="BtnDownLoadInit" OnClientClick="return true;"
            ImageUrl="~/Images/DownLoad.gif" runat="server" />
         <asp:HiddenField ID="HidFileID" runat="server" />
        <asp:HiddenField ID="HidFileName" runat="server" />
         <asp:HiddenField ID="HidCanAdd" Value ="0" runat="server" />
        <asp:HiddenField ID="Hidcuruser" runat="server" />
    </div>
    </form>
</body>
</html>
