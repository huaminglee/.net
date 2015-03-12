#Region "導入命名空間"
Imports System
Imports System.Xml
Imports System.Xml.Serialization
Imports System.Runtime.Serialization
#End Region

''' <summary>實例類</summary>
''' <remarks></remarks>
<Serializable()> _
Partial Public Class VisitsPersonInfo
#Region " Private Fields "
		private  m_iPKID as Integer
		private  m_iCustomerVisitsPKID as Integer
		private  m_strName as string
		private  m_strContact as string
		private  m_strPost as string
		private  m_strWorkContent as string
		private  m_strRemark as string
		private  m_strExtend01 as string
		private  m_strExtend02 as string
		private  m_strExtend03 as string
		private  m_strExtend04 as string
		private  m_strExtend05 as string

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
		public Property CustomerVisitsPKID as Integer 
		Get
			return m_iCustomerVisitsPKID 
		End Get
		Set(ByVal Value As Integer)
			 m_iCustomerVisitsPKID = value
		End Set
		End Property
		''' <summary>
		''' 
		''' </summary>
		public Property Name as string 
		Get
			 return m_strName 
		End Get
		Set(ByVal Value As string)
			 m_strName = value
		End Set
		End Property
		''' <summary>
		''' 
		''' </summary>
		public Property Contact as string 
		Get
			 return m_strContact 
		End Get
		Set(ByVal Value As string)
			 m_strContact = value
		End Set
		End Property
		''' <summary>
		''' 
		''' </summary>
		public Property Post as string 
		Get
			 return m_strPost 
		End Get
		Set(ByVal Value As string)
			 m_strPost = value
		End Set
		End Property
		''' <summary>
		''' 
		''' </summary>
		public Property WorkContent as string 
		Get
			 return m_strWorkContent 
		End Get
		Set(ByVal Value As string)
			 m_strWorkContent = value
		End Set
		End Property
		''' <summary>
		''' 
		''' </summary>
		public Property Remark as string 
		Get
			 return m_strRemark 
		End Get
		Set(ByVal Value As string)
			 m_strRemark = value
		End Set
		End Property
		''' <summary>
		''' 
		''' </summary>
		public Property Extend01 as string 
		Get
			 return m_strExtend01 
		End Get
		Set(ByVal Value As string)
			 m_strExtend01 = value
		End Set
		End Property
		''' <summary>
		''' 
		''' </summary>
		public Property Extend02 as string 
		Get
			 return m_strExtend02 
		End Get
		Set(ByVal Value As string)
			 m_strExtend02 = value
		End Set
		End Property
		''' <summary>
		''' 
		''' </summary>
		public Property Extend03 as string 
		Get
			 return m_strExtend03 
		End Get
		Set(ByVal Value As string)
			 m_strExtend03 = value
		End Set
		End Property
		''' <summary>
		''' 
		''' </summary>
		public Property Extend04 as string 
		Get
			 return m_strExtend04 
		End Get
		Set(ByVal Value As string)
			 m_strExtend04 = value
		End Set
		End Property
		''' <summary>
		''' 
		''' </summary>
		public Property Extend05 as string 
		Get
			 return m_strExtend05 
		End Get
		Set(ByVal Value As string)
			 m_strExtend05 = value
		End Set
		End Property

#End Region
End Class

