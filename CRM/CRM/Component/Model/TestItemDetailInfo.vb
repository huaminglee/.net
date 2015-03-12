#Region "�ɤJ�R�W�Ŷ�"
Imports System
Imports System.Xml
Imports System.Xml.Serialization
Imports System.Runtime.Serialization
#End Region

''' <summary>�����</summary>
''' <remarks></remarks>
<Serializable()> _
Partial Public Class TestItemDetailInfo
#Region " Private Fields "
    Private m_iPKID As Integer = 0
    Private m_iQuotationPKID As Integer = 0
    Private m_iSamplePKID As Integer = 0
    Private m_strServiceType As String = String.Empty
    Private m_iServicePKID As Integer = 0
    Private m_iTestItemPKID As Integer = 0
    Private m_strTestItemName As String = String.Empty
    Private m_iNumbers As Double = 0
    Private m_iBasicMoney As Integer = 0
    Private m_iPaijia As Integer = 0
    Private m_iShijidanjia As Integer = 0
    Private m_iShijizongjia As Double = 0
    Private m_strTestStandard As String = String.Empty
    Private m_strRemark As String = String.Empty
    Private m_strExtend01 As String = String.Empty
    Private m_strExtend02 As String = String.Empty
    Private m_strExtend03 As String = String.Empty
    Private m_strExtend04 As String = String.Empty
    Private m_strExtend05 As String = String.Empty
    Private m_strExtend06 As String = String.Empty
    Private m_strExtend07 As String = String.Empty
    Private m_strExtend08 As String = String.Empty
    Private m_strExtend09 As String = String.Empty
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
		''' ������PKID
		''' </summary>
		public Property QuotationPKID as Integer 
		Get
			return m_iQuotationPKID 
		End Get
		Set(ByVal Value As Integer)
			 m_iQuotationPKID = value
		End Set
		End Property
		''' <summary>
		''' �˫~��PKID
		''' </summary>
		public Property SamplePKID as Integer 
		Get
			return m_iSamplePKID 
		End Get
		Set(ByVal Value As Integer)
			 m_iSamplePKID = value
		End Set
		End Property
		''' <summary>
		''' �A������
		''' </summary>
		public Property ServiceType as string 
		Get
			 return m_strServiceType 
		End Get
		Set(ByVal Value As string)
			 m_strServiceType = value
		End Set
		End Property
		''' <summary>
		''' �A������PKID
		''' </summary>
		public Property ServicePKID as Integer 
		Get
			return m_iServicePKID 
		End Get
		Set(ByVal Value As Integer)
			 m_iServicePKID = value
		End Set
		End Property
		''' <summary>
		''' ���ն���PKID
		''' </summary>
		public Property TestItemPKID as Integer 
		Get
			return m_iTestItemPKID 
		End Get
		Set(ByVal Value As Integer)
			 m_iTestItemPKID = value
		End Set
		End Property
		''' <summary>
		''' ��������
		''' </summary>
		public Property TestItemName as string 
		Get
			 return m_strTestItemName 
		End Get
		Set(ByVal Value As string)
			 m_strTestItemName = value
		End Set
		End Property
		''' <summary>
		''' �ƶq
		''' </summary>
    Public Property Numbers() As Double
        Get
            Return m_iNumbers
        End Get
        Set(ByVal Value As Double)
            m_iNumbers = Value
        End Set
    End Property
		''' <summary>
		''' �򥻪�
		''' </summary>
		public Property BasicMoney as Integer 
		Get
			return m_iBasicMoney 
		End Get
		Set(ByVal Value As Integer)
			 m_iBasicMoney = value
		End Set
		End Property
		''' <summary>
		''' �P��
		''' </summary>
		public Property Paijia as Integer 
		Get
			return m_iPaijia 
		End Get
		Set(ByVal Value As Integer)
			 m_iPaijia = value
		End Set
		End Property
		''' <summary>
		''' ��ڳ��
		''' </summary>
		public Property Shijidanjia as Integer 
		Get
			return m_iShijidanjia 
		End Get
		Set(ByVal Value As Integer)
			 m_iShijidanjia = value
		End Set
		End Property
		''' <summary>
		''' ����`��
		''' </summary>
    Public Property Shijizongjia() As Double
        Get
            Return m_iShijizongjia
        End Get
        Set(ByVal Value As Double)
            m_iShijizongjia = Value
        End Set
    End Property
		''' <summary>
		''' ���ռз�
		''' </summary>
		public Property TestStandard as string 
		Get
			 return m_strTestStandard 
		End Get
		Set(ByVal Value As string)
			 m_strTestStandard = value
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
    ''' �P�����
		''' </summary>
		public Property Extend01 as string 
		Get
			 return m_strExtend01 
		End Get
		Set(ByVal Value As string)
			 m_strExtend01 = value
		End Set
		End Property
		''' <summary>
    ''' �����`��
		''' </summary>
		public Property Extend02 as string 
		Get
			 return m_strExtend02 
		End Get
		Set(ByVal Value As string)
			 m_strExtend02 = value
		End Set
		End Property
		''' <summary>
    ''' �������
		''' </summary>
		public Property Extend03 as string 
		Get
			 return m_strExtend03 
		End Get
		Set(ByVal Value As string)
			 m_strExtend03 = value
		End Set
		End Property
		''' <summary>
    ''' �򥻪�
		''' </summary>
		public Property Extend04 as string 
		Get
			 return m_strExtend04 
		End Get
		Set(ByVal Value As string)
			 m_strExtend04 = value
		End Set
		End Property
		''' <summary>
    ''' �����}�X��
		''' </summary>
		public Property Extend05 as string 
		Get
			 return m_strExtend05 
		End Get
		Set(ByVal Value As string)
			 m_strExtend05 = value
		End Set
    End Property
    ''' <summary>
    ''' �p�����
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property Extend06() As String
        Get
            Return m_strExtend06
        End Get
        Set(ByVal Value As String)
            m_strExtend06 = Value
        End Set
    End Property
    ''' <summary>
    ''' 
    ''' </summary>
    Public Property Extend07() As String
        Get
            Return m_strExtend07
        End Get
        Set(ByVal Value As String)
            m_strExtend07 = value
        End Set
    End Property
    ''' <summary>
    ''' 
    ''' </summary>
    Public Property Extend08() As String
        Get
            Return m_strExtend08
        End Get
        Set(ByVal Value As String)
            m_strExtend08 = value
        End Set
    End Property
    ''' <summary>
    ''' 
    ''' </summary>
    Public Property Extend09() As String
        Get
            Return m_strExtend09
        End Get
        Set(ByVal Value As String)
            m_strExtend09 = value
        End Set
    End Property
    ''' <summary>
    ''' 
    ''' </summary>
    Public Property Extend10() As String
        Get
            Return m_strExtend10
        End Get
        Set(ByVal Value As String)
            m_strExtend10 = value
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

