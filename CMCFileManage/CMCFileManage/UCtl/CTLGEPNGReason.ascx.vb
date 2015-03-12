Imports System.Math
Imports CommonData.BusinessLayer
Public Class CTLGEPNGReason
    Inherits System.Web.UI.UserControl

#Region " Web Form �]�p�u�㲣�ͪ��{���X "

    '���� Web Form �]�p�u��һݪ��I�s�C
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents Datagrid1 As System.Web.UI.WebControls.DataGrid

    '�`�N: �U�C�w�d��m�ŧi�O Web Form �]�p�u��ݭn�����ءC
    '�ФŧR���β��ʥ��C
    Private designerPlaceholderDeclaration As System.Object

    Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
        'CODEGEN: ���� Web Form �]�p�u��һݪ���k�I�s
        '�ФŨϥε{���X�s�边�i��ק�C
        InitializeComponent()
    End Sub

#End Region

#Region "Private Define"
    Private _DeptPKID As Integer
    Private _DeptItemPKID As String
    Private _NGSelectReason As String() = Nothing
    Private Hide_CheckCount As String = "ViewState:CheckCount"
#End Region

#Region "Property"
    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' �լd����PKID
    ''' </summary>
    ''' <value></value>
    ''' <remarks>
    ''' </remarks>
    ''' -----------------------------------------------------------------------------
    Public Property DeptPKID() As Integer
        Get
            Return _DeptPKID
        End Get
        Set(ByVal Value As Integer)
            _DeptPKID = Value
        End Set
    End Property

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' �լd����PKID
    ''' </summary>
    ''' <value></value>
    ''' <remarks>
    ''' </remarks>
    ''' -----------------------------------------------------------------------------
    Public Property DeptItemPKID() As Integer
        Get
            Return _DeptItemPKID
        End Get
        Set(ByVal Value As Integer)
            _DeptItemPKID = Value
        End Set
    End Property

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' �լd����NG��]
    ''' </summary>
    ''' <value></value>
    ''' <remarks>
    ''' </remarks>
    ''' -----------------------------------------------------------------------------
    Public Property NGSelectReason() As String()
        Get
            Return _NGSelectReason
        End Get
        Set(ByVal Value As String())
            _NGSelectReason = Value
        End Set
    End Property

    Private Property CheckCount() As Integer
        Get
            If ViewState(Hide_CheckCount) Is Nothing Then
                Return 0
            End If
            Return Convert.ToInt32(ViewState(Hide_CheckCount))
        End Get
        Set(ByVal Value As Integer)
            ViewState(Hide_CheckCount) = Value
        End Set
    End Property
#End Region

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        '�b�o�̩�m�ϥΪ̵{���X�H��l�ƺ���       
        If Not Page.IsPostBack Then
            BindControlData()
        End If
    End Sub


    Public Sub BindControlData()
        If (DeptPKID > 0 AndAlso DeptItemPKID > 0) Then
            Dim mNGReason As DataSet
            Dim SearchCondition As String = " DeptPKID=" + DeptPKID.ToString + " AND a.DeptItemPKID =" + DeptItemPKID.ToString
            mNGReason = GEPCSI_NGItemReasonDAL.GetInfoBySearchCondtion(SearchCondition)
            If Not mNGReason Is Nothing Then
                Me.Datagrid1.DataSource = mNGReason
                Me.Datagrid1.DataBind()
            End If
            If Not NGSelectReason Is Nothing Then
                Me.Datagrid1.Style.Item("DISPLAY") = "block"
                Me.Datagrid1.Style.Item("VISIBILITY") = "visible"

            End If
        End If
    End Sub

    Private Sub Datagrid1_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs) Handles Datagrid1.ItemDataBound
        If e.Item.ItemType = ListItemType.Item Or e.Item.ItemType = ListItemType.AlternatingItem Then
            Dim ChklistNgReason As CheckBox = DirectCast(e.Item.FindControl("chkNgReason"), CheckBox)
            Dim mIsWithTextBox As String = DirectCast(e.Item.FindControl("lblIsWithTextBox"), Label).Text
            Dim mReasonInput As TextBox = DirectCast(e.Item.FindControl("txtNgReasonInput"), TextBox)
            If mIsWithTextBox = "1" Then
                mReasonInput.Visible = True
                ' ChklistNgReason.Attributes.Add("onclick", "return CheckInput(this,'" + mReasonInput.ClientID + "')")
            Else
            End If
            If Not NGSelectReason Is Nothing AndAlso NGSelectReason.Length = 2 Then
                Dim i As Integer = e.Item.ItemIndex
                If (NGSelectReason(0) And Pow(2, i)) = Pow(2, i) Then
                    ChklistNgReason.Checked = True
                    CheckCount = CheckCount + 1
                    If mIsWithTextBox = "1" Then
                        mReasonInput.Text = NGSelectReason(1).Split("^")(CheckCount - 1).Split(":")(1)
                    End If
                End If
            End If
        End If
    End Sub

    Private Sub Datagrid1_ItemCreated(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs) Handles Datagrid1.ItemCreated
        If e.Item.ItemType = ListItemType.Header Then
            e.Item.Cells(0).ColumnSpan = 2
            e.Item.Cells(1).Visible = False
        End If
    End Sub

    Public Function SaveNgReason() As String()
        Dim count As Integer = 0
        Dim i As Integer
        Me.Datagrid1.Style.Item("DISPLAY") = "block"
        Me.Datagrid1.Style.Item("VISIBILITY") = "visible"
        Dim ReturnInfo(1) As String
        For i = 0 To Me.Datagrid1.Items.Count - 1
            Dim item As DataGridItem = Me.Datagrid1.Items(i)
            Dim mCheck As CheckBox = DirectCast(item.FindControl("chkNgReason"), CheckBox)
            Dim mIsWithTextBox As String = DirectCast(item.FindControl("lblIsWithTextBox"), Label).Text
            If mCheck.Checked AndAlso mIsWithTextBox = "0" Then
                ReturnInfo(0) += Pow(2, i)
                ReturnInfo(1) += (i + 1).ToString + ": " + "" + "^"
                count = count + 1
            ElseIf mCheck.Checked AndAlso mIsWithTextBox = "1" Then
                Dim mReasonInput As String = DirectCast(item.FindControl("txtNgReasonInput"), TextBox).Text
                ReturnInfo(0) += Pow(2, i)
                ReturnInfo(1) += (i + 1).ToString + ":" + mReasonInput + "^"
                count = count + 1
            End If
        Next
        If count = 0 Then
            Return Nothing
        Else
            ReturnInfo(1) = ReturnInfo(1).Remove(ReturnInfo(1).LastIndexOf("^"), 1)
        End If
        Return ReturnInfo
    End Function
  
End Class
