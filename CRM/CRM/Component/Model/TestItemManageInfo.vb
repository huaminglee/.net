#Region "導入命名空間"
Imports System
Imports System.Xml
Imports System.Xml.Serialization
Imports System.Runtime.Serialization
#End Region

''' <summary>實例類</summary>
''' <remarks></remarks>
<Serializable()> _
Partial Public Class TestItemManageInfo
#Region " Private Fields "
		private  m_iPKID as Integer
		private  m_iTestItemPKID as Integer
		private  m_iLbServicePKID as Integer
		private  m_strLbServiceName as string
		private  m_strTestItemName as string
		private  m_iCBbootfee as Integer
		private  m_iCBunitfee as Integer
		private  m_iDWPJbootfee as Integer
		private  m_iDWPJunitfee as Integer
		private  m_iDWDJbootfee as Integer
		private  m_iDWDJunitfee as Integer
		private  m_strExtend1 as string
		private  m_strExtend2 as string
		private  m_strExtend3 as string
		private  m_strExtend4 as string
		private  m_strExtend5 as string
		private  m_strExtend6 as string
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
		''' 測試項目PKID
		''' </summary>
		public Property TestItemPKID as Integer 
		Get
			return m_iTestItemPKID 
		End Get
		Set(ByVal Value As Integer)
			 m_iTestItemPKID = value
		End Set
		End Property
		''' <summary>
		''' 服務項目PKID
		''' </summary>
		public Property LbServicePKID as Integer 
		Get
			return m_iLbServicePKID 
		End Get
		Set(ByVal Value As Integer)
			 m_iLbServicePKID = value
		End Set
		End Property
		''' <summary>
		''' 服務項目名
		''' </summary>
		public Property LbServiceName as string 
		Get
			 return m_strLbServiceName 
		End Get
		Set(ByVal Value As string)
			 m_strLbServiceName = value
		End Set
		End Property
		''' <summary>
		''' 測試項目名
		''' </summary>
		public Property TestItemName as string 
		Get
			 return m_strTestItemName 
		End Get
		Set(ByVal Value As string)
			 m_strTestItemName = value
		End Set
		End Property
		''' <summary>
		''' 成本開幾價
		''' </summary>
		public Property CBbootfee as Integer 
		Get
			return m_iCBbootfee 
		End Get
		Set(ByVal Value As Integer)
			 m_iCBbootfee = value
		End Set
		End Property
		''' <summary>
		''' 成本單價
		''' </summary>
		public Property CBunitfee as Integer 
		Get
			return m_iCBunitfee 
		End Get
		Set(ByVal Value As Integer)
			 m_iCBunitfee = value
		End Set
		End Property
		''' <summary>
		''' 對往外牌價開機價
		''' </summary>
		public Property DWPJbootfee as Integer 
		Get
			return m_iDWPJbootfee 
		End Get
		Set(ByVal Value As Integer)
			 m_iDWPJbootfee = value
		End Set
		End Property
		''' <summary>
		''' 對外牌價單價
		''' </summary>
		public Property DWPJunitfee as Integer 
		Get
			return m_iDWPJunitfee 
		End Get
		Set(ByVal Value As Integer)
			 m_iDWPJunitfee = value
		End Set
		End Property
		''' <summary>
		''' 對外低價開機價
		''' </summary>
		public Property DWDJbootfee as Integer 
		Get
			return m_iDWDJbootfee 
		End Get
		Set(ByVal Value As Integer)
			 m_iDWDJbootfee = value
		End Set
		End Property
		''' <summary>
		''' 對外低價單價
		''' </summary>
		public Property DWDJunitfee as Integer 
		Get
			return m_iDWDJunitfee 
		End Get
		Set(ByVal Value As Integer)
			 m_iDWDJunitfee = value
		End Set
		End Property
		''' <summary>
    ''' 計價單位
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
		''' 
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

