Imports Platform.eAuthorize

Partial Public Class UcWorkWaitFor
    Inherits System.Web.UI.UserControl

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            If Not UserInfo.CurrentUserInstance Is Nothing Then
                BindDatalist()
            End If

        End If
    End Sub
    Private Sub BindDatalist()

        Dim usershili As Platform.eHR.Core.AccountInfo = UserInfo.GetSpecAccountInfo(UserInfo.CurrentUserID)
        Dim workscount As Integer = 0
        Dim ds As DataSet
        'If UserInfo.IsInRoles("ZHONGXINZHUGUAN") OrElse UserInfo.IsInRoles("TEDINGSHENHE") Then
        '    ds = SqlHelper.ExecuteDataset(ConfigurationInfo.ConnectionString, "WF_LoadAllQyWorkByUserSID", UserInfo.CurrentUserID)
        'Else
        '    ds = SqlHelper.ExecuteDataset(ConfigurationInfo.ConnectionString, "WF_LoadWaitWorkByUserPKID", usershili.AccountPKID)
        'End If
        ds = SqlHelper.ExecuteDataset(ConfigurationInfo.ConnectionString, "WF_LoadWaitWorkByUserPKID", usershili.AccountPKID)
        If Not ds Is Nothing Then
            Me.DataList1.DataSource = ds
            Me.DataList1.DataBind()
            workscount = ds.Tables(0).Rows.Count
            Me.LbWorkCount.Text = String.Format("您有{0}項事項待處理", workscount.ToString)
        End If
    End Sub

    Protected Sub DataList1_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataListItemEventArgs) Handles DataList1.ItemDataBound
        If e.Item.ItemType = ListItemType.AlternatingItem OrElse e.Item.ItemType = ListItemType.Item Then
            Dim LbURL As Label = CType(e.Item.FindControl("LbURL"), Label)
            Dim LbApplyPerson As Label = CType(e.Item.FindControl("LbApplyPerson"), Label)
            Dim LbDept As Label = CType(e.Item.FindControl("LbDept"), Label)
            Dim LbWaitTime As Label = CType(e.Item.FindControl("LbWaitTime"), Label)
            Dim LbCreateTime As Label = CType(e.Item.FindControl("LbCreateTime"), Label)
            If Not LbCreateTime Is Nothing AndAlso LbCreateTime.Text.Trim <> String.Empty Then
                Dim startdate As DateTime = CDate(LbCreateTime.Text)
                If Not LbURL Is Nothing AndAlso LbURL.Text.Trim <> String.Empty Then
                    Dim Length As Integer = LbURL.Text.IndexOf("&") - LbURL.Text.IndexOf("=") - 1
                    Dim type As String = LbURL.Text.Substring(LbURL.Text.IndexOf("=") + 1, Length)
                    Dim eflowhrf As HtmlControls.HtmlAnchor = CType(e.Item.FindControl("eflowhrf"), HtmlControls.HtmlAnchor)
                    
                    Select Case type.ToLower
                        Case "qcfile"
                            Dim eFlowDocID As String = LbURL.Text.Substring(LbURL.Text.IndexOf("EFLOWDOCID=") + 11, 36)

                            Dim _qcfileinfo As QC_FileInfoInfo = New QC_FileInfoInfo()
                            _qcfileinfo = QC_FileInfoDAL.GetInfoByeFLowdocID(eFlowDocID)
                            If Not _qcfileinfo Is Nothing Then
                                LbApplyPerson.Text = _qcfileinfo.ApplyUser
                                LbDept.Text = _qcfileinfo.ApplyDept
                            End If
                        Case "filedelete"
                            Dim eFlowDocID As String = LbURL.Text.Substring(LbURL.Text.IndexOf("EFLOWDOCID=") + 11, 36)
                            Dim _filedeleteinfo As QC_FileDeleteInfoInfo = New QC_FileDeleteInfoInfo()
                            _filedeleteinfo = QC_FileDeleteInfoDAL.GetInfoByeFlowDocID(eFlowDocID)

                            If Not _filedeleteinfo Is Nothing Then
                                LbApplyPerson.Text = _filedeleteinfo.AduitUser
                                LbDept.Text = _filedeleteinfo.FileDept
                            End If
                        Case "outfile"
                            Dim eFlowDocID As String = LbURL.Text.Substring(LbURL.Text.IndexOf("EFLOWDOCID=") + 11, 36)
                            Dim _outfileinfo As OutFileManageInfo = OutFileManageDAL.GetInfoByeFlowDocID(eFlowDocID)
                            If Not _outfileinfo Is Nothing Then
                                Dim Label2 As Label = CType(e.Item.FindControl("Label2"), Label)
                                Label2.Text = "文件名"
                                LbApplyPerson.Text = _outfileinfo.FileName
                                LbDept.Text = _outfileinfo.FileDept
                            End If
                        Case "fileread"
                            Dim eFlowDocID As String = LbURL.Text.Substring(LbURL.Text.IndexOf("EFLOWDOCID=") + 11, 36)
                            Dim _filereadinfo As FileReadManageInfo = FileReadManageDAL.GetInfoByeFlowDocID(eFlowDocID)
                            If Not _filereadinfo Is Nothing Then
                                LbApplyPerson.Text = _filereadinfo.ApplyUser
                                LbDept.Text = _filereadinfo.UseUserOrDept
                            End If
                    End Select
                    LbWaitTime.Text = DateDiff(DateInterval.Hour, startdate, DateTime.Now)
                End If
            End If
        End If
    End Sub
End Class