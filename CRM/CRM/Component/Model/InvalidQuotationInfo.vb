#Region "導入命名空間"
Imports System
Imports System.Xml
Imports System.Xml.Serialization
Imports System.Runtime.Serialization
#End Region

''' <summary>實例類</summary>
''' <remarks></remarks>
<Serializable()> _
Partial Public Class InvalidQuotationInfo
#Region " Private Fields "
    Private m_iPKID As Integer = 0
    Private m_iQuotationPKID As Integer = 0
    Private m_iReporDetailPKID As Integer = 0
    Private m_strAddUserID As String = String.Empty
    Private m_strConfirmUserID As String = String.Empty
    Private m_dtAddDate As DateTime = DateTime.MaxValue
    Private m_dtConfirmDate As DateTime = DateTime.MaxValue
    Private m_strReason As String = String.Empty
    Private m_iStatus As Integer = 0
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
    Private m_iRecorddeleted As Integer = 0

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
		''' 報價單PKID
		''' </summary>
		public Property QuotationPKID as Integer 
		Get
			return m_iQuotationPKID 
		End Get
		Set(ByVal Value As Integer)
			 m_iQuotationPKID = value
		End Set
		End Property
		''' <summary>
		''' 
		''' </summary>
		public Property ReporDetailPKID as Integer 
		Get
			return m_iReporDetailPKID 
		End Get
		Set(ByVal Value As Integer)
			 m_iReporDetailPKID = value
		End Set
		End Property
		''' <summary>
		''' 
		''' </summary>
		public Property AddUserID as string 
		Get
			 return m_strAddUserID 
		End Get
		Set(ByVal Value As string)
			 m_strAddUserID = value
		End Set
		End Property
		''' <summary>
		''' 
		''' </summary>
		public Property ConfirmUserID as string 
		Get
			 return m_strConfirmUserID 
		End Get
		Set(ByVal Value As string)
			 m_strConfirmUserID = value
		End Set
		End Property
		''' <summary>
		''' 
		''' </summary>
		public Property AddDate as DateTime 
		Get
			return m_dtAddDate 
		End Get
		Set(ByVal Value As DateTime)
			 m_dtAddDate = value
		End Set
		End Property
		''' <summary>
		''' 
		''' </summary>
		public Property ConfirmDate as DateTime 
		Get
			return m_dtConfirmDate 
		End Get
		Set(ByVal Value As DateTime)
			 m_dtConfirmDate = value
		End Set
		End Property
		''' <summary>
		''' 
		''' </summary>
		public Property Reason as string 
		Get
			 return m_strReason 
		End Get
		Set(ByVal Value As string)
			 m_strReason = value
		End Set
		End Property
		''' <summary>
		''' 
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
		''' 
		''' </summary>
		public Property Recorddeleted as Integer 
		Get
			return m_iRecorddeleted 
		End Get
		Set(ByVal Value As Integer)
			 m_iRecorddeleted = value
		End Set
		End Property

#End Region
End Class

