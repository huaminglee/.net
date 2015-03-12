<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="UCtlImgList.ascx.vb"
    Inherits="CRM.UCtlImgList" %>

<script src="../JS/JSLeft.js" type="text/javascript"></script>

<%--onmousemove="move_layer()"--%>
<table border="0" cellpadding="0" cellspacing="0" width="100%">
    <tr>
        <td align="left">
            <asp:DataList ID="DataList1" runat="server" RepeatDirection="Horizontal">
                <ItemStyle VerticalAlign="Bottom" />
                <ItemTemplate>
                    <table border="0" cellpadding="0" cellspacing="0">
                        <tr>
                            <td align="right">
                                <asp:LinkButton ID="lnkDelete" runat="server" CommandName="Delete" ForeColor="Red">刪除</asp:LinkButton>
                            </td>
                        </tr>
                        <tr>
                            <td valign="bottom">
                                <%--onmouseover="show(this)" onmouseout="hide(this)" 圖片預覽功能（在同一頁面中多個使用會出現錯誤，改進中）--%>
                                <div id="divImg" runat="server" >
                                    <asp:HyperLink ID="HyperLink1" runat="server" Target="_blank" >
                                        <asp:Image ID="Image1" runat="server" /></asp:HyperLink></div>
                            </td>
                        </tr>
                    </table>
                </ItemTemplate>
            </asp:DataList>
        </td>
    </tr>
    <tr>
        <td align="left" id="TDDown" runat="server">
            <asp:FileUpload ID="FileUpload1" runat="server" />
            <asp:Button ID="BtnAddImg" runat="server" Text="上傳" />
            <asp:Button ID="BtnClear" runat="server" Text="清空" />
        </td>
    </tr>
</table>
<div id="enlarge_images" style="position: absolute; z-index: 2">
</div>
