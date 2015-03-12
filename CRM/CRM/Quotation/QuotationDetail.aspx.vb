Imports System.Web.Services
Imports Platform.eAuthorize
Imports System.Xml
Imports eWorkFlow.eFlowDoc
Imports System.Transactions
Imports Platform.eHR.Core
Imports System.IO
Imports CRM.PDFSignservice

Partial Public Class QuotationDetail
    Inherits System.Web.UI.Page
    Implements IDocInfo

#Region "Const"
    Private Const HIDE_APPLICANTIDX_KEY As String = "ViewState:PKID"
    Private Const HIDE_DOCUNIQUEID_KEY As String = "ViewState:DocUniqueID"
    Private Const _RequestType As String = "ViewState:Type"
    Private Const _SearchConditon As String = "ViewState:SearchConditon"
    Private Const HIDE_SORTFIELD As String = "ViewState:SortField"
    Private Const HIDE_SortOrder As String = "ViewState:SortOrder"
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
    Private Property CustomerPKID() As Integer
        Get
            If ViewState("CustomerPKID") Is Nothing Then
                Return 0
            End If

            Return Convert.ToInt32(ViewState("CustomerPKID"))
        End Get
        Set(ByVal Value As Integer)
            ViewState("CustomerPKID") = Value
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
                If PKID <> 0 Then
                    _QuotationInfo = QuotationDAL.GetInfoByPKID(PKID)
                    Me.HiddenPKID.Value = _QuotationInfo.PKID
                ElseIf DocUniqueID <> String.Empty Then
                    _QuotationInfo = QuotationDAL.GetInfoByeFLowdocID(DocUniqueID)
                    PKID = _QuotationInfo.PKID
                    Me.HiddenPKID.Value = _QuotationInfo.PKID
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
            If ViewState(_RequestType) Is Nothing Then
                Return "0"
            End If
            Return CStr(ViewState(_RequestType))
        End Get
        Set(ByVal Value As String)
            ViewState(_RequestType) = Value
        End Set
    End Property
    Private ReadOnly Property InitSearch() As String
        Get
            If ViewState("InitSearch") IsNot Nothing Then
                Return CStr(ViewState("InitSearch"))
            Else
                Dim SearchCondition As String = String.Empty
                SearchCondition = " CustomerPKID='" + Me.HiddenCustomerPKID.Value + "'"
                Return SearchCondition
            End If
        End Get

    End Property

    Private ReadOnly Property SearchCondition() As String
        Get
            If ViewState("SearchCondition") Is Nothing Then
                Return InitSearch
            Else
                Return ViewState("SearchCondition").ToString

            End If
        End Get
    End Property
    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' 排序字段
    ''' </summary>
    ''' <value></value>
    ''' <remarks>
    ''' </remarks>
    ''' -----------------------------------------------------------------------------
    Private Property SortField() As String
        Get
            If ViewState(HIDE_SORTFIELD) Is Nothing Then
                ViewState(HIDE_SORTFIELD) = "ServiceType, TestItemName"
                ViewState(HIDE_SortOrder) = "DESC"
            End If
            Return ViewState(HIDE_SORTFIELD).ToString
        End Get
        Set(ByVal Value As String)
            ViewState(HIDE_SORTFIELD) = Value
        End Set
    End Property

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' 排序方式
    ''' </summary>
    ''' <value></value>
    ''' <remarks>
    ''' </remarks>
    ''' -----------------------------------------------------------------------------
    Private Property SortOrder() As String
        Get
            If ViewState(HIDE_SortOrder) Is Nothing Then
                ViewState(HIDE_SortOrder) = "DESC"
            Else
            End If
            Return ViewState(HIDE_SortOrder).ToString.Trim
        End Get
        Set(ByVal Value As String)
            ViewState(HIDE_SortOrder) = Value
        End Set
    End Property
    Private Property IsHasJiaozhun() As Integer
        Get
            If ViewState("IsHasJiaozhun") Is Nothing Then
                Return 0
            End If
            Return CInt(ViewState("IsHasJiaozhun"))
        End Get
        Set(ByVal value As Integer)
            ViewState("IsHasJiaozhun") = value
        End Set
    End Property
    Private Property pageindex() As Integer
        Get
            If Not ViewState("Pageindex") Is Nothing Then
                Return CInt(ViewState("Pageindex"))
            End If
            Return 1
        End Get
        Set(ByVal value As Integer)
            ViewState("Pageindex") = value
        End Set
    End Property
    Private Property IsSign() As Boolean
        Get
            If Not ViewState("IsSign") Is Nothing Then
                Return CBool(ViewState("IsSign"))
            End If
            Return False
        End Get
        Set(ByVal value As Boolean)
            ViewState("IsSign") = value
        End Set
    End Property
#End Region
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            GetParam()
            Me.LinkGetPDF.OnClientClick = "ShowProgress(); "
            Me.TxtHopeFinishDate.Attributes.Add("onclick", "javascript:WdatePicker({isShowClear:false,startDate:'%y-%M-01',dateFmt:'yyyy-MM-dd'});")
            Me.TxtQuotationDate.Attributes.Add("onclick", "javascript:WdatePicker({isShowClear:false,startDate:'%y-%M-01',dateFmt:'yyyy-MM-dd'});")
            Me.TxtPaijia.Attributes.Add("readonly", True)
            Me.TxtHopeFinishDate.Attributes.Add("readonly", True)
            Me.TxtQuotationDate.Attributes.Add("readonly", True)
            Me.TxtQuotationNO.Attributes.Add("readonly", True)
            Me.TxtCustomerName.Attributes.Add("readonly", True)
            Me.TxtContactName.Attributes.Add("readonly", True)
            Me.TxtContactPhone.Attributes.Add("readonly", True)
            Me.TxtContactEmail.Attributes.Add("readonly", True)
            Me.TxtHopeFinishDate.Text = DateTime.Now.AddDays(14).ToShortDateString
            BindControlData()
            Me.UcFileDetail1.CanUpload = False
            Me.UcFileDetail1.CanRemove = False
            Me.UcFileDetail2.CanUpload = False
            Me.UcFileDetail2.CanRemove = False
            Me.UcFileDetail1.ParentID = PKID
            Me.UcFileDetail2.ParentID = PKID
            Me.UcFileDetail1.ParentCategory = 1
            Me.UcFileDetail2.ParentCategory = 1
            Me.UcFileDetail1.ParentSubCategory = 1
            Me.UcFileDetail2.ParentSubCategory = 2
            If UserInfo.IsInRoles("EXTERNALWORKER") Then
            ElseIf UserInfo.IsInRoles("CRM經管") OrElse UserInfo.IsInRoles("ZHONGXINZHUGUAN") OrElse UserInfo.IsInRoles("TEDINGSHENHE") OrElse UserInfo.IsInRoles("Yewuzhuguan") Then
                Me.HiddenIsLeader.Value = 1
            Else
                Me.HiddenIsCustomer.Value = 1
                Me.LbPaijia.Visible = False
                Me.TxtPaijia.Visible = False
                Me.Label3.Visible = False
                Me.LbYouhuibili.Visible = False
                Me.GridView1.Columns(4).Visible = False

            End If
            Me.TxtCondition.Attributes.Add("onclick", "if (this.value=='默認只顯示五天內記錄，搜尋可顯示更早數據') this.value='';")
        End If
    End Sub
    Private Sub GetParam()
        If Not Request.QueryString("PKID") Is Nothing Then
            PKID = Convert.ToInt32(Request.QueryString("PKID"))
            Me.HiddenPKID.Value = PKID
        End If
        If Not Request.QueryString(Global_asax.QUERY_DOCUNIQUEID) Is Nothing Then
            DocUniqueID = Request.QueryString(Global_asax.QUERY_DOCUNIQUEID)
        End If
        If Not Request.QueryString("Type") Is Nothing Then
            CurType = Convert.ToInt32(Request.QueryString("Type"))
        End If
        If Not Request.QueryString("CustomerPKID") Is Nothing Then
            CustomerPKID = Convert.ToInt32(Request.QueryString("CustomerPKID"))
        End If
        If Not Request.QueryString("pageindex") Is Nothing Then
            pageindex = CInt(Request.QueryString("pageindex"))
        End If
    End Sub

    Private Sub BindControlData()
        BindDiscountInfo()
        If Not Request.QueryString("C") Is Nothing Then
            PKID = QuotationDAL.CopyQuotation(PKID)
            Me.HiddenPKID.Value = PKID
        End If
        If Not QuotationInfo Is Nothing Then
            If PKID = 0 Then
                Me.HiddenQuoterID.Value = UserInfo.CurrentUserID
                Dim curquoterinfo As ContactInfo = ContactDAL.GetInfoByUserSID(UserInfo.CurrentUserID)
                If curquoterinfo.CusTomerPKID <> 0 Then
                    Me.HiddenQuoterFax.Value = curquoterinfo.Extend3

                    Me.TxtQuotationNO.Text = CustomersDAL.GetInfoByPKID(curquoterinfo.CusTomerPKID).City + DateTime.Now.ToString("yyMMdd") + "-??"

                    Me.TxtQuotationDate.Text = DateTime.Now.ToShortDateString()
                    Me.TxtQuotater.Text = curquoterinfo.UserName
                    Me.TxtQuotaterEmail.Text = curquoterinfo.Extend4
                    Me.TxtQuotaterPhone.Text = curquoterinfo.Extend1
                    If CustomerPKID <> 0 Then
                        Me.HiddenIsFast.Value = 1
                        Me.HiddenCustomerPKID.Value = CustomerPKID
                        Dim curcustomerinfo As CustomersInfo = CustomersDAL.GetInfoByPKID(CustomerPKID)
                        Me.TxtCustomerName.Text = curcustomerinfo.CustomerName

                        Me.LbCustomerGrade.Text = curcustomerinfo.Grade.Substring(1, 1) + "級"
                        If Me.LbCustomerGrade.Text = "1級" Then
                            Me.HiddenCurrentCan.Value = Me.HiddenOne.Value
                        ElseIf Me.LbCustomerGrade.Text = "2級" Then
                            Me.HiddenCurrentCan.Value = Me.HiddenTwo.Value
                        ElseIf Me.LbCustomerGrade.Text = "3級" Then
                            Me.HiddenCurrentCan.Value = Me.HiddenThree.Value
                        ElseIf Me.LbCustomerGrade.Text = "4級" Then
                            Me.HiddenCurrentCan.Value = Me.HiddenFour.Value
                        ElseIf Me.LbCustomerGrade.Text = "5級" Then
                            Me.HiddenCurrentCan.Value = Me.HiddenFive.Value
                        End If
                        Me.LbCusHistory.Text = QuotationDAL.GetHisByCustomerPKID(CustomerPKID)
                        If curcustomerinfo.TypeofPay = 1 Then
                            Me.LbTypeOfPay.Text = "預付款客戶"
                        ElseIf curcustomerinfo.TypeofPay = 2 Then
                            Me.LbTypeOfPay.Text = "月結客戶"
                        End If

                    End If
                Else

                    Page.RegisterStartupScript("xxx", "<script>alert('你還未填寫個人資料！'); window.location='../Forms/UserADVInfo.aspx';</script>")
                End If
            Else
                If UserInfo.IsInRoles("SYS_ADMINISTRATOR") OrElse UserInfo.IsInRoles("CRM經管") OrElse UserInfo.IsInRoles("ZHONGXINZHUGUAN") OrElse UserInfo.IsInRoles("TEDINGSHENHE") OrElse UserInfo.IsInRoles("Yewuzhuguan") OrElse UserInfo.IsInRoles("EXTERNALWORKER") OrElse UserInfo.CurrentUserID = QuotationInfo.Extend01 Then
                    Me.HiddenMinYOUhui.Value = QuotationInfo.Extend08
                    Me.RDOisneedFapiao.SelectedIndex = Me.RDOisneedFapiao.Items.IndexOf(Me.RDOisneedFapiao.Items.FindByValue(QuotationInfo.Extend07))
                    Me.HiddenQuotationPKID.Value = PKID

                    Dim CurQuoRemark As QuoTestRemarkInfo = QuoTestRemarkDAL.GetInfoByParentPKID(PKID)
                    Me.TxtTestRemark.Text = CurQuoRemark.TestRemark
                    Me.TxtCusRemark.Text = CurQuoRemark.Extend2

                    If CurType = 88 Then   '異常結案
                        Me.quotationinvalid.Visible = True
                        Dim quoinvalid As InvalidQuotationInfo = InvalidQuotationDAL.GetInfoByQuotationPKID(PKID)
                        Me.TxtReason.Text = quoinvalid.Reason
                        If Not UserInfo.IsInRoles("Yewuzhuguan") OrElse InvalidQuotationDAL.GetInfoByQuotationPKID(PKID).Status <> 1 Then
                            Me.Linkbohui.Visible = False
                            Me.LinkapproveQuoinvalid.Visible = False
                        End If
                    End If
                    Me.HiddenQuoterID.Value = QuotationInfo.Extend03
                    Me.HiddenContactFax.Value = QuotationInfo.Extend05
                    Me.HiddenQuoterFax.Value = QuotationInfo.Extend04
                    Dim reportdtail As ReportDetailInfo = ReportDetailDAL.GetInfoByQuotationPKID(PKID)
                    If Not reportdtail Is Nothing Then
                        Me.LinkReport.Visible = True
                    End If
                    Me.TxtContactEmail.Text = QuotationInfo.ContactEmail
                    Me.TxtQuotationNO.Text = QuotationInfo.QuotationNO
                    Me.TxtQuotationDate.Text = QuotationInfo.QuoteDate.ToShortDateString
                    Me.TxtQuotaterPhone.Text = QuotationInfo.QuotaerPhone
                    Me.TxtQuotaterEmail.Text = QuotationInfo.QuoteEmail
                    Me.TxtQuotater.Text = QuotationInfo.QuotaerName
                    Me.TxtPaijia.Text = QuotationInfo.Paijia
                    Me.TxtHopeFinishDate.Text = QuotationInfo.HopeFinishDATE.ToShortDateString
                    Me.TxtDangqiangzongjia.Text = QuotationInfo.Shijizongjia
                    Me.TxtCustomerName.Text = QuotationInfo.CustomerName
                    Me.TxtContactPhone.Text = QuotationInfo.ContactPhone
                    Me.TxtContactName.Text = QuotationInfo.ContactName
                    Me.HiddenContactEmail.Value = QuotationInfo.ContactEmail
                    Me.HiddenContactID.Value = QuotationInfo.Extend01
                    Me.HiddenContactName.Value = QuotationInfo.ContactName
                    Me.HiddenContactPhone.Value = QuotationInfo.ContactPhone
                    Me.HiddenCustomerName.Value = QuotationInfo.CustomerName
                    Me.HiddenCustomerPKID.Value = QuotationInfo.CustomerPKID
                    Me.HiddenPaijia.Value = QuotationInfo.Paijia
                    Me.HiddenShijibaojia.Value = QuotationInfo.Shijizongjia
                    Me.LbCusHistory.Text = QuotationDAL.GetHisByCustomerPKID(QuotationInfo.CustomerPKID)
                    Me.HiddenYouhuibili.Value = CInt(Me.HiddenShijibaojia.Value) / CInt(Me.HiddenPaijia.Value)
                    Me.LbYouhuibili.Text = (Convert.ToSingle(Me.HiddenYouhuibili.Value) * 100).ToString("0.00") + "%"
                    Dim curcustomerinfo As CustomersInfo = CustomersDAL.GetInfoByPKID(Me.HiddenCustomerPKID.Value)
                    'If QuotationInfo.TestNO <> "" Then
                    '    Dim ApplyPKID As String() = QuotationInfo.TestNO.Substring(0, QuotationInfo.TestNO.Length - 1).Split(",")
                    '    Me.DataList1.DataSource = ApplyPKID
                    '    Me.DataList1.DataBind()
                    'End If
                    Me.LbCustomerGrade.Text = curcustomerinfo.Grade.Substring(1, 1) + "級"
                    If curcustomerinfo.TypeofPay = 1 Then
                        Me.LbTypeOfPay.Text = "預付款客戶"
                    ElseIf curcustomerinfo.TypeofPay = 2 Then
                        Me.LbTypeOfPay.Text = "月結客戶"
                    End If
                    Me.RdoIsneedBack.SelectedIndex = Me.RdoIsneedBack.Items.IndexOf(Me.RdoIsneedBack.Items.FindByValue(QuotationInfo.Extend02))
                    Me.RdoTestCategory.SelectedIndex = QuotationInfo.TestCategory


                    If Me.LbCustomerGrade.Text = "1級" Then
                        Me.HiddenCurrentCan.Value = Me.HiddenOne.Value
                    ElseIf Me.LbCustomerGrade.Text = "2級" Then
                        Me.HiddenCurrentCan.Value = Me.HiddenTwo.Value
                    ElseIf Me.LbCustomerGrade.Text = "3級" Then
                        Me.HiddenCurrentCan.Value = Me.HiddenThree.Value
                    ElseIf Me.LbCustomerGrade.Text = "4級" Then
                        Me.HiddenCurrentCan.Value = Me.HiddenFour.Value
                    ElseIf Me.LbCustomerGrade.Text = "5級" Then
                        Me.HiddenCurrentCan.Value = Me.HiddenFive.Value
                    End If
                    Me.HiddenCB.Value = QuotationInfo.Extend06
                    If UserInfo.IsInRoles("Zhongxinzhuguan") OrElse UserInfo.IsInRoles("TEDINGSHENHE") OrElse UserInfo.IsInRoles("Yewuzhuguan") Then
                        Me.LbCB.Visible = True
                        Me.LbCBshow.Visible = True
                        Me.LbProfitShow.Visible = True
                        Me.LbPrifit.Visible = True
                        Me.LbCB.Text = QuotationInfo.Extend06
                        Me.LbPrifit.Text = ((QuotationInfo.Shijizongjia - CInt(QuotationInfo.Extend06)) / CInt(QuotationInfo.Shijizongjia) * 100).ToString("0.00") + "%"

                    End If
                Else    '客戶
                    Response.Write("<script>alert('您無權限訪問該頁面！'); window.location='../Index.aspx';</script>")

                End If
            End If

        End If



    End Sub
    Private Sub BindDiscountInfo()
        If UserInfo.IsInRoles("Zhongxinzhuguan") Then
            Dim curdiscountinfo As DiscountInfo = DiscountDAL.GetDiscountInfoByRoleName("Zhongxinzhuguan")
            Me.HiddenOne.Value = curdiscountinfo.One
            Me.HiddenTwo.Value = curdiscountinfo.Two
            Me.HiddenThree.Value = curdiscountinfo.Three
            Me.HiddenFour.Value = curdiscountinfo.Four
            Me.HiddenFive.Value = curdiscountinfo.Five
        ElseIf UserInfo.IsInRoles("TEDINGSHENHE") Then
            Dim curdiscountinfo As DiscountInfo = DiscountDAL.GetDiscountInfoByRoleName("TEDINGSHENHE")
            Me.HiddenOne.Value = curdiscountinfo.One
            Me.HiddenTwo.Value = curdiscountinfo.Two
            Me.HiddenThree.Value = curdiscountinfo.Three
            Me.HiddenFour.Value = curdiscountinfo.Four
            Me.HiddenFive.Value = curdiscountinfo.Five
        ElseIf UserInfo.IsInRoles("Yewuzhuguan") Then
            Dim curdiscountinfo As DiscountInfo = DiscountDAL.GetDiscountInfoByRoleName("Yewuzhuguan")
            Me.HiddenOne.Value = curdiscountinfo.One
            Me.HiddenTwo.Value = curdiscountinfo.Two
            Me.HiddenThree.Value = curdiscountinfo.Three
            Me.HiddenFour.Value = curdiscountinfo.Four
            Me.HiddenFive.Value = curdiscountinfo.Five
        ElseIf UserInfo.IsInRoles("EXTERNALWORKER ") Then
            Dim curdiscountinfo As DiscountInfo = DiscountDAL.GetDiscountInfoByRoleName("EXTERNALWORKER")
            Me.HiddenOne.Value = curdiscountinfo.One
            Me.HiddenTwo.Value = curdiscountinfo.Two
            Me.HiddenThree.Value = curdiscountinfo.Three
            Me.HiddenFour.Value = curdiscountinfo.Four
            Me.HiddenFive.Value = curdiscountinfo.Five
        End If
    End Sub
    Private Function GetQuotationNO() As String
        Dim QuotationNO As String = String.Empty
        'Dim doc As XmlDocument = New XmlDocument()
        'Dim xmlPath As String = ""
        'Dim genpath As String = Server.MapPath("~")


        'xmlPath = genpath + "\XMLData\SysSetting.xml"
        'doc.Load(xmlPath)
        'Dim nodeList As XmlNodeList = doc.SelectSingleNode("Dataset").ChildNodes
        'For Each xn As XmlNode In nodeList
        '    Select Case xn.Name
        '        Case "Complaininfo"
        '            Dim DH As String = xn.ChildNodes.ItemOf(0).InnerText
        '            Dim QH As String = xn.ChildNodes.ItemOf(1).InnerText
        '            Dim lsm As Integer = 0
        '            ' lsm = TableBMHDAL.GetMaxlsmbyCategory(DateTime.Now.ToString("yyMMdd")) + 1
        '            QuotationNO = DH + QH + DateTime.Now.ToString("yyMMdd") + "???" + New Random().Next.ToString.Substring(0, 5)
        '    End Select
        'Next
        Return QuotationNO
    End Function

#Region "WebMethod"
    <WebMethod()> _
   Public Shared Function GetMyCustomer() As List(Of DictionaryEntry)
        Dim mCustomerInfo As List(Of DictionaryEntry) = CustomersDAL.GetCustomerByPersonIncharge(StrConv(UserInfo.CurrentUserCHName, VbStrConv.SimplifiedChinese, 2052))
        Return mCustomerInfo
    End Function
    <WebMethod()> _
 Public Shared Sub Upfileclientname(ByVal filenewname As String, ByVal fileidint As Integer)
        SqlHelper.ExecuteNonQuery(ConfigurationInfo.ConnectionString, "WF_AttachFileinfo_Uprealname", filenewname, fileidint)
    End Sub
    <WebMethod()> _
  Public Shared Function GetAllTestService() As List(Of DictionaryEntry)
        Dim mTestService As List(Of DictionaryEntry) = TestItemManageDAL.GetAllServiceDic()
        Return mTestService
    End Function
    <WebMethod()> _
  Public Shared Function GetTestItemByServiceName(ByVal ServiceName As String) As List(Of DictionaryEntry)
        Dim mTestService As List(Of DictionaryEntry) = TestItemManageDAL.GetTestItemBySeviceName(ServiceName)
        Return mTestService
    End Function
    <WebMethod()> _
 Public Shared Function GetVIPTestItemByServiceName(ByVal ServiceName As String) As List(Of DictionaryEntry)
        Dim mTestService As List(Of DictionaryEntry) = TestItemManageDAL.GetVIPTestItemBySeviceName(ServiceName)
        Return mTestService
    End Function
    <WebMethod()> _
    Public Shared Function GetContactByCustomerPKID(ByVal CustomerPKID As Integer) As List(Of DictionaryEntry)
        Dim mContactInfo As List(Of DictionaryEntry) = ContactDAL.GetContactByCustomerPKID(CustomerPKID)
        Return mContactInfo
    End Function
    <WebMethod()> _
   Public Shared Function SaveQuotationInfo(ByVal mQuotation As QuotationInfo) As Integer

        mQuotation.StateOrder = 0
        mQuotation.PKID = 0
        mQuotation.eFlowDocID = Guid.Empty
        mQuotation.StateName = String.Empty
        mQuotation.IsFinished = 0
        mQuotation.RecordDeleted = 2 '未保存的臨時案件
        mQuotation.RecordCreated = DateTime.Now
        mQuotation.Shijizongjia = 0
        mQuotation.Paijia = 0
        mQuotation.Extend06 = 0


        Dim mQuoDal As QuotationDAL = New QuotationDAL(mQuotation)

        mQuoDal.Save()
        Return mQuotation.PKID

    End Function
    <WebMethod()> _
   Public Shared Sub DeleteTestItem(ByVal TestItemPKID As Integer)
        TestItemDetailDAL.Delete(TestItemPKID)
    End Sub
    <WebMethod()> _
  Public Shared Function GetCustomerHisByCustomerPKID(ByVal CustomerPKID As Integer) As String
        Return QuotationDAL.GetHisByCustomerPKID(CustomerPKID)

    End Function
    <WebMethod()> _
  Public Shared Sub DeleteSample(ByVal SamplePKID As Integer)
        SampleInfoDAL.Delete(SamplePKID)
    End Sub
    <WebMethod()> _
   Public Shared Function SaveSampleInfo(ByVal mSampleInfo As SampleInfoInfo) As Integer
        mSampleInfo.RecordCreated = DateTime.Now
        mSampleInfo.RecordDeleted = 0

        Dim mSampleDAo As SampleInfoDAL = New SampleInfoDAL(mSampleInfo)

        mSampleDAo.Save()
        Return mSampleInfo.PKID
    End Function
    <WebMethod()> _
    Public Shared Function SaveTestDetailInfo(ByVal mTestItemDetailInfo As TestItemDetailInfo) As Integer
        If mTestItemDetailInfo.PKID = 0 Then
            mTestItemDetailInfo.RecordCreated = DateTime.Now
        End If
        mTestItemDetailInfo.RecordDeleted = 0
        Dim mApplyDetailDAO As TestItemDetailDAL = New TestItemDetailDAL(mTestItemDetailInfo)
        mApplyDetailDAO.Save()
        Return mTestItemDetailInfo.PKID

    End Function
    <WebMethod()> _
  Public Shared Function SaveTaocanInfo(ByVal mTestItemDetailInfo As TestItemDetailInfo) As Integer
        If mTestItemDetailInfo.PKID = 0 Then
            mTestItemDetailInfo.RecordCreated = DateTime.Now
        End If
        mTestItemDetailInfo.RecordDeleted = 2
        Dim mApplyDetailDAO As TestItemDetailDAL = New TestItemDetailDAL(mTestItemDetailInfo)
        mApplyDetailDAO.Save()
        If mTestItemDetailInfo.TestItemPKID = -1 Then   'TODO 所有套餐")
            SqlHelper.ExecuteNonQuery(ConfigurationInfo.ConnectionString, "InsertRohs4", mTestItemDetailInfo.QuotationPKID, mTestItemDetailInfo.SamplePKID, mTestItemDetailInfo.Numbers, mTestItemDetailInfo.TestStandard)

        ElseIf mTestItemDetailInfo.TestItemPKID = -2 Then
            SqlHelper.ExecuteNonQuery(ConfigurationInfo.ConnectionString, "InsertRohs2", mTestItemDetailInfo.QuotationPKID, mTestItemDetailInfo.SamplePKID, mTestItemDetailInfo.Numbers, mTestItemDetailInfo.TestStandard)

        ElseIf mTestItemDetailInfo.TestItemPKID = -3 Then
            SqlHelper.ExecuteNonQuery(ConfigurationInfo.ConnectionString, "InsertRohs6", mTestItemDetailInfo.QuotationPKID, mTestItemDetailInfo.SamplePKID, mTestItemDetailInfo.Numbers, mTestItemDetailInfo.TestStandard)
        End If


        Return mTestItemDetailInfo.PKID
    End Function
    <WebMethod()> _
   Public Shared Function GetSumExpense(ByVal QuotationPKID As Integer) As String
        Return QuotationDAL.GetExpenseByQuotationPKID(QuotationPKID)
    End Function
#End Region
#Region "eFlowNet"
    Public ReadOnly Property BusniessName() As String Implements eWorkFlow.eFlowDoc.IDocInfo.BusniessName
        Get
            Return "CRM報價單到申請單流程"
        End Get
    End Property

    Public Sub DeleteDocInfo(ByVal CurDocInfo As eWorkFlow.eFlowDoc.DocInfoSystem, ByVal CommandName As Platform.eWorkFlow.Model.Enm_ActionType) Implements eWorkFlow.eFlowDoc.IDocInfo.DeleteDocInfo
        QuotationDAL.Delete(PKID)
    End Sub

    Public ReadOnly Property IsUseFlow() As Boolean Implements eWorkFlow.eFlowDoc.IDocInfo.IsUseFlow
        Get
            Return True
        End Get
    End Property

    Public Sub LeaveDocInfo() Implements eWorkFlow.eFlowDoc.IDocInfo.LeaveDocInfo
       
        If CtlWFActionList1.OnlySave Then
            Dim ReturnURL As String = "../Quotation/QuotationDetail.aspx?" & Global_asax.QUERY_APPLICANTIDX & "=" + Me.HiddenPKID.Value
            If (DocUniqueID <> String.Empty AndAlso DocUniqueID <> Guid.Empty.ToString) Then
                ReturnURL = ReturnURL + "&" + Global_asax.QUERY_DOCUNIQUEID + "=" + DocUniqueID
            End If
            Response.Redirect(ReturnURL)
        Else
            Dim tourl As String
            If UserInfo.IsInRoles("EXTERNALWORKER") OrElse CurType <> 0 Then
                tourl = "../Quotation/QuotationList.aspx?Type=" + CurType.ToString + "&pageindex=" + pageindex.ToString
            Else
                tourl = "../index.aspx"
            End If
            Me.Hiddentourl.Value = tourl
            If IsSign Then
                Dim FileID As String
                Dim ds As DataSet = WF_AttachFileInfoDAL.GetLastquotationclientname(PKID)
                If Not ds Is Nothing Then
                    Dim dt As DataTable = ds.Tables(0)
                    Dim dr As DataRow = dt.Rows(0)
                    Dim filename As String = dr.Item("FileClientName").ToString
                    Dim fileidint As Integer = CInt(dr.Item("fileid"))
                    Me.HiddenFileidINT.Value = fileidint
                    FileID = filename
                    Me.HiddenFileID.Value = FileID
                    Me.HiddenSignFile.Value = "LastSign"
                End If
                ScriptManager.RegisterStartupScript(Me.Page, Me.Page.GetType(), DateTime.Now.ToString(), "<script>eSignTest();</script>", False)
            Else
                ScriptManager.RegisterStartupScript(Me.Page, Me.Page.GetType(), DateTime.Now.ToString(), "<script>leavepage();</script>", False)
            End If
        End If
    End Sub

    Public Sub LoadDocInfo(ByVal CurDocInfo As eWorkFlow.eFlowDoc.DocInfoSystem) Implements eWorkFlow.eFlowDoc.IDocInfo.LoadDocInfo
        Me.HiddenStateorder.Value = CurDocInfo.CurStateOrder
        If CurDocInfo.CurStateOrder > 1 OrElse Not UserInfo.IsInRoles("EXTERNALWORKER") Then
            Me.HiddenCanAdd.Value = False
            Me.TxtHopeFinishDate.Attributes.Remove("onclick")
            Me.TxtQuotationDate.Attributes.Remove("onclick")
            Me.TxtDangqiangzongjia.Attributes.Add("readonly", True)
            Me.TxtQuotater.Attributes.Add("readonly", True)
            Me.TxtQuotaterPhone.Attributes.Add("readonly", True)
            Me.TxtQuotaterEmail.Attributes.Add("readonly", True)
            Me.RDOisneedFapiao.Enabled = False
            Me.RdoTestCategory.Enabled = False
            Me.RdoIsneedBack.Enabled = False
            If ConfigurationManager.AppSettings("CQ") = "SZ" AndAlso (CurDocInfo.CurStateOrder = 4 OrElse CurDocInfo.IsFinishFlag = True) Then
                Me.LbTecsuppry.Visible = True
                Me.DPLtecsupport.Visible = True
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
                If UserInfo.CurrentUserID.Trim.ToUpper = QuotationInfo.Extend01.Trim.ToUpper Then
                    CtlWFActionList1.DisplaySaveButton(True)
                End If

            End If
        End If
        If CurDocInfo.CurStateOrder > 1 Then
            If testhistory.Visible = False Then
                Me.testhistory.Visible = True
                Dim SearchCondition As String = InitSearch + " and RecordCreated >'" + DateTime.Now.AddDays(-5).ToShortDateString + "'"

                BindGrid1(SearchCondition)
            Else
                Me.testhistory.Visible = False
            End If
        End If
        If CurDocInfo.CurStateOrder = 1 AndAlso CtlWFActionList1.InRoles AndAlso PKID <> 0 Then
            Me.exceptionend.Visible = True
        End If
        If (CurDocInfo.CurStateOrder = 4 OrElse CurDocInfo.CurStateOrder = 1) AndAlso CtlWFActionList1.InRoles AndAlso PKID <> 0 Then           '客戶回傳報價單
            If CurType <> 88 Then
                Me.exceptionend.Visible = True
            End If
            Me.RdoTestCategory.Enabled = False
            Me.RdoIsneedBack.Enabled = False
            Me.UcFileDetail2.CanUpload = True
            Me.UcFileDetail2.CanEdit = True
            Me.UcFileDetail2.CanRemove = True
            Dim isException As String = String.Empty
            Dim ds As DataSet = SqlHelper.ExecuteDataset(ConfigurationInfo.ConnectionString, "GetisExceprionByQuotationpkid", PKID)
            If ds.Tables(0).Rows.Count > 0 Then
                isException = ds.Tables(0).Rows(0).Item("status").ToString
                If isException <> 3 Then
                    Me.CtlWFActionList1.Visible = False
                    Me.exceptionend.Visible = False
                End If
            End If
        ElseIf CurDocInfo.CurStateOrder = 2 AndAlso CtlWFActionList1.InRoles Then           '生成PDF
            If PKID <> 0 Then
                Me.LinkGetPDF.Attributes.Add("style", "display:inline")
            End If
            Me.RdoIsSendMail.Visible = True
            Me.LbIsSendMail.Visible = True
            Me.UcFileDetail1.CanUpload = True
            Me.UcFileDetail1.CanEdit = True
            Me.UcFileDetail1.CanRemove = True
        End If
        If CurDocInfo.CurStateOrder = 4 AndAlso Me.CtlWFActionList1.InRoles Then


            Me.BtnSendMail.Visible = True

        End If
        Me.CtlWFActionList1.DisplayDeleteButton(False)
        CtlWFActionList1.CurURL = String.Format("{0}?PageType=quotation", Global_asax.URL_INDEX)  '往框架中跳
    End Sub

    Public Sub SaveDocInfo(ByVal CurDocInfo As eWorkFlow.eFlowDoc.DocInfoSystem, ByVal CommandName As Platform.eWorkFlow.Model.Enm_ActionType) Implements eWorkFlow.eFlowDoc.IDocInfo.SaveDocInfo
        DocUniqueID = CurDocInfo.DocUniqueID
        QuotationInfo.PKID = Me.HiddenPKID.Value
        QuotationInfo.eFlowDocID = New Guid(CurDocInfo.DocUniqueID)
        QuotationInfo.ContactEmail = Me.HiddenContactEmail.Value
        QuotationInfo.ContactName = Me.HiddenContactName.Value
        QuotationInfo.ContactPhone = Me.HiddenContactPhone.Value
        QuotationInfo.CustomerName = Me.HiddenCustomerName.Value
        QuotationInfo.CustomerPKID = Me.HiddenCustomerPKID.Value
        QuotationInfo.HopeFinishDATE = Me.TxtHopeFinishDate.Text
        QuotationInfo.Paijia = Me.HiddenPaijia.Value
        QuotationInfo.QuotaerName = Me.TxtQuotater.Text
        QuotationInfo.QuotaerPhone = Me.TxtQuotaterPhone.Text
        QuotationInfo.QuoteDate = Me.TxtQuotationDate.Text
        QuotationInfo.QuoteEmail = Me.TxtQuotaterEmail.Text
        QuotationInfo.Shijizongjia = Me.HiddenShijibaojia.Value
        QuotationInfo.Extend01 = Me.HiddenContactID.Value.ToUpper
        If CurDocInfo.CurStateOrder = 1 Then
            QuotationInfo.Extend06 = Me.HiddenCB.Value
            QuotationInfo.Extend03 = UserInfo.CurrentUserID
        End If
        QuotationInfo.Extend04 = Me.HiddenQuoterFax.Value
        QuotationInfo.Extend05 = Me.HiddenContactFax.Value
        QuotationInfo.Extend07 = Me.RDOisneedFapiao.SelectedValue
        QuotationInfo.Extend08 = Me.HiddenMinYOUhui.Value

        QuotationInfo.RecordDeleted = 0


        QuotationInfo.TestCategory = Me.RdoTestCategory.SelectedValue
        QuotationInfo.Extend02 = Me.RdoIsneedBack.SelectedValue
        Dim QuotationDal As QuotationDAL = New QuotationDAL(QuotationInfo)
        QuotationDal.Save()

        PKID = QuotationInfo.PKID
        Me.HiddenPKID.Value = PKID

        Dim QuoTestRemark As QuoTestRemarkInfo = QuoTestRemarkDAL.GetInfoByParentPKID(PKID)
        QuoTestRemark.ParentID = PKID
        QuoTestRemark.TestRemark = Me.TxtTestRemark.Text
        QuoTestRemark.Extend2 = Me.TxtCusRemark.Text
        Dim quoremarkdal As QuoTestRemarkDAL = New QuoTestRemarkDAL(QuoTestRemark)
        quoremarkdal.Save()

        If CurDocInfo.CurStateOrder = 2 Then
            Me.UcFileDetail1.ParentID = PKID
            Me.UcFileDetail1.SaveDatatoDataBase()
        End If
        If CurDocInfo.CurStateOrder = 4 Then
            Me.UcFileDetail2.ParentID = PKID
            Me.UcFileDetail2.SaveDatatoDataBase()
        End If

    End Sub

    Public ReadOnly Property TemplateName() As String Implements eWorkFlow.eFlowDoc.IDocInfo.TemplateName
        Get
            Return "CRM報價單到申請單流程"
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
            SaveScript.Append("if (mSamplerow>0 && TestItemRow>0){  ")
            SaveScript.Append(" } else {  alert('請維護送檢物品及測試項目信息,\r\n每一樣品至少應該有一個測試項目.');return false;}")
            SaveScript.Append("if (($('#HiddenCustomerPKID').val()=='0')||($('#HiddenContactID').val()=='0')){return false;} ")
            CtlWFActionList1.AduitScript = SaveScript.ToString
            CtlWFActionList1.SaveScript = SaveScript.ToString
        End If
        If CurDocInfo.CurStateOrder = 4 Then
            Dim SaveScript As StringBuilder = New StringBuilder()
            SaveScript.Append("if($('#TxtTestRemark').val()==''){alert('請填寫測試要求信息！');return false;}")
            If ConfigurationManager.AppSettings("CQ") = "SZ" Then
                SaveScript.Append("if (($('#HiddenTecSupport').val()=='0')||($('#HiddenTecSupport').val()=='未選擇')){alert('請選額技術客服！');return false;} ")
            End If
            CtlWFActionList1.AduitScript = SaveScript.ToString

        End If
    End Sub

    Private Sub CtlWFActionList1_Postsave(ByVal CurDocInfo As eWorkFlow.eFlowDoc.DocInfoSystem, ByVal e As eWorkFlow.eFlowDoc.PostSaveDocEventArgs) Handles CtlWFActionList1.Postsave
        If CurDocInfo.CurStateOrder = 1 And e.CommandName = Platform.eWorkFlow.Model.Enm_ActionType.Approve Then
            GetPDFquo()
        End If
        If CurDocInfo.NextStateOrder = 2 AndAlso CurDocInfo.CurStateOrder <> 1 And CurDocInfo.CurStateOrder <> 4 Then
            IsSign = True
        End If
        If Me.TxtQuotationNO.Text.Contains("?") Then
            Dim lsm As Integer = TableBMHDAL.GetMaxlsmbyCategory(Me.TxtQuotationNO.Text.Substring(0, Me.TxtQuotationNO.Text.IndexOf("?"))) + 1
            Dim newtableinfo As TableBMHInfo = New TableBMHInfo()
            newtableinfo.PKID = 0
            newtableinfo.RecordPKID = PKID
            newtableinfo.Category = Me.TxtQuotationNO.Text.Substring(0, Me.TxtQuotationNO.Text.IndexOf("?"))
            newtableinfo.YMD = DateTime.Now.ToShortDateString
            newtableinfo.BMH = lsm
            Dim newtabledal As TableBMHDAL = New TableBMHDAL(newtableinfo)
            newtabledal.Save()
        ElseIf e.CommandName = Platform.eWorkFlow.Model.Enm_ActionType.Approve AndAlso CurDocInfo.NextStateOrder = 4 AndAlso Me.RdoIsSendMail.SelectedValue = "1" Then
            Try
                Dim maillist As String = QuotationInfo.ContactEmail
                Dim Title As String = String.Format("华南检测中心({0})：您有一份报价单待下载和回传", ConfigurationManager.AppSettings("CQ"))
                Dim info As String = String.Format("尊敬的客户：</br>您好！您咨询的测试报价单已经制作完成，详情请点击下方链接下载！您若接受我们的报价，还请签字、盖章，并上传。谢谢！</br> 以上为系统自动发送邮件, 请勿直接回复!</br><a href='http://cmc.foxconn.com/crm/Default.aspx?PageType=quotation&eFlowDocID={0}", QuotationInfo.eFlowDocID) + "'>点此进入查看</a>"
                info += String.Format("</br>账号：{0}，初始密码为password", QuotationInfo.Extend01)
                info += String.Format("</br>扫描下方二维码关注CMC微信官方号</br><img src ='http://cmc.foxconn.com/crm/Images/CMCer.JPG' width='200px' />")
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
                cursengmailinfo.Remark = "通知客戶下載報價單和回傳報價單"
                Dim cursendmaildal As SendOutMailLogDAL = New SendOutMailLogDAL(cursengmailinfo)
                cursendmaildal.Save()
            Catch ex As Exception
            End Try
        ElseIf e.CommandName = Platform.eWorkFlow.Model.Enm_ActionType.Finish Then
            Dim sendsampletime As String = "9999-12-31 23:59:59.997"
            Dim sendfapiaotime As String = "9999-12-31 23:59:59.997"
            If QuotationInfo.Extend02 = "實驗室自行處理" Then
                sendsampletime = QuotationInfo.QuoteDate.ToString
            End If
            If QuotationInfo.Extend07 = "2" Then
                sendfapiaotime = QuotationInfo.QuoteDate.ToString
            End If
            Dim reportpkid As String
            If QuotationInfo.Extend09 = "1" Then
                reportpkid = SqlHelper.ExecuteScalar(ConfigurationInfo.ConnectionString, "Quotation_InserToReportNoauto", PKID, sendsampletime, sendfapiaotime).ToString
            Else
                reportpkid = SqlHelper.ExecuteScalar(ConfigurationInfo.ConnectionString, "Quotation_InserToReport", PKID, sendsampletime, sendfapiaotime).ToString
            End If
            If ConfigurationManager.AppSettings("CQ") = "SZ" Then
                Dim tecaccountinfo As AccountInfo = AccountManage.LoadAccountInfoByUserSID(QuotationInfo.Extend10)
                If Not tecaccountinfo Is Nothing Then
                    Dim emailaddress As String = tecaccountinfo.Email1
                    Dim title As String = String.Format("CRM系統有一份報價單(報價單號：{0})指定您為技術客服，請處理({1})", QuotationInfo.QuotationNO, Me.DPLtecsupport.SelectedItem.Text)
                    Dim info As String = title + "</br><a href='" + Global_asax.UrlBase + String.Format("/Default.aspx?PageType=report&pkid={0}", reportpkid.ToString) + "'>點此進入查看</a>"
                    QuotationInvoid.SendMail(emailaddress, title, info)
                End If
            End If
        End If
    End Sub
    Private Sub CtlWFActionList1_Querysave(ByVal CurDocInfo As eWorkFlow.eFlowDoc.DocInfoSystem, ByVal e As eWorkFlow.eFlowDoc.QuerySaveDocEventArgs) Handles CtlWFActionList1.Querysave
        If e.CommandName = Platform.eWorkFlow.Model.Enm_ActionType.Approve _
          OrElse e.CommandName = Platform.eWorkFlow.Model.Enm_ActionType.Rejection _
          OrElse e.CommandName = Platform.eWorkFlow.Model.Enm_ActionType.Revoke _
          OrElse e.CommandName = Platform.eWorkFlow.Model.Enm_ActionType.Finish Then
            QuotationInfo.StateName = CurDocInfo.NextStateName
            QuotationInfo.StateOrder = CurDocInfo.NextStateOrder
        Else
            QuotationInfo.StateName = CurDocInfo.CurStateName
            QuotationInfo.StateOrder = CurDocInfo.CurStateOrder
        End If
        If CurDocInfo.CurStateOrder = 4 And ConfigurationManager.AppSettings("CQ") = "SZ" Then
            QuotationInfo.Extend10 = Me.HiddenTecSupport.Value
        End If
        If e.CommandName = Platform.eWorkFlow.Model.Enm_ActionType.Finish Then
            QuotationInfo.IsFinished = 1
            QuotationInfo.FinishDate = DateTime.Now
            If ConfigurationManager.AppSettings("IswithTAM") = "1" Then


                Dim itemds As DataSet = TestItemDetailDAL.GetDsByQuotationPKID(PKID)
                Dim itemdt As DataTable = itemds.Tables(0)
                Dim itemdr As DataRow
                Dim ServiceTypes As String = String.Empty
                Dim i As Integer
                If itemdt.Rows.Count > 0 Then
                    For i = 0 To itemdt.Rows.Count - 1
                        itemdr = itemdt.Rows(i)
                        ServiceTypes += itemdr.Item("ServiceType").ToString
                    Next
                End If
                If ServiceTypes.IndexOf("校准实验室") > -1 Then
                    IsHasJiaozhun = 1
                    QuotationInfo.Extend09 = "1"
                Else
                    QuotationInfo.TestNO = SqlHelper.ExecuteScalar(ConfigurationInfo.ConnectionString, "Quotation_InsertIntoTsetApplyManage", PKID, UserInfo.CurrentEmail)
                End If
            Else
                QuotationInfo.Extend09 = "1"
            End If
       
        End If
        If Me.TxtQuotationNO.Text.Contains("?") Then
            Dim lsm As Integer = 0
            lsm = TableBMHDAL.GetMaxlsmbyCategory(Me.TxtQuotationNO.Text.Substring(0, Me.TxtQuotationNO.Text.IndexOf("?"))) + 1
            QuotationInfo.QuotationNO = Me.TxtQuotationNO.Text.Substring(0, Me.TxtQuotationNO.Text.IndexOf("?")) + lsm.ToString("00")
        Else
            QuotationInfo.QuotationNO = Me.TxtQuotationNO.Text
        End If

    End Sub
#End Region

    Dim i As Integer = 1


    Protected Sub LinkReport_Click(ByVal sender As Object, ByVal e As EventArgs) Handles LinkReport.Click
        Dim reportinfo As ReportDetailInfo = ReportDetailDAL.GetInfoByQuotationPKID(PKID)

        Dim url As String = String.Format("../Quotation/ReportDetailDetail.aspx?PKID={0}", reportinfo.PKID.ToString)
        If reportinfo.eFlowDocID.ToString <> "00000000-0000-0000-0000-000000000000" Then
            url += "&eFlowDocID=" + reportinfo.eFlowDocID.ToString

        End If
        Response.Redirect(url)
    End Sub

    Private Sub BindGrid1(ByVal SearchCondition As String)
        Dim TotalRecord As Integer = 0
        Dim ds As DataSet = CustomersDAL.GetTestHistoryBySearchCondition(SearchCondition)
        If ds Is Nothing Then
            Me.emptyinfo.Visible = True
            Me.GridView1.DataSource = Nothing
            Me.GridView1.DataBind()
        Else
            Me.emptyinfo.Visible = False
            Me.GridView1.DataSource = ds
            Me.GridView1.DataBind()
        End If
    End Sub



    Protected Sub LinkButton1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles LinkButton1.Click
        If Me.HiddenCustomerPKID.Value <> 0 Then
            If testhistory.Visible = False Then
                Me.testhistory.Visible = True
                Dim SearchCondition As String = InitSearch + " and RecordCreated >'" + DateTime.Now.AddDays(-5).ToShortDateString + "'"

                BindGrid1(SearchCondition)
            Else
                Me.testhistory.Visible = False
            End If
            ScriptManager.RegisterStartupScript(Me.UpdatePanel1, Me.UpdatePanel1.GetType(), DateTime.Now.ToString(), "<script>parent.iFrameHeight();</script>", False)
            ' ClientScript.RegisterClientScriptBlock(Me.GetType(), DateTime.Now.ToString(), "<script language=javascript>parent.iFrameHeightadd();</script>", True)
        End If
    End Sub



    Protected Sub BtnSearch_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BtnSearch.Click
        Dim SearchCondition As String = InitSearch
        If Me.TxtCondition.Text = "默認只顯示五天內記錄，搜尋可顯示更早數據" Then
            Me.TxtCondition.Text = ""
        End If
        Me.testhistory.Visible = True
        SearchCondition += String.Format(" and ( TestItemName like '%{0}%' or ServiceType like '%{0}%' or QuotationNO like '%{0}%')", Me.TxtCondition.Text)

        BindGrid1(SearchCondition)
        ScriptManager.RegisterStartupScript(Me.UpdatePanel1, Me.UpdatePanel1.GetType(), DateTime.Now.ToString(), "<script>parent.iFrameHeight();</script>", False)
    End Sub

    Protected Sub LinkGetPDF_Click(ByVal sender As Object, ByVal e As EventArgs) Handles LinkGetPDF.Click
        GetSignedquote()
    End Sub
    Private Sub GetPDFquo()

        Dim curfileguid As Guid = System.Guid.NewGuid
        Dim report As CrystalReport1
        Dim myDS As New DataSet1()
        myDS = QuotationDAL.TransFotReport(Convert.ToInt32(Me.HiddenPKID.Value))
        report = New CrystalReport1()
        report.SetDataSource(myDS)
        Dim cusinfo As CustomersInfo = CustomersDAL.GetInfoByPKID(ContactDAL.GetInfoByUserSID(UserInfo.CurrentUserID).CusTomerPKID)
        report.SetParameterValue("MyConpanyName", cusinfo.CustomerName)
        ' report.SetParameterValue("NO", "CMC432")
        Dim curcontactinfo As ContactInfo
        If QuotationInfo.Extend01.Trim <> String.Empty Then
            curcontactinfo = ContactDAL.Contact_GetInfoByContactID(QuotationInfo.Extend01)
        Else
            curcontactinfo = New ContactInfo()
        End If

        If curcontactinfo.PKID <> 0 Then
            report.SetParameterValue("Customers", Me.HiddenCustomerName.Value)
            report.SetParameterValue("Contactname", curcontactinfo.UserName)
            report.SetParameterValue("Contactphone", curcontactinfo.Extend1)
            report.SetParameterValue("ContactEmail", curcontactinfo.Extend4)
            report.SetParameterValue("ContactFax", curcontactinfo.Extend3)
        Else
            report.SetParameterValue("Customers", Me.HiddenCustomerName.Value)
            report.SetParameterValue("Contactname", Me.HiddenContactName.Value)
            report.SetParameterValue("Contactphone", Me.HiddenContactPhone.Value)
            report.SetParameterValue("ContactEmail", Me.HiddenContactEmail.Value)
            report.SetParameterValue("ContactFax", Me.HiddenContactFax.Value)
        End If
        If Me.RadioButtonList1.SelectedValue = 0 Then

            report.SetParameterValue("HanshuiTotal", FormatNumber((Convert.ToDouble((Me.HiddenShijibaojia.Value)) * 1.06).ToString("0.00"), 2, -1, 0, -1) + "(已含6%稅)")
        Else
            report.SetParameterValue("HanshuiTotal", Int((Convert.ToDouble(Me.HiddenShijibaojia.Value) * 1.06) + 0.5).ToString + "(已含6%稅)")

        End If
        If Me.CHBisneedseal.Checked Then
            report.SetParameterValue("IsneedSeal", "1")
        Else
            report.SetParameterValue("IsneedSeal", "0")
        End If
        report.SetParameterValue("fileguid", curfileguid.ToString)
        report.SetParameterValue("BankNo", cusinfo.BankAccount)
        report.SetParameterValue("BankName", cusinfo.Bank)
        report.SetParameterValue("AccountName", cusinfo.AccountName)
        report.SetParameterValue("TotalMoney", FormatNumber(CDbl(Me.HiddenShijibaojia.Value).ToString("0.00"), 2, -1, 0, -1) + "(未含稅)")
        report.SetParameterValue("CQ", ConfigurationManager.AppSettings("CQ"))
        report.SetParameterValue("MyCompanyNameEN", cusinfo.CustomerEnglishName)
        report.SetParameterValue("Address", cusinfo.Address)
        report.SetParameterValue("Consignee", cusinfo.Extend3)
        report.SetParameterValue("Phone", cusinfo.Phone)
        report.SetParameterValue("CellPhone", cusinfo.Extend2)
        report.SetParameterValue("Zipcode", cusinfo.ZipCode)
        report.SetParameterValue("AddressEn", cusinfo.Extend1)


        QuotationInfo = QuotationDAL.GetInfoByPKID(Convert.ToInt32(Me.HiddenPKID.Value))
        Dim filename As String = QuotationInfo.QuotationNO.Trim() + "_" + CustomersDAL.GetInfoByPKID(CInt(Me.HiddenCustomerPKID.Value)).CustomerAlias + ".pdf"
        Dim fileclientname As String = DateTime.Now.ToString("yyyyMMddHHmm") + QuotationInfo.QuotationNO.Trim() + ".pdf"
        ' Dim filepath As String = String.Format("{0}\{1}\{2}", Server.MapPath(Request.ApplicationPath), "UploadFiles", fileclientname)
        'report.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, filepath)




        Dim AttachFileInfo As WF_AttachFileInfoInfo = New WF_AttachFileInfoInfo()
        AttachFileInfo.FileID = 0
        AttachFileInfo.ParentID = PKID
        AttachFileInfo.ParentCategory = 1
        AttachFileInfo.ParentSubCategory = 1
        AttachFileInfo.FileName = filename
        AttachFileInfo.FileGuID = curfileguid
        Dim iStream As Stream = report.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat)
        AttachFileInfo.FileSize = iStream.Length
        Dim MyArray(iStream.Length) As Byte
        iStream.Read(MyArray, 0, iStream.Length)
        iStream.Close()
        Dim Filerealname As String
        If CDbl(Me.HiddenMinYOUhui.Value) < 0.9 Then
            '開始調用webservice
            Dim quoterpdfserver As PDFService = New PDFService()
            Dim mSignLocation() As SignLocation = Nothing
            Dim mSignl As SignLocation = New SignLocation()
            mSignl.SignField = "LastSign"
            mSignl.PageNum = 0
            mSignl.llx = 80
            mSignl.lly = 130
            mSignl.urx = 200
            mSignl.ury = 180
            ReDim Preserve mSignLocation(0)
            mSignLocation(0) = mSignl
            Filerealname = quoterpdfserver.CreatePDFFile("CRMQUOTER", MyArray, mSignLocation, "CRMQUOTER")
        Else
            AttachFileInfo.FileContent = MyArray
            Filerealname = fileclientname
        End If
       

        AttachFileInfo.FileExtension = "pdf"
        AttachFileInfo.FileClientName = Filerealname
        AttachFileInfo.Extend1 = String.Empty
        AttachFileInfo.Extend2 = String.Empty
        AttachFileInfo.Extend3 = String.Empty
        AttachFileInfo.Extend4 = String.Empty
        AttachFileInfo.Extend5 = String.Empty
        AttachFileInfo.RecordVersion = ConfigurationInfo.RecordVersion
        AttachFileInfo.RecordCreateTime = DateTime.Now
        AttachFileInfo.RecordDeleted = 2

        Dim AttachDal As WF_AttachFileInfoDAL = New WF_AttachFileInfoDAL(AttachFileInfo)
        AttachDal.Save()

        report.Close()
        report.Dispose()


    End Sub
    Private Sub GetSignedquote()
        Dim FileID As String
        Dim FileIDint As Integer
        Dim ds As DataSet = WF_AttachFileInfoDAL.GetLastquotationclientname(PKID)
        If Not ds Is Nothing Then
            Dim dt As DataTable = ds.Tables(0)
            Dim dr As DataRow = dt.Rows(0)
            Dim filename As String
            FileIDint = CInt(dr.Item("fileid"))
            If CDbl(Me.HiddenMinYOUhui.Value) >= 0.9 Then
                filename = dr.Item("FileClientName").ToString
                WF_AttachFileInfoDAL.UpDeleteinfo(FileIDint, 0)
                Me.UcFileDetail1.BindDataGrid()
            Else
                filename = dr.Item("FileClientName").ToString
                FileID = filename
                Dim pdfserverupcontent As PDFService = New PDFService()
                Dim filecontent() As Byte = pdfserverupcontent.GetFileStreamByID(FileID, "CRMQUOTER", True)
                
                If Not filecontent Is Nothing Then
                    WF_AttachFileInfoDAL.Upcontentandsize(FileIDint, filecontent, filecontent.Length)
                    Me.UcFileDetail1.BindDataGrid()
                End If
            End If
        End If
        ScriptManager.RegisterStartupScript(Me.UpdatePanel2, Me.UpdatePanel2.GetType(), DateTime.Now.ToString(), "<script>ShowProgress();</script>", False)

    End Sub

    Protected Sub LinkapproveQuoinvalid_Click(ByVal sender As Object, ByVal e As EventArgs) Handles LinkapproveQuoinvalid.Click
        Dim address As String = AccountManage.LoadAccountInfoByUserSID(InvalidQuotationDAL.GetInfoByQuotationPKID(PKID).AddUserID).Email1
        Dim Title As String = String.Format("您好，CRM報價單{0}申請異常結案，主管已核准，請知曉", QuotationInfo.QuotationNO)
        Dim info As String = Title + "</br><a href='" + Global_asax.UrlBase + String.Format("/Default.aspx?PageType=quotation&eFlowDocID={0}", QuotationInfo.eFlowDocID) + "'>點此進入查看</a>"
        QuotationInvoid.SendMail(address, Title, info)
        Dim tx As System.Transactions.TransactionScope = New System.Transactions.TransactionScope()
        Try
            If QuotationInfo.IsFinished = 0 Then
                DocInfoSystem.BatchAuditInfo(Platform.eWorkFlow.Model.Enm_ActionType.Finish, DocUniqueID, "")
            End If
            SqlHelper.ExecuteNonQuery(ConfigurationInfo.ConnectionString, "UpQuotationInvalid", PKID, 1)
            tx.Complete()
        Catch ex As Exception
            System.Transactions.Transaction.Current.Rollback() '將所有操作回滾
        Finally
            tx.Dispose()
        End Try
        Response.Redirect("../Quotation/QuotationList.aspx?Type=" + CurType.ToString)
    End Sub

    Protected Sub Linkbohui_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Linkbohui.Click
        SqlHelper.ExecuteNonQuery(ConfigurationInfo.ConnectionString, "UpQuotationInvalid", PKID, 0)


        Dim address As String = AccountManage.LoadAccountInfoByUserSID(InvalidQuotationDAL.GetInfoByQuotationPKID(PKID).AddUserID).Email1
        Dim Title As String = String.Format("您好，CRM報價單{0}申請異常結案，主管已駁回，請知曉", QuotationInfo.QuotationNO)
        Dim info As String = Title + "</br><a href='" + Global_asax.UrlBase + String.Format("/Default.aspx?PageType=quotation&eFlowDocID={0}", QuotationInfo.eFlowDocID) + "'>點此進入查看</a>"
        QuotationInvoid.SendMail(address, Title, info)

        Response.Redirect("../Quotation/QuotationList.aspx?Type=" + CurType.ToString)
    End Sub

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button1.Click
        Response.Redirect("../Quotation/QuotationList.aspx?Type=" + CurType.ToString)
    End Sub

    Protected Sub BtnSendMail_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BtnSendMail.Click
        Dim maillist As String = QuotationInfo.ContactEmail
        Dim Title As String = String.Format("华南检测中心({0})：您有一份报价单待下载和回传", ConfigurationManager.AppSettings("CQ"))
        Dim info As String = String.Format("尊敬的客户：</br>您好！您咨询的测试报价单已经制作完成，详情请点击下方链接下载！您若接受我们的报价，还请签字、盖章，并上传。谢谢！</br> 以上为系统自动发送邮件, 请勿直接回复!</br><a href='http://cmc.foxconn.com/crm/Default.aspx?PageType=quotation&eFlowDocID={0}", QuotationInfo.eFlowDocID) + "'>点此进入查看</a>"
        info += String.Format("</br>账号：{0}，初始密碼為password", QuotationInfo.Extend01)
        info += String.Format("</br>扫描下方二维码关注CMC微信官方号</br><img src ='http://cmc.foxconn.com/crm/Images/CMCer.JPG' width='200px' />")
        Try
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
            cursengmailinfo.Remark = "通知客戶下載報價單和回傳報價單"
            Dim cursendmaildal As SendOutMailLogDAL = New SendOutMailLogDAL(cursengmailinfo)
            cursendmaildal.Save()
        Catch ex As Exception

        End Try
    End Sub
End Class