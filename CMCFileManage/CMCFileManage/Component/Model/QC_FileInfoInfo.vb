#Region "導入命名空間"
Imports System
Imports System.Xml
Imports System.Xml.Serialization
Imports System.Runtime.Serialization
#End Region

''' <summary>實例類</summary>
''' <remarks></remarks>
<Serializable()> _
Partial Public Class QC_FileInfoInfo
#Region " Private Fields "
    Private m_iPKID As Integer = 0
    Private m_strRecordNO As String = String.Empty
		private  m_deceFlowDocID as Guid
    Private m_iIsFinish As Integer = 0
    Private m_iStateOrder As Integer = 0
    Private m_strStateName As String = String.Empty
    Private m_iNeedAround As Integer = 0
    Private m_strApplyDept As String = String.Empty
    Private m_strApplyUser As String = String.Empty
    Private m_strApplyDate As DateTime = DateTime.MaxValue
    Private m_strFileVersion As String = String.Empty
    Private m_iToTalPage As Integer = 0
    Private m_strFileName As String = String.Empty
    Private m_strFileLayer As String = String.Empty
    Private m_strFileCategory As String = String.Empty
    Private m_strISO As String = String.Empty
    Private m_strFileBH As String = String.Empty
    Private m_strChangeReason As String = String.Empty
    Private m_strChangePreDes As String = String.Empty
    Private m_strChangeBehDes As String = String.Empty
    Private m_strLabTechniqueCharge As String = String.Empty
    Private m_iCounterSignType As Integer = 0
    Private m_iSendDept As Integer = 0
    Private m_strSendNum As String = String.Empty
    Private m_iSendPaperNums As Integer = 0
    Private m_iIsTeach As Integer = 0
    Private m_strTeachDept As String = String.Empty
    Private m_strEffectDate As DateTime = DateTime.MaxValue
    Private m_iIsPdf As Integer = 0
    Private m_iIsexecl As Integer = 0
    Private m_strCenterTechniqueCharge As String = String.Empty
    Private m_strCenterQuantityCharge As String = String.Empty
    Private m_strHighManager As String = String.Empty
    Private m_strQualityFinishUser As String = String.Empty
    Private m_iIsChange As Integer = 0
    Private m_iBackDept As Integer = 0
    Private m_strBackSum As String = String.Empty
    Private m_iRecordType As Integer = 0
    Private m_iFileStatus As Integer = 0
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
		''' 記錄編號(文件變更號)
		''' </summary>
		public Property RecordNO as string 
		Get
			 return m_strRecordNO 
		End Get
		Set(ByVal Value As string)
			 m_strRecordNO = value
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
		''' 適用範圍，多億多選，已2的冪次方存儲
		''' </summary>
		public Property NeedAround as Integer 
		Get
			return m_iNeedAround 
		End Get
		Set(ByVal Value As Integer)
			 m_iNeedAround = value
		End Set
		End Property
		''' <summary>
		''' 提案部門
		''' </summary>
		public Property ApplyDept as string 
		Get
			 return m_strApplyDept 
		End Get
		Set(ByVal Value As string)
			 m_strApplyDept = value
		End Set
		End Property
		''' <summary>
		''' 提案人員
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
		''' 提案日期
		''' </summary>
    Public Property ApplyDate() As DateTime
        Get
            Return m_strApplyDate
        End Get
        Set(ByVal Value As DateTime)
            m_strApplyDate = Value
        End Set
    End Property
		''' <summary>
		''' 文件版本
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
		''' 總頁數
		''' </summary>
		public Property ToTalPage as Integer 
		Get
			return m_iToTalPage 
		End Get
		Set(ByVal Value As Integer)
			 m_iToTalPage = value
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
		''' 文件階層
		''' </summary>
		public Property FileLayer as string 
		Get
			 return m_strFileLayer 
		End Get
		Set(ByVal Value As string)
			 m_strFileLayer = value
		End Set
		End Property
		''' <summary>
		''' 文件類別
		''' </summary>
		public Property FileCategory as string 
		Get
			 return m_strFileCategory 
		End Get
		Set(ByVal Value As string)
			 m_strFileCategory = value
		End Set
		End Property
		''' <summary>
		''' 
		''' </summary>
		public Property ISO as string 
		Get
			 return m_strISO 
		End Get
		Set(ByVal Value As string)
			 m_strISO = value
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
		''' 變更原因
		''' </summary>
		public Property ChangeReason as string 
		Get
			 return m_strChangeReason 
		End Get
		Set(ByVal Value As string)
			 m_strChangeReason = value
		End Set
		End Property
		''' <summary>
		''' 變更前描述
		''' </summary>
		public Property ChangePreDes as string 
		Get
			 return m_strChangePreDes 
		End Get
		Set(ByVal Value As string)
			 m_strChangePreDes = value
		End Set
		End Property
		''' <summary>
		''' 變更後描述
		''' </summary>
		public Property ChangeBehDes as string 
		Get
			 return m_strChangeBehDes 
		End Get
		Set(ByVal Value As string)
			 m_strChangeBehDes = value
		End Set
		End Property
		''' <summary>
		''' 實驗室技術負責人
		''' </summary>
		public Property LabTechniqueCharge as string 
		Get
			 return m_strLabTechniqueCharge 
		End Get
		Set(ByVal Value As string)
			 m_strLabTechniqueCharge = value
		End Set
		End Property
		''' <summary>
		''' 會簽方式
		''' </summary>
		public Property CounterSignType as Integer 
		Get
			return m_iCounterSignType 
		End Get
		Set(ByVal Value As Integer)
			 m_iCounterSignType = value
		End Set
		End Property
		''' <summary>
		''' 分發單位，多個單位以2的冪次方存儲
		''' </summary>
		public Property SendDept as Integer 
		Get
			return m_iSendDept 
		End Get
		Set(ByVal Value As Integer)
			 m_iSendDept = value
		End Set
		End Property
		''' <summary>
		''' 分發份數,多個實驗室以^拼接
		''' </summary>
		public Property SendNum as string 
		Get
			 return m_strSendNum 
		End Get
		Set(ByVal Value As string)
			 m_strSendNum = value
		End Set
		End Property
		''' <summary>
		''' 
		''' </summary>
		public Property SendPaperNums as Integer 
		Get
			return m_iSendPaperNums 
		End Get
		Set(ByVal Value As Integer)
			 m_iSendPaperNums = value
		End Set
		End Property
		''' <summary>
		''' 是否教育訓練
		''' </summary>
		public Property IsTeach as Integer 
		Get
			return m_iIsTeach 
		End Get
		Set(ByVal Value As Integer)
			 m_iIsTeach = value
		End Set
		End Property
		''' <summary>
		''' 教育訓練部門
		''' </summary>
		public Property TeachDept as string 
		Get
			 return m_strTeachDept 
		End Get
		Set(ByVal Value As string)
			 m_strTeachDept = value
		End Set
		End Property
		''' <summary>
		''' 生效日期
		''' </summary>
    Public Property EffectDate() As DateTime
        Get
            Return m_strEffectDate
        End Get
        Set(ByVal Value As DateTime)
            m_strEffectDate = Value
        End Set
    End Property
		''' <summary>
		''' 是否上傳pdf文檔
		''' </summary>
		public Property IsPdf as Integer 
		Get
			return m_iIsPdf 
		End Get
		Set(ByVal Value As Integer)
			 m_iIsPdf = value
		End Set
		End Property
		''' <summary>
		''' 是否有上傳Excel文檔
		''' </summary>
		public Property Isexecl as Integer 
		Get
			return m_iIsexecl 
		End Get
		Set(ByVal Value As Integer)
			 m_iIsexecl = value
		End Set
		End Property
		''' <summary>
		''' 中心技術負責人
		''' </summary>
		public Property CenterTechniqueCharge as string 
		Get
			 return m_strCenterTechniqueCharge 
		End Get
		Set(ByVal Value As string)
			 m_strCenterTechniqueCharge = value
		End Set
		End Property
		''' <summary>
		''' 中心質量負責人
		''' </summary>
		public Property CenterQuantityCharge as string 
		Get
			 return m_strCenterQuantityCharge 
		End Get
		Set(ByVal Value As string)
			 m_strCenterQuantityCharge = value
		End Set
		End Property
		''' <summary>
		''' 最高主管
		''' </summary>
		public Property HighManager as string 
		Get
			 return m_strHighManager 
		End Get
		Set(ByVal Value As string)
			 m_strHighManager = value
		End Set
		End Property
		''' <summary>
		''' 品保結案
		''' </summary>
		public Property QualityFinishUser as string 
		Get
			 return m_strQualityFinishUser 
		End Get
		Set(ByVal Value As string)
			 m_strQualityFinishUser = value
		End Set
		End Property
		''' <summary>
		''' 是否變更，當進行文件變更時該記錄為1
		''' </summary>
		public Property IsChange as Integer 
		Get
			return m_iIsChange 
		End Get
		Set(ByVal Value As Integer)
			 m_iIsChange = value
		End Set
		End Property
		''' <summary>
		''' 回收部門，與分發部門相同
		''' </summary>
		public Property BackDept as Integer 
		Get
			return m_iBackDept 
		End Get
		Set(ByVal Value As Integer)
			 m_iBackDept = value
		End Set
		End Property
		''' <summary>
		''' 回收份數,與分發份數相同
		''' </summary>
		public Property BackSum as string 
		Get
			 return m_strBackSum 
		End Get
		Set(ByVal Value As string)
			 m_strBackSum = value
		End Set
		End Property
		''' <summary>
		''' 記錄類別(1:新版發行;2:文件變更;3:文件作廢)
		''' </summary>
		public Property RecordType as Integer 
		Get
			return m_iRecordType 
		End Get
		Set(ByVal Value As Integer)
			 m_iRecordType = value
		End Set
		End Property
		''' <summary>
		''' 文件狀態
		''' </summary>
		public Property FileStatus as Integer 
		Get
			return m_iFileStatus 
		End Get
		Set(ByVal Value As Integer)
			 m_iFileStatus = value
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
    ''' 預留欄位4存是否為Notes導入
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
    ''' 系統名稱
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
    ''' 技術負責人ID
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
    ''' 預留欄位品保承辦
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
		''' 預留欄位10
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

