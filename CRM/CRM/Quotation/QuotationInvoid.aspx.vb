Imports Platform.eAuthorize
Imports Platform.eHR.Core
Imports Platform.Framework


Partial Public Class QuotationInvoid
    Inherits System.Web.UI.Page
    Private Property QuotationPKID() As Integer
        Get
            If Not ViewState("QuotationPKID") Is Nothing Then

                Return CInt(ViewState("QuotationPKID"))
            Else
                Return 0
            End If
        End Get
        Set(ByVal value As Integer)
            ViewState("QuotationPKID") = value
        End Set
    End Property
    Private Property ReportDetailPKID() As Integer
        Get
            If Not ViewState("ReportDetailPKID") Is Nothing Then

                Return CInt(ViewState("ReportDetailPKID"))
            Else
                Return 0
            End If
        End Get
        Set(ByVal value As Integer)
            ViewState("ReportDetailPKID") = value
        End Set
    End Property
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            If Not Request.QueryString("QuotationPKID") Is Nothing Then
                QuotationPKID = CInt(Request.QueryString("QuotationPKID"))
            End If
            If Not Request.QueryString("ReportDetailPKID") Is Nothing Then
                ReportDetailPKID = CInt(Request.QueryString("ReportDetailPKID"))
            End If
        End If
    End Sub

    Protected Sub BtnSave_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BtnSave.Click
        If QuotationPKID <> 0 Then

            Dim leaderaccount As List(Of AccountInfo) = AccountManage.LoadLeaderCollection(UserInfo.CurrentUserID)
            If Not leaderaccount Is Nothing Then

                Dim quotationinvolid As InvalidQuotationInfo = New InvalidQuotationInfo()
                quotationinvolid.PKID = 0
                quotationinvolid.QuotationPKID = QuotationPKID
                quotationinvolid.ReporDetailPKID = ReportDetailPKID
                quotationinvolid.AddDate = DateTime.Now
                quotationinvolid.AddUserID = UserInfo.CurrentUserID
                quotationinvolid.ConfirmDate = DateTime.MaxValue
                quotationinvolid.ConfirmUserID = leaderaccount(0).UserSID
                quotationinvolid.Reason = Me.TxtReason.Text.Trim
                quotationinvolid.Recorddeleted = 0
                quotationinvolid.Status = 1

                Dim quoinvaliddal As InvalidQuotationDAL = New InvalidQuotationDAL(quotationinvolid)
                quoinvaliddal.Save()

                Dim QUOINFO As QuotationInfo = QuotationDAL.GetInfoByPKID(QuotationPKID)
                Dim address As String = leaderaccount(0).Email1
                Dim Title As String = String.Format("您好，CRM報價單{0}申請異常結案，請執行審核動作", QUOINFO.QuotationNO)
                Dim info As String = Title + "</br><a href='" + Global_asax.UrlBase + String.Format("/Default.aspx?type=88&PageType=quotation&eFlowDocID={0}", QUOINFO.eFlowDocID) + "'>點此進入查看</a>"
                SendMail(address, Title, info)
                Response.Write("<script>alert('已送審'); </script>")
                Response.Write("<script>window.opener.thisclose();window.close(); </script>")
                '發郵件
            Else
                Response.Write("主管信息为空！")
            End If

        End If
    End Sub


    Public Shared Sub SendMail(ByVal AddressList As String, ByVal Title As String, ByVal infomation As String)
        Dim mailTo As String()
        If Not AddressList = "" AndAlso AddressList IsNot Nothing Then
            mailTo = AddressList.Split(",")
            Dim MailSystem As New MailSystem
            Dim rs As Boolean = MailSystem.SendMail(mailTo, Nothing, Nothing, Title, True, infomation)
        End If
    End Sub
End Class