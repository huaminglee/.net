Imports System.Web
Imports System.Web.Services
Imports System.IO

Public Class AjaxUploadHandler
    Implements System.Web.IHttpHandler

    Sub ProcessRequest(ByVal context As HttpContext) Implements IHttpHandler.ProcessRequest

        context.Response.ContentType = "text/plain"

        Dim postedFile As HttpPostedFile = context.Request.Files("Filedata")
        Dim mInfo As New WF_AttachFileInfoInfo
        Dim MyStream As Stream = postedFile.InputStream()
        Dim filelength As Integer = postedFile.ContentLength
        Dim br As New BinaryReader(MyStream)
        Dim MyArray() As Byte = br.ReadBytes(MyStream.Length)
        mInfo.FileSize = MyStream.Length
        br.Close()
        MyStream.Close()
        MyStream.Read(MyArray, 0, filelength)


        Dim FileName As String = postedFile.FileName.Substring(postedFile.FileName.LastIndexOf("\") + 1)
        Dim ExtendName As String = Right(FileName, FileName.Length - FileName.LastIndexOf(".") - 1)  '擴展名


        Dim mPKID As Integer = CInt(context.Request("PKID"))
        Dim mParentCategory As Integer = CInt(context.Request("ParentCategory"))
        Dim FileDescription As String = context.Request("FileDesc")
        Dim ParentSubCategory As Integer
        If Not context.Request("ParentSubCategory") Is Nothing Then
            ParentSubCategory = CInt(context.Request("ParentSubCategory"))
        Else
            ParentSubCategory = 0
        End If
        Dim uploader As String = String.Empty
        If Not context.Request("uploader") Is Nothing Then
            uploader = context.Request("uploader").ToString
        End If





        mInfo.FileID = 0
        mInfo.ParentID = mPKID
        mInfo.ParentCategory = mParentCategory
        mInfo.ParentSubCategory = ParentSubCategory
        mInfo.FileGuID = Guid.NewGuid()
        mInfo.FileName = FileName
        mInfo.FileExtension = ExtendName
        mInfo.RecordCreateTime = DateTime.Now
        mInfo.FileClientName = FileName
        mInfo.Extend1 = FileDescription
        mInfo.Extend2 = uploader
        mInfo.FileContent = MyArray
        Dim mFileDao As WF_AttachFileInfoDAL = New WF_AttachFileInfoDAL(mInfo)
        mFileDao.Save()


        context.Response.Write("1")

    End Sub

    ReadOnly Property IsReusable() As Boolean Implements IHttpHandler.IsReusable
        Get
            Return False
        End Get
    End Property

End Class