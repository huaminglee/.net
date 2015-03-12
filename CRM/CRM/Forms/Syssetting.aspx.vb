Imports System.Xml

Partial Public Class Syssetting
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            Dim doc As XmlDocument = New XmlDocument()
            Dim xmlPath As String = ""
            Dim genpath As String = Server.MapPath("~")
            xmlPath = genpath + "\XMLData\SysSetting.xml"
            doc.Load(xmlPath)
            Dim nodeList As XmlNodeList = doc.SelectSingleNode("Dataset").ChildNodes
            For Each xn As XmlNode In nodeList
                Select Case xn.Name
                    Case "Complaininfo"
                        Dim DH As String = xn.ChildNodes.ItemOf(0).InnerText
                        Dim QH As String = xn.ChildNodes.ItemOf(1).InnerText
                        Me.TxtDH.Text = DH
                        Me.TxtQH.Text = QH
                   
                End Select
            Next
            BindRemark()
            BindGrid()
        End If

    End Sub

    Protected Sub BtnSave_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BtnSave.Click
        Dim doc As XmlDocument = New XmlDocument()
        Dim xmlPath As String = ""
        xmlPath = Server.MapPath("~") + "\XMLData\SysSetting.xml"
        doc.Load(xmlPath)
        Dim nodeList As XmlNodeList = doc.SelectSingleNode("Dataset").ChildNodes
        For Each xn As XmlNode In nodeList
            Select Case xn.Name
                Case "Complaininfo"
                    xn.ChildNodes.ItemOf(0).InnerText = Me.TxtDH.Text
                    xn.ChildNodes.ItemOf(1).InnerText = Me.TxtQH.Text
            End Select
        Next
        doc.Save(xmlPath)
    End Sub

    Protected Sub BindGrid()
        Dim ds As DataSet = SqlHelper.ExecuteDataset(ConfigurationInfo.ConnectionString, "Discount_GetInfoBySearchCondition", "")
        If Not ds Is Nothing Then
            Me.GridView1.DataSource = ds
            Me.GridView1.DataKeyNames = New String() {"PKID"}
            Me.GridView1.DataBind()
        Else
            Me.GridView1.DataSource = Nothing
            Me.GridView1.DataBind()
        End If
    End Sub
    Protected Sub GridView1_RowUpdating(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewUpdateEventArgs) Handles GridView1.RowUpdating
        Dim mpkid As Integer = Me.GridView1.DataKeys(e.RowIndex).Value
        Dim disinfo As DiscountInfo = DiscountDAL.GetInfoByPKID(mpkid)
        disinfo.One = CType(Me.GridView1.Rows(e.RowIndex).Cells(1).Controls(0), TextBox).Text.Trim()
        disinfo.Two = CType(Me.GridView1.Rows(e.RowIndex).Cells(2).Controls(0), TextBox).Text.Trim()
        disinfo.Three = CType(Me.GridView1.Rows(e.RowIndex).Cells(3).Controls(0), TextBox).Text.Trim()
        disinfo.Four = CType(Me.GridView1.Rows(e.RowIndex).Cells(4).Controls(0), TextBox).Text.Trim()
        disinfo.Five = CType(Me.GridView1.Rows(e.RowIndex).Cells(5).Controls(0), TextBox).Text.Trim()

        Dim disdal As DiscountDAL = New DiscountDAL(disinfo)
        disdal.Save()
        Me.GridView1.EditIndex = -1
        BindGrid()

    End Sub

    Protected Sub GridView1_RowEditing(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewEditEventArgs) Handles GridView1.RowEditing
        Me.GridView1.EditIndex = e.NewEditIndex
        BindGrid()
    End Sub

    Protected Sub GridView1_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GridView1.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            Dim LbRole As Label = CType(e.Row.FindControl("LbRole"), Label)
            Dim LbJuese As Label = CType(e.Row.FindControl("LbJuese"), Label)
            Select Case LbRole.Text
                Case "Zhongxinzhuguan"
                    LbJuese.Text = "中心主管"
                Case "Yewuzhuguan"
                    LbJuese.Text = "業務主管"
                Case "EXTERNALWORKER"
                    LbJuese.Text = "業務員"
                Case "TEDINGSHENHE"
                    LbJuese.Text = "授權主管"
            End Select
        End If
    End Sub

    Protected Sub GridView1_RowCancelingEdit(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCancelEditEventArgs) Handles GridView1.RowCancelingEdit
        Me.GridView1.EditIndex = -1
        BindGrid()
    End Sub
    Private Sub BindRemark()
        Dim doc As XmlDocument = New XmlDocument()
        Dim xmlPath As String = ""
        Dim genpath As String = Server.MapPath("~")
        xmlPath = genpath + "\XMLData\CusLevelRemark.xml"
        doc.Load(xmlPath)
        Dim nodeList As XmlNodeList = doc.SelectSingleNode("Dataset").ChildNodes
        For Each xn As XmlNode In nodeList
            Select Case xn.Name
                Case "LevelRemark"
                    Dim OneRemark As String = xn.ChildNodes.ItemOf(0).InnerText
                    Dim TwoRemark As String = xn.ChildNodes.ItemOf(1).InnerText
                    Dim ThreeRemark As String = xn.ChildNodes.ItemOf(2).InnerText
                    Dim FourRemark As String = xn.ChildNodes.ItemOf(3).InnerText
                    Dim FiveRemark As String = xn.ChildNodes.ItemOf(4).InnerText
                    Me.TxtCusOne.Text = OneRemark
                    Me.TxtCusTwo.Text = TwoRemark
                    Me.TxtCusThree.Text = ThreeRemark
                    Me.TxtCusFour.Text = FourRemark
                    Me.TxtCusFive.Text = FiveRemark
            End Select
        Next
    End Sub

    Protected Sub BtnSaveRemark_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BtnSaveRemark.Click
        Dim doc As XmlDocument = New XmlDocument()
        Dim xmlPath As String = ""
        Dim genpath As String = Server.MapPath("~")
        xmlPath = genpath + "\XMLData\CusLevelRemark.xml"
        doc.Load(xmlPath)
        Dim nodeList As XmlNodeList = doc.SelectSingleNode("Dataset").ChildNodes
        For Each xn As XmlNode In nodeList
            Select Case xn.Name
                Case "LevelRemark"
                    If Not Me.TxtCusFive.Text.Trim = String.Empty Then
                        xn.ChildNodes.ItemOf(4).InnerText = Me.TxtCusFive.Text
                    End If
                    If Not Me.TxtCusFour.Text.Trim = String.Empty Then
                        xn.ChildNodes.ItemOf(3).InnerText = Me.TxtCusFour.Text
                    End If
                    If Not Me.TxtCusOne.Text.Trim = String.Empty Then
                        xn.ChildNodes.ItemOf(0).InnerText = Me.TxtCusOne.Text
                    End If
                    If Not Me.TxtCusThree.Text.Trim = String.Empty Then
                        xn.ChildNodes.ItemOf(2).InnerText = Me.TxtCusThree.Text
                    End If
                    If Not Me.TxtCusTwo.Text.Trim = String.Empty Then
                        xn.ChildNodes.ItemOf(1).InnerText = Me.TxtCusTwo.Text
                    End If
            End Select
        Next
        doc.Save(xmlPath)
    End Sub
End Class