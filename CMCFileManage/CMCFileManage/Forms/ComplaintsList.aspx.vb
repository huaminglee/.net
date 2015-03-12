Imports Platform.eAuthorize

Partial Public Class ComplaintsList
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
                ViewState(HIDE_SORTFIELD) = "BeComplaintsDept"
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
                SearchCondition = "RecordDeleted=0  "
                If Not UserInfo.CurrentUserInstance Is Nothing AndAlso (UserInfo.IsInRoles("QA") OrElse UserInfo.IsInRoles("Audit") OrElse UserInfo.IsInRoles("SYS_ADMINISTRATOR")) Then

                Else                                              '外廠區人員或本廠區非QA或本廠區非Audit人員
                    Dim changqu As String = "LH"
                    Dim curneefaround As String = "龍華檢測中心"
                    If Not Request.Cookies("changqu") Is Nothing Then
                        changqu = Server.HtmlEncode(Request.Cookies("changqu").Value)
                    End If
                    Select Case changqu
                        Case "LH"
                            curneefaround = "龍華檢測中心"
                        Case "YT"
                            curneefaround = "煙台檢測中心"
                        Case "WH"
                            curneefaround = "武漢檢測中心"
                        Case "CD"
                            curneefaround = "成都檢測中心"
                        Case "WSJ"
                            curneefaround = "吳淞江檢測中心"
                        Case "GL"
                            curneefaround = "觀瀾檢測中心"
                        Case "CQ"
                            curneefaround = "重慶檢測中心"
                        Case "ZZ"
                            curneefaround = "鄭州檢測中心"
                    End Select
                    SearchCondition += String.Format(" AND QyuLocation ='{0}'", curneefaround)
                    Dim curdept As String
                    Dim curdeptstr As String = String.Empty
                    If Not Request.Cookies("userdepts") Is Nothing Then
                        Dim dept As String() = HttpUtility.UrlDecode(Request.Cookies("userdepts").Value).ToString.Split(";")
                        For Each curdept In dept
                            curdeptstr += curdept
                        Next
                        SearchCondition += String.Format(" AND (charindex(BeComplaintsDept,'{0}')>0 or charindex(ComplaintsDept,'{0}')>0)", curdeptstr)
                    Else
                        SearchCondition = "  1>2"         '無部門信息
                    End If

                End If
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
            BindGridData(InitSearch)
            If UserInfo.IsInRoles("QALEADER") Then
                Me.GridView1.Columns(8).Visible = True
            End If
            'Dim helper As New GridViewHelper(Me.GridView1)
            'helper.RegisterGroup("BeComplaintsDept", True, False)
            'helper.ApplyGroupSort()
        End If
    End Sub
    Private Sub BindGridData(ByVal SearchCondition As String)
        Dim TotalRecord As Integer = 0
        Dim ds As DataSet = TableBMHDAL.GetPageInfoBySearchCondition("Complaints", SearchCondition, "*", SortField, PageSize, PageIndex, TotalRecord)
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
    Dim count As Integer = 0
    Protected Sub GridView1_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GridView1.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            e.Row.Attributes.Add("onmouseover", "this.style.cursor='hand';this.style.color='#FFFFFF'; currentcolor=this.style.backgroundColor;this.style.backgroundColor='#40A0FE',this.style.fontWeight='';")
            e.Row.Attributes.Add("onmouseout", "this.style.color='#1e5494'; this.style.backgroundColor=currentcolor,this.style.fontWeight='';")
            If e.Row.RowState = DataControlRowState.Alternate OrElse e.Row.RowState = DataControlRowState.Normal Then
                count += 1
                Dim HLDetail As HyperLink = CType(e.Row.FindControl("HLDetail"), HyperLink)
                Dim pkid As Integer = Convert.ToInt32(CType(e.Row.FindControl("LblPKID"), Label).Text)
                Dim DocUniqueID As String = CType(e.Row.FindControl("lblDocUniqueID"), Label).Text
                Dim returnurl As String = "../Forms/ComplaintsDetail.aspx?pkid=" + pkid.ToString
                If (DocUniqueID <> String.Empty AndAlso DocUniqueID <> Guid.Empty.ToString) Then
                    returnurl = returnurl + "&" + Global_asax.QUERY_DOCUNIQUEID + "=" + DocUniqueID
                End If
                HLDetail.NavigateUrl = returnurl
                e.Row.Attributes.Add("onclick", "window.location.href='" + returnurl + "';")
                Dim BtnCancel As ImageButton = TryCast(e.Row.FindControl("BtnDelete"), ImageButton)
                BtnCancel.Attributes.Add("onclick", " return confirm('確定要刪除該記錄嗎?');")
                Dim LbIsfinished As Label = CType(e.Row.FindControl("LbIsfinished"), Label)
                Dim LbIsFinishedShow As Label = CType(e.Row.FindControl("LbIsFinishedShow"), Label)
                If LbIsfinished.Text = "0" Then
                    LbIsFinishedShow.Text = "未結案"
                ElseIf LbIsfinished.Text = "1" Then
                    LbIsFinishedShow.Text = "已結案"
                End If
                Dim LbDesc As Label = CType(e.Row.FindControl("LbDesc"), Label)
                If LbDesc.Text.Length > 10 Then
                    LbDesc.ToolTip = LbDesc.Text
                    LbDesc.Text = LbDesc.Text.Substring(0, 10) + "..."
                End If
            End If
        ElseIf e.Row.RowType = DataControlRowType.Footer Then
            e.Row.Cells(9).Text = count.ToString
        End If

    End Sub
    Protected Sub GridView1_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles GridView1.RowDeleting
        Dim mpkid As Integer = Convert.ToInt32(GridView1.DataKeys(e.RowIndex).Value)
        ComplaintsDAL.Delete(mpkid)
        BindGridData(SearchCondition)
        'Dim helper As New GridViewHelper(Me.GridView1)
        'helper.RegisterGroup("BeComplaintsDept", True, False)
        'helper.ApplyGroupSort()
    End Sub
    Private Sub PagerControl1_PageChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles PagerControl1.PageChanged
        BindGridData(SearchCondition)
        'Dim helper As New GridViewHelper(Me.GridView1)
        'helper.RegisterGroup("BeComplaintsDept", True, False)
        'helper.ApplyGroupSort()
    End Sub

    Private Sub PagerControl1_PageSizeChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles PagerControl1.PageSizeChanged
        BindGridData(SearchCondition)
        'Dim helper As New GridViewHelper(Me.GridView1)
        'helper.RegisterGroup("BeComplaintsDept", True, False)
        'helper.ApplyGroupSort()
    End Sub
    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button1.Click
        Dim newsearchcondition As StringBuilder = New StringBuilder()
        newsearchcondition.Append(InitSearch)
        If Me.TxtSearchCondition.Text.Trim() <> String.Empty Then
            newsearchcondition.Append(String.Format(" AND (ComlaintsPerson LIKE '%{0}%' OR ComplaintsDept LIKE '%{0}%' OR BeComplaintsDept LIKE '%{0}%' OR ComplaintsDesc LIKE '%{0}%' OR RecordNO LIKE '%{0}%')", Me.TxtSearchCondition.Text.ToString.Trim))
        End If
        ViewState("SearchCondition") = newsearchcondition
        BindGridData(SearchCondition)
        'Dim helper As New GridViewHelper(Me.GridView1)
        'helper.RegisterGroup("BeComplaintsDept", True, False)
        'helper.ApplyGroupSort()
    End Sub

    Protected Sub GridView1_Sorting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewSortEventArgs) Handles GridView1.Sorting
        Dim SortFieldName As String = e.SortExpression
        count = 0
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
        BindGridData(SearchCondition)

    End Sub
End Class