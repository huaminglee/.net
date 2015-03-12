Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.IO


''' <summary>
''' 日志类(常用的都是用log4net，这里简陋地实现一个写入文本日志类)
''' </summary>
Public NotInheritable Class SimpleLogger
    Private Sub New()
    End Sub

    ''' <summary>
    ''' 写入异常日志
    ''' </summary>
    ''' <param name="exMsg"></param>
    ''' <param name="path"></param>
    ''' <remarks></remarks>
    Public Shared Sub WriteFileLog(ByVal exMsg As String, ByVal path As String)
        Dim fs As FileStream = Nothing
        Dim m_streamWriter As StreamWriter = Nothing
        Try
            If Not Directory.Exists(path) Then
                Directory.CreateDirectory(path)
            End If

            path = path & "\" & DateTime.Now.ToString("yyyyMMdd") & ".txt"
            fs = New FileStream(path, FileMode.OpenOrCreate, FileAccess.Write)
            m_streamWriter = New StreamWriter(fs)
            m_streamWriter.BaseStream.Seek(0, SeekOrigin.[End])
            m_streamWriter.WriteLine(DateTime.Now.ToString() & vbLf)
            m_streamWriter.WriteLine("-----------------------------------------------------------")
            m_streamWriter.WriteLine("-----------------------------------------------------------")
            m_streamWriter.WriteLine(exMsg)
            m_streamWriter.WriteLine("-----------------------------------------------------------")
            m_streamWriter.WriteLine("-----------------------------------------------------------")
            m_streamWriter.Flush()
        Finally
            If m_streamWriter IsNot Nothing Then
                m_streamWriter.Close()
            End If
            If fs IsNot Nothing Then
                fs.Close()
            End If
        End Try
    End Sub
End Class

