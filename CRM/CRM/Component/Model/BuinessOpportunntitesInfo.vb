#Region "導入命名空間"
Imports System
Imports System.Xml
Imports System.Xml.Serialization
Imports System.Runtime.Serialization
#End Region

''' <summary>實例類</summary>
''' <remarks></remarks>
<Serializable()> _
Partial Public Class BuinessOpportunntitesInfo
#Region " Private Fields "
    Private m_iPKID As Integer = 0
    Private m_strOpportName As String = String.Empty
    Private m_strInserPerson As String = String.Empty
    Private m_strOppOwoner As String = String.Empty
    Private m_strLastChange As String = String.Empty
    Private m_iAmounts As Integer = 0
    Private m_strCustomerName As String = String.Empty
    Private m_strType As String = String.Empty
    Private m_strCategory As String = String.Empty
    Private m_strCustomerSources As String = String.Empty
    Private m_dExcepedIncome As Double = 0
    Private m_dPossibility As Double = 0
    Private m_strRemark As String = String.Empty
    Private m_dtEndDate As DateTime = DateTime.MaxValue
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
		''' 業務機會名
		''' </summary>
		public Property OpportName as string 
		Get
			 return m_strOpportName 
		End Get
		Set(ByVal Value As string)
			 m_strOpportName = value
		End Set
		End Property
		''' <summary>
		''' 製錶人
		''' </summary>
		public Property InserPerson as string 
		Get
			 return m_strInserPerson 
		End Get
		Set(ByVal Value As string)
			 m_strInserPerson = value
		End Set
		End Property
		''' <summary>
		''' 業務機會所有人
		''' </summary>
		public Property OppOwoner as string 
		Get
			 return m_strOppOwoner 
		End Get
		Set(ByVal Value As string)
			 m_strOppOwoner = value
		End Set
		End Property
		''' <summary>
		''' 上次改變
		''' </summary>
		public Property LastChange as string 
		Get
			 return m_strLastChange 
		End Get
		Set(ByVal Value As string)
			 m_strLastChange = value
		End Set
		End Property
		''' <summary>
		''' 金額
		''' </summary>
		public Property Amounts as Integer 
		Get
			return m_iAmounts 
		End Get
		Set(ByVal Value As Integer)
			 m_iAmounts = value
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
		''' 類別
		''' </summary>
		public Property Type as string 
		Get
			 return m_strType 
		End Get
		Set(ByVal Value As string)
			 m_strType = value
		End Set
		End Property
		''' <summary>
		''' 狀態
		''' </summary>
		public Property Category as string 
		Get
			 return m_strCategory 
		End Get
		Set(ByVal Value As string)
			 m_strCategory = value
		End Set
		End Property
		''' <summary>
		''' 客戶來源
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
		''' 預期收入
		''' </summary>
		public Property ExcepedIncome as double 
		Get
			return m_dExcepedIncome 
		End Get
		Set(ByVal Value As double)
			 m_dExcepedIncome = value
		End Set
		End Property
		''' <summary>
		''' 可能性
		''' </summary>
		public Property Possibility as double 
		Get
			return m_dPossibility 
		End Get
		Set(ByVal Value As double)
			 m_dPossibility = value
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
		''' 
		''' </summary>
		public Property EndDate as DateTime 
		Get
			return m_dtEndDate 
		End Get
		Set(ByVal Value As DateTime)
			 m_dtEndDate = value
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
		''' 
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
		''' 
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
		''' 
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
		''' 
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

