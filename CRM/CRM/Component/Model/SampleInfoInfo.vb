#Region "導入命名空間"
Imports System
Imports System.Xml
Imports System.Xml.Serialization
Imports System.Runtime.Serialization
#End Region

''' <summary>實例類</summary>
''' <remarks></remarks>
<Serializable()> _
Partial Public Class SampleInfoInfo
#Region " Private Fields "
		private  m_iPKID as Integer
		private  m_iQuotationPKID as Integer
		private  m_strSampleName as string
		private  m_iIsNeedBack as Integer
		private  m_iNumbers as Integer
		private  m_strExtend01 as string
		private  m_strExtend02 as string
		private  m_strExtend03 as string
		private  m_strExtend04 as string
		private  m_strExtend05 as string
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
		''' 對應報價單PKID
		''' </summary>
		public Property QuotationPKID as Integer 
		Get
			return m_iQuotationPKID 
		End Get
		Set(ByVal Value As Integer)
			 m_iQuotationPKID = value
		End Set
		End Property
		''' <summary>
		''' 樣品名
		''' </summary>
		public Property SampleName as string 
		Get
			 return m_strSampleName 
		End Get
		Set(ByVal Value As string)
			 m_strSampleName = value
		End Set
		End Property
		''' <summary>
		''' 樣品是否取回
		''' </summary>
		public Property IsNeedBack as Integer 
		Get
			return m_iIsNeedBack 
		End Get
		Set(ByVal Value As Integer)
			 m_iIsNeedBack = value
		End Set
		End Property
		''' <summary>
		''' 數量
		''' </summary>
		public Property Numbers as Integer 
		Get
			return m_iNumbers 
		End Get
		Set(ByVal Value As Integer)
			 m_iNumbers = value
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

