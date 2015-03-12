<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="MarketPlanDetail.aspx.vb"
    Inherits="CRM.MarketPlanDetail" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
     
    <link href="../IconsThemes/icon.css" rel="Stylesheet" type="text/css" />
    <link href="../NewScript/themes/Default/easyui.css" rel="stylesheet" type="text/css" />

    <script src="../NewScript/jquery-1.7.2.min.js" type="text/javascript"></script>

    <script src="../NewScript/jquery.easyui.min.js" type="text/javascript"></script>

    <script src="../NewScript/My97DatePicker/WdatePicker.js" type="text/javascript"></script>

    <script src="Marketplan.js" type="text/javascript"></script>

   

</head>
<body>
    <form id="form1" runat="server">
    <div id="title" style="height: 30px; font-size: 20px;" align="center">
        <asp:Label ID="MarketPlanName" runat="server"></asp:Label>
    </div>
    <div>
        <asp:LinkButton ID="LinkBack" class="easyui-linkbutton" iconcls="icon-back" plain="true"
            runat="server">返回列表</asp:LinkButton>
        &nbsp;&nbsp;<asp:LinkButton ID="LinkEdit" class="easyui-linkbutton" plain="true"
            iconcls="icon-edit" runat="server">編輯</asp:LinkButton>
        &nbsp;&nbsp;&nbsp;</div>
    <div id="planedit" runat="server">
        <table width="100%" border="1" cellpadding="0" cellspacing="0" bordercolordark="#FFFFFF"
            bordercolor="#999999">
            <tr>
                <td colspan="4" bgcolor="#E6E6E6" height="50">
                    <asp:Image ID="Image3" runat="server" Style="vertical-align: middle" ImageUrl="~/Images/ico/baseinfo.png" />
                    <asp:Label ID="Label8" runat="server" Text="營銷計劃信息" Font-Bold="True" Font-Size="14px"></asp:Label>
                </td>
            </tr>
            <tr>
                <td align="right">
                    營銷計劃所有人
                </td>
                <td>
                    <asp:DropDownList ID="DPLOwoner" runat="server">
                    </asp:DropDownList>
                </td>
                <td align="right">
                    發送數
                </td>
                <td>
                    <asp:TextBox ID="TxtSendNums" Text ="0" class="easyui-numberbox" data-options="min:0,precision:0,required:true" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td align="right">
                    營銷計劃名
                </td>
                <td>
                    <asp:TextBox ID="TxtPlanName" runat="server"></asp:TextBox>
                </td>
                <td align="right">
                    啟用狀態
                </td>
                <td>
                    <asp:RadioButtonList ID="RdoIsStarted" runat="server" RepeatDirection="Horizontal"
                        RepeatLayout="Flow">
                        <asp:ListItem Selected="True" Value="1">已啟動</asp:ListItem>
                        <asp:ListItem Value="0">未啟動</asp:ListItem>
                    </asp:RadioButtonList>
                </td>
            </tr>
            <tr>
                <td align="right">
                    類型
                </td>
                <td>
                    <asp:DropDownList ID="DplType" runat="server">
                        <asp:ListItem>發郵件</asp:ListItem>
                        <asp:ListItem>現場活動</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td align="right">
                    響應總數
                </td>
                <td>
                    <asp:TextBox ID="TxtResponseNums" text="0" class="easyui-numberbox" data-options="min:0,precision:0,required:true" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td align="right">
                    狀態
                </td>
                <td>
                    <asp:DropDownList ID="DPLCategory" runat="server">
                    </asp:DropDownList>
                </td>
                <td align="right">
                    結束日期
                </td>
                <td>
                    <asp:TextBox ID="TxtEndDate" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td align="right">
                    開始日期
                </td>
                <td>
                    <asp:TextBox ID="TxtStartDate" runat="server"></asp:TextBox>
                </td>
                <td align="right">
                    預期成本
                </td>
                <td>
                    <asp:TextBox ID="TxtBudgetCost" Text ="0" class="easyui-numberbox" data-options="min:0,precision:0,required:true" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td align="right">
                    預期收入
                </td>
                <td>
                    <asp:TextBox ID="TxtExceptedIncome" Text ="0" class="easyui-numberbox" data-options="min:0,precision:0,required:true" runat="server"></asp:TextBox>
                </td>
                <td align="right">
                    預期響應百分比
                </td>
                <td>
                    <asp:TextBox ID="TxtExceptedResPercent" text="0" class="easyui-numberbox" data-options="min:0,precision:0,required:true" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td align="right">
                    實際成本
                </td>
                <td>
                    <asp:TextBox ID="TxtActualCosts" Text ="0" class="easyui-numberbox" data-options="min:0,precision:0,required:true" runat="server"></asp:TextBox>
                </td>
                <td align="right">
                    &nbsp;
                </td>
                <td>
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td align="right">
                    描述
                </td>
                <td colspan="3">
                    <asp:TextBox ID="TxtRemark" runat="server" Height="80px" TextMode="MultiLine" 
                        Width="80%"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td align="center" colspan="4">
                    <asp:Button ID="BtnSave"  runat="server"
                        Text="保存" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Button ID="BtnCancel" runat="server" 
                        Text="取消" />
                </td>
            </tr>
        </table>
    </div>
    <div id="planshow" runat="server">
        <table width="100%" border="1" cellpadding="0" cellspacing="0" bordercolordark="#FFFFFF"
            bordercolor="#999999">
            <tr>
                <td colspan="4" bgcolor="#E6E6E6" height="50">
                    <asp:Image ID="Image1" runat="server" Style="vertical-align: middle" ImageUrl="~/Images/ico/baseinfo.png" />
                    <asp:Label ID="Label1" runat="server" Text="營銷計劃信息" Font-Bold="True" Font-Size="14px"></asp:Label>
                </td>
            </tr>
            <tr>
                <td align="right" width="150px">
                    營銷計劃名：
                </td>
                <td>
                    <asp:Label ID="LbmarketName" runat="server"></asp:Label>
                </td>
                <td align="right">
                    營銷計劃所有人：
                </td>
                <td>
                    <asp:Label ID="LbOwoner" runat="server" Text=""></asp:Label>
                </td>
            </tr>
            <tr>
                <td align="right">
                    類型：
                </td>
                <td>
                    <asp:Label ID="LbType" runat="server" Text=""></asp:Label>
                </td>
                <td align="right">
                    發送數：
                </td>
                <td>
                    <asp:Label ID="LbSendNums" runat="server" Text=""></asp:Label>
                </td>
            </tr>
            <tr>
                <td align="right">
                    狀態：
                </td>
                <td>
                    <asp:Label ID="LbCategory" runat="server" Text=""></asp:Label>
                </td>
                <td align="right">
                    啟用狀態：
                </td>
                <td>
                    <asp:Label ID="LbIsstarted" runat="server" Text=""></asp:Label>
                </td>
            </tr>
            <tr>
                <td align="right" >
                    響應總數：
                </td>
                <td >
                    <asp:Label ID="LbResponseNums" runat="server" Text=""></asp:Label>
                </td>
                <td align="right" >
                    潛在客戶總數：
                </td>
                <td >
                    <asp:Label ID="LbQCustomersNums" runat="server" Text=""></asp:Label>
                </td>
            </tr>
            <tr>
                <td align="right">
                    開始日期：
                </td>
                <td>
                    <asp:Label ID="LbStartDate" runat="server" Text=""></asp:Label>
                </td>
                <td align="right">
                    結束日期：
                </td>
                <td>
                    <asp:Label ID="LbEndDate" runat="server" Text=""></asp:Label>
                </td>
            </tr>
            <tr>
                <td align="right">
                    預期收入：
                </td>
                <td>
                    <asp:Label ID="LbExceptedIncome" runat="server" Text=""></asp:Label>
                </td>
                <td align="right">
                    預算成本：
                </td>
                <td>
                    <asp:Label ID="LbBudgetCost" runat="server" Text=""></asp:Label>
                </td>
            </tr>
            <tr>
                <td align="right">
                    實際成本：
                </td>
                <td>
                    <asp:Label ID="LbActualCosts" runat="server" Text=""></asp:Label>
                </td>
                <td align="right">
                    預期響應百分比：
                </td>
                <td>
                    <asp:Label ID="LbExpectedRePercent" runat="server" Text=""></asp:Label>
                </td>
            </tr>
            <tr>
                <td align="right">
                    成交業務機會總值：
                </td>
                <td>
                    <asp:Label ID="LbBusOppCGValue" runat="server" Text=""></asp:Label>
                </td>
                <td align="right">
                    業務機會總值：
                </td>
                <td>
                    <asp:Label ID="LbBusOppTotalvalue" runat="server" Text=""></asp:Label>
                </td>
            </tr>
            <tr>
                <td align="right">
                    成員總數：
                </td>
                <td>
                    <asp:Label ID="LbContactNums" runat="server" Text=""></asp:Label>
                </td>
                <td align="right">
                    獲得業務機會數：
                </td>
                <td>
                    <asp:Label ID="LbBusOppNums" runat="server" Text=""></asp:Label>
                </td>
            </tr>
            <tr>
                <td align="right">
                    每個響應的平均成本：
                </td>
                <td>
                    <asp:Label ID="LbPerResponseCB" runat="server" Text=""></asp:Label>
                </td>
                <td align="right">
                    投資回報率：
                </td>
                <td>
                    <asp:Label ID="LbTZHBL" runat="server" Text=""></asp:Label>
                </td>
            </tr>
            <tr>
                <td align="right">
                    每個客戶的平均成本：
                </td>
                <td>
                    <asp:Label ID="LbPerCusCB" runat="server" Text=""></asp:Label>
                </td>
                <td align="right">
                    已轉換潛在客戶數：
                </td>
                <td>
                    <asp:Label ID="LbChangeCusNums" runat="server" Text=""></asp:Label>
                </td>
            </tr>
            <tr>
                <td align="right" >
                    描述：
                </td>
                <td  colspan="3">
                    <asp:Label ID="LbRemark" runat="server" Text=""></asp:Label>
                &nbsp;&nbsp;</td>
            </tr>
        </table>
    </div>
    <div id="yewujihui" runat="server">
        <table width="100%" border="1" cellpadding="0" cellspacing="0" bordercolordark="#FFFFFF"
            bordercolor="#999999">
            <tr>
                <td valign="middle" bgcolor="#E6E6E6" height="30">
                    &nbsp;<asp:Label ID="Label22" Style="vertical-align: middle" runat="server" Text="業務機會"
                        Height="20px" Font-Bold="True" Font-Size="14px"></asp:Label>
                    &nbsp; &nbsp;<asp:LinkButton ID="LinkNewBussOpp" class="easyui-linkbutton" iconcls="icon-Approve"
                        plain="true" runat="server">新建</asp:LinkButton>
                    &nbsp; <a class="easyui-linkbutton" plain="true" onclick="addbussopp()" iconcls="icon-add">
                        添加</a>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:GridView ID="GridBussOpp" runat="server" AutoGenerateColumns="False" Width="100%">
                        <Columns>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:Label ID="LBpkid" Visible="false" runat="server" Text='<%#DataBinder.Eval(Container,"DataItem.pkid") %>'></asp:Label>
                                    <asp:LinkButton ID="LinkEdit" CommandName="editup" runat="server">編輯</asp:LinkButton>&nbsp;&nbsp;<asp:LinkButton
                                        ID="LinkSave" Visible="false" CommandName="saveup" runat="server">更新</asp:LinkButton>&nbsp;&nbsp;<asp:LinkButton
                                            ID="LinkCancle" runat="server" CommandName="cancleed" Visible="false">取消</asp:LinkButton>&nbsp;&nbsp;
                                    <asp:HyperLink ID="HYLinkSee" runat="server">查看</asp:HyperLink>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField HeaderText="業務機會名稱" DataField="OpportName" HeaderStyle-HorizontalAlign="Left"
                                ItemStyle-HorizontalAlign="Left">
                                <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                                <ItemStyle HorizontalAlign="Left"></ItemStyle>
                            </asp:BoundField>
                            <asp:BoundField HeaderText="業務機會所有人" DataField="OppOwoner" HeaderStyle-HorizontalAlign="Left"
                                ItemStyle-HorizontalAlign="Left">
                                <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                                <ItemStyle HorizontalAlign="Left"></ItemStyle>
                            </asp:BoundField>
                            <asp:BoundField HeaderText="結束日期" DataField="EndDate" HeaderStyle-HorizontalAlign="Left"
                                ItemStyle-HorizontalAlign="Left" DataFormatString ="{0:yy-MM-dd}">
                                <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                                <ItemStyle HorizontalAlign="Left"></ItemStyle>
                            </asp:BoundField>
                            <asp:BoundField HeaderText="客戶名稱" DataField="CustomerName" HeaderStyle-HorizontalAlign="Left"
                                ItemStyle-HorizontalAlign="Left">
                                <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                                <ItemStyle HorizontalAlign="Left"></ItemStyle>
                            </asp:BoundField>
                            <asp:TemplateField HeaderText="階段" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                <ItemTemplate>
                                    <asp:Label ID="LbCategory" runat="server" Text='<%#DataBinder.Eval(Container,"DataItem.Category") %>'></asp:Label>
                                    <asp:DropDownList ID="DPLCategory" Visible="false" runat="server">
                                    </asp:DropDownList>
                                </ItemTemplate>
                                <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                                <ItemStyle HorizontalAlign="Left"></ItemStyle>
                            </asp:TemplateField>
                            <asp:BoundField DataField="Amounts" HeaderText="金額"  HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left"/>
                            <asp:TemplateField HeaderText="可能性" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                <ItemTemplate>
                                    <asp:Label ID="lBPossibility" runat="server" Text='<%#DataBinder.Eval(Container,"DataItem.Possibility") %>'></asp:Label><asp:TextBox
                                        ID="TxtPossibility" Visible="false" class="easyui-numberbox" data-options="min:0,max:100,precision:0,required:true"
                                        Text='<%#DataBinder.Eval(Container,"DataItem.Possibility") %>' runat="server"
                                        Width="30px"></asp:TextBox>%
                                </ItemTemplate>
                                <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                                <ItemStyle HorizontalAlign="Left"></ItemStyle>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="刪除">
                                <ItemTemplate>
                                    <asp:ImageButton ID="BtnDelete" runat="server" ToolTip="刪除" ImageUrl="../Images/ico/trash.png"
                                        CommandName="Delete"></asp:ImageButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                    <div id="busemptyinfo" runat="server" visible="false" style="width: 100%; height: 30px;
                        background-color: #DBE3FF; line-height: 30px; overflow: hidden;">
                        <asp:Image ID="Image2" runat="server" ImageUrl="~/Images/Icons/information.png" />
                        &nbsp;&nbsp;&nbsp; 沒有找到相關業務機會，您可以新建或添加。</div>
                </td>
            </tr>
        </table>
    </div>
    <div id="jihuaMember" runat="server">
        <table width="100%" border="1" cellpadding="0" cellspacing="0" bordercolordark="#FFFFFF"
            bordercolor="#999999">
            <tr>
                <td bgcolor="#E6E6E6" height="30">
                    <asp:Label ID="Label21" Style="vertical-align: middle" runat="server" Text="營銷計劃成員"
                        Height="20px" Font-Bold="True" Font-Size="14px"></asp:Label>
                    &nbsp;&nbsp;<asp:LinkButton ID="LinkNewContact" class="easyui-linkbutton" iconcls="icon-Approve"
                        plain="true" runat="server">新建聯繫人</asp:LinkButton>
                    &nbsp;&nbsp;<asp:LinkButton ID="LinkButton1" class="easyui-linkbutton" iconcls="icon-Approve"
                        plain="true" runat="server">新建潛在客戶</asp:LinkButton>
                    &nbsp;&nbsp; &nbsp;&nbsp;<a id="addcustomer" onclick ="opaddcustom()" class="easyui-linkbutton" iconcls="icon-add"
                        plain="true" >添加現有潛在客戶</a>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:GridView ID="GridPlanMember" runat="server" AutoGenerateColumns="False" Width="100%">
                        <Columns>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:Label ID="LBpkid" Visible="false" runat="server" Text='<%#DataBinder.Eval(Container,"DataItem.pkid") %>'></asp:Label>
                                    <asp:Label ID="LbCustomerPKID" Visible="false" runat="server" Text='<%#DataBinder.Eval(Container,"DataItem.CustomerPKID") %>'></asp:Label>
                                    <asp:Label ID="LbContactPKID" Visible="false" runat="server" Text='<%#DataBinder.Eval(Container,"DataItem.ContactPKID") %>'></asp:Label>
                                    <asp:LinkButton ID="LinkEdit" CommandName="editup" runat="server">編輯</asp:LinkButton>&nbsp;&nbsp;<asp:LinkButton
                                        ID="LinkSave" Visible="false" CommandName="saveup" runat="server">更新</asp:LinkButton>&nbsp;&nbsp;<asp:LinkButton
                                            ID="LinkCancle" runat="server" CommandName="cancleed" Visible="false">取消</asp:LinkButton>&nbsp;&nbsp;
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="Type" HeaderText="成員類型" />
                            <asp:TemplateField HeaderText="狀態">
                                <ItemTemplate>
                                    <asp:Label ID="LbMemberCategory" runat="server" Text='<%#DataBinder.Eval(Container,"DataItem.MemberCategory") %>'></asp:Label>
                                    <asp:DropDownList ID="DPLmembercategory" Visible="false" runat="server">
                                    </asp:DropDownList>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField HeaderText="聯繫人" DataField="ContactName" />
                            <asp:BoundField HeaderText="潛在客戶" DataField="CustomerName" />
                            <asp:TemplateField HeaderText="刪除">
                                <ItemTemplate>
                                    <asp:ImageButton ID="BtnDelete" runat="server" ToolTip="刪除" ImageUrl="../Images/ico/trash.png"
                                        CommandName="Delete"></asp:ImageButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                    <div id="menberemptyinfo" runat="server" visible="false" style="width: 100%; height: 30px;
                        background-color: #DBE3FF; line-height: 30px; overflow: hidden;">
                        <asp:Image ID="Image4" runat="server" ImageUrl="~/Images/Icons/information.png" />
                        &nbsp;&nbsp;&nbsp; 沒有找到相關成員，您可以新建或添加。</div>
                </td>
            </tr>
        </table>
    </div>
    <div id="sysinfo" runat ="server" align="center" >
        
        <table width ="100%">
            <tr>
                <td colspan="2" align ="left" style="font-size: 14px; font-weight: bold"  >
                    &nbsp;系統信息</td>
            </tr>
            <tr>
                <td style="margin-left: 40px">
                    創建人：<asp:Label ID="LbInsertPerson" runat="server"></asp:Label>
                </td>
                <td align="left">
                    上次修改人：<asp:Label ID="LbLastChange" runat="server"></asp:Label>
                </td>
            </tr>
        </table>
        
    </div>
    <div style="display: none">
        <asp:HiddenField ID="HiddenPKID" Value="0" runat="server" />
        <asp:Button ID="Button1" runat="server" Text="Button" />
        <asp:Button ID="Button2" runat="server" Text="Button" />
        </div>
    </form>
</body>
</html>
