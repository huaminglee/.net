Public Class XmlData

    Private m_StrCName As String
    Private m_StrEName As String
    Private m_StrImageUrl As String

    Public Property CName() As String
        Get
            Return m_StrCName
        End Get
        Set(ByVal value As String)
            m_StrCName = value
        End Set
    End Property


    Public Property EName() As String
        Get
            Return m_StrEName
        End Get
        Set(ByVal value As String)
            m_StrEName = value
        End Set
    End Property


    Public Property ImageUrl() As String
        Get
            Return m_StrImageUrl
        End Get
        Set(ByVal value As String)
            m_StrImageUrl = value
        End Set
    End Property

End Class
