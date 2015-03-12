Imports Platform.eAuthorize

Partial Public Class OutFileList
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
                SearchCondition = "RecordDeleted=0  "
                Select Case CurType
                    Case "2"
                        SearchCondition += " AND RecordStype=2 "
                    Case "3"
                        SearchCondition += " and RecordStype=3 "
                    Case "4"
                        SearchCondition += " and RecordStype=4 "
                    Case "5"
                        SearchCondition += " and RecordStype=5 "
                End Select

                If Not UserInfo.CurrentUserInstance Is Nothing AndAlso (UserInfo.IsInRoles("QA") OrElse UserInfo.IsInRoles("Audit") OrElse UserInfo.IsInRoles("SYS_ADMINISTRATOR")) Then

                Else                                              '外廠區人員或本廠區非QA或本廠區非Audit人員
                    Dim changqu As String = "LH"
                    Dim curneefaround As String = "龍華檢測中心"
                    If Not Request.Cookies("changqu") Is Nothing Then
                        changqu = Server.HtmlEncode(Request.Cookies("changqu").Value)
                    End If
                    'Select Case changqu
                    '    Case "TY"
                    '        curneefaround = "太原檢測中心"
                    '    Case "NN"
                    '        curneefaround = "南寧檢測中"
                    '    Case "LH"
                    '        curneefaround = "龍華檢測中心"
                    '    Case "YT"
                    '        curneefaround = "煙台檢測中心"
                    '    Case "WH"
                    '        curneefaround = "武漢檢測中心"
                    '    Case "CD"
                    '        curneefaround = "成都檢測中心"
                    '    Case "WSJ"
                    '        curneefaround = "吳淞江檢測中心"
                    '    Case "GL"
                    '        curneefaround = "觀瀾檢測中心"
                    '    Case "CQ"
                    '        curneefaround = "重慶檢測中心"
                    '    Case "ZZ"
                    '        curneefaround = "鄭州檢測中心"
                    'End Select
                    'SearchCondition += String.Format(" AND QYLocation ='{0}'", curneefaround)
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
                        SearchCondition += String.Format(" AND charindex(FileDept,'{0}')>0", curdeptstr)  '部門在分發單位中
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
            GetRequestParam()
            Me.addnew.HRef = "OutFileDetail.aspx?Type=" + CurType.ToString
            If UserInfo.CurrentUserInstance Is Nothing OrElse Not UserInfo.IsInRoles("QALeader") Then
                Me.GridView1.Columns(14).Visible = False
            End If
            If UserInfo.IsInRoles("LabFileManager") Then
                Me.add.Visible = True
            Else
                Me.add.Visible = False
            End If
            Select Case CurType
                Case 2                         '測試規格計劃
                    Me.GridView1.Columns(6).Visible = False
                    Me.GridView1.Columns(7).Visible = False
                    Me.GridView1.Columns(8).Visible = False
                    Me.GridView1.Columns(9).Visible = False
                    Me.GridView1.Columns(10).Visible = False
                    Me.GridView1.Columns(11).Visible = False
                    Me.GridView1.Columns(12).Visible = False
                    Me.GridView1.Columns(13).Visible = False
                    Me.GridView1.Columns(3).HeaderText = "規格名稱"
                    Me.GridView1.Columns(4).HeaderText = "規格號碼"
                    Me.HiddenType.Value = 7
                Case 3                         '軟體
                    Me.GridView1.Columns(4).Visible = False
                    Me.GridView1.Columns(6).Visible = False
                    Me.GridView1.Columns(7).Visible = False
                    Me.GridView1.Columns(8).Visible = False
                    Me.GridView1.Columns(13).Visible = False

                    Me.GridView1.Columns(4).HeaderText = "軟體名稱"
                    Me.HiddenType.Value = 10

                Case 4                        '說明書
                    Me.GridView1.Columns(4).Visible = False
                    Me.GridView1.Columns(5).Visible = False
                    Me.GridView1.Columns(6).Visible = False
                    Me.GridView1.Columns(8).Visible = False
                    Me.GridView1.Columns(9).Visible = False
                    Me.GridView1.Columns(10).Visible = False
                    Me.GridView1.Columns(11).Visible = False
                    Me.GridView1.Columns(12).Visible = False
                    Me.GridView1.Columns(13).Visible = False
                    Me.HiddenType.Value = 6

                Case 5                         '外來文件
                    Me.GridView1.Columns(9).Visible = False
                    Me.GridView1.Columns(10).Visible = False
                    Me.GridView1.Columns(11).Visible = False
                    Me.GridView1.Columns(12).Visible = False
                    Me.GridView1.Columns(13).Visible = False
                    Me.HiddenType.Value = 10
            End Select
            BindGridDept()
            ' BindGridData(InitSearch)
            'Dim helper As New GridViewHelper(Me.GridView1)
            'helper.RegisterGroup("FileDept", True, False)
            'helper.ApplyGroupSort()
        End If
    End Sub
    Private Sub GetRequestParam()
        If Not Request.QueryString("Type") Is Nothing Then
            CurType = Request.QueryString("Type")

        End If

    End Sub
    Private Sub BindGridDept()
        Dim dt As DataTable = OutFileManageDAL.GetDeptBySearchcondition(InitSearch)

        Me.GridViewTop.DataSource = dt
        Me.GridViewTop.DataBind()

    End Sub

    Private Sub BindGridData(ByVal SearchCondition As String)
        Dim TotalRecord As Integer = 0
        Dim ds As DataSet = TableBMHDAL.GetPageInfoBySearchCondition("OutFileManage", SearchCondition, "*", SortField, PageSize, PageIndex, TotalRecord)
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
            e.Row.Attributes.Add("onmouseover", "this.style.color='#FFFFFF'; currentcolor=this.style.backgroundColor;this.style.backgroundColor='#40A0FE',this.style.fontWeight='';")
            e.Row.Attributes.Add("onmouseout", "this.style.color='#1e5494'; this.style.backgroundColor=currentcolor,this.style.fontWeight='';")
            If e.Row.RowState = DataControlRowState.Alternate OrElse e.Row.RowState = DataControlRowState.Normal Then
                count += 1
                Dim HLDetail As HyperLink = CType(e.Row.FindControl("HLDetail"), HyperLink)
                Dim pkid As Integer = Convert.ToInt32(CType(e.Row.FindControl("LblPKID"), Label).Text)
                Dim DocUniqueID As String = CType(e.Row.FindControl("lblDocUniqueID"), Label).Text
                Dim returnurl As String = "../Forms/OutFileDetail.aspx?pkid=" + pkid.ToString + "&Type=" + CurType.ToString
                If (DocUniqueID <> String.Empty AndAlso DocUniqueID <> Guid.Empty.ToString) Then
                    returnurl = returnurl + "&" + Global_asax.QUERY_DOCUNIQUEID + "=" + DocUniqueID
                End If
                HLDetail.NavigateUrl = returnurl
                Dim BtnCancel As ImageButton = TryCast(e.Row.FindControl("BtnDelete"), ImageButton)
                BtnCancel.Attributes.Add("onclick", " return confirm('確定要刪除該記錄嗎?');")
                If e.Row.Cells(3).Text.Length > 20 Then
                    e.Row.Cells(3).ToolTip = e.Row.Cells(3).Text
                    e.Row.Cells(3).Text = e.Row.Cells(3).Text.Substring(0, 19) + "..."
                End If
            End If
        ElseIf e.Row.RowType = DataControlRowType.Footer Then
            e.Row.Cells(15).Text = count.ToString
        End If

    End Sub
    Protected Sub GridView1_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles GridView1.RowDeleting
        Dim mpkid As Integer = Convert.ToInt32(GridView1.DataKeys(e.RowIndex).Value)
        OutFileManageDAL.Delete(mpkid)
        Dim newdeletelog As DeleteLogInfo = New DeleteLogInfo()
        newdeletelog.pkid = 0
        newdeletelog.Parentid = mpkid
        newdeletelog.parenttype = "其它文件"
        newdeletelog.DeleteUserName = UserInfo.CurrentUserCHName
        newdeletelog.DeleteUserSID = UserInfo.CurrentUserID
        newdeletelog.RecordCreated = DateTime.Now
        Dim newdeletedal As DeleteLogDAL = New DeleteLogDAL(newdeletelog)
        newdeletedal.Save()
        BindGridData(SearchCondition)
    End Sub

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button1.Click
        Dim newsearchcondition As StringBuilder = New StringBuilder()
        newsearchcondition.Append(InitSearch)
        Me.GridViewTop.Visible = False
        Me.GridView1.Visible = True
        If Me.TxtSearchCondition.Text.Trim() <> String.Empty Then
            newsearchcondition.Append(String.Format(" AND (FileDept LIKE '%{0}%' OR QYLocation LIKE '%{0}%' OR FileName LIKE '%{0}%' OR FileBH LIKE '%{0}%' OR FileVersion LIKE '%{0}%' OR Remark LIKE '%{0}%')", Me.TxtSearchCondition.Text.ToString.Trim.Replace("'", "''")))
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
        'Dim helper As New GridViewHelper(Me.GridView1)
        'helper.RegisterGroup("FileDept", True, False)
        'helper.ApplyGroupSort()
    End Sub

    Private Sub PagerControl1_PageSizeChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles PagerControl1.PageSizeChanged
        BindGridData(SearchCondition)
        'Dim helper As New GridViewHelper(Me.GridView1)
        'helper.RegisterGroup("FileDept", True, False)
        'helper.ApplyGroupSort()
    End Sub

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
        Dim curgridQu As GridQy = CType(dr.FindControl("GridQy1"), GridQy)
        curgridQu.Searchcondition = InitSearch + " and FileDept='" + deptname.ToString + "'"
        curgridQu.RecordType = CurType
        curgridQu.Parentindex = rowindex
        curgridQu.BindQu()
        Dim Image2 As Image = CType(dr.FindControl("Image2"), Image)
        Image2.Attributes.Remove("onclick")
        Image2.Attributes.Add("onclick", "deptchangeshow('" + curgridQu.ClientID + "_GridView1','" + rowindex.ToString + "')")
    End Sub

    Protected Sub BtnSetCSSshow_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BtnSetCSSshow.Click
        Dim curQyindex As String = Me.HiddencursetcssQyindex.Value
        Dim curgridqy As GridQy = CType(Me.GridViewTop.Rows(curQyindex).FindControl("GridQy1"), GridQy)
        curgridqy.DisplayInfo = "Show"
        curgridqy.BindQu()
    End Sub

    Protected Sub BtnSetCSShidd_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BtnSetCSShidd.Click
        Dim curQyindex As String = Me.HiddencursetcssQyindex.Value
        Dim curgridqy As GridQy = CType(Me.GridViewTop.Rows(curQyindex).FindControl("GridQy1"), GridQy)
        curgridqy.DisplayInfo = "Hid"
        curgridqy.BindQu()
    End Sub
    Protected Sub BtnSetFileCssShow_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BtnSetFileCssShow.Click
        Dim curfileindex As String = Me.Hiddencursetcssfileindex.Value
        Dim fatherindex = Me.Hiddenparenetindex.Value
        Dim curgridqy As GridQy = CType(Me.GridViewTop.Rows(fatherindex).FindControl("GridQy1"), GridQy)
        Dim curoutfile As GridOutFile = CType(CType(curgridqy.FindControl("Gridview1"), GridView).Rows(curfileindex).FindControl("GridOutFile1"), GridOutFile)
        curoutfile.DisplayInfo = "Show"
        curoutfile.BinOutFile()
    End Sub

    Protected Sub BtnSetFileCSSHid_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BtnSetFileCSSHid.Click
        Dim curfileindex As String = Me.Hiddencursetcssfileindex.Value
        Dim fatherindex = Me.Hiddenparenetindex.Value
        Dim curgridqy As GridQy = CType(Me.GridViewTop.Rows(fatherindex).FindControl("GridQy1"), GridQy)
        Dim curoutfile As GridOutFile = CType(CType(curgridqy.FindControl("Gridview1"), GridView).Rows(curfileindex).FindControl("GridOutFile1"), GridOutFile)
        curoutfile.DisplayInfo = "Hid"
        curoutfile.BinOutFile()
    End Sub
End Class