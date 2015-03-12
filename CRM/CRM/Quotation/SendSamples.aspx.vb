Imports Platform.eAuthorize

Partial Public Class SendSamples
    Inherits System.Web.UI.Page
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
    Private _CurCustomerinfo As CustomersInfo
    Private Property CurCustomerinfo() As CustomersInfo
        Get
            If _CurCustomerinfo Is Nothing Then
                If Not QuotationInfo Is Nothing Then
                    _CurCustomerinfo = CustomersDAL.GetInfoByPKID(QuotationInfo.CustomerPKID)
                End If
            End If
            Return _CurCustomerinfo
        End Get
        Set(ByVal value As CustomersInfo)
            _CurCustomerinfo = value
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
        End If
    End Sub
    Private Sub GetParam()
        If Not Request.QueryString("PKID") Is Nothing Then
            PKID = Convert.ToInt32(Request.QueryString("PKID"))
        End If
        If Not Request.QueryString("Type") Is Nothing Then
            CurType = Convert.ToInt32(Request.QueryString("Type"))
        End If
    End Sub
    Private Sub BindControlData()
        If Not ReportDetail Is Nothing Then
            If PKID <> 0 Then
                Me.LbCustomer.Text = QuotationInfo.CustomerName
                Me.LbAddress.Text = CurCustomerinfo.Address
                Me.LbContact.Text = QuotationInfo.ContactName
                Me.LbEmail.Text = QuotationInfo.ContactEmail
                Me.LbQuotationNo.Text = QuotationInfo.QuotationNO
                Me.LbQuoter.Text = QuotationInfo.QuotaerName
                Dim sampleandtestno(2) As String
                sampleandtestno = TestItemDetailDAL.GetSamplesAndTestNoByQuotationPKID(QuotationPKID)
                If Not sampleandtestno Is Nothing Then
                    Me.LbSamples.Text = sampleandtestno(0)
                    Me.LbTestNo.Text = sampleandtestno(1)
                End If
                Select Case CurType
                    Case "10"
                        Me.TxtSendinfo.Text = ReportDetail.Extend01
                    Case "20"
                        Me.TxtSendinfo.Text = ReportDetail.Extend02
                End Select
                If ReportDetail.Extend04 = "9999-12-31 23:59:59.997" Then
                    Me.BtnSendSamples.Visible = True
                Else
                    Me.LbSendSapleTimes.Visible = True
                    Me.LbSendSapleTimes.Text = "寄樣品時間：" + ReportDetail.Extend04
                End If
                If ReportDetail.Extend06 = "9999-12-31 23:59:59.997" AndAlso ReportDetail.Extend05 <> "9999-12-31 23:59:59.997" Then
                    Me.BtnSendFapiao.Visible = True
                ElseIf ReportDetail.Extend06 <> "9999-12-31 23:59:59.997" Then
                    Me.LbSendFapiaoTime.Visible = True
                    Me.LbSendFapiaoTime.Text = "寄發票時間：" + ReportDetail.Extend06
                End If
                If ReportDetail.Extend04 = "9999-12-31 23:59:59.997" AndAlso ReportDetail.Extend06 = "9999-12-31 23:59:59.997" AndAlso ReportDetail.Extend05 <> "9999-12-31 23:59:59.997" Then
                    Me.BtnSendAll.Visible = True
                End If
            End If
        End If
    End Sub

    Protected Sub BtnSendSamples_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BtnSendSamples.Click
        ReportDetail.Extend04 = DateTime.Now.ToLongDateString
        ReportDetail.Extend01 = Me.TxtSendinfo.Text
        Dim reportdal As ReportDetailDAL = New ReportDetailDAL(ReportDetail)
        reportdal.Save()
        If Me.ChbIsmailCus.Checked = True Then


            Try
                Dim maillist As String = Me.LbEmail.Text.Trim
                Dim Title As String = "华南检测中心：您的样品我中心已寄回，请注意查收"
                Dim info As String = String.Format("尊敬的客户：</br>您好！您的样品{0}我中心已寄回，请注意查收。</br>快递信息:{1}</br> 以上为系统自动发送邮件, 请勿直接回复!</br>", Me.LbSamples.Text, Me.TxtSendinfo.Text)

                OtherSendOutMail.SendOutMail(maillist, Title, info, Nothing)
                Dim cursengmailinfo As SendOutMailLogInfo = New SendOutMailLogInfo()
                cursengmailinfo.pkid = 0
                cursengmailinfo.ParentID = PKID
                cursengmailinfo.ParentType = 1
                cursengmailinfo.CurrentUserSID = UserInfo.CurrentUserID
                cursengmailinfo.MailAddress = maillist
                cursengmailinfo.MailContent = info
                cursengmailinfo.MailTitle = Title
                cursengmailinfo.RecordCreated = DateTime.Now
                cursengmailinfo.RecordDeleted = 0
                cursengmailinfo.Remark = "通知客戶已寄样品"
                Dim cursendmaildal As SendOutMailLogDAL = New SendOutMailLogDAL(cursengmailinfo)
                cursendmaildal.Save()

            Catch ex As Exception

            End Try
        End If
        Response.Redirect("../Quotation/SendSampleList.aspx?Type=1")
    End Sub

    Protected Sub BtnSendFapiao_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BtnSendFapiao.Click
        ReportDetail.Extend06 = DateTime.Now.ToLongDateString
        ReportDetail.Extend02 = Me.TxtSendinfo.Text
        Dim reportdal As ReportDetailDAL = New ReportDetailDAL(ReportDetail)
        reportdal.Save()
        If Me.ChbIsmailCus.Checked = True Then

            Try
                Dim maillist As String = Me.LbEmail.Text.Trim
                Dim Title As String = "华南检测中心：您的发票我中心已寄回，请注意查收"
                Dim info As String = String.Format("尊敬的客户：</br>您好！您在我中心所做测试(报价单号：{0})的发票我中心已寄回，请注意查收。</br>快递信息:{1}</br> 以上为系统自动发送邮件, 请勿直接回复!</br>", QuotationInfo.QuotationNO, Me.TxtSendinfo.Text)

                OtherSendOutMail.SendOutMail(maillist, Title, info, Nothing)
                Dim cursengmailinfo As SendOutMailLogInfo = New SendOutMailLogInfo()
                cursengmailinfo.pkid = 0
                cursengmailinfo.ParentID = PKID
                cursengmailinfo.ParentType = 1
                cursengmailinfo.CurrentUserSID = UserInfo.CurrentUserID
                cursengmailinfo.MailAddress = maillist
                cursengmailinfo.MailContent = info
                cursengmailinfo.MailTitle = Title
                cursengmailinfo.RecordCreated = DateTime.Now
                cursengmailinfo.RecordDeleted = 0
                cursengmailinfo.Remark = "通知客戶已寄发票"
                Dim cursendmaildal As SendOutMailLogDAL = New SendOutMailLogDAL(cursengmailinfo)
                cursendmaildal.Save()

            Catch ex As Exception

            End Try
        End If
        Response.Redirect("../Quotation/SendSampleList.aspx?Type=2")
    End Sub

    Protected Sub BtnSendAll_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BtnSendAll.Click
        ReportDetail.Extend06 = DateTime.Now.ToLongDateString
        ReportDetail.Extend04 = DateTime.Now.ToLongDateString
        ReportDetail.Extend01 = Me.TxtSendinfo.Text
        ReportDetail.Extend02 = Me.TxtSendinfo.Text
        Dim reportdal As ReportDetailDAL = New ReportDetailDAL(ReportDetail)
        reportdal.Save()
        If Me.ChbIsmailCus.Checked = True Then

            Try
                Dim maillist As String = Me.LbEmail.Text.Trim
                Dim Title As String = "华南检测中心：您的样品和发票我中心已寄回，请注意查收"
                Dim info As String = String.Format("尊敬的客户：</br>您好！您在我中心所做测试(报价单号：{0})的发票和样品我中心已寄回，请注意查收。</br>快递信息:{1}</br> 以上为系统自动发送邮件, 请勿直接回复!</br>", QuotationInfo.QuotationNO, Me.TxtSendinfo.Text)

                OtherSendOutMail.SendOutMail(maillist, Title, info, Nothing)
                Dim cursengmailinfo As SendOutMailLogInfo = New SendOutMailLogInfo()
                cursengmailinfo.pkid = 0
                cursengmailinfo.ParentID = PKID
                cursengmailinfo.ParentType = 1
                cursengmailinfo.CurrentUserSID = UserInfo.CurrentUserID
                cursengmailinfo.MailAddress = maillist
                cursengmailinfo.MailContent = info
                cursengmailinfo.MailTitle = Title
                cursengmailinfo.RecordCreated = DateTime.Now
                cursengmailinfo.RecordDeleted = 0
                cursengmailinfo.Remark = "通知客戶已寄发票样品"
                Dim cursendmaildal As SendOutMailLogDAL = New SendOutMailLogDAL(cursengmailinfo)
                cursendmaildal.Save()

            Catch ex As Exception

            End Try
        End If
        Response.Redirect("../Quotation/SendSampleList.aspx?Type=1")
    End Sub
End Class