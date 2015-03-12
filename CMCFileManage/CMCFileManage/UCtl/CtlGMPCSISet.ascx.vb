Imports System.Data.SqlClient
Imports System.Configuration
Imports System.IO
Imports CommonData.BusinessLayer
Imports System.Text
Imports System.Drawing

Public Class CtlGMPCSISet
    Inherits System.Web.UI.UserControl

#Region " Web Form 設計工具產生的程式碼 "

    '此為 Web Form 設計工具所需的呼叫。
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents txtStartDate As System.Web.UI.WebControls.TextBox
    Protected WithEvents TxtNotice As System.Web.UI.WebControls.TextBox
    Protected WithEvents BtnConfirm As System.Web.UI.WebControls.Button
    Protected WithEvents FileUpload As System.Web.UI.HtmlControls.HtmlInputFile
    Protected WithEvents lblOrderDate As System.Web.UI.WebControls.Label
    Protected WithEvents LblStart As System.Web.UI.WebControls.Label
    Protected WithEvents LblEnd As System.Web.UI.WebControls.Label
    Protected WithEvents txtEndDate As System.Web.UI.WebControls.TextBox
    Protected WithEvents LblMsg As System.Web.UI.WebControls.Label
    Protected WithEvents LbSendMsg As System.Web.UI.WebControls.Label
    Protected WithEvents lblCSITime As System.Web.UI.WebControls.Label
    Protected WithEvents BtnUpLoad As System.Web.UI.WebControls.LinkButton
    Protected WithEvents DLLabList As System.Web.UI.WebControls.DropDownList
    Protected WithEvents Label1 As System.Web.UI.WebControls.Label
    Protected WithEvents lblDept As System.Web.UI.WebControls.Label
    Protected WithEvents Label2 As System.Web.UI.WebControls.Label
    Protected WithEvents TableOutDate As System.Web.UI.HtmlControls.HtmlTable
    Protected WithEvents ImgSend As System.Web.UI.WebControls.LinkButton
    Protected WithEvents DList As System.Web.UI.WebControls.DataList
    Protected WithEvents DataGrid1 As System.Web.UI.WebControls.DataGrid
    Protected WithEvents PagerControl1 As myControl.PagerControl
    Protected WithEvents CCEmail As System.Web.UI.HtmlControls.HtmlInputText
    'Protected WithEvents CheckBoxCc As System.Web.UI.WebControls.CheckBox
    Protected WithEvents txtCSITime As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents LblNotice As System.Web.UI.WebControls.Label
    Protected WithEvents notice As System.Web.UI.HtmlControls.HtmlTableRow

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
    Private oBook As New C1.C1Excel.C1XLBook
    Private oSheet As C1.C1Excel.XLSheet
    Private oStyle As New C1.C1Excel.XLStyle(oBook)
    Private sFile As String, sTemplate As String
    Private Const HIDE_PKID As String = "ViewState:PKID"
    Private Const HIDE_ReturnSelectedDeptIndex As String = "View:ReturnSelectedDeptIndex"
    Private Const HIDE_ReturnSelectedDeptName As String = "View:ReturnSelectedDeptName"
    Private Const HIDE_SORTFIELD As String = "ViewState:SortField"
    Private Const HIDE_SortOrder As String = "ViewState:SortOrder"
#End Region

#Region "Properties"

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

    Private Property PKID() As Integer
        Get
            If ViewState(HIDE_PKID) Is Nothing Then
                Return 0
            End If
            Return Convert.ToInt32(ViewState(HIDE_PKID))
        End Get
        Set(ByVal Value As Integer)
            ViewState(HIDE_PKID) = Value
        End Set
    End Property


    Private Property ReturnSelectedDeptIndex() As Integer
        Get
            If ViewState(HIDE_ReturnSelectedDeptIndex) Is Nothing Then
                ViewState(HIDE_ReturnSelectedDeptIndex) = 0
            End If
            Return Convert.ToInt32(ViewState(HIDE_ReturnSelectedDeptIndex))
        End Get
        Set(ByVal Value As Integer)
            ViewState(HIDE_ReturnSelectedDeptIndex) = Value
        End Set
    End Property '返回當前選中的單位的索引號

    Private Property ReturnSelectedDeptName() As String
        Get
            If ViewState(HIDE_ReturnSelectedDeptIndex) Is Nothing Then
                ViewState(HIDE_ReturnSelectedDeptName) = String.Empty
            End If
            Return Convert.ToString(ViewState(HIDE_ReturnSelectedDeptName))
        End Get
        Set(ByVal Value As String)
            ViewState(HIDE_ReturnSelectedDeptName) = Value
        End Set
    End Property '返回當前選中的單位
    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' 排序字段
    ''' </summary>
    ''' <value></value>
    ''' <remarks>
    ''' </remarks>
    ''' -----------------------------------------------------------------------------
    Private Property SortField() As String
        Get
            If ViewState(HIDE_SORTFIELD) Is Nothing Then
                ViewState(HIDE_SORTFIELD) = "ResultPKID"
                ViewState(HIDE_SortOrder) = "DESC"
            End If
            Return ViewState(HIDE_SORTFIELD).ToString
        End Get
        Set(ByVal Value As String)
            ViewState(HIDE_SORTFIELD) = Value
        End Set
    End Property

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' 排序方式
    ''' </summary>
    ''' <value></value>
    ''' <remarks>
    ''' </remarks>
    ''' -----------------------------------------------------------------------------
    Private Property SortOrder() As String
        Get
            If ViewState(HIDE_SortOrder) Is Nothing Then
                ViewState(HIDE_SortOrder) = "ASC"
            Else
            End If
            Return ViewState(HIDE_SortOrder).ToString.Trim
        End Get
        Set(ByVal Value As String)
            ViewState(HIDE_SortOrder) = Value
        End Set
    End Property
#End Region

#Region "Self Define Sub/Function"

    Private Sub BindControlText()
        Dim Last As GEPCSI_Period = GEPCSI_Period.GetLastPeriod
        If Last Is Nothing Then
            'CSITime = 1
            Me.txtCSITime.Value = 1
            Me.txtStartDate.Attributes.Add("onclick", "javascript:WdatePicker({startDate:'%y-%M-01',dateFmt:'yyyy-MM-dd',alwaysUseStartDate:true});")
            Me.txtEndDate.Attributes.Add("onclick", "javascript:WdatePicker({startDate:'%y-%M-01',dateFmt:'yyyy-MM-dd',alwaysUseStartDate:true});")

        ElseIf Last.StartDate <= FormatDateTime(Date.Now, DateFormat.ShortDate) AndAlso Last.EndDate >= FormatDateTime(Date.Now, DateFormat.ShortDate) Then
            Me.txtCSITime.Value = Last.CSITime
            Me.txtStartDate.Text = Last.StartDate
            Me.txtEndDate.Text = Last.EndDate
            Me.TxtNotice.Text = Last.Notice
            Me.BtnConfirm.Visible = False
            Me.DList.SelectedIndex = 0
            BindDataList()
        Else
            Me.TableOutDate.Visible = True
            ' CSITime = Last.CSITime + 1
            Me.txtCSITime.Value = Last.CSITime + 1
            Me.txtStartDate.Attributes.Add("onclick", "javascript:WdatePicker({startDate:'%y-%M-01',dateFmt:'yyyy-MM-dd',alwaysUseStartDate:true});")
            Me.txtEndDate.Attributes.Add("onclick", "javascript:WdatePicker({startDate:'%y-%M-01',dateFmt:'yyyy-MM-dd',alwaysUseStartDate:true});")

        End If
        Me.lblCSITime.Text = "第" + Me.txtCSITime.Value + "次調查"
    End Sub

    Private Sub BindDropData()
        Dim Alist As ArrayList = GEPCSI_Dept.GetAllDepeInfo()
        If Not Alist Is Nothing Then
            Me.DLLabList.DataSource = Alist
            Me.DLLabList.DataTextField = "Text"
            Me.DLLabList.DataValueField = "Value"
            Me.DLLabList.DataBind()
        End If
    End Sub

    Private Sub BindDataList()
        Dim SearchString As String = " CSITime=" + Me.txtCSITime.Value
        Dim Alist As ArrayList = GEPCSI_Result.GetImportDeptInfo(SearchString)

        If Not Alist Is Nothing Then
            Me.DList.DataSource = Alist
            Me.DList.DataBind()
            If ReturnSelectedDeptIndex = 0 Then
                ReturnSelectedDeptIndex = Alist.Item(0).Value
                ReturnSelectedDeptName() = Alist.Item(0).Text
            End If
            BindDataGrid()
        End If
    End Sub
    '根據當前選中的實驗室綁定實驗室被調查的對象
    Private Sub BindDataGrid()
        Dim SeatchCondition As String = " CSITime=" + Me.txtCSITime.Value + " AND DeptPKID=" + ReturnSelectedDeptIndex.ToString
        Dim SelectDeptCollection As GEPCSI_ResultCollection = GEPCSI_Result.LoadPageInfoBySearchcondition(SeatchCondition, "GEPCSI_Result", Me.SortField + " " + Me.SortOrder, "ResultPKID", Me.PageIndex, Me.PageSize)
        Me.PagerControl1.TotalRecords = GEPCSI_Result.LoadDataCount("GEPCSI_Result", "ResultPKID", SeatchCondition)
        Me.DataGrid1.DataSource = SelectDeptCollection
        Me.DataGrid1.DataKeyField = "ResultPKID"
        Me.PagerControl1.Visible = True
        Me.DataGrid1.DataBind()
        Me.CCEmail.Value = "GMP-MIC/CEN/FOXCONN"
    End Sub

    Private Sub RegisterScript()

        ' Me.CheckBoxCc.Attributes.Add("onclick", "DisPlayInput(this,'" + Me.CCEmail.ClientID + "')")
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
        Dim myconn As SqlConnection = New SqlConnection(ConfigurationInfo.ConnectionString)
        myconn.Open()
        Dim myTrans As SqlTransaction
        myTrans = myconn.BeginTransaction()
        Try
            If File.Exists(strFileNameOnServer) Then
                File.Delete(strFileNameOnServer)
            End If
            Me.FileUpload.PostedFile.SaveAs(strFileNameOnServer)
            oBook.Load(strFileNameOnServer)
            Dim mResult As New GEPCSI_Result
            mResult.ResultPKID = 0
            mResult.CSITime = Me.txtCSITime.Value
            mResult.DeptPKID = Me.DLLabList.SelectedItem.Value.Trim
            mResult.DeptName = Me.DLLabList.SelectedItem.Text.Trim
            mResult.IsSubmited = 0
            Dim mycmd As New SqlCommand("GEPCSI_Result_Insert", myconn)
            mycmd.Transaction = myTrans
            mycmd.CommandType = CommandType.StoredProcedure
            PrePareParameter(mycmd)
            For i = 0 To oBook.Sheets.Count - 1
                oSheet = oBook.Sheets(i)
                For j = 1 To oSheet.Rows.Count - 1

                    Row = j
                    If oSheet(Row, 0) Is Nothing Then
                        mResult.AcceptGroup = String.Empty
                    Else
                        mResult.AcceptGroup = oSheet(Row, 0).Value.ToString.Trim
                    End If

                    If oSheet(Row, 1) Is Nothing Then
                        mResult.AcceptDivision = String.Empty
                    Else
                        mResult.AcceptDivision = oSheet(Row, 1).Value.ToString.Trim
                    End If
                    If oSheet(Row, 2) Is Nothing Then
                        mResult.AcceptDept = String.Empty
                    Else
                        mResult.AcceptDept = oSheet(Row, 2).Value.ToString.Trim
                    End If
                    If oSheet(Row, 3) Is Nothing Then
                        mResult.AcceptMan = String.Empty
                    Else
                        mResult.AcceptMan = oSheet(Row, 3).Value.ToString.Trim
                    End If

                    If oSheet(Row, 4) Is Nothing Then
                        mResult.AcceptExt = String.Empty
                    Else
                        mResult.AcceptExt = oSheet(Row, 4).Value.ToString.Trim
                    End If
                    If oSheet(Row, 5) Is Nothing Then
                        mResult.AcceptEmail = String.Empty
                    Else
                        mResult.AcceptEmail = oSheet(Row, 5).Value.ToString.Trim
                    End If
                    SetPareParameterValue(mycmd, mResult)
                    If mResult.AcceptEmail <> String.Empty Then
                        mycmd.ExecuteNonQuery()
                    End If
                Next
            Next
            myTrans.Commit()
            Me.LblMsg.Text = "導入數據庫成功！"
            Me.LblMsg.ForeColor = Color.Blue
            '  Me.DList.SelectedIndex = mResult.DeptPKID - 1
            ReturnSelectedDeptIndex = mResult.DeptPKID
            ReturnSelectedDeptName = mResult.DeptName
            BindDataList()
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
        mycmd.Parameters.Add(New SqlParameter("@ResultPKID", SqlDbType.Int, 4))
        mycmd.Parameters.Add(New SqlParameter("@CSITime", SqlDbType.Int, 4))
        mycmd.Parameters.Add(New SqlParameter("@DeptPKID", SqlDbType.Int, 4))
        mycmd.Parameters.Add(New SqlParameter("@DeptName", SqlDbType.NVarChar))
        mycmd.Parameters.Add(New SqlParameter("@AcceptGroup", SqlDbType.NVarChar))
        mycmd.Parameters.Add(New SqlParameter("@AcceptDivision", SqlDbType.NVarChar))
        mycmd.Parameters.Add(New SqlParameter("@AcceptDept", SqlDbType.NVarChar))
        mycmd.Parameters.Add(New SqlParameter("@AcceptMan", SqlDbType.NVarChar))
        mycmd.Parameters.Add(New SqlParameter("@AcceptExt", SqlDbType.Int, 4))
        mycmd.Parameters.Add(New SqlParameter("@AcceptEmail", SqlDbType.NVarChar))
        mycmd.Parameters.Add(New SqlParameter("@SubmitGroup", SqlDbType.NVarChar))
        mycmd.Parameters.Add(New SqlParameter("@SubmitDivision", SqlDbType.NVarChar))
        mycmd.Parameters.Add(New SqlParameter("@SubmitDept", SqlDbType.NVarChar))
        mycmd.Parameters.Add(New SqlParameter("@SubmitMan", SqlDbType.NVarChar))
        mycmd.Parameters.Add(New SqlParameter("@SubmitExt", SqlDbType.Int, 4))
        mycmd.Parameters.Add(New SqlParameter("@SubmitEmail", SqlDbType.NVarChar))
        mycmd.Parameters.Add(New SqlParameter("@SendTime", SqlDbType.DateTime))
        mycmd.Parameters.Add(New SqlParameter("@SubmitTime", SqlDbType.DateTime))
        mycmd.Parameters.Add(New SqlParameter("@IsSubmited", SqlDbType.Int, 4))
        mycmd.Parameters.Add(New SqlParameter("@Remark", SqlDbType.NVarChar))
        mycmd.Parameters.Add(New SqlParameter("@Extend1", SqlDbType.NVarChar))
        mycmd.Parameters.Add(New SqlParameter("@Extend2", SqlDbType.NVarChar))
        mycmd.Parameters.Add(New SqlParameter("@Extend3", SqlDbType.NVarChar))
        mycmd.Parameters.Add(New SqlParameter("@Extend4", SqlDbType.NVarChar))
        mycmd.Parameters.Add(New SqlParameter("@Extend5", SqlDbType.NVarChar))

    End Sub

    ' 設置參數的值
    Private Sub SetPareParameterValue(ByVal mycmd As SqlCommand, ByVal mResult As GEPCSI_Result)
        mycmd.Parameters("@ResultPKID").Direction = ParameterDirection.Output
        mycmd.Parameters("@CSITime").Value = mResult.CSITime
        mycmd.Parameters("@DeptPKID").Value = mResult.DeptPKID
        mycmd.Parameters("@DeptName").Value = mResult.DeptName
        mycmd.Parameters("@AcceptGroup").Value = mResult.AcceptGroup
        mycmd.Parameters("@AcceptDivision").Value = mResult.AcceptDivision
        mycmd.Parameters("@AcceptDept").Value = mResult.AcceptDept
        mycmd.Parameters("@AcceptMan").Value = mResult.AcceptMan
        mycmd.Parameters("@AcceptExt").Value = mResult.AcceptExt
        mycmd.Parameters("@AcceptEmail").Value = mResult.AcceptEmail
        mycmd.Parameters("@SubmitGroup").Value = mResult.SubmitGroup
        mycmd.Parameters("@SubmitDivision").Value = mResult.SubmitDivision
        mycmd.Parameters("@SubmitDept").Value = mResult.SubmitDept
        mycmd.Parameters("@SubmitMan").Value = mResult.SubmitMan
        mycmd.Parameters("@SubmitExt").Value = mResult.SubmitExt
        mycmd.Parameters("@SubmitEmail").Value = mResult.SubmitEmail
        mycmd.Parameters("@IsSubmited").Value = mResult.IsSubmited
        mycmd.Parameters("@SendTime").Value = mResult.SendTime
        mycmd.Parameters("@SubmitTime").Value = mResult.SubmitTime
        mycmd.Parameters("@Remark").Value = mResult.Remark
        mycmd.Parameters("@extend1").Value = mResult.Extend1
        mycmd.Parameters("@extend2").Value = mResult.Extend2
        mycmd.Parameters("@extend3").Value = mResult.Extend3
        mycmd.Parameters("@extend4").Value = mResult.Extend4
        mycmd.Parameters("@extend5").Value = mResult.Extend5
    End Sub

#End Region

#Region "Button Events"

    Private Sub BtnConfirm_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnConfirm.Click
        If VerifyInput() Then
            Me.BtnConfirm.Enabled = False
            Dim mPeriod As New GEPCSI_Period
            mPeriod.StartDate = Convert.ToDateTime(Me.txtStartDate.Text.Trim)
            mPeriod.EndDate = Convert.ToDateTime(Me.txtEndDate.Text.Trim)
            mPeriod.Notice = Me.TxtNotice.Text.Trim
            mPeriod.CSITime = Convert.ToInt32(Me.txtCSITime.Value())
            mPeriod.Save()
            BindControlText()
            Page.ClientScript.RegisterStartupScript(MyBase.GetType(), "xxx", "<script language='javascript' defer>alert('設定成功！');</script>")

        End If

    End Sub
    Private Sub BtnUpLoad_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnUpLoad.Click
        InputResource()
    End Sub

    Private Sub ImgSend_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ImgSend.Click
        Dim i As Integer
        Dim SendResultPKID As String = String.Empty
        Dim MailCCList(0) As String
        MailCCList = Nothing
        'If CheckBoxCc.Checked Then
        '    MailCCList(0) = Me.CCEmail.Value
        'Else
        '    MailCCList = Nothing
        'End If
        Dim sendcount As Integer = 0
        Dim checkcount As Integer = 0
        For i = 0 To Me.DataGrid1.Items.Count - 1
            Dim item As DataGridItem = Me.DataGrid1.Items(i)
            Dim chk As CheckBox = CType(item.FindControl("chkDelete"), CheckBox)
            If chk.Checked Then
                checkcount += 1
                Dim MailSubject As String = "※檢測塑應中心{0}客戶滿意度調查表※  TO:{1}(先生/女士)"
                Dim MailBody As New StringBuilder
                MailBody.Append("<TABLE id='Table1'   width='800' border='0'>")
                MailBody.Append("<TR>")
                MailBody.Append("<TD align='center' style='FONT-WEIGHT: bold; FONT-SIZE: 15pt; COLOR: #ff3300; FONT-FAMILY: 標楷體' colSpan='2'>客戶滿意度調查</TD>")
                MailBody.Append("<TR>")
                MailBody.Append("<TD noWrap colSpan='2'>Dear{0}:</TD>")
                MailBody.Append("</TR>")
                MailBody.Append("<TR><TD></TD></TR>")
                MailBody.Append("<TR>")
                MailBody.Append("<TD noWrap colSpan='2'>&nbsp;&nbsp;&nbsp;&nbsp;非常感謝您在百忙中閱讀此郵件.</TD>")
                MailBody.Append("</TR>")
                MailBody.Append("<TR><TD></TD></TR>")
                MailBody.Append("<TR>")
                MailBody.Append("<TD noWrap colSpan='2'>&nbsp;&nbsp;&nbsp;&nbsp;檢測塑應中心(TPC)為了更好的服務于您,了解並滿足您的需求,")
                MailBody.Append("特展開客戶滿意度調查. </TD>")
                MailBody.Append("</TR>")
                MailBody.Append("<TR>")
                MailBody.Append("<TD noWrap colSpan='2'>&nbsp;&nbsp;&nbsp;&nbsp;檢測塑應中心真誠地希望聽到您的意見和心聲,煩請您抽空回覆,")
                MailBody.Append("再次感謝您的關注! </TD>")
                MailBody.Append("</TR>")
                MailBody.Append("<TR><TD></TD></TR>")
                MailBody.Append("<TR>")
                MailBody.Append("<TD noWrap colSpan='2'>&nbsp;&nbsp;&nbsp;&nbsp;煩請點擊以下鏈結進入:")
                MailBody.Append("<A style='FONT-SIZE: 12pt; COLOR: #ff3333; TEXT-DECORATION: none' href='" + Global_asax.UrlBase + "/default.aspx?PageType=satsur&DeptPKID={1}&ClientPKID={2}'>***點擊進入***</A>")
                MailBody.Append("</TR>")
                MailBody.Append("<TR><TD></TD></TR>")
                MailBody.Append("<TR>")
                MailBody.Append("<TD noWrap colspan='2' align='left'>")
                MailBody.Append("&nbsp;&nbsp;&nbsp;&nbsp;本郵件為系統自動發送郵件,請勿直接回復.</TD>")
                MailBody.Append("</TR>")
                MailBody.Append("<TR>")
                MailBody.Append("<TD noWrap colspan='2' align='left'>")
                MailBody.Append("&nbsp;&nbsp;&nbsp;&nbsp;如有任何疑問或不願意再次收到此類郵件,請聯繫以下窗口:</TD>")
                MailBody.Append("</TR>")
                MailBody.Append("<TR>")
                MailBody.Append("<TD noWrap colspan='2' align='left'>")
                MailBody.Append("&nbsp;&nbsp;&nbsp;&nbsp;XXX &nbsp;&nbsp;&nbsp;&nbsp;25339&nbsp;&nbsp;&nbsp;&nbsp;XXXX</TD>")
                MailBody.Append("</TR>")
                MailBody.Append("</TABLE>")
                Dim MailIDList(0) As String
                MailIDList(0) = DirectCast(item.FindControl("lblAcceptEmail"), Label).Text
                If Not MailIDList Is Nothing Then
                    Dim Vistor As String = DirectCast(item.FindControl("lblAcceptMan"), Label).Text
                    Dim ResultPKID As String = Me.DataGrid1.DataKeys(i).ToString
                    Dim RealMailSubject = String.Format(MailSubject, ReturnSelectedDeptName, Vistor)
                    Dim RealMailBody As String = String.Format(MailBody.ToString(), Vistor, ReturnSelectedDeptIndex, ResultPKID)
                    AddQCFileDetail.SendMail(MailIDList(0).ToString, RealMailSubject, RealMailBody)
                    sendcount += 1
                End If
                Dim mkIsSubmited As Integer = Convert.ToInt32(DirectCast(item.FindControl("lblIsSubmited"), Label).Text)
                If mkIsSubmited = 0 Then
                    SendResultPKID += Me.DataGrid1.DataKeys(i).ToString + ","
                End If
            End If

        Next
        If checkcount > 0 Then
            Me.LbSendMsg.Text = String.Format("選擇{0}份記錄，成功發送{1}份郵件", checkcount, sendcount)
            Me.LbSendMsg.ForeColor = Color.Green
        Else
            Me.LbSendMsg.Text = "未選擇任何記錄！"
            Me.LbSendMsg.ForeColor = Color.Red
        End If
        If SendResultPKID <> String.Empty Then
            SendResultPKID = "(" + SendResultPKID.Remove(SendResultPKID.LastIndexOf(","), 1) + ")"
            GEPCSI_Result.UpdateStatus(SendResultPKID)
        End If
        BindDataGrid()
    End Sub
#End Region

#Region "PagerControl Event"
    Private Sub PagerControl1_PageChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        BindDataGrid()
    End Sub
    Private Sub PagerControl1_PageSizeChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.PageIndex = 0
        BindDataGrid()
    End Sub
#End Region

#Region "DataList Events"
    Private Sub DList_ItemCommand(ByVal source As System.Object, ByVal e As System.Web.UI.WebControls.DataListCommandEventArgs) Handles DList.ItemCommand
        Select Case e.CommandName
            Case "SearchDeptName"

                If e.Item.ItemType = ListItemType.Item OrElse e.Item.ItemType = ListItemType.AlternatingItem Then
                    ReturnSelectedDeptIndex = Convert.ToInt32(e.CommandArgument)
                    Me.DList.SelectedIndex = e.Item.ItemIndex
                    Dim SelectedMachine As String = CType(Me.DList.SelectedItem.FindControl("linkDeptName"), LinkButton).Text
                    ReturnSelectedDeptName = SelectedMachine
                    BindDataList()
                End If
        End Select
    End Sub
#End Region

#Region "DataGrid Events"
    Private Sub DataGrid1_ItemCommand(ByVal source As System.Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles DataGrid1.ItemCommand
        Select Case e.CommandName
            Case "Delete"
                GEPCSI_Result.Delete(DataGrid1.DataKeys(e.Item.ItemIndex))
                BindDataGrid()
        End Select
    End Sub
    Private Sub DataGrid1_ItemDataBound(ByVal sender As System.Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs) Handles DataGrid1.ItemDataBound
        If e.Item.ItemType = ListItemType.Header Then
            Dim objCheckBox As CheckBox = CType(e.Item.FindControl("CheckAll"), CheckBox)
            objCheckBox.Attributes.Add("onclick", "return CheckChanged();")
        End If
        If e.Item.ItemType = ListItemType.AlternatingItem Or e.Item.ItemType = ListItemType.Item Then
            Dim mGEPCSI_Result As GEPCSI_Result = DirectCast(e.Item.DataItem, GEPCSI_Result)
            Dim mImgDelete As ImageButton = DirectCast(e.Item.FindControl("ImgDelete"), ImageButton)
            If mGEPCSI_Result.IsSubmited = 0 Then
                mImgDelete.Visible = True
                mImgDelete.Attributes.Add("onclick", "return confirm('請確認是否刪除這筆資料?');")
            End If
            CType(e.Item.FindControl("chkDelete"), CheckBox).Attributes.Add("onclick", "SelectRow(this);")

        End If
    End Sub

    Private Sub DataGrid1_SortCommand(ByVal source As System.Object, ByVal e As System.Web.UI.WebControls.DataGridSortCommandEventArgs) Handles DataGrid1.SortCommand
        Dim SortFieldName As String = e.SortExpression
        If SortFieldName <> String.Empty Then
            Me.SortField = SortFieldName
        End If
        If Me.SortOrder = "ASC" Then
            Me.SortOrder = "DESC"
        ElseIf Me.SortOrder = "DESC" Then
            Me.SortOrder = "ASC"
        Else
            Me.SortOrder = "DESC"
        End If
        BindDataGrid()
    End Sub

#End Region

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        '在這裡放置使用者程式碼以初始化網頁
        If Not IsPostBack Then
            Me.txtEndDate.Attributes.Add("ReadOnly", True)
            Me.txtStartDate.Attributes.Add("ReadOnly", True)
            BindControlText()
            BindDropData()
        End If
        RegisterScript()
    End Sub

    Private Function VerifyInput() As Boolean
        If Me.txtStartDate.Text = String.Empty OrElse Me.txtEndDate.Text = String.Empty Then
            Me.notice.Visible = True
            Me.LblNotice.Text = "請設定調查日期"
            Return False
        End If
        Return True
    End Function


End Class
