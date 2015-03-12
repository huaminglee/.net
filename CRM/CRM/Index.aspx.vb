Imports Platform.eAuthorize
Imports System.Math
Imports Platform.eHR.Core

Partial Public Class Index
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            'Dim usershili As Platform.eHR.Core.AccountInfo = UserInfo.GetSpecAccountInfo(UserInfo.CurrentUserID)

            Dim agentDefineInfo As AgentDefineInfo
            Dim AgentDefineInfos As List(Of AgentDefineInfo) = AgentManage.LoadAgentDefine(UserInfo.CurrentUserID)
            If AgentDefineInfos Is Nothing Then
                agentDefineInfo = New AgentDefineInfo
                agentDefineInfo.AgentObjectPKID = 0
                agentDefineInfo.AgentType = -1
                agentDefineInfo.Description = ""
                agentDefineInfo.Extend2 = ""
                agentDefineInfo.Extend3 = ""
                agentDefineInfo.Extend4 = ""
                agentDefineInfo.Extend5 = ""
                agentDefineInfo.RecordCreateTime = DateTime.Now
                agentDefineInfo.RecordDeleteFlag = 0
                agentDefineInfo.RecordModifyTime = DateTime.Now
                agentDefineInfo.RecordVersion = ""
                agentDefineInfo.RecordVersionExt = ""
                agentDefineInfo.RegisterMan = "System--" + UserInfo.CurrentUserCHName
                agentDefineInfo.ScopePKID = -1
                agentDefineInfo.UserName = UserInfo.CurrentUserCHName
                agentDefineInfo.UserSID = UserInfo.CurrentUserID
                Dim agentdefineDAL As New AgentDefineDAL(agentDefineInfo)
                agentdefineDAL.Save()
            Else
                agentDefineInfo = AgentDefineInfos(0)
            End If

            Me.setagent.HRef = String.Format("{0}/eFlowNet/Forms/HR/AgentInstanceDetail.aspx?AgentPKID={1}", Global_asax.UrlHost, agentDefineInfo.AgentPKID)

            Me.TxtStartDate.Attributes.Add("onclick", "javascript:WdatePicker({startDate:'%y-%M-01',dateFmt:'yyyy-MM-dd HH:mm'});")
            Me.TxtEndDate.Attributes.Add("onclick", "javascript:WdatePicker({startDate:'%y-%M-01',dateFmt:'yyyy-MM-dd HH:mm'});")
            Me.TxtDoDate.Attributes.Add("onclick", "javascript:WdatePicker({startDate:'%y-%M-01',dateFmt:'yyyy-MM-dd HH:mm'});")
            Me.TxtStartDate.Text = DateTime.Now
            BindControlData()
            BindDataList()
            BindDataList3()
            BindBirth()
        End If
    End Sub
    Private Sub BindControlData()
        Dim curcontactinfo As ContactInfo = ContactDAL.GetInfoByUserSID(UserInfo.CurrentUserID)
        Me.username.InnerText = UserInfo.CurrentUserCHName
        If Not curcontactinfo Is Nothing Then
            Dim xb As String = String.Empty
            If curcontactinfo.Sex = 1 Then
                xb = "男"
            ElseIf curcontactinfo.Sex = 2 Then
                xb = "女"
            Else
                xb = "男"

            End If
            Me.LbJibenxinxi.Text = curcontactinfo.CustomerName + "<br />職務:" + curcontactinfo.Position
            If curcontactinfo.Photo <> "" Then
                Me.Image1.ImageUrl = "UserPhoto/" + curcontactinfo.Photo.ToString
            End If
            Me.Lbaddr.Text = curcontactinfo.Address
            Me.Lbbirth.Text = curcontactinfo.Birthday.ToShortDateString
            Me.Lbdegree.Text = curcontactinfo.Degree
            Me.Lbphone.Text = curcontactinfo.Extend1
            Me.Lbsex.Text = xb

        End If
    End Sub
    Private Sub BindDataList3()
        Dim ds As DataSet = calendarDAL.GetundodsByUserSid(UserInfo.CurrentUserID)
        If Not ds Is Nothing Then
            Me.Lbshow3.Visible = False
            Me.DataList3.DataSource = ds
            Me.DataList3.DataBind()
        Else
            Me.DataList3.DataSource = Nothing
            Me.DataList3.DataBind()
            Me.LbShow.Visible = True
        End If
    End Sub
    Private Sub BindDataList()
        'Dim birthtixing As Integer = 0
        'Dim SearchCondition As String = String.Format(" PKID IN (select ContactPKID from ContactManage where Type=2 and RecordDeleted=0  and CustomerPKID={0} union select pkid from contact where  CustomerPKID in (select PKID from Customers where RecordDeleted=0 and PersonInCharge='{1}'))", ContactDAL.GetInfoByUserSID(UserInfo.CurrentUserID).PKID.ToString, UserInfo.CurrentUserCHName)
        'Dim contactlist As List(Of ContactInfo) = ContactDAL.GetInfoBySearchCondtion(SearchCondition)
        'Dim curmonth As Integer = DateTime.Now.Month
        'Dim curday As Integer = DateTime.Now.Day
        'For Each Curcontactinfo As ContactInfo In contactlist
        '    Dim curbirthmonth As Integer = Curcontactinfo.Birthday.Month
        '    Dim curbirthday As Integer = Curcontactinfo.Birthday.Day
        '    If curmonth = curbirthmonth AndAlso curday + 2 <= curbirthday + 1 Then

        '        Dim IsHas As Integer = calendarDAL.IsExites(Curcontactinfo.UserSID + "*" + DateTime.Now.Year.ToString, UserInfo.CurrentUserID)
        '        If IsHas = 0 Then         '還未添加到代辦事項


        '        End If
        '    End If

        'Next

        Dim ds As DataSet = calendarDAL.GetdsByUserSid(UserInfo.CurrentUserID)
        If Not ds Is Nothing Then
            Me.LbShow.Visible = False
            Me.DataList1.DataSource = ds
            Me.DataList1.DataBind()
        Else
            Me.DataList1.DataSource = Nothing
            Me.DataList1.DataBind()
            Me.LbShow.Visible = True
        End If
    End Sub
    Private Sub BindBirth()
        Dim needcontact As List(Of ContactInfo) = New List(Of ContactInfo)
        Dim SearchCondition As String = String.Format(" PKID IN (select ContactPKID from ContactManage where Type=2 and RecordDeleted=0  and CustomerPKID={0} union select pkid from contact where  CustomerPKID in (select PKID from Customers where RecordDeleted=0 and PersonInCharge='{1}'))", ContactDAL.GetInfoByUserSID(UserInfo.CurrentUserID).PKID.ToString, UserInfo.CurrentUserCHName)
        Dim contactlist As List(Of ContactInfo) = ContactDAL.GetInfoBySearchCondtion(SearchCondition)
        If Not contactlist Is Nothing Then


            For Each Curcontactinfo As ContactInfo In contactlist
                Dim diffbirth As DateTime = New DateTime()
                diffbirth = CDate(DateTime.Now.Year.ToString() + "-" + Curcontactinfo.Birthday.Month.ToString() + "-" + Curcontactinfo.Birthday.Day.ToString())
                Dim days As Integer = DateDiff("d", DateTime.Now, diffbirth)
                If days >= 0 AndAlso days <= 3 Then
                    needcontact.Add(Curcontactinfo)
                End If
            Next
            If needcontact.Count > 0 Then
                Me.Label1.Visible = False
                Me.DataList2.DataSource = needcontact
                Me.DataList2.DataBind()
            End If
        End If
    End Sub
    Protected Sub Btnaddclendar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Btnaddclendar.Click

        Dim newclandal As calendarInfo = New calendarInfo()
        newclandal.UserSID = UserInfo.CurrentUserID
        newclandal.Title = Me.HiddenTitle.Value
        newclandal.Xiangxi = Me.Hiddenxiangxi.Value
        newclandal.BeginTime = Me.Hiddenstart.Value
        newclandal.EndTime = Me.Hiddenend.Value
        newclandal.Extend2 = Me.Hiddendo.Value
        newclandal.RecordCreated = DateTime.Now
        newclandal.IsDeal = 0
        Dim newcladal As calendarDAL = New calendarDAL(newclandal)
        newcladal.Save()
        BindDataList()
    End Sub
#Region "DataList1"
    Protected Sub DataList1_DeleteCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataListCommandEventArgs) Handles DataList1.DeleteCommand
        Dim MPKID As Integer = CInt(CType(e.Item.FindControl("LbPKID"), Label).Text)
        calendarDAL.Delete(MPKID)
        BindDataList()
    End Sub

    Protected Sub DataList1_ItemCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataListCommandEventArgs) Handles DataList1.ItemCommand
        If e.CommandName = "finish" Then
            Dim MPKID As Integer = CInt(CType(e.Item.FindControl("LbPKID"), Label).Text)
            Dim newclandal As calendarInfo = calendarDAL.GetInfoByPKID(MPKID)
            newclandal.IsDeal = 1

            Dim newcladal As calendarDAL = New calendarDAL(newclandal)
            newcladal.Save()
            BindDataList()
        End If

    End Sub

    Protected Sub DataList1_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataListItemEventArgs) Handles DataList1.ItemDataBound
        If e.Item.ItemType = ListItemType.Item OrElse e.Item.ItemType = ListItemType.AlternatingItem Then
            Dim Lbtitle As Label = CType(e.Item.FindControl("Lbtitle"), Label)
            Dim Lbxiangxi As Label = CType(e.Item.FindControl("Lbxiangxi"), Label)
            Lbtitle.ToolTip = Lbxiangxi.Text
            Dim LbIsdeal As Label = CType(e.Item.FindControl("LbIsdeal"), Label)
            'If LbIsdeal.Text = 1 Then
            '    Lbtitle.Font.Strikeout = True
            'End If
        End If
    End Sub
#End Region
#Region "DataList3"
    Protected Sub DataList3_ItemCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataListCommandEventArgs) Handles DataList3.ItemCommand
        If e.CommandName = "finish" Then
            Dim MPKID As Integer = CInt(CType(e.Item.FindControl("LbPKID"), Label).Text)
            Dim newclandal As calendarInfo = calendarDAL.GetInfoByPKID(MPKID)
            newclandal.IsDeal = 1

            Dim newcladal As calendarDAL = New calendarDAL(newclandal)
            newcladal.Save()
            BindDataList3()
        End If
    End Sub

    Protected Sub DataList3_DeleteCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataListCommandEventArgs) Handles DataList3.DeleteCommand
        Dim MPKID As Integer = CInt(CType(e.Item.FindControl("LbPKID"), Label).Text)
        calendarDAL.Delete(MPKID)
        BindDataList3()
    End Sub

    Protected Sub DataList3_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataListItemEventArgs) Handles DataList3.ItemDataBound
        If e.Item.ItemType = ListItemType.Item Then
            Dim Lbtitle As Label = CType(e.Item.FindControl("Lbtitle"), Label)
            Dim Lbxiangxi As Label = CType(e.Item.FindControl("Lbxiangxi"), Label)
            Lbtitle.ToolTip = Lbxiangxi.Text
            Dim LbIsdeal As Label = CType(e.Item.FindControl("LbIsdeal"), Label)
            If LbIsdeal.Text = 1 Then
                Lbtitle.Font.Strikeout = True
            End If
        End If
    End Sub
#End Region

    Protected Sub DataList2_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataListItemEventArgs) Handles DataList2.ItemDataBound
        If e.Item.ItemType = ListItemType.Item OrElse e.Item.ItemType = ListItemType.AlternatingItem Then
            Dim LbBirth As Label = CType(e.Item.FindControl("LbBirth"), Label)
            Dim LbDays As Label = CType(e.Item.FindControl("LbDays"), Label)
            Dim birthday As DateTime = CDate(LbBirth.Text)
            LbBirth.Text = "生日：" + birthday.ToShortDateString

            Dim diffbirth As DateTime = New DateTime()
            diffbirth = CDate(DateTime.Now.Year.ToString() + "-" + birthday.Month.ToString() + "-" + birthday.Day.ToString())
            Dim days As Integer = DateDiff("d", DateTime.Now, diffbirth)
            LbDays.Text = "還有" + days.ToString + "天"
        End If
    End Sub
End Class