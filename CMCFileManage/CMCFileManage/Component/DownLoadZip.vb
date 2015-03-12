Imports System.IO
Imports ICSharpCode.SharpZipLib.Zip


Public Class DownLoadZip
    Inherits System.Web.UI.Page

    Private _Arrary_FileName As String() = Nothing
    Private _Real_FileName As String() = Nothing
    Private _FilePath As String = Nothing
    Private _Memory As MemoryStream = New MemoryStream
    Public _ZipName As String = Date.Now.ToString
    Public _ErrorMessage As String = ""
#Region "property"
    ''' <summary>
    ''' 要下載的文件名稱，昰一個數組
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property FileNames() As String()
        Get
            Return _Arrary_FileName
        End Get
        Set(ByVal value As String())
            _Arrary_FileName = value
        End Set
    End Property

    ''' <summary>
    ''' 要下載的文件所在文件夾的路徑
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property FilePath() As String
        Get
            Return _FilePath
        End Get
        Set(ByVal value As String)
            _FilePath = value
        End Set
    End Property

    ''' <summary>
    ''' 壓縮檔的名稱
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property ZipName() As String
        Get
            Return _ZipName
        End Get
        Set(ByVal value As String)
            _ZipName = value
        End Set
    End Property

    ''' <summary>
    '''出現異常時的信息（錯誤信息）
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property ErrorMessage() As String
        Get
            Return _ErrorMessage
        End Get
    End Property

    Public Property RealFilename() As String()
        Get
            Return _Real_FileName
        End Get
        Set(ByVal value As String())
            _Real_FileName = value
        End Set
    End Property


    Public ReadOnly Property Memory() As MemoryStream
        Get
            Return _Memory
        End Get
    End Property




#End Region


#Region "public  function"
    Public Function CreatStream() As Boolean

        Dim array_FileName As String() = FileNames
        Dim strmZipOutputStream As ZipOutputStream
        strmZipOutputStream = New ZipOutputStream(_Memory)
        strmZipOutputStream.SetLevel(9)


        If FileNames Is Nothing Then
            _ErrorMessage = "沒有要要打包的文件，請給FileNames確定的值"
            Return False
        End If

        If FilePath Is Nothing Then
            _ErrorMessage = "沒有確定文件的位置，請給FilePath確定的值"
            Return False
        End If

        If Me.RealFilename Is Nothing Then
            Me.RealFilename = Me.FileNames
        End If
        Dim Array_realname As String() = Me.RealFilename

        Dim index As Integer
        For index = 0 To array_FileName.Length - 1
            Dim FileDownLoadPath As String = FilePath + "\" + array_FileName(index)
            If File.Exists(FileDownLoadPath) Then
                Dim iStream As System.IO.FileStream
                iStream = New System.IO.FileStream(FileDownLoadPath, System.IO.FileMode.Open, _
                                                    IO.FileAccess.Read, IO.FileShare.Read)
                Dim Byte_FileStream(iStream.Length - 1) As Byte
                iStream.Read(Byte_FileStream, 0, iStream.Length - 1)
                Dim abyBuffer As Byte() = Byte_FileStream
                Dim objZipEntry As ZipEntry = New ZipEntry(Array_realname(index))
                objZipEntry.DateTime = DateTime.Now
                objZipEntry.Size = abyBuffer.Length
                strmZipOutputStream.PutNextEntry(objZipEntry)
                strmZipOutputStream.Write(abyBuffer, 0, abyBuffer.Length)
            Else
                strmZipOutputStream.Finish()
                _ErrorMessage = "你所要下載的文件有的不存在"
                Return False
            End If
        Next
        strmZipOutputStream.Finish()
        Return True
    End Function

#End Region


End Class
