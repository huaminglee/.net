#region "導入命名空間"
Imports System
Imports System.Xml
Imports System.Xml.Serialization

#end region

''' <summary>
''' 採購人員信息實例類
''' </summary>
''' <remarks></remarks>


Public Class CaiGouUserInfo

	#Region "成員變量"
	Private _HumanPKID As Integer
	Private _HumanID As String
	Private _HumanName As String
	Private _HumanTel As String
	Private _HumanEmail As String
	Private _HumanDataSource As Integer
	Private _SkillDegree As String
	Private _Extend1 As String
	Private _Extend2 As String
	Private _Extend3 As String
	Private _Extend4 As String
	Private _Extend5 As String
	Private _LastModifyTime As Date
	Private _RecordDeleted As Integer
	Private _RecordCreated As Date
	Private _RecordVersion As String

	#End Region
	
	#region "屬性"
	'''<summary>作業人員PKID編號</summary>
	'''<remarks></remarks>
	Public Property HumanPKID As Integer
		Get
			Return _HumanPKID
		End Get
		Set(Byval value As Integer)
			_HumanPKID = Value
		End Set
	End Property '作業人員PKID編號

	'''<summary>採購人員的工號</summary>
	'''<remarks></remarks>
	Public Property HumanID As String
		Get
			Return _HumanID
		End Get
		Set(Byval value As String)
			_HumanID = Value
		End Set
	End Property '採購人員的工號

	'''<summary>採購人員的姓名</summary>
	'''<remarks></remarks>
	Public Property HumanName As String
		Get
			Return _HumanName
		End Get
		Set(Byval value As String)
			_HumanName = Value
		End Set
	End Property '採購人員的姓名

	'''<summary>採購人員的電話</summary>
	'''<remarks></remarks>
	Public Property HumanTel As String
		Get
			Return _HumanTel
		End Get
		Set(Byval value As String)
			_HumanTel = Value
		End Set
	End Property '採購人員的電話

	'''<summary>採購人員的郵件</summary>
	'''<remarks></remarks>
	Public Property HumanEmail As String
		Get
			Return _HumanEmail
		End Get
		Set(Byval value As String)
			_HumanEmail = Value
		End Set
	End Property '採購人員的郵件

	'''<summary>此採購人員在eFlow帳號表中的PKID</summary>
	'''<remarks></remarks>
	Public Property HumanDataSource As Integer
		Get
			Return _HumanDataSource
		End Get
		Set(Byval value As Integer)
			_HumanDataSource = Value
		End Set
	End Property '此採購人員在eFlow帳號表中的PKID

	'''<summary>採購人員的作業熟練程度</summary>
	'''<remarks></remarks>
	Public Property SkillDegree As String
		Get
			Return _SkillDegree
		End Get
		Set(Byval value As String)
			_SkillDegree = Value
		End Set
	End Property '採購人員的作業熟練程度

	'''<summary>預留擴展</summary>
	'''<remarks></remarks>
	Public Property Extend1 As String
		Get
			Return _Extend1
		End Get
		Set(Byval value As String)
			_Extend1 = Value
		End Set
	End Property '預留擴展

	'''<summary>預留擴展</summary>
	'''<remarks></remarks>
	Public Property Extend2 As String
		Get
			Return _Extend2
		End Get
		Set(Byval value As String)
			_Extend2 = Value
		End Set
	End Property '預留擴展

	'''<summary>預留擴展</summary>
	'''<remarks></remarks>
	Public Property Extend3 As String
		Get
			Return _Extend3
		End Get
		Set(Byval value As String)
			_Extend3 = Value
		End Set
	End Property '預留擴展

	'''<summary>預留擴展</summary>
	'''<remarks></remarks>
	Public Property Extend4 As String
		Get
			Return _Extend4
		End Get
		Set(Byval value As String)
			_Extend4 = Value
		End Set
	End Property '預留擴展

	'''<summary>預留擴展</summary>
	'''<remarks></remarks>
	Public Property Extend5 As String
		Get
			Return _Extend5
		End Get
		Set(Byval value As String)
			_Extend5 = Value
		End Set
	End Property '預留擴展

	'''<summary>最後更新時間（用於排程同步）</summary>
	'''<remarks></remarks>
	Public Property LastModifyTime As Date
		Get
			Return _LastModifyTime
		End Get
		Set(Byval value As Date)
			_LastModifyTime = Value
		End Set
	End Property '最後更新時間（用於排程同步）

	'''<summary>刪除標志</summary>
	'''<remarks></remarks>
	Public Property RecordDeleted As Integer
		Get
			Return _RecordDeleted
		End Get
		Set(Byval value As Integer)
			_RecordDeleted = Value
		End Set
	End Property '刪除標志

	'''<summary>創建時間</summary>
	'''<remarks></remarks>
	Public Property RecordCreated As Date
		Get
			Return _RecordCreated
		End Get
		Set(Byval value As Date)
			_RecordCreated = Value
		End Set
	End Property '創建時間

	'''<summary>版本</summary>
	'''<remarks></remarks>
	Public Property RecordVersion As String
		Get
			Return _RecordVersion
		End Get
		Set(Byval value As String)
			_RecordVersion = Value
		End Set
	End Property '版本


	#End region
    
	#Region "欄位名稱"
	'''<summary>HumanPKID[作業人員PKID編號]對應在資料庫中的欄位名稱</summary>
	Public Const Text_HumanPKID As String = "HumanPKID"
	'''<summary>HumanID[採購人員的工號]對應在資料庫中的欄位名稱</summary>
	Public Const Text_HumanID As String = "HumanID"
	'''<summary>HumanName[採購人員的姓名]對應在資料庫中的欄位名稱</summary>
	Public Const Text_HumanName As String = "HumanName"
	'''<summary>HumanTel[採購人員的電話]對應在資料庫中的欄位名稱</summary>
	Public Const Text_HumanTel As String = "HumanTel"
	'''<summary>HumanEmail[採購人員的郵件]對應在資料庫中的欄位名稱</summary>
	Public Const Text_HumanEmail As String = "HumanEmail"
	'''<summary>HumanDataSource[此採購人員在eFlow帳號表中的PKID]對應在資料庫中的欄位名稱</summary>
	Public Const Text_HumanDataSource As String = "HumanDataSource"
	'''<summary>SkillDegree[採購人員的作業熟練程度]對應在資料庫中的欄位名稱</summary>
	Public Const Text_SkillDegree As String = "SkillDegree"
	'''<summary>Extend1[預留擴展]對應在資料庫中的欄位名稱</summary>
	Public Const Text_Extend1 As String = "Extend1"
	'''<summary>Extend2[預留擴展]對應在資料庫中的欄位名稱</summary>
	Public Const Text_Extend2 As String = "Extend2"
	'''<summary>Extend3[預留擴展]對應在資料庫中的欄位名稱</summary>
	Public Const Text_Extend3 As String = "Extend3"
	'''<summary>Extend4[預留擴展]對應在資料庫中的欄位名稱</summary>
	Public Const Text_Extend4 As String = "Extend4"
	'''<summary>Extend5[預留擴展]對應在資料庫中的欄位名稱</summary>
	Public Const Text_Extend5 As String = "Extend5"
	'''<summary>LastModifyTime[最後更新時間（用於排程同步）]對應在資料庫中的欄位名稱</summary>
	Public Const Text_LastModifyTime As String = "LastModifyTime"
	'''<summary>RecordDeleted[刪除標志]對應在資料庫中的欄位名稱</summary>
	Public Const Text_RecordDeleted As String = "RecordDeleted"
	'''<summary>RecordCreated[創建時間]對應在資料庫中的欄位名稱</summary>
	Public Const Text_RecordCreated As String = "RecordCreated"
	'''<summary>RecordVersion[版本]對應在資料庫中的欄位名稱</summary>
	Public Const Text_RecordVersion As String = "RecordVersion"

	#End Region	
    
	#Region "屬性長度說明"
	'''<summary>[採購人員的工號]的欄位長度</summary>
	'''<remarks>默認長度為50</remarks>
	Public  Const ColumnLengthForHumanID As Integer =50

	'''<summary>[採購人員的姓名]的欄位長度</summary>
	'''<remarks>默認長度為50</remarks>
	Public  Const ColumnLengthForHumanName As Integer =50

	'''<summary>[採購人員的電話]的欄位長度</summary>
	'''<remarks>默認長度為50</remarks>
	Public  Const ColumnLengthForHumanTel As Integer =50

	'''<summary>[採購人員的郵件]的欄位長度</summary>
	'''<remarks>默認長度為50</remarks>
	Public  Const ColumnLengthForHumanEmail As Integer =50

	'''<summary>[採購人員的作業熟練程度]的欄位長度</summary>
	'''<remarks>默認長度為50</remarks>
	Public  Const ColumnLengthForSkillDegree As Integer =50

	'''<summary>[預留擴展]的欄位長度</summary>
	'''<remarks>默認長度為50</remarks>
	Public  Const ColumnLengthForExtend1 As Integer =50

	'''<summary>[預留擴展]的欄位長度</summary>
	'''<remarks>默認長度為50</remarks>
	Public  Const ColumnLengthForExtend2 As Integer =50

	'''<summary>[預留擴展]的欄位長度</summary>
	'''<remarks>默認長度為50</remarks>
	Public  Const ColumnLengthForExtend3 As Integer =50

	'''<summary>[預留擴展]的欄位長度</summary>
	'''<remarks>默認長度為50</remarks>
	Public  Const ColumnLengthForExtend4 As Integer =50

	'''<summary>[預留擴展]的欄位長度</summary>
	'''<remarks>默認長度為50</remarks>
	Public  Const ColumnLengthForExtend5 As Integer =50

	'''<summary>[版本]的欄位長度</summary>
	'''<remarks>默認長度為50</remarks>
	Public  Const ColumnLengthForRecordVersion As Integer =50


	#End region
	
End Class
