Imports System.Data.SqlClient
Imports System.Drawing
Imports System.IO

Partial Public Class TestItemManage
    Inherits System.Web.UI.Page
    Private Const HIDE_APPLICANTIDX_KEY As String = "ViewState:PKID"
    Private oBook As New C1.C1Excel.C1XLBook
    Private oSheet As C1.C1Excel.XLSheet
    Private oStyle As New C1.C1Excel.XLStyle(oBook)
    Private sFile As String, sTemplate As String
#Region "Properties"
    Private Property ItemPKID() As Integer
        Get
            If ViewState("ItemPKID") Is Nothing Then
                Return 0
            End If
            Return Convert.ToInt32(ViewState("ItemPKID"))
        End Get
        Set(ByVal value As Integer)
            ViewState("ItemPKID") = value
        End Set
    End Property
    Private Property PKID() As Integer
        Get
            If ViewState(HIDE_APPLICANTIDX_KEY) Is Nothing Then
                Return 0
            End If

            Return Convert.ToInt32(ViewState(HIDE_APPLICANTIDX_KEY))
        End Get
        Set(ByVal Value As Integer)
            ViewState(HIDE_APPLICANTIDX_KEY) = Value
        End Set
    End Property
    Private _ItemManage As TestItemManageInfo
    Private Property ItemManage() As TestItemManageInfo
        Get
            If _ItemManage Is Nothing Then
                If PKID <> 0 Then
                    If Not TestItemManageDAL.GetInfoByPKIDAllqy(PKID) Is Nothing Then
                        _ItemManage = TestItemManageDAL.GetInfoByPKIDAllqy(PKID)
                    Else
                        _ItemManage = New TestItemManageInfo()
                    End If
                End If
            End If
            Return _ItemManage
        End Get
        Set(ByVal value As TestItemManageInfo)
            _ItemManage = value
        End Set
    End Property
#End Region
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            Me.DPLcq.SelectedIndex = Me.DPLcq.Items.IndexOf(Me.DPLcq.Items.FindByValue(ConfigurationInfo.CQ))
            BindTreeView()
            Me.TreeView1.Attributes.Add("onclick", "parent.iFrameHeight();")
        End If

    End Sub
    Private Sub BindTreeView()
        Dim ds As DataSet = SqlHelper.ExecuteDataset(ConfigurationInfo.ConnectionStringAllcq, "TestItemManage_GetService")
        Dim dt As DataTable = ds.Tables(0)
        Dim dr As DataRow
        If dt.Rows.Count > 0 Then
            For Each dr In dt.Rows
                Dim tn As TreeNode = New TreeNode()
                tn.Text = dr.Item("LbServiceName").ToString
                tn.Value = dr.Item("LbServiceName").ToString
                tn.Expanded = False
                tn.SelectAction = TreeNodeSelectAction.Expand
                TreeView1.Nodes.Add(tn)

                AddChildrenNode(tn)
            Next
        End If
    End Sub
    Private Sub AddChildrenNode(ByVal tn As TreeNode)
        Dim ds As DataSet = SqlHelper.ExecuteDataset(ConfigurationInfo.ConnectionStringAllcq, "TestItemManage_GetItemByService", tn.Value.ToString)
        Dim dt As DataTable = ds.Tables(0)
        Dim dr As DataRow
        If dt.Rows.Count > 0 Then
            For i As Integer = 0 To dt.Rows.Count - 1
                dr = dt.Rows(i)
                Dim ctn As TreeNode = New TreeNode()
                ctn.Text = dr.Item("TestItemName").ToString
                ctn.Value = dr.Item("PKID").ToString
                'ctn.Expanded = False
                'ctn.SelectAction = TreeNodeSelectAction.Expand
                tn.ChildNodes.Add(ctn)

                ' AddChildChildNode(ctn)
            Next
        End If
    End Sub
    'Private Sub AddChildChildNode(ByVal ctn As TreeNode)
    '    Dim ds As DataSet = SqlHelper.ExecuteDataset(ConfigurationInfo.ConnectionStringAllcq, "View_TestItem_GetItemByCategory", ctn.Value.ToString)
    '    Dim dt As DataTable = ds.Tables(0)
    '    Dim dr As DataRow
    '    If dt.Rows.Count > 0 Then
    '        For i As Integer = 0 To dt.Rows.Count - 1
    '            dr = dt.Rows(i)
    '            Dim cctn As TreeNode = New TreeNode()
    '            cctn.Text = dr.Item("ItemName").ToString
    '            cctn.Value = dr.Item("TestItemPKID").ToString
    '            ctn.ChildNodes.Add(cctn)

    '        Next
    '    End If
    'End Sub
    Protected Sub TreeView1_SelectedNodeChanged(ByVal sender As Object, ByVal e As EventArgs) Handles TreeView1.SelectedNodeChanged
        Dim curnode As TreeNode = TreeView1.SelectedNode
        If curnode.ChildNodes.Count = 0 Then
            PKID = curnode.Value
            BindControlData(PKID)
            Me.LbItemname.Text = curnode.Text
            Me.LbTestService.Text = curnode.Parent.Text
        End If
    End Sub
    Private Sub BindControlData(ByVal pkid As Integer)
        If Not pkid = 0 Then

            If Not ItemManage Is Nothing Then
                If ItemManage.PKID <> 0 Then
                    ItemPKID = ItemManage.PKID
                    Me.TxtCBbootfee.Text = ItemManage.CBbootfee
                    Me.TxtCBunitfee.Text = ItemManage.CBunitfee
                    Me.TxtDWDJbootfee.Text = ItemManage.DWDJbootfee
                    Me.TxtDWDJunitfee.Text = ItemManage.DWDJunitfee
                    Me.TxtDWPJbootfee.Text = ItemManage.DWPJbootfee
                    Me.TxtDWPJunitfee.Text = ItemManage.DWPJunitfee
                    Me.TxtUnit.Text = ItemManage.Extend1
                Else
                    Me.TxtCBbootfee.Text = 0
                    Me.TxtCBunitfee.Text = 0
                    Me.TxtDWDJbootfee.Text = 0
                    Me.TxtDWDJunitfee.Text = 0
                    Me.TxtDWPJbootfee.Text = 0
                    Me.TxtDWPJunitfee.Text = 0
                    Me.TxtUnit.Text = ""
                End If
            End If
        End If
    End Sub

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button1.Click
        If ItemPKID <> 0 Then
            ItemManage.TestItemName = Me.TreeView1.SelectedNode.Text
            ItemManage.LbServiceName = Me.TreeView1.SelectedNode.Parent.Text
            ItemManage.CBbootfee = Me.TxtCBbootfee.Text
            ItemManage.CBunitfee = Me.TxtCBunitfee.Text
            ItemManage.DWDJbootfee = Me.TxtDWDJbootfee.Text
            ItemManage.DWDJunitfee = Me.TxtDWDJunitfee.Text
            ItemManage.DWPJbootfee = Me.TxtDWPJbootfee.Text
            ItemManage.DWPJunitfee = Me.TxtDWPJunitfee.Text
            ItemManage.Extend1 = Me.TxtUnit.Text
            If ItemManage.PKID = 0 Then
                ItemManage.RecordCreated = DateTime.Now
            End If
            ItemManage.RecordDeleted = 0

            Dim itemmanagedal As TestItemManageDAL = New TestItemManageDAL(ItemManage)
            itemmanagedal.Save()
        End If
    End Sub

    '' -----------------------------------------------------------------------------
    '' <summary>
    '' 匯入Excel文檔
    '' </summary>
    '' <remarks>
    '' </remarks>
    '' -----------------------------------------------------------------------------
    Private Sub InputResource()
        Dim strFileName As String = Path.GetFileName(Me.FileUpload.PostedFile.FileName)
        Dim strFileExtensionName As String = Path.GetExtension(Me.FileUpload.PostedFile.FileName)
        Dim i As Integer, j As Integer
        Dim Row As Integer
        If Not checkInput(strFileExtensionName) Then
            Exit Sub
        End If
        Dim UpDownloadsServerPath As String = Server.MapPath(String.Format("{0}/TempUploadFiles", HttpContext.Current.Request.ApplicationPath))
        Dim strFileNameOnServer As String = String.Format("{0}\{1}", UpDownloadsServerPath, strFileName)
        Dim myconn As SqlConnection = New SqlConnection(ConfigurationInfo.ConnectionStringAllcq)
        myconn.Open()
        Dim myTrans As SqlTransaction
        myTrans = myconn.BeginTransaction()
        Try
            ' SqlHelper.ExecuteNonQuery(ConfigurationInfo.ConnectionStringAllcq, "TestItemManage_DeleteAll") ' 不能回滾
            Dim Mycmdclear As SqlCommand = New SqlCommand()
            Mycmdclear.Connection = myconn
            Mycmdclear.Transaction = myTrans
            Mycmdclear.CommandText = " Update TestItemManage set RecordDeleted=1"
            Mycmdclear.ExecuteNonQuery()

            If File.Exists(strFileNameOnServer) Then
                File.Delete(strFileNameOnServer)
            End If
            Me.FileUpload.PostedFile.SaveAs(strFileNameOnServer)
            oBook.Load(strFileNameOnServer)
            Dim mtestitem As New TestItemManageInfo
            mtestitem.PKID = 0
            mtestitem.LbServicePKID = 0
            mtestitem.TestItemPKID = 0
            mtestitem.DWDJbootfee = 0
            mtestitem.DWDJunitfee = 0
            mtestitem.Extend2 = ""
            mtestitem.Extend3 = ""
            mtestitem.Extend4 = ""
            mtestitem.Extend5 = ""
            mtestitem.Extend6 = ""
            mtestitem.RecordCreated = DateTime.Now
            mtestitem.RecordDeleted = 0

            Dim mycmd As New SqlCommand("TestItemManage_Insert", myconn)
            mycmd.Transaction = myTrans
            mycmd.CommandType = CommandType.StoredProcedure
            PrePareParameter(mycmd)
            For i = 0 To oBook.Sheets.Count - 1
                oSheet = oBook.Sheets(i)
                For j = 2 To oSheet.Rows.Count - 1

                    Row = j
                    If oSheet(Row, 0) Is Nothing OrElse oSheet(Row, 2).Value Is Nothing Then
                        mtestitem.LbServiceName = String.Empty
                    Else
                        mtestitem.LbServiceName = oSheet(Row, 0).Value.ToString.Trim
                    End If


                    If oSheet(Row, 2) Is Nothing OrElse oSheet(Row, 2).Value Is Nothing Then
                        mtestitem.TestItemName = String.Empty
                    Else
                        mtestitem.TestItemName = oSheet(Row, 2).Value.ToString.Trim
                    End If
                    If oSheet(Row, 3) Is Nothing OrElse oSheet(Row, 3).Value Is Nothing Then
                        mtestitem.Extend1 = String.Empty
                    Else
                        mtestitem.Extend1 = oSheet(Row, 3).Value.ToString.Trim
                    End If

                    If oSheet(Row, 4) Is Nothing OrElse oSheet(Row, 4).Value Is Nothing Then
                        mtestitem.DWPJbootfee = 0
                    Else
                        mtestitem.DWPJbootfee = oSheet(Row, 4).Value.ToString.Trim
                    End If
                    If oSheet(Row, 5) Is Nothing OrElse oSheet(Row, 5).Value Is Nothing Then
                        mtestitem.DWPJunitfee = 0
                    Else
                        mtestitem.DWPJunitfee = oSheet(Row, 5).Value.ToString.Trim
                    End If
                    If oSheet(Row, 6) Is Nothing OrElse oSheet(Row, 6).Value Is Nothing Then
                        mtestitem.CBunitfee = 1
                    Else
                        mtestitem.CBunitfee = oSheet(Row, 6).Value.ToString.Trim
                    End If


                    SetPareParameterValue(mycmd, mtestitem)
                    mycmd.ExecuteNonQuery()

                Next
            Next
            Dim MycmdAfter As SqlCommand = New SqlCommand()
            MycmdAfter.Connection = myconn
            MycmdAfter.Transaction = myTrans
            MycmdAfter.CommandText = "update TestItemManage set LbServicePKID =1 where LbServiceName =N'可靠度'"
            MycmdAfter.CommandText += "update TestItemManage set LbServicePKID =2 where LbServiceName =N'SMT'"
            MycmdAfter.CommandText += "update TestItemManage set LbServicePKID =3 where LbServiceName =N'JDM'"
            MycmdAfter.CommandText += "update TestItemManage set LbServicePKID =4 where LbServiceName =N'金属'"
            MycmdAfter.CommandText += "update TestItemManage set LbServicePKID =5 where LbServiceName =N'塑发室'"
            MycmdAfter.CommandText += " update TestItemManage set LbServicePKID =6 where LbServiceName =N'元素'"
            MycmdAfter.CommandText += " update TestItemManage set LbServicePKID =7 where LbServiceName =N'量测'"
            MycmdAfter.CommandText += "update TestItemManage set LbServicePKID =8 where LbServiceName =N'校准'"
            MycmdAfter.CommandText += " update TestItemManage set LbServicePKID =9 where LbServiceName =N'食品检测'"
            MycmdAfter.CommandText += " update TestItemManage set LbServicePKID =10 where LbServiceName =N'HALT'"
            MycmdAfter.CommandText += "update TestItemManage set LbServicePKID =11 where LbServiceName =N'噪音'"
            MycmdAfter.CommandText += " update TestItemManage set LbServicePKID =12 where LbServiceName =N'其它'"
            MycmdAfter.CommandText += " update TestItemManage set LbServicePKID =13 where LbServiceName =N'ECM'"
            MycmdAfter.CommandText += " update TestItemManage set LbServicePKID =14 where LbServiceName =N'ECME'"
            MycmdAfter.CommandText += " update TestItemManage set TestItemPKID =PKID"
            MycmdAfter.ExecuteNonQuery()

            myTrans.Commit()
            Me.LblMsg.Text = "導入數據庫成功！"
            Me.LblMsg.ForeColor = Color.Blue


            BindTreeView()
            Me.TreeView1.Attributes.Add("onclick", "parent.iFrameHeight();")
        Catch ex As Exception
            myTrans.Rollback()
            Me.LblMsg.Text = "導入數據庫失敗,請檢查格式或聯繫管理員！"
            Me.LblMsg.ForeColor = Color.Red
        Finally
            myconn.Close()
            If File.Exists(strFileNameOnServer) Then
                File.Delete(strFileNameOnServer)
            End If
        End Try
    End Sub

    Private Function checkInput(ByVal strFileExtensionName As String) As Boolean
        If Me.FileUpload.PostedFile.ContentLength = 0 Then
            Me.LblMsg.Text = "選取的文件不存在"
            Me.LblMsg.ForeColor = Color.Red
            Return False
        End If
        If strFileExtensionName.ToLower <> ".xls" AndAlso strFileExtensionName.ToLower <> ".xlsx" Then
            Me.LblMsg.Text = "不允許的文件格式"
            Me.LblMsg.ForeColor = Color.Red
            Return False
        End If
        Return True
    End Function
    ' 準備參數
    Private Sub PrePareParameter(ByVal mycmd As SqlCommand)
        mycmd.Parameters.Add(New SqlParameter("@PKID", SqlDbType.Int, 4))
        mycmd.Parameters.Add(New SqlParameter("@TestItemPKID", SqlDbType.Int, 4))
        mycmd.Parameters.Add(New SqlParameter("@LbServicePKID", SqlDbType.Int, 4))
        mycmd.Parameters.Add(New SqlParameter("@LbServiceName", SqlDbType.NVarChar))
        mycmd.Parameters.Add(New SqlParameter("@TestItemName", SqlDbType.NVarChar))
        mycmd.Parameters.Add(New SqlParameter("@CBbootfee", SqlDbType.Int, 4))
        mycmd.Parameters.Add(New SqlParameter("@CBunitfee", SqlDbType.Int, 4))
        mycmd.Parameters.Add(New SqlParameter("@DWPJbootfee", SqlDbType.Int, 4))
        mycmd.Parameters.Add(New SqlParameter("@DWPJunitfee", SqlDbType.Int, 4))
        mycmd.Parameters.Add(New SqlParameter("@DWDJbootfee", SqlDbType.Int, 4))
        mycmd.Parameters.Add(New SqlParameter("@DWDJunitfee", SqlDbType.Int, 4))
        mycmd.Parameters.Add(New SqlParameter("@Extend1", SqlDbType.NVarChar))
        mycmd.Parameters.Add(New SqlParameter("@Extend2", SqlDbType.NVarChar))
        mycmd.Parameters.Add(New SqlParameter("@Extend3", SqlDbType.NVarChar))
        mycmd.Parameters.Add(New SqlParameter("@Extend4", SqlDbType.NVarChar))
        mycmd.Parameters.Add(New SqlParameter("@Extend5", SqlDbType.NVarChar))
        mycmd.Parameters.Add(New SqlParameter("@Extend6", SqlDbType.NVarChar))
        mycmd.Parameters.Add(New SqlParameter("@RecordCreated", SqlDbType.DateTime))
        mycmd.Parameters.Add(New SqlParameter("@RecordDeleted", SqlDbType.Int, 4))

    End Sub
    ' 設置參數的值
    Private Sub SetPareParameterValue(ByVal mycmd As SqlCommand, ByVal mtestitem As TestItemManageInfo)
        mycmd.Parameters("@PKID").Direction = ParameterDirection.Output
        mycmd.Parameters("@TestItemPKID").Value = mtestitem.TestItemPKID
        mycmd.Parameters("@LbServicePKID").Value = mtestitem.LbServicePKID
        mycmd.Parameters("@LbServiceName").Value = mtestitem.LbServiceName
        mycmd.Parameters("@TestItemName").Value = mtestitem.TestItemName
        mycmd.Parameters("@CBbootfee").Value = mtestitem.CBbootfee
        mycmd.Parameters("@CBunitfee").Value = mtestitem.CBunitfee
        mycmd.Parameters("@DWPJbootfee").Value = mtestitem.DWPJbootfee
        mycmd.Parameters("@DWPJunitfee").Value = mtestitem.DWPJunitfee
        mycmd.Parameters("@DWDJbootfee").Value = mtestitem.DWDJbootfee
        mycmd.Parameters("@DWDJunitfee").Value = mtestitem.DWDJunitfee
        mycmd.Parameters("@extend1").Value = mtestitem.Extend1
        mycmd.Parameters("@extend2").Value = mtestitem.Extend2
        mycmd.Parameters("@extend3").Value = mtestitem.Extend3
        mycmd.Parameters("@extend4").Value = mtestitem.Extend4
        mycmd.Parameters("@extend5").Value = mtestitem.Extend5
        mycmd.Parameters("@extend6").Value = mtestitem.Extend6
        mycmd.Parameters("@RecordCreated").Value = mtestitem.RecordCreated
        mycmd.Parameters("@RecordDeleted").Value = mtestitem.RecordDeleted

    End Sub

    Protected Sub BtnExcel_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BtnExcel.Click
        InputResource()
    End Sub


    Protected Sub btnrefresh_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnrefresh.Click
        Me.TreeView1.Nodes.Clear()
        BindTreeView()
    End Sub

    Protected Sub btnExcelout_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnExcelout.Click
        Dim excelds As DataSet
        excelds = SqlHelper.ExecuteDataset(ConfigurationInfo.ConnectionStringAllcq, "TestItemManage_GetInfoBySearchCondition", "")
        If excelds IsNot Nothing Then
            If excelds.Tables(0).Rows.Count > 0 Then
                Const StartRow As Integer = 2
                Dim oBook As New C1.C1Excel.C1XLBook
                Dim oSheet As C1.C1Excel.XLSheet
                Dim oStyle As New C1.C1Excel.XLStyle(oBook)
                Dim oStyledel As New C1.C1Excel.XLStyle(oBook)
                Dim sTemplate As String
                sTemplate = Server.MapPath(Request.ApplicationPath) & "\Reports\EquipmentInfoReport.xls"
                Try
                    oBook.Load(sTemplate)
                Catch ex As Exception

                    Exit Sub
                End Try

                Dim row As Integer = StartRow
                'Dim NO As Integer = 0

                oSheet = oBook.Sheets(0)
                Dim exceltitle As String = "測試項目信息"

                oSheet(0, 0).Value = exceltitle
                oSheet(1, 0).Value = "實驗室"
                oSheet(1, 1).Value = "序號"
                oSheet(1, 2).Value = "實驗項目"
                oSheet(1, 3).Value = "計價單位"
                oSheet(1, 4).Value = "牌價基本金"
                oSheet(1, 5).Value = "牌價單價"
                oSheet(1, 6).Value = "成本價"


                For j As Integer = 0 To excelds.Tables(0).Rows.Count - 1
                    Dim dr As DataRow = excelds.Tables(0).Rows(j)
                    oSheet(j + 2, 0).Value = dr.Item("LbServiceName")
                    oSheet(j + 2, 1).Value = dr.Item("TestItemPKID")
                    oSheet(j + 2, 2).Value = dr.Item("TestItemName")
                    oSheet(j + 2, 3).Value = dr.Item("Extend1")
                    oSheet(j + 2, 4).Value = dr.Item("TestItemName")
                    oSheet(j + 2, 5).Value = dr.Item("DWPJbootfee")
                    oSheet(j + 2, 6).Value = dr.Item("DWPJunitfee")
                    oSheet(j + 2, 7).Value = dr.Item("CBunitfee")

                    row += 1

                Next
                oStyle.AlignHorz = C1.C1Excel.XLAlignHorzEnum.Center
                oStyle.SetBorderStyle(C1.C1Excel.XLLineStyleEnum.Thin)
                oStyledel.AlignHorz = C1.C1Excel.XLAlignHorzEnum.Center
                oStyledel.SetBorderStyle(C1.C1Excel.XLLineStyleEnum.Thin)
                oStyledel.BackColor = Drawing.Color.Red

                Try
                    Dim PS As New C1.C1Excel.XLPrintSettings
                    PS.AutoScale = True
                    PS.CenterHorizontal = True
                    PS.Landscape = True
                    PS.PaperKind = Drawing.Printing.PaperKind.A4 ' Printing.PaperKind.A4
                    oSheet.PrintSettings = PS
                    oBook.Save(Server.MapPath(Request.ApplicationPath) & "\Reports\QuotationStatistics.xls")
                    Response.Redirect("\CRM\Reports\QuotationStatistics.xls")
                Catch ex As Exception

                End Try
            End If
        Else
            '沒有數據,無需導出
        End If
    End Sub

    Protected Sub DPLcq_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles DPLcq.SelectedIndexChanged
        ConfigurationInfo.CQ = Me.DPLcq.SelectedValue
        Me.TreeView1.Nodes.Clear()
        ItemPKID = 0
        BindTreeView()
    End Sub
End Class