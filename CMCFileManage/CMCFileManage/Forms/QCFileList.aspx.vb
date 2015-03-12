Imports Platform.eAuthorize

Partial Public Class QCFileList
    Inherits System.Web.UI.Page

#Region "字段定義"
    Private Const _RequestType As String = "ViewState:Type"
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

    '''<summary>
    '''當前請求狀態
    '''</summary>
    Private Property CurType() As String
        Get
            Return CStr(ViewState(_RequestType))
        End Get
        Set(ByVal Value As String)
            ViewState(_RequestType) = Value
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
                ViewState(HIDE_SORTFIELD) = "FileLayer , EffectDate"
                ViewState(HIDE_SortOrder) = "ASC"
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
               
                Select Case CurType
                    Case "0"
                        SearchCondition = " (FileLayer ='QM' OR FileLayer ='QP') AND FileStatus =0 AND RecordType !=3 and StateOrder >= 9 "
                        Me.GridView1.Columns(3).Visible = False
                        Me.HiddenType.Value = 9
                    Case "1"
                        SearchCondition = " FileLayer ='WI'   AND FileStatus =0 and StateOrder >= 9   AND RecordType !=3"
                        Me.HiddenType.Value = 10
                    Case "2"
                        SearchCondition = " FileLayer ='QF'   AND FileStatus =0 and StateOrder >= 9  AND RecordType !=3"
                        Me.GridView1.Columns(3).Visible = False
                        Me.HiddenType.Value = 9
                    Case "3"
                        SearchCondition = "(FileStatus =1 or RecordType  =3)"
                        Me.HiddenType.Value = 10
                End Select

                If Not UserInfo.CurrentUserInstance Is Nothing AndAlso (CurType = 0 OrElse UserInfo.IsInRoles("QA") OrElse UserInfo.IsInRoles("Audit") OrElse UserInfo.IsInRoles("SYS_ADMINISTRATOR")) Then

                Else
                    Dim changqu As String = "LH"
                    Dim curneefaround As Integer = 0
                    If Not Request.Cookies("changqu") Is Nothing Then
                        changqu = Server.HtmlEncode(Request.Cookies("changqu").Value)
                    End If
                    'Select Case changqu
                    '    Case "TY"
                    '        curneefaround = 512
                    '    Case "NN"
                    '        curneefaround = 256
                    '    Case "LH"
                    '        curneefaround = 128
                    '    Case "YT"
                    '        curneefaround = 64
                    '    Case "WH"
                    '        curneefaround = 32
                    '    Case "CD"
                    '        curneefaround = 16
                    '    Case "WSJ"
                    '        curneefaround = 8
                    '    Case "GL"
                    '        curneefaround = 4
                    '    Case "CQ"
                    '        curneefaround = 2
                    '    Case "ZZ"
                    '        curneefaround = 1
                    '    Case "NN"
                    '        curneefaround = 256
                    '    Case "TY"
                    '        curneefaround = 512
                    'End Select
                    'SearchCondition += String.Format(" and NeedAround & {0}={0}", curneefaround)         '廠區在分發廠區中
                    Dim curdept As String
                    Dim curdeptnum As Integer = 0
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

                            Select Case curdept.Trim
                                Case "校準實驗室"
                                    curdeptnum += 2 ^ 0
                                Case "CAE仿真分析實驗室"
                                    curdeptnum += 2 ^ 1
                                Case "尺寸量測實驗室"
                                    curdeptnum += 2 ^ 2
                                Case "HALT高加速壽命實驗室"
                                    curdeptnum += 2 ^ 3
                                Case "金屬材料實驗室"
                                    curdeptnum += 2 ^ 4
                                Case "元素成分分析實驗室"
                                    curdeptnum += 2 ^ 5
                                Case "塑料研發實驗室"
                                    curdeptnum += 2 ^ 6
                                Case "管理層"
                                    curdeptnum += 2 ^ 7
                                Case "可靠度實驗室"
                                    curdeptnum += 2 ^ 8
                                Case "品保課"
                                    curdeptnum += 2 ^ 9
                                Case "噪音實驗室"
                                    curdeptnum += 2 ^ 10
                                Case "應用系統整合實驗室"
                                    curdeptnum += 2 ^ 11
                                Case "移動產品驗証實驗室"
                                    curdeptnum += 2 ^ 12
                                Case "制程檢測開發實驗室"
                                    curdeptnum += 2 ^ 13
                                Case "檢測設備開發實驗室"
                                    curdeptnum += 2 ^ 14
                                Case "SMT實驗室"
                                    curdeptnum += 2 ^ 15
                                Case "超精密量測實驗室"
                                    curdeptnum += 2 ^ 16
                                Case "三次元校準維修"
                                    curdeptnum += 2 ^ 17
                                Case "3D工程及驗証實驗室"
                                    curdeptnum += 2 ^ 18
                                Case "精密儀器研發部"
                                    curdeptnum += 2 ^ 19
                                Case "3D工程于量測技術開發實驗室"
                                    curdeptnum += 2 ^ 20
                                Case "食材檢測實驗室"
                                    curdeptnum += 2 ^ 21
                                Case "業務部"
                                    curdeptnum += 2 ^ 22


                            End Select
                        Next
                        If curdeptnum = 0 Then
                            SearchCondition = " 1<0"          '部門不在以上實驗室中
                        Else
                            SearchCondition += String.Format("  AND ( ( SendDept & {0}!=0)", curdeptnum)  '部門在分發單位中
                            SearchCondition += " or ApplyDept='品保課')"
                        End If

                    Else
                        SearchCondition = " 1<0"               '無部門信息
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
            GetRequestParam()
            Me.HiddenCurType.Value = CurType
            PageSize = 100
            If CurType = 0 Then
                BindGridData(SearchCondition)
            ElseIf CurType = 1 Then
                BindGridDept()
            ElseIf CurType = 2 OrElse CurType = 3 Then
                BindGridSiDept()
            End If
            '  BindGridData(SearchCondition)
            '    Dim helper As New GridViewHelper(Me.GridView1)
            ' helper.RegisterGroup("ApplyDept", True, False)
            ' helper.ApplyGroupSort()
        End If
    End Sub
    Private Sub GetRequestParam()
        If Not Request.QueryString("Type") Is Nothing Then
            CurType = Request.QueryString("Type")

        End If

    End Sub
    Private Sub BindGridDept()
        Dim dt As DataTable = QC_FileInfoDAL.GetApplydeptBySearchcondition(SearchCondition)
        Me.GridViewDept.DataSource = dt
        Me.GridViewDept.DataBind()
    End Sub
    Private Sub BindGridData(ByVal SearchCondition As String)
        Dim TotalRecord As Integer = 0
        Dim ds As DataSet = TableBMHDAL.GetPageInfoBySearchCondition("QC_FileInfo", SearchCondition, "*", SortField, PageSize, PageIndex, TotalRecord)
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
        Dim helper As New GridViewHelper(Me.GridView1)
        helper.RegisterGroup("ApplyDept", True, False)
        helper.ApplyGroupSort()

    End Sub
    Private Sub PagerControl1_PageSizeChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles PagerControl1.PageSizeChanged
        BindGridData(SearchCondition)
        Dim helper As New GridViewHelper(Me.GridView1)
        helper.RegisterGroup("ApplyDept", True, False)
        helper.ApplyGroupSort()
    End Sub
#End Region

    Dim count As Integer = 0
    Protected Sub GridView1_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GridView1.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            e.Row.Attributes.Add("onmouseover", "this.style.cursor='hand';this.style.color='#FFFFFF'; currentcolor=this.style.backgroundColor;this.style.backgroundColor='#40A0FE',this.style.fontWeight='';")
            e.Row.Attributes.Add("onmouseout", "this.style.color='#1e5494'; this.style.backgroundColor=currentcolor,this.style.fontWeight='';")
            If e.Row.RowState = DataControlRowState.Normal OrElse e.Row.RowState = DataControlRowState.Alternate Then
                count += 1
                Dim pkid As Integer = CType(e.Row.FindControl("LblPKID"), Label).Text
                Dim eflowdocid As String = CType(e.Row.FindControl("lblDocUniqueID"), Label).Text
                Dim HLDetail As HyperLink = CType(e.Row.FindControl("HLDetail"), HyperLink)
                Dim returnurl As String = "../Forms/QCFileDetail.aspx?pkid=" + pkid.ToString + "&Type=" + CurType.ToString
                e.Row.Attributes.Add("onclick", "window.location.href='" + returnurl + "';")
                If eflowdocid <> String.Empty AndAlso eflowdocid <> Guid.Empty.ToString Then
                    returnurl = returnurl + "&" + Global_asax.QUERY_DOCUNIQUEID + "=" + eflowdocid
                End If
                HLDetail.NavigateUrl = returnurl
                Select Case CurType
                    Case "0"
                        If e.Row.Cells(1).Text = "QM" Then
                            e.Row.Cells(1).Text = "一階文件"
                        Else
                            e.Row.Cells(1).Text = "二階文件"
                        End If
                    Case "1"
                        e.Row.Cells(1).Text = "三階文件"
                    Case "2"
                        e.Row.Cells(1).Text = "四階文件"

                End Select
                Dim isinchange As String = SqlHelper.ExecuteDataset(ConfigurationInfo.ConnectionString, "QC_ISinchange", pkid).Tables(0).Rows(0).Item("notfinishcount").ToString
                If isinchange <> "0" Then
                    e.Row.BackColor = System.Drawing.Color.Gray
                End If
                Dim LbFileCategoreINT As Label = CType(e.Row.FindControl("LbFileCategoreINT"), Label)
                ' Dim LbFileCategoreSTR As Label = CType(e.Row.FindControl("LbFileCategorySTR"), Label)
                'Select Case LbFileCategoreINT.Text
                '    Case "1"
                '        LbFileCategoreSTR.Text = "校準程序"
                '    Case "2"
                '        LbFileCategoreSTR.Text = "操作規範"
                '    Case "3"
                '        LbFileCategoreSTR.Text = "作業規範"
                '    Case "4"
                '        LbFileCategoreSTR.Text = "管理要求"
                '    Case "5"
                '        LbFileCategoreSTR.Text = "技術要求"
                '    Case "6"
                '        LbFileCategoreSTR.Text = "其他"
                'End Select
            End If
        ElseIf e.Row.RowType = DataControlRowType.Footer Then
            e.Row.Cells(10).Text = count.ToString
        End If
    End Sub

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button1.Click
        Dim newsearchcondition As StringBuilder = New StringBuilder()
        Me.GridViewDept.Visible = False
        Me.GridViewSiTop.Visible = False
        newsearchcondition.Append(InitSearch)
        If Me.TxtSearchCondition.Text.Trim() <> String.Empty Then
            newsearchcondition.Append(String.Format(" AND (ApplyDept LIKE '%{0}%' OR FileCategory LIKE '%{0}%' OR FileBH LIKE '%{0}%' OR FileName LIKE '%{0}%' OR RecordNO LIKE '%{0}%')", Me.TxtSearchCondition.Text.ToString.Trim))
        End If
        ViewState("SearchCondition") = newsearchcondition
        BindGridData(SearchCondition)
        Dim helper As New GridViewHelper(Me.GridView1)
        helper.RegisterGroup("ApplyDept", True, False)
        helper.ApplyGroupSort()
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
    Protected Sub BtnSetCSSshow_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BtnSetCSSshow.Click
        Dim curcategoryindex As String = Me.Hiddencursetcsscategoryindex.Value
        Dim curcategory As GridCategory = CType(Me.GridViewDept.Rows(curcategoryindex).FindControl("GridCategory1"), GridCategory)
        curcategory.DisplayInfo = "Show"
        curcategory.BindCategoryGrid()

    End Sub

    Protected Sub BtnSetCSShidd_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BtnSetCSShidd.Click
        Dim curcategoryindex As String = Me.Hiddencursetcsscategoryindex.Value
        Dim curcategory As GridCategory = CType(Me.GridViewDept.Rows(curcategoryindex).FindControl("GridCategory1"), GridCategory)
        curcategory.DisplayInfo = "Hid"
        curcategory.BindCategoryGrid()

    End Sub
    Protected Sub BtnSetFileCssShow_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BtnSetFileCssShow.Click
        Dim curfileindex As String = Me.Hiddencursetcssfileindex.Value
        Dim fatherindex = Me.Hiddenparenetindex.Value
        Dim curcategory As GridCategory = CType(Me.GridViewDept.Rows(fatherindex).FindControl("GridCategory1"), GridCategory)
        Dim curfile As GridFile = CType(CType(curcategory.FindControl("Gridview1"), GridView).Rows(curfileindex).FindControl("GridFile1"), GridFile)
        curfile.DisplayInfo = "Show"
        curfile.BindFile()
    End Sub

    Protected Sub BtnSetFileCSSHid_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BtnSetFileCSSHid.Click
        Dim curfileindex As String = Me.Hiddencursetcssfileindex.Value
        Dim fatherindex = Me.Hiddenparenetindex.Value
        Dim curcategory As GridCategory = CType(Me.GridViewDept.Rows(fatherindex).FindControl("GridCategory1"), GridCategory)
        Dim curfile As GridFile = CType(CType(curcategory.FindControl("Gridview1"), GridView).Rows(curfileindex).FindControl("GridFile1"), GridFile)
        curfile.DisplayInfo = "Hid"
        curfile.BindFile()
    End Sub

    Protected Sub GridViewDept_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GridViewDept.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            Dim LbApplydept As Label = CType(e.Row.FindControl("LbApplydept"), Label)
            Dim Image2 As Image = CType(e.Row.FindControl("Image2"), Image)
            Image2.Attributes.Add("onclick", "BindCategory('" + e.Row.RowIndex.ToString + "','" + LbApplydept.Text.ToString + "')")
        End If
    End Sub

    Protected Sub Button3_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button3.Click
        BindCategory()
    End Sub
    Public Sub BindCategory()
        Dim deptname As String = Me.Hiddencurdeptname.Value
        Dim rowindex As Integer = Me.Hiddencurrowindex.Value
        Dim dr As GridViewRow = Me.GridViewDept.Rows(rowindex)
        Dim GridCategory As GridCategory = CType(dr.FindControl("GridCategory1"), GridCategory)
        GridCategory.DeptName = deptname
        GridCategory.RecordType = CurType
        GridCategory.Parentindex = rowindex
        GridCategory.Searchcondition = SearchCondition + " and ApplyDept='" + deptname + "'"
        GridCategory.BindCategoryGrid()
        Dim Image2 As Image = CType(dr.FindControl("Image2"), Image)
        Image2.Attributes.Remove("onclick")
        Image2.Attributes.Add("onclick", "deptchangeshow('" + GridCategory.ClientID + "_GridView1','" + rowindex.ToString + "')")
    End Sub

    Protected Sub GridViewSiTop_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GridViewSiTop.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            Dim LbApplydept As Label = CType(e.Row.FindControl("LbApplydept"), Label)
            Dim Image2 As Image = CType(e.Row.FindControl("Image1"), Image)
            Image2.Attributes.Add("onclick", "BindSiFile('" + e.Row.RowIndex.ToString + "','" + LbApplydept.Text.ToString + "')")
        End If
    End Sub
    Private Sub BindGridSiDept()
        Dim dt As DataTable = QC_FileInfoDAL.GetApplydeptBySearchcondition(SearchCondition)

        Me.GridViewSiTop.DataSource = dt
        Me.GridViewSiTop.DataBind()

    End Sub

    Protected Sub BtnBindSiBydeptname_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BtnBindSiBydeptname.Click
        Dim deptname As String = Me.Hiddencurdeptname.Value
        Dim curindex As String = Me.Hiddencurrowindex.Value
        Dim dr As GridViewRow = Me.GridViewSiTop.Rows(curindex)
        Dim LbApplydept As Label = CType(dr.FindControl("LbApplydept"), Label)
        Dim curgridfile As GridFile = CType(dr.FindControl("GridFile1"), GridFile)
        curgridfile.ParentType = CurType + 1
        curgridfile.DeptName = LbApplydept.Text
        curgridfile.Searchcondition = SearchCondition + " and ApplyDept='" + LbApplydept.Text.ToString + "'"
        curgridfile.RecordType = CurType
        curgridfile.BindFile()
        Dim Image2 As Image = CType(dr.FindControl("Image1"), Image)
        Image2.Attributes.Remove("onclick")
        Image2.Attributes.Add("onclick", "fourdeptchangeshow('" + curgridfile.ClientID + "_GridView1','" + curindex.ToString + "')")
    End Sub

    Protected Sub BtnFourcssShoe_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BtnFourcssShoe.Click
        Dim curfileindex As String = Me.Hiddensetcssfourfileindex.Value
        Dim curgridfile As GridFile = CType(Me.GridViewSiTop.Rows(curfileindex).FindControl("GridFile1"), GridFile)
        curgridfile.DisplayInfo = "Show"
        curgridfile.BindFile()
    End Sub

    Protected Sub BtnFourcssHid_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BtnFourcssHid.Click
        Dim curfileindex As String = Me.Hiddensetcssfourfileindex.Value
        Dim curgridfile As GridFile = CType(Me.GridViewSiTop.Rows(curfileindex).FindControl("GridFile1"), GridFile)
        curgridfile.DisplayInfo = "Hid"
        curgridfile.BindFile()
    End Sub
End Class