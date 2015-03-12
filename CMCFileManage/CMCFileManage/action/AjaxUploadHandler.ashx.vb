Imports System.Web
Imports System.Web.Services
Imports System.IO

Public Class Handler1
    Implements System.Web.IHttpHandler

    Sub ProcessRequest(ByVal context As HttpContext) Implements IHttpHandler.ProcessRequest

        context.Response.ContentType = "text/plain"

        Dim postedFile As HttpPostedFile = context.Request.Files("Filedata")
        Dim filelength As Integer = postedFile.ContentLength
        Dim fileSize As Integer = 163600 '150K

        Dim uploadPath As String = ConfigurationManager.AppSettings("FilePath")
        Dim savePath As String

        Dim LabCode As String = String.Empty
        Dim CaseCode As String = String.Empty

        If context.Request.Params("TestNO") IsNot Nothing OrElse Not context.Request.Params("TestNO").ToString = "" Then
            CaseCode = context.Request.Params("TestNO").ToString.Trim
            LabCode = CaseCode.Trim.Substring(0, CaseCode.Length - 7)
        End If

        If CaseCode.Contains("?") Then
            savePath = uploadPath + "\" + LabCode + "\ApplyFile"
        Else
            savePath = uploadPath + "\" + LabCode + "\" + CaseCode
        End If
        '判断实验室的文件夹是否存在，不存在则新建
        If Not Directory.Exists(uploadPath + "\" + LabCode) Then
            Directory.CreateDirectory(uploadPath + "\" + LabCode)
        End If

        '判断测试编码的文件夹是否存在，不存在则新建
        If Not Directory.Exists(savePath) Then
            Directory.CreateDirectory(savePath)
        End If

        Dim FileName As String = postedFile.FileName.Substring(postedFile.FileName.LastIndexOf("\") + 1)
        Dim ExtendName As String = FileName.Substring(FileName.LastIndexOf("."), FileName.Length - FileName.LastIndexOf(".") - 1) '擴展名
        Dim FileClientName As String = DateTime.Now.ToString("yyyyMMddhhmmssFFF") + "." + ExtendName


        postedFile.SaveAs(Path.Combine(savePath, FileClientName))



        Dim mApplyPKID As Integer = CInt(context.Request("PKID"))
        Dim mParentCategory As Integer = CInt(context.Request("ParentCategory"))
        Dim FileDescription As String = context.Request("FileDesc")
        Dim ParentSubCategory As Integer
        If context.Request("ParentSubCategory") IsNot Nothing OrElse Not context.Request("TestNO").ToString = "" Then
            ParentSubCategory = CInt(context.Request("ParentSubCategory"))
        Else
            ParentSubCategory = 0
        End If

        Dim ExceptionNO As String
        If context.Request("ExceptionNO") IsNot Nothing Then
            ExceptionNO = context.Request("ExceptionNO").ToString
        Else
            ExceptionNO = ""
        End If

        Dim mInfo As New QC_AttachFileInfoInfo


        mInfo.FileID = 0
        mInfo.ParentID = mApplyPKID
        mInfo.ParentCategory = mParentCategory
        mInfo.ParentSubCategory = ParentSubCategory
        mInfo.FileGuID = Guid.Empty
        mInfo.FileName = FileName
        mInfo.FileExtension = ExtendName
        mInfo.FileSize = postedFile.ContentLength
        mInfo.FileClientName = FileClientName
        mInfo.Extend1 = FileDescription
        mInfo.Extend5 = ExceptionNO
        Dim mFileDao As QC_AttachFileInfoDAL = New QC_AttachFileInfoDAL(mInfo)
        mFileDao.Save()


        context.Response.Write("1")




    End Sub

   

     
  
    ReadOnly Property IsReusable() As Boolean Implements IHttpHandler.IsReusable
        Get
            Return False
        End Get
    End Property

End Class