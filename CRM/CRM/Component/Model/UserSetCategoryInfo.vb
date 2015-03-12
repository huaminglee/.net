#Region "導入命名空間"
Imports System
Imports System.Xml
Imports System.Xml.Serialization
Imports System.Runtime.Serialization
#End Region

''' <summary>實例類</summary>
''' <remarks></remarks>
<Serializable()> _
Partial Public Class UserSetCategoryInfo
#Region " Private Fields "
		private  m_iPKID as Integer
		private  m_strCategoryName as string
		private  m_iStateOrder as Integer
		private  m_iType as Integer
		private  m_iNextStateOrder as Integer

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
		''' 狀態名
		''' </summary>
		public Property CategoryName as string 
		Get
			 return m_strCategoryName 
		End Get
		Set(ByVal Value As string)
			 m_strCategoryName = value
		End Set
		End Property
		''' <summary>
		''' 狀態序號
		''' </summary>
		public Property StateOrder as Integer 
		Get
			return m_iStateOrder 
		End Get
		Set(ByVal Value As Integer)
			 m_iStateOrder = value
		End Set
		End Property
		''' <summary>
		''' 類別1聯繫人狀態2潛在客戶狀態3業務機會狀態
		''' </summary>
		public Property Type as Integer 
		Get
			return m_iType 
		End Get
		Set(ByVal Value As Integer)
			 m_iType = value
		End Set
		End Property
		''' <summary>
		''' 下一站序號
		''' </summary>
		public Property NextStateOrder as Integer 
		Get
			return m_iNextStateOrder 
		End Get
		Set(ByVal Value As Integer)
			 m_iNextStateOrder = value
		End Set
		End Property

#End Region
End Class

