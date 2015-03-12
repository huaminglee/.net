#Region "導入命名空間"
Imports System
Imports System.Xml
Imports System.Xml.Serialization
Imports System.Runtime.Serialization
#End Region

''' <summary>實例類</summary>
''' <remarks></remarks>
<Serializable()> _
Partial Public Class EquipManageInfo
#Region " Private Fields "
		private  m_iPKID as Integer
		private  m_deceFlowDocID as Guid
		private  m_iIsFinish as Integer
		private  m_iStateOrder as Integer
		private  m_strStateName as string
		private  m_strEquipName as string
		private  m_strControlNO as string
		private  m_strManuFacturer as string
		private  m_strEquipModel as string
		private  m_strSpecification as string
		private  m_strEquipDept as string
		private  m_strQyLocation as string
		private  m_strEquipLocation as string
		private  m_strKeepUser as string
		private  m_iIsHasDetail as Integer
		private  m_strRemark as string
		private  m_iIsHasFile as Integer
		private  m_strExtend1 as string
		private  m_strExtend2 as string
		private  m_strExtend3 as string
		private  m_strExtend4 as string
		private  m_strExtend5 as string
    Private m_dtRecordCreated As DateTime = DateTime.MaxValue
		private  m_iRecordDeleted as Integer

#End Region

#Region " Public Properties"
		''' <summary>
		''' 記錄編號
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
		''' 流程實例ID
		''' </summary>
		public Property eFlowDocID as Guid 
		Get
			return m_deceFlowDocID 
		End Get
		Set(ByVal Value As Guid)
			 m_deceFlowDocID = value
		End Set
		End Property
		''' <summary>
		''' 是否結案
		''' </summary>
		public Property IsFinish as Integer 
		Get
			return m_iIsFinish 
		End Get
		Set(ByVal Value As Integer)
			 m_iIsFinish = value
		End Set
		End Property
		''' <summary>
		''' 所屬狀態Num
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
		''' 狀態名稱
		''' </summary>
		public Property StateName as string 
		Get
			 return m_strStateName 
		End Get
		Set(ByVal Value As string)
			 m_strStateName = value
		End Set
		End Property
		''' <summary>
		''' 設備名稱
		''' </summary>
		public Property EquipName as string 
		Get
			 return m_strEquipName 
		End Get
		Set(ByVal Value As string)
			 m_strEquipName = value
		End Set
		End Property
		''' <summary>
		''' 管制編號
		''' </summary>
		public Property ControlNO as string 
		Get
			 return m_strControlNO 
		End Get
		Set(ByVal Value As string)
			 m_strControlNO = value
		End Set
		End Property
		''' <summary>
		''' 廠商
		''' </summary>
		public Property ManuFacturer as string 
		Get
			 return m_strManuFacturer 
		End Get
		Set(ByVal Value As string)
			 m_strManuFacturer = value
		End Set
		End Property
		''' <summary>
		''' 儀器型號
		''' </summary>
		public Property EquipModel as string 
		Get
			 return m_strEquipModel 
		End Get
		Set(ByVal Value As string)
			 m_strEquipModel = value
		End Set
		End Property
		''' <summary>
		''' 主要規格
		''' </summary>
		public Property Specification as string 
		Get
			 return m_strSpecification 
		End Get
		Set(ByVal Value As string)
			 m_strSpecification = value
		End Set
		End Property
		''' <summary>
		''' 所屬實驗室
		''' </summary>
		public Property EquipDept as string 
		Get
			 return m_strEquipDept 
		End Get
		Set(ByVal Value As string)
			 m_strEquipDept = value
		End Set
		End Property
		''' <summary>
		''' 區域位置
		''' </summary>
		public Property QyLocation as string 
		Get
			 return m_strQyLocation 
		End Get
		Set(ByVal Value As string)
			 m_strQyLocation = value
		End Set
		End Property
		''' <summary>
		''' 放置地點
		''' </summary>
		public Property EquipLocation as string 
		Get
			 return m_strEquipLocation 
		End Get
		Set(ByVal Value As string)
			 m_strEquipLocation = value
		End Set
		End Property
		''' <summary>
		''' 保管人
		''' </summary>
		public Property KeepUser as string 
		Get
			 return m_strKeepUser 
		End Get
		Set(ByVal Value As string)
			 m_strKeepUser = value
		End Set
		End Property
		''' <summary>
		''' 是否有設備附件
		''' </summary>
		public Property IsHasDetail as Integer 
		Get
			return m_iIsHasDetail 
		End Get
		Set(ByVal Value As Integer)
			 m_iIsHasDetail = value
		End Set
		End Property
		''' <summary>
		''' 備註
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
		''' 是否有附件
		''' </summary>
		public Property IsHasFile as Integer 
		Get
			return m_iIsHasFile 
		End Get
		Set(ByVal Value As Integer)
			 m_iIsHasFile = value
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
		''' 預留欄位2
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

