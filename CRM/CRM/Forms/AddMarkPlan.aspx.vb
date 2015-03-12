Public Partial Class AddMarkPlan
    Inherits System.Web.UI.Page
    Private Property BussOppPKID() As Integer
        Get
            If ViewState("bussopppkid") Is Nothing Then
                Return 0
            End If
            Return CInt(ViewState("bussopppkid"))
        End Get
        Set(ByVal value As Integer)
            ViewState("bussopppkid") = value
        End Set
    End Property
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            If Not Request.QueryString("bussopppkid") Is Nothing Then
                BussOppPKID = CInt(Request.QueryString("bussopppkid"))
            End If
            BindGrid()
        End If
    End Sub
    Protected Sub BindGrid()
        Dim ds As DataSet = MarketingPlanDAL.GetAllCanAddMarketPlan(BussOppPKID)
        If Not ds Is Nothing Then
            Me.GridView1.DataSource = ds
            Me.GridView1.DataKeyNames = New String() {"pkid"}
            Me.GridView1.DataBind()
        Else
            Me.GridView1.DataSource = Nothing
            Me.GridView1.DataBind()
        End If
    End Sub

    Protected Sub BtnSave_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BtnSave.Click
        Dim checkMarkplanPKIDS As String = String.Empty
        For i As Integer = 0 To Me.GridView1.Rows.Count - 1
            Dim CheckBox1 As CheckBox = CType(GridView1.Rows(i).FindControl("CheckBox1"), CheckBox)
            If CheckBox1.Checked Then
                checkMarkplanPKIDS += Me.GridView1.DataKeys(Me.GridView1.Rows(i).RowIndex).Value.ToString + ";"
            End If
        Next
        If checkMarkplanPKIDS <> String.Empty Then
            MarkOppContactDAL.AddContactForBussopp(BussOppPKID, checkMarkplanPKIDS)
        End If
        Response.Write("<script>window.opener.upgridmark();window.close(); </script>")
    End Sub

    Protected Sub BtnCancel_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BtnCancel.Click
        Response.Write("<script>window.opener=null;window.close(); </script>")
    End Sub
End Class