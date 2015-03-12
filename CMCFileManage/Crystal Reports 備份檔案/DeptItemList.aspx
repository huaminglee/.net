<%@ Page Language="vb" AutoEventWireup="false" Theme="Default" CodeBehind="DeptItemList.aspx.vb"
    Inherits="CMCFileManage.DeptItemList" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="Styles/CSIStyles.css" rel="stylesheet" type="text/css" />
    <link href="../CSS/newaction.css" rel="stylesheet" type="text/css" />

    <script src="DeptItem.js" type="text/javascript"></script>

    <%-- <style type="text/css">
        html
        {
            overflow: hidden;
        }
        body
        {
            background: white;
        }
        #menu
        {
            padding: 10px;
            background: white;
            height: 800px;
            width: 10%;
        }
        #menu a
        {
            display: block;
            text-decoration: none;
            font-family: arial, helvetica, verdana, sans-serif;
            white-space: nowrap;
        }
    </style>

    <script type="text/javascript"><!--
        var P, T;
        var over = -1;

        ///////////////
        var fontSize = 19;
        var lensFX = 1;
        var num = true;
        var color = "black";
        var selected = "#F80";
        ///////////////

        function zoom(s) {
            if (s != over) {
                over = s;
                for (var i = 0; i < T; i++) {
                    P[i].style.fontSize = Math.floor(fontSize / (Math.abs(i - s) + lensFX) + 12) + "px";
                    P[i].style.color = (i == s) ? selected : color;
                }
            }
        }

        onload = function() {
            P = document.getElementById("menu").getElementsByTagName("a");
            T = P.length;
            for (var i = 0; i < T; i++) {
                if (num) {
                    x = i + ".";
                    if (x.length < 3) x = "0" + x;
                    P[i].innerHTML = x + P[i].innerHTML;
                }
                P[i].style.width = "100%";
                P[i].onmouseover = new Function("zoom(" + i + ");");
            }
            zoom(0);
        }
//-->
    </script>--%>
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div>
                <table width="100%">
                    <tr>
                        <td width="150px">
                            &nbsp;
                        </td>
                        <td align="center" valign="top">
                            <asp:Label ID="Lbtitle" runat="server" Font-Size="20px" ForeColor="#009933"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td width="150px">
                            <div id="menu">
                                <asp:DataList ID="DataList1" runat="server">
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
                            </div>
                        </td>
                        <td valign="top">
                            <div>
                                <li class="LiAdd"><a id="A1" href="javascript:Addnew()" style="width: 70px; float: left;"
                                    runat="server"><span>新增項目 </a></li>
                                <div style="clear: both">
                                </div>
                                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" Width="100%"
                                    EmptyDataText="無調查項目">
                                    <Columns>
                                        <asp:TemplateField>
                                            <ItemTemplate>
                                                <asp:HyperLink ID="HLDetail" Target="MainFrame" runat="server" ToolTip="編輯" ImageUrl="~/Images/pen.png">查看</asp:HyperLink>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="ItemName" HeaderText="項目名稱" HeaderStyle-HorizontalAlign="Left">
                                            <HeaderStyle HorizontalAlign="Left" />
                                        </asp:BoundField>
                                        <asp:TemplateField>
                                            <ItemTemplate>
                                                <asp:ImageButton ID="BtnDelete" runat="server" ImageUrl="~/Images/trash.png" CommandName="Delete">
                                                </asp:ImageButton>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                            </div>
                        </td>
                    </tr>
                </table>
            </div>
            <div style="display: none">
                <asp:Button ID="btn1" runat="server" Text="Button" />
                <asp:HiddenField ID="HidDeptPKID" Value="0" runat="server" />
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>
