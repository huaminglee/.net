#Region "導入命名空間"
Imports System
Imports System.Xml
Imports System.Xml.Serialization
Imports System.Runtime.Serialization
#End Region

''' <summary>實例類</summary>
''' <remarks></remarks>
<Serializable()> _
Partial Public Class CustomerVisitsInfo
#Region " Private Fields "
    Private m_iPKID As Integer = 0
    Private m_strVisitsNO As String = String.Empty
		private  m_deceFlowDocID as Guid
    Private m_strStateName As String = String.Empty
    Private m_iIsFinished As Integer = 0
    Private m_dtFinishTime As DateTime = DateTime.MaxValue
    Private m_iStateOrder As Integer = 0
    Private m_strQuoterID As String = String.Empty
    Private m_strQuoterName As String = String.Empty
    Private m_dtVisitDate As DateTime = DateTime.MaxValue
    Private m_iIsFirstVisits As Integer = 0
    Private m_iCustomerPKID As Integer = 0
    Private m_strCustomerName As String = String.Empty
    Private m_strCustomerSources As String = String.Empty
    Private m_strCustomerScale As String = String.Empty
    Private m_strCustomerNature As String = String.Empty
    Private m_strProductRange As String = String.Empty
    Private m_dTestAmountPerYeay As Double = 0
    Private m_strCooperationAgen As String = String.Empty
    Private m_iTypeofPay As Integer = 0
    Private m_strCooperationProj As String = String.Empty
    Private m_strCustomerAddress As String = String.Empty
    Private m_strRemark As String = String.Empty
    Private m_strConversationmatters As String = String.Empty
    Private m_strResult As String = String.Empty
    Private m_strMattertracked As String = String.Empty
    Private m_strExtend01 As String = String.Empty
    Private m_strExtend02 As String = String.Empty
    Private m_strExtend03 As String = String.Empty
    Private m_strExtend04 As String = String.Empty
    Private m_strExtend05 As String = String.Empty
    Private m_strExtend06 As String = String.Empty
    Private m_strExtend07 As String = String.Empty
    Private m_strExtend08 As String = String.Empty
    Private m_strExtend09 As String = String.Empty
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
		''' 拜訪單號
		''' </summary>
		public Property VisitsNO as string 
		Get
			 return m_strVisitsNO 
		End Get
		Set(ByVal Value As string)
			 m_strVisitsNO = value
		End Set
		End Property
		''' <summary>
		''' 流程GUID
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
		''' 是否結案,1為結案2為需要取回的案件已確認取回
		''' </summary>
		public Property IsFinished as Integer 
		Get
			return m_iIsFinished 
		End Get
		Set(ByVal Value As Integer)
			 m_iIsFinished = value
		End Set
		End Property
		''' <summary>
		''' 對賬時間
		''' </summary>
		public Property FinishTime as DateTime 
		Get
			return m_dtFinishTime 
		End Get
		Set(ByVal Value As DateTime)
			 m_dtFinishTime = value
		End Set
		End Property
		''' <summary>
		''' 站別
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
		''' 
		''' </summary>
		public Property QuoterID as string 
		Get
			 return m_strQuoterID 
		End Get
		Set(ByVal Value As string)
			 m_strQuoterID = value
		End Set
		End Property
		''' <summary>
		''' 
		''' </summary>
		public Property QuoterName as string 
		Get
			 return m_strQuoterName 
		End Get
		Set(ByVal Value As string)
			 m_strQuoterName = value
		End Set
		End Property
		''' <summary>
		''' 
		''' </summary>
		public Property VisitDate as DateTime 
		Get
			return m_dtVisitDate 
		End Get
		Set(ByVal Value As DateTime)
			 m_dtVisitDate = value
		End Set
		End Property
		''' <summary>
		''' 
		''' </summary>
		public Property IsFirstVisits as Integer 
		Get
			return m_iIsFirstVisits 
		End Get
		Set(ByVal Value As Integer)
			 m_iIsFirstVisits = value
		End Set
		End Property
		''' <summary>
		''' 
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
		''' 
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
		''' 
		''' </summary>
		public Property CustomerSources as string 
		Get
			 return m_strCustomerSources 
		End Get
		Set(ByVal Value As string)
			 m_strCustomerSources = value
		End Set
		End Property
		''' <summary>
		''' 
		''' </summary>
		public Property CustomerScale as string 
		Get
			 return m_strCustomerScale 
		End Get
		Set(ByVal Value As string)
			 m_strCustomerScale = value
		End Set
		End Property
		''' <summary>
		''' 
		''' </summary>
		public Property CustomerNature as string 
		Get
			 return m_strCustomerNature 
		End Get
		Set(ByVal Value As string)
			 m_strCustomerNature = value
		End Set
		End Property
		''' <summary>
		''' 
		''' </summary>
		public Property ProductRange as string 
		Get
			 return m_strProductRange 
		End Get
		Set(ByVal Value As string)
			 m_strProductRange = value
		End Set
		End Property
		''' <summary>
		''' 
		''' </summary>
		public Property TestAmountPerYeay as double 
		Get
			return m_dTestAmountPerYeay 
		End Get
		Set(ByVal Value As double)
			 m_dTestAmountPerYeay = value
		End Set
		End Property
		''' <summary>
		''' 合作機構
		''' </summary>
		public Property CooperationAgen as string 
		Get
			 return m_strCooperationAgen 
		End Get
		Set(ByVal Value As string)
			 m_strCooperationAgen = value
		End Set
		End Property
		''' <summary>
		''' 
		''' </summary>
		public Property TypeofPay as Integer 
		Get
			return m_iTypeofPay 
		End Get
		Set(ByVal Value As Integer)
			 m_iTypeofPay = value
		End Set
		End Property
		''' <summary>
		''' 合作項目
		''' </summary>
		public Property CooperationProj as string 
		Get
			 return m_strCooperationProj 
		End Get
		Set(ByVal Value As string)
			 m_strCooperationProj = value
		End Set
		End Property
		''' <summary>
		''' 
		''' </summary>
		public Property CustomerAddress as string 
		Get
			 return m_strCustomerAddress 
		End Get
		Set(ByVal Value As string)
			 m_strCustomerAddress = value
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
		''' 交談事項
		''' </summary>
		public Property Conversationmatters as string 
		Get
			 return m_strConversationmatters 
		End Get
		Set(ByVal Value As string)
			 m_strConversationmatters = value
		End Set
		End Property
		''' <summary>
		''' 
		''' </summary>
		public Property Result as string 
		Get
			 return m_strResult 
		End Get
		Set(ByVal Value As string)
			 m_strResult = value
		End Set
		End Property
		''' <summary>
		''' 待追蹤事項
		''' </summary>
		public Property Mattertracked as string 
		Get
			 return m_strMattertracked 
		End Get
		Set(ByVal Value As string)
			 m_strMattertracked = value
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
		''' 記錄刪除標誌(0正常，1?除，2未保存，3不??)
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

