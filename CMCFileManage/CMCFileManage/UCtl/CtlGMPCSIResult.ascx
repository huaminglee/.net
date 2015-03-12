<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="CtlGMPCSIResult.ascx.vb"
    Inherits="CMCFileManage.CtlGMPCSIResult" TargetSchema="http://schemas.microsoft.com/intellisense/ie5" %>
<%@ Register TagPrefix="cc1" Namespace="myControl" Assembly="myControl" %>
<table id="TableTitle" width="100%">
    <tr align="center">
        <td class="PageHead" nowrap align="center">
            機構采購檢查中心客戶滿意度調查清單
        </td>
    </tr>
</table>
<table id="Table1" cellspacing="0" cellpadding="0" width="100%" border="0">
    <tr>
        <td nowrap align="right">
            <asp:Label ID="Label1" CssClass="CSIRed" runat="server">調查批次：</asp:Label>
        </td>
        <td nowrap colspan="2">
            <asp:DataList ID="Datalist1" RepeatDirection="Horizontal" RepeatColumns="11" HorizontalAlign="Left"
                runat="server">
                <SelectedItemStyle Wrap="False" HorizontalAlign="Center" BackColor="#FFFFC0"></SelectedItemStyle>
                <SelectedItemTemplate>
                    <asp:Label ID="lblPeriodName" Width="55px" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.Text") %>'
                        CssClass="SkinObject">
                    </asp:Label>
                </SelectedItemTemplate>
                <ItemStyle Wrap="False" HorizontalAlign="Center"></ItemStyle>
                <ItemTemplate>
                    <asp:LinkButton ID="LinkPeriod" Width="55px" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.Text") %>'
                        CssClass="SkinObject" CommandName="SearchPeriod" CommandArgument='<%# DataBinder.Eval(Container, "DataItem.Value") %>'>
                    </asp:LinkButton>
                </ItemTemplate>
            </asp:DataList>
        </td>
    </tr>
    <tr>
        <td valign="top" nowrap width="150">
            <table width="150" align="center">
                <!--Header Part2-->
                <tr>
                    <td class="containerrow1_gray" style="background-color: #339933; color: #FFFFFF;
                        font-weight: bold">
                        請選擇部門
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:DataList ID="Datalist2" RepeatDirection="Vertical" HorizontalAlign="Left" runat="server"
                            Width="100%">
                            <ItemStyle Wrap="False" HorizontalAlign="Left"></ItemStyle>
                            <SelectedItemStyle BackColor="#999999" HorizontalAlign="Left" Wrap="True" />
                            <SelectedItemTemplate>
                                <asp:Label ID="LblSelectedDeptName" runat="server" CssClass="SkinObject" Text='<%# DataBinder.Eval(Container, "DataItem.Text") %>'>
                                </asp:Label>
                            </SelectedItemTemplate>
                            <ItemTemplate>
                                <asp:LinkButton ID="linkDeptName" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.Text") %>'
                                    CommandName="SearchDeptName" CommandArgument='<%# DataBinder.Eval(Container, "DataItem.Value") %>'
                                    CssClass="SkinObject">
                                </asp:LinkButton>
                                <br />
                            </ItemTemplate>
                        </asp:DataList>
                    </td>
                </tr>
            </table>
        </td>
        <td width="100%" colspan="2">
            <table border="1" cellspacing="0" cellpadding="0" bordercolor="#000000" bordercolordark="#FFFFFF"
                cellspacing="0" cellpadding="5" width="100%" align="center" style="height: 100%">
                <tr>
                    <td>
                        <table class="SkinObject" cellspacing="0" cellpadding="0"  border="0">
                            <tr>
                                <td  align="right">
                                    事業群
                                </td>
                                <td >
                                    <asp:TextBox ID="txtGroup" CssClass="NormalTextBox" runat="server" Width="150px"></asp:TextBox>
                                </td>
                                <td  align="right" >
                                    事業處
                                </td>
                                <td>
                                    <asp:TextBox ID="txtDivision" CssClass="NormalTextBox" runat="server" Width="150px"></asp:TextBox>
                                </td>
                                <td >
                                    受訪單位</td>
                                <td >
                                    <asp:TextBox ID="txtAcceptDept" CssClass="NormalTextBox" runat="server" Width="150px"></asp:TextBox>
                                </td>
                                <td >
                                    <asp:ImageButton ID="btnSearch" runat="server" ToolTip="搜索" ImageUrl="../images/view.gif">
                                    </asp:ImageButton>
                                    <asp:ImageButton ID="btnReview" runat="server" ToolTip="重置" 
                                        ImageUrl="../images/refresh.gif" Height="16px" Width="16px">
                                    </asp:ImageButton>
                                    <asp:ImageButton ID="btnExportExcel" runat="server" ToolTip="客戶滿意度清單" ImageUrl="../images/xls.gif"
                                        AlternateText="客戶滿意度報表"></asp:ImageButton>
                                </td>
                            </tr>
                            <tr height="10">
                                <td nowrap colspan="4">
                                    <asp:Label ID="lblSearchResult" CssClass="CSIRed" runat="server" BackColor="#FFFFC0"
                                        ForeColor="Maroon"></asp:Label>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:DataGrid ID="DataGrid1" CssClass="Fix_GridStyle" runat="server" Width="100%"
                            AllowSorting="True" AutoGenerateColumns="False" bodyHeight="630">
                           <AlternatingItemStyle CssClass="GridAlterItem" />
                            <ItemStyle CssClass="GridItem" />
                             <HeaderStyle CssClass="GridHead" />
                           
                            <Columns>
                                <asp:TemplateColumn HeaderText="序號">
                                    <HeaderStyle Wrap="False" HorizontalAlign="Left" Width ="30px" ></HeaderStyle>
                                    <ItemTemplate>
                                        <asp:Label ID="LblNO" runat="server" Text="<%# Container.ItemIndex+1+me.datagrid1.pagesize*me.datagrid1.CurrentPageIndex %>">
                                        </asp:Label>
                                        <asp:Label ID="lblResultPKID" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.ResultPKID") %>'
                                            Visible="False">
                                        </asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateColumn>
                                <asp:TemplateColumn HeaderText="詳細" HeaderStyle-Wrap="False">
                                    <HeaderStyle Wrap="False" Width ="30px" ></HeaderStyle>
                                    <ItemTemplate>
                                        <asp:HyperLink ID="EditLink" runat="server" ImageUrl="../images/edit.gif" ToolTip="點擊進入"></asp:HyperLink>
                                    </ItemTemplate>
                                </asp:TemplateColumn>
                                <asp:TemplateColumn HeaderText="事業群">
                                    <HeaderStyle Wrap="False" ></HeaderStyle>
                                    <ItemTemplate>
                                        <asp:Label ID="lblAcceptGroup" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.SubmitGroup") %>'>
                                        </asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateColumn>
                                <asp:TemplateColumn HeaderText="事業處">
                                    <HeaderStyle Wrap="False" ></HeaderStyle>
                                    <ItemTemplate>
                                        <asp:Label ID="lblAcceptDivision" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.SubmitDivision") %>'>
                                        </asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateColumn>
                                <asp:TemplateColumn HeaderText="受訪單位">
                                    <HeaderStyle Wrap="False" ></HeaderStyle>
                                    <ItemTemplate>
                                        <asp:Label ID="lblAcceptDept" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.SubmitDept") %>'>
                                        </asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateColumn>
                                <asp:TemplateColumn HeaderText="受訪人">
                                    <HeaderStyle Wrap="False" ></HeaderStyle>
                                    <ItemTemplate>
                                        <asp:Label ID="lblAcceptMan" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.SubmitMan") %>'>
                                        </asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateColumn>
                                <asp:TemplateColumn HeaderText="受訪人分機">
                                    <HeaderStyle Wrap="False" ></HeaderStyle>
                                    <ItemTemplate>
                                        <asp:Label ID="lblAcceptExt" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.SubmitExt") %>'>
                                        </asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateColumn>
                                <asp:TemplateColumn HeaderText="受訪人Email">
                                    <ItemTemplate>
                                        <asp:Label ID="lblAcceptEmail" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.SubmitEmail") %>'>
                                        </asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateColumn>
                                <asp:TemplateColumn HeaderText="發送時間">
                                    <HeaderStyle Wrap="False" ></HeaderStyle>
                                    <ItemTemplate>
                                        <asp:Label ID="lblSendTimel" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.SendTime","{0:yyyy-MM-dd}") %>'>
                                        </asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateColumn>
                                <asp:TemplateColumn HeaderText="提交時間">
                                    <HeaderStyle Wrap="False" ></HeaderStyle>
                                    <ItemTemplate>
                                        <asp:Label ID="lblSubmitTime" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.SubmitTime","{0:yyyy-MM-dd}") %>'>
                                        </asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateColumn>
                            </Columns>
                        </asp:DataGrid><cc1:PagerControl ID="PagerControl1" CssClass="Pager" runat="server"
                            TotalPagesColor="Black" TotalCountsColor="Black" RecordsPerPage="100" Visible="False">
                        </cc1:PagerControl>
                    </td>
                </tr>
            </table>
        </td>
    </tr>
</table>
