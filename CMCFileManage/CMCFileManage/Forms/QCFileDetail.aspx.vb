Imports Platform.eAuthorize

Partial Public Class QCFileDetail
    Inherits System.Web.UI.Page
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
    Private Property CurType() As String
        Get
            Return CStr(ViewState(_RequestType))
        End Get
        Set(ByVal Value As String)
            ViewState(_RequestType) = Value
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
#End Region

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            If UserInfo.CurrentUserInstance Is Nothing Then
                Me.LinkFileChange.Attributes.Add("style", "display:none")
                Me.LinkFileInvalid.Attributes.Add("style", "display:none")
            End If
            GetRequestParam()

            BindConttrolData()
        End If
    End Sub
    Private Sub GetRequestParam()
        If Not Request.QueryString("pkid") Is Nothing Then
            PKID = Convert.ToInt32(Request.QueryString(Global_asax.QUERY_APPLICANTIDX))
            DocUniqueID = QCFileInfo.eFlowDocID.ToString

        End If
        If Not Request.QueryString("eFlowDocID") Is Nothing Then
            DocUniqueID = Request.QueryString("eFlowDocID").ToString
        End If
        If Not Request.QueryString("Type") Is Nothing Then
            CurType = Request.QueryString("Type")
        End If
        Dim dt As DataTable = QC_UserParameterDAL.GetInfoByCategory("Dept")
        If Not dt Is Nothing Then
            Me.DPLapplydept.DataSource = dt
            Me.DPLapplydept.DataTextField = "ParameterText"
            Me.DPLapplydept.DataValueField = "ParameterValue2"
            Me.DPLapplydept.DataBind()
        End If

    End Sub
    Private Sub BindConttrolData()
        If Not QCFileInfo Is Nothing AndAlso PKID <> 0 Then
            BindRepeater1()
            Me.UcFileDetail1.ParentID = PKID
            Me.UcFileDetail1.ParentCategory = 0
            Me.UcFileDetail1.ParentSubCategory = 1
            Me.UcFileDetail1.CanUpload = False
            Me.UcFileDetail1.CanRemove = False
            Me.UcFileDetail1.CanDownLoad = True
            Me.UcFileDetail2.ParentID = PKID
            Me.UcFileDetail2.ParentCategory = 0
            Me.UcFileDetail2.ParentSubCategory = 4
            Me.UcFileDetail2.CanUpload = False
            Me.UcFileDetail2.CanRemove = False
            Me.UcFileDetail2.CanDownLoad = True
            Me.UcFileDetail3.ParentID = PKID
            Me.UcFileDetail4.ParentID = PKID
            Me.UcFileDetail3.ParentCategory = 0
            Me.UcFileDetail4.ParentCategory = 0
            Me.UcFileDetail3.ParentSubCategory = 1
            Me.UcFileDetail4.ParentSubCategory = 4

            Me.UcFileDetail1.IsOld = 1
            Me.UcFileDetail2.IsOld = 1
            Me.UcFileDetail1.FileType = "QCFile"
            Me.UcFileDetail2.FileType = "QCFile"

            If QCFileInfo.StateOrder >= 9 And UserInfo.IsInRoles("QA") Then
                Me.UcFileDetail3.CanUpload = True
                Me.UcFileDetail4.CanUpload = True
                Me.UcFileDetail3.CanRemove = True
                Me.UcFileDetail4.CanRemove = True
                Me.UcFileDetail1.CanRemove = True
                Me.UcFileDetail2.CanRemove = True
                Me.UcFileDetail3.CanUpload = True
                Me.UcFileDetail4.CanUpload = True
                'Me.UcFileDetail2.CanUpload = True
                'Me.UcFileDetail2.CanRemove = True
                Me.LinkEdit.Visible = True
            Else
                Me.UcFileDetail3.CanUpload = False
                Me.UcFileDetail4.CanUpload = False
            End If
            Me.LBSysName.Text = QCFileInfo.Extend5
            Me.LBApplydepth.Text = QCFileInfo.ApplyDept
            Me.LBApplyUser.Text = QCFileInfo.ApplyUser
            Me.LBEffectime.Text = QCFileInfo.EffectDate
            Me.LBFileCategory.Text = QCFileInfo.FileCategory
            'Select Case QCFileInfo.FileCategory
            '    Case "1"
            '        LBFileCategory.Text = "校準程序"
            '    Case "2"
            '        LBFileCategory.Text = "操作規範"
            '    Case "3"
            '        LBFileCategory.Text = "作業規範"
            '    Case "4"
            '        LBFileCategory.Text = "管理要求"
            '    Case "5"
            '        LBFileCategory.Text = "技術要求"
            '    Case "6"
            '        LBFileCategory.Text = "其他"
            'End Select
            Select Case QCFileInfo.FileLayer
                Case "QM"
                    Me.LBFileLayer.Text = "一階文件"
                    Me.UcFileDetail1.CanDown = 1

                Case "QF"

                    Me.UcFileDetail2.ParentSubCategory = 4
                    Me.UcFileDetail1.ParentSubCategory = 0
                    Me.UcFileDetail3.ParentSubCategory = 0
                    Me.UcFileDetail4.ParentSubCategory = 4
                    Me.LBFileLayer.Text = "四階文件"
                Case "QP"
                    Me.UcFileDetail1.CanDown = 0
                    Me.LBFileLayer.Text = "二階文件"

                Case "WI"
                    Me.UcFileDetail1.CanDown = 1
                    Me.LBFileLayer.Text = "三階文件"
                    Me.LBFileCategory.Visible = True
            End Select


            Me.LBFileName.Text = QCFileInfo.FileName
            Me.LBFileNo.Text = QCFileInfo.FileBH
            Me.LBFileRecordNo.Text = QCFileInfo.RecordNO
            Me.LBFileTotalpage.Text = QCFileInfo.ToTalPage
            Me.LBFileversion.Text = QCFileInfo.FileVersion
            Me.LBQualityFinishUser.Text = QCFileInfo.Extend7
            Me.TxtQualityCB.Text = QCFileInfo.Extend7
            Me.TxtFileName.Text = QCFileInfo.FileName
            Me.Txtfiletotalpage.Text = QCFileInfo.ToTalPage
            Me.Txtfileversion.Text = QCFileInfo.FileVersion
            Me.TxtRecordNo.Text = QCFileInfo.RecordNO
            Me.TxtFileNo.Text = QCFileInfo.FileBH
            Me.DPLapplydept.SelectedIndex = Me.DPLapplydept.Items.IndexOf(Me.DPLapplydept.Items.FindByText(QCFileInfo.ApplyDept))
            Me.DPLfilecategory.SelectedIndex = Me.DPLfilecategory.Items.IndexOf(Me.DPLfilecategory.Items.FindByText(QCFileInfo.FileCategory))
            Me.DPLfilelayer.SelectedIndex = Me.DPLfilelayer.Items.IndexOf(Me.DPLfilelayer.Items.FindByText(QCFileInfo.FileLayer))
            If Not QCFileInfo.Extend5 = String.Empty Then
                Me.DropDownList1.SelectedIndex = Me.DropDownList1.Items.IndexOf(Me.DropDownList1.Items.FindByText(QCFileInfo.Extend5))
            End If
            bindfenfadanwei()


        End If
    End Sub
    Private Sub bindfenfadanwei()
        Dim fenfadanwei As Integer = QCFileInfo.SendDept
        Dim sennum As String() = QCFileInfo.SendNum.Split("^")

        Dim rpi As RepeaterItem
        Dim i As Integer = 0
        For Each rpi In Repeater1.Items
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
        'If (fenfadanwei And 2 ^ 22) = 2 ^ 22 Then
        '    Me.CHBjz.Checked = True
        '    Me.jz.Visible = True
        'End If
        'If (fenfadanwei And 2 ^ 21) = 2 ^ 21 Then
        '    Me.CHBlc.Checked = True
        '    Me.lc.Visible = True
        'End If
        'If (fenfadanwei And 2 ^ 20) = 2 ^ 20 Then
        '    Me.CHBjs.Checked = True
        '    Me.js.Visible = True
        'End If
        'If (fenfadanwei And 2 ^ 19) = 2 ^ 19 Then
        '    Me.CHBsf.Checked = True
        '    Me.sf.Visible = True
        'End If
        'If (fenfadanwei And 2 ^ 18) = 2 ^ 18 Then
        '    Me.CHBkkd.Checked = True
        '    Me.kkd.Visible = True
        'End If
        'If (fenfadanwei And 2 ^ 17) = 2 ^ 17 Then
        '    Me.CHBzy.Checked = True
        '    Me.zy.Visible = True
        'End If
        'If (fenfadanwei And 2 ^ 16) = 2 ^ 16 Then
        '    Me.CHByd.Checked = True
        '    Me.yd.Visible = True
        'End If
        'If (fenfadanwei And 2 ^ 15) = 2 ^ 15 Then
        '    Me.CHBjckf.Checked = True
        '    Me.jckf.Visible = True
        'End If
        'If (fenfadanwei And 2 ^ 14) = 2 ^ 14 Then
        '    Me.CHBcjm.Checked = True
        '    Me.cjm.Visible = True
        'End If
        'If (fenfadanwei And 2 ^ 13) = 2 ^ 13 Then
        '    Me.CHBsdgc.Checked = True
        '    Me.sdgc.Visible = True
        'End If
        'If (fenfadanwei And 2 ^ 12) = 2 ^ 12 Then
        '    Me.CHBsdlc.Checked = True
        '    Me.sdlc.Visible = True
        'End If
        'If (fenfadanwei And 2 ^ 11) = 2 ^ 11 Then
        '    Me.CHBcae.Checked = True
        '    Me.cae.Visible = True
        'End If
        'If (fenfadanwei And 2 ^ 10) = 2 ^ 10 Then
        '    Me.CHBhalt.Checked = True
        '    Me.halt.Visible = True
        'End If
        'If (fenfadanwei And 2 ^ 9) = 2 ^ 9 Then
        '    Me.CHBys.Checked = True
        '    Me.ys.Visible = True
        'End If
        'If (fenfadanwei And 2 ^ 8) = 2 ^ 8 Then
        '    Me.CHBglc.Checked = True
        '    Me.glc.Visible = True
        'End If
        'If (fenfadanwei And 2 ^ 7) = 2 ^ 7 Then
        '    Me.CHBpbk.Checked = True
        '    Me.pbk.Visible = True
        'End If
        'If (fenfadanwei And 2 ^ 6) = 2 ^ 6 Then
        '    Me.CHByxzh.Checked = True
        '    Me.yxzh.Visible = True
        'End If
        'If (fenfadanwei And 2 ^ 5) = 2 ^ 5 Then
        '    Me.CHBzcjc.Checked = True
        '    Me.zcjc.Visible = True
        'End If

        'If (fenfadanwei And 2 ^ 4) = 2 ^ 4 Then
        '    Me.CHBsmt.Checked = True
        '    Me.smt.Visible = True
        'End If
        'If (fenfadanwei And 2 ^ 3) = 2 ^ 3 Then
        '    Me.CHBscy.Checked = True
        '    Me.scy.Visible = True
        'End If
        'If (fenfadanwei And 2 ^ 2) = 2 ^ 2 Then
        '    Me.CHBjmyqyf.Checked = True
        '    Me.jmyqyf.Visible = True
        'End If
        'If (fenfadanwei And 2 ^ 1) = 2 ^ 1 Then
        '    Me.CHBscjc.Checked = True
        '    Me.scjc.Visible = True
        'End If
    End Sub

    Protected Sub LinkFileChangeForm_Click(ByVal sender As Object, ByVal e As EventArgs) Handles LinkFileChangeForm.Click
        Response.Redirect("../Forms/AddQCFileDetail.aspx?pkid=" + PKID.ToString + "&eFlowDocID=" + DocUniqueID)
    End Sub

    Protected Sub LinkFileChange_Click(ByVal sender As Object, ByVal e As EventArgs) Handles LinkFileChange.Click
        Dim isinchange As String = SqlHelper.ExecuteDataset(ConfigurationInfo.ConnectionString, "QC_ISinchange", PKID).Tables(0).Rows(0).Item("notfinishcount").ToString
        If isinchange = "0" Then
            Response.Redirect("../Forms/AddQCFileDetail.aspx?ParentID=" + PKID.ToString + "&ischange=1&Type=1")
        Else
            Page.ClientScript.RegisterStartupScript(Me.GetType(), "xxx", "<script language='javascript' defer>alert('該文件已處於變更中無法重複申請！');</script>")

        End If

    End Sub

    Protected Sub LinkFileInvalid_Click(ByVal sender As Object, ByVal e As EventArgs) Handles LinkFileInvalid.Click
        Dim isinchange As String = SqlHelper.ExecuteDataset(ConfigurationInfo.ConnectionString, "QC_ISinchange", PKID).Tables(0).Rows(0).Item("notfinishcount").ToString
        If isinchange = "0" Then
            Response.Redirect("../Forms/AddQCFileDetail.aspx?ParentID=" + PKID.ToString + "&ischange=1&Type=3")
        Else
            Page.ClientScript.RegisterStartupScript(Me.GetType(), "xxx", "<script language='javascript' defer>alert('該文件已處於變更中無法重複申請！');</script>")

        End If
    End Sub

    Protected Sub LinkLeave_Click(ByVal sender As Object, ByVal e As EventArgs) Handles LinkLeave.Click
        Response.Redirect("../Forms/QCFileList.aspx?Type=" + CurType)
    End Sub
    Private Sub BindRepeater1()
        Dim dt As DataTable = QC_UserParameterDAL.GetInfoByCategory("Dept")
        If Not dt Is Nothing Then
            Me.Repeater1.DataSource = dt
            Me.Repeater1.DataBind()
        End If
    End Sub
    Protected Sub Repeater1_ItemCreated(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.RepeaterItemEventArgs) Handles Repeater1.ItemCreated
        If ((e.Item.ItemIndex + 1) Mod 2) = 0 Then
            e.Item.Controls.Add(New LiteralControl("</tr><tr border='1px' style='border:1px; '>"))

        End If
    End Sub

    Protected Sub LinkEdit_Click(ByVal sender As Object, ByVal e As EventArgs) Handles LinkEdit.Click
        Me.LinkSave.Visible = True
        Me.LBQualityFinishUser.Visible = False
        Me.TxtQualityCB.Visible = True
        Me.LinkEdit.Visible = False
        Me.DropDownList1.Visible = True
        Me.LBSysName.Visible = False
        Me.Txtfileversion.Visible = True
        Me.TxtFileName.Visible = True
        Me.Txtfiletotalpage.Visible = True
        Me.TxtRecordNo.Visible = True
        Me.DPLapplydept.Visible = True
        Me.DPLfilecategory.Visible = True
        Me.DPLfilelayer.Visible = True
        Me.LBFileversion.Visible = False
        Me.LBFileName.Visible = False
        Me.LBFileTotalpage.Visible = False
        Me.LBApplydepth.Visible = False
        Me.LBFileCategory.Visible = False
        Me.LBFileLayer.Visible = False
        Me.LBFileRecordNo.Visible = False
        Me.LBFileNo.Visible = False
        Me.TxtFileNo.Visible = True
    End Sub

    Protected Sub LinkSave_Click(ByVal sender As Object, ByVal e As EventArgs) Handles LinkSave.Click
        QCFileInfo.Extend5 = Me.DropDownList1.SelectedItem.Text
        QCFileInfo.RecordNO = Me.TxtRecordNo.Text
        QCFileInfo.ToTalPage = Me.Txtfiletotalpage.Text
        QCFileInfo.ApplyDept = Me.DPLapplydept.SelectedItem.Text
        QCFileInfo.FileCategory = Me.DPLfilecategory.SelectedItem.Text
        QCFileInfo.FileLayer = Me.DPLfilelayer.SelectedItem.Text
        QCFileInfo.FileName = Me.TxtFileName.Text
        QCFileInfo.FileVersion = Me.Txtfileversion.Text
        QCFileInfo.FileBH = Me.TxtFileNo.Text
        QCFileInfo.Extend7 = Me.TxtQualityCB.Text
        LBSysName.Text = Me.DropDownList1.SelectedItem.Text
        Dim qcfildal As QC_FileInfoDAL = New QC_FileInfoDAL(QCFileInfo)
        qcfildal.Save()
        Me.UcFileDetail1.SaveDatatoDataBase()
        Me.UcFileDetail2.SaveDatatoDataBase()
        Me.UcFileDetail3.SaveDatatoDataBase()
        Me.UcFileDetail4.SaveDatatoDataBase()
        Response.Redirect("../Forms/QCFileDetail.aspx?pkid=" + PKID.ToString + "&Type=" + CurType.ToString)
        'Me.DropDownList1.Visible = False
        'Me.LBSysName.Visible = True
        'Me.UcFileDetail1.SaveDatatoDataBase()
        'Me.UcFileDetail2.SaveDatatoDataBase()
        'Me.UcFileDetail3.SaveDatatoDataBase()
        'Me.UcFileDetail4.SaveDatatoDataBase()
        'Me.LinkEdit.Visible = True
        'Me.LinkSave.Visible = False
    End Sub
End Class