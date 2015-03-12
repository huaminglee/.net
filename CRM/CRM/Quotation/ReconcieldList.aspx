<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="ReconcieldList.aspx.vb"
    Inherits="CRM.ReconcieldList" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../CSS/newaction.css" rel="stylesheet" type="text/css" />

    <script src="../NewScript/My97DatePicker/WdatePicker.js" type="text/javascript"></script>

    <script type="text/javascript" src="../NewScript/UIHelper.js"></script>

    </head>
<body>
    <form id="form1" runat="server">
    <div>
        <table>
            <tr>
                <td>
                    起始時間<asp:TextBox ID="TxtStartDate" class="text-input" runat="server" AutoPostBack="True"></asp:TextBox>
                </td>
                <td>
                    截止時間<asp:TextBox ID="TxtEndDate" class="text-input" runat="server" AutoPostBack="True"></asp:TextBox>
                </td>
                <td>
                    客戶信息<asp:DropDownList ID="DPLCustomerinfo" runat="server" AutoPostBack="True" Width="200px">
                    </asp:DropDownList>
                </td>
                <td>
                </td>
                <td>
                    <asp:LinkButton ID="LinkGetPre" runat="server" Font-Underline="False" ForeColor="Black">
                        <asp:Image ID="Image1" runat="server" Style="vertical-align: middle" ImageUrl="../Images/ico/get.png" />
                        生成對賬單</asp:LinkButton>
                </td>
                <td>
                    &nbsp;
                </td>
            </tr>
        </table>
    </div>
    <div>
        <table width="100%" border="1" cellpadding="0" cellspacing="0" bordercolordark="#FFFFFF"
            bordercolor="#999999">
            <tr>
                <td colspan="3" bgcolor="#E6E6E6" height="50">
                    <asp:Image ID="Image4" runat="server" Style="vertical-align: middle" ImageUrl="~/Images/ico/finishcheck.png" />
                    <asp:Label ID="Label8" runat="server" Text="完成對賬" Font-Bold="True" Font-Size="14px"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    對賬月份：<asp:Label ID="LbReconMonth" runat="server" Text=""></asp:Label>
                </td>
                <td>
                    上傳客戶回傳對帳單：<asp:FileUpload ID="FileUpload1" runat="server" />
                </td>
                <td>
                    <asp:LinkButton ID="LinkFinishPre" runat="server" Font-Underline="False" ForeColor="Black">
                        <asp:Image ID="Image2" runat="server" Style="vertical-align: middle" ImageUrl="../Images/ico/20130611080337494_easyicon_net_24.png" />完成對賬</asp:LinkButton>
                </td>
            </tr>
        </table>
    </div>
    <div>
        <table width="100%" border="1" cellpadding="0" cellspacing="0" bordercolordark="#FFFFFF"
            bordercolor="#999999">
            <tr>
                <td bgcolor="#E6E6E6" height="30">
                    <asp:Image ID="Image5" runat="server" Style="vertical-align: middle" ImageUrl="~/Images/ico/hisrecon.png" />
                    <asp:Label ID="Label1" runat="server" Text="最近對賬信息" Font-Bold="True" Font-Size="14px"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <div id="enmty2" runat="server" visible="false" style="width: 100%; height: 30px; background-color: #DBE3FF;
                        line-height: 30px; overflow: hidden;">
                        <asp:Image ID="Image7" runat="server" ImageUrl="~/Images/Icons/information.png" />
                        &nbsp;&nbsp;&nbsp; 沒有找到相關記錄，請嘗試其他選項。</div>
                    <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" Width="100%"
                        OnRowDataBound="GridView2_RowDataBound">
                        <Columns>
                            <asp:BoundField DataField="XH" HeaderText="序號" />
                            <asp:BoundField DataField="ReconcieldMonth" HeaderText="月份" />
                            <asp:BoundField DataField="ReconPersonID" HeaderText="對賬人" />
                            <asp:BoundField DataField="ReconDate" HeaderText="對賬時間" />
                            <asp:TemplateField HeaderText="回傳對帳單">
                                <ItemTemplate>
                                    <asp:Label ID="LbFileClientName" Visible="false" runat="server" Text='<%#DataBinder.Eval(Container,"DataItem.FileClientName") %>'></asp:Label>
                                    <asp:LinkButton ID="LinkCusFile" Text='<%# DataBinder.Eval(Container,"DataItem.FileRealName") %>'
                                        CommandName="Downfile" runat="server"></asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </td>
            </tr>
        </table>
    </div>
    <div>
        <table width="100%" border="1" cellpadding="0" cellspacing="0" bordercolordark="#FFFFFF"
            bordercolor="#999999">
            <tr>
                <td bgcolor="#E6E6E6" height="30">
                    <asp:Image ID="Image6" runat="server" Style="vertical-align: middle" ImageUrl="~/Images/ico/precidel.ico" />
                    <asp:Label ID="Label2" runat="server" Text="需要對賬信息" Font-Bold="True" Font-Size="14px"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <div id="emptyinfo" runat="server" visible="false" style="width: 100%; height: 30px;
                        background-color: #DBE3FF; line-height: 30px; overflow: hidden;">
                        <asp:Image ID="Image3" runat="server" ImageUrl="~/Images/Icons/information.png" />
                        &nbsp;&nbsp;&nbsp; 沒有找到需要對賬的客戶，請嘗試其他選項。</div>
                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" Width="100%"
                        ShowFooter="True">
                        <Columns>
                            <asp:TemplateField HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                <ItemTemplate>
                                    <asp:CheckBox ID="ChkSelect" class="chkselect" runat="server" onclick="SelectSingleCheckBoxClick(window.event);" />
                                    <asp:Label ID="mPKID" runat="server" Text='<%#DataBinder.Eval(Container,"DataItem.PKID") %>'></asp:Label>
                                    <asp:Label ID="lblDocUniqueID" runat="server" Text='<%# DataBinder.Eval(Container,"DataItem.eFlowDocID").ToString() %>'
                                        Visible="False"></asp:Label>
                                    <asp:HyperLink ID="HLDetail" Target="_self" runat="server" ToolTip="編輯" ImageUrl="~/Images/edit.gif">查看</asp:HyperLink>
                                </ItemTemplate>
                                <HeaderTemplate>
                                    <asp:CheckBox ID="CheckAll" Text="全選" onclick="CheckChanged()" runat="server" />
                                </HeaderTemplate>
                                <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                                <ItemStyle HorizontalAlign="Left"></ItemStyle>
                            </asp:TemplateField>
                            <asp:BoundField HeaderText="報價單號" DataField="QuotationNO" HeaderStyle-HorizontalAlign="Left"
                                ItemStyle-HorizontalAlign="Left">
                                <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                                <ItemStyle HorizontalAlign="Left"></ItemStyle>
                            </asp:BoundField>
                            <asp:BoundField HeaderText="客戶名" DataField="CustomerName" HeaderStyle-HorizontalAlign="Left"
                                ItemStyle-HorizontalAlign="Left">
                                <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                                <ItemStyle HorizontalAlign="Left"></ItemStyle>
                            </asp:BoundField>
                            <asp:BoundField HeaderText="聯繫人" DataField="ContactName" HeaderStyle-HorizontalAlign="Left"
                                ItemStyle-HorizontalAlign="Left">
                                <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                                <ItemStyle HorizontalAlign="Left"></ItemStyle>
                            </asp:BoundField>
                            <asp:BoundField HeaderText="報價人" DataField="QuotaerName" HeaderStyle-HorizontalAlign="Left"
                                ItemStyle-HorizontalAlign="Left">
                                <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                                <ItemStyle HorizontalAlign="Left"></ItemStyle>
                            </asp:BoundField>
                            <asp:BoundField DataField="ContactPhone" HeaderText="聯繫電話" HeaderStyle-HorizontalAlign="Left"
                                ItemStyle-HorizontalAlign="Left">
                                <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                                <ItemStyle HorizontalAlign="Left"></ItemStyle>
                            </asp:BoundField>
                            <asp:BoundField DataField="QuoteDate" HeaderText="報價日期" HeaderStyle-HorizontalAlign="Left"
                                ItemStyle-HorizontalAlign="Left" DataFormatString="{0:yyyy-MM-dd}">
                                <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                                <ItemStyle HorizontalAlign="Left"></ItemStyle>
                            </asp:BoundField>
                            <asp:BoundField DataField="Shijizongjia" HeaderText="未稅報價" HeaderStyle-HorizontalAlign="Left"
                                ItemStyle-HorizontalAlign="Left">
                                <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                                <ItemStyle HorizontalAlign="Left"></ItemStyle>
                            </asp:BoundField>
                             <asp:BoundField DataField="newitemmoney" HeaderText="實際報價" HeaderStyle-HorizontalAlign="Left"
                                ItemStyle-HorizontalAlign="Left">
                                <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                                <ItemStyle HorizontalAlign="Left"></ItemStyle>
                            </asp:BoundField>
                        </Columns>
                    </asp:GridView>
                </td>
            </tr>
        </table>
    </div>
    <div style="display: none">
        <asp:HiddenField ID="HiddenTotal" Value="0" runat="server" />
    </div>
    </form>
</body>
</html>
