Imports Platform.eAuthorize

Partial Public Class AddQCFileList
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
                ViewState(HIDE_SORTFIELD) = "ApplyDept"
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
                If CurType = 0 Then
                    SearchCondition = "RecordDeleted=0 AND RecordType =1  "
                ElseIf CurType = 1 Then
                    SearchCondition = "RecordDeleted=0 AND RecordType =2  "
                ElseIf CurType = 2 Then
                    SearchCondition = "RecordDeleted=0 AND IsFinish =0 and FileStatus =0 "
                ElseIf CurType = 3 Then
                    SearchCondition = "RecordDeleted=0 AND RecordType =3  "
                ElseIf CurType = 987 Then
                    SearchCondition = "RecordDeleted=0 AND RecordType =1 "
                    Me.RadioButtonList1.SelectedIndex = Me.RadioButtonList1.Items.IndexOf(Me.RadioButtonList1.Items.FindByValue("1"))
                ElseIf CurType = 988 Then
                    SearchCondition = "RecordDeleted=0 AND RecordType =2 "
                    Me.RadioButtonList1.SelectedIndex = Me.RadioButtonList1.Items.IndexOf(Me.RadioButtonList1.Items.FindByValue("1"))
                ElseIf CurType = 989 Then
                    SearchCondition = "RecordDeleted=0 AND RecordType =3 "
                    Me.RadioButtonList1.SelectedIndex = Me.RadioButtonList1.Items.IndexOf(Me.RadioButtonList1.Items.FindByValue("1"))
                Else
                    SearchCondition = "RecordDeleted=0"
                End If
                If Me.RadioButtonList1.SelectedValue = 1 Then
                    SearchCondition += " and isFinish=1"
                ElseIf RadioButtonList1.SelectedValue = 0 Then
                    SearchCondition += " and isFinish=0"
                ElseIf RadioButtonList1.SelectedValue = 2 Then

                End If
                If Not UserInfo.CurrentUserInstance Is Nothing AndAlso (UserInfo.IsInRoles("QA") OrElse UserInfo.IsInRoles("Audit") OrElse UserInfo.IsInRoles("SYS_ADMINISTRATOR")) Then

                Else
                    Dim changqu As String = "LH"
                    Dim curneefaround As Integer = 0
                    If Not Request.Cookies("changqu") Is Nothing Then
                        changqu = Server.HtmlEncode(Request.Cookies("changqu").Value)
                    End If
                    'Select Case changqu
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
                            SearchCondition += String.Format(" AND ( SendDept & {0}!=0)", curdeptnum)  '部門在分發單位中
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
            If UserInfo.CurrentUserInstance Is Nothing Then
                Me.Divdoaction.Attributes.Add("style", "display:none")
                Me.GridView1.Columns(0).Visible = False
                Me.GridView1.Columns(9).Visible = False
            End If
           
            Getparms()
            If UserInfo.IsInRoles("QALEADER") AndAlso CurType = 2 Then
                Me.GridView1.Columns(11).Visible = True
            End If
            Me.HiddenCurType.Value = CurType
            '  BindGrid(InitSearch)
            BindZTgrid()
        End If
    End Sub
    Private Sub Getparms()
        If Not Request.QueryString("Type") Is Nothing Then
            CurType = Convert.ToInt32(Request.QueryString("Type"))
        End If
    End Sub
    Private Sub BindZTgrid()
        Dim dt As DataTable = QC_FileInfoDAL.GetZTBySearchcondition(InitSearch)
        If Not dt Is Nothing Then
            Me.GridViewTop.DataSource = dt
            Me.GridViewTop.DataBind()
        Else
            Me.GridViewTop.DataSource = Nothing
            Me.GridViewTop.DataBind()
        End If
    End Sub
    Private Sub BindGrid(ByVal SearchCondition As String)
        Dim TotalRecord As Integer = 0
        Dim ds As DataSet = TableBMHDAL.GetPageInfoBySearchCondition("QC_FileInfo", SearchCondition, "*", SortField + " " + SortOrder, PageSize, PageIndex, TotalRecord)
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
            Dim DocUniqueID As String = CType(e.Row.FindControl("lblDocUniqueID"), Label).Text
            Dim HLDetail As HyperLink = CType(e.Row.FindControl("HLDetail"), HyperLink)
            Dim ReturnURL As String = "../Forms/AddQCFileDetail.aspx?pkid=" + mPKID.ToString + "&Type=" + CurType.ToString
            If (DocUniqueID <> String.Empty AndAlso DocUniqueID <> Guid.Empty.ToString) Then
                ReturnURL = ReturnURL + "&" + Global_asax.QUERY_DOCUNIQUEID + "=" + DocUniqueID
            End If
            HLDetail.NavigateUrl = ReturnURL
            Dim BtnCancel As ImageButton = TryCast(e.Row.FindControl("BtnDelete"), ImageButton)
            BtnCancel.Attributes.Add("onclick", " return confirm('確定要刪除該記錄嗎?');")

           

            Dim lbISfinish As Label = CType(e.Row.FindControl("LbIsFinish"), Label)
            Dim lbshifoujiean As Label = CType(e.Row.FindControl("Lbshifoujiean"), Label)
            'If lbISfinish.Text = 0 Then
            '    lbshifoujiean.Text = "未結案"
            'Else
            '    lbshifoujiean.Text = "已結案"
            'End If
            Dim LblApplyTime As Label = CType(e.Row.FindControl("LblApplyTime"), Label)
            If LblApplyTime.Text = "9999-12-31" Then
                LblApplyTime.Text = "未生效"
            End If
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
        QC_FileInfoDAL.Delete(mpkid)
        Dim newdeletelog As DeleteLogInfo = New DeleteLogInfo()
        newdeletelog.pkid = 0
        newdeletelog.Parentid = mpkid
        newdeletelog.parenttype = "品質文件"
        newdeletelog.DeleteUserName = UserInfo.CurrentUserCHName
        newdeletelog.DeleteUserSID = UserInfo.CurrentUserID
        newdeletelog.RecordCreated = DateTime.Now
        Dim newdeletedal As DeleteLogDAL = New DeleteLogDAL(newdeletelog)
        newdeletedal.Save()
        BindGrid(SearchCondition)
    End Sub
#End Region




    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button1.Click
        Me.GridViewTop.Visible = False
        Dim newsearchcondition As StringBuilder = New StringBuilder()
        newsearchcondition.Append(InitSearch)
        If Me.TxtSearchCondition.Text.Trim() <> String.Empty Then
            newsearchcondition.Append(String.Format(" AND (RecordNO LIKE '%{0}%' OR ApplyDept LIKE '%{0}%' OR FileName LIKE '%{0}%' OR Filebh LIKE '%{0}%')", Me.TxtSearchCondition.Text.ToString.Trim))
        End If
        ViewState("SearchCondition") = newsearchcondition
        BindGrid(SearchCondition)
    End Sub
#Region "pageEvent"

    Private Sub PagerControl1_PageChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles PagerControl1.PageChanged
        BindGrid(SearchCondition)
    End Sub

    Private Sub PagerControl1_PageSizeChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles PagerControl1.PageSizeChanged
        BindGrid(SearchCondition)
    End Sub
#End Region

    Protected Sub RadioButtonList1_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles RadioButtonList1.SelectedIndexChanged
        BindZTgrid()
    End Sub
    Protected Sub GridViewTop_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GridViewTop.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            Dim LbIsfinish As Label = CType(e.Row.FindControl("LbIsfinish"), Label)
            Dim Image2 As Image = CType(e.Row.FindControl("Image2"), Image)
            Image2.Attributes.Add("onclick", "BindDepts('" + Image2.ClientID + "','" + e.Row.RowIndex.ToString + "','" + LbIsfinish.Text.ToString + "')")
            'If LbIsfinish.Text = "1" Then
            '    LbIsfinish.Text = "已結案"
            'Else
            '    LbIsfinish.Text = "未結案"
            'End If
        End If
    End Sub
    Public Sub BindDept()
        Dim isfi As String = Me.Hiddencurrowisfi.Value
        Dim rowindex As Integer = Me.Hiddencurrowindex.Value
        Dim dr As GridViewRow = Me.GridViewTop.Rows(rowindex)
        Dim GridDept1 As GridDept = CType(dr.FindControl("GridDept1"), GridDept)
        'GridDept1.IsFinished = isfi
        GridDept1.Parentindex = rowindex
        GridDept1.RecordType = CurType
        GridDept1.Searchcondition = SearchCondition + " and StateName='" + isfi + "'"
        GridDept1.BindDeptGrid()
        Dim Image2 As Image = CType(dr.FindControl("Image2"), Image)
        Image2.Attributes.Remove("onclick")
        Image2.Attributes.Add("onclick", "ztchangeshow('" + GridDept1.ClientID + "_GridView1','" + rowindex.ToString + "')")
    End Sub

    Protected Sub Button3_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button3.Click
        BindDept()
    End Sub

    Protected Sub BtnSetCSSshow_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BtnSetCSSshow.Click
        Dim curid As String = Me.HiddenCurdeptSetCSid.Value
        Dim curdeptindex As String = Me.Hiddencursetcssdeptindex.Value
        Dim curdept As GridDept = CType(Me.GridViewTop.Rows(curdeptindex).FindControl("GridDept1"), GridDept)
        curdept.DisplayInfo = "Show"
        curdept.BindDeptGrid()
        'Dim curdetp As GridDept = CType(Me.GridViewTop.FindControl(curid), GridDept)
        'curdetp.Attributes.Add("style", "display:inline")
    End Sub

    Protected Sub BtnSetCSShidd_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BtnSetCSShidd.Click
        Dim curdeptindex As String = Me.Hiddencursetcssdeptindex.Value

        Dim curdept As GridDept = CType(Me.GridViewTop.Rows(curdeptindex).FindControl("GridDept1"), GridDept)
        curdept.DisplayInfo = "Hid"
        curdept.BindDeptGrid()
    End Sub

    Protected Sub BtnSetFileCSSHid_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BtnSetFileCSSHid.Click
        Dim curfileindex As String = Me.Hiddencursetcssfileindex.Value
        Dim fatherindex = Me.Hiddenparenetindex.Value
        Dim curdept As GridDept = CType(Me.GridViewTop.Rows(fatherindex).FindControl("GridDept1"), GridDept)
        Dim curfile As GridFile = CType(CType(curdept.FindControl("Gridview1"), GridView).Rows(curfileindex).FindControl("GridFile1"), GridFile)
        curfile.DisplayInfo = "Hid"
        curfile.BindFile()
    End Sub

    Protected Sub BtnSetFileCssShow_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BtnSetFileCssShow.Click
        Dim curfileindex As String = Me.Hiddencursetcssfileindex.Value
        Dim fatherindex = Me.Hiddenparenetindex.Value
        Dim curdept As GridDept = CType(Me.GridViewTop.Rows(fatherindex).FindControl("GridDept1"), GridDept)
        Dim curfile As GridFile = CType(CType(curdept.FindControl("Gridview1"), GridView).Rows(curfileindex).FindControl("GridFile1"), GridFile)
        curfile.DisplayInfo = "Show"
        curfile.BindFile()
    End Sub

End Class