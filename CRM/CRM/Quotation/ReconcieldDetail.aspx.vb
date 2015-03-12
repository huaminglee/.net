Public Partial Class ReconcieldDetail
    Inherits System.Web.UI.Page
    Private Property CustomerPKID() As Integer
        Get
            If ViewState("CustomerPKID") Is Nothing Then
                Return 0
            Else
                Return Convert.ToInt32(ViewState("CustomerPKID"))
            End If
        End Get
        Set(ByVal value As Integer)
            ViewState("CustomerPKID") = value
        End Set
    End Property
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            If Not Request.QueryString("CustomerPKID") Is Nothing Then
                CustomerPKID = Convert.ToInt32(Request.QueryString("CustomerPKID"))
            End If
        End If
    End Sub

    Protected Sub BtnGetReconcield_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BtnGetReconcield.Click

        Dim ds As DataSet = SqlHelper.ExecuteDataset(ConfigurationInfo.ConnectionString, "GetReconcieldByCustomerPKIDandDate", 124, "2013-6-1", "2013-7-1")
        Dim dt As DataTable = ds.Tables(0)
        Dim mergeCellNums As Dictionary(Of Integer, Integer) = New Dictionary(Of Integer, Integer)
        For i As Integer = 0 To dt.Columns.Count - 1
            mergeCellNums.Add(i, 1)
        Next
        Dim header As TableCell() = New TableCell(1) {}
        For i As Integer = 0 To header.Length - 1
            header(i) = New TableCell()
        Next
        header(0).ColumnSpan = 10
        header(0).Text = "對帳單"

      

    End Sub
End Class