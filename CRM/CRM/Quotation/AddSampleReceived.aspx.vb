Imports Platform.eAuthorize
Imports System.Web.Services

Partial Public Class AddSampleReceived
    Inherits System.Web.UI.Page
#Region "Const"
    Private Const HIDE_APPLICANTIDX_KEY As String = "ViewState:PKID"
#End Region
#Region "Properties"

    '當前文件惟一ID
    Private Property PKID() As Integer
        Get
            If ViewState(HIDE_APPLICANTIDX_KEY) Is Nothing Then
                Return 0
            End If

            Return Convert.ToInt32(ViewState(HIDE_APPLICANTIDX_KEY))
        End Get
        Set(ByVal Value As Integer)
            ViewState(HIDE_APPLICANTIDX_KEY) = Value
        End Set
    End Property
    Private _AddSampleReceived As SamplesReceivedInfo
    Private Property AddSampleReceived() As SamplesReceivedInfo
        Get
            If _AddSampleReceived Is Nothing Then
                If PKID <> 0 Then
                    _AddSampleReceived = SamplesReceivedDAL.GetInfoByPKID(PKID)
                Else
                    _AddSampleReceived = New SamplesReceivedInfo()
                End If
            End If
            Return _AddSampleReceived
        End Get
        Set(ByVal value As SamplesReceivedInfo)
            _AddSampleReceived = value
        End Set
    End Property
#End Region
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            GetParam()
            Me.TxtKDHumanName.Attributes.Add("readonly", True)
            Me.TxtKDHumanNO.Attributes.Add("readonly", True)
            BindDPL()
            BindControlData()
        End If
    End Sub
    Private Sub GetParam()
        If Not Request.QueryString("PKID") Is Nothing Then
            PKID = Convert.ToInt32(Request.QueryString("PKID"))
        End If
    End Sub
    Private Sub BindDPL()
        Dim sourcexmlpath As String = Server.MapPath("~") + "\XMLData\ReceivedSampleAddress.xml"
        Dim ds As DataSet = New DataSet
        ds.ReadXml(sourcexmlpath)
        Me.DplReceivedAddress.DataSource = ds
        Me.DplReceivedAddress.DataTextField = "value"
        Me.DplReceivedAddress.DataValueField = "key"
        Me.DplReceivedAddress.DataBind()
    End Sub

    Private Sub BindControlData()
        If Not AddSampleReceived Is Nothing Then
            If PKID = 0 Then
                Me.TxtAcceptUser.Text = UserInfo.CurrentUserID.ToString + "/" + UserInfo.CurrentUserCHName
                Me.TxtReachTime.Text = DateTime.Now.ToString()
                'Me.TxtReachTime.Attributes.Add("onclick", "javascript:WdatePicker({isShowClear:false,startDate:'%y-%M-01',dateFmt:'yyyy-MM-dd'});")
            Else
                Me.signtable.Visible = True
                Me.BtnGet.Text = "再次通知業務員"
                Me.TxtAcceptUser.Text = AddSampleReceived.AcceptUser
                Me.TxtCustomerName.Text = AddSampleReceived.CustomerName
                Me.HiddenCustomerName.Value = AddSampleReceived.CustomerName
                Me.HiddenCustomerPKID.Value = AddSampleReceived.CustomerPKID
                Me.HiddenEmail.Value = AddSampleReceived.InformEmail
                Me.HiddenPersonIncharge.Value = AddSampleReceived.InformUser
                Me.HiddenPersonSid.Value = AddSampleReceived.Extend01
                Me.TxtReachTime.Text = AddSampleReceived.ReachTime
                Me.TxtRemark.Text = AddSampleReceived.Remark
                Me.TxtSamples.Text = AddSampleReceived.SampleName
                Me.TxtSamplesNums.Text = AddSampleReceived.SampleNums
                Me.LbPersonIncharge.Text = AddSampleReceived.InformUser
                Me.LbEmail.Text = AddSampleReceived.InformEmail
                Me.TxtCourier.Text = AddSampleReceived.Extend03
                Me.TxtCourierNo.Text = AddSampleReceived.Extend04
                If AddSampleReceived.IsTakeaway = 1 Then
                    Me.duka.Visible = False
                    Me.Button1.Visible = False
                    Me.TxtKDHumanName.Text = AddSampleReceived.TakeawayUser
                    Me.TxtKDHumanNO.Text = AddSampleReceived.Extend02
                    Me.LbSigngtime.Text = AddSampleReceived.TakeawayTime
                End If
            End If
        End If
    End Sub

    Protected Sub BtnGet_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BtnGet.Click
        If Not Me.HiddenCustomerPKID.Value = 0 Then
            AddSampleReceived.CustomerName = Me.HiddenCustomerName.Value
            AddSampleReceived.CustomerPKID = Me.HiddenCustomerPKID.Value
            AddSampleReceived.AcceptUser = Me.TxtAcceptUser.Text
            AddSampleReceived.InformUser = Me.HiddenPersonIncharge.Value
            AddSampleReceived.InformEmail = Me.HiddenEmail.Value
            AddSampleReceived.SampleName = Me.TxtSamples.Text
            AddSampleReceived.SampleNums = Me.TxtSamplesNums.Text
            AddSampleReceived.Remark = Me.TxtRemark.Text
            AddSampleReceived.Extend03 = Me.TxtCourier.Text
            AddSampleReceived.Extend04 = Me.TxtCourierNo.Text
            AddSampleReceived.ReceivedAddress = Me.DplReceivedAddress.SelectedItem.Text
            AddSampleReceived.Extend01 = Me.HiddenPersonSid.Value

            If PKID = 0 Then
                AddSampleReceived.ReachTime = Me.TxtReachTime.Text
                AddSampleReceived.RecordCreated = DateTime.Now
            End If

            Dim addsampledal As SamplesReceivedDAL = New SamplesReceivedDAL(AddSampleReceived)
            addsampledal.Save()
            Try
                Dim Title As String = String.Format("※CRM系統※ 您的客戶：{0}有樣品倉庫已經收件({1})", Me.HiddenCustomerName.Value, Me.HiddenPersonIncharge.Value)
                Dim info As String = String.Format("CRM系統 您的客戶：<font color='blue'>{0} </font>有樣品:<font color='blue'>{1}</font> 數量：<font color='red'>{3}</font> 倉庫已經收件，快遞公司：<font color='blue'>{4}</font> 快遞單號：<font color='blue'>{5}</font>; 說明：<font color='blue'>{2}</font>", Me.HiddenCustomerName.Value, Me.TxtSamples.Text, Me.TxtRemark.Text, Me.TxtSamplesNums.Text, Me.TxtCourier.Text, Me.TxtCourierNo.Text)
                QuotationInvoid.SendMail(Me.HiddenEmail.Value, Title, info)
            Catch ex As Exception

            End Try
            Response.Redirect("../Quotation/SampelReceivedList.aspx?Type=0")
        End If
    End Sub
    <WebMethod()> _
 Public Shared Function GetCustomers() As List(Of DictionaryEntry)
        Dim mCustomerInfo As List(Of DictionaryEntry) = CustomersDAL.GetCustomerandPersonIncharge()
        Return mCustomerInfo
    End Function

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button1.Click
        If Me.Hiddenhumanname.Value <> String.Empty AndAlso Me.Hiddenhumanno.Value <> String.Empty Then

            AddSampleReceived.IsTakeaway = 1
            AddSampleReceived.Extend02 = Me.Hiddenhumanno.Value
            AddSampleReceived.TakeawayUser = Me.Hiddenhumanname.Value
            AddSampleReceived.TakeawayTime = DateTime.Now.ToString
            Dim addsampledal As SamplesReceivedDAL = New SamplesReceivedDAL(AddSampleReceived)
            addsampledal.Save()
            BindControlData()
        End If
    End Sub
End Class