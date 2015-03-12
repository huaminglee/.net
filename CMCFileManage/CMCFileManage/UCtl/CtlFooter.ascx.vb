Public Class CtlFooter
    Inherits System.Web.UI.UserControl

#Region " Web Form 設計工具產生的程式碼 "

    '此為 Web Form 設計工具所需的呼叫。
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents HLPracScheme As System.Web.UI.WebControls.HyperLink
    Protected WithEvents Hyperlink1 As System.Web.UI.WebControls.HyperLink
    Protected WithEvents Hyperlink2 As System.Web.UI.WebControls.HyperLink
    Protected WithEvents Hyperlink3 As System.Web.UI.WebControls.HyperLink

    '注意: 下列預留位置宣告是 Web Form 設計工具需要的項目。
    '請勿刪除或移動它。
    Private designerPlaceholderDeclaration As System.Object

    Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
        'CODEGEN: 此為 Web Form 設計工具所需的方法呼叫
        '請勿使用程式碼編輯器進行修改。
        InitializeComponent()
    End Sub

#End Region

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        '在這裡放置使用者程式碼以初始化網頁
        If Not IsPostBack Then
            Me.Hyperlink1.NavigateUrl = Global_asax.UrlBase + "/GMPCSI/GMPCSISet.aspx"
            Me.Hyperlink2.NavigateUrl = Global_asax.UrlBase + "/GMPCSI/GMPCSIResult.aspx"
            Me.Hyperlink3.NavigateUrl = Global_asax.UrlBase + "/GMPCSI/GMPCSIItemReports.aspx"
        End If
    End Sub

End Class
