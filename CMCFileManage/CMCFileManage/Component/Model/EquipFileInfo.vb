#Region "導入命名空間"
Imports System
Imports System.Xml
Imports System.Xml.Serialization
Imports System.Runtime.Serialization
#End Region

''' <summary>實例類</summary>
''' <remarks></remarks>
<Serializable()> _
Partial Public Class EquipFileInfo
#Region " Private Fields "
    Private m_iPKID As Integer = 0
    Private m_iParentPKID As Integer = 0
		private  m_deceFlowDocID as Guid
    Private m_iIsFinish As Integer = 0
    Private m_iStateOrder As Integer = 0
    Private m_strStateName As String = String.Empty
    Private m_strEquipDept As String = String.Empty
    Private m_strQyLocation As String = String.Empty
    Private m_strEquipName As String = String.Empty
    Private m_strControlNO As String = String.Empty
    Private m_strManuFacturer As String = String.Empty
    Private m_strDetailName As String = String.Empty
    Private m_strDetailControlNO As String = String.Empty
    Private m_strEquipModel As String = String.Empty
    Private m_strSerialNumber As String = String.Empty
    Private m_strMainSpecification As String = String.Empty
    Private m_iEquipNum As String = String.Empty
    Private m_strEquipLocation As String = String.Empty
    Private m_strKeepUser As String = String.Empty
    Private m_strExtend1 As String = String.Empty
    Private m_strExtend2 As String = String.Empty
    Private m_strExtend3 As String = String.Empty
    Private m_strExtend4 As String = String.Empty
    Private m_strExtend5 As String = String.Empty
    Private m_dtRecordCreated As DateTime = DateTime.Now
    Private m_iRecordDeleted As Integer = 0


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
		''' 設備清單記錄編號
		''' </summary>
		public Property ParentPKID as Integer 
		Get
			return m_iParentPKID 
		End Get
		Set(ByVal Value As Integer)
			 m_iParentPKID = value
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
		''' 附件名稱
		''' </summary>
		public Property DetailName as string 
		Get
			 return m_strDetailName 
		End Get
		Set(ByVal Value As string)
			 m_strDetailName = value
		End Set
		End Property
		''' <summary>
		''' 附件管制編號
		''' </summary>
		public Property DetailControlNO as string 
		Get
			 return m_strDetailControlNO 
		End Get
		Set(ByVal Value As string)
			 m_strDetailControlNO = value
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
		''' 序列號
		''' </summary>
		public Property SerialNumber as string 
		Get
			 return m_strSerialNumber 
		End Get
		Set(ByVal Value As string)
			 m_strSerialNumber = value
		End Set
		End Property
		''' <summary>
		''' 主要規格
		''' </summary>
		public Property MainSpecification as string 
		Get
			 return m_strMainSpecification 
		End Get
		Set(ByVal Value As string)
			 m_strMainSpecification = value
		End Set
		End Property
		''' <summary>
		''' 數量
		''' </summary>
    Public Property EquipNum() As String
        Get
            Return m_iEquipNum
        End Get
        Set(ByVal Value As String)
            m_iEquipNum = Value
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
		''' 預留欄位5備註
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

