Imports CommonData.BusinessLayer

Public Class CtlGMPCSIResult
    Inherits System.Web.UI.UserControl

#Region " Web Form 設計工具產生的程式碼 "

    '此為 Web Form 設計工具所需的呼叫。
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents Datalist1 As System.Web.UI.WebControls.DataList
    Protected WithEvents Datalist2 As System.Web.UI.WebControls.DataList
    Protected WithEvents DataGrid1 As System.Web.UI.WebControls.DataGrid
    Protected WithEvents PagerControl1 As myControl.PagerControl
    Protected WithEvents Label1 As System.Web.UI.WebControls.Label
    Protected WithEvents txtPNSearch As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtColorBrandSearch As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtCustomer As System.Web.UI.WebControls.TextBox
    Protected WithEvents btnSearch As System.Web.UI.WebControls.ImageButton
    Protected WithEvents btnReview As System.Web.UI.WebControls.ImageButton
    Protected WithEvents btnExportExcel As System.Web.UI.WebControls.ImageButton
    Protected WithEvents txtGroup As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtDivision As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtAcceptDept As System.Web.UI.WebControls.TextBox
    Protected WithEvents lblSearchResult As System.Web.UI.WebControls.Label

    '注意: 下列預留位置宣告是 Web Form 設計工具需要的項目。
    '請勿刪除或移動它。
    Private designerPlaceholderDeclaration As System.Object

    Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
        'CODEGEN: 此為 Web Form 設計工具所需的方法呼叫
        '請勿使用程式碼編輯器進行修改。
        InitializeComponent()
    End Sub

#End Region

#Region "Const Define"
    Private Const HIDE_CSITime As String = "ViewState:CSITime"
    Private Const HIDE_DeptPKID As String = "ViewState:DeptPKID"
    Private Const HIDE_DeptName As String = "ViewState:DeptName"
#End Region

#Region "Properties"


    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' 當前頁的索引
    ''' </summary>
    ''' <value></value>
    ''' <remarks>
    ''' </remarks>
    ''' -----------------------------------------------------------------------------
    Private Property PageIndex() As Integer
        Get
            Return Me.PagerControl1.CurrentPage - 1
        End Get
        Set(ByVal Value As Integer)
            Me.PagerControl1.CurrentPage = Value + 1
        End Set
    End Property
    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' 當前頁的行
    ''' </summary>
    ''' <value></value>
    ''' <remarks>
    ''' </remarks>
    ''' -----------------------------------------------------------------------------
    Private Property PageSize() As Integer
        Get
            Return Me.PagerControl1.RecordsPerPage
        End Get
        Set(ByVal Value As Integer)
            Me.PagerControl1.RecordsPerPage = Value
        End Set
    End Property
    Private Property CSITime() As Integer
        Get
            If ViewState(HIDE_CSITime) Is Nothing Then
                Return 0
            End If
            Return Convert.ToInt32(ViewState(HIDE_CSITime))
        End Get
        Set(ByVal Value As Integer)
            ViewState(HIDE_CSITime) = Value
        End Set
    End Property

    Private Property DeptPKID() As Integer
        Get
            If ViewState(HIDE_DeptPKID) Is Nothing Then
                Return 0
            End If
            Return Convert.ToInt32(ViewState(HIDE_DeptPKID))
        End Get
        Set(ByVal Value As Integer)
            ViewState(HIDE_DeptPKID) = Value
        End Set
    End Property

    Private Property DeptName() As String
        Get
            If ViewState(HIDE_DeptName) Is Nothing Then
                Return String.Empty
            End If
            Return ViewState(HIDE_DeptName)
        End Get
        Set(ByVal Value As String)
            ViewState(HIDE_DeptName) = Value
        End Set
    End Property
#End Region

#Region "Self define Sub/function"
    Private Sub BindDataListPeriod()
        Dim SearchCondition As String = String.Empty
        Dim Alist As ArrayList = GEPCSI_Period.GetPeriodListInfo()
        If Not Alist Is Nothing Then
            Me.Datalist1.DataSource = Alist
            Me.Datalist1.DataBind()
            If CSITime = 0 Then
                CSITime = Alist.Item(0).Value
            End If
            Me.Datalist2.SelectedIndex = 0
            BindDataListDept()
        Else
            Exit Sub
        End If
    End Sub


    Private Sub BindDataListDept()
        Dim SearchString As String = " CSITime=" + CSITime.ToString + " AND IsSubmited=2"
        Dim Alist As ArrayList = GEPCSI_Result.GetImportDeptInfo(SearchString)
        If Not Alist Is Nothing Then
            Me.Datalist2.DataSource = Alist
            Me.Datalist2.DataBind()
            If DeptPKID = 0 Then
                DeptPKID = Alist.Item(0).Value
                DeptName = Alist.Item(0).Text
            End If
        End If
        BindDataGrid()

    End Sub

    '根據當前選中的實驗室綁定實驗室被調查的對象
    Private Sub BindDataGrid()
        Dim SearchCondition As String
        Dim SelectDeptCollection As GEPCSI_ResultCollection
        If DeptPKID = 0 Then
            SelectDeptCollection = Nothing
        Else
            If ViewState("SearchCondition") Is Nothing Then
                SearchCondition = " CSITime=" + CSITime.ToString + " AND DeptPKID=" + DeptPKID.ToString + "  AND IsSubmited=2 "
            Else
                SearchCondition = " CSITime=" + CSITime.ToString + " AND DeptPKID=" + DeptPKID.ToString + "  AND IsSubmited=2 " + _
                                  " AND " + CType(ViewState("SearchCondition"), String)
            End If
            SelectDeptCollection = GEPCSI_Result.LoadPageInfoBySearchcondition(SearchCondition, "GEPCSI_Result", "ResultPKID", "ResultPKID", Me.PageIndex, Me.PageSize)
            Me.PagerControl1.TotalRecords = GEPCSI_Result.LoadDataCount("GEPCSI_Result", "ResultPKID", SearchCondition)
        End If
        If SelectDeptCollection Is Nothing Then
            Me.PagerControl1.Visible = False
        Else
            Me.PagerControl1.Visible = True
        End If
        Me.DataGrid1.DataSource = SelectDeptCollection
        Me.DataGrid1.DataKeyField = "ResultPKID"
        Me.DataGrid1.DataBind()
    End Sub
#End Region

#Region "DataList Events"

    Private Sub Datalist1_ItemCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataListCommandEventArgs) Handles Datalist1.ItemCommand
        Select Case e.CommandName
            Case "SearchPeriod"

                If e.Item.ItemType = ListItemType.Item OrElse e.Item.ItemType = ListItemType.AlternatingItem Then
                    CSITime = Convert.ToInt32(e.CommandArgument)
                    Me.Datalist1.SelectedIndex = e.Item.ItemIndex
                    BindDataListPeriod()
                End If
                ScriptManager.RegisterStartupScript(Me.Parent, Me.Parent.GetType(), DateTime.Now.ToString(), "<script>parent.iFrameHeight();</script>", False)
        End Select
    End Sub


    Private Sub Datalist2_ItemCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataListCommandEventArgs) Handles Datalist2.ItemCommand
        Select Case e.CommandName
            Case "SearchDeptName"

                If e.Item.ItemType = ListItemType.Item OrElse e.Item.ItemType = ListItemType.AlternatingItem Then
                    DeptPKID = Convert.ToInt32(e.CommandArgument)
                    Me.Datalist2.SelectedIndex = e.Item.ItemIndex
                    Dim SelectedMachine As String = CType(Me.Datalist2.SelectedItem.FindControl("linkDeptName"), LinkButton).Text
                    DeptName = SelectedMachine
                    BindDataListDept()
                End If
                ScriptManager.RegisterStartupScript(Me.Parent, Me.Parent.GetType(), DateTime.Now.ToString(), "<script>parent.iFrameHeight();</script>", False)
        End Select
    End Sub
#End Region

#Region "   PagerControl Event"
    Private Sub PagerControl1_PageChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles PagerControl1.PageChanged
        BindDataGrid()
    End Sub
    Private Sub PagerControl1_PageSizeChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles PagerControl1.PageSizeChanged
        Me.PageIndex = 0
        BindDataGrid()
    End Sub
#End Region

#Region "DataGrid Events"
    Private Sub DataGrid1_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs) Handles DataGrid1.ItemDataBound
        If e.Item.ItemType = ListItemType.AlternatingItem Or e.Item.ItemType = ListItemType.Item Then
            Dim URLString As String
            URLString = "../GMPCSI/GMPCSIMoudle.aspx?DeptPKID={0}&ClientPKID={1}&CSITime={2}"
            Dim ResultPKID As String = Me.DataGrid1.DataKeys(e.Item.ItemIndex).ToString
            URLString = String.Format(URLString, DeptPKID, ResultPKID, CSITime)
            CType(e.Item.FindControl("EditLink"), HyperLink).NavigateUrl = URLString
            Dim lblSendTimel As Label = CType(e.Item.FindControl("lblSendTimel"), Label)
            If lblSendTimel.Text = "9999-12-31" Then
                lblSendTimel.Text = "被動調查"
            End If
        End If
    End Sub
#End Region


    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        '在這裡放置使用者程式碼以初始化網頁
        If Not IsPostBack Then
            Me.Datalist1.SelectedIndex = 0
            BindDataListPeriod()
        End If
    End Sub


    Private Sub btnSearch_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnSearch.Click
        Me.PageIndex = 0
        Dim SearchString As String = String.Empty
        If Me.txtGroup.Text <> String.Empty Then
            SearchString = SearchString & String.Format(" AcceptGroup like '%{0}%' ", Me.txtGroup.Text.Trim)
        End If


        If Me.txtDivision.Text.Trim <> String.Empty Then

            If SearchString <> String.Empty Then
                SearchString = SearchString & String.Format(" AND  AcceptDivision like '%{0}%' ", Me.txtDivision.Text.Trim)
            Else
                SearchString = SearchString & String.Format(" AcceptDivision like '%{0}%' ", Me.txtDivision.Text.Trim)
            End If
        End If

        If Me.txtAcceptDept.Text.Trim <> String.Empty Then

            If SearchString <> String.Empty Then
                SearchString = SearchString & String.Format(" AND  AcceptDept like '%{0}%' ", Me.txtAcceptDept.Text.Trim)
            Else
                SearchString = SearchString & String.Format(" AcceptDept like '%{0}%' ", Me.txtAcceptDept.Text.Trim)
            End If
        End If
        If SearchString <> String.Empty Then
            ViewState("SearchCondition") = SearchString
            BindDataGrid()
            If Me.PagerControl1.TotalRecords = 0 Then
                Me.lblSearchResult.Text = "共找到0筆符合條件的資料!"
            Else
                Me.lblSearchResult.Text = "共找到" + Me.PagerControl1.TotalRecords.ToString + "筆符合條件的資料!"
            End If
        End If
    End Sub

    Private Sub btnReview_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnReview.Click
        Me.txtGroup.Text = String.Empty
        Me.txtDivision.Text = String.Empty
        Me.txtAcceptDept.Text = String.Empty
        ViewState("SearchCondition") = Nothing
        Me.lblSearchResult.Text = String.Empty
        Me.PageIndex = 0
        BindDataGrid()
    End Sub

    Private Sub btnExportExcel_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnExportExcel.Click
        Dim SearchCondition As String = String.Empty
        If ViewState("SearchCondition") Is Nothing Then
            SearchCondition = " CSITime=" + CSITime.ToString + " AND DeptPKID=" + DeptPKID.ToString + "  AND IsSubmited=2 "
        Else
            SearchCondition = " CSITime=" + CSITime.ToString + " AND DeptPKID=" + DeptPKID.ToString + "  AND IsSubmited=2 " + _
                              " AND " + CType(ViewState("SearchCondition"), String)
        End If
        Dim ds As DataSet = GEPCSI_Result.GetDsBySearchCondtion(SearchCondition)
        If Not ds Is Nothing AndAlso ds.Tables.Count > 0 AndAlso ds.Tables(0).Rows.Count > 0 Then
            Dim HeaderList As String() = Nothing
            Dim HeaderTextList As String() = Nothing
            HeaderList = New String() {"SubmitGroup", "SubmitDivision", "SubmitDept", "SubmitMan", "SubmitExt", "SubmitEmail", "SendTime", "SubmitTime"}
            HeaderTextList = New String() {"事業群", "事業處", "受訪單位", "受訪人", "受訪人分機", "受訪人Email", "發送時間", "提交時間"}

            Dim data As String = ExportCSVData.ExportCSV(HeaderList, ds.Tables(0), HeaderTextList)
            Dim temp As String = String.Format("attachment;filename={0}", "CSIResultData.csv")
            Response.ClearHeaders()
            Response.ContentEncoding = System.Text.Encoding.Default '取得系統目前 ANSI 字碼頁的編碼方式。
            Response.Charset = "UTF-8"
            Response.ContentType = "application/csv"
            Response.AppendHeader("Content-disposition", temp)
            Response.Write(data)
            Response.End()
        End If
    End Sub
End Class
