Imports Platform.eAuthorize
Imports Platform.eFlowConfiguration
Imports Platform.eHR.Core

Partial Public Class Login
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.TxtUserName.Focus()
        If Not Page.IsPostBack Then
            BindDpl()
            If Not Request.Cookies("changqu") Is Nothing Then
                Dim cuechangqu As String = Server.HtmlEncode(Request.Cookies("changqu").Value)
                Me.DPLChangqu.SelectedIndex = Me.DPLChangqu.Items.IndexOf(Me.DPLChangqu.Items.FindByValue(cuechangqu))
            End If


            If UserInfo.IsAuthenticated Then

                If Context.Request.Cookies("dt_cookie_user_name_remember") Is Nothing Then
                    HttpContext.Current.Session("dt_session_user_info") = Nothing
                    Authorization.Logout()
                Else
                    If Context.Request("ReturnUrl") Is Nothing Then
                        Response.Redirect("Default.aspx")
                    Else
                        Response.Redirect(Context.Request("ReturnUrl"))
                    End If
                End If
                'ElseIf Not Context.Request.Cookies("dt_cookie_user_name_remember") Is Nothing Then
                '    Dim UserName As String = Context.Request.Cookies("dt_cookie_user_name_remember")("DTcms").ToString()

                '    FormsAuthentication.RedirectFromLoginPage(UserName, True)
                '    If Context.Request("ReturnUrl") Is Nothing Then
                '        Response.Redirect("default.aspx")
                '    Else
                '        Response.Redirect(Context.Request("ReturnUrl"))
                '    End If

            End If


        End If
    End Sub
    Private Sub BindDpl()
        Dim dt As DataTable = QC_UserParameterDAL.GetInfoByCategory("CQ")
        If Not dt Is Nothing Then
            Me.DPLChangqu.DataSource = dt
            Me.DPLChangqu.DataTextField = "ParameterText"
            Me.DPLChangqu.DataValueField = "ParameterValue1"
            Me.DPLChangqu.DataBind()

        End If
    End Sub
    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button1.Click
        If Page.IsValid = True Then
            Dim changqu As String = Me.DPLChangqu.SelectedValue
            Dim addr As String = Request.UserHostAddress
            Dim name As String = Me.TxtUserName.Text.ToUpper

            If AccountManage.Login(Me.TxtUserName.Text.Trim.ToUpper, Me.TxtPassword.Text, changqu) Then

                Dim loginlog As Log = New Log(1, name, "System", DateTime.Now, addr, "登入成功")
                FormsAuthentication.RedirectFromLoginPage(TxtUserName.Text.ToUpper, Me.chkRem.Checked)


                HttpContext.Current.Session("dt_session_user_info") = TxtUserName.Text.ToUpper
                If chkRem.Checked Then

                    WriteCookie("dt_cookie_user_name_remember", "DTcms", Me.TxtUserName.Text.ToUpper, 43200)
                    WriteCookie("dt_cookie_user_pwd_remember", "DTcms", Me.TxtPassword.Text, 43200)
                Else
                    WriteCookie("dt_cookie_user_name_remember", "DTcms", Me.TxtUserName.Text.ToUpper)
                    WriteCookie("dt_cookie_user_pwd_remember", "DTcms", Me.TxtPassword.Text)
                End If


                Response.Cookies("changqu").Value = Me.DPLChangqu.SelectedValue
                Response.Cookies("changqu").Expires = DateTime.Now.AddYears(1)
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

    ''' <summary>
    ''' 写cookie的值
    ''' </summary>
    ''' <param name="strName">名称</param>
    ''' <param name="Key">值</param>
    ''' <param name="strValue"></param>
    ''' <param name="expires"></param>
    ''' <remarks></remarks>
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