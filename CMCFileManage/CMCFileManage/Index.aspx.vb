Imports System.Web.Services

Partial Public Class Index
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub
    <WebMethod()> _
Public Function GetSysNews(ByVal SercvicePKID As Integer) As DataTable
        Return Sys_NewsDAL.GetDtInfoBySearchCondtion("  ServicePKID=" + SercvicePKID.ToString + " and  EndTime>getdate() ")
    End Function
End Class