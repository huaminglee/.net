#Region "�ɤJ�R�W�Ŷ�"
Imports System
Imports System.Xml
Imports System.Xml.Serialization
Imports System.Runtime.Serialization
#End Region

''' <summary>�����</summary>
''' <remarks></remarks>
<Serializable()> _
Partial Public Class CustomerGradeChangeRecordInfo
#Region " Private Fields "
    Private m_iPKID As Integer = 0
    Private m_iCustomerPKID As Integer = 0
    Private m_strChangePerson As String = String.Empty
    Private m_strOldGrade As String = String.Empty
    Private m_strNewGrade As String = String.Empty
    Private m_strReason As String = String.Empty
    Private m_strExtend1 As String = String.Empty
    Private m_strExtend2 As String = String.Empty
    Private m_strExtend3 As String = String.Empty
    Private m_strExtend4 As String = String.Empty
    Private m_strExtend5 As String = String.Empty
    Private m_dtRecordCreated As DateTime = DateTime.Now
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
		''' �Ȥ�PKID
		''' </summary>
		public Property CustomerPKID as Integer 
		Get
			return m_iCustomerPKID 
		End Get
		Set(ByVal Value As Integer)
			 m_iCustomerPKID = value
		End Set
		End Property
		''' <summary>
		''' �ܧ�H(�m�W/�n���W)
		''' </summary>
		public Property ChangePerson as string 
		Get
			 return m_strChangePerson 
		End Get
		Set(ByVal Value As string)
			 m_strChangePerson = value
		End Set
		End Property
		''' <summary>
		''' �쵥��
		''' </summary>
		public Property OldGrade as string 
		Get
			 return m_strOldGrade 
		End Get
		Set(ByVal Value As string)
			 m_strOldGrade = value
		End Set
		End Property
		''' <summary>
		''' �s����
		''' </summary>
		public Property NewGrade as string 
		Get
			 return m_strNewGrade 
		End Get
		Set(ByVal Value As string)
			 m_strNewGrade = value
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
		''' �w�ȥ�,0:�ӽФH��g�����ն���,1:����Z��g�����ն���
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
		''' �w�ȥ�,��������ǱM��,�w����첧�`�B�z�t�μлx��,1���w����
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
		''' �w����,�s���Ҥj�p
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
		''' �O���Юɶ�
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
		''' �O���R���лx
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

