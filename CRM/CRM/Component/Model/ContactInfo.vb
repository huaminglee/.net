#Region "導入命名空間"
Imports System
Imports System.Xml
Imports System.Xml.Serialization
Imports System.Runtime.Serialization
#End Region

''' <summary>實例類</summary>
''' <remarks></remarks>
<Serializable()> _
Partial Public Class ContactInfo
#Region " Private Fields "
    Private m_iPKID As Integer = 0
    Private m_strUserSID As String = String.Empty
    Private m_strUserName As String = String.Empty
    Private m_iContactCategory As Integer = 0
    Private m_iCusTomerPKID As Integer = 0
    Private m_strCustomerName As String = String.Empty
    Private m_strPosition As String = String.Empty
    Private m_strPhoto As String = String.Empty
    Private m_strAddress As String = String.Empty
    Private m_strIDnumber As String = String.Empty
    Private m_dtBirthday As DateTime = DateTime.MaxValue
    Private m_iSex As Integer = 0
    Private m_iZIPcode As Integer = 0
    Private m_strGraduated As String = String.Empty
    Private m_strDegree As String = String.Empty
    Private m_strMajor As String = String.Empty
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
		''' 登陸名
		''' </summary>
		public Property UserSID as string 
		Get
			 return m_strUserSID 
		End Get
		Set(ByVal Value As string)
			 m_strUserSID = value
		End Set
		End Property
		''' <summary>
		''' 用戶名
		''' </summary>
		public Property UserName as string 
		Get
			 return m_strUserName 
		End Get
		Set(ByVal Value As string)
			 m_strUserName = value
		End Set
		End Property
		''' <summary>
		''' 聯繫人類別（1：內部2：外部）
		''' </summary>
		public Property ContactCategory as Integer 
		Get
			return m_iContactCategory 
		End Get
		Set(ByVal Value As Integer)
			 m_iContactCategory = value
		End Set
		End Property
		''' <summary>
		''' 公司pkid
		''' </summary>
		public Property CusTomerPKID as Integer 
		Get
			return m_iCusTomerPKID 
		End Get
		Set(ByVal Value As Integer)
			 m_iCusTomerPKID = value
		End Set
		End Property
		''' <summary>
		''' 公司名
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
		''' 職務
		''' </summary>
		public Property Position as string 
		Get
			 return m_strPosition 
		End Get
		Set(ByVal Value As string)
			 m_strPosition = value
		End Set
		End Property
		''' <summary>
		''' 頭像
		''' </summary>
		public Property Photo as string 
		Get
			 return m_strPhoto 
		End Get
		Set(ByVal Value As string)
			 m_strPhoto = value
		End Set
		End Property
		''' <summary>
		''' 地址
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
		''' 身份證號
		''' </summary>
		public Property IDnumber as string 
		Get
			 return m_strIDnumber 
		End Get
		Set(ByVal Value As string)
			 m_strIDnumber = value
		End Set
		End Property
		''' <summary>
		''' 生日
		''' </summary>
		public Property Birthday as DateTime 
		Get
			return m_dtBirthday 
		End Get
		Set(ByVal Value As DateTime)
			 m_dtBirthday = value
		End Set
		End Property
		''' <summary>
		''' 性別（1男2女3保密）
		''' </summary>
		public Property Sex as Integer 
		Get
			return m_iSex 
		End Get
		Set(ByVal Value As Integer)
			 m_iSex = value
		End Set
		End Property
		''' <summary>
		''' 郵政號碼
		''' </summary>
		public Property ZIPcode as Integer 
		Get
			return m_iZIPcode 
		End Get
		Set(ByVal Value As Integer)
			 m_iZIPcode = value
		End Set
		End Property
		''' <summary>
		''' 畢業院校
		''' </summary>
		public Property Graduated as string 
		Get
			 return m_strGraduated 
		End Get
		Set(ByVal Value As string)
			 m_strGraduated = value
		End Set
		End Property
		''' <summary>
		''' 學歷
		''' </summary>
		public Property Degree as string 
		Get
			 return m_strDegree 
		End Get
		Set(ByVal Value As string)
			 m_strDegree = value
		End Set
		End Property
		''' <summary>
		''' 專業
		''' </summary>
		public Property Major as string 
		Get
			 return m_strMajor 
		End Get
		Set(ByVal Value As string)
			 m_strMajor = value
		End Set
		End Property
		''' <summary>
		''' 備註
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
    ''' 電話
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
    ''' 郵箱
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
    ''' 傳真
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
    ''' 外部郵箱
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
		''' 預留欄位5
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
		''' 記錄創時間
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
		''' 記錄刪除標誌
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

