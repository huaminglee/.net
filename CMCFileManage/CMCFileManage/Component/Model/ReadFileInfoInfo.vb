#Region "導入命名空間"
Imports System
Imports System.Xml
Imports System.Xml.Serialization
Imports System.Runtime.Serialization
#End Region

''' <summary>實例類</summary>
''' <remarks></remarks>
<Serializable()> _
Partial Public Class ReadFileInfoInfo
#Region " Private Fields "
		private  m_ipkid as Integer
		private  m_iparentid as Integer
		private  m_strFileBH as string
		private  m_strFileName as string
		private  m_strReadType as string
		private  m_strReadFor as string
		private  m_strExtend1 as string
		private  m_strExtend2 as string
		private  m_strExtend3 as string
		private  m_strExtend4 as string
		private  m_strExtend5 as string
    Private m_dtRecordCreated As DateTime = DateTime.MaxValue
		private  m_iRecordDeleted as Integer

#End Region

#Region " Public Properties"
		''' <summary>
		''' 
		''' </summary>
		public Property pkid as Integer 
		Get
			return m_ipkid 
		End Get
		Set(ByVal Value As Integer)
			 m_ipkid = value
		End Set
		End Property
		''' <summary>
		''' 文件調閱表主鍵
		''' </summary>
		public Property parentid as Integer 
		Get
			return m_iparentid 
		End Get
		Set(ByVal Value As Integer)
			 m_iparentid = value
		End Set
		End Property
		''' <summary>
		''' 
		''' </summary>
		public Property FileBH as string 
		Get
			 return m_strFileBH 
		End Get
		Set(ByVal Value As string)
			 m_strFileBH = value
		End Set
		End Property
		''' <summary>
		''' 
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
		''' 調閱方式
		''' </summary>
		public Property ReadType as string 
		Get
			 return m_strReadType 
		End Get
		Set(ByVal Value As string)
			 m_strReadType = value
		End Set
		End Property
		''' <summary>
		''' 用途說明
		''' </summary>
		public Property ReadFor as string 
		Get
			 return m_strReadFor 
		End Get
		Set(ByVal Value As string)
			 m_strReadFor = value
		End Set
		End Property
		''' <summary>
    '''份數
		''' </summary>
		public Property Extend1 as string 
		Get
			 return m_strExtend1 
		End Get
		Set(ByVal Value As string)
			 m_strExtend1 = value
		End Set
		End Property
		''' <summary>
    ''' 說明
		''' </summary>
		public Property Extend2 as string 
		Get
			 return m_strExtend2 
		End Get
		Set(ByVal Value As string)
			 m_strExtend2 = value
		End Set
		End Property
		''' <summary>
		''' 
		''' </summary>
		public Property Extend3 as string 
		Get
			 return m_strExtend3 
		End Get
		Set(ByVal Value As string)
			 m_strExtend3 = value
		End Set
		End Property
		''' <summary>
		''' 
		''' </summary>
		public Property Extend4 as string 
		Get
			 return m_strExtend4 
		End Get
		Set(ByVal Value As string)
			 m_strExtend4 = value
		End Set
		End Property
		''' <summary>
		''' 
		''' </summary>
		public Property Extend5 as string 
		Get
			 return m_strExtend5 
		End Get
		Set(ByVal Value As string)
			 m_strExtend5 = value
		End Set
		End Property
		''' <summary>
		''' 
		''' </summary>
		public Property RecordCreated as DateTime 
		Get
			return m_dtRecordCreated 
		End Get
		Set(ByVal Value As DateTime)
			 m_dtRecordCreated = value
		End Set
		End Property
		''' <summary>
		''' 
		''' </summary>
		public Property RecordDeleted as Integer 
		Get
			return m_iRecordDeleted 
		End Get
		Set(ByVal Value As Integer)
			 m_iRecordDeleted = value
		End Set
		End Property

#End Region
End Class

