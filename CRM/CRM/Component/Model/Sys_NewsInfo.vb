#Region "�ɤJ�R�W�Ŷ�"
Imports System
Imports System.Xml
Imports System.Xml.Serialization
Imports System.Runtime.Serialization
#End Region

''' <summary>�����</summary>
''' <remarks></remarks>
<Serializable()> _
Partial Public Class Sys_NewsInfo
#Region " Private Fields "

    Private m_strNewsID As String
    Private m_strNewTitle As String
    Private m_strNewContent As String
    Private m_strCreateUser As String
    Private m_strModifyUser As String
    Private m_dtModifyTime As DateTime
    Private m_ServicePKID As Integer = 0
    Private m_ServiceName As String = String.Empty
    Private m_EndTime As Date
    Private m_strExtend1 As String = String.Empty
    Private m_strExtend2 As String = String.Empty
    Private m_strExtend3 As String = String.Empty
    Private m_strExtend4 As String = String.Empty
    Private m_strExtend5 As String = String.Empty
    Private m_dtRecordCreated As DateTime
    Private m_iRecordDeleted As Integer

#End Region

#Region " Public Properties"
		''' <summary>
		''' �����s��
		''' </summary>
    Public Property NewsID() As String
        Get
            Return m_strNewsID
        End Get
        Set(ByVal Value As String)
            m_strNewsID = Value
        End Set
    End Property
		''' <summary>
		''' �����D�D
		''' </summary>
		public Property NewTitle as string 
		Get
			 return m_strNewTitle 
		End Get
		Set(ByVal Value As string)
			 m_strNewTitle = value
		End Set
		End Property
		''' <summary>
		''' �������e
		''' </summary>
		public Property NewContent as string 
		Get
			 return m_strNewContent 
		End Get
		Set(ByVal Value As string)
			 m_strNewContent = value
		End Set
		End Property
		''' <summary>
		''' �ЫؤH��(�Τ�W/�u��)
		''' </summary>
		public Property CreateUser as string 
		Get
			 return m_strCreateUser 
		End Get
		Set(ByVal Value As string)
			 m_strCreateUser = value
		End Set
		End Property
		''' <summary>
		''' �ק�H��(�Τ�W/�u��)
		''' </summary>
		public Property ModifyUser as string 
		Get
			 return m_strModifyUser 
		End Get
		Set(ByVal Value As string)
			 m_strModifyUser = value
		End Set
		End Property
		''' <summary>
		''' �ק�ɶ�
		''' </summary>
		public Property ModifyTime as DateTime 
		Get
			return m_dtModifyTime 
		End Get
		Set(ByVal Value As DateTime)
			 m_dtModifyTime = value
		End Set
    End Property

    Public Property ServicePKID() As Integer
        Get
            Return m_ServicePKID
        End Get
        Set(ByVal value As Integer)
            m_ServicePKID = value
        End Set
    End Property
    Public Property ServiceName() As String
        Get
            Return m_ServiceName
        End Get
        Set(ByVal value As String)
            m_ServiceName = value
        End Set
    End Property
    Public Property EndTime() As Date
        Get
            Return m_EndTime
        End Get
        Set(ByVal value As Date)
            m_EndTime = value
        End Set
    End Property
		''' <summary>
		''' �w�d���1
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
		''' �w�d���2
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
		''' �w�d���3
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
		''' �O���Ыخɶ�
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
		''' �O���R���аO
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

