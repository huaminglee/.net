Imports Platform.eAuthorize
Imports System.Web.Services

Partial Public Class _Default
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            'Dim userdelts As String = String.Empty
            'If Not UserInfo.CurrentUserInstance Is Nothing Then
            '    If Not UserInfo.CurrentUserDept Is Nothing Then
            '        For Each curdept In UserInfo.CurrentUserDept
            '            userdelts += curdept.DeptName + ";"
            '        Next
            '        userdelts = userdelts.Substring(0, userdelts.Length - 1)
            '    End If
            '    Session("userdepts") = userdelts
            '    Session("username") = UserInfo.CurrentUserCHName
            'ElseIf Session("username") Is Nothing Then
            '    Response.Redirect("Login.aspx")
            'End If
            'Platform.eFlowConfiguration.ConfigurationInfo._ChangQU = ""          '重置廠區
            'If Not Session("username") Is Nothing Then
            '    Me.username.InnerText = Session("username").ToString
            'End If




            'FormsAuthentication.SetAuthCookie(UserInfo.CurrentUserID, False)
            'Dim cookie As HttpCookie = Response.Cookies(FormsAuthentication.FormsCookieName)
            'cookie.Domain = "10.162.197.5"
            'Response.Cookies.Add(cookie)
            'FormsAuthentication.RedirectFromLoginPage(UserInfo.CurrentUserID, False)
            Me.Page.Title = String.Format("客戶關係管理系統--{0}", ConfigurationManager.AppSettings("CQ"))
            Platform.eFlowConfiguration.ConfigurationInfo._ChangQU = ""
            Me.username.InnerText = UserInfo.CurrentUserCHName
            GetRequestParam()
            SetMenuShow()

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
    Protected Sub LKBlogoOUT_Click(ByVal sender As Object, ByVal e As EventArgs) Handles LKBlogoOUT.Click
        Authorization.Logout()
        Response.Redirect("Login.aspx")
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
        Dim CustomerPKID As String = String.Empty
        If Not Request.QueryString("CustomerPKID") Is Nothing Then
            CustomerPKID = Request.QueryString("CustomerPKID")
        End If
        If PageType <> String.Empty Then
            Select Case PageType.ToLower
                Case "quotation" '報價單處理
                    If Type <> String.Empty Then
                        HidInitUrl.Value = String.Format("Quotation/QuotationDetail.aspx?{0}={1}&type={2}", Global_asax.QUERY_DOCUNIQUEID, DocUniqueID, Type)
                    Else
                        HidInitUrl.Value = String.Format("Quotation/QuotationDetail.aspx?{0}={1}", Global_asax.QUERY_DOCUNIQUEID, DocUniqueID)

                    End If
                Case "cuschange" '客戶變更'
                    HidInitUrl.Value = String.Format("Forms/CustomerLevelChange.aspx?{0}={1}&type={2}&CustomerPKID={3}&pkid={4}", Global_asax.QUERY_DOCUNIQUEID, DocUniqueID, Type, CustomerPKID, pkid.ToString)

                Case "report" '報告處理
                    If DocUniqueID <> String.Empty Then
                        HidInitUrl.Value = String.Format("Quotation/ReportDetailDetail.aspx?{0}={1}", Global_asax.QUERY_DOCUNIQUEID, DocUniqueID)

                    ElseIf pkid <> String.Empty Then
                        HidInitUrl.Value = String.Format("Quotation/ReportDetailDetail.aspx?pkid={0}", pkid.ToString)

                    End If
                Case "customervisit"
                    HidInitUrl.Value = String.Format("Forms/CustomerVisitDetail.aspx?{0}={1}", Global_asax.QUERY_DOCUNIQUEID, DocUniqueID)
                Case "fileshare"
                    HidInitUrl.Value = String.Format("Forms/AddFileShareDetail.aspx?{0}={1}", Global_asax.QUERY_DOCUNIQUEID, DocUniqueID)
                Case "satsur"  '客戶滿意度調查
                    HidInitUrl.Value = String.Format("GMPCSI/GMPCSIMoudle.aspx?ClientPKID={0}&DeptPKID={1}", ClientPKID, DeptPKID)
                Case "complaints" '客戶投訴
                    HidInitUrl.Value = String.Format("Forms/ComplaintsDetail.aspx?{0}={1}", Global_asax.QUERY_DOCUNIQUEID, DocUniqueID)
            End Select
        End If
    End Sub
    Private Sub SetMenuShow()
        If Not UserInfo.CurrentUserInstance Is Nothing Then
            If UserInfo.IsInRoles("EXTERNALWORKER") Then
                Me.yewu1.Visible = True
                Me.yewu2.Visible = True

                Me.duizhang.Visible = True
                Me.Tongji.Visible = True
                Me.gonggao.Visible = True
                Me.usercenter.Visible = True
                Me.divSell.Visible = True
                Me.store.Visible = True
            End If
            If UserInfo.IsInRoles("CENTEREM") Then                 '中心經管
                Me.Tongji.Visible = True
                Me.gonggao.Visible = True
                Me.usercenter.Visible = True
                Me.leadreport.Visible = True
            End If
            If UserInfo.IsInRoles("CRM經管") Then                 '經管
                Me.jinguan.Visible = True
                Me.Tongji.Visible = True
                Me.gonggao.Visible = True
                Me.usercenter.Visible = True
                Me.leadreport.Visible = True
            End If
            If UserInfo.IsInRoles("ZHONGXINZHUGUAN") Then     '中心主管
                Me.zhuguanwork.Visible = True
                Me.manage.Visible = True
                Me.leadreport.Visible = True
                Me.Tongji.Visible = True
                Me.gonggao.Visible = True
            End If
            If UserInfo.IsInRoles("Yewuzhuguan") Then        '業務主管

                Me.yichang.Visible = True
                Me.zhuguanwork.Visible = True
                Me.manage.Visible = True
                Me.reportsh.Visible = True
                Me.leadreport.Visible = True
                Me.Tongji.Visible = True
                Me.gonggao.Visible = True
            End If
            If UserInfo.IsInRoles("OperationsAssistant") Then      '業務助理
                Me.yewu2.Visible = True
                Me.work3.Visible = False
                Me.worke2.Visible = False
                Me.gonggao.Visible = True
                Me.usercenter.Visible = True
                Me.store.Visible = True
            End If

            If UserInfo.IsInRoles("TEDINGSHENHE") Then         '授權主管
                Me.leadreport.Visible = True
                Me.zhuguanwork.Visible = True
                Me.usercenter.Visible = True
                Me.manage.Visible = True
                Me.reportsh.Visible = True
                Me.gonggao.Visible = True
            End If
            If UserInfo.IsInRoles("CRMTECSUPPORT") Then
                Me.work3.Visible = True
                Me.worke2.Visible = True
                Me.yewu2.Visible = True
                Me.gonggao.Visible = True
                Me.usercenter.Visible = True
                Me.store.Visible = True
            End If
            If UserInfo.IsInRoles("storekeeper") Then
                Me.store.Visible = True
            End If
            If UserInfo.IsInRoles("SYS_ADMINISTRATOR") Then
                If ConfigurationManager.AppSettings("CQ") = "SZ" Then
                    Me.itemmanage.Visible = True
                End If
                Me.store.Visible = True
                Me.yewu1.Visible = True
                Me.yewu2.Visible = True
                gonggao.Visible = True
                Me.yewu4.Visible = True
                Me.duizhang.Visible = True
                Me.yichang.Visible = True
                Me.DIVComplaints.Visible = True
                Me.manage.Visible = True
                Me.CustomerWork.Visible = False
                Me.cus.Visible = False
                Me.Tongji.Visible = True
                Me.usercenter.Visible = True
                Me.divSell.Visible = True
                Me.leadreport.Visible = True
                Me.inquote.Visible = True
            End If
            If Not UserInfo.IsInRoles("SYS_ADMINISTRATOR") AndAlso Not UserInfo.IsInRoles("CRM經管") AndAlso Not UserInfo.IsInRoles("TEDINGSHENHE") AndAlso Not UserInfo.IsInRoles("OperationsAssistant") AndAlso Not UserInfo.IsInRoles("Yewuzhuguan") AndAlso Not UserInfo.IsInRoles("ZHONGXINZHUGUAN") AndAlso Not UserInfo.IsInRoles("EXTERNALWORKER") AndAlso Not UserInfo.IsInRoles("CRMTECSUPPORT") AndAlso Not UserInfo.IsInRoles("storekeeper") AndAlso Not UserInfo.IsInRoles("CENTEREM") Then          '客戶
                Me.CustomerWork.Visible = True
                Me.Customerwork1.Visible = True
                Me.Customerwork2.Visible = True

                Me.yewu1.Visible = False
                Me.yewu2.Visible = False
                Me.yewu3.Visible = False
                Me.yewu4.Visible = False
                Me.DIVComplaints.Visible = False
                Me.gonggao.Visible = False
                Me.usercenter.Visible = False
                Me.divSell.Visible = False
                Me.cus.Visible = True
                Me.Tongji.Visible = False


            End If
            If ConfigurationManager.AppSettings("CQ") = "SZ" Then
                Me.sysuse.Visible = True
            End If
            If ConfigurationManager.AppSettings("IswithTAM") = "1" Then
                Me.work4.Visible = True
            Else
                Me.work4.Visible = False
            End If


        End If
    End Sub

End Class