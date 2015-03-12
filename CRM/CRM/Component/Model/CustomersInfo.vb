#Region "�ɤJ�R�W�Ŷ�"
Imports System
Imports System.Xml
Imports System.Xml.Serialization
Imports System.Runtime.Serialization
#End Region

''' <summary>�����</summary>
''' <remarks></remarks>
<Serializable()> _
Partial Public Class CustomersInfo
#Region " Private Fields "
    Private m_iPKID As Integer = 0
    Private m_strInsertPsrson As String = String.Empty
    Private m_strCustomerName As String = String.Empty
    Private m_strCustomerID As String = String.Empty
    Private m_strCustomerAlias As String = String.Empty
    Private m_strCustomerEnglishName As String = String.Empty
    Private m_iCategory As Integer = 0
    Private m_strPersonInCharge As String = String.Empty
    Private m_strManagers As String = String.Empty
    Private m_strGrade As String = String.Empty
    Private m_iTypeofPay As Integer = 0
    Private m_strIndustry As String = String.Empty
    Private m_iStatus As Integer = 0
    Private m_strSource As String = String.Empty
    Private m_strCity As String = String.Empty
    Private m_iZipCode As Integer = 0
    Private m_strPhone As String = String.Empty
    Private m_strFax As String = String.Empty
    Private m_strEmail As String = String.Empty
    Private m_strWebAddress As String = String.Empty
    Private m_strAddress As String = String.Empty
    Private m_iZhuceCapital As Integer = 0
    Private m_iEmployeeNum As Integer = 0
    Private m_strBank As String = String.Empty
    Private m_strBankAccount As String = String.Empty
    Private m_strAccountName As String = String.Empty
    Private m_strBillingName As String = String.Empty
    Private m_strVATNum As String = String.Empty
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
		''' �Ȥ��D��
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
		''' �K�[�H
		''' </summary>
		public Property InsertPsrson as string 
		Get
			 return m_strInsertPsrson 
		End Get
		Set(ByVal Value As string)
			 m_strInsertPsrson = value
		End Set
		End Property
		''' <summary>
		''' �Ȥ�W
		''' </summary>
		public Property CustomerName as string 
		Get
			 return m_strCustomerName 
		End Get
		Set(ByVal Value As string)
			 m_strCustomerName = value
		End Set
		End Property
		''' <summary>
		''' �Ȥ�s��
		''' </summary>
		public Property CustomerID as string 
		Get
			 return m_strCustomerID 
		End Get
		Set(ByVal Value As string)
			 m_strCustomerID = value
		End Set
		End Property
		''' <summary>
		''' �Ȥ�O�W
		''' </summary>
		public Property CustomerAlias as string 
		Get
			 return m_strCustomerAlias 
		End Get
		Set(ByVal Value As string)
			 m_strCustomerAlias = value
		End Set
		End Property
		''' <summary>
		''' �Ȥ�^��W
		''' </summary>
		public Property CustomerEnglishName as string 
		Get
			 return m_strCustomerEnglishName 
		End Get
		Set(ByVal Value As string)
			 m_strCustomerEnglishName = value
		End Set
		End Property
		''' <summary>
		''' �Ȥ����O�]1�G����2�G�~���^
		''' </summary>
		public Property Category as Integer 
		Get
			return m_iCategory 
		End Get
		Set(ByVal Value As Integer)
			 m_iCategory = value
		End Set
		End Property
		''' <summary>
		''' �t�d�H
		''' </summary>
		public Property PersonInCharge as string 
		Get
			 return m_strPersonInCharge 
		End Get
		Set(ByVal Value As string)
			 m_strPersonInCharge = value
		End Set
		End Property
		''' <summary>
		''' �g��H
		''' </summary>
		public Property Managers as string 
		Get
			 return m_strManagers 
		End Get
		Set(ByVal Value As string)
			 m_strManagers = value
		End Set
		End Property
		''' <summary>
		''' �Ȥ�ŧO
		''' </summary>
		public Property Grade as string 
		Get
			 return m_strGrade 
		End Get
		Set(ByVal Value As string)
			 m_strGrade = value
		End Set
		End Property
		''' <summary>
		''' �I�ڤ覡(1:��2�G��3�G�u4�G�~)
		''' </summary>
		public Property TypeofPay as Integer 
		Get
			return m_iTypeofPay 
		End Get
		Set(ByVal Value As Integer)
			 m_iTypeofPay = value
		End Set
		End Property
		''' <summary>
		''' ��~
		''' </summary>
		public Property Industry as string 
		Get
			 return m_strIndustry 
		End Get
		Set(ByVal Value As string)
			 m_strIndustry = value
		End Set
		End Property
		''' <summary>
		''' �Ȥ᪬�A
		''' </summary>
		public Property Status as Integer 
		Get
			return m_iStatus 
		End Get
		Set(ByVal Value As Integer)
			 m_iStatus = value
		End Set
		End Property
		''' <summary>
		''' �ӷ�
		''' </summary>
		public Property Source as string 
		Get
			 return m_strSource 
		End Get
		Set(ByVal Value As string)
			 m_strSource = value
		End Set
		End Property
		''' <summary>
		''' �����ϰ�
		''' </summary>
		public Property City as string 
		Get
			 return m_strCity 
		End Get
		Set(ByVal Value As string)
			 m_strCity = value
		End Set
		End Property
		''' <summary>
		''' �l�F���X
		''' </summary>
		public Property ZipCode as Integer 
		Get
			return m_iZipCode 
		End Get
		Set(ByVal Value As Integer)
			 m_iZipCode = value
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
		''' �ǯu
		''' </summary>
		public Property Fax as string 
		Get
			 return m_strFax 
		End Get
		Set(ByVal Value As string)
			 m_strFax = value
		End Set
		End Property
		''' <summary>
		''' �l�c
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
		''' ���}
		''' </summary>
		public Property WebAddress as string 
		Get
			 return m_strWebAddress 
		End Get
		Set(ByVal Value As string)
			 m_strWebAddress = value
		End Set
		End Property
		''' <summary>
		''' �a�}
		''' </summary>
		public Property Address as string 
		Get
			 return m_strAddress 
		End Get
		Set(ByVal Value As string)
			 m_strAddress = value
		End Set
		End Property
		''' <summary>
		''' ���U���
		''' </summary>
		public Property ZhuceCapital as Integer 
		Get
			return m_iZhuceCapital 
		End Get
		Set(ByVal Value As Integer)
			 m_iZhuceCapital = value
		End Set
		End Property
		''' <summary>
		''' ���u��
		''' </summary>
		public Property EmployeeNum as Integer 
		Get
			return m_iEmployeeNum 
		End Get
		Set(ByVal Value As Integer)
			 m_iEmployeeNum = value
		End Set
		End Property
		''' <summary>
		''' �}��Ȧ�
		''' </summary>
		public Property Bank as string 
		Get
			 return m_strBank 
		End Get
		Set(ByVal Value As string)
			 m_strBank = value
		End Set
		End Property
		''' <summary>
		''' �Ȧ�b��
		''' </summary>
		public Property BankAccount as string 
		Get
			 return m_strBankAccount 
		End Get
		Set(ByVal Value As string)
			 m_strBankAccount = value
		End Set
		End Property
		''' <summary>
		''' �}��W��
		''' </summary>
		public Property AccountName as string 
		Get
			 return m_strAccountName 
		End Get
		Set(ByVal Value As string)
			 m_strAccountName = value
		End Set
		End Property
		''' <summary>
		''' �}���W��
		''' </summary>
		public Property BillingName as string 
		Get
			 return m_strBillingName 
		End Get
		Set(ByVal Value As string)
			 m_strBillingName = value
		End Set
		End Property
		''' <summary>
		''' �W�ȵ|��
		''' </summary>
		public Property VATNum as string 
		Get
			 return m_strVATNum 
		End Get
		Set(ByVal Value As string)
			 m_strVATNum = value
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
    ''' ���ĵ�i�}�o���h�֤ѥ����I��
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
    ''' �w�d2
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
    ''' �w�d3
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

