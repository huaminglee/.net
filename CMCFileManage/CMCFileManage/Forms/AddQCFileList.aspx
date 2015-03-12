<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="AddQCFileList.aspx.vb"
    Inherits="CMCFileManage.AddQCFileList" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<%@ Register Assembly="eFlowWebControl" Namespace="eFlowWebControl" TagPrefix="cc1" %>
<%@ Register Src="../UCtl/GridDept.ascx" TagName="GridDept" TagPrefix="uc1" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../CSS/newaction.css" rel="stylesheet" type="text/css" />
   <%-- <link href="../IconsThemes/icon.css" rel="Stylesheet" type="text/css" />
    <link href="../NewScript/themes/Default/easyui.css" rel="Stylesheet" type="text/css" />

    <script src="../NewScript/UIHelper.js" type="text/javascript"></script>--%>

    <script src="../NewScript/jquery-1.7.2.min.js" type="text/javascript"></script>

  <%--  <script src="../NewScript/jquery.easyui.min.js" type="text/javascript"></script>

    <script type="text/javascript" src="../NewScript/datagrid-detailview.js"></script>

    <script type="text/javascript" src="../NewScript/datagrid-groupview.js"></script>--%>

    <script src="addasgirdview.js" type="text/javascript"></script>

</head>
<body scroll="Auto">
    <form id="form1" runat="server" defaultbutton="Button1">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
     <table width ="100%" ><tr><td> <asp:Image ID="Image3" runat="server" ImageUrl="../Images/blank.jpg" />
    <div id="Divdoaction" style="float: left" runat="server" align="left">
        <table>
            <tr>
                <td class="LiAddqc">
                    <a id="new"  target="MainFrame" href="AddQCFileDetail.aspx">新版發行 </a>
                </td>
                <td  class="Lichangeqc">
                <a href ="#" onclick ="alert('請找到對應的文件在做變更')" >舊版變更</a>
                    <%--<a target="MainFrame"  href="AddQCFileDetail.aspx?ischange=1&Type=1">舊版變更</a>--%>
                </td>
                <td  class="Lizuofeiqc">
                 <a href ="#" onclick ="alert('請找到對應的文件在做變更')" >文件作廢</a>
                    <%--<a target="MainFrame" href="AddQCFileDetail.aspx?ischange=1&Type=3">文件作廢 </a>--%>
                </td>
                <td class="Lizuofeiqc">
                    <a target="MainFrame" href="DownSOP.htm">下載SOP格式 </a></td>
            </tr>
        </table>
    </div>
    <div id="search" style="float: left">
        <ul class="searchli">
            <li>
                <asp:RadioButtonList ID="RadioButtonList1" runat="server" RepeatDirection="Horizontal"
                    RepeatLayout="Flow" AutoPostBack="True">
                    <asp:ListItem Value="0">未結案</asp:ListItem>
                    <asp:ListItem Value="1">已結案</asp:ListItem>
                    <asp:ListItem Selected="True" Value="2">全部</asp:ListItem>
                </asp:RadioButtonList>
            </li>
            <li>
                <asp:TextBox ID="TxtSearchCondition" class="text-input" runat="server" Width="300px"></asp:TextBox></li>
            <li>
                <asp:Button ID="Button1" class="button" runat="server" Text="搜尋" Height="30px" />&nbsp;&nbsp;
            </li>
            <li></li>
            
        </ul>
    </div>
    <div style="clear: both">
    </div>
    <div id="emptyinfo" runat="server" visible="false" style="width: 100%; height: 30px;
        background-color: #DBE3FF; line-height: 30px; overflow: hidden;">
        <asp:Image ID="Image1" runat="server" ImageUrl="~/Images/Icons/information.png" />
        &nbsp;&nbsp;&nbsp; 沒有找到相關記錄，請嘗試其他選項。</div>
    <div>
        <table id="asgridview">
        </table>
       <%-- <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
            <ContentTemplate>--%>
                <asp:Button ID="Button3" Style="display: none" runat="server" Text="Button" />
                <asp:GridView ID="GridViewTop" runat="server" AutoGenerateColumns="False" Width="100%">
                    <Columns>
                        <asp:TemplateField HeaderText="結案狀態" ItemStyle-Width="80px">
                            <ItemTemplate>
                                <asp:Image ID="Image2" runat="server" style="cursor:hand;" ImageUrl="../Images/addGrid.png" />
                                <asp:Label ID="LbIsfinish" runat="server" Text='<%#DataBinder.Eval(Container,"Dataitem.StateName") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <uc1:GridDept ID="GridDept1" runat="server" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="Nums" HeaderText="數量" HeaderStyle-HorizontalAlign="Right"
                            ItemStyle-HorizontalAlign="Right" ItemStyle-Width="50px" />
                    </Columns>
                </asp:GridView>
           <%-- </ContentTemplate>
        </asp:UpdatePanel>--%>
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" Width="100%">
            <Columns>
                <asp:TemplateField>
                    <ItemTemplate>
                        <%--<asp:CheckBox ID="ChkSelect" class="chkselect" runat="server" onclick="SelectSingleCheckBoxClick(window.event);" />--%>
                        <asp:Label ID="LblNo" Width="30px" runat="server" Text="<%# Container.DataItemIndex+1+PageSize*(PageIndex-1)%>"></asp:Label>
                        <asp:Label ID="LblPKID" runat="server" Text='<%# DataBinder.Eval(Container,"DataItem.PKID").ToString() %>'
                            Visible="False"></asp:Label>
                        <asp:Label ID="lblDocUniqueID" runat="server" Text='<%# DataBinder.Eval(Container,"DataItem.eFlowDocID").ToString() %>'
                            Visible="False"></asp:Label>
                        <asp:HyperLink ID="HLDetail" Target="MainFrame" runat="server" ToolTip="編輯" ImageUrl="~/Images/edit.gif">查看</asp:HyperLink>
                    </ItemTemplate>
                    <HeaderTemplate>
                        <%--<asp:CheckBox ID="CheckAll" onclick="CheckChanged()" Text="全選" runat="server" />--%>
                    </HeaderTemplate>
                    <HeaderStyle HorizontalAlign="Left" />
                    <ItemStyle HorizontalAlign="Left" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="文件狀態">
                    <ItemTemplate>
                        <asp:Label ID="LbIsFinish" runat="server" Text='<%# DataBinder.Eval(Container,"DataItem.StateName").ToString() %>'
                            ></asp:Label>
                        <asp:Label ID="Lbshifoujiean" runat="server" Text=""></asp:Label>
                    </ItemTemplate>
                    <HeaderStyle HorizontalAlign="Left" />
                </asp:TemplateField>
                <asp:BoundField DataField="ApplyDept" HeaderText="實驗室">
                    <HeaderStyle HorizontalAlign="Left" />
                </asp:BoundField>
                <asp:BoundField DataField="FileName" HeaderText="文件名">
                    <HeaderStyle HorizontalAlign="Left" />
                </asp:BoundField>
                <asp:BoundField DataField="FileBH" HeaderText="文件號碼">
                    <HeaderStyle HorizontalAlign="Left" />
                </asp:BoundField>
                <asp:BoundField DataField="RecordNO" HeaderText="變更號碼">
                    <HeaderStyle HorizontalAlign="Left" />
                </asp:BoundField>
                <asp:BoundField DataField="FileVersion" HeaderText="REV">
                    <HeaderStyle HorizontalAlign="Left" />
                </asp:BoundField>
                <asp:BoundField DataField="ToTalPage" HeaderText="頁數">
                    <HeaderStyle HorizontalAlign="Left" />
                </asp:BoundField>
                <asp:BoundField DataField="ApplyDate" HeaderText="提案時間" DataFormatString="{0:yyyy-MM-dd}"
                    HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left" />
                <asp:TemplateField HeaderText="生效時間" SortExpression="EffectDate">
                    <ItemTemplate>
                        <asp:Label ID="LblApplyTime" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.EffectDate","{0:yyyy-MM-dd}") %>'></asp:Label>
                    </ItemTemplate>
                    <HeaderStyle Wrap="False" />
                    <HeaderStyle HorizontalAlign="Left" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="數量"></asp:TemplateField>
                <asp:TemplateField Visible="false">
                    <ItemTemplate>
                        <asp:ImageButton ID="BtnDelete" runat="server" ImageUrl="~/Images/Delete.gif" CommandName="Delete">
                        </asp:ImageButton>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>
    <div id="page">
        <cc1:PagerControl ID="PagerControl1" Visible="false" runat="server" SkinID="PagerControlSkin">
        </cc1:PagerControl>
    </div>
    <div style="display: none">
        <asp:Button ID="BtnSetFileCSSHid" runat="server" Text="Button" />
        <asp:Button ID="BtnSetFileCssShow" runat="server" Text="Button" />
        <asp:Button ID="BtnSetCSShidd" runat="server" Text="Button" />
        <asp:Button ID="BtnSetCSSshow" runat="server" Text="Button" />
        <asp:HiddenField ID="Hiddenparenetindex" runat="server" />
        <asp:HiddenField ID="Hiddencursetcssfileindex" runat="server" />
        <asp:HiddenField ID="Hiddencursetcssdeptindex" runat="server" />
        <asp:HiddenField ID="HiddenCurdeptSetCSid" runat="server" />
        <asp:HiddenField ID="HiddenCurType" runat="server" />
        <asp:HiddenField ID="Hiddencurrowindex" runat="server" />
        <asp:HiddenField ID="Hiddencurrowisfi" runat="server" />
        <asp:HiddenField ID="HiddenDeptRowindex" runat="server" />
        <asp:HiddenField ID="HiddenDeptIsfini" runat="server" />
    </div>
    </td> </tr> </table> 
    </form>
</body>
</html>
