Imports Webb.WAVE.Controls.Upload
Imports System.IO
Imports Platform.eAuthorize
Imports System.Web.Services

Partial Public Class FileShare
    Inherits System.Web.UI.Page
    Private Property UseSize() As Long
        Get
            If Not ViewState("UseSize") Is Nothing Then
                Return CType(ViewState("UseSize"), Long)
            Else
                ViewState("UseSize") = 0
                Return 0
            End If
        End Get
        Set(ByVal value As Long)
            ViewState("UseSize") = value
        End Set
    End Property
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            bindcustomer()
        End If
    End Sub
    Private Sub bindcustomer()
        If UserInfo.IsInRoles("SYS_ADMINISTRATOR") OrElse UserInfo.IsInRoles("EXTERNALWORKER") OrElse UserInfo.IsInRoles("CRMTECSUPPORT") OrElse UserInfo.IsInRoles("Yewuzhuguan") OrElse UserInfo.IsInRoles("TEDINGSHENHE") OrElse UserInfo.IsInRoles("ZHONGXINZHUGUAN") Then
            Me.HiddenCanSelectCus.Value = "1"
            Me.LbCustomer.Visible = False
        Else
            Me.HiddenCanSelectCus.Value = "0"
            Dim curcontactinfo As ContactInfo = ContactDAL.GetInfoByUserSID(UserInfo.CurrentUserID)
            If Not curcontactinfo Is Nothing AndAlso Not curcontactinfo.PKID = 0 Then
                Me.LbCustomer.Text = curcontactinfo.CustomerName
                LbCustomer.Visible = True
                lbtishi.Visible = False
                Me.HiddenCustomerPKID.Value = curcontactinfo.CusTomerPKID
                Me.HiddenCustomerName.Value = curcontactinfo.CustomerName
                Me.Txtcustomer.Visible = False
                bindgrid()
            End If
        End If

       
    End Sub
    Private Sub bindgrid()
        If Me.HiddenCustomerPKID.Value > 0 Then
            UseSize = 0
            filecount = 0
            Dim SearchOption As String = " RecordDeleted =0 and ParentCategory=3 and Extend3='1' and ParentSubCategory=" + Me.HiddenCustomerPKID.Value.ToString
            Dim FileInfos As DataSet = WF_AttachFileInfoDAL.GetdsnocontentInfoBySearchCondtion(SearchOption)
            If FileInfos IsNot Nothing Then
                emptyinfo.Visible = False
                Me.GridView1.DataSource = FileInfos
                Me.GridView1.DataKeyNames = New String() {"FileID"}
                Me.GridView1.DataBind()
            Else
                emptyinfo.Visible = True
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


                'iStream = New System.IO.FileStream(FileDownLoadPath, System.IO.FileMode.Open, _
                '                                    IO.FileAccess.Read, IO.FileShare.Read)


            Case "remove"
                FileID = e.CommandArgument
                If FileID <> 0 Then
                    WF_AttachFileInfoDAL.Delete(FileID)
                End If
                bindgrid()
        End Select
    End Sub
    Dim filecount As Integer = 0
    Private Sub GridView1_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GridView1.RowDataBound

        If e.Row.RowType = DataControlRowType.DataRow Then

            Dim lblFileName As String = CType(e.Row.FindControl("lblFileName"), Label).Text


            Dim btnRem As ImageButton = DirectCast(e.Row.FindControl("btnRemove"), ImageButton)
            btnRem.Attributes.Add("onclick", "return confirm('請確認是否刪除此筆資料!');")
            Dim LblFileSize As Label = CType(e.Row.FindControl("LblFileSize"), Label)
            Dim LblFileSizeShow As Label = CType(e.Row.FindControl("LblFileSizeShow"), Label)
            Dim newfilesize As String = GetFormatString(LblFileSize.Text)
            LblFileSizeShow.Text = newfilesize
            UseSize += CType(LblFileSize.Text, Long)
            filecount += 1
        End If
    End Sub


    Public Shared Function GetFormatString(ByVal FileSize As Double) As String
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

                ' .Flush()
                .End()

            End With
        End If
    End Sub
    'Protected Sub Button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button1.Click
    '    Dim m_path As String = Path.Combine(MapPath("."), "TempUploadFiles")
    '    Dim m_upload As WebbUpload = New WebbUpload()
    '    Dim mfiles As UploadFileCollection = m_upload.GetUploadFileList("m_file")
    '    Dim m_filePath As String = String.Empty
    '    For Each m_file As UploadFile In mfiles
    '        If Not m_file.FileName Is Nothing AndAlso Not m_file.FileName = String.Empty Then
    '            m_filePath = Path.Combine(m_path, m_file.FileName)
    '            m_file.SaveAs(m_filePath)
    '            Dim AttachFileInfo As WF_AttachFileInfoInfo = New WF_AttachFileInfoInfo()  '保存至數據庫
    '            AttachFileInfo.FileID = 0
    '            AttachFileInfo.ParentID = Me.DPLcustomer.SelectedValue
    '            AttachFileInfo.ParentCategory = 3
    '            AttachFileInfo.ParentSubCategory = 0
    '            AttachFileInfo.FileGuID = System.Guid.NewGuid()
    '            AttachFileInfo.FileName = m_file.ClientFullPathName
    '            AttachFileInfo.FileExtension = m_file.FileName.Substring(m_file.FileName.LastIndexOf(".") + 1)
    '            Dim NewName As String = DateTime.Now.ToString("yyyyMMddHHmm") + m_file.FileName
    '            Dim iStream As Stream = New System.IO.FileStream(m_filePath, System.IO.FileMode.Open, _
    '                                                        IO.FileAccess.Read, IO.FileShare.Read)
    '            Dim MyArray(iStream.Length) As Byte
    '            iStream.Read(MyArray, 0, MyArray.Length)
    '            AttachFileInfo.FileContent = MyArray
    '            AttachFileInfo.FileSize = iStream.Length
    '            iStream.Close()

    '            AttachFileInfo.FileClientName = NewName
    '            AttachFileInfo.Extend1 = UserInfo.CurrentUserCHName
    '            AttachFileInfo.Extend2 = Me.TxtRemark.Text
    '            AttachFileInfo.Extend3 = String.Empty
    '            AttachFileInfo.Extend4 = String.Empty
    '            AttachFileInfo.Extend5 = String.Empty
    '            AttachFileInfo.RecordVersion = ConfigurationInfo.RecordVersion
    '            AttachFileInfo.RecordCreateTime = DateTime.Now
    '            AttachFileInfo.RecordDeleted = 0
    '            Dim AttachDal As WF_AttachFileInfoDAL = New WF_AttachFileInfoDAL(AttachFileInfo)
    '            AttachDal.Save()
    '        End If
    '    Next
    '    bindgrid()
    'End Sub

    'Protected Sub Button1_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Button1.Load
    '    Dim _webupload As WebbUpload = New WebbUpload()
    '    _webupload.RegisterProgressBar(Button1)
    'End Sub

    Protected Sub DPLcustomer_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles DPLcustomer.SelectedIndexChanged
        bindgrid()
    End Sub

    Protected Sub GridView1_DataBound(ByVal sender As Object, ByVal e As EventArgs) Handles GridView1.DataBound
        Me.Lbtongji.Text = String.Format("您的資料共享區:文件總數{0}，已經使用空間{1}，<font color='#009933'>剩餘{2}</font>", filecount, GetFormatString(UseSize), GetFormatString(2147483648 - UseSize))
        If UseSize >= 2147483648 Then
            'Me.Button1.Visible = False
            Me.Lbtongji.Text += "請刪除部份文件后再上傳"
        End If
    End Sub
    <WebMethod()> _
 Public Shared Function GetAllCustomer() As List(Of DictionaryEntry)
        Dim mCustomerInfo As List(Of DictionaryEntry) = CustomersDAL.GetAllCustomerdic()
        Return mCustomerInfo
    End Function
    <WebMethod()> _
 Public Shared Function GetCustomerUseinfo(ByVal CustomerPKID As Integer) As String
        Dim UseSize As Long = WF_AttachFileInfoDAL.GetTongjiInfoByCustomerPKID(CustomerPKID)
        Dim ReturnString As String = String.Empty
        ReturnString = String.Format("您的資料共享區: ，已經使用空間{0}，<font color='#009933'>剩餘{1}</font>", GetFormatString(UseSize), GetFormatString(2147483648 - UseSize))
        If UseSize >= 2147483648 Then
            ReturnString += "請刪除部份文件后再上傳"
        End If
        Return ReturnString
    End Function

    Protected Sub Button2_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button2.Click
        bindgrid()
    End Sub
End Class