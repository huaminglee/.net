Imports System.Configuration
Imports System.Globalization
Imports System.Threading
Imports System.Xml
Imports System.Web
Imports Platform.eWorkFlow.Core.DAL


''' <summary>
''' 配置項功能類及常用方法
''' </summary>
''' <remarks></remarks>
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
    Public Shared ReadOnly Property ConnectionStringAllcq() As String
        Get
            Return System.Configuration.ConfigurationManager.ConnectionStrings("DBConnStr" + CQ).ConnectionString
        End Get
    End Property
    Public Shared ReadOnly Property ConnectionStringWH() As String
        Get
            Return System.Configuration.ConfigurationManager.ConnectionStrings("DBConnStrWH").ConnectionString
        End Get
    End Property
    Public Shared ReadOnly Property ConnectionStringCD() As String
        Get
            Return System.Configuration.ConfigurationManager.ConnectionStrings("DBConnStrCD").ConnectionString
        End Get
    End Property
    Public Shared ReadOnly Property ConnectionStringCQ() As String
        Get
            Return System.Configuration.ConfigurationManager.ConnectionStrings("DBConnStrCQ").ConnectionString
        End Get
    End Property
    Public Shared ReadOnly Property ConnectionStringYT() As String
        Get
            Return System.Configuration.ConfigurationManager.ConnectionStrings("DBConnStrYT").ConnectionString
        End Get
    End Property
    Public Shared ReadOnly Property ConnectionStringWSJ() As String
        Get
            Return System.Configuration.ConfigurationManager.ConnectionStrings("DBConnStrWSJ").ConnectionString
        End Get
    End Property
    Public Shared ReadOnly Property ConnectionStringZZ() As String
        Get
            Return System.Configuration.ConfigurationManager.ConnectionStrings("DBConnStrZZ").ConnectionString
        End Get
    End Property
    Public Shared ReadOnly Property ConnectionStringNN() As String
        Get
            Return System.Configuration.ConfigurationManager.ConnectionStrings("DBConnStrNN").ConnectionString
        End Get
    End Property

    Public Shared ReadOnly Property ConnectionStringlhflownet() As String
        Get
            Return System.Configuration.ConfigurationManager.ConnectionStrings("DBConnStrlhflownet").ConnectionString
        End Get
    End Property
    Public Shared ReadOnly Property ConnectionStringWHflownet() As String
        Get
            Return System.Configuration.ConfigurationManager.ConnectionStrings("DBConnStrWHflownet").ConnectionString
        End Get
    End Property
    Public Shared ReadOnly Property ConnectionStringCDflownet() As String
        Get
            Return System.Configuration.ConfigurationManager.ConnectionStrings("DBConnStrCDflownet").ConnectionString
        End Get
    End Property
    Public Shared ReadOnly Property ConnectionStringCQflownet() As String
        Get
            Return System.Configuration.ConfigurationManager.ConnectionStrings("DBConnStrCQflownet").ConnectionString
        End Get
    End Property
    Public Shared ReadOnly Property ConnectionStringYTflownet() As String
        Get
            Return System.Configuration.ConfigurationManager.ConnectionStrings("DBConnStrYTflownet").ConnectionString
        End Get
    End Property
    Public Shared ReadOnly Property ConnectionStringWSJflownet() As String
        Get
            Return System.Configuration.ConfigurationManager.ConnectionStrings("DBConnStrWSJflownet").ConnectionString
        End Get
    End Property
    Public Shared ReadOnly Property ConnectionStringZZflownet() As String
        Get
            Return System.Configuration.ConfigurationManager.ConnectionStrings("DBConnStrZZflownet").ConnectionString
        End Get
    End Property

    ''' <summary>
    ''' 取得配置項的值
    ''' </summary>
    ''' <param name="ConfigName">配置項名稱</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function GetConfigValue(ByVal ConfigName As String) As String
        Return System.Configuration.ConfigurationManager.AppSettings(ConfigName).ToString
    End Function

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
    ''' 取得專案URL目錄地址
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared ReadOnly Property UrlBase()
        Get
            Return String.Format("http://{0}{1}", HttpContext.Current.Request.Url.Authority, HttpContext.Current.Request.ApplicationPath)
        End Get
    End Property

    Public Shared ReadOnly Property UrlHost()
        Get
            Return String.Format("http://{0}", HttpContext.Current.Request.Url.Authority)
        End Get
    End Property

    Public Shared ReadOnly Property LblPKID() As Integer
        Get
            Return CInt(ConfigurationManager.AppSettings("LblPKID"))
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
    ''' 自定分頁默認記錄數
    ''' </summary>
    Public Shared ReadOnly Property PageSize() As String
        Get
            Return ConfigurationManager.AppSettings("CustomPageSize")
        End Get
    End Property




    ''' <summary>
    ''' 取得遠端訪問用戶的IP地址
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared ReadOnly Property RemoteUserIP() As String
        Get
            Dim str As String = ""
            If System.Web.HttpContext.Current.Request.ServerVariables("HTTP_VIA") IsNot Nothing Then
                str = System.Web.HttpContext.Current.Request.ServerVariables("HTTP_X_FORWARDED_FOR").ToString
            Else
                str = System.Web.HttpContext.Current.Request.ServerVariables("REMOTE_ADDR").ToString
            End If
            Return str
        End Get
    End Property

    ''' <summary>
    ''' 獲取指流程名稱，版本的流程狀態
    ''' </summary>
    ''' <param name="TemplateName">ConfigurationManager.AppSettings("TemplateName")</param>
    ''' <param name="TemplateVersion">ConfigurationManager.AppSettings("TemplateVersion")</param>
    ''' <returns></returns>
    ''' <remarks>
    ''' 不同流程可以在配置檔中進行配置
    ''' </remarks>
    Public Shared Function GetStateListByNameAndVersion(ByVal TemplateName As String, ByVal TemplateVersion As Integer) As List(Of DictionaryEntry)
        Dim mCollection As List(Of DictionaryEntry) = TemplateStateDAL.LoadTemplateStateByTemplateName(TemplateName, TemplateVersion)
        Return mCollection
    End Function

    Public Shared Function IsContains(ByVal List As String(), ByVal Element As String) As Boolean
        Dim i As Integer
        For i = 0 To List.Length - 1
            If List(i) = Element Then
                Return True
            End If
        Next
        Return False
    End Function '判斷指定的字串元素是否在指定的字串數組中




    Public Shared Function GetXmlToDataTable(ByVal mConfigFileName As String) As List(Of XmlData)

        Dim doc As XmlDocument = New XmlDocument()
        Dim XmlFilePath As String = HttpContext.Current.Server.MapPath("")
        doc.Load(XmlFilePath + "/ConfigurationFiles/" + mConfigFileName)
        Dim xlist As XmlNodeList = doc.SelectNodes("root//paramInfo")
        Dim mList As New List(Of XmlData)
        For i As Integer = 0 To xlist.Count - 1
            Dim xe As XmlElement = CType(xlist.Item(i), XmlElement)
            Dim mXmlData As XmlData = New XmlData()
            mXmlData.CName = xe.Attributes("CName").Value
            mXmlData.EName = xe.Attributes("EName").Value
            mXmlData.ImageUrl = xe.Attributes("ImageUrl").Value
            mList.Add(mXmlData)
        Next
        Return mList
    End Function
    Public Shared Function GetXmlToList(ByVal mConfigFileName As String) As List(Of String)

        Dim doc As XmlDocument = New XmlDocument()
        Dim XmlFilePath As String = HttpContext.Current.Server.MapPath("../")
        doc.Load(XmlFilePath + "/ConfigurationFiles/" + mConfigFileName)
        Dim xlist As XmlNodeList = doc.SelectNodes("root//paramInfo")
        Dim mList As New List(Of String)
        For i As Integer = 0 To xlist.Count - 1
            Dim xe As XmlElement = CType(xlist.Item(i), XmlElement)
            Dim mCategory As String = xe.Attributes("Key").Value

            mList.Add(mCategory)
        Next
        Return mList
    End Function


    Public Shared Function GetXmlToDE(ByVal mConfigFileName As String) As List(Of DictionaryEntry)

        Dim doc As XmlDocument = New XmlDocument()
        Dim XmlFilePath As String = HttpContext.Current.Server.MapPath("")
        Dim path As String = HttpContext.Current.Server.MapPath("../")
        doc.Load(path + "/ConfigurationFiles/" + mConfigFileName)
        Dim xlist As XmlNodeList = doc.SelectNodes("root//paramInfo")
        Dim mList As New List(Of DictionaryEntry)
        For i As Integer = 0 To xlist.Count - 1
            Dim xe As XmlElement = CType(xlist.Item(i), XmlElement)
            mList.Add(New DictionaryEntry(xe.Attributes(0).Value, xe.Attributes(1).Value))
        Next
        Return mList
    End Function

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

    Public Shared Function GetMailInfo(ByVal XMLPath As String, ByVal Template As String, ByVal State As String, ByVal Optionstr As String) As List(Of DictionaryEntry)
        Dim Result As New List(Of DictionaryEntry)
        Dim reader As XmlTextReader = Nothing
        Try
            reader = New XmlTextReader(XMLPath)
            While reader.Read


                If reader.Name = "SubMenuItem" Then

                    If reader.Item("key") = Optionstr And reader.Item("value") = Template And reader.Item("name") = State Then
                        Dim address As String = reader.Item("Address").ToString
                        Dim title As String = reader.Item("Title").ToString
                        Result.Add(New DictionaryEntry(address, title))
                    End If

                End If

                '元素結束結點的處理
                If reader.NodeType = XmlNodeType.EndElement Then
                    '處理MenuItem的結束結點 

                End If
            End While

        Catch e As XmlException
        Catch ex As Exception
        Finally
            If Not reader Is Nothing Then
                reader.Close()
            End If
        End Try
        Return Result
    End Function

    Public Shared Function GetXMLPath(ByVal LabPKID As String) As String
        Dim path As String = ""
        Try
            Select Case Convert.ToInt32(LabPKID)
                '應用系統整合實驗室
                Case 4
                    path = ""


                    '可靠度實驗室
                Case 15
                    path = "/MailAddress/CredibilitySendMailAddress.xml"


                    '金屬實驗室
                Case 16
                    path = "/MailAddress/MetalSendMailAddress.xml"


                    '塑發實驗室
                Case 18
                    path = ""


                    'SMT實驗室
                Case 20
                    path = ""


                    '校正實驗室
                Case 21
                    path = ""


                    'HALT實驗室
                Case 22
                    path = ""


                    '元素成份分析實驗室
                Case 23
                    'path = "D:\Project\TestApplyManage\TestApplyManage\MailAddress\RohsSendMailAddress.xml"
                    path = "/MailAddress/RohsSendMailAddress.xml"


                    '噪音實驗室
                Case 25
                    path = ""


                    '移動產品驗證
                Case 27
                    path = ""


                    'CAE仿真實驗室
                Case 28
                    path = ""


                    '尺寸量測實驗室
                Case 29
                    path = ""


                    '3D工程及驗証實驗室
                Case 30
                    path = ""

            End Select
        Catch ex As Exception

        End Try
        Return path
    End Function

    Public Shared Role_Admin As String = "SYS_ADMINISTRATOR" '管理員
    Public Shared Role_Purchases As String = "Test_Purchases" '經管，品保
    Public Shared Role_Scheme As String = "TestScheme" '實驗室排配角色
    Public Shared Role_Record As String = "TestRecord" '實驗室測試角色
    Public Shared Role_CreateReport As String = " TestCreateReport" '上傳報告
    Public Shared Role_aduitreport As String = "testaduitreport" '報告核準
    Public Shared Role_ApproveReport As String = " TestApproveReport" '報告審核
    Public Shared Group_LblInfo As String = "LabGroup" '實驗室群組
    Public Shared CQ As String = "LH"

End Class
