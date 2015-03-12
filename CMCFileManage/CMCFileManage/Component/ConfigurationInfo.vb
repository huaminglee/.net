Imports System.Globalization
Imports System.Threading

Public Class ConfigurationInfo
    ''' <summary>
    ''' 數據庫連接字串
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared ReadOnly Property ConnectionString() As String
        Get
            Return System.Configuration.ConfigurationManager.ConnectionStrings("DBConnStr").ConnectionString
        End Get
    End Property

    Public Shared ReadOnly Property UploadTempPath() As String
        Get
            Return System.Configuration.ConfigurationManager.AppSettings("UploadTempPath").ToString
        End Get
    End Property

    Public Shared ReadOnly Property SystemModuleList() As String
        Get
            Return System.Configuration.ConfigurationManager.AppSettings("SystemModuleList").ToString
        End Get
    End Property
    ''' <summary>
    ''' 數據格式
    ''' </summary>
    Public Shared ReadOnly Property DeciamalFormat() As String
        Get
            Return ConfigurationManager.AppSettings("DeciamlFormat")
        End Get
    End Property

    ''' <summary>
    ''' 取得當前線程的文化屬性名稱
    ''' </summary>
    ''' <value></value>
    ''' <remarks>
    ''' </remarks>
    Public Shared ReadOnly Property GetCurrentCultureName() As String
        Get
            Dim ci As CultureInfo = Thread.CurrentThread.CurrentCulture
            Return ci.Name
        End Get
    End Property '取得當前線程的文化屬性名稱

    ''' <summary>
    ''' 取得當前DLL對應的版本編號
    ''' </summary>
    ''' <value></value>
    ''' <remarks>
    ''' </remarks>
    Public Shared ReadOnly Property RecordVersion() As String
        Get
            Dim m_AssInfo As System.Reflection.Assembly = System.Reflection.Assembly.GetExecutingAssembly
            Dim mAssemblyName As System.Reflection.AssemblyName = m_AssInfo.GetName
            Dim mVersion As Version = mAssemblyName.Version
            Return mVersion.ToString
        End Get
    End Property '取得當前DLL對應的版本編號
    ''' <summary>
    ''' 自定分頁默認記錄數
    ''' </summary>
    Public Shared ReadOnly Property PageSize() As String
        Get
            Return ConfigurationManager.AppSettings("CustomPageSize")
        End Get
    End Property
    Public Shared ReadOnly Property UrlBase()
        Get
            Dim mURLBase As String = String.Format("http://{0}{1}", HttpContext.Current.Request.Url.Authority, HttpContext.Current.Request.ApplicationPath)
            If mURLBase.EndsWith("/") Then
                Return mURLBase.Substring(0, mURLBase.Length - 1)
            Else
                Return mURLBase
            End If
        End Get
    End Property
    Public Shared Function GetPageInfoBySearchCondition(ByVal TableName As String, ByVal SearchCondition As String, ByVal Fields As String, _
                                                    ByVal OrderField As String, Optional ByVal PageSize As Integer = 20, _
                                                    Optional ByVal pageIndex As Integer = 1, Optional ByVal TotalRecord As Integer = 0) As DataSet

        Dim ds As DataSet = SqlHelper.ExecuteDataset(ConfigurationInfo.ConnectionString, "up_Page2005V2", TableName, Fields, OrderField, SearchCondition, PageSize, pageIndex, TotalRecord)




        Dim dt As DataTableCollection = ds.Tables()
        If dt(0).Rows.Count = 0 Then
            Return Nothing
        Else
            Return ds
        End If

    End Function
    Public Shared Role_Admin As String = "SYS_ADMINISTRATOR" '管理員
End Class
