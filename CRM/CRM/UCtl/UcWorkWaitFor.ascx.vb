Imports Platform.eAuthorize

Partial Public Class UcWorkWaitFor
    Inherits System.Web.UI.UserControl

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then

            BindDatalist()
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
            Dim LbNo As Label = CType(e.Item.FindControl("LbNo"), Label)
            Dim LBCustomerName As Label = CType(e.Item.FindControl("LBCustomerName"), Label)
            Dim LbWaitTime As Label = CType(e.Item.FindControl("LbWaitTime"), Label)
            Dim LbCreateTime As Label = CType(e.Item.FindControl("LbCreateTime"), Label)
            If Not LbCreateTime Is Nothing AndAlso LbCreateTime.Text.Trim <> String.Empty Then
                Dim startdate As DateTime = CDate(LbCreateTime.Text)
                If Not LbURL Is Nothing AndAlso LbURL.Text.Trim <> String.Empty Then
                    Dim Length As Integer = LbURL.Text.IndexOf("&") - LbURL.Text.IndexOf("=") - 1
                    Dim type As String = LbURL.Text.Substring(LbURL.Text.IndexOf("=") + 1, Length)
                    Dim eflowhrf As HtmlControls.HtmlAnchor = CType(e.Item.FindControl("eflowhrf"), HtmlControls.HtmlAnchor)
                    If UserInfo.IsInRoles("ZHONGXINZHUGUAN") OrElse UserInfo.IsInRoles("TEDINGSHENHE") Then
                        eflowhrf.HRef = eflowhrf.HRef + "&userid=" + UserInfo.CurrentUserID + "&pass=" + UserInfo.CurrentUserInstance.Password
                    End If
                    Select Case type
                        Case "QUOTATION"
                            Dim eFlowDocID As String = LbURL.Text.Substring(LbURL.Text.IndexOf("EFLOWDOCID=") + 11, 36)
                            Dim curquotation As QuotationInfo = New QuotationInfo()
                            curquotation = QuotationDAL.GetInfoByeFLowdocID(eFlowDocID)
                            If Not curquotation Is Nothing Then
                                LbNo.Text = curquotation.QuotationNO
                                LBCustomerName.Text = curquotation.CustomerName
                            End If
                        Case "REPORT"
                            Dim eFlowDocID As String = LbURL.Text.Substring(LbURL.Text.IndexOf("EFLOWDOCID=") + 11, 36)
                            Dim curquotation As QuotationInfo = New QuotationInfo()

                            Dim reportinfo As ReportDetailInfo = ReportDetailDAL.GetInfoByeFLowdocID(eFlowDocID)
                            If Not reportinfo Is Nothing Then
                                curquotation = QuotationDAL.GetInfoByPKID(reportinfo.QuotationPKID)
                            End If
                            If Not curquotation.PKID = 0 Then
                                LbNo.Text = curquotation.QuotationNO
                                LBCustomerName.Text = curquotation.CustomerName
                            End If
                        Case "CUSCHANGE"
                            Dim eFlowDocID As String = LbURL.Text.Substring(LbURL.Text.IndexOf("EFLOWDOCID=") + 11, 36)
                            Dim cusgradechange As CustomerGradeChangeRecordInfo = CustomerGradeChangeRecordDAL.GetInfoByeFLowdocID(eFlowDocID)
                            If Not cusgradechange Is Nothing Then
                                Dim Label1 As Label = CType(e.Item.FindControl("Label1"), Label)
                                Dim Label2 As Label = CType(e.Item.FindControl("Label2"), Label)
                                Label2.Text = "類型"
                                Label1.Text = "申請人"
                                LbNo.Text = "客戶等級變更"
                                LBCustomerName.Text = cusgradechange.ChangePerson
                            End If
                    End Select
                    LbWaitTime.Text = DateDiff(DateInterval.Hour, startdate, DateTime.Now)
                End If
            End If
        End If
    End Sub
End Class