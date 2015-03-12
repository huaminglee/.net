Public Partial Class GridStandardZZ
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
    Public Property ParentType() As Integer
        Get
            If ViewState("ParentType") Is Nothing Then
                Return 1
            End If
            Return CInt(ViewState("ParentType"))
        End Get
        Set(ByVal value As Integer)
            ViewState("ParentType") = value
        End Set
    End Property
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub
    Public Sub Bindzz()
        Dim parimg As Image = Me.Parent.Parent.FindControl("Image1")
        If DisplayInfo = "Show" Then
            parimg.ImageUrl = "../Images/Expand.png"
            Me.GridView1.Attributes.Add("Style", "display:inline")
            Dim dt As DataTable
            dt = StandardFileManageDAL.GetzzBysearchcondition(Searchcondition)
            Me.GridView1.DataSource = dt
            Me.GridView1.DataBind()
        ElseIf DisplayInfo = "Hid" Then
            parimg.ImageUrl = "../Images/addGrid.png"
            Me.GridView1.Attributes.Add("Style", "display:none")
        End If

    End Sub
    Protected Sub GridView1_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GridView1.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            Dim Image1 As Image = CType(e.Row.FindControl("Image1"), Image)
            Image1.Attributes.Add("onclick", "Bindfile('" + e.Row.RowIndex.ToString + "','" + Me.Button1.ClientID + "')")
        End If
    End Sub
    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button1.Click

        Dim HiddenzzRowindex As HiddenField = CType(Me.Parent.Parent.Parent.Parent.Parent.Parent.Parent.Parent.Parent.Parent.Parent.Parent.Parent.Parent.Parent.FindControl("HiddenzzRowindex"), HiddenField)
        Dim dr As GridViewRow = Me.GridView1.Rows(HiddenzzRowindex.Value)

        Dim curotherfile As GridOtherFile = CType(dr.FindControl("GridOtherFile1"), GridOtherFile)
        curotherfile.Searchcondition = Searchcondition + " and StandardOrganize='" + CType(dr.FindControl("LbZZ"), Label).Text.ToString + "'"
        curotherfile.RecordType = RecordType
        curotherfile.BindOthweFile()

        Dim Image1 As Image = CType(dr.FindControl("Image1"), Image)
        Image1.Attributes.Remove("onclick")
        Image1.Attributes.Add("onclick", "changeshow('" + curotherfile.ClientID + "_GridView1')")


    End Sub
End Class