<%@ Page Language="vb" AutoEventWireup="false" Theme ="Default"  CodeBehind="SysNewsList.aspx.vb" Inherits="CMCFileManage.SysNewsList" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<%@ Register Assembly="eFlowWebControl" Namespace="eFlowWebControl" TagPrefix="cc1" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>最新消息</title>
    <meta http-equiv="Content-Type" content="text/html; charset=UTF-8" />
    <link href="../IconsThemes/icon.css" rel="Stylesheet" type="text/css" />
    <link href="../NewScript/themes/Default/easyui.css" rel="stylesheet" type="text/css" />

    <script type="text/javascript" src="../NewScript/jquery-1.7.2.min.js"></script>

    <script src="../NewScript/jquery.easyui.min.js" type="text/javascript"></script>

    <script type="text/javascript" defer="defer" src="../NewScript/easyloader.js"></script>

    <script type="text/javascript" defer="defer" src="../NewScript/UIHelper.js"></script>

    <script type="text/javascript" defer="defer" src="../NewScript/My97DatePicker/WdatePicker.js"></script>

    <script type="text/javascript">

        $(function() {
            $('#LinkSearch').click(function() {


                var StartDateSearch = $('#TxtStartTime').val();
                var EndDateSearch = $('#TxtEndTime').val();

                if (StartDateSearch != '' && EndDateSearch != '') {

                    return true;

                }
                else if ($('#TxtTitle').val() != '') {
                    return true;
                }
                else

                { $('#lblErrorInfo').html("請輸入查詢條件"); return false; }
            });

        });
        
    </script>

    <style type="text/css">
        .style1
        {
            width: 100%;
        }
    </style>
</head>
<body scroll="Auto">
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div id="PageContainer">
        <table  width ="100%">
            <tr>
                <td>
                    <asp:LinkButton ID="NewItem" Visible ="false"  class="easyui-linkbutton" plain="true" iconCls="icon-add"
                        runat="server">新增</asp:LinkButton>
                    <asp:LinkButton ID="LinkDelete" Visible ="false" class="easyui-linkbutton" plain="true" iconCls="icon-no"
                        runat="server">刪除</asp:LinkButton>
                </td>
            </tr>
            <tr>
                <td>
                    主題:<asp:TextBox ID="TxtTitle" runat="server"></asp:TextBox>
                    發佈日期:<asp:TextBox ID="TxtStartTime" runat="server"></asp:TextBox>到
                    <asp:TextBox ID="TxtEndTime" runat="server"></asp:TextBox>
                    <asp:LinkButton ID="LinkSearch" class="easyui-linkbutton" plain="true" iconCls="icon-search"
                        runat="server">查詢</asp:LinkButton>
                    <asp:Label ID="lblErrorInfo" runat="server" EnableViewState="False" ForeColor="Red"></asp:Label>
                </td>
            </tr>
        </table>
    </div>
    <div style="clear: both;">
    </div>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div >
                <asp:GridView ID="GridView1" EmptyDataText="無數據" EmptyDataRowStyle-ForeColor="Red"
                    runat="server" AutoGenerateColumns="False" Width="100%" AllowSorting="True">
                    <HeaderStyle HorizontalAlign="Center" />
                    <RowStyle HorizontalAlign="Center" />
                    <Columns>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:CheckBox ID="ChkSelect" Visible ="false"   runat="server" />
                                <asp:HyperLink ID="HLDetail" runat="server" ToolTip ="查看" ImageUrl="~/Images/edit.gif" Target="_self"></asp:HyperLink>
                            </ItemTemplate>
                            <HeaderTemplate>
                                <asp:CheckBox ID="CheckAll" Visible ="false"  Text="全選" runat="server" />
                            </HeaderTemplate>
                            <HeaderStyle HorizontalAlign="Left" />
                            <ItemStyle HorizontalAlign="Left" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="刪除" Visible ="false">
                            <ItemTemplate>
                                <asp:ImageButton ID="BtnDelete" runat="server" ImageUrl="~/Images/Delete.gif"
                                    CommandName="Delete"></asp:ImageButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="NewSid" HeaderText="消息编号" />
                        <asp:BoundField DataField="NewTitle" HeaderText="消息主題" />
                        <asp:BoundField DataField="CreateUser" HeaderText="新增人員" />
                        <asp:BoundField DataField="RecordCreated" HeaderText="創建時間" DataFormatString="{0:yyyy-MM-dd HH:mm}" />
                    </Columns>
                </asp:GridView>
            </div>
            <div class="Pager">
                <cc1:PagerControl ID="PagerControl1" runat="server">
                </cc1:PagerControl>
            </div>
        </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="LinkSearch" />
            <asp:AsyncPostBackTrigger ControlID="LinkDelete" />
        </Triggers>
    </asp:UpdatePanel>
    </div>
    </form>
</body>
</html>
