Imports Platform.eAuthorize

Partial Public Class GridFile
    Inherits System.Web.UI.UserControl
    Public Property RecordType() As Integer
        Get
            If ViewState("RecordType") Is Nothing Then
                Return 0
            End If
            Return CInt(ViewState("RecordType"))
        End Get
        Set(ByVal value As Integer)
            ViewState("RecordType") = value
        End Set
    End Property
    Public Property IsFinished() As Integer
        Get
            If ViewState("IsFinished") Is Nothing Then
                Return 0
            End If
            Return CInt(ViewState("IsFinished"))
        End Get
        Set(ByVal value As Integer)
            ViewState("IsFinished") = value
        End Set
    End Property
    Public Property DeptName() As String
        Get
            If ViewState("DeptName") Is Nothing Then
                Return ""
            End If
            Return ViewState("DeptName")
        End Get
        Set(ByVal value As String)
            ViewState("DeptName") = value
        End Set
    End Property
    Public Property DisplayInfo() As String
        Get
            If ViewState("Css") Is Nothing Then
                Return "Show"
            Else
                Return ViewState("Css")
            End If
        End Get
        Set(ByVal value As String)
            ViewState("Css") = value
        End Set
    End Property
    Public Property FileCategory() As String
        Get
            If ViewState("FileCategory") Is Nothing Then
                Return ""
            End If
            Return ViewState("FileCategory")
        End Get
        Set(ByVal value As String)
            ViewState("FileCategory") = value
        End Set
    End Property
    Public Property ParentType() As Integer
        Get
            If ViewState("ParentType") Is Nothing Then
                Return 1
            End If
            Return CInt(ViewState("ParentType"))
        End Get
        Set(ByVal value As Integer)
            ViewState("ParentType") = value
        End Set
    End Property
    Public Property Searchcondition() As String
        Get
            If ViewState("Searchcondition") Is Nothing Then
                Return ""
            End If
            Return ViewState("Searchcondition")
        End Get
        Set(ByVal value As String)
            ViewState("Searchcondition") = value
        End Set
    End Property
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub
    Public Sub BindFile()
        Dim parimg As Image = Me.Parent.Parent.FindControl("Image1")
        If DisplayInfo = "Show" Then
            parimg.ImageUrl = "../Images/Expand.png"
            If ParentType = 1 AndAlso UserInfo.IsInRoles("QALEADER") Then
                Me.GridView1.Columns(7).Visible = True
            End If
            Dim dt As DataTable
            If ParentType = 1 Then
                dt = QC_FileInfoDAL.GetFileBySearchcondition(Searchcondition)
            ElseIf ParentType = 2 Then
                dt = QC_FileInfoDAL.GetFileBySearchcondition(Searchcondition)
            ElseIf ParentType = 3 Then
                dt = QC_FileInfoDAL.GetFileBySearchcondition(Searchcondition)
            ElseIf ParentType = 4 Then
                dt = QC_FileInfoDAL.GetFileBySearchcondition(Searchcondition)
            End If

            If Not dt Is Nothing Then
                Me.GridView1.DataSource = dt
                Me.GridView1.DataKeyNames = New String() {"PKID"}
                Me.GridView1.DataBind()
                Me.GridView1.Attributes.Add("Style", "display:inline")
            Else
                Me.GridView1.DataSource = Nothing
                Me.GridView1.DataBind()

            End If

        ElseIf DisplayInfo = "Hid" Then
            parimg.ImageUrl = "../Images/addGrid.png"
            Me.GridView1.Attributes.Add("Style", "display:none")
        End If

    End Sub

    Protected Sub GridView1_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GridView1.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            e.Row.Attributes.Add("onmouseover", "this.style.cursor='hand';this.style.color='#FFFFFF'; currentcolor=this.style.backgroundColor;this.style.backgroundColor='#40A0FE',this.style.fontWeight='';")
            e.Row.Attributes.Add("onmouseout", "this.style.color='#1e5494'; this.style.backgroundColor=currentcolor,this.style.fontWeight='';")
            'If e.Row.Cells(1).Text.Length > 15 Then
            '    e.Row.Cells(1).ToolTip = e.Row.Cells(1).Text
            '    e.Row.Cells(1).Text = e.Row.Cells(1).Text.Substring(0, 14) + "..."
            'End If
            If e.Row.Cells(6).Text = "9999/12/31" Then
                e.Row.Cells(6).Text = "未生效"
            End If
            If ParentType = 1 Then
                Dim mPKID As Integer = CInt(GridView1.DataKeys(e.Row.RowIndex).Value)
                Dim DocUniqueID As String = CType(e.Row.FindControl("lblDocUniqueID"), Label).Text
                Dim HLDetail As HyperLink = CType(e.Row.FindControl("HLDetail"), HyperLink)
                Dim ReturnURL As String = "../Forms/AddQCFileDetail.aspx?pkid=" + mPKID.ToString + "&Type=" + RecordType.ToString
                If (DocUniqueID <> String.Empty AndAlso DocUniqueID <> Guid.Empty.ToString) Then
                    ReturnURL = ReturnURL + "&" + Global_asax.QUERY_DOCUNIQUEID + "=" + DocUniqueID
                End If
                e.Row.Attributes.Add("onclick", "window.location.href='" + ReturnURL + "';")
                HLDetail.NavigateUrl = ReturnURL
                Dim BtnCancel As ImageButton = TryCast(e.Row.FindControl("BtnDelete"), ImageButton)
                BtnCancel.Attributes.Add("onclick", " return confirm('確定要刪除該記錄嗎?');")

            ElseIf ParentType = 2 OrElse ParentType = 3 OrElse ParentType = 4 Then
                Dim pkid As Integer = CType(e.Row.FindControl("LblPKID"), Label).Text
                Dim eflowdocid As String = CType(e.Row.FindControl("lblDocUniqueID"), Label).Text
                Dim HLDetail As HyperLink = CType(e.Row.FindControl("HLDetail"), HyperLink)
                Dim returnurl As String = "../Forms/QCFileDetail.aspx?pkid=" + pkid.ToString + "&Type=" + RecordType.ToString
                e.Row.Attributes.Add("onclick", "window.location.href='" + returnurl + "';")
                If eflowdocid <> String.Empty AndAlso eflowdocid <> Guid.Empty.ToString Then
                    returnurl = returnurl + "&" + Global_asax.QUERY_DOCUNIQUEID + "=" + eflowdocid
                End If
                Dim isinchange As String = SqlHelper.ExecuteDataset(ConfigurationInfo.ConnectionString, "QC_ISinchange", pkid).Tables(0).Rows(0).Item("notfinishcount").ToString
                If isinchange <> "0" Then
                    e.Row.BackColor = System.Drawing.Color.Gray
                End If
                e.Row.Attributes.Add("onclick", "window.location.href='" + returnurl + "';")
                HLDetail.NavigateUrl = returnurl
            End If

        End If
    End Sub
    Protected Sub GridView1_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles GridView1.RowDeleting
        Dim mpkid As Integer = Convert.ToInt32(GridView1.DataKeys(e.RowIndex).Value)
        QC_FileInfoDAL.Delete(mpkid)
        Dim newdeletelog As DeleteLogInfo = New DeleteLogInfo()
        newdeletelog.pkid = 0
        newdeletelog.Parentid = mpkid
        newdeletelog.parenttype = "品質文件"
        newdeletelog.DeleteUserName = UserInfo.CurrentUserCHName
        newdeletelog.DeleteUserSID = UserInfo.CurrentUserID
        newdeletelog.RecordCreated = DateTime.Now
        Dim newdeletedal As DeleteLogDAL = New DeleteLogDAL(newdeletelog)
        newdeletedal.Save()
        BindFile()
    End Sub
End Class