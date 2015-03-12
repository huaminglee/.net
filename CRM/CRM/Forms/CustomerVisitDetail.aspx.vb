Imports System.Web.Services
Imports eWorkFlow.eFlowDoc
Imports Platform.eAuthorize
Imports Aspose.Words.Tables
Imports Aspose.Words

Partial Public Class CustomerVisitDetail
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
    Private _CustomerVisit As CustomerVisitsInfo
    Private Property CustomerVisit() As CustomerVisitsInfo
        Get
            If _CustomerVisit Is Nothing Then
                If PKID <> 0 Then
                    _CustomerVisit = CustomerVisitsDAL.GetInfoByPKID(PKID)
                ElseIf DocUniqueID <> String.Empty Then
                    _CustomerVisit = CustomerVisitsDAL.GetInfoByeFLowdocID(DocUniqueID)
                    PKID = _CustomerVisit.PKID
                    Me.HiddenPKID.Value = PKID
                Else
                    _CustomerVisit = New CustomerVisitsInfo()
                End If
            End If
            Return _CustomerVisit
        End Get
        Set(ByVal value As CustomerVisitsInfo)
            _CustomerVisit = value
        End Set
    End Property
#End Region

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            Me.TxtVisitDate.Attributes.Add("onclick", "javascript:WdatePicker({isShowClear:false,startDate:'%y-%M-01',dateFmt:'yyyy-MM-dd'});")
            GetParam()
            BindControlData()
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
        If Not Request.QueryString("CustomerPKID") Is Nothing Then
            CustomerPKID = Convert.ToInt32(Request.QueryString("CustomerPKID"))
        End If
    End Sub
    Private Sub BindControlData()
        If Not CustomerVisit Is Nothing Then
            If PKID <> 0 Then
                Me.HiddenCustomerPKID.Value = CustomerVisit.CustomerPKID
                Me.TxtCooperationAgen.Text = CustomerVisit.CooperationAgen
                Me.TxtCooperationProj.Text = CustomerVisit.CooperationProj
                Me.TxtCustomerAddress.Text = CustomerVisit.CustomerAddress
                Me.TxtCustomerName.Text = CustomerVisit.CustomerName
                Me.TxtCustomerNature.Text = CustomerVisit.CustomerNature
                Me.TxtCustomerScale.Text = CustomerVisit.CustomerNature
                Me.TxtCustomerSources.Text = CustomerVisit.CustomerSources
                Me.RdoIsfirst.SelectedIndex = Me.RdoIsfirst.Items.IndexOf(Me.RdoIsfirst.Items.FindByValue(CustomerVisit.IsFirstVisits))
                Me.TxtProductRange.Text = CustomerVisit.ProductRange
                Me.TxtQuoter.Text = CustomerVisit.QuoterName
                Me.Txtremark.Text = CustomerVisit.Remark
                Me.TxtTestAmountPerYeay.Text = CustomerVisit.TestAmountPerYeay
                Me.TxtVisitDate.Text = CustomerVisit.VisitDate
                Me.TxtConversationmatters.Text = CustomerVisit.Conversationmatters
                Me.TxtResult.Text = CustomerVisit.Result
                Me.TxtMattertracked.Text = CustomerVisit.Mattertracked
                Me.DPLTypeofPay.SelectedIndex = Me.DPLTypeofPay.Items.IndexOf(Me.DPLTypeofPay.Items.FindByValue(CustomerVisit.TypeofPay))
                Me.LbConversationmatters.Text = Replace(Me.TxtConversationmatters.Text, vbCrLf, "   <br/>  ")
                Me.LbCooperationAgen.Text = CustomerVisit.CooperationAgen
                Me.LbCustomerAddress.Text = CustomerVisit.CustomerAddress
                Me.LbCustomerName.Text = CustomerVisit.CustomerName
                Me.LbCustomerNature.Text = CustomerVisit.CustomerNature
                Me.LbCustomerScale.Text = CustomerVisit.CustomerScale
                Me.LbCustomerSources.Text = CustomerVisit.CustomerSources
                Me.LbMattertracked.Text = Replace(Me.TxtMattertracked.Text, vbCrLf, "<br/> ")
                Me.LbProductRange.Text = CustomerVisit.ProductRange
                Me.Lbremark.Text = CustomerVisit.Result
                Me.LbResult.Text = Replace(Me.TxtResult.Text, vbCrLf, "<br/> ")
                Me.LbtCooperationProj.Text = CustomerVisit.CooperationProj
                Me.LbTestAmountPerYeay.Text = CustomerVisit.TestAmountPerYeay
                Me.LbTypeofPay.Text = Me.DPLTypeofPay.SelectedItem.Text

            ElseIf CustomerPKID <> 0 Then
                Me.TxtVisitDate.Text = DateTime.Now.ToShortDateString
                Me.TxtQuoter.Text = UserInfo.CurrentUserCHName
                Me.HiddenCustomerPKID.Value = "0"
                Me.HiddenPKID.Value = "0"
                Dim CustomerInfo As CustomersInfo = CustomersDAL.GetInfoByPKID(CustomerPKID)
                If Not CustomerInfo Is Nothing Then
                    Me.TxtCustomerName.Text = CustomerInfo.CustomerName
                    Me.HiddenCustomerPKID.Value = CustomerInfo.PKID
                    Me.DPLTypeofPay.SelectedIndex = Me.DPLTypeofPay.Items.IndexOf(Me.DPLTypeofPay.Items.FindByValue(CustomerInfo.TypeofPay))
                    Me.TxtCustomerSources.Text = CustomerInfo.Source
                    Me.TxtCustomerScale.Text = String.Format("員工數：{0},註冊資金：{1}", CustomerInfo.EmployeeNum, CustomerInfo.ZhuceCapital)
                    Me.TxtCustomerAddress.Text = CustomerInfo.Address
                End If
            End If
        End If
    End Sub
#Region "WebService"


    <WebMethod()> _
  Public Shared Function SaveCustomerVisitsInfo(ByVal mVisitsinfo As CustomerVisitsInfo) As Integer

        mVisitsinfo.StateOrder = 0
        mVisitsinfo.PKID = 0
        mVisitsinfo.eFlowDocID = Guid.Empty
        mVisitsinfo.StateName = String.Empty
        mVisitsinfo.IsFinished = 0
        mVisitsinfo.RecordDeleted = 2 '未保存的臨時案件
        mVisitsinfo.RecordCreated = DateTime.Now



        Dim mViDAL As CustomerVisitsDAL = New CustomerVisitsDAL(mVisitsinfo)

        mViDAL.Save()
        Return mVisitsinfo.PKID

    End Function
    <WebMethod()> _
 Public Shared Sub DeletePerson(ByVal PersonPKID As Integer)
        VisitsPersonDAL.Delete(PersonPKID)
    End Sub
    <WebMethod()> _
   Public Shared Function SavePersonInfo(ByVal mPersonInfo As VisitsPersonInfo) As Integer

        Dim mPersondal As VisitsPersonDAL = New VisitsPersonDAL(mPersonInfo)

        mPersondal.Save()
        Return mPersonInfo.PKID
    End Function
#End Region
#Region "Idoc"



    Public ReadOnly Property BusniessName() As String Implements eWorkFlow.eFlowDoc.IDocInfo.BusniessName
        Get
            Return "客戶拜訪"
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
            Dim ReturnURL As String = "../Forms/CustomerVisitDetail.aspx?" & Global_asax.QUERY_APPLICANTIDX & "=" + Me.HiddenPKID.Value
            If (DocUniqueID <> String.Empty AndAlso DocUniqueID <> Guid.Empty.ToString) Then
                ReturnURL = ReturnURL + "&" + Global_asax.QUERY_DOCUNIQUEID + "=" + DocUniqueID
            End If
            Response.Redirect(ReturnURL)
        Else
            If UserInfo.IsInRoles("EXTERNALWORKER") Then
                Response.Redirect("../Forms/CustomersList.aspx")
            Else
                Response.Redirect("../Index.aspx")
            End If
        End If
    End Sub

    Public Sub LoadDocInfo(ByVal CurDocInfo As eWorkFlow.eFlowDoc.DocInfoSystem) Implements eWorkFlow.eFlowDoc.IDocInfo.LoadDocInfo
        If CurDocInfo.CurStateOrder = 1 Then
            Me.HiddenCanAdd.Value = "True"
            SeteditDisplay(True)
        Else
            SeteditDisplay(False)
            Me.HiddenCanAdd.Value = "False"
        End If
        CtlWFActionList1.CurURL = String.Format("{0}?PageType=CustomerVisit", Global_asax.URL_INDEX)
    End Sub
    Private Sub SeteditDisplay(ByVal isshow As Boolean)
        If isshow Then
            Me.LbConversationmatters.Visible = False
            Me.LbCooperationAgen.Visible = False
            Me.LbCustomerAddress.Visible = False
            Me.LbCustomerName.Visible = False
            Me.LbCustomerNature.Visible = False
            Me.LbCustomerScale.Visible = False
            Me.LbCustomerSources.Visible = False
            Me.LbMattertracked.Visible = False
            Me.LbProductRange.Visible = False
            Me.Lbremark.Visible = False
            Me.LbResult.Visible = False
            Me.LbtCooperationProj.Visible = False
            Me.LbTestAmountPerYeay.Visible = False
            Me.LbTypeofPay.Visible = False
            Me.TxtConversationmatters.Visible = True
            Me.TxtCooperationAgen.Visible = True
            Me.TxtCooperationProj.Visible = True
            Me.TxtCustomerAddress.Visible = True
            Me.TxtCustomerName.Visible = True
            Me.TxtCustomerNature.Visible = True
            Me.TxtCustomerScale.Visible = True
            Me.TxtCustomerSources.Visible = True
            Me.TxtMattertracked.Visible = True
            Me.TxtProductRange.Visible = True
            Me.Txtremark.Visible = True
            Me.TxtResult.Visible = True
            Me.TxtTestAmountPerYeay.Visible = True
            Me.DPLTypeofPay.Visible = True


        Else
            Me.LbConversationmatters.Visible = True
            Me.LbCooperationAgen.Visible = True
            Me.LbCustomerAddress.Visible = True
            Me.LbCustomerName.Visible = True
            Me.LbCustomerNature.Visible = True
            Me.LbCustomerScale.Visible = True
            Me.LbCustomerSources.Visible = True
            Me.LbMattertracked.Visible = True
            Me.LbProductRange.Visible = True
            Me.Lbremark.Visible = True
            Me.LbResult.Visible = True
            Me.LbtCooperationProj.Visible = True
            Me.LbTestAmountPerYeay.Visible = True
            Me.LbTypeofPay.Visible = True
            Me.TxtConversationmatters.Visible = False
            Me.TxtCooperationAgen.Visible = False
            Me.TxtCooperationProj.Visible = False
            Me.TxtCustomerAddress.Visible = False
            Me.TxtCustomerName.Visible = False
            Me.TxtCustomerNature.Visible = False
            Me.TxtCustomerScale.Visible = False
            Me.TxtCustomerSources.Visible = False
            Me.TxtMattertracked.Visible = False
            Me.TxtProductRange.Visible = False
            Me.Txtremark.Visible = False
            Me.TxtResult.Visible = False
            Me.TxtTestAmountPerYeay.Visible = False
            Me.DPLTypeofPay.Visible = False
        End If
    End Sub
    Public Sub SaveDocInfo(ByVal CurDocInfo As eWorkFlow.eFlowDoc.DocInfoSystem, ByVal CommandName As Platform.eWorkFlow.Model.Enm_ActionType) Implements eWorkFlow.eFlowDoc.IDocInfo.SaveDocInfo
        DocUniqueID = CurDocInfo.DocUniqueID
        CustomerVisit.PKID = Me.HiddenPKID.Value
        CustomerVisit.eFlowDocID = New Guid(CurDocInfo.DocUniqueID)
        CustomerVisit.Conversationmatters = Me.TxtConversationmatters.Text
        CustomerVisit.CooperationAgen = Me.TxtCooperationAgen.Text
        CustomerVisit.CooperationProj = Me.TxtCooperationProj.Text
        CustomerVisit.CustomerAddress = Me.TxtCustomerAddress.Text
        CustomerVisit.CustomerName = Me.TxtCustomerName.Text
        CustomerVisit.CustomerNature = Me.TxtCustomerNature.Text
        CustomerVisit.CustomerPKID = Me.HiddenCustomerPKID.Value
        CustomerVisit.CustomerScale = Me.TxtCustomerScale.Text
        CustomerVisit.CustomerSources = Me.TxtCustomerSources.Text
        CustomerVisit.IsFirstVisits = Me.RdoIsfirst.SelectedValue
        CustomerVisit.Mattertracked = Me.TxtMattertracked.Text
        CustomerVisit.ProductRange = Me.TxtProductRange.Text
        CustomerVisit.QuoterName = Me.TxtQuoter.Text
        CustomerVisit.Remark = Me.Txtremark.Text
        CustomerVisit.Result = Me.TxtResult.Text
        CustomerVisit.TestAmountPerYeay = Me.TxtTestAmountPerYeay.Text
        CustomerVisit.TypeofPay = Me.DPLTypeofPay.SelectedValue
        CustomerVisit.VisitDate = Me.TxtVisitDate.Text
        CustomerVisit.RecordDeleted = 0
        Dim cusvisdal As CustomerVisitsDAL = New CustomerVisitsDAL(CustomerVisit)
        cusvisdal.Save()
    End Sub

    Public ReadOnly Property TemplateName() As String Implements eWorkFlow.eFlowDoc.IDocInfo.TemplateName
        Get
            Return "客戶拜訪"
        End Get
    End Property

    Public ReadOnly Property TemplateVersion() As Integer Implements eWorkFlow.eFlowDoc.IDocInfo.TemplateVersion
        Get
            Return 2
        End Get
    End Property
#End Region

    Private Sub CtlWFActionList1_Querysave(ByVal CurDocInfo As eWorkFlow.eFlowDoc.DocInfoSystem, ByVal e As eWorkFlow.eFlowDoc.QuerySaveDocEventArgs) Handles CtlWFActionList1.Querysave
        If e.CommandName = Platform.eWorkFlow.Model.Enm_ActionType.Approve _
         OrElse e.CommandName = Platform.eWorkFlow.Model.Enm_ActionType.Rejection _
         OrElse e.CommandName = Platform.eWorkFlow.Model.Enm_ActionType.Revoke _
         OrElse e.CommandName = Platform.eWorkFlow.Model.Enm_ActionType.Finish Then
            CustomerVisit.StateName = CurDocInfo.NextStateName
            CustomerVisit.StateOrder = CurDocInfo.NextStateOrder
        Else
            CustomerVisit.StateName = CurDocInfo.CurStateName
            CustomerVisit.StateOrder = CurDocInfo.CurStateOrder
        End If
        If e.CommandName = Platform.eWorkFlow.Model.Enm_ActionType.Finish Then
            CustomerVisit.IsFinished = 1
            CustomerVisit.FinishTime = DateTime.Now
        End If
    End Sub

    Protected Sub LinkExport_Click(ByVal sender As Object, ByVal e As EventArgs) Handles LinkExport.Click
        If PKID <> 0 Then


            Dim doc As Aspose.Words.Document = New Aspose.Words.Document(Server.MapPath("~") + "\UploadFiles\客戶拜訪交際回饋表.doc")
            Dim builder As Aspose.Words.DocumentBuilder = New Aspose.Words.DocumentBuilder(doc) '只有是2003 的模板文件才可以
            builder.RowFormat.Alignment = RowAlignment.Center

            Dim ds As DataSet = SqlHelper.ExecuteDataset(ConfigurationInfo.ConnectionString, "ExportPersoninfobyVisitsPKID", PKID)
            Dim dt As DataTable = ds.Tables(0)
            If dt.Rows.Count > 0 Then
                Dim widthList As List(Of Double) = New List(Of Double)
                builder.MoveToBookmark("table")    '开始添加值  '只有是2003 的模板文件才可以 2007 類型的移到該書籤添加沒有生成table 
                Dim pagewidth As Double = 18.72
                Dim width() As Double = New Double() {pagewidth * 0.15, pagewidth * 0.15, pagewidth * 0.15, pagewidth * 0.15, pagewidth * 0.25, pagewidth * 0.15}

                builder.StartTable()
                Dim header() As String = New String() {"序號", "姓名", "聯繫方式", "職務", "工作執掌", "備註"}
                builder.InsertCell()

                builder.CellFormat.Borders.LineStyle = LineStyle.Single
                builder.CellFormat.Borders.Color = System.Drawing.Color.Black
                builder.CellFormat.Width = pagewidth
                builder.Font.Size = 12
                builder.Font.Name = "Simsun"
                builder.Font.Bold = True
                builder.CellFormat.HorizontalMerge = CellMerge.None
                builder.CellFormat.VerticalMerge = Aspose.Words.Tables.CellMerge.None
                builder.CellFormat.VerticalAlignment = CellVerticalAlignment.Center
                builder.ParagraphFormat.Alignment = ParagraphAlignment.Center
                builder.Write("客戶基本信息")
                builder.EndRow()
                For k As Integer = 0 To 5
                    builder.InsertCell()
                    builder.CellFormat.Borders.LineStyle = LineStyle.Single
                    builder.CellFormat.Borders.Color = System.Drawing.Color.Black
                    builder.CellFormat.Width = width(k)
                    builder.Font.Size = 10
                    builder.Font.Name = "Simsun"
                    builder.Font.Bold = False
                    builder.CellFormat.HorizontalMerge = CellMerge.None

                    builder.CellFormat.VerticalMerge = Aspose.Words.Tables.CellMerge.None
                    builder.CellFormat.VerticalAlignment = CellVerticalAlignment.Center
                    builder.ParagraphFormat.Alignment = ParagraphAlignment.Center
                    builder.Write(header(k))

                Next
                builder.EndRow()
                builder.EndTable()

                builder.StartTable()
                builder.ParagraphFormat.Alignment = ParagraphAlignment.Center
                For i As Integer = 0 To dt.Rows.Count - 1

                    For j As Integer = 0 To dt.Columns.Count - 1
                        builder.InsertCell()
                        builder.CellFormat.Borders.LineStyle = LineStyle.Single
                        builder.CellFormat.Borders.Color = System.Drawing.Color.Black

                        builder.CellFormat.Width = width(j)
                        builder.Font.Size = 10
                        builder.Font.Name = "Simsun"
                        builder.Font.Bold = False
                        builder.CellFormat.VerticalMerge = Aspose.Words.Tables.CellMerge.None

                        builder.ParagraphFormat.Alignment = ParagraphAlignment.Center

                        builder.Write(dt.Rows(i)(j).ToString())
                    Next
                    builder.EndRow()
                Next
                builder.EndTable()
                doc.Range.Bookmarks("table").Text = ""

              
            End If
            Dim mBookMarks As BookmarkCollection = doc.Range.Bookmarks
            For Each mBookMark As Bookmark In mBookMarks
                Dim bookname As String = mBookMark.Name

                If bookname = "Quotername" Then
                    doc.Range.Bookmarks(bookname).Text = CustomerVisit.QuoterName
                ElseIf bookname = "VisitDate" Then
                    doc.Range.Bookmarks(bookname).Text = CustomerVisit.VisitDate
                ElseIf bookname = "IsFirstVisit" Then
                    If CustomerVisit.IsFirstVisits = 1 Then
                        doc.Range.Bookmarks(bookname).Text = "是"
                    Else
                        doc.Range.Bookmarks(bookname).Text = "否"
                    End If
                ElseIf bookname = "Customername" Then
                    doc.Range.Bookmarks(bookname).Text = CustomerVisit.CustomerName
                ElseIf bookname = "CustomerSources" Then
                    doc.Range.Bookmarks(bookname).Text = CustomerVisit.CustomerSources
                ElseIf bookname = "CustomerScale" Then
                    doc.Range.Bookmarks(bookname).Text = CustomerVisit.CustomerScale
                ElseIf bookname = "CustomerNature" Then
                    doc.Range.Bookmarks(bookname).Text = CustomerVisit.CustomerNature
                ElseIf bookname = "ProductRange" Then
                    doc.Range.Bookmarks(bookname).Text = CustomerVisit.ProductRange
                ElseIf bookname = "TestAmountPerYeay" Then
                    doc.Range.Bookmarks(bookname).Text = CustomerVisit.TestAmountPerYeay
                ElseIf bookname = "CooperationAgen" Then
                    doc.Range.Bookmarks(bookname).Text = CustomerVisit.CooperationAgen
                ElseIf bookname = "TypeofPay" Then
                    If CustomerVisit.TypeofPay = 1 Then
                        doc.Range.Bookmarks(bookname).Text = "預付款"
                    Else
                        doc.Range.Bookmarks(bookname).Text = "月結"
                    End If
                ElseIf bookname = "CooperationProj" Then
                    doc.Range.Bookmarks(bookname).Text = CustomerVisit.CooperationProj
                ElseIf bookname = "CustomerAddress" Then
                    doc.Range.Bookmarks(bookname).Text = CustomerVisit.CustomerAddress
                ElseIf bookname = "Remark" Then
                    doc.Range.Bookmarks(bookname).Text = CustomerVisit.Remark
                ElseIf bookname = "Conversationmatters" Then
                    doc.Range.Bookmarks(bookname).Text = CustomerVisit.Conversationmatters
                ElseIf bookname = "Result" Then
                    doc.Range.Bookmarks(bookname).Text = CustomerVisit.Result
                ElseIf bookname = "Mattertracked" Then
                    doc.Range.Bookmarks(bookname).Text = CustomerVisit.Mattertracked
                End If

            Next
            doc.Save(Server.MapPath("~") + "\UploadFiles\customervisits.doc")
            Response.Redirect("..\UploadFiles\customervisits.doc")
        End If
    End Sub
End Class