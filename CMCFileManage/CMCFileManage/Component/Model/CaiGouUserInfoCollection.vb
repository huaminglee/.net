#region "導入命名空間"
Imports System
Imports System.Collections

#end region

''' <summary>
''' 採購人員信息集合類
''' </summary>
''' <remarks></remarks>
Public NotInheritable Class CaiGouUserInfoCollection
    Inherits ArrayList


#Region "Entity Convert"
    ''' <summary>
    ''' 將實體對象集合轉換為實體泛型集合
    ''' </summary>
    ''' <param name="Collection">實體對象集合</param>
    ''' <returns>實體泛型集合</returns>
    ''' <remarks></remarks>
    Public Shared Function Convert2EntityList(ByVal Collection As CaiGouUserInfoCollection) As List(Of CaiGouUserInfo)
        If (Not Collection Is Nothing) AndAlso (Collection.Count > 0) Then
            Dim list As New List(Of CaiGouUserInfo)
            For Each m As CaiGouUserInfo In Collection
                list.Add(m)
            Next
            Return list
        Else
            Return Nothing
        End If
    End Function
#End Region
End Class

