<%@ Page Language="vb" AutoEventWireup="false" Theme="Default" CodeBehind="QuotationDetail.aspx.vb"
    Inherits="CRM.QuotationDetail" %>

<%@ Register Src="../EFlowNet/Doc/Modules/CtlWFActionList.ascx" TagName="CtlWFActionList"
    TagPrefix="uc1" %>
<%@ Register Src="../EFlowNet/Doc/Modules/ctlWFHistory.ascx" TagName="ctlWFHistory"
    TagPrefix="uc2" %>
<%@ Register Src="../UCtl/UcFileDetail.ascx" TagName="UcFileDetail" TagPrefix="uc3" %>
<%@ Register Assembly="eFlowWebControl" Namespace="eFlowWebControl" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <object id="Signer" classid="clsid:EDAD2404-CEE0-4495-8D17-8DF60B32917E" codebase="../SignGadget.msi#version=1.0.1">
    </object>
    <link href="../IconsThemes/icon.css" rel="Stylesheet" type="text/css" />
    <link href="../NewScript/themes/Default/easyui.css" rel="Stylesheet" type="text/css" />
    <%--<link href="../CSS/newaction.css" rel="stylesheet" type="text/css" />--%>

    <script src="../NewScript/jquery-1.7.2.min.js" type="text/javascript"></script>

    <script type="text/javascript" src="../NewScript/plugins/jquery.bgiframe.js"></script>

    <script src="../NewScript/jquery.easyui.min.js" type="text/javascript"></script>

    <script type="text/javascript" src="../NewScript/plugins/jquery.toggleLoading.js"></script>

    <script type="text/javascript" src="../NewScript/datagrid-detailview.js"></script>

    <script type="text/javascript" src="../NewScript/datagrid-groupview.js"></script>

    <script src="../NewScript/My97DatePicker/WdatePicker.js" type="text/javascript"></script>

    <script src="QuotationDetail.js" type="text/javascript"></script>

    <script language="javascript" type="text/javascript">
        function showexception() {
            var QuotationPKID = document.getElementById("HiddenQuotationPKID").value;
            window.open('../Quotation/QuotationInvoid.aspx?DetailPKID=0&QuotationPKID=' + QuotationPKID,
		'popupcal',
		'width=320,height=190,left=400,top=380');
        }
        function thisclose() {
            document.getElementById('Button1').click();
        }
        function leavepage() {
            var tourl = document.getElementById("Hiddentourl").value;
            window.location = tourl;
        }
        function eSignTest() {
            var tourl = document.getElementById("Hiddentourl").value;
            var info;
            var FileID = document.getElementById("HiddenFileID").value;
            var SignID = document.getElementById("HiddenSignFile").value;
            var fileidint = document.getElementById("HiddenFileidINT").value;
            if (typeof (Signer) == "object") {
                //        var date1 = new Date();
                //        var result = Signer.SignFile("merge.pdf^merge2.pdf", "Signature1", "NNR1400043", "0");
                //        var date2 = new Date();
                //        var haomiao = date2.getTime() - date1.getTime();
                //        alert(haomiao);

                try {
                    var date3 = new Date();

                    //            var result = Signer.SignByName("merge.pdf,merge2.pdf,merge3.pdf", "Signature1,Signature1,Signature1", "NNFileManage\\NNR\\NNR1400043", "")
                    var result = Signer.SignByName2(FileID, SignID, "CRMQUOTER", 5, "", "FOXCONN CA");
                    if (result == "true") {
                        var info2 = Signer.SignSuccessfulList;
                        info2.split(",")

                        var ResultList = info2.split(";");
                        var ReturnFile = [];
                        for (var i = 0; i < ResultList.length - 1; i++) {
                            var mFileInfo = ResultList[i].split(",");
                            ReturnFile.push(mFileInfo[2]);
                        }
                        var allFileName = ReturnFile.join("^");

                        $.ajax({
                            type: "POST",
                            contentType: "application/json",
                            url: "QuotationDetail.aspx/Upfileclientname",
                            data: "{'filenewname':'" + allFileName + "','fileidint': '" + fileidint + "'}",
                            dataType: 'json',
                            success: function(msg) {
                            }
                        });

                    }
                   

                    //                    if (result == "true") {
                    //                        var info2 = Signer.SignSuccessfulList;
                    //                        info2.split(",")

                    //                        var ResultList = info2.split(";");
                    //                        var ReturnFile = [];
                    //                        for (var i = 0; i < ResultList.length - 1; i++) {
                    //                            var mFileInfo = ResultList[i].split(",");
                    //                            ReturnFile.push(mFileInfo[2]);
                    //                        }
                    //                        var allFileName = ReturnFile.join("^");

                    //                        alert(allFileName);
                    //                        //document.getElementById("TxtSignFile").value = allFileName;
                    //                        return false;
                    //                        
                    //                    }
                } catch (e) {
                    alert('PDF簽名失敗！');
                }
                window.location = tourl;
            }
        }
    </script>

</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div align="center" style="font-size: 20px">
        報價單</div>
    <div>
        <table width="100%">
            <tr>
                <td width="80%">
                    <uc1:CtlWFActionList ID="CtlWFActionList1" runat="server" />
                </td>
                <td>
                    <a id="exceptionend" class="easyui-linkbutton" iconcls="icon-Approve" runat="server"
                        visible="false" onclick="showexception()">異常結案處理</a>
                    <asp:LinkButton ID="LinkReport" class="easyui-linkbutton" Visible="false" iconcls="icon-Approve"
                        runat="server">對應報告處理單</asp:LinkButton>
                </td>
            </tr>
        </table>
    </div>
    <div style="clear: both">
    </div>
    <div id="quotationinvalid" runat="server" visible="false">
        異常結案原因：<asp:TextBox ID="TxtReason" runat="server" Width="500px"></asp:TextBox>
        <asp:LinkButton ID="LinkapproveQuoinvalid" class="easyui-linkbutton" iconcls="icon-Approve"
            runat="server">核准異常結案</asp:LinkButton>
        <asp:LinkButton ID="Linkbohui" class="easyui-linkbutton" iconcls="icon-undo" runat="server">駁回異常結案</asp:LinkButton>
    </div>
    <div id="DivQuotationInfo">
        <table width="100%" border="1" cellpadding="0" cellspacing="0" bordercolordark="#FFFFFF"
            bordercolor="#999999">
            <tr>
                <td colspan="10" bgcolor="#E6E6E6" height="50">
                    <asp:Image ID="Image3" runat="server" Style="vertical-align: middle" ImageUrl="~/Images/ico/baseinfo.png" />
                    <asp:Label ID="Label8" runat="server" Text="報價單基本信息" Font-Bold="True" Font-Size="14px"></asp:Label>
                     <asp:Label ID="LbTecsuppry" Visible="false" runat="server" Text="技術客服"></asp:Label>
                    <asp:DropDownList ID="DPLtecsupport" onchange="tecsupportchange()" Visible="false"
                        runat="server">
                    </asp:DropDownList>
                    <asp:Label ID="LbIsSendMail" Visible="false" runat="server" Text="是否郵件通知客戶"></asp:Label>
                    <asp:RadioButtonList ID="RdoIsSendMail" runat="server" Visible="false" RepeatDirection="Horizontal"
                        RepeatLayout="Flow">
                        <asp:ListItem Selected="True" Value="1">通知</asp:ListItem>
                        <asp:ListItem Value="0">不通知</asp:ListItem>
                    </asp:RadioButtonList>
                    <asp:Button ID="BtnSendMail" Visible="false" runat="server" Text="重新郵件通知客戶" />
                </td>
            </tr>
            <tr>
                <td>
                    報價單號
                </td>
                <td style="margin-left: 40px">
                    <asp:TextBox ID="TxtQuotationNO" runat="server" Width="130px"></asp:TextBox>
                    <asp:HiddenField ID="HiddenPKID" Value="0" runat="server" />
                </td>
                <td>
                    測試類型
                </td>
                <td>
                    <asp:RadioButtonList ID="RdoTestCategory" runat="server" RepeatDirection="Horizontal"
                        RepeatLayout="Flow">
                        <asp:ListItem Value="0" Selected="True">一般</asp:ListItem>
                        <asp:ListItem Value="1">特殊</asp:ListItem>
                    </asp:RadioButtonList>
                </td>
                <td align="left">
                    <%--<asp:DataList ID="DataList1" runat="server" RepeatDirection="Horizontal" 
                        RepeatLayout="Flow">
                       <ItemTemplate>
                                <asp:LinkButton ID="LinkButton1" runat="server" Text='<%#Container.DataItem%>'></asp:LinkButton>
                                &nbsp;
                            </ItemTemplate>
                    </asp:DataList>--%>期望完成日期
                </td>
                <td>
                    <asp:TextBox ID="TxtHopeFinishDate" Width="100px" class="Wdate" runat="server"></asp:TextBox>
                </td>
                <td colspan="2">
                    是否開發票
                </td>
                <td colspan="2">
                    <asp:RadioButtonList ID="RDOisneedFapiao" runat="server" RepeatDirection="Horizontal"
                        RepeatLayout="Flow">
                        <asp:ListItem Selected="True" Value="1">是</asp:ListItem>
                        <asp:ListItem Value="2">否</asp:ListItem>
                    </asp:RadioButtonList>
                </td>
            </tr>
            <tr>
                <td>
                    報價人
                </td>
                <td>
                    <asp:TextBox ID="TxtQuotater" Width="130px" runat="server"></asp:TextBox>
                    <asp:HiddenField ID="HiddenQuoterID" runat="server" />
                </td>
                <td>
                    報價日期
                </td>
                <td>
                    <asp:TextBox ID="TxtQuotationDate" Width="100px" class="Wdate" runat="server"></asp:TextBox>
                </td>
                <td>
                    電話
                </td>
                <td>
                    <asp:TextBox ID="TxtQuotaterPhone" Width="100px" runat="server"></asp:TextBox>
                </td>
                <td colspan="2">
                    Email
                </td>
                <td colspan="2">
                    <asp:TextBox ID="TxtQuotaterEmail" Width="100px" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    公司名稱
                </td>
                <td>
                    <asp:TextBox ID="TxtCustomerName" class="easyui-validatebox" required="true" Width="130px"
                        runat="server"></asp:TextBox>
                    <asp:HiddenField ID="HiddenCustomerName" Value="0" runat="server" />
                    <asp:HiddenField ID="HiddenCustomerPKID" Value="0" runat="server" />
                </td>
                <td>
                    聯繫人
                </td>
                <td>
                    <asp:TextBox ID="TxtContactName" class="easyui-validatebox" required="true" Width="100px"
                        runat="server"></asp:TextBox>
                    <asp:HiddenField ID="HiddenContactName" Value="0" runat="server" />
                    <asp:HiddenField ID="HiddenContactID" Value="0" runat="server" />
                </td>
                <td>
                    電話
                </td>
                <td>
                    <asp:TextBox ID="TxtContactPhone" Width="100px" runat="server"></asp:TextBox>
                    <asp:HiddenField ID="HiddenContactPhone" Value="" runat="server" />
                </td>
                <td colspan="2">
                    Email
                </td>
                <td colspan="2">
                    <asp:TextBox ID="TxtContactEmail" Width="100px" runat="server"></asp:TextBox>
                    <asp:HiddenField ID="HiddenContactEmail" Value="" runat="server" />
                </td>
            </tr>
            <tr>
                <td>
                    客戶等級
                </td>
                <td>
                    <asp:Label ID="LbCustomerGrade" runat="server"></asp:Label>
                    &nbsp;
                </td>
                <td>
                    付款方式
                </td>
                <td>
                    <asp:Label ID="LbTypeOfPay" runat="server"></asp:Label>
                    &nbsp;
                </td>
                <td>
                    測試歷史
                </td>
                <td>
                    <asp:Label ID="LbCusHistory" runat="server"></asp:Label>
                    &nbsp;
                </td>
                <td colspan="2">
                    樣品取回
                </td>
                <td colspan="2">
                    <asp:RadioButtonList ID="RdoIsneedBack" runat="server" RepeatDirection="Horizontal"
                        RepeatLayout="Flow">
                        <asp:ListItem Selected="True" Value="申請人取回">取回</asp:ListItem>
                        <asp:ListItem Value="實驗室自行處理">不取回</asp:ListItem>
                    </asp:RadioButtonList>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="LbCBshow" Visible="false" runat="server" Text="成本價"></asp:Label>
                    &nbsp;
                </td>
                <td>
                    <asp:Label ID="LbCB" Visible="false" runat="server"></asp:Label>
                    <asp:HiddenField ID="HiddenCB" Value="0" runat="server" />
                    &nbsp;
                </td>
                <td>
                    <asp:Label ID="LbPaijia" runat="server" Text="牌價"></asp:Label>
                    &nbsp;
                </td>
                <td>
                    <asp:TextBox ID="TxtPaijia" Width="100px" Text="0" Enabled="false" runat="server"></asp:TextBox>
                    <asp:HiddenField ID="HiddenPaijia" Value="0" runat="server" />
                </td>
                <td>
                    當前報價
                </td>
                <td>
                    <asp:TextBox ID="TxtDangqiangzongjia" Width="100px" Enabled="false" onchange="jisuanbili()"
                        Text="0" runat="server"></asp:TextBox>
                    <asp:HiddenField ID="HiddenShijibaojia" Value="0" runat="server" />
                </td>
                <td>
                    <asp:Label ID="Label3" runat="server" Text="優惠比例" Font-Bold="True" ForeColor="#009933"></asp:Label>
                    &nbsp;
                </td>
                <td>
                    <asp:Label ID="LbYouhuibili" runat="server" Font-Bold="True" ForeColor="#009933"></asp:Label>
                    <asp:HiddenField ID="HiddenYouhuibili" runat="server" />
                    &nbsp;
                </td>
                <td>
                    <asp:Label ID="LbProfitShow" Font-Bold="True" Visible="false" ForeColor="#009933"
                        runat="server" Text="利潤率"></asp:Label>
                    &nbsp;
                </td>
                <td>
                    <asp:Label ID="LbPrifit" Visible="false" Font-Bold="True" ForeColor="#009933" runat="server"></asp:Label>
                    &nbsp;
                </td>
            </tr>
        </table>
    </div>
    <br />
    <div title="送檢物品及測試項目信息" id="DivSample" style="height: auto;" iconcls="icon-Manage">
        <table width="100%" border="1" cellpadding="0" cellspacing="0" bordercolordark="#FFFFFF"
            bordercolor="#999999">
            <tr>
                <td bgcolor="#E6E6E6" height="50">
                    <asp:Image ID="Image4" runat="server" Style="vertical-align: middle" ImageUrl="~/Images/ico/sample.png" />
                    <asp:Label ID="Label7" runat="server" Text="送檢物品及測試項目信息" Font-Bold="True" Font-Size="14px"></asp:Label>
                    <asp:RadioButtonList ID="RDOishanshui" runat="server" 
                        RepeatDirection="Horizontal" RepeatLayout="Flow">
                        <asp:ListItem Selected="True" Value="0">未稅價</asp:ListItem>
                        <asp:ListItem Value="1">含稅價</asp:ListItem>
                    </asp:RadioButtonList>
                </td>
            </tr>
            <tr>
                <td>
                    <table id="SampleTable" parent="1" fitcolumns="false" style="height: auto" singleselect="true"
                        idfield="SamplePKID">
                    </table>
                    <div id="SampleButtons" style="display: none;">
                        <a href="#" class="easyui-linkbutton" iconcls="icon-add" id="btnAdd" plain="true"
                            onclick="AddSample()">添加樣品</a> <a href="#" class="easyui-linkbutton" iconcls="icon-cut"
                                disabled="true" id="btnDelete" plain="true" onclick="DeleteSample()">刪除樣品</a>
                        <a href="#" class="easyui-linkbutton" iconcls="icon-save" disabled="true" id="btnSave"
                            plain="true" onclick="SaveSample(0)">保存</a> <a href="#" class="easyui-linkbutton"
                                iconcls="icon-undo" disabled="true" id="btnCancel" plain="true" onclick="CencelSample()">
                                取消編輯</a>
                    </div>
                </td>
            </tr>
        </table>
    </div>
    <br />
    <div id="testremark" style="display: none">
        <table width="100%" border="1" cellpadding="0" cellspacing="0" bordercolordark="#FFFFFF"
            bordercolor="#999999">
            <tr>
                <td colspan="2" bgcolor="#E6E6E6" height="50">
                    <asp:Image ID="Image2" runat="server" Style="vertical-align: middle" ImageUrl="~/Images/ico/tip.png" />
                    <asp:Label ID="Label2" runat="server" Text="測試要求及說明" Font-Bold="True" Font-Size="14px"></asp:Label>
                </td>
            </tr>
            <tr>
                <td width="50%">
                    <asp:TextBox ID="TxtTestRemark" runat="server" Height="50px" TextMode="MultiLine"
                        Width="366px"></asp:TextBox>
                </td>
                <td>
                    <uc3:UcFileDetail ID="UcFileDetail3" runat="server" />
                </td>
            </tr>
        </table>
    </div>
    <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <div style="float: left; width: 50%;">
                <table width="100%" border="1" cellpadding="0" cellspacing="0" bordercolordark="#FFFFFF"
                    bordercolor="#999999">
                    <tr>
                        <td bgcolor="#E6E6E6" height="50">
                            <asp:Image ID="Image5" runat="server" Style="vertical-align: middle" ImageUrl="~/Images/ico/topdf.png" />
                            <asp:Label ID="Label5" runat="server" Text="系統生成報價單" Font-Bold="True" Font-Size="14px"></asp:Label>
                            <asp:RadioButtonList ID="RadioButtonList1" runat="server" RepeatDirection="Horizontal"
                                RepeatLayout="Flow">
                                <asp:ListItem Value="0" Selected="True">保留兩位小數</asp:ListItem>
                                <asp:ListItem Value="1">取整</asp:ListItem>
                            </asp:RadioButtonList>
                            <asp:LinkButton ID="LinkGetPDF" class="easyui-linkbutton" plain="true" iconcls="icon-print"
                                Style="display: none" runat="server">生成PDF檔</asp:LinkButton>
                            <asp:CheckBox ID="CHBisneedseal" runat="server" Checked="False" Text="加蓋印章" />
                        </td>
                    </tr>
                    <tr>
                        <td height="65px">
                            <uc3:UcFileDetail ID="UcFileDetail1" runat="server" />
                        </td>
                    </tr>
                </table>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
    <div style="float: right; width: 49.9%;">
        <table width="100%" border="1" cellpadding="0" cellspacing="0" bordercolordark="#FFFFFF"
            bordercolor="#999999">
            <tr>
                <td bgcolor="#E6E6E6" height="50" colspan="2">
                    <asp:Image ID="Image6" runat="server" Style="vertical-align: middle" ImageUrl="~/Images/ico/topdf.png" />
                    <asp:Label ID="Label6" runat="server" Text="客戶回傳報價單" Font-Bold="True" Font-Size="14px"></asp:Label>
                </td>
            </tr>
            <tr>
                <td height="65px">
                    說明：<asp:TextBox ID="TxtCusRemark" runat="server" Height="45px" TextMode="MultiLine"></asp:TextBox>
                </td>
                <td height="65px">
                    <uc3:UcFileDetail ID="UcFileDetail2" runat="server" />
                </td>
            </tr>
        </table>
    </div>
    <div style="clear: both">
    </div>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <div class="DivShow">
                <table>
                    <tr>
                        <td width="100px">
                        </td>
                        <td width="100px">
                        </td>
                    </tr>
                </table>
            </div>
            <div>
                <div class="DivShow">
                    <table width="100%" border="1" cellpadding="0" cellspacing="0" bordercolordark="#FFFFFF"
                        bordercolor="#999999">
                        <tr>
                            <td bgcolor="#E6E6E6" height="50">
                                <asp:LinkButton ID="LinkButton1" runat="server" ToolTip="點擊可顯示或隱藏" Font-Underline="false">
                                    <asp:Image ID="Image1" runat="server" Style="vertical-align: middle" ImageUrl="../Images/ico/history.png" />
                                </asp:LinkButton>
                                <asp:Label ID="Label4" runat="server" Text="歷 史 記 錄" Font-Bold="True" Font-Size="14px"></asp:Label>
                                <asp:TextBox ID="TxtCondition" Text="默認只顯示五天內記錄，搜尋可顯示更早數據" class="text-input" runat="server"
                                    Width="500px"></asp:TextBox>
                                <asp:Button ID="BtnSearch" class="button" runat="server" Text="搜尋" />
                            </td>
                        </tr>
                        <tr id="testhistory" runat="server" visible="false">
                            <td>
                                <div id="emptyinfo" runat="server" visible="false" style="width: 100%; height: 30px;
                                    background-color: #DBE3FF; line-height: 30px; overflow: hidden;">
                                    <asp:Image ID="Image7" runat="server" Style="vertical-align: middle" ImageUrl="~/Images/Icons/information.png" />
                                    &nbsp;&nbsp;&nbsp; 近期沒有報價記錄，請搜尋以查看所有歷史記錄</div>
                                <div>
                                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" Width="100%">
                                        <Columns>
                                            <asp:BoundField DataField="QuotationNO" HeaderText="報價單號" HeaderStyle-HorizontalAlign="Left" />
                                            <asp:BoundField DataField="ServiceType" HeaderText="服務類別" HeaderStyle-HorizontalAlign="Left" />
                                            <asp:BoundField DataField="TestItemName" HeaderText="測試項目" HeaderStyle-HorizontalAlign="Left" />
                                            <asp:BoundField DataField="Numbers" HeaderText="數量" HeaderStyle-HorizontalAlign="Left" />
                                            <asp:BoundField DataField="Paijiadanjia" HeaderText="牌價單價" ItemStyle-ForeColor="#009933"
                                                HeaderStyle-HorizontalAlign="Left" />
                                            <asp:BoundField DataField="Shijidanjia" HeaderText="報價單價" ItemStyle-ForeColor="#FF3300"
                                                HeaderStyle-HorizontalAlign="Left" />
                                            <asp:BoundField DataField="RecordCreated" DataFormatString="{0:yyyy-MM-dd}" HeaderText="時間"
                                                HeaderStyle-HorizontalAlign="Left" />
                                        </Columns>
                                        <SelectedRowStyle BackColor="Yellow" />
                                    </asp:GridView>
                                </div>
                            </td>
                        </tr>
                    </table>
                </div>
            </div>
            <br />
        </ContentTemplate>
    </asp:UpdatePanel>
    <br />
    <div>
        <table width="100%" border="1" cellpadding="0" cellspacing="0" bordercolordark="#FFFFFF"
            bordercolor="#999999">
            <tr>
                <td bgcolor="#E6E6E6" height="30">
                    <asp:Label ID="Label1" runat="server" Text="簽 核 歷 史" Font-Bold="True" Font-Size="14px"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <uc2:ctlWFHistory ID="ctlWFHistory1" runat="server" />
                </td>
            </tr>
        </table>
    </div>
    <div id="tab-tools">
    </div>
    <div id="dlgTestItemDetail" title="測試項目信息" class="easyui-dialog" closed="true" style="width: 810px;
        height: 540px; padding: 10px">
        <table id="DlgTestItem">
        </table>
    </div>
    <div style="display: none">
        <input id="afaddsample" type="button" onclick="AftAddsample()" />
        <asp:HiddenField ID="HiddenMinYOUhui" Value="1" runat="server" />
        <asp:Button ID="Button1" runat="server" Text="Button" />
        <asp:HiddenField ID="HiddenQuotationPKID" Value="0" runat="server" />
        <asp:HiddenField ID="HiddenIsLeader" Value="0" runat="server" />
        <asp:HiddenField ID="HiddenQuoterFax" runat="server" />
        <asp:HiddenField ID="HiddenContactFax" runat="server" />
        <asp:HiddenField ID="HiddenStateorder" Value="0" runat="server" />
        <asp:HiddenField ID="HiddenCanAdd" Value="True" runat="server" />
        <asp:HiddenField ID="HidSamplePKID" runat="server" />
        <asp:HiddenField ID="HiddenCurrentCan" Value="0" runat="server" />
        <asp:HiddenField ID="HiddenOne" Value="0.8" runat="server" />
        <asp:HiddenField ID="HiddenTwo" Value="0.9" runat="server" />
        <asp:HiddenField ID="HiddenThree" Value="1" runat="server" />
        <asp:HiddenField ID="HiddenFour" Value="1" runat="server" />
        <asp:HiddenField ID="HiddenFive" Value="1" runat="server" />
        <asp:HiddenField ID="HiddenIsCustomer" Value="0" runat="server" />
        <asp:HiddenField ID="HiddenIsFast" Value="0" runat="server" />
        <asp:HiddenField ID="HiddenIsGoods" runat="server" />
        <asp:HiddenField ID="HiddenTecSupport" Value="0" runat="server" />
        <asp:HiddenField ID="HiddenFileID" runat="server" />
        <asp:HiddenField ID="HiddenSignFile" runat="server" />
        <asp:HiddenField ID="Hiddentourl" runat="server" />
        <asp:HiddenField ID="HiddenFileidINT" runat="server" />
    </div>
    </form>
</body>
</html>
