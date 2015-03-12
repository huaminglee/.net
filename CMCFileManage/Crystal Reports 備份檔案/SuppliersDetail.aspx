<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="SuppliersDetail.aspx.vb"
    Inherits="CMCFileManage.SuppliersDetail" %>

<%@ Register Src="../UCtl/UcFileDetail.ascx" TagName="UcFileDetail" TagPrefix="uc1" %>
<%@ Register Src="../EFlowNet/Doc/Modules/CtlWFActionList.ascx" TagName="CtlWFActionList"
    TagPrefix="uc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../NewScript/themes/Default/easyui.css" rel="stylesheet" type="text/css" />
    <link href="../IconsThemes/icon.css" rel="stylesheet" type="text/css" />

    <script src="../NewScript/jquery-1.7.2.min.js" type="text/javascript"></script>

    <script src="../NewScript/jquery.easyui.min.js" type="text/javascript"></script>

    <script src="../NewScript/easyloader.js" type="text/javascript"></script>

    <script src="../NewScript/plugins/jquery.bgiframe.js" type="text/javascript"></script>

    <script src="../NewScript/plugins/jquery.toggleLoading.js" type="text/javascript"></script>

    <script src="../NewScript/My97DatePicker/WdatePicker.js" type="text/javascript"></script>

    <script src="Supplisers.js" type="text/javascript"></script>

</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div>
        <uc2:CtlWFActionList ID="CtlWFActionList1" runat="server" />
    </div>
    <div style="float: left; width: 60%">
        <table style="height: 80px" border="1" cellspacing="0" cellpadding="0" bordercolor="#000000"
            bordercolordark="#FFFFFF" align="left" width="100%">
            <tr>
                <td colspan="2" bgcolor="#E6E6E6" height="50">
                    <asp:Image ID="Image1" runat="server"  Style="vertical-align: middle" ImageUrl="~/Images/ico/personal.png" />
                    <asp:Label ID="Label8" runat="server" Text="供應商基本信息" Font-Bold="True" Font-Size="14px"></asp:Label>
                    </td> 
            </tr>
            <tr>
                <td>
                    供應商名稱
                </td>
                <td>
                    <asp:TextBox ID="TxtSupplierName" runat="server" Width="250px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    供應商簡稱
                </td>
                <td>
                    <asp:TextBox ID="TxtSupplierShortName"  Width="250px" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    聯繫人
                </td>
                <td>
                    <asp:TextBox ID="TxtContactName"  Width="250px" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    聯繫電話
                </td>
                <td>
                    <asp:TextBox ID="TxtContactPhone"  Width="250px" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    地址
                </td>
                <td>
                    <asp:TextBox ID="TxtAddress"  Width="250px" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    經營項目
                </td>
                <td>
                    <asp:TextBox ID="TxtIndustry"  Width="250px" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    所屬實驗室
                </td>
                <td>
                    <asp:DropDownList ID="DplBelongLab" runat="server" Width="250px">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>
                    ISO證書有效期限
                </td>
                <td>
                    <asp:TextBox ID="TxtISOdate"  Width="250px" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    營業執照有效期限
                </td>
                <td>
                    <asp:TextBox ID="TxtBIdate"  Width="250px" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    評估人
                </td>
                <td>
                    <asp:TextBox ID="TxtAssessor"  Width="250px" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    交易狀態
                </td>
                <td>
                    <asp:RadioButtonList ID="RdoStatus" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow"
                        Width="250px">
                        <asp:ListItem Value="1" Selected="True">交易中</asp:ListItem>
                        <asp:ListItem Value="2">已凍結</asp:ListItem>
                    </asp:RadioButtonList>
                </td>
            </tr>
            <tr>
                <td>
                    評估週期
                </td>
                <td>
                    <asp:TextBox ID="TxtAssessCycle" Text="0"  Width="250px" class="easyui-numberbox" data-options="min:0,max:1000,required:true,precision:0"
                        runat="server"></asp:TextBox>個月
                </td>
            </tr>
            <tr>
                <td>
                    評估日期
                </td>
                <td>
                    <asp:TextBox ID="TxtAssessDate"  Width="250px" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    評估結果
                </td>
                <td>
                    <asp:TextBox ID="TxtAssessResult"  Width="250px" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    備註
                </td>
                <td>
                    <asp:TextBox ID="TxtRemark"  Width="250px" runat="server"></asp:TextBox>
                </td>
            </tr>
        </table>
    </div>
    <div style="float: right; width: 38%">
        <table border="1" cellspacing="0" cellpadding="0" bordercolor="#000000" bordercolordark="#FFFFFF"
            align="left" width="100%">
            <tr>
                <td bgcolor="#E6E6E6" colspan="2" height="50">
                    <asp:Image ID="Image2" runat="server"  Style="vertical-align: middle" ImageUrl="~/Images/ico/topdf.png" />
                    <asp:Label ID="Label1" runat="server" Text="供應商附件信息" Font-Bold="True" Font-Size="14px"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <uc1:UcFileDetail ID="UcFileDetail1" runat="server" />
                </td>
            </tr>
        </table>
    </div>
    <div style="clear: both">
    </div>
    <div id="checkrecord" runat="server">
        <table border="1" cellspacing="0" cellpadding="0" bordercolor="#000000" bordercolordark="#FFFFFF"
            align="left" width="100%">
            <tr>
                <td class="LiAdd " bgcolor="#E6E6E6" colspan="2" height="50">
                    <table>
                        <tr>
                            <td>
                                <asp:Image ID="Image3" runat="server"  Style="vertical-align: middle" ImageUrl="~/Images/ico/history.png" />
                                <asp:Label ID="Label2" runat="server" Text="定期檢查記錄" Font-Bold="True" Font-Size="14px"></asp:Label>
                            </td>
                            <td>
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<a
                                    id="addcheck" runat="server" visible="false" href="#" onclick="addcheck()">添加檢查記錄</a>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" Width="100%">
                        <Columns>
                            <asp:BoundField DataField="CheckDate" HeaderText="檢查日期" DataFormatString='{0:yy-MM-dd}'
                                HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left" />
                            <asp:TemplateField HeaderText="品質" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                <ItemTemplate>
                                    <asp:Label ID="LbQuality" runat="server" Text='<%# DataBinder.Eval(Container,"DataItem.Quality") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="服務" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                <ItemTemplate>
                                    <asp:Label ID="LbService" runat="server" Text='<%# DataBinder.Eval(Container,"DataItem.Service") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="交貨" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                <ItemTemplate>
                                    <asp:Label ID="LbDelivery" runat="server" Text='<%# DataBinder.Eval(Container,"DataItem.Delivery") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="Others" HeaderText="其他" HeaderStyle-HorizontalAlign="Left"
                                ItemStyle-HorizontalAlign="Left" />
                            <asp:TemplateField HeaderText="合格判定" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                <ItemTemplate>
                                    <asp:Label ID="LbIsOK" runat="server" Text='<%# DataBinder.Eval(Container,"DataItem.IsOK") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="CheckPerson" HeaderText="考評人" HeaderStyle-HorizontalAlign="Left"
                                ItemStyle-HorizontalAlign="Left" />
                            <asp:BoundField DataField="Remark" HeaderText="備註" HeaderStyle-HorizontalAlign="Left"
                                ItemStyle-HorizontalAlign="Left" />
                        </Columns>
                    </asp:GridView>
                </td>
            </tr>
        </table>
    </div>
    <div style="clear: both">
    </div>
    <br />
    <div>
        <table border="1" cellspacing="0" cellpadding="0" bordercolor="#000000" bordercolordark="#FFFFFF"
            align="left" width="100%">
            <tr>
                <td bgcolor="#E6E6E6" colspan="2" height="50">
                    <asp:Label ID="Label3" runat="server" Text="文件變更記錄" Font-Bold="True" Font-Size="14px"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" Width="100%">
                        <Columns>
                            <asp:BoundField DataField="ChangeUser" HeaderText="變更人" HeaderStyle-HorizontalAlign="Left"
                                ItemStyle-HorizontalAlign="Left" />
                            <asp:TemplateField HeaderText="變更時間" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                <ItemTemplate>
                                    <asp:Label ID="LbChangeTime" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.ChangeTime","{0:yyyy-MM-dd}") %>'></asp:Label>
                                </ItemTemplate>
                                <HeaderStyle Wrap="False" />
                                <HeaderStyle HorizontalAlign="Left" />
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </td>
            </tr>
        </table>
    </div>
    <div style="display: none">
        <asp:Button ID="btn1" runat="server" Text="Button" />
        <asp:HiddenField ID="HiddenPKID" Value="0" runat="server" />
    </div>
    </form>
</body>
</html>
