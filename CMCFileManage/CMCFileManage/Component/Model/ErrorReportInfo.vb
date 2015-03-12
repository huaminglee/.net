#Region "�ɤJ�R�W�Ŷ�"
Imports System
Imports System.Xml
Imports System.Xml.Serialization
Imports System.Runtime.Serialization
#End Region

''' <summary>�����</summary>
''' <remarks></remarks>
<Serializable()> _
Partial Public Class ErrorReportInfo
#Region " Private Fields "
		private  m_iPKID as Integer
		private  m_strReportBH as string
		private  m_strDept as string
		private  m_strQulocation as string
		private  m_strAduiter as string
		private  m_strFollower as string
		private  m_strSpecTitle as string
		private  m_strSpecVersion as string
    Private m_dtReportDate As DateTime = DateTime.MaxValue
		private  m_iAppSec as Integer
		private  m_strDescription as string
		private  m_strFindOut as string
		private  m_strReason as string
    Private m_dtFinishTime As DateTime = DateTime.MaxValue
		private  m_strReady as string
		private  m_strApprovedzg as string
		private  m_strFinishAduit as string
		private  m_iVertifyResult as Integer
		private  m_strResult as string
		private  m_strApproved as string
		private  m_strVertigyer as string
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
		''' �s��
		''' </summary>
		public Property ReportBH as string 
		Get
			 return m_strReportBH 
		End Get
		Set(ByVal Value As string)
			 m_strReportBH = value
		End Set
		End Property
		''' <summary>
		''' ����
		''' </summary>
		public Property Dept as string 
		Get
			 return m_strDept 
		End Get
		Set(ByVal Value As string)
			 m_strDept = value
		End Set
		End Property
		''' <summary>
		''' �ϰ��m
		''' </summary>
		public Property Qulocation as string 
		Get
			 return m_strQulocation 
		End Get
		Set(ByVal Value As string)
			 m_strQulocation = value
		End Set
		End Property
		''' <summary>
		''' �f�֪�
		''' </summary>
		public Property Aduiter as string 
		Get
			 return m_strAduiter 
		End Get
		Set(ByVal Value As string)
			 m_strAduiter = value
		End Set
		End Property
		''' <summary>
		''' ���H��
		''' </summary>
		public Property Follower as string 
		Get
			 return m_strFollower 
		End Get
		Set(ByVal Value As string)
			 m_strFollower = value
		End Set
		End Property
		''' <summary>
		''' �W���D��
		''' </summary>
		public Property SpecTitle as string 
		Get
			 return m_strSpecTitle 
		End Get
		Set(ByVal Value As string)
			 m_strSpecTitle = value
		End Set
		End Property
		''' <summary>
		''' �W�檩��
		''' </summary>
		public Property SpecVersion as string 
		Get
			 return m_strSpecVersion 
		End Get
		Set(ByVal Value As string)
			 m_strSpecVersion = value
		End Set
		End Property
		''' <summary>
		''' ���
		''' </summary>
		public Property ReportDate as DateTime 
		Get
			return m_dtReportDate 
		End Get
		Set(ByVal Value As DateTime)
			 m_dtReportDate = value
		End Set
		End Property
		''' <summary>
		''' ���γW��
		''' </summary>
		public Property AppSec as Integer 
		Get
			return m_iAppSec 
		End Get
		Set(ByVal Value As Integer)
			 m_iAppSec = value
		End Set
		End Property
		''' <summary>
		''' �y�z
		''' </summary>
		public Property Description as string 
		Get
			 return m_strDescription 
		End Get
		Set(ByVal Value As string)
			 m_strDescription = value
		End Set
		End Property
		''' <summary>
		''' �f�ֵo�{
		''' </summary>
		public Property FindOut as string 
		Get
			 return m_strFindOut 
		End Get
		Set(ByVal Value As string)
			 m_strFindOut = value
		End Set
		End Property
		''' <summary>
		''' ��]
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
		''' �������
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
		''' �w��
		''' </summary>
		public Property Ready as string 
		Get
			 return m_strReady 
		End Get
		Set(ByVal Value As string)
			 m_strReady = value
		End Set
		End Property
		''' <summary>
		''' �֭�]�D�ޡ^
		''' </summary>
		public Property Approvedzg as string 
		Get
			 return m_strApprovedzg 
		End Get
		Set(ByVal Value As string)
			 m_strApprovedzg = value
		End Set
		End Property
		''' <summary>
		''' �f��
		''' </summary>
		public Property FinishAduit as string 
		Get
			 return m_strFinishAduit 
		End Get
		Set(ByVal Value As string)
			 m_strFinishAduit = value
		End Set
		End Property
		''' <summary>
		''' ���ҵ��G
		''' </summary>
		public Property VertifyResult as Integer 
		Get
			return m_iVertifyResult 
		End Get
		Set(ByVal Value As Integer)
			 m_iVertifyResult = value
		End Set
		End Property
		''' <summary>
		''' ���G
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
		''' �֭�H
		''' </summary>
		public Property Approved as string 
		Get
			 return m_strApproved 
		End Get
		Set(ByVal Value As string)
			 m_strApproved = value
		End Set
		End Property
		''' <summary>
		''' ���ҤH
		''' </summary>
		public Property Vertigyer as string 
		Get
			 return m_strVertigyer 
		End Get
		Set(ByVal Value As string)
			 m_strVertigyer = value
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
		''' �O���R���аO0���`�F1�R��
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

