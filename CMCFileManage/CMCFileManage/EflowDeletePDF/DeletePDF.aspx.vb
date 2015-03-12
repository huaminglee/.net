Public Partial Class DeletePDF
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim path As IO.DirectoryInfo = New System.IO.DirectoryInfo(Server.MapPath("../TempUploadFiles"))
        For Each f As System.IO.FileInfo In path.GetFiles()
            If f.Name.ToLower.IndexOf(".pdf") > -1 Then
                f.Delete()
            End If
        Next
    End Sub

End Class