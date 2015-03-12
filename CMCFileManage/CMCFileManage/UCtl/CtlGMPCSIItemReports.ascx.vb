Imports System.Text
Imports System.Math
Imports CommonData.BusinessLayer
Public Class CtlGMPCSIItemReports
    Inherits System.Web.UI.UserControl

#Region " Web Form 設計工具產生的程式碼 "

    '此為 Web Form 設計工具所需的呼叫。
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents Datagrid1 As System.Web.UI.WebControls.DataGrid
    Protected WithEvents GridDiv As System.Web.UI.HtmlControls.HtmlGenericControl
    Protected WithEvents Datagrid2 As System.Web.UI.WebControls.DataGrid
    Protected WithEvents DataGrid3 As System.Web.UI.WebControls.DataGrid
    Protected WithEvents Datalist1 As System.Web.UI.WebControls.DataList
    Protected WithEvents Datalist2 As System.Web.UI.WebControls.DataList
    Protected WithEvents Label2 As System.Web.UI.WebControls.Label
    Protected WithEvents Datagrid4 As System.Web.UI.WebControls.DataGrid
    Protected WithEvents ImgXls As System.Web.UI.WebControls.Image
    Protected WithEvents LinkReport As System.Web.UI.WebControls.LinkButton
    Protected WithEvents Image1 As System.Web.UI.WebControls.Image
    Protected WithEvents Linkbutton1 As System.Web.UI.WebControls.LinkButton
    Protected WithEvents Image2 As System.Web.UI.WebControls.Image
    Protected WithEvents Linkbutton2 As System.Web.UI.WebControls.LinkButton
    Protected WithEvents lblBGNGItem As System.Web.UI.WebControls.Label
    Protected WithEvents LblDeptNgTitle As System.Web.UI.WebControls.Label
    Protected WithEvents Datagrid5 As System.Web.UI.WebControls.DataGrid
    Protected WithEvents Label5 As System.Web.UI.WebControls.Label
    Protected WithEvents Label6 As System.Web.UI.WebControls.Label
    Protected WithEvents Label7 As System.Web.UI.WebControls.Label
    Protected WithEvents Label8 As System.Web.UI.WebControls.Label

    '注意: 下列預留位置宣告是 Web Form 設計工具需要的項目。
    '請勿刪除或移動它。
    Private designerPlaceholderDeclaration As System.Object

    Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
        'CODEGEN: 此為 Web Form 設計工具所需的方法呼叫
        '請勿使用程式碼編輯器進行修改。
        InitializeComponent()
    End Sub

#End Region

#Region "Const Define"
    Private Const HIDE_CSITime As String = "ViewState:CSITime"
    Private Const HIDE_DeptPKID As String = "ViewState:DeptPKID"
    Private Const HIDE_DeptName As String = "ViewState:DeptName"
#End Region

#Region "Properties"
    Private Property CSITime() As Integer
        Get
            If ViewState(HIDE_CSITime) Is Nothing Then
                Return 0
            End If
            Return Convert.ToInt32(ViewState(HIDE_CSITime))
        End Get
        Set(ByVal Value As Integer)
            ViewState(HIDE_CSITime) = Value
        End Set
    End Property

    Private Property DeptPKID() As Integer
        Get
            If ViewState(HIDE_DeptPKID) Is Nothing Then
                Return 0
            End If
            Return Convert.ToInt32(ViewState(HIDE_DeptPKID))
        End Get
        Set(ByVal Value As Integer)
            ViewState(HIDE_DeptPKID) = Value
        End Set
    End Property

    Private Property DeptName() As String
        Get
            If ViewState(HIDE_DeptName) Is Nothing Then
                Return String.Empty
            End If
            Return ViewState(HIDE_DeptName)
        End Get
        Set(ByVal Value As String)
            ViewState(HIDE_DeptName) = Value
        End Set
    End Property
#End Region

#Region "Self Degfine Sub/function"

    Private Sub BindDataListPeriod()
        Dim SearchCondition As String = String.Empty
        Dim Alist As ArrayList = GEPCSI_Period.GetPeriodListInfo()
        If Not Alist Is Nothing Then
            Me.Datalist1.DataSource = Alist
            Me.Datalist1.DataBind()
            If CSITime = 0 Then
                CSITime = Alist.Item(0).Value
            End If
            BindDataGrid1()
            BindDataGrid2()
            BindDatagrid4()
            Me.Datalist2.SelectedIndex = 0
            DeptPKID = 0
            BindDataListDept()
        Else
            Exit Sub
        End If
    End Sub

    Private Sub BindDataListDept()
        Dim SearchString As String = " CSITime=" + CSITime.ToString + " AND IsSubmited=2"
        Dim Alist As ArrayList = GEPCSI_Result.GetImportDeptInfo(SearchString)
        If Not Alist Is Nothing Then
            Me.Datalist2.DataSource = Alist
            Me.Datalist2.DataBind()
            If DeptPKID = 0 Then
                DeptPKID = Alist.Item(0).Value
                DeptName = Alist.Item(0).Text
            End If
        End If
        BindDataGrid3()
    End Sub

    Private Sub BindDataGrid1()
        Dim SearchString As String = "  AND CSITime=" + CSITime.ToString
        Dim GroupName As String = "SubmitGroup"
        Dim ds As DataSet = GEPCSI_DetailResult.GetReportInfoBySearchCondition(SearchString, GroupName)
        If Not ds Is Nothing Then
            Me.Datagrid1.DataSource = ds
            Me.Datagrid1.DataBind()
            ' Me.lblBGNGItem.Text = GEPCSI_DetailResult.GetNGItemBySearchCondtion(SearchString)
        End If

    End Sub

    Private Sub BindDataGrid2()
        Dim SearchString As String = "  AND CSITime=" + CSITime.ToString
        Dim GroupName As String = "DeptName"
        Dim ds As DataSet = GEPCSI_DetailResult.GetReportInfoBySearchCondition(SearchString, GroupName)
        If Not ds Is Nothing Then
            Me.Datagrid2.DataSource = ds
            Me.Datagrid2.DataBind()
        End If
    End Sub

    Private Sub BindDataGrid3()
        Dim ds As DataSet
        Dim SearchString As String
        If DeptPKID = 0 Then
            ds = Nothing
        Else
            SearchString = "  AND CSITime=" + CSITime.ToString + "  AND DeptPKID=" + DeptPKID.ToString
            Dim GroupName As String = "ItemName"
            ds = GEPCSI_DetailResult.GetReportInfoBySearchCondition(SearchString, GroupName)
        End If
        If Not ds Is Nothing Then

            Me.LblDeptNgTitle.Text = "a. " + DeptName + "在本次問卷調查的不滿意主要在哪些調查項目?"
            Me.DataGrid3.DataSource = ds
            Me.DataGrid3.DataBind()
            BindDatagrid5()
            '  Me.LblDeptNgItem.Text = GEPCSI_DetailResult.GetNGItemBySearchCondtion(SearchString)
        End If

    End Sub

    Private Sub BindDatagrid4()
        Dim SearchString As String = "  AND CSITime=" + CSITime.ToString
        Dim ds As DataSet = GEPCSI_DetailResult.GetNGItemBySearchCondtion(SearchString)
        If Not ds Is Nothing Then
            Me.Datagrid4.DataSource = ds
            Me.Datagrid4.DataBind()
        End If
    End Sub

    Private Sub BindDatagrid5()
        Dim SearchString As String = "  AND CSITime=" + CSITime.ToString + "  AND DeptPKID=" + DeptPKID.ToString
        Dim ds As DataSet = GEPCSI_DetailResult.GetNGItemBySearchCondtion(SearchString)
        If Not ds Is Nothing Then
            Me.Datagrid5.DataSource = ds
            Me.Datagrid5.DataBind()
        End If
    End Sub

#End Region

#Region "DataGrid Events"

    Private Sub DataGrid1_ItemDataBound(ByVal sender As System.Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs) Handles Datagrid1.ItemDataBound
        If e.Item.ItemType = ListItemType.Item OrElse e.Item.ItemType = ListItemType.AlternatingItem Then
            Dim dc As DataRowView = DirectCast(e.Item.DataItem, DataRowView)
            Dim lblSumVote1 As Integer = Convert.ToInt32(DirectCast(e.Item.FindControl("lblSumVote1"), Label).Text)
            Dim lblZHSumVote1 As Label = DirectCast(e.Item.FindControl("lblZHSumVote1"), Label)
            Dim lblAverageSum1 As Label = DirectCast(e.Item.FindControl("lblAverageSum1"), Label)
            Dim lblSatisfaction1 As Label = DirectCast(e.Item.FindControl("lblSatisfaction1"), Label)
            Dim ZhSum As Integer = dc.Item("VeryGood") * 5 + dc.Item("Good") * 4 + dc.Item("Bad") * 2 + dc.Item("VeryBad") * 1
            lblZHSumVote1.Text = ZhSum.ToString
            Dim Average1 As Decimal
            If lblSumVote1 <> 0 Then
                Average1 = ZhSum / lblSumVote1
                lblAverageSum1.Text = Round((Average1), 2)
            End If
            lblSatisfaction1.Text = Round((Average1 / 5) * 100%, 2).ToString + "%"
        End If
    End Sub

    Private Sub Datagrid2_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs) Handles Datagrid2.ItemDataBound
        If e.Item.ItemType = ListItemType.Item OrElse e.Item.ItemType = ListItemType.AlternatingItem Then
            Dim dc As DataRowView = DirectCast(e.Item.DataItem, DataRowView)
            Dim lblSumVote2 As Integer = Convert.ToInt32(DirectCast(e.Item.FindControl("lblSumVote2"), Label).Text)
            Dim lblZHSumVote2 As Label = DirectCast(e.Item.FindControl("lblZHSumVote2"), Label)
            Dim lblAverageSum2 As Label = DirectCast(e.Item.FindControl("lblAverageSum2"), Label)
            Dim lblSatisfaction2 As Label = DirectCast(e.Item.FindControl("lblSatisfaction2"), Label)
            Dim ZhSum As Integer = dc.Item("VeryGood") * 5 + dc.Item("Good") * 4 + dc.Item("Bad") * 2 + dc.Item("VeryBad") * 1
            lblZHSumVote2.Text = ZhSum.ToString
            Dim Average2 As Decimal
            If lblSumVote2 <> 0 Then
                Average2 = ZhSum / lblSumVote2
                lblAverageSum2.Text = Round(Average2, 2)
            End If
            lblSatisfaction2.Text = Round((Average2 / 5) * 100%, 2).ToString + "%"
        End If
    End Sub

    Private Sub Datagrid4_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs) Handles Datagrid4.ItemDataBound
        If e.Item.ItemType = ListItemType.Item OrElse e.Item.ItemType = ListItemType.AlternatingItem Then
            'Dim lblItemName1 As Label = DirectCast(e.Item.FindControl("Label2"), Label)
            Dim lblItemCount1 As Label = DirectCast(e.Item.FindControl("Label4"), Label)

            Dim lblNGReason1 As Label = DirectCast(e.Item.FindControl("Label5"), Label)
            Dim dc As DataRowView = DirectCast(e.Item.DataItem, DataRowView)
            Dim NgItem As String = String.Empty
            Dim NgItemAnswer As String
            'Dim Count As Integer
            NgItemAnswer = Convert.ToString(dc.Item("ItemName"))
            Dim DeptItemPKID As String = dc.Item("DeptItemPKID")
            'Count = NgItemAnswer.IndexOf("是否")
            'If Count > 0 Then
            '    NgItem += NgItemAnswer.Remove(Count, NgItemAnswer.Length - Count)
            'End If
            'lblItemName1.Text = NgItem
            Dim mLblSumNGReason As Label = DirectCast(e.Item.FindControl("LblSumNGReason"), Label)
            Dim ds As DataSet
            Dim SearchCondition As String = "  AND CSITime=" + CSITime.ToString + " AND DeptItemPKID=" + DeptItemPKID.ToString
            ds = GEPCSI_NGItemReasonDAL.GetReportInfoBySearchCondtion(SearchCondition, DeptItemPKID)
            If Not ds Is Nothing Then
                Dim dt1 As DataTable = ds.Tables(0)
                Dim dt2 As DataTable = ds.Tables(1)
                lblItemCount1.Text = dt2.Rows.Count
                If Not dt2 Is Nothing AndAlso dt2.Rows.Count > 0 Then

                    Dim j As Integer
                    For j = 0 To dt2.Rows.Count - 1
                        Dim dr1 As DataRow = dt2.Rows(j)
                        Dim i As Integer
                        Dim CheckCount As Integer = 0
                        For i = 0 To dt1.Rows.Count - 1
                            Dim dr As DataRow = dt1.Rows(i)
                            If (dr1.Item("ItemNGReason") And Pow(2, i)) = Pow(2, i) Then
                                CheckCount = CheckCount + 1
                                Dim NGItemName As String = dr.Item("NGItemName")
                                If dr.Item("IsWithTextBox") = "0" Then
                                    If mLblSumNGReason.Text.IndexOf(";" + NGItemName) = -1 Then
                                        mLblSumNGReason.Text += dr.Item("NGItemName") + ";"
                                    End If

                                Else
                                    mLblSumNGReason.Text += NGItemName + ":" + dr1.Item("ItemNGText").Split("^")(CheckCount - 1).Split(":")(1) + ";"
                                End If
                            End If
                        Next
                    Next
                End If
            End If
        End If
    End Sub

    Private Sub Datagrid5_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs) Handles Datagrid5.ItemDataBound
        If e.Item.ItemType = ListItemType.Item OrElse e.Item.ItemType = ListItemType.AlternatingItem Then
            'Dim lblItemName1 As Label = DirectCast(e.Item.FindControl("Label6"), Label)
            Dim lblItemCount1 As Label = DirectCast(e.Item.FindControl("Label7"), Label)

            Dim lblNGReason1 As Label = DirectCast(e.Item.FindControl("Label8"), Label)
            Dim dc As DataRowView = DirectCast(e.Item.DataItem, DataRowView)
            Dim NgItem As String = String.Empty
            Dim NgItemAnswer As String
            ' Dim Count As Integer
            NgItemAnswer = Convert.ToString(dc.Item("ItemName"))
            Dim DeptItemPKID As String = dc.Item("DeptItemPKID")
            'Count = NgItemAnswer.IndexOf("是否")
            'If Count > 0 Then
            '    NgItem += NgItemAnswer.Remove(Count, NgItemAnswer.Length - Count)
            'End If
            'lblItemName1.Text = NgItem
            Dim mLblSumNGReason As Label = DirectCast(e.Item.FindControl("Label8"), Label)
            Dim ds As DataSet
            Dim SearchCondition As String = "  AND CSITime=" + CSITime.ToString + "  AND DeptPKID=" + DeptPKID.ToString + " AND DeptItemPKID=" + DeptItemPKID.ToString
            ds = GEPCSI_NGItemReasonDAL.GetReportInfoBySearchCondtion(SearchCondition, DeptItemPKID)
            If Not ds Is Nothing Then
                Dim dt1 As DataTable = ds.Tables(0)
                Dim dt2 As DataTable = ds.Tables(1)
                lblItemCount1.Text = dt2.Rows.Count
                If Not dt2 Is Nothing AndAlso dt2.Rows.Count > 0 Then

                    Dim j As Integer
                    For j = 0 To dt2.Rows.Count - 1
                        Dim dr1 As DataRow = dt2.Rows(j)
                        Dim i As Integer
                        Dim CheckCount As Integer = 0
                        For i = 0 To dt1.Rows.Count - 1
                            Dim dr As DataRow = dt1.Rows(i)
                            If (dr1.Item("ItemNGReason") And Pow(2, i)) = Pow(2, i) Then
                                CheckCount = CheckCount + 1
                                Dim NGItemName As String = dr.Item("NGItemName")
                                If dr.Item("IsWithTextBox") = "0" Then
                                    If mLblSumNGReason.Text.IndexOf(";" + NGItemName) = -1 Then
                                        mLblSumNGReason.Text += dr.Item("NGItemName") + ";"
                                    End If

                                Else
                                    mLblSumNGReason.Text += NGItemName + ":" + dr1.Item("ItemNGText").Split("^")(CheckCount - 1).Split(":")(1) + ";"
                                End If
                            End If
                        Next
                    Next
                End If
            End If
        End If
    End Sub


#End Region

#Region "DataList Events"
    Private Sub Datalist2_ItemCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataListCommandEventArgs) Handles Datalist2.ItemCommand
        Select Case e.CommandName
            Case "SearchDeptName"

                If e.Item.ItemType = ListItemType.Item OrElse e.Item.ItemType = ListItemType.AlternatingItem Then
                    DeptPKID = Convert.ToInt32(e.CommandArgument)
                    Me.Datalist2.SelectedIndex = e.Item.ItemIndex
                    Dim SelectedDeptName As String = DirectCast(Me.Datalist2.SelectedItem.FindControl("linkDeptName"), LinkButton).Text
                    DeptName = SelectedDeptName
                    BindDataListDept()
                End If
                ScriptManager.RegisterStartupScript(Me.Parent, Me.Parent.GetType(), DateTime.Now.ToString(), "<script>parent.iFrameHeight();</script>", False)

        End Select
    End Sub

    Private Sub Datalist1_ItemCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataListCommandEventArgs) Handles Datalist1.ItemCommand
        Select Case e.CommandName
            Case "SearchPeriod"

                If e.Item.ItemType = ListItemType.Item OrElse e.Item.ItemType = ListItemType.AlternatingItem Then
                    CSITime = Convert.ToInt32(e.CommandArgument)
                    Me.Datalist1.SelectedIndex = e.Item.ItemIndex
                    BindDataListPeriod()
                    ScriptManager.RegisterStartupScript(Me.Parent, Me.Parent.GetType(), DateTime.Now.ToString(), "<script>parent.iFrameHeight();</script>", False)

                End If
        End Select
    End Sub
#End Region

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        '在這裡放置使用者程式碼以初始化網頁
        If Not IsPostBack Then
            Me.Datalist1.SelectedIndex = 0
            BindDataListPeriod()
        End If
    End Sub


    Private Sub LinkReport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LinkReport.Click
        Dim count As Integer = 0
        If Me.Datagrid1.Items.Count > 0 Then
            Dim strbData As StringBuilder = New StringBuilder
            strbData.Append("BG,很滿意,滿意,不滿意,很不滿意,總計,折合總分,平均給分,滿意度,")
            strbData.Append(vbCrLf)
            Dim i As Integer
            For i = 0 To Me.Datagrid1.Items.Count - 1
                Dim DGI As DataGridItem = Me.Datagrid1.Items(i)
                Dim BG As String = CType(DGI.FindControl("lblGroup"), Label).Text
                Dim VeryGood1 As String = CType(DGI.FindControl("lblVeryGood1"), Label).Text
                Dim Good1 As String = CType(DGI.FindControl("lblGood1"), Label).Text
                Dim Bad1 As String = CType(DGI.FindControl("lblBad1"), Label).Text
                Dim VeryBad1 As String = CType(DGI.FindControl("lblVerybad1"), Label).Text
                Dim SumVote1 As String = CType(DGI.FindControl("lblSumVote1"), Label).Text
                Dim ZHSumVote1 As String = CType(DGI.FindControl("lblZHSumVote1"), Label).Text
                Dim AverageSum1 As String = CType(DGI.FindControl("lblAverageSum1"), Label).Text
                Dim Satisfaction1 As String = CType(DGI.FindControl("lblSatisfaction1"), Label).Text
                strbData.Append(BG + ",")
                strbData.Append(VeryGood1 + ",")
                strbData.Append(Good1 + ",")
                strbData.Append(Bad1 + ",")
                strbData.Append(VeryBad1 + ",")
                strbData.Append(SumVote1 + ",")
                strbData.Append(ZHSumVote1 + ",")
                strbData.Append(AverageSum1 + ",")
                strbData.Append(Satisfaction1 + ",")

                strbData.Append(vbCrLf)
            Next
            Dim temp As String = String.Format("attachment;filename={0}", "BgVoteData.csv")
            Response.ClearHeaders()
            Response.ContentEncoding = System.Text.Encoding.Default
            Response.Charset = "utf-8"
            Response.ContentType = "application/csv"
            Response.AppendHeader("Content-disposition", temp)
            Response.Write(strbData.ToString)
            Response.End()
        End If
    End Sub

    Private Sub Linkbutton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Linkbutton1.Click
        Dim count As Integer = 0
        If Me.Datagrid2.Items.Count > 0 Then
            Dim strbData As StringBuilder = New StringBuilder
            strbData.Append("Commodity,很滿意,滿意,不滿意,很不滿意,總計,折合總分,平均給分,滿意度,")
            strbData.Append(vbCrLf)
            Dim i As Integer
            For i = 0 To Me.Datagrid2.Items.Count - 1
                Dim DGI As DataGridItem = Me.Datagrid2.Items(i)
                Dim Commodity As String = CType(DGI.FindControl("lblCommodity"), Label).Text
                Dim VeryGood2 As String = CType(DGI.FindControl("lblVeryGood2"), Label).Text
                Dim Good2 As String = CType(DGI.FindControl("lblGood2"), Label).Text
                Dim Bad2 As String = CType(DGI.FindControl("lblBad2"), Label).Text
                Dim VeryBad2 As String = CType(DGI.FindControl("lblVerybad2"), Label).Text
                Dim SumVote2 As String = CType(DGI.FindControl("lblSumVote2"), Label).Text
                Dim ZHSumVote2 As String = CType(DGI.FindControl("lblZHSumVote2"), Label).Text
                Dim AverageSum2 As String = CType(DGI.FindControl("lblAverageSum2"), Label).Text
                Dim Satisfaction2 As String = CType(DGI.FindControl("lblSatisfaction2"), Label).Text

                strbData.Append(Commodity + ",")
                strbData.Append(VeryGood2 + ",")
                strbData.Append(Good2 + ",")
                strbData.Append(Bad2 + ",")
                strbData.Append(VeryBad2 + ",")
                strbData.Append(SumVote2 + ",")
                strbData.Append(ZHSumVote2 + ",")
                strbData.Append(AverageSum2 + ",")
                strbData.Append(Satisfaction2 + ",")
                strbData.Append(vbCrLf)
            Next
            Dim temp As String = String.Format("attachment;filename={0}", "CommodityVoteData.csv")
            Response.ClearHeaders()
            Response.ContentEncoding = System.Text.Encoding.Default
            Response.Charset = "utf-8"
            Response.ContentType = "application/csv"
            Response.AppendHeader("Content-disposition", temp)
            Response.Write(strbData.ToString)
            Response.End()
        End If
    End Sub

    Private Sub Linkbutton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Linkbutton2.Click
        Dim count As Integer = 0
        If Me.DataGrid3.Items.Count > 0 Then
            Dim strbData As StringBuilder = New StringBuilder
            strbData.Append(DeptName + ",")
            strbData.Append(vbCrLf)
            strbData.Append("調查內容,很滿意,滿意,不滿意,很不滿意,")
            strbData.Append(vbCrLf)
            Dim i As Integer
            For i = 0 To Me.DataGrid3.Items.Count - 1
                Dim DGI As DataGridItem = Me.DataGrid3.Items(i)
                Dim ItemName As String = CType(DGI.FindControl("lblItemName"), Label).Text.Trim
                Dim VeryGood3 As String = CType(DGI.FindControl("lblVeryGood3"), Label).Text.Trim
                Dim Good3 As String = CType(DGI.FindControl("lblGood3"), Label).Text.Trim
                Dim Bad3 As String = CType(DGI.FindControl("lblBad3"), Label).Text.Trim
                Dim VeryBad3 As String = CType(DGI.FindControl("lblVerybad3"), Label).Text.Trim
                strbData.Append(ItemName + ",")
                strbData.Append(VeryGood3 + ",")
                strbData.Append(Good3 + ",")
                strbData.Append(Bad3 + ",")
                strbData.Append(VeryBad3 + ",")
                strbData.Append(vbCrLf)
            Next
            Dim temp As String = String.Format("attachment;filename={0}", "ItemVoteData.csv")
            Response.ClearHeaders()
            Response.ContentEncoding = System.Text.Encoding.Default
            Response.Charset = "utf-8"
            Response.ContentType = "application/csv"
            Response.AppendHeader("Content-disposition", temp)
            Response.Write(strbData.ToString)
            Response.End()
        End If
    End Sub


    
End Class
