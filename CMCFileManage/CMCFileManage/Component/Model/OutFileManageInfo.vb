#Region "導入命名空間"
Imports System
Imports System.Xml
Imports System.Xml.Serialization
Imports System.Runtime.Serialization
#End Region

''' <summary>實例類</summary>
''' <remarks></remarks>
<Serializable()> _
Partial Public Class OutFileManageInfo
#Region " Private Fields "
		private  m_iPKID as Integer
		private  m_iRecordStype as Integer
		private  m_deceFlowDocID as Guid
		private  m_iIsFinish as Integer
		private  m_iStateOrder as Integer
		private  m_strStateName as string
		private  m_strFileBH as string
		private  m_strFileName as string
		private  m_strFileVersion as string
		private  m_iFilePageNum as Integer
		private  m_iFileNum as Integer
		private  m_strUseFor as string
		private  m_strUseForEquip as string
		private  m_strFileSource as string
		private  m_strQyLocation as string
		private  m_strFileDept as string
    Private m_dtBuyTime As DateTime = DateTime.MaxValue
		private  m_strBackAddress as string
		private  m_strRemark as string
		private  m_iSaveType as Integer
		private  m_iIsHasFile as Integer
		private  m_strExtend1 as string
		private  m_strExtend2 as string
		private  m_strExtend3 as string
		private  m_strExtend4 as string
		private  m_strExtend5 as string
		private  m_strExtend6 as string
		private  m_strExtend7 as string
		private  m_strExtend8 as string
		private  m_strExtend9 as string
		private  m_strExtend10 as string
    Private m_dtRecordCreated As DateTime = DateTime.MaxValue
		private  m_iRecordDeleted as Integer

#End Region

#Region " Public Properties"
		''' <summary>
		''' 記錄編號
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
		''' 記錄類別(2:客戶規格/測試計劃;3:測試校準軟體;4:說明書;5外來文件)
		''' </summary>
		public Property RecordStype as Integer 
		Get
			return m_iRecordStype 
		End Get
		Set(ByVal Value As Integer)
			 m_iRecordStype = value
		End Set
		End Property
		''' <summary>
		''' 流程實例ID
		''' </summary>
		public Property eFlowDocID as Guid 
		Get
			return m_deceFlowDocID 
		End Get
		Set(ByVal Value As Guid)
			 m_deceFlowDocID = value
		End Set
		End Property
		''' <summary>
		''' 是否結案
		''' </summary>
		public Property IsFinish as Integer 
		Get
			return m_iIsFinish 
		End Get
		Set(ByVal Value As Integer)
			 m_iIsFinish = value
		End Set
		End Property
		''' <summary>
		''' 所屬狀態Num
		''' </summary>
		public Property StateOrder as Integer 
		Get
			return m_iStateOrder 
		End Get
		Set(ByVal Value As Integer)
			 m_iStateOrder = value
		End Set
		End Property
		''' <summary>
		''' 狀態名稱
		''' </summary>
		public Property StateName as string 
		Get
			 return m_strStateName 
		End Get
		Set(ByVal Value As string)
			 m_strStateName = value
		End Set
		End Property
		''' <summary>
		''' 文件編號
		''' </summary>
		public Property FileBH as string 
		Get
			 return m_strFileBH 
		End Get
		Set(ByVal Value As string)
			 m_strFileBH = value
		End Set
		End Property
		''' <summary>
		''' 文件名稱
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
		''' 版次
		''' </summary>
		public Property FileVersion as string 
		Get
			 return m_strFileVersion 
		End Get
		Set(ByVal Value As string)
			 m_strFileVersion = value
		End Set
		End Property
		''' <summary>
		''' 頁數
		''' </summary>
		public Property FilePageNum as Integer 
		Get
			return m_iFilePageNum 
		End Get
		Set(ByVal Value As Integer)
			 m_iFilePageNum = value
		End Set
		End Property
		''' <summary>
		''' 份數
		''' </summary>
		public Property FileNum as Integer 
		Get
			return m_iFileNum 
		End Get
		Set(ByVal Value As Integer)
			 m_iFileNum = value
		End Set
		End Property
		''' <summary>
		''' 用途
		''' </summary>
		public Property UseFor as string 
		Get
			 return m_strUseFor 
		End Get
		Set(ByVal Value As string)
			 m_strUseFor = value
		End Set
		End Property
		''' <summary>
		''' 適用設備
		''' </summary>
		public Property UseForEquip as string 
		Get
			 return m_strUseForEquip 
		End Get
		Set(ByVal Value As string)
			 m_strUseForEquip = value
		End Set
		End Property
		''' <summary>
		''' 文件來源
		''' </summary>
		public Property FileSource as string 
		Get
			 return m_strFileSource 
		End Get
		Set(ByVal Value As string)
			 m_strFileSource = value
		End Set
		End Property
		''' <summary>
		''' 區域
		''' </summary>
		public Property QyLocation as string 
		Get
			 return m_strQyLocation 
		End Get
		Set(ByVal Value As string)
			 m_strQyLocation = value
		End Set
		End Property
		''' <summary>
		''' 所屬實驗室
		''' </summary>
		public Property FileDept as string 
		Get
			 return m_strFileDept 
		End Get
		Set(ByVal Value As string)
			 m_strFileDept = value
		End Set
		End Property
		''' <summary>
		''' 購買時間
		''' </summary>
		public Property BuyTime as DateTime 
		Get
			return m_dtBuyTime 
		End Get
		Set(ByVal Value As DateTime)
			 m_dtBuyTime = value
		End Set
		End Property
		''' <summary>
		''' 備份地址
		''' </summary>
		public Property BackAddress as string 
		Get
			 return m_strBackAddress 
		End Get
		Set(ByVal Value As string)
			 m_strBackAddress = value
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
		''' 存儲方式0無1紙檔2電子檔3兩種
		''' </summary>
		public Property SaveType as Integer 
		Get
			return m_iSaveType 
		End Get
		Set(ByVal Value As Integer)
			 m_iSaveType = value
		End Set
		End Property
		''' <summary>
		''' 
		''' </summary>
		public Property IsHasFile as Integer 
		Get
			return m_iIsHasFile 
		End Get
		Set(ByVal Value As Integer)
			 m_iIsHasFile = value
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
		''' 預留欄位8
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
		''' 預留欄位9
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
    ''' 是否Notes導入
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

