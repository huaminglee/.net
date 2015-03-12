#Region "導入命名空間"
Imports System
Imports System.Xml
Imports System.Xml.Serialization
Imports System.Runtime.Serialization
#End Region

''' <summary>實例類</summary>
''' <remarks></remarks>
<Serializable()> _
Partial Public Class SignRecordInfo
#Region " Private Fields "
		private  m_ipkid as Integer
		private  m_strRecordNo as string
		private  m_strSinger as string
		private  m_dtSignTime as DateTime
		private  m_strSignremark as string
		private  m_stractivity as string
		private  m_strExtend1 as string
		private  m_strExtend2 as string
		private  m_strExtend3 as string

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
		''' 
		''' </summary>
		public Property RecordNo as string 
		Get
			 return m_strRecordNo 
		End Get
		Set(ByVal Value As string)
			 m_strRecordNo = value
		End Set
		End Property
		''' <summary>
		''' 
		''' </summary>
		public Property Singer as string 
		Get
			 return m_strSinger 
		End Get
		Set(ByVal Value As string)
			 m_strSinger = value
		End Set
		End Property
		''' <summary>
		''' 
		''' </summary>
		public Property SignTime as DateTime 
		Get
			return m_dtSignTime 
		End Get
		Set(ByVal Value As DateTime)
			 m_dtSignTime = value
		End Set
		End Property
		''' <summary>
		''' 
		''' </summary>
		public Property Signremark as string 
		Get
			 return m_strSignremark 
		End Get
		Set(ByVal Value As string)
			 m_strSignremark = value
		End Set
		End Property
		''' <summary>
		''' 
		''' </summary>
		public Property activity as string 
		Get
			 return m_stractivity 
		End Get
		Set(ByVal Value As string)
			 m_stractivity = value
		End Set
		End Property
		''' <summary>
		''' 
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
		''' 
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

#End Region
End Class

