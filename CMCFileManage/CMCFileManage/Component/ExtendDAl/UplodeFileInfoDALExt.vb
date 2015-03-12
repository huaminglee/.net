Imports Platform.eWorkFlow.Model
Imports Platform.Framework



Partial Public Class UplodeFileInfoDAL


    ''' <summary>依文件GuID刪除記錄</summary>
    ''' <param name="FileGuid">附件FileGuid</param>
    ''' <remarks></remarks>
    Public Shared Sub DeleteByFileGuid(ByVal FileGuid As String)
        SqlHelper.ExecuteNonQuery(ConfigurationInfo.ConnectionString, "WF_DeleteAttachFileInfoByFileGuid", FileGuid)
    End Sub

    Public Shared Sub ChangeParentIDByFileList(ByVal ParentID As Integer, ByVal FileGuidList As String)
        SqlHelper.ExecuteNonQuery(ConfigurationInfo.ConnectionString, "WF_ChangeAttachFileInfoByFileGuid", ParentID, FileGuidList)

    End Sub

End Class
