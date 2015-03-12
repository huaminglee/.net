Imports Platform.eAuthorize

Partial Public Class EquipManageList
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
                SearchCondition = "RecordDeleted=0 "
                If Not UserInfo.CurrentUserInstance Is Nothing AndAlso (UserInfo.IsInRoles("QA") OrElse UserInfo.IsInRoles("Audit") OrElse UserInfo.IsInRoles("SYS_ADMINISTRATOR")) Then

                Else
                    Dim changqu As String = "LH"
                    Dim curneefaround As String = "龍華檢測中心"
                    If Not Request.Cookies("changqu") Is Nothing Then
                        changqu = Server.HtmlEncode(Request.Cookies("changqu").Value)
                    End If
                    'Select Case changqu
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

                        SearchCondition += String.Format(" AND charindex(EquipDept,'{0}')>0", curdeptstr)
                    Else
                        SearchCondition = " 1>2"   '無部門信息
                    End If
                    If UserInfo.CurrentUserInstance Is Nothing Then         '對外廠區人員只能看到已結案的
                        SearchCondition += " and IsFinish=1"
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
                Me.addnew3.Attributes.Add("style", "display:none")
                Me.addnew2.Attributes.Add("style", "display:none")
                Me.GridView1.Columns(8).Visible = False
            End If
            ' BindGrid(InitSearch)
            BingGridTop()
            If UserInfo.IsInRoles("QALeader") Then
                Me.GridView1.Columns(8).Visible = True
            End If
        End If
    End Sub
    Private Sub BingGridTop()
        Dim dt As DataTable = EquipManageDAL.GetDeptBySearchcondition(InitSearch)
        Me.GridViewTop.DataSource = dt
        Me.GridViewTop.DataBind()
    End Sub
    Private Sub BindGrid(ByVal SearchCondition As String)
        Dim TotalRecord As Integer = 0
        Dim ds As DataSet = TableBMHDAL.GetPageInfoBySearchCondition("EquipManage", SearchCondition, "*", SortField, PageSize, PageIndex, TotalRecord)
        If Not ds Is Nothing Then
            Me.PagerControl1.Visible = True
            Me.PagerControl1.TotalRecords = CInt(ds.Tables(1).Rows(0)("TotalRecord"))
            Me.GridView1.DataSource = ds
            Me.GridView1.DataKeyNames = New String() {"PKID"}
            Me.GridView1.DataBind()
        Else
            Me.PagerControl1.Visible = False
            Me.GridView1.DataSource = Nothing
            Me.GridView1.DataBind()
        End If


    End Sub

    Protected Sub GridView1_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GridView1.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then

            Dim mPKID As Integer = CInt(GridView1.DataKeys(e.Row.RowIndex).Value)
            Dim DocUniqueID As String = CType(e.Row.FindControl("lblDocUniqueID"), Label).Text
            Dim HLDetail As HyperLink = CType(e.Row.FindControl("HLDetail"), HyperLink)
            Dim ReturnURL As String = "../Forms/EquipManageDetail.aspx?pkid=" + mPKID.ToString
            'If (DocUniqueID <> String.Empty AndAlso DocUniqueID <> Guid.Empty.ToString) Then
            '    ReturnURL = ReturnURL + "&" + Global_asax.QUERY_DOCUNIQUEID + "=" + DocUniqueID
            'End If
            HLDetail.NavigateUrl = ReturnURL
            Dim BtnCancel As ImageButton = TryCast(e.Row.FindControl("BtnDelete"), ImageButton)
            BtnCancel.Attributes.Add("onclick", " return confirm('確定要刪除該記錄嗎?');")

            Dim LbEquipModel As Label = CType(e.Row.FindControl("LbEquipModel"), Label)
            If LbEquipModel.Text.Length > 10 Then
                LbEquipModel.ToolTip = LbEquipModel.Text
                LbEquipModel.Text = LbEquipModel.Text.Substring(0, 9) + "..."
            End If
            Dim LbSpecification As Label = CType(e.Row.FindControl("LbSpecification"), Label)
            If LbSpecification.Text.Length > 10 Then
                LbSpecification.ToolTip = LbSpecification.Text
                LbSpecification.Text = LbSpecification.Text.Substring(0, 9) + "..."
            End If
            Dim lbishadetail As Label = CType(e.Row.FindControl("LbisHasDetail"), Label)
            Dim LbshowisHasDetail As Label = CType(e.Row.FindControl("LbshowisHasDetail"), Label)
            If lbishadetail.Text = 0 Then
                LbshowisHasDetail.Text = "無"
            Else
                LbshowisHasDetail.Text = "有"
            End If
        End If
    End Sub
    Protected Sub GridView1_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles GridView1.RowDeleting
        Dim mpkid As Integer = Convert.ToInt32(GridView1.DataKeys(e.RowIndex).Value)
        EquipManageDAL.Delete(mpkid)
        Dim newdeletelog As DeleteLogInfo = New DeleteLogInfo()
        newdeletelog.pkid = 0
        newdeletelog.Parentid = mpkid
        newdeletelog.parenttype = "設備清單"
        newdeletelog.DeleteUserName = UserInfo.CurrentUserCHName
        newdeletelog.DeleteUserSID = UserInfo.CurrentUserID
        newdeletelog.RecordCreated = DateTime.Now
        Dim newdeletedal As DeleteLogDAL = New DeleteLogDAL(newdeletelog)
        newdeletedal.Save()
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

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button1.Click
        Dim newsearchcondition As StringBuilder = New StringBuilder()
        newsearchcondition.Append(InitSearch)
        Me.GridViewTop.Visible = False
        If Me.TxtSearchCondition.Text.Trim() <> String.Empty Then
            newsearchcondition.Append(String.Format(" AND (EquipDept LIKE '%{0}%' OR EquipName LIKE '%{0}%' OR ControlNO LIKE '%{0}%' OR ManuFacturer LIKE '%{0}%' OR EquipModel LIKE '%{0}%')", Me.TxtSearchCondition.Text.ToString.Trim))
        End If
        ViewState("SearchCondition") = newsearchcondition
        BindGrid(SearchCondition)
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
        curgridQu.Searchcondition = InitSearch + " and EquipDept='" + deptname.ToString + "'"
        curgridQu.ParentType = 3
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
        Dim curequip As GridEquip = CType(CType(curgridqy.FindControl("Gridview1"), GridView).Rows(curfileindex).FindControl("GridEquip1"), GridEquip)
        curequip.DisplayInfo = "Show"
        curequip.BindEquip()
    End Sub

    Protected Sub BtnSetFileCSSHid_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BtnSetFileCSSHid.Click
        Dim curfileindex As String = Me.Hiddencursetcssfileindex.Value
        Dim fatherindex = Me.Hiddenparenetindex.Value
        Dim curgridqy As GridQy = CType(Me.GridViewTop.Rows(fatherindex).FindControl("GridQy1"), GridQy)
        Dim curequip As GridEquip = CType(CType(curgridqy.FindControl("Gridview1"), GridView).Rows(curfileindex).FindControl("GridEquip1"), GridEquip)
        curequip.DisplayInfo = "Hid"
        curequip.BindEquip()
    End Sub
End Class