<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="FileShare.aspx.vb" Inherits="CRM.FileShare" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../IconsThemes/icon.css" rel="Stylesheet" type="text/css" />
    <link href="../NewScript/themes/Default/easyui.css" rel="Stylesheet" type="text/css" />

    <script src="../NewScript/jquery-1.7.2.min.js" type="text/javascript"></script>

    <script src="../NewScript/jquery.easyui.min.js" type="text/javascript"></script>

    <script src="fileshare2.js" type="text/javascript"></script>

    </head>
<body>
    <form id="form1" runat="server" method="post" enctype="multipart/form-data">
   
    <div>
        客戶：<asp:DropDownList ID="DPLcustomer" Visible="false" runat="server" AutoPostBack="True"
            Width="290px">
        </asp:DropDownList>
        <asp:Label ID="LbCustomer" Visible ="false"  runat="server" Text=""></asp:Label>
        <asp:TextBox ID="Txtcustomer" Width="300px" runat="server"></asp:TextBox>
        <asp:Label ID="lbtishi" runat="server" Text="輸入關鍵字以查詢"></asp:Label><asp:HiddenField ID="HiddenCustomerName" runat="server" />
        <asp:HiddenField ID="HiddenCustomerPKID" Value="0" runat="server" />
        <asp:HiddenField ID="HiddenCanSelectCus" Value ="0" runat="server" />
        <asp:Button ID="Button2" Style="display: none" runat="server" Text="Button" />
        <asp:Label ID="Lbtongji" runat="server" Text="" ForeColor="#FF3300" Font-Size="14px"></asp:Label>
    </div>
   <%-- <div  >
        <table width="100%" border="1" cellpadding="0" cellspacing="0" bordercolordark="#FFFFFF"
            bordercolor="#999999">
            <tr>
                <td  colspan="2" bgcolor="#E6E6E6" height="50">
                <asp:Image ID="Image3" runat="server" Style="vertical-align: middle" ImageUrl="~/Images/ico/upload.png" />
                    <asp:Label ID="Label8" runat="server" Text="上傳文件" Font-Bold="True" Font-Size="14px"></asp:Label>
                </td>
                
            </tr>
            <tr>
                <td width="300px">
                    <input class="s_verdana" contenteditable="false" type="file" size="40" name="m_file"
                        id="m_file"><br>
                    <input class="s_verdana" contenteditable="false" type="file" size="40" name="m_file"
                        id="m_file"><font face="冼极"><br>
                        </font>
                    <input class="s_verdana" contenteditable="false" type="file" size="40" name="m_file"
                        id="m_file"><font face="冼极"><br>
                            <input class="s_verdana" contenteditable="false" type="file" size="40" name="m_file"
                                id="m_file"></font><br>
                </td>
                <td>
                    文件說明：
                    <asp:TextBox ID="TxtRemark" runat="server" Height="71px" TextMode="MultiLine"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td align="center">
                    <asp:Button ID="Button1" runat="server" Text="上傳" CssClass="s_verdana" OnClick="Button1_Click"
                        OnLoad="Button1_Load" Height="38px" Width="140px"></asp:Button>
                </td>
                <td>
                    &nbsp;
                </td>
            </tr>
        </table>
    </div>
    --%>
    <div style="clear: both">
    </div>
    <div>
    
        <table  width="100%" border="1" cellpadding="0" cellspacing="0" bordercolordark="#FFFFFF"
            bordercolor="#999999">
            <tr>
                <td bgcolor="#E6E6E6" height="50">
                <asp:Image ID="Image2" runat="server" Style="vertical-align: middle" 
                        ImageUrl="~/Images/ico/downloadfile.png" Width="32px" />
                    <asp:Label ID="Label1" runat="server" Text="共享文件" Font-Bold="True" Font-Size="14px"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:GridView ID="GridView1" AutoGenerateColumns="False" runat="server" Width="100%"
            BorderStyle="None" CellPadding="0" GridLines="None">
            <Columns>
                <asp:TemplateField ItemStyle-Width="10px">
                    <HeaderStyle Width="10px"></HeaderStyle>
                    <ItemTemplate>
                        <asp:Image ID="ImageFile" runat="server" ImageUrl='<%# String.Format("~/Images/Icons/{0}.gif",DataBinder.Eval(Container, "DataItem.FileExtension")) %>'>
                        </asp:Image>
                    </ItemTemplate>
                    <ItemStyle Width="10px"></ItemStyle>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="文件名" HeaderStyle-HorizontalAlign="left" ItemStyle-HorizontalAlign="left">
                    <ItemTemplate>
                        <asp:Label ID="lblParentID" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.ParentID") %>'
                            Visible="false"></asp:Label>
                        <asp:Label ID="lblFileName" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.FileName") %>'>
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
                        <asp:Label ID="LbTestNo" runat="server" Visible="false" Text='<%# DataBinder.Eval(Container,"DataItem.Extend4") %>'></asp:Label>
                    </ItemTemplate>
                    <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                    <ItemStyle HorizontalAlign="Left"></ItemStyle>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="文件大小" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <asp:Label ID="LblFileSize" Visible="false" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.FileSize") %>'>
                        </asp:Label>
                        <asp:Label ID="LblFileSizeShow" runat="server" Text=""></asp:Label>
                    </ItemTemplate>
                    <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                </asp:TemplateField>
                <asp:BoundField DataField="Extend1" HeaderText="上傳人" HeaderStyle-HorizontalAlign="Center"
                    ItemStyle-HorizontalAlign="Center">
                    <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                </asp:BoundField>
                <asp:BoundField DataField="RecordCreateTime" DataFormatString="{0:yyyy-MM-dd}" HeaderText="上傳時間"
                    ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center">
                    <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                </asp:BoundField>
                <asp:BoundField DataField="Extend2" HeaderText="說明" HeaderStyle-HorizontalAlign="Left"
                    ItemStyle-HorizontalAlign="Left" ItemStyle-Width="300px" />
                <asp:TemplateField HeaderText="下載" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <asp:ImageButton ID="btnDownload" ToolTip="下載" runat="server" CommandArgument='<%# DataBinder.Eval(Container, "DataItem.FileId") %>'
                            CommandName="DownLoad" ImageUrl="../Images/ico/DownLoadFile.gif" />
                        <%--<asp:LinkButton ID="btnDownload" Visible="false" runat="server" CommandArgument='<%# DataBinder.Eval(Container, "DataItem.FileId") %>'
                                        CommandName="DownLoad" OnInit="BtnDownLoadInit">下載</asp:LinkButton>&nbsp;&nbsp;--%>
                    </ItemTemplate>
                    <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="刪除" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <asp:ImageButton ID="btnRemove" ToolTip="刪除" runat="server" CommandArgument='<%# DataBinder.Eval(Container, "DataItem.FileId") %>'
                            CommandName="Remove" ImageUrl="../Images/ico/trash.png" />
                        <%--<asp:LinkButton ID="btnRemove" Visible="false" runat="server" CommandArgument='<%# DataBinder.Eval(Container, "DataItem.FileId") %>'
                                        CommandName="Remove">刪除</asp:LinkButton>--%>
                    </ItemTemplate>
                    <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                </asp:TemplateField>
            </Columns>
        </asp:GridView></td>
            </tr>
        </table>
    
        
    </div>
     <div id="emptyinfo" runat="server" visible="false" style="width: 100%; height: 30px;
        background-color: #DBE3FF; line-height: 30px; overflow: hidden;">
        <asp:Image ID="Image1" runat="server" ImageUrl="~/Images/Icons/information.png" />
        &nbsp;&nbsp;&nbsp; 客戶還沒有共享文件。</div>
        
    </form>
</body>
</html>
