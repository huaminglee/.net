Imports Platform.eAuthorize

Partial Public Class _Default
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then

            Dim userdelts As String = String.Empty
            If Not UserInfo.CurrentUserInstance Is Nothing Then
                If Not UserInfo.CurrentUserDept Is Nothing Then
                    For Each curdept In UserInfo.CurrentUserDept
                        userdelts += curdept.DeptName + ";"
                    Next
                    userdelts = userdelts.Substring(0, userdelts.Length - 1)
                End If
                Session.Timeout = 320
                Response.Cookies("userdepts").Value = HttpUtility.UrlEncode(userdelts)
                Response.Cookies("userdepts").Expires = DateTime.Now.AddYears(1)

                Session("username") = UserInfo.CurrentUserCHName
            ElseIf Session("username") Is Nothing Then
                Response.Redirect("Login.aspx")
            End If
            Platform.eFlowConfiguration.ConfigurationInfo._ChangQU = ""          '重置廠區
            GetRequestParam()
        End If
    End Sub
    Private Sub bindothercook()
        Dim fat As FormsAuthenticationTicket = New FormsAuthenticationTicket(1, UserInfo.CurrentUserID, DateTime.Now, DateTime.Now.AddHours(1), True, "")
        Dim cookie As HttpCookie = New HttpCookie(".BarAuth")
        cookie.Value = FormsAuthentication.Encrypt(fat)
        cookie.Expires = fat.Expiration
        HttpContext.Current.Response.Cookies.Add(cookie)
        FormsAuthentication.RedirectFromLoginPage(UserInfo.CurrentUserID, False)
    End Sub
    Private Sub GetRequestParam()

        Dim DocUniqueID As String = String.Empty
        If Not Request.QueryString(Global_asax.QUERY_DOCUNIQUEID) Is Nothing Then
            DocUniqueID = Request.QueryString(Global_asax.QUERY_DOCUNIQUEID)
        End If
        Dim PageType As String = String.Empty
        If Not Request.QueryString("PageType") Is Nothing Then
            PageType = Request.QueryString("PageType")
        End If
        Dim pkid As String = String.Empty
        If Not Request.QueryString("PKID") Is Nothing Then
            pkid = Request.QueryString("PKID")
        End If
        Dim Type As String = String.Empty
        If Not Request.QueryString("Type") Is Nothing Then
            Type = Request.QueryString("Type")
        End If
        Dim IsRole_TEST_EQUIPROLE As String = String.Empty
        If Not Request.QueryString("IsRole_TEST_EQUIPROLE") Is Nothing Then
            IsRole_TEST_EQUIPROLE = Request.QueryString("IsRole_TEST_EQUIPROLE")
        End If
        Dim ClientPKID As String = String.Empty
        Dim DeptPKID As String = String.Empty
        If Not Request.QueryString("ClientPKID") Is Nothing Then
            ClientPKID = Request.QueryString("ClientPKID")
        End If
        If Not Request.QueryString("DeptPKID") Is Nothing Then
            DeptPKID = Request.QueryString("DeptPKID")
        End If
        If PageType <> String.Empty Then
            Select Case PageType.ToLower
                Case "qcfile" 'qc文件
                    HidInitUrl.Value = String.Format("Forms/AddQcFileDetail.aspx?{0}={1}&type={2}", Global_asax.QUERY_DOCUNIQUEID, DocUniqueID, Type)
                Case "equipmanagefile" '設備附件
                    HidInitUrl.Value = String.Format("Forms/EquipFileDetail.aspx?{0}={1}", Global_asax.QUERY_DOCUNIQUEID, DocUniqueID)
                Case "equipmanage" '設備清單
                    HidInitUrl.Value = String.Format("Forms/EquipManageDetail.aspx?{0}={1}", Global_asax.QUERY_DOCUNIQUEID, DocUniqueID)
                Case "filedelete"
                    HidInitUrl.Value = String.Format("Forms/FileDeleteApplyDetail.aspx?{0}={1}", Global_asax.QUERY_DOCUNIQUEID, DocUniqueID)
                Case "fileread"
                    HidInitUrl.Value = String.Format("Forms/FileReadManageDetail.aspx?{0}={1}", Global_asax.QUERY_DOCUNIQUEID, DocUniqueID)
                Case "outfile"
                    HidInitUrl.Value = String.Format("Forms/OutFileDetail.aspx?{0}={1}&type={2}", Global_asax.QUERY_DOCUNIQUEID, DocUniqueID, Type)
                Case "supplier"
                    HidInitUrl.Value = String.Format("Suppliers/SuppliersDetail.aspx?{0}={1}&type={2}", Global_asax.QUERY_DOCUNIQUEID, DocUniqueID, Type)
                Case "satsur"  '客戶滿意度調查
                    HidInitUrl.Value = String.Format("GMPCSI/GMPCSIMoudle.aspx?ClientPKID={0}&DeptPKID={1}", ClientPKID, DeptPKID)
                Case "complaints" '客戶投訴
                    HidInitUrl.Value = String.Format("Forms/ComplaintsDetail.aspx?{0}={1}", Global_asax.QUERY_DOCUNIQUEID, DocUniqueID)
            End Select
        End If
    End Sub


End Class