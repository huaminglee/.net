#Region "導入命名空間"
Imports System
Imports System.Xml
Imports System.Xml.Serialization
Imports System.Runtime.Serialization
#End Region

''' <summary>實例類</summary>
''' <remarks></remarks>
<Serializable()> _
Partial Public Class SendOutMailLogInfo
#Region " Private Fields "
    Private m_ipkid As Integer = 0
    Private m_iParentID As Integer = 0
    Private m_iParentType As Integer = 0
    Private m_strCurrentUserSID As String = String.Empty
    Private m_strMailAddress As String = String.Empty
    Private m_strMailContent As String = String.Empty
    Private m_strMailCC As String = String.Empty
    Private m_strMailTitle As String = String.Empty
    Private m_strRemark As String = String.Empty
    Private m_strExtend1 As String = String.Empty
    Private m_strExtend2 As String = String.Empty
    Private m_strExtend3 As String = String.Empty
    Private m_strExtend4 As String = String.Empty
    Private m_strExtend5 As String = String.Empty
    Private m_dtRecordCreated As DateTime = DateTime.MaxValue
    Private m_iRecordDeleted As Integer = 0

#End Region

#Region " Public Properties"
		''' <summary>
		''' 
		''' </summary>
		public Property pkid as Integer 
		Get
			return m_ipkid 
		End Get
		Set(ByVal Value As Integer)
			 m_ipkid = value
		End Set
		End Property
		''' <summary>
		''' 
		''' </summary>
		public Property ParentID as Integer 
		Get
			return m_iParentID 
		End Get
		Set(ByVal Value As Integer)
			 m_iParentID = value
		End Set
		End Property
		''' <summary>
		''' 
		''' </summary>
		public Property ParentType as Integer 
		Get
			return m_iParentType 
		End Get
		Set(ByVal Value As Integer)
			 m_iParentType = value
		End Set
		End Property
		''' <summary>
		''' 
		''' </summary>
		public Property CurrentUserSID as string 
		Get
			 return m_strCurrentUserSID 
		End Get
		Set(ByVal Value As string)
			 m_strCurrentUserSID = value
		End Set
		End Property
		''' <summary>
		''' 
		''' </summary>
		public Property MailAddress as string 
		Get
			 return m_strMailAddress 
		End Get
		Set(ByVal Value As string)
			 m_strMailAddress = value
		End Set
		End Property
		''' <summary>
		''' 
		''' </summary>
		public Property MailContent as string 
		Get
			 return m_strMailContent 
		End Get
		Set(ByVal Value As string)
			 m_strMailContent = value
		End Set
		End Property
		''' <summary>
		''' 
		''' </summary>
		public Property MailCC as string 
		Get
			 return m_strMailCC 
		End Get
		Set(ByVal Value As string)
			 m_strMailCC = value
		End Set
		End Property
		''' <summary>
		''' 
		''' </summary>
		public Property MailTitle as string 
		Get
			 return m_strMailTitle 
		End Get
		Set(ByVal Value As string)
			 m_strMailTitle = value
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

