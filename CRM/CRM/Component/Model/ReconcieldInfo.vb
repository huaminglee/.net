#Region "導入命名空間"
Imports System
Imports System.Xml
Imports System.Xml.Serialization
Imports System.Runtime.Serialization
#End Region

''' <summary>實例類</summary>
''' <remarks></remarks>
<Serializable()> _
Partial Public Class ReconcieldInfo
#Region " Private Fields "
		private  m_iPKID as Integer
		private  m_iReconcieldMonth as Integer
		private  m_strReconPersonID as string
		private  m_dtReconDate as DateTime
		private  m_iCustomerPKID as Integer
		private  m_strCustomerName as string
		private  m_strFileClientName as string
		private  m_strFileRealName as string
		private  m_strExtend01 as string
		private  m_strExtend02 as string
		private  m_strExtend03 as string
		private  m_strExtend04 as string
		private  m_strExtend05 as string
		private  m_strExtend06 as string
		private  m_strExtend07 as string
		private  m_strExtend08 as string
		private  m_strExtend09 as string
		private  m_strExtend10 as string
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
		''' 對賬月份
		''' </summary>
		public Property ReconcieldMonth as Integer 
		Get
			return m_iReconcieldMonth 
		End Get
		Set(ByVal Value As Integer)
			 m_iReconcieldMonth = value
		End Set
		End Property
		''' <summary>
		''' 對賬人ID
		''' </summary>
		public Property ReconPersonID as string 
		Get
			 return m_strReconPersonID 
		End Get
		Set(ByVal Value As string)
			 m_strReconPersonID = value
		End Set
		End Property
		''' <summary>
		''' 對賬日期
		''' </summary>
		public Property ReconDate as DateTime 
		Get
			return m_dtReconDate 
		End Get
		Set(ByVal Value As DateTime)
			 m_dtReconDate = value
		End Set
		End Property
		''' <summary>
		''' 客戶PKID
		''' </summary>
		public Property CustomerPKID as Integer 
		Get
			return m_iCustomerPKID 
		End Get
		Set(ByVal Value As Integer)
			 m_iCustomerPKID = value
		End Set
		End Property
		''' <summary>
		''' 客戶名
		''' </summary>
		public Property CustomerName as string 
		Get
			 return m_strCustomerName 
		End Get
		Set(ByVal Value As string)
			 m_strCustomerName = value
		End Set
		End Property
		''' <summary>
		''' 回傳對帳單唯一名
		''' </summary>
		public Property FileClientName as string 
		Get
			 return m_strFileClientName 
		End Get
		Set(ByVal Value As string)
			 m_strFileClientName = value
		End Set
		End Property
		''' <summary>
		''' 回傳對帳單real
		''' </summary>
		public Property FileRealName as string 
		Get
			 return m_strFileRealName 
		End Get
		Set(ByVal Value As string)
			 m_strFileRealName = value
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
		''' 
		''' </summary>
		public Property Extend06 as string 
		Get
			 return m_strExtend06 
		End Get
		Set(ByVal Value As string)
			 m_strExtend06 = value
		End Set
		End Property
		''' <summary>
		''' 
		''' </summary>
		public Property Extend07 as string 
		Get
			 return m_strExtend07 
		End Get
		Set(ByVal Value As string)
			 m_strExtend07 = value
		End Set
		End Property
		''' <summary>
		''' 
		''' </summary>
		public Property Extend08 as string 
		Get
			 return m_strExtend08 
		End Get
		Set(ByVal Value As string)
			 m_strExtend08 = value
		End Set
		End Property
		''' <summary>
		''' 
		''' </summary>
		public Property Extend09 as string 
		Get
			 return m_strExtend09 
		End Get
		Set(ByVal Value As string)
			 m_strExtend09 = value
		End Set
		End Property
		''' <summary>
		''' 
		''' </summary>
		public Property Extend10 as string 
		Get
			 return m_strExtend10 
		End Get
		Set(ByVal Value As string)
			 m_strExtend10 = value
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

