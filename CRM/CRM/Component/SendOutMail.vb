Public Class SendOutMail
    Public Shared Sub SendMail(ByVal MailAddress As String, ByVal subject As String, ByVal content As String, ByVal cc As String)
        Dim sMail As New com.foxconn.cmc.SendMail()
        sMail.MailSend(MailAddress, subject, content, cc)
    End Sub
End Class
