Imports System.Web.Services
Imports System.Web.Services.Protocols
Imports System.ComponentModel

' 若要允許使用 ASP.NET AJAX 從指令碼呼叫此 Web 服務，請取消註解下一行。
' <System.Web.Script.Services.ScriptService()> _
<System.Web.Services.WebService(Namespace:="http://tempuri.org/")> _
<System.Web.Services.WebServiceBinding(ConformsTo:=WsiProfiles.BasicProfile1_1)> _
<ToolboxItem(False)> _
Public Class WebService
    Inherits System.Web.Services.WebService

    <WebMethod()> _
    Public Function HelloWorld() As String
       Return "Hello World"
    End Function
    <WebMethod()> _
    Public Function GetSysNews(ByVal SercvicePKID As Integer) As DataTable
        Return Sys_NewsDAL.GetDtInfoBySearchCondtion("  ServicePKID=" + SercvicePKID.ToString + " and  EndTime>getdate() ")
    End Function
    <WebMethod()> _
   Public Sub OtherQYSendOutMail(ByVal MailAddress As String, ByVal subject As String, ByVal content As String, ByVal cc As String)
        SendOutMail.SendMail(MailAddress, subject, content, cc)
    End Sub
End Class