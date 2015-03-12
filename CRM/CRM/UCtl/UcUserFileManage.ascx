<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="UcUserFileManage.ascx.vb"
    Inherits="CRM.UcUserFileManage" %>
<%--<link href="../NewScript/Themes/default/easyui.css" rel="stylesheet" type="text/css" />
<link href="../CSS/WebFileManager.css" rel="stylesheet" type="text/css" />

<script src="../NewScript/jquery.js" type="text/javascript"></script>

<script type="text/javascript" src="../NewScript/jqModal.js"></script>

<script src="../JS/FileUpload.js" type="text/javascript"></script>

<script src="../NewScript/UIHelper.js" type="text/javascript"></script>--%>

<div>
    <table width="100%">
        <tr>
            <td bgcolor="#5EA500" height="30px" valign="middle">
                <asp:Label ID="Label1" runat="server" Font-Bold="True" ForeColor="White" Text="我的文件暫存區"></asp:Label>
            </td>
        </tr>
    </table>
    <div id="menu">
        <ul>
            <li><a href="javascript:void(0);" id="create">
                <asp:Image ID="Image2" title="新建" alt="新建" runat="server" ImageUrl="~/images/ico/folder_new.gif" />
                新建文件夾</a></li>
            <li><a href="javascript:void(0);" id="cut">
                <asp:Image ID="Image4" title="剪切" alt="剪切" runat="server" ImageUrl="~/images/ico/cut.gif" />
                剪切</a></li>
            <li><a href="javascript:void(0);" id="copy">
                <asp:Image ID="Image5" title="複製" alt="複製" runat="server" ImageUrl="~/images/ico/copy.gif" />
                複製</a></li>
            <li><a href="javascript:void(0);" id="paste">
                <asp:Image ID="Image6" title="粘貼" alt="粘貼" runat="server" ImageUrl="~/images/ico/paste.gif" />
                粘貼</a></li>
            <li><a href="javascript:void(0);" id="rename">
                <asp:Image ID="Image8" title="重命名" alt="重命名" runat="server" ImageUrl="~/images/ico/rename.gif" />
                重命名</a></li>
            <li><a href="javascript:void(0);" id="delete">
                <asp:Image ID="Image9" title="刪除" alt="刪除" runat="server" ImageUrl="../Images/ico/delete.gif" />
                刪除</a></li>
            <li><a href="javascript:void(0);" id="upload">
                <asp:Image ID="Image1" title="上傳" alt="上傳" runat="server" ImageUrl="../Images/ico/up.gif" />
                上傳</a></li>
            <li>
                <%--<a href="#" id="A1" onclick="Download()">
            <asp:Image ID="Image3" title="下載" alt="下載" runat="server" ImageUrl="~/Images/DownLoadFile.gif" />
            下載</a>--%>
                <asp:ImageButton ID="ImageTestDown" OnClientClick="return true;" runat="server" ImageUrl="~/Images/DownLoadFile.gif" />
                <asp:LinkButton ID="LinkButton2" runat="server">下載</asp:LinkButton>
                </li>
        </ul>
    </div>
    <div style="display: none">
    </div>
    <div style="float: left; width: 100%;">
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" Width="100%"
            OnRowCommand="GridView1_RowCommand" Font-Names="Verdana" Font-Size="12px" OnRowDataBound="GridView1_RowDataBound">
            <Columns>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:CheckBox ID="ChkSelect" runat="server" onclick="SelectSingleCheckBox(window.event);" />
                    </ItemTemplate>
                    <HeaderTemplate>
                        <input type="checkbox" name="CheckAll" id="CheckAll" onclick="CheckChanged()" />
                    </HeaderTemplate>
                    <ItemStyle width="30px" Wrap="False" HorizontalAlign="Center" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="名稱">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("Name") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:LinkButton ID="LinkButton1" runat="server" CommandArgument='<%# Eval("FullName") %>'
                            Text='<%# Eval("Name") %>'></asp:LinkButton>
                    </ItemTemplate>
                    <HeaderStyle HorizontalAlign="Left" />
                </asp:TemplateField>
                <asp:BoundField DataField="CreationDate" HeaderText="創建日期">
                    <ItemStyle Width="12%" Wrap="False" />
                    <HeaderStyle HorizontalAlign="Left" />
                </asp:BoundField>
                <asp:BoundField DataField="Size" HeaderText="大小" DataFormatString="{0} MB">
                    <ItemStyle HorizontalAlign="Right" Width="5%" Wrap="False" />
                    <HeaderStyle HorizontalAlign="Left" />
                </asp:BoundField>
            </Columns>
            <HeaderStyle Height="30px" />
        </asp:GridView>
    </div>
    <div id="divUpload" class="jqmWindow" style="display: none;">
        <h3>
            文件上传</h3>
        <div id="fileQueue" style="width: 100%">
        </div>
        <div style="clear: both">
        </div>
        <input type="file" name="File1" id="uploadify" />
        <a href="javascript:$('#uploadify').uploadifyUpload()" style="font-size: 13px">上传</a>|
        <a href="javascript:$('#uploadify').uploadifyClearQueue()" style="font-size: 13px">取消上传</a>
        <asp:Button ID="btnPanel3Cancel" runat="server" Text="關閉" />
    </div>
    <div id="divCreate" class="jqmWindow" style="display: none;">
        <h3>
            新建文件夾</h3>
        名稱：<asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
        <asp:Button ID="btnCreateFolder" runat="server" Text="確定" OnClick="btnCreateFolder_Click" />
        <asp:Button ID="btnPanel2Cancel" runat="server" Text="取消" /><br />
    </div>
    <div id="divCreateFile" class="jqmWindow" style="display: none;">
        <h3>
            新建文件</h3>
        <p>
            注意：如果本目錄已存在同名的檔，則新建的檔將覆蓋此同名檔。</p>
        <br />
        名稱：<asp:TextBox ID="TextBox4" runat="server" Text="New File.txt"></asp:TextBox>
        <asp:Button ID="Button1" runat="server" Text="確定" OnClick="btnCreateFile_Click" />
        <asp:Button ID="Button4" runat="server" Text="取消" /><br />
    </div>
    <div id="divRename" class="jqmWindow" style="display: none;">
        <h3>
            重命名</h3>
        新名稱：
        <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
        <asp:Button ID="btnRename" runat="server" Text="確定" OnClick="btnRename_Click" />
        <asp:Button ID="btnPanel4Cancel" runat="server" Text="取消" />
    </div>
    <div id="divDelete" class="jqmWindow" style="display: none;">
        <h3>
            刪除檔</h3>
        <p>
            確定刪除選中的檔或檔夾嗎？<br />
            <br />
            <asp:Button ID="btnDelete" runat="server" Text="確定" OnClick="btnDelete_Click" />
            <asp:Button ID="Button2" runat="server" Text="取消" /></p>
    </div>
    <div id="divCopy" class="jqmWindow" style="display: none;">
        <h3>
            複製檔</h3>
        <p>
            確定複製選中的檔或檔夾嗎？<br />
            <br />
            <asp:Button ID="btnCopy" runat="server" Text="確定" OnClick="btnCopy_Click" />
            <asp:Button ID="Button3" runat="server" Text="取消" /></p>
    </div>
    <div id="divPaste" class="jqmWindow" style="display: none;">
        <h3>
            粘貼文件</h3>
        <p>
            確定粘貼選中的檔或檔夾嗎？<br />
            <br />
            <asp:Button ID="btnPaste" runat="server" Text="確定" OnClick="btnPaste_Click" />
            <asp:Button ID="Button5" runat="server" Text="取消" /></p>
    </div>
    <div id="divEdit" class="jqmWindow" style="display: none;">
        <h3>
            編輯檔</h3>
        <p>
            確定編輯檔嗎？<br />
            <br />
            <asp:Button ID="Button8" runat="server" Text="確定" OnClick="btnEdit_Click" />
            <asp:Button ID="Button9" runat="server" Text="取消" /></p>
    </div>
    <div id="divCut" class="jqmWindow" style="display: none;">
        <h3>
            剪切文件</h3>
        <p>
            確定剪切選中的檔或檔夾嗎？<br />
            <br />
            <asp:Button ID="btnCut" runat="server" Text="確定" OnClick="btnCut_Click" />
            <asp:Button ID="Button7" runat="server" Text="取消" /></p>
    </div>
    <div id="divErr" class="jqmWindow" style="display: none;">
        <h3>
            Error</h3>
        <p>
            <asp:Label ID="ErrText" Text="Err" Font-Bold="true" runat="server" Font-Names="Verdana"
                Font-Size="12px"></asp:Label><br />
            <br />
            <asp:Button ID="Button6" runat="server" Text="確定" /></p>
    </div>
    <div id="divEditFile" class="jqmWindow" style="display: none;">
        <h3>
            編輯檔</h3>
        <p>
            路徑：<asp:Label ID="FilePath" Text="FilePath" Font-Bold="true" runat="server" Font-Names="Verdana"
                Font-Size="12px"></asp:Label><br />
            <br />
            <p>
                <asp:TextBox ID="TextBox5" runat="server" Width="100%" Height="300px" TextMode="MultiLine"></asp:TextBox><br />
                <br />
                <asp:Button ID="Button10" runat="server" Text="確定" OnClick="btnEditFile" /></p>
    </div>
    <%--<div style="padding:5px;"><strong>路徑: </strong><asp:Label ID="lblCurrentPath" Font-Bold="true" runat="server" Font-Names="Verdana" Font-Size="12px"></asp:Label></div>--%>
    <div style="display: none">
    </div>
    <div class="searchBox">
        <asp:Image ID="Imagesearch" runat="server" ImageUrl="~/images/ico/computer.gif" Style="border: none;
            vertical-align: absmiddle;" />
        <%= currPath %>
    </div>
    <div style="display: none">
    </div>
    <div style="text-align: center; margin: 5px 0px;">
        目錄數:
        <%= folderNum %>&nbsp;&nbsp;&nbsp;&nbsp;文件數:
        <%= fileNum %></div>
</div>
