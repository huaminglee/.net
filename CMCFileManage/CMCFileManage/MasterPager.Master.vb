Public Partial Class MasterPager
    Inherits System.Web.UI.MasterPage

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            HttpContext.Current.Request.ToString()
            If HttpContext.Current.User.Identity.IsAuthenticated Then
                ''根據權限綁定TreeView''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                Contrl_BD()
            Else

            End If
        End If
    End Sub
    ''' <summary>
    ''' 根據權限綁定TreeView
    ''' </summary>
    ''' <remarks></remarks>
    Sub Contrl_BD()
  
        ' UCtlMenu1.DataSource = OperationTree.GetInfosBySearchCondition("")

    End Sub

End Class