#Region "導入命名空間"
Imports System
Imports System.Xml
Imports System.Xml.Serialization
Imports System.Runtime.Serialization
#End Region

''' <summary>實例類</summary>
''' <remarks></remarks>
<Serializable()> _
Partial Public Class GEPCSI_NGItemReasonInfo
#Region " Private Fields "
		private  m_iPKID as Integer
    Private m_iDeptItemPKID As Integer = 0
    Private m_iNGItemNO As Integer = 0
		private  m_strNGItemName as string
    Private m_iIsWithTextBox As Integer = 0
		private  m_strDisplayOrder as string
		private  m_strExtend1 as string
		private  m_strExtend2 as string
		private  m_strExtend3 as string
		private  m_strExtend4 as string
		private  m_strExtend5 as string
    Private m_iRecordDeleted As Integer = 0
    Private m_dtRecordCreated As DateTime = DateTime.MaxValue
		private  m_strRecordVersion as string

#End Region

#Region " Public Properties"
		''' <summary>
		''' PKID
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
		''' 主表PKID
		''' </summary>
		public Property DeptItemPKID as Integer 
		Get
			return m_iDeptItemPKID 
		End Get
		Set(ByVal Value As Integer)
			 m_iDeptItemPKID = value
		End Set
		End Property
		''' <summary>
		''' 不滿意時的項目列表編號
		''' </summary>
		public Property NGItemNO as Integer 
		Get
			return m_iNGItemNO 
		End Get
		Set(ByVal Value As Integer)
			 m_iNGItemNO = value
		End Set
		End Property
		''' <summary>
		''' 不滿意時的項目列表名字
		''' </summary>
		public Property NGItemName as string 
		Get
			 return m_strNGItemName 
		End Get
		Set(ByVal Value As string)
			 m_strNGItemName = value
		End Set
		End Property
		''' <summary>
		''' 是否帶TextBox(1有:0無)
		''' </summary>
		public Property IsWithTextBox as Integer 
		Get
			return m_iIsWithTextBox 
		End Get
		Set(ByVal Value As Integer)
			 m_iIsWithTextBox = value
		End Set
		End Property
		''' <summary>
		''' 顯示次序
		''' </summary>
		public Property DisplayOrder as string 
		Get
			 return m_strDisplayOrder 
		End Get
		Set(ByVal Value As string)
			 m_strDisplayOrder = value
		End Set
		End Property
		''' <summary>
		''' 預留
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
		''' 預留
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
		''' 預留
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
		''' 預留
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
		''' 預留
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
		''' 刪除標志( 1軟刪)
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
		''' 記錄生成時間
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
		''' 記錄版本號
		''' </summary>
		public Property RecordVersion as string 
		Get
			 return m_strRecordVersion 
		End Get
		Set(ByVal Value As string)
			 m_strRecordVersion = value
		End Set
		End Property

#End Region
End Class

