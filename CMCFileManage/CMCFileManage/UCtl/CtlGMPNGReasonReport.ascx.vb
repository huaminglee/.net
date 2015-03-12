Imports System.Math
Imports CommonData.BusinessLayer
Public Class CtlGMPNGReasonReport
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
    Private _SearchCondition As String
    Private _DeptItemPKID As String
#End Region

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
    Public Property SearchCondition() As String
        Get
            Return _SearchCondition
        End Get
        Set(ByVal Value As String)
            _SearchCondition = Value
        End Set
    End Property
    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        '�b�o�̩�m�ϥΪ̵{���X�H��l�ƺ���
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
