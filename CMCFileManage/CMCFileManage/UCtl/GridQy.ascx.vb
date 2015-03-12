Public Partial Class GridQy
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
            If ParentType = 2 Then    '標準
                dt = StandardFileManageDAL.GetQyBysearchcondition(Searchcondition)
            ElseIf ParentType = 3 Then   '設備清單
                dt = EquipManageDAL.GetQyBySearchcondition(Searchcondition)
            ElseIf ParentType = 4 Then    '設備附件
                dt = EquipFileDAL.GetQyBySearchcondition(Searchcondition)

            Else     '其他文件
                dt = OutFileManageDAL.GetQuBySearchcondition(Searchcondition)
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
            Dim curgridoutfile As GridOutFile = CType(dr.FindControl("GridOutFile1"), GridOutFile)
            curgridoutfile.Searchcondition = Searchcondition + " and QyLocation='" + CType(dr.FindControl("LbQy"), Label).Text.ToString + "'"
            curgridoutfile.RecordType = RecordType
            curgridoutfile.BinOutFile()
            Dim Image1 As Image = CType(dr.FindControl("Image1"), Image)
            Image1.Attributes.Remove("onclick")
            Image1.Attributes.Add("onclick", "qychangeshow('" + Parentindex.ToString + "','" + HiddenQyRowindex.Value.ToString + "','" + curgridoutfile.ClientID + "_GridView1')")
        ElseIf ParentType = 2 Then
            'Dim curotherfile As GridOtherFile = CType(dr.FindControl("GridOtherFile1"), GridOtherFile)
            'curotherfile.Searchcondition = Searchcondition + " and QyLocation='" + CType(dr.FindControl("LbQy"), Label).Text.ToString + "'"
            'curotherfile.RecordType = RecordType
            'curotherfile.BindOthweFile()
            'Dim Image1 As Image = CType(dr.FindControl("Image1"), Image)
            'Image1.Attributes.Remove("onclick")
            'Image1.Attributes.Add("onclick", "qychangeshow('" + Parentindex.ToString + "','" + HiddenQyRowindex.Value.ToString + "','" + curotherfile.ClientID + "_GridView1')")
            Dim GridStandartZT1 As GridStandartZT = CType(dr.FindControl("GridStandartZT1"), GridStandartZT)
            GridStandartZT1.Searchcondition = Searchcondition + " and QyLocation='" + CType(dr.FindControl("LbQy"), Label).Text.ToString + "'"
            GridStandartZT1.RecordType = RecordType
            GridStandartZT1.Bindzt()
            Dim Image1 As Image = CType(dr.FindControl("Image1"), Image)
            Image1.Attributes.Remove("onclick")
            Image1.Attributes.Add("onclick", "changeshow('" + GridStandartZT1.ClientID + "_GridView1')")

        ElseIf ParentType = 3 Then
            Dim curequip As GridEquip = CType(dr.FindControl("GridEquip1"), GridEquip)
            curequip.Searchcondition = Searchcondition + " and QyLocation='" + CType(dr.FindControl("LbQy"), Label).Text.ToString + "'"
            curequip.RecordType = RecordType
            curequip.BindEquip()
            Dim Image1 As Image = CType(dr.FindControl("Image1"), Image)
            Image1.Attributes.Remove("onclick")
            Image1.Attributes.Add("onclick", "qychangeshow('" + Parentindex.ToString + "','" + HiddenQyRowindex.Value.ToString + "','" + curequip.ClientID + "_GridView1')")
        ElseIf ParentType = 4 Then
            Dim curequipfile As GridEquipFile = CType(dr.FindControl("GridEquipFile1"), GridEquipFile)
            curequipfile.Searchcondition = Searchcondition + " and QyLocation='" + CType(dr.FindControl("LbQy"), Label).Text.ToString + "'"
            curequipfile.RecordType = RecordType
            curequipfile.BindEquipFile()
            Dim Image1 As Image = CType(dr.FindControl("Image1"), Image)
            Image1.Attributes.Remove("onclick")
            Image1.Attributes.Add("onclick", "qychangeshow('" + Parentindex.ToString + "','" + HiddenQyRowindex.Value.ToString + "','" + curequipfile.ClientID + "_GridView1')")

        End If

    End Sub
End Class