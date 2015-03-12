<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="FileDeleteApplyDetail.aspx.vb"
    Inherits="CMCFileManage.FileDeleteApplyDetail" %>

<%@ Register Src="../EFlowNet/Doc/Modules/CtlWFActionList.ascx" TagName="CtlWFActionList"
    TagPrefix="uc1" %>
<%@ Register Src="../EFlowNet/Doc/Modules/ctlWFHistory.ascx" TagName="ctlWFHistory"
    TagPrefix="uc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../IconsThemes/icon.css" rel="stylesheet" type="text/css" />
    <link href="../NewScript/themes/Default/easyui.css" rel="stylesheet" type="text/css" />

    <script src="../NewScript/jquery-1.7.2.min.js" type="text/javascript"></script>

    <script src="../NewScript/jquery.easyui.min.js" type="text/javascript"></script>

    <script src="../NewScript/plugins/jquery.bgiframe.js" type="text/javascript"></script>

    <script src="../NewScript/easyloader.js" type="text/javascript"></script>

    <script src="../NewScript/plugins/jquery.toggleLoading.js" type="text/javascript"></script>

    <script src="../NewScript/UIHelper.js" type="text/javascript"></script>
    
     <script src="Ie6addbgiframe.js" type="text/javascript"></script>

</head>
<body scroll="Auto">
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <table width="100%">
        <tr>
            <td>
                <asp:Image ID="Image3" runat="server" ImageUrl="../Images/blank.jpg" />
                <div>
                    <uc1:CtlWFActionList ID="CtlWFActionList1" runat="server" />
                </div>
                <div style="clear: both">
                </div>
                <div align="center" style="font-size: 20px; font-family: 標楷體">
                    文件刪除申請單</div>
                <div>
                    申請日期:<asp:Label ID="LBApplyDate" runat="server" Text=""></asp:Label></div>
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <div>
                            <table width="100%" style="height: 200px" cellpadding="0" cellspacing="0" border="1"
                                bordercolor="#000000" bordercolordark="#FFFFFF" align="center">
                                <tr align="center">
                                    <td bgcolor="#E5E5E5">
                                        文件類型
                                    </td>
                                    <td align="left">
                                        <asp:DropDownList ID="DPLFileCategory" runat="server" Width="153px" AutoPostBack="True">
                                            <asp:ListItem Selected="True">外來文件</asp:ListItem>
                                            <asp:ListItem>測試標準</asp:ListItem>
                                            <asp:ListItem>客戶規格/測試計劃</asp:ListItem>
                                            <asp:ListItem>測試校準軟體</asp:ListItem>
                                            <asp:ListItem>說明書</asp:ListItem>
                                            <asp:ListItem>設備清單</asp:ListItem>
                                            <asp:ListItem>設備清單附件</asp:ListItem>
                                             <asp:ListItem>關鍵物品清單</asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                    <td bgcolor="#E5E5E5">
                                        文件名稱
                                    </td>
                                    <td align="left">
                                        <asp:TextBox ID="TxtFilename" runat="server"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr align="center">
                                    <td bgcolor="#E5E5E5">
                                        文件編號
                                    </td>
                                    <td align="left">
                                        <asp:TextBox ID="TxtFileBH" runat="server"></asp:TextBox>
                                    </td>
                                    <td bgcolor="#E5E5E5">
                                        所屬實驗室
                                    </td>
                                    <td align="left">
                                        <asp:DropDownList ID="DPLDepth" runat="server" Width="153px">
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr align="center">
                                    <td bgcolor="#E5E5E5">
                                        刪除原因
                                    </td>
                                    <td align="left">
                                        <asp:TextBox ID="TxtReason" runat="server"></asp:TextBox>
                                    </td>
                                    <td bgcolor="#E5E5E5">
                                        申請人
                                    </td>
                                    <td align="left">
                                        <asp:TextBox ID="TxtApplyer" runat="server"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr align="center">
                                    <td bgcolor="#E5E5E5">
                                        備註</td>
                                    <td align="left" colspan="3">
                                        <asp:TextBox ID="TxtRemark" runat="server" TextMode="MultiLine" Width="90%"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr align="center">
                                    <td bgcolor="#E5E5E5">
                                        審核
                                    </td>
                                    <td align="left">
                                        <asp:Label ID="LBshenhe" runat="server"></asp:Label>
                                        &nbsp;
                                    </td>
                                    <td bgcolor="#E5E5E5">
                                        品保結案
                                    </td>
                                    <td align="left">
                                        <asp:Label ID="LBpinbao" runat="server"></asp:Label>
                                        &nbsp;
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
                <div style="height: 20px">
                </div>
                <div>
                 <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
            Width="100%">
            <Columns>
                <asp:BoundField DataField="Singer" HeaderText="簽核者" ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left" />
                <asp:BoundField DataField="SignTime" HeaderText="時間" ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left"/>
                <asp:BoundField DataField="activity" HeaderText="動作" ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left"/>
                <asp:BoundField DataField="Signremark" HeaderText="意見" ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left"/>
            </Columns>
        </asp:GridView>
                    <uc2:ctlWFHistory ID="ctlWFHistory1" runat="server" />
                </div>
                
            </td>
        </tr>
    </table>
    </form>
</body>
</html>
