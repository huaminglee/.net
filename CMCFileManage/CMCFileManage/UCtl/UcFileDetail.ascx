<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="UcFileDetail.ascx.vb"
    Inherits="CMCFileManage.UcFileDetail" %>
<%@ Register TagPrefix="CuteEditor" Namespace="CuteEditor"  Assembly="CuteEditor" %>
<asp:UpdatePanel runat="server" ID="FilePanel" UpdateMode="Conditional">
    <ContentTemplate>
        <table style="width: 267px; height: 100%;">
            <tr>
                <td rowspan="2">
                    <asp:LinkButton runat="server" ID="BrowseButton">
                        <img id="Img1" runat="server" alt="上傳檔案" src="~/Images/UploadFile.gif" border="0" />
                    </asp:LinkButton>
                </td>
                <asp:HiddenField ID="HidFileCount" Value="0" runat="server" />
                <td>
                    <CuteEditor:UploadAttachments ID="UploadAttachments1" runat="server" ProgressCtrlID="Panel1"
                        ProgressTextID="Label1" ManualStartUpload="false" MultipleFilesUpload="true"
                        ShowCheckBoxes="false" InsertButtonID="BrowseButton" CancelAllMsg="取消所有的上傳" CancelText="取消"
                        CancelUploadMsg="取消上傳" InsertText="選擇上傳文件" UploadingMsg="上傳中..." TempDirectory="~/TempUploadFiles">
                    </CuteEditor:UploadAttachments>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:GridView ID="GridView1" AutoGenerateColumns="False" ShowHeader="false" runat="server">
                        <Columns>
                            <asp:TemplateField>
                                <HeaderStyle Width="10px"></HeaderStyle>
                                <ItemTemplate>
                                    <asp:Image ID="ImageFile" runat="server" ImageUrl='<%# String.Format("~/Images/Icons/{0}.gif",DataBinder.Eval(Container, "DataItem.FileExtension")) %>'>
                                    </asp:Image>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:Label ID="lblParentID" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.ParentID") %>'
                                        Visible="false"></asp:Label>
                                    <asp:Label ID="LbRecordNo" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.Extend5") %>'
                                        Visible="false"></asp:Label>
                                    <asp:Label ID="lblFileName" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.FileName") %>'>
                                    </asp:Label>
                                    <asp:Label ID="lblFileNameNocut" Visible ="false"  runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.FileName") %>'>
                                    </asp:Label>
                                    <asp:Label ID="lblFileID" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.FileID") %>'
                                        Visible="False">
                                    </asp:Label>
                                    <asp:Label ID="LblFileGuiD" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.FileGuID") %>'
                                        Visible="False">
                                    </asp:Label>
                                    <asp:Label ID="lblFileClientName" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.FileClientName") %>'
                                        Visible="False">
                                    </asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:Label ID="LblFileSize" Visible="false" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.FileSize") %>'>
                                    </asp:Label>
                                    <asp:Label ID="LblFileSizeShow" runat="server" Text=""></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:ImageButton ID="btnDownload" Visible="false" ToolTip="閱讀" runat="server" CommandArgument='<%# DataBinder.Eval(Container, "DataItem.FileId") %>'
                                        CommandName="DownLoad" OnInit="BtnDownLoadInit" ImageUrl="../Images/ico/file_new.gif" />
                                    <%--<asp:LinkButton ID="btnDownload" Visible="false" runat="server" CommandArgument='<%# DataBinder.Eval(Container, "DataItem.FileId") %>'
                                        CommandName="DownLoad" OnInit="BtnDownLoadInit">下載</asp:LinkButton>&nbsp;&nbsp;--%>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:ImageButton ID="btnRemove" Visible="false" ToolTip="刪除" runat="server" CommandArgument='<%# DataBinder.Eval(Container, "DataItem.FileId") %>'
                                        CommandName="Remove" ImageUrl="../Images/ico/Delete.gif" />
                                    <%-- <asp:LinkButton ID="btnRemove" Visible="false" runat="server" CommandArgument='<%# DataBinder.Eval(Container, "DataItem.FileId") %>'
                                        CommandName="Remove">刪除</asp:LinkButton>--%>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:Panel ID="Panel1" runat="server">
                        <asp:Label ID="Label1" runat="server"></asp:Label>
                    </asp:Panel>
                </td>
            </tr>
        </table>
    </ContentTemplate>
    <Triggers>
        <asp:AsyncPostBackTrigger ControlID="GridView1" EventName="RowCommand" />
        <asp:AsyncPostBackTrigger ControlID="BrowseButton" EventName="Click" />
    </Triggers>
</asp:UpdatePanel>
