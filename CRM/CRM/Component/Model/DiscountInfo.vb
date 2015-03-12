#Region "導入命名空間"
Imports System
Imports System.Xml
Imports System.Xml.Serialization
Imports System.Runtime.Serialization
#End Region

''' <summary>實例類</summary>
''' <remarks></remarks>
<Serializable()> _
Partial Public Class DiscountInfo
#Region " Private Fields "
		private  m_iPKID as Integer
		private  m_strRoleName as string
		private  m_strOne as string
		private  m_strTwo as string
		private  m_strThree as string
		private  m_strFour as string
		private  m_strFive as string
		private  m_strExtend1 as string
		private  m_strExtend2 as string
		private  m_strExtend3 as string
		private  m_strExtend4 as string
		private  m_strExtend5 as string
		private  m_dtRecordCreated as DateTime
		private  m_iRecordDeleted as Integer

#End Region

#Region " Public Properties"
		''' <summary>
		''' 
		''' </summary>
		public Property PKID as Integer 
		Get
			return m_iPKID 
		End Get
		Set(ByVal Value As Integer)
			 m_iPKID = value
		End Set
		End Property
		''' <summary>
		''' 
		''' </summary>
		public Property RoleName as string 
		Get
			 return m_strRoleName 
		End Get
		Set(ByVal Value As string)
			 m_strRoleName = value
		End Set
		End Property
		''' <summary>
		''' 
		''' </summary>
		public Property One as string 
		Get
			 return m_strOne 
		End Get
		Set(ByVal Value As string)
			 m_strOne = value
		End Set
		End Property
		''' <summary>
		''' 
		''' </summary>
		public Property Two as string 
		Get
			 return m_strTwo 
		End Get
		Set(ByVal Value As string)
			 m_strTwo = value
		End Set
		End Property
		''' <summary>
		''' 
		''' </summary>
		public Property Three as string 
		Get
			 return m_strThree 
		End Get
		Set(ByVal Value As string)
			 m_strThree = value
		End Set
		End Property
		''' <summary>
		''' 
		''' </summary>
		public Property Four as string 
		Get
			 return m_strFour 
		End Get
		Set(ByVal Value As string)
			 m_strFour = value
		End Set
		End Property
		''' <summary>
		''' 
		''' </summary>
		public Property Five as string 
		Get
			 return m_strFive 
		End Get
		Set(ByVal Value As string)
			 m_strFive = value
		End Set
		End Property
		''' <summary>
		''' 電話
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
		''' 郵箱
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
		''' 已佔用,存標籤大小
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
		''' 預留欄位4
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
		''' 預留欄位5
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
		''' 記錄創時間
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
		''' 記錄刪除標誌
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

