#Region "�ɤJ�R�W�Ŷ�"
Imports System
Imports System.Xml
Imports System.Xml.Serialization
Imports System.Runtime.Serialization
#End Region

''' <summary>�����</summary>
''' <remarks></remarks>
<Serializable()> _
Partial Public Class calendarInfo
#Region " Private Fields "
    Private m_iPKID As Integer = 0
    Private m_strUserSID As String = String.Empty
    Private m_strTitle As String = String.Empty
    Private m_strXiangxi As String = String.Empty
    Private m_dtBeginTime As DateTime = DateTime.MaxValue
    Private m_dtEndTime As DateTime = DateTime.MaxValue
    Private m_iIsDeal As Integer = 0
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
		public Property PKID as Integer 
		Get
			return m_iPKID 
		End Get
		Set(ByVal Value As Integer)
			 m_iPKID = value
		End Set
		End Property
		''' <summary>
		''' �K�[�HID
		''' </summary>
		public Property UserSID as string 
		Get
			 return m_strUserSID 
		End Get
		Set(ByVal Value As string)
			 m_strUserSID = value
		End Set
		End Property
		''' <summary>
		''' ���D
		''' </summary>
		public Property Title as string 
		Get
			 return m_strTitle 
		End Get
		Set(ByVal Value As string)
			 m_strTitle = value
		End Set
		End Property
		''' <summary>
		''' �ԲӴy�z
		''' </summary>
		public Property Xiangxi as string 
		Get
			 return m_strXiangxi 
		End Get
		Set(ByVal Value As string)
			 m_strXiangxi = value
		End Set
		End Property
		''' <summary>
		''' �}�l�ɶ�
		''' </summary>
		public Property BeginTime as DateTime 
		Get
			return m_dtBeginTime 
		End Get
		Set(ByVal Value As DateTime)
			 m_dtBeginTime = value
		End Set
		End Property
		''' <summary>
		''' �����ɶ�
		''' </summary>
		public Property EndTime as DateTime 
		Get
			return m_dtEndTime 
		End Get
		Set(ByVal Value As DateTime)
			 m_dtEndTime = value
		End Set
		End Property
		''' <summary>
		''' �O�_�B�z
		''' </summary>
		public Property IsDeal as Integer 
		Get
			return m_iIsDeal 
		End Get
		Set(ByVal Value As Integer)
			 m_iIsDeal = value
		End Set
		End Property
		''' <summary>
    ''' �pô�H�ͤ�
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
    ''' �@�~�ɶ�
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
		''' �w�d���4
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
		''' �w�d���5
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
		''' �O���Юɶ�
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
		''' �O���R���лx
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

