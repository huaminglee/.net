#Region "導入命名空間"
Imports System
Imports System.Xml
Imports System.Xml.Serialization
Imports System.Runtime.Serialization
#End Region

''' <summary>實例類</summary>
''' <remarks></remarks>
<Serializable()> _
Partial Public Class WF_AttachFileInfoInfo
#Region " Private Fields "
		private  m_iFileID as Integer
		private  m_iParentID as Integer
		private  m_iParentCategory as Integer
		private  m_iParentSubCategory as Integer
		private  m_decFileGuID as Guid
		private  m_strFileName as string
		private  m_strFileExtension as string
		private  m_iFileSize as Integer
    Private m_strFileClientName As String
    Private m_strFileContent() As Byte
    Private m_strExtend1 As String = String.Empty
    Private m_strExtend2 As String = String.Empty
    Private m_strExtend3 As String = String.Empty
    Private m_strExtend4 As String = String.Empty
    Private m_strExtend5 As String = String.Empty
    Private m_strRecordVersion As String = "1.0"
    Private m_dtRecordCreateTime As DateTime = DateTime.Now
    Private m_iRecordDeleted As Integer = 0

#End Region

#Region " Public Properties"
		''' <summary>
		''' 附件PKID
		''' </summary>
		public Property FileID as Integer 
		Get
			return m_iFileID 
		End Get
		Set(ByVal Value As Integer)
			 m_iFileID = value
		End Set
		End Property
		''' <summary>
		''' 附件主表PKID
		''' </summary>
		public Property ParentID as Integer 
		Get
			return m_iParentID 
		End Get
		Set(ByVal Value As Integer)
			 m_iParentID = value
		End Set
		End Property
		''' <summary>
		''' 附件類別(不同模組附件的區分)
		''' </summary>
		public Property ParentCategory as Integer 
		Get
			return m_iParentCategory 
		End Get
		Set(ByVal Value As Integer)
			 m_iParentCategory = value
		End Set
		End Property
		''' <summary>
		''' 附件子類別(同一模組不同類別附件的區分)
		''' </summary>
		public Property ParentSubCategory as Integer 
		Get
			return m_iParentSubCategory 
		End Get
		Set(ByVal Value As Integer)
			 m_iParentSubCategory = value
		End Set
		End Property
		''' <summary>
		''' 附件GuID
		''' </summary>
		public Property FileGuID as Guid 
		Get
			return m_decFileGuID 
		End Get
		Set(ByVal Value As Guid)
			 m_decFileGuID = value
		End Set
		End Property
		''' <summary>
		''' 附件名稱
		''' </summary>
		public Property FileName as string 
		Get
			 return m_strFileName 
		End Get
		Set(ByVal Value As string)
			 m_strFileName = value
		End Set
		End Property
		''' <summary>
		''' 附件類型
		''' </summary>
		public Property FileExtension as string 
		Get
			 return m_strFileExtension 
		End Get
		Set(ByVal Value As string)
			 m_strFileExtension = value
		End Set
		End Property
		''' <summary>
		''' 附件大小
		''' </summary>
		public Property FileSize as Integer 
		Get
			return m_iFileSize 
		End Get
		Set(ByVal Value As Integer)
			 m_iFileSize = value
		End Set
    End Property
    Public Property FileContent() As Byte()
        Get
            Return m_strFileContent
        End Get
        Set(ByVal Value As Byte())
            m_strFileContent = Value
        End Set
    End Property
    ''' <summary>
    ''' 附件客戶端名稱
    ''' </summary>
    Public Property FileClientName() As String
        Get
            Return m_strFileClientName
        End Get
        Set(ByVal Value As String)
            m_strFileClientName = Value
        End Set
    End Property
    ''' <summary>
    ''' 擴展欄位1
    ''' </summary>
    Public Property Extend1() As String
        Get
            Return m_strExtend1
        End Get
        Set(ByVal Value As String)
            m_strExtend1 = Value
        End Set
    End Property
    ''' <summary>
    ''' 擴展欄位2
    ''' </summary>
    Public Property Extend2() As String
        Get
            Return m_strExtend2
        End Get
        Set(ByVal Value As String)
            m_strExtend2 = Value
        End Set
    End Property
    ''' <summary>
    ''' 擴展欄位3
    ''' </summary>
    Public Property Extend3() As String
        Get
            Return m_strExtend3
        End Get
        Set(ByVal Value As String)
            m_strExtend3 = Value
        End Set
    End Property
    ''' <summary>
    ''' 擴展欄位4
    ''' </summary>
    Public Property Extend4() As String
        Get
            Return m_strExtend4
        End Get
        Set(ByVal Value As String)
            m_strExtend4 = Value
        End Set
    End Property
    ''' <summary>
    ''' 擴展欄位5
    ''' </summary>
    Public Property Extend5() As String
        Get
            Return m_strExtend5
        End Get
        Set(ByVal Value As String)
            m_strExtend5 = Value
        End Set
    End Property
    ''' <summary>
    ''' 記錄版本
    ''' </summary>
    Public Property RecordVersion() As String
        Get
            Return m_strRecordVersion
        End Get
        Set(ByVal Value As String)
            m_strRecordVersion = Value
        End Set
    End Property
    ''' <summary>
    ''' 記錄創建時間
    ''' </summary>
    Public Property RecordCreateTime() As DateTime
        Get
            Return m_dtRecordCreateTime
        End Get
        Set(ByVal Value As DateTime)
            m_dtRecordCreateTime = Value
        End Set
    End Property
    ''' <summary>
    ''' 記錄刪除標記(0:未刪除,1:已刪除)
    ''' </summary>
    Public Property RecordDeleted() As Integer
        Get
            Return m_iRecordDeleted
        End Get
        Set(ByVal Value As Integer)
            m_iRecordDeleted = Value
        End Set
    End Property

#End Region
End Class

