Imports Platform.eAuthorize

Partial Public Class ForReportView
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Request.QueryString("pkid") Is Nothing Then
            BindReportView()
        End If

    End Sub
    Dim report As CrystalReport1
    Private Sub BindReportView()

        Dim myDS As New DataSet1()
        myDS = QuotationDAL.TransFotReport(Convert.ToInt32(Request.QueryString("pkid")))

        report = New CrystalReport1()
        report.SetDataSource(myDS)
        Dim cusinfo As CustomersInfo = CustomersDAL.GetInfoByPKID(ContactDAL.GetInfoByUserSID(UserInfo.CurrentUserID).CusTomerPKID)
        report.SetParameterValue("MyConpanyName", cusinfo.CustomerName)
        ' report.SetParameterValue("NO", "CMC432")
        report.SetParameterValue("BankNo", cusinfo.BankAccount)
        report.SetParameterValue("BankName", cusinfo.Bank)
        'report.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, "fffff.pdf")
        'report.Close()
        'report.Dispose()
        Me.CrystalReportViewer1.ReportSource = report
        Me.CrystalReportViewer1.DataBind()

    End Sub

    Private Sub ForReportView_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Unload
        report.Dispose()
    End Sub
End Class