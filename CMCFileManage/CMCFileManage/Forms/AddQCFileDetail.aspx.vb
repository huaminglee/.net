Imports eWorkFlow.eFlowDoc
Imports System.IO
Imports Platform.eAuthorize
Imports System.Web.Services
Imports Platform.Framework
Imports Platform.eHR
Imports Platform.eHR.Core

Partial Public Class AddQCFileDetail
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

    Private Property CurType() As String
        Get
            If Not ViewState(_RequestType) Is Nothing Then
                Return CStr(ViewState(_RequestType))
            Else
                Return 0
            End If
        End Get
        Set(ByVal Value As String)
            ViewState(_RequestType) = Value
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
    Private _QCFileInfo As QC_FileInfoInfo
    Private Property QCFileInfo() As QC_FileInfoInfo
        Get
            If _QCFileInfo Is Nothing Then
                If PKID <> 0 Then
                    _QCFileInfo = QC_FileInfoDAL.GetInfoByPKID(PKID)
                    DocUniqueID = _QCFileInfo.eFlowDocID.ToString
                ElseIf DocUniqueID <> String.Empty Then
                    _QCFileInfo = QC_FileInfoDAL.GetInfoByeFLowdocID(DocUniqueID)
                    PKID = _QCFileInfo.PKID
                Else
                    _QCFileInfo = New QC_FileInfoInfo()

                End If
            End If
            Return _QCFileInfo
        End Get
        Set(ByVal value As QC_FileInfoInfo)
            _QCFileInfo = value
        End Set
    End Property

    Public Property ParentID() As Integer
        Get
            If ViewState(HIDE_ParentID) Is Nothing Then
                Return 0
            Else
                Return Convert.ToInt32(ViewState(HIDE_ParentID))
            End If
        End Get
        Set(ByVal Value As Integer)
            ViewState(HIDE_ParentID) = Value
        End Set
    End Property

    ''' <summary>
    ''' 附件父類別
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property ParentCategory() As Integer
        Get
            If ViewState(HIDE_ParentCategory) Is Nothing Then
                Return 0
            Else
                Return Convert.ToInt32(ViewState(HIDE_ParentCategory))
            End If
        End Get
        Set(ByVal Value As Integer)
            ViewState(HIDE_ParentCategory) = Value.ToString
        End Set
    End Property
    ''' <summary>
    ''' 附件子類別
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property ParentSubCategory() As Integer
        Get
            If ViewState(HIDE_ParentSubCategory) Is Nothing Then
                Return 0
            Else
                Return Convert.ToInt32(ViewState(HIDE_ParentSubCategory))
            End If
        End Get
        Set(ByVal Value As Integer)
            ViewState(HIDE_ParentSubCategory) = Value.ToString
        End Set
    End Property
    ''' <summary>
    ''' 是否變更 1為變更
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property ischange() As Integer
        Get
            If ViewState("ischange") Is Nothing Then
                Return 0
            Else
                Return Convert.ToInt32(ViewState("ischange"))
            End If
        End Get
        Set(ByVal value As Integer)
            ViewState("ischange") = value.ToString
        End Set
    End Property
#End Region
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            If UserInfo.CurrentUserInstance Is Nothing Then
                Response.Redirect("../Login.aspx")
            Else

                GetRequestParam()

                Me.LBFileNo.Attributes.Add("readonly", True)
                Me.TxtApplyDate.Attributes.Add("readonly", True)
                Me.LbPaperNum.Attributes.Add("readonly", True)
                BindApplyDept()

                Me.TxtApplyDate.Attributes.Add("onclick", "javascript:WdatePicker({startDate:'%y-%M-01',dateFmt:'yyyy-MM-dd',alwaysUseStartDate:true});")
                Me.UcFileDetail1.FileUplode = "doc;docx;xls;xlsx;dat"
                Me.UcFileDetail3.FileUplode = "pdf;doc;docx;xls;xlsx;dat"
                Me.UcFileDetail2.FileUplode = "pdf;doc;docx;xls;xlsx;dat"
                Me.UcFileDetail1.CanEdit = True
                Me.UcFileDetail1.CanRemove = True
                Me.UcFileDetail3.CanRemove = True
                Me.UcFileDetail3.CanEdit = True
                Me.UcFileDetail1.FileSize = ConfigurationManager.AppSettings("UploadMaxSize")
                Me.UcFileDetail3.FileSize = ConfigurationManager.AppSettings("UploadMaxSize")
                Me.UcFileDetail2.ParentCategory = 0
                Me.UcFileDetail2.ParentSubCategory = 1
                Me.UcFileDetail2.ParentID = PKID
                Me.UcFileDetail2.IsOld = 0
                Me.UcFileDetail2.CanEdit = False
                Me.UcFileDetail2.CanUpload = False

                Me.UcFileDetail1.ParentCategory = 0
                Me.UcFileDetail3.ParentCategory = 0
                Me.UcFileDetail1.ParentSubCategory = 0
                Me.UcFileDetail3.ParentSubCategory = 1

                Me.UcFileDetail4.ParentCategory = 0
                Me.UcFileDetail4.ParentSubCategory = 2

                Me.UcFileDetail5.ParentCategory = 0
                Me.UcFileDetail5.ParentSubCategory = 3

                BindConttrolData()
            End If
        End If
    End Sub
    Private Sub BindApplyDept()
        Dim dt As DataTable = QC_UserParameterDAL.GetInfoByCategory("Dept")
        If Not dt Is Nothing Then
            Me.DPLApplyDepth.DataSource = dt
            Me.DPLApplyDepth.DataTextField = "ParameterText"
            Me.DPLApplyDepth.DataValueField = "ParameterValue2"
            Me.DPLApplyDepth.DataBind()
            Me.Repeater2.DataSource = dt
            Me.Repeater2.DataBind()
        End If
        If (QCFileInfo.IsChange = 1 OrElse ischange = 1) AndAlso QCFileInfo.RecordType <> 3 AndAlso CurType <> 3 Then
            Me.hs.Attributes.Add("style", "display:block ;width: 100%")
            If Not dt Is Nothing Then
                Me.Repeater3.DataSource = dt
                Me.Repeater3.DataBind()
            End If
            Me.HidRecordType.Value = 2
        End If
    End Sub
    Private Sub BindDepth()
        Dim accountlist As List(Of AccountInfo) = RoleManage.LoadAccountCollection("LabTechniqueCharge")
        If accountlist.Count > 0 Then
            Dim i As Integer

            For i = 0 To accountlist.Count - 1
                Dim isindept As Boolean = False

                For Each curlbdept In DeptManage.LoadDepartmentByUserInfo(accountlist(i))
                    Dim curlbdeptname As String = curlbdept.DeptName
                    If Not UserInfo.CurrentUserDept Is Nothing Then
                        For Each curdept In UserInfo.CurrentUserDept
                            Dim medelt As String = curdept.DeptName
                            If medelt = curlbdeptname Then
                                isindept = True
                            End If
                        Next

                    End If
                    If Not Request.Cookies("userdepts") Is Nothing Then
                        Dim curdept As String
                        Dim dept As String() = HttpUtility.UrlDecode(Request.Cookies("userdepts").Value).ToString.Split(";")
                        For Each curdept In dept
                            If curdept = curlbdeptname Then
                                isindept = True
                            End If
                        Next
                    End If

                Next
                If isindept = True Then
                    Dim newitem As ListItem = New ListItem(accountlist(i).UserName + "_" + accountlist(i).Email1, accountlist(i).UserSID)

                    Me.DPLLabTechniqueCharge.Items.Add(newitem)
                End If


            Next
            'Me.DPLLabTechniqueCharge.DataSource = accountlist
            'Me.DPLLabTechniqueCharge.DataTextField = "UserName"
            'Me.DPLLabTechniqueCharge.DataValueField = "UserSID"
            'Me.DPLLabTechniqueCharge.DataBind()
        End If
        Me.DPLLabTechniqueCharge.Items.Add("未選擇")
        Me.DPLLabTechniqueCharge.SelectedIndex = Me.DPLLabTechniqueCharge.Items.IndexOf(Me.DPLLabTechniqueCharge.Items.FindByText("未選擇"))
        Me.HidLabTechniqueCharge.Value = "未選擇"


    End Sub
    Private Sub GetRequestParam()
        If Not Request.QueryString(Global_asax.QUERY_APPLICANTIDX) Is Nothing AndAlso Request.QueryString(Global_asax.QUERY_APPLICANTIDX) <> "" Then
            PKID = Convert.ToInt32(Request.QueryString(Global_asax.QUERY_APPLICANTIDX))
            DocUniqueID = QCFileInfo.eFlowDocID.ToString

        End If
        If Not Request.QueryString("eFlowDocID") Is Nothing Then
            DocUniqueID = Request.QueryString("eFlowDocID").ToString
        End If
        If Not Request.QueryString("ParentID") Is Nothing Then
            ParentID = Convert.ToInt32(Request.QueryString("ParentID"))
        End If
        If Not Request.QueryString("ischange") Is Nothing Then
            ischange = Convert.ToInt32(Request.QueryString("ischange"))
        End If
        If Not Request.QueryString("Type") Is Nothing Then
            CurType = Convert.ToInt32(Request.QueryString("Type"))
        End If
    End Sub
#Region "Eflow"

    Public ReadOnly Property BusniessName() As String Implements eWorkFlow.eFlowDoc.IDocInfo.BusniessName
        Get
            If CurType = 3 Then
                Return "QC文件作廢流程"
            Else
                Return "QC文件發行作業流程"
            End If
        End Get
    End Property

    Public Sub DeleteDocInfo(ByVal CurDocInfo As eWorkFlow.eFlowDoc.DocInfoSystem, ByVal CommandName As Platform.eWorkFlow.Model.Enm_ActionType) Implements eWorkFlow.eFlowDoc.IDocInfo.DeleteDocInfo
        QC_FileInfoDAL.Delete(PKID)
    End Sub

    Public ReadOnly Property IsUseFlow() As Boolean Implements eWorkFlow.eFlowDoc.IDocInfo.IsUseFlow
        Get
            Return True
        End Get
    End Property

    Public Sub LeaveDocInfo() Implements eWorkFlow.eFlowDoc.IDocInfo.LeaveDocInfo
        If CtlWFActionList1.OnlySave Then
            Dim Returnurl As String = "../Forms/AddQCFileDetail.aspx?pkid=" + PKID.ToString + "&Type=" + CurType.ToString
            If DocUniqueID <> String.Empty AndAlso DocUniqueID <> Guid.Empty.ToString Then
                Returnurl += "&" + Global_asax.QUERY_DOCUNIQUEID + "=" + DocUniqueID
            End If
            Response.Redirect(Returnurl)
        Else
            If Not UserInfo.IsInRoles("QA") Then
                Response.Redirect("../Index.aspx")
            Else
                Select Case CurType
                    Case 0
                        Response.Redirect("../Forms/AddQCFileList.aspx?Type=987" + CurType.ToString)
                    Case 1
                        Response.Redirect("../Forms/AddQCFileList.aspx?Type=988" + CurType.ToString)
                    Case 3
                        Response.Redirect("../Forms/AddQCFileList.aspx?Type=989" + CurType.ToString)
                    Case Else
                        Response.Redirect("../Forms/AddQCFileList.aspx?Type=1" + CurType.ToString)
                End Select
            End If
            

        End If

    End Sub

    Public Sub LoadDocInfo(ByVal CurDocInfo As eWorkFlow.eFlowDoc.DocInfoSystem) Implements eWorkFlow.eFlowDoc.IDocInfo.LoadDocInfo
        If Not IsPostBack Then
            If CurDocInfo.IsNewDoc Then
                HidIsNewDoc.Value = "0" '是新單
            End If
            If CurDocInfo.CurStateOrder = 1 Then
                BindDepth()
            Else
                Dim newitem As ListItem = New ListItem(QCFileInfo.LabTechniqueCharge, QCFileInfo.Extend6)
                Me.DPLLabTechniqueCharge.Items.Add(newitem)
                Me.DPLLabTechniqueCharge.SelectedIndex = Me.DPLLabTechniqueCharge.Items.IndexOf(Me.DPLLabTechniqueCharge.Items.FindByText(QCFileInfo.LabTechniqueCharge))
                Me.HidLabTechniqueCharge.Value = QCFileInfo.Extend6

            End If
            If UserInfo.IsInRoles("SYS_ADMINISTRATOR") OrElse Me.CtlWFActionList1.InRoles Then
                Me.UcFileDetail1.CanDownLoad = True
                Me.UcFileDetail3.CanDownLoad = True
                Me.UcFileDetail2.CanDownLoad = True
                Me.UcFileDetail1.CanEdit = True
                Me.UcFileDetail2.CanEdit = True
                UcFileDetail2.CanUpload = False
                Me.UcFileDetail3.CanEdit = True
            Else
                Me.UcFileDetail2.CanRemove = False
                Me.UcFileDetail1.CanRemove = False
                Me.UcFileDetail3.CanRemove = False
                Me.UcFileDetail1.CanDownLoad = False
                Me.UcFileDetail3.CanDownLoad = False
                Me.UcFileDetail2.CanDownLoad = False
            End If
            'If CurDocInfo.CurStateName = "填寫文件發行通知單" AndAlso QCFileInfo.IsChange = 0 AndAlso ischange = 0 Then  '駁回至第一站且不是舊版變更則需重新編號
            '    Me.LBFileNo.Text = ""
            'End If
            ' If CurDocInfo.CurStateName <> "配給文件編號" AndAlso ParentID = 0 Then
            'Me.LBFileNo.Text = QCFileInfo.FileBH
            'End If
            If UserInfo.IsInRoles("SYS_ADMINISTRATOR") Then
                Me.CtlWFActionList1.DisplayManagerButton(True)
                If CurDocInfo.CurStateOrder >= 9 Then
                    Me.LinkEmail.Visible = True
                End If
            End If
            If QCFileInfo.FileBH <> "" Then
                Me.LBFileNo.Text = QCFileInfo.FileBH
            End If
            If QCFileInfo.FileBH = "" AndAlso CurDocInfo.CurStateName = "配給文件編號" Then
                CtlWFActionList1.ChangeSaveText("配給文件編號")
                'Me.CtlWFActionList1.IsUseFlow = False
            End If
            Me.CtlWFActionList1.DisplayDeleteButton(False)
            If QCFileInfo.IsFinish = 1 Then
                Me.CtlWFActionList1.DisplayDeleteButton(False)
                Me.CtlWFActionList1.DisplaySaveButton(False)
                Me.CtlWFActionList1.DisplayManagerButton(False)
                Me.CtlWFActionList1.IsUseFlow = False
                If UserInfo.IsInRoles("SYS_ADMINISTRATOR") Then
                    Me.CtlWFActionList1.DisplaySaveButton(True)
                End If
            End If
        End If
        CtlWFActionList1.CurURL = String.Format("{0}?PageType=qcfile&Type={1}", Global_asax.URL_INDEX, CurType)  '往框架中跳
    End Sub

    Public Sub SaveDocInfo(ByVal CurDocInfo As eWorkFlow.eFlowDoc.DocInfoSystem, ByVal CommandName As Platform.eWorkFlow.Model.Enm_ActionType) Implements eWorkFlow.eFlowDoc.IDocInfo.SaveDocInfo
        DocUniqueID = CurDocInfo.DocUniqueID
        QCFileInfo.PKID = PKID
        QCFileInfo.eFlowDocID = New Guid(CurDocInfo.DocUniqueID)
        If Me.HidFileBH.Value <> "" Then
            QCFileInfo.FileBH = Me.HidFileBH.Value
        ElseIf Me.LBFileNo.Text <> String.Empty Then
            QCFileInfo.FileBH = Me.LBFileNo.Text
        End If
        QCFileInfo.ApplyDate = Me.TxtApplyDate.Text.Trim
        QCFileInfo.ApplyDept = Me.HidApplyDeptText.Value
        QCFileInfo.Extend9 = CurDocInfo.CurStateName
        QCFileInfo.ApplyUser = Me.TxtApplyUser.Text
        QCFileInfo.ChangeBehDes = Me.TxtChangeBehDes.Text.ToString
        QCFileInfo.ChangePreDes = Me.TxtChangePreDes.Text.ToString
        QCFileInfo.ChangeReason = Me.TxtChangeReason.Text.Trim
        If QCFileInfo.IsFinish = 1 Then
            QCFileInfo.SendNum = ""
            QCFileInfo.SendDept = 0
            QCFileInfo.SendPaperNums = 0
            QCFileInfo.Extend6 = Me.DPLLabTechniqueCharge.SelectedValue
            Dim rpi2 As RepeaterItem
            Dim i As Integer = 0
            For Each rpi2 In Repeater2.Items
                Dim TxtzdNums As TextBox = CType(rpi2.FindControl("TxtzdNums"), TextBox)
                Dim CHBdept As CheckBox = CType(rpi2.FindControl("CHBdept"), CheckBox)
                If CHBdept.Checked = True Then
                    QCFileInfo.SendNum += TxtzdNums.Text.ToString + "^"
                    QCFileInfo.SendPaperNums += CInt(TxtzdNums.Text)
                    QCFileInfo.SendDept += 2 ^ i
                Else
                    QCFileInfo.SendNum += "0^"
                End If
                i += 1
            Next
            QCFileInfo.SendNum = QCFileInfo.SendNum.Substring(0, QCFileInfo.SendNum.Length - 1)
        End If

        Dim around As Integer = 0
        Dim chbfile As CheckBox
        Dim rpi As RepeaterItem
        For Each rpi In Repeater1.Items
            chbfile = rpi.FindControl("CKBcq")
            If chbfile.Checked Then
                Select Case chbfile.Text
                    Case "TY"
                        around += 512
                    Case "NN"
                        around += 256
                    Case "LH"
                        around += 128
                    Case "YT"
                        around += 64
                    Case "WH"
                        around += 32
                    Case "CD"
                        around += 16
                    Case "WSJ"
                        around += 8
                    Case "GL"
                        around += 4
                    Case "CQ"
                        around += 2
                    Case "ZZ"
                        around += 1
                   
                End Select

            End If
        Next
        
        QCFileInfo.NeedAround = around
        If Me.CHBNone.Checked Then
            QCFileInfo.CounterSignType = 0
        ElseIf CHBPaper.Checked Then
            QCFileInfo.CounterSignType = 1
        ElseIf CKBMeeting.Checked Then
            QCFileInfo.CounterSignType = 2
        End If

        ' QCFileInfo.SendDept = Convert.ToInt32(Me.Hidfenfadanwei.Value)
        QCFileInfo.FileCategory = Me.HidFileCategoryText.Value
        If Me.HIDFilename.Value <> "" Then
            QCFileInfo.FileName = Me.HIDFilename.Value
        ElseIf Me.TxtFileName.Text <> "" Then
            QCFileInfo.FileName = Me.TxtFileName.Text
        End If
        QCFileInfo.FileVersion = Me.TxtFileVersion.Text
        QCFileInfo.IsChange = ischange
        QCFileInfo.FileLayer = Me.HidFileLayer.Value
        QCFileInfo.IsTeach = Me.HidIsteach.Value
        QCFileInfo.ISO = Me.HidISO.Value
        QCFileInfo.LabTechniqueCharge = Me.DPLLabTechniqueCharge.SelectedItem.Text

        QCFileInfo.RecordCreated = DateTime.Now
        QCFileInfo.RecordDeleted = 0
        QCFileInfo.RecordType = Me.HidRecordType.Value
        QCFileInfo.TeachDept = Me.TxtTeachDept.Text
        QCFileInfo.ToTalPage = Me.TxtToTalPage.Text
        'QCFileInfo.SendNum = Me.TXTjz.Text + "^" + Me.TXTlc.Text + "^" + Me.TXTjs.Text + "^" + Me.TXTsf.Text + "^" + TXTkkd.Text + "^" + TXTzy.Text + "^" + TXTyd.Text + "^" + TXTjckf.Text + "^" + TXTcjm.Text + "^" + TXTsdgc.Text + "^" + TXTsdlc.Text + "^" + TXTcae.Text + "^" + TXThalt.Text + "^" + TXTys.Text + "^" + TXTglc.Text + "^" + TXTpbk.Text + "^" + TXTyxzh.Text + "^" + TXTzcjc.Text + "^" + TXTsmt.Text + "^" + TXTscy.Text + "^" + TXTjmyqyf.Text + "^" + TXTscjc.Text
        ' QCFileInfo.SendPaperNums = CInt(Me.Hidfenfadanwei.Value)



        If Me.Image1.Value <> "1" Then
            Dim bitimage As String = ConvertImageToString(Me.Image1.Value)
            QCFileInfo.CenterTechniqueCharge = bitimage
        End If

        Dim qcFiledal As QC_FileInfoDAL = New QC_FileInfoDAL(QCFileInfo)
        PKID = qcFiledal.Save()

        Me.UcFileDetail1.ParentID = PKID                         '保存附件
        Me.UcFileDetail3.ParentID = PKID
        Me.UcFileDetail4.ParentID = PKID
        Me.UcFileDetail5.ParentID = PKID
        Me.UcFileDetail4.SaveDatatoDataBase()
        Me.UcFileDetail5.SaveDatatoDataBase()
        Me.UcFileDetail1.SaveDatatoDataBase()
        Me.UcFileDetail3.SaveDatatoDataBase()
    End Sub

    Public ReadOnly Property TemplateName() As String Implements eWorkFlow.eFlowDoc.IDocInfo.TemplateName
        Get
            If CurType = 3 OrElse QCFileInfo.RecordType = 3 Then
                Return "QC文件作廢流程"
            Else
                Return "QC文件發行作業流程"
            End If
        End Get
    End Property

    Public ReadOnly Property TemplateVersion() As Integer Implements eWorkFlow.eFlowDoc.IDocInfo.TemplateVersion
        Get
            If CurType = 3 Then
                Return 1
            Else
                Return 2
            End If
        End Get
    End Property
#End Region
#Region "CtlWFActionList1"
    Private Sub CtlWFActionList1_Postopen(ByVal CurDocInfo As eWorkFlow.eFlowDoc.DocInfoSystem, ByVal e As eWorkFlow.eFlowDoc.BaseEventArgs) Handles CtlWFActionList1.Postopen
        Dim SaveScript As StringBuilder = New StringBuilder()
        If CurDocInfo.CurStateOrder = 1 Then
            SaveScript.Append("if( $('#HidLabTechniqueCharge').val()=='未選擇'){ alert('請選擇實驗室技術負責人');return false;}")
        End If
        If CurDocInfo.CurStateOrder = 2 Then
            SaveScript.Append("if( $('#LBFileNo').val()==''){ alert('請先配給文件編號');return false;}")
        End If
        SaveScript.Append("if( $('#TxtApplyUser').val()==''){ alert('請填寫提案人');return false;}")
        SaveScript.Append("if( $('#TxtApplyDate').val()==''){ alert('請填寫提案日期');return false;}")
        SaveScript.Append("if( $('#TxtFileVersion').val()==''){ alert('請填寫版次');return false;}")
        SaveScript.Append("if( $('#TxtToTalPage').val()==''){ alert('請填寫頁數');return false;}")
        SaveScript.Append("if( $('#TxtFileName').val()==''){ alert('請填寫文件名稱');return false;}")

        SaveScript.Append("if( $('#HidFileLayer').val()=='WI' && $('#HidFileCategoryValue').val()=='' ){ alert('請選擇文件類別！');return false;}")
        SaveScript.Append("if( $('#HidFileLayer').val()=='QP' && $('#HidISO').val()=='' ){ alert('請選擇ISO！');return false;}")
        SaveScript.Append("if(document.getElementById('CHBPaper').checked==false &&document.getElementById('CKBMeeting').checked==false  && document.getElementById('CHBNone').checked==false){ alert('請填寫會簽方式');return false;}")
        If CurDocInfo.CurStateName = "電子檔發行" Then
            SaveScript.Append("if(document.getElementById('UcFileDetail1_HidFileCount').value=='0'&&document.getElementById('UcFileDetail3_HidFileCount').value=='0'){alert('未上傳任何文件');return false;}")
        End If
        CtlWFActionList1.AduitScript = SaveScript.ToString
        'CtlWFActionList1.SaveScript = SaveScript.ToString
        Me.CtlWFActionList1.IsMergeUser = True
    End Sub

    Private Sub CtlWFActionList1_Postsave(ByVal CurDocInfo As eWorkFlow.eFlowDoc.DocInfoSystem, ByVal e As eWorkFlow.eFlowDoc.PostSaveDocEventArgs) Handles CtlWFActionList1.Postsave
        If e.CommandName = Platform.eWorkFlow.Model.Enm_ActionType.Approve OrElse e.CommandName = Platform.eWorkFlow.Model.Enm_ActionType.Save Then
            Select Case CurDocInfo.CurStateName
                Case "配給文件編號"
                    If Me.LBFileNo.Text = "" Then
                        Dim lsm As Integer
                        Dim bhtype As String = String.Empty
                        Select Case QCFileInfo.FileLayer
                            Case "QM"
                                bhtype = "QM"
                            Case "QP"
                                bhtype = "QP-" + QCFileInfo.ISO.ToString
                            Case "WI"
                                bhtype = "WI-" + Me.HidApplyDeptValue.Value.ToString + Me.HidFileCategoryValue.Value.ToString
                            Case "QF"
                                bhtype = "QF-" + Me.HidApplyDeptValue.Value.ToString
                        End Select
                        lsm = TableBMHDAL.GetMaxlsmbyCategory(bhtype) + 1
                        Dim tableInfo As TableBMHInfo = New TableBMHInfo()
                        tableInfo.PKID = 0
                        tableInfo.Category = bhtype
                        tableInfo.BMH = lsm
                        tableInfo.RecordPKID = PKID
                        tableInfo.YMD = DateTime.Now.ToString

                        Dim tabledal As TableBMHDAL = New TableBMHDAL(tableInfo)
                        tabledal.Save()
                        If QCFileInfo.Extend1 <> "" Then
                            Dim URL As String = "</br><a href ='" + Global_asax.UrlBase + String.Format("/default.aspx?PageType={1}&eFlowDocID={0}&pkid={2}&Type={3}", CurDocInfo.DocUniqueID, "qcfile", PKID, CurType) + "'>點擊此處進入查看</a>"
                            Dim TitlesTR As String = String.Format("您好！{0}于{1}填寫的品管系統{2}文件編號已完成，請知曉.", QCFileInfo.ApplyUser, QCFileInfo.ApplyDate, QCFileInfo.FileName)
                            SendMail(QCFileInfo.Extend1, TitlesTR, TitlesTR + URL)
                        End If
                    End If
              
            End Select
            If (CurDocInfo.NextStateName = "電子檔發行" AndAlso Me.LbFileChangeNO.Text.Contains("?")) OrElse (CurType = 3 AndAlso e.CommandName = Platform.eWorkFlow.Model.Enm_ActionType.Finish) Then
                Dim lsm As Integer
                lsm = TableBMHDAL.GetMaxlsmbyCategory("TM-" + DateTime.Now.Year.ToString.Substring(2, 2)) + 1
                Dim tableInfo As TableBMHInfo = New TableBMHInfo()
                tableInfo.PKID = 0
                tableInfo.Category = "TM-" + DateTime.Now.Year.ToString.Substring(2, 2)
                tableInfo.BMH = lsm
                tableInfo.RecordPKID = PKID
                tableInfo.YMD = DateTime.Now.ToString

                Dim tabledal As TableBMHDAL = New TableBMHDAL(tableInfo)
                tabledal.Save()
            End If
        End If
        If e.CommandName = Platform.eWorkFlow.Model.Enm_ActionType.Approve OrElse e.CommandName = Platform.eWorkFlow.Model.Enm_ActionType.Finish Then
            If e.CommandName = Platform.eWorkFlow.Model.Enm_ActionType.Finish Then
                If QCFileInfo.Extend10 <> String.Empty Then
                    QC_FileInfoDAL.QC_FileUpFileStatus(QCFileInfo.Extend10)      '更新原紀錄失效
                    'QC_FileInfoDAL.Delete(Convert.ToInt32(QCFileInfo.Extend10))  '刪除原紀錄
                    'If QCFileInfo.RecordType = 3 Then      '作廢
                    '    QC_AttachFileInfoDAL.UPdateFileSubCategory(Convert.ToInt32(QCFileInfo.Extend10), PKID) '更新文件recorddeleted為2和更新parentid
                    'ElseIf QCFileInfo.RecordType = 2 Then      '變更
                    '    QC_AttachFileInfoDAL.UPdateFileParentid(Convert.ToInt32(QCFileInfo.Extend10), PKID)  '更新parentid
                    'End If

                End If
            End If
        End If
    End Sub

    'Private Sub CtlWFActionList1_PreAction(ByVal CurDocInfo As eWorkFlow.eFlowDoc.DocInfoSystem, ByVal e As eWorkFlow.eFlowDoc.PreActionEventArgs) Handles CtlWFActionList1.PreAction
    '    If CurDocInfo.CurStateName = "電子檔發行" Then
    '        If Me.UcFileDetail1.FileCount = 0 AndAlso Me.UcFileDetail3.FileCount = 0 Then
    '            Response.Write("<Script Language=JavaScript>alert('未上傳任何文件!');</Script>")
    '            e.IsContinue = False
    '        End If
    '    End If
    'End Sub

    Private Sub CtlWFActionList1_Querysave(ByVal CurDocInfo As eWorkFlow.eFlowDoc.DocInfoSystem, ByVal e As eWorkFlow.eFlowDoc.QuerySaveDocEventArgs) Handles CtlWFActionList1.Querysave
        QCFileInfo.RecordNO = Me.LbFileChangeNO.Text
        QCFileInfo.SendNum = ""
        QCFileInfo.SendDept = 0
        QCFileInfo.SendPaperNums = 0
        QCFileInfo.Extend6 = Me.DPLLabTechniqueCharge.SelectedValue

        Dim rpi2 As RepeaterItem
        Dim i As Integer = 0
        For Each rpi2 In Repeater2.Items
            Dim TxtzdNums As TextBox = CType(rpi2.FindControl("TxtzdNums"), TextBox)
            Dim CHBdept As CheckBox = CType(rpi2.FindControl("CHBdept"), CheckBox)
            If CHBdept.Checked = True Then
                QCFileInfo.SendNum += TxtzdNums.Text.ToString + "^"
                QCFileInfo.SendPaperNums += CInt(TxtzdNums.Text)
                QCFileInfo.SendDept += 2 ^ i
            Else
                QCFileInfo.SendNum += "0^"
            End If
            i += 1
        Next
        QCFileInfo.SendNum = QCFileInfo.SendNum.Substring(0, QCFileInfo.SendNum.Length - 1)

        If QCFileInfo.IsChange = 1 OrElse ischange = 1 Then
            QCFileInfo.BackSum = ""
            QCFileInfo.BackDept = 0
            QCFileInfo.BackDept = Me.Hidhuishoudanwei.Value
            Dim rpi3 As RepeaterItem
            For Each rpi3 In Repeater3.Items
                Dim TxtzdNums As TextBox = CType(rpi3.FindControl("TxtzdNums"), TextBox)
                Dim CHBdept As CheckBox = CType(rpi3.FindControl("CHBdept"), CheckBox)
                If CHBdept.Checked = True Then
                    QCFileInfo.BackSum += TxtzdNums.Text.ToString + "^"
                Else
                    QCFileInfo.BackSum += "0^"
                End If
            Next
            If Not QCFileInfo.BackSum = "" OrElse Not QCFileInfo.BackSum = String.Empty Then
                QCFileInfo.BackSum = QCFileInfo.BackSum.Substring(0, QCFileInfo.BackSum.Length - 1)
            End If


        End If

        If CurDocInfo.CurStateOrder = 11 Then   '回收

            If QCFileInfo.IsChange = 1 OrElse ischange = 1 Then
                QCFileInfo.BackDept = Me.Hidhuishoudanwei.Value
                QCFileInfo.BackSum = ""
                Dim rpi3 As RepeaterItem
                For Each rpi3 In Repeater3.Items
                    Dim TxtzdNums As TextBox = CType(rpi3.FindControl("TxtzdNums"), TextBox)
                    Dim CHBdept As CheckBox = CType(rpi3.FindControl("CHBdept"), CheckBox)
                    If CHBdept.Checked = True Then
                        QCFileInfo.BackSum += TxtzdNums.Text.ToString + "^"
                    Else
                        QCFileInfo.BackSum += "0^"
                    End If
                Next
                QCFileInfo.BackSum = QCFileInfo.BackSum.Substring(0, QCFileInfo.BackSum.Length - 1)
            End If
        End If
        If e.CommandName = Platform.eWorkFlow.Model.Enm_ActionType.Approve _
            OrElse e.CommandName = Platform.eWorkFlow.Model.Enm_ActionType.Rejection _
            OrElse e.CommandName = Platform.eWorkFlow.Model.Enm_ActionType.Revoke _
            OrElse e.CommandName = Platform.eWorkFlow.Model.Enm_ActionType.Finish Then
            QCFileInfo.StateName = CurDocInfo.NextStateName
            QCFileInfo.StateOrder = CurDocInfo.NextStateOrder

        Else
            QCFileInfo.StateName = CurDocInfo.CurStateName
            QCFileInfo.StateOrder = CurDocInfo.CurStateOrder

        End If
        If ParentID <> 0 Then
            QCFileInfo.Extend10 = ParentID  '存原紀錄pkid 用於在結案時更新原紀錄狀態
        End If

        If e.CommandName = Platform.eWorkFlow.Model.Enm_ActionType.Finish Then
            QCFileInfo.IsFinish = 1
            QCFileInfo.QualityFinishUser = UserInfo.CurrentUserCHName
        ElseIf e.CommandName = Platform.eWorkFlow.Model.Enm_ActionType.Approve OrElse e.CommandName = Platform.eWorkFlow.Model.Enm_ActionType.Save Then
            Select Case CurDocInfo.CurStateName
                Case "填寫文件發行通知單"
                    QCFileInfo.Extend1 = UserInfo.CurrentEmail
                    QCFileInfo.Extend2 = UserInfo.CurrentUserID


                Case "中心質量負責人"
                    QCFileInfo.CenterQuantityCharge = UserInfo.CurrentUserCHName
                Case "中心質量負責人核定"
                    QCFileInfo.CenterQuantityCharge = UserInfo.CurrentUserCHName
                Case "中心技術負責人"
                    QCFileInfo.CenterTechniqueCharge = UserInfo.CurrentUserCHName
                Case "中心最高主管"
                    QCFileInfo.HighManager = UserInfo.CurrentUserCHName
                    'Case "電子檔發行"
                    '    Dim lsm As Integer = TableBMHDAL.GetMaxlsmbyCategory("TM-" + DateTime.Now.Year.ToString.Substring(2, 2)) + 1
                    '    QCFileInfo.RecordNO = "TM-" + DateTime.Now.Year.ToString.Substring(2, 2) + "-" + lsm.ToString("000")
            End Select
            If (CurDocInfo.NextStateName = "電子檔發行" AndAlso QCFileInfo.RecordNO.Contains("?")) OrElse (QCFileInfo.RecordType = 3 AndAlso e.CommandName = Platform.eWorkFlow.Model.Enm_ActionType.Finish) Then
                Dim lsm As Integer = TableBMHDAL.GetMaxlsmbyCategory("TM-" + DateTime.Now.Year.ToString.Substring(2, 2)) + 1
                QCFileInfo.RecordNO = "TM-" + DateTime.Now.Year.ToString.Substring(2, 2) + "-" + lsm.ToString("000")
                QCFileInfo.EffectDate = DateTime.Now
            End If

            If CurDocInfo.CurStateName = "配給文件編號" AndAlso QCFileInfo.FileBH = "" Then
                QCFileInfo.Extend9 = "TESTGETIN"
                Dim lsm As Integer
                Dim bhtype As String = String.Empty
                Select Case QCFileInfo.FileLayer
                    Case "QM"
                        bhtype = "QM"
                    Case "QP"
                        bhtype = "QP-" + QCFileInfo.ISO.ToString
                    Case "WI"
                        bhtype = "WI-" + Me.HidApplyDeptValue.Value.ToString + Me.HidFileCategoryValue.Value.ToString
                    Case "QF"
                        bhtype = "QF-" + Me.HidApplyDeptValue.Value.ToString
                End Select
                lsm = TableBMHDAL.GetMaxlsmbyCategory(bhtype) + 1
                Select Case QCFileInfo.FileLayer
                    Case "QM"

                        QCFileInfo.FileBH = "QM-" + lsm.ToString("00")
                    Case "QP"
                        QCFileInfo.FileBH = "QP-" + QCFileInfo.ISO.ToString + "-" + lsm.ToString("000")
                    Case "WI"
                        QCFileInfo.FileBH = "WI-" + Me.HidApplyDeptValue.Value.ToString + Me.HidFileCategoryValue.Value.ToString + "-" + lsm.ToString("000")
                    Case "QF"
                        QCFileInfo.FileBH = "QF-" + Me.HidApplyDeptValue.Value.ToString + "-" + lsm.ToString("000")
                End Select
            End If

        End If
    End Sub
#End Region

    Private Sub BindConttrolData()

        
        If CurType = 3 OrElse (CurType = 2 AndAlso QCFileInfo.RecordType = 3) Then
            Me.HidRecordType.Value = 3
            Me.LBtitle.Text = "文件作廢通知單"
            Me.LBFF1.Text = "回收單位"
            Me.LBZD1.Text = "回收紙檔份數"
            Me.LBFF2.Text = "回收單位"
            Me.LBZD2.Text = "回收紙檔份數"
        ElseIf QCFileInfo.RecordType = 2 OrElse CurType = 1 Then
            Me.LBtitle.Text = "文件更版發行通知單"
        End If
        If Not PKID = 0 Then
            If QCFileInfo.RecordType <> 1 Then
                CurType = QCFileInfo.RecordType
            End If
            If QCFileInfo.Extend4 = "1" Then
                Me.ctlWFHistory1.Visible = False
                Me.GridView1.Visible = True
                Dim dt1 As DataTable = SignRecordDAL.GetInfoByRecordNo(QCFileInfo.RecordNO)
                Me.GridView1.DataSource = dt1
                Me.GridView1.DataBind()
            End If
            If QCFileInfo.StateOrder >= 9 Then
                Me.LinkFile.Visible = True
            End If
            If QCFileInfo.Extend4 = "1" Then
                Me.UcFileDetail2.Visible = True
                Me.UcFileDetail1.FileType = "QCFile"
                Me.UcFileDetail3.FileType = "QCFile"
                Me.UcFileDetail1.IsOld = 1
                Me.UcFileDetail3.IsOld = 1
            End If
            ischange = QCFileInfo.IsChange
            Me.LbFileChangeNO.Text = QCFileInfo.RecordNO
            Me.TxtApplyDate.Text = QCFileInfo.ApplyDate
            Me.DPLApplyDepth.SelectedIndex = Me.DPLApplyDepth.Items.IndexOf(Me.DPLApplyDepth.Items.FindByText(QCFileInfo.ApplyDept))
            Me.HidApplyDeptText.Value = Me.DPLApplyDepth.SelectedItem.Text
            Me.HidApplyDeptValue.Value = Me.DPLApplyDepth.SelectedValue
            Me.TxtApplyUser.Text = QCFileInfo.ApplyUser
            Me.TxtChangeBehDes.Text = QCFileInfo.ChangeBehDes
            Me.TxtChangePreDes.Text = QCFileInfo.ChangePreDes
            Me.TxtChangeReason.Text = QCFileInfo.ChangeReason
            Me.TxtChangePreDes.ToolTip = QCFileInfo.ChangePreDes
            Me.TxtChangeBehDes.ToolTip = QCFileInfo.ChangeBehDes
            Me.TxtChangeReason.ToolTip = QCFileInfo.ChangeReason
            Me.HidFileCategoryText.Value = QCFileInfo.FileCategory
            Select Case QCFileInfo.CounterSignType
                Case 0
                    Me.CHBNone.Checked = True
                Case 1
                    Me.CHBPaper.Checked = True
                    Me.shumianjilu.Attributes.Remove("class")
                Case 2
                    Me.CKBMeeting.Checked = True
                    Me.huiyijilu.Attributes.Remove("class")
            End Select
            Me.TxtToTalPage.Text = QCFileInfo.ToTalPage
            If Not QCFileInfo.EffectDate = "9999/12/31" Then
                Me.LbEffectDate.Text = QCFileInfo.EffectDate
            Else
                Me.LbEffectDate.Text = "未生效"
            End If


            Me.DPLFileLayer.SelectedIndex = Me.DPLFileLayer.Items.IndexOf(Me.DPLFileLayer.Items.FindByText(QCFileInfo.FileLayer))
            Me.HidFileLayer.Value = DPLFileLayer.SelectedItem.Text
            Me.TxtFileName.Text = QCFileInfo.FileName
            Me.TxtFileName.ToolTip = QCFileInfo.FileName
            If QCFileInfo.FileLayer = "WI" Then
                Me.DPLFileCategory.Attributes.Add("style", "display:inline")
                Me.Lbfilecate.Attributes.Add("style", "display:inline")
                Me.DPLFileCategory.SelectedIndex = Me.DPLFileCategory.Items.IndexOf(Me.DPLFileCategory.Items.FindByText(QCFileInfo.FileCategory))

                Select Case QCFileInfo.FileCategory
                    Case "校準程序"
                        Me.HidFileCategoryValue.Value = 1
                    Case "操作規程(設備/軟件)"
                        Me.HidFileCategoryValue.Value = 2
                    Case "作業規范"
                        Me.HidFileCategoryValue.Value = 3
                    Case "不確定度"
                        Me.HidFileCategoryValue.Value = 4
                    Case "其它"
                        Me.HidFileCategoryValue.Value = 5
                End Select
            ElseIf QCFileInfo.FileLayer = "QP" Then
                Me.LbIso.Attributes.Add("style", "display:inline")
                Me.DPLiso.Attributes.Add("style", "display:inline")
                Me.DPLiso.SelectedIndex = Me.DPLiso.Items.IndexOf(Me.DPLiso.Items.FindByText(QCFileInfo.ISO))
                Me.HidISO.Value = QCFileInfo.ISO
            End If
            If QCFileInfo.IsFinish = 1 Then
                Me.lbQualityFinishUser.Text = QCFileInfo.QualityFinishUser

            End If
            Me.TxtFileVersion.Text = QCFileInfo.FileVersion

            Select Case QCFileInfo.IsTeach
                Case 1
                    Me.RdBIsTeach.SelectedIndex = 0
                    Me.TxtTeachDept.Attributes.Remove("class")
                Case 0
                    Me.RdBIsTeach.SelectedIndex = 1
            End Select
            Me.HidIsteach.Value = QCFileInfo.IsTeach
            'Dim labindex As Integer = Me.DPLLabTechniqueCharge.Items.IndexOf(Me.DPLLabTechniqueCharge.Items.FindByText(QCFileInfo.LabTechniqueCharge))
            'If labindex > -1 Then
            '    Me.DPLLabTechniqueCharge.SelectedIndex = labindex
            '    Me.HidLabTechniqueCharge.Value = DPLLabTechniqueCharge.Items(labindex).Value
            'Else
            '    Me.DPLLabTechniqueCharge.SelectedItem.Text = QCFileInfo.LabTechniqueCharge
            '    Me.HidLabTechniqueCharge.Value = QCFileInfo.Extend6
            'End If
            Me.TxtTeachDept.Text = QCFileInfo.TeachDept
            bindfenfazhidang()
            If QCFileInfo.IsChange = 1 OrElse ischange = 1 AndAlso QCFileInfo.BackSum <> "" Then
                BindHuishou(QCFileInfo.BackDept, QCFileInfo.BackSum)

            End If
            HidApplyDeptText.Value = QCFileInfo.ApplyDept   '用於eflow流程
            HidApplyUser.Value = QCFileInfo.Extend2


            If QCFileInfo.CenterQuantityCharge <> "" AndAlso File.Exists(Server.MapPath(Request.ApplicationPath) + "\SignImg\" + QCFileInfo.CenterQuantityCharge + ".gif") Then
                Me.ImgCenterQuantityCharge.Visible = True
                Me.ImgCenterQuantityCharge.ImageUrl = "~/SignImg/" + QCFileInfo.CenterQuantityCharge + ".gif"
            End If
            If QCFileInfo.CenterTechniqueCharge <> "" AndAlso File.Exists(Server.MapPath(Request.ApplicationPath) + "\SignImg\" + QCFileInfo.CenterTechniqueCharge + ".gif") Then
                Me.ImgCenterTechniqueCharge.Visible = True
                Me.ImgCenterTechniqueCharge.ImageUrl = "~/SignImg/" + QCFileInfo.CenterTechniqueCharge + ".gif"
            End If
            If QCFileInfo.HighManager <> "" AndAlso File.Exists(Server.MapPath(Request.ApplicationPath) + "\SignImg\" + QCFileInfo.HighManager + ".gif") Then
                Me.ImgHighManager.Visible = True
                Me.ImgHighManager.ImageUrl = "~/SignImg/" + QCFileInfo.HighManager + ".gif"
            End If
            Me.HidFileLayer.Value = QCFileInfo.FileLayer
            Me.LbPaperNum.Text = QCFileInfo.SendPaperNums


            Dim dt As DataTable = QC_UserParameterDAL.GetInfoByCategory("CQ")
            If Not dt Is Nothing AndAlso dt.Rows.Count > 0 Then
                Me.Repeater1.DataSource = dt
                Me.Repeater1.DataBind()
                Dim chbfile As CheckBox
                Dim rpi As RepeaterItem
                Dim around As Integer = QCFileInfo.NeedAround
                For Each rpi In Repeater1.Items
                    chbfile = rpi.FindControl("CKBcq")
                    Select Case chbfile.Text
                        Case "TY"
                            If (around And 512) = 512 Then
                                chbfile.Checked = True
                            End If
                        Case "NN"
                            If (around And 256) = 256 Then
                                chbfile.Checked = True
                            End If
                        Case "LH"
                            If (around And 128) = 128 Then
                                chbfile.Checked = True
                            End If
                        Case "YT"
                            If (around And 64) = 64 Then
                                chbfile.Checked = True
                            End If
                        Case "WH"
                            If (around And 32) = 32 Then
                                chbfile.Checked = True
                            End If
                        Case "CD"
                            If (around And 16) = 16 Then
                                chbfile.Checked = True
                            End If
                        Case "WSJ"
                            If (around And 8) = 8 Then
                                chbfile.Checked = True
                            End If
                        Case "GL"
                            If (around And 4) = 4 Then
                                chbfile.Checked = True
                            End If
                        Case "CQ"
                            If (around And 2) = 2 Then
                                chbfile.Checked = True
                            End If
                        Case "ZZ"
                            If (around And 1) = 1 Then
                                chbfile.Checked = True
                            End If
                    End Select

                Next
                ' bindfenfadanwei()

                If QCFileInfo.StateOrder > 1 Then
                    Me.DPLFileCategory.Enabled = False
                    Me.DPLFileCategory.BackColor = System.Drawing.Color.White
                    Me.DPLFileLayer.Enabled = False
                    Me.DPLiso.Enabled = False
                End If
            End If

            Me.UcFileDetail1.ParentID = PKID                         '綁定附件
            Me.UcFileDetail3.ParentID = PKID
            Me.UcFileDetail4.ParentID = PKID
            Me.UcFileDetail5.ParentID = PKID
            Me.UcFileDetail1.ParentCategory = 0
            Me.UcFileDetail3.ParentCategory = 0
            Me.UcFileDetail1.ParentSubCategory = 0
            Me.UcFileDetail3.ParentSubCategory = 1
            If QCFileInfo.IsFinish = 1 Then
                Me.UcFileDetail1.CanUpload = False
                Me.UcFileDetail3.CanUpload = False
                Me.UcFileDetail1.CanRemove = False
                Me.UcFileDetail3.CanRemove = False
            End If
        ElseIf PKID = 0 Then


            Dim dt As DataTable = QC_UserParameterDAL.GetInfoByCategory("CQ")
            If Not dt Is Nothing AndAlso dt.Rows.Count > 0 Then
                Me.Repeater1.DataSource = dt
                Me.Repeater1.DataBind()
                Dim chbfile As CheckBox
                Dim rpi As RepeaterItem
                For Each rpi In Repeater1.Items
                    chbfile = rpi.FindControl("CKBcq")
                    chbfile.Checked = False

                Next
            End If
            If ParentID <> 0 Then
                Me.DPLFileLayer.Enabled = False
                Me.DPLFileCategory.Enabled = False
                Me.DPLApplyDepth.Enabled = False

                Dim curqcfileinfo As QC_FileInfoInfo = QC_FileInfoDAL.GetInfoByPKID(ParentID)
                Me.TxtApplyUser.Text = curqcfileinfo.ApplyUser
                Me.DPLApplyDepth.SelectedIndex = Me.DPLApplyDepth.Items.IndexOf(Me.DPLApplyDepth.Items.FindByText(curqcfileinfo.ApplyDept))
                Me.HidApplyDeptText.Value = Me.DPLApplyDepth.SelectedItem.Text
                Me.HidApplyDeptValue.Value = Me.DPLApplyDepth.SelectedValue
                Me.TxtToTalPage.Text = curqcfileinfo.ToTalPage
                Me.TxtFileName.Text = curqcfileinfo.FileName
                Me.DPLFileLayer.SelectedIndex = Me.DPLFileLayer.Items.IndexOf(Me.DPLFileLayer.Items.FindByText(curqcfileinfo.FileLayer))
                Me.HidFileLayer.Value = curqcfileinfo.FileLayer
                Me.LBFileNo.Text = curqcfileinfo.FileBH
                Me.HidApplyUser.Value = curqcfileinfo.Extend2
                Me.TxtChangePreDes.Text = curqcfileinfo.ChangeBehDes
                Me.TxtChangePreDes.ToolTip = curqcfileinfo.ChangePreDes
                Me.TxtChangeBehDes.ToolTip = curqcfileinfo.ChangeBehDes
                Me.TxtChangeReason.ToolTip = curqcfileinfo.ChangeReason

                Dim backdept As Integer = curqcfileinfo.SendDept
                Dim backzhidang As String = curqcfileinfo.SendNum
                BindHuishou(backdept, backzhidang)

                If CurType = 3 Then       '作廢該文件 
                    Me.TxtFileVersion.Text = curqcfileinfo.FileVersion
                End If
                If curqcfileinfo.FileLayer = "WI" Then
                    Me.DPLFileCategory.Attributes.Add("style", "display:inline")
                    Me.Lbfilecate.Attributes.Add("style", "display:inline")
                    Me.DPLFileCategory.SelectedIndex = Me.DPLFileCategory.Items.IndexOf(Me.DPLFileCategory.Items.FindByText(curqcfileinfo.FileCategory))
                    Select Case curqcfileinfo.FileCategory
                        Case "校準程序"
                            Me.HidFileCategoryValue.Value = 1
                        Case "操作規程(設備/軟件)"
                            Me.HidFileCategoryValue.Value = 2
                        Case "作業規范"
                            Me.HidFileCategoryValue.Value = 3
                        Case "不確定度"
                            Me.HidFileCategoryValue.Value = 4
                        Case "其它"
                            Me.HidFileCategoryValue.Value = 5
                    End Select
                    Me.HidFileCategoryText.Value = curqcfileinfo.FileCategory
                ElseIf curqcfileinfo.FileLayer = "QP" Then
                    Me.LbIso.Attributes.Add("style", "display:inline")
                    Me.DPLiso.Attributes.Add("style", "display:inline")
                    Me.DPLiso.SelectedIndex = Me.DPLiso.Items.IndexOf(Me.DPLiso.Items.FindByText(curqcfileinfo.ISO))
                    Me.HidISO.Value = curqcfileinfo.ISO
                End If
            ElseIf ParentID = 0 AndAlso ischange = 1 Then           '直接新增舊版變更或作廢
                Me.Hiddenischange.Value = 1
                Me.DPLApplyDepth.Items.Add("--請選擇--")
                Me.DPLApplyDepth.SelectedIndex = Me.DPLApplyDepth.Items.IndexOf(Me.DPLApplyDepth.Items.FindByText("--請選擇--"))
                Me.DPLFileLayer.Items.Clear()
                ' ClientScript.RegisterStartupScript(Me.GetType(), DateTime.Now.ToString(), "InitfileComobobox('LBFileNo', 'TxtFileName');", True)

            End If

            Me.LbFileChangeNO.Text = "TM-" + DateTime.Now.Year.ToString.Substring(2, 2) + "-" + "???"
        End If




    End Sub

    ''' <summary>
    ''' 計算發行紙檔數量
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function jisuanpapernums() As Integer
        Dim papernums As String() = QCFileInfo.SendNum.Split("^")
        Dim i As Integer
        Dim jiguo As Integer = 0
        For i = 0 To papernums.Length - 1
            jiguo += Convert.ToInt32(papernums(i))
        Next
        Me.LbPaperNum.Text = jiguo
        Return jiguo
    End Function
    Public Function ConvertImageToString(ByVal filepath As String) As String
        If filepath = "" Then
            Return ""
        End If

        Try
            Dim fs As FileStream = New FileStream(filepath, FileMode.Open, FileAccess.Read, FileShare.Read, 20480, True)
            Dim ibg(fs.Length) As Byte
            fs.Read(ibg, 0, fs.Length)
            Return Encoding.ASCII.GetString(ibg)
        Catch

        End Try
        Return ""
    End Function
    Public Function ConvertStringToImage(ByVal str As String) As System.Drawing.Image
        Try
            Dim ImageBytes() As Byte = Convert.FromBase64String(str)
            Dim ImageMem As System.IO.MemoryStream = New System.IO.MemoryStream(ImageBytes)
            Return System.Drawing.Image.FromStream(ImageMem)
        Catch
        End Try

        Return Nothing
    End Function


#Region "分發單位"
    Private Sub bindfenfazhidang()
        If QCFileInfo.SendNum <> "" Then
            Dim sennum As String() = QCFileInfo.SendNum.Split("^")
            Dim fenfadanwei As Integer = QCFileInfo.SendDept
            Me.Hidfenfadanwei.Value = fenfadanwei
            Dim rpi As RepeaterItem
            Dim i As Integer = 0
            For Each rpi In Repeater2.Items
                Dim TxtzdNums As TextBox = CType(rpi.FindControl("TxtzdNums"), TextBox)
                Dim CHBdept As CheckBox = CType(rpi.FindControl("CHBdept"), CheckBox)
                Dim divzdnums As HtmlControls.HtmlGenericControl = CType(rpi.FindControl("divzdnums"), HtmlControls.HtmlGenericControl)
                If (fenfadanwei And 2 ^ i) = 2 ^ i Then
                    CHBdept.Checked = True
                    divzdnums.Attributes.Add("style", "display:inline; float:right")
                    TxtzdNums.Text = sennum(i)
                End If
                i += 1
            Next
        End If

    End Sub
#End Region
#Region "回收單位"

    Private Sub BindHuishou(ByVal fenfadanwei As Integer, ByVal backzhidang As String)
        Me.Hidhuishoudanwei.Value = fenfadanwei
        Dim sennum As String() = backzhidang.Split("^")
        Dim rpi As RepeaterItem
        Dim i As Integer = 0
        For Each rpi In Repeater3.Items
            Dim TxtzdNums As TextBox = CType(rpi.FindControl("TxtzdNums"), TextBox)
            Dim CHBdept As CheckBox = CType(rpi.FindControl("CHBdept"), CheckBox)
            Dim divzdnums As HtmlControls.HtmlGenericControl = CType(rpi.FindControl("divzdnums"), HtmlControls.HtmlGenericControl)
            If (fenfadanwei And 2 ^ i) = 2 ^ i Then
                CHBdept.Checked = True
                divzdnums.Attributes.Add("style", "display:inline; float:right")
                TxtzdNums.Text = sennum(i)
            End If
            i += 1
        Next

    End Sub
    ''' <summary>
    ''' 綁定回收單位
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub bindhuishoudanwei(ByVal fenfadanwei As Integer)


        Me.Hidhuishoudanwei.Value = fenfadanwei
        'If (fenfadanwei And 2 ^ 22) = 2 ^ 22 Then
        '    Me.hsCHBjz.Checked = True
        '    Me.hsjz.Attributes.Add("style", "display:inline; float:right")
        'End If
        'If (fenfadanwei And 2 ^ 21) = 2 ^ 21 Then
        '    Me.hsCHBlc.Checked = True
        '    Me.hslc.Attributes.Add("style", "display:inline; float:right")
        'End If
        'If (fenfadanwei And 2 ^ 20) = 2 ^ 20 Then
        '    Me.hsCHBjs.Checked = True
        '    Me.hsjs.Attributes.Add("style", "display:inline; float:right")
        'End If
        'If (fenfadanwei And 2 ^ 19) = 2 ^ 19 Then
        '    Me.hsCHBsf.Checked = True
        '    Me.hssf.Attributes.Add("style", "display:inline; float:right")
        'End If
        'If (fenfadanwei And 2 ^ 18) = 2 ^ 18 Then
        '    Me.hsCHBkkd.Checked = True
        '    Me.hskkd.Attributes.Add("style", "display:inline; float:right")
        'End If
        'If (fenfadanwei And 2 ^ 17) = 2 ^ 17 Then
        '    Me.hsCHBzy.Checked = True
        '    Me.hszy.Attributes.Add("style", "display:inline; float:right")
        'End If
        'If (fenfadanwei And 2 ^ 16) = 2 ^ 16 Then
        '    Me.hsCHByd.Checked = True
        '    Me.hsyd.Attributes.Add("style", "display:inline; float:right")
        'End If
        'If (fenfadanwei And 2 ^ 15) = 2 ^ 15 Then
        '    Me.hsCHBjckf.Checked = True
        '    Me.hsjckf.Attributes.Add("style", "display:inline; float:right")
        'End If
        'If (fenfadanwei And 2 ^ 14) = 2 ^ 14 Then
        '    Me.hsCHBcjm.Checked = True
        '    Me.hscjm.Attributes.Add("style", "display:inline; float:right")
        'End If
        'If (fenfadanwei And 2 ^ 13) = 2 ^ 13 Then
        '    Me.hsCHBsdgc.Checked = True
        '    Me.hssdgc.Attributes.Add("style", "display:inline; float:right")
        'End If
        'If (fenfadanwei And 2 ^ 12) = 2 ^ 12 Then
        '    Me.hsCHBsdlc.Checked = True
        '    Me.hssdlc.Attributes.Add("style", "display:inline; float:right")
        'End If
        'If (fenfadanwei And 2 ^ 11) = 2 ^ 11 Then
        '    Me.hsCHBcae.Checked = True
        '    Me.hscae.Attributes.Add("style", "display:inline; float:right")
        'End If
        'If (fenfadanwei And 2 ^ 10) = 2 ^ 10 Then
        '    Me.hsCHBhalt.Checked = True
        '    Me.hshalt.Attributes.Add("style", "display:inline; float:right")
        'End If
        'If (fenfadanwei And 2 ^ 9) = 2 ^ 9 Then
        '    Me.hsCHBys.Checked = True
        '    Me.hsys.Attributes.Add("style", "display:inline; float:right")
        'End If
        'If (fenfadanwei And 2 ^ 8) = 2 ^ 8 Then
        '    Me.hsCHBglc.Checked = True
        '    Me.hsglc.Attributes.Add("style", "display:inline; float:right")
        'End If
        'If (fenfadanwei And 2 ^ 7) = 2 ^ 7 Then
        '    Me.hsCHBpbk.Checked = True
        '    Me.hspbk.Attributes.Add("style", "display:inline; float:right")
        'End If
        'If (fenfadanwei And 2 ^ 6) = 2 ^ 6 Then
        '    Me.hsCHByxzh.Checked = True
        '    Me.hsyxzh.Attributes.Add("style", "display:inline; float:right")
        'End If
        'If (fenfadanwei And 2 ^ 5) = 2 ^ 5 Then
        '    Me.hsCHBzcjc.Checked = True
        '    Me.hszcjc.Attributes.Add("style", "display:inline; float:right")
        'End If

        'If (fenfadanwei And 2 ^ 4) = 2 ^ 4 Then
        '    Me.hsCHBsmt.Checked = True
        '    Me.hssmt.Attributes.Add("style", "display:inline; float:right")
        'End If
        'If (fenfadanwei And 2 ^ 3) = 2 ^ 3 Then
        '    Me.hsCHBscy.Checked = True
        '    Me.hsscy.Attributes.Add("style", "display:inline; float:right")
        'End If
        'If (fenfadanwei And 2 ^ 2) = 2 ^ 2 Then
        '    Me.hsCHBjmyqyf.Checked = True
        '    Me.hsjmyqyf.Attributes.Add("style", "display:inline; float:right")
        'End If
        'If (fenfadanwei And 2 ^ 1) = 2 ^ 1 Then
        '    Me.hsCHBscjc.Checked = True
        '    Me.hsscjc.Attributes.Add("style", "display:inline; float:right")
        'End If


    End Sub


    Private Sub bindhuishouzhidang(ByVal backzhidang As String)
        Dim sennum As String() = backzhidang.Split("^")

        'Me.hsTXTjz.Text = sennum(0)
        'Me.hsTXTlc.Text = sennum(1)
        'Me.hsTXTjs.Text = sennum(2)
        'Me.hsTXTsf.Text = sennum(3)
        'hsTXTkkd.Text = sennum(4)
        'hsTXTzy.Text = sennum(5)
        'hsTXTyd.Text = sennum(6)
        'hsTXTjckf.Text = sennum(7)
        'hsTXTcjm.Text = sennum(8)
        'hsTXTsdgc.Text = sennum(9)
        'hsTXTsdlc.Text = sennum(10)
        'hsTXTcae.Text = sennum(11)
        'hsTXThalt.Text = sennum(12)
        'hsTXTys.Text = sennum(13)
        'hsTXTglc.Text = sennum(14)
        'hsTXTpbk.Text = sennum(15)
        'hsTXTyxzh.Text = sennum(16)
        'hsTXTzcjc.Text = sennum(17)
        'hsTXTsmt.Text = sennum(18)
        'hsTXTscy.Text = sennum(19)
        'hsTXTjmyqyf.Text = sennum(20)
        'hsTXTscjc.Text = sennum(21)

    End Sub
#End Region
    <WebMethod()> _
Public Shared Function GetFileInfo(ByVal ApplyDept As String, ByVal FileLayer As String) As List(Of DictionaryEntry)

        Dim mfileinfo As List(Of DictionaryEntry) = QC_FileInfoDAL.GetReadFileInfoListall(ApplyDept, FileLayer)
        Return mfileinfo
    End Function
    <WebMethod()> _
Public Shared Function GetFileLayer(ByVal ApplyDept As String) As String

        Dim filelayers As String = QC_FileInfoDAL.QC_fILE_GetFilelayerByApplyDept(ApplyDept)
        Return filelayers
    End Function
    <WebMethod()> _
    Public Shared Function ReturnNullData() As List(Of DictionaryEntry)
        Dim mList As New List(Of DictionaryEntry)
        mList.Add(New DictionaryEntry("", ""))
        Return mList
    End Function

#Region "SendMail"
    ''' <summary>
    ''' 發送郵件
    ''' </summary>
    ''' <param name="AddressList">地址</param>
    ''' <param name="Title">標題</param>
    ''' <param name="infomation">郵件內容</param>
    ''' <remarks></remarks>
    Public Shared Sub SendMail(ByVal AddressList As String, ByVal Title As String, ByVal infomation As String)
        Dim mailTo As String()
        If Not AddressList = "" AndAlso AddressList IsNot Nothing Then
            mailTo = AddressList.Split(",")
            'mailTo = New String() {"lamei.lm.yin@mail.foxconn.com"}
            Dim MailSystem As New MailSystem
            Dim rs As Boolean = MailSystem.SendMail(mailTo, Nothing, Nothing, Title, True, infomation)
        End If
    End Sub
    Private Sub SendMail(ByVal SendList As String(), ByVal Title As String, ByVal infomation As String)
        Dim MailSystem As New MailSystem
        Dim rs As Boolean = MailSystem.SendMail(SendList, Nothing, Nothing, Title, True, infomation)
    End Sub

    Public Shared Function GetAddress(ByVal NextUserList As String) As String
        Dim Address As New StringBuilder
        If NextUserList.Length > 0 Then
            Dim peoples As String() = NextUserList.Split("^")
            Dim index As Integer
            For index = 0 To peoples.Length - 1
                If peoples(index).Length > 0 Then
                    Dim ItemEmail As String = UserInfo.GetSpecAccountInfo(peoples(index).Split(":")(3)).Email1
                    Address.Append(ItemEmail)
                    Address.Append(",")
                End If
            Next
        End If

        '去掉最後一個逗號
        Dim LastStr As String = Address.ToString
        LastStr = RemoveLastStr(LastStr)
        Return LastStr
    End Function
    ''' <summary>
    ''' 去掉最後一個逗號
    ''' </summary>
    ''' <param name="SourceStr"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function RemoveLastStr(ByVal SourceStr As String) As String
        Dim result As String = SourceStr
        If result.Length > 0 AndAlso result.Substring(result.Length - 1, 1) = "," Then
            result = result.Substring(0, result.Length - 1)
        End If
        Return result
    End Function

    Private Sub DealSenmailParameter()

    End Sub
#End Region

    Protected Sub LinkFile_Click(ByVal sender As Object, ByVal e As EventArgs) Handles LinkFile.Click
        Dim FileT As String = String.Empty
        Select Case QCFileInfo.FileLayer
            Case "QM"
                FileT = 0
            Case "QP"
                FileT = 0
            Case "WI"
                FileT = 1
            Case "QF"
                FileT = 2
        End Select
        Dim FILEURL As String = String.Format("../Forms/QCFileDetail.aspx?pkid={0}&eFlowDocID={1}&Type={2}", PKID, DocUniqueID, FileT.ToString)
        Response.Redirect(FILEURL)
    End Sub
    
    
    Protected Sub Repeater2_ItemCreated(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.RepeaterItemEventArgs) Handles Repeater2.ItemCreated
        If ((e.Item.ItemIndex + 1) Mod 2) = 0 Then
            e.Item.Controls.Add(New LiteralControl("</tr><tr border='1px' style='border:1px; '>"))

        End If

    End Sub

    Protected Sub Repeater3_ItemCreated(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.RepeaterItemEventArgs) Handles Repeater3.ItemCreated
        If ((e.Item.ItemIndex + 1) Mod 2) = 0 Then
            e.Item.Controls.Add(New LiteralControl("</tr><tr border='1px' style='border:1px; '>"))

        End If
    End Sub

    Protected Sub LinkPrint_Click(ByVal sender As Object, ByVal e As EventArgs) Handles LinkPrint.Click
        Response.Redirect("../Forms/QcFilePrint.aspx?pkid=" + PKID.ToString)
    End Sub

    Protected Sub LinkEmail_Click(ByVal sender As Object, ByVal e As EventArgs) Handles LinkEmail.Click
        Dim EmailList As StringBuilder = New StringBuilder()
        Dim URL As String = "</br><a href ='" + Global_asax.UrlBase + String.Format("/default.aspx?PageType={1}&eFlowDocID={0}&pkid={2}&Type={3}", DocUniqueID, "qcfile", PKID, CurType) + "'>點擊此處進入查看</a>"
        Dim TitlesTR As String = String.Format("您好！{0}于{1}填寫的品管系統{2}文件已發行，請知曉.", QCFileInfo.ApplyUser, QCFileInfo.ApplyDate, QCFileInfo.FileName)
        Dim ds As DataSet = SqlHelper.ExecuteDataset(ConfigurationInfo.ConnectionString, "MailsendSet_GetMailByQyandDept", QCFileInfo.NeedAround, QCFileInfo.SendDept)
        Dim dt As DataTable = ds.Tables(0)
        Dim dr As DataRow
        Dim i As Integer
        If dt.Rows.Count > 0 Then
            For i = 0 To dt.Rows.Count - 1
                dr = dt.Rows(i)
                EmailList.Append(dr.Item("UserEmail") + ",")
            Next
        End If
        Dim allemail As String = EmailList.ToString
        allemail = allemail.Substring(0, allemail.Length - 1)
        If allemail <> String.Empty Then
            SendMail(allemail, TitlesTR, TitlesTR + URL)
        End If





    End Sub
End Class