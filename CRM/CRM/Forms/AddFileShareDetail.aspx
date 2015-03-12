<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="AddFileShareDetail.aspx.vb"
    Inherits="CRM.AddFileShareDetail" %>

<%@ Register TagPrefix="telerik" Namespace="Telerik.QuickStart" Assembly="Telerik.QuickStart" %>
<%@ Register TagPrefix="radU" Namespace="Telerik.WebControls" Assembly="RadUpload.Net2" %>
<%@ Register Src="../EFlowNet/Doc/Modules/CtlWFActionList.ascx" TagName="CtlWFActionList"
    TagPrefix="uc1" %>
<%@ Register Src="../EFlowNet/Doc/Modules/ctlWFHistory.ascx" TagName="ctlWFHistory"
    TagPrefix="uc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../IconsThemes/icon.css" rel="Stylesheet" type="text/css" />
    <link href="../NewScript/themes/Default/easyui.css" rel="Stylesheet" type="text/css" />

    <script src="../NewScript/jquery-1.7.2.min.js" type="text/javascript"></script>

    <script type="text/javascript" src="../NewScript/plugins/jquery.bgiframe.js"></script>

    <script src="../NewScript/jquery.easyui.min.js" type="text/javascript"></script>

    <script type="text/javascript" src="../NewScript/datagrid-detailview.js"></script>

    <script type="text/javascript" src="../NewScript/datagrid-groupview.js"></script>

    <script type="text/javascript" src="../NewScript/uploadScript/swfobject.js"></script>

    <script type="text/javascript" src="../NewScript/uploadScript/jquery.uploadify.min.js"></script>

    <script type="text/javascript" src="../NewScript/plugins/jquery.toggleLoading.js"></script>

    <script src="fileshare.js" type="text/javascript"></script>

    <style type="text/css">
        UL
        {
            clear: both;
            padding-right: 0px;
            padding-left: 0px;
            padding-bottom: 0px;
            margin: 0px;
            list-style-type: none;
            padding-top: 2px;
        }
        LI
        {
            padding-right: 0px;
            display: block;
            padding-left: 0px;
            float: left;
            padding-bottom: 0px;
            margin: 0px;
            line-height: 20px;
            padding-top: 0px;
            height: auto;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server" method="post" enctype="multipart/form-data">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" UpdateMode="Conditional" runat="server">
        <ContentTemplate>
            <div>
                <uc1:CtlWFActionList ID="CtlWFActionList1" runat="server" />
            </div>
            <div style="clear: both">
            </div>
            <br />
            <div>
                客戶：
                <asp:TextBox ID="Txtcustomer"  Width="300px" runat="server"></asp:TextBox>
                <asp:Label ID="LbCustomerName"  runat="server" Text="" Font-Size="14px" ForeColor="#009900"></asp:Label>
                <asp:Label ID="lbtishi" runat="server" Text="輸入關鍵字以查詢"></asp:Label><asp:HiddenField
                    ID="HiddenCustomerName" runat="server" />
                <asp:HiddenField ID="HiddenCustomerPKID" Value="0" runat="server" />
                <asp:HiddenField ID="HiddenIsCustomer" Value="1" runat="server" />
                <asp:Button ID="Button2" Style="display: none" runat="server" Text="Button" />
                <asp:Label ID="Lbtongji" runat="server" Text="" ForeColor="#FF3300" Font-Size="14px"></asp:Label>
                <input id="confthis" type ="button" onclick ="confirmthis()" value ="確定選擇該客戶" />
            </div>
            <div>
                <table width="100%" border="1" cellpadding="0" cellspacing="0" bordercolordark="#FFFFFF"
                    bordercolor="#999999">
                    <tr>
                        <td colspan="2" bgcolor="#E6E6E6" height="50">
                            <asp:Image ID="Image3" runat="server" Style="vertical-align: middle" ImageUrl="~/Images/ico/upload.png" />
                            <asp:Label ID="Label8" runat="server" Text="上傳文件" Font-Bold="True" Font-Size="14px"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td   colspan="2">
                            <div title="附件信息" id="FileTab" iconcls="icon-save" style="padding: 10px;">
                                <table id="Filetable">
                                </table>
                                <div id="fileQueue">
                                </div>
                                <div id="DivFileDesc" style="display: none">
                                    <ul>
                                        <li>文件描述</li>
                                        <li style="width: 400px">
                                            <input id="TxtFileDesc" style="width: 400px" type="text" /></li>
                                    </ul>
                                </div>
                            </div>
                            <div id="FileButtons" style="display: none">
                                <ul>
                                    <li>
                                        <input type="file" name="File1" id="FileInfo" />
                                    </li>
                                    <li><a href="#" class="easyui-linkbutton" iconcls="icon-upload" disabled="true" id="BtnFileUpload"
                                        style="top: 10px" onclick="UploadFile();">上傳</a> <a href="#" class="easyui-linkbutton"
                                            iconcls="icon-download" onclick="Download('Filetable');">下載</a> <a href="#" class="easyui-linkbutton"
                                                id="BtnFileDelete" disabled="true" iconcls="icon-cut" onclick="DeleteFile();">Delete</a>
                                    </li>
                                </ul>
                            </div>
                            <div id="FileButtonsDoenload" style="display: none">
                                <a href="#" class="easyui-linkbutton" iconcls="icon-download" onclick="Download('Filetable');">
                                    下載</a>
                            </div>
                        </td>
                    </tr>
                </table>
            </div>
            <div style="clear: both">
            </div>
            
        </ContentTemplate>
    </asp:UpdatePanel>
    <div style="display: none">
        <asp:HiddenField ID="HidCanAdd" Value ="0" runat="server" />
        <asp:HiddenField ID="hidPKID" Value="0" runat="server" />
        <asp:HiddenField ID="HiddenCanSelectCus" Value="0" runat="server" />
        <asp:ImageButton ID="ImageTestDown" OnInit="BtnDownLoadInit" OnClientClick="return true;"
            ImageUrl="~/Images/DownLoad.gif" runat="server" />
        <asp:HiddenField ID="HidFileID" runat="server" />
        <asp:HiddenField ID="HidFileName" runat="server" />
         <asp:HiddenField ID="Hidcuruser" runat="server" />
    </div>
    </form>
</body>
</html>
