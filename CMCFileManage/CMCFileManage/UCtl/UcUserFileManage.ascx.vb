Imports FileManager
Imports System.IO
Imports System.Web.UI

Partial Public Class UcUserFileManage
    Inherits System.Web.UI.UserControl
    Protected currPath As String = ""
    Protected fileNum As Integer = 0
    Protected folderNum As Integer = 0
    Protected folderPath As String = HttpContext.Current.Request.QueryString("path")
    Private spa() As String = New String() {""}


    Private Sub BindGrid()
        Dim list As List(Of FileSystemItem) = FileSystemManager.GetItems()
        Me.GridView1.DataSource = List
        Me.GridView1.DataBind()
        Me.showUserCurrPath(FileSystemManager.GetRootPath())
    End Sub


    Private Sub BindGrid(ByVal path As String)
        Dim list As List(Of FileSystemItem) = FileSystemManager.GetItems(path)
        Me.GridView1.DataSource = List
        Me.GridView1.DataBind()
        Me.showUserCurrPath(path)
    End Sub


    Protected Sub btnCopy_Click(ByVal sender As Object, ByVal e As EventArgs)

        Dim items As List(Of String) = New List(Of String)()
        Dim row As GridViewRow
        For Each row In Me.GridView1.Rows
            If row.RowType = DataControlRowType.DataRow Then
                Dim cb As CheckBox = CType(row.Cells(0).FindControl("ChkSelect"), CheckBox)
                If cb.Checked Then
                    Dim lb As LinkButton = CType(row.Cells(1).FindControl("LinkButton1"), LinkButton)
                    items.Add(lb.CommandArgument)
                End If
            End If
        Next
        Me.ViewState("clipboard") = items
        Me.ViewState("action") = "copy"
    End Sub



    Protected Sub btnCreateFile_Click(ByVal sender As Object, ByVal e As EventArgs)
        If (FileSystemManager.IsSafeName(Me.TextBox4.Text.ToString())) Then

            FileSystemManager.CreateFile(Me.TextBox4.Text, Me.Session("currentPath").ToString())

        Else

            Me.ShowErr("檔案名稱違法！不允許添加本格式檔！") '5#1#a#s#p#x
        End If
        Me.BindGrid(Me.Session("currentPath").ToString())
    End Sub



    Protected Sub btnCreateFolder_Click(ByVal sender As Object, ByVal e As EventArgs)
        If (FileSystemManager.IsUnsafeName(Me.TextBox2.Text.ToString())) Then

            Me.ShowErr("檔夾名稱違法！不允許添加本名稱檔夾！")

        Else

            FileSystemManager.CreateFolder(Me.TextBox2.Text, Me.Session("currentPath").ToString())
        End If
        Me.BindGrid(Me.Session("currentPath").ToString())
    End Sub


    Protected Sub btnCut_Click(ByVal sender As Object, ByVal e As EventArgs)

        Dim items As List(Of String) = New List(Of String)()
        Dim row As GridViewRow
        For Each row In Me.GridView1.Rows
            If (row.RowType = DataControlRowType.DataRow) Then
                Dim cb As CheckBox = CType(row.Cells(0).FindControl("ChkSelect"), CheckBox)
                If cb.Checked Then
                    Dim lb As LinkButton = CType(row.Cells(1).FindControl("LinkButton1"), LinkButton)
                    items.Add(lb.CommandArgument)
                End If
            End If
        Next
        Me.ViewState("clipboard") = items
        Me.ViewState("action") = "cut"
    End Sub

    Protected Sub btnDelete_Click(ByVal sender As Object, ByVal e As EventArgs)
        Dim row As GridViewRow
        For Each row In Me.GridView1.Rows
            If (row.RowType = DataControlRowType.DataRow) Then
                Dim cb As CheckBox = CType(row.Cells(0).FindControl("ChkSelect"), CheckBox)
                If cb.Checked Then
                    Dim lb As LinkButton = CType(row.Cells(1).FindControl("LinkButton1"), LinkButton)
                    If (Directory.Exists(lb.CommandArgument)) Then
                        If (Not FileSystemManager.DeleteFolder(lb.CommandArgument)) Then
                            Me.ShowErr("目錄裏面有檔！")
                        End If
                    Else
                        FileSystemManager.DeleteFile(lb.CommandArgument)
                    End If
                End If
            End If
        Next
        Me.BindGrid(Me.Session("currentPath").ToString())
    End Sub

    Protected Sub btnEdit_Click(ByVal sender As Object, ByVal e As EventArgs)
        Dim row As GridViewRow
        For Each row In Me.GridView1.Rows

            If (row.RowType = DataControlRowType.DataRow) Then

                Dim cb As CheckBox = CType(row.Cells(0).FindControl("ChkSelect"), CheckBox)
                If (cb.Checked) Then

                    Dim lb As LinkButton = CType(row.Cells(1).FindControl("LinkButton1"), LinkButton)
                    If (Directory.Exists(lb.CommandArgument)) Then
                        Me.ShowErr("不能編輯檔夾！")
                    ElseIf (FileSystemManager.IsCanEdit(lb.CommandArgument)) Then
                        Me.FilePath.Text = lb.CommandArgument
                        Me.TextBox5.Text = FileSystemManager.OpenText(lb.CommandArgument)
                        Dim cstype As Type = MyBase.GetType()
                        Dim csname2 As String = "ButtonClickScript"
                        '  MyBase.ClientScript.RegisterClientScriptBlock(cstype, csname2, "<script> $().ready(function() {$('#divEditFile').jqmShow();});</script>")
                    Else
                        Me.ShowErr("不能編輯本格式檔！")
                    End If
                End If
            End If
        Next
        Me.BindGrid(Me.Session("currentPath").ToString())
    End Sub


    Protected Sub btnEditFile(ByVal sender As Object, ByVal e As EventArgs)
        FileSystemManager.WriteAllText(Me.FilePath.Text, Me.TextBox5.Text)
        Me.BindGrid(Me.Session("currentPath").ToString())
    End Sub


    Protected Sub btnPaste_Click(ByVal sender As Object, ByVal e As EventArgs)

        If Not Me.ViewState("clipboard") Is Nothing Then
            Dim items As List(Of String)
            If (Me.ViewState("action").ToString() = "cut") Then

                items = CType(Me.ViewState("clipboard"), List(Of String))
                Dim s As String
                For Each s In items
                    If (Directory.Exists(s)) Then
                        If (Not Directory.Exists(Me.Session("currentPath").ToString() + s.Substring(s.LastIndexOf("\")))) Then
                            Directory.Move(s, Me.Session("currentPath").ToString() + s.Substring(s.LastIndexOf("\")))
                        Else
                            Me.ShowErr("當文件夾已存在時，無法創建該文件夾。")
                        End If
                    ElseIf (Not File.Exists(Me.Session("currentPath").ToString() + "\" + Path.GetFileName(s))) Then
                        File.Move(s, Me.Session("currentPath").ToString() + "\" + Path.GetFileName(s))
                    Else
                        Me.ShowErr("當文件已存在時，無法創建該文件。")
                    End If
                Next
            Else
                items = CType(Me.ViewState("clipboard"), List(Of String))
                Dim s As String
                For Each s In items
                    If (Directory.Exists(s)) Then
                        Dim di As DirectoryInfo = New DirectoryInfo(s)
                        FileSystemManager.CopyFolder(s, Me.Session("currentPath").ToString() + "\" + di.Name)
                    Else
                        File.Copy(s, Me.Session("currentPath").ToString() + "\複件 " + Path.GetFileName(s), True)
                    End If
                Next
            End If
        End If
        Me.ViewState("clipboard") = Nothing
        Me.ViewState("action") = Nothing
        Me.BindGrid(Me.Session("currentPath").ToString())
    End Sub

    Protected Sub btnRename_Click(ByVal sender As Object, ByVal e As EventArgs)

        Dim src As String = ""
        Dim dest As String = ""
        Dim row As GridViewRow
        For Each row In Me.GridView1.Rows

            If row.RowType = DataControlRowType.DataRow Then
                Dim cb As CheckBox = CType(row.Cells(0).FindControl("ChkSelect"), CheckBox)
                If cb.Checked Then
                    Dim lb As LinkButton = CType(row.Cells(1).FindControl("LinkButton1"), LinkButton)
                    src = lb.CommandArgument
                End If
            End If
        Next
        If src.Length > 0 Then
            dest = src.Substring(0, src.LastIndexOf("\")) + "\" + Me.TextBox3.Text
            If Directory.Exists(src) Then
                FileSystemManager.MoveFolder(src, dest)
            Else
                FileSystemManager.MoveFile(src, dest)
            End If
            Me.BindGrid(Me.Session("currentPath").ToString())
        End If
    End Sub



    Protected Sub GridView1_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GridView1.RowCommand
        If (Directory.Exists(e.CommandArgument.ToString())) Then
            Me.BindGrid(e.CommandArgument.ToString())
            Me.showCurrINI(e.CommandArgument.ToString())
        Else
            '  MyBase.ClientScript.RegisterClientScriptBlock(Me, Me.GetType(), DateTime.Now.ToString(), "<script language=javascript>window.open('" + e.CommandArgument.ToString().Replace(FileSystemManager.GetRootPath(), "UserFile\" + Me.Session("userID").ToString()).Replace("\", "/") + "')</script>", True)

        End If
    End Sub

    Protected Sub GridView1_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GridView1.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            Dim lb As LinkButton = CType(e.Row.Cells(1).FindControl("LinkButton1"), LinkButton)
            Dim lbtext As String = lb.Text + "  "
            If lbtext.Substring(0, 2) <> " <" Then
                If Directory.Exists(lb.CommandArgument.ToString()) Then
                    lb.Text = String.Format("<img src='images/file/folder.gif' style='border:none ;vertical-align:middle' /> {0}", lb.Text)

                Else
                    Dim ext As String = lb.CommandArgument.ToString().Substring(lb.CommandArgument.LastIndexOf(".") + 1)
                    If File.Exists(MyBase.Server.MapPath(String.Format("images/file/{0}.gif", ext))) Then
                        lb.Text = String.Format("<a href='" + lb.CommandArgument.ToString() + "'><img src='images/file/{0}.gif' style='border:none; vertical-align:middle;' /> {1}</a>", ext, lb.Text)
                    Else
                        lb.Text = String.Format("<a href='" + lb.CommandArgument.ToString() + "'><img src='images/file/other.gif' style='border:none; vertical-align:middle' /> {0}</a>", lb.Text)

                    End If
                End If
            Else
                e.Row.Cells(0).Controls.Clear()
            End If
        End If

    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Me.Session("userID") Is Nothing Then
            ' Throw New Exception("可能因電腦閒置時間過長，導致系統找不到您的登錄資訊。請重新登錄！")
            Response.Redirect("Login.aspx")
        End If
        If Page.IsPostBack Then
            If Not Me.Session("PathHref") Is Nothing Then
                Me.currPath = Me.Session("PathHref").ToString()
            End If
            If Not Me.Session("PathText") Is Nothing Then
                Me.showCurrINI(FileSystemManager.GetRootPath() + Me.Session("PathText").ToString())
            End If
        ElseIf Not Me.folderPath Is Nothing Then
            Me.folderPath = Me.folderPath.Replace("我的硬碟:", "")
            Dim thePath As String = FileSystemManager.GetRootPath() + Me.folderPath
            If Directory.Exists(thePath) Then
                Me.BindGrid(thePath)
            End If
            Me.showCurrINI(thePath)
        ElseIf Not Page.IsPostBack Then
            Me.BindGrid()
            Me.showCurrINI(FileSystemManager.GetRootPath())
        End If
    End Sub

    Private Sub showCurrINI(ByVal currPath As String)
        Dim di As DirectoryInfo = New DirectoryInfo(currPath)
        Me.folderNum = di.GetDirectories().Length
        Me.fileNum = di.GetFiles().Length
    End Sub


    Protected Sub ShowErr(ByVal Err As String)

        Me.ErrText.Text = Err
        Dim cstype As Type = MyBase.GetType()
        Dim csname2 As String = "ButtonClickScript"
        Response.Write("<script language=javascript>alert('" + Err + "');</script>")

    End Sub

    Private Sub showUserCurrPath(ByVal LondPath As String)

        Me.Session("currentPath") = LondPath
        Me.spa(0) = FileSystemManager.GetRootPath()
        Dim getArr() As String = LondPath.Split(Me.spa, StringSplitOptions.None)
        Dim comePath As String = ""
        Me.currPath = ""
        Dim q As String
        For Each q In ("我的硬碟:" + getArr(1)).Split(New Char())

            comePath = comePath + q
            Me.currPath = Me.currPath + String.Format("<a id='Curpath' href='Webform2.aspx?path={1}'>{0}</a>", q + "\", MyBase.Server.UrlEncode(comePath))
            comePath = comePath + "\"
        Next

        Me.Session("PathHref") = Me.currPath
        Me.Session("PathText") = getArr(1)
    End Sub




    Protected Sub ImageTestDown_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImageTestDown.Click
        Dim uploadPath As String = Session("currentPath") + "\"
        Dim mFileClientName As String = String.Empty
        Dim ZipName As String = "MyFile"
        Dim row As GridViewRow
        Dim mFileSize As String = "1"
        For Each row In GridView1.Rows
            Dim checkb As CheckBox = CType(row.Cells(0).FindControl("ChkSelect"), CheckBox)
            Dim txtName As LinkButton = CType(row.Cells(1).FindControl("LinkButton1"), LinkButton)
            mFileSize = row.Cells(3).Text
            If checkb.Checked AndAlso Not Directory.Exists(txtName.CommandArgument.ToString()) Then

                Dim lblenth As Integer = txtName.CommandArgument.Length
                Dim fiindex As Integer = txtName.CommandArgument.LastIndexOf("\") + 1
                mFileClientName += txtName.CommandArgument.Substring(fiindex) + ","
            End If
        Next
        If mFileClientName <> String.Empty AndAlso mFileClientName <> "" Then
            mFileClientName = mFileClientName.Substring(0, mFileClientName.Length - 1)
            Dim array_FileName As String() = mFileClientName.Split(",")
            If array_FileName.Length > 1 Then
                Dim LoadEndentity As New DownLoadZip
                LoadEndentity.FileNames = array_FileName
                LoadEndentity.RealFilename = mFileClientName.Split(",")
                LoadEndentity.ZipName = ZipName
                LoadEndentity.FilePath = uploadPath
                If (LoadEndentity.CreatStream()) Then
                    DownLoad(LoadEndentity.ZipName, LoadEndentity.Memory)
                End If
            Else
                If mFileClientName <> String.Empty Then
                    Dim FileDownLoadPath As String = uploadPath + "\" + mFileClientName

                    Dim iStream As System.IO.Stream
                    iStream = New System.IO.FileStream(FileDownLoadPath, System.IO.FileMode.Open, _
                                                        IO.FileAccess.Read, IO.FileShare.Read)

                    FileDownload(mFileClientName, mFileSize, iStream)
                End If
            End If
        End If
    End Sub
    Public Sub DownLoad(ByVal ZipName As String, ByVal _Memory As MemoryStream)
        Dim NewFileName = String.Format("{0}.zip", ZipName)
        Try
            Page.Response.ContentType = "application/zip"
            Page.Response.AppendHeader("Content-Disposition", "attachment;   filename=" + Page.Server.UrlPathEncode(NewFileName))
            _Memory.WriteTo(Response.OutputStream)
            _Memory.Close()
        Catch ex As Exception
            Response.Write(ex.Message)
        End Try
    End Sub
    Private Sub FileDownload(ByVal strFileName As String, ByVal FileSize As String, ByVal iStream As Stream)
        If strFileName <> "" Then
            With Page.Response
                .Clear()
                .ClearHeaders()
                .Buffer = False
                .ContentType = "application/octet-stream"""
                .ContentEncoding = System.Text.Encoding.GetEncoding("UTF-8")

                Page.Response.AddHeader("content-disposition", "attachment;filename=" & HttpUtility.UrlEncode(strFileName, System.Text.Encoding.UTF8))
                Response.AppendHeader("Content-Length", FileSize.ToString())
                Dim buffer(10000) As Byte

                Dim length As Integer

                Dim dataToRead As Long

                Try
                    dataToRead = iStream.Length

                    While dataToRead > 0
                        If Response.IsClientConnected Then
                            length = iStream.Read(buffer, 0, 10000)

                            Response.OutputStream.Write(buffer, 0, length)

                            Response.Flush() ' Clear the buffer

                            ReDim buffer(10000)
                            dataToRead = dataToRead - length
                        Else
                            dataToRead = -1
                        End If
                    End While

                Catch ex As Exception
                    ' Response.Write("Error : " & ex.Message)
                Finally
                    If IsNothing(iStream) = False Then
                        iStream.Close()
                    End If
                End Try

                ' .Flush()
                .End()

            End With
        End If
    End Sub
    '將下載控制項註冊為回發的觸發器，才可以下載
    Protected Sub BtnDownLoadInit(ByVal sender As Object, ByVal e As EventArgs)
        Dim ScriptManager1 As ScriptManager
        If Me.Page.Master Is Nothing Then
            ScriptManager1 = DirectCast(MyBase.Page.FindControl("ScriptManager1"), ScriptManager)
        Else
            ScriptManager1 = DirectCast(Me.Page.Master.FindControl("ScriptManager1"), ScriptManager)
        End If
        ScriptManager1.RegisterPostBackControl(CType(sender, Control))

    End Sub

    Protected Sub LinkButton2_Click(ByVal sender As Object, ByVal e As EventArgs) Handles LinkButton2.Click
        Dim uploadPath As String = Session("currentPath") + "\"
        Dim mFileClientName As String = String.Empty
        Dim ZipName As String = "MyFile"
        Dim row As GridViewRow
        Dim mFileSize As String = "1"
        For Each row In GridView1.Rows
            Dim checkb As CheckBox = CType(row.Cells(0).FindControl("ChkSelect"), CheckBox)
            Dim txtName As LinkButton = CType(row.Cells(1).FindControl("LinkButton1"), LinkButton)
            mFileSize = row.Cells(3).Text
            If checkb.Checked AndAlso Not Directory.Exists(txtName.CommandArgument.ToString()) Then

                Dim lblenth As Integer = txtName.CommandArgument.Length
                Dim fiindex As Integer = txtName.CommandArgument.LastIndexOf("\") + 1
                mFileClientName += txtName.CommandArgument.Substring(fiindex) + ","
            End If
        Next
        If mFileClientName <> String.Empty AndAlso mFileClientName <> "" Then
            mFileClientName = mFileClientName.Substring(0, mFileClientName.Length - 1)
            Dim array_FileName As String() = mFileClientName.Split(",")
            If array_FileName.Length > 1 Then
                Dim LoadEndentity As New DownLoadZip
                LoadEndentity.FileNames = array_FileName
                LoadEndentity.RealFilename = mFileClientName.Split(",")
                LoadEndentity.ZipName = ZipName
                LoadEndentity.FilePath = uploadPath
                If (LoadEndentity.CreatStream()) Then
                    DownLoad(LoadEndentity.ZipName, LoadEndentity.Memory)
                End If
            Else
                If mFileClientName <> String.Empty Then
                    Dim FileDownLoadPath As String = uploadPath + "\" + mFileClientName

                    Dim iStream As System.IO.Stream
                    iStream = New System.IO.FileStream(FileDownLoadPath, System.IO.FileMode.Open, _
                                                        IO.FileAccess.Read, IO.FileShare.Read)

                    FileDownload(mFileClientName, mFileSize, iStream)
                End If
            End If
        End If
    End Sub
End Class
