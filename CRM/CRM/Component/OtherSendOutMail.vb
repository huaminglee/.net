Public Class OtherSendOutMail
    Public Shared Sub SendOutMail(ByVal MailAddress As String, ByVal subject As String, ByVal content As String, ByVal cc As String)
        Dim sMail As New ECMC.Sendoutmail.WebService()
        sMail.OtherQYSendOutMail(MailAddress, subject, content, cc)
    End Sub
End Class
