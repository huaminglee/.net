Imports Platform.eHR.Core
Imports System.Web
Imports System.Web.Services
Imports System.Reflection
Imports System.IO
Imports System.Net

Public Class JqueryS
    Implements System.Web.IHttpHandler
    Dim Request As HttpRequest
    Dim Response As HttpResponse
    Sub ProcessRequest(ByVal context As HttpContext) Implements IHttpHandler.ProcessRequest

        context.Response.ContentType = "text/plain"
        Request = context.Request
        Response = context.Response
        Dim Method As String = context.Request("Method").ToString()
        Dim methodInfo As MethodInfo = Me.GetType().GetMethod(Method)
        methodInfo.Invoke(Me, Nothing)
        context.Response.Flush()
        context.Response.End()


    End Sub

    Public Sub TestHello()
        Response.Write("Hello World!")

    End Sub
    Public Sub Contact()
        Dim row As Integer = CInt(Request("rows").ToString())
        Dim page As Integer = CInt(Request("page").ToString())
        Dim TotalRecord As Integer = 0
        Dim ContactName As String = Request("ContactName")
        Dim ds As DataSet
        If ContactName <> String.Empty Then
            ds = ContactDAL.GetdsByContactName(ContactName)
        Else
            ds = GridViewPage.GetPageInfoBySearchCondition("Contact", "", "*", "UserName", row, page, TotalRecord)
        End If
        Dim Contact As List(Of String) = New List(Of String)
        Contact.Add("PKID")
        Contact.Add("UserName")
        Contact.Add("UserSID")
        Contact.Add("CustomerName")
        If Not ds Is Nothing Then
            Dim AllCount As Integer = CInt(ds.Tables(1).Rows(0)("TotalRecord"))
            Dim text As String = Json.ToJson(AllCount, ds.Tables(0), Contact)
            Response.Write(text)
        Else
            Response.Write("{""rows"":[""]}")
        End If
    End Sub
    Public Sub Customer()
        Dim row As Integer = CInt(Request("rows").ToString())
        Dim page As Integer = CInt(Request("page").ToString())
        Dim TotalRecord As Integer = 0
        Dim customername As String = Request("CustomerName")
        Dim ds As DataSet
        If customername <> String.Empty Then
            ds = CustomersDAL.GetInfoByCustomername(customername)
        Else
            ds = GridViewPage.GetPageInfoBySearchCondition("Customers", "", "*", "CustomerName", row, page, TotalRecord)

        End If

        Dim customer As List(Of String) = New List(Of String)
        customer.Add("PKID")
        customer.Add("CustomerID")
        customer.Add("CustomerName")
        customer.Add("CustomerEnglishName")
        customer.Add("Industry")

        If Not ds Is Nothing Then
            Dim AllCount As Integer = CInt(ds.Tables(1).Rows(0)("TotalRecord"))
            Dim text As String = Json.ToJson(AllCount, ds.Tables(0), customer)
            Response.Write(text)
        Else
            Response.Write("{""rows"":[""]}")
        End If
    End Sub
    Public Sub CodeUder()
        Dim row As Integer = CInt(Request("rows").ToString())
        Dim page As Integer = CInt(Request("page").ToString())
        Dim UserID As String = Request("UserID").ToString
        Dim SearchCondition As String = "AccountScope=2 "

        If UserID <> String.Empty Then
            SearchCondition = SearchCondition + "  and  UserName='" + UserID + "'"
        End If


        Dim Ds As DataSet = AccountManage.LoadAccountByPaging(row, page, 0, "AccountPKID,UserSID,UserName,Email1,Telphone", SearchCondition)
        Dim UserInfo As List(Of String) = New List(Of String)
        UserInfo.Add("AccountPKID")
        UserInfo.Add("UserSID")
        UserInfo.Add("UserSID")
        UserInfo.Add("UserName")
        UserInfo.Add("Email1")
        UserInfo.Add("Telphone")
        If Not Ds Is Nothing Then
            Dim AllCount As Integer = CInt(Ds.Tables(1).Rows(0)("TotalRecord"))
            Dim text As String = Json.ToJson(AllCount, Ds.Tables(0), UserInfo)
            Response.Write(text)
        Else
            Response.Write("{""rows"":[""]}")
        End If

    End Sub


    Public Function GetTestItemBySamplePKID()

        Dim SamplePKID As String = Request("SamplePKID").ToString

        If SamplePKID = "0" Then
            Response.Write("{""rows"":[""]}")
        Else
            Dim DT As DataTable = TestItemDetailDAL.GetInfoSamplePKID(SamplePKID)

            Dim Result As String = Json.ToJson(DT)
            Response.Write(Result)
        End If
    End Function

    Public Sub SampleInfoAndTestItem()
        Dim PKID As String = Request("PKID").ToString
        If PKID = "0" Then
            Response.Write("{""rows"":[""]}")
        Else
            Dim DT As DataTable
            If Request("Type") Is Nothing Then
                DT = SampleInfoDAL.GetSampleAndTestItemByQuotationPKID(PKID)
            Else
                DT = SampleInfoDAL.GetSampleAndTestItem(PKID)
            End If

            Dim Result As String = Json.ToJson(DT)
            Response.Write(Result)
        End If

    End Sub

    Public Sub SampleInfo()
        Dim PKID As String = Request("PKID").ToString
        If PKID = "0" Then
            Response.Write("{""rows"":[""]}")
        Else
            Dim DT As DataTable
            If Request("Type") Is Nothing Then
                DT = SampleInfoDAL.GetSampleInfoByQuotationPKID(PKID)
            Else
                DT = SampleInfoDAL.GetSampleInfoByPKID(PKID)
            End If

            Dim Result As String = Json.ToJson(DT)
            Response.Write(Result)
        End If

    End Sub
    Public Sub GetTestItem()


        Dim Returnstring = "{""rows"":[""]}"


        Dim DT As DataTable = TestItemManageDAL.GetAllItem()
        If Not DT Is Nothing AndAlso DT.Rows.Count > 0 Then
            Dim text As String = Json.ToJson(DT)
            Response.Write(text)
        Else
            Response.Write(Returnstring)
        End If



    End Sub
    Public Sub GetAllItemBySerVicePKID()

        Dim TestServicePKID As String = Request("TestServicePKID").ToString
        Dim Returnstring = "{""rows"":[""]}"


        Dim DT As DataTable = TestItemManageDAL.GetAllItemByTestServicePKID(TestServicePKID)
        If Not DT Is Nothing AndAlso DT.Rows.Count > 0 Then
            Dim text As String = Json.ToJson(DT)
            Response.Write(text)
        Else
            Response.Write(Returnstring)
        End If



    End Sub
    Public Sub GetAllItemByLbServiceName()

        Dim LbServiceName As String = Request("LbServiceName").ToString

       

        LbServiceName = HttpUtility.UrlDecode(LbServiceName)

        Dim Returnstring = "{""rows"":[""]}"


        Dim DT As DataTable = TestItemManageDAL.GetAllItemByTestLbServiceName(LbServiceName)
        If Not DT Is Nothing AndAlso DT.Rows.Count > 0 Then
            Dim text As String = Json.ToJson(DT)
            Response.Write(text)
        Else
            Response.Write(Returnstring)
        End If



    End Sub
    Public Sub GetTestService()
        Dim Returnstring = "{""rows"":[""]}"


        Dim DT As DataTable = TestItemManageDAL.GetAllService()
        If Not DT Is Nothing AndAlso DT.Rows.Count > 0 Then
            Dim text As String = Json.ToJson(DT)
            Response.Write(text)
        Else
            Response.Write(Returnstring)
        End If
    End Sub
    Public Sub GetreportInfo()
        Dim mPKID As Integer = CInt(Request("PKID"))
        If mPKID = 0 Then
            Response.Write("{""rows"":[""]}")
        Else
            Dim SearchOption As String = " RecordDeleted =0 and ParentCategory=2 AND ParentSubCategory=2 and ParentID=" + mPKID.ToString
            Dim FileInfos As DataSet = WF_AttachFileInfoDAL.GetdsnocontentInfoBySearchCondtion(SearchOption)
            If Not FileInfos Is Nothing Then
                Dim DT As DataTable = FileInfos.Tables(0)
                Dim Result As String = Json.ToJson(DT)
                Response.Write(Result)
            Else
                Response.Write("{""rows"":[""]}")
            End If
        End If
    End Sub
    Public Sub VisitsInfo()
        Dim PKID As String = Request("PKID").ToString
        If PKID = "0" Then
            Response.Write("{""rows"":[""]}")
        Else
            Dim DT As DataTable

            DT = VisitsPersonDAL.GetPersonInfoByCustomerVisitsPKID(PKID)


            Dim Result As String = Json.ToJson(DT)
            Response.Write(Result)
        End If

    End Sub
    ReadOnly Property IsReusable() As Boolean Implements IHttpHandler.IsReusable
        Get
            Return False
        End Get
    End Property

End Class