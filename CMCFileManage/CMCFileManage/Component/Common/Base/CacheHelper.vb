Imports System.Collections.Generic
Imports System.Web
Imports System

''' <summary> 
''' 缓存控制类 
''' </summary> 
Public Class CacheHelper
    Public Shared AllUseCacheKey As New List(Of String)()
    ''' <summary> 
    ''' 添加缓存 
    ''' </summary> 
    ''' <param name="key"></param> 
    ''' <param name="value"></param> 
    ''' <param name="absoluteExpiration"></param> 
    Public Shared Sub AddCache(ByVal key As String, ByVal value As Object, ByVal absoluteExpiration As DateTime)
        If Not AllUseCacheKey.Contains(key) Then
            AllUseCacheKey.Add(key)
        End If
        HttpContext.Current.Cache.Add(key, value, Nothing, absoluteExpiration, TimeSpan.Zero, System.Web.Caching.CacheItemPriority.Normal, _
         Nothing)
    End Sub

    ''' <summary> 
    ''' 移除缓存 
    ''' </summary> 
    ''' <param name="key"></param> 
    Public Shared Sub RemoveCache(ByVal key As String)
        If AllUseCacheKey.Contains(key) Then
            AllUseCacheKey.Remove(key)
        End If
        HttpContext.Current.Cache.Remove(key)
    End Sub

    ''' <summary> 
    ''' 清空使用的缓存 
    ''' </summary> 
    Public Shared Sub ClearCache()
        For Each value As String In AllUseCacheKey
            HttpContext.Current.Cache.Remove(value)
        Next
        AllUseCacheKey.Clear()
    End Sub
End Class

