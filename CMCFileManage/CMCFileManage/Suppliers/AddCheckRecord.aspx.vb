Imports Platform.eAuthorize

Partial Public Class AddCheckRecord
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            If Not Request.QueryString("supplierpkid") Is Nothing Then
                Me.TxtCheckDate.Attributes.Add("readonly", True)
                Me.TxtCheckDate.Attributes.Add("onclick", "javascript:WdatePicker({isShowClear:false,startDate:'%y-%M-01',dateFmt:'yyyy-MM-dd'});")
                Me.TxtCheckDate.Text = DateTime.Now.ToShortDateString
                Me.TxtCheckPerson.Text = UserInfo.CurrentUserCHName
            End If
        End If
    End Sub

    Protected Sub BtnSave_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BtnSave.Click
        If Not Request.QueryString("supplierpkid") Is Nothing Then
            Dim curcheckrecordinfo As CheckRecordInfo = New CheckRecordInfo()
            curcheckrecordinfo.PKID = 0
            curcheckrecordinfo.ParentPKID = Convert.ToInt32(Request.QueryString("supplierpkid"))
            curcheckrecordinfo.CheckDate = Me.TxtCheckDate.Text
            curcheckrecordinfo.CheckPerson = Me.TxtCheckPerson.Text
            curcheckrecordinfo.Others = Me.TxtOthers.Text
            curcheckrecordinfo.Remark = Me.TxtRemark.Text
            curcheckrecordinfo.Quality = Me.RdoQuality.SelectedValue
            curcheckrecordinfo.Service = Me.RdoService.SelectedValue
            curcheckrecordinfo.Delivery = Me.RdoDelivery.SelectedValue
            curcheckrecordinfo.IsOK = Me.RdoISok.SelectedValue
            curcheckrecordinfo.RecordCreated = DateTime.Now
            curcheckrecordinfo.RecordDeleted = 0

            Dim curcheckdal As CheckRecordDAL = New CheckRecordDAL(curcheckrecordinfo)
            curcheckdal.Save()

            Response.Write("<script>window.opener.refreshview();window.close(); </script>")
        End If
    End Sub

    Protected Sub BtnCancel_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BtnCancel.Click
        Response.Write("<script>window.opener=null;window.close(); </script>")
    End Sub
End Class