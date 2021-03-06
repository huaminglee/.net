Imports System.Data.SqlClient
Imports System.Configuration
Imports Platform.eAuthorize

Public Class CtlGMPCSIMoudle
    Inherits System.Web.UI.UserControl

#Region " Web Form 設計工具產生的程式碼 "

    '此為 Web Form 設計工具所需的呼叫。
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents BtnSubmit1 As System.Web.UI.WebControls.Button
    Protected WithEvents lblTitle As System.Web.UI.WebControls.Label
    Protected WithEvents lblHead As System.Web.UI.WebControls.Label
    Protected WithEvents lblDeptName As System.Web.UI.WebControls.Label
    Protected WithEvents lblCSIExplain As System.Web.UI.WebControls.Label
    Protected WithEvents LblNotice As System.Web.UI.WebControls.Label
    Protected WithEvents lblItem1 As System.Web.UI.WebControls.Label
    Protected WithEvents TxtGroup As System.Web.UI.WebControls.TextBox
    Protected WithEvents RequiredFieldValidator1 As System.Web.UI.WebControls.RequiredFieldValidator
    Protected WithEvents TxtDept As System.Web.UI.WebControls.TextBox
    Protected WithEvents RequiredFieldValidator2 As System.Web.UI.WebControls.RequiredFieldValidator
    Protected WithEvents TxtUnit As System.Web.UI.WebControls.TextBox
    Protected WithEvents RequiredFieldValidator3 As System.Web.UI.WebControls.RequiredFieldValidator
    Protected WithEvents TxtVisitor As System.Web.UI.WebControls.TextBox
    Protected WithEvents RequiredFieldValidator4 As System.Web.UI.WebControls.RequiredFieldValidator
    Protected WithEvents TxtExt As System.Web.UI.WebControls.TextBox
    Protected WithEvents Txtcusphone As System.Web.UI.WebControls.TextBox
    Protected WithEvents TxtFax As System.Web.UI.WebControls.TextBox
    Protected WithEvents TxtWebSite As System.Web.UI.WebControls.TextBox
    Protected WithEvents RequiredFieldValidator5 As System.Web.UI.WebControls.RequiredFieldValidator
    Protected WithEvents RegularExpressionValidator1 As System.Web.UI.WebControls.RegularExpressionValidator
    Protected WithEvents TxtEmail As System.Web.UI.WebControls.TextBox
    Protected WithEvents RequiredFieldValidator6 As System.Web.UI.WebControls.RequiredFieldValidator
    Protected WithEvents lblItem2 As System.Web.UI.WebControls.Label
    Protected WithEvents DataGrid1 As System.Web.UI.WebControls.DataGrid
    Protected WithEvents DataGrid3 As System.Web.UI.WebControls.DataGrid
    Protected WithEvents lblItem3 As System.Web.UI.WebControls.Label
    Protected WithEvents Datagrid2 As System.Web.UI.WebControls.DataGrid
    Protected WithEvents lblEnd As System.Web.UI.WebControls.Label
    Protected WithEvents BtnSubmit2 As System.Web.UI.WebControls.Button
    Protected WithEvents TableContent As System.Web.UI.HtmlControls.HtmlTable
    Protected WithEvents txtDeptName As System.Web.UI.HtmlControls.HtmlInputText
    Protected WithEvents Label2 As System.Web.UI.WebControls.Label
    Protected WithEvents TableOutDate As System.Web.UI.HtmlControls.HtmlTable
    Protected WithEvents lblSearchResult As System.Web.UI.WebControls.Label
    Protected WithEvents CSIStatus As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents BtnBack As System.Web.UI.HtmlControls.HtmlInputButton
    Protected WithEvents lblCSITitle As System.Web.UI.WebControls.Label


    '注意: 下列預留位置宣告是 Web Form 設計工具需要的項目。
    '請勿刪除或移動它。
    Private designerPlaceholderDeclaration As System.Object

    Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
        'CODEGEN: 此為 Web Form 設計工具所需的方法呼叫
        '請勿使用程式碼編輯器進行修改。
        InitializeComponent()
    End Sub

#End Region

#Region "Const Define"
    Private Const HIDE_ClientPKID As String = "ViewState:ClientPKID"
    Private Const HIDE_DeptPKID As String = "ViewState:DeptPKID"
    Private Const HIDE_CSITime As String = "ViewState:CSITime"
    Private _mCSIResult As GEPCSI_Result
#End Region

#Region "Properties"
    Private Property ClientPKID() As Integer
        Get
            If ViewState(HIDE_ClientPKID) Is Nothing Then
                Return 0
            End If
            Return Convert.ToInt32(ViewState(HIDE_ClientPKID))
        End Get
        Set(ByVal Value As Integer)
            ViewState(HIDE_ClientPKID) = Value
        End Set
    End Property
    Private Property DeptPKID() As Integer
        Get
            If ViewState(HIDE_DeptPKID) Is Nothing Then
                Return 0
            End If
            Return Convert.ToInt32(ViewState(HIDE_DeptPKID))
        End Get
        Set(ByVal Value As Integer)
            ViewState(HIDE_DeptPKID) = Value
        End Set
    End Property
    Private Property CSITime() As Integer
        Get
            If ViewState(HIDE_CSITime) Is Nothing Then
                Return 0
            End If
            Return Convert.ToInt32(ViewState(HIDE_CSITime))
        End Get
        Set(ByVal Value As Integer)
            ViewState(HIDE_CSITime) = Value
        End Set
    End Property

    ' 當前的滿意度調查主表信息
    Private Property mCSIResult() As GEPCSI_Result
        Get
            If _mCSIResult Is Nothing Then
                If ClientPKID <> 0 Then
                    _mCSIResult = GEPCSI_Result.GetInfoByPKID(ClientPKID)
                Else
                    _mCSIResult = New GEPCSI_Result

                End If
            End If

            Return _mCSIResult
        End Get
        Set(ByVal Value As GEPCSI_Result)
            _mCSIResult = Value
        End Set
    End Property
#End Region

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        '在這裡放置使用者程式碼以初始化網頁
        If Not IsPostBack Then

            If Not Request.QueryString("ClientPKID") Is Nothing Then
                ClientPKID = CInt(Request.QueryString("ClientPKID"))
            End If

            If Not Request.QueryString("CSITime") Is Nothing Then
                CSITime = Convert.ToInt32(Request.QueryString("CSITime"))
            End If

            If Not Request.QueryString("DeptPKID") Is Nothing Then
                DeptPKID = Convert.ToInt32(Request.QueryString("DeptPKID"))
            End If
            BindControlText()
        End If
        RegisterScript()
    End Sub

#Region "Self Define Sub/function"
    Private Sub BindControlText()
        Dim Last As GEPCSI_Period
        If CSITime = 0 Then
            Last = GEPCSI_Period.GetLastPeriod
            If Not Last Is Nothing Then
                CSITime = Last.CSITime
            End If

        Else
            Last = GEPCSI_Period.GetInfoByPKID(CSITime)
        End If
        Dim IsDeal As Boolean = False
        If Not Last Is Nothing AndAlso CSITime <> 0 Then
            IsDeal = Last.StartDate <= FormatDateTime(Date.Now, DateFormat.ShortDate) AndAlso Last.EndDate >= FormatDateTime(Date.Now, DateFormat.ShortDate)
        End If
        If IsDeal = False Then
            Me.lblEnd.Text = "本次调查已结束，感谢您的配合！"
            Me.TableOutDate.Visible = True
            Me.BtnSubmit1.Visible = False
            Me.BtnSubmit2.Visible = False
            Me.TableContent.Visible = False
            Exit Sub

        End If
        Dim mGEPDept As GEPCSI_Dept = GEPCSI_Dept.GetInfoByPKID(DeptPKID)
        Me.lblCSITitle.Text = String.Format("华南检测中心({0})", mGEPDept.DeptName)
        Me.txtDeptName.Value = mGEPDept.DeptName
        Me.lblHead.Text = "尊敬的客户:"
        Me.lblTitle.Text = "客户满意度调查——————"
        Me.lblCSIExplain.Text = mGEPDept.CSIExplain
        Me.lblCSIExplain.Text += "</br>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;本次调查(" + Last.StartDate.ToShortDateString + "~" + Last.EndDate.ToShortDateString + ")为期" + DateDiff(DateInterval.Day, Last.StartDate, Last.EndDate).ToString + "天"
        Me.LblNotice.Text = "本次调查说明" + Last.Notice
        Me.lblItem1.Text = "调查表填写人信息:"
        Me.lblItem2.Text = "单选项目"
        Me.lblItem3.Text = "问答项目:"
        If mCSIResult.IsSubmited = 1 Then
            Me.TxtGroup.Text = mCSIResult.AcceptGroup
            Me.TxtDept.Text = mCSIResult.AcceptDivision
            Me.TxtUnit.Text = mCSIResult.AcceptDept
            Me.TxtVisitor.Text = mCSIResult.AcceptMan
            Me.TxtExt.Text = mCSIResult.AcceptExt
            Me.TxtEmail.Text = mCSIResult.AcceptEmail
        ElseIf mCSIResult.IsSubmited = 2 Then
            Me.TxtGroup.Text = mCSIResult.SubmitGroup
            Me.TxtDept.Text = mCSIResult.SubmitDivision
            Me.TxtUnit.Text = mCSIResult.SubmitDept
            Me.TxtVisitor.Text = mCSIResult.SubmitMan
            Me.TxtExt.Text = mCSIResult.SubmitExt
            Me.TxtEmail.Text = mCSIResult.SubmitEmail
            Me.TxtWebSite.Text = mCSIResult.Extend3
            Me.Txtcusphone.Text = mCSIResult.Extend1
            Me.TxtFax.Text = mCSIResult.Extend2
            If CSITime > 0 Then
                Me.BtnSubmit1.Visible = False
                Me.BtnSubmit2.Visible = False
            End If
        ElseIf mCSIResult.IsSubmited = 0 Then       '被動調查
            If Not UserInfo.CurrentUserInstance Is Nothing Then
                Me.TxtVisitor.Text = UserInfo.CurrentUserCHName
                Me.TxtEmail.Text = UserInfo.CurrentEmail
                Me.TxtExt.Text = UserInfo.CurrentUserInstance.Telphone
                Me.TxtDept.Text = UserInfo.CurrentUserInstance.DeptName
            End If
        End If

        BindDataGrid()
        
    End Sub
    Private Sub RegisterScript()
    End Sub

    Private Sub BindDataGrid()
        Dim SearchCondition As String = " DeptPKID=" + DeptPKID.ToString
        Dim ds As DataSet
        If mCSIResult.IsSubmited = 2 Then
            SearchCondition = " ResultPKID=" + ClientPKID.ToString
            ds = GEPCSI_DetailResult.GetDsBySearchCondtion(SearchCondition)
        Else
            SearchCondition = " DeptPKID=" + DeptPKID.ToString
            ds = GEPCSI_DeptItem.GetDsBySearchCondtion(SearchCondition)
        End If
        If Not ds Is Nothing Then
            Me.DataGrid1.DataSource = ds.Tables(0)
            Me.DataGrid1.DataKeyField = "DeptItemPKID"
            Me.DataGrid1.DataBind()
            Me.Datagrid2.DataSource = ds.Tables(1)
            Me.Datagrid2.DataKeyField = "DeptItemPKID"
            Me.Datagrid2.DataBind()
            Me.DataGrid3.DataSource = ds.Tables(2)
            Me.DataGrid3.DataKeyField = "DeptItemPKID"
            Me.DataGrid3.DataBind()
        End If
    End Sub
#End Region

#Region "DateGrid Events"

    Private Sub DataGrid1_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs) Handles DataGrid1.ItemDataBound
        If e.Item.ItemType = ListItemType.Item Or e.Item.ItemType = ListItemType.AlternatingItem Then
            e.Item.Attributes.Add("onmouseover", "currentcolor=this.style.backgroundColor;this.style.backgroundColor='#40A0FE',this.style.fontWeight='';")
            e.Item.Attributes.Add("onmouseout", " this.style.backgroundColor=currentcolor,this.style.fontWeight='';")
            Dim mRadioBtnList As RadioButtonList = DirectCast(e.Item.FindControl("RadioBtnList"), RadioButtonList)
            Dim mCtlNGGrid As CTLGEPNGReason = CType(e.Item.FindControl("CTLGEPNGReason1"), CTLGEPNGReason)
            Dim RowNo As Integer = e.Item.ItemIndex + 1
            mRadioBtnList.Attributes.Add("onclick", "return CheckCSISelect(this,'" + mCtlNGGrid.ClientID + "');")
            If mCSIResult.IsSubmited = 2 Then
                Dim mTxtDetailPKID As HtmlInputHidden = DirectCast(e.Item.FindControl("TxtPKID"), HtmlInputHidden)

                Dim dc As DataRowView = DirectCast(e.Item.DataItem, DataRowView)
                mTxtDetailPKID.Value = dc.Item("DetailPKID")
                Dim mItemValue As Integer = dc.Item("ItemValue")
                mRadioBtnList.SelectedIndex = mRadioBtnList.Items.IndexOf(mRadioBtnList.Items.FindByValue(mItemValue))
                If mItemValue = 4 OrElse mItemValue = 5 Then
                    Dim ReturnInfo(1) As String
                    Dim mItemNGReason As String = dc.Item("ItemNGReason")
                    Dim mItemNGText As String = dc.Item("ItemNGText")
                    ReturnInfo(0) = mItemNGReason
                    ReturnInfo(1) = mItemNGText
                    mCtlNGGrid.NGSelectReason = ReturnInfo
                End If
                mCtlNGGrid.DeptPKID = DeptPKID
                mCtlNGGrid.DeptItemPKID = Me.DataGrid1.DataKeys(e.Item.ItemIndex)
            Else
                mCtlNGGrid.DeptPKID = DeptPKID
                mCtlNGGrid.DeptItemPKID = Me.DataGrid1.DataKeys(e.Item.ItemIndex)

            End If
            'mCtlNGGrid.BindControlData()
        End If
    End Sub

    Private Sub Datagrid2_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs) Handles Datagrid2.ItemDataBound
        If e.Item.ItemType = ListItemType.Item Or e.Item.ItemType = ListItemType.AlternatingItem Then
            e.Item.Attributes.Add("onmouseover", " currentcolor=this.style.backgroundColor;this.style.backgroundColor='#40A0FE',this.style.fontWeight='';")
            e.Item.Attributes.Add("onmouseout", " this.style.backgroundColor=currentcolor,this.style.fontWeight='';")
            Dim mAnswerItem As Label = DirectCast(e.Item.FindControl("lblAnswerItem"), Label)
            If mAnswerItem.Text.IndexOf("{0}") <> -1 Then
                mAnswerItem.Text = String.Format(mAnswerItem.Text, Me.txtDeptName.Value)
            End If
            If mCSIResult.IsSubmited = 2 Then
                Dim mTxtDetailPKID As HtmlInputHidden = DirectCast(e.Item.FindControl("txtAnswerPKID"), HtmlInputHidden)
                Dim mtxtAdvice As TextBox = DirectCast(e.Item.FindControl("txtAdvice"), TextBox)
                Dim dc As DataRowView = DirectCast(e.Item.DataItem, DataRowView)
                mtxtAdvice.Text = dc.Item("ItemValue")
                mTxtDetailPKID.Value = dc.Item("DetailPKID")
            End If
        End If
    End Sub
#End Region

#Region "Button Events"
    Private Sub BtnSubmit1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnSubmit1.Click
        If Page.IsValid = False Then
            Exit Sub
        Else
            SaveCSIInfo()
        End If
    End Sub

    Private Sub BtnSubmit2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnSubmit2.Click
        If Page.IsValid = False Then
            Exit Sub
        Else
            SaveCSIInfo()
        End If

    End Sub

    Private Sub SaveCSIInfo()
        If ChenkSelectNgReason() Then

            mCSIResult.DeptPKID = DeptPKID
            If mCSIResult.IsSubmited = 0 Then            '被動調查
                mCSIResult.DeptName = GEPCSI_Dept.GetDeptnameByDeptPKID(DeptPKID)
                mCSIResult.AcceptDept = Me.TxtDept.Text
                mCSIResult.AcceptGroup = Me.TxtGroup.Text
                mCSIResult.AcceptDivision = Me.TxtDept.Text
                mCSIResult.AcceptDept = Me.TxtUnit.Text
                mCSIResult.AcceptMan = Me.TxtVisitor.Text
                mCSIResult.AcceptExt = Me.TxtExt.Text
                mCSIResult.AcceptEmail = Me.TxtEmail.Text
                Dim Last As GEPCSI_Period = GEPCSI_Period.GetLastPeriod
                If Last Is Nothing Then
                    mCSIResult.CSITime = 1
                Else
                    mCSIResult.CSITime = Last.CSITime
                End If
            End If
            mCSIResult.Extend1 = Me.Txtcusphone.Text
            mCSIResult.Extend2 = Me.TxtFax.Text
            mCSIResult.Extend3 = Me.TxtWebSite.Text
            mCSIResult.ResultPKID = ClientPKID
            mCSIResult.SubmitGroup = Me.TxtGroup.Text
            mCSIResult.SubmitDivision = Me.TxtDept.Text
            mCSIResult.SubmitDept = Me.TxtUnit.Text
            mCSIResult.SubmitMan = Me.TxtVisitor.Text
            mCSIResult.SubmitExt = Me.TxtExt.Text
            mCSIResult.SubmitEmail = Me.TxtEmail.Text
            mCSIResult.IsSubmited = 2
            mCSIResult.SubmitTime = DateTime.Now
            ClientPKID = mCSIResult.Save()
            If ClientPKID > 0 Then
                SaveGatdGridInfo()
            End If
            Response.Write("<script > alert('您的反饋已提交，感謝您的意見');window.location.href ='../GMPCSI/SelectDept.aspx' </script>")
            ' Response.Redirect("../Index.aspx")
        End If

    End Sub

    Private Function ChenkSelectNgReason() As Boolean
        Dim i As Integer
        Me.lblSearchResult.Text = String.Empty
        For i = 0 To Me.DataGrid1.Items.Count - 1
            Dim item As DataGridItem = Me.DataGrid1.Items(i)
            Dim ItemValue As String = DirectCast(item.FindControl("RadioBtnList"), RadioButtonList).SelectedValue
            If ItemValue = "4" OrElse ItemValue = "5" Then
                Dim mCtlNGGrid As CTLGEPNGReason = CType(item.FindControl("CTLGEPNGReason1"), CTLGEPNGReason)
                Dim NgReason() As String = mCtlNGGrid.SaveNgReason
                If NgReason Is Nothing Then
                    Me.lblSearchResult.Text = "請選擇不滿意原因"
                End If
            End If
        Next
        If Me.lblSearchResult.Text <> String.Empty Then
            Return False
        Else
            Return True
        End If
    End Function

    Private Sub SaveGatdGridInfo()
        Dim i As Integer
        For i = 0 To Me.DataGrid1.Items.Count - 1
            Dim item As DataGridItem = Me.DataGrid1.Items(i)
            Dim mCSIDetail As GEPCSI_DetailResult = New GEPCSI_DetailResult
            mCSIDetail.ResultPKID = ClientPKID
            mCSIDetail.DetailPKID = Convert.ToInt32(DirectCast(item.FindControl("TxtPKID"), HtmlInputHidden).Value)
            mCSIDetail.ItemCategory = 1
            mCSIDetail.DeptItemPKID = Me.DataGrid1.DataKeys(i)
            mCSIDetail.ItemName = DirectCast(item.FindControl("lblItemName"), Label).Text
            mCSIDetail.ItemValue = DirectCast(item.FindControl("RadioBtnList"), RadioButtonList).SelectedValue
            If mCSIDetail.ItemValue = "4" OrElse mCSIDetail.ItemValue = "5" Then
                Dim mCtlNGGrid As CTLGEPNGReason = CType(item.FindControl("CTLGEPNGReason1"), CTLGEPNGReason)
                Dim NgReason() As String = mCtlNGGrid.SaveNgReason
                If Not NgReason Is Nothing AndAlso NgReason.Length = 2 Then
                    mCSIDetail.ItemNGReason = NgReason(0)
                    mCSIDetail.ItemNGText = NgReason(1)
                End If
            Else
                mCSIDetail.ItemNGReason = 0
                mCSIDetail.ItemNGText = String.Empty
            End If
            mCSIDetail.Save()
        Next
        Dim j As Integer
        For j = 0 To Me.Datagrid2.Items.Count - 1
            Dim item As DataGridItem = Me.Datagrid2.Items(j)
            Dim mCSIDetail As GEPCSI_DetailResult = New GEPCSI_DetailResult
            mCSIDetail.DetailPKID = Convert.ToInt32(DirectCast(item.FindControl("txtAnswerPKID"), HtmlInputHidden).Value)
            mCSIDetail.ResultPKID = ClientPKID
            mCSIDetail.DeptItemPKID = Me.Datagrid2.DataKeys(j)
            mCSIDetail.ItemCategory = 2
            mCSIDetail.ItemName = DirectCast(item.FindControl("lblAnswerItem"), Label).Text
            mCSIDetail.ItemValue = DirectCast(item.FindControl("txtAdvice"), TextBox).Text
            mCSIDetail.ItemNGReason = 0
            mCSIDetail.ItemNGText = String.Empty
            mCSIDetail.Save()
        Next
        Dim k As Integer
        For k = 0 To Me.DataGrid3.Items.Count - 1
            Dim item As DataGridItem = Me.DataGrid3.Items(k)
            Dim mCSIDetail As GEPCSI_DetailResult = New GEPCSI_DetailResult
            mCSIDetail.ResultPKID = ClientPKID
            mCSIDetail.DetailPKID = Convert.ToInt32(DirectCast(item.FindControl("TxtPKID"), HtmlInputHidden).Value)
            mCSIDetail.ItemCategory = 3
            mCSIDetail.DeptItemPKID = Me.DataGrid3.DataKeys(k)
            mCSIDetail.ItemName = DirectCast(item.FindControl("lblItemName"), Label).Text
            mCSIDetail.ItemValue = ""

            Dim mulchoiceitem1 As mulchoiceitem = CType(item.FindControl("mulchoiceitem1"), mulchoiceitem)
            Dim NgReason() As String = mulchoiceitem1.SaveNgReason
            If Not NgReason Is Nothing AndAlso NgReason.Length = 2 Then
                mCSIDetail.ItemNGReason = NgReason(0)
                mCSIDetail.ItemNGText = NgReason(1)
            End If

            mCSIDetail.Save()
        Next

    End Sub

#End Region

    
    Protected Sub DataGrid3_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs) Handles DataGrid3.ItemDataBound
        If e.Item.ItemType = ListItemType.Item Or e.Item.ItemType = ListItemType.AlternatingItem Then
            e.Item.Attributes.Add("onmouseover", " currentcolor=this.style.backgroundColor;this.style.backgroundColor='#40A0FE',this.style.fontWeight='';")
            e.Item.Attributes.Add("onmouseout", " this.style.backgroundColor=currentcolor,this.style.fontWeight='';")

            Dim mulchoiceitem1 As mulchoiceitem = CType(e.Item.FindControl("mulchoiceitem1"), mulchoiceitem)
            If mCSIResult.IsSubmited = 2 Then
                Dim mTxtDetailPKID As HtmlInputHidden = DirectCast(e.Item.FindControl("TxtPKID"), HtmlInputHidden)
                Dim dc As DataRowView = DirectCast(e.Item.DataItem, DataRowView)
                mTxtDetailPKID.Value = dc.Item("DetailPKID")

                Dim ReturnInfo(1) As String
                Dim mItemNGReason As String = dc.Item("ItemNGReason")
                Dim mItemNGText As String = dc.Item("ItemNGText")
                ReturnInfo(0) = mItemNGReason
                ReturnInfo(1) = mItemNGText
                mulchoiceitem1.NGSelectReason = ReturnInfo

                mulchoiceitem1.DeptPKID = DeptPKID
                mulchoiceitem1.DeptItemPKID = Me.DataGrid3.DataKeys(e.Item.ItemIndex)
            Else
                mulchoiceitem1.DeptPKID = DeptPKID
                mulchoiceitem1.DeptItemPKID = Me.DataGrid3.DataKeys(e.Item.ItemIndex)
            End If
            
        End If
    End Sub
End Class
