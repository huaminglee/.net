#Region "�ɤJ�R�W�Ŷ�"
Imports System
Imports System.Xml
Imports System.Xml.Serialization
Imports System.Runtime.Serialization
#End Region

''' <summary>�����</summary>
''' <remarks></remarks>
<Serializable()> _
Partial Public Class EquipManageInfo
#Region " Private Fields "
		private  m_iPKID as Integer
		private  m_deceFlowDocID as Guid
		private  m_iIsFinish as Integer
		private  m_iStateOrder as Integer
		private  m_strStateName as string
		private  m_strEquipName as string
		private  m_strControlNO as string
		private  m_strManuFacturer as string
		private  m_strEquipModel as string
		private  m_strSpecification as string
		private  m_strEquipDept as string
		private  m_strQyLocation as string
		private  m_strEquipLocation as string
		private  m_strKeepUser as string
		private  m_iIsHasDetail as Integer
		private  m_strRemark as string
		private  m_iIsHasFile as Integer
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
		''' �]�ƦW��
		''' </summary>
		public Property EquipName as string 
		Get
			 return m_strEquipName 
		End Get
		Set(ByVal Value As string)
			 m_strEquipName = value
		End Set
		End Property
		''' <summary>
		''' �ި�s��
		''' </summary>
		public Property ControlNO as string 
		Get
			 return m_strControlNO 
		End Get
		Set(ByVal Value As string)
			 m_strControlNO = value
		End Set
		End Property
		''' <summary>
		''' �t��
		''' </summary>
		public Property ManuFacturer as string 
		Get
			 return m_strManuFacturer 
		End Get
		Set(ByVal Value As string)
			 m_strManuFacturer = value
		End Set
		End Property
		''' <summary>
		''' ��������
		''' </summary>
		public Property EquipModel as string 
		Get
			 return m_strEquipModel 
		End Get
		Set(ByVal Value As string)
			 m_strEquipModel = value
		End Set
		End Property
		''' <summary>
		''' �D�n�W��
		''' </summary>
		public Property Specification as string 
		Get
			 return m_strSpecification 
		End Get
		Set(ByVal Value As string)
			 m_strSpecification = value
		End Set
		End Property
		''' <summary>
		''' ���ݹ����
		''' </summary>
		public Property EquipDept as string 
		Get
			 return m_strEquipDept 
		End Get
		Set(ByVal Value As string)
			 m_strEquipDept = value
		End Set
		End Property
		''' <summary>
		''' �ϰ��m
		''' </summary>
		public Property QyLocation as string 
		Get
			 return m_strQyLocation 
		End Get
		Set(ByVal Value As string)
			 m_strQyLocation = value
		End Set
		End Property
		''' <summary>
		''' ��m�a�I
		''' </summary>
		public Property EquipLocation as string 
		Get
			 return m_strEquipLocation 
		End Get
		Set(ByVal Value As string)
			 m_strEquipLocation = value
		End Set
		End Property
		''' <summary>
		''' �O�ޤH
		''' </summary>
		public Property KeepUser as string 
		Get
			 return m_strKeepUser 
		End Get
		Set(ByVal Value As string)
			 m_strKeepUser = value
		End Set
		End Property
		''' <summary>
		''' �O�_���]�ƪ���
		''' </summary>
		public Property IsHasDetail as Integer 
		Get
			return m_iIsHasDetail 
		End Get
		Set(ByVal Value As Integer)
			 m_iIsHasDetail = value
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
		''' �O�_������
		''' </summary>
		public Property IsHasFile as Integer 
		Get
			return m_iIsHasFile 
		End Get
		Set(ByVal Value As Integer)
			 m_iIsHasFile = value
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

