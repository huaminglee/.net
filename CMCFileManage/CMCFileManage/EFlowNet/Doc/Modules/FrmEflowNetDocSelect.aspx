<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="FrmEflowNetDocSelect.aspx.vb"
    Inherits="eWorkFlow.eFlowDoc.FrmEflowNetDocSelect" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Src="~/EFlowNet/Doc/Modules/UcFileDetail.ascx" TagName="UcFileDetail" TagPrefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <base target="_self" />
    <title></title>
    <link id="css3" rel="stylesheet" type="text/css" runat="server" href="~/EFlowNet/Doc/CSS/GridViewLock.css" />
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
        <Scripts>
            <asp:ScriptReference Path="~/EFlowNet/Doc/JS/WinHelper.js" />
            <asp:ScriptReference Path="~/EFlowNet/Doc/JS/UIHelper.js" />
        </Scripts>
    </asp:ScriptManager>

    <table cellspacing="0" cellpadding="0" width="100%">
        <tr>
            <td nowrap colspan="2" align="right">
            </td>
            <td align="right" nowrap style="padding-right: 5px">
                <span>請輸入選擇項目</span>
                <asp:TextBox ID="txtSearch" runat="server" MaxLength="20" Width="80px"></asp:TextBox>
                <asp:LinkButton ID="btnSearch" runat="server">搜索</asp:LinkButton>&nbsp;
                <asp:LinkButton ID="BtnReturn" runat="server" ForeColor="Blue">選中返回</asp:LinkButton>&nbsp;
                <asp:LinkButton ID="btnReload" runat="server" ForeColor="Red">重置</asp:LinkButton>
            </td>
        </tr>
        <tr style="padding-bottom: 5px">
            <td valign="top" align="left" colspan="3">
                <cc1:TabContainer ID="TabContainer1" runat="server" ActiveTabIndex="1" Width="100%"
                    Height="200" ScrollBars="Auto">
                    <cc1:TabPanel runat="server" HeaderText="簽核意見" ID="TabPanel0">
                        <ContentTemplate>
                            <div id="divForFlowHistory" runat="server" style="width: 500px; height: 200px; overflow: auto">
                                <asp:GridView ID="GrdForFlowHistory" runat="server" AutoGenerateColumns="false" Width="100%">
                                    <Columns>
                                        <asp:TemplateField HeaderText="NO">
                                            <ItemTemplate>
                                                <asp:Label ID="LabNO" runat="server"></asp:Label>
                                                <asp:HiddenField ID="HidStateInstanceKeyID" runat="server" Value='<%# DataBinder.Eval(Container.DataItem, "(StateKeyID)") %>' />
                                                <asp:HiddenField ID="HidTransactPKID" runat="server" Value='<%# DataBinder.Eval(Container.DataItem, "(TransactPKID)") %>' />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="簽核人員">
                                            <ItemTemplate>
                                                <asp:Label ID="labPersonInfo" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "(TransactUserName)") %>'>
                                                </asp:Label>
                                                <asp:HiddenField ID="HidTransactUSerID" runat="server" Value='<%# DataBinder.Eval(Container.DataItem, "(TransactUserID)") %>' />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="執行動作">
                                            <ItemTemplate>
                                                <asp:Label ID="lblTransactOption" Width="80" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "(TransactOption)") %>'>
                                                </asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="辦理時間">
                                            <ItemTemplate>
                                                <asp:Label ID="Label3" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "(RecordCreateTime)", "{0:yyyy/MM/dd HH:mm}") %>'>
                                                </asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="簽核意見">
                                            <ItemTemplate>
                                                <asp:Label ID="labComment" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "(TransactResult)") %>'>
                                                </asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="附件">
                                            <ItemTemplate>
                                                <asp:ImageButton ID="ImgFile" ImageAlign="Middle" Visible="false" runat="server"
                                                    ToolTip="附件" ImageUrl="~/EFlowNet/Doc/Images/DownLoadFile.gif" />
                                                <asp:HiddenField ID="HidIsFile" runat="server" Value='<%# DataBinder.Eval(Container.DataItem, "(Extend1)") %>' />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                            </div>
                        </ContentTemplate>
                    </cc1:TabPanel>
                    <cc1:TabPanel runat="server" HeaderText="用戶清單" ID="TabPanel1">
                        <ContentTemplate>
                            <div id="divForHuman" runat="server" style="width: 500px; height: 200px; overflow: auto">
                                <asp:GridView ID="GrdForHuman" runat="server" AutoGenerateColumns="False" Width="100%">
                                    <Columns>
                                        <asp:TemplateField HeaderText="選擇">
                                            <ItemTemplate>
                                                <asp:CheckBox ID="CheckBox1" runat="server" />
                                                <asp:Label ID="LblNotes" runat="server" Visible="false" Text='<%# DataBinder.Eval(Container,"DataItem.Email1").ToString() %>'> </asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle Width="40px" Wrap="False" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="抄送">
                                            <ItemTemplate>
                                                <asp:CheckBox ID="CheckBox2" runat="server" /></ItemTemplate>
                                            <HeaderStyle Width="40px" Wrap="False" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="帳號" Visible="False">
                                            <ItemTemplate>
                                                <asp:Label ID="LblUserSID" runat="server" Visible="False" Text='<%# DataBinder.Eval(Container,"DataItem.UserSID").ToString() %>'></asp:Label>
                                                <asp:Label ID="LblAccountPKID" runat="server" Text='<%# DataBinder.Eval(Container,"DataItem.AccountPKID").ToString() %>'
                                                    Visible="False"></asp:Label>
                                                <asp:Label ID="LblOfficialPosition" runat="server" Text='<%# DataBinder.Eval(Container,"DataItem.OfficialPosition").ToString() %>'
                                                    Visible="False"></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle Width="80px" Wrap="False" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="用戶姓名">
                                            <ItemTemplate>
                                                <asp:Image ID="ImgLeader" runat="server" ImageUrl="~/Images/IconAccount.png" />
                                                <asp:Label ID="LblUserName" runat="server" Text='<%# DataBinder.Eval(Container,"DataItem.UserName").ToString() %>'></asp:Label></ItemTemplate>
                                            <HeaderStyle Width="80px" Wrap="False" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="部門">
                                            <ItemTemplate>
                                                <asp:Label ID="LblDeptName" runat="server"></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                    <HeaderStyle CssClass="tt" />
                                </asp:GridView>
                            </div>
                        </ContentTemplate>
                    </cc1:TabPanel>
                    <cc1:TabPanel ID="TabPanel2" runat="server" HeaderText="部門清單">
                        <ContentTemplate>
                            <div id="divForDept" runat="server" style="width: 500px; height: 200px; overflow: auto">
                                <asp:GridView ID="GrdForDept" runat="server" AutoGenerateColumns="False" Width="100%">
                                    <HeaderStyle CssClass="tt" />
                                    <Columns>
                                        <asp:TemplateField HeaderText="選擇">
                                            <ItemTemplate>
                                                <asp:CheckBox ID="CheckBox1" runat="server" /></ItemTemplate>
                                            <HeaderStyle Width="40px" Wrap="False" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="抄送">
                                            <ItemTemplate>
                                                <asp:CheckBox ID="CheckBox2" runat="server" /><asp:Label ID="LblDeptPKID" runat="server"
                                                    Text='<%# DataBinder.Eval(Container,"DataItem.DeptPKID").ToString() %>' Visible="False"></asp:Label></ItemTemplate>
                                            <HeaderStyle Width="40px" Wrap="False" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="部門名稱">
                                            <ItemTemplate>
                                                <asp:Label ID="LblDeptLevel" runat="server" Text='<%# DataBinder.Eval(Container,"DataItem.DeptLevel").ToString() %>'></asp:Label><asp:Label
                                                    ID="LblDeptName" runat="server" Text='<%# DataBinder.Eval(Container,"DataItem.DeptName").ToString() %>'></asp:Label></ItemTemplate>
                                            <HeaderStyle Wrap="True" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="所在分支">
                                            <ItemTemplate>
                                                <asp:Label ID="LblDeptLocation" runat="server" Text='<%# DataBinder.Eval(Container,"DataItem.DeptLocation").ToString() %>'></asp:Label></ItemTemplate>
                                            <HeaderStyle Width="80px" Wrap="False" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="所在位置">
                                            <ItemTemplate>
                                                <asp:Label ID="LblDeptArea" runat="server" Text='<%# DataBinder.Eval(Container,"DataItem.DeptArea").ToString() %>'></asp:Label></ItemTemplate>
                                            <HeaderStyle Width="80px" Wrap="False" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="費用代碼">
                                            <ItemTemplate>
                                                <asp:Label ID="LblDeptCostCode" runat="server" Text='<%# DataBinder.Eval(Container,"DataItem.DeptCostCode").ToString()%>'></asp:Label></ItemTemplate>
                                            <HeaderStyle Width="80px" Wrap="False" />
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                            </div>
                        </ContentTemplate>
                    </cc1:TabPanel>
                    <cc1:TabPanel ID="TabPanel3" runat="server" HeaderText="角色清單">
                        <ContentTemplate>
                            <div id="divForRole" runat="server" style="width: 500px; height: 200px; overflow: auto">
                                <asp:GridView ID="GrdForRoles" runat="server" AutoGenerateColumns="False" Width="100%">
                                    <HeaderStyle CssClass="tt" />
                                    <Columns>
                                        <asp:TemplateField HeaderText="選擇">
                                            <ItemTemplate>
                                                <asp:CheckBox ID="CheckBox1" runat="server" /></ItemTemplate>
                                            <HeaderStyle Width="40px" Wrap="False" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="抄送">
                                            <ItemTemplate>
                                                <asp:CheckBox ID="CheckBox2" runat="server" /><asp:Label ID="LblRolePKID" runat="server"
                                                    Text='<%# DataBinder.Eval(Container,"DataItem.RolePKID").ToString() %>' Visible="False"></asp:Label></ItemTemplate>
                                            <HeaderStyle Width="40px" Wrap="False" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="角色名稱">
                                            <ItemTemplate>
                                                <asp:Label ID="LblRoleName" runat="server" Text='<%# DataBinder.Eval(Container,"DataItem.RoleName").ToString() %>'></asp:Label></ItemTemplate>
                                            <HeaderStyle Width="100px" Wrap="False" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="角色類別">
                                            <ItemTemplate>
                                                <asp:Label ID="LblRoleCategory" runat="server" Text='<%# DataBinder.Eval(Container,"DataItem.RoleCategory").ToString() %>'></asp:Label></ItemTemplate>
                                            <HeaderStyle Width="100px" Wrap="False" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="角色描述">
                                            <ItemTemplate>
                                                <asp:Label ID="LblDescription" runat="server" Text='<%# DataBinder.Eval(Container,"DataItem.Description").ToString()%>'></asp:Label></ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                            </div>
                        </ContentTemplate>
                    </cc1:TabPanel>
                    <cc1:TabPanel ID="TabPanel4" runat="server" HeaderText="群組清單">
                        <ContentTemplate>
                            <div id="divForGroup" runat="server" style="width: 500px; height: 200px; overflow: auto">
                                <asp:GridView ID="GrdForGroup" runat="server" AutoGenerateColumns="False" Width="100%">
                                    <HeaderStyle CssClass="tt" />
                                    <Columns>
                                        <asp:TemplateField HeaderText="選擇">
                                            <ItemTemplate>
                                                <asp:CheckBox ID="CheckBox1" runat="server" /></ItemTemplate>
                                            <HeaderStyle Width="40px" Wrap="False" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="抄送">
                                            <ItemTemplate>
                                                <asp:CheckBox ID="CheckBox2" runat="server" /><asp:Label ID="LblGroupPKID" runat="server"
                                                    Text='<%# DataBinder.Eval(Container,"DataItem.GroupPKID").ToString() %>' Visible="False"></asp:Label></ItemTemplate>
                                            <HeaderStyle Width="40px" Wrap="False" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="作用域">
                                            <ItemTemplate>
                                                <asp:Label ID="LblScopePKID" runat="server" Text='<%# DataBinder.Eval(Container,"DataItem.ScopePKID").ToString() %>'></asp:Label></ItemTemplate>
                                            <HeaderStyle Width="100px" Wrap="False" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="群組名稱">
                                            <ItemTemplate>
                                                <asp:Label ID="LblGroupName" runat="server" Text='<%# DataBinder.Eval(Container,"DataItem.GroupName").ToString() %>'></asp:Label></ItemTemplate>
                                            <HeaderStyle Width="100px" Wrap="False" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="群組描述">
                                            <ItemTemplate>
                                                <asp:Label ID="LblDescription" runat="server" Text='<%# DataBinder.Eval(Container,"DataItem.Describution").ToString()%>'></asp:Label></ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                            </div>
                        </ContentTemplate>
                    </cc1:TabPanel>
                </cc1:TabContainer>
            </td>
        </tr>
        <tr>
            <td colspan="3">
                <table border="0" cellpadding="0" cellspacing="0" width="100%">
                    <tr id="TrForBack" runat="server">
                        <td width="80" nowrap align="left">
                            <span>駁回站別</span>
                        </td>
                        <td align="left" width="100%">
                            <asp:DropDownList ID="DDLRejectionStateNumber" runat="server" Width="250px" 
                                Font-Size="9pt">
                            </asp:DropDownList>
                            <asp:Button ID="BtnSelectStateOrder" runat="server" Text="選定步驟" />
                        </td>
                    </tr>
                    <tr id="TrDynamicDataManage" runat="server">
                        <td width="80" nowrap align="left">
                            <span>動態管理</span>
                        </td>
                        <td align="left" width="100%">
                            <asp:CheckBox ID="ChkDynamicManage" runat="server" AutoPostBack="True" Text="編輯清單數據" />
                        </td>
                    </tr>
                    <tr height="20">
                        <td width="80" nowrap align="left">
                            <span>輸入簽核意見</span>
                        </td>
                        <td align="left" width="100%">
                            <asp:TextBox ID="TxtAuditSuggest" Width="300px" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr id="TrForDigiSign" runat="server" height="20">
                        <td width="80" nowrap align="left">
                            <asp:Label ID="LblSelectSigner" runat="server" Text="選擇簽名檔" ForeColor="Blue" Style="cursor: pointer"></asp:Label>
                        </td>
                        <td align="left" width="100%">
                            <asp:TextBox ID="TxtESingerPublicKey" runat="server"></asp:TextBox>
                            <asp:Label ID="LblSignerEffect" runat="server" Visible="False"></asp:Label>
                        </td>
                    </tr>
                    <tr id="TrForUploadFile" runat="server">
                        <td width="80" nowrap align="left">
                            <span>上傳簽核附檔</span>
                        </td>
                        <td align="left" width="100%">
                            <uc1:UcFileDetail ID="UcFileDetail1" runat="server" CanDownLoad="false" CanEdit="false"
                                ParentCategory="1" ParentSubCategory="1" CanRemove="True" CanUpload="True" />
                        </td>
                    </tr>
                    <tr height="20">
                        <td align="left" colspan="2">
                            <span>同類型流程待簽核實例數為:</span>
                            <asp:Label ID="LblInstanceNum" runat="server" Text=""></asp:Label>
                        </td>
                    </tr>
                    <tr height="20">
                        <td colspan="2" align="left">
                            <asp:CheckBox ID="ChkContinueSigner" Enabled="false" runat="server" Text="是否連續簽核同类型流程" />
                        </td>
                    </tr>
                    <tr height="20">
                        <td colspan="2" align="left">
                            <asp:Button ID="BtnConfirm" runat="server" Text="確認" />&nbsp;
                            <asp:Button ID="BtnCancel" runat="server" Text="取消" />&nbsp;
                            <asp:Button ID="BtnError" runat="server" Text="報告錯誤" />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" align="left">
                            <asp:Label ID="LblError" ForeColor="Red" runat="server"></asp:Label>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>

    <div id="Foots" runat="server">
    </div>
    </form>
</body>
</html>
