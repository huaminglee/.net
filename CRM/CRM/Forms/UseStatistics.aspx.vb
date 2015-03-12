Public Partial Class UseStatistics
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            Me.Txtbegintime.Attributes.Add("readonly", True)
            Me.Txtbegintime.Attributes.Add("onclick", "javascript:WdatePicker({startDate:'%y-%M-01',dateFmt:'yyyy-MM-dd'});")

            Me.Txtendtime.Attributes.Add("readonly", True)
            Me.Txtendtime.Attributes.Add("onclick", "javascript:WdatePicker({startDate:'%y-%M-01',dateFmt:'yyyy-MM-dd'});")
            Me.Txtbegintime.Text = DateTime.Now.Year.ToString + "-" + DateTime.Now.Month.ToString + "-" + "1"
            Me.Txtendtime.Text = DateTime.Now.ToShortDateString
            Me.Button1.OnClientClick = "btnnosee()"
        End If
    End Sub

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button1.Click
        Dim ds As DataSet = SqlHelper.ExecuteDataset(ConfigurationInfo.ConnectionString, "WF_LoadAllQyuse", CDate(Me.Txtbegintime.Text), CDate(Me.Txtendtime.Text))
        Me.GridView1.DataSource = ds
        Me.GridView1.DataBind()
    End Sub
End Class