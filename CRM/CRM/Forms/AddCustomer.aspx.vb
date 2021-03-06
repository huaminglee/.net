﻿Imports Platform.eAuthorize

Partial Public Class AddCustomer
    Inherits System.Web.UI.Page
    Private Property MarkPlanPKID() As Integer
        Get
            If ViewState("MarkPlanPKID") Is Nothing Then
                Return 0
            End If
            Return CInt(ViewState("MarkPlanPKID"))
        End Get
        Set(ByVal value As Integer)
            ViewState("MarkPlanPKID") = value
        End Set
    End Property
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            If Not Request.QueryString("Markplanpkid") Is Nothing Then
                MarkPlanPKID = CInt(Request.QueryString("Markplanpkid"))
                BindGrid()
            End If
        End If
    End Sub
    Protected Sub BindGrid()
        Dim ds As DataSet = CustomersDAL.GetAllCanAddCustomers(MarkPlanPKID, StrConv(UserInfo.CurrentUserCHName, VbStrConv.SimplifiedChinese, 2052))
        If Not ds Is Nothing Then
            Me.GridView1.DataSource = ds
            Me.GridView1.DataKeyNames = New String() {"pkid"}
            Me.GridView1.DataBind()
        Else
            Me.GridView1.DataSource = Nothing
            Me.GridView1.DataBind()
        End If
    End Sub
    Protected Sub BtnSave_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BtnSave.Click
        Dim checkcusPKID As String = String.Empty
        Dim checkcusnames As String = String.Empty
        For i As Integer = 0 To Me.GridView1.Rows.Count - 1
            Dim CheckBox1 As CheckBox = CType(GridView1.Rows(i).FindControl("CheckBox1"), CheckBox)
            If CheckBox1.Checked Then
                checkcusPKID += Me.GridView1.DataKeys(Me.GridView1.Rows(i).RowIndex).Value.ToString + ";"
                checkcusnames += Me.GridView1.Rows(i).Cells(1).Text + ";"
            End If
        Next
        If checkcusPKID <> String.Empty Then
            MarketMemberDAL.AddMemberForCustomer(MarkPlanPKID, checkcusPKID, checkcusnames)
        End If
        Response.Write("<script>window.opener.upgridmember();window.close(); </script>")
    End Sub

    Protected Sub BtnCancel_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BtnCancel.Click
        Response.Write("<script>window.opener=null;window.close(); </script>")
    End Sub
End Class