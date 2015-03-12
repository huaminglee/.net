Public Partial Class NGItemReason
    Inherits System.Web.UI.Page
#Region "Const"

    Private Const HIDE_APPLICANTIDX_KEY As String = "ViewState:DeptItemPKID"
   
#End Region
#Region "Properties"
    '當前文件惟一ID
    Private Property DeptItemPKID() As Integer
        Get
            If ViewState(HIDE_APPLICANTIDX_KEY) Is Nothing Then
                Return 0

            End If

            Return Convert.ToInt32(ViewState(HIDE_APPLICANTIDX_KEY))
        End Get
        Set(ByVal Value As Integer)
            ViewState(HIDE_APPLICANTIDX_KEY) = Value
        End Set
    End Property
    Private _DeptItemInfo As GEPCSI_DeptItem
    Private Property DeptItemInfo() As GEPCSI_DeptItem
        Get
            If _DeptItemInfo Is Nothing Then
                If DeptItemPKID <> 0 Then
                    _DeptItemInfo = GEPCSI_DeptItem.GetInfoByPKID(DeptItemPKID)
                Else
                    _DeptItemInfo = New GEPCSI_DeptItem()
                End If

            End If
            Return _DeptItemInfo
        End Get
        Set(ByVal value As GEPCSI_DeptItem)
            _DeptItemInfo = value
        End Set
    End Property
    Private Property SearchCondition() As String
        Get
            If ViewState("SearchCondition") Is Nothing Then
                ViewState("SearchCondition") = " A.DeptItemPKID=" + DeptItemPKID.ToString
            Else
            End If
            Return ViewState("SearchCondition").ToString
        End Get
        Set(ByVal value As String)
            ViewState("SearchCondition") = value
        End Set
    End Property
#End Region
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            Getparam()
            BindControlData()
            BindGrid(SearchCondition)
        End If
    End Sub
    Private Sub GetParam()
        If Not Request.QueryString("DeptItemPKID") Is Nothing Then
            DeptItemPKID = Convert.ToInt32(Request.QueryString("DeptItemPKID"))
            Me.HidDeptItemPKID.Value = DeptItemPKID
        End If
    End Sub
    Private Sub BindControlData()
        If Not DeptItemInfo Is Nothing Then
            If DeptItemPKID <> 0 Then
                Me.LbTitle.Text = DeptItemInfo.ItemName
            End If
        End If
    End Sub
    Private Sub BindGrid(ByVal SearchCondition As String)
        Dim ds As DataSet = GEPCSI_NGItemReasonDAL.GetInfoBySearchCondtion(SearchCondition)
        If Not ds Is Nothing Then
            Me.GridView1.DataSource = ds
            Me.GridView1.DataKeyNames = New String() {"PKID"}
            Me.GridView1.DataBind()
        End If
    End Sub

    Protected Sub GridView1_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GridView1.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then

            Dim mPKID As Integer = CInt(GridView1.DataKeys(e.Row.RowIndex).Value)
          
            Dim BtnCancel As ImageButton = TryCast(e.Row.FindControl("BtnDelete"), ImageButton)
            BtnCancel.Attributes.Add("onclick", " return confirm('確定要刪除該記錄嗎?');")

            Dim CheIsTextBox As CheckBox = CType(e.Row.FindControl("CheIsTextBox"), CheckBox)
            Dim lbistextbox As Label = CType(e.Row.FindControl("LbIsTextBox"), Label)
            If lbistextbox.Text = 1 Then
                CheIsTextBox.Checked = True
            Else
                CheIsTextBox.Checked = False
            End If
        End If
    End Sub

    Protected Sub GridView1_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles GridView1.RowDeleting
        Dim mpkid As Integer = Convert.ToInt32(GridView1.DataKeys(e.RowIndex).Value)
        GEPCSI_NGItemReasonDAL.Delete(mpkid)
        BindGrid(SearchCondition)
    End Sub

  
    Protected Sub ImbSave_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImbSave.Click
        Dim i As Integer
        For i = 0 To GridView1.Rows.Count - 1
            Dim griditem As GridViewRow = GridView1.Rows(i)
            Dim curpkid As Integer = Convert.ToInt32(GridView1.DataKeys(griditem.RowIndex).Value)
            Dim curNGItemInfo As GEPCSI_NGItemReasonInfo = GEPCSI_NGItemReasonDAL.GetInfoByPKID(curpkid)
            Dim checkboxistext As CheckBox = CType(griditem.FindControl("CheIsTextBox"), CheckBox)
            If checkboxistext.Checked = True Then
                curNGItemInfo.IsWithTextBox = 1
            Else
                curNGItemInfo.IsWithTextBox = 0
            End If
            Dim curNgdal As GEPCSI_NGItemReasonDAL = New GEPCSI_NGItemReasonDAL(curNGItemInfo)
            curNgdal.Save()
        Next
        Response.Redirect("../GMPCSI/DeptItemList.aspx?DeptPKID=" + DeptItemInfo.DeptPKID.ToString)
    End Sub

    Protected Sub btn1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn1.Click
        BindGrid(SearchCondition)
    End Sub

    Protected Sub ImbLeave_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImbLeave.Click
        Response.Redirect("../GMPCSI/DeptItemList.aspx?DeptPKID=" + DeptItemInfo.DeptPKID.ToString)
    End Sub
End Class