Imports System.Web.UI.Page
Imports System.Runtime.InteropServices
Imports Platform.eAuthorize

Partial Public Class UcLog
    Inherits System.Web.UI.UserControl

    Private Const HIDE_RETURNCATEGORY As String = "ViewState:ReturnCategory"

    Private Property ReturnCategory() As Integer
        Get
            If ViewState(HIDE_RETURNCATEGORY) Is Nothing Then
                ViewState(HIDE_RETURNCATEGORY) = 0
            End If
            Return Convert.ToInt32(ViewState(HIDE_RETURNCATEGORY))
        End Get
        Set(ByVal Value As Integer)
            ViewState(HIDE_RETURNCATEGORY) = Value
        End Set
    End Property  '當前選中狀態的值

    Private Property SearchCondition() As String
        Get
            If ViewState("SearchCondition") Is Nothing Then
                ViewState("SearchCondition") = ""
            End If

            Return ViewState("SearchCondition")
        End Get
        Set(ByVal Value As String)
            ViewState("SearchCondition") = Value
        End Set
    End Property  '搜索條件

    Public Property PageIndex() As Integer
        Get
            Return Me.PagerControl1.CurrentPage
        End Get
        Set(ByVal Value As Integer)
            Me.PagerControl1.CurrentPage = Value
        End Set
    End Property

    Public Property PageSize() As Integer
        Get
            Return Me.PagerControl1.RecordsPerPage
        End Get
        Set(ByVal Value As Integer)
            Me.PagerControl1.RecordsPerPage = Value
        End Set
    End Property

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not Page.IsPostBack Then
            iStartDate.Value = Now.ToString("yyyy-MM-dd")
            iEndDate.Value = Now.ToString("yyyy-MM-dd")
            Dim operater As String = Request.QueryString("Operator")
            Dim operated As String = Request.QueryString("Operated")
            If UserInfo.IsInRoles(ConfigurationInfo.Role_Admin) Then
                Me.gvLog.Columns(8).Visible = True
            End If
            ddlType.DataSource = Log.LogType
            ddlType.DataBind()

            BindGridData(operater, operated)
        End If

    End Sub

    Private Sub BindGridData(ByVal operater As String, ByVal operated As String)
        Dim mInfos As List(Of Log) = Nothing
        Dim SearchStr As New StringBuilder()
        SearchStr.Append("  Time between '" & iStartDate.Value & " 00:00:00 ' and '" & iEndDate.Value & " 23:59:59' and RecordDeleted = 0 ")

        txtOperator.Text = operater
        txtObject.Text = operated
        If ddlType.SelectedIndex <> 0 Then
            'SearchStr.Append(" and Type = '" & ddlType.SelectedItem.Value & "'")
            SearchStr.Append(" and Type = '" & ddlType.SelectedIndex & "'")
        End If

        If txtOperator.Text.Trim().Length <> 0 Then
            SearchStr.Append(" and Operator = '" & txtOperator.Text.Trim() & "'")
        End If

        If txtObject.Text.Trim().Length <> 0 Then
            SearchStr.Append(" and Operated = '" & txtObject.Text.Trim() & "'")
        End If

        If UserInfo.IsInRoles(ConfigurationInfo.Role_Admin) Then
        Else
            SearchStr.Append("and ( Operator = '" + UserInfo.CurrentUserID + "' or Operated= '" + UserInfo.CurrentUserID + "' )")
        End If

        mInfos = Log.LoadInstanceCollectionByCustomPaging(SearchStr.ToString(), "Time DESC", "Log", PageIndex, PagerControl1.RecordsPerPage)
        Dim ResultCounts As Integer = Log.LoadInstanceCountgBySearch(SearchStr.ToString())

        If mInfos Is Nothing Then
            Me.PagerControl1.Visible = False
            Me.gvLog.DataSource = Nothing
            Me.gvLog.DataBind()
        Else
            Me.PagerControl1.Visible = True
            Me.PagerControl1.TotalRecords = ResultCounts
            Me.gvLog.DataSource = mInfos
            Me.gvLog.DataKeyNames = New String() {"PKID"}
            Me.gvLog.DataBind()
        End If

        gvLog.Columns(7).Visible = chkShowDetail.Checked
    End Sub



    Private Sub gvLog_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gvLog.RowDataBound

        Select Case e.Row.RowType
            Case DataControlRowType.DataRow
                Dim time As DateTime
                If DateTime.TryParse(CType(e.Row.FindControl("litTime"), Literal).Text, time) Then
                    CType(e.Row.FindControl("litTime"), Literal).Text = time.ToString("yyyy-MM-dd HH:mm:ss")
                End If

                Dim BtnCancel As ImageButton = TryCast(e.Row.FindControl("BtnDelete"), ImageButton)
                BtnCancel.Attributes.Add("onclick", " return confirm('確定要刪除該記錄嗎?');")


                'If Request.Url.ToString().Contains("?") Then
                '    CType(e.Row.FindControl("hylOperator"), HyperLink).NavigateUrl = Request.Url().ToString() & "&Operator=" & CType(e.Row.FindControl("hylOperator"), HyperLink).Text
                '    CType(e.Row.FindControl("hylOperated"), HyperLink).NavigateUrl = Request.Url().ToString() & "&Operated=" & CType(e.Row.FindControl("hylOperated"), HyperLink).Text
                'Else
                '    CType(e.Row.FindControl("hylOperator"), HyperLink).NavigateUrl = Request.Url().ToString() & "?Operator=" & CType(e.Row.FindControl("hylOperator"), HyperLink).Text
                '    CType(e.Row.FindControl("hylOperated"), HyperLink).NavigateUrl = Request.Url().ToString() & "?Operated=" & CType(e.Row.FindControl("hylOperated"), HyperLink).Text
                'End If


                If txtOperator.Text.Trim.Length <> 0 Then
                    CType(e.Row.FindControl("hylOperator"), HyperLink).Enabled = False
                Else
                    CType(e.Row.FindControl("hylOperator"), HyperLink).Enabled = True
                End If

                If txtObject.Text.Trim.Length <> 0 Then
                    CType(e.Row.FindControl("hylOperated"), HyperLink).Enabled = False
                Else
                    CType(e.Row.FindControl("hylOperated"), HyperLink).Enabled = True
                End If


        End Select

    End Sub

    Private Sub PagerControl1_PageChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles PagerControl1.PageChanged
        BindGridData(txtOperator.Text.Trim(), txtObject.Text.Trim())
    End Sub

    Private Sub PagerControl1_PageSizeChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles PagerControl1.PageSizeChanged
        PagerControl1.CurrentPage = 1
        BindGridData(txtOperator.Text.Trim(), txtObject.Text.Trim())
    End Sub

    Private Sub chkShowDetail_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkShowDetail.CheckedChanged
        gvLog.Columns(7).Visible = chkShowDetail.Checked
    End Sub


    Protected Sub gvLog_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles gvLog.RowDeleting
        Log.Delete(Convert.ToInt32(gvLog.DataKeys(e.RowIndex).Value))
        BindGridData(txtOperator.Text.Trim(), txtObject.Text.Trim())
    End Sub

    Protected Sub LinkSearch_Click(ByVal sender As Object, ByVal e As EventArgs) Handles LinkSearch.Click
        litInfo.Text = ""
        If iStartDate.Value = "undefined" Or iEndDate.Value = "undefined" Then
            litInfo.Text = "<font size=2 color=red>日期格式錯誤！</font>"
            Exit Sub
        End If

        If DateTime.Compare(DateTime.Parse(iStartDate.Value), DateTime.Parse(iEndDate.Value)) > 0 Then
            litInfo.Text = "<font size=2 color=red>結束日期不能早于開始時間！</font>"
            Exit Sub
        End If

        BindGridData(txtOperator.Text.Trim(), txtObject.Text.Trim())
    End Sub
End Class




