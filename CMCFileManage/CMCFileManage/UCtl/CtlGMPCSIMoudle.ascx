<%@ Control Language="vb" AutoEventWireup="false"  CodeBehind="CtlGMPCSIMoudle.ascx.vb"
    Inherits="CMCFileManage.CtlGMPCSIMoudle" TargetSchema="http://schemas.microsoft.com/intellisense/ie5" %>
<%@ Register src="CTLGEPNGReason.ascx" tagname="CTLGEPNGReason" tagprefix="uc1" %>
<%@ Register src="mulchoiceitem.ascx" tagname="mulchoiceitem" tagprefix="uc2" %>
<table id="TableOutDate" width="100%" runat="server" visible="false">
    <tr valign="middle">
        <td valign="middle" align="center">
            <asp:Label ID="Label2" runat="server" Text="本此調查已經結束,請下次參與!" CssClass="NormalRedBig"></asp:Label>
        </td>
    </tr>
</table>
<table id="TableContent" width="100%" runat="server">
    <tr>
        <td class="TdTitle" height="30" align="left">
            <asp:Button ID="BtnSubmit1" runat="server" Text="保存并提交" class="button">
            </asp:Button>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <input type="text" id="txtDeptName" style="display: none; visibility: hidden" runat="server"
                name="txtDeptName">&nbsp;&nbsp;&nbsp;&nbsp;
            <input type="button" class="button" value="返回" runat="server" id="BtnBack"
                onclick="javascript:history.go(-1);return false;">
        </td>
    </tr>
    <tr>
        <td align="center">
            <asp:Label ID="lblTitle" CssClass="TitleText" runat="server"></asp:Label>
        </td>
    </tr>
    <tr>
        <td  align="center">
            <asp:Label ID="lblCSITitle" CssClass="TitleText" runat="server"></asp:Label>
        </td>
    </tr>
    <tr>
        <td>
            <asp:Label ID="lblHead" CssClass="SubTitleText" runat="server"></asp:Label>
        </td>
    </tr>
    <tr>
        <td class="SubTitleText">
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;您好！
        </td>
    </tr>
    <tr>
        <td>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="lblCSIExplain" CssClass="SubTitleText" runat="server"></asp:Label>
        </td>
    </tr>
    <tr>
        <td align="center">
            <p align="center">
                <asp:Label ID="LblNotice" runat="server" CssClass="CSIRed" ForeColor="Red" Width="632px"></asp:Label></p>
        </td>
    </tr>
    <tr>
        <td align="left">
            <table id="tableItem2" width="100%" border="0">
                <tr>
                    <td align="left">
                        <asp:Label ID="lblItem2" CssClass="SubTitleText" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr height="10">
                    <td align="right" >
                        <asp:Label ID="lblSearchResult" runat="server" CssClass="CSIRed" ForeColor="Maroon"
                            BackColor="#FFFFC0"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td nowrap>
                        <asp:DataGrid ID="DataGrid1" runat="server" Width="100%" AutoGenerateColumns="False"
                            AllowSorting="True">
                            <AlternatingItemStyle CssClass="GridAlterItem" />
                            <ItemStyle CssClass="GridItem" />
                            <Columns>
                                <asp:TemplateColumn HeaderText="序號" FooterText="No">
                                    <HeaderStyle Wrap="False" Width="30px"></HeaderStyle>
                                    <ItemTemplate>
                                        <asp:Label ID="LblNO" runat="server" Text="<%# Container.ItemIndex+1 %>">
                                        </asp:Label><input id="TxtPKID" type="hidden" value="0" name="TxtPKID" runat="server" />
                                    </ItemTemplate>
                                </asp:TemplateColumn>
                                <asp:TemplateColumn HeaderText="调查项目">
                                    <ItemStyle Wrap="False" Width="35%" ></ItemStyle>
                                    <ItemTemplate>
                                        <asp:Label ID="lblItemName" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.ItemName") %>'>
                                        </asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateColumn>
                                <asp:TemplateColumn HeaderText="评价">
                                    <ItemTemplate>
                                        <asp:RadioButtonList ID="RadioBtnList" runat="server" CssClass="SkinObject" Width="350px"
                                            RepeatDirection="Horizontal">
                                            <asp:ListItem Value="1">很满意</asp:ListItem>
                                            <asp:ListItem Value="2">满意</asp:ListItem>
                                            <asp:ListItem Value="3">一般</asp:ListItem>
                                            <asp:ListItem Value="4">不满意</asp:ListItem>
                                            <asp:ListItem Value="5">很不满意</asp:ListItem>
                                            <asp:ListItem Value="6">不涉及</asp:ListItem>
                                        </asp:RadioButtonList>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator7" Display="Dynamic" ControlToValidate="RadioBtnList"
                                            runat="server" ErrorMessage="*"></asp:RequiredFieldValidator>
                                    </ItemTemplate>
                                </asp:TemplateColumn>
                                <asp:TemplateColumn HeaderText="不满意原因">
                                    <ItemStyle Wrap="False" Width="260px"></ItemStyle>
                                    <ItemTemplate>
                                    <uc1:CTLGEPNGReason ID="CTLGEPNGReason1" runat="server" />
                                    </ItemTemplate>
                                </asp:TemplateColumn>
                            </Columns>
                            <HeaderStyle CssClass="GridHead" />
                        </asp:DataGrid>
                    </td>
                </tr>
            </table>
        </td>
    </tr>
    <tr>
        <td align="left">
            <table width ="100%">
                <tr>
                    <td>
                        <asp:Label ID="Label3" CssClass="SubTitleText"  runat="server" Text="多选项目"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                         <asp:DataGrid ID="DataGrid3" runat="server" Width="100%" AutoGenerateColumns="False"
                            AllowSorting="True">
                             <ItemStyle HorizontalAlign="Left" CssClass="GridItem"></ItemStyle>
                            <HeaderStyle CssClass="GridHead"></HeaderStyle>
                             <Columns>
                              <asp:TemplateColumn HeaderText="序號" FooterText="No">
                                    <HeaderStyle Width="30px"></HeaderStyle>
                                    <ItemTemplate>
                                        <asp:Label ID="lblAnswerNo" runat="server" Text="<%# Container.ItemIndex+1 %>">
                                        </asp:Label> <input id="TxtPKID" type="hidden" value="0" name="TxtPKID" runat="server" />
                                    </ItemTemplate>
                                </asp:TemplateColumn>
                              <asp:TemplateColumn HeaderText="調查項目">
                                    <ItemStyle Wrap="False" Width="35%"></ItemStyle>
                                    <ItemTemplate>
                                        <asp:Label ID="lblItemName" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.ItemName") %>'>
                                        </asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateColumn>
                                  <asp:TemplateColumn HeaderText=" ">
                                  <ItemTemplate >
                                  <uc2:mulchoiceitem ID="mulchoiceitem1" runat="server" />
                                  </ItemTemplate>
                                  </asp:TemplateColumn> 
                             </Columns> 
                            </asp:DataGrid> 
                    </td>
                </tr>
            </table>
        </td>
    </tr>
    <tr>
        <td align="left">
            <table class="SkinObject" id="tableItem3" width="100%" border="0">
                <tr>
                    <td align="left">
                        <asp:Label ID="lblItem3" CssClass="SubTitleText" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:DataGrid ID="Datagrid2" runat="server" Width="100%" AutoGenerateColumns="False"
                            AllowSorting="True">
                            <ItemStyle HorizontalAlign="Left" CssClass="GridItem"></ItemStyle>
                            <HeaderStyle CssClass="GridHead"></HeaderStyle>
                            <Columns>
                                <asp:TemplateColumn HeaderText="序號" FooterText="No">
                                    <HeaderStyle Width="30px"></HeaderStyle>
                                    <ItemTemplate>
                                        <asp:Label ID="lblAnswerNo" runat="server" Text="<%# Container.ItemIndex+1 %>">
                                        </asp:Label><input id="txtAnswerPKID" type="hidden" value="0" name="txtAnswerPKID"
                                            runat="server">
                                    </ItemTemplate>
                                </asp:TemplateColumn>
                                <asp:TemplateColumn HeaderText="調查項目">
                                    <ItemStyle Wrap="False" Width="35%"></ItemStyle>
                                    <ItemTemplate>
                                        <asp:Label ID="lblAnswerItem" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.ItemName") %>'>
                                        </asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateColumn>
                                <asp:TemplateColumn HeaderText="請注明您的意見反饋">
                                    <ItemTemplate>
                                        <asp:TextBox ID="txtAdvice" Width="100%" runat="server"></asp:TextBox>
                                    </ItemTemplate>
                                </asp:TemplateColumn>
                            </Columns>
                        </asp:DataGrid>
                    </td>
                </tr>
            </table>
        </td>
    </tr>
    <tr>
        <td align="left">
            <table class="SkinObject" id="Table1" width="100%" border="0">
                <tr>
                    <td align="left" colspan="6">
                        <asp:Label CssClass="SubTitleText" ID="lblItem1" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        公司名称:</td>
                    <td align="left" colspan="5">
                        <asp:TextBox ID="TxtUnit" Width="220px" runat="server"></asp:TextBox><asp:RequiredFieldValidator
                            ID="RequiredFieldValidator3" runat="server" CssClass="NormalText" ErrorMessage="必填"
                            Display="Dynamic" ControlToValidate="TxtUnit"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td align="left">
                        <p align="right">
                            联系人:</p>
                    </td>
                    <td align="left">
                        <%--<asp:RequiredFieldValidator
                            ID="RequiredFieldValidator1" runat="server" CssClass="NormalText" ErrorMessage="必填"
                            Display="Dynamic" ControlToValidate="TxtGroup"></asp:RequiredFieldValidator>--%>
                        <asp:TextBox ID="TxtVisitor" runat="server"></asp:TextBox>
                    </td>
                    <td align="left">
                        <p align="right">
                            电话:</p>
                    </td>
                    <td align="left">
                        <%--<asp:RequiredFieldValidator
                            ID="RequiredFieldValidator2" runat="server" CssClass="NormalText" ErrorMessage="必填"
                            Display="Dynamic" ControlToValidate="TxtDept"></asp:RequiredFieldValidator>--%>
                        <asp:TextBox ID="Txtcusphone" runat="server"></asp:TextBox>
                    </td>
                    <td align="left">
                        <p align="right">
                            手机:</p>
                    </td>
                    <td align="left">
                        <asp:TextBox ID="TxtExt" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td align="left">
                        <p align="right">
                            E-Mail:</p>
                    </td>
                    <td align="left">
                        <asp:TextBox ID="TxtEmail" runat="server" Width="220px"></asp:TextBox>
                    </td>
                    <td align="left">
                        <p align="right">
                            传真:</p>
                    </td>
                    <td align="left">
                        <asp:TextBox ID="TxtFax" runat="server"></asp:TextBox>
                    </td>
                    <td align="left">
                        <p align="right">
                            网址:</p>
                    </td>
                    <td align="left">
                        <asp:TextBox ID="TxtWebSite" runat="server"></asp:TextBox>
                    </td>
                </tr>
            </table>
        </td>
    </tr>
    <tr>
        <td align="left">
            <asp:Label ID="lblEnd" runat="server"></asp:Label>
        </td>
    </tr>
    <tr>
        <td class="TdTitle" height="30" align="left">
            <asp:Button ID="BtnSubmit2" runat="server" Text="保存并提交" class="button">
            </asp:Button>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <input type="button" id="BtnClose2" value="關閉" class="button" onclick="javascript:window.close();"
                name="BtnClose2">&nbsp;&nbsp;&nbsp;&nbsp;
            <input type="button" class="button" value="返回" runat="server" id="btnBack2"
                onclick="javascript:history.go(-1);return false;" name="btnBack2">
            
            
            
        </td>
    </tr>
</table>
<div style ="display :none ">
<asp:TextBox ID="TxtGroup" Visible ="false"  Text="外部客戶" runat="server"></asp:TextBox>
<asp:TextBox ID="TxtDept" Visible ="false"  Text ="外部客戶" runat="server"></asp:TextBox>
</div>
