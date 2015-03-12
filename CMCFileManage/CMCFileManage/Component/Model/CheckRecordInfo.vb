#Region "�ɤJ�R�W�Ŷ�"
Imports System
Imports System.Xml
Imports System.Xml.Serialization
Imports System.Runtime.Serialization
#End Region

''' <summary>�����</summary>
''' <remarks></remarks>
<Serializable()> _
Partial Public Class CheckRecordInfo
#Region " Private Fields "
    Private m_iPKID As Integer = 0
    Private m_iParentPKID As Integer = 0
    Private m_iType As Integer = 0
    Private m_dtCheckDate As DateTime = DateTime.MaxValue
    Private m_iQuality As Integer = 0
    Private m_iService As Integer = 0
    Private m_iDelivery As Integer = 0
    Private m_strOthers As String = String.Empty
    Private m_iIsOK As Integer = 0
    Private m_strCheckPerson As String = String.Empty
    Private m_strRemark As String = String.Empty
    Private m_strExtend1 As String = String.Empty
    Private m_strExtend2 As String = String.Empty
    Private m_strExtend3 As String = String.Empty
    Private m_strExtend4 As String = String.Empty
    Private m_strExtend5 As String = String.Empty
    Private m_strExtend6 As String = String.Empty
    Private m_strExtend7 As String = String.Empty
    Private m_strExtend8 As String = String.Empty
    Private m_strExtend9 As String = String.Empty
    Private m_strExtend10 As String = String.Empty
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
		''' 
		''' </summary>
		public Property ParentPKID as Integer 
		Get
			return m_iParentPKID 
		End Get
		Set(ByVal Value As Integer)
			 m_iParentPKID = value
		End Set
		End Property
		''' <summary>
		''' 
		''' </summary>
		public Property Type as Integer 
		Get
			return m_iType 
		End Get
		Set(ByVal Value As Integer)
			 m_iType = value
		End Set
		End Property
		''' <summary>
		''' �������
		''' </summary>
		public Property CheckDate as DateTime 
		Get
			return m_dtCheckDate 
		End Get
		Set(ByVal Value As DateTime)
			 m_dtCheckDate = value
		End Set
		End Property
		''' <summary>
		''' �~��
		''' </summary>
		public Property Quality as Integer 
		Get
			return m_iQuality 
		End Get
		Set(ByVal Value As Integer)
			 m_iQuality = value
		End Set
		End Property
		''' <summary>
		''' �A��
		''' </summary>
		public Property Service as Integer 
		Get
			return m_iService 
		End Get
		Set(ByVal Value As Integer)
			 m_iService = value
		End Set
		End Property
		''' <summary>
		''' ��f
		''' </summary>
		public Property Delivery as Integer 
		Get
			return m_iDelivery 
		End Get
		Set(ByVal Value As Integer)
			 m_iDelivery = value
		End Set
		End Property
		''' <summary>
		''' ��L
		''' </summary>
		public Property Others as string 
		Get
			 return m_strOthers 
		End Get
		Set(ByVal Value As string)
			 m_strOthers = value
		End Set
		End Property
		''' <summary>
		''' �X��P�w
		''' </summary>
		public Property IsOK as Integer 
		Get
			return m_iIsOK 
		End Get
		Set(ByVal Value As Integer)
			 m_iIsOK = value
		End Set
		End Property
		''' <summary>
		''' �����H
		''' </summary>
		public Property CheckPerson as string 
		Get
			 return m_strCheckPerson 
		End Get
		Set(ByVal Value As string)
			 m_strCheckPerson = value
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
		''' �w�d���
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
		''' �w�d���
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
		''' �w�d���10�s�����pkid
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

