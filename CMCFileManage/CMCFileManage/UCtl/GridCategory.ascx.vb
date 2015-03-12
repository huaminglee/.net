Public Partial Class GridCategory
    Inherits System.Web.UI.UserControl
    Public Property DisplayInfo() As String
        Get
            If ViewState("Css") Is Nothing Then
                Return "Show"
            Else
                Return ViewState("Css")
            End If
        End Get
        Set(ByVal value As String)
            ViewState("Css") = value
        End Set
    End Property
    Public Property RecordType() As Integer
        Get
            If ViewState("RecordType") Is Nothing Then
                Return 0
            End If
            Return CInt(ViewState("RecordType"))
        End Get
        Set(ByVal value As Integer)
            ViewState("RecordType") = value
        End Set
    End Property
    Public Property Parentindex() As Integer
        Get
            If ViewState("Parentindex") Is Nothing Then
                Return 0
            End If
            Return CInt(ViewState("Parentindex"))
        End Get
        Set(ByVal value As Integer)
            ViewState("Parentindex") = value
        End Set
    End Property
    Public Property DeptName() As String
        Get
            If ViewState("DeptName") Is Nothing Then
                Return ""
            End If
            Return ViewState("DeptName")
        End Get
        Set(ByVal value As String)
            ViewState("DeptName") = value
        End Set
    End Property
    Public Property Searchcondition() As String
        Get
            If ViewState("Searchcondition") Is Nothing Then
                Return ""
            End If
            Return ViewState("Searchcondition")
        End Get
        Set(ByVal value As String)
            ViewState("Searchcondition") = value
        End Set
    End Property
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub
    Public Sub BindCategoryGrid()
        Dim parimg As Image = Me.Parent.Parent.FindControl("Image2")
        If DisplayInfo = "Show" Then
            parimg.ImageUrl = "../Images/Expand.png"
            Me.GridView1.Attributes.Add("Style", "display:inline")
            Dim dt As DataTable = QC_FileInfoDAL.GetFilecategoryBySearchcondition(Searchcondition)
            If Not dt Is Nothing Then
                Me.GridView1.DataSource = dt
                Me.GridView1.DataBind()
            Else
                Me.GridView1.DataSource = Nothing
                Me.GridView1.DataBind()
            End If
        ElseIf DisplayInfo = "Hid" Then
            parimg.ImageUrl = "../Images/addGrid.png"
            Me.GridView1.Attributes.Add("Style", "display:none")
        End If

    End Sub

    Protected Sub GridView1_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GridView1.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            Dim Image1 As Image = CType(e.Row.FindControl("Image1"), Image)
            Dim LbCategory As Label = CType(e.Row.FindControl("LbCategory"), Label)

            Image1.Attributes.Add("onclick", "BindFile('" + LbCategory.Text + "','" + e.Row.RowIndex.ToString + "','" + Me.Button1.ClientID + "')")
        End If
    End Sub

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button1.Click
        Dim HiddenCategoryRowindex As HiddenField = CType(Me.Parent.Parent.Parent.Parent.Parent.FindControl("HiddenCategoryRowindex"), HiddenField)
        Dim dr As GridViewRow = Me.GridView1.Rows(HiddenCategoryRowindex.Value)
        Dim GridFile1 As GridFile = CType(dr.FindControl("GridFile1"), GridFile)
        GridFile1.FileCategory = CType(dr.FindControl("LbCategory"), Label).Text
        GridFile1.DeptName = DeptName
        GridFile1.RecordType = RecordType
        GridFile1.Searchcondition = Searchcondition + " and FileCategory='" + CType(dr.FindControl("LbCategory"), Label).Text.ToString + "'"
        GridFile1.ParentType = 2
        GridFile1.BindFile()
        Dim Image1 As Image = CType(dr.FindControl("Image1"), Image)
        Image1.Attributes.Remove("onclick")
        Image1.Attributes.Add("onclick", "categorychangeshow('" + Parentindex.ToString + "','" + HiddenCategoryRowindex.Value.ToString + "','" + GridFile1.ClientID + "_GridView1')")

    End Sub
End Class