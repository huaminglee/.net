Imports System.Web
Imports System.Web.Services
Imports Platform.eWorkFlow.Model
Imports Platform.eWorkFlow.Core.DAL
Imports Platform.eHR.Core
Imports Platform.eAuthorize
Imports Platform.Framework

Public Class eFLowHandler
    Implements System.Web.IHttpHandler

    Sub ProcessRequest(ByVal context As HttpContext) Implements IHttpHandler.ProcessRequest

        'context.Response.Write("Hello World!")
        'context.Response.End()


        Dim type As String = context.Request("type").ToString()
        Dim RouteResult As String = String.Empty
        Dim CurrentStateID As Integer = 0
        If context.Request("Route") IsNot Nothing Then
            RouteResult = Convert.ToString(context.Request("Route"))
        End If
        If context.Request("CurrentState") IsNot Nothing Then
            CurrentStateID = Convert.ToInt32(context.Request("CurrentState"))
        End If
        Select Case type
            Case "state"
                If RouteResult <> String.Empty Then  '
                    Dim RouteList As List(Of TemplateRouteInfo) = TemplateRouteDAL.LoadTemplateRouteInfoByTemplateStateID(CurrentStateID)
                    If RouteList IsNot Nothing AndAlso RouteList.Count > 0 Then
                        Dim mRouteInfo As TemplateRouteInfo = RouteList.Find(Function(p) p.RouteResult = RouteResult)
                        If mRouteInfo IsNot Nothing Then
                            ' Dim StateResult As String = mRouteInfo.NextTemplateStateID.ToString + "^" + mRouteInfo.Extend1
                            Dim StateResult As String = mRouteInfo.NextTemplateStateID.ToString

                            context.Response.Write(StateResult)
                            
                        End If
                    End If
                End If
            Case "user"
                Dim InstanceID As Guid
                Dim TemplateID As Integer = 0

                Dim NextStateID As Integer = 0
                Dim ActionKey As String = String.Empty
                Dim SpecColumn As String = String.Empty
                Dim InstanceKeyID As Integer = 0
                Dim IsMergeUser As Boolean = False
                If context.Request("InstanceID") IsNot Nothing Then
                    InstanceID = New Guid(Convert.ToString(context.Request("InstanceID")))
                End If

                If context.Request("Template") IsNot Nothing Then
                    TemplateID = Convert.ToInt32(context.Request("Template"))
                End If

                If context.Request("CurrentState") IsNot Nothing Then
                    CurrentStateID = Convert.ToInt32(context.Request("CurrentState"))
                End If

                If context.Request("NextState") IsNot Nothing Then
                    NextStateID = Convert.ToInt32(context.Request("NextState"))
                End If

                If context.Request("Action") IsNot Nothing Then
                    ActionKey = Convert.ToString(context.Request("Action"))
                End If

                If context.Request("SpecCol") IsNot Nothing Then
                    SpecColumn = Convert.ToString(context.Request("SpecCol"))
                End If

                If context.Request("InstanceKey") IsNot Nothing Then
                    InstanceKeyID = Convert.ToString(context.Request("InstanceKey"))
                End If

                If context.Request("IsMerge") IsNot Nothing Then
                    IsMergeUser = Convert.ToBoolean(context.Request("IsMerge"))
                End If
                Dim Result As String = GetUserInfo(IsMergeUser, InstanceID, TemplateID, CurrentStateID, NextStateID, ActionKey, SpecColumn, RouteResult, InstanceKeyID)
                context.Response.Write(Result)
        End Select





    End Sub

    ReadOnly Property IsReusable() As Boolean Implements IHttpHandler.IsReusable
        Get
            Return False
        End Get
    End Property



    Private Function GetUserInfo(ByVal IsMergeUser As Boolean, ByVal InstanceID As Guid, ByVal TemplateID As Integer, ByVal CurrentStateID As Integer, ByVal NextStateID As Integer, ByVal ActionKey As String, ByVal SpecColumn As String, ByVal RouteResult As String, ByVal InstanceKeyID As Integer) As String
        Dim Json As StringBuilder = New StringBuilder()
        If ActionKey = "Approve" Then


            Dim mNextFlowInfo As TemplateStateInfo = TemplateStateDAL.LoadTemplateStateInfoByTemplateStateID(NextStateID)
            If Not mNextFlowInfo Is Nothing Then
                If Not mNextFlowInfo.TemplateStateType = Enm_TemplateState_TemplateStateType.StopState Then
                    Dim SpecColumnList As List(Of DictionaryEntry) = SpecColumnInfo(SpecColumn)
                    Dim HumanCollection As New List(Of AccountInfo)

                   
                    Dim list As List(Of DictionaryEntry) = LoadPreSelectedObjList(NextStateID, 1) ' 此處1為辦理類別
                    If (list IsNot Nothing) AndAlso list.Count > 0 Then
                        For Each m As DictionaryEntry In list
                            Select Case CInt(m.Key)
                                Case 1 '人員帳號(1)
                                    If HumanCollection Is Nothing Then
                                        HumanCollection = New List(Of AccountInfo)
                                    End If
                                    Dim tmp As String = m.Value '人員帳號的PKID

                                    Dim mInfo As AccountInfo = AccountManage.LoadAccountByAccountPKID(CInt(tmp))
                                    If mInfo IsNot Nothing Then
                                        If Not HumanCollection.Contains(mInfo) Then
                                            HumanCollection.Add(mInfo)
                                        End If
                                    End If

                                Case 50 '當前人員主管
                                    If UserInfo.CurrentUserID <> String.Empty Then
                                        Dim accInfos As List(Of AccountInfo) = AccountManage.LoadLeaderCollection(UserInfo.CurrentUserID)
                                        If accInfos IsNot Nothing Then
                                            HumanCollection.AddRange(accInfos)
                                        End If
                                    End If
                                Case 51 '特定人員主管的主管
                                    Dim tmp As String = m.Value
                                    Dim accInfos As List(Of AccountInfo) = AccountManage.LoadLeaderCollection(tmp)
                                    If accInfos IsNot Nothing Then
                                        HumanCollection.AddRange(accInfos)
                                    End If
                                Case 53 '特定欄位內容（人員）的主管

                                    Dim mResourceInfo As ResourceInfoInfo = ResourceInfoDAL.LoadResourceInfoInfoByResourceKeyID(m.Value)
                                    If mResourceInfo IsNot Nothing Then
                                        Select Case mResourceInfo.Extend1
                                            Case 1
                                                For Each de As DictionaryEntry In SpecColumnList
                                                    If mResourceInfo.ResourceKeyID = CInt(de.Key) Then
                                                        If HumanCollection Is Nothing Then
                                                            HumanCollection = New List(Of AccountInfo)
                                                        End If
                                                        Dim accInfos As List(Of AccountInfo) = AccountManage.LoadLeaderCollection(de.Value.ToString)
                                                        If accInfos IsNot Nothing Then
                                                            HumanCollection.AddRange(accInfos)
                                                        End If
                                                        Exit For
                                                    End If
                                                Next
                                            Case 2
                                                For Each de As DictionaryEntry In SpecColumnList
                                                    If mResourceInfo.ResourceKeyID = CInt(de.Key) Then
                                                        
                                                        Dim mInfo As DepartmentInfo = DeptManage.LoadDepartment(de.Value)
                                                       
                                                        Dim mAccounts As List(Of AccountInfo) = DeptManage.LoadAccountCollecition(mInfo)
                                                        If mAccounts IsNot Nothing Then
                                                            HumanCollection.AddRange(mAccounts)
                                                        End If
                                                        Exit For
                                                    End If
                                                Next
                                            Case 3
                                                For Each de As DictionaryEntry In SpecColumnList
                                                    If mResourceInfo.ResourceKeyID = CInt(de.Key) Then
                                                       
                                                        Dim mInfo As RoleSettingInfo = RoleManage.LoadRole(CInt(de.Value))
                                                       
                                                        Dim mAccounts As List(Of AccountInfo) = RoleManage.LoadAccountCollection(mInfo)
                                                        If mAccounts IsNot Nothing Then

                                                           HumanCollection.AddRange(mAccounts)
                                                        End If
                                                        Exit For
                                                    End If
                                                Next
                                            Case 4
                                                For Each de As DictionaryEntry In SpecColumnList
                                                    If mResourceInfo.ResourceKeyID = CInt(de.Key) Then
                                                      
                                                        Dim mInfo As GroupSettingInfo = GroupManage.LoadGroup(CInt(de.Value))
                                                       
                                                        Dim mAccounts As List(Of AccountInfo) = GroupManage.LoadAccountCollection(mInfo)
                                                        If mAccounts IsNot Nothing Then
                                                            HumanCollection.AddRange(mAccounts)
                                                        End If
                                                        Exit For
                                                    End If
                                                Next
                                        End Select
                                    End If

                                Case 52 '特定部門主管
                                    Dim tmp As String = m.Value
                                    Dim accInfos As List(Of AccountInfo) = AccountManage.LoadDepartmentLeaderInfoByDeptPKID(CInt(tmp))
                                    If accInfos IsNot Nothing Then
                                        HumanCollection.AddRange(accInfos)
                                    End If

                                Case 2 '特定部門
                                    Dim tmp As String = m.Value
                                    Dim mInfo As DepartmentInfo = DeptManage.LoadDepartment(CInt(tmp))

                                    '[周富強2010/07/19]開發會議後討論決定
                                    Dim mAccounts As List(Of AccountInfo) = DeptManage.LoadAccountCollecition(mInfo)
                                    If mAccounts IsNot Nothing Then
                                        If IsMergeUser Then
                                            If HumanCollection IsNot Nothing Then
                                                HumanCollection.Intersect(mAccounts)
                                            Else
                                                HumanCollection.AddRange(mAccounts)
                                            End If

                                        Else
                                            HumanCollection.AddRange(mAccounts)
                                        End If
                                    End If
                                Case 3 '特定角色
                                    Dim Tmp As String = m.Value
                                    Dim mInfo As RoleSettingInfo = RoleManage.LoadRole(CInt(Tmp))
                                  

                                    '[周富強2010/07/19]開發會議後討論決定
                                    Dim mAccounts As List(Of AccountInfo) = RoleManage.LoadAccountCollection(mInfo)
                                    If mAccounts IsNot Nothing Then
                                        If IsMergeUser Then
                                            If HumanCollection IsNot Nothing Then
                                                HumanCollection.Intersect(mAccounts)
                                            Else
                                                HumanCollection.AddRange(mAccounts)
                                            End If

                                        Else
                                            HumanCollection.AddRange(mAccounts)
                                        End If
                                    End If
                                Case 4 '特定群組
                                    Dim Tmp As String = m.Value
                                    Dim mInfo As GroupSettingInfo = GroupManage.LoadGroup(CInt(Tmp))
                                    

                                    '[周富強2010/07/19]開發會議後討論決定
                                    Dim mAccounts As List(Of AccountInfo) = GroupManage.LoadAccountCollection(mInfo)
                                    If mAccounts IsNot Nothing Then
                                        If IsMergeUser Then
                                            If HumanCollection IsNot Nothing Then
                                                HumanCollection.Intersect(mAccounts)
                                            Else
                                                HumanCollection.AddRange(mAccounts)
                                            End If

                                        Else
                                            HumanCollection.AddRange(mAccounts)
                                        End If
                                    End If
                                Case 6 '特定欄位內容
                                    Dim mResourceInfo As ResourceInfoInfo = ResourceInfoDAL.LoadResourceInfoInfoByResourceKeyID(m.Value)
                                    If mResourceInfo IsNot Nothing Then
                                        Select Case mResourceInfo.Extend1
                                            Case 1
                                                For Each de As DictionaryEntry In SpecColumnList
                                                    If mResourceInfo.ResourceKeyID = CInt(de.Key) Then
                                                        If HumanCollection Is Nothing Then
                                                            HumanCollection = New List(Of AccountInfo)
                                                        End If
                                                        Dim mInfo As AccountInfo = AccountManage.LoadAccountInfoByUserSID(de.Value)
                                                        If mInfo IsNot Nothing Then
                                                            HumanCollection.Add(mInfo)
                                                        End If
                                                        Exit For
                                                    End If
                                                Next
                                            Case 2
                                                For Each de As DictionaryEntry In SpecColumnList
                                                    If mResourceInfo.ResourceKeyID = CInt(de.Key) Then
                                                       
                                                        Dim mInfo As DepartmentInfo = DeptManage.LoadDepartment(CInt(de.Value))
                                                      
                                                        Dim mAccounts As List(Of AccountInfo) = DeptManage.LoadAccountCollecition(mInfo)
                                                        If mAccounts IsNot Nothing Then
                                                            If IsMergeUser Then
                                                                If HumanCollection IsNot Nothing Then
                                                                    HumanCollection.Intersect(mAccounts)
                                                                Else
                                                                    HumanCollection.AddRange(mAccounts)
                                                                End If

                                                            Else
                                                                HumanCollection.AddRange(mAccounts)
                                                            End If
                                                        End If
                                                        Exit For
                                                    End If
                                                Next
                                            Case 3
                                                For Each de As DictionaryEntry In SpecColumnList
                                                    If mResourceInfo.ResourceKeyID = CInt(de.Key) Then
                                                       
                                                        Dim mInfo As RoleSettingInfo = RoleManage.LoadRole(CInt(de.Value))
                                                       
                                                        Dim mAccounts As List(Of AccountInfo) = RoleManage.LoadAccountCollection(mInfo)
                                                        If mAccounts IsNot Nothing Then
                                                            If IsMergeUser Then
                                                                If HumanCollection IsNot Nothing Then
                                                                    HumanCollection.Intersect(mAccounts)
                                                                Else
                                                                    HumanCollection.AddRange(mAccounts)
                                                                End If

                                                            Else
                                                                HumanCollection.AddRange(mAccounts)
                                                            End If
                                                        End If
                                                        Exit For
                                                    End If
                                                Next
                                            Case 4

                                                For Each de As DictionaryEntry In SpecColumnList
                                                    If mResourceInfo.ResourceKeyID = CInt(de.Key) Then
                                                       
                                                        Dim mInfo As GroupSettingInfo = GroupManage.LoadGroup(CInt(de.Value))
                                                       
                                                        Dim mAccounts As List(Of AccountInfo) = GroupManage.LoadAccountCollection(mInfo)
                                                        If mAccounts IsNot Nothing Then
                                                            If IsMergeUser Then
                                                                If HumanCollection IsNot Nothing Then
                                                                    HumanCollection.Intersect(mAccounts)
                                                                Else
                                                                    HumanCollection.AddRange(mAccounts)
                                                                End If

                                                            Else
                                                                HumanCollection.AddRange(mAccounts)
                                                            End If
                                                        End If
                                                        Exit For
                                                    End If
                                                Next
                                        End Select
                                    End If
                                Case 7 '特定步驟簽核人員

                                    Dim TransInfos As List(Of InstanceStateTransactInfo) = InstanceStateTransactDAL.LoadInstanceStateTransactByInstanceKeyIDAndStateID(InstanceKeyID, CInt(m.Value))
                                    If TransInfos IsNot Nothing AndAlso TransInfos.Count > 0 Then
                                        For Each TransInfo In TransInfos
                                            Dim mAccount As AccountInfo = AccountManage.LoadAccountByAccountPKID(TransInfo.TransactUserPKID)
                                            If mAccount IsNot Nothing Then
                                                HumanCollection.Add(mAccount)
                                            End If
                                        Next
                                    End If

                            End Select
                        Next
                    End If
                    If Not IsMergeUser Then
                        HumanCollection = HumanCollection.Distinct(New HumanComparer()).ToList '去掉集合中的重覆項
                    End If

                    If Not HumanCollection Is Nothing Then


                        ' Json.Append("{""total"":" + tableSource.Rows.Count.ToString + ",")
                        Json.Append("{""total"":" + HumanCollection.Count.ToString + ",")

                        Json.Append("""rows"":[")

                        For Each mHumanInfo In HumanCollection
                            Json.Append("{")
                            Json.Append("""UserPKID"":""" + mHumanInfo.AccountPKID.ToString + """")
                            Json.Append(",")
                            Json.Append("""UserSID"":""" + mHumanInfo.UserSID + """")
                            Json.Append(",")
                            Json.Append("""UserName"":""" + mHumanInfo.UserName + """")
                            Json.Append(",")
                            'Json.Append("""DeptName"":""" + mHumanInfo.DeptName + """")
                            Json.Append("""StateName"":""" + mNextFlowInfo.TemplateStateName + """")
                            Json.Append(",")
                            Json.Append("""NextStateID"":""" + mNextFlowInfo.TemplateStateID.ToString + """")

                            Json.Append("},")
                        Next
                        Json.Remove(Json.Length - 1, 1)
                        Json.Append("]}")

                        Return Json.ToString
                    End If
                Else
                    Json.Append("{""rows"":[")
                    Json.Append("]}")
                    Return Json.ToString
                End If

            End If
        ElseIf ActionKey = "Rejection" Then '駁回

            If InstanceKeyID > 0 Then  'if NextStateID=0 為駁回自由站別

                Dim dt As DataTable = InstanceStateTransactDAL.LoadHistoryTractUser(InstanceKeyID, NextStateID)
                If Not dt Is Nothing Then
                    Dim UserInfo As List(Of String) = New List(Of String)
                    UserInfo.Add("UserPKID")
                    UserInfo.Add("StateName")
                    UserInfo.Add("UserSID")
                    UserInfo.Add("UserName")
                    UserInfo.Add("NextStateID")
                    Dim text As String = JsonHelper.ToJson(0, dt, "UserInfo", UserInfo)
                    Return text
                End If
            End If


        End If
        Return String.Empty

    End Function



    Private Shared Function LoadPreSelectedObjList(ByVal NextStateID As Integer, ByVal AuthorizeCategory As Integer) As List(Of DictionaryEntry)
        If NextStateID > 0 Then
            Dim authorzeSetList As List(Of AuthorizeSetInfo) = AuthorizeSetDAL.GetAuthorizeSetByTemplateStateID(NextStateID)
            If authorzeSetList IsNot Nothing AndAlso authorzeSetList.Count > 0 Then
                Dim ReturnList As New List(Of DictionaryEntry)
                For Each m As AuthorizeSetInfo In authorzeSetList
                    If m.AuthorizeCategory = AuthorizeCategory Then
                        If m.AuthorizeType = "6" Then
                            Dim mResource As ResourceInfoInfo = ResourceInfoDAL.LoadResourceInfoInfoByResourceKeyID(m.AuthorizeID)
                            If (mResource IsNot Nothing) AndAlso (mResource.Extend1 > 0) Then
                                ReturnList.Add(New DictionaryEntry(m.AuthorizeType, m.AuthorizeID.ToString))
                            End If
                        Else
                            ReturnList.Add(New DictionaryEntry(m.AuthorizeType, m.AuthorizeID.ToString))
                        End If
                    End If
                Next
                Return ReturnList
            Else
                Return Nothing
            End If
        Else
            Return Nothing
        End If
    End Function


    Private Function SpecColumnInfo(ByVal SpecColumn As String) As List(Of DictionaryEntry)

        Dim returnList As List(Of DictionaryEntry) = Nothing
        If SpecColumn <> String.Empty Then
            Dim TmpStrList As String() = SpecColumn.Trim.Split("^")
            If TmpStrList.Length > 0 Then
                Dim keyID As String() = TmpStrList(0).Split(":")
                Dim KeyValue As String() = TmpStrList(1).Split(":")
                returnList = New List(Of DictionaryEntry)
                For i As Integer = 0 To keyID.Length - 1 Step i + 1
                    returnList.Add(New DictionaryEntry(keyID(i), KeyValue(i)))
                Next
                
            End If
        End If
        Return returnList

    End Function
End Class


''' <summary>
''' 比較類
''' </summary>
''' <remarks>
''' 用于解析完對象綁定到用戶清單上的數據源采用人員ID過濾重覆項
''' </remarks>
Public Class HumanComparer
    Implements IEqualityComparer(Of AccountInfo)

    Public Function Equals1(ByVal x As Platform.eHR.Core.AccountInfo, ByVal y As Platform.eHR.Core.AccountInfo) As Boolean Implements System.Collections.Generic.IEqualityComparer(Of Platform.eHR.Core.AccountInfo).Equals
        Return x.AccountPKID.Equals(y.AccountPKID)
    End Function

    Public Function GetHashCode1(ByVal obj As Platform.eHR.Core.AccountInfo) As Integer Implements System.Collections.Generic.IEqualityComparer(Of Platform.eHR.Core.AccountInfo).GetHashCode
        Return obj.AccountPKID.GetHashCode()
    End Function
End Class