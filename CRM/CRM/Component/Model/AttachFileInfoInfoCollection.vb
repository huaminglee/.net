#region "導入命名空間"
Imports System
Imports System.Collections
Imports System.Runtime.Serialization
#end region

''' <summary>
''' 集合類
''' </summary>
''' <remarks></remarks>
<DataContract()> _
<Serializable()> _
Public NotInheritable Class AttachFileInfoInfoCollection
    Private _AttachFileInfoInfoList As List(Of AttachFileInfoInfo)
    ''' <summary>
    ''' 集合類
    ''' </summary>
    ''' <value></value>
    ''' <returns>List(Of AttachFileInfoInfo)</returns>
    ''' <remarks></remarks>
    <DataMember()> _
    Public Property AttachFileInfoInfoList() As List(Of AttachFileInfoInfo)
        Get
            Return _AttachFileInfoInfoList
        End Get
        Set(ByVal value As List(Of AttachFileInfoInfo))
            _AttachFileInfoInfoList = value
        End Set
    End Property
End Class

#Region"排序比較類"

#end region 


