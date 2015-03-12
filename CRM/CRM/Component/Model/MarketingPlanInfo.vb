#Region "�ɤJ�R�W�Ŷ�"
Imports System
Imports System.Xml
Imports System.Xml.Serialization
Imports System.Runtime.Serialization
#End Region

''' <summary>�����</summary>
''' <remarks></remarks>
<Serializable()> _
Partial Public Class MarketingPlanInfo
#Region " Private Fields "
    Private m_iPKID As Integer = 0
    Private m_strInsertPerson As String = String.Empty
    Private m_strOwner As String = String.Empty
    Private m_strMarkPlanName As String = String.Empty
    Private m_strType As String = String.Empty
    Private m_strCategory As String = String.Empty
    Private m_dtStartDate As DateTime = DateTime.MaxValue
    Private m_dExcepedIncome As Double = 0
    Private m_dActualCosts As Double = 0
    Private m_iSendNums As Integer = 0
    Private m_iIsStarted As Integer = 0
    Private m_iResponseNums As Integer = 0
    Private m_dtEndDate As DateTime = DateTime.MaxValue
    Private m_dBudgetCost As Double = 0
    Private m_dExpectedRePercent As Double = 0
    Private m_strRemark As String = String.Empty
    Private m_strLastchange As String = String.Empty
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
    Private m_strExtend11 As String = String.Empty
    Private m_strExtend12 As String = String.Empty
    Private m_strExtend13 As String = String.Empty
    Private m_strExtend14 As String = String.Empty
    Private m_strExtend15 As String = String.Empty
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
		''' �s���H
		''' </summary>
		public Property InsertPerson as string 
		Get
			 return m_strInsertPerson 
		End Get
		Set(ByVal Value As string)
			 m_strInsertPerson = value
		End Set
		End Property
		''' <summary>
		''' �p���Ҧ��H
		''' </summary>
		public Property Owner as string 
		Get
			 return m_strOwner 
		End Get
		Set(ByVal Value As string)
			 m_strOwner = value
		End Set
		End Property
		''' <summary>
		''' �p���W
		''' </summary>
		public Property MarkPlanName as string 
		Get
			 return m_strMarkPlanName 
		End Get
		Set(ByVal Value As string)
			 m_strMarkPlanName = value
		End Set
		End Property
		''' <summary>
		''' ����
		''' </summary>
		public Property Type as string 
		Get
			 return m_strType 
		End Get
		Set(ByVal Value As string)
			 m_strType = value
		End Set
		End Property
		''' <summary>
		''' ���A
		''' </summary>
		public Property Category as string 
		Get
			 return m_strCategory 
		End Get
		Set(ByVal Value As string)
			 m_strCategory = value
		End Set
		End Property
		''' <summary>
		''' �}�l���
		''' </summary>
		public Property StartDate as DateTime 
		Get
			return m_dtStartDate 
		End Get
		Set(ByVal Value As DateTime)
			 m_dtStartDate = value
		End Set
		End Property
		''' <summary>
		''' �w�����J
		''' </summary>
		public Property ExcepedIncome as double 
		Get
			return m_dExcepedIncome 
		End Get
		Set(ByVal Value As double)
			 m_dExcepedIncome = value
		End Set
		End Property
		''' <summary>
		''' ��ڦ���
		''' </summary>
		public Property ActualCosts as double 
		Get
			return m_dActualCosts 
		End Get
		Set(ByVal Value As double)
			 m_dActualCosts = value
		End Set
		End Property
		''' <summary>
		''' �o�e��
		''' </summary>
		public Property SendNums as Integer 
		Get
			return m_iSendNums 
		End Get
		Set(ByVal Value As Integer)
			 m_iSendNums = value
		End Set
		End Property
		''' <summary>
		''' �O�_�Ұ�
		''' </summary>
		public Property IsStarted as Integer 
		Get
			return m_iIsStarted 
		End Get
		Set(ByVal Value As Integer)
			 m_iIsStarted = value
		End Set
		End Property
		''' <summary>
		''' �T����
		''' </summary>
		public Property ResponseNums as Integer 
		Get
			return m_iResponseNums 
		End Get
		Set(ByVal Value As Integer)
			 m_iResponseNums = value
		End Set
		End Property
		''' <summary>
		''' �������
		''' </summary>
		public Property EndDate as DateTime 
		Get
			return m_dtEndDate 
		End Get
		Set(ByVal Value As DateTime)
			 m_dtEndDate = value
		End Set
		End Property
		''' <summary>
		''' �w�⦨��
		''' </summary>
		public Property BudgetCost as double 
		Get
			return m_dBudgetCost 
		End Get
		Set(ByVal Value As double)
			 m_dBudgetCost = value
		End Set
		End Property
		''' <summary>
		''' �w���T���ʤ���
		''' </summary>
		public Property ExpectedRePercent as double 
		Get
			return m_dExpectedRePercent 
		End Get
		Set(ByVal Value As double)
			 m_dExpectedRePercent = value
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
		''' �W���ק�
		''' </summary>
		public Property Lastchange as string 
		Get
			 return m_strLastchange 
		End Get
		Set(ByVal Value As string)
			 m_strLastchange = value
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
		''' 
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
		''' 
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
		''' 
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
		''' 
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
		''' 
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
		''' 
		''' </summary>
		public Property Extend11 as string 
		Get
			 return m_strExtend11 
		End Get
		Set(ByVal Value As string)
			 m_strExtend11 = value
		End Set
		End Property
		''' <summary>
		''' 
		''' </summary>
		public Property Extend12 as string 
		Get
			 return m_strExtend12 
		End Get
		Set(ByVal Value As string)
			 m_strExtend12 = value
		End Set
		End Property
		''' <summary>
		''' 
		''' </summary>
		public Property Extend13 as string 
		Get
			 return m_strExtend13 
		End Get
		Set(ByVal Value As string)
			 m_strExtend13 = value
		End Set
		End Property
		''' <summary>
		''' 
		''' </summary>
		public Property Extend14 as string 
		Get
			 return m_strExtend14 
		End Get
		Set(ByVal Value As string)
			 m_strExtend14 = value
		End Set
		End Property
		''' <summary>
		''' 
		''' </summary>
		public Property Extend15 as string 
		Get
			 return m_strExtend15 
		End Get
		Set(ByVal Value As string)
			 m_strExtend15 = value
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

