<%@ Page Language="vb" AutoEventWireup="false" Theme="Default" CodeBehind="SuppliersList.aspx.vb"
    Inherits="CMCFileManage.SuppliersList" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<%@ Register Assembly="eFlowWebControl" Namespace="eFlowWebControl" TagPrefix="cc1" %>
<%@ Register Src="../UCtl/GridSuppli.ascx" TagName="GridSuppli" TagPrefix="uc1" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../CSS/newaction.css" rel="stylesheet" type="text/css" />

    <script src="../NewScript/jquery-1.7.2.min.js" type="text/javascript"></script>

    <script src="supplilist.js" type="text/javascript"></script>

    <script type="text/javascript">
        function zhedie() {
            var index = 1;
            var strSex = "";
            var pertotal = 0;
            $.each($('#GridView1 tr'), function(t, own) {
                if (index == t) {
                    strSex = $(own).children().get(0).innerText;

                    $(own).html("<td bgcolor='#D7E3FF' width='10%' class='GroupExp' ></td><td bgcolor='#D7E3FF'></td><td bgcolor='#D7E3FF'></td><td bgcolor='#D7E3FF'></td><td bgcolor='#D7E3FF'></td><td  bgcolor='#D7E3FF'></td><td  bgcolor='#D7E3FF'></td><td  bgcolor='#D7E3FF'></td><td  bgcolor='#D7E3FF'></td><td  bgcolor='#D7E3FF'></td><td  bgcolor='#D7E3FF'></td><td  bgcolor='#D7E3FF'></td><td  bgcolor='#D7E3FF'></td>");

                    $(own).addClass("rows_" + index);
                    $(own).children('td').get(0).innerHTML = "<a  href='#'  onclick=\"ShowDetail('rows_" + index + "_child','rows_" + index + "')\"><font color='red'>+</font>" + strSex + "</a>";
                }
                else if (t > 0) {
                    if (!isNaN($(own).children().get(0).innerText) && ($(own).children().get(0).innerText) != " ") {   //如果分組依據為數字則失效
                        $(own).addClass("rows_" + index + "_child");
                        pertotal += 1;
                        $(own).hide();
                    }
                    else {
                        if (($(own).children().get(0).innerText) != " ") {
                            $(".rows_" + index).children('td').get(11).innerHTML = pertotal
                            pertotal = 0;
                            index = t;
                            strSex = $(own).children().get(0).innerText;
                            $(own).html("<td bgcolor='#D7E3FF' width='10%' class='GroupExp' ></td><td bgcolor='#D7E3FF'></td><td bgcolor='#D7E3FF'></td><td bgcolor='#D7E3FF'></td><td bgcolor='#D7E3FF'></td><td  bgcolor='#D7E3FF'></td><td  bgcolor='#D7E3FF'></td><td  bgcolor='#D7E3FF'></td><td  bgcolor='#D7E3FF'></td><td  bgcolor='#D7E3FF'></td><td  bgcolor='#D7E3FF'></td><td  bgcolor='#D7E3FF'></td><td  bgcolor='#D7E3FF'></td>");
                            $(own).addClass("rows_" + index);
                            $(own).children('td').get(0).innerHTML = "<a   href='#' onclick=\"ShowDetail('rows_" + index + "_child','rows_" + index + "')\"><font color='red'>+</font>" + strSex + "</a>";
                        }
                        else {
                            $(".rows_" + index).children('td').get(11).innerHTML = "" + pertotal;
                        }
                    }
                }
            })

        }
        function ShowDetail(classname, moname) {
            strSex = $("." + moname).children('td').get(0).innerText;
            if (strSex.substring(0, 1) == "+") {
                strSex = strSex.substring(1, strSex.length);
                $("." + moname).children('td').get(0).innerHTML = "<a   href='#' onclick=\"ShowDetail('" + classname + "','" + moname + "')\"><font color='red'>-</font>" + strSex + "</a>";

            }
            else {
                strSex = strSex.substring(1, strSex.length);
                $("." + moname).children('td').get(0).innerHTML = "<a   href='#' onclick=\"ShowDetail('" + classname + "','" + moname + "')\"><font color='red'>+</font>" + strSex + "</a>";

            }


            var size = $("." + classname).size();
            if (size > 0) {
                $("." + classname).toggle();
            }
        }
    </script>

</head>
<body>
    <form id="form1" runat="server" defaultbutton="Button1">
    <table width="100%">
        <tr>
            <td>
                <asp:Image ID="Image3" runat="server" ImageUrl="../Images/blank.jpg" />
                <div id="search">
                    <ul class="searchli">
                        <li id="add" runat="server" class="LiAdd"><a id="addnew" runat="server" target="MainFrame"
                            href="#">新增文件</a></li>
                        <li>
                            <asp:RadioButtonList ID="RadioButtonList1" runat="server" AutoPostBack="True" Height="30px"
                                RepeatDirection="Horizontal">
                                <asp:ListItem Selected="True">全部</asp:ListItem>
                                <asp:ListItem>交易中</asp:ListItem>
                                <asp:ListItem>已凍結</asp:ListItem>
                            </asp:RadioButtonList>
                        </li>
                        <li>
                            <asp:TextBox ID="TxtSearchCondition" class="text-input" runat="server" Width="500px"></asp:TextBox></li>
                        <li>
                            <asp:Button ID="Button1" class="button" runat="server" Text="搜尋" Height="30px" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        </li>
                        <li>
                            <asp:Button ID="Button2" Visible="false" class="button" runat="server" Text="按實驗室分組顯示"
                                Height="30px" />
                        </li>
                    </ul>
                </div>
                <div>
                    <asp:GridView ID="GridViewTop" runat="server" AutoGenerateColumns="False" Width="100%">
                        <Columns>
                            <asp:TemplateField HeaderText="實驗室" ItemStyle-Width="170px" ItemStyle-HorizontalAlign="Left"
                                HeaderStyle-HorizontalAlign="Left">
                                <ItemTemplate>
                                    <asp:Image ID="Image1" runat="server" Style="cursor: hand;" ImageUrl="../Images/addGrid.png" />
                                    <asp:Label ID="LbApplydept" runat="server" Text='<%#DataBinder.Eval(Container,"Dataitem.BelongLab") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <uc1:GridSuppli ID="GridSuppli1" runat="server" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="Nums" HeaderText="數量" HeaderStyle-HorizontalAlign="Right"
                                ItemStyle-Width="50px" ItemStyle-HorizontalAlign="Right" />
                        </Columns>
                    </asp:GridView>
                </div>
                <div style="clear: both">
                </div>
                <br />
                <div id="emptyinfo" runat="server" visible="false" style="width: 100%; height: 30px;
                    background-color: #DBE3FF; line-height: 30px; overflow: hidden;">
                    <asp:Image ID="Image1" runat="server" ImageUrl="~/Images/Icons/information.png" />
                    &nbsp;&nbsp;&nbsp; 沒有找到相關記錄，請嘗試其他選項。</div>
                <div>
                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" Width="100%"
                        ShowFooter="True">
                        <Columns>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:Label ID="LblNo" Width="30px" runat="server" Text="<%# Container.DataItemIndex+1+PageSize*(PageIndex-1)%>"></asp:Label>
                                    <asp:Label ID="LblPKID" runat="server" Text='<%# DataBinder.Eval(Container,"DataItem.PKID").ToString() %>'
                                        Visible="False"></asp:Label>
                                    <asp:Label ID="lblDocUniqueID" runat="server" Text='<%# DataBinder.Eval(Container,"DataItem.eFlowDocID").ToString() %>'
                                        Visible="False"></asp:Label>
                                    <asp:HyperLink ID="HLDetail" Target="MainFrame" runat="server" ToolTip="查看" ImageUrl="~/Images/edit.gif">查看</asp:HyperLink>
                                </ItemTemplate>
                                <HeaderStyle HorizontalAlign="Left" />
                                <ItemStyle HorizontalAlign="Left" />
                            </asp:TemplateField>
                            <asp:BoundField DataField="SupplierName" HeaderText="供應商名稱" ItemStyle-HorizontalAlign="Left"
                                HeaderStyle-HorizontalAlign="Left">
                                <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                                <ItemStyle HorizontalAlign="Left"></ItemStyle>
                            </asp:BoundField>
                            <asp:BoundField DataField="ContactName" HeaderText="聯繫人" ItemStyle-HorizontalAlign="Left"
                                HeaderStyle-HorizontalAlign="Left">
                                <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                                <ItemStyle HorizontalAlign="Left"></ItemStyle>
                            </asp:BoundField>
                            <asp:BoundField DataField="ContactPhone" HeaderText="聯繫電話" ItemStyle-HorizontalAlign="Left"
                                HeaderStyle-HorizontalAlign="Left">
                                <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                                <ItemStyle HorizontalAlign="Left"></ItemStyle>
                            </asp:BoundField>
                            <asp:BoundField DataField="BelongLab" HeaderText="所屬實驗室" ItemStyle-HorizontalAlign="Left"
                                HeaderStyle-HorizontalAlign="Left">
                                <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                                <ItemStyle HorizontalAlign="Left"></ItemStyle>
                            </asp:BoundField>
                            <asp:BoundField DataField="Address" HeaderText="地址" ItemStyle-HorizontalAlign="Left"
                                HeaderStyle-HorizontalAlign="Left">
                                <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                                <ItemStyle HorizontalAlign="Left"></ItemStyle>
                            </asp:BoundField>
                            <asp:BoundField DataField="Industry" HeaderText="經營項目" ItemStyle-HorizontalAlign="Left"
                                HeaderStyle-HorizontalAlign="Left">
                                <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                                <ItemStyle HorizontalAlign="Left"></ItemStyle>
                            </asp:BoundField>
                            <asp:BoundField DataField="SupplierShortName" HeaderText="簡稱" ItemStyle-HorizontalAlign="Left"
                                HeaderStyle-HorizontalAlign="Left">
                                <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                                <ItemStyle HorizontalAlign="Left"></ItemStyle>
                            </asp:BoundField>
                            <asp:BoundField DataField="Assessor" HeaderText="評估人" ItemStyle-HorizontalAlign="Left"
                                HeaderStyle-HorizontalAlign="Left">
                                <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                                <ItemStyle HorizontalAlign="Left"></ItemStyle>
                            </asp:BoundField>
                            <asp:BoundField DataField="AssessDate" HeaderText="評估日期" ItemStyle-HorizontalAlign="Left"
                                HeaderStyle-HorizontalAlign="Left" DataFormatString='{0:yy-MM-dd}'>
                                <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                                <ItemStyle HorizontalAlign="Left"></ItemStyle>
                            </asp:BoundField>
                            <asp:BoundField DataField="AssessCycle" HeaderText="評估週期" ItemStyle-HorizontalAlign="Left"
                                HeaderStyle-HorizontalAlign="Left">
                                <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                                <ItemStyle HorizontalAlign="Left"></ItemStyle>
                            </asp:BoundField>
                            <asp:TemplateField HeaderText="數量"></asp:TemplateField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:ImageButton ID="BtnDelete" runat="server" ImageUrl="~/Images/Delete.gif" CommandName="Delete">
                                    </asp:ImageButton>
                                </ItemTemplate>
                                <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                                <ItemStyle HorizontalAlign="Left"></ItemStyle>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </div>
                <div id="page">
                    <cc1:PagerControl ID="PagerControl1" Visible="false" runat="server" SkinID="PagerControlSkin">
                    </cc1:PagerControl>
                </div>
                <div style="display: none">
                    <asp:Button ID="BtnFourcssShoe" runat="server" Text="Button" /><asp:Button ID="BtnFourcssHid"
                        runat="server" Text="Button" />
                    <asp:HiddenField ID="Hiddensetcssfourfileindex" runat="server" />
                    <asp:Button ID="BtnBindSiBydeptname" runat="server" Text="Button" />
                    <asp:HiddenField ID="Hiddencurrowindex" runat="server" />
                    <asp:HiddenField ID="Hiddencurdeptname" runat="server" />
                </div>
            </td>
        </tr>
    </table>
    </form>
</body>
</html>
