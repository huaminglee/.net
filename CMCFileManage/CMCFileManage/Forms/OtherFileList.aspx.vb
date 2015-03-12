Imports Platform.eAuthorize

Partial Public Class OtherFileList
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

    ''''<summary>
    ''''當前請求狀態
    ''''</summary>
    'Private Property CurType() As String
    '    Get
    '        Return CStr(ViewState(_RequestType))
    '    End Get
    '    Set(ByVal Value As String)
    '        ViewState(_RequestType) = Value
    '    End Set
    'End Property
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
                ViewState(HIDE_SORTFIELD) = "StandardDept"
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
               
                SearchCondition += " and RecordStype =1 "

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
                        SearchCondition += String.Format(" AND( charindex(StandardDept,'{0}')>0", curdeptstr)  '部門在分發單位中
                        SearchCondition += " or StandardDept ='品保課') "
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
            Me.addnew.HRef = "OtherFileDetail.aspx"
            If UserInfo.CurrentUserInstance Is Nothing Then
                Me.add.Attributes.Add("style", "display:none")
            End If
            If UserInfo.IsInRoles("QALEADER") Then
                Me.GridView1.Columns(8).Visible = True
            Else
                Me.GridView1.Columns(8).Visible = False
            End If
            If UserInfo.IsInRoles("LabFileManager") Then
                Me.add.Visible = True
            Else
                Me.add.Visible = False
            End If
            bindgridtop()
            ' BindGridData(InitSearch)
            'Dim helper As New GridViewHelper(Me.GridView1)
            'helper.RegisterGroup("StandardDept", True, False)
            'helper.ApplyGroupSort()
        End If
    End Sub
    Dim count As Integer = 0
    Private Sub bindgridtop()
        Dim dt As DataTable = StandardFileManageDAL.GetDeptBysearchcondition(InitSearch)
        Me.GridViewTop.DataSource = dt
        Me.GridViewTop.DataBind()
    End Sub
    Private Sub BindGridData(ByVal SearchCondition As String)
        Dim TotalRecord As Integer = 0
        Dim ds As DataSet = TableBMHDAL.GetPageInfoBySearchCondition("StandardFileManage", SearchCondition, "*", SortField, PageSize, PageIndex, TotalRecord)
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
    Protected Sub GridView1_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles GridView1.RowDeleting
        Dim mpkid As Integer = Convert.ToInt32(GridView1.DataKeys(e.RowIndex).Value)
        StandardFileManageDAL.Delete(mpkid)
        Dim newdeletelog As DeleteLogInfo = New DeleteLogInfo()
        newdeletelog.pkid = 0
        newdeletelog.Parentid = mpkid
        newdeletelog.parenttype = "測試標準"
        newdeletelog.DeleteUserName = UserInfo.CurrentUserCHName
        newdeletelog.DeleteUserSID = UserInfo.CurrentUserID
        newdeletelog.RecordCreated = DateTime.Now
        Dim newdeletedal As DeleteLogDAL = New DeleteLogDAL(newdeletelog)
        newdeletedal.Save()
        BindGridData(SearchCondition)
    End Sub
    Protected Sub GridView1_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GridView1.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            e.Row.Attributes.Add("onmouseover", "this.style.color='#FFFFFF'; currentcolor=this.style.backgroundColor;this.style.backgroundColor='#40A0FE',this.style.fontWeight='';")
            e.Row.Attributes.Add("onmouseout", "this.style.color='#1e5494'; this.style.backgroundColor=currentcolor,this.style.fontWeight='';")
            If e.Row.RowState = DataControlRowState.Alternate OrElse e.Row.RowState = DataControlRowState.Normal Then
                count += 1
                Dim HLDetail As HyperLink = CType(e.Row.FindControl("HLDetail"), HyperLink)
                Dim pkid As Integer = Convert.ToInt32(CType(e.Row.FindControl("LblPKID"), Label).Text)
                Dim returnurl As String = "../Forms/OtherFileDetail.aspx?pkid=" + pkid.ToString
                HLDetail.NavigateUrl = returnurl
                Dim BtnCancel As ImageButton = TryCast(e.Row.FindControl("BtnDelete"), ImageButton)
                BtnCancel.Attributes.Add("onclick", " return confirm('確定要刪除該記錄嗎?');")
                Dim LbFileStatusnum As Label = CType(e.Row.FindControl("LbFileStatusnum"), Label)
                Dim LbFileStatus As Label = CType(e.Row.FindControl("LbFileStatus"), Label)
                Select Case LbFileStatusnum.Text
                    Case "1"
                        LbFileStatus.Text = "參考"
                    Case "2"
                        LbFileStatus.Text = "使用"
                    Case "3"
                        LbFileStatus.Text = "參考&使用"

                End Select
                If e.Row.Cells(3).Text.Length > 20 Then
                    e.Row.Cells(3).ToolTip = e.Row.Cells(3).Text
                    e.Row.Cells(3).Text = e.Row.Cells(3).Text.Substring(0, 19) + "..."
                End If
            End If
        ElseIf e.Row.RowType = DataControlRowType.Footer Then
            e.Row.Cells(9).Text = count.ToString
        End If

    End Sub
    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button1.Click
        Dim newsearchcondition As StringBuilder = New StringBuilder()
        newsearchcondition.Append(InitSearch)
        Me.GridViewTop.Visible = False
        If Me.TxtSearchCondition.Text.Trim() <> String.Empty Then
            newsearchcondition.Append(String.Format(" AND (StandardDept LIKE '%{0}%' OR QYLocation LIKE '%{0}%' OR StandardName LIKE '%{0}%' OR StandardNumber LIKE '%{0}%' OR StandardVersion LIKE '%{0}%' OR StandardOrganize LIKE '%{0}%')", Me.TxtSearchCondition.Text.ToString.Trim))
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
#Region "PageEvent"
    Private Sub PagerControl1_PageChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles PagerControl1.PageChanged
        BindGridData(SearchCondition)
        'Dim helper As New GridViewHelper(Me.GridView1)
        'helper.RegisterGroup("StandardDept", True, False)
        'helper.ApplyGroupSort()
    End Sub

    Private Sub PagerControl1_PageSizeChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles PagerControl1.PageSizeChanged
        BindGridData(SearchCondition)
        'Dim helper As New GridViewHelper(Me.GridView1)
        'helper.RegisterGroup("StandardDept", True, False)
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
        curgridQu.Searchcondition = InitSearch + " and StandardDept='" + deptname.ToString + "'"
        curgridQu.ParentType = 2
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
        'Dim curfileindex As String = Me.Hiddencursetcssfileindex.Value
        'Dim fatherindex = Me.Hiddenparenetindex.Value
        'Dim curgridqy As GridQy = CType(Me.GridViewTop.Rows(fatherindex).FindControl("GridQy1"), GridQy)
        'Dim curoutfile As GridOutFile = CType(CType(curgridqy.FindControl("Gridview1"), GridView).Rows(curfileindex).FindControl("GridOutFile1"), GridOutFile)
        'curoutfile.DisplayInfo = "Show"
        'curoutfile.BinOutFile()
    End Sub

    Protected Sub BtnSetFileCSSHid_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BtnSetFileCSSHid.Click
        'Dim curfileindex As String = Me.Hiddencursetcssfileindex.Value
        'Dim fatherindex = Me.Hiddenparenetindex.Value
        'Dim curgridqy As GridQy = CType(Me.GridViewTop.Rows(fatherindex).FindControl("GridQy1"), GridQy)
        'Dim curotherfile As GridOtherFile = CType(CType(curgridqy.FindControl("Gridview1"), GridView).Rows(curfileindex).FindControl("GridOtherFile1"), GridOtherFile)
        'curotherfile.DisplayInfo = "Hid"
        'curotherfile.BindOthweFile()
    End Sub
  
#End Region

   
End Class