<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="CtlGMPCSIItemReports.ascx.vb"
    Inherits="CMCFileManage.CtlGMPCSIItemReports" TargetSchema="http://schemas.microsoft.com/intellisense/ie5" %>
<table id="TableTitle" class="TableTitle" width="100%">
    <tr align="center">
        <td class="PageHead" nowrap align="center">
            檢測塑應中心滿意度調查結果分析
        </td>
    </tr>
</table>
<table id="Table1" cellspacing="0" cellpadding="0" width="100%" border="0">
    <tbody>
        <tr>
            <td class="TdTitle" nowrap colspan="3" height="30">
                1.各BG對檢測塑應中心的滿意度統計：
            </td>
        </tr>
        <tr>
            <td nowrap colspan="3">
                <asp:DataList ID="Datalist1" runat="server" HorizontalAlign="Left" RepeatColumns="11"
                    RepeatDirection="Horizontal">
                    <SelectedItemStyle Wrap="False" HorizontalAlign="Center" BackColor="#FFFFC0"></SelectedItemStyle>
                    <SelectedItemTemplate>
                        <asp:Label ID="lblPeriodName" Width="55px" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.Text") %>'
                            CssClass="SkinObject">
                        </asp:Label>
                    </SelectedItemTemplate>
                    <ItemStyle Wrap="False" HorizontalAlign="Center"></ItemStyle>
                    <ItemTemplate>
                        <asp:LinkButton ID="LinkPeriod" Width="55px" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.Text") %>'
                            CommandName="SearchPeriod" CssClass="SkinObject" CommandArgument='<%# DataBinder.Eval(Container, "DataItem.Value") %>'>
                        </asp:LinkButton>
                    </ItemTemplate>
                </asp:DataList>
                <div style="float: right">
                    <asp:Image ID="ImgXls" runat="server" ImageUrl="../Images/xls.gif"></asp:Image><asp:LinkButton
                        ID="LinkReport" runat="server" CssClass="ContentText">報表</asp:LinkButton></div>
            </td>
        </tr>
        <tr>
            <td nowrap colspan="3">
                <asp:DataGrid ID="Datagrid1" runat="server" AllowSorting="True" AutoGenerateColumns="False"
                    Width="100%">
                    <AlternatingItemStyle CssClass="GridAlterItem" />
                    <ItemStyle CssClass="GridItem" />
                    <HeaderStyle CssClass="GridHead" />
                    <Columns>
                        <asp:TemplateColumn HeaderText="序號" FooterText="No">
                            <HeaderStyle Wrap="False" HorizontalAlign="Left" Width="50px"></HeaderStyle>
                            <ItemTemplate>
                                <asp:Label ID="lblNo1" runat="server" Text="<%# Container.ItemIndex+1 %>">
                                </asp:Label>
                            </ItemTemplate>
                        </asp:TemplateColumn>
                        <asp:TemplateColumn HeaderText="BG">
                            <ItemTemplate>
                                <asp:Label ID="lblGroup" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.SubmitGroup") %>'>
                                </asp:Label>
                            </ItemTemplate>
                        </asp:TemplateColumn>
                        <asp:TemplateColumn HeaderText="很滿意">
                            <ItemTemplate>
                                <asp:Label ID="lblVeryGood1" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.VeryGood") %>'>
                                </asp:Label>
                            </ItemTemplate>
                        </asp:TemplateColumn>
                        <asp:TemplateColumn HeaderText="滿意">
                            <ItemTemplate>
                                <asp:Label ID="lblGood1" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.Good") %>'>
                                </asp:Label>
                            </ItemTemplate>
                        </asp:TemplateColumn>
                        <asp:TemplateColumn HeaderText="不滿意">
                            <ItemTemplate>
                                <asp:Label ID="lblBad1" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.bad") %>'>
                                </asp:Label>
                            </ItemTemplate>
                        </asp:TemplateColumn>
                        <asp:TemplateColumn HeaderText="很不滿意">
                            <ItemTemplate>
                                <asp:Label ID="lblVerybad1" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.Verybad") %>'>
                                </asp:Label>
                            </ItemTemplate>
                        </asp:TemplateColumn>
                        <asp:TemplateColumn HeaderText="總計">
                            <ItemTemplate>
                                <asp:Label ID="lblSumVote1" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.SumVote") %>'>
                                </asp:Label>
                            </ItemTemplate>
                        </asp:TemplateColumn>
                        <asp:TemplateColumn HeaderText="折合總分">
                            <ItemTemplate>
                                <asp:Label ID="lblZHSumVote1" runat="server"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateColumn>
                        <asp:TemplateColumn HeaderText="平均給分">
                            <ItemTemplate>
                                <asp:Label ID="lblAverageSum1" runat="server"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateColumn>
                        <asp:TemplateColumn HeaderText="滿意度">
                            <ItemTemplate>
                                <asp:Label ID="lblSatisfaction1" runat="server"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateColumn>
                    </Columns>
                </asp:DataGrid>
            </td>
        </tr>
        <tr>
            <td nowrap colspan="3" height="30" class="SubTitleText">
                a. BG對檢測塑應中心的不滿意主要體現在哪些調查項目?
            </td>
        </tr>
        <tr>
            <td nowrap colspan="3">
                <asp:DataGrid ID="Datagrid4" runat="server" AllowSorting="True" AutoGenerateColumns="False"
                    Width="100%">
                    <AlternatingItemStyle CssClass="GridAlterItem" />
                    <ItemStyle CssClass="GridItem" />
                    <HeaderStyle CssClass="GridHead" />
                    <Columns>
                        <asp:TemplateColumn HeaderText="序號" FooterText="No">
                            <HeaderStyle Wrap="False" HorizontalAlign="Left" Width="50px"></HeaderStyle>
                            <ItemTemplate>
                                <asp:Label ID="Label1" runat="server" Text="<%# Container.ItemIndex+1 %>">
                                </asp:Label>
                            </ItemTemplate>
                        </asp:TemplateColumn>
                        <asp:TemplateColumn HeaderText="Commodity" FooterText="No">
                            <HeaderStyle Wrap="False" HorizontalAlign="Left"></HeaderStyle>
                            <ItemTemplate>
                                <asp:Label ID="lblReportDept" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.DeptName") %>'>
                                </asp:Label>
                            </ItemTemplate>
                        </asp:TemplateColumn>
                        <asp:TemplateColumn HeaderText="調查項目" FooterText="No">
                            <HeaderStyle Wrap="False" HorizontalAlign="Left"></HeaderStyle>
                            <ItemTemplate>
                                <asp:Label ID="Label2" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.ItemName") %>'>
                                </asp:Label>
                            </ItemTemplate>
                        </asp:TemplateColumn>
                        <asp:TemplateColumn HeaderText="投票次數" FooterText="No">
                            <HeaderStyle Wrap="False" HorizontalAlign="Left"></HeaderStyle>
                            <ItemTemplate>
                                <asp:Label ID="Label4" runat="server"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateColumn>
                        <asp:TemplateColumn HeaderText="不滿意原因" FooterText="No">
                            <HeaderStyle Wrap="False" HorizontalAlign="Left"></HeaderStyle>
                            <ItemTemplate>
                                <asp:Label ID="LblSumNGReason" runat="server"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateColumn>
                    </Columns>
                </asp:DataGrid>
            </td>
        </tr>
        <tr>
            <td class="TdTitle" nowrap colspan="3" height="30">
                2.檢測塑應中心各實驗室滿意度統計:
                <div style="float: right">
                    <asp:Image ID="Image1" runat="server" ImageUrl="../Images/xls.gif"></asp:Image><asp:LinkButton
                        ID="Linkbutton1" runat="server" CssClass="ContentText">報表</asp:LinkButton></div>
            </td>
        </tr>
        <tr>
            <td nowrap colspan="3">
                <asp:DataGrid ID="Datagrid2" runat="server" AllowSorting="True" AutoGenerateColumns="False"
                    Width="100%">
                    <AlternatingItemStyle CssClass="GridAlterItem" />
                    <ItemStyle CssClass="GridItem" />
                    <HeaderStyle CssClass="GridHead" />
                    <Columns>
                        <asp:TemplateColumn HeaderText="序號" FooterText="No">
                            <HeaderStyle Wrap="False" HorizontalAlign="Left" Width="50px"></HeaderStyle>
                            <ItemTemplate>
                                <asp:Label ID="Label3" runat="server" Text="<%# Container.ItemIndex+1 %>">
                                </asp:Label>
                            </ItemTemplate>
                        </asp:TemplateColumn>
                        <asp:TemplateColumn HeaderText="Commodity">
                            <ItemTemplate>
                                <asp:Label ID="lblCommodity" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.DeptName") %>'>
                                </asp:Label>
                            </ItemTemplate>
                        </asp:TemplateColumn>
                        <asp:TemplateColumn HeaderText="很滿意">
                            <ItemTemplate>
                                <asp:Label ID="LblVeryGood2" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.VeryGood") %>'>
                                </asp:Label>
                            </ItemTemplate>
                        </asp:TemplateColumn>
                        <asp:TemplateColumn HeaderText="滿意">
                            <ItemTemplate>
                                <asp:Label ID="lblGood2" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.Good") %>'>
                                </asp:Label>
                            </ItemTemplate>
                        </asp:TemplateColumn>
                        <asp:TemplateColumn HeaderText="不滿意">
                            <ItemTemplate>
                                <asp:Label ID="lblBad2" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.Bad") %>'>
                                </asp:Label>
                            </ItemTemplate>
                        </asp:TemplateColumn>
                        <asp:TemplateColumn HeaderText="很不滿意">
                            <ItemTemplate>
                                <asp:Label ID="lblVeryBad2" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.VeryBad") %>'>
                                </asp:Label>
                            </ItemTemplate>
                        </asp:TemplateColumn>
                        <asp:TemplateColumn HeaderText="總計">
                            <ItemTemplate>
                                <asp:Label ID="lblSumVote2" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.SumVote") %>'>
                                </asp:Label>
                            </ItemTemplate>
                        </asp:TemplateColumn>
                        <asp:TemplateColumn HeaderText="折合總分">
                            <ItemTemplate>
                                <asp:Label ID="lblZHSumVote2" runat="server"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateColumn>
                        <asp:TemplateColumn HeaderText="平均給分">
                            <ItemTemplate>
                                <asp:Label ID="lblAverageSum2" runat="server"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateColumn>
                        <asp:TemplateColumn HeaderText="滿意度">
                            <ItemTemplate>
                                <asp:Label ID="lblSatisfaction2" runat="server"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateColumn>
                    </Columns>
                </asp:DataGrid>
            </td>
        </tr>
        <tr class="TrStyle">
            <td>
            </td>
        </tr>
        <tr>
            <td class="TdTitle" nowrap colspan="3" height="30">
                3.各實驗室調查內容匯總表:
                <div style="float: right">
                    <asp:Image ID="Image2" runat="server" ImageUrl="../Images/xls.gif"></asp:Image><asp:LinkButton
                        ID="Linkbutton2" runat="server" CssClass="ContentText">報表</asp:LinkButton></div>
            </td>
        </tr>
        <tr>
            <td valign="top" width="150px">
                <table width="150px" align="left">
                    <!--Header Part2-->
                    <tr>
                        <td bgcolor="#339933" style="color: #FFFFFF">
                            請選擇部門
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:DataList ID="Datalist2" runat="server" HorizontalAlign="Left" RepeatDirection="Vertical">
                                <SelectedItemStyle Wrap="False" HorizontalAlign="Left" BackColor="#999999"></SelectedItemStyle>
                                <SelectedItemTemplate>
                                    <asp:Label ID="LblSelectedDeptName" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.Text") %>'
                                        CssClass="SkinObject">
                                    </asp:Label>
                                </SelectedItemTemplate>
                                <ItemStyle Wrap="False" HorizontalAlign="Left"></ItemStyle>
                                <ItemTemplate>
                                    <asp:LinkButton ID="linkDeptName" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.Text") %>'
                                        CommandName="SearchDeptName" CommandArgument='<%# DataBinder.Eval(Container, "DataItem.Value") %>'
                                        CssClass="SkinObject">
                                    </asp:LinkButton>
                                </ItemTemplate>
                            </asp:DataList>
                        </td>
                    </tr>
                </table>
            </td>
            <td valign="top" width="100%" colspan="2">
                <table height="100%" width="100%">
                    <tbody>
                        <tr>
                            <td valign="top">
                                <asp:DataGrid ID="DataGrid3" runat="server" AllowSorting="True" AutoGenerateColumns="False"
                                    Width="100%">
                                    <AlternatingItemStyle CssClass="GridAlterItem" />
                                    <ItemStyle CssClass="GridItem" />
                                    <HeaderStyle CssClass="GridHead" />
                                    <Columns>
                                        <asp:TemplateColumn HeaderText="序號" FooterText="No">
                                            <HeaderStyle Wrap="False" HorizontalAlign="Left" Width="50px"></HeaderStyle>
                                            <ItemTemplate>
                                                <asp:Label ID="lblNo3" runat="server" Text="<%# Container.ItemIndex+1 %>">
                                                </asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateColumn>
                                        <asp:TemplateColumn HeaderText="調查項目">
                                            <ItemTemplate>
                                                <asp:Label ID="lblItemName" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.ItemName") %>'>
                                                </asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateColumn>
                                        <asp:TemplateColumn HeaderText="很滿意">
                                            <ItemTemplate>
                                                <asp:Label ID="lblVeryGood3" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.VeryGood") %>'>
                                                </asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateColumn>
                                        <asp:TemplateColumn HeaderText="滿意">
                                            <ItemTemplate>
                                                <asp:Label ID="lblGood3" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.Good") %>'>
                                                </asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateColumn>
                                        <asp:TemplateColumn HeaderText="不滿意">
                                            <ItemTemplate>
                                                <asp:Label ID="lblBad3" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.Bad") %>'>
                                                </asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateColumn>
                                        <asp:TemplateColumn HeaderText="很不滿意">
                                            <ItemTemplate>
                                                <asp:Label ID="lblVeryBad3" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.VeryBad") %>'>
                                                </asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateColumn>
                                    </Columns>
                                </asp:DataGrid>
                            </td>
                        </tr>
                        <tr>
                            <td nowrap height="30" class="SubTitleText">
                                <asp:Label runat="server" ID="LblDeptNgTitle"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td nowrap>
                                <asp:DataGrid ID="Datagrid5" runat="server" AllowSorting="True" AutoGenerateColumns="False"
                                    Width="100%">
                                    <AlternatingItemStyle CssClass="GridAlterItem" />
                                    <ItemStyle CssClass="GridItem" />
                                    <HeaderStyle CssClass="GridHead" />
                                    <Columns>
                                        <asp:TemplateColumn HeaderText="序號" FooterText="No">
                                            <HeaderStyle Wrap="False" HorizontalAlign="Left" Width="50px"></HeaderStyle>
                                            <ItemTemplate>
                                                <asp:Label ID="Label5" runat="server" Text="<%# Container.ItemIndex+1 %>">
                                                </asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateColumn>
                                        <asp:TemplateColumn HeaderText="調查項目" FooterText="No">
                                            <HeaderStyle Wrap="False" HorizontalAlign="Left"></HeaderStyle>
                                            <ItemTemplate>
                                                <asp:Label ID="Label6" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.ItemName") %>'>
                                                </asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateColumn>
                                        <asp:TemplateColumn HeaderText="投票次數" FooterText="No">
                                            <HeaderStyle Wrap="False" HorizontalAlign="Left"></HeaderStyle>
                                            <ItemTemplate>
                                                <asp:Label ID="Label7" runat="server"></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateColumn>
                                        <asp:TemplateColumn HeaderText="不滿意原因" FooterText="No">
                                            <HeaderStyle Wrap="False" HorizontalAlign="Left"></HeaderStyle>
                                            <ItemTemplate>
                                                <asp:Label ID="Label8" runat="server"></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateColumn>
                                    </Columns>
                                </asp:DataGrid>
                            </td>
                        </tr>
                    </tbody>
                </table>
            </td>
        </tr>
    </tbody>
</table>
