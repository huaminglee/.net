Imports Platform.eAuthorize

Partial Public Class OtherFileDetail
    Inherits System.Web.UI.Page
#Region "Const"
    Private Const _RequestType As String = "ViewState:Type"
    Private Const HIDE_APPLICANTIDX_KEY As String = "ViewState:PKID"
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


    Private _OtherFileInfo As StandardFileManageInfo
    Private Property OtherFileInfo() As StandardFileManageInfo
        Get
            If _OtherFileInfo Is Nothing Then
                If PKID <> 0 Then
                    _OtherFileInfo = StandardFileManageDAL.GetInfoByPKID(PKID)

                Else
                    _OtherFileInfo = New StandardFileManageInfo()

                End If
            End If
            Return _OtherFileInfo
        End Get
        Set(ByVal value As StandardFileManageInfo)
            _OtherFileInfo = value
        End Set
    End Property
    ''' <summary>
    ''' 附件主表PKID
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
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
            ViewState(HIDE_ParentCategory) = Value
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
            ViewState(HIDE_ParentSubCategory) = Value
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
            ViewState(ischange) = value.ToString
        End Set
    End Property
    ''''<summary>
    ''''當前請求狀態
    ''''</summary>
    'Private Property CurType() As String
    '    Get
    '        Return CStr(ViewState(_RequestType))
    '    End Get
    '    Set(ByVal Value As String)
    '        ViewState(_RequestType) = Value
    '    End Set
    'End Property
#End Region
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            GetRequestParam()
            Me.UcFileDetail2.CanUpload = False
            Me.UcFileDetail3.CanUpload = False
            Me.UcFileDetail2.CanRemove = False
            Me.UcFileDetail3.CanRemove = False
            If UserInfo.CurrentUserInstance Is Nothing Then
                Me.LinkEdit.Visible = False
                Me.UcFileDetail1.CanUpload = False
                Me.UcFileDetail4.CanUpload = False
            End If
            If UserInfo.IsInRoles("LabFileManager") Then
                Me.LinkEdit.Visible = True
                Me.UcFileDetail1.CanRemove = True
                Me.UcFileDetail4.CanRemove = True
                Me.UcFileDetail4.CanUpload = True
                Me.UcFileDetail1.CanUpload = True
                Me.UcFileDetail2.CanRemove = True
                Me.UcFileDetail3.CanRemove = True
            Else
                Me.LinkEdit.Visible = False
                Me.UcFileDetail2.CanRemove = False
                Me.UcFileDetail3.CanRemove = False
                Me.UcFileDetail1.CanRemove = False
                Me.UcFileDetail4.CanRemove = False
                Me.UcFileDetail1.CanUpload = False
                Me.UcFileDetail4.CanUpload = False
            End If
            Me.UcFileDetail2.ParentID = PKID
            Me.UcFileDetail3.ParentID = PKID
 
            Me.UcFileDetail2.FileSize = ConfigurationManager.AppSettings("UploadMaxSize")
            Me.UcFileDetail3.FileSize = ConfigurationManager.AppSettings("UploadMaxSize")
            Me.UcFileDetail2.ParentCategory = 4
            Me.UcFileDetail3.ParentCategory = 4
            Me.UcFileDetail1.ParentID = PKID
            Me.UcFileDetail4.ParentID = PKID
            Me.UcFileDetail1.ParentCategory = 4
            Me.UcFileDetail4.ParentCategory = 4
            Me.UcFileDetail4.ParentSubCategory = 12
            Me.UcFileDetail1.ParentSubCategory = 11
            Me.UcFileDetail3.ParentSubCategory = 12
            Me.UcFileDetail2.ParentSubCategory = 11
            Me.Label1.Text = "測試標準管理"
            Me.Label7.Text = "標準組織"
            Me.Label2.Text = "標準號碼"
            Me.Label3.Text = "標準名稱"

            Me.remark.Visible = False

            Dim dt As DataTable = QC_UserParameterDAL.GetInfoByCategory("Dept")
            If Not dt Is Nothing Then
                Me.DPLDepth.DataSource = dt
                Me.DPLDepth.DataTextField = "ParameterText"
                Me.DPLDepth.DataValueField = "ParameterValue1"
                Me.DPLDepth.DataBind()
            End If
            Dim dt2 As DataTable = QC_UserParameterDAL.GetInfoByCategory("QY")
            If Not dt Is Nothing Then
                Me.DplQuyuLocation.DataSource = dt2
                Me.DplQuyuLocation.DataTextField = "ParameterText"
                Me.DplQuyuLocation.DataValueField = "ParameterValue2"
                Me.DplQuyuLocation.DataBind()
            End If
            BindControlData()

        End If
    End Sub
    Private Sub GetRequestParam()
        If Not Request.QueryString("pkid") Is Nothing Then
            PKID = Convert.ToInt32(Request.QueryString(Global_asax.QUERY_APPLICANTIDX))


        End If
        'If Not Request.QueryString("Type") Is Nothing Then
        '    CurType = Request.QueryString("Type").ToString
        'End If
    End Sub
    Private Sub BindControlData()
        If Not OtherFileInfo Is Nothing Then
            If PKID <> 0 Then

                Me.UcFileDetail2.IsOld = 1
                Me.UcFileDetail3.IsOld = 1
                Me.UcFileDetail2.FileType = "Stand"
                Me.UcFileDetail3.FileType = "Stand"

                Me.TxtApplyUser.Text = OtherFileInfo.ApplyUser

                Me.TxtFileBH.Text = OtherFileInfo.StandardNumber
                Me.TxtFileName.Text = OtherFileInfo.StandardName
                Me.TxtLaiyuan.Text = OtherFileInfo.StandardOrganize
                Me.TxtRemark.Text = OtherFileInfo.Remark
                Me.TxtStandardVersion.Text = OtherFileInfo.StandardVersion



                Me.DPLDepth.SelectedItem.Text = OtherFileInfo.StandardDept
                Me.DplQuyuLocation.SelectedItem.Text = OtherFileInfo.QYLocation
                Select Case OtherFileInfo.StandardStatus
                    Case 0
                        Me.CHBztck.Checked = False
                        Me.CHBztsy.Checked = False
                    Case 1
                        Me.CHBztck.Checked = True
                    Case 2
                        Me.CHBztsy.Checked = True
                    Case 3
                        Me.CHBztsy.Checked = True
                        Me.CHBztck.Checked = True
                End Select
                Select Case OtherFileInfo.StandardSaveType
                    Case 0
                        Me.CHBccdzd.Checked = False
                        Me.CHBcczd.Checked = False
                    Case 2
                        Me.CHBccdzd.Checked = True
                    Case 1
                        Me.CHBcczd.Checked = True
                    Case 3
                        Me.CHBcczd.Checked = True
                        Me.CHBccdzd.Checked = True
                End Select
                Me.TxtApplyUser.Enabled = False

                Me.TxtFileBH.Enabled = False
                Me.TxtFileName.Enabled = False
                Me.TxtLaiyuan.Enabled = False
                Me.TxtRemark.Enabled = False
                Me.TxtStandardVersion.Enabled = False

                Me.DPLDepth.Enabled = False
                Me.CHBztck.Enabled = False
                Me.CHBccdzd.Enabled = False
                Me.CHBztsy.Enabled = False
                Me.CHBcczd.Enabled = False
                Me.DplQuyuLocation.Enabled = False
            ElseIf PKID = 0 Then
                Me.LinkEdit.Visible = False
                Me.LinkSave.Visible = True
            End If

            BindHisGrid(PKID)
        End If
    End Sub
    Public Sub BindHisGrid(ByVal RecordPKID As Integer)
        Dim dt As DataTable = Record_ChangeHistoryDAL.GetInfoByRecordPKID(PKID, 0)
        If Not dt Is Nothing Then
            Me.GridView1.DataSource = dt
            Me.GridView1.DataBind()
        End If
    End Sub
    Protected Sub LinkEdit_Click(ByVal sender As Object, ByVal e As EventArgs) Handles LinkEdit.Click
       
        Me.LinkSave.Visible = True
        Me.LinkEdit.Visible = False
        Me.TxtApplyUser.Enabled = True
      
        Me.TxtFileBH.Enabled = True
        Me.TxtFileName.Enabled = True
        Me.TxtLaiyuan.Enabled = True
        Me.TxtRemark.Enabled = True
        Me.TxtStandardVersion.Enabled = True
       
        Me.DPLDepth.Enabled = True
        Me.CHBztck.Enabled = True
        Me.CHBccdzd.Enabled = True
        Me.CHBztsy.Enabled = True
        Me.CHBcczd.Enabled = True
        Me.DplQuyuLocation.Enabled = True

    End Sub

    Protected Sub LinkSave_Click(ByVal sender As Object, ByVal e As EventArgs) Handles LinkSave.Click
        OtherFileInfo.PKID = PKID
        OtherFileInfo.ApplyUser = Me.TxtApplyUser.Text

       

        OtherFileInfo.QYLocation = Me.DplQuyuLocation.SelectedItem.Text
        OtherFileInfo.RecordCreated = DateTime.Now
        OtherFileInfo.RecordDeleted = 0
        OtherFileInfo.Remark = Me.TxtRemark.Text
        OtherFileInfo.StandardDept = Me.DPLDepth.SelectedItem.Text
        OtherFileInfo.StandardName = Me.TxtFileName.Text
        OtherFileInfo.StandardNumber = Me.TxtFileBH.Text
        OtherFileInfo.StandardOrganize = Me.TxtLaiyuan.Text

        If CHBccdzd.Checked = False AndAlso CHBcczd.Checked = False Then
            OtherFileInfo.StandardSaveType = 0
        End If
        If Me.CHBccdzd.Checked = True Then
            OtherFileInfo.StandardSaveType = 2
        End If
        If CHBcczd.Checked = True Then
            OtherFileInfo.StandardSaveType = 1
        End If
        If CHBccdzd.Checked = True AndAlso CHBcczd.Checked = True Then
            OtherFileInfo.StandardSaveType = 3
        End If

        If Me.CHBztck.Checked = False AndAlso Me.CHBztsy.Checked = False Then
            OtherFileInfo.StandardStatus = 0
        End If
        If Me.CHBztck.Checked = True Then
            OtherFileInfo.StandardStatus = 1
        End If
        If Me.CHBztsy.Checked = True Then
            OtherFileInfo.StandardStatus = 2
        End If
        If Me.CHBztck.Checked = True AndAlso Me.CHBztsy.Checked = True Then
            OtherFileInfo.StandardStatus = 3
        End If
        OtherFileInfo.StandardVersion = Me.TxtStandardVersion.Text
        OtherFileInfo.RecordStype = 1
        OtherFileInfo.RecordCreated = DateTime.Now
        Dim otherfiledal As StandardFileManageDAL = New StandardFileManageDAL(OtherFileInfo)
        PKID = otherfiledal.Save()


        Dim recordchangehis As Record_ChangeHistoryInfo = New Record_ChangeHistoryInfo()
        recordchangehis.PKID = 0
        recordchangehis.RecordPKID = PKID
        recordchangehis.ChangeTime = DateTime.Now
        recordchangehis.ChangeUser = UserInfo.CurrentUserCHName
        recordchangehis.ChangeCategory = 0
        recordchangehis.RecordDeleted = 0
        recordchangehis.RecordCreated = DateTime.Now
        Dim recorddal As Record_ChangeHistoryDAL = New Record_ChangeHistoryDAL(recordchangehis)
        recorddal.Save()
        Me.UcFileDetail1.ParentID = PKID
        Me.UcFileDetail4.ParentID = PKID
        Me.UcFileDetail4.SaveDatatoDataBase()
        Me.UcFileDetail1.SaveDatatoDataBase()
        Me.UcFileDetail2.ParentID = PKID
        Me.UcFileDetail3.ParentID = PKID
        UcFileDetail2.SaveDatatoDataBase()                  '附加檔案
        UcFileDetail3.SaveDatatoDataBase()                  '文件內容

        Response.Redirect("../Forms/OtherFileList.aspx")
    End Sub

    Protected Sub LinkLeave_Click(ByVal sender As Object, ByVal e As EventArgs) Handles LinkLeave.Click
        Response.Redirect("../Forms/OtherFileList.aspx")
    End Sub
End Class