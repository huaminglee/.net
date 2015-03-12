Partial Public Class ErrorPage
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Me.IsPostBack Then
            'CType(Me.Master.FindControl("imgMT"), HtmlImage).Visible = False
            Dim ErrorString As String = Global_asax._strerrormessage
            If ErrorString <> String.Empty Then
                Me.LblErrorMessage.Text = ErrorString
            Else
                If Server.GetLastError IsNot Nothing Then
                    Me.LblErrorMessage.Text = HttpContext.Current.Server.GetLastError.Message
                End If

            End If
            Me.HyperLink1.NavigateUrl = "Default.aspx"
            If (Not Request.UrlReferrer Is Nothing) AndAlso (Request.UrlReferrer.ToString <> String.Empty) Then
                Me.HyperLink2.NavigateUrl = Request.UrlReferrer.ToString()
            Else
                Me.HyperLink2.NavigateUrl = "Default.aspx"
            End If
        End If

        Page.Title = "發生錯誤!"
    End Sub

End Class