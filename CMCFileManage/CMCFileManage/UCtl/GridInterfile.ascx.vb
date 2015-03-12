Imports Platform.eAuthorize

Partial Public Class GridInterfile
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
    Public Property RecordType() As Integer
        Get
            If ViewState("RecordType") Is Nothing Then
                Return 0
            End If
            Return CInt(ViewState("RecordType"))
        End Get
        Set(ByVal value As Integer)
            ViewState("RecordType") = value
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
            Me.GridView1.Columns(4).Visible = True
        End If
    End Sub
    Public Sub BindInelFile()

        If DisplayInfo = "Show" Then

            Dim dt As DataTable = InternalAuditPlanandReportDAL.GetInelFileBySearchcondition(Searchcondition)
            Me.GridView1.DataSource = dt
            Me.GridView1.DataKeyNames = New String() {"PKID"}
            Me.GridView1.DataBind()
            Me.GridView1.Attributes.Add("Style", "display:inline")
        ElseIf DisplayInfo = "Hid" Then

            Me.GridView1.Attributes.Add("Style", "display:none")
        End If
    End Sub
    Protected Sub GridView1_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GridView1.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            e.Row.Attributes.Add("onmouseover", "this.style.cursor='hand';this.style.color='#FFFFFF'; currentcolor=this.style.backgroundColor;this.style.backgroundColor='#40A0FE',this.style.fontWeight='';")
            e.Row.Attributes.Add("onmouseout", "this.style.color='#1e5494'; this.style.backgroundColor=currentcolor,this.style.fontWeight='';")
            If e.Row.RowState = DataControlRowState.Alternate OrElse e.Row.RowState = DataControlRowState.Normal Then
                Dim pkid As Integer = CType(e.Row.FindControl("LblPKID"), Label).Text

                Dim HLDetail As HyperLink = CType(e.Row.FindControl("HLDetail"), HyperLink)
                Dim returnurl As String = "../Forms/InternalAuditDetail.aspx?pkid=" + pkid.ToString + "&Type=" + RecordType.ToString
                HLDetail.NavigateUrl = returnurl

                e.Row.Attributes.Add("onclick", "window.location.href='" + returnurl + "';")
                Dim BtnCancel As ImageButton = TryCast(e.Row.FindControl("BtnDelete"), ImageButton)
                BtnCancel.Attributes.Add("onclick", " return confirm('確定要刪除該記錄嗎?');")
               

            End If
        End If

    End Sub
    Protected Sub GridView1_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles GridView1.RowDeleting
        Dim mpkid As Integer = Convert.ToInt32(GridView1.DataKeys(e.RowIndex).Value)
        InternalAuditPlanandReportDAL.Delete(mpkid)
        Dim newdeletelog As DeleteLogInfo = New DeleteLogInfo()
        newdeletelog.pkid = 0
        newdeletelog.Parentid = mpkid
        newdeletelog.parenttype = "內審"
        newdeletelog.DeleteUserName = UserInfo.CurrentUserCHName
        newdeletelog.DeleteUserSID = UserInfo.CurrentUserID
        newdeletelog.RecordCreated = DateTime.Now
        Dim newdeletedal As DeleteLogDAL = New DeleteLogDAL(newdeletelog)
        newdeletedal.Save()
        BindInelFile()
    End Sub
End Class