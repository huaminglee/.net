#Region "�ɤJ�R�W�Ŷ�"
Imports System
Imports System.Xml
Imports System.Xml.Serialization
Imports System.Runtime.Serialization
#End Region

''' <summary>�����</summary>
''' <remarks></remarks>
<Serializable()> _
Partial Public Class QC_UserParameterInfo
#Region " Private Fields "
		private  m_iPKID as Integer
		private  m_strParameterCategory as string
		private  m_strParameterText as string
		private  m_strParameterValue1 as string
		private  m_strParameterValue2 as string
		private  m_iDispalyOrder as Integer
		private  m_strExtend1 as string
		private  m_strExtend2 as string
		private  m_strExtend3 as string
		private  m_strExtend4 as string
		private  m_strExtend5 as string
		private  m_dtRecordCreated as DateTime
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
		''' �Ѽ����O
		''' </summary>
		public Property ParameterCategory as string 
		Get
			 return m_strParameterCategory 
		End Get
		Set(ByVal Value As string)
			 m_strParameterCategory = value
		End Set
		End Property
		''' <summary>
		''' �Ѽ�Text
		''' </summary>
		public Property ParameterText as string 
		Get
			 return m_strParameterText 
		End Get
		Set(ByVal Value As string)
			 m_strParameterText = value
		End Set
		End Property
		''' <summary>
		''' �Ѽ�Value
		''' </summary>
		public Property ParameterValue1 as string 
		Get
			 return m_strParameterValue1 
		End Get
		Set(ByVal Value As string)
			 m_strParameterValue1 = value
		End Set
		End Property
		''' <summary>
		''' 
		''' </summary>
		public Property ParameterValue2 as string 
		Get
			 return m_strParameterValue2 
		End Get
		Set(ByVal Value As string)
			 m_strParameterValue2 = value
		End Set
		End Property
		''' <summary>
		''' ��ܶ���
		''' </summary>
		public Property DispalyOrder as Integer 
		Get
			return m_iDispalyOrder 
		End Get
		Set(ByVal Value As Integer)
			 m_iDispalyOrder = value
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

