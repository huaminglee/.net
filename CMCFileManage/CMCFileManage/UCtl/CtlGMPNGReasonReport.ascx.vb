Imports System.Math
Imports CommonData.BusinessLayer
Public Class CtlGMPNGReasonReport
    Inherits System.Web.UI.UserControl

#Region " Web Form 設計工具產生的程式碼 "

    '此為 Web Form 設計工具所需的呼叫。
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents Datagrid1 As System.Web.UI.WebControls.DataGrid

    '注意: 下列預留位置宣告是 Web Form 設計工具需要的項目。
    '請勿刪除或移動它。
    Private designerPlaceholderDeclaration As System.Object

    Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
        'CODEGEN: 此為 Web Form 設計工具所需的方法呼叫
        '請勿使用程式碼編輯器進行修改。
        InitializeComponent()
    End Sub

#End Region

#Region "Private Define"
    Private _SearchCondition As String
    Private _DeptItemPKID As String
#End Region

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' 調查項目PKID
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
    ''' 調查項目NG原因
    ''' </summary>
    ''' <value></value>
    ''' <remarks>
    ''' </remarks>
    ''' -----------------------------------------------------------------------------
    Public Property SearchCondition() As String
        Get
            Return _SearchCondition
        End Get
        Set(ByVal Value As String)
            _SearchCondition = Value
        End Set
    End Property
    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        '在這裡放置使用者程式碼以初始化網頁
        If Not Page.IsPostBack Then
            BindControlData()
        End If
    End Sub


    Public Sub BindControlData()
        If (SearchCondition <> String.Empty AndAlso DeptItemPKID > 0) Then
            Dim ds As DataSet
            ds = GEPCSI_NGItemReasonDAL.GetReportInfoBySearchCondtion(SearchCondition, DeptItemPKID)
            Dim lblNGReason1 As String = String.Empty
            If Not ds Is Nothing Then
                Dim dt1 As DataTable = ds.Tables(0)
                Dim dt2 As DataTable = ds.Tables(1)
                Dim CheckCount As Integer = 0
                If Not dt1 Is Nothing AndAlso dt1.Rows.Count > 0 Then

                    Dim i As Integer
                    For i = 0 To dt1.Rows.Count - 1
                        Dim dr As DataRow = dt1.Rows(i)
                        Dim j As Integer
                        For j = 0 To dt2.Rows.Count - 1
                            Dim dr1 As DataRow = dt2.Rows(j)

                            If (dr1.Item("ItemNGReason") And Pow(2, i)) = Pow(2, i) Then
                                CheckCount = CheckCount + 1
                                If dr.Item("IsWithTextBox") = "0" Then
                                    lblNGReason1 += dr.Item("NGItemName") + ";"
                                Else
                                    lblNGReason1 += dr1.Item("ItemNGText").Split("^")(CheckCount - 1).Split(":")(1)
                                End If
                            End If
                        Next
                    Next
                End If
            End If
            If Not lblNGReason1 Is Nothing Then
                Me.Datagrid1.DataSource = lblNGReason1
                Me.Datagrid1.DataBind()
            End If
        End If
    End Sub

End Class
