Imports Platform.eAuthorize
Partial Public Class UCtlMenu
    Inherits System.Web.UI.UserControl
#Region "Property"
    ''' <summary>
    ''' Treeview的數據源
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property DataSource() As DataSet
        Get
            If ViewState("DataSource") Is Nothing Then
                ViewState("DataSource") = New DataSet
            End If
            Return ViewState("DataSource")
        End Get
        Set(ByVal value As DataSet)
            ViewState("DataSource") = value
        End Set
    End Property
#End Region
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            grd_BD()
            Ctl_BD()
        End If

    End Sub

    Sub grd_BD()

        If DataSource.Tables.Count > 0 Then
            Dim dt As DataTable = DataSource.Tables(0)
            For i As Integer = 0 To dt.Rows.Count - 1
                Dim dr As DataRow = dt.Rows(i)
                If dr("ParentID").ToString = "0" Then
                    Dim RootNode As MenuItem = New MenuItem(dr("NodeText").ToString, dr("NodeID").ToString)
                    If dr.IsNull("NavigateURL") Or dr("NavigateURL") <> "" Then
                        RootNode.Selectable = True
                        RootNode.NavigateUrl = dr("NavigateURL").ToString
                    Else
                        RootNode.Selectable = False
                    End If
                    Dim num As Integer = Integer.Parse(dr("NodeValue"))
                    If num > Menu1.Items.Count Then
                        num = Menu1.Items.Count
                    End If
                    Menu1.Items.AddAt(num, RootNode)
                End If
            Next
            For i As Integer = 0 To dt.Rows.Count - 1
                Dim dr As DataRow = dt.Rows(i)
                If dr("ParentID").ToString <> "0" Then
                    For Each node As MenuItem In Menu1.Items
                        If dr("ParentID").ToString = node.Value Then
                            Dim RootNode As MenuItem = New MenuItem(dr("NodeText").ToString, dr("NodeID").ToString)
                            ' RootNode.ImageUrl = "..\Image\TreeView\152.gif"

                            RootNode.NavigateUrl = dr("NavigateURL").ToString
                            Dim num As Integer = Integer.Parse(dr("NodeValue"))
                            If num > node.ChildItems.Count Then
                                num = node.ChildItems.Count
                            End If
                            node.ChildItems.AddAt(num, RootNode)
                        End If
                    Next
                End If
            Next

        End If
    End Sub
    Sub Ctl_BD()
        If HttpContext.Current.Request.IsAuthenticated Then

            Me.LabName.Text = "歡迎你，" + UserInfo.CurrentUserCHName
            LnkLogIO.Text = "註銷"
            Lnk.Text = "個人信息"
        Else
            Me.LabName.Text = "匿名用戶"
            LnkLogIO.Text = "登錄"
        End If
    End Sub
    Protected Sub LnkLogIO_Click(ByVal sender As Object, ByVal e As EventArgs) Handles LnkLogIO.Click
        FormsAuthentication.SignOut()
        Response.Redirect("Login.aspx")
    End Sub
End Class