#Region "導入命名空間"
Imports System
Imports System.Xml
Imports System.Xml.Serialization
Imports System.Runtime.Serialization
#End Region

''' <summary>實例類</summary>
''' <remarks></remarks>
<Serializable()> _
Partial Public Class StandardFileManageInfo
#Region " Private Fields "
		private  m_iPKID as Integer
		private  m_iRecordStype as Integer
		private  m_strStandardOrganize as string
		private  m_strStandardNumber as string
		private  m_strStandardName as string
		private  m_strStandardVersion as string
		private  m_strStandardDept as string
		private  m_strApplyUser as string
		private  m_iStandardStatus as Integer
		private  m_iStandardSaveType as Integer
		private  m_strQYLocation as string
		private  m_iIsHasFile as Integer
		private  m_iIsAdditionFile as Integer
		private  m_strBackUpAddress as string
    Private m_dtBuyTime As DateTime = DateTime.MaxValue
		private  m_strUseFor as string
		private  m_strUseForEquip as string
		private  m_strRemark as string
		private  m_strExtend1 as string
		private  m_strExtend2 as string
		private  m_strExtend3 as string
		private  m_strExtend4 as string
		private  m_strExtend5 as string
    Private m_dtRecordCreated As DateTime = DateTime.MaxValue
		private  m_iRecordDeleted as Integer
		private  m_iZhangshu as Integer
		private  m_iFenshu as Integer

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
		''' 記錄類別(1:測試標準;2:客戶規格/測試計劃;3:測試校準軟體;4:說明書;5外來文件)
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
		''' ?准??
		''' </summary>
		public Property StandardOrganize as string 
		Get
			 return m_strStandardOrganize 
		End Get
		Set(ByVal Value As string)
			 m_strStandardOrganize = value
		End Set
		End Property
		''' <summary>
		''' ?准??
		''' </summary>
		public Property StandardNumber as string 
		Get
			 return m_strStandardNumber 
		End Get
		Set(ByVal Value As string)
			 m_strStandardNumber = value
		End Set
		End Property
		''' <summary>
		''' ?准名?
		''' </summary>
		public Property StandardName as string 
		Get
			 return m_strStandardName 
		End Get
		Set(ByVal Value As string)
			 m_strStandardName = value
		End Set
		End Property
		''' <summary>
		''' ?准版本
		''' </summary>
		public Property StandardVersion as string 
		Get
			 return m_strStandardVersion 
		End Get
		Set(ByVal Value As string)
			 m_strStandardVersion = value
		End Set
		End Property
		''' <summary>
		''' 所???室
		''' </summary>
		public Property StandardDept as string 
		Get
			 return m_strStandardDept 
		End Get
		Set(ByVal Value As string)
			 m_strStandardDept = value
		End Set
		End Property
		''' <summary>
		''' 申?人
		''' </summary>
		public Property ApplyUser as string 
		Get
			 return m_strApplyUser 
		End Get
		Set(ByVal Value As string)
			 m_strApplyUser = value
		End Set
		End Property
		''' <summary>
		''' ?准??
		''' </summary>
		public Property StandardStatus as Integer 
		Get
			return m_iStandardStatus 
		End Get
		Set(ByVal Value As Integer)
			 m_iStandardStatus = value
		End Set
		End Property
		''' <summary>
		''' ?准存?方式
		''' </summary>
		public Property StandardSaveType as Integer 
		Get
			return m_iStandardSaveType 
		End Get
		Set(ByVal Value As Integer)
			 m_iStandardSaveType = value
		End Set
		End Property
		''' <summary>
		''' ?域位置
		''' </summary>
		public Property QYLocation as string 
		Get
			 return m_strQYLocation 
		End Get
		Set(ByVal Value As string)
			 m_strQYLocation = value
		End Set
		End Property
		''' <summary>
		''' 是否有上?文件
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
		''' 附加?案
		''' </summary>
		public Property IsAdditionFile as Integer 
		Get
			return m_iIsAdditionFile 
		End Get
		Set(ByVal Value As Integer)
			 m_iIsAdditionFile = value
		End Set
		End Property
		''' <summary>
		''' 備份地址
		''' </summary>
		public Property BackUpAddress as string 
		Get
			 return m_strBackUpAddress 
		End Get
		Set(ByVal Value As string)
			 m_strBackUpAddress = value
		End Set
		End Property
		''' <summary>
		''' 
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
		''' 使用儀器
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
		''' <summary>
		''' 
		''' </summary>
		public Property Zhangshu as Integer 
		Get
			return m_iZhangshu 
		End Get
		Set(ByVal Value As Integer)
			 m_iZhangshu = value
		End Set
		End Property
		''' <summary>
		''' 
		''' </summary>
		public Property Fenshu as Integer 
		Get
			return m_iFenshu 
		End Get
		Set(ByVal Value As Integer)
			 m_iFenshu = value
		End Set
		End Property

#End Region
End Class

