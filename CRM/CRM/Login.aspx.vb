Imports Platform.eAuthorize
Imports Platform.eFlowConfiguration
Imports Platform.eHR.Core

Partial Public Class Login
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.TxtUserName.Focus()
        If Not Page.IsPostBack Then
            Me.Page.Title = String.Format("登陸--{0}", ConfigurationManager.AppSettings("CQ"))
            If UserInfo.IsAuthenticated Then
                If Context.Request("ReturnUrl") Is Nothing Then
                    Response.Redirect("default.aspx")
                Else
                    Response.Redirect(Context.Request("ReturnUrl"))
                End If
            Else

                If Not Context.Request("ReturnUrl") Is Nothing Then
                    Dim returi As String = Context.Request("ReturnUrl").ToString
                    If returi.IndexOf("userid") > 0 Then

                        Dim userid As String = returi.Substring(92, returi.IndexOf("&pass=") - 92)
                        Dim pass As String = returi.Substring(returi.IndexOf("&pass=") + 6, returi.Length - (returi.IndexOf("&pass=") + 6))
                        If Not AccountManage.LoadAccountInfoByUserSID(userid) Is Nothing Then
                            Platform.eFlowConfiguration.ConfigurationInfo._ChangQU = "LH"
                            If AccountManage.LoadAccountInfoByUserSID(userid).Password = pass Then
                                Session("userID") = Me.TxtUserName.Text
                                Session.Timeout = 120
                                FormsAuthentication.RedirectFromLoginPage(userid, True)
                                If Context.Request("ReturnUrl") Is Nothing Then
                                    Response.Redirect("default.aspx")
                                Else
                                    Response.Redirect(Context.Request("ReturnUrl"))
                                End If
                            End If
                        End If
                    End If
                End If
            End If

        End If

    End Sub
   
    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button1.Click
        If Page.IsValid = True Then
            Dim Result As Boolean = False
            If Me.HidUsername.Value <> String.Empty And HidEmail.Value <> String.Empty Then  '證書登錄的代碼
                '驗證用戶名郵件地址
                Dim UserID As String
                If HidEmail.Value = "li-min.ding@mail.foxconn.com" Then
                    HidEmail.Value = "hzlh-cmc-ding.lm@mail.foxconn.com"
                ElseIf HidEmail.Value = "Randy C.P. Liang/SHZBG/FOXCONN" Then
                    HidEmail.Value = "randy.cp.liang@foxconn.com "
                End If
                UserID = AccountManage.CALogin(Me.HidUsername.Value, HidEmail.Value)
                If UserID <> String.Empty Then
                    Me.TxtUserName.Text = UserID
                    Result = True
                Else
                    LError.Text = "您選擇的證書信息有誤"
                    Me.wronginfo.Visible = True
                    HidUsername.Value = ""
                    HidEmail.Value = ""
                    Exit Sub
                End If
            Else
                Result = AccountManage.Login(Me.TxtUserName.Text.Trim.ToUpper, Me.TxtPassword.Text)
            End If
            Dim addr As String = Request.UserHostAddress
            Dim name As String = Me.TxtUserName.Text.ToUpper
            If Result Then
                Dim loginlog As Log = New Log(1, name, "System", DateTime.Now, addr, "登入成功")
                Session("userID") = Me.TxtUserName.Text
                Session.Timeout = 120
                WriteCookie("dt_cookie_user_name_remember", "DTcms", Me.TxtUserName.Text.ToUpper, 43200)
                WriteCookie("dt_cookie_user_pwd_remember", "DTcms", Me.TxtPassword.Text, 43200)

                FormsAuthentication.RedirectFromLoginPage(TxtUserName.Text.Trim.ToUpper, Me.chkRem.Checked)
                If Context.Request("ReturnUrl") Is Nothing Then
                    Response.Redirect("default.aspx")
                Else
                    Response.Redirect(Context.Request("ReturnUrl"))
                End If
            Else
                Dim loginlog As Log = New Log(1, name, "System", DateTime.Now, addr, "登入失敗")
                wronginfo.Visible = True
                Me.TxtPassword.Text = String.Empty
            End If
           
            
        End If


    End Sub
    Private Sub WriteCookie(ByVal strName As String, ByVal Key As String, ByVal strValue As String, Optional ByVal expires As Integer = 0)
        Dim cookie As HttpCookie = HttpContext.Current.Request.Cookies(strName)
        If cookie Is Nothing Then
            cookie = New HttpCookie(strName)
        End If
        strValue = strValue.Replace("'", "")
        cookie(Key) = HttpContext.Current.Server.UrlEncode(strValue)
        If expires > 0 Then
            cookie.Expires = DateTime.Now.AddMinutes(expires)
        End If
        HttpContext.Current.Response.AppendCookie(cookie)
    End Sub

   
End Class