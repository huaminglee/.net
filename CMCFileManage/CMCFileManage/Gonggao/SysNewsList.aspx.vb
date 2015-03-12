Imports Platform.eAuthorize

Partial Public Class SysNewsList
    Inherits System.Web.UI.Page

#Region "屬性"
    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' 當前頁的索引
    ''' </summary>
    ''' -----------------------------------------------------------------------------

    Private Property PageIndex() As Integer
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
    Private Property PageSize() As Integer
        Get
            Return Me.PagerControl1.RecordsPerPage
        End Get
        Set(ByVal Value As Integer)
            Me.PagerControl1.RecordsPerPage = Value
        End Set
    End Property



#End Region

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then

            Me.PagerControl1.RecordsPerPage = ConfigurationInfo.PageSize
            BindGridData()
        End If

        RegisterScript()
    End Sub

#Region "Private Methods"

    Private Sub RegisterScript()
        Dim TextMsgDeleteTip As String = "是否刪除選中的記錄？"
        Me.LinkDelete.Attributes.Add("onclick", "return DeleteConfirm('" + TextMsgDeleteTip + "');")
        Me.TxtStartTime.Attributes.Add("onclick", "javascript:WdatePicker({startDate:'%y-%M-01',dateFmt:'yyyy-MM-dd',alwaysUseStartDate:true});")
        Me.TxtEndTime.Attributes.Add("onclick", "javascript:WdatePicker({startDate:'%y-%M-01',dateFmt:'yyyy-MM-dd',alwaysUseStartDate:true});")
        If UserInfo.IsInRoles("SYS_ADMINISTRATOR") OrElse UserInfo.IsInRoles("QA") Then
            Me.NewItem.Visible = True
            If UserInfo.IsInRoles("SYS_ADMINISTRATOR") Then
                Me.LinkDelete.Visible = True
                Me.GridView1.Columns(1).Visible = True
            End If
        End If
    End Sub

    Private Sub BindGridData()
        Dim ds As DataSet = Nothing
        Dim TotalRecord As Integer = 0

        Dim SearchCondition As String = String.Empty


        If Me.TxtTitle.Text <> String.Empty Then
            SearchCondition = "  NewTitle like '%" + Me.TxtTitle.Text.Trim + "%'"
        End If

        If Me.TxtStartTime.Text <> String.Empty AndAlso Me.TxtEndTime.Text <> String.Empty Then
            If SearchCondition = String.Empty Then
                SearchCondition = String.Format("  RecordCreated Between '{0}' AND '{1}'", Me.TxtStartTime.Text, Me.TxtEndTime.Text)
            Else

                SearchCondition = SearchCondition + String.Format(" AND RecordCreated Between '{0}' AND '{1}'", Me.TxtStartTime.Text, Me.TxtEndTime.Text)

            End If

        End If
        Dim Files As String = "NewSID,NewTitle,CreateUser,RecordCreated"
        ds = ConfigurationInfo.GetPageInfoBySearchCondition("Sys_News", SearchCondition, "*", "NewsID", Me.PageSize, Me.PageIndex, TotalRecord)
        If ds Is Nothing Then

            Me.PagerControl1.Visible = False
            Me.LinkDelete.Visible = False


            Me.GridView1.DataSource = Nothing
            Me.GridView1.DataBind()
        Else

            Dim dt As DataTable = ds.Tables(0)

            Me.PagerControl1.Visible = True
            Me.PagerControl1.TotalRecords = CInt(ds.Tables(1).Rows(0)("TotalRecord"))
            Me.GridView1.DataSource = dt
            Me.GridView1.DataKeyNames = New String() {"NewsID"}
            Me.GridView1.DataBind()
        End If
    End Sub
#End Region

#Region "Button Events"

    Private Sub NewItem_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles NewItem.Click
        Response.Redirect("SysNewsDetail.aspx")
    End Sub

    Private Sub LinkDelete_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LinkDelete.Click
        Dim j As Integer = 0
        Dim RowCount As Integer = Me.GridView1.Rows.Count
        If RowCount > 0 Then
            For i As Integer = 0 To RowCount - 1
                Dim mDataGridItem As GridViewRow = Me.GridView1.Rows(i)
                If CType(mDataGridItem.FindControl("ChkSelect"), CheckBox).Checked Then
                    Dim KeyPKID As String = GridView1.DataKeys(i).Value
                    Sys_NewsDAL.Delete(KeyPKID)
                    j += 1
                End If
            Next
            If (j = RowCount) Then
                If Me.GridView1.PageIndex > 0 Then
                    Me.GridView1.PageIndex = Me.GridView1.PageIndex - 1
                Else
                    Me.GridView1.PageIndex = 0
                End If
            End If
        End If

        BindGridData()
    End Sub


    Private Sub LinkSearch_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LinkSearch.Click



        BindGridData()

    End Sub

#End Region

#Region "GridView Events"


    Private Sub GridView1_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GridView1.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            If e.Row.RowState = DataControlRowState.Normal OrElse e.Row.RowState = DataControlRowState.Alternate Then
                Dim mPKID As String = GridView1.DataKeys(e.Row.RowIndex).Value
                e.Row.Attributes.Add("onmouseover", "this.style.color='#FFFFFF'; currentcolor=this.style.backgroundColor;this.style.backgroundColor='#40A0FE',this.style.fontWeight='';")
                e.Row.Attributes.Add("onmouseout", "this.style.color='#000000';this.style.backgroundColor=currentcolor,this.style.fontWeight='';")

                Dim HLDetail As HyperLink = CType(e.Row.FindControl("HLDetail"), HyperLink)

                Dim ReturnURL As String = "SysNewsDetail.aspx?" & Global_asax.QUERY_APPLICANTIDX & "={0}"
                HLDetail.NavigateUrl = String.Format(ReturnURL, mPKID)

                Dim BtnCancel As ImageButton = TryCast(e.Row.FindControl("BtnDelete"), ImageButton)
                BtnCancel.Attributes.Add("onclick", " return confirm('確定要刪除該記錄嗎?');")

            End If
        End If
    End Sub

    Private Sub GridView1_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles GridView1.RowDeleting
        Dim DeletePKID As String = GridView1.DataKeys(e.RowIndex).Value
        Sys_NewsDAL.Delete(DeletePKID)
        BindGridData()
    End Sub

    Private Sub GridView1_RowCreated(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GridView1.RowCreated
        If e.Row.RowType = DataControlRowType.DataRow Then
            Dim ChkSelect As CheckBox = CType(e.Row.FindControl("ChkSelect"), CheckBox)
            If UserInfo.IsInRoles("SYS_ADMINISTRATOR") Then
                ChkSelect.Visible = True
            End If
        End If
        If e.Row.RowType = DataControlRowType.Header Then
            Dim objCheckBox As CheckBox = CType(e.Row.FindControl("CheckAll"), CheckBox)
            If UserInfo.IsInRoles("SYS_ADMINISTRATOR") Then
                objCheckBox.ValidationGroup = True
                objCheckBox.Attributes.Add("onclick", "return CheckChanged()")
            End If

        End If
    End Sub


#End Region

#Region "Custom Paging Event"



    Private Sub PagerControl1_PageChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles PagerControl1.PageChanged

        BindGridData()
    End Sub

    Private Sub PagerControl1_PageSizeChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles PagerControl1.PageSizeChanged
        BindGridData()
    End Sub
#End Region

End Class