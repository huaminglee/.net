#Region "導入命名空間"
Imports System
Imports System.Xml
Imports System.Xml.Serialization
Imports System.Runtime.Serialization
#End Region

''' <summary>實例類</summary>
''' <remarks></remarks>
<Serializable()> _
Partial Public Class QuotationInfo
#Region " Private Fields "
    Private m_iPKID As Integer = 0
    Private m_strQuotationNO As String = String.Empty
    Private m_strTestNO As String = String.Empty
		private  m_deceFlowDocID as Guid
    Private m_strStateName As String = String.Empty
    Private m_iIsFinished As Integer = 0
    Private m_dtFinishTime As DateTime = DateTime.MaxValue
    Private m_iCustomerPKID As Integer = 0
    Private m_iStateOrder As Integer = 0
    Private m_strCustomerName As String = String.Empty
    Private m_iTestCategory As Integer = 0
    Private m_strContactName As String = String.Empty
    Private m_strContactPhone As String = String.Empty
    Private m_strContactEmail As String = String.Empty
    Private m_strQuotaerName As String = String.Empty
    Private m_strQuotaerPhone As String = String.Empty
    Private m_strQuoteEmail As String = String.Empty
    Private m_dtQuoteDate As DateTime = DateTime.MaxValue
    Private m_dtFinishDate As DateTime = DateTime.MaxValue
    Private m_dtHopeFinishDATE As DateTime = DateTime.MaxValue
    Private m_iPaijia As Integer = 0
    Private m_iShijizongjia As Double = 0
    Private m_strExtend01 As String = String.Empty
    Private m_strExtend02 As String = String.Empty
    Private m_strExtend03 As String = String.Empty
    Private m_strExtend04 As String = String.Empty
    Private m_strExtend05 As String = String.Empty
    Private m_strExtend06 As String = String.Empty
    Private m_strExtend07 As String = String.Empty
    Private m_strExtend08 As String = String.Empty
    Private m_strExtend09 As String = String.Empty
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
		''' 報價單號
		''' </summary>
		public Property QuotationNO as string 
		Get
			 return m_strQuotationNO 
		End Get
		Set(ByVal Value As string)
			 m_strQuotationNO = value
		End Set
		End Property
		''' <summary>
		''' 測試單標號
		''' </summary>
		public Property TestNO as string 
		Get
			 return m_strTestNO 
		End Get
		Set(ByVal Value As string)
			 m_strTestNO = value
		End Set
		End Property
		''' <summary>
		''' 流程GUID
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
		''' 是否結案,1為結案2為需要取回的案件已確認取回
		''' </summary>
		public Property IsFinished as Integer 
		Get
			return m_iIsFinished 
		End Get
		Set(ByVal Value As Integer)
			 m_iIsFinished = value
		End Set
		End Property
		''' <summary>
    ''' 對賬時間
		''' </summary>
		public Property FinishTime as DateTime 
		Get
			return m_dtFinishTime 
		End Get
		Set(ByVal Value As DateTime)
			 m_dtFinishTime = value
		End Set
		End Property
		''' <summary>
		''' 客戶PKID
		''' </summary>
		public Property CustomerPKID as Integer 
		Get
			return m_iCustomerPKID 
		End Get
		Set(ByVal Value As Integer)
			 m_iCustomerPKID = value
		End Set
		End Property
		''' <summary>
		''' 站別
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
		''' 客戶名
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
		''' 測試類型
		''' </summary>
		public Property TestCategory as Integer 
		Get
			return m_iTestCategory 
		End Get
		Set(ByVal Value As Integer)
			 m_iTestCategory = value
		End Set
		End Property
		''' <summary>
		''' 聯繫人姓名
		''' </summary>
		public Property ContactName as string 
		Get
			 return m_strContactName 
		End Get
		Set(ByVal Value As string)
			 m_strContactName = value
		End Set
		End Property
		''' <summary>
		''' 聯繫人電話
		''' </summary>
		public Property ContactPhone as string 
		Get
			 return m_strContactPhone 
		End Get
		Set(ByVal Value As string)
			 m_strContactPhone = value
		End Set
		End Property
		''' <summary>
		''' 聯繫人郵箱
		''' </summary>
		public Property ContactEmail as string 
		Get
			 return m_strContactEmail 
		End Get
		Set(ByVal Value As string)
			 m_strContactEmail = value
		End Set
		End Property
		''' <summary>
		''' 報價人姓名
		''' </summary>
		public Property QuotaerName as string 
		Get
			 return m_strQuotaerName 
		End Get
		Set(ByVal Value As string)
			 m_strQuotaerName = value
		End Set
		End Property
		''' <summary>
		''' 報價人電話
		''' </summary>
		public Property QuotaerPhone as string 
		Get
			 return m_strQuotaerPhone 
		End Get
		Set(ByVal Value As string)
			 m_strQuotaerPhone = value
		End Set
		End Property
		''' <summary>
		''' 
		''' </summary>
		public Property QuoteEmail as string 
		Get
			 return m_strQuoteEmail 
		End Get
		Set(ByVal Value As string)
			 m_strQuoteEmail = value
		End Set
		End Property
		''' <summary>
		''' 報價日期
		''' </summary>
		public Property QuoteDate as DateTime 
		Get
			return m_dtQuoteDate 
		End Get
		Set(ByVal Value As DateTime)
			 m_dtQuoteDate = value
		End Set
		End Property
		''' <summary>
    ''' 報價結束時間
		''' </summary>
		public Property FinishDate as DateTime 
		Get
			return m_dtFinishDate 
		End Get
		Set(ByVal Value As DateTime)
			 m_dtFinishDate = value
		End Set
		End Property
		''' <summary>
		''' 希望完成日期
		''' </summary>
		public Property HopeFinishDATE as DateTime 
		Get
			return m_dtHopeFinishDATE 
		End Get
		Set(ByVal Value As DateTime)
			 m_dtHopeFinishDATE = value
		End Set
		End Property
		''' <summary>
		''' 牌價
		''' </summary>
		public Property Paijia as Integer 
		Get
			return m_iPaijia 
		End Get
		Set(ByVal Value As Integer)
			 m_iPaijia = value
		End Set
		End Property
		''' <summary>
		''' 實際總價
		''' </summary>
    Public Property Shijizongjia() As Double
        Get
            Return m_iShijizongjia
        End Get
        Set(ByVal Value As Double)
            m_iShijizongjia = Value
        End Set
    End Property
		''' <summary>
    ''' 聯繫人ID
		''' </summary>
		public Property Extend01 as string 
		Get
			 return m_strExtend01 
		End Get
		Set(ByVal Value As string)
			 m_strExtend01 = value
		End Set
		End Property
		''' <summary>
    ''' 樣品取回
		''' </summary>
		public Property Extend02 as string 
		Get
			 return m_strExtend02 
		End Get
		Set(ByVal Value As string)
			 m_strExtend02 = value
		End Set
		End Property
		''' <summary>
    ''' 報價人ID
		''' </summary>
		public Property Extend03 as string 
		Get
			 return m_strExtend03 
		End Get
		Set(ByVal Value As string)
			 m_strExtend03 = value
		End Set
		End Property
		''' <summary>
    ''' 報價人Fax
		''' </summary>
		public Property Extend04 as string 
		Get
			 return m_strExtend04 
		End Get
		Set(ByVal Value As string)
			 m_strExtend04 = value
		End Set
		End Property
		''' <summary>
    ''' 聯繫人Fax
		''' </summary>
		public Property Extend05 as string 
		Get
			 return m_strExtend05 
		End Get
		Set(ByVal Value As string)
			 m_strExtend05 = value
		End Set
		End Property
		''' <summary>
    ''' 成本價
		''' </summary>
		public Property Extend06 as string 
		Get
			 return m_strExtend06 
		End Get
		Set(ByVal Value As string)
			 m_strExtend06 = value
		End Set
		End Property
		''' <summary>
    ''' 是否需要開發票
		''' </summary>
		public Property Extend07 as string 
		Get
			 return m_strExtend07 
		End Get
		Set(ByVal Value As string)
			 m_strExtend07 = value
		End Set
		End Property
		''' <summary>
    ''' 最低優惠比例
		''' </summary>
		public Property Extend08 as string 
		Get
			 return m_strExtend08 
		End Get
		Set(ByVal Value As string)
			 m_strExtend08 = value
		End Set
		End Property
		''' <summary>
		''' 
		''' </summary>
		public Property Extend09 as string 
		Get
			 return m_strExtend09 
		End Get
		Set(ByVal Value As string)
			 m_strExtend09 = value
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

