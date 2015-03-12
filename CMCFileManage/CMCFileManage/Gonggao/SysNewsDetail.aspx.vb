Imports Platform.eAuthorize
Partial Public Class SysNewsDetail
    Inherits System.Web.UI.Page



#Region "Const"
    Private Const HIDE_NewsID_KEY As String = "NewsID"

#End Region

#Region "Properties"


    Private Property NewsID() As String
        Get
            If ViewState(HIDE_NewsID_KEY) Is Nothing Then
                Return String.Empty
            End If
            Return ViewState(HIDE_NewsID_KEY).ToString
        End Get
        Set(ByVal value As String)
            ViewState(HIDE_NewsID_KEY) = value
        End Set
    End Property

    ' 記錄實體信息
    Private _SysNews As Sys_NewsInfo
    Private Property mSysNews() As Sys_NewsInfo
        Get
            If _SysNews Is Nothing Then
                If NewsID <> String.Empty Then
                    _SysNews = Sys_NewsDAL.GetInfoByPKID(NewsID)
                Else
                    _SysNews = New Sys_NewsInfo
                End If
            End If
            Return _SysNews
        End Get
        Set(ByVal Value As Sys_NewsInfo)
            _SysNews = Value
        End Set
    End Property
    

#End Region

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then

            BindRequestParam()

            BindControlData()
        End If
    End Sub

#Region "private Methods"
    ''' <summary>
    ''' 獲取頁面傳遞的參數
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub BindRequestParam()
        If Request.Params("PKID") IsNot Nothing Then
            NewsID = Request.Params("PKID").ToString
        End If
       
    End Sub

    Private Sub BindControlData()
        
        If NewsID = String.Empty Then
            Me.sea.Visible = False
            Me.divedit.Visible = True

            Me.TxtID.Text = DateTime.Now.ToString("yyMMddhhmmss")
            Me.DDLServiceName.Items.Insert(0, New ListItem("品質管理系統", -3))
            ' Me.DDLServiceName.Items.Insert(0, New ListItem("開啟申請單", -1))
            '  Me.DDLServiceName.Items.Insert(0, New ListItem("CRM", -2))
            ' Me.DDLServiceName.Items.Insert(0, New ListItem("品質管理系統", -3))
        Else
            Me.sea.Visible = True
            Me.divedit.Visible = False

            Me.TxtID.Text = NewsID
            Me.txtNewsTitle.Text = mSysNews.NewTitle
            Me.DDLServiceName.Items.Insert(0, New ListItem(mSysNews.ServiceName, mSysNews.ServicePKID))
            Me.txtEndTime.Text = mSysNews.EndTime
            If UserInfo.IsInRoles("SYS_ADMINISTRATOR") OrElse UserInfo.IsInRoles("qa") Then
                Me.LinkEdit.Visible = True
            End If
            Me.LinkCancel.Text = "返回"
            Me.LbContent.Text = HttpUtility.HtmlDecode(mSysNews.NewContent)
            Me.LBDate.Text = mSysNews.RecordCreated.ToShortDateString
            Me.LbFanwei.Text = mSysNews.ServiceName
            Me.LbSubject.Text = mSysNews.NewTitle
            Me.LbYOUxiaodate.Text = mSysNews.EndTime
            Me.LbZZ.Text = mSysNews.CreateUser
            Me.WebEditor1.Text = HttpUtility.HtmlDecode(mSysNews.NewContent)

        End If

        Me.txtEndTime.Attributes.Add("onclick", "javascript:WdatePicker({startDate:'%y-%M-01 00:00',dateFmt:'yyyy-MM-dd HH:mm',alwaysUseStartDate:true});")

    End Sub

#End Region

#Region "Button Events"

#End Region

    Private Sub LinkSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LinkSave.Click
        Dim isInsert As Boolean = False
        If NewsID = String.Empty Then
            isInsert = True
            mSysNews.CreateUser = UserInfo.CurrentUserCHName + "/" + UserInfo.CurrentUserID
            mSysNews.RecordCreated = DateTime.Now
            mSysNews.RecordDeleted = 0
            mSysNews.ModifyTime = DateTime.MaxValue

        Else
            mSysNews.ModifyUser = UserInfo.CurrentUserCHName + "/" + UserInfo.CurrentUserID
            mSysNews.ModifyTime = DateTime.Now

        End If
        mSysNews.NewsID = Me.TxtID.Text
        mSysNews.NewTitle = Me.txtNewsTitle.Text
        mSysNews.ServicePKID = Me.DDLServiceName.SelectedItem.Value
        mSysNews.ServiceName = Me.DDLServiceName.SelectedItem.Text
        mSysNews.EndTime = Me.txtEndTime.Text
        mSysNews.NewContent = HttpUtility.HtmlEncode(Me.WebEditor1.Text)

        Dim mNewsDao As Sys_NewsDAL = New Sys_NewsDAL(mSysNews)
        mNewsDao.Save(isInsert)
        LinkCancel_Click(Nothing, Nothing)
    End Sub


    Private Sub LinkCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LinkCancel.Click
        Response.Redirect("SysNewsList.aspx")
        ' Server.Transfer("SysInfo/SysNewsList.aspx")  '頁面在本站點之間跳轉,只進行一次PostBack
    End Sub

    Protected Sub LinkEdit_Click(ByVal sender As Object, ByVal e As EventArgs) Handles LinkEdit.Click
        Me.divedit.Visible = True
        Me.sea.Visible = False
    End Sub

    Protected Sub LinkClose_Click(ByVal sender As Object, ByVal e As EventArgs) Handles LinkClose.Click
        Response.Redirect("SysNewsList.aspx")
    End Sub
End Class