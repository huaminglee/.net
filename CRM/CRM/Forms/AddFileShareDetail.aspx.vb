Imports Webb.WAVE.Controls.Upload
Imports eWorkFlow.eFlowDoc
Imports System.IO
Imports Platform.eAuthorize

Partial Public Class AddFileShareDetail
    Inherits System.Web.UI.Page
    Implements IDocInfo

#Region "Const"
    Private Const HIDE_APPLICANTIDX_KEY As String = "ViewState:PKID"
    Private Const HIDE_DOCUNIQUEID_KEY As String = "ViewState:DocUniqueID"
    Private Const _SearchConditon As String = "ViewState:SearchConditon"
    Private Const HIDE_SORTFIELD As String = "ViewState:SortField"
    Private Const HIDE_SortOrder As String = "ViewState:SortOrder"
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
    Private Property CustomerPKID() As Integer
        Get
            If ViewState("CustomerPKID") Is Nothing Then
                Return 0
            End If

            Return Convert.ToInt32(ViewState("CustomerPKID"))
        End Get
        Set(ByVal Value As Integer)
            ViewState("CustomerPKID") = Value
        End Set
    End Property
    '流程控制文件ID
    Private Property DocUniqueID() As String
        Get
            If ViewState(HIDE_DOCUNIQUEID_KEY) Is Nothing Then
                Return String.Empty
            End If

            Return ViewState(HIDE_DOCUNIQUEID_KEY).ToString()
        End Get
        Set(ByVal Value As String)
            ViewState(HIDE_DOCUNIQUEID_KEY) = Value
        End Set
    End Property
    Private _curAddFileShareInfo As AddFileSharedInfo
    Private Property curAddFileShareInfo() As AddFileSharedInfo
        Get
            If _curAddFileShareInfo Is Nothing Then
                If PKID <> 0 Then
                    _curAddFileShareInfo = AddFileSharedDAL.GetInfoByPKID(PKID)

                ElseIf DocUniqueID <> String.Empty Then
                    _curAddFileShareInfo = AddFileSharedDAL.GetInfoByeFLowdocID(DocUniqueID)
                    PKID = _curAddFileShareInfo.PKID

                Else
                    _curAddFileShareInfo = New AddFileSharedInfo()
                End If
            End If

            Return _curAddFileShareInfo
        End Get
        Set(ByVal value As AddFileSharedInfo)
            _curAddFileShareInfo = value
        End Set
    End Property

    Private ReadOnly Property InitSearch() As String
        Get
            If ViewState("InitSearch") IsNot Nothing Then
                Return CStr(ViewState("InitSearch"))
            Else
                Dim SearchCondition As String = String.Empty
                SearchCondition = " "
                Return SearchCondition
            End If
        End Get

    End Property

    Private ReadOnly Property SearchCondition() As String
        Get
            If ViewState("SearchCondition") Is Nothing Then
                Return InitSearch
            Else
                Return ViewState("SearchCondition").ToString

            End If
        End Get
    End Property
    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' 排序字段
    ''' </summary>
    ''' <value></value>
    ''' <remarks>
    ''' </remarks>
    ''' -----------------------------------------------------------------------------
    Private Property SortField() As String
        Get
            If ViewState(HIDE_SORTFIELD) Is Nothing Then
                ViewState(HIDE_SORTFIELD) = "ServiceType, TestItemName"
                ViewState(HIDE_SortOrder) = "DESC"
            End If
            Return ViewState(HIDE_SORTFIELD).ToString
        End Get
        Set(ByVal Value As String)
            ViewState(HIDE_SORTFIELD) = Value
        End Set
    End Property

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' 排序方式
    ''' </summary>
    ''' <value></value>
    ''' <remarks>
    ''' </remarks>
    ''' -----------------------------------------------------------------------------
    Private Property SortOrder() As String
        Get
            If ViewState(HIDE_SortOrder) Is Nothing Then
                ViewState(HIDE_SortOrder) = "DESC"
            Else
            End If
            Return ViewState(HIDE_SortOrder).ToString.Trim
        End Get
        Set(ByVal Value As String)
            ViewState(HIDE_SortOrder) = Value
        End Set
    End Property
#End Region
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            GetParam()
            BindControlData()
        End If
    End Sub
    Private Sub GetParam()
        If Not Request.QueryString("PKID") Is Nothing Then
            PKID = Convert.ToInt32(Request.QueryString("PKID"))
        End If
        If Not Request.QueryString(Global_asax.QUERY_DOCUNIQUEID) Is Nothing Then
            DocUniqueID = Request.QueryString(Global_asax.QUERY_DOCUNIQUEID)
        End If

    End Sub
    Private Sub BindControlData()
        If Not curAddFileShareInfo Is Nothing Then
            If PKID = 0 Then

            Else

                Me.Txtcustomer.Text = curAddFileShareInfo.CustomerName
                Me.HiddenCustomerName.Value = curAddFileShareInfo.CustomerName
                Me.HiddenCustomerPKID.Value = curAddFileShareInfo.CustomerPKID

                Dim UseSize As Long = WF_AttachFileInfoDAL.GetTongjiInfoByCustomerPKID(CustomerPKID)
                Dim ReturnString As String = String.Empty
                ReturnString = String.Format("您的資料共享區: ，已經使用空間{0}，<font color='#009933'>剩餘{1}</font>", GetFormatString(UseSize), GetFormatString(2147483648 - UseSize))
                If UseSize >= 2147483648 Then
                    ReturnString += "請刪除部份文件后再上傳"
                End If
                Lbtongji.Text = ReturnString
                BindGrid()
            End If
        End If
    End Sub
    Private Sub BindGrid()
        If Me.HiddenCustomerPKID.Value > 0 Then


            Dim SearchOption As String = " RecordDeleted =0 and ParentCategory=3 and ParentID=" + PKID.ToString
            Dim FileInfos As DataSet = WF_AttachFileInfoDAL.GetdsnocontentInfoBySearchCondtion(SearchOption)
            If FileInfos IsNot Nothing Then
                Me.GridView1.DataSource = FileInfos
                Me.GridView1.DataKeyNames = New String() {"FileID"}
                Me.GridView1.DataBind()
            Else
                Me.GridView1.DataSource = Nothing
                Me.GridView1.DataBind()
            End If

        End If
    End Sub
    Private Sub GridView1_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GridView1.RowCommand
        Dim FileID As String
        Dim DateRow As GridViewRow = CType(CType(e.CommandSource, Control).Parent.Parent, GridViewRow)
        Dim mFileClientName As String = CType(DateRow.Cells(1).FindControl("lblFileClientName"), Label).Text

        Select Case e.CommandName.ToLower
            Case "download"
                Dim lblFileName As String = CType(DateRow.Cells(1).FindControl("lblFileName"), Label).Text

                FileID = e.CommandArgument

                Dim mFIleInfo As WF_AttachFileInfoInfo = WF_AttachFileInfoDAL.GetInfoByPKID(FileID)
                If mFIleInfo IsNot Nothing Then
                    If mFIleInfo.FileContent IsNot Nothing AndAlso mFIleInfo.FileContent.Length > 0 Then
                        Dim iStream As System.IO.Stream = New MemoryStream(mFIleInfo.FileContent)
                        FileDownload(lblFileName, mFIleInfo.FileContent.Length, iStream)
                    End If

                End If

            Case "remove"
                FileID = e.CommandArgument
                If FileID <> 0 Then
                    WF_AttachFileInfoDAL.Delete(FileID)
                End If
                BindGrid()
        End Select
    End Sub
    Private Sub GridView1_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GridView1.RowDataBound

        If e.Row.RowType = DataControlRowType.DataRow Then

            Dim lblFileName As String = CType(e.Row.FindControl("lblFileName"), Label).Text
            Dim btnRem As ImageButton = DirectCast(e.Row.FindControl("btnRemove"), ImageButton)
            btnRem.Attributes.Add("onclick", "return confirm('請確認是否刪除此筆資料!');")
            Dim LblFileSize As Label = CType(e.Row.FindControl("LblFileSize"), Label)
            Dim LblFileSizeShow As Label = CType(e.Row.FindControl("LblFileSizeShow"), Label)
            Dim newfilesize As String = GetFormatString(LblFileSize.Text)
            LblFileSizeShow.Text = newfilesize
        End If
    End Sub
    Private Function GetFormatString(ByVal FileSize As Double) As String
        Dim sizeString As String
        If FileSize > 1048576 Then
            sizeString = Math.Round(FileSize / 1048576, 2).ToString + " MB"
        ElseIf FileSize > 1024 Then
            sizeString = Math.Round(FileSize / 1024, 2).ToString + " KB"
        Else
            sizeString = FileSize.ToString + " B"
        End If
        Return sizeString
    End Function

    Private Sub FileDownload(ByVal strFileName As String, ByVal FileSize As Double, ByVal iStream As Stream)
        If strFileName <> "" Then
            With Page.Response
                .Clear()
                .ClearHeaders()
                .Buffer = False
                .ContentType = "application/octet-stream"""
                .ContentEncoding = System.Text.Encoding.GetEncoding("UTF-8")

                Page.Response.AddHeader("content-disposition", "attachment;filename=" & HttpUtility.UrlEncode(strFileName, System.Text.Encoding.UTF8))
                Response.AppendHeader("Content-Length", FileSize.ToString())
                Dim buffer(10000) As Byte

                Dim length As Integer

                Dim dataToRead As Long

                Try
                    dataToRead = iStream.Length

                    While dataToRead > 0
                        If Response.IsClientConnected Then
                            length = iStream.Read(buffer, 0, 10000)

                            Response.OutputStream.Write(buffer, 0, length)

                            Response.Flush() ' Clear the buffer

                            ReDim buffer(10000)
                            dataToRead = dataToRead - length
                        Else
                            dataToRead = -1
                        End If
                    End While

                Catch ex As Exception
                    Response.Write("Error : " & ex.Message)
                Finally
                    If IsNothing(iStream) = False Then
                        iStream.Close()
                    End If
                End Try

                .End()

            End With
        End If
    End Sub
    Private Sub Saveinfo()
        curAddFileShareInfo.CustomerName = Me.HiddenCustomerName.Value
        curAddFileShareInfo.CustomerPKID = Me.HiddenCustomerPKID.Value
        curAddFileShareInfo.UploadUserSID = UserInfo.CurrentUserID
        curAddFileShareInfo.RecordCreated = DateTime.Now
        curAddFileShareInfo.RecordDeleted = 2
        Dim curadddal As AddFileSharedDAL = New AddFileSharedDAL(curAddFileShareInfo)
        curadddal.Save()
        PKID = curAddFileShareInfo.PKID
    End Sub
    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button1.Click
        If PKID = 0 Then
            Saveinfo()
        End If
        Dim m_path As String = Path.Combine(MapPath("."), "TempUploadFiles")
        Dim m_upload As WebbUpload = New WebbUpload()
        Dim mfiles As UploadFileCollection = m_upload.GetUploadFileList("m_file")
        Dim m_filePath As String = String.Empty
        For Each m_file As UploadFile In mfiles
            If Not m_file.FileName Is Nothing AndAlso Not m_file.FileName = String.Empty Then
                m_filePath = Path.Combine(m_path, m_file.FileName)
                m_file.SaveAs(m_filePath)
                Dim AttachFileInfo As WF_AttachFileInfoInfo = New WF_AttachFileInfoInfo()  '保存至數據庫
                AttachFileInfo.FileID = 0
                AttachFileInfo.ParentID = PKID
                AttachFileInfo.ParentCategory = 3
                AttachFileInfo.ParentSubCategory = Me.HiddenCustomerPKID.Value
                AttachFileInfo.FileGuID = System.Guid.NewGuid()
                If m_file.ClientFullPathName.IndexOf("\") > -1 Then
                    AttachFileInfo.FileName = m_file.ClientFullPathName.Substring(m_file.ClientFullPathName.LastIndexOf("\") + 1, m_file.ClientFullPathName.Length - m_file.ClientFullPathName.LastIndexOf("\") - 1)
                Else
                    AttachFileInfo.FileName = m_file.ClientFullPathName
                End If
                AttachFileInfo.FileExtension = m_file.FileName.Substring(m_file.FileName.LastIndexOf(".") + 1)
                Dim NewName As String = DateTime.Now.ToString("yyyyMMddHHmm") + m_file.FileName
                Dim iStream As Stream = New System.IO.FileStream(m_filePath, System.IO.FileMode.Open, _
                                                            IO.FileAccess.Read, IO.FileShare.Read)
                Dim MyArray(iStream.Length) As Byte
                iStream.Read(MyArray, 0, MyArray.Length)
                AttachFileInfo.FileContent = MyArray
                AttachFileInfo.FileSize = iStream.Length
                iStream.Close()

                AttachFileInfo.FileClientName = NewName
                AttachFileInfo.Extend1 = UserInfo.CurrentUserCHName
                AttachFileInfo.Extend2 = Me.TxtRemark.Text
                AttachFileInfo.Extend3 = "0"
                AttachFileInfo.Extend4 = String.Empty
                AttachFileInfo.Extend5 = String.Empty
                AttachFileInfo.RecordVersion = ConfigurationInfo.RecordVersion
                AttachFileInfo.RecordCreateTime = DateTime.Now
                AttachFileInfo.RecordDeleted = 0
                Dim AttachDal As WF_AttachFileInfoDAL = New WF_AttachFileInfoDAL(AttachFileInfo)
                AttachDal.Save()
                If File.Exists(m_filePath) Then
                    File.Delete(m_filePath)
                End If
            End If
        Next
        BindGrid()
    End Sub

    Protected Sub Button1_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Button1.Load
        Dim _webupload As WebbUpload = New WebbUpload()
        _webupload.RegisterProgressBar(Button1)
    End Sub
#Region "IDOC"
    Public ReadOnly Property BusniessName() As String Implements eWorkFlow.eFlowDoc.IDocInfo.BusniessName
        Get
            Return "客戶資料共享審核"
        End Get
    End Property

    Public Sub DeleteDocInfo(ByVal CurDocInfo As eWorkFlow.eFlowDoc.DocInfoSystem, ByVal CommandName As Platform.eWorkFlow.Model.Enm_ActionType) Implements eWorkFlow.eFlowDoc.IDocInfo.DeleteDocInfo
        AddFileSharedDAL.Delete(PKID)
        WF_AttachFileInfoDAL.DeleteByParentIDandParentcategory(PKID, 3, Me.HiddenCustomerPKID.Value)
    End Sub

    Public ReadOnly Property IsUseFlow() As Boolean Implements eWorkFlow.eFlowDoc.IDocInfo.IsUseFlow
        Get
            Return True
        End Get
    End Property

    Public Sub LeaveDocInfo() Implements eWorkFlow.eFlowDoc.IDocInfo.LeaveDocInfo
        If CtlWFActionList1.OnlySave Then
            Dim ReturnURL As String = "../Forms/AddFileShareDetail.aspx?" & Global_asax.QUERY_APPLICANTIDX & "=" + PKID.ToString
            If (DocUniqueID <> String.Empty AndAlso DocUniqueID <> Guid.Empty.ToString) Then
                ReturnURL = ReturnURL + "&" + Global_asax.QUERY_DOCUNIQUEID + "=" + DocUniqueID
            End If
            Response.Redirect(ReturnURL)
        Else

            Response.Redirect("../Forms/AddFileShareList.aspx")
            
        End If
    End Sub

    Public Sub LoadDocInfo(ByVal CurDocInfo As eWorkFlow.eFlowDoc.DocInfoSystem) Implements eWorkFlow.eFlowDoc.IDocInfo.LoadDocInfo
        If CurDocInfo.CurStateOrder = 1 Then
            Me.HiddenCanSelectCus.Value = "1"
        Else
        End If
        CtlWFActionList1.CurURL = String.Format("{0}?PageType=fileshare", Global_asax.URL_INDEX)  '往框架中跳
    End Sub

    Public Sub SaveDocInfo(ByVal CurDocInfo As eWorkFlow.eFlowDoc.DocInfoSystem, ByVal CommandName As Platform.eWorkFlow.Model.Enm_ActionType) Implements eWorkFlow.eFlowDoc.IDocInfo.SaveDocInfo
        DocUniqueID = CurDocInfo.DocUniqueID
        curAddFileShareInfo.PKID = PKID
        curAddFileShareInfo.eFlowDocID = New Guid(CurDocInfo.DocUniqueID)
        curAddFileShareInfo.CustomerName = Me.HiddenCustomerName.Value
        curAddFileShareInfo.CustomerPKID = Me.HiddenCustomerPKID.Value
        curAddFileShareInfo.UploadUserSID = UserInfo.CurrentUserID.ToString + "/" + UserInfo.CurrentUserCHName
        curAddFileShareInfo.RecordDeleted = 0
        Dim curAddFileShareDal As AddFileSharedDAL = New AddFileSharedDAL(curAddFileShareInfo)
        curAddFileShareDal.Save()

    End Sub

    Public ReadOnly Property TemplateName() As String Implements eWorkFlow.eFlowDoc.IDocInfo.TemplateName
        Get
            Return "客戶資料共享審核"
        End Get
    End Property

    Public ReadOnly Property TemplateVersion() As Integer Implements eWorkFlow.eFlowDoc.IDocInfo.TemplateVersion
        Get
            Return 1
        End Get
    End Property
#End Region
#Region "ActionList"

    Private Sub CtlWFActionList1_Postopen(ByVal CurDocInfo As eWorkFlow.eFlowDoc.DocInfoSystem, ByVal e As eWorkFlow.eFlowDoc.BaseEventArgs) Handles CtlWFActionList1.Postopen
        If CurDocInfo.CurStateOrder = 1 Then
            Dim SaveScript As StringBuilder = New StringBuilder()
            SaveScript.Append("if ($('#HiddenCustomerPKID').val()=='0'  ){alert('请选择客户'); return false;}  ")

            CtlWFActionList1.AduitScript = SaveScript.ToString
            CtlWFActionList1.SaveScript = SaveScript.ToString
        End If
    End Sub


    Private Sub CtlWFActionList1_Postsave(ByVal CurDocInfo As eWorkFlow.eFlowDoc.DocInfoSystem, ByVal e As eWorkFlow.eFlowDoc.PostSaveDocEventArgs) Handles CtlWFActionList1.Postsave
        If e.CommandName = Platform.eWorkFlow.Model.Enm_ActionType.Finish Then
            AddFileSharedDAL.UpFileInfoFinish(PKID)
        End If
    End Sub

    Private Sub CtlWFActionList1_Querysave(ByVal CurDocInfo As eWorkFlow.eFlowDoc.DocInfoSystem, ByVal e As eWorkFlow.eFlowDoc.QuerySaveDocEventArgs) Handles CtlWFActionList1.Querysave
        If e.CommandName = Platform.eWorkFlow.Model.Enm_ActionType.Approve _
         OrElse e.CommandName = Platform.eWorkFlow.Model.Enm_ActionType.Rejection _
         OrElse e.CommandName = Platform.eWorkFlow.Model.Enm_ActionType.Revoke _
         OrElse e.CommandName = Platform.eWorkFlow.Model.Enm_ActionType.Finish Then
            curAddFileShareInfo.StateName = CurDocInfo.NextStateName
            curAddFileShareInfo.StateOrder = CurDocInfo.NextStateOrder
        Else
            curAddFileShareInfo.StateName = CurDocInfo.CurStateName
            curAddFileShareInfo.StateOrder = CurDocInfo.CurStateOrder
        End If
        If e.CommandName = Platform.eWorkFlow.Model.Enm_ActionType.Finish Then
            curAddFileShareInfo.IsFinished = 1
            curAddFileShareInfo.FinishTime = DateTime.Now
        End If
    End Sub
    Protected Sub Button2_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button2.Click
        Dim USEsize As Long = WF_AttachFileInfoDAL.GetTongjiInfoByCustomerPKID(Me.HiddenCustomerPKID.Value)
        Me.Lbtongji.Text = String.Format("您的資料共享區: 已經使用空間{0}，<font color='#009933'>剩餘{1}</font>", GetFormatString(USEsize), GetFormatString(2147483648 - USEsize))
        If USEsize >= 247483648 Then
            Me.Button1.Visible = False
            Me.Lbtongji.Text += "請刪除部份文件后再上傳"
        End If
    End Sub
#End Region
End Class