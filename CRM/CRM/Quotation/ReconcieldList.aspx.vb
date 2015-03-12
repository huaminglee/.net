Imports Platform.eAuthorize
Imports System.IO
Imports Aspose.Words
Imports Aspose.Words.Tables

Partial Public Class ReconcieldList
    Inherits System.Web.UI.Page
#Region "Const"
    Private Const _SearchConditon As String = "ViewState:SearchConditon"
#End Region
#Region "屬性"
    Private ReadOnly Property InitSearch() As String
        Get
            If ViewState("InitSearch") IsNot Nothing Then
                Return CStr(ViewState("InitSearch"))
            Else
                Dim SearchCondition As String = " RecordDeleted=0 "
                Return SearchCondition
            End If
        End Get
    End Property
    Private ReadOnly Property SearchCondition() As String
        Get
            If ViewState("SearchCondition") Is Nothing Then
                Return InitSearch
            Else
                Return ViewState("SearchCondition").ToString

            End If
        End Get
    End Property
#End Region
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            Me.TxtEndDate.Attributes.Add("readonly", True)
            Me.TxtEndDate.Attributes.Add("onclick", "javascript:WdatePicker({startDate:'%y-%M-01',dateFmt:'yyyy-MM-dd'});")

            Me.TxtStartDate.Attributes.Add("readonly", True)
            Me.TxtStartDate.Attributes.Add("onclick", "javascript:WdatePicker({startDate:'%y-%M-01',dateFmt:'yyyy-MM-dd'});")

            Me.LinkGetPre.Attributes.Add("onclick", "return DeleteConfirm('確認生成對帳單');")
            Me.LinkFinishPre.Attributes.Add("onclick", "return DeleteConfirm('確認對所選報價單完成對賬嗎？');")
        End If
    End Sub
    Private Sub BindDPL()
        Dim ds As DataSet = SqlHelper.ExecuteDataset(ConfigurationInfo.ConnectionString, "GetNeedPreconcieldByCustomerPKID", 0, Me.TxtEndDate.Text, Me.TxtStartDate.Text, StrConv(UserInfo.CurrentUserCHName, VbStrConv.SimplifiedChinese, 2052))
        If ds.Tables(1).Rows.Count > 0 Then
            Me.DPLCustomerinfo.DataSource = ds.Tables(1)
            Me.DPLCustomerinfo.DataTextField = "CustomerName"
            Me.DPLCustomerinfo.DataValueField = "CustomerPKID"
            Me.DPLCustomerinfo.DataBind()
        Else
            Me.DPLCustomerinfo.DataSource = Nothing
            Me.DPLCustomerinfo.DataBind()
        End If

    End Sub
    Private Sub BindGrid()
        Total = 0
        Me.HiddenTotal.Value = 0
        Dim ds As DataSet = SqlHelper.ExecuteDataset(ConfigurationInfo.ConnectionString, "GetNeedPreconcieldByCustomerPKID", Me.DPLCustomerinfo.SelectedValue, Me.TxtEndDate.Text, Me.TxtStartDate.Text, StrConv(UserInfo.CurrentUserCHName, VbStrConv.SimplifiedChinese, 2052))
        If ds.Tables(0).Rows.Count > 0 Then
            Me.emptyinfo.Visible = False
            Me.GridView1.DataSource = ds.Tables(0)
            Me.GridView1.DataKeyNames = New String() {"PKID"}
            Me.GridView1.DataBind()
        Else
            Me.emptyinfo.Visible = True
            Me.GridView1.DataSource = Nothing
            Me.GridView1.DataBind()
        End If
    End Sub

    Protected Sub TxtEndDate_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles TxtEndDate.TextChanged
        If Me.TxtStartDate.Text <> String.Empty AndAlso Me.TxtEndDate.Text <> String.Empty Then
            BindDPL()
            Me.LbReconMonth.Text = CDate(Me.TxtStartDate.Text).Month.ToString
            If Not Me.DPLCustomerinfo.DataSource Is Nothing Then
                Me.emptyinfo.Visible = False
                BindGrid()
                BindGrid2()
            Else
                Me.emptyinfo.Visible = True
            End If
        End If
    End Sub
    Protected Sub TxtStartDate_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles TxtStartDate.TextChanged
        If Me.TxtStartDate.Text <> String.Empty AndAlso Me.TxtEndDate.Text <> String.Empty Then
            BindDPL()
            Me.LbReconMonth.Text = CDate(Me.TxtStartDate.Text).Month.ToString
            If Not Me.DPLCustomerinfo.DataSource Is Nothing Then
                BindGrid()
                BindGrid2()
            End If
        End If
    End Sub

    Protected Sub DPLCustomerinfo_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles DPLCustomerinfo.SelectedIndexChanged
        BindGrid()
    End Sub
    Dim Total As Double = 0
    Dim total2 As Double = 0
    Protected Sub GridView1_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GridView1.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            Dim mPKID As Integer = CInt(GridView1.DataKeys(e.Row.RowIndex).Value)
            Dim HLDetail As HyperLink = CType(e.Row.FindControl("HLDetail"), HyperLink)
            Dim DocUniqueID As String = CType(e.Row.FindControl("lblDocUniqueID"), Label).Text
            Dim ReturnURL As String = "../Quotation/QuotationDetail.aspx?" & Global_asax.QUERY_APPLICANTIDX & "=" + mPKID.ToString
            If (DocUniqueID <> String.Empty AndAlso DocUniqueID <> Guid.Empty.ToString) Then
                ReturnURL = ReturnURL + "&" + Global_asax.QUERY_DOCUNIQUEID + "=" + DocUniqueID
            End If
            HLDetail.NavigateUrl = ReturnURL
            Total += CDbl(e.Row.Cells(7).Text)
            total2 += CDbl(e.Row.Cells(8).Text)
            Me.HiddenTotal.Value = Total
        ElseIf e.Row.RowType = DataControlRowType.Footer Then
            e.Row.Cells(7).ForeColor = System.Drawing.Color.Red
            e.Row.Cells(7).Text = "合計：" + Total.ToString
            e.Row.Cells(8).Text = "合計：" + total2.ToString
        End If
    End Sub
    Protected Sub LinkGetPre_Click(ByVal sender As Object, ByVal e As EventArgs) Handles LinkGetPre.Click
        Dim rowcount As Integer = Me.GridView1.Rows.Count
        Dim quotationpkids As String = String.Empty
        If rowcount > 0 Then
            For i As Integer = 0 To rowcount - 1
                Dim mdatagrid As GridViewRow = GridView1.Rows(i)
                If CType(mdatagrid.FindControl("ChkSelect"), CheckBox).Checked Then
                    Dim mpkid As Integer = Convert.ToInt32(Me.GridView1.DataKeys(mdatagrid.RowIndex).Value)
                    quotationpkids += mpkid.ToString + ","
                End If
            Next
            If quotationpkids.Length > 0 Then
                Dim doc As Aspose.Words.Document = New Aspose.Words.Document(Server.MapPath("~") + "\UploadFiles\對帳單.doc")
                Dim builder As Aspose.Words.DocumentBuilder = New Aspose.Words.DocumentBuilder(doc) '只有是2003 的模板文件才可以
                builder.RowFormat.Alignment = RowAlignment.Center
                quotationpkids = quotationpkids.Substring(0, quotationpkids.Length - 1)
                Dim SearchCondition As String = " PKID IN (" + quotationpkids + ")"
                Dim ds As DataSet = SqlHelper.ExecuteDataset(ConfigurationInfo.ConnectionString, "View_Reconcield_GetInfoBySearchcondition", SearchCondition)
                If ds.Tables(0).Rows.Count > 0 Then
                    Dim dt As DataTable = ds.Tables(0)
                    Dim widthList As List(Of Double) = New List(Of Double)
                    builder.MoveToBookmark("table")    '开始添加值  '只有是2003 的模板文件才可以 2007 類型的移到該書籤添加沒有生成table 
                    Dim pagewidth As Double = builder.PageSetup.PageWidth
                    Dim width() As Double = New Double() {pagewidth * 0.066, pagewidth * 0.128, pagewidth * 0.106, pagewidth * 0.083, pagewidth * 0.117, pagewidth * 0.133, pagewidth * 0.167, pagewidth * 0.1, pagewidth * 0.096}

                    builder.StartTable()
                    Dim header() As String = New String() {"序号", "报价单号", "申请日期", "申请人", "测试单号", "样品名称", "测试项目", "测试金额 （RMB）", "备  注"}
                    For k As Integer = 0 To 8
                        builder.InsertCell()
                        builder.CellFormat.Borders.LineStyle = LineStyle.Single
                        builder.CellFormat.Borders.Color = System.Drawing.Color.Black
                        builder.CellFormat.Width = width(k)
                        builder.Font.Size = 10
                        builder.Font.Name = "Simsun"
                        builder.Font.Bold = False
                        builder.CellFormat.HorizontalMerge = CellMerge.None

                        builder.CellFormat.VerticalMerge = Aspose.Words.Tables.CellMerge.None
                        builder.CellFormat.VerticalAlignment = CellVerticalAlignment.Center
                        builder.ParagraphFormat.Alignment = ParagraphAlignment.Center
                        builder.Write(header(k))

                    Next
                    builder.EndRow()
                    builder.EndTable()

                    builder.StartTable()
                    builder.ParagraphFormat.Alignment = ParagraphAlignment.Center
                                       For i As Integer = 0 To dt.Rows.Count - 1

                        For j As Integer = 0 To dt.Columns.Count - 1
                            builder.InsertCell()
                            builder.CellFormat.Borders.LineStyle = LineStyle.Single
                            builder.CellFormat.Borders.Color = System.Drawing.Color.Black

                            builder.CellFormat.Width = width(j)
                            builder.Font.Size = 10
                            builder.Font.Name = "Simsun"
                            builder.Font.Bold = False
                            builder.CellFormat.VerticalMerge = Aspose.Words.Tables.CellMerge.None

                            builder.ParagraphFormat.Alignment = ParagraphAlignment.Center

                            builder.Write(dt.Rows(i)(j).ToString())
                        Next
                        builder.EndRow()
                    Next
                    builder.EndTable()
                    doc.Range.Bookmarks("table").Text = ""

                    Dim mBookMarks As BookmarkCollection = doc.Range.Bookmarks
                    For Each mBookMark As Bookmark In mBookMarks
                        Dim bookname As String = mBookMark.Name
                        Dim cusinfo As CustomersInfo = CustomersDAL.GetInfoByPKID(CInt(Me.DPLCustomerinfo.SelectedItem.Value))
                        Dim quoterinfo As ContactInfo = ContactDAL.GetInfoByContactName(cusinfo.PersonInCharge)
                        Dim mycus As CustomersInfo = CustomersDAL.GetInfoByPKID(quoterinfo.CusTomerPKID)

                        If bookname = "QuoterCompany" Then
                            doc.Range.Bookmarks(bookname).Text = mycus.CustomerName
                        ElseIf bookname = "AccountName" Then
                            doc.Range.Bookmarks(bookname).Text = mycus.AccountName
                        ElseIf bookname = "BankName" Then
                            doc.Range.Bookmarks(bookname).Text = mycus.Bank
                        ElseIf bookname = "BankNo" Then
                            doc.Range.Bookmarks(bookname).Text = mycus.BankAccount
                        ElseIf bookname = "signdate" Then
                            doc.Range.Bookmarks(bookname).Text = DateTime.Now.ToShortDateString

                        Else
                            Dim dt2 As DataTable = ds.Tables(1)
                            If dt2.Columns().Contains(bookname) Then
                                doc.Range.Bookmarks(bookname).Text = dt2.Rows(0)(bookname).ToString()
                            End If
                        End If

                    Next

                    builder.StartTable()


                    builder.InsertCell()
                    builder.CellFormat.Borders.LineStyle = LineStyle.Single
                    builder.CellFormat.Borders.Color = System.Drawing.Color.Black
                    builder.CellFormat.Width = pagewidth
                    builder.Font.Size = 10
                    builder.Font.Name = "Simsun"
                    builder.Font.Bold = False
                    builder.CellFormat.VerticalMerge = Aspose.Words.Tables.CellMerge.None
                    builder.CellFormat.VerticalAlignment = CellVerticalAlignment.Center
                    builder.ParagraphFormat.Alignment = ParagraphAlignment.Left

                    Dim ds2 As DataSet = SqlHelper.ExecuteDataset(ConfigurationInfo.ConnectionString, "Quotation_GetSumMoneyBySearchCondition", SearchCondition)
                    If ds2.Tables(0).Rows.Count > 0 Then
                        Dim totalmoney As Double = CDbl(ds2.Tables(0).Rows(0).Item("TotalMoney"))
                        builder.Write("合计:" + FormatNumber(totalmoney.ToString("0.00"), 2, -1, 0, -1) + " RMB")
                    End If
                    builder.EndRow()
                    builder.EndTable()


                    doc.Save(Server.MapPath("~") + "\UploadFiles\payment statement.doc")
                    Response.Redirect("..\UploadFiles\payment statement.doc")
                End If

            End If
        End If





        'Dim rowcount As Integer = Me.GridView1.Rows.Count
        'Dim quotationpkids As String = String.Empty
        'If rowcount > 0 Then
        '    For i As Integer = 0 To rowcount - 1
        '        Dim mdatagrid As GridViewRow = GridView1.Rows(i)
        '        If CType(mdatagrid.FindControl("ChkSelect"), CheckBox).Checked Then
        '            Dim mpkid As Integer = Convert.ToInt32(Me.GridView1.DataKeys(mdatagrid.RowIndex).Value)
        '            quotationpkids += mpkid.ToString + ","
        '        End If
        '    Next
        '    If quotationpkids.Length > 0 Then
        '        quotationpkids = quotationpkids.Substring(0, quotationpkids.Length - 1)
        '        Dim SearchCondition As String = " PKID IN (" + quotationpkids + ")"
        '        Dim report As CrystalReport2
        '        Dim myDS As New DataSet2()
        '        myDS = QuotationDAL.TransForReconcield(SearchCondition)
        '        report = New CrystalReport2()
        '        report.SetDataSource(myDS)
        '        Dim cusinfo As CustomersInfo = CustomersDAL.GetInfoByPKID(CInt(Me.DPLCustomerinfo.SelectedItem.Value))
        '        Dim quoterinfo As ContactInfo = ContactDAL.GetInfoByContactName(cusinfo.PersonInCharge)
        '        Dim mycus As CustomersInfo = CustomersDAL.GetInfoByPKID(quoterinfo.CusTomerPKID)

        '        report.SetParameterValue("QuoterCompany", mycus.CustomerName)
        '        report.SetParameterValue("BankNO", mycus.BankAccount)
        '        report.SetParameterValue("BankName", mycus.Bank)
        '        Dim ds As DataSet = SqlHelper.ExecuteDataset(ConfigurationInfo.ConnectionString, "Quotation_GetSumMoneyBySearchCondition", SearchCondition)
        '        If ds.Tables(0).Rows.Count > 0 Then
        '            Dim totalmoney As Double = CDbl(ds.Tables(0).Rows(0).Item("TotalMoney"))
        '            report.SetParameterValue("TotalMoney", FormatNumber(totalmoney.ToString("0.00"), 2, -1, 0, -1))


        '        End If



        '        Response.ClearContent()
        '        Response.ClearHeaders()
        '        Response.ContentType = "application/xls"
        '        Dim temp As String = String.Format("attachment; filename={0}.xls", System.Web.HttpUtility.UrlEncode(Me.DPLCustomerinfo.SelectedItem.Text + DateTime.Now.ToString("yyMMdd") + "對帳單", System.Text.Encoding.UTF8))
        '        Response.AppendHeader("Content-Disposition", temp)

        '        Dim data As Stream
        '        Dim datastring As String = String.Empty

        '        data = report.ExportToStream(CrystalDecisions.Shared.ExportFormatType.ExcelRecord)
        '        Dim buffer() As Byte = New Byte(data.Length - 1) {}
        '        data.Read(buffer, 0, CInt(data.Length))
        '        Response.BinaryWrite(buffer)

        '        data.Flush()
        '        data.Close()
        '        Response.Flush()




        '    End If
        'End If
    End Sub

    Protected Sub LinkFinishPre_Click(ByVal sender As Object, ByVal e As EventArgs) Handles LinkFinishPre.Click
        If Me.FileUpload1.HasFile Then
            Dim filepath As String = String.Format("{0}\{1}\", Server.MapPath(Request.ApplicationPath), "CusReconcield")
            Dim filename As String = DateTime.Now.ToString("yyMMddhhmmss") + Path.GetExtension(FileUpload1.FileName)
            Me.FileUpload1.SaveAs(filepath + filename)

            Dim CurReconcieldInfo As ReconcieldInfo = New ReconcieldInfo()
            CurReconcieldInfo.PKID = 0
            CurReconcieldInfo.CustomerName = Me.DPLCustomerinfo.SelectedItem.Text
            CurReconcieldInfo.CustomerPKID = Me.DPLCustomerinfo.SelectedValue
            CurReconcieldInfo.ReconcieldMonth = Me.LbReconMonth.Text
            CurReconcieldInfo.ReconDate = DateTime.Now
            CurReconcieldInfo.ReconPersonID = UserInfo.CurrentUserID
            CurReconcieldInfo.RecordDeleted = 0
            CurReconcieldInfo.FileRealName = FileUpload1.FileName
            CurReconcieldInfo.FileClientName = filename

            Dim CurRecondal As ReconcieldDAL = New ReconcieldDAL(CurReconcieldInfo)
            CurRecondal.Save()

            Dim rowcount As Integer = Me.GridView1.Rows.Count
            Dim quotationpkids As String = String.Empty
            If rowcount > 0 Then
                For i As Integer = 0 To rowcount - 1
                    Dim mdatagrid As GridViewRow = GridView1.Rows(i)
                    If CType(mdatagrid.FindControl("ChkSelect"), CheckBox).Checked Then
                        Dim mpkid As Integer = Convert.ToInt32(Me.GridView1.DataKeys(mdatagrid.RowIndex).Value)
                        QuotationDAL.UpdateFinishTimeByPKID(mpkid)
                    End If
                Next
                BindGrid()
            End If
            BindGrid2()
        Else
            Page.RegisterStartupScript("xxx", "<script>alert('請先上傳客戶回傳對帳單！')</script>")
        End If
    End Sub


    Protected Sub GridView2_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GridView2.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then



        End If
    End Sub
    Private Sub BindGrid2()
        Dim ds As DataSet = SqlHelper.ExecuteDataset(ConfigurationInfo.ConnectionString, "ReconcieldGetdsByCustomerPKID", Me.DPLCustomerinfo.SelectedValue)
        If ds.Tables(0).Rows.Count > 0 Then
            Me.enmty2.Visible = False
            Me.GridView2.DataSource = ds
            Me.GridView2.DataBind()
        Else
            Me.enmty2.Visible = True
            Me.GridView2.DataSource = Nothing
            Me.GridView2.DataBind()
        End If
    End Sub
    Protected Sub GridView2_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GridView2.RowCommand
        Select Case e.CommandName
            Case "Downfile"
                Dim DateRow As GridViewRow = CType(CType(e.CommandSource, Control).Parent.Parent, GridViewRow)
                Dim LbFileClientName As Label = CType(DateRow.Cells(4).FindControl("LbFileClientName"), Label)
                Dim LinkCusFile As LinkButton = CType(DateRow.Cells(4).FindControl("LinkCusFile"), LinkButton)

                Dim filename As String = LbFileClientName.Text
                Dim filepath As String = String.Format("{0}\{1}\{2}", Server.MapPath(Request.ApplicationPath), "CusReconcield", filename)
                Dim iStream As System.IO.Stream
                iStream = New System.IO.FileStream(filepath, System.IO.FileMode.Open, _
                                                    IO.FileAccess.Read, IO.FileShare.Read)
                FileDownload(LinkCusFile.Text, iStream.Length, iStream)
        End Select
    End Sub
    Private Sub FileDownload(ByVal strFileName As String, ByVal FileSize As Double, ByVal iStream As Stream)
        If strFileName <> "" Then
            With Page.Response
                .Clear()
                .ClearHeaders()
                .Buffer = False
                .ContentType = "application/octet-stream"""
                .ContentEncoding = System.Text.Encoding.GetEncoding("UTF-8")

                Page.Response.AddHeader("content-disposition", "attachment;filename=" & HttpUtility.UrlEncode(strFileName, System.Text.Encoding.UTF8))
                Response.AppendHeader("Content-Length", FileSize.ToString())
                Dim buffer(10000) As Byte

                Dim length As Integer

                Dim dataToRead As Long

                Try
                    dataToRead = iStream.Length

                    While dataToRead > 0
                        If Response.IsClientConnected Then
                            length = iStream.Read(buffer, 0, 10000)

                            Response.OutputStream.Write(buffer, 0, length)

                            Response.Flush() ' Clear the buffer

                            ReDim buffer(10000)
                            dataToRead = dataToRead - length
                        Else
                            dataToRead = -1
                        End If
                    End While

                Catch ex As Exception
                    Response.Write("Error : " & ex.Message)
                Finally
                    If IsNothing(iStream) = False Then
                        iStream.Close()
                    End If
                End Try

                ' .Flush()
                .End()

            End With
        End If
    End Sub
End Class