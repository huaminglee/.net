#Region "�ɤJ�R�W�Ŷ�"
Imports System
Imports System.Xml
Imports System.Xml.Serialization
Imports System.Runtime.Serialization
#End Region

''' <summary>�����</summary>
''' <remarks></remarks>
<Serializable()> _
Partial Public Class FileReadManageInfo
#Region " Private Fields "
		private  m_iPKID as Integer
		private  m_deceFlowDocID as Guid
		private  m_iIsFinish as Integer
		private  m_iStateOrder as Integer
		private  m_strStateName as string
		private  m_strApplyUser as string
		private  m_strReadDept as string
		private  m_strApplyTime as string
		private  m_strUseUserOrDept as string
		private  m_strLeaderUser as string
		private  m_strRemark as string
		private  m_strAduitUser as string
    Private m_dtAduitTime As DateTime = DateTime.MaxValue
		private  m_strFileHandle as string
		private  m_iIsBack as Integer
		private  m_strApplyConfirmInfo as string
		private  m_strDealwithUser as string
    Private m_dtDealWithTime As DateTime = DateTime.MaxValue
		private  m_strDealRemark as string
		private  m_strExtend1 as string
		private  m_strExtend2 as string
		private  m_strExtend3 as string
		private  m_strExtend4 as string
		private  m_strExtend5 as string
		private  m_strExtend6 as string
		private  m_strExtend7 as string
		private  m_strExtend8 as string
		private  m_strExtend9 as string
		private  m_strExtend10 as string
    Private m_dtRecordCreated As DateTime = DateTime.MaxValue
		private  m_iRecordDeleted as Integer

#End Region

#Region " Public Properties"
		''' <summary>
		''' �O���s��
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
		''' �O�_����
		''' </summary>
		public Property IsFinish as Integer 
		Get
			return m_iIsFinish 
		End Get
		Set(ByVal Value As Integer)
			 m_iIsFinish = value
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
		''' �ӽФH
		''' </summary>
		public Property ApplyUser as string 
		Get
			 return m_strApplyUser 
		End Get
		Set(ByVal Value As string)
			 m_strApplyUser = value
		End Set
		End Property
		''' <summary>
		''' ���ݳ��
		''' </summary>
		public Property ReadDept as string 
		Get
			 return m_strReadDept 
		End Get
		Set(ByVal Value As string)
			 m_strReadDept = value
		End Set
		End Property
		''' <summary>
		''' �ӽФ��
		''' </summary>
		public Property ApplyTime as string 
		Get
			 return m_strApplyTime 
		End Get
		Set(ByVal Value As string)
			 m_strApplyTime = value
		End Set
		End Property
		''' <summary>
		''' �ϥΤH�γ��
		''' </summary>
		public Property UseUserOrDept as string 
		Get
			 return m_strUseUserOrDept 
		End Get
		Set(ByVal Value As string)
			 m_strUseUserOrDept = value
		End Set
		End Property
		''' <summary>
		''' �D�޼f��(�H���W��/�ɶ�)
		''' </summary>
		public Property LeaderUser as string 
		Get
			 return m_strLeaderUser 
		End Get
		Set(ByVal Value As string)
			 m_strLeaderUser = value
		End Set
		End Property
		''' <summary>
		''' �Ƶ�
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
		''' ��ǤH��
		''' </summary>
		public Property AduitUser as string 
		Get
			 return m_strAduitUser 
		End Get
		Set(ByVal Value As string)
			 m_strAduitUser = value
		End Set
		End Property
		''' <summary>
		''' ��Ǥ��
		''' </summary>
		public Property AduitTime as DateTime 
		Get
			return m_dtAduitTime 
		End Get
		Set(ByVal Value As DateTime)
			 m_dtAduitTime = value
		End Set
		End Property
		''' <summary>
		''' ���B�z
		''' </summary>
		public Property FileHandle as string 
		Get
			 return m_strFileHandle 
		End Get
		Set(ByVal Value As string)
			 m_strFileHandle = value
		End Set
		End Property
		''' <summary>
		''' �O�_�k��
		''' </summary>
		public Property IsBack as Integer 
		Get
			return m_iIsBack 
		End Get
		Set(ByVal Value As Integer)
			 m_iIsBack = value
		End Set
		End Property
		''' <summary>
		''' �ӽФHñ��/���
		''' </summary>
		public Property ApplyConfirmInfo as string 
		Get
			 return m_strApplyConfirmInfo 
		End Get
		Set(ByVal Value As string)
			 m_strApplyConfirmInfo = value
		End Set
		End Property
		''' <summary>
		''' �ӿ�H
		''' </summary>
		public Property DealwithUser as string 
		Get
			 return m_strDealwithUser 
		End Get
		Set(ByVal Value As string)
			 m_strDealwithUser = value
		End Set
		End Property
		''' <summary>
		''' �ӿ���
		''' </summary>
		public Property DealWithTime as DateTime 
		Get
			return m_dtDealWithTime 
		End Get
		Set(ByVal Value As DateTime)
			 m_dtDealWithTime = value
		End Set
		End Property
		''' <summary>
		''' �ƪ`
		''' </summary>
		public Property DealRemark as string 
		Get
			 return m_strDealRemark 
		End Get
		Set(ByVal Value As string)
			 m_strDealRemark = value
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
		''' �w�d���6
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
		''' �w�d���7
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
		''' �w�d���8
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
		''' �w�d���9
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
		''' �w�d���10
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

