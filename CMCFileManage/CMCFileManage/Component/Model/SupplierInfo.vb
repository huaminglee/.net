#Region "導入命名空間"
Imports System
Imports System.Xml
Imports System.Xml.Serialization
Imports System.Runtime.Serialization
#End Region

''' <summary>實例類</summary>
''' <remarks></remarks>
<Serializable()> _
Partial Public Class SupplierInfo
#Region " Private Fields "
    Private m_iPKID As Integer = 0
    Private m_iType As Integer = 0
		private  m_deceFlowDocID as Guid
    Private m_iIsFinish As Integer = 0
    Private m_iStateOrder As Integer = 0
    Private m_strStateName As String = String.Empty
    Private m_strSupplierName As String = String.Empty
    Private m_strSupplierShortName As String = String.Empty
    Private m_strContactName As String = String.Empty
    Private m_strContactPhone As String = String.Empty
    Private m_strAddress As String = String.Empty
    Private m_strIndustry As String = String.Empty
    Private m_strBelongLab As String = String.Empty
    Private m_dtISOdate As DateTime = DateTime.MaxValue
    Private m_dtBIdate As DateTime = DateTime.MaxValue
    Private m_strAssessor As String = String.Empty
    Private m_iStatus As Integer = 0
    Private m_iAssessCycle As Integer = 0
    Private m_dtAssessDate As DateTime = DateTime.MaxValue
    Private m_strAssessResult As String = String.Empty
    Private m_strRemark As String = String.Empty
    Private m_strExtend1 As String = String.Empty
    Private m_strExtend2 As String = String.Empty
    Private m_strExtend3 As String = String.Empty
    Private m_strExtend4 As String = String.Empty
    Private m_strExtend5 As String = String.Empty
    Private m_strExtend6 As String = String.Empty
    Private m_strExtend7 As String = String.Empty
    Private m_strExtend8 As String = String.Empty
    Private m_strExtend9 As String = String.Empty
    Private m_strExtend10 As String = String.Empty
    Private m_dtRecordCreated As DateTime = DateTime.MaxValue
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
		''' 供應商類型（1:關鍵品2：設備3：校準）
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
		''' 供應商名稱
		''' </summary>
		public Property SupplierName as string 
		Get
			 return m_strSupplierName 
		End Get
		Set(ByVal Value As string)
			 m_strSupplierName = value
		End Set
		End Property
		''' <summary>
		''' 供應商簡稱
		''' </summary>
		public Property SupplierShortName as string 
		Get
			 return m_strSupplierShortName 
		End Get
		Set(ByVal Value As string)
			 m_strSupplierShortName = value
		End Set
		End Property
		''' <summary>
		''' 聯繫人姓名
		''' </summary>
		public Property ContactName as string 
		Get
			 return m_strContactName 
		End Get
		Set(ByVal Value As string)
			 m_strContactName = value
		End Set
		End Property
		''' <summary>
		''' 聯繫人電話
		''' </summary>
		public Property ContactPhone as string 
		Get
			 return m_strContactPhone 
		End Get
		Set(ByVal Value As string)
			 m_strContactPhone = value
		End Set
		End Property
		''' <summary>
		''' 地址
		''' </summary>
		public Property Address as string 
		Get
			 return m_strAddress 
		End Get
		Set(ByVal Value As string)
			 m_strAddress = value
		End Set
		End Property
		''' <summary>
		''' 行業
		''' </summary>
		public Property Industry as string 
		Get
			 return m_strIndustry 
		End Get
		Set(ByVal Value As string)
			 m_strIndustry = value
		End Set
		End Property
		''' <summary>
		''' 所屬實驗室
		''' </summary>
		public Property BelongLab as string 
		Get
			 return m_strBelongLab 
		End Get
		Set(ByVal Value As string)
			 m_strBelongLab = value
		End Set
		End Property
		''' <summary>
		''' ISO有效期
		''' </summary>
		public Property ISOdate as DateTime 
		Get
			return m_dtISOdate 
		End Get
		Set(ByVal Value As DateTime)
			 m_dtISOdate = value
		End Set
		End Property
		''' <summary>
		''' 經營證書有效期
		''' </summary>
		public Property BIdate as DateTime 
		Get
			return m_dtBIdate 
		End Get
		Set(ByVal Value As DateTime)
			 m_dtBIdate = value
		End Set
		End Property
		''' <summary>
		''' 評估人
		''' </summary>
		public Property Assessor as string 
		Get
			 return m_strAssessor 
		End Get
		Set(ByVal Value As string)
			 m_strAssessor = value
		End Set
		End Property
		''' <summary>
		''' 交易狀態
		''' </summary>
		public Property Status as Integer 
		Get
			return m_iStatus 
		End Get
		Set(ByVal Value As Integer)
			 m_iStatus = value
		End Set
		End Property
		''' <summary>
		''' 評估週期
		''' </summary>
		public Property AssessCycle as Integer 
		Get
			return m_iAssessCycle 
		End Get
		Set(ByVal Value As Integer)
			 m_iAssessCycle = value
		End Set
		End Property
		''' <summary>
		''' 評估日期
		''' </summary>
		public Property AssessDate as DateTime 
		Get
			return m_dtAssessDate 
		End Get
		Set(ByVal Value As DateTime)
			 m_dtAssessDate = value
		End Set
		End Property
		''' <summary>
		''' 評估結論
		''' </summary>
		public Property AssessResult as string 
		Get
			 return m_strAssessResult 
		End Get
		Set(ByVal Value As string)
			 m_strAssessResult = value
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

