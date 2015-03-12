Public Partial Class QcFilePrint
    Inherits System.Web.UI.Page
    Private _QCFileInfo As QC_FileInfoInfo
    Private Const HIDE_APPLICANTIDX_KEY As String = "ViewState:PKID"
    Private Const HIDE_DOCUNIQUEID_KEY As String = "ViewState:DocUniqueID"
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
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            GetRequestParam()
            BindRepeater2()
            BindRepeater3()
            BindControldata()
        End If
    End Sub
    Private Sub GetRequestParam()
        If Not Request.QueryString(Global_asax.QUERY_APPLICANTIDX) Is Nothing AndAlso Request.QueryString(Global_asax.QUERY_APPLICANTIDX) <> "" Then
            PKID = Convert.ToInt32(Request.QueryString(Global_asax.QUERY_APPLICANTIDX))
            DocUniqueID = QCFileInfo.eFlowDocID.ToString
        End If
    End Sub
    Private Sub BindControldata()
        If QCFileInfo.PKID <> 0 Then
            Me.LbApplydate.Text = QCFileInfo.ApplyDate
            Me.LbApplyDept.Text = QCFileInfo.ApplyDept
            Me.LbApplyUser.Text = QCFileInfo.ApplyUser
            Me.LbChangeaft.Text = QCFileInfo.ChangeBehDes
            Me.LbChangebef.Text = QCFileInfo.ChangePreDes
            Me.LbChangeReason.Text = QCFileInfo.ChangeReason
            If QCFileInfo.EffectDate = "9999-12-31" Then
                Me.LbEffectDate.Text = "未生效"
            Else
                Me.LbEffectDate.Text = QCFileInfo.EffectDate
            End If
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
            End If
            Me.LbFileBH.Text = QCFileInfo.FileBH
            Me.LbFileName.Text = QCFileInfo.FileName
            Me.LbFileVersion.Text = QCFileInfo.FileVersion
            Me.Lblabtecnicperson.Text = QCFileInfo.LabTechniqueCharge
            Me.LbRecordNo.Text = QCFileInfo.RecordNO
            Me.LbTeachDept.Text = QCFileInfo.TeachDept
            If QCFileInfo.RecordType = 1 Then
                Me.LbTitle.Text = "文件新版發行通知單"
            ElseIf QCFileInfo.RecordType = 2 Then
                Me.LbTitle.Text = "文件更版發行通知單"
            ElseIf QCFileInfo.RecordType = 3 Then
                Me.LbTitle.Text = "文件作廢通知單"
            End If
            Me.LbTotalpages.Text = QCFileInfo.ToTalPage
            Me.LbZdfenshu.Text = QCFileInfo.SendPaperNums
            Select Case QCFileInfo.CounterSignType
                Case 0
                    Me.CheckBox3.Checked = True
                Case 1
                    Me.CheckBox1.Checked = True

                Case 2
                    Me.CheckBox2.Checked = True
            End Select
            Me.RadioButtonList1.SelectedValue = QCFileInfo.IsTeach

            If QCFileInfo.SendNum <> "" Then
                Dim sennum As String() = QCFileInfo.SendNum.Split("^")
                Dim fenfadanwei As Integer = QCFileInfo.SendDept
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

            If QCFileInfo.RecordType = 2 Then
                Me.back1.Visible = True
                Me.back2.Visible = True
                Dim sennum As String() = QCFileInfo.BackSum.Split("^")
                Dim rpi As RepeaterItem
                Dim i As Integer = 0
                For Each rpi In Repeater3.Items
                    Dim TxtzdNums As TextBox = CType(rpi.FindControl("TxtzdNums"), TextBox)
                    Dim CHBdept As CheckBox = CType(rpi.FindControl("CHBdept"), CheckBox)
                    Dim divzdnums As HtmlControls.HtmlGenericControl = CType(rpi.FindControl("divzdnums"), HtmlControls.HtmlGenericControl)
                    If (QCFileInfo.BackDept And 2 ^ i) = 2 ^ i Then
                        CHBdept.Checked = True
                        divzdnums.Attributes.Add("style", "display:inline; float:right")
                        TxtzdNums.Text = sennum(i)
                    End If
                    i += 1
                Next
            End If
        End If
    End Sub
    Private Sub BindRepeater2()
        Dim dt As DataTable = QC_UserParameterDAL.GetInfoByCategory("Dept")
        If Not dt Is Nothing Then
            Me.Repeater2.DataSource = dt
            Me.Repeater2.DataBind()
        End If
    End Sub
    Private Sub BindRepeater3()
        Dim dt As DataTable = QC_UserParameterDAL.GetInfoByCategory("Dept")
        If Not dt Is Nothing Then
            Me.Repeater3.DataSource = dt
            Me.Repeater3.DataBind()
        End If
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
End Class