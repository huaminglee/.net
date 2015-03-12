Public Partial Class DeptItemList
    Inherits System.Web.UI.Page
    Private Property DeptPKID() As String
        Get
            If ViewState("DeptPKID") Is Nothing Then
                Return 0
            Else
                Return ViewState("DeptPKID").ToString

            End If
        End Get
        Set(ByVal value As String)
            ViewState("DeptPKID") = value
            Me.HidDeptPKID.Value = value
        End Set
    End Property
    Private Property SearchCondition() As String
        Get
            If ViewState("SearchCondition") Is Nothing Then
                ViewState("SearchCondition") = " DeptPKID=" + DeptPKID
            Else
            End If
            Return ViewState("SearchCondition").ToString
        End Get
        Set(ByVal value As String)
            ViewState("SearchCondition") = value
        End Set
    End Property
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            GetParam()
            BindDept()
            If DeptPKID <> 0 Then
                Me.Lbtitle.Text = GEPCSI_Dept.GetDeptnameByDeptPKID(DeptPKID)
                BindGrid(SearchCondition)

            End If
        End If

    End Sub
    Private Sub GetParam()
        If Not Request.QueryString("DeptPKID") Is Nothing Then
            DeptPKID = Convert.ToInt32(Request.QueryString("DeptPKID"))
        End If
    End Sub
    Private Sub BindDept()
        Dim Alist As ArrayList = GEPCSI_Result.GetallDeptInfo()
        If Not Alist Is Nothing Then
            Me.DataList1.DataSource = Alist
            Me.DataList1.DataBind()
        End If
    End Sub
    Private Sub BindGrid(ByVal searchCondition As String)
        Dim ds As DataSet = GEPCSI_DeptItem.GetallDsBySearchCondtion(searchCondition)
        If Not ds Is Nothing Then
            Me.GridView1.DataSource = ds
            Me.GridView1.DataKeyNames = New String() {"DeptItemPKID"}
            Me.GridView1.DataBind()
        Else
            Me.GridView1.DataSource = Nothing
            Me.GridView1.DataBind()
        End If
    End Sub
    Protected Sub DataList1_ItemCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataListCommandEventArgs) Handles DataList1.ItemCommand
        Select Case e.CommandName
            Case "SearchDeptName"

                If e.Item.ItemType = ListItemType.Item OrElse e.Item.ItemType = ListItemType.AlternatingItem Then
                    DeptPKID = e.CommandArgument.ToString
                    Me.DataList1.SelectedIndex = e.Item.ItemIndex
                    SearchCondition = " DeptPKID=" + DeptPKID

                    Me.Lbtitle.Text = DirectCast(Me.DataList1.SelectedItem.FindControl("linkDeptName"), LinkButton).Text
                    BindDept()
                    BindGrid(SearchCondition)

                End If
        End Select
    End Sub

    Protected Sub GridView1_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GridView1.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then

            Dim mPKID As Integer = CInt(GridView1.DataKeys(e.Row.RowIndex).Value)
            Dim HLDetail As HyperLink = CType(e.Row.FindControl("HLDetail"), HyperLink)
            Dim ReturnURL As String = "../GMPCSI/NGItemReason.aspx?DeptItemPKID=" + mPKID.ToString
            HLDetail.NavigateUrl = ReturnURL
            Dim BtnCancel As ImageButton = TryCast(e.Row.FindControl("BtnDelete"), ImageButton)
            BtnCancel.Attributes.Add("onclick", " return confirm('確定要刪除該記錄嗎?');")
            Dim LbItemCategory As Label = CType(e.Row.FindControl("LbItemCategory"), Label)
            If LbItemCategory.Text = "3" Then
                LbItemCategory.Text = "多選項"
            ElseIf LbItemCategory.Text = "1" Then
                LbItemCategory.Text = "單選項"
            End If
        End If
    End Sub

    Protected Sub GridView1_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles GridView1.RowDeleting
        Dim mpkid As Integer = Convert.ToInt32(GridView1.DataKeys(e.RowIndex).Value)
        GEPCSI_DeptItem.Delete(mpkid)
        BindGrid(SearchCondition)
    End Sub
   
    Protected Sub btn1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn1.Click
        BindGrid(SearchCondition)
    End Sub
End Class