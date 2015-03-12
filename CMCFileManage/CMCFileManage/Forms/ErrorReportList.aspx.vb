Imports Platform.eAuthorize

Partial Public Class ErrorReportList
    Inherits System.Web.UI.Page
#Region "字段定義"
    Private Const _SearchConditon As String = "ViewState:SearchConditon"
    Private Const HIDE_SORTFIELD As String = "ViewState:SortField"
    Private Const HIDE_SortOrder As String = "ViewState:SortOrder"
#End Region
#Region "屬性"
    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' 當前頁的索引
    ''' </summary>
    ''' -----------------------------------------------------------------------------
    Public Property PageIndex() As Integer
        Get
            Return Me.PagerControl1.CurrentPage
        End Get
        Set(ByVal Value As Integer)
            Me.PagerControl1.CurrentPage = Value + 1
        End Set
    End Property

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' 當前頁的行
    ''' </summary>
    ''' -----------------------------------------------------------------------------
    Public Property PageSize() As Integer
        Get
            Return Me.PagerControl1.RecordsPerPage
        End Get
        Set(ByVal Value As Integer)
            Me.PagerControl1.RecordsPerPage = Value
        End Set
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
                ViewState(HIDE_SORTFIELD) = "pkid"
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

    Private ReadOnly Property InitSearch() As String
        Get
            If ViewState("InitSearch") IsNot Nothing Then
                Return CStr(ViewState("InitSearch"))
            Else
                Dim SearchCondition As String

                SearchCondition = "RecordDeleted=0"

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
#End Region
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            If UserInfo.IsInRoles("QA") OrElse UserInfo.IsInRoles("QALEADER") Then
                Me.add.Visible = True
                If UserInfo.IsInRoles("QALEADER") Then
                    Me.GridView1.Columns(8).Visible = True
                End If
            Else
                Me.add.Visible = False
            End If
            ' BindGrid(InitSearch)
            BindGridTop()
        End If
    End Sub
    Private Sub BindGridTop()
        Dim dt As DataTable = ErrorReportDAL.GetQyBySearchcondition(InitSearch)
        Me.GridViewTop.DataSource = dt
        Me.GridViewTop.DataBind()
    End Sub
    Private Sub BindGrid(ByVal SearchCondition As String)
        Dim TotalRecord As Integer = 0
        Dim ds As DataSet = TableBMHDAL.GetPageInfoBySearchCondition("ErrorReport", SearchCondition, "*", SortField, PageSize, PageIndex, TotalRecord)
        If Not ds Is Nothing Then
            Me.emptyinfo.Visible = False
            Me.PagerControl1.Visible = True
            Me.PagerControl1.TotalRecords = CInt(ds.Tables(1).Rows(0)("TotalRecord"))
            Me.GridView1.DataSource = ds
            Me.GridView1.DataKeyNames = New String() {"PKID"}
            Me.GridView1.DataBind()
        Else
            Me.emptyinfo.Visible = True
            Me.PagerControl1.Visible = False
            Me.GridView1.DataSource = Nothing
            Me.GridView1.DataBind()
        End If


    End Sub
#Region "GridViewEvent"
    Protected Sub GridView1_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GridView1.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            e.Row.Attributes.Add("onmouseover", "this.style.color='#FFFFFF'; currentcolor=this.style.backgroundColor;this.style.backgroundColor='#40A0FE',this.style.fontWeight='';")
            e.Row.Attributes.Add("onmouseout", "this.style.color='#1e5494'; this.style.backgroundColor=currentcolor,this.style.fontWeight='';")
            Dim mPKID As Integer = CInt(GridView1.DataKeys(e.Row.RowIndex).Value)
            Dim HLDetail As HyperLink = CType(e.Row.FindControl("HLDetail"), HyperLink)
            Dim ReturnURL As String = "../Forms/ErrorReportDetail.aspx?pkid=" + mPKID.ToString

            HLDetail.NavigateUrl = ReturnURL
            Dim BtnCancel As ImageButton = TryCast(e.Row.FindControl("BtnDelete"), ImageButton)
            BtnCancel.Attributes.Add("onclick", " return confirm('確定要刪除該記錄嗎?');")

            Dim LbType As Label = CType(e.Row.FindControl("LbType"), Label)
            Dim LbTypeShow As Label = CType(e.Row.FindControl("LbTypeShow"), Label)
            If LbType.Text = "1" Then
                LbTypeShow.Text = "主要缺失"
            ElseIf LbType.Text = "2" Then
                LbTypeShow.Text = "次要缺失"
            ElseIf LbType.Text = "3" Then
                LbTypeShow.Text = "建議觀察"
            ElseIf LbType.Text = "4" Then
                LbTypeShow.Text = "觀察"
            End If
            Dim LbResult As Label = CType(e.Row.FindControl("LbResult"), Label)
            Dim LbresultShow As Label = CType(e.Row.FindControl("LbresultShow"), Label)
            Select Case LbResult.Text
                Case "1"
                    LbresultShow.Text = "已結案"
                Case "2"
                    LbresultShow.Text = "未結案"
            End Select
        End If
    End Sub
    Protected Sub GridView1_Sorting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewSortEventArgs) Handles GridView1.Sorting
        Dim SortFieldName As String = e.SortExpression
        If SortFieldName <> String.Empty Then
            Me.SortField = SortFieldName
        End If
        If Me.SortOrder = "ASC" Then
            Me.SortOrder = "DESC"
        ElseIf Me.SortOrder = "DESC" Then
            Me.SortOrder = "ASC"
        Else
            Me.SortOrder = "DESC"
        End If
        BindGrid(SearchCondition)
    End Sub
    Protected Sub GridView1_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles GridView1.RowDeleting
        Dim mpkid As Integer = Convert.ToInt32(GridView1.DataKeys(e.RowIndex).Value)
        ErrorReportDAL.Delete(mpkid)
        Dim newdeletelog As DeleteLogInfo = New DeleteLogInfo()
        newdeletelog.pkid = 0
        newdeletelog.Parentid = mpkid
        newdeletelog.parenttype = "偏差報告"
        newdeletelog.DeleteUserName = UserInfo.CurrentUserCHName
        newdeletelog.DeleteUserSID = UserInfo.CurrentUserID
        newdeletelog.RecordCreated = DateTime.Now
        Dim newdeletedal As DeleteLogDAL = New DeleteLogDAL(newdeletelog)
        newdeletedal.Save()
        BindGrid(SearchCondition)
    End Sub
#End Region
#Region "pageEvent"

    Private Sub PagerControl1_PageChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles PagerControl1.PageChanged
        BindGrid(SearchCondition)
    End Sub

    Private Sub PagerControl1_PageSizeChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles PagerControl1.PageSizeChanged
        BindGrid(SearchCondition)
    End Sub
#End Region
    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button1.Click
        Dim newsearchcondition As StringBuilder = New StringBuilder()
        newsearchcondition.Append(InitSearch)
        Me.GridViewTop.Visible = False
        Me.GridView1.Visible = True
        If Me.TxtSearchCondition.Text.Trim() <> String.Empty Then
            newsearchcondition.Append(String.Format(" AND (Qulocation LIKE '%{0}%' OR Dept LIKE '%{0}%' OR ReportBH LIKE '%{0}%' OR SpecTitle LIKE '%{0}%')", Me.TxtSearchCondition.Text.ToString.Trim))
        End If
        ViewState("SearchCondition") = newsearchcondition
        BindGrid(SearchCondition)
    End Sub

    Protected Sub GridViewTop_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GridViewTop.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            Dim LbQulocation As Label = CType(e.Row.FindControl("LbQulocation"), Label)
            Dim Image2 As Image = CType(e.Row.FindControl("Image2"), Image)
            Image2.Attributes.Add("onclick", "BindQy('" + e.Row.RowIndex.ToString + "','" + LbQulocation.Text.ToString + "')")
        End If
    End Sub

    Protected Sub Button3_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button3.Click
        BindQu()
    End Sub
    Private Sub BindQu()
        Dim deptname As String = Me.Hiddencurdeptname.Value
        Dim rowindex As Integer = Me.Hiddencurrowindex.Value
        Dim dr As GridViewRow = Me.GridViewTop.Rows(rowindex)
        Dim curgridQu As GridPersonDept = CType(dr.FindControl("GridPersonDept1"), GridPersonDept)
        curgridQu.Searchcondition = InitSearch + " and Qulocation='" + deptname.ToString + "'"
        curgridQu.ParentType = 2
        curgridQu.Parentindex = rowindex
        curgridQu.BindDept()
        Dim Image2 As Image = CType(dr.FindControl("Image2"), Image)
        Image2.Attributes.Remove("onclick")
        Image2.Attributes.Add("onclick", "deptchangeshow('" + curgridQu.ClientID + "_GridView1','" + rowindex.ToString + "')")
    End Sub

    Protected Sub BtnSetCSSshow_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BtnSetCSSshow.Click
        Dim curQyindex As String = Me.HiddencursetcssQyindex.Value
        Dim curgridqy As GridPersonDept = CType(Me.GridViewTop.Rows(curQyindex).FindControl("GridPersonDept1"), GridPersonDept)
        curgridqy.DisplayInfo = "Show"
        curgridqy.BindDept()
    End Sub

    Protected Sub BtnSetCSShidd_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BtnSetCSShidd.Click
        Dim curQyindex As String = Me.HiddencursetcssQyindex.Value
        Dim curgridqy As GridPersonDept = CType(Me.GridViewTop.Rows(curQyindex).FindControl("GridPersonDept1"), GridPersonDept)
        curgridqy.DisplayInfo = "Hid"
        curgridqy.BindDept()
    End Sub
    Protected Sub BtnSetFileCssShow_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BtnSetFileCssShow.Click
        Dim curfileindex As String = Me.Hiddencursetcssfileindex.Value
        Dim fatherindex = Me.Hiddenparenetindex.Value
        Dim curgridqy As GridPersonDept = CType(Me.GridViewTop.Rows(fatherindex).FindControl("GridPersonDept1"), GridPersonDept)
        Dim curequip As GridErropreport = CType(CType(curgridqy.FindControl("Gridview1"), GridView).Rows(curfileindex).FindControl("GridErropreport1"), GridErropreport)
        curequip.DisplayInfo = "Show"
        curequip.Binderrorreport()
    End Sub

    Protected Sub BtnSetFileCSSHid_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BtnSetFileCSSHid.Click
        Dim curfileindex As String = Me.Hiddencursetcssfileindex.Value
        Dim fatherindex = Me.Hiddenparenetindex.Value
        Dim curgridqy As GridPersonDept = CType(Me.GridViewTop.Rows(fatherindex).FindControl("GridPersonDept1"), GridPersonDept)
        Dim curequip As GridErropreport = CType(CType(curgridqy.FindControl("Gridview1"), GridView).Rows(curfileindex).FindControl("GridErropreport1"), GridErropreport)
        curequip.DisplayInfo = "Hid"
        curequip.Binderrorreport()
    End Sub
End Class