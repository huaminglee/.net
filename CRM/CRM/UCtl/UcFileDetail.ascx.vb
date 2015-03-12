Imports CuteEditor
Imports System.IO
Imports Platform.eWorkFlow.Core.DAL
Imports Platform.eWorkFlow.Model
Imports Platform.Framework

Partial Public Class UcFileDetail
    Inherits System.Web.UI.UserControl
    Private ReadOnly HIDE_ParentID = "ViewState:ParentID"
    Private ReadOnly HIDE_ParentCategory = "ViewState:ParentCategory"
    Private ReadOnly HIDE_ParentSubCategory = "ViewState:ParentSubCategory"
    Private ReadOnly HIDE_CANUpload As String = "ViewState:CanUpload"
    Private ReadOnly HIDE_CANDownLoad As String = "ViewState:CanDownLoad"
    Private ReadOnly HIDE_CANRemove As String = "ViewState:CanRemove"
    Private ReadOnly HIDE_CANEdit As String = "ViewState:CanEdit"
    Private _FileGuidList As List(Of String) = New List(Of String)

#Region "Property"
    ''' <summary>
    ''' 附件主表PKID
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property ParentID() As Integer
        Get
            If ViewState(HIDE_ParentID) Is Nothing Then
                Return 0
            Else
                Return Convert.ToInt32(ViewState(HIDE_ParentID))
            End If
        End Get
        Set(ByVal Value As Integer)
            ViewState(HIDE_ParentID) = Value
        End Set
    End Property

    ''' <summary>
    ''' 附件父類別
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property ParentCategory() As Integer
        Get
            If ViewState(HIDE_ParentCategory) Is Nothing Then
                Return 0
            Else
                Return Convert.ToInt32(ViewState(HIDE_ParentCategory))
            End If
        End Get
        Set(ByVal Value As Integer)
            ViewState(HIDE_ParentCategory) = Value
        End Set
    End Property
    ''' <summary>
    ''' 上傳文件集合(需要修改这些FileGuid對應的ParentID)
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property FileGuidList() As List(Of String)
        Get
            Return _FileGuidList
        End Get
        Set(ByVal Value As List(Of String))
            _FileGuidList = Value
        End Set
    End Property

    ''' <summary>
    ''' 附件子類別
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property ParentSubCategory() As Integer
        Get
            If ViewState(HIDE_ParentSubCategory) Is Nothing Then
                Return 0
            Else
                Return Convert.ToInt32(ViewState(HIDE_ParentSubCategory))
            End If
        End Get
        Set(ByVal Value As Integer)
            ViewState(HIDE_ParentSubCategory) = Value
        End Set
    End Property
    ''' <summary>
    '''  是否可上傳數據
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property CanUpload() As Boolean
        Get
            If ViewState(HIDE_CANUpload) Is Nothing Then
                Return True
            Else
                Return Convert.ToBoolean(ViewState(HIDE_CANUpload))
            End If
        End Get
        Set(ByVal Value As Boolean)
            ViewState(HIDE_CANUpload) = Value
        End Set
    End Property

    ''' <summary>
    '''  是否可下載附件
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property CanDownLoad() As Boolean
        Get
            If ViewState(HIDE_CANDownLoad) Is Nothing Then
                Return True
            Else
                Return Convert.ToBoolean(ViewState(HIDE_CANDownLoad))
            End If
        End Get
        Set(ByVal Value As Boolean)
            ViewState(HIDE_CANDownLoad) = Value
        End Set
    End Property

    ''' <summary>
    '''     是否可刪除附件
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property CanRemove() As Boolean
        Get
            If ViewState(HIDE_CANRemove) Is Nothing Then
                Return False
            Else
                Return Convert.ToBoolean(ViewState(HIDE_CANRemove))
            End If
        End Get
        Set(ByVal Value As Boolean)
            ViewState(HIDE_CANRemove) = Value
        End Set
    End Property

    ''' <summary>
    '''  是否可編輯
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property CanEdit() As Boolean
        Get
            If ViewState(HIDE_CANEdit) Is Nothing Then
                Return True
            Else
                Return Convert.ToBoolean(ViewState(HIDE_CANEdit))
            End If
        End Get
        Set(ByVal Value As Boolean)
            ViewState(HIDE_CANEdit) = Value
            ViewState(HIDE_CANRemove) = Value
            ViewState(HIDE_CANDownLoad) = Value
            ViewState(HIDE_CANUpload) = Value
        End Set
    End Property

    ''' <summary>
    '''  可以上传的文件类型
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property FileUplode() As String
        Get
            If ViewState("FilteUplode") Is Nothing Then
                Return String.Empty
            Else
                Return ViewState("FilteUplode").ToString
            End If
        End Get
        Set(ByVal Value As String)
            ViewState("FilteUplode") = Value
        End Set
    End Property

    ''' <summary>
    '''  可以上传的文件大小
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property FileSize() As Integer
        Get
            If ViewState("FilteSize") Is Nothing Then
                Return 0
            Else
                Return CInt(ViewState("FilteSize"))
            End If
        End Get
        Set(ByVal Value As Integer)
            ViewState("FilteSize") = Value
        End Set
    End Property


    Public Property FileCount() As Integer
        Get
            If ViewState("FileCount") Is Nothing Then
                Return 0
            Else
                Return CInt(ViewState("FileCount"))
            End If
        End Get
        Set(ByVal value As Integer)
            ViewState("FileCount") = value
        End Set
    End Property
    Private _mFileInfos As List(Of WF_AttachFileInfoInfo)
    Private Property mFileInfos() As List(Of WF_AttachFileInfoInfo)
        Get
            If ViewState("mFileInfos") Is Nothing Then
                _mFileInfos = Nothing
            Else
                _mFileInfos = ViewState("mFileInfos")
            End If
            Return _mFileInfos
        End Get
        Set(ByVal value As List(Of WF_AttachFileInfoInfo))
            _mFileInfos = value
            ViewState("mFileInfos") = value
        End Set
    End Property
    Public Property ISQuotation() As String
        Get
            If ViewState("ISQuotation") Is Nothing Then
                Return "0"
            Else
                Return ViewState("ISQuotation")
            End If
        End Get
        Set(ByVal value As String)
            ViewState("ISQuotation") = value
        End Set
    End Property
#End Region

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            BindControlText()
            If ParentID > 0 AndAlso ParentCategory >= 0 Then
                'If ISQuotation = 0 Then
                BindDataGrid()
                'ElseIf ISQuotation = 1 Then
                'BindDataGridQuotation()
                'End If

            End If
        Else
            ReBuildFileList()
        End If

    End Sub

    Private Sub ReBuildFileList()
        If Me.GridView1.Rows.Count > 0 Then
            Dim i As Integer
            For i = 0 To Me.GridView1.Rows.Count - 1
                Dim item As GridViewRow = Me.GridView1.Rows(i)
                Dim lblparentID As Integer = CInt(DirectCast(item.FindControl("lblParentID"), Label).Text)
                If lblparentID <= 0 Then
                    _FileGuidList.Add(DirectCast(item.FindControl("LblFileGuiD"), Label).Text)
                End If
            Next
        End If
    End Sub

    Private Sub BindControlText()

        If Not CanUpload Then ' 不能上传时直接隐藏UploadAttachments1控件
            Me.UploadAttachments1.Visible = False
            Me.BrowseButton.Visible = False
        Else
            UploadAttachments1.ActionButtonText = "下載"
            UploadAttachments1.RemoveButtonText = "刪除"
            UploadAttachments1.ShowActionButtons = CanDownLoad
            UploadAttachments1.ShowRemoveButtons = CanRemove
            UploadAttachments1.ValidateOption.AllowedFileExtensions = FileUplode
            If FileSize > 0 Then
                UploadAttachments1.ValidateOption.MaxSizeKB = FileSize * 10274 '转化为字节
            End If
        End If
    End Sub
    Private Sub BindDataGridQuotation()
        Dim SearchCondition As String = String.Format(" RecordDeleted!=1 AND ( ( ParentID in (select TestControlPKID  from TestApplyManage .dbo .TestControlInfo where ApplyPKID in (select ApplyPKID from TestApplyManage .dbo.TestApplyInfo where TestApplyInfo . Extend10 ='{0}'))  AND ParentCategory=2 AND ( ParentSubCategory=0 or ParentSubCategory=4) or (ParentCategory=4 and ParentSubCategory=4 and ParentID in(select ApplyPKID from TestApplyManage .dbo.TestApplyInfo where TestApplyInfo . Extend10 ='{0}') )))", ParentID)
        Dim FileList As List(Of WF_AttachFileInfoInfo) = WF_AttachFileInfoDAL.GetInfoBySearchCondtionQuotation(SearchCondition)
        mFileInfos = FileList
        BindDataGrid(FileList)
    End Sub
    Public Sub BindDataGrid()
        Dim SearchOption As String = " RecordDeleted!=1 AND ParentID='" + ParentID.ToString + "' AND ParentCategory='" + ParentCategory.ToString + "' AND ParentSubCategory='" + ParentSubCategory.ToString + "'"
        Dim FileList As List(Of WF_AttachFileInfoInfo) = WF_AttachFileInfoDAL.GetInfoBySearchCondtion(SearchOption)
        mFileInfos = FileList
        BindDataGrid(FileList)
    End Sub

    Private Sub BindDataGrid(ByVal FileInfos As List(Of WF_AttachFileInfoInfo))
        If FileInfos IsNot Nothing AndAlso FileInfos.Count > 0 Then
            FileCount = FileInfos.Count
            HidFileCount.Value = FileInfos.Count
            Me.GridView1.DataSource = FileInfos
            Me.GridView1.DataKeyNames = New String() {"FileID"}
            Me.GridView1.DataBind()
        Else
            HidFileCount.Value = 0
            Me.GridView1.DataSource = Nothing
            Me.GridView1.DataBind()
        End If
    End Sub




    '附件上傳完成后進行重新綁定
    Private Sub UploadAttachments1_UploadCompleted(ByVal sender As Object, ByVal args() As CuteEditor.UploaderEventArgs) Handles UploadAttachments1.UploadCompleted
        BindDataGrid(mFileInfos)
        For Each mfileinfo As WF_AttachFileInfoInfo In mFileInfos
            Dim FileDownLoadPath As String = String.Format("{0}\{1}\{2}", Server.MapPath(Request.ApplicationPath), "UploadFiles", mfileinfo.FileClientName)
            If File.Exists(FileDownLoadPath) Then
                File.Delete(FileDownLoadPath)
            End If
        Next
    End Sub

    '附件下載
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

                ' .Flush()
                .End()

            End With
        End If
    End Sub

#Region "GridView Events"

    Private Sub GridView1_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GridView1.RowCommand
        Dim FileID As String
        Dim DateRow As GridViewRow = CType(CType(e.CommandSource, Control).Parent.Parent, GridViewRow)
        Dim mFileClientName As String = CType(DateRow.Cells(1).FindControl("lblFileClientName"), Label).Text
        'Dim FileDownLoadPath As String
        'If ISQuotation = 1 Then
        '    Dim TestNo As String = CType(DateRow.Cells(1).FindControl("LbTestNo"), Label).Text
        '    If TestNo <> String.Empty Then
        '        FileDownLoadPath = String.Format("{0}\{1}\{2}\{3}", ConfigurationManager.AppSettings("FilePath"), TestNo.Substring(0, TestNo.Length - 7), TestNo, mFileClientName)
        '    End If
        'Else
        '    FileDownLoadPath = String.Format("{0}\{1}\{2}", Server.MapPath(Request.ApplicationPath), "UploadFiles", mFileClientName)
        'End If

        'Dim FileDownLoadPath As String = String.Format("{0}\{1}", ConfigurationManager.AppSettings("FilePath"), mFileClientName)
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


                'iStream = New System.IO.FileStream(FileDownLoadPath, System.IO.FileMode.Open, _
                '                                    IO.FileAccess.Read, IO.FileShare.Read)


            Case "remove"
                FileID = e.CommandArgument

                'If File.Exists(FileDownLoadPath) Then
                '    File.Delete(FileDownLoadPath)
                'End If
                If mFileInfos(DateRow.RowIndex).FileID <> 0 Then
                    WF_AttachFileInfoDAL.Delete(mFileInfos(DateRow.RowIndex).FileID)
                End If
                mFileInfos.RemoveAt(DateRow.RowIndex)
                BindDataGrid(mFileInfos)
        End Select
    End Sub

    Private Sub GridView1_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GridView1.RowDataBound

        If e.Row.RowType = DataControlRowType.DataRow Then
            If CanEdit Then
                e.Row.FindControl("btnRemove").Visible = CanRemove
                e.Row.FindControl("btnDownload").Visible = CanDownLoad
            End If

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

#End Region

    Private Sub Page_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.PreRender
        Me.GridView1.Attributes.Add("onmouseout", "")
        Me.GridView1.Attributes.Add("onmouseover", "")
    End Sub

    '将下載控件注册为回发的触发器，才可以下載
    Protected Sub BtnDownLoadInit(ByVal sender As Object, ByVal e As EventArgs)
        Dim ScriptManager1 As ScriptManager
        If Me.Page.Master Is Nothing Then
            ScriptManager1 = DirectCast(Me.Page.FindControl("ScriptManager1"), ScriptManager)
        Else
            ScriptManager1 = DirectCast(Me.Page.Master.FindControl("ScriptManager1"), ScriptManager)
        End If
        ScriptManager1.RegisterPostBackControl(CType(sender, Control))

    End Sub


    Protected Sub UploadAttachments1_FileUploaded1(ByVal sender As Object, ByVal args As CuteEditor.UploaderEventArgs) Handles UploadAttachments1.FileUploaded

        Dim AttachFileInfo As WF_AttachFileInfoInfo = New WF_AttachFileInfoInfo()  '保存至數據庫
        AttachFileInfo.FileID = 0
        AttachFileInfo.ParentID = ParentID
        AttachFileInfo.ParentCategory = ParentCategory
        AttachFileInfo.ParentSubCategory = ParentSubCategory
        AttachFileInfo.FileGuID = args.FileGuid
        AttachFileInfo.FileName = args.FileName
        AttachFileInfo.FileSize = args.FileSize



        'MyStream.Close()
        'Dim iStream As Stream = New System.IO.FileStream(curargs.GetTempFilePath(), System.IO.FileMode.Open, _
        '                                             IO.FileAccess.Read, IO.FileShare.Read)


        AttachFileInfo.FileExtension = args.FileName.Substring(args.FileName.LastIndexOf(".") + 1)
        Dim NewName As String = DateTime.Now.ToString("yyyyMMddHHmm") + args.FileName
        My.Computer.FileSystem.RenameFile(args.GetTempFilePath(), NewName) '文件上傳完后可以重命名文件名
        '  Dim iStream As Stream = curargs.OpenStream()
        Dim FileDownLoadPath As String = String.Format("{0}\{1}\{2}", Server.MapPath(Request.ApplicationPath), "UploadFiles", NewName)
        Dim iStream As Stream = New System.IO.FileStream(FileDownLoadPath, System.IO.FileMode.Open, _
                                                    IO.FileAccess.Read, IO.FileShare.Read)
        Dim MyArray(args.FileSize) As Byte
        iStream.Read(MyArray, 0, args.FileSize)
        AttachFileInfo.FileContent = MyArray
        iStream.Close()
        AttachFileInfo.FileClientName = NewName
        AttachFileInfo.Extend1 = String.Empty
        AttachFileInfo.Extend2 = String.Empty
        AttachFileInfo.Extend3 = String.Empty
        AttachFileInfo.Extend4 = String.Empty
        AttachFileInfo.Extend5 = String.Empty
        AttachFileInfo.RecordVersion = ConfigurationInfo.RecordVersion
        AttachFileInfo.RecordCreateTime = DateTime.Now
        AttachFileInfo.RecordDeleted = 0
        'Dim AttachDal As WF_AttachFileInfoDAL = New WF_AttachFileInfoDAL(AttachFileInfo)
        'AttachDal.Save()
        If mFileInfos Is Nothing Then
            mFileInfos = New List(Of WF_AttachFileInfoInfo)

        End If

        mFileInfos.Add(AttachFileInfo)
        HidFileCount.Value = mFileInfos.Count

    End Sub

    Public Sub SaveDatatoDataBase()
        If Not mFileInfos Is Nothing Then

            For Each AttachFileInfo As WF_AttachFileInfoInfo In mFileInfos

                AttachFileInfo.ParentID = ParentID
                Dim AttachDal As WF_AttachFileInfoDAL = New WF_AttachFileInfoDAL(AttachFileInfo)
                AttachDal.Save()
            Next

        End If
    End Sub
End Class