Imports Platform.eAuthorize
Imports Platform.eHR.Core
Imports System.Web.Services

Partial Public Class UserADVInfo
    Inherits System.Web.UI.Page
#Region "Const"
    Private Const HIDE_APPLICANTIDX_KEY As String = "ViewState:PKID"
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
    Private Property IsAdd() As Integer
        Get
            If ViewState("IsAdd") Is Nothing Then
                Return 0
            Else
                Return Convert.ToInt32(ViewState("IsAdd"))
            End If
        End Get
        Set(ByVal value As Integer)
            ViewState("IsAdd") = value
        End Set
    End Property
    Private Property CustomerPKID() As Integer
        Get
            If ViewState("CustomerPKID") Is Nothing Then
                Return 0
            End If
            Return Convert.ToInt32(ViewState("CustomerPKID"))
        End Get
        Set(ByVal value As Integer)
            ViewState("CustomerPKID") = value
        End Set
    End Property
    Private Property CustomerName() As String
        Get
            If ViewState("CustomerName") Is Nothing Then
                Return String.Empty
            End If
            Return ViewState("CustomerName").ToString
        End Get
        Set(ByVal value As String)
            ViewState("CustomerName") = value
        End Set
    End Property
    Private _Contact As ContactInfo
    Private Property Contact() As ContactInfo
        Get
            If _Contact Is Nothing Then
                If PKID <> 0 Then
                    _Contact = ContactDAL.GetInfoByPKID(PKID)

                ElseIf IsAdd = 0 Then
                    _Contact = ContactDAL.GetInfoByUserSID(UserInfo.CurrentUserID)
                    PKID = _Contact.PKID
                Else
                    _Contact = New ContactInfo()
                    PKID = 0
                End If
            End If
            Return _Contact
        End Get
        Set(ByVal value As ContactInfo)
            _Contact = value
        End Set
    End Property
#End Region
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            'BindDPL()
            GetParam()
            RegisterScript()
            BindControlData()
            Me.TxtBirthday.Attributes.Add("readonly", True)
            Me.TxtBirthday.Attributes.Add("onclick", "javascript:WdatePicker({isShowClear:false,dateFmt:'yyyy-MM-dd',maxDate:'%y-%M-%d'});")
        End If
    End Sub
    Private Sub GetParam()
        If Not Request.QueryString("pkid") Is Nothing Then
            PKID = Convert.ToInt32(Request.QueryString("pkid"))
        End If
        If Not Request.QueryString("IsAdd") Is Nothing Then
            IsAdd = Convert.ToInt32(Request.QueryString("IsAdd"))
            If Not Request.QueryString("CustomerPKID") Is Nothing Then
                CustomerPKID = Convert.ToInt32(Request.QueryString("CustomerPKID"))
                CustomerName = CustomersDAL.GetInfoByPKID(CustomerPKID).CustomerName
            End If
        End If
        If Not Request.QueryString("Markplanpkid") Is Nothing Then
            ViewState("Markplanpkid") = Request.QueryString("Markplanpkid")
        End If
    End Sub
    Private Sub RegisterScript()

        If IsAdd = 0 AndAlso Contact.UserSID.Trim <> String.Empty Then '修改信息時無需驗證
            Me.TxtUserSID.Enabled = False
            Me.TxtUserSID.CssClass = ""
            Me.TxtUserSID.Attributes.Remove("required")
            Me.TxtUserSID.Attributes.Remove("invalidMessage")
        ElseIf IsAdd = 1 OrElse Contact.UserSID.Trim = String.Empty Then
            Me.TxtUserSID.Attributes.Add("validType", "remote['UserADVInfo.aspx/CheckUserSid','UserSID']")

        End If
    End Sub
    'Private Sub BindDPL()
    '    Dim ds As DataSet = CustomersDAL.GetAllCustomer()
    '    Dim dt As DataTable = ds.Tables(0)
    '    If Not dt Is Nothing Then
    '        Me.DPLCustomerName.DataSource = dt
    '        Me.DPLCustomerName.DataTextField = "CustomerName"
    '        Me.DPLCustomerName.DataValueField = "PKID"
    '        Me.DPLCustomerName.DataBind()
    '    End If
    'End Sub
    Private Sub BindControlData()
        If Not Contact Is Nothing Then
            ' Me.TxtUserSID.Attributes.Add("readonly", True)
            Me.InpCustomerName.Attributes.Add("readonly", True)

            If PKID <> 0 Then
                If UserInfo.IsInRoles("SYS_ADMINISTRATOR ") OrElse UserInfo.IsInRoles("ZHONGXINZHUGUAN") OrElse UserInfo.IsInRoles("TEDINGSHENHE") OrElse UserInfo.IsInRoles("Yewuzhuguan") Then
                    Me.LinkEdit.Visible = True
                ElseIf Contact.UserSID = UserInfo.CurrentUserID Then
                    Me.LinkEdit.Visible = True
                    Me.Image2.Attributes.Add("style", "display:none")

                Else
                    If Contact.CusTomerPKID <> 0 Then
                        If UserInfo.IsInRoles("EXTERNALWORKER") AndAlso CustomersDAL.GetInfoByPKID(Contact.CusTomerPKID).PersonInCharge = StrConv(UserInfo.CurrentUserCHName, VbStrConv.SimplifiedChinese, 2052) Then
                            Me.LinkEdit.Visible = True
                        Else
                            Me.LinkEdit.Visible = False
                        End If
                    Else
                        Me.LinkEdit.Visible = False
                    End If
                End If
                If Contact.UserSID.Trim = String.Empty Then
                    Me.LbNullIDinfo.Visible = True
                Else
                    Me.LbNullIDinfo.Visible = False
                End If
                Me.TxtUserSID.Text = Contact.UserSID
                Me.LbPhone.Text = Contact.Extend1 ' UserInfo.GetSpecAccountInfo(Me.TxtUserSID.Text.ToString).Telphone
                Me.TxtPhone.Text = Me.LbPhone.Text
                Me.LbEmail.Text = Contact.Extend2 ' UserInfo.GetSpecAccountInfo(Me.TxtUserSID.Text.ToString).Email1
                Me.TxtEmail.Text = Me.LbEmail.Text
                Me.TxtName.Text = Contact.UserName
                Me.TxtFax.Text = Contact.Extend3
                Me.TxtPosition.Text = Contact.Position
                Me.TxtOutMail.Text = Contact.Extend4
                Me.LbOutMail.Text = Contact.Extend4
                Me.TxtAddress.Text = Contact.Address
                Me.TxtBirthday.Text = Contact.Birthday
                Me.TxtDegree.Text = Contact.Degree
                Me.TxtGraduated.Text = Contact.Graduated
                Me.TxtIDnumber.Text = Contact.IDnumber
                Me.TxtMajor.Text = Contact.Major
                Me.TxtRemark.Text = Contact.Remark
                Me.TxtZIPcode.Text = Contact.ZIPcode
                Me.RDOsex.SelectedIndex = Me.RDOsex.Items.IndexOf(Me.RDOsex.Items.FindByValue(Contact.Sex))
                Me.RDOUserCategory.SelectedIndex = Me.RDOUserCategory.Items.IndexOf(Me.RDOUserCategory.Items.FindByValue(Contact.ContactCategory))
                Me.InpCustomerName.Value = Contact.CustomerName
                Me.HiddenCustomerNmae.Value = Contact.CustomerName
                Me.HiddenCustomerPKID.Value = Contact.CusTomerPKID
                Me.LbFax.Text = Contact.Extend3
                Me.LbName.Text = Contact.UserName
                Me.LbUserSID.Text = Contact.UserSID
                Me.LbPosition.Text = Contact.Position
                Me.LbAddress.Text = Contact.Address
                Me.LbBirthday.Text = Contact.Birthday
                Me.LbDegree.Text = Contact.Degree
                Me.LbGraduated.Text = Contact.Graduated
                Me.LbIDnumber.Text = Contact.IDnumber
                Me.LbMajor.Text = Contact.Major
                Me.LbRemark.Text = Contact.Remark
                Me.LbZIPcode.Text = Contact.ZIPcode
                Me.LbSex.Text = Me.RDOsex.SelectedItem.Text
                Me.LbUserCategory.Text = Me.RDOUserCategory.SelectedItem.Text
                Me.LbCustomerName.Text = Contact.CustomerName
                If Contact.Photo <> "" Then
                    Me.Image1.Visible = True
                    Me.Image1.ImageUrl = "../UserPhoto/" + Contact.Photo.ToString
                End If

            ElseIf IsAdd = 0 Then
                Me.Image1.Visible = True
                Me.LinkEdit.Visible = False

                Me.btnSave.Visible = True

                Me.TxtUserSID.Text = UserInfo.CurrentUserID
                Me.LbUserSID.Text = UserInfo.CurrentUserID
                Me.TxtName.Text = UserInfo.CurrentUserCHName
                Me.LbPhone.Text = UserInfo.GetSpecAccountInfo(Me.TxtUserSID.Text.ToString).Telphone
                Me.TxtPhone.Text = Me.LbPhone.Text
                Me.LbEmail.Text = UserInfo.GetSpecAccountInfo(Me.TxtUserSID.Text.ToString).Email1
                Me.TxtEmail.Text = Me.LbEmail.Text
                Me.TxtPosition.Text = UserInfo.CurrentUserInstance.OfficialPosition
                Me.TxtBirthday.Text = "1990-01-01"
                Me.LbName.Text = UserInfo.CurrentUserCHName
                Me.LbPosition.Text = UserInfo.CurrentUserInstance.OfficialPosition
                Me.LbBirthday.Text = "1990-01-01"

                Me.TxtPhone.Visible = True
                Me.TxtEmail.Visible = True
                Me.TxtFax.Visible = True
                Me.TxtOutMail.Visible = True

                Me.FilePhoto.Visible = True
                Me.Image2.Visible = True
                Me.TxtZIPcode.Visible = True
                Me.TxtUserSID.Visible = True
                Me.TxtRemark.Visible = True
                Me.TxtPosition.Visible = True
                Me.TxtPosition.Visible = True
                Me.TxtName.Visible = True
                Me.TxtMajor.Visible = True
                Me.TxtIDnumber.Visible = True
                Me.TxtGraduated.Visible = True
                Me.TxtDegree.Visible = True
                Me.TxtBirthday.Visible = True
                Me.TxtAddress.Visible = True
                Me.RDOsex.Visible = True
                Me.RDOUserCategory.Visible = True
                Me.InpCustomerName.Visible = True

                Me.LbOutMail.Visible = False
                Me.LbFax.Visible = False
                Me.LbPhone.Visible = False
                Me.LbEmail.Visible = False
                Me.LbAddress.Visible = False
                Me.LbBirthday.Visible = False
                Me.LbCustomerName.Visible = False
                Me.LbDegree.Visible = False
                Me.LbGraduated.Visible = False
                Me.LbIDnumber.Visible = False
                Me.LbMajor.Visible = False
                Me.LbName.Visible = False
                Me.LbPosition.Visible = False
                Me.LbRemark.Visible = False
                Me.LbSex.Visible = False
                Me.LbUserCategory.Visible = False
                Me.LbUserSID.Visible = False
                Me.LbZIPcode.Visible = False
            ElseIf IsAdd = 1 Then
                Me.TxtUserSID.Attributes.Remove("readonly")
                Me.Image1.Visible = True
                Me.LinkEdit.Visible = False
                Me.btnSave.Visible = True


                Me.TxtPhone.Visible = True
                Me.TxtEmail.Visible = True
                Me.TxtOutMail.Visible = True
                Me.TxtFax.Visible = True
                Me.FilePhoto.Visible = True
                Me.Image2.Visible = True
                Me.TxtZIPcode.Visible = True
                Me.TxtUserSID.Visible = True
                Me.TxtRemark.Visible = True
                Me.TxtPosition.Visible = True
                Me.TxtPosition.Visible = True
                Me.TxtName.Visible = True
                Me.TxtMajor.Visible = True
                Me.TxtIDnumber.Visible = True
                Me.TxtGraduated.Visible = True
                Me.TxtDegree.Visible = True
                Me.TxtBirthday.Visible = True
                Me.TxtAddress.Visible = True
                Me.RDOsex.Visible = True
                Me.RDOUserCategory.Visible = True
                Me.InpCustomerName.Visible = True

                Me.LbOutMail.Visible = False
                Me.LbFax.Visible = False
                Me.LbPhone.Visible = False
                Me.LbEmail.Visible = False
                Me.LbAddress.Visible = False
                Me.LbBirthday.Visible = False
                Me.LbCustomerName.Visible = False
                Me.LbDegree.Visible = False
                Me.LbGraduated.Visible = False
                Me.LbIDnumber.Visible = False
                Me.LbMajor.Visible = False
                Me.LbName.Visible = False
                Me.LbPosition.Visible = False
                Me.LbRemark.Visible = False
                Me.LbSex.Visible = False
                Me.LbUserCategory.Visible = False
                Me.LbUserSID.Visible = False
                Me.LbZIPcode.Visible = False
                If CustomerPKID <> 0 Then
                    Me.HiddenCustomerPKID.Value = CustomerPKID
                    Me.HiddenCustomerNmae.Value = CustomerName
                    Me.InpCustomerName.Value = CustomerName
                    Me.Image2.Visible = False
                End If
            End If
        End If
    End Sub

    Protected Sub LinkSave_Click(ByVal sender As Object, ByVal e As EventArgs) Handles LinkSave.Click
        If FilePhoto.HasFile Then
            Dim filename As String = DateTime.Now.ToString("yyyyMMddHHmm") + Me.FilePhoto.FileName
            Dim filepath As String = Server.MapPath(String.Format("{0}/UserPhoto", HttpContext.Current.Request.ApplicationPath))
            Dim fileonserver As String = String.Format("{0}\{1}", filepath, filename)
            Me.FilePhoto.SaveAs(fileonserver)
            Contact.Photo = filename
        ElseIf Contact.Photo = String.Empty Then
            Contact.Photo = "defaultimg.jpg"

        End If
        Contact.PKID = PKID
        Contact.Address = Me.TxtAddress.Text
        Contact.Birthday = Me.TxtBirthday.Text
        Contact.ContactCategory = Me.RDOUserCategory.SelectedValue
        Contact.CustomerName = Me.HiddenCustomerNmae.Value
        Contact.CusTomerPKID = Me.HiddenCustomerPKID.Value
        Contact.Degree = Me.TxtDegree.Text
        Contact.Graduated = Me.TxtGraduated.Text
        Contact.IDnumber = Me.TxtIDnumber.Text
        Contact.Major = Me.TxtMajor.Text
        Contact.Extend1 = Me.TxtPhone.Text.Trim

        Contact.Extend2 = Me.TxtEmail.Text.Trim
        If Me.TxtFax.Text.Trim <> String.Empty Then
            Contact.Extend3 = Me.TxtFax.Text.Trim
        Else
            Contact.Extend3 = "/"
        End If

        Contact.Extend4 = Me.TxtOutMail.Text.Trim
        Contact.Position = Me.TxtPosition.Text
        If PKID = 0 Then
            Contact.RecordCreated = DateTime.Now

        End If
        Contact.RecordDeleted = 0
        Contact.Remark = Me.TxtRemark.Text
        Contact.Sex = Me.RDOsex.SelectedValue
        Contact.UserName = Me.TxtName.Text.Trim
        Dim oldusersid As String = Contact.UserSID
        Contact.UserSID = Me.TxtUserSID.Text.Trim
        If Me.TxtZIPcode.Text = "" Then
            Contact.ZIPcode = 0
        Else
            Contact.ZIPcode = Me.TxtZIPcode.Text
        End If
        Dim contactdal As ContactDAL = New ContactDAL(Contact)
        PKID = contactdal.Save()
        If AccountManage.LoadAccountInfoByUserSID(Me.TxtUserSID.Text.Trim) Is Nothing Then
            ' If IsAdd = 1 OrElse oldusersid = String.Empty Then
            Dim mAccountInfo As AccountInfo = New AccountInfo()
            mAccountInfo.UserSID = Me.TxtUserSID.Text
            mAccountInfo.UserName = Me.TxtName.Text
            mAccountInfo.UserAlias = String.Empty
            mAccountInfo.AccountScope = 2 '為測試申請系統的作用域
            mAccountInfo.AccountStatus = 0
            mAccountInfo.AccountType = 2
            mAccountInfo.Email2 = String.Empty
            mAccountInfo.Extend1 = String.Empty
            mAccountInfo.Extend2 = String.Empty
            mAccountInfo.Extend3 = String.Empty
            mAccountInfo.AgentEnableFlag = String.Empty
            mAccountInfo.OfficialPosition = "無管理職"
            mAccountInfo.Password = "password"
            mAccountInfo.RecordCreateTime = DateTime.Now
            mAccountInfo.RecordDeleteFlag = 0
            mAccountInfo.RecordVersion = "CRM"
            mAccountInfo.RecordVersionExt = String.Empty
            mAccountInfo.RecordModifyTime = DateTime.Now
            mAccountInfo.Email1 = Me.TxtEmail.Text
            mAccountInfo.Telphone = Me.TxtPhone.Text
            mAccountInfo.Mobile = String.Empty

            AccountManage.CreateAccount(mAccountInfo)

            'Dim newcontactmanageinfo As ContactManageInfo = New ContactManageInfo()
            'newcontactmanageinfo.PKID = 0
            'newcontactmanageinfo.Type = 2
            'newcontactmanageinfo.CustomerPKID = contactdal.GetInfoByUserSID(UserInfo.CurrentUserID).PKID
            'newcontactmanageinfo.ContactPKID = PKID
            'newcontactmanageinfo.RecordDeleted = 0
            'newcontactmanageinfo.RecordCreated = DateTime.Now

            'Dim newcontactmanagedal As ContactManageDAL = New ContactManageDAL(newcontactmanageinfo)
            'newcontactmanagedal.Save()
            If Not ViewState("Markplanpkid") Is Nothing Then                '從營銷活動而來
                Dim markmember As MarketMemberInfo = New MarketMemberInfo()
                markmember.PKID = 0
                markmember.ContactName = Contact.UserName
                markmember.ContactPKID = Contact.PKID
                markmember.CustomerName = Contact.CustomerName
                markmember.CustomerPKID = Contact.CusTomerPKID
                markmember.MemberCategory = UserSetCategoryDAL.GetInfoByType(1).Tables(0).Rows(0).Item("CategoryName").ToString
                markmember.PlanPKID = CInt(ViewState("Markplanpkid"))
                markmember.Type = "聯繫人"

                Dim markmenberdal As MarketMemberDAL = New MarketMemberDAL(markmember)
                markmenberdal.Save()
                Response.Redirect("../Forms/MarketPlanDetail.aspx?pkid=" + ViewState("Markplanpkid").ToString)
            End If
            If CustomerPKID <> 0 Then
                Response.Redirect("../Forms/CustomerDetail.aspx?PKID=" + CustomerPKID.ToString)
            ElseIf IsAdd = 1 Then
                Response.Redirect("../Forms/ContactList.aspx?Type=0")   '所有聯繫人
            Else
                Response.Redirect("../Forms/ContactManage.aspx?Type=2")   '我的聯繫人
            End If
        Else
            Dim mAccountInfo As AccountInfo = AccountManage.LoadAccountInfoByUserSID(Me.TxtUserSID.Text)
            If Not mAccountInfo Is Nothing Then

                mAccountInfo.Email1 = Me.TxtEmail.Text
                mAccountInfo.Telphone = Me.TxtPhone.Text
                AccountManage.UpdateAccount(mAccountInfo)
            End If
            Dim BackUrl As String = "../Forms/UserADVInfo.aspx?PKID=" + PKID.ToString
            If CustomerPKID <> 0 Then
                BackUrl += "" & CustomerPKID = " + CustomerPKID.ToString)"
            End If
            If Not Request.QueryString("IsAdd") Is Nothing Then
                BackUrl += "&IsAdd=1"
            End If
            If Not Request.QueryString("pageindex") Is Nothing Then
                BackUrl += "&pageindex=" + Request.QueryString("pageindex").ToString
            End If
            Response.Redirect(BackUrl)
        End If
       
    End Sub

    Protected Sub LinkEdit_Click(ByVal sender As Object, ByVal e As EventArgs) Handles LinkEdit.Click

        Me.btnSave.Visible = True

        Me.LinkEdit.Visible = False
        Me.FilePhoto.Visible = True
        Me.Image2.Visible = True
        Me.TxtZIPcode.Visible = True
        Me.TxtUserSID.Visible = True
        Me.TxtRemark.Visible = True
        Me.TxtPosition.Visible = True
        Me.TxtPosition.Visible = True
        Me.TxtName.Visible = True
        Me.TxtMajor.Visible = True
        Me.TxtIDnumber.Visible = True
        Me.TxtGraduated.Visible = True
        Me.TxtDegree.Visible = True
        Me.TxtBirthday.Visible = True
        Me.TxtAddress.Visible = True
        Me.RDOsex.Visible = True
        Me.RDOUserCategory.Visible = True
        Me.InpCustomerName.Visible = True
        Me.TxtEmail.Visible = True
        Me.TxtPhone.Visible = True
        Me.TxtFax.Visible = True
        Me.TxtOutMail.Visible = True

        Me.LbOutMail.Visible = False
        Me.LbFax.Visible = False
        Me.LbPhone.Visible = False
        Me.LbEmail.Visible = False
        Me.LbAddress.Visible = False
        Me.LbBirthday.Visible = False
        Me.LbCustomerName.Visible = False
        Me.LbDegree.Visible = False
        Me.LbGraduated.Visible = False
        Me.LbIDnumber.Visible = False
        Me.LbMajor.Visible = False
        Me.LbName.Visible = False
        Me.LbPosition.Visible = False
        Me.LbRemark.Visible = False
        Me.LbSex.Visible = False
        Me.LbUserCategory.Visible = False
        Me.LbUserSID.Visible = False
        Me.LbZIPcode.Visible = False
       

    End Sub

    <WebMethod()> _
Public Shared Function CheckUserSid(ByVal UserSID As String) As Boolean
        If ContactDAL.GetInfoByUserSID(UserSID).PKID = 0 Then
            If Regex.IsMatch(UserSID, "^[a-z0-9A-Z\-@_.]+$") Then
                Return True
            End If
        End If
        Return False
    End Function

   
    Protected Sub LinkBack_Click(ByVal sender As Object, ByVal e As EventArgs) Handles LinkBack.Click
        Dim BackURL As String = String.Empty

        If Not Request.QueryString("IsAdd") Is Nothing Then
            BackURL = "../Forms/ContactList.aspx?Type=0"   '所有聯繫人
        Else
            BackURL = "../Forms/ContactManage.aspx?Type=2" '我的聯繫人
        End If
        If Not Request.QueryString("pageindex") Is Nothing Then
            BackURL += "&pageindex=" + Request.QueryString("pageindex").ToString
        End If
        If Not Request.QueryString("CustomerPKID") Is Nothing Then
            BackURL = "../Forms/CustomerDetail.aspx?pkid=" + Request.QueryString("CustomerPKID").ToString
        End If

        Response.Redirect(BackURL)
    End Sub
End Class