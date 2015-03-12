Public Partial Class GridQyext
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
    Public Sub BindQu()
        Dim parimg As Image = Me.Parent.Parent.FindControl("Image2")
        If DisplayInfo = "Show" Then
            parimg.ImageUrl = "../Images/Expand.png"
            Me.GridView1.Attributes.Add("Style", "display:inline")
            Dim dt As DataTable
            If ParentType = 1 Then    '偏差報告
                dt = ErrorReportDAL.GetQyBySearchcondition(Searchcondition)
            ElseIf ParentType = 2 Then   '關鍵物品
                dt = ImportantGoodsDAL.GetQyBySearchcondition(Searchcondition)
            End If

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
            Dim LbQy As Label = CType(e.Row.FindControl("LbQy"), Label)

            Image1.Attributes.Add("onclick", "BindoutFile('" + e.Row.RowIndex.ToString + "','" + Me.Button1.ClientID + "')")
        End If
    End Sub
    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button1.Click
        Dim HiddenQyRowindex As HiddenField = CType(Me.Parent.Parent.Parent.Parent.Parent.FindControl("HiddenQyRowindex"), HiddenField)
        Dim dr As GridViewRow = Me.GridView1.Rows(HiddenQyRowindex.Value)
        If ParentType = 1 Then
            Dim curgridoutfile As GridErropreport = CType(dr.FindControl("GridErropreport1"), GridErropreport)
            curgridoutfile.Searchcondition = Searchcondition + " and Qulocation='" + CType(dr.FindControl("LbQy"), Label).Text.ToString + "'"
            curgridoutfile.RecordType = RecordType
            curgridoutfile.Binderrorreport()
            Dim Image1 As Image = CType(dr.FindControl("Image1"), Image)
            Image1.Attributes.Remove("onclick")
            Image1.Attributes.Add("onclick", "qychangeshow('" + Parentindex.ToString + "','" + HiddenQyRowindex.Value.ToString + "','" + curgridoutfile.ClientID + "_GridView1')")
        ElseIf ParentType = 2 Then
            Dim curgridoutfile As GridImportant = CType(dr.FindControl("GridImportant1"), GridImportant)
            curgridoutfile.Searchcondition = Searchcondition + " and Qulocation='" + CType(dr.FindControl("LbQy"), Label).Text.ToString + "'"
            curgridoutfile.RecordType = RecordType
            curgridoutfile.BinImportant()
            Dim Image1 As Image = CType(dr.FindControl("Image1"), Image)
            Image1.Attributes.Remove("onclick")
            Image1.Attributes.Add("onclick", "qychangeshow('" + Parentindex.ToString + "','" + HiddenQyRowindex.Value.ToString + "','" + curgridoutfile.ClientID + "_GridView1')")

        End If

    End Sub
End Class