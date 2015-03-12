Imports Platform.eAuthorize

Partial Public Class GridPerson
    Inherits System.Web.UI.UserControl
    Public Property DisplayInfo() As String
        Get
            If ViewState("Css") Is Nothing Then
                Return "Show"
            Else
                Return ViewState("Css")
            End If
        End Get
        Set(ByVal value As String)
            ViewState("Css") = value
        End Set
    End Property
    Public Property Searchcondition() As String
        Get
            If ViewState("Searchcondition") Is Nothing Then
                Return ""
            End If
            Return ViewState("Searchcondition")
        End Get
        Set(ByVal value As String)
            ViewState("Searchcondition") = value
        End Set
    End Property
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If UserInfo.IsInRoles("QALeader") Then
            Me.GridView1.Columns(7).Visible = True
        End If
    End Sub
    Public Sub BindPerson()
        If DisplayInfo = "Show" Then
            Dim dt As DataTable = PersonTecDAL.GetDsBySearchcontition(Searchcondition)
            If Not dt Is Nothing Then
                Me.GridView1.DataSource = dt
                Me.GridView1.DataKeyNames = New String() {"PKID"}
                Me.GridView1.DataBind()
                Me.GridView1.Attributes.Add("Style", "display:inline")
            Else
                Me.GridView1.DataSource = Nothing
                Me.GridView1.DataBind()
            End If

        Else
            Me.GridView1.Attributes.Add("Style", "display:none")
        End If
    End Sub

    Protected Sub GridView1_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GridView1.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            e.Row.Attributes.Add("onmouseover", "this.style.cursor='hand';this.style.color='#FFFFFF'; currentcolor=this.style.backgroundColor;this.style.backgroundColor='#40A0FE',this.style.fontWeight='';")
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
        BindPerson()
    End Sub
End Class