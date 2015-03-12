#Region "導入命名空間"
Imports System
Imports System.Xml
Imports System.Xml.Serialization
Imports System.Runtime.Serialization
#End Region

''' <summary>實例類</summary>
''' <remarks></remarks>
<Serializable()> _
Partial Public Class AddFileSharedInfo
#Region " Private Fields "
    Private m_iPKID As Integer = 0
		private  m_deceFlowDocID as Guid
    Private m_strStateName As String = String.Empty
    Private m_iStateOrder As Integer = 0
    Private m_iIsFinished As Integer = 0
    Private m_dtFinishTime As DateTime = DateTime.MaxValue
    Private m_iCustomerPKID As Integer = 0
    Private m_strCustomerName As String = String.Empty
    Private m_strUploadUserSID As String = String.Empty
    Private m_strExtend01 As String = String.Empty
    Private m_strExtend02 As String = String.Empty
    Private m_strExtend03 As String = String.Empty
    Private m_strExtend04 As String = String.Empty
    Private m_strExtend05 As String = String.Empty
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
		''' 
		''' </summary>
		public Property UploadUserSID as string 
		Get
			 return m_strUploadUserSID 
		End Get
		Set(ByVal Value As string)
			 m_strUploadUserSID = value
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

