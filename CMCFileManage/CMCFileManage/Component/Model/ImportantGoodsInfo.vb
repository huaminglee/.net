#Region "導入命名空間"
Imports System
Imports System.Xml
Imports System.Xml.Serialization
Imports System.Runtime.Serialization
#End Region

''' <summary>實例類</summary>
''' <remarks></remarks>
<Serializable()> _
Partial Public Class ImportantGoodsInfo
#Region " Private Fields "
		private  m_iPKID as Integer
		private  m_strLabName as string
		private  m_strGoodsName as string
		private  m_strStandars as string
		private  m_strBrands as string
		private  m_strSupplier as string
		private  m_strTecRequir as string
		private  m_strQulocation as string
		private  m_strRemark as string
		private  m_strExtend1 as string
		private  m_strExtend2 as string
		private  m_strExtend3 as string
		private  m_strExtend4 as string
		private  m_strExtend5 as string
		private  m_strExtend6 as string
		private  m_strExtend7 as string
		private  m_strExtend8 as string
		private  m_strExtend9 as string
		private  m_strExtend10 as string
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
		public Property LabName as string 
		Get
			 return m_strLabName 
		End Get
		Set(ByVal Value As string)
			 m_strLabName = value
		End Set
		End Property
		''' <summary>
		''' 
		''' </summary>
		public Property GoodsName as string 
		Get
			 return m_strGoodsName 
		End Get
		Set(ByVal Value As string)
			 m_strGoodsName = value
		End Set
		End Property
		''' <summary>
		''' 
		''' </summary>
		public Property Standars as string 
		Get
			 return m_strStandars 
		End Get
		Set(ByVal Value As string)
			 m_strStandars = value
		End Set
		End Property
		''' <summary>
		''' 
		''' </summary>
		public Property Brands as string 
		Get
			 return m_strBrands 
		End Get
		Set(ByVal Value As string)
			 m_strBrands = value
		End Set
		End Property
		''' <summary>
		''' 
		''' </summary>
		public Property Supplier as string 
		Get
			 return m_strSupplier 
		End Get
		Set(ByVal Value As string)
			 m_strSupplier = value
		End Set
		End Property
		''' <summary>
		''' 
		''' </summary>
		public Property TecRequir as string 
		Get
			 return m_strTecRequir 
		End Get
		Set(ByVal Value As string)
			 m_strTecRequir = value
		End Set
		End Property
		''' <summary>
		''' 
		''' </summary>
		public Property Qulocation as string 
		Get
			 return m_strQulocation 
		End Get
		Set(ByVal Value As string)
			 m_strQulocation = value
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
		''' 預留欄位1
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
		''' 預留欄位3
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
		''' 預留欄位6
		''' </summary>
		public Property Extend6 as string 
		Get
			 return m_strExtend6 
		End Get
		Set(ByVal Value As string)
			 m_strExtend6 = value
		End Set
		End Property
		''' <summary>
		''' 預留欄位7
		''' </summary>
		public Property Extend7 as string 
		Get
			 return m_strExtend7 
		End Get
		Set(ByVal Value As string)
			 m_strExtend7 = value
		End Set
		End Property
		''' <summary>
		''' 預留欄位
		''' </summary>
		public Property Extend8 as string 
		Get
			 return m_strExtend8 
		End Get
		Set(ByVal Value As string)
			 m_strExtend8 = value
		End Set
		End Property
		''' <summary>
		''' 預留欄位
		''' </summary>
		public Property Extend9 as string 
		Get
			 return m_strExtend9 
		End Get
		Set(ByVal Value As string)
			 m_strExtend9 = value
		End Set
		End Property
		''' <summary>
		''' 預留欄位10存原紀錄pkid
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
		''' 記錄創建時間
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
		''' 記錄刪除標記0正常；1刪除
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

