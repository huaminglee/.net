<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="QCFileDetail.aspx.vb"
    Inherits="CMCFileManage.QCFileDetail" %>

<%@ Register Src="../UCtl/UcFileDetail.ascx" TagName="UcFileDetail" TagPrefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <style type="text/css">
        .cssnovisible
        {
            display: none;
        }
        .cssvisible
        {
            display :inline-table   ;
        }
        
    </style>
    <link href="../IconsThemes/icon.css" rel="stylesheet" type="text/css" />
    <link href="../CSS/AddQCFileDetail.css" rel="stylesheet" type="text/css" />

    <script src="../NewScript/jquery-1.7.2.min.js" type="text/javascript"></script>

    <script src="../NewScript/easyloader.js" type="text/javascript"></script>

    </head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div>
        <div style="float: left">
            <asp:LinkButton ID="LinkFileChangeForm" class="easyui-linkbutton"   iconCls="icon-Manage"
                runat="server">文件變更通知單</asp:LinkButton>
            <asp:LinkButton ID="LinkFileChange" class="easyui-linkbutton"   iconCls="icon-edit"
                runat="server">文件變更</asp:LinkButton></div>
        <asp:LinkButton ID="LinkFileInvalid" class="easyui-linkbutton"   iconCls="icon-no"
            runat="server">文件作廢</asp:LinkButton>
        <asp:LinkButton ID="LinkLeave" class="easyui-linkbutton"   iconCls="icon-back"
            runat="server">離開</asp:LinkButton>
        <div style="float: right">
        </div>
    </div>
    <div align="center" style="color: #0066FF; font-size: 20px; font-family: 標楷體">
        品質文件
    </div>
    <div>
        <table width="100%" style="height: 80px" border="1" cellspacing="0" cellpadding="0"
            bordercolor="#000000" bordercolordark="#FFFFFF" align="center">
            <tr >
                <td align="left" colspan="8" bgcolor="#E6e6e6" height="50">
                    <asp:Image ID="Image5" runat="server" Style="vertical-align: middle" ImageUrl="~/Images/ico/baseinfo.png" />
                    <asp:Label ID="Label4" runat="server" Text="文件基本信息" Font-Bold="True" Font-Size="14px"></asp:Label></td>
            </tr>
            <tr bgcolor="#F3F3F3">
                <td align="center" height="35">
                    文件編號
                </td>
                <td align="center">
                    系統名稱
                </td>
                <td align="center">
                    文件主題
                </td>
                <td align="center">
                    文件變更號
                </td>
                <td align="center">
                    版次
                </td>
                <td align="center">
                    階層
                </td>
                <td align="center">
                    文件類別
                </td>
                <td align="center">
                    頁數
                </td>
            </tr>
            <tr align="center">
                <td>
                    <asp:Label ID="LBFileNo" runat="server" Text=""></asp:Label>
                </td>
                <td>
                    <asp:Label ID="LBSysName" runat="server" Text="華南檢測中心品質管理系統"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="LBFileName" runat="server"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="LBFileRecordNo" runat="server"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="LBFileversion" runat="server"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="LBFileLayer" runat="server"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="LBFileCategory" runat="server"></asp:Label>
                    &nbsp;
                </td>
                <td>
                    <asp:Label ID="LBFileTotalpage" runat="server"></asp:Label>
                </td>
            </tr>
        </table>
    </div>
    <div style="clear: both; height: 20px">
    </div>
    <div id="divfilefujian" runat="server" style="float: right; width: 50%">
        <table style="height: 80px" border="1" cellspacing="0" cellpadding="0" bordercolor="#000000"
            bordercolordark="#FFFFFF" align="left" width="100%">
            <tr>
                <td colspan="2" bgcolor="#E6E6E6" height="50">
                    <asp:Image ID="Image1" Style="vertical-align: middle" runat="server" ImageUrl="~/Images/ico/topdf.png" />
                    <asp:Label ID="Label8" runat="server" Text="文件內容" Font-Bold="True" Font-Size="14px"></asp:Label>
                </td>
            </tr>
            <tr>
                <td height="60">
                    <uc1:UcFileDetail ID="UcFileDetail1" runat="server" />
                </td>
            </tr>
        </table>
    </div>
    <div style="float: left; width: 47%">
        <table style="height: 80px" border="1" cellspacing="0" cellpadding="0" bordercolor="#000000"
            bordercolordark="#FFFFFF" align="left" width="100%">
            <tr>
                <td colspan="2" bgcolor="#E6E6E6" height="50">
                    <asp:Image ID="Image2" Style="vertical-align: middle" runat="server" ImageUrl="~/Images/ico/personal.png" />
                    <asp:Label ID="Label1" runat="server" Text="附加檔案" Font-Bold="True" Font-Size="14px"></asp:Label>
                </td>
            </tr>
            <tr>
                <td height="60">
                    <uc1:UcFileDetail ID="UcFileDetail2" runat="server" />
                </td>
            </tr>
        </table>
    </div>
    <div id="xiuding" runat="server" visible="false" style="font-size: 20px; font-family: 標楷體;
        color: #CC0000">
        修訂履歷</div>
   
    <br />
    <div style="clear: both; height: 20px">
    </div>
    <div>
        <table width="100%" style="height: 60px" border="1" cellpadding="0" cellspacing="0"
            bordercolor="#000000" bordercolordark="#ffffff">
            <tr>
                <td bgcolor="#E6E6E6" colspan="4" height="50">
                    <asp:Image ID="Image3" Style="vertical-align: middle" runat="server" ImageUrl="~/Images/ico/personal.png" />
                    <asp:Label ID="Label2" runat="server" Text="文件所屬信息" Font-Bold="True" Font-Size="14px"></asp:Label>
                </td>
            </tr>
            <tr>
                <td bgcolor="#F3F3F3">
                    申請人
                </td>
                <td>
                    <asp:Label ID="LBApplyUser" runat="server"></asp:Label>
                </td>
                <td bgcolor="#F3F3F3">
                    所屬實驗室
                </td>
                <td>
                    <asp:Label ID="LBApplydepth" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td bgcolor="#F3F3F3">
                    文件生效時間
                </td>
                <td>
                    <asp:Label ID="LBEffectime" runat="server"></asp:Label>
                </td>
                <td bgcolor="#F3F3F3">
                    品保承辦
                </td>
                <td>
                    <asp:Label ID="LBQualityFinishUser" runat="server"></asp:Label>
                    &nbsp;
                </td>
            </tr>
        </table>
    </div>
    <div style="clear: both; height: 20px">
    </div>
    <table width="100%" style="height: 60px" border="1" cellpadding="0" cellspacing="0"
        bordercolor="#000000" bordercolordark="#ffffff">
        <tr >
            <td colspan="2" bgcolor="#E6E6E6" height="50">
                <asp:Image ID="Image4" Style="vertical-align: middle" runat="server" ImageUrl="~/Images/ico/sample.png" />
                <asp:Label ID="Label3" runat="server" Text="分發單位" Font-Bold="True" Font-Size="14px"></asp:Label>
            </td>
        </tr>
        <tr bgcolor="#F3F3F3">
            <td height="35" width="47%">
                <div style="float: left">
                    分發單位</div>
                <div style="float: right">
                    分發紙檔份數
                </div>
            </td>
            <td width="53%">
                <div style="float: left">
                    分發單位</div>
                <div style="float: right">
                    分發紙檔份數</div>
            </td>
        </tr>
        <tr>
            <td colspan="2">
             <table width="100%" >
                        <asp:Repeater ID="Repeater1" runat="server">
                            <ItemTemplate>
                                <td align="left">
                                    <asp:CheckBox ID="CHBdept" Enabled ="false"  Text='<%# DataBinder.Eval(Container.DataItem,"ParameterText") %> '
                                        runat="server" />
                                
                                    <div id="divzdnums" runat ="server"  style="float :right "  class="cssnovisible">
                                        <asp:TextBox ID="TxtzdNums" Width="30px" Enabled ="false"  class="easyui-numberbox" data-options="min:0,max:100,required:true,precision:0"
                                            Text="0" runat="server"></asp:TextBox>
                                    </div>
                                </td>
                            </ItemTemplate>
                        </asp:Repeater>
                    </table>
              
            </td>
        </tr>
    </table>
    </form>
</body>
</html>
