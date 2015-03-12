''' <summary>
''' 上傳傳下載圖片(一般默認情況下只需要設定ImgList或者得到ImgList)
''' </summary>
''' <remarks></remarks>
Partial Public Class UCtlImgList
    Inherits System.Web.UI.UserControl
#Region "Property"
    ''' <summary>
    ''' 取得或設定圖片地址陣列
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property ImgList() As List(Of String)
        Get
            If ViewState("ImgList") Is Nothing Then
                ViewState("ImgList") = New List(Of String)
                Return ViewState("ImgList")
            Else
                Return ViewState("ImgList")
            End If
            Return ViewState("ImgList")
        End Get
        Set(ByVal value As List(Of String))
            ViewState("ImgList") = value
        End Set
    End Property
    ''' <summary>
    ''' 存放圖片文件夾(在Upload下的資料夾) 
    ''' 如果上傳圖片需要分類請設定Folder為Upload文件夾下的子文件夾，默認為直接在Upload中
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property Folder() As String
        Get    
            Return ViewState("Folder")
        End Get
        Set(ByVal value As String)
            ViewState("Folder") = value
        End Set
    End Property
    ''' <summary>
    ''' 是否只可下載
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property DownLoadOnly() As Boolean
        Get
            If ViewState("DownLoadOnly") Is Nothing Then
                ViewState("DownLoadOnly") = True
            End If
            Return ViewState("DownLoadOnly")
        End Get
        Set(ByVal value As Boolean)
            ViewState("DownLoadOnly") = value
        End Set
    End Property
    ''' <summary>
    ''' 圖片預覽高度
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Protected Property ImgHeight() As Unit
        Get
            If ViewState("ImgHeight") Is Nothing Then
                Return 32
            Else
                Return ViewState("ImgHeight")
            End If
        End Get
        Set(ByVal value As Unit)
            ViewState("ImgHeight") = value
        End Set
    End Property
    ''' <summary>
    ''' 圖片預覽寬度
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Protected Property ImgWidth() As Unit
        Get
            If ViewState("ImgWidth") Is Nothing Then
                Return 32
            Else
                Return ViewState("ImgWidth")
            End If
        End Get
        Set(ByVal value As Unit)
            ViewState("ImgWidth") = value
        End Set
    End Property
    ''' <summary>
    ''' 流覽Txt寬度
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property TxtWidth() As Unit
        Get
            If ViewState("TxtWidth") Is Nothing Then
                Return 150
            Else
                Return ViewState("TxtWidth")
            End If
        End Get
        Set(ByVal value As Unit)
            ViewState("TxtWidth") = value
        End Set
    End Property
    ''' <summary>
    ''' 保持圖片總可以下載（針對在流程中下載被層遮擋住后不可下載附近進行設置，默認為被層遮擋后可下載）
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property AlwaysDownLoad() As Boolean
        Get
            If ViewState("AlwaysDownLoad") Is Nothing Then
                ViewState("AlwaysDownLoad") = True
            End If
            Return ViewState("AlwaysDownLoad")
        End Get
        Set(ByVal value As Boolean)
            ViewState("AlwaysDownLoad") = value
        End Set
    End Property
#End Region

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            ' ImgList = New List(Of String)
            datalist_BD()
            FileUpload1.Width = TxtWidth
            TDDown.Visible = DownLoadOnly

        End If

    End Sub


    Sub datalist_BD()
        ImgList.RemoveAll(AddressOf RemovEmpty)
        DataList1.DataSource = ImgList
        DataList1.DataBind()
    End Sub

    Private Shared Function RemovEmpty(ByVal s As String) As Boolean

        If s = "" Then
            Return True
        Else
            Return False
        End If
    End Function
    Protected Sub BtnAddImg_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BtnAddImg.Click
        upload()
    End Sub

    Function upload() As Boolean

        If FileUpload1.HasFile Then
            Try
                Dim FileName As String = Date.Now.ToString("yyyyMMddhhmmss") + FileUpload1.FileName.Substring(FileUpload1.FileName.IndexOf("."))

                FileUpload1.PostedFile.SaveAs(Server.MapPath("~/") + "\Upload\" + Folder + "\" + FileName)
                'IO.File.Copy(FileUpload1.PostedFile.FileName, Server.MapPath("~/") + "\Upload\" + Folder + "\" + FileName, False)
                'IO.File.Exists(Server.MapPath("~/") + "\Upload\" + Folder + "\" + FileName)
                ImgList.Add("~\Upload\" + Folder + "\" + FileName)
                datalist_BD()
                Return True
            Catch ex As Exception
                If ex.Message.Contains("已經存在") Then
                    DataAssist.ShowMessage("文件名重複，請修改文件名后重新上傳", Me.Page)

                    Return False
                Else
                    DataAssist.ShowMessage(ex.Message, Me.Page)
                    Return False
                End If
            End Try
        Else
            DataAssist.ShowMessage("請選擇文件", Me.Page)
            Return False
        End If
    End Function

    Protected Sub DataList1_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataListItemEventArgs) Handles DataList1.ItemDataBound
        If CType(DataList1.DataSource, List(Of String)).Count > 0 Then
            Dim list As List(Of String) = DataList1.DataSource
            Dim img As Image = CType(e.Item.FindControl("Image1"), Image)
            Dim HL As HyperLink = CType(e.Item.FindControl("HyperLink1"), HyperLink)
            Dim str As String = list(e.Item.ItemIndex).ToString
            Dim lnkdelete As LinkButton = e.Item.FindControl("lnkDelete")
            Dim div As HtmlGenericControl = CType(e.Item.FindControl("divImg"), Web.UI.HtmlControls.HtmlGenericControl)



            lnkdelete.Visible = DownLoadOnly

            Try
                Drawing.Image.FromFile(Server.MapPath("~/") + str.Replace("~", ""))
                img.ImageUrl = str
                img.Width = ImgWidth
                img.Height = ImgHeight
            Catch ex As Exception
                img.ImageUrl = "~\Image\Get Document.png"
                img.Height = "32"
                img.Width = "32"

            End Try
            HL.NavigateUrl = str
            If AlwaysDownLoad Then

                div.Style.Add("z-index", "1000")
                div.Style.Add("position", "relative")
            Else
                div.Style.Clear()
            End If
        End If

    End Sub

    Protected Sub BtnClear_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BtnClear.Click
        ImgList.Clear()
        datalist_BD()
    End Sub

    Protected Sub DataList1_DeleteCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataListCommandEventArgs) Handles DataList1.DeleteCommand
        Dim img As Image = CType(e.Item.FindControl("Image1"), Image)
        Dim HL As HyperLink = CType(e.Item.FindControl("HyperLink1"), HyperLink)
        If Not img Is Nothing Then
            ImgList.Remove(HL.NavigateUrl)
            datalist_BD()
        End If
    End Sub
End Class