#Region "�ɤJ�R�W�Ŷ�"
Imports System
Imports System.Xml
Imports System.Xml.Serialization
Imports System.Runtime.Serialization
#End Region

''' <summary>�����</summary>
''' <remarks></remarks>
<Serializable()> _
Partial Public Class Record_ChangeHistoryInfo
#Region " Private Fields "
		private  m_iPKID as Integer
		private  m_strRecordPKID as string
		private  m_iChangeCategory as Integer
		private  m_strChangeUser as string
    Private m_dtChangeTime As DateTime = DateTime.MaxValue
		private  m_strChangeReason as string
		private  m_strExtend1 as string
		private  m_strExtend2 as string
		private  m_strExtend3 as string
		private  m_strExtend4 as string
		private  m_strExtend5 as string
    Private m_dtRecordCreated As DateTime = DateTime.MaxValue
		private  m_iRecordDeleted as Integer

#End Region

#Region " Public Properties"
		''' <summary>
		''' �ܧ�i��PKID
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
		''' �n�ܧ󪺰O��PKID
		''' </summary>
		public Property RecordPKID as string 
		Get
			 return m_strRecordPKID 
		End Get
		Set(ByVal Value As string)
			 m_strRecordPKID = value
		End Set
		End Property
		''' <summary>
		''' ?���?ID
		''' </summary>
		public Property ChangeCategory as Integer 
		Get
			return m_iChangeCategory 
		End Get
		Set(ByVal Value As Integer)
			 m_iChangeCategory = value
		End Set
		End Property
		''' <summary>
		''' �ܧ�H��
		''' </summary>
		public Property ChangeUser as string 
		Get
			 return m_strChangeUser 
		End Get
		Set(ByVal Value As string)
			 m_strChangeUser = value
		End Set
		End Property
		''' <summary>
		''' �ܧ�ɶ�
		''' </summary>
		public Property ChangeTime as DateTime 
		Get
			return m_dtChangeTime 
		End Get
		Set(ByVal Value As DateTime)
			 m_dtChangeTime = value
		End Set
		End Property
		''' <summary>
		''' ?���]
		''' </summary>
		public Property ChangeReason as string 
		Get
			 return m_strChangeReason 
		End Get
		Set(ByVal Value As string)
			 m_strChangeReason = value
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

