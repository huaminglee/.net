<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="CtlGMPCSISet.ascx.vb"
    Inherits="CMCFileManage.CtlGMPCSISet" TargetSchema="http://schemas.microsoft.com/intellisense/ie5" %>
<%@ Register TagPrefix="cc1" Namespace="myControl" Assembly="myControl" %>
<table id="TableTitle" width="100%">
    <tr align="center">
        <td class="PageHead" style="white-space: nowrap" align="center">
            機構採購檢測中心客戶滿意度調查</B>
        </td>
    </tr>
</table>
<table id="TableOutDate" width="100%" runat="server" visible="false">
    <tr valign="middle">
        <td valign="middle" align="center">
            <asp:Label ID="Label2" runat="server" Text="本此調查已經結束,請設定新的一次調查信息!" CssClass="NormalRedBig"></asp:Label>
        </td>
    </tr>
</table>
<table id="Table1" cellspacing="0" cellpadding="0" width="100%" border="0">
    <tr>
        <td class="TdTitle" style="white-space: nowrap" colspan="4" height="30">
            1.設定調查基本信息
        </td>
    </tr>
    <tr id="notice" runat="server" visible="false">
        <td align="center" colspan="2">
            <p align="left">
                <asp:Label ID="LblNotice" runat="server" CssClass="CSIRed" ForeColor="Red" Width="632px"></asp:Label></p>
        </td>
    </tr>
    <tr class="ContentText">
        <td style="white-space: nowrap" align="right" height="25">
            <asp:Label ID="lblOrderDate" runat="server">調查日期:</asp:Label>
        </td>
        <td style="white-space: nowrap">
            &nbsp;&nbsp;<asp:Label ID="LblStart" runat="server">開始:</asp:Label>
            <asp:TextBox ID="txtStartDate" runat="server" Width="120px"></asp:TextBox>&nbsp;&nbsp;<asp:Label
                ID="LblEnd" runat="server">截止:</asp:Label>
            <asp:TextBox ID="txtEndDate" runat="server" Width="120px"></asp:TextBox><asp:Label
                ID="lblCSITime" runat="server" CssClass="CSIRed"></asp:Label>
        </td>
        <td>
            <input type="hidden" id="txtCSITime" runat="server" name="txtCSITime">
        </td>
        <td style="white-space: nowrap" width="15%">
        </td>
    </tr>
    <tr>
        <td style="white-space: nowrap" align="right" class="ContentText">
            <asp:Label ID="Label1" runat="server">調查注意事項:</asp:Label>
        </td>
        <td style="white-space: nowrap">
            <asp:TextBox ID="TxtNotice" runat="server" Width="400px" MaxLength="200" TextMode="MultiLine"></asp:TextBox><asp:Button
                ID="BtnConfirm" runat="server" class="button" Text="確 定"></asp:Button>
        </td>
        <td>
        </td>
        <td style="white-space: nowrap" width="15%">
        </td>
    </tr>
    <tr height="5">
        <td>
        </td>
    </tr>
    <tr>
        <td class="TdTitle" style="white-space: nowrap" colspan="4" height="30">
            2.主動調查數據源
        </td>
    </tr>
    <tr height="5">
        <td>
        </td>
    </tr>
    <tr class="ContentText">
        <td style="white-space: nowrap" align="right">
            <asp:Label ID="lblDept" runat="server" CssClass="NormalText">選擇實驗室:</asp:Label>
        </td>
        <td style="white-space: nowrap">
            <asp:DropDownList ID="DLLabList" runat="server" CssClass="NormalText" Width="152px">
            </asp:DropDownList>
            <asp:Label ID="LblMsg" runat="server" CssClass="CSIRed"></asp:Label>
        </td>
        <td>
        </td>
        <td style="white-space: nowrap" width="15%">
        </td>
    </tr>
    <tr class="ContentText">
        <td class="NormalText" style="white-space: nowrap" align="right">
            匯入調查數據:
        </td>
        <td style="white-space: nowrap" align="left" colspan="2">
            <input class="FileUpload" id="FileUpload" type="file" name="FileUpload" runat="server">
            <asp:LinkButton ID="BtnUpLoad" runat="server" CssClass="CommandButton">
				<img alt="上傳" src="../images/UploadFile.gif" border="0">上傳</asp:LinkButton>
        </td>
        <td style="white-space: nowrap" width="15%">
            <a href="../ModuleForExcel/匯入調查人員信息模板.xls">
                <asp:Image ID="Image1" runat="server" ImageUrl="~/Images/Excel.gif" />
                數據匯入模板下載</a>
        </td>
    </tr>
    <tr height="5">
        <td>
        </td>
    </tr>
    <tr class="TdTitle">
        <td style="white-space: nowrap" height="30">
            3.受訪數據源清單
        </td>
        <td valign="middle" style="white-space: nowrap" align="right">
            <%--<asp:CheckBox ID="CheckBoxCc" runat="server" CssClass="SkinObject" Text="是否抄送"></asp:CheckBox>--%>
        </td>
        <td style="white-space: nowrap" align="center">
            <input type="text" id="CCEmail" runat="server" style="display: none; visibility: hidden;
                width: 250px">
            <asp:Label ID="LbSendMsg" Font-Bold ="false"  runat="server"></asp:Label>
        </td>
        <td>
            <asp:LinkButton ID="ImgSend" runat="server" CssClass="CommandButton">
				<IMG alt="發送Email" src="../images/www6Lucn0021.gif" border="0">發送Email</asp:LinkButton>
        </td>
    </tr>
    <tr height="5">
        <td>
        </td>
    </tr>
    <tr>
        <td valign="top" style="white-space: nowrap" align="left" width="150px">
            <table align="center" border="0" width="150px">
                <!--Header Part2-->
                <tr>
                    <td valign="top" bgcolor="#339933" style="color: #FFFFFF">
                        請選擇部門
                    </td>
                </tr>
                <tr>
                    <td valign="top" align="left">
                        <asp:DataList ID="DList" runat="server" HorizontalAlign="Left" RepeatDirection="Vertical">
                            <SelectedItemStyle Wrap="False" HorizontalAlign="Left" BackColor="#999999"></SelectedItemStyle>
                            <SelectedItemTemplate>
                                <asp:Label ID="LblSelectedDeptName" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.Text") %>'
                                    CssClass="SkinObject">
                                </asp:Label>
                            </SelectedItemTemplate>
                            <ItemStyle Wrap="False" HorizontalAlign="Left"></ItemStyle>
                            <ItemTemplate>
                                <asp:LinkButton ID="linkDeptName" runat="server" CssClass="SkinObject" Text='<%# DataBinder.Eval(Container, "DataItem.Text") %>'
                                    CommandName="SearchDeptName" CommandArgument='<%# DataBinder.Eval(Container, "DataItem.value") %>'>
                                </asp:LinkButton>
                            </ItemTemplate>
                        </asp:DataList>
                    </td>
                </tr>
            </table>
        </td>
        <td colspan="3">
            <asp:DataGrid bodyHeight="500" ID="DataGrid1" runat="server" CssClass="Fix_GridStyle"
                Width="100%" AllowSorting="True" AutoGenerateColumns="False">
                <AlternatingItemStyle CssClass="GridAlterItem" Wrap="False"></AlternatingItemStyle>
                <ItemStyle CssClass="GridItem" Wrap="False"></ItemStyle>
                <HeaderStyle CssClass="GridHead" Wrap="False"></HeaderStyle>
                <Columns>
                    <asp:TemplateColumn>
                        <HeaderStyle Wrap="False" HorizontalAlign="Left" Width="50px"></HeaderStyle>
                        <HeaderTemplate>
                            <asp:CheckBox ID="CheckAll" runat="server" Text="全選"></asp:CheckBox>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <asp:CheckBox ID="chkDelete" runat="server"></asp:CheckBox>
                            <asp:Label ID="LblNO" runat="server" Text="<%# Container.ItemIndex+1+me.datagrid1.pagesize*me.datagrid1.CurrentPageIndex %>">
                            </asp:Label>
                            <asp:Label ID="lblResultPKID" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.ResultPKID") %>'
                                Visible="False">
                            </asp:Label>
                        </ItemTemplate>
                    </asp:TemplateColumn>
                    <asp:TemplateColumn HeaderText="事業群" SortExpression="AcceptGroup">
                        <HeaderStyle Wrap="False" Width="80px"></HeaderStyle>
                        <ItemTemplate>
                            <asp:Label ID="lblAcceptGroup" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.AcceptGroup") %>'>
                            </asp:Label>
                        </ItemTemplate>
                    </asp:TemplateColumn>
                    <asp:TemplateColumn HeaderText="事業處" SortExpression="AcceptDivision">
                        <HeaderStyle Wrap="False" Width="100px"></HeaderStyle>
                        <ItemTemplate>
                            <asp:Label ID="lblAcceptDivision" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.AcceptDivision") %>'>
                            </asp:Label>
                        </ItemTemplate>
                    </asp:TemplateColumn>
                    <asp:TemplateColumn HeaderText="受訪單位" SortExpression="AcceptDept">
                        <HeaderStyle Wrap="False" Width="150px"></HeaderStyle>
                        <ItemTemplate>
                            <asp:Label ID="lblAcceptDept" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.AcceptDept") %>'>
                            </asp:Label>
                        </ItemTemplate>
                    </asp:TemplateColumn>
                    <asp:TemplateColumn HeaderText="受訪人">
                        <HeaderStyle Wrap="False" Width="60px"></HeaderStyle>
                        <ItemTemplate>
                            <asp:Label ID="lblAcceptMan" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.AcceptMan") %>'>
                            </asp:Label>
                        </ItemTemplate>
                    </asp:TemplateColumn>
                    <asp:TemplateColumn HeaderText="受訪人分機">
                        <HeaderStyle Wrap="False" Width="100px"></HeaderStyle>
                        <ItemTemplate>
                            <asp:Label ID="lblAcceptExt" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.AcceptExt") %>'>
                            </asp:Label>
                        </ItemTemplate>
                    </asp:TemplateColumn>
                    <asp:TemplateColumn HeaderText="受訪人Email">
                        <ItemTemplate>
                            <asp:Label ID="lblAcceptEmail" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.AcceptEmail") %>'>
                            </asp:Label>
                        </ItemTemplate>
                    </asp:TemplateColumn>
                    <asp:TemplateColumn HeaderText="狀態" SortExpression="IsSubmited">
                        <HeaderStyle Wrap="False" Width="50px"></HeaderStyle>
                        <ItemTemplate>
                            <asp:Label ID="lblSendStatus" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.SendStatus") %>'>
                            </asp:Label>
                            <asp:Label ID="lblIsSubmited" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.IsSubmited") %>'
                                Visible="False">
                            </asp:Label>
                        </ItemTemplate>
                    </asp:TemplateColumn>
                    <asp:TemplateColumn HeaderText="刪除" HeaderStyle-Wrap="False">
                        <HeaderStyle Wrap="False" Width="30px"></HeaderStyle>
                        <ItemTemplate>
                            <asp:ImageButton Visible="False" ID="ImgDelete" runat="server" ImageUrl="../images/icon-delete.gif"
                                CommandName="Delete"></asp:ImageButton>
                        </ItemTemplate>
                    </asp:TemplateColumn>
                </Columns>
            </asp:DataGrid><cc1:PagerControl ID="PagerControl1" runat="server" Visible="False"
                CssClass="Pager" TotalPagesColor="Black" TotalCountsColor="Black" RecordsPerPage="100">
            </cc1:PagerControl>
        </td>
    </tr>
</table>
