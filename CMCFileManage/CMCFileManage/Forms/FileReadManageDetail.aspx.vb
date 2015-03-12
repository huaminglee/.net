Imports System.Web.Services
Imports eWorkFlow.eFlowDoc
Imports Platform.eAuthorize

Partial Public Class FileReadManageDetail
    Inherits System.Web.UI.Page
    Implements IDocInfo

#Region "Const"
    Private Const _RequestType As String = "ViewState:Type"
    Private Const HIDE_APPLICANTIDX_KEY As String = "ViewState:PKID"
    Private Const HIDE_DOCUNIQUEID_KEY As String = "ViewState:DocUniqueID"
    Private ReadOnly HIDE_ParentID = "ViewState:ParentID"
    Private ReadOnly HIDE_ParentCategory = "ViewState:ParentCategory"
    Private ReadOnly HIDE_ParentSubCategory = "ViewState:ParentSubCategory"
#End Region
#Region "Properties"
    '當前文件惟一ID
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

    '流程控制文件ID
    Private Property DocUniqueID() As String
        Get
            If ViewState(HIDE_DOCUNIQUEID_KEY) Is Nothing Then
                Return String.Empty
            End If

            Return ViewState(HIDE_DOCUNIQUEID_KEY).ToString()
        End Get
        Set(ByVal Value As String)
            ViewState(HIDE_DOCUNIQUEID_KEY) = Value

        End Set
    End Property
    Private _FileReadInfo As FileReadManageInfo
    Private Property FileReadInfo() As FileReadManageInfo
        Get
            If _FileReadInfo Is Nothing Then
                If PKID <> 0 Then
                    _FileReadInfo = FileReadManageDAL.GetInfoByPKID(PKID)
                    DocUniqueID = _FileReadInfo.eFlowDocID.ToString
                    If Not ReadFileInfoDAL.GetInfoByparentid(PKID) Is Nothing Then
                        _ReadFileInfo = ReadFileInfoDAL.GetInfoByparentid(PKID)
                        readpkid = _ReadFileInfo.pkid
                    End If
                ElseIf DocUniqueID <> String.Empty AndAlso DocUniqueID <> Guid.Empty.ToString Then
                    _FileReadInfo = FileReadManageDAL.GetInfoByeFlowDocID(DocUniqueID)
                    PKID = _FileReadInfo.PKID
                    If Not ReadFileInfoDAL.GetInfoByparentid(PKID) Is Nothing Then
                        _ReadFileInfo = ReadFileInfoDAL.GetInfoByparentid(PKID)
                        readpkid = _ReadFileInfo.pkid
                    End If
                Else
                    _FileReadInfo = New FileReadManageInfo()
                End If
            End If
            Return _FileReadInfo
        End Get
        Set(ByVal value As FileReadManageInfo)
            _FileReadInfo = value
        End Set
    End Property
    Private _ReadFileInfo As ReadFileInfoInfo
    Private Property ReadFileInfo() As ReadFileInfoInfo
        Get
            If _ReadFileInfo Is Nothing Then
                If PKID <> 0 Then
                    If Not ReadFileInfoDAL.GetInfoByparentid(PKID) Is Nothing Then
                        _ReadFileInfo = ReadFileInfoDAL.GetInfoByparentid(PKID)

                    Else
                        _ReadFileInfo = New ReadFileInfoInfo()
                    End If
                Else
                    _ReadFileInfo = New ReadFileInfoInfo()
                End If
            End If
            Return _ReadFileInfo

        End Get
        Set(ByVal value As ReadFileInfoInfo)
            _ReadFileInfo = value
        End Set
    End Property
    Private Property readpkid() As Integer
        Get
            If Not ViewState("readpkid") Is Nothing Then
                Return Convert.ToInt32(ViewState("readpkid"))
            Else
                Return 0
            End If
        End Get
        Set(ByVal value As Integer)
            ViewState("readpkid") = value
        End Set
    End Property
#End Region
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            GetRequestParam()
            Dim dt2 As DataTable = QC_UserParameterDAL.GetInfoByCategory("Dept")
            If Not dt2 Is Nothing Then
                Me.DPLDept.DataSource = dt2
                Me.DPLDept.DataTextField = "ParameterText"
                Me.DPLDept.DataValueField = "ParameterText"
                Me.DPLDept.DataBind()
            End If
            ' BindDPL()
            Me.TXTApplydate.Attributes.Add("onclick", "javascript:WdatePicker({startDate:'%y-%M-01',dateFmt:'yyyy-MM-dd',alwaysUseStartDate:true});")
            BindControldata()
        End If
    End Sub
    Private Sub GetRequestParam()
        If Not Request.QueryString("pkid") Is Nothing Then
            PKID = Convert.ToInt32(Request.QueryString(Global_asax.QUERY_APPLICANTIDX))
            DocUniqueID = FileReadInfo.eFlowDocID.ToString

        End If
        If Not Request.QueryString("eFlowDocID") Is Nothing Then
            DocUniqueID = Request.QueryString("eFlowDocID").ToString
        End If
    End Sub
    'Private Sub BindDPL()
    '    Dim DT As DataTable = QC_UserParameterDAL.GetInfoByCategory("RT")
    '    If Not DT Is Nothing Then
    '        For i As Integer = 1 To Convert.ToInt32(Me.HiddenFileCount.Value)
    '            Dim curdpl As DropDownList = CType(Me.FindControl("DPLReadType" + i.ToString), DropDownList)
    '            curdpl.DataSource = DT
    '            curdpl.DataTextField = "ParameterText"
    '            curdpl.DataValueField = "ParameterText"
    '            curdpl.DataBind()
    '        Next
    '    End If

    'End Sub
    Private Sub BindControldata()
        If Not FileReadInfo Is Nothing Then
            If PKID <> 0 Then

                Dim filenums As Integer = 1
                Dim filesname As String()
                Dim filesbh As String()
                Dim filetypes As String()
                Dim readfor As String()
                Dim fenshu As String()
                Dim shuoming As String()

                Me.TXTApplydate.Text = FileReadInfo.ApplyTime
                Me.TxtApplyer.Text = FileReadInfo.ApplyUser
                Me.TXTzhuguan.Text = FileReadInfo.AduitUser
                Me.TXTUser.Text = FileReadInfo.UseUserOrDept
                Me.TXTRemark.Text = FileReadInfo.Remark
                Me.LBpizhun0.Text = FileReadInfo.AduitUser
                If Not FileReadInfo.AduitTime = "9999-12-31 23:59:59.997" Then
                    Me.LBpizhunDate0.Text = FileReadInfo.AduitTime
                Else
                    Me.LBpizhunDate0.Text = "未核准"
                End If
                If Not FileReadInfo.ApplyConfirmInfo = "9999-12-31 23:59:59.997" Then
                    Me.LBApplyuerqianshou.Text = FileReadInfo.ApplyConfirmInfo
                Else
                    Me.LBApplyuerqianshou.Text = "未簽收"
                End If
                If Not FileReadInfo.DealWithTime = "9999-12-31 23:59:59.997" Then
                    Me.LBchengbandate.Text = FileReadInfo.DealWithTime.ToShortDateString
                Else
                    Me.LBchengbandate.Text = "未承辦"
                End If
                If Not FileReadInfo.DealWithTime = "9999-12-31 23:59:59.997" Then
                    Me.LBChengbanqianshou.Text = FileReadInfo.DealwithUser + FileReadInfo.DealWithTime.ToShortDateString
                Else
                    Me.LBChengbanqianshou.Text = "未簽收"
                End If
                Me.TXTzhuguan.Text = FileReadInfo.LeaderUser
                Me.TxtcbRemark0.Text = FileReadInfo.DealRemark

                Me.LBchengbanUser.Text = FileReadInfo.DealwithUser


                Me.DPLDept.SelectedIndex = Me.DPLDept.Items.IndexOf(Me.DPLDept.Items.FindByText(FileReadInfo.ReadDept))
                If readpkid <> 0 Then
                    filesbh = ReadFileInfo.FileBH.Split("^")
                    filenums = filesbh.Length
                    filesname = ReadFileInfo.FileName.Split("^")
                    filetypes = ReadFileInfo.ReadType.Split("^")
                    readfor = ReadFileInfo.ReadFor.Split("^")
                    fenshu = ReadFileInfo.Extend1.Split("^")
                    shuoming = ReadFileInfo.Extend2.Split("^")
                    Me.HiddenFileCount.Value = filesbh.Length
                    Me.LbFileCount.Text = filenums.ToString
                    For i As Integer = 1 To filenums
                        Dim tri As System.Web.UI.HtmlControls.HtmlTableRow = CType(Me.FindControl("file" + i.ToString), System.Web.UI.HtmlControls.HtmlTableRow)
                        tri.Attributes.Remove("class")

                    Next
                    If filenums < 10 Then
                        For i As Integer = filenums + 1 To 10
                            Dim tri As System.Web.UI.HtmlControls.HtmlTableRow = CType(Me.FindControl("file" + i.ToString), System.Web.UI.HtmlControls.HtmlTableRow)
                            tri.Attributes.Add("class", "cssnovisible")

                        Next
                    End If
                    ' BindDPL()
                    For i As Integer = 1 To filenums
                        CType(Me.FindControl("HiddenFileBH" + i.ToString), HtmlInputHidden).Value = filesbh(i - 1)
                        CType(Me.FindControl("FileBH" + i.ToString), HtmlInputText).Value = filesbh(i - 1)
                        CType(Me.FindControl("txtFilename" + i.ToString), TextBox).Text = filesname(i - 1)
                        CType(Me.FindControl("HiddenFileName" + i.ToString), HiddenField).Value = filesname(i - 1)
                        CType(Me.FindControl("DPLReadType" + i.ToString), DropDownList).SelectedIndex = CType(Me.FindControl("DPLReadType" + i.ToString), DropDownList).Items.IndexOf(CType(Me.FindControl("DPLReadType" + i.ToString), DropDownList).Items.FindByText(filetypes(i - 1)))
                        If (filetypes(i - 1) = "電子原檔" OrElse filetypes(i - 1) = "受控紙檔" OrElse filetypes(i - 1) = "非受控紙檔" OrElse filetypes(i - 1) = "其它") Then
                            Me.HidIsFlow.Value += 1
                        End If
                        If filetypes(i - 1) = "受控紙檔" OrElse filetypes(i - 1) = "非受控紙檔" Then
                            CType(Me.FindControl("fenshu" + i.ToString), HtmlControls.HtmlGenericControl).Attributes.Remove("class")
                            CType(Me.FindControl("fenshu" + i.ToString), HtmlControls.HtmlGenericControl).Attributes.Add("class", "cssvisible")
                            CType(Me.FindControl("TxtFenshu" + i.ToString), TextBox).Text = fenshu(i - 1)
                        ElseIf filetypes(i - 1) = "其它" Then
                            CType(Me.FindControl("shuoming" + i.ToString), HtmlControls.HtmlGenericControl).Attributes.Remove("class")
                            CType(Me.FindControl("shuoming" + i.ToString), HtmlControls.HtmlGenericControl).Attributes.Add("class", "cssvisible")
                            CType(Me.FindControl("Txtshuoming" + i.ToString), TextBox).Text = shuoming(i - 1)
                        End If
                        CType(Me.FindControl("TxtRemark" + i.ToString), TextBox).Text = readfor(i - 1)
                    Next
                    If Me.HidIsFlow.Value > 0 Then
                        Me.HidIsFlow.Value = 1
                    Else
                        Me.HidIsFlow.Value = 0
                    End If
                End If
            Else
                Me.TXTApplydate.Text = DateTime.Now.ToShortDateString
                Me.TxtApplyer.Text = UserInfo.CurrentUserCHName

            End If


        End If
    End Sub


#Region "Eflow"

    Public ReadOnly Property BusniessName() As String Implements eWorkFlow.eFlowDoc.IDocInfo.BusniessName
        Get
            Return "QC文件調閱流程"
        End Get
    End Property

    Public Sub DeleteDocInfo(ByVal CurDocInfo As eWorkFlow.eFlowDoc.DocInfoSystem, ByVal CommandName As Platform.eWorkFlow.Model.Enm_ActionType) Implements eWorkFlow.eFlowDoc.IDocInfo.DeleteDocInfo
        FileReadManageDAL.Delete(PKID)

    End Sub

    Public ReadOnly Property IsUseFlow() As Boolean Implements eWorkFlow.eFlowDoc.IDocInfo.IsUseFlow
        Get
            Return True
        End Get
    End Property

    Public Sub LeaveDocInfo() Implements eWorkFlow.eFlowDoc.IDocInfo.LeaveDocInfo
        If CtlWFActionList1.OnlySave Then
            Dim Returnurl As String = "../Forms/FileReadManageDetail.aspx?pkid=" + PKID.ToString
            If DocUniqueID <> String.Empty AndAlso DocUniqueID <> Guid.Empty.ToString Then
                Returnurl += "&" + Global_asax.QUERY_DOCUNIQUEID + "=" + DocUniqueID
            End If
            Response.Redirect(Returnurl)
        Else
            Response.Redirect("../Forms/FileReadManageList.aspx")
        End If
    End Sub

    Public Sub LoadDocInfo(ByVal CurDocInfo As eWorkFlow.eFlowDoc.DocInfoSystem) Implements eWorkFlow.eFlowDoc.IDocInfo.LoadDocInfo
        If CurDocInfo.CurStateName = "承辦狀態" OrElse CurDocInfo.CurStateOrder = 5 Then
            Me.CHBfsk.Enabled = True
            Me.CHBneedBack.Enabled = True
            Me.CHBsk.Enabled = True
            Me.Txtsknum.Enabled = True
            Me.TXTfsknum.Enabled = True
            Me.TxtcbRemark0.Enabled = True
        End If
        If CurDocInfo.CurStateOrder > 1 Then
            Me.divaddf.Visible = False
        End If
        If UserInfo.IsInRoles("SYS_ADMINISTRATOR") Then
            Me.CtlWFActionList1.DisplayManagerButton(True)
        End If
        If CurDocInfo.CurStateOrder > 3 Then
            If FileReadInfo.FileHandle <> String.Empty Then
                Dim filechuli As String() = FileReadInfo.FileHandle.Split("^")
                If filechuli(0) = 1 Then
                    Me.CHBsk.Checked = True
                    Me.Txtsknum.Text = filechuli(1)
                End If
                If filechuli(2) = 1 Then
                    Me.CHBfsk.Checked = True
                    Me.TXTfsknum.Text = filechuli(3)
                End If
            End If
            If FileReadInfo.IsBack = 1 Then
                Me.CHBneedBack.Checked = True
            End If
        End If
        If CurDocInfo.CurStateOrder > 5 Then
            Me.LBApplyuerqianshou.Text = FileReadInfo.ApplyConfirmInfo
        End If
        If FileReadInfo.IsFinish = 1 Then
            Me.CtlWFActionList1.DisplayDeleteButton(False)
            Me.CtlWFActionList1.DisplaySaveButton(False)
            Me.CtlWFActionList1.DisplayManagerButton(False)
            Me.CtlWFActionList1.IsUseFlow = False
        End If
        CtlWFActionList1.CurURL = String.Format("{0}?PageType=fileread", Global_asax.URL_INDEX)  '往框架中跳
    End Sub

    Public Sub SaveDocInfo(ByVal CurDocInfo As eWorkFlow.eFlowDoc.DocInfoSystem, ByVal CommandName As Platform.eWorkFlow.Model.Enm_ActionType) Implements eWorkFlow.eFlowDoc.IDocInfo.SaveDocInfo
        DocUniqueID = CurDocInfo.DocUniqueID
        FileReadInfo.PKID = PKID
        FileReadInfo.eFlowDocID = New Guid(CurDocInfo.DocUniqueID)
        FileReadInfo.ReadDept = Me.DPLDept.SelectedItem.Text
        FileReadInfo.ApplyTime = DateTime.Now
        FileReadInfo.ApplyUser = Me.TxtApplyer.Text
        FileReadInfo.Remark = Me.TXTRemark.Text
        FileReadInfo.UseUserOrDept = Me.TXTUser.Text
        FileReadInfo.RecordCreated = DateTime.Now

        Dim FilereadmanageDal As FileReadManageDAL = New FileReadManageDAL(FileReadInfo)
        PKID = FilereadmanageDal.Save()

       

    End Sub

    Public ReadOnly Property TemplateName() As String Implements eWorkFlow.eFlowDoc.IDocInfo.TemplateName
        Get
            Return "QC文件調閱流程"
        End Get
    End Property

    Public ReadOnly Property TemplateVersion() As Integer Implements eWorkFlow.eFlowDoc.IDocInfo.TemplateVersion
        Get
            Return 3
        End Get
    End Property
#End Region

    'Protected Sub DropDownList1_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles DropDownList1.SelectedIndexChanged
    '    Dim filnum As Integer = Convert.ToInt32(Me.DropDownList1.SelectedItem.Text)
    '    Me.hidfilnum.Value = filnum
    '    For i As Integer = 1 To filnum
    '        Dim tri As System.Web.UI.HtmlControls.HtmlTableRow = CType(Me.FindControl("file" + i.ToString), System.Web.UI.HtmlControls.HtmlTableRow)
    '        tri.Attributes.Remove("class")

    '    Next
    '    If filnum < 10 Then
    '        For i As Integer = filnum + 1 To 10
    '            Dim tri As System.Web.UI.HtmlControls.HtmlTableRow = CType(Me.FindControl("file" + i.ToString), System.Web.UI.HtmlControls.HtmlTableRow)
    '            tri.Attributes.Add("class", "cssnovisible")
    '        Next
    '    End If
    '    BindDPL()
    '    ' ScriptManager.RegisterClientScriptBlock(UpdatePanel1, Me.GetType(), DateTime.Now.ToString(), "Initcombox();", True)

    '    'ClientScript.RegisterStartupScript(Me.GetType(), DateTime.Now.ToString(), "Initcombox();", True)

    'End Sub
    <WebMethod()> _
 Public Shared Function GetFileInfo() As List(Of DictionaryEntry)

        Dim mfileinfo As List(Of DictionaryEntry) = QC_FileInfoDAL.GetReadFileInfoList()
        Return mfileinfo
    End Function

    Private Sub CtlWFActionList1_Postopen(ByVal CurDocInfo As eWorkFlow.eFlowDoc.DocInfoSystem, ByVal e As eWorkFlow.eFlowDoc.BaseEventArgs) Handles CtlWFActionList1.Postopen
        Dim SaveScript As StringBuilder = New StringBuilder()
        SaveScript.Append("if ($('#LbFileCount').html() == 0) {alert('至少添加一份調閱文件'); return false;}")
        CtlWFActionList1.AduitScript = SaveScript.ToString
        CtlWFActionList1.SaveScript = SaveScript.ToString
    End Sub

    Private Sub CtlWFActionList1_Postsave(ByVal CurDocInfo As eWorkFlow.eFlowDoc.DocInfoSystem, ByVal e As eWorkFlow.eFlowDoc.PostSaveDocEventArgs) Handles CtlWFActionList1.Postsave
        If CurDocInfo.CurStateOrder = 1 Then
            Dim filebh As String = String.Empty
            Dim filename As String = String.Empty
            Dim readfor As String = String.Empty
            Dim readtype As String = String.Empty
            Dim fenshu As String = String.Empty
            Dim shuoming As String = String.Empty
            For i As Integer = 1 To Convert.ToInt32(Me.HiddenFileCount.Value)
                filebh += CType(Me.FindControl("HiddenFileBH" + i.ToString), HtmlInputHidden).Value + "^"
                filename += CType(Me.FindControl("HiddenFileName" + i.ToString), HiddenField).Value + "^"
                readfor += CType(Me.FindControl("TxtRemark" + i.ToString), TextBox).Text + "^"
                readtype += CType(Me.FindControl("DPLReadType" + i.ToString), DropDownList).SelectedItem.Text + "^"
                fenshu += CType(Me.FindControl("TxtFenshu" + i.ToString), TextBox).Text.Trim.ToString + "^"
                shuoming += CType(Me.FindControl("Txtshuoming" + i.ToString), TextBox).Text.Trim.ToString + "^"
            Next
            ReadFileInfo.parentid = PKID
            ReadFileInfo.pkid = readpkid
            ReadFileInfo.FileBH = filebh.Substring(0, filebh.Length - 1)
            ReadFileInfo.FileName = filename.Substring(0, filename.Length - 1)
            ReadFileInfo.ReadFor = readfor.Substring(0, readfor.Length - 1)
            ReadFileInfo.ReadType = readtype.Substring(0, readtype.Length - 1)
            ReadFileInfo.RecordCreated = DateTime.Now
            ReadFileInfo.Extend1 = fenshu
            ReadFileInfo.Extend2 = shuoming

            Dim ReadFileDal As ReadFileInfoDAL = New ReadFileInfoDAL(ReadFileInfo)
            ReadFileDal.Save()
        End If
    End Sub

    Private Sub CtlWFActionList1_Querysave(ByVal CurDocInfo As eWorkFlow.eFlowDoc.DocInfoSystem, ByVal e As eWorkFlow.eFlowDoc.QuerySaveDocEventArgs) Handles CtlWFActionList1.Querysave
        If e.CommandName = Platform.eWorkFlow.Model.Enm_ActionType.Approve _
           OrElse e.CommandName = Platform.eWorkFlow.Model.Enm_ActionType.Rejection _
           OrElse e.CommandName = Platform.eWorkFlow.Model.Enm_ActionType.Revoke _
           OrElse e.CommandName = Platform.eWorkFlow.Model.Enm_ActionType.Finish Then
            FileReadInfo.StateName = CurDocInfo.NextStateName
            FileReadInfo.StateOrder = CurDocInfo.NextStateOrder

        Else
            FileReadInfo.StateName = CurDocInfo.CurStateName
            FileReadInfo.StateOrder = CurDocInfo.CurStateOrder

        End If
        If e.CommandName = Platform.eWorkFlow.Model.Enm_ActionType.Finish Then
            FileReadInfo.IsFinish = 1
        End If
        Select Case CurDocInfo.CurStateName
            Case "承辦狀態"
                FileReadInfo.DealwithUser = UserInfo.CurrentUserCHName
                FileReadInfo.DealWithTime = DateTime.Now
                FileReadInfo.DealRemark = Me.TxtcbRemark0.Text
                If Me.CHBneedBack.Checked = True Then
                    FileReadInfo.IsBack = 1
                Else
                    FileReadInfo.IsBack = 0
                End If
                If Me.CHBsk.Checked = True AndAlso Me.CHBfsk.Checked = False Then
                    FileReadInfo.FileHandle = "1^" + Me.Txtsknum.Text + "^0^0"
                ElseIf Me.CHBsk.Checked = True AndAlso Me.CHBfsk.Checked = True Then
                    FileReadInfo.FileHandle = "1^" + Me.Txtsknum.Text + "^1^" + Me.TXTfsknum.Text
                ElseIf Me.CHBsk.Checked = False AndAlso Me.CHBfsk.Checked = True Then
                    FileReadInfo.FileHandle = "0^0^1^" + Me.TXTfsknum.Text
                ElseIf Me.CHBsk.Checked = False AndAlso Me.CHBfsk.Checked = False Then
                    FileReadInfo.FileHandle = "0^0^0^0"
                End If
            Case "審核狀態"
                FileReadInfo.LeaderUser = UserInfo.CurrentUserCHName + DateTime.Now.ToShortDateString
            Case "核准狀態"
                FileReadInfo.AduitUser = UserInfo.CurrentUserCHName
                FileReadInfo.AduitTime = DateTime.Now
            Case "申請人簽收狀態"
                FileReadInfo.ApplyConfirmInfo = UserInfo.CurrentUserCHName + DateTime.Now.ToShortDateString
        End Select
    End Sub

   
End Class