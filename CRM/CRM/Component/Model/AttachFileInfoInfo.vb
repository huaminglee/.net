#region "導入命名空間"
Imports System
Imports System.Xml
Imports System.Xml.Serialization
Imports System.Runtime.Serialization
#end region

''' <summary>實例類</summary>
''' <remarks></remarks>
<DataContract()> _
<Serializable()> _
Public Class AttachFileInfoInfo

	#Region "成員變量"
	Private _FileID As Integer
	Private _ParentID As Integer
	Private _ParentCategory As Integer
	Private _ParentSubCategory As Integer
	Private _FileGuID As System.Guid
	Private _FileName As String
	Private _FileExtension As String
	Private _FileSize As Integer
	Private _FileClientName As String
	Private _Extend1 As String
	Private _Extend2 As String
	Private _Extend3 As String
	Private _Extend4 As String
	Private _Extend5 As String
	Private _RecordVersion As String
	Private _RecordCreateTime As DateTime
	Private _RecordDeleted As Integer

	#End Region
	
	#region "屬性"
	'''<summary>附件PKID</summary>
	'''<remarks></remarks>
	<DataMember()> _
	Public Property FileID As Integer
		Get
			Return _FileID
		End Get
		Set(Byval value As Integer)
			_FileID = Value
		End Set
	End Property '附件PKID

	'''<summary>附件主表PKID</summary>
	'''<remarks></remarks>
	<DataMember()> _
	Public Property ParentID As Integer
		Get
			Return _ParentID
		End Get
		Set(Byval value As Integer)
			_ParentID = Value
		End Set
	End Property '附件主表PKID

	'''<summary>附件類別(不同模組附件的區分)</summary>
	'''<remarks></remarks>
	<DataMember()> _
	Public Property ParentCategory As Integer
		Get
			Return _ParentCategory
		End Get
		Set(Byval value As Integer)
			_ParentCategory = Value
		End Set
	End Property '附件類別(不同模組附件的區分)

	'''<summary>附件子類別(同一模組不同類別附件的區分)</summary>
	'''<remarks></remarks>
	<DataMember()> _
	Public Property ParentSubCategory As Integer
		Get
			Return _ParentSubCategory
		End Get
		Set(Byval value As Integer)
			_ParentSubCategory = Value
		End Set
	End Property '附件子類別(同一模組不同類別附件的區分)

	'''<summary>附件GuID</summary>
	'''<remarks></remarks>
	<DataMember()> _
	Public Property FileGuID As System.Guid
		Get
			Return _FileGuID
		End Get
		Set(Byval value As System.Guid)
			_FileGuID = Value
		End Set
	End Property '附件GuID

	'''<summary>附件名稱</summary>
	'''<remarks></remarks>
	<DataMember()> _
	Public Property FileName As String
		Get
			Return _FileName
		End Get
		Set(Byval value As String)
			_FileName = Value
		End Set
	End Property '附件名稱

	'''<summary>附件類型</summary>
	'''<remarks></remarks>
	<DataMember()> _
	Public Property FileExtension As String
		Get
			Return _FileExtension
		End Get
		Set(Byval value As String)
			_FileExtension = Value
		End Set
	End Property '附件類型

	'''<summary>附件大小</summary>
	'''<remarks></remarks>
	<DataMember()> _
	Public Property FileSize As Integer
		Get
			Return _FileSize
		End Get
		Set(Byval value As Integer)
			_FileSize = Value
		End Set
	End Property '附件大小

	'''<summary>附件客戶端名稱</summary>
	'''<remarks></remarks>
	<DataMember()> _
	Public Property FileClientName As String
		Get
			Return _FileClientName
		End Get
		Set(Byval value As String)
			_FileClientName = Value
		End Set
	End Property '附件客戶端名稱

	'''<summary>擴展欄位1</summary>
	'''<remarks></remarks>
	<DataMember()> _
	Public Property Extend1 As String
		Get
			Return _Extend1
		End Get
		Set(Byval value As String)
			_Extend1 = Value
		End Set
	End Property '擴展欄位1

	'''<summary>擴展欄位2</summary>
	'''<remarks></remarks>
	<DataMember()> _
	Public Property Extend2 As String
		Get
			Return _Extend2
		End Get
		Set(Byval value As String)
			_Extend2 = Value
		End Set
	End Property '擴展欄位2

	'''<summary>擴展欄位3</summary>
	'''<remarks></remarks>
	<DataMember()> _
	Public Property Extend3 As String
		Get
			Return _Extend3
		End Get
		Set(Byval value As String)
			_Extend3 = Value
		End Set
	End Property '擴展欄位3

	'''<summary>擴展欄位4</summary>
	'''<remarks></remarks>
	<DataMember()> _
	Public Property Extend4 As String
		Get
			Return _Extend4
		End Get
		Set(Byval value As String)
			_Extend4 = Value
		End Set
	End Property '擴展欄位4

	'''<summary>擴展欄位5</summary>
	'''<remarks></remarks>
	<DataMember()> _
	Public Property Extend5 As String
		Get
			Return _Extend5
		End Get
		Set(Byval value As String)
			_Extend5 = Value
		End Set
	End Property '擴展欄位5

	'''<summary>記錄版本</summary>
	'''<remarks></remarks>
	<DataMember()> _
	Public Property RecordVersion As String
		Get
			Return _RecordVersion
		End Get
		Set(Byval value As String)
			_RecordVersion = Value
		End Set
	End Property '記錄版本

	'''<summary>記錄創建時間</summary>
	'''<remarks></remarks>
	<DataMember()> _
	Public Property RecordCreateTime As DateTime
		Get
			Return _RecordCreateTime
		End Get
		Set(Byval value As DateTime)
			_RecordCreateTime = Value
		End Set
	End Property '記錄創建時間

	'''<summary>記錄刪除標記(0:未刪除,1:已刪除)</summary>
	'''<remarks></remarks>
	<DataMember()> _
	Public Property RecordDeleted As Integer
		Get
			Return _RecordDeleted
		End Get
		Set(Byval value As Integer)
			_RecordDeleted = Value
		End Set
	End Property '記錄刪除標記(0:未刪除,1:已刪除)


	#End region
    
	#Region "欄位名稱"
	'''<summary>FileID[附件PKID]對應在資料庫中的欄位名稱</summary>
	Public Const Text_FileID As String = "FileID"
	'''<summary>ParentID[附件主表PKID]對應在資料庫中的欄位名稱</summary>
	Public Const Text_ParentID As String = "ParentID"
	'''<summary>ParentCategory[附件類別(不同模組附件的區分)]對應在資料庫中的欄位名稱</summary>
	Public Const Text_ParentCategory As String = "ParentCategory"
	'''<summary>ParentSubCategory[附件子類別(同一模組不同類別附件的區分)]對應在資料庫中的欄位名稱</summary>
	Public Const Text_ParentSubCategory As String = "ParentSubCategory"
	'''<summary>FileGuID[附件GuID]對應在資料庫中的欄位名稱</summary>
	Public Const Text_FileGuID As String = "FileGuID"
	'''<summary>FileName[附件名稱]對應在資料庫中的欄位名稱</summary>
	Public Const Text_FileName As String = "FileName"
	'''<summary>FileExtension[附件類型]對應在資料庫中的欄位名稱</summary>
	Public Const Text_FileExtension As String = "FileExtension"
	'''<summary>FileSize[附件大小]對應在資料庫中的欄位名稱</summary>
	Public Const Text_FileSize As String = "FileSize"
	'''<summary>FileClientName[附件客戶端名稱]對應在資料庫中的欄位名稱</summary>
	Public Const Text_FileClientName As String = "FileClientName"
	'''<summary>Extend1[擴展欄位1]對應在資料庫中的欄位名稱</summary>
	Public Const Text_Extend1 As String = "Extend1"
	'''<summary>Extend2[擴展欄位2]對應在資料庫中的欄位名稱</summary>
	Public Const Text_Extend2 As String = "Extend2"
	'''<summary>Extend3[擴展欄位3]對應在資料庫中的欄位名稱</summary>
	Public Const Text_Extend3 As String = "Extend3"
	'''<summary>Extend4[擴展欄位4]對應在資料庫中的欄位名稱</summary>
	Public Const Text_Extend4 As String = "Extend4"
	'''<summary>Extend5[擴展欄位5]對應在資料庫中的欄位名稱</summary>
	Public Const Text_Extend5 As String = "Extend5"
	'''<summary>RecordVersion[記錄版本]對應在資料庫中的欄位名稱</summary>
	Public Const Text_RecordVersion As String = "RecordVersion"
	'''<summary>RecordCreateTime[記錄創建時間]對應在資料庫中的欄位名稱</summary>
	Public Const Text_RecordCreateTime As String = "RecordCreateTime"
	'''<summary>RecordDeleted[記錄刪除標記(0:未刪除,1:已刪除)]對應在資料庫中的欄位名稱</summary>
	Public Const Text_RecordDeleted As String = "RecordDeleted"

	#End Region	
    
	#Region "屬性長度說明"
	'''<summary>[附件名稱]的欄位長度</summary>
	'''<remarks>默認長度為200</remarks>
	Public  Const ColumnLengthForFileName As Integer =200

	'''<summary>[附件類型]的欄位長度</summary>
	'''<remarks>默認長度為50</remarks>
	Public  Const ColumnLengthForFileExtension As Integer =50

	'''<summary>[附件客戶端名稱]的欄位長度</summary>
	'''<remarks>默認長度為500</remarks>
	Public  Const ColumnLengthForFileClientName As Integer =500

	'''<summary>[擴展欄位1]的欄位長度</summary>
	'''<remarks>默認長度為50</remarks>
	Public  Const ColumnLengthForExtend1 As Integer =50

	'''<summary>[擴展欄位2]的欄位長度</summary>
	'''<remarks>默認長度為50</remarks>
	Public  Const ColumnLengthForExtend2 As Integer =50

	'''<summary>[擴展欄位3]的欄位長度</summary>
	'''<remarks>默認長度為50</remarks>
	Public  Const ColumnLengthForExtend3 As Integer =50

	'''<summary>[擴展欄位4]的欄位長度</summary>
	'''<remarks>默認長度為50</remarks>
	Public  Const ColumnLengthForExtend4 As Integer =50

	'''<summary>[擴展欄位5]的欄位長度</summary>
	'''<remarks>默認長度為100</remarks>
	Public  Const ColumnLengthForExtend5 As Integer =100

	'''<summary>[記錄版本]的欄位長度</summary>
	'''<remarks>默認長度為50</remarks>
	Public  Const ColumnLengthForRecordVersion As Integer =50


	#End region
	
End Class
