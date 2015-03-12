﻿Imports System.Math
Partial Public Class mulchoiceitem
    Inherits System.Web.UI.UserControl
#Region "Private Define"
    Private _DeptPKID As Integer
    Private _DeptItemPKID As String
    Private _NGSelectReason As String() = Nothing
    Private Hide_CheckCount As String = "ViewState:CheckCount"
#End Region

#Region "Property"
    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' 調查項目PKID
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
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            Binddatalist()
        End If
    End Sub
    Public Sub Binddatalist()
        Dim mNGReason As DataSet
        Dim SearchCondition As String = " DeptPKID=" + DeptPKID.ToString + " AND a.DeptItemPKID =" + DeptItemPKID.ToString
        mNGReason = GEPCSI_NGItemReasonDAL.GetInfoBySearchCondtion(SearchCondition)
        If Not mNGReason Is Nothing Then
            Me.DataList1.DataSource = mNGReason
            Me.DataList1.DataBind()
        End If
        If Not NGSelectReason Is Nothing Then
            Me.DataList1.Style.Item("DISPLAY") = "block"
            Me.DataList1.Style.Item("VISIBILITY") = "visible"

        End If
    End Sub

    Protected Sub DataList1_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataListItemEventArgs) Handles DataList1.ItemDataBound
        Dim ChklistNgReason As CheckBox = DirectCast(e.Item.FindControl("chkNgReason"), CheckBox)
        Dim mIsWithTextBox As String = DirectCast(e.Item.FindControl("lblIsWithTextBox"), Label).Text
        Dim TxtRemark As TextBox = DirectCast(e.Item.FindControl("TxtRemark"), TextBox)
        If mIsWithTextBox = "1" Then
            TxtRemark.Visible = True
        End If
        If Not NGSelectReason Is Nothing AndAlso NGSelectReason.Length = 2 Then
            Dim i As Integer = e.Item.ItemIndex
            If (NGSelectReason(0) And Pow(2, i)) = Pow(2, i) Then
                ChklistNgReason.Checked = True
                CheckCount = CheckCount + 1
                If mIsWithTextBox = "1" Then
                    TxtRemark.Text = NGSelectReason(1).Split("^")(CheckCount - 1).Split(":")(1)
                End If
            End If
        End If

    End Sub
    Public Function SaveNgReason() As String()
        Dim count As Integer = 0
        Dim i As Integer
        Me.DataList1.Style.Item("DISPLAY") = "block"
        Me.DataList1.Style.Item("VISIBILITY") = "visible"
        Dim ReturnInfo(1) As String
        For i = 0 To Me.DataList1.Items.Count - 1
            Dim item As DataListItem = Me.DataList1.Items(i)
            Dim mCheck As CheckBox = DirectCast(item.FindControl("chkNgReason"), CheckBox)
            Dim mIsWithTextBox As String = DirectCast(item.FindControl("lblIsWithTextBox"), Label).Text
            If mCheck.Checked AndAlso mIsWithTextBox = "0" Then
                ReturnInfo(0) += Pow(2, i)
                ReturnInfo(1) += (i + 1).ToString + ": " + "" + "^"
                count = count + 1
            ElseIf mCheck.Checked AndAlso mIsWithTextBox = "1" Then
                Dim mReasonInput As String = DirectCast(item.FindControl("TxtRemark"), TextBox).Text
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