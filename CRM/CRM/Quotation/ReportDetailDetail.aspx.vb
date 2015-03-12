Imports eWorkFlow.eFlowDoc
Imports Platform.eAuthorize
Imports Platform.eHR.Core
Imports System.IO
Imports System.Web.Services

Partial Public Class ReportDetailDetail
    Inherits System.Web.UI.Page
    Implements IDocInfo

#Region "Const"
    Private Const HIDE_APPLICANTIDX_KEY As String = "ViewState:PKID"
    Private Const HIDE_DOCUNIQUEID_KEY As String = "ViewState:DocUniqueID"
    Private Const _RequestType As String = "ViewState:Type"
#End Region
#Region "Properties"

    '當前文件惟一ID
    Private Property PKID() As Integer
        Get
            If ViewState(HIDE_APPLICANTIDX_KEY) Is Nothing Then
                Return 0
            End If

            Return Convert.ToInt32(ViewState(HIDE_APPLICANTIDX_KEY))
        End Get
        Set(ByVal Value As Integer)
            ViewState(HIDE_APPLICANTIDX_KEY) = Value
        End Set
    End Property
    Private Property QuotationPKID() As Integer
        Get
            If ViewState("QuotationPKID") Is Nothing Then
                Return 0
            End If
            Return Convert.ToInt32(ViewState("QuotationPKID"))
        End Get
        Set(ByVal value As Integer)
            ViewState("QuotationPKID") = value
        End Set
    End Property
    '流程控制文件ID
    Private Property DocUniqueID() As String
        Get
            If ViewState(HIDE_DOCUNIQUEID_KEY) Is Nothing Then
                Return String.Empty
            End If

            Return ViewState(HIDE_DOCUNIQUEID_KEY).ToString()
        End Get
        Set(ByVal Value As String)
            ViewState(HIDE_DOCUNIQUEID_KEY) = Value
        End Set
    End Property
    Private _QuotationInfo As QuotationInfo
    Private Property QuotationInfo() As QuotationInfo
        Get
            If _QuotationInfo Is Nothing Then
                If QuotationPKID <> 0 Then
                    _QuotationInfo = QuotationDAL.GetInfoByPKID(QuotationPKID)
                Else
                    _QuotationInfo = New QuotationInfo()
                End If
            End If

            Return _QuotationInfo
        End Get
        Set(ByVal value As QuotationInfo)
            _QuotationInfo = value
        End Set
    End Property
    Private Property CurType() As String
        Get
            If Not ViewState(_RequestType) Is Nothing Then
                Return CStr(ViewState(_RequestType))
            Else
                Return 0
            End If
        End Get
        Set(ByVal Value As String)
            ViewState(_RequestType) = Value
        End Set
    End Property
    Private _ReportDetail As ReportDetailInfo
    Private Property ReportDetail() As ReportDetailInfo
        Get
            If _ReportDetail Is Nothing Then
                If PKID <> 0 Then
                    _ReportDetail = ReportDetailDAL.GetInfoByPKID(PKID)
                    QuotationPKID = _ReportDetail.QuotationPKID
                ElseIf DocUniqueID <> String.Empty Then
                    _ReportDetail = ReportDetailDAL.GetInfoByeFLowdocID(DocUniqueID)
                    PKID = _ReportDetail.PKID
                    QuotationPKID = _ReportDetail.QuotationPKID
                Else
                    _ReportDetail = New ReportDetailInfo()
                End If
            End If
            Return _ReportDetail
        End Get
        Set(ByVal value As ReportDetailInfo)
            _ReportDetail = value
        End Set
    End Property
    Private _CurTestRemark As QuoTestRemarkInfo
    Private Property CurTestRemark() As QuoTestRemarkInfo
        Get
            If _CurTestRemark Is Nothing Then
                If QuotationPKID <> 0 Then
                    _CurTestRemark = QuoTestRemarkDAL.GetInfoByParentPKID(QuotationPKID)
                End If
            End If
            Return _CurTestRemark
        End Get
        Set(ByVal value As QuoTestRemarkInfo)
            _CurTestRemark = value
        End Set
    End Property
#End Region

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            GetParam()
            BindControlData()
            If CurType = 99 Then
                Me.DivTestApplyinfo.Visible = True
                Me.DivTestApplyNo.Visible = False
                Me.CtlWFActionList1.Visible = False
                Me.ctlWFHistory1.Visible = False
                BindGrid2()
                Me.LinkDirect.Visible = True
            Else
                If CurType = 1 And ConfigurationManager.AppSettings("IsWithTAM") = "1" Then
                    BindGrid2()
                End If
                '  Me.DivTestApplyinfo.Visible = False
                Me.DivTestApplyNo.Visible = True
                BindRepeatere()
            End If
            If UserInfo.IsInRoles("EXTERNALWORKER") OrElse UserInfo.IsInRoles("CRM經管") OrElse UserInfo.IsInRoles("ZHONGXINZHUGUAN") OrElse UserInfo.IsInRoles("XINGZHENGZHUGUAN") OrElse UserInfo.IsInRoles("Yewuzhuguan") Then
                If UserInfo.IsInRoles("EXTERNALWORKER") Then
                    Me.DPLtecsupport.Visible = True
                    Me.LbTecSupport.Visible = False
                    Me.BtnUptec.Visible = True
                    Dim accountlist As List(Of AccountInfo) = RoleManage.LoadAccountCollection("CRMTECSUPPORT") '綁定所有技術客服
                    Me.DPLtecsupport.DataSource = accountlist
                    Me.DPLtecsupport.DataTextField = "UserName"
                    Me.DPLtecsupport.DataValueField = "UserSID"
                    Me.DPLtecsupport.DataBind()
                    Me.DPLtecsupport.Items.Add("未選擇")
                    If QuotationInfo.Extend10 <> "" AndAlso QuotationInfo.Extend10 <> "未選擇" Then
                        Me.DPLtecsupport.SelectedIndex = Me.DPLtecsupport.Items.IndexOf(Me.DPLtecsupport.Items.FindByValue(QuotationInfo.Extend10))
                        Me.HiddenTecSupport.Value = QuotationInfo.Extend10
                    Else
                        Me.DPLtecsupport.SelectedIndex = Me.DPLtecsupport.Items.IndexOf(Me.DPLtecsupport.Items.FindByText("未選擇"))
                        Me.HiddenTecSupport.Value = "未選擇"
                    End If
                End If
            Else

                Me.LbPaijia.Visible = False
                Me.LbPajiashow.Visible = False

            End If
            If UserInfo.IsInRoles("OperationsAssistant") Then
                Me.div1.Visible = False
                Me.div2.Visible = False
                Me.div3.Visible = False
            End If

            'Me.UcFileDetail1.CanRemove = False
            'Me.UcFileDetail1.CanUpload = False
            'Me.UcFileDetail1.ISQuotation = 1                     '所有報告
            'Me.UcFileDetail1.ParentID = QuotationPKID
            'Me.UcFileDetail1.ParentCategory = 2
            'Me.UcFileDetail1.ParentSubCategory = 0
            Me.UcFileDetail1.ParentID = QuotationPKID
            Me.UcFileDetail1.ParentCategory = 1
            Me.UcFileDetail1.ParentSubCategory = 3

            Me.UcFileDetail2.ParentID = PKID                 '付款憑證
            Me.UcFileDetail2.ParentCategory = 2
            Me.UcFileDetail2.ParentSubCategory = 1
            Me.UcFileDetail2.CanUpload = False
            Me.UcFileDetail2.CanRemove = False
         
            Me.UcFileDetail4.ParentID = QuotationPKID               '客戶回傳的報價單
            Me.UcFileDetail4.ParentCategory = 1
            Me.UcFileDetail4.ParentSubCategory = 2
            'Me.UcFileDetail5.FileSize = ConfigurationManager.AppSettings("UploadMaxSize")

            'Me.UcFileDetail5.CanUpload = False
            'Me.UcFileDetail5.CanRemove = False
            'Me.UcFileDetail5.ParentID = QuotationPKID                 '業務上傳的報告
            'Me.UcFileDetail5.ParentCategory = 2
            'Me.UcFileDetail5.ParentSubCategory = 2
        End If
    End Sub
    Private Sub GetParam()
        If Not Request.QueryString("PKID") Is Nothing Then
            PKID = Convert.ToInt32(Request.QueryString("PKID"))
        End If
        If Not Request.QueryString(Global_asax.QUERY_DOCUNIQUEID) Is Nothing Then
            DocUniqueID = Request.QueryString(Global_asax.QUERY_DOCUNIQUEID)
        End If
        If Not Request.QueryString("Type") Is Nothing Then
            CurType = Convert.ToInt32(Request.QueryString("Type"))
        End If
    End Sub
    Private Sub BindRepeatere()
        Dim ds As DataSet = TestItemDetailDAL.GetDsByQuotationPKID(QuotationPKID)
        If Not ds Is Nothing Then
            Me.Repeater1.DataSource = ds
            Me.Repeater1.DataBind()
        End If
    End Sub
    Private Sub BindControlData()
        If Not ReportDetail Is Nothing Then
            If Not QuotationInfo Is Nothing Then
                If QuotationPKID <> 0 Then
                    If UserInfo.IsInRoles("SYS_ADMINISTRATOR") OrElse UserInfo.IsInRoles("CRM經管") OrElse UserInfo.IsInRoles("ZHONGXINZHUGUAN") OrElse UserInfo.IsInRoles("TEDINGSHENHE") OrElse UserInfo.IsInRoles("Yewuzhuguan") OrElse (UserInfo.IsInRoles("EXTERNALWORKER") AndAlso QuotationInfo.Extend03.Trim.ToUpper = UserInfo.CurrentUserID.Trim.ToUpper) OrElse (UserInfo.CurrentUserID.Trim.ToUpper = QuotationInfo.Extend01.Trim.ToUpper AndAlso ReportDetail.IsFinished = 1) OrElse (UserInfo.IsInRoles("CRMTECSUPPORT") AndAlso QuotationInfo.Extend10.Trim.ToUpper = UserInfo.CurrentUserID.Trim.ToUpper) Then
                        If UserInfo.IsInRoles("SYS_ADMINISTRATOR") Then
                            Me.BtnUpTestNO.Visible = True
                        End If
                        Dim CurQuoRemark As QuoTestRemarkInfo = QuoTestRemarkDAL.GetInfoByParentPKID(QuotationPKID)
                        Me.LbCushui.Text = CurQuoRemark.Extend2

                        Me.HiddenReportDetailPKID.Value = PKID
                        Me.HiddenQuotationPKID.Value = QuotationPKID
                        If QuotationInfo.Extend10 <> "" AndAlso QuotationInfo.Extend10 <> "未選擇" Then
                            Me.LbTecSupport.Text = AccountManage.LoadAccountInfoByUserSID(QuotationInfo.Extend10).UserName
                            Me.HiddenTecSupport.Value = QuotationInfo.Extend10
                        End If
                        Me.TxtTestRemark.Text = CurTestRemark.TestRemark
                        Me.LbTestremarkchage.Text = Replace(CurTestRemark.Extend1, ",", "<br/>")

                        If ReportDetail.Extend04 = "9999-12-31 23:59:59.997" AndAlso (UserInfo.IsInRoles("OperationsAssistant") OrElse (UserInfo.IsInRoles("EXTERNALWORKER") AndAlso QuotationInfo.Extend03 = UserInfo.CurrentUserID.Trim.ToUpper) OrElse (UserInfo.IsInRoles("CRMTECSUPPORT") AndAlso QuotationInfo.Extend10.Trim.ToUpper = UserInfo.CurrentUserID.Trim.ToUpper)) Then
                            Me.LinkSendsample.Visible = True
                        End If
                        If ReportDetail.Extend05 = "9999-12-31 23:59:59.997" AndAlso UserInfo.IsInRoles("CRM經管") Then
                            Me.LinkDoinvoice.Visible = True
                        End If
                        If ReportDetail.Extend06 = "9999-12-31 23:59:59.997" AndAlso ReportDetail.Extend05 <> "9999-12-31 23:59:59.997" AndAlso (UserInfo.IsInRoles("OperationsAssistant") OrElse (UserInfo.IsInRoles("EXTERNALWORKER") AndAlso QuotationInfo.Extend03 = UserInfo.CurrentUserID.Trim.ToUpper) OrElse (UserInfo.IsInRoles("CRMTECSUPPORT") AndAlso QuotationInfo.Extend10.Trim.ToUpper = UserInfo.CurrentUserID.Trim.ToUpper)) Then
                            Me.LinkSendinvoice.Visible = True
                        End If
                        If ReportDetail.Extend04 = "9999-12-31 23:59:59.997" Then
                            Me.LbSendSampleDate.Text = "未寄樣品"
                        Else
                            Me.LbSendSampleDate.Text = CDate(ReportDetail.Extend04).ToString("yy-MM-dd HH:MM")
                        End If
                        If ReportDetail.Extend05 = "9999-12-31 23:59:59.997" Then
                            Me.LbDOinvoiceDate.Text = "未開發票"
                        Else
                            Me.LbDOinvoiceDate.Text = CDate(ReportDetail.Extend05).ToString("yy-MM-dd HH:MM")
                        End If
                        If ReportDetail.Extend06 = "9999-12-31 23:59:59.997" Then
                            Me.LbSendInvoicedate.Text = "未寄發票"
                        Else
                            Me.LbSendInvoicedate.Text = CDate(ReportDetail.Extend06).ToString("yy-MM-dd HH:MM")
                        End If
                        Me.HiddenQuoterPKID.Value = QuotationInfo.Extend03
                        Me.LbContactEmail.Text = QuotationInfo.ContactEmail
                        Me.LbContactName.Text = QuotationInfo.ContactName
                        Me.LbCustomerName.Text = QuotationInfo.CustomerName
                        Me.LbHopefinishdate.Text = QuotationInfo.HopeFinishDATE
                        Me.LbIsback.Text = QuotationInfo.Extend02
                        Me.LbPaijia.Text = QuotationInfo.Paijia
                        Me.LbQuotaterEmail.Text = QuotationInfo.QuoteEmail
                        Me.LbQuotaterPhone.Text = QuotationInfo.QuotaerPhone
                        Me.LbQuotationNO.Text = QuotationInfo.QuotationNO
                        Me.LbQuoterDate.Text = QuotationInfo.QuoteDate
                        Me.LbQuoterName.Text = QuotationInfo.QuotaerName
                        Me.LbShijibaojia.Text = QuotationInfo.Shijizongjia
                        Me.HiddenContactID.Value = QuotationInfo.Extend01
                        'If QuotationInfo.TestNO <> "" Then
                        '    Dim ApplyPKID As String() = QuotationInfo.TestNO.Substring(0, QuotationInfo.TestNO.Length - 1).Split(",")
                        '    Me.DataList1.DataSource = ApplyPKID
                        '    Me.DataList1.DataBind()
                        'End If
                        Me.ContactPhone.Text = QuotationInfo.ContactPhone
                        If QuotationInfo.TestCategory = 1 Then
                            Me.LbTestCategory.Text = "特殊測試"
                        Else
                            Me.LbTestCategory.Text = "一般測試"
                        End If
                        Me.HiddenTestCategory.Value = QuotationInfo.TestCategory
                        If QuotationInfo.Extend07 = "1" Then
                            Me.LbYinshoumoney.Text = (QuotationInfo.Shijizongjia * 1.06).ToString("0.00")
                        ElseIf QuotationInfo.Extend07 = "2" Then
                            Me.LbYinshoumoney.Text = QuotationInfo.Shijizongjia
                        End If


                        Dim curcustomerinfo As CustomersInfo = CustomersDAL.GetInfoByPKID(QuotationInfo.CustomerPKID)
                        Me.LbCustomerGrade.Text = curcustomerinfo.Grade.Substring(1, 1) + "級"
                        Me.LbCustomerAddress.Text = curcustomerinfo.Address

                        Me.LbCusHistory.Text = QuotationDAL.GetHisByCustomerPKID(QuotationInfo.CustomerPKID)
                        Me.LbCustomerGrade.Text = curcustomerinfo.Grade.Substring(1, 1) + "級"
                        Me.HiddenTypeofPay.Value = curcustomerinfo.TypeofPay
                        If curcustomerinfo.TypeofPay = 1 Then
                            Me.LbTypeOfPay.Text = "預付款客戶"
                        ElseIf curcustomerinfo.TypeofPay = 2 Then
                            Me.LbTypeOfPay.Text = "月結客戶"

                        End If
                    Else
                        ' Me.UcFileDetail1.ParentID = 0
                        Me.UcFileDetail2.ParentID = 0

                        Me.UcFileDetail4.ParentID = 0
                        ' Me.UcFileDetail5.ParentID = 0
                        Response.Write("<script>alert('您無權限訪問該頁面！'); window.location='../Index.aspx';</script>")

                    End If
                End If
            End If
        End If
    End Sub
    Dim i As Integer = 1

#Region "IDOC"
    Public ReadOnly Property BusniessName() As String Implements eWorkFlow.eFlowDoc.IDocInfo.BusniessName
        Get
            Return "CRM報告處理流程"
        End Get
    End Property

    Public Sub DeleteDocInfo(ByVal CurDocInfo As eWorkFlow.eFlowDoc.DocInfoSystem, ByVal CommandName As Platform.eWorkFlow.Model.Enm_ActionType) Implements eWorkFlow.eFlowDoc.IDocInfo.DeleteDocInfo

    End Sub

    Public ReadOnly Property IsUseFlow() As Boolean Implements eWorkFlow.eFlowDoc.IDocInfo.IsUseFlow
        Get
            Return True
        End Get
    End Property

    Public Sub LeaveDocInfo() Implements eWorkFlow.eFlowDoc.IDocInfo.LeaveDocInfo
        If CtlWFActionList1.OnlySave Then
            Dim ReturnURL As String = "../Quotation/ReportDetailDetail.aspx?" & Global_asax.QUERY_APPLICANTIDX & "=" + PKID.ToString
            If (DocUniqueID <> String.Empty AndAlso DocUniqueID <> Guid.Empty.ToString) Then
                ReturnURL = ReturnURL + "&" + Global_asax.QUERY_DOCUNIQUEID + "=" + DocUniqueID
            End If
            Response.Redirect(ReturnURL)
        Else
            If UserInfo.IsInRoles("EXTERNALWORKER") OrElse CurType <> 0 Then
                Response.Redirect("../Quotation/ReportDetailList.aspx?Type=" + CurType.ToString)
            Else
                Response.Redirect("../index.aspx")
            End If
        End If
    End Sub

    Public Sub LoadDocInfo(ByVal CurDocInfo As eWorkFlow.eFlowDoc.DocInfoSystem) Implements eWorkFlow.eFlowDoc.IDocInfo.LoadDocInfo
        If (CurDocInfo.CurStateOrder = 3 OrElse CurDocInfo.CurStateOrder = 1) AndAlso CtlWFActionList1.InRoles Then
            Me.UcFileDetail2.CanUpload = True
            Me.UcFileDetail2.CanRemove = True
        End If

        If CurDocInfo.CurStateOrder = 1 AndAlso CtlWFActionList1.InRoles Then
            Me.quoinvalid.Visible = True
            Dim isexception As String = String.Empty
            Dim ds As DataSet = SqlHelper.ExecuteDataset(ConfigurationInfo.ConnectionString, "GetisExceprionByQuotationpkid", QuotationPKID)
            If ds.Tables(0).Rows.Count > 0 Then
                isexception = ds.Tables(0).Rows(0).Item("status").ToString
                If isexception <> 3 Then
                    Me.CtlWFActionList1.Visible = False
                    Me.quoinvalid.Visible = False
                End If
            End If
            Me.HidCanAdd.Value = "1"
            'Me.UcFileDetail5.CanUpload = True
            'Me.UcFileDetail5.CanRemove = True
        End If
        If CurDocInfo.CurStateOrder = 4 AndAlso Me.CtlWFActionList1.InRoles Then
            Me.LbIsSendMail.Visible = True
            Me.RdoInsendmail.Visible = True

        End If
        If CtlWFActionList1.InRoles Then
            Me.UcFileDetail4.CanRemove = True
            Me.UcFileDetail4.CanUpload = True
        End If
        CtlWFActionList1.CurURL = String.Format("{0}?PageType=report", Global_asax.URL_INDEX)  '往框架中跳
    End Sub

    Public Sub SaveDocInfo(ByVal CurDocInfo As eWorkFlow.eFlowDoc.DocInfoSystem, ByVal CommandName As Platform.eWorkFlow.Model.Enm_ActionType) Implements eWorkFlow.eFlowDoc.IDocInfo.SaveDocInfo
        DocUniqueID = CurDocInfo.DocUniqueID
        ReportDetail.PKID = PKID
        ReportDetail.eFlowDocID = New Guid(CurDocInfo.DocUniqueID)

        Dim ReportDal As ReportDetailDAL = New ReportDetailDAL(ReportDetail)
        ReportDal.Save()

        If Not CurTestRemark Is Nothing Then
            If Me.TxtTestRemark.Text <> CurTestRemark.TestRemark Then
                CurTestRemark.TestRemark = Me.TxtTestRemark.Text
                CurTestRemark.Extend1 += "變更人：" + UserInfo.CurrentUserCHName + " &nbsp;時間：" + DateTime.Now.ToShortDateString + ","
                Dim curtestdal As QuoTestRemarkDAL = New QuoTestRemarkDAL(CurTestRemark)
                curtestdal.Save()
            End If
        End If
        Me.UcFileDetail1.ParentID = QuotationPKID
        Me.UcFileDetail1.SaveDatatoDataBase()
        Me.UcFileDetail4.SaveDatatoDataBase()
        If CurDocInfo.CurStateOrder = 3 OrElse CurDocInfo.CurStateOrder = 1 Then
            Me.UcFileDetail2.ParentID = PKID
            Me.UcFileDetail2.SaveDatatoDataBase()
        End If
        If CurDocInfo.CurStateOrder = 1 Then
            'Me.UcFileDetail5.ParentID = QuotationPKID
            'Me.UcFileDetail5.SaveDatatoDataBase()

            Dim rpi As RepeaterItem
            Dim LbServiceType As Label
            Dim TxtTestNo As TextBox
            For Each rpi In Repeater1.Items
                LbServiceType = rpi.FindControl("LbTestItem")
                TxtTestNo = rpi.FindControl("TxtTestNo")
                If TxtTestNo.Text <> String.Empty Then
                    TestItemDetailDAL.UpTestNoByQuotationPKIDandServicetype(QuotationPKID, LbServiceType.Text, TxtTestNo.Text)
                End If
            Next

        End If

    End Sub

    Public ReadOnly Property TemplateName() As String Implements eWorkFlow.eFlowDoc.IDocInfo.TemplateName
        Get
            Return "CRM報告處理流程"
        End Get
    End Property

    Public ReadOnly Property TemplateVersion() As Integer Implements eWorkFlow.eFlowDoc.IDocInfo.TemplateVersion
        Get
            Return 1
        End Get
    End Property
#End Region
#Region "ActionList"

    Private Sub CtlWFActionList1_Postopen(ByVal CurDocInfo As eWorkFlow.eFlowDoc.DocInfoSystem, ByVal e As eWorkFlow.eFlowDoc.BaseEventArgs) Handles CtlWFActionList1.Postopen
        If CurDocInfo.CurStateOrder = 1 Then
            Dim SaveScript As StringBuilder = New StringBuilder()
            SaveScript.Append(" var index = 1;var tabtestbh = document.getElementById('tabletestno');var inputs = tabtestbh.getElementsByTagName('input');for (var i = 0; i < inputs.length; i++) {if (inputs[i].type == 'text') {if ($.trim(inputs[i].value) == '') {alert('請先維護測試編號！');return false; }  } }    ")
            CtlWFActionList1.AduitScript = SaveScript.ToString

        End If
    End Sub

    Private Sub CtlWFActionList1_Postsave(ByVal CurDocInfo As eWorkFlow.eFlowDoc.DocInfoSystem, ByVal e As eWorkFlow.eFlowDoc.PostSaveDocEventArgs) Handles CtlWFActionList1.Postsave
        If e.CommandName = Platform.eWorkFlow.Model.Enm_ActionType.Finish Then
            If Me.HiddenTypeofPay.Value = 1 AndAlso Me.HiddenTestCategory.Value = 0 Then
                QuotationDAL.UpdateFinishTimeByPKID(QuotationPKID)
            End If
            If Me.RdoInsendmail.SelectedValue = "1" Then


                Dim mailaddress As String = QuotationInfo.ContactEmail
                Dim title As String = String.Format("华南检测中心({0})：您有一份报告待下载", ConfigurationManager.AppSettings("CQ"))
                Dim info As String = String.Format("尊敬的客户︰</br>您好！您在 {0}(时间)测试及报告已完成，报告详情请点击下方链接下载！(帳號為申請者郵箱，初始密碼為password)</br> 以上为系统自动发送邮件, 请勿直接回复!</br><a href='http://cmc.foxconn.com/crm/Default.aspx?PageType=report&eFlowDocID={1}", QuotationInfo.RecordCreated.ToShortDateString, ReportDetail.eFlowDocID) + "'>点此进入查看</a>"
                info += String.Format("</br>账号：{0}，初始密码为password", QuotationInfo.Extend01)
                info += String.Format("</br>扫描下方二维码关注CMC微信官方号</br><img src ='http://cmc.foxconn.com/crm/Images/CMCer.JPG' width='200px' />")
                Try
                    OtherSendOutMail.SendOutMail(mailaddress, title, info, Nothing)
                    Dim cursengmailinfo As SendOutMailLogInfo = New SendOutMailLogInfo()
                    cursengmailinfo.pkid = 0
                    cursengmailinfo.ParentID = PKID
                    cursengmailinfo.ParentType = 2
                    cursengmailinfo.CurrentUserSID = UserInfo.CurrentUserID
                    cursengmailinfo.MailAddress = mailaddress
                    cursengmailinfo.MailContent = info
                    cursengmailinfo.MailTitle = title
                    cursengmailinfo.RecordCreated = DateTime.Now
                    cursengmailinfo.RecordDeleted = 0
                    cursengmailinfo.Remark = "通知客戶下載報告"
                    Dim cursendmaildal As SendOutMailLogDAL = New SendOutMailLogDAL(cursengmailinfo)
                    cursendmaildal.Save()
                Catch ex As Exception

                End Try

            End If

        End If
    End Sub
    Private Sub CtlWFActionList1_Querysave(ByVal CurDocInfo As eWorkFlow.eFlowDoc.DocInfoSystem, ByVal e As eWorkFlow.eFlowDoc.QuerySaveDocEventArgs) Handles CtlWFActionList1.Querysave
        If e.CommandName = Platform.eWorkFlow.Model.Enm_ActionType.Approve _
         OrElse e.CommandName = Platform.eWorkFlow.Model.Enm_ActionType.Rejection _
         OrElse e.CommandName = Platform.eWorkFlow.Model.Enm_ActionType.Revoke _
         OrElse e.CommandName = Platform.eWorkFlow.Model.Enm_ActionType.Finish Then
            ReportDetail.StateName = CurDocInfo.NextStateName
            ReportDetail.StateOrder = CurDocInfo.NextStateOrder
        Else
            ReportDetail.StateName = CurDocInfo.CurStateName
            ReportDetail.StateOrder = CurDocInfo.CurStateOrder
        End If
        If e.CommandName = Platform.eWorkFlow.Model.Enm_ActionType.Finish Then
            'QuotationInfo.FinishTime = DateTime.Now
            'Dim quodal As QuotationDAL = New QuotationDAL(QuotationInfo)
            'quodal.Save()
            ReportDetail.IsFinished = 1
            ReportDetail.FinishTime = DateTime.Now
        End If
        If CurDocInfo.NextStateName = "待發送報告狀態" Then
            ReportDetail.Extend02 = DateTime.Now.ToString
        ElseIf CurDocInfo.NextStateName = "待確認收款狀態" Then
            ReportDetail.Extend03 = DateTime.Now.ToString

        End If
        If CurDocInfo.CurStateOrder = 1 AndAlso e.CommandName = Platform.eWorkFlow.Model.Enm_ActionType.Approve Then
            ReportDetail.Extend08 = DateTime.Now.ToShortDateString
        End If
    End Sub
#End Region

    Protected Sub LinkQuotation_Click(ByVal sender As Object, ByVal e As EventArgs) Handles LinkQuotation.Click
        Dim url As String = String.Format("../Quotation/QuotationDetail.aspx?PKID={0}&eFlowDocID={1}", QuotationInfo.PKID.ToString, QuotationInfo.eFlowDocID)
        Response.Redirect(url)
    End Sub

    Protected Sub LinkSendsample_Click(ByVal sender As Object, ByVal e As EventArgs) Handles LinkSendsample.Click
        ReportDetailDAL.UPsendsample(PKID)
        If Not CurType Is Nothing Then
            Response.Redirect("../Quotation/ReportDetailList.aspx?Type=" + CurType.ToString)
        Else
            Response.Redirect("../Quotation/ReportDetailList.aspx")
        End If
    End Sub

    Protected Sub LinkDoinvoice_Click(ByVal sender As Object, ByVal e As EventArgs) Handles LinkDoinvoice.Click
        ReportDetailDAL.UPdoinvoice(PKID)
        If Me.HiddenTypeofPay.Value = "1" Then     '預付款客戶 
            QuotationInfo.FinishTime = DateTime.Now
            Dim quodal As QuotationDAL = New QuotationDAL(QuotationInfo)
            quodal.Save()
        End If
        If Not CurType Is Nothing Then
            Response.Redirect("../Quotation/ReportDetailList.aspx?Type=" + CurType.ToString)
        Else
            Response.Redirect("../Quotation/ReportDetailList.aspx")
        End If
    End Sub

    Protected Sub LinkSendinvoice_Click(ByVal sender As Object, ByVal e As EventArgs) Handles LinkSendinvoice.Click
        ReportDetailDAL.UPsendinvoice(PKID)
        If Not CurType Is Nothing Then
            Response.Redirect("../Quotation/ReportDetailList.aspx?Type=" + CurType.ToString)
        Else
            Response.Redirect("../Quotation/ReportDetailList.aspx")
        End If
    End Sub

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button1.Click
        Response.Redirect("../Quotation/ReportDetailList.aspx?Type=" + CurType.ToString)
    End Sub
    Private Sub BindGrid2()
        Dim TotalRecord As Integer = 0
        Dim ds As DataSet = SqlHelper.ExecuteDataset(ConfigurationInfo.ConnectionString, "GetTestApplyInfoByQuotationPKID", QuotationPKID)
        If ds Is Nothing Then
            Me.GridView2.DataSource = Nothing
            Me.GridView2.DataBind()
        Else
            Me.GridView2.DataSource = ds
            Me.GridView2.DataKeyNames = New String() {"ApplyPKID"}
            Me.GridView2.DataBind()
        End If
    End Sub
    Protected Sub GridView2_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GridView2.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            If e.Row.RowState = DataControlRowState.Normal OrElse e.Row.RowState = DataControlRowState.Alternate Then

                Dim mPKID As Integer = CInt(CType(e.Row.FindControl("lbPKID"), Label).Text)
                Dim HLDetail As HyperLink = CType(e.Row.FindControl("HLDetail"), HyperLink)
                Dim DocUniqueID As String = CType(e.Row.FindControl("lblDocUniqueID"), Label).Text
                Dim ReturnURL As String
                If ConfigurationManager.AppSettings("CQ") = "NN" Then
                    ReturnURL = Global_asax.UrlHost + "/NNTAM/Frameset/Index.aspx?PageType=apply"
                ElseIf ConfigurationManager.AppSettings("CQ") = "WH" Then
                    ReturnURL = Global_asax.UrlHost + "/TESTAPPLYMANAGE/Frameset/Index.aspx?PageType=apply"
                Else
                    ReturnURL = Global_asax.UrlHost + "/TAM/Frameset/Index.aspx?PageType=apply"
                End If

                ReturnURL += "&applypkid=" + mPKID.ToString
                If (DocUniqueID <> String.Empty AndAlso DocUniqueID <> Guid.Empty.ToString) Then
                    ReturnURL = ReturnURL + "&" + Global_asax.QUERY_DOCUNIQUEID + "=" + DocUniqueID
                End If
                HLDetail.Target = "_blank"
                HLDetail.NavigateUrl = ReturnURL
                If e.Row.Cells(5).Text.Length > 20 Then
                    e.Row.Cells(5).ToolTip = e.Row.Cells(5).Text
                    e.Row.Cells(5).Text = e.Row.Cells(5).Text.Substring(0, 20) + "..."
                End If
                If e.Row.Cells(2).Text.Length > 20 Then
                    e.Row.Cells(2).ToolTip = e.Row.Cells(2).Text
                    e.Row.Cells(2).Text = e.Row.Cells(2).Text.Substring(0, 20) + "..."
                End If
                If e.Row.Cells(1).Text = "待送審" Then
                    e.Row.BackColor = System.Drawing.Color.Gray
                    e.Row.ForeColor = System.Drawing.Color.White
                End If
            End If
        End If
    End Sub

    Protected Sub BtnUptec_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BtnUptec.Click

        QuotationInfo.Extend10 = Me.HiddenTecSupport.Value
        Dim quodal As QuotationDAL = New QuotationDAL(QuotationInfo)
        quodal.Save()

        Dim emailaddress As String = AccountManage.LoadAccountInfoByUserSID(QuotationInfo.Extend10).Email1
        Dim title As String = String.Format("CRM系統有一份報價單(報價單號：{0})指定您為技術客服，請處理({1})", QuotationInfo.QuotationNO, Me.DPLtecsupport.SelectedItem.Text)
        Dim info As String = title + "</br><a href='" + Global_asax.UrlBase + String.Format("/Default.aspx?PageType=report&pkid={0}", PKID.ToString) + "'>點此進入查看</a>"
        QuotationInvoid.SendMail(emailaddress, title, info)
        Me.LBinfo.Text = "重新指派并發郵件成功！"

    End Sub

    Protected Sub BtnUpTestNO_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BtnUpTestNO.Click
        Dim rpi As RepeaterItem
        Dim LbServiceType As Label
        Dim TxtTestNo As TextBox
        For Each rpi In Repeater1.Items
            LbServiceType = rpi.FindControl("LbTestItem")
            TxtTestNo = rpi.FindControl("TxtTestNo")
            If TxtTestNo.Text <> String.Empty Then
                TestItemDetailDAL.UpTestNoByQuotationPKIDandServicetype(QuotationPKID, LbServiceType.Text, TxtTestNo.Text)
            End If
        Next
    End Sub

    Protected Sub LinkDirect_Click(ByVal sender As Object, ByVal e As EventArgs) Handles LinkDirect.Click
        ReportDetail.RecordDeleted = 0
        Dim ReportDal As ReportDetailDAL = New ReportDetailDAL(ReportDetail)
        ReportDal.Save()
        Dim ReturnURL As String = "../Quotation/ReportDetailDetail.aspx?" & Global_asax.QUERY_APPLICANTIDX & "=" + PKID.ToString
        If (DocUniqueID <> String.Empty AndAlso DocUniqueID <> Guid.Empty.ToString) Then
            ReturnURL = ReturnURL + "&" + Global_asax.QUERY_DOCUNIQUEID + "=" + DocUniqueID
        End If
        Response.Redirect(ReturnURL)
    End Sub

    Private Sub ImageTestDown_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImageTestDown.Click

        Dim array_FileId As String() = Me.HidFileID.Value.Split(",")
        If array_FileId.Length > 1 Then
            Dim loadendentity As New DownLoadZip
            loadendentity.FileID = array_FileId
            If loadendentity.CreatZIP() Then
                downFileMore(loadendentity.Memory)
            End If

        Else
            If Not Me.HidFileID.Value = String.Empty Then
                Dim FileID As Integer = CInt(Me.HidFileID.Value)
                Dim mFIleInfo As WF_AttachFileInfoInfo = WF_AttachFileInfoDAL.GetInfoByPKID(FileID)
                If mFIleInfo IsNot Nothing Then
                    If mFIleInfo.FileContent IsNot Nothing AndAlso mFIleInfo.FileContent.Length > 0 Then
                        Dim iStream As System.IO.Stream = New MemoryStream(mFIleInfo.FileContent)
                        FileDownload(HidFileName.Value, mFIleInfo.FileContent.Length, iStream)
                    End If

                End If
            End If
        End If
    End Sub

    Protected Sub BtnDownLoadInit(ByVal sender As Object, ByVal e As EventArgs)
        Dim ScriptManager1 As ScriptManager
        If Me.Page.Master Is Nothing Then
            ScriptManager1 = DirectCast(Me.Page.FindControl("ScriptManager1"), ScriptManager)
        Else
            ScriptManager1 = DirectCast(Me.Page.Master.FindControl("ScriptManager1"), ScriptManager)
        End If
        ScriptManager1.RegisterPostBackControl(CType(sender, Control))

    End Sub
    Private Sub FileDownload(ByVal strFileName As String, ByVal iStream As Stream)
        If strFileName <> "" Then
            With Page.Response
                .Clear()
                .ClearHeaders()
                .Buffer = False
                .ContentType = "application/octet-stream"""
                .ContentEncoding = System.Text.Encoding.GetEncoding("UTF-8")

                Page.Response.AddHeader("content-disposition", "attachment;filename=" & HttpUtility.UrlEncode(strFileName, System.Text.Encoding.UTF8))
                Response.AppendHeader("Content-Length", iStream.Length)
                Dim buffer(10000) As Byte

                Dim length As Integer

                Dim dataToRead As Long

                Try
                    dataToRead = iStream.Length

                    While dataToRead > 0
                        If Response.IsClientConnected Then
                            length = iStream.Read(buffer, 0, 10000)

                            Response.OutputStream.Write(buffer, 0, length)

                            Response.Flush() ' Clear the buffer

                            ReDim buffer(10000)
                            dataToRead = dataToRead - length
                        Else
                            dataToRead = -1
                        End If
                    End While




                Catch ex As Exception
                    ' Response.Write("Error : " & ex.Message)
                Finally
                    If IsNothing(iStream) = False Then
                        iStream.Close()
                    End If
                End Try

                ' .Flush()
                .End()
                Me.HidFileID.Value = String.Empty

            End With
        End If
    End Sub
    Private Sub downFileMore(ByVal memory As MemoryStream)
        Dim NewFileName As String = "MyReport.zip"
        Try
            Page.Response.ContentType = "application/zip"
            Page.Response.AppendHeader("Content-Disposition", "attachment;   filename=" + Page.Server.UrlPathEncode(NewFileName))
            memory.WriteTo(Response.OutputStream)
            memory.Close()
        Catch ex As Exception
            Response.Write(ex.Message)
        End Try
    End Sub
    Private Sub FileDownload(ByVal strFileName As String, ByVal FileSize As Double, ByVal iStream As Stream)
        If strFileName <> "" Then
            With Page.Response
                .Clear()
                .ClearHeaders()
                .Buffer = False
                .ContentType = "application/octet-stream"""
                .ContentEncoding = System.Text.Encoding.GetEncoding("UTF-8")

                Page.Response.AddHeader("content-disposition", "attachment;filename=" & HttpUtility.UrlEncode(strFileName, System.Text.Encoding.UTF8))
                Response.AppendHeader("Content-Length", FileSize.ToString())
                Dim buffer(10000) As Byte

                Dim length As Integer

                Dim dataToRead As Long

                Try
                    dataToRead = iStream.Length

                    While dataToRead > 0
                        If Response.IsClientConnected Then
                            length = iStream.Read(buffer, 0, 10000)

                            Response.OutputStream.Write(buffer, 0, length)

                            Response.Flush() ' Clear the buffer

                            ReDim buffer(10000)
                            dataToRead = dataToRead - length
                        Else
                            dataToRead = -1
                        End If
                    End While

                Catch ex As Exception
                    Response.Write("Error : " & ex.Message)
                Finally
                    If IsNothing(iStream) = False Then
                        iStream.Close()
                    End If
                End Try

                .End()

            End With
        End If
    End Sub
    <WebMethod()> _
  Public Shared Sub DeleteFile(ByVal FileID As Integer)
        WF_AttachFileInfoDAL.Delete(FileID)
    End Sub
End Class
