Imports Platform.eAuthorize
Partial Public Class ListAction
    Inherits System.Web.UI.UserControl
#Region "Property"

    ''' <summary>
    ''' DDLSearchType的搜索類型
    ''' </summary>
    ''' <remarks></remarks>
    Public Enum SearchTypeValue
        TxtValue = 0
        DDLValue = 1
        DateTimeValue = 2
        DateTimeSpanValue = 3
    End Enum
    ''' <summary>
    ''' Excel匯出數據源
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property ExcelDt() As DataTable
        Get
            If ViewState("ExcelDt") Is Nothing Then
                ViewState("ExcelDt") = BLLClass.GetInfosBySearchCondition("").Tables(0)
            End If
            Return ViewState("ExcelDt")
        End Get
        Set(ByVal value As DataTable)
            ViewState("ExcelDt") = value
        End Set
    End Property
    ''' <summary>
    ''' gridview的ID,默認GridView1
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property GrdID() As String
        Get
            If ViewState("GrdID") = Nothing Then
                Return "GridView1"
            Else
                Return ViewState("GrdID")
            End If
        End Get
        Set(ByVal value As String)
            ViewState("GrdID") = value
        End Set
    End Property
    ''' <summary>
    ''' 操作類(必填)
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property BLLClass() As IFactory
        Get
            Return ViewState("BLLClass")
        End Get
        Set(ByVal value As IFactory)
            ViewState("BLLClass") = value
        End Set
    End Property
    ''' <summary>
    ''' 新增跳轉頁面(必填)
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property UrlAdd() As String
        Get
            Return ViewState("UrlAdd")
        End Get
        Set(ByVal value As String)
            ViewState("UrlAdd") = value
        End Set
    End Property
    ''' <summary>
    ''' 搜索資料庫中的欄位名稱,SearchVisible必須為True才有效
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property SearchKey() As String
        Get
            If ViewState("SearchKey") Is Nothing Then
                ViewState("SearchKey") = ""
            End If
            Return ViewState("SearchKey")
        End Get
        Set(ByVal value As String)
            ViewState("SearchKey") = value
        End Set
    End Property
    ''' <summary>
    ''' 是否顯示搜索功能
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property SearchVisible() As Boolean
        Get
            If ViewState("SearchBool") Is Nothing Then
                Return False
            Else
                Return ViewState("SearchBool")
            End If
        End Get
        Set(ByVal value As Boolean)
            ViewState("SearchBool") = value
        End Set
    End Property

    Private ReadOnly Property GrdView() As GridView
        Get
            If Me.Page.Controls.Count = 1 Then
                Return CType(Me.Page.Master.FindControl("Form1").FindControl("ContentPlaceHolder1").FindControl(GrdID), GridView)

            Else
                Return CType(Me.Page.FindControl(GrdID), GridView)
            End If
        End Get
    End Property

    ''' <summary>
    ''' 是否顯示刪除
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property DeleteVisible() As Boolean
        Get
            If ViewState("DeleteVisible") Is Nothing Then
                Return True
            Else
                Return ViewState("DeleteVisible")
            End If
        End Get
        Set(ByVal value As Boolean)
            ViewState("DeleteVisible") = value
        End Set
    End Property
    ''' <summary>
    ''' 是否顯示新增
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property AddVisible() As Boolean
        Get
            If ViewState("AddVisible") Is Nothing Then
                Return True
            Else
                Return ViewState("AddVisible")
            End If
        End Get
        Set(ByVal value As Boolean)
            ViewState("AddVisible") = value
        End Set
    End Property
    ''' <summary>
    ''' 搜索值類型,默認值SearchTypeValue.TxtValue(如果為SearchTypeValue.DDLValue則需設置二級聯動DDL)
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property ValueType() As SearchTypeValue
        Get
            If ViewState("ValueType") Is Nothing Then
                ViewState("ValueType") = SearchTypeValue.TxtValue
            End If
            Return ViewState("ValueType")
        End Get
        Set(ByVal value As SearchTypeValue)
            ViewState("ValueType") = value
        End Set
    End Property
    ''' <summary>
    ''' 搜索值
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property SearchValue() As String
        Get
            If ViewState("SearchValue") Is Nothing Then
                ViewState("SearchValue") = ""
            End If
            Return ViewState("SearchValue")
        End Get
        Set(ByVal value As String)
            ViewState("SearchValue") = value
        End Set
    End Property
#End Region
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            ControlVisible()
        End If
        Me.LnkDelete.Attributes.Add("onclick", "return confirm('請確認是否刪除這筆資料?');")
       
    End Sub
    ''' <summary>
    ''' 根據搜索類型顯示control
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub ControlVisible()
        tdSearch.Visible = SearchVisible
        LnkDelete.Visible = DeleteVisible
        LnkAdd.Visible = AddVisible
        Select Case ValueType
            Case SearchTypeValue.TxtValue
                TxtSearch1.Attributes.Add("onfocus", "")
                TxtSearch1.Text = ""
                tdTime2.Visible = False
                TxtSearch1.Visible = True
                DDLSearchValue.Visible = False
            Case SearchTypeValue.DDLValue
                TxtSearch1.Text = ""
                TxtSearch1.Attributes.Add("onfocus", "")
                DDLSearchValue.Visible = True
                TxtSearch1.Visible = False
                tdTime2.Visible = False
            Case SearchTypeValue.DateTimeValue
                'onfocus="setDay(this)"
                TxtSearch1.Attributes.Add("onfocus", "setDay(this)")
                TxtSearch1.Visible = True
                DDLSearchValue.Visible = False
                tdTime2.Visible = False
            Case SearchTypeValue.DateTimeSpanValue
                TxtSearch1.Attributes.Add("onfocus", "setDay(this)")
                tdTime2.Visible = True
                TxtSearch1.Visible = True
                DDLSearchValue.Visible = False
            Case Else

        End Select
    End Sub



    Protected Sub LnkDelete_Click(ByVal sender As Object, ByVal e As EventArgs) Handles LnkDelete.Click
        Dim grd As GridView = GrdView


        Dim i As Integer
        Dim RowCount As Integer
        If Not grd Is Nothing Then
            RowCount = grd.Rows.Count
            If RowCount > 0 Then
                For i = 0 To RowCount - 1
                    If CType(grd.Rows(i).FindControl("chkDelete"), CheckBox).Checked Then
                        Dim ListPKID As String = grd.Rows(i).Cells(1).Text
                        BLLClass.Delete(CType(ListPKID, Integer))
                    End If
                Next
                ' Dim ds As DataSet = BLLClass.GetInfosBySearchCondition("")
                ' BindData(ds)
                Response.Redirect(HttpContext.Current.Request.Url.AbsoluteUri)
            End If

            'BindData()
        End If
    End Sub

    Protected Sub LnkAdd_Click(ByVal sender As Object, ByVal e As EventArgs) Handles LnkAdd.Click
        Response.Redirect(UrlAdd)
    End Sub


    Protected Sub BtnSearch_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BtnSearch.Click
        Dim SearchCondition As String = ""

        Select Case ValueType
            Case SearchTypeValue.TxtValue

                SearchCondition = DDLSearchType.SelectedValue + " like '%" + TxtSearch1.Text.Trim + "%' order by createTime desc"
            Case SearchTypeValue.DDLValue
                SearchCondition = DDLSearchType.SelectedValue + "='" + DDLSearchValue.SelectedValue + "' order by createTime desc"
            Case SearchTypeValue.DateTimeValue
                SearchCondition = DDLSearchType.SelectedValue + "='" + TxtSearch1.Text.Trim + "' order by createTime desc"
            Case SearchTypeValue.DateTimeSpanValue
                SearchCondition = DDLSearchType.SelectedValue + " between '" + TxtSearch1.Text.Trim + "' and '" + TxtSearch2.Text.Trim + "' order by createTime desc"
            Case Else
                SearchCondition = ""
        End Select

        Dim ds As DataSet = BLLClass.GetInfosBySearchCondition(SearchCondition)
        BindData(ds)
    End Sub

    Sub BindData(ByVal ds As DataSet)
        Dim grd As GridView = GrdView
        grd.DataSource = ds.Tables(0)
        Dim uctl As UCtlGrdPage = Me.Parent.FindControl("")
        UCtlPage(ds.Tables(0))
        ExcelDt = ds.Tables(0)
        grd.DataBind()
    End Sub

    Sub UCtlPage(ByVal obj As Object)
        If Me.Page.Master IsNot Nothing Then
            Dim UCtl As UCtlGrdPage = Me.Page.Master.FindControl("ContentPlaceHolder1").FindControl("UCtlGrdPage1")
            UCtl.DataSource = obj
            UCtl.Grd_BD()
        End If

    End Sub

    Protected Sub BtnReset_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BtnReset.Click

        TxtSearch1.Text = ""
        TxtSearch2.Text = ""
        DDLSearchType.SelectedValue = -1
        DDLSearchValue.SelectedValue = -1
        Dim ds As DataSet = BLLClass.GetInfosBySearchCondition(" 1=1 order by createTime desc")
        If ds IsNot Nothing Then
            BindData(ds)
        End If
    End Sub



    Function EOccasion(ByVal value As Integer) As String
        Select Case value
            Case 1
                Return "開機"
            Case 2
                Return "制程"
            Case 3
                Return "完工"
            Case Else
                Return ""
        End Select
    End Function

    Function ImproveLv(ByVal value As Integer) As String
        Select Case value
            Case 1
                Return "無改善"
            Case 2
                Return "部份改善"
            Case 3
                Return "完全改善"
            Case Else
                Return ""
        End Select
    End Function

    Protected Sub ImageButton1_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImageButton1.Click
        Dim dt As DataTable = New DataTable
        Dim dtcol() As DataColumn = New DataColumn(GrdView.Columns.Count) {}

        dtcol(0) = New DataColumn
        dtcol(0).DataType = Type.GetType("System.String")
        dtcol(0).AutoIncrement = True
        dtcol(0).AutoIncrementSeed = 1
        dtcol(0).AutoIncrementStep = 1
        dtcol(0).ColumnName = "ID"
        For i As Integer = 0 To GrdView.Columns.Count - 1
            'dtcol(i).ColumnName = GrdView.Columns(i).HeaderText
            dtcol(i + 1) = New DataColumn
            dtcol(i + 1).DataType = Type.GetType("System.String")
            dtcol(i + 1).AutoIncrement = False
            'dtcol(i).Caption = GrdView.Columns(1).BoundField
            If GrdView.Columns(i).GetType().Name = "BoundField" Then

                dtcol(i + 1).ColumnName = CType(GrdView.Columns(i), BoundField).DataField
            Else
                dtcol(i + 1).ColumnName = "0"
            End If
            If i = 17 Then
                dtcol(i + 1).ColumnName = "CreaterID"
            End If
            If GrdView.Columns(i).HeaderStyle.CssClass = "Display" Then
                dtcol(i + 1).ColumnName = "0"
            End If
        Next
        For Each dc As DataColumn In dtcol
            If dc.ColumnName <> "0" Then
                dt.Columns.Add(dc)
            End If
        Next
        For i As Integer = ExcelDt.Rows.Count - 1 To 0 Step -1
            Dim row As DataRow = dt.NewRow()
            For Each dc As DataColumn In dt.Columns
                If dc.ColumnName <> "ID" Then
                    row(dc.ColumnName) = ExcelDt.Rows(i)(dc.ColumnName)
                    If dc.ColumnName = "ExceptionOccasion" Then
                        row(dc.ColumnName) = EOccasion(ExcelDt.Rows(i)(dc.ColumnName))
                    End If
                    If dc.ColumnName = "ImproveLv" Then
                        row(dc.ColumnName) = ImproveLv(ExcelDt.Rows(i)(dc.ColumnName))
                    End If
                    If dc.ColumnName = "ExceptionDate" Then
                        row(dc.ColumnName) = CType(ExcelDt.Rows(i)(dc.ColumnName), Date).ToString("yyyy-MM-dd")
                    End If
                    If dc.ColumnName = "CreateTime" Then
                        row(dc.ColumnName) = CType(ExcelDt.Rows(i)(dc.ColumnName), Date).ToString("yyyy-MM-dd")
                    End If
                    If dc.ColumnName = "CreaterID" Then
                        row(dc.ColumnName) = UserInfo.GetSpecAccountInfo(ExcelDt.Rows(i)(dc.ColumnName).ToString).UserName
                    End If

                End If

            Next
            dt.Rows.Add(row)

        Next



        'dt.DefaultView.Sort = "CreateTime DESC"
        DataExcel.ToExcel(dt, "RecordReport.xls")

    End Sub
End Class