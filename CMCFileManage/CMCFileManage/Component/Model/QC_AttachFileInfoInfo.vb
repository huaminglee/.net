#Region "�ɤJ�R�W�Ŷ�"
Imports System
Imports System.Xml
Imports System.Xml.Serialization
Imports System.Runtime.Serialization
#End Region

''' <summary>�����</summary>
''' <remarks></remarks>
<Serializable()> _
Partial Public Class QC_AttachFileInfoInfo
#Region " Private Fields "
		private  m_iFileID as Integer
		private  m_strParentID as string
		private  m_iParentCategory as Integer
		private  m_iParentSubCategory as Integer
		private  m_decFileGuID as Guid
		private  m_strFileName as string
		private  m_strFileExtension as string
		private  m_iFileSize as Integer
		private  m_strFileClientName as string
		private  m_strExtend1 as string
		private  m_strExtend2 as string
		private  m_strExtend3 as string
		private  m_strExtend4 as string
		private  m_strExtend5 as string
		private  m_strRecordVersion as string
		private  m_dtRecordCreateTime as DateTime
		private  m_iRecordDeleted as Integer

#End Region

#Region " Public Properties"
		''' <summary>
		''' ����PKID
		''' </summary>
		public Property FileID as Integer 
		Get
			return m_iFileID 
		End Get
		Set(ByVal Value As Integer)
			 m_iFileID = value
		End Set
		End Property
		''' <summary>
		''' ����D��s��
		''' </summary>
		public Property ParentID as string 
		Get
			 return m_strParentID 
		End Get
		Set(ByVal Value As string)
			 m_strParentID = value
		End Set
		End Property
		''' <summary>
		''' �������O(���P�Ҳժ��󪺰Ϥ�)
		''' </summary>
		public Property ParentCategory as Integer 
		Get
			return m_iParentCategory 
		End Get
		Set(ByVal Value As Integer)
			 m_iParentCategory = value
		End Set
		End Property
		''' <summary>
		''' ���i�l���O
		''' </summary>
		public Property ParentSubCategory as Integer 
		Get
			return m_iParentSubCategory 
		End Get
		Set(ByVal Value As Integer)
			 m_iParentSubCategory = value
		End Set
		End Property
		''' <summary>
		''' ����GuID
		''' </summary>
		public Property FileGuID as Guid 
		Get
			return m_decFileGuID 
		End Get
		Set(ByVal Value As Guid)
			 m_decFileGuID = value
		End Set
		End Property
		''' <summary>
		''' ����W��
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
		''' ��������
		''' </summary>
		public Property FileExtension as string 
		Get
			 return m_strFileExtension 
		End Get
		Set(ByVal Value As string)
			 m_strFileExtension = value
		End Set
		End Property
		''' <summary>
		''' ����j�p
		''' </summary>
		public Property FileSize as Integer 
		Get
			return m_iFileSize 
		End Get
		Set(ByVal Value As Integer)
			 m_iFileSize = value
		End Set
		End Property
		''' <summary>
		''' ����Ȥ�ݦW��
		''' </summary>
		public Property FileClientName as string 
		Get
			 return m_strFileClientName 
		End Get
		Set(ByVal Value As string)
			 m_strFileClientName = value
		End Set
		End Property
		''' <summary>
		''' �X�i���1
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
		''' �X�i���2
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
		''' �X�i���3
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
		''' �X�i���4
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
		''' �w���Ρ]�s���`�O����s���γ��i�ܧ�O���^
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
		''' �O������
		''' </summary>
		public Property RecordVersion as string 
		Get
			 return m_strRecordVersion 
		End Get
		Set(ByVal Value As string)
			 m_strRecordVersion = value
		End Set
		End Property
		''' <summary>
		''' �O���Ыخɶ�
		''' </summary>
		public Property RecordCreateTime as DateTime 
		Get
			return m_dtRecordCreateTime 
		End Get
		Set(ByVal Value As DateTime)
			 m_dtRecordCreateTime = value
		End Set
		End Property
		''' <summary>
		''' �O���R���аO(0:1)
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

