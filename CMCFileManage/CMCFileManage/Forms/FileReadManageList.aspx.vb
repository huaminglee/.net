Imports Platform.eAuthorize

Partial Public Class FileReadManageList
    Inherits System.Web.UI.Page
#Region "字段定義"
    Private Const _SearchStatus As String = "ViewState:IsSearch"
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
                ViewState(HIDE_SORTFIELD) = "StateName"
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
            If UserInfo.CurrentUserInstance Is Nothing Then
                Me.add.Attributes.Add("style", "display:none")
                Me.GridView1.Columns(0).Visible = False
                Me.GridView1.Columns(7).Visible = False
            End If
            If UserInfo.IsInRoles("QALEADER") Then
                Me.GridView1.Columns(7).Visible = True
            Else
                Me.GridView1.Columns(7).Visible = False
            End If
            'BindGridData(SearchCondition)
            BindGridTop()
        End If
    End Sub
    Private Sub BindGridTop()
        Dim dt As DataTable = FileReadManageDAL.GetstatenamedBySearchcondition(SearchCondition)
        Me.GridViewTop.DataSource = dt
        Me.GridViewTop.DataBind()
    End Sub
    Private Sub BindGridData(ByVal SearchCondition As String)
        Dim TotalRecord As Integer = 0
        Dim ds As DataSet = TableBMHDAL.GetPageInfoBySearchCondition("ViewFileRead", SearchCondition, "*", SortField, PageSize, PageIndex, TotalRecord)
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
#Region "Custom Paging Event"
    Private Sub PagerControl1_PageChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles PagerControl1.PageChanged
        BindGridData(SearchCondition)


    End Sub
    Private Sub PagerControl1_PageSizeChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles PagerControl1.PageSizeChanged
        BindGridData(SearchCondition)
    End Sub
#End Region
    Protected Sub GridView1_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GridView1.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            If e.Row.RowState = DataControlRowState.Alternate OrElse e.Row.RowState = DataControlRowState.Normal Then
                Dim pkid As Integer = CType(e.Row.FindControl("LblPKID"), Label).Text
                Dim eflowdocid As String = CType(e.Row.FindControl("lblDocUniqueID"), Label).Text
                Dim HLDetail As HyperLink = CType(e.Row.FindControl("HLDetail"), HyperLink)
                Dim returnurl As String = "../Forms/FileReadManageDetail.aspx?pkid=" + pkid.ToString
                Dim BtnCancel As ImageButton = TryCast(e.Row.FindControl("BtnDelete"), ImageButton)
                BtnCancel.Attributes.Add("onclick", " return confirm('確定要刪除該記錄嗎?');")
                If eflowdocid <> String.Empty AndAlso eflowdocid <> Guid.Empty.ToString Then
                    returnurl = returnurl + "&" + Global_asax.QUERY_DOCUNIQUEID + "=" + eflowdocid
                End If
                HLDetail.NavigateUrl = returnurl
                'Dim lbisfinish As Label = CType(e.Row.FindControl("LBisfinish"), Label)
                'Dim lbzhuangtai As Label = CType(e.Row.FindControl("LBzhuangtai"), Label)
                'If lbisfinish.Text = 0 Then
                '    lbzhuangtai.Text = "未結案"
                'ElseIf lbisfinish.Text = 1 Then
                '    lbzhuangtai.Text = "已結案"
                'End If
                Dim LBfilename As Label = CType(e.Row.FindControl("LbFileName"), Label)
                Dim LBfilebh As Label = CType(e.Row.FindControl("LbFileBH"), Label)
                If LBfilename.Text.Contains("^") Then
                    LBfilename.ToolTip = LBfilename.Text
                    LBfilename.Text = LBfilename.Text.Substring(0, LBfilename.Text.IndexOf("^")) + "..."

                End If
                If LBfilebh.Text.Contains("^") Then
                    LBfilebh.ToolTip = LBfilebh.Text
                    LBfilebh.Text = LBfilebh.Text.Substring(0, LBfilebh.Text.IndexOf("^")) + "..."

                End If
            End If
        End If
    End Sub

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button1.Click
        Dim newsearchcondition As StringBuilder = New StringBuilder()
        newsearchcondition.Append(InitSearch)
        Me.GridView1.Visible = True
        Me.GridViewTop.Visible = False
        If Me.TxtSearchCondition.Text.Trim() <> String.Empty Then
            newsearchcondition.Append(String.Format(" AND (ReadDept LIKE '%{0}%' OR ApplyUser LIKE '%{0}%' OR FileName LIKE '%{0}%' OR FileBH LIKE '%{0}%' OR StateName LIKE '%{0}%')", Me.TxtSearchCondition.Text.ToString.Trim))
        End If
        ViewState("SearchCondition") = newsearchcondition
        BindGridData(SearchCondition)
    End Sub

    Protected Sub GridView1_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles GridView1.RowDeleting
        Dim mpkid As Integer = Convert.ToInt32(Me.GridView1.DataKeys(e.RowIndex).Value)
        FileReadManageDAL.Delete(mpkid)
        Dim newdeletelog As DeleteLogInfo = New DeleteLogInfo()
        newdeletelog.pkid = 0
        newdeletelog.Parentid = mpkid
        newdeletelog.parenttype = "文件調閱"
        newdeletelog.DeleteUserName = UserInfo.CurrentUserCHName
        newdeletelog.DeleteUserSID = UserInfo.CurrentUserID
        newdeletelog.RecordCreated = DateTime.Now
        Dim newdeletedal As DeleteLogDAL = New DeleteLogDAL(newdeletelog)
        newdeletedal.Save()
        BindGridData(SearchCondition)
    End Sub

    Protected Sub GridViewTop_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GridViewTop.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            Dim LbApplydept As Label = CType(e.Row.FindControl("LbApplydept"), Label)
            Dim Image2 As Image = CType(e.Row.FindControl("Image1"), Image)
            Image2.Attributes.Add("onclick", "BindSiFile('" + e.Row.RowIndex.ToString + "','" + LbApplydept.Text.ToString + "')")
        End If
    End Sub

    Protected Sub BtnBindSiBydeptname_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BtnBindSiBydeptname.Click
        Dim deptname As String = Me.Hiddencurdeptname.Value
        Dim curindex As String = Me.Hiddencurrowindex.Value
        Dim dr As GridViewRow = Me.GridViewTop.Rows(curindex)
        Dim LbApplydept As Label = CType(dr.FindControl("LbApplydept"), Label)
        Dim GridStandSearch1 As GridFileread = CType(dr.FindControl("GridFileread1"), GridFileread)
        GridStandSearch1.Searchcondition = SearchCondition + " and StateName='" + LbApplydept.Text.ToString + "'"
        GridStandSearch1.BindFileread()
        Dim Image2 As Image = CType(dr.FindControl("Image1"), Image)
        Image2.Attributes.Remove("onclick")
        Image2.Attributes.Add("onclick", "fourdeptchangeshow('" + GridStandSearch1.ClientID + "_GridView1','" + curindex.ToString + "')")
    End Sub

    Protected Sub BtnFourcssShoe_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BtnFourcssShoe.Click
        Dim curfileindex As String = Me.Hiddensetcssfourfileindex.Value
        Dim GridStandSearch1 As GridFileread = CType(Me.GridViewTop.Rows(curfileindex).FindControl("GridFileread1"), GridFileread)
        GridStandSearch1.DisplayInfo = "Show"
        GridStandSearch1.BindFileread()
    End Sub

    Protected Sub BtnFourcssHid_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BtnFourcssHid.Click
        Dim curfileindex As String = Me.Hiddensetcssfourfileindex.Value
        Dim GridStandSearch1 As GridFileread = CType(Me.GridViewTop.Rows(curfileindex).FindControl("GridFileread1"), GridFileread)
        GridStandSearch1.DisplayInfo = "Hid"
        GridStandSearch1.BindFileread()
    End Sub
End Class