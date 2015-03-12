Imports Platform.eAuthorize

Partial Public Class StandardSearchManageList
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
                ViewState(HIDE_SORTFIELD) = "SearchDept"
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
                    '    SearchCondition += String.Format(" AND QYLocation ='{0}'", curneefaround)
                    Dim curdept As String
                    Dim curdeptstr As String = String.Empty
                    If Not Request.Cookies("userdepts") Is Nothing Then
                        Dim dept As String() = HttpUtility.UrlDecode(Request.Cookies("userdepts").Value).ToString.Split(";")
                        For Each curdept In dept

                            Dim ds As DataSet = SqlHelper.ExecuteDataset(ConfigurationInfo.ConnectionString, "DeptNameChange_GetDeptInmysysByDeptNameINeflow", curdept, changqu)
                            Dim dt As DataTable = ds.Tables(0)
                            If dt.Rows.Count > 0 Then
                                curdept = dt.Rows(0).Item("DeptNameInmysys").ToString
                            Else
                                curdept = curdept
                            End If

                            curdeptstr += curdept
                        Next
                        SearchCondition += String.Format(" AND charindex(SearchDept,'{0}')>0", curdeptstr)  '部門在分發單位中
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
            If UserInfo.CurrentUserInstance Is Nothing OrElse Not UserInfo.IsInRoles("LabFileManager") Then
                Me.add.Attributes.Add("style", "display:none")
            End If
            'BindGrid(InitSearch)
            BindGridDept()
        End If
    End Sub
    Private Sub BindGrid(ByVal SearchCondition As String)
        Dim TotalRecord As Integer = 0
        Dim ds As DataSet = TableBMHDAL.GetPageInfoBySearchCondition("StandardSearchManage", SearchCondition, "*", SortField, PageSize, PageIndex, TotalRecord)
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
    Protected Sub GridView1_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GridView1.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            e.Row.Attributes.Add("onmouseover", "this.style.color='#FFFFFF'; currentcolor=this.style.backgroundColor;this.style.backgroundColor='#40A0FE',this.style.fontWeight='';")
            e.Row.Attributes.Add("onmouseout", "this.style.color='#1e5494'; this.style.backgroundColor=currentcolor,this.style.fontWeight='';")
            Dim mPKID As Integer = CInt(GridView1.DataKeys(e.Row.RowIndex).Value)
            Dim HLDetail As HyperLink = CType(e.Row.FindControl("HLDetail"), HyperLink)
            Dim ReturnURL As String = "../Forms/StandardSearchManageDetail.aspx?pkid=" + mPKID.ToString
            HLDetail.NavigateUrl = ReturnURL
            Dim BtnCancel As ImageButton = TryCast(e.Row.FindControl("BtnDelete"), ImageButton)
            BtnCancel.Attributes.Add("onclick", " return confirm('確定要刪除該記錄嗎?');")
        End If
    End Sub
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
        Me.GridView1.Visible = False
        If Me.TxtSearchCondition.Text.Trim() <> String.Empty Then
            newsearchcondition.Append(String.Format(" AND (SearchDept LIKE '%{0}%' OR SearchJD LIKE '%{0}%' OR SearchUser LIKE '%{0}%' OR Remark LIKE '%{0}%')", Me.TxtSearchCondition.Text.ToString.Trim))
        End If
        ViewState("SearchCondition") = newsearchcondition
        BindGrid(SearchCondition)
    End Sub


    Protected Sub GridView1_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles GridView1.RowDeleting
        Dim mpkid As Integer = Convert.ToInt32(GridView1.DataKeys(e.RowIndex).Value)
        StandardSearchManageDAL.Delete(mpkid)
        BindGrid(SearchCondition)
    End Sub

    Protected Sub GridViewTop_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GridViewTop.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            Dim LbApplydept As Label = CType(e.Row.FindControl("LbApplydept"), Label)
            Dim Image2 As Image = CType(e.Row.FindControl("Image1"), Image)
            Image2.Attributes.Add("onclick", "BindSiFile('" + e.Row.RowIndex.ToString + "','" + LbApplydept.Text.ToString + "')")
        End If
    End Sub
    Private Sub BindGridDept()
        Dim dt As DataTable = StandardSearchManageDAL.GetDeptBySearchcondition(SearchCondition)

        Me.GridViewTop.DataSource = dt
        Me.GridViewTop.DataBind()

    End Sub
    Protected Sub BtnBindSiBydeptname_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BtnBindSiBydeptname.Click
        Dim deptname As String = Me.Hiddencurdeptname.Value
        Dim curindex As String = Me.Hiddencurrowindex.Value
        Dim dr As GridViewRow = Me.GridViewTop.Rows(curindex)
        Dim LbApplydept As Label = CType(dr.FindControl("LbApplydept"), Label)
        Dim GridStandSearch1 As GridStandSearch = CType(dr.FindControl("GridStandSearch1"), GridStandSearch)
        GridStandSearch1.Searchcondition = SearchCondition + " and SearchDept='" + LbApplydept.Text.ToString + "'"
        GridStandSearch1.Bindstandsearch()
        Dim Image2 As Image = CType(dr.FindControl("Image1"), Image)
        Image2.Attributes.Remove("onclick")
        Image2.Attributes.Add("onclick", "fourdeptchangeshow('" + GridStandSearch1.ClientID + "_GridView1','" + curindex.ToString + "')")
    End Sub

    Protected Sub BtnFourcssShoe_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BtnFourcssShoe.Click
        Dim curfileindex As String = Me.Hiddensetcssfourfileindex.Value
        Dim GridStandSearch1 As GridStandSearch = CType(Me.GridViewTop.Rows(curfileindex).FindControl("GridStandSearch1"), GridStandSearch)
        GridStandSearch1.DisplayInfo = "Show"
        GridStandSearch1.Bindstandsearch()
    End Sub

    Protected Sub BtnFourcssHid_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BtnFourcssHid.Click
        Dim curfileindex As String = Me.Hiddensetcssfourfileindex.Value
        Dim GridStandSearch1 As GridStandSearch = CType(Me.GridViewTop.Rows(curfileindex).FindControl("GridStandSearch1"), GridStandSearch)
        GridStandSearch1.DisplayInfo = "Hid"
        GridStandSearch1.Bindstandsearch()
    End Sub
End Class