#Region "�ɤJ�R�W�Ŷ�"
Imports System
Imports System.Xml
Imports System.Xml.Serialization
Imports System.Runtime.Serialization
#End Region

''' <summary>�����</summary>
''' <remarks></remarks>
<Serializable()> _
Partial Public Class ComplaintsInfo
#Region " Private Fields "
		private  m_iPKID as Integer
		private  m_deceFlowDocID as Guid
		private  m_strRecordNO as string
		private  m_iStateOrder as Integer
		private  m_strStateName as string
		private  m_strQyuLocation as string
		private  m_strComlaintsPerson as string
		private  m_strComplaintsDept as string
		private  m_strComplaintsPosition as string
		private  m_strBeComplaintsDept as string
    Private m_dtComplaintsDate As DateTime = DateTime.MaxValue
    Private m_dtHopeFinishTime As DateTime = DateTime.MaxValue
		private  m_strPhone as string
		private  m_strEmail as string
		private  m_strComplaintsDesc as string
		private  m_strComplaintsDetailed as string
		private  m_strFindings as string
		private  m_strReasons as string
		private  m_strImprove as string
		private  m_strHinding as string
    Private m_iIsFinished As Integer = 0
		private  m_strApproved as string
		private  m_strUnderTake as string
		private  m_strExtend1 as string
		private  m_strExtend2 as string
		private  m_strExtend3 as string
		private  m_strExtend4 as string
		private  m_strExtend5 as string
		private  m_iRecordDeleted as Integer
    Private m_dtRecordCreated As DateTime = DateTime.MaxValue

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
		''' �y�{���ID
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
		''' �O���s��
		''' </summary>
		public Property RecordNO as string 
		Get
			 return m_strRecordNO 
		End Get
		Set(ByVal Value As string)
			 m_strRecordNO = value
		End Set
		End Property
		''' <summary>
		''' ���ݪ��ANum
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
		''' ���A�W��
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
		''' 
		''' </summary>
		public Property QyuLocation as string 
		Get
			 return m_strQyuLocation 
		End Get
		Set(ByVal Value As string)
			 m_strQyuLocation = value
		End Set
		End Property
		''' <summary>
		''' 
		''' </summary>
		public Property ComlaintsPerson as string 
		Get
			 return m_strComlaintsPerson 
		End Get
		Set(ByVal Value As string)
			 m_strComlaintsPerson = value
		End Set
		End Property
		''' <summary>
		''' ��D�Ի~
		''' </summary>
		public Property ComplaintsDept as string 
		Get
			 return m_strComplaintsDept 
		End Get
		Set(ByVal Value As string)
			 m_strComplaintsDept = value
		End Set
		End Property
		''' <summary>
		''' ��D�H¾��
		''' </summary>
		public Property ComplaintsPosition as string 
		Get
			 return m_strComplaintsPosition 
		End Get
		Set(ByVal Value As string)
			 m_strComplaintsPosition = value
		End Set
		End Property
		''' <summary>
		''' �Q��D���
		''' </summary>
		public Property BeComplaintsDept as string 
		Get
			 return m_strBeComplaintsDept 
		End Get
		Set(ByVal Value As string)
			 m_strBeComplaintsDept = value
		End Set
		End Property
		''' <summary>
		''' ��D���
		''' </summary>
		public Property ComplaintsDate as DateTime 
		Get
			return m_dtComplaintsDate 
		End Get
		Set(ByVal Value As DateTime)
			 m_dtComplaintsDate = value
		End Set
		End Property
		''' <summary>
		''' ���槹�����
		''' </summary>
		public Property HopeFinishTime as DateTime 
		Get
			return m_dtHopeFinishTime 
		End Get
		Set(ByVal Value As DateTime)
			 m_dtHopeFinishTime = value
		End Set
		End Property
		''' <summary>
		''' �q��
		''' </summary>
		public Property Phone as string 
		Get
			 return m_strPhone 
		End Get
		Set(ByVal Value As string)
			 m_strPhone = value
		End Set
		End Property
		''' <summary>
		''' Email
		''' </summary>
		public Property Email as string 
		Get
			 return m_strEmail 
		End Get
		Set(ByVal Value As string)
			 m_strEmail = value
		End Set
		End Property
		''' <summary>
		''' ��D�ƶ�²�z
		''' </summary>
		public Property ComplaintsDesc as string 
		Get
			 return m_strComplaintsDesc 
		End Get
		Set(ByVal Value As string)
			 m_strComplaintsDesc = value
		End Set
		End Property
		''' <summary>
		''' ��D�ƶ�
		''' </summary>
		public Property ComplaintsDetailed as string 
		Get
			 return m_strComplaintsDetailed 
		End Get
		Set(ByVal Value As string)
			 m_strComplaintsDetailed = value
		End Set
		End Property
		''' <summary>
		''' �լd
		''' </summary>
		public Property Findings as string 
		Get
			 return m_strFindings 
		End Get
		Set(ByVal Value As string)
			 m_strFindings = value
		End Set
		End Property
		''' <summary>
		''' ��]
		''' </summary>
		public Property Reasons as string 
		Get
			 return m_strReasons 
		End Get
		Set(ByVal Value As string)
			 m_strReasons = value
		End Set
		End Property
		''' <summary>
		''' �ﵽ�ﵦ
		''' </summary>
		public Property Improve as string 
		Get
			 return m_strImprove 
		End Get
		Set(ByVal Value As string)
			 m_strImprove = value
		End Set
		End Property
		''' <summary>
		''' �B�z
		''' </summary>
		public Property Hinding as string 
		Get
			 return m_strHinding 
		End Get
		Set(ByVal Value As string)
			 m_strHinding = value
		End Set
		End Property
		''' <summary>
		''' �O�_����
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
		''' �֭�
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
		''' �ӿ�
		''' </summary>
		public Property UnderTake as string 
		Get
			 return m_strUnderTake 
		End Get
		Set(ByVal Value As string)
			 m_strUnderTake = value
		End Set
		End Property
		''' <summary>
		''' �w�d
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
		''' �w�d
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
		''' �w�d
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
		''' �w�d
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
    ''' Notes�ɤJ
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
		''' �R���Ч�( 1�n�R)
		''' </summary>
		public Property RecordDeleted as Integer 
		Get
			return m_iRecordDeleted 
		End Get
		Set(ByVal Value As Integer)
			 m_iRecordDeleted = value
		End Set
		End Property
		''' <summary>
		''' �O���ͦ��ɶ�
		''' </summary>
		public Property RecordCreated as DateTime 
		Get
			return m_dtRecordCreated 
		End Get
		Set(ByVal Value As DateTime)
			 m_dtRecordCreated = value
		End Set
		End Property

#End Region
End Class

