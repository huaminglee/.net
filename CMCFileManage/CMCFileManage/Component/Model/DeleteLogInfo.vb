#Region "導入命名空間"
Imports System
Imports System.Xml
Imports System.Xml.Serialization
Imports System.Runtime.Serialization
#End Region

''' <summary>實例類</summary>
''' <remarks></remarks>
<Serializable()> _
Partial Public Class DeleteLogInfo
#Region " Private Fields "
    Private m_ipkid As Integer = 0
    Private m_iParentid As Integer = 0
    Private m_strparenttype As String = String.Empty
    Private m_strDeleteUserSID As String = String.Empty
    Private m_strDeleteUserName As String = String.Empty
    Private m_dtRecordCreated As DateTime = DateTime.Now

#End Region

#Region " Public Properties"
		''' <summary>
		''' 
		''' </summary>
		public Property pkid as Integer 
		Get
			return m_ipkid 
		End Get
		Set(ByVal Value As Integer)
			 m_ipkid = value
		End Set
		End Property
		''' <summary>
		''' 
		''' </summary>
		public Property Parentid as Integer 
		Get
			return m_iParentid 
		End Get
		Set(ByVal Value As Integer)
			 m_iParentid = value
		End Set
		End Property
		''' <summary>
		''' 
		''' </summary>
		public Property parenttype as string 
		Get
			 return m_strparenttype 
		End Get
		Set(ByVal Value As string)
			 m_strparenttype = value
		End Set
		End Property
		''' <summary>
		''' 
		''' </summary>
		public Property DeleteUserSID as string 
		Get
			 return m_strDeleteUserSID 
		End Get
		Set(ByVal Value As string)
			 m_strDeleteUserSID = value
		End Set
		End Property
		''' <summary>
		''' 
		''' </summary>
		public Property DeleteUserName as string 
		Get
			 return m_strDeleteUserName 
		End Get
		Set(ByVal Value As string)
			 m_strDeleteUserName = value
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

#End Region
End Class

