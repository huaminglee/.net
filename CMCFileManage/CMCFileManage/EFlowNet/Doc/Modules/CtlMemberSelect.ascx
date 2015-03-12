<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="CtlMemberSelect.ascx.vb" Inherits="eWorkFlow.eFlowDoc.CtlMemberSelect" %>
<%@ Register Assembly="ComponentArt.Web.UI" Namespace="ComponentArt.Web.UI" TagPrefix="ComponentArt" %>
<table id="Table1" cellspacing="0" cellpadding="0" width="100%">
    <tr>
        <td valign="bottom" align="left">
            <ComponentArt:TabStrip ID="TabStrip1" CssClass="TopGroup" DefaultItemLookId="DefaultTabLook" DefaultSelectedItemLookId="SelectedTabLook" DefaultDisabledItemLookId="DisabledTabLook" DefaultGroupTabSpacing="1" ImagesBaseUrl="~/EFlowNet/Doc/Images/" MultiPageId="MultiPage1" runat="server" ScrollingEnabled="False">
                <ItemLooks>
                    <ComponentArt:ItemLook LookId="DefaultTabLook" CssClass="DefaultTab" HoverCssClass="DefaultTabHover" LabelPaddingLeft="10px" LabelPaddingRight="10px" LabelPaddingTop="5px" LabelPaddingBottom="4px" LeftIconUrl="tab_left_icon.gif" RightIconUrl="tab_right_icon.gif" HoverLeftIconUrl="hover_tab_left_icon.gif" HoverRightIconUrl="hover_tab_right_icon.gif" LeftIconWidth="3px" LeftIconHeight="21px" RightIconWidth="3px" RightIconHeight="21px" />
                    <ComponentArt:ItemLook LookId="SelectedTabLook" CssClass="SelectedTab" LabelPaddingLeft="10px" LabelPaddingRight="10px" LabelPaddingTop="4px" LabelPaddingBottom="4px" LeftIconUrl="selected_tab_left_icon.gif" RightIconUrl="selected_tab_right_icon.gif" LeftIconWidth="3px" LeftIconHeight="21px" RightIconWidth="3px" RightIconHeight="21px" />
                </ItemLooks>
                <Tabs>
                    <ComponentArt:TabStripTab ID="TabStripTab1" runat="server" DefaultSubGroupTabSpacing="1px" SubGroupTabSpacing="1px" Text="用戶清單">
                    </ComponentArt:TabStripTab>
                    <ComponentArt:TabStripTab ID="TabStripTab2" runat="server" DefaultSubGroupTabSpacing="1px" SubGroupTabSpacing="1px" Text="部門清單">
                    </ComponentArt:TabStripTab>
                    <ComponentArt:TabStripTab ID="TabStripTab3" runat="server" DefaultSubGroupTabSpacing="1px" SubGroupTabSpacing="1px" Text="角色清單">
                    </ComponentArt:TabStripTab>
                    <ComponentArt:TabStripTab ID="TabStripTab4" runat="server" DefaultSubGroupTabSpacing="1px" SubGroupTabSpacing="1px" Text="群組清單">
                    </ComponentArt:TabStripTab>
                    <ComponentArt:TabStripTab ID="TabStripTab5" runat="server" DefaultSubGroupTabSpacing="1px" SubGroupTabSpacing="1px" Text="人員主管">
                    </ComponentArt:TabStripTab>
                    <ComponentArt:TabStripTab ID="TabStripTab6" runat="server" DefaultSubGroupTabSpacing="1px" SubGroupTabSpacing="1px" Text="欄位內容">
                    </ComponentArt:TabStripTab>
                    <ComponentArt:TabStripTab ID="TabStripTab7" runat="server" DefaultSubGroupTabSpacing="1px" SubGroupTabSpacing="1px" Text="部門主管">
                    </ComponentArt:TabStripTab>
                    <ComponentArt:TabStripTab ID="TabStripTab8" runat="server" DefaultSubGroupTabSpacing="1px" SubGroupTabSpacing="1px" Text="欄位主管">
                    </ComponentArt:TabStripTab>
                </Tabs>
            </ComponentArt:TabStrip>
        </td>
        <td align="right">
            <asp:TextBox ID="txtSearch" runat="server" MaxLength="20"></asp:TextBox>
        </td>
        <td align="right" nowrap style="padding-right: 15px">
            <asp:LinkButton ID="btnSearch" runat="server" ForeColor="Red">搜索</asp:LinkButton>&nbsp;
            <asp:LinkButton ID="BtnSelected" runat="server" ForeColor="Blue">選中返回</asp:LinkButton>&nbsp;
            <asp:LinkButton ID="btnReload" runat="server">重置</asp:LinkButton>
        </td>
    </tr>
    <tr>
        <td colspan="3" align="left" width=100%>
            <ComponentArt:MultiPage ID="MultiPage1" CssClass="MultiPage" runat="server" Width="100%">
                <PageViews>
                    <ComponentArt:PageView ID="PageView1" runat="server" CssClass="PageContent">
                        <div id="divForHuman" runat="server" style="width: 450px; height: 350px; overflow: auto">
                            <asp:GridView ID="GrdForHuman" runat="server" AutoGenerateColumns="False" Width="100%" UseAccessibleHeader="true">
                                <HeaderStyle CssClass="tt" />
                                <Columns>
                                    <asp:TemplateField HeaderText="選擇">
                                        <ItemTemplate>
                                            <asp:CheckBox ID="CheckBox1" runat="server" />
                                        </ItemTemplate>
                                        <HeaderStyle Width="40px" Wrap="False" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="抄送">
                                        <ItemTemplate>
                                            <asp:CheckBox ID="CheckBox2" runat="server" />
                                        </ItemTemplate>
                                        <HeaderStyle Width="40px" Wrap="False" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="帳號">
                                        <ItemTemplate>
                                            <asp:Label ID="LblUserSID" runat="server" Text='<%# DataBinder.Eval(Container,"DataItem.UserSID").ToString() %>'></asp:Label>
                                            <asp:Label ID="LblAccountPKID" runat="server" Text='<%# DataBinder.Eval(Container,"DataItem.AccountPKID").ToString() %>' Visible="False"></asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle Width="80px" Wrap="False" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="用戶姓名">
                                        <ItemTemplate>
                                            <asp:Label ID="LblUserName" runat="server" Text='<%# DataBinder.Eval(Container,"DataItem.UserName").ToString() %>'></asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle Width="80px" Wrap="False" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Notes">
                                        <ItemTemplate>
                                            <asp:Label ID="LblNotes" runat="server" Text='<%# DataBinder.Eval(Container,"DataItem.Email1").ToString() %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                        </div>
                    </ComponentArt:PageView>
                    <ComponentArt:PageView ID="PageView2" runat="server" CssClass="PageContent">
                        <div id="divForDept" runat="server" style="width: 450px; height: 350px; overflow: auto">
                            <asp:GridView ID="GrdForDept" runat="server" AutoGenerateColumns="False" Width="100%">
                                <HeaderStyle CssClass="tt" />
                                <Columns>
                                    <asp:TemplateField HeaderText="選擇">
                                        <ItemTemplate>
                                            <asp:CheckBox ID="CheckBox1" runat="server" />
                                        </ItemTemplate>
                                        <HeaderStyle Width="40px" Wrap="False" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="抄送">
                                        <ItemTemplate>
                                            <asp:CheckBox ID="CheckBox2" runat="server" />
                                            <asp:Label ID="LblDeptPKID" runat="server" Text='<%# DataBinder.Eval(Container,"DataItem.DeptPKID").ToString() %>' Visible="False"></asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle Width="40px" Wrap="False" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="部門名稱">
                                        <ItemTemplate>
                                            <asp:Label ID="LblDeptLevel" runat="server" Text='<%# DataBinder.Eval(Container,"DataItem.DeptLevel").ToString() %>'></asp:Label>
                                            <asp:Label ID="LblDeptName" runat="server" Text='<%# DataBinder.Eval(Container,"DataItem.DeptName").ToString() %>'></asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle Wrap="True" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="所在分支">
                                        <ItemTemplate>
                                            <asp:Label ID="LblDeptLocation" runat="server" Text='<%# DataBinder.Eval(Container,"DataItem.DeptLocation").ToString() %>'></asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle Width="80px" Wrap="False" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="所在位置">
                                        <ItemTemplate>
                                            <asp:Label ID="LblDeptArea" runat="server" Text='<%# DataBinder.Eval(Container,"DataItem.DeptArea").ToString() %>'></asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle Width="80px" Wrap="False" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="費用代碼">
                                        <ItemTemplate>
                                            <asp:Label ID="LblDeptCostCode" runat="server" Text='<%# DataBinder.Eval(Container,"DataItem.DeptCostCode").ToString()%>'></asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle Width="80px" Wrap="False" />
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                        </div>
                    </ComponentArt:PageView>
                    <ComponentArt:PageView ID="PageView3" runat="server" CssClass="PageContent">
                        <div id="divForRole" runat="server" style="width: 450px; height: 330px; overflow: auto">
                            <asp:GridView ID="GrdForRoles" runat="server" AutoGenerateColumns="False" Width="100%">
                                <HeaderStyle CssClass="tt" />
                                <Columns>
                                    <asp:TemplateField HeaderText="選擇">
                                        <ItemTemplate>
                                            <asp:CheckBox ID="CheckBox1" runat="server" />
                                        </ItemTemplate>
                                        <HeaderStyle Width="40px" Wrap="False" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="抄送">
                                        <ItemTemplate>
                                            <asp:CheckBox ID="CheckBox2" runat="server" />
                                            <asp:Label ID="LblRolePKID" runat="server" Text='<%# DataBinder.Eval(Container,"DataItem.RolePKID").ToString() %>' Visible="False"></asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle Width="40px" Wrap="False" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="角色名稱">
                                        <ItemTemplate>
                                            <asp:Label ID="LblRoleName" runat="server" Text='<%# DataBinder.Eval(Container,"DataItem.RoleName").ToString() %>'></asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle Width="100px" Wrap="False" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="角色類別">
                                        <ItemTemplate>
                                            <asp:Label ID="LblRoleCategory" runat="server" Text='<%# DataBinder.Eval(Container,"DataItem.RoleCategory").ToString() %>'></asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle Width="100px" Wrap="False" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="角色描述">
                                        <ItemTemplate>
                                            <asp:Label ID="LblDescription" runat="server" Text='<%# DataBinder.Eval(Container,"DataItem.Description").ToString()%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                        </div>
                    </ComponentArt:PageView>
                    <ComponentArt:PageView ID="PageView4" runat="server" CssClass="PageContent">
                        <div id="divForGroup" runat="server" style="width: 450px; height: 350px; overflow: auto">
                            <asp:GridView ID="GrdForGroup" runat="server" AutoGenerateColumns="False" Width="100%">
                                <HeaderStyle CssClass="tt" />
                                <Columns>
                                    <asp:TemplateField HeaderText="選擇">
                                        <ItemTemplate>
                                            <asp:CheckBox ID="CheckBox1" runat="server" />
                                        </ItemTemplate>
                                        <HeaderStyle Width="40px" Wrap="False" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="抄送">
                                        <ItemTemplate>
                                            <asp:CheckBox ID="CheckBox2" runat="server" />
                                            <asp:Label ID="LblGroupPKID" runat="server" Text='<%# DataBinder.Eval(Container,"DataItem.GroupPKID").ToString() %>' Visible="False"></asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle Width="40px" Wrap="False" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="作用域">
                                        <ItemTemplate>
                                            <asp:Label ID="LblScopePKID" runat="server" Text='<%# DataBinder.Eval(Container,"DataItem.ScopePKID").ToString() %>'></asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle Width="100px" Wrap="False" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="群組名稱">
                                        <ItemTemplate>
                                            <asp:Label ID="LblGroupName" runat="server" Text='<%# DataBinder.Eval(Container,"DataItem.GroupName").ToString() %>'></asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle Width="100px" Wrap="False" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="群組描述">
                                        <ItemTemplate>
                                            <asp:Label ID="LblDescription" runat="server" Text='<%# DataBinder.Eval(Container,"DataItem.Describution").ToString()%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                        </div>
                    </ComponentArt:PageView>
                    <ComponentArt:PageView ID="PageView5" runat="server" CssClass="PageContent">
                        <div id="divForLeader" runat="server" style="width: 450px; height: 350px; overflow: auto">
                            <asp:GridView ID="GrdLeaderForHuman" runat="server" AutoGenerateColumns="False" Width="100%">
                                <HeaderStyle CssClass="tt" />
                                <Columns>
                                    <asp:TemplateField HeaderText="選擇">
                                        <ItemTemplate>
                                            <asp:CheckBox ID="CheckBox1" runat="server" />
                                        </ItemTemplate>
                                        <HeaderStyle Width="40px" Wrap="False" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="抄送">
                                        <ItemTemplate>
                                            <asp:CheckBox ID="CheckBox2" runat="server" />
                                        </ItemTemplate>
                                        <HeaderStyle Width="40px" Wrap="False" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="帳號">
                                        <ItemTemplate>
                                            <asp:Label ID="LblUserSID" runat="server" Text='<%# DataBinder.Eval(Container,"DataItem.UserSID").ToString() %>'></asp:Label>
                                            <asp:Label ID="LblAccountPKID" runat="server" Text='<%# DataBinder.Eval(Container,"DataItem.AccountPKID").ToString() %>' Visible="False"></asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle Width="80px" Wrap="False" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="用戶姓名">
                                        <ItemTemplate>
                                            <asp:Label ID="LblUserName" runat="server" Text='<%# DataBinder.Eval(Container,"DataItem.UserName").ToString() %>'></asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle Width="80px" Wrap="False" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Notes">
                                        <ItemTemplate>
                                            <asp:Label ID="LblNotes" runat="server" Text='<%# DataBinder.Eval(Container,"DataItem.Email1").ToString() %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                        </div>
                    </ComponentArt:PageView>
                    <ComponentArt:PageView ID="PageView6" runat="server" CssClass="PageContent">
                        <div id="DivForColumnContent" runat="server" style="width: 450px; height: 350px; overflow: auto">
                            <asp:GridView ID="GridViewForColumnContent" runat="server" AutoGenerateColumns="False" Width="100%">
                                <HeaderStyle CssClass="tt"></HeaderStyle>
                                <Columns>
                                    <asp:TemplateField HeaderText="選擇">
                                        <ItemTemplate>
                                            <asp:CheckBox ID="CheckBox1" runat="server" />
                                        </ItemTemplate>
                                        <HeaderStyle Width="40px" Wrap="False" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="抄送">
                                        <ItemTemplate>
                                            <asp:CheckBox ID="CheckBox2" runat="server" />
                                            <asp:Label ID="LblResourceKeyID" runat="server" Text='<%# DataBinder.Eval(Container,"DataItem.ResourceKeyID").ToString() %>' Visible="False"></asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle Width="40px" Wrap="False" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="欄位ID">
                                        <ItemTemplate>
                                            <asp:Label ID="LblResourceCode" runat="server" Text='<%# DataBinder.Eval(Container,"DataItem.ResourceCode").ToString() %>'></asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle Wrap="True" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="欄位名稱">
                                        <ItemTemplate>
                                            <asp:Label ID="LblResourceName" runat="server" Text='<%# DataBinder.Eval(Container,"DataItem.ResourceName").ToString() %>'></asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle Width="80px" Wrap="False" />
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                        </div>
                    </ComponentArt:PageView>
                    <ComponentArt:PageView ID="PageView7" runat="server" CssClass="PageContent">
                        <div id="divForDeptLeader" runat="server" style="width: 450px; height: 350px; overflow: auto">
                            <asp:GridView ID="GridViewForDeptLeader" runat="server" AutoGenerateColumns="False" Width="100%">
                                <HeaderStyle CssClass="tt" />
                                <Columns>
                                    <asp:TemplateField HeaderText="選擇">
                                        <ItemTemplate>
                                            <asp:CheckBox ID="CheckBox1" runat="server" />
                                        </ItemTemplate>
                                        <HeaderStyle Width="40px" Wrap="False" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="抄送">
                                        <ItemTemplate>
                                            <asp:CheckBox ID="CheckBox2" runat="server" />
                                            <asp:Label ID="LblDeptPKID" runat="server" Text='<%# DataBinder.Eval(Container,"DataItem.DeptPKID").ToString() %>' Visible="False"></asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle Width="40px" Wrap="False" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="部門名稱">
                                        <ItemTemplate>
                                            <asp:Label ID="LblDeptLevel" runat="server" Text='<%# DataBinder.Eval(Container,"DataItem.DeptLevel").ToString() %>'></asp:Label>
                                            <asp:Label ID="LblDeptName" runat="server" Text='<%# DataBinder.Eval(Container,"DataItem.DeptName").ToString() %>'></asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle Wrap="True" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="所在分支">
                                        <ItemTemplate>
                                            <asp:Label ID="LblDeptLocation" runat="server" Text='<%# DataBinder.Eval(Container,"DataItem.DeptLocation").ToString() %>'></asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle Width="80px" Wrap="False" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="所在位置">
                                        <ItemTemplate>
                                            <asp:Label ID="LblDeptArea" runat="server" Text='<%# DataBinder.Eval(Container,"DataItem.DeptArea").ToString() %>'></asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle Width="80px" Wrap="False" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="費用代碼">
                                        <ItemTemplate>
                                            <asp:Label ID="LblDeptCostCode" runat="server" Text='<%# DataBinder.Eval(Container,"DataItem.DeptCostCode").ToString()%>'></asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle Width="80px" Wrap="False" />
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                        </div>
                    </ComponentArt:PageView>
                    <ComponentArt:PageView ID="PageView8" runat="server" CssClass="PageContent">
                        <div id="DivForColumnContentLeader" runat="server" style="width: 450px; height: 350px; overflow: auto">
                            <asp:GridView ID="GridViewForColumnContentLeader" runat="server" AutoGenerateColumns="False" Width="100%">
                                <HeaderStyle CssClass="tt"></HeaderStyle>
                                <Columns>
                                    <asp:TemplateField HeaderText="選擇">
                                        <ItemTemplate>
                                            <asp:CheckBox ID="CheckBox1" runat="server" />
                                        </ItemTemplate>
                                        <HeaderStyle Width="40px" Wrap="False" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="抄送">
                                        <ItemTemplate>
                                            <asp:CheckBox ID="CheckBox2" runat="server" />
                                            <asp:Label ID="LblResourceKeyID" runat="server" Text='<%# DataBinder.Eval(Container,"DataItem.ResourceKeyID").ToString() %>' Visible="False"></asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle Width="40px" Wrap="False" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="欄位ID">
                                        <ItemTemplate>
                                            <asp:Label ID="LblResourceCode" runat="server" Text='<%# DataBinder.Eval(Container,"DataItem.ResourceCode").ToString() %>'></asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle Wrap="True" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="欄位名稱">
                                        <ItemTemplate>
                                            <asp:Label ID="LblResourceName" runat="server" Text='<%# DataBinder.Eval(Container,"DataItem.ResourceName").ToString() %>'></asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle Width="80px" Wrap="False" />
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                        </div>
                    </ComponentArt:PageView>
                </PageViews>
            </ComponentArt:MultiPage>
        </td>
    </tr>
    <tr>
        <td colspan="3" align="center" style="padding: 8px">
            <asp:Button ID="BtnConfirm" runat="server" Text="確定" />&nbsp;<asp:Button ID="BtnClose" runat="server" Text="關閉" />
        </td>
    </tr>
</table>

