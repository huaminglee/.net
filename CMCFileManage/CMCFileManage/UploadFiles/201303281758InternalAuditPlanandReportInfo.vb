#Region "導入命名空間"
Imports System
Imports System.Xml
Imports System.Xml.Serialization
Imports System.Runtime.Serialization
#End Region

''' <summary>實例類</summary>
''' <remarks></remarks>
<Serializable()> _
Partial Public Class InternalAuditPlanandReportInfo
#Region " Private Fields "
		private  m_iPKID as Integer
		private  m_iRecordType as Integer
		private  m_strRecordNO as string
		private  m_dtFormulDate as DateTime
		private  m_strName as string
		private  m_strQulocation as string
		private  m_strFormulDept as string
		private  m_strFprmilUser as string
		private  m_strExtend1 as string
		private  m_strExtend2 as string
		private  m_strExtend3 as string
		private  m_strExtend4 as string
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
		''' 類別1為內審計劃2為內審報告
		''' </summary>
		public Property RecordType as Integer 
		Get
			return m_iRecordType 
		End Get
		Set(ByVal Value As Integer)
			 m_iRecordType = value
		End Set
		End Property
		''' <summary>
		''' 記錄編號
		''' </summary>
		public Property RecordNO as string 
		Get
			 return m_strRecordNO 
		End Get
		Set(ByVal Value As string)
			 m_strRecordNO = value
		End Set
		End Property
		''' <summary>
		''' 
		''' </summary>
		public Property FormulDate as DateTime 
		Get
			return m_dtFormulDate 
		End Get
		Set(ByVal Value As DateTime)
			 m_dtFormulDate = value
		End Set
		End Property
		''' <summary>
		''' 名稱
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
		''' 區域
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
		''' 制定單位
		''' </summary>
		public Property FormulDept as string 
		Get
			 return m_strFormulDept 
		End Get
		Set(ByVal Value As string)
			 m_strFormulDept = value
		End Set
		End Property
		''' <summary>
		''' 制定人
		''' </summary>
		public Property FprmilUser as string 
		Get
			 return m_strFprmilUser 
		End Get
		Set(ByVal Value As string)
			 m_strFprmilUser = value
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
		''' 記錄刪除標記
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

