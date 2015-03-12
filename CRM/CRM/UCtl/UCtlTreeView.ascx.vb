Imports Platform.eAuthorize
Partial Public Class UCtlTreeView
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
            TView_BD()
        End If
    End Sub
    Sub TView_BD()

        If DataSource.Tables.Count > 0 Then

            Dim dv() As DataRow = New DataRow() {}
            Dim dt As DataTable = DataSource.Tables(0)
           



            For i As Integer = 0 To dv.Length - 1
                Dim dr As DataRow = dv(i)
                If dr("ParentID").ToString = "0" Then
                    Dim RootNode As TreeNode = New TreeNode(dr("NodeText").ToString, dr("NodeID").ToString)
                    Dim num As Integer = Integer.Parse(dr("NodeValue"))
                    RootNode.SelectAction = TreeNodeSelectAction.Expand
                    If num > TreeView1.Nodes.Count Then
                        num = TreeView1.Nodes.Count
                    End If
                    TreeView1.Nodes.AddAt(num, RootNode)
                End If
            Next
            For i As Integer = 0 To dv.Length - 1
                Dim dr As DataRow = dv(i)
                If dr("ParentID").ToString <> "0" Then
                    For Each node As TreeNode In TreeView1.Nodes
                        If dr("ParentID").ToString = node.Value Then

                            Dim StrUrl As String = dr("NavigateURL").ToString
                            Dim RootNode As TreeNode = New TreeNode(dr("NodeText").ToString, StrUrl)
                            Dim num As Integer = Integer.Parse(dr("NodeValue"))
                            RootNode.ImageUrl = "..\Image\TreeView\152.gif"
                            '  RootNode.SelectAction = TreeNodeSelectAction.Select
                            RootNode.NavigateUrl = StrUrl
                            If num > node.ChildNodes.Count Then
                                num = node.ChildNodes.Count
                            End If

                            If GetUrlPath(StrUrl) = GetUrlPath(HttpContext.Current.Request.Url.PathAndQuery) Then
                                RootNode.Selected = True
                            End If
                            node.ChildNodes.AddAt(num, RootNode)
                        End If
                    Next
                End If
            Next
        End If

    End Sub
    ''' <summary>
    ''' 通過對比當前url與Treeview中的url確定被選中節點
    ''' </summary>
    ''' <param name="url"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Function GetUrlPath(ByVal url As String) As String
        Dim urlAb As String
        If url.ToString.Contains("?") Then
            Dim str() As String = url.Split("?")
            urlAb = Server.MapPath(str(0)) + "?" + str(1)
        Else
            urlAb = Server.MapPath(url)
        End If
        Return urlAb
    End Function

End Class