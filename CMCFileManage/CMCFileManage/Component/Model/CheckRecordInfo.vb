#Region "導入命名空間"
Imports System
Imports System.Xml
Imports System.Xml.Serialization
Imports System.Runtime.Serialization
#End Region

''' <summary>實例類</summary>
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
		''' 評估日期
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
		''' 品質
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
		''' 服務
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
		''' 交貨
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
		''' 其他
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
		''' 合格判定
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
		''' 評估人
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
		''' 預留欄位1
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
		''' 預留欄位6
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
		''' 預留欄位7
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
		''' 預留欄位
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
		''' 預留欄位
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
		''' 預留欄位10存原紀錄pkid
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
		''' 記錄刪除標記0正常；1刪除
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

