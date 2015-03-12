Imports Platform.eAuthorize

Partial Public Class PersonTecFileList
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
                SearchCondition = "RecordDeleted=0  "
                Select Case Me.RadioButtonList1.SelectedItem.Text
                    Case "全部"

                    Case "在職"
                        SearchCondition += " and CurType=1"
                    Case "離職"
                        SearchCondition += " and CurType=3"
                    Case "轉出"
                        SearchCondition += " and CurType=2"
                End Select
                If Not UserInfo.CurrentUserInstance Is Nothing AndAlso (UserInfo.IsInRoles("QA") OrElse UserInfo.IsInRoles("Audit") OrElse UserInfo.IsInRoles("SYS_ADMINISTRATOR")) Then

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
                        SearchCondition += String.Format(" AND charindex(Dept,'{0}')>0", curdeptstr)  '部門在分發單位中
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
            Me.addnew.HRef = "PersonTecFileDetail.aspx"
            If UserInfo.IsInRoles("QALEADER") Then
                Me.GridView1.Columns(9).Visible = True
            End If
            If UserInfo.IsInRoles("LabFileManager") OrElse UserInfo.IsInRoles("QA") Then
                Me.add.Visible = True
            Else
                Me.add.Visible = False
            End If
            BindGridTop()
            '  BindGridData(InitSearch)
        End If
    End Sub
    Private Sub BindGridData(ByVal Searchcontition As String)
        Dim dt As DataTable = PersonTecDAL.GetDsBySearchcontition(SearchCondition)
        If Not dt Is Nothing Then
            Me.emptyinfo.Visible = False
            Me.GridView1.DataSource = dt
            Me.GridView1.DataKeyNames = New String() {"PKID"}
            Me.GridView1.DataBind()
        Else
            Me.emptyinfo.Visible = True
            Me.GridView1.DataSource = Nothing
            Me.GridView1.DataBind()

        End If
    End Sub

    Protected Sub GridView1_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GridView1.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            e.Row.Attributes.Add("onmouseover", "this.style.color='#FFFFFF'; currentcolor=this.style.backgroundColor;this.style.backgroundColor='#40A0FE',this.style.fontWeight='';")
            e.Row.Attributes.Add("onmouseout", "this.style.color='#1e5494'; this.style.backgroundColor=currentcolor,this.style.fontWeight='';")

            Dim LbTypeInt As Label = CType(e.Row.FindControl("LbTypeInt"), Label)
            Dim LbType As Label = CType(e.Row.FindControl("LbType"), Label)
            Select Case LbTypeInt.Text
                Case "1"
                    LbType.Text = "在職"
                Case "2"
                    LbType.Text = "轉出"
                Case "3"
                    LbType.Text = "離職"
            End Select
            Dim pkid As Integer = CType(e.Row.FindControl("LblPKID"), Label).Text
            Dim returnurl As String = "../Forms/PersonTecFileDetail.aspx?pkid=" + pkid.ToString
            e.Row.Attributes.Add("onclick", "window.location.href='" + returnurl + "';")
            Dim BtnCancel As ImageButton = TryCast(e.Row.FindControl("BtnDelete"), ImageButton)
            BtnCancel.Attributes.Add("onclick", " return confirm('確定要刪除該記錄嗎?');")
        End If
    End Sub

 
    Protected Sub GridView1_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles GridView1.RowDeleting
        Dim mpkid As Integer = Convert.ToInt32(GridView1.DataKeys(e.RowIndex).Value)
        PersonTecDAL.Delete(mpkid)
        Dim newdeletelog As DeleteLogInfo = New DeleteLogInfo()
        newdeletelog.pkid = 0
        newdeletelog.Parentid = mpkid
        newdeletelog.parenttype = "人員技術檔案"
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
        Me.GridView1.Visible = True
        Me.GridViewTop.Visible = False
        If Me.TxtSearchCondition.Text.Trim() <> String.Empty Then
            newsearchcondition.Append(String.Format(" AND (Dept LIKE '%{0}%' OR QuLocation LIKE '%{0}%' OR UserName LIKE '%{0}%' OR UserSid LIKE '%{0}%' OR CerNO LIKE '%{0}%' OR Position LIKE '%{0}%')", Me.TxtSearchCondition.Text.ToString.Trim))
        End If
        ViewState("SearchCondition") = newsearchcondition
        BindGridData(SearchCondition)
    End Sub
    Private Sub BindGridTop()
        Dim dt As DataTable = PersonTecDAL.GetQuBySearchcontition(SearchCondition)
        Me.GridViewTop.DataSource = dt
        Me.GridViewTop.DataBind()
    End Sub

    Protected Sub Button3_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button3.Click
        BindQu()
    End Sub
    Private Sub BindQu()
        Dim deptname As String = Me.Hiddencurdeptname.Value
        Dim rowindex As Integer = Me.Hiddencurrowindex.Value
        Dim dr As GridViewRow = Me.GridViewTop.Rows(rowindex)
        Dim curgridQu As GridPersonDept = CType(dr.FindControl("GridPersonDept1"), GridPersonDept)
        curgridQu.Searchcondition = InitSearch + " and QuLocation='" + deptname.ToString + "'"
        curgridQu.Parentindex = rowindex
        curgridQu.ParentType = 1
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
        Dim curoutfile As GridPerson = CType(CType(curgridqy.FindControl("Gridview1"), GridView).Rows(curfileindex).FindControl("GridPerson1"), GridPerson)
        curoutfile.DisplayInfo = "Show"
        curoutfile.BindPerson()
    End Sub

    Protected Sub BtnSetFileCSSHid_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BtnSetFileCSSHid.Click
        Dim curfileindex As String = Me.Hiddencursetcssfileindex.Value
        Dim fatherindex = Me.Hiddenparenetindex.Value
        Dim curgridqy As GridPersonDept = CType(Me.GridViewTop.Rows(fatherindex).FindControl("GridPersonDept1"), GridPersonDept)
        Dim curoutfile As GridPerson = CType(CType(curgridqy.FindControl("Gridview1"), GridView).Rows(curfileindex).FindControl("GridPerson1"), GridPerson)
        curoutfile.DisplayInfo = "Hid"
        curoutfile.BindPerson()
    End Sub

    Protected Sub GridViewTop_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GridViewTop.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            Dim LbQuLocation As Label = CType(e.Row.FindControl("LbQuLocation"), Label)
            Dim Image2 As Image = CType(e.Row.FindControl("Image2"), Image)
            Image2.Attributes.Add("onclick", "BindQy('" + e.Row.RowIndex.ToString + "','" + LbQuLocation.Text.ToString + "')")
        End If
    End Sub

    Protected Sub RadioButtonList1_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles RadioButtonList1.SelectedIndexChanged
        BindGridTop()
    End Sub
End Class