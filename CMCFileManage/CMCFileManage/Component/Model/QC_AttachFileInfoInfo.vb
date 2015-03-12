#Region "導入命名空間"
Imports System
Imports System.Xml
Imports System.Xml.Serialization
Imports System.Runtime.Serialization
#End Region

''' <summary>實例類</summary>
''' <remarks></remarks>
<Serializable()> _
Partial Public Class QC_AttachFileInfoInfo
#Region " Private Fields "
		private  m_iFileID as Integer
		private  m_strParentID as string
		private  m_iParentCategory as Integer
		private  m_iParentSubCategory as Integer
		private  m_decFileGuID as Guid
		private  m_strFileName as string
		private  m_strFileExtension as string
		private  m_iFileSize as Integer
		private  m_strFileClientName as string
		private  m_strExtend1 as string
		private  m_strExtend2 as string
		private  m_strExtend3 as string
		private  m_strExtend4 as string
		private  m_strExtend5 as string
		private  m_strRecordVersion as string
		private  m_dtRecordCreateTime as DateTime
		private  m_iRecordDeleted as Integer

#End Region

#Region " Public Properties"
		''' <summary>
		''' 附件PKID
		''' </summary>
		public Property FileID as Integer 
		Get
			return m_iFileID 
		End Get
		Set(ByVal Value As Integer)
			 m_iFileID = value
		End Set
		End Property
		''' <summary>
		''' 附件主表編號
		''' </summary>
		public Property ParentID as string 
		Get
			 return m_strParentID 
		End Get
		Set(ByVal Value As string)
			 m_strParentID = value
		End Set
		End Property
		''' <summary>
		''' 附件類別(不同模組附件的區分)
		''' </summary>
		public Property ParentCategory as Integer 
		Get
			return m_iParentCategory 
		End Get
		Set(ByVal Value As Integer)
			 m_iParentCategory = value
		End Set
		End Property
		''' <summary>
		''' 報告子類別
		''' </summary>
		public Property ParentSubCategory as Integer 
		Get
			return m_iParentSubCategory 
		End Get
		Set(ByVal Value As Integer)
			 m_iParentSubCategory = value
		End Set
		End Property
		''' <summary>
		''' 附件GuID
		''' </summary>
		public Property FileGuID as Guid 
		Get
			return m_decFileGuID 
		End Get
		Set(ByVal Value As Guid)
			 m_decFileGuID = value
		End Set
		End Property
		''' <summary>
		''' 附件名稱
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
		''' 附件類型
		''' </summary>
		public Property FileExtension as string 
		Get
			 return m_strFileExtension 
		End Get
		Set(ByVal Value As string)
			 m_strFileExtension = value
		End Set
		End Property
		''' <summary>
		''' 附件大小
		''' </summary>
		public Property FileSize as Integer 
		Get
			return m_iFileSize 
		End Get
		Set(ByVal Value As Integer)
			 m_iFileSize = value
		End Set
		End Property
		''' <summary>
		''' 附件客戶端名稱
		''' </summary>
		public Property FileClientName as string 
		Get
			 return m_strFileClientName 
		End Get
		Set(ByVal Value As string)
			 m_strFileClientName = value
		End Set
		End Property
		''' <summary>
		''' 擴展欄位1
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
		''' 擴展欄位2
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
		''' 擴展欄位3
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
		''' 擴展欄位4
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
		''' 已佔用（存異常記錄單編號或報告變更記錄）
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
		''' 記錄版本
		''' </summary>
		public Property RecordVersion as string 
		Get
			 return m_strRecordVersion 
		End Get
		Set(ByVal Value As string)
			 m_strRecordVersion = value
		End Set
		End Property
		''' <summary>
		''' 記錄創建時間
		''' </summary>
		public Property RecordCreateTime as DateTime 
		Get
			return m_dtRecordCreateTime 
		End Get
		Set(ByVal Value As DateTime)
			 m_dtRecordCreateTime = value
		End Set
		End Property
		''' <summary>
		''' 記錄刪除標記(0:1)
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

