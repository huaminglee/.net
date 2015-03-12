#Region "導入命名空間"
Imports System
Imports System.Xml
Imports System.Xml.Serialization
Imports System.Runtime.Serialization
#End Region

''' <summary>實例類</summary>
''' <remarks></remarks>
<Serializable()> _
Partial Public Class SamplesReceivedInfo
#Region " Private Fields "
    Private m_iPKID As Integer = 0
    Private m_iCustomerPKID As Integer = 0
    Private m_strCustomerName As String = String.Empty
    Private m_strSampleName As String = String.Empty
    Private m_dSampleNums As Double = 0
    Private m_strReceivedAddress As String = String.Empty
    Private m_strRemark As String = String.Empty
    Private m_dtReachTime As DateTime = DateTime.MaxValue
    Private m_strAcceptUser As String = String.Empty
    Private m_strInformUser As String = String.Empty
    Private m_strInformEmail As String = String.Empty
    Private m_iIsTakeaway As Integer = 0
    Private m_strTakeawayUser As String = String.Empty
    Private m_dtTakeawayTime As DateTime = DateTime.MaxValue
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
		public Property SampleName as string 
		Get
			 return m_strSampleName 
		End Get
		Set(ByVal Value As string)
			 m_strSampleName = value
		End Set
		End Property
		''' <summary>
		''' 
		''' </summary>
		public Property SampleNums as double 
		Get
			return m_dSampleNums 
		End Get
		Set(ByVal Value As double)
			 m_dSampleNums = value
		End Set
		End Property
		''' <summary>
		''' 
		''' </summary>
		public Property ReceivedAddress as string 
		Get
			 return m_strReceivedAddress 
		End Get
		Set(ByVal Value As string)
			 m_strReceivedAddress = value
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
		''' 
		''' </summary>
		public Property ReachTime as DateTime 
		Get
			return m_dtReachTime 
		End Get
		Set(ByVal Value As DateTime)
			 m_dtReachTime = value
		End Set
		End Property
		''' <summary>
		''' 
		''' </summary>
		public Property AcceptUser as string 
		Get
			 return m_strAcceptUser 
		End Get
		Set(ByVal Value As string)
			 m_strAcceptUser = value
		End Set
		End Property
		''' <summary>
		''' 
		''' </summary>
		public Property InformUser as string 
		Get
			 return m_strInformUser 
		End Get
		Set(ByVal Value As string)
			 m_strInformUser = value
		End Set
		End Property
		''' <summary>
		''' 
		''' </summary>
		public Property InformEmail as string 
		Get
			 return m_strInformEmail 
		End Get
		Set(ByVal Value As string)
			 m_strInformEmail = value
		End Set
		End Property
		''' <summary>
		''' 
		''' </summary>
		public Property IsTakeaway as Integer 
		Get
			return m_iIsTakeaway 
		End Get
		Set(ByVal Value As Integer)
			 m_iIsTakeaway = value
		End Set
		End Property
		''' <summary>
		''' 
		''' </summary>
		public Property TakeawayUser as string 
		Get
			 return m_strTakeawayUser 
		End Get
		Set(ByVal Value As string)
			 m_strTakeawayUser = value
		End Set
		End Property
		''' <summary>
		''' 
		''' </summary>
		public Property TakeawayTime as DateTime 
		Get
			return m_dtTakeawayTime 
		End Get
		Set(ByVal Value As DateTime)
			 m_dtTakeawayTime = value
		End Set
		End Property
		''' <summary>
    ''' 業務員SID
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
		''' 記錄刪除標誌0正常,1刪除
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

