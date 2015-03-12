#Region "導入命名空間"
Imports System
Imports System.Xml
Imports System.Xml.Serialization
Imports System.Runtime.Serialization
#End Region

''' <summary>實例類</summary>
''' <remarks></remarks>
<Serializable()> _
Partial Public Class RoleManageInfo
#Region " Private Fields "
    Private m_iPKID As Integer = 0
    Private m_iRolePKID As Integer = 0
    Private m_strRoleName As String = String.Empty
    Private m_iUserpkid As Integer = 0
    Private m_strUserSid As String = String.Empty
    Private m_strUserName As String = String.Empty
    Private m_strUserEmail As String = String.Empty
    Private m_strUserPhone As String = String.Empty
    Private m_iIsCanEdit As Integer = 0
    Private m_dtStartDate As DateTime = DateTime.MaxValue
    Private m_dtEndDate As DateTime = DateTime.MaxValue
    Private m_strExtend01 As String = String.Empty
    Private m_strExtend02 As String = String.Empty
    Private m_strExtend03 As String = String.Empty
    Private m_strExtend04 As String = String.Empty
    Private m_strExtend05 As String = String.Empty
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
		public Property RolePKID as Integer 
		Get
			return m_iRolePKID 
		End Get
		Set(ByVal Value As Integer)
			 m_iRolePKID = value
		End Set
		End Property
		''' <summary>
		''' 
		''' </summary>
		public Property RoleName as string 
		Get
			 return m_strRoleName 
		End Get
		Set(ByVal Value As string)
			 m_strRoleName = value
		End Set
		End Property
		''' <summary>
		''' 
		''' </summary>
		public Property Userpkid as Integer 
		Get
			return m_iUserpkid 
		End Get
		Set(ByVal Value As Integer)
			 m_iUserpkid = value
		End Set
		End Property
		''' <summary>
		''' 
		''' </summary>
		public Property UserSid as string 
		Get
			 return m_strUserSid 
		End Get
		Set(ByVal Value As string)
			 m_strUserSid = value
		End Set
		End Property
		''' <summary>
		''' 
		''' </summary>
		public Property UserName as string 
		Get
			 return m_strUserName 
		End Get
		Set(ByVal Value As string)
			 m_strUserName = value
		End Set
		End Property
		''' <summary>
		''' 
		''' </summary>
		public Property UserEmail as string 
		Get
			 return m_strUserEmail 
		End Get
		Set(ByVal Value As string)
			 m_strUserEmail = value
		End Set
		End Property
		''' <summary>
		''' 
		''' </summary>
		public Property UserPhone as string 
		Get
			 return m_strUserPhone 
		End Get
		Set(ByVal Value As string)
			 m_strUserPhone = value
		End Set
		End Property
		''' <summary>
		''' 
		''' </summary>
		public Property IsCanEdit as Integer 
		Get
			return m_iIsCanEdit 
		End Get
		Set(ByVal Value As Integer)
			 m_iIsCanEdit = value
		End Set
		End Property
		''' <summary>
		''' 
		''' </summary>
		public Property StartDate as DateTime 
		Get
			return m_dtStartDate 
		End Get
		Set(ByVal Value As DateTime)
			 m_dtStartDate = value
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

