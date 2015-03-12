Public Partial Class UCtlGrdPage
    Inherits System.Web.UI.UserControl
#Region "Property"
    ''' <summary>
    ''' gridview的ID,默認GridView1
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property GrdID() As String
        Get
            If ViewState("GrdID") = Nothing Then
                Return "GridView1"
            Else
                Return ViewState("GrdID")
            End If

        End Get
        Set(ByVal value As String)
            ViewState("GrdID") = value
        End Set
    End Property

    ReadOnly Property GrdView() As GridView
        Get
            If Me.Page.Controls.Count = 1 Then
                Return CType(Me.Page.Master.FindControl("Form1").FindControl("ContentPlaceHolder1").FindControl(GrdID), GridView)

            Else
                Return CType(Me.Page.FindControl(GrdID), GridView)
            End If
        End Get
    End Property
    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' 當前頁的索引
    ''' </summary>
    ''' <value></value>
    ''' <remarks>
    ''' </remarks>
    ''' -----------------------------------------------------------------------------

    Private Property PageIndex() As Integer
        Get
            Return Me.PagerControl1.CurrentPage - 1
        End Get
        Set(ByVal Value As Integer)
            Me.PagerControl1.CurrentPage = Value + 1
        End Set
    End Property

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' 當前頁的行
    ''' </summary>
    ''' <value></value>
    ''' <remarks>
    ''' </remarks>
    ''' -----------------------------------------------------------------------------
    Private Property PageSize() As Integer
        Get
            Return Me.PagerControl1.RecordsPerPage
        End Get
        Set(ByVal Value As Integer)
            Me.PagerControl1.RecordsPerPage = Value
        End Set
    End Property
    ''' <summary>
    ''' 數據源，如果Grd為默認ID，則只需要設定數據源
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property DataSource() As Object
        Get     
            Return ViewState("DS")
        End Get
        Set(ByVal value As Object)
            ViewState("DS") = value
        End Set
    End Property

#End Region

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            If Not DataSource Is Nothing Then
                Grd_BD()
            End If
        End If
    End Sub

    Private Sub PagerControl1_PageChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles PagerControl1.PageChanged
        Grd_BD()
    End Sub

    Private Sub PagerControl1_PageSizeChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles PagerControl1.PageSizeChanged
        Grd_BD()
    End Sub

    Public Sub Grd_BD()
        GrdView.AllowPaging = True
        GrdView.PagerSettings.Visible = False
        If DataSource.ToString.Contains("Table") Then
            PagerControl1.TotalRecords = CType(DataSource, DataTable).Rows.Count
        Else
            PagerControl1.TotalRecords = DataSource.Count
        End If

        GrdView.PageSize = PageSize
        GrdView.PageIndex = PageIndex
        GrdView.DataSource = DataSource
        GrdView.DataBind()
    End Sub
End Class