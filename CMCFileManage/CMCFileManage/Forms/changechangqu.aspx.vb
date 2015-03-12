Public Partial Class changechangqu
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub ButtonLH_Click(ByVal sender As Object, ByVal e As EventArgs) Handles ButtonLH.Click
        Response.Cookies("changqu").Value = "LH"
        Response.Cookies("changqu").Expires = DateTime.Now.AddYears(1)
        Response.Write("<script>window.opener=null;window.close();</script>")
    End Sub

    Protected Sub ButtonGL_Click(ByVal sender As Object, ByVal e As EventArgs) Handles ButtonGL.Click
        Response.Cookies("changqu").Value = "GL"
        Response.Cookies("changqu").Expires = DateTime.Now.AddYears(1)
        Response.Write("<script>window.opener=null;window.close();</script>")
    End Sub

    Protected Sub ButtonWH_Click(ByVal sender As Object, ByVal e As EventArgs) Handles ButtonWH.Click
        Response.Cookies("changqu").Value = "WH"
        Response.Cookies("changqu").Expires = DateTime.Now.AddYears(1)
        Response.Write("<script>window.opener=null;window.close();</script>")
    End Sub

    Protected Sub ButtonYT_Click(ByVal sender As Object, ByVal e As EventArgs) Handles ButtonYT.Click
        Response.Cookies("changqu").Value = "YT"
        Response.Cookies("changqu").Expires = DateTime.Now.AddYears(1)
        Response.Write("<script>window.opener=null;window.close();</script>")
    End Sub

    Protected Sub ButtonWSJ_Click(ByVal sender As Object, ByVal e As EventArgs) Handles ButtonWSJ.Click
        Response.Cookies("changqu").Value = "WSJ"
        Response.Cookies("changqu").Expires = DateTime.Now.AddYears(1)
        Response.Write("<script>window.opener=null;window.close();</script>")
    End Sub

    Protected Sub ButtonCQ_Click(ByVal sender As Object, ByVal e As EventArgs) Handles ButtonCQ.Click
        Response.Cookies("changqu").Value = "CQ"
        Response.Cookies("changqu").Expires = DateTime.Now.AddYears(1)
        Response.Write("<script>window.opener=null;window.close();</script>")
    End Sub

    Protected Sub ButtonCD_Click(ByVal sender As Object, ByVal e As EventArgs) Handles ButtonCD.Click
        Response.Cookies("changqu").Value = "CD"
        Response.Cookies("changqu").Expires = DateTime.Now.AddYears(1)
        Response.Write("<script>window.opener=null;window.close();</script>")
    End Sub

    Protected Sub ButtonZZ_Click(ByVal sender As Object, ByVal e As EventArgs) Handles ButtonZZ.Click
        Response.Cookies("changqu").Value = "ZZ"
        Response.Cookies("changqu").Expires = DateTime.Now.AddYears(1)
        Response.Write("<script>window.opener=null;window.close();</script>")
    End Sub
End Class