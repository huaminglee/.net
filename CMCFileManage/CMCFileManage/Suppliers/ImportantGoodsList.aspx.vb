Imports Platform.eAuthorize

Partial Public Class ImportantGoodsList
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
                ViewState(HIDE_SORTFIELD) = "PKID"
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
                If Not UserInfo.CurrentUserInstance Is Nothing AndAlso (UserInfo.IsInRoles("QA") OrElse UserInfo.IsInRoles("Audit") OrElse UserInfo.IsInRoles("SYS_ADMINISTRATOR") OrElse UserInfo.IsInRoles("qcStockGroup")) Then

                Else
                    Dim changqu As String = "LH"
                    Dim curneefaround As String = "龍華檢測中心"
                    If Not Request.Cookies("changqu") Is Nothing Then
                        changqu = Server.HtmlEncode(Request.Cookies("changqu").Value)
                    End If
                    Dim curdept As String
                    Dim curdeptstr As String = String.Empty
                    If Not Request.Cookies("userdepts") Is Nothing Then
                        Dim dept As String() = HttpUtility.UrlDecode(Request.Cookies("userdepts").Value).ToString.Split(";")
                        For Each curdept In dept
                            Dim curdeptchange As String
                            Dim ds As DataSet = SqlHelper.ExecuteDataset(ConfigurationInfo.ConnectionString, "DeptNameChange_GetDeptInmysysByDeptNameINeflow", curdept, changqu)
                            Dim dt As DataTable = ds.Tables(0)
                            If dt.Rows.Count > 0 Then
                                curdeptchange = dt.Rows(0).Item("DeptNameInmysys").ToString
                            Else
                                curdeptchange = curdept
                            End If
                            curdeptstr += curdeptchange
                        Next
                        SearchCondition += String.Format(" AND charindex(LabName,'{0}')>0", curdeptstr)  '部門在分發單位中
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
    Dim count As Integer = 0
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            ' BindGridData(InitSearch)
            If UserInfo.IsInRoles("QALEADER") Then
                Me.GridView1.Columns(9).Visible = True
            End If
            If UserInfo.IsInRoles("LabFileManager") Then
                Me.add.Visible = True
            Else
                Me.add.Visible = False
            End If
            BindGridTop()

        End If
    End Sub
    Private Sub BindGridTop()
        Dim dt As DataTable = ImportantGoodsDAL.GetDeptBySearchcondition(InitSearch)
        Me.GridViewTop.DataSource = dt
        Me.GridViewTop.DataBind()
    End Sub
    Private Sub BindGridData(ByVal SearchCondition As String)
        Dim TotalRecord As Integer = 0
        Dim ds As DataSet = TableBMHDAL.GetPageInfoBySearchCondition("ImportantGoods", SearchCondition, "*", SortField, PageSize, PageIndex, TotalRecord)
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
            If e.Row.RowState = DataControlRowState.Alternate OrElse e.Row.RowState = DataControlRowState.Normal Then
                count += 1

                Dim HLDetail As HyperLink = CType(e.Row.FindControl("HLDetail"), HyperLink)
                Dim pkid As Integer = Convert.ToInt32(CType(e.Row.FindControl("LblPKID"), Label).Text)
                Dim returnurl As String = "../Suppliers/ImportantGoodsDetail.aspx?pkid=" + pkid.ToString
                HLDetail.NavigateUrl = returnurl
                Dim BtnCancel As ImageButton = TryCast(e.Row.FindControl("BtnDelete"), ImageButton)
                BtnCancel.Attributes.Add("onclick", " return confirm('確定要刪除該記錄嗎?');")
            End If
        ElseIf e.Row.RowType = DataControlRowType.Footer Then
            e.Row.Cells(8).Text = count.ToString
        End If

    End Sub
    Protected Sub GridView1_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles GridView1.RowDeleting
        Dim mpkid As Integer = Convert.ToInt32(GridView1.DataKeys(e.RowIndex).Value)
        ImportantGoodsDAL.Delete(mpkid)
        BindGridData(SearchCondition)
    End Sub

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button1.Click
        Dim newsearchcondition As StringBuilder = New StringBuilder()
        newsearchcondition.Append(InitSearch)
        Me.GridViewTop.Visible = False
        If Me.TxtSearchCondition.Text.Trim() <> String.Empty Then
            newsearchcondition.Append(String.Format(" AND (GoodsName LIKE '%{0}%' OR LabName LIKE '%{0}%' OR Supplier LIKE '%{0}%' OR Qulocation LIKE '%{0}%' OR Brands LIKE '%{0}%' OR Remark LIKE '%{0}%')", Me.TxtSearchCondition.Text.ToString.Trim))
        End If
        ViewState("SearchCondition") = newsearchcondition
        BindGridData(SearchCondition)
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

    Private Sub PagerControl1_PageChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles PagerControl1.PageChanged
        BindGridData(SearchCondition)
        ' If Me.Button2.Text = "取消分組顯示" Then
        Dim helper As New GridViewHelper(Me.GridView1)
        helper.RegisterGroup("LabName", True, False)
        helper.ApplyGroupSort()
        '  End If
    End Sub

    Private Sub PagerControl1_PageSizeChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles PagerControl1.PageSizeChanged
        BindGridData(SearchCondition)
        ' If Me.Button2.Text = "取消分組顯示" Then
        Dim helper As New GridViewHelper(Me.GridView1)
        helper.RegisterGroup("LabName", True, False)
        helper.ApplyGroupSort()
        ' End If
    End Sub

    'Protected Sub Button2_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button2.Click
    '    If Me.Button2.Text = "按實驗室分組顯示" Then
    '        Dim helper As New GridViewHelper(Me.GridView1)
    '        helper.RegisterGroup("LabName", True, False)
    '        helper.ApplyGroupSort()
    '        ClientScript.RegisterStartupScript(Me.GetType(), DateTime.Now.ToString(), "zhedie();", True)
    '        Me.Button2.Text = "取消分組顯示"
    '    Else
    '        BindGridData(SearchCondition)
    '        Me.Button2.Text = "按實驗室分組顯示"
    '    End If

    'End Sub

    Protected Sub GridViewTop_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GridViewTop.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            Dim LbApplydept As Label = CType(e.Row.FindControl("LbApplydept"), Label)
            Dim Image2 As Image = CType(e.Row.FindControl("Image2"), Image)
            Image2.Attributes.Add("onclick", "BindQy('" + e.Row.RowIndex.ToString + "','" + LbApplydept.Text.ToString + "')")
        End If
    End Sub

    Protected Sub Button3_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button3.Click
        BindQu()
    End Sub
    Private Sub BindQu()
        Dim deptname As String = Me.Hiddencurdeptname.Value
        Dim rowindex As Integer = Me.Hiddencurrowindex.Value
        Dim dr As GridViewRow = Me.GridViewTop.Rows(rowindex)
        Dim curgridQu As GridQyext = CType(dr.FindControl("GridQyext1"), GridQyext)
        curgridQu.Searchcondition = InitSearch + " and LabName='" + deptname.ToString + "'"
        curgridQu.ParentType = 2
        curgridQu.Parentindex = rowindex
        curgridQu.BindQu()
        Dim Image2 As Image = CType(dr.FindControl("Image2"), Image)
        Image2.Attributes.Remove("onclick")
        Image2.Attributes.Add("onclick", "deptchangeshow('" + curgridQu.ClientID + "_GridView1','" + rowindex.ToString + "')")
    End Sub

    Protected Sub BtnSetCSSshow_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BtnSetCSSshow.Click
        Dim curQyindex As String = Me.HiddencursetcssQyindex.Value
        Dim curgridqy As GridQyext = CType(Me.GridViewTop.Rows(curQyindex).FindControl("GridQyext1"), GridQyext)
        curgridqy.DisplayInfo = "Show"
        curgridqy.BindQu()
    End Sub

    Protected Sub BtnSetCSShidd_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BtnSetCSShidd.Click
        Dim curQyindex As String = Me.HiddencursetcssQyindex.Value
        Dim curgridqy As GridQyext = CType(Me.GridViewTop.Rows(curQyindex).FindControl("GridQyext1"), GridQyext)
        curgridqy.DisplayInfo = "Hid"
        curgridqy.BindQu()
    End Sub
    Protected Sub BtnSetFileCssShow_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BtnSetFileCssShow.Click
        Dim curfileindex As String = Me.Hiddencursetcssfileindex.Value
        Dim fatherindex = Me.Hiddenparenetindex.Value
        Dim curgridqy As GridQyext = CType(Me.GridViewTop.Rows(fatherindex).FindControl("GridQyext1"), GridQyext)
        Dim curequip As GridImportant = CType(CType(curgridqy.FindControl("Gridview1"), GridView).Rows(curfileindex).FindControl("GridImportant1"), GridImportant)
        curequip.DisplayInfo = "Show"
        curequip.BinImportant()
    End Sub

    Protected Sub BtnSetFileCSSHid_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BtnSetFileCSSHid.Click
        Dim curfileindex As String = Me.Hiddencursetcssfileindex.Value
        Dim fatherindex = Me.Hiddenparenetindex.Value
        Dim curgridqy As GridQyext = CType(Me.GridViewTop.Rows(fatherindex).FindControl("GridQyext1"), GridQyext)
        Dim curequip As GridImportant = CType(CType(curgridqy.FindControl("Gridview1"), GridView).Rows(curfileindex).FindControl("GridImportant1"), GridImportant)
        curequip.DisplayInfo = "Hid"
        curequip.BinImportant()
    End Sub
End Class