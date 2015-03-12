#Region "導入命名空間"
Imports System
Imports System.Xml
Imports System.Xml.Serialization
Imports System.Runtime.Serialization
#End Region

''' <summary>實例類</summary>
''' <remarks></remarks>
<Serializable()> _
Partial Public Class PersonTecInfo
#Region " Private Fields "
    Private m_iPKID As Integer = 0
    Private m_strDept As String = String.Empty
    Private m_strUserName As String = String.Empty
    Private m_strUserSid As String = String.Empty
    Private m_strQuLocation As String = String.Empty
    Private m_strJobType As String = String.Empty
    Private m_strPosition As String = String.Empty
    Private m_strCerNO As String = String.Empty
    Private m_dtIntime As DateTime = DateTime.MaxValue
    Private m_dtPostsTime As DateTime = DateTime.MaxValue
    Private m_strPostsRemark As String = String.Empty
    Private m_strOtherRemark As String = String.Empty
    Private m_iCurType As Integer = 0
    Private m_strRemark As String = String.Empty
    Private m_strExtend1 As String = String.Empty
    Private m_strExtend2 As String = String.Empty
    Private m_strExtend3 As String = String.Empty
    Private m_strExtend4 As String = String.Empty
    Private m_strExtend5 As String = String.Empty
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
		public Property Dept as string 
		Get
			 return m_strDept 
		End Get
		Set(ByVal Value As string)
			 m_strDept = value
		End Set
		End Property
		''' <summary>
		''' 
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
		''' 
		''' </summary>
		public Property UserSid as string 
		Get
			 return m_strUserSid 
		End Get
		Set(ByVal Value As string)
			 m_strUserSid = value
		End Set
		End Property
		''' <summary>
		''' 
		''' </summary>
		public Property QuLocation as string 
		Get
			 return m_strQuLocation 
		End Get
		Set(ByVal Value As string)
			 m_strQuLocation = value
		End Set
		End Property
		''' <summary>
		''' 
		''' </summary>
		public Property JobType as string 
		Get
			 return m_strJobType 
		End Get
		Set(ByVal Value As string)
			 m_strJobType = value
		End Set
		End Property
		''' <summary>
		''' 管理職
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
		''' 證書編號
		''' </summary>
		public Property CerNO as string 
		Get
			 return m_strCerNO 
		End Get
		Set(ByVal Value As string)
			 m_strCerNO = value
		End Set
		End Property
		''' <summary>
		''' 進廠日期
		''' </summary>
		public Property Intime as DateTime 
		Get
			return m_dtIntime 
		End Get
		Set(ByVal Value As DateTime)
			 m_dtIntime = value
		End Set
		End Property
		''' <summary>
		''' 上崗日期
		''' </summary>
		public Property PostsTime as DateTime 
		Get
			return m_dtPostsTime 
		End Get
		Set(ByVal Value As DateTime)
			 m_dtPostsTime = value
		End Set
		End Property
		''' <summary>
		''' 上崗說明
		''' </summary>
		public Property PostsRemark as string 
		Get
			 return m_strPostsRemark 
		End Get
		Set(ByVal Value As string)
			 m_strPostsRemark = value
		End Set
		End Property
		''' <summary>
		''' 其他說明
		''' </summary>
		public Property OtherRemark as string 
		Get
			 return m_strOtherRemark 
		End Get
		Set(ByVal Value As string)
			 m_strOtherRemark = value
		End Set
		End Property
		''' <summary>
		''' 狀態：1在職2轉出3離職
		''' </summary>
		public Property CurType as Integer 
		Get
			return m_iCurType 
		End Get
		Set(ByVal Value As Integer)
			 m_iCurType = value
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
    ''' 從Notes導入
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
		''' 預留欄位2
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
		''' 預留欄位3
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
		''' 預留欄位4
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
		''' 預留欄位5備註
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
		''' 記錄創建時間
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
		''' 記錄刪除標記
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

