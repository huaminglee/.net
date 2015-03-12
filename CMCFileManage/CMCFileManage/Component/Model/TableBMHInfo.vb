#Region "導入命名空間"
Imports System
Imports System.Xml
Imports System.Xml.Serialization
Imports System.Runtime.Serialization
#End Region

''' <summary>實例類</summary>
''' <remarks></remarks>
<Serializable()> _
Partial Public Class TableBMHInfo
#Region " Private Fields "
		private  m_iPKID as Integer
		private  m_strCategory as string
		private  m_strYMD as string
		private  m_iBMH as Integer
		private  m_iRecordPKID as Integer

#End Region

#Region " Public Properties"
		''' <summary>
		''' 單號PKID
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
		''' 編號類別
		''' </summary>
		public Property Category as string 
		Get
			 return m_strCategory 
		End Get
		Set(ByVal Value As string)
			 m_strCategory = value
		End Set
		End Property
		''' <summary>
		''' 年月日
		''' </summary>
		public Property YMD as string 
		Get
			 return m_strYMD 
		End Get
		Set(ByVal Value As string)
			 m_strYMD = value
		End Set
		End Property
		''' <summary>
		''' 
		''' </summary>
		public Property BMH as Integer 
		Get
			return m_iBMH 
		End Get
		Set(ByVal Value As Integer)
			 m_iBMH = value
		End Set
		End Property
		''' <summary>
		''' 
		''' </summary>
		public Property RecordPKID as Integer 
		Get
			return m_iRecordPKID 
		End Get
		Set(ByVal Value As Integer)
			 m_iRecordPKID = value
		End Set
		End Property

#End Region
End Class

