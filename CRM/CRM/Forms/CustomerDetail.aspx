<%@ Page Language="vb" AutoEventWireup="false" Theme="Default" CodeBehind="CustomerDetail.aspx.vb"
    Inherits="CRM.CustomerDetail" %>

<%@ Register Assembly="eFlowWebControl" Namespace="eFlowWebControl" TagPrefix="cc1" %>
<%@ Register Src="../UCtl/UcFileDetail.ascx" TagName="UcFileDetail" TagPrefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../IconsThemes/icon.css" rel="stylesheet" type="text/css" />
    <link href="../NewScript/themes/Default/easyui.css" rel="stylesheet" type="text/css" />

    <script src="../NewScript/jquery-1.7.2.min.js" type="text/javascript"></script>

    <script src="../NewScript/jquery.easyui.min.js" type="text/javascript"></script>

    <script src="ContactManage.js" type="text/javascript"></script>

</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div align="center" style="font-family: 細明體">
        <asp:Label ID="LbTitle" runat="server" Font-Size="20px" Text="客戶基本信息"></asp:Label>
    </div>
    <div>
        <asp:LinkButton ID="LinkEdit" class="easyui-linkbutton" plain="true" iconCls="icon-edit"
            runat="server">修改</asp:LinkButton>
        <asp:LinkButton ID="LinkBack" class="easyui-linkbutton" plain="true" iconCls="icon-back"
            runat="server">返回</asp:LinkButton>
        <asp:LinkButton ID="LinkSave" class="easyui-linkbutton" Visible="false" plain="true"
            iconCls="icon-save" runat="server">保存</asp:LinkButton>
        <asp:LinkButton ID="LinkDelete" class="easyui-linkbutton" plain="true" iconCls="icon-no"
            runat="server">刪除</asp:LinkButton>
        <%--<asp:LinkButton ID="LinkContactManage" class="easyui-linkbutton" plain="true" iconCls="icon-Manage"
            runat="server">聯繫人管理</asp:LinkButton>--%>
        <asp:LinkButton ID="LinkTransacTions" class="easyui-linkbutton" plain="true" iconCls="icon-sum"
            runat="server">交易記錄</asp:LinkButton>
        <asp:LinkButton ID="LinkComplaints" Enabled="false" class="easyui-linkbutton" plain="true"
            iconCls="icon-tip" runat="server">投訴記錄</asp:LinkButton>
        <asp:LinkButton ID="LinkGMPCSI" Enabled="false" class="easyui-linkbutton" plain="true"
            iconCls="icon-Approve" runat="server">滿意度調查</asp:LinkButton>
        <asp:LinkButton ID="LinkLevelChange" Visible="false" class="easyui-linkbutton" plain="true"
            iconCls="icon-remove" runat="server">客戶等級變更</asp:LinkButton>
    </div>
    <div id="DTableImage" class="easyui-tabs" tools="#tab-tools" style="height: auto;">
        <div title="基本信息" style="padding: 5px; height: auto;" iconcls="icon-Manage">
            <table width="99%" border="1" cellpadding="0" cellspacing="0" bordercolordark="#FFFFFF"
                bordercolor="#999999">
                <tr>
                    <td align="right" style="color: #009933">
                        單位名稱
                    </td>
                    <td colspan="3" style="padding-left: 5px">
                        <asp:TextBox ID="TxtCustomerName" Visible="false" runat="server" Width="500px"></asp:TextBox>
                        <asp:Label ID="LbCustomerName" runat="server" Text=""></asp:Label>
                        &nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TxtCustomerName"
                            ErrorMessage="請填寫單位名稱"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td align="right" style="color: #009933">
                        客戶編號
                    </td>
                    <td colspan="3" style="padding-left: 5px">
                        <asp:Label ID="LbCustomerNO" runat="server" Text=""></asp:Label>
                        &nbsp;<asp:Label ID="LbNotice" runat="server" Text="客戶編號由行業加類別加流水碼自動生成" Visible="False"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td align="right" style="color: #009933">
                        客戶簡稱
                    </td>
                    <td colspan="3" style="padding-left: 5px">
                        <asp:TextBox ID="TxtCustomerAlias" Visible="false" runat="server" Width="500px"></asp:TextBox>
                        <asp:Label ID="LbCustomerAlias" runat="server" Text=""></asp:Label>
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td align="right" style="color: #009933">
                        英文名
                    </td>
                    <td colspan="3" style="padding-left: 5px">
                        <asp:TextBox ID="TxtCustomerEnglishName" Visible="false" runat="server" Width="500px"></asp:TextBox>
                        <asp:Label ID="LbCustomerEnglishName" runat="server" Text=""></asp:Label>
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td align="right" style="color: #009933">
                        負責人
                    </td>
                    <td colspan="3" style="padding-left: 5px" valign="bottom">
                        <asp:DropDownList ID="DPLPersonincharge" Visible="false" runat="server" Width="505px">
                        </asp:DropDownList>
                        <asp:DataList ID="DataList1" runat="server" HorizontalAlign="Left" RepeatDirection="Horizontal"
                            RepeatLayout="Flow">
                            <ItemTemplate>
                                <asp:LinkButton ID="LinkButton1" runat="server" Text='<%#Container.DataItem%>'></asp:LinkButton>
                                &nbsp;
                            </ItemTemplate>
                        </asp:DataList>
                        <%--  <asp:TextBox ID="TxtPersonInCharge" Visible="false" runat="server" Width="500px"
                        ForeColor="#0066FF"></asp:TextBox>
                    <asp:HiddenField ID="HiddenPersonIncharge" runat="server" />
                    <asp:Label ID="Lbnotic0" Visible="false" runat="server" Text="多個負責人以、分隔"></asp:Label>
                    <asp:Image ID="Image2" Visible="false" Style="cursor: hand;" ToolTip="點擊選擇" ImageUrl="~/Images/search.png"
                        runat="server" onclick="GetMutilContactDialog('#ContactDialog', '#ContactInfo', 'TxtPersonInCharge', 'HiddenPersonIncharge')" />
                    <asp:DataList ID="DataList1" runat="server" HorizontalAlign="Left" 
                        RepeatDirection="Horizontal" RepeatLayout="Flow">
                        <ItemTemplate>
                            <asp:LinkButton ID="LinkButton1" runat="server" Text='<%#Container.DataItem%>'></asp:LinkButton>
                            &nbsp;
                        </ItemTemplate>
                    </asp:DataList>
                   
                    &nbsp;--%>
                    </td>
                </tr>
                <%--<tr>
                <td align="right" style="color: #009933">
                    聯繫人
                </td>
                <td colspan="3" style="padding-left: 5px">
                    <asp:TextBox ID="TxtManagers" Visible="false" runat="server" Width="500px" ForeColor="#0066FF"></asp:TextBox>
                    
                    <asp:DataList ID="DataList2" runat="server" HorizontalAlign="Left" 
                        RepeatDirection="Horizontal" RepeatLayout="Flow">
                        <ItemTemplate>
                            <asp:LinkButton ID="LinkButton1" runat="server" Text='<%#Container.DataItem%>'></asp:LinkButton>
                            &nbsp;
                        </ItemTemplate>
                    </asp:DataList>
                    <asp:HiddenField ID="HiddenManages" runat="server" />
                    <asp:Image ID="Image1" Visible="false" Style="cursor: hand;" ToolTip="點擊選擇" ImageUrl="~/Images/search.png"
                        runat="server" onclick="GetMutilContactDialog('#ContactDialog', '#ContactInfo', 'TxtManagers', 'HiddenManages')" />
                    <asp:Label ID="Lbnotic" Visible="false" runat="server" Text="多個聯繫人以、分隔"></asp:Label>
                    &nbsp;
                </td>
            </tr>--%>
                <tr>
                    <td align="right" width="10%" style="color: #009933">
                        類別
                    </td>
                    <td width="45%" style="padding-left: 5px">
                        <asp:DropDownList ID="DPLCategory" Visible="false" runat="server" Width="205px">
                            <asp:ListItem Value="1">內部客戶</asp:ListItem>
                            <asp:ListItem Value="2" Selected="True">外部客戶</asp:ListItem>
                        </asp:DropDownList>
                        <asp:Label ID="LbCategory" runat="server" Text=""></asp:Label>
                    </td>
                    <td width="10%" align="right" style="color: #009933">
                        賬款警告
                    </td>
                    <td width="33%" style="padding-left: 5px">
                        <asp:TextBox ID="TxtPaywarning" class="easyui-numberbox" Width="200px" runat="server"
                            Visible="False"></asp:TextBox>
                        <asp:Label ID="LbPaywarning" runat="server"></asp:Label>
                        天
                    </td>
                </tr>
                <tr>
                    <td align="right" width="10%" style="color: #009933">
                        行業
                    </td>
                    <td width="45%" style="padding-left: 5px">
                        <asp:DropDownList ID="DPLIndustry" Visible="false" runat="server" Width="205px">
                        </asp:DropDownList>
                        <asp:Label ID="LbIndustry" runat="server" Text=""></asp:Label>
                        &nbsp;
                    </td>
                    <td width="10%" align="right" style="color: #009933">
                        付款方式
                    </td>
                    <td width="33%" style="padding-left: 5px">
                        <asp:DropDownList ID="DPLTypeofPay" Enabled="false" Visible="false" runat="server"
                            Width="205px">
                            <asp:ListItem Value="1">預付款</asp:ListItem>
                            <asp:ListItem Value="2">月結</asp:ListItem>
                        </asp:DropDownList>
                        <asp:Label ID="LbTypeofPay" runat="server" Text=""></asp:Label>
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td align="right" style="color: #009933">
                        狀態
                    </td>
                    <td style="padding-left: 5px">
                        <asp:DropDownList ID="DPLStatus" Visible="false" runat="server" Width="205px">
                            <asp:ListItem Value="1">正常</asp:ListItem>
                            <asp:ListItem Value="2">凍結</asp:ListItem>
                        </asp:DropDownList>
                        <asp:Label ID="LbStatus" runat="server" Text=""></asp:Label>
                        &nbsp;
                    </td>
                    <td align="right" style="color: #009933">
                        客戶來源
                    </td>
                    <td style="padding-left: 5px">
                        <asp:DropDownList ID="DPLSource" Visible="false" runat="server" Width="205px">
                        </asp:DropDownList>
                        <asp:Label ID="LbSource" runat="server" Text=""></asp:Label>
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td align="right" style="color: #009933">
                        區域
                    </td>
                    <td style="padding-left: 5px">
                        <asp:TextBox ID="TxtCity" Visible="false" Width="200px" runat="server">請填寫市級行政區域</asp:TextBox>
                        <asp:Label ID="LbCity" runat="server" Text=""></asp:Label>
                        &nbsp;
                    </td>
                    <td align="right" style="color: #009933">
                        郵政編號
                    </td>
                    <td style="padding-left: 5px">
                        <asp:TextBox ID="TxtZipCode" class="easyui-numberbox" Visible="false" runat="server"
                            Width="200px"></asp:TextBox>
                        <asp:Label ID="LbZipCode" runat="server" Text=""></asp:Label>
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td align="right" style="color: #009933">
                        電話
                    </td>
                    <td style="padding-left: 5px">
                        <asp:TextBox ID="TxtPhone" Visible="false" runat="server" Width="200px"></asp:TextBox>
                        <asp:Label ID="LbPhone" runat="server" Text=""></asp:Label>
                        &nbsp;
                    </td>
                    <td align="right" style="color: #009933">
                        傳真
                    </td>
                    <td style="padding-left: 5px">
                        <asp:TextBox ID="TxtFax" Visible="false" runat="server" Width="200px"></asp:TextBox>
                        <asp:Label ID="LbFax" runat="server" Text=""></asp:Label>
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td align="right" style="color: #009933">
                        註冊資金
                    </td>
                    <td style="padding-left: 5px">
                        <asp:TextBox ID="TxtZhuceCapital" class="easyui-numberbox" Visible="false" runat="server"
                            Width="200px"></asp:TextBox>
                        <asp:Label ID="LbZhuceCapital" runat="server" Text=""></asp:Label>(萬元) &nbsp;
                    </td>
                    <td align="right" style="color: #009933">
                        員工數量
                    </td>
                    <td style="padding-left: 5px">
                        <asp:TextBox ID="TxtEmployeeNum" class="easyui-numberbox" Visible="false" runat="server"
                            Width="200px"></asp:TextBox>
                        <asp:Label ID="LbEmployeeNum" runat="server" Text=""></asp:Label>
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td align="right" style="color: #009933">
                        開戶銀行
                    </td>
                    <td style="padding-left: 5px">
                        <asp:TextBox ID="TxtBank" Visible="false" runat="server" Width="200px"></asp:TextBox>
                        <asp:Label ID="LbBank" runat="server" Text=""></asp:Label>
                        &nbsp;
                    </td>
                    <td align="right" style="color: #009933">
                        銀行帳號
                    </td>
                    <td style="padding-left: 5px">
                        <asp:TextBox ID="TxtBankAccount" Visible="false" runat="server" Width="200px"></asp:TextBox>
                        <asp:Label ID="LbBankAccount" runat="server" Text=""></asp:Label>
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td align="right" style="color: #009933">
                        郵件
                    </td>
                    <td colspan="3" style="padding-left: 5px">
                        <asp:TextBox ID="TxtEmail" Visible="false" runat="server" Width="500px"></asp:TextBox>
                        <asp:Label ID="LbEmail" runat="server" Text=""></asp:Label>
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td align="right" style="color: #009933">
                        網址
                    </td>
                    <td colspan="3" style="padding-left: 5px">
                        <asp:TextBox ID="TxtWebAddress" Visible="false" runat="server" Width="500px"></asp:TextBox>
                        <asp:Label ID="LbWebAddress" runat="server" Text=""></asp:Label>
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td align="right" style="color: #009933">
                        地址
                    </td>
                    <td colspan="3" style="padding-left: 5px">
                        <asp:TextBox ID="TxtAddress" Visible="false" runat="server" Width="500px"></asp:TextBox>
                        <asp:Label ID="LbAddress" runat="server" Text=""></asp:Label>
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td align="right" style="color: #009933">
                        開戶名稱
                    </td>
                    <td colspan="3" style="padding-left: 5px">
                        <asp:TextBox ID="TxtAccountName" Visible="false" runat="server" Width="500px"></asp:TextBox>
                        <asp:Label ID="LbAccountName" runat="server" Text=""></asp:Label>
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td align="right" style="color: #009933">
                        開票名稱
                    </td>
                    <td colspan="3" style="padding-left: 5px">
                        <asp:TextBox ID="TxtBillingName" Visible="false" runat="server" Width="500px"></asp:TextBox>
                        <asp:Label ID="LbBillingName" runat="server" Text=""></asp:Label>
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td align="right" style="color: #009933">
                        增值稅號
                    </td>
                    <td colspan="3" style="padding-left: 5px">
                        <asp:TextBox ID="TxtVATNum" Visible="false" runat="server" Width="500px"></asp:TextBox>
                        <asp:Label ID="LbVATNum" runat="server" Text=""></asp:Label>
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td align="right" style="color: #009933">
                        摘要
                    </td>
                    <td colspan="3" style="padding-left: 5px">
                        <asp:TextBox ID="TxtRemark" Visible="false" runat="server" Height="100px" TextMode="MultiLine"
                            Width="500px"></asp:TextBox>
                        <asp:Label ID="LbRemark" runat="server" Text=""></asp:Label>
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td align="right" style="color: #009933">
                        附件
                    </td>
                    <td colspan="3" style="padding-left: 5px">
                        <uc1:UcFileDetail ID="UcFileDetail1" runat="server" />
                    </td>
                </tr>
            </table>
        </div>
        <div id="CusPerson" runat="server" title="公司人員" style="padding: 5px; height: auto;"
            iconcls="icon-Manage">
            <div>
                <table>
                    <tr>
                        <td colspan="4">
                            搜尋：<input id="InpSearch" runat="server" class="easyui-searchbox" searcher="searchcontact"
                                style="width: 600px"></input>
                            <asp:Button ID="BtnSearch" Style="display: none" runat="server" Text="Button" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:LinkButton ID="LinkAdd" class="easyui-linkbutton" plain="true" iconcls="icon-add"
                                runat="server">新增人員</asp:LinkButton>
                        </td>
                        <td>
                        </td>
                        <td>
                        </td>
                        <td>
                        </td>
                    </tr>
                </table>
            </div>
            <div id="emptyinfo" runat="server" visible="false" style="width: 100%; height: 30px;
                background-color: #DBE3FF; line-height: 30px; overflow: hidden;">
                <asp:Image ID="Image1" runat="server" ImageUrl="~/Images/Icons/information.png" />
                &nbsp;&nbsp;&nbsp; 該公司還未添加人員信息，請先添加。</div>
            <div>
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" Width="100%">
                    <Columns>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:Label ID="LblNo" Width="30px" runat="server" Text="<%# Container.DataItemIndex+1+PageSize*(PageIndex-1)%>"></asp:Label>
                                <asp:Label ID="lbPKID" runat="server" Text='<%# DataBinder.Eval(Container,"DataItem.PKID").ToString() %>'
                                    Visible="False"></asp:Label>
                                <asp:HyperLink ID="HLDetail" Target="_self" runat="server" ToolTip="編輯" ImageUrl="../Images/ico/pen.png">查看</asp:HyperLink>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="UserName" HeaderText="姓名" />
                        <asp:BoundField DataField="UserSID" HeaderText="帳號" />
                        <asp:BoundField DataField="Position" HeaderText="職務" />
                        <asp:BoundField DataField="CustomerName" HeaderText="公司名" />
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:ImageButton ID="BtnDelete" runat="server" ToolTip="刪除" ImageUrl="../Images/ico/trash.png"
                                    CommandName="Delete"></asp:ImageButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>
            <div class="Pager">
                <cc1:PagerControl ID="PagerControl1" Visible="false" runat="server" SkinID="PagerControlSkin">
                </cc1:PagerControl>
            </div>
            <div id="Div1" iconcls="icon-save" closed="true" title="請選擇聯繫人信息" runat="server">
                <div id="Div2" toolbar="#dlg-toolbar">
                </div>
                <div id="Div3" style="display: none;">
                    <table cellpadding="0" cellspacing="0" style="width: 100%">
                        <tr>
                            <td style="width: 100%; text-align: right;" style="padding-left: 2px">
                                <asp:Label ID="Label1" runat="server" Text="姓名"></asp:Label>
                            </td>
                            <td style="text-align: right; padding-right: 2px">
                                <input class="easyui-searchbox" searcher="selectcontact"></input>
                            </td>
                        </tr>
                    </table>
                </div>
            </div>
        </div>
        <div id="CustomerVisits" runat="server" title="客戶拜訪" style="padding: 5px; height: auto;"
            iconcls="icon-Manage">
            <div>
                <asp:LinkButton ID="LinkAddVisits" class="easyui-linkbutton" plain="true" iconcls="icon-add"
                    runat="server">新增拜訪</asp:LinkButton>
            </div>
            <div id="emptyinfo2" runat="server" visible="false" style="width: 100%; height: 30px;
                background-color: #DBE3FF; line-height: 30px; overflow: hidden;">
                <asp:Image ID="Image2" runat="server" ImageUrl="~/Images/Icons/information.png" />
                &nbsp;&nbsp;&nbsp; 該公司還未添加拜訪信息，請先添加。</div>
            <div>
                <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" Width="100%">
                    <Columns>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:Label ID="LblNo" Width="30px" runat="server" Text="<%# Container.DataItemIndex+1+PageSize*(PageIndex-1)%>"></asp:Label>
                                <asp:Label ID="lbPKID" runat="server" Text='<%# DataBinder.Eval(Container,"DataItem.PKID").ToString() %>'
                                    Visible="False"></asp:Label>
                                <asp:Label ID="lblDocUniqueID" runat="server" Text='<%# DataBinder.Eval(Container,"DataItem.eFlowDocID").ToString() %>'
                                    Visible="False"></asp:Label>
                                <asp:HyperLink ID="HLDetail" Target="_self" runat="server" ToolTip="編輯" ImageUrl="../Images/ico/pen.png">查看</asp:HyperLink>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="QuoterName" HeaderText="業務員" ItemStyle-HorizontalAlign="Center" />
                        <asp:BoundField DataField="StateName" HeaderText="狀態" ItemStyle-HorizontalAlign="Center" />
                        <asp:BoundField DataField="VisitDate" HeaderText="拜訪日期" DataFormatString="{0:yy-MM-dd}"
                            ItemStyle-HorizontalAlign="Center" />
                        <asp:BoundField DataField="CooperationAgen" HeaderText="現合作機構" ItemStyle-HorizontalAlign="Center" />
                        <asp:TemplateField >
                    <ItemTemplate>
                        <asp:ImageButton ID="BtnDelete" runat="server" ToolTip="刪除" ImageUrl="../Images/ico/trash.png"
                            CommandName="Delete"></asp:ImageButton>
                    </ItemTemplate>
                </asp:TemplateField>
                    </Columns>
                    <HeaderStyle HorizontalAlign="Center" />
                </asp:GridView>
            </div>
            <div class="Pager">
                <cc1:PagerControl ID="PagerControl2" Visible="false" runat="server" SkinID="PagerControlSkin">
                </cc1:PagerControl>
            </div>
        </div>
    </div>
    <div align="center" style="font-size: 10px; color: #3399FF">
        創建人：<asp:Label ID="LbCreater" runat="server" Font-Bold="True"></asp:Label>&nbsp;&nbsp;&nbsp;
        創建日期：<asp:Label ID="LbCreateDate" runat="server" Font-Bold="True"></asp:Label>
    </div>
    <div id="ContactDialog" iconcls="icon-save" closed="true" title="請選擇聯繫人信息" runat="server">
        <div id="ContactInfo" toolbar="#dlg-toolbar">
        </div>
        <div id="dlg-toolbar" style="display: none;">
            <table cellpadding="0" cellspacing="0" style="width: 100%">
                <tr>
                    <td style="width: 100%; text-align: right;" style="padding-left: 2px">
                        <asp:Label ID="Label22" runat="server" Text="姓名"></asp:Label>
                    </td>
                    <td style="text-align: right; padding-right: 2px">
                        <input class="easyui-searchbox" searcher="selectcontact"></input>
                    </td>
                </tr>
            </table>
        </div>
    </div>
    </form>
</body>
</html>
