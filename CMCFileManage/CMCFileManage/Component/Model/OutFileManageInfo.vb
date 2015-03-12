#Region "�ɤJ�R�W�Ŷ�"
Imports System
Imports System.Xml
Imports System.Xml.Serialization
Imports System.Runtime.Serialization
#End Region

''' <summary>�����</summary>
''' <remarks></remarks>
<Serializable()> _
Partial Public Class OutFileManageInfo
#Region " Private Fields "
		private  m_iPKID as Integer
		private  m_iRecordStype as Integer
		private  m_deceFlowDocID as Guid
		private  m_iIsFinish as Integer
		private  m_iStateOrder as Integer
		private  m_strStateName as string
		private  m_strFileBH as string
		private  m_strFileName as string
		private  m_strFileVersion as string
		private  m_iFilePageNum as Integer
		private  m_iFileNum as Integer
		private  m_strUseFor as string
		private  m_strUseForEquip as string
		private  m_strFileSource as string
		private  m_strQyLocation as string
		private  m_strFileDept as string
    Private m_dtBuyTime As DateTime = DateTime.MaxValue
		private  m_strBackAddress as string
		private  m_strRemark as string
		private  m_iSaveType as Integer
		private  m_iIsHasFile as Integer
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
		''' �O�����O(2:�Ȥ�W��/���խp��;3:���ծշǳn��;4:������;5�~�Ӥ��)
		''' </summary>
		public Property RecordStype as Integer 
		Get
			return m_iRecordStype 
		End Get
		Set(ByVal Value As Integer)
			 m_iRecordStype = value
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
		''' ���s��
		''' </summary>
		public Property FileBH as string 
		Get
			 return m_strFileBH 
		End Get
		Set(ByVal Value As string)
			 m_strFileBH = value
		End Set
		End Property
		''' <summary>
		''' ���W��
		''' </summary>
		public Property FileName as string 
		Get
			 return m_strFileName 
		End Get
		Set(ByVal Value As string)
			 m_strFileName = value
		End Set
		End Property
		''' <summary>
		''' ����
		''' </summary>
		public Property FileVersion as string 
		Get
			 return m_strFileVersion 
		End Get
		Set(ByVal Value As string)
			 m_strFileVersion = value
		End Set
		End Property
		''' <summary>
		''' ����
		''' </summary>
		public Property FilePageNum as Integer 
		Get
			return m_iFilePageNum 
		End Get
		Set(ByVal Value As Integer)
			 m_iFilePageNum = value
		End Set
		End Property
		''' <summary>
		''' ����
		''' </summary>
		public Property FileNum as Integer 
		Get
			return m_iFileNum 
		End Get
		Set(ByVal Value As Integer)
			 m_iFileNum = value
		End Set
		End Property
		''' <summary>
		''' �γ~
		''' </summary>
		public Property UseFor as string 
		Get
			 return m_strUseFor 
		End Get
		Set(ByVal Value As string)
			 m_strUseFor = value
		End Set
		End Property
		''' <summary>
		''' �A�γ]��
		''' </summary>
		public Property UseForEquip as string 
		Get
			 return m_strUseForEquip 
		End Get
		Set(ByVal Value As string)
			 m_strUseForEquip = value
		End Set
		End Property
		''' <summary>
		''' ���ӷ�
		''' </summary>
		public Property FileSource as string 
		Get
			 return m_strFileSource 
		End Get
		Set(ByVal Value As string)
			 m_strFileSource = value
		End Set
		End Property
		''' <summary>
		''' �ϰ�
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
		''' ���ݹ����
		''' </summary>
		public Property FileDept as string 
		Get
			 return m_strFileDept 
		End Get
		Set(ByVal Value As string)
			 m_strFileDept = value
		End Set
		End Property
		''' <summary>
		''' �ʶR�ɶ�
		''' </summary>
		public Property BuyTime as DateTime 
		Get
			return m_dtBuyTime 
		End Get
		Set(ByVal Value As DateTime)
			 m_dtBuyTime = value
		End Set
		End Property
		''' <summary>
		''' �ƥ��a�}
		''' </summary>
		public Property BackAddress as string 
		Get
			 return m_strBackAddress 
		End Get
		Set(ByVal Value As string)
			 m_strBackAddress = value
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
		''' �s�x�覡0�L1����2�q�l��3���
		''' </summary>
		public Property SaveType as Integer 
		Get
			return m_iSaveType 
		End Get
		Set(ByVal Value As Integer)
			 m_iSaveType = value
		End Set
		End Property
		''' <summary>
		''' 
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
    ''' �O�_Notes�ɤJ
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

