<%@ Page Language="vb" AutoEventWireup="false" Theme="Default" CodeBehind="QCFileList.aspx.vb"
    Inherits="CMCFileManage.QCFileList" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<%@ Register Assembly="eFlowWebControl" Namespace="eFlowWebControl" TagPrefix="cc1" %>
<%@ Register Src="../UCtl/GridCategory.ascx" TagName="GridCategory" TagPrefix="uc1" %>
<%@ Register Src="../UCtl/GridFile.ascx" TagName="GridFile" TagPrefix="uc2" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <link href="../CSS/newaction.css" rel="stylesheet" type="text/css" />
    <%-- <link href="../IconsThemes/icon.css" rel="Stylesheet" type="text/css" />
    <link href="../NewScript/themes/Default/easyui.css" rel="Stylesheet" type="text/css" />

    <script src="../NewScript/UIHelper.js" type="text/javascript"></script>
--%>

    <script src="../NewScript/jquery-1.7.2.min.js" type="text/javascript"></script>

    <%-- <script src="../NewScript/jquery.easyui.min.js" type="text/javascript"></script>

    <script type="text/javascript" src="../NewScript/datagrid-detailview.js"></script>

    <script type="text/javascript" src="../NewScript/datagrid-groupview.js"></script>--%>

    <script src="qcgridview.js" type="text/javascript"></script>

    <script src="QCfileList.js" type="text/javascript"></script>

    <script type="text/javascript">
        $(document).ready(function() {
            //  zhedie();
        });
        function zhedie() {
            var index = 1;
            var strSex = "";
            var pertotal = 0;
            var type = $('#HiddenType').val();
            $.each($('#GridView1 tr'), function(t, own) {
                if (index == t) {
                    strSex = $(own).children().get(0).innerText;
                    if (type == 10) {
                        $(own).html("<td bgcolor='#D7E3FF' width='10%' class='GroupExp' ></td><td bgcolor='#D7E3FF'></td><td bgcolor='#D7E3FF'></td><td bgcolor='#D7E3FF'></td><td bgcolor='#D7E3FF'></td><td  bgcolor='#D7E3FF'></td><td  bgcolor='#D7E3FF'></td><td  bgcolor='#D7E3FF'></td><td  bgcolor='#D7E3FF'></td><td  bgcolor='#D7E3FF'></td><td  bgcolor='#D7E3FF'></td>");
                    }
                    else if (type == 9) {
                        $(own).html("<td bgcolor='#D7E3FF' width='10%' class='GroupExp' ></td><td bgcolor='#D7E3FF'></td><td bgcolor='#D7E3FF'></td><td bgcolor='#D7E3FF'></td><td bgcolor='#D7E3FF'></td><td  bgcolor='#D7E3FF'></td><td  bgcolor='#D7E3FF'></td><td  bgcolor='#D7E3FF'></td><td  bgcolor='#D7E3FF'></td><td  bgcolor='#D7E3FF'></td>");
                    }

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
                            $(".rows_" + index).children('td').get(type).innerHTML = pertotal
                            pertotal = 0;
                            index = t;
                            strSex = $(own).children().get(0).innerText;
                            if (type == 10) {
                                $(own).html("<td bgcolor='#D7E3FF' width='10%' class='GroupExp' ></td><td bgcolor='#D7E3FF'></td><td bgcolor='#D7E3FF'></td><td bgcolor='#D7E3FF'></td><td bgcolor='#D7E3FF'></td><td  bgcolor='#D7E3FF'></td><td  bgcolor='#D7E3FF'></td><td  bgcolor='#D7E3FF'></td><td  bgcolor='#D7E3FF'></td><td  bgcolor='#D7E3FF'></td><td  bgcolor='#D7E3FF'></td>");
                            }
                            else if (type == 9) {
                                $(own).html("<td bgcolor='#D7E3FF' width='10%' class='GroupExp' ></td><td bgcolor='#D7E3FF'></td><td bgcolor='#D7E3FF'></td><td bgcolor='#D7E3FF'></td><td bgcolor='#D7E3FF'></td><td  bgcolor='#D7E3FF'></td><td  bgcolor='#D7E3FF'></td><td  bgcolor='#D7E3FF'></td><td  bgcolor='#D7E3FF'></td><td  bgcolor='#D7E3FF'></td>");
                            }
                            $(own).addClass("rows_" + index);
                            $(own).children('td').get(0).innerHTML = "<a   href='#' onclick=\"ShowDetail('rows_" + index + "_child','rows_" + index + "')\"><font color='red'>+</font>" + strSex + "</a>";
                        }
                        else {
                            $(".rows_" + index).children('td').get(type).innerHTML = "" + pertotal;
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
            parent.iFrameHeight();
        }
    </script>

</head>
<body scroll="Auto">
    <form id="form1" runat="server" defaultbutton="Button1">
    <table width="100%">
        <tr>
            <td>
                <asp:Image ID="Image3" runat="server" ImageUrl="../Images/blank.jpg" />
                <div id="search" style="padding: 0px; margin: 0px; float: left; left: 0px;">
                    <ul class="searchli">
                        <li>
                            <asp:TextBox ID="TxtSearchCondition" class="text-input" runat="server" Width="500px"></asp:TextBox></li>
                        <li>
                            <asp:Button ID="Button1" class="button" runat="server" Text="搜尋" Height="30px" /></li>
                    </ul>
                </div>
                <div style="clear: both">
                </div>
                <div id="emptyinfo" runat="server" visible="false" style="width: 100%; height: 30px;
                    background-color: #DBE3FF; line-height: 30px; overflow: hidden;">
                    <asp:Image ID="Image1" runat="server" ImageUrl="~/Images/Icons/information.png" />
                    &nbsp;&nbsp;&nbsp; 沒有找到相關記錄，請嘗試其他選項。</div>
                <div id="sanjie">
                    <asp:GridView ID="GridViewDept" runat="server" AutoGenerateColumns="False" Width="100%">
                        <Columns>
                            <asp:TemplateField HeaderText="實驗室">
                                <ItemTemplate>
                                    <asp:Image ID="Image2" runat="server" Style="cursor: hand;" ImageUrl="../Images/addGrid.png" />
                                    <asp:Label ID="LbApplydept" runat="server" Text='<%#DataBinder.Eval(Container,"Dataitem.ApplyDept") %>'></asp:Label>
                                </ItemTemplate>
                                <ItemStyle Width="150px" />
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <uc1:GridCategory ID="GridCategory1" runat="server" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="Nums" HeaderText="數量" ItemStyle-Width="50px">
                                <HeaderStyle HorizontalAlign="Right" />
                                <ItemStyle HorizontalAlign="Right" />
                            </asp:BoundField>
                        </Columns>
                    </asp:GridView>
                </div>
                <div id="sijie">
                    <asp:GridView ID="GridViewSiTop" runat="server" AutoGenerateColumns="False" Width="100%">
                        <Columns>
                            <asp:TemplateField HeaderText="實驗室" ItemStyle-Width="150px" ItemStyle-HorizontalAlign="Left"
                                HeaderStyle-HorizontalAlign="Left">
                                <ItemTemplate>
                                    <asp:Image ID="Image1" runat="server" Style="cursor: hand;" ImageUrl="../Images/addGrid.png" />
                                    <asp:Label ID="LbApplydept" runat="server" Text='<%#DataBinder.Eval(Container,"Dataitem.ApplyDept") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <uc2:GridFile ID="GridFile1" runat="server" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="Nums" HeaderText="數量" HeaderStyle-HorizontalAlign="Right"
                                ItemStyle-Width="50px" ItemStyle-HorizontalAlign="Right" />
                        </Columns>
                    </asp:GridView>
                </div>
                <div>
                    <%-- <table id="asgridview">
        </table>--%>
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
                                    <asp:HyperLink ID="HLDetail" Visible="false" Target="MainFrame" runat="server" ToolTip="編輯"
                                        ImageUrl="~/Images/edit.gif">查看</asp:HyperLink>
                                </ItemTemplate>
                                <HeaderStyle HorizontalAlign="Left" />
                                <ItemStyle HorizontalAlign="Left" />
                            </asp:TemplateField>
                            <asp:BoundField DataField="FileLayer" HeaderText="文件階層">
                                <HeaderStyle HorizontalAlign="Left" />
                            </asp:BoundField>
                            <asp:BoundField DataField="ApplyDept" HeaderText="實驗室">
                                <HeaderStyle HorizontalAlign="Left" />
                            </asp:BoundField>
                            <asp:TemplateField HeaderText="文件類別">
                                <ItemTemplate>
                                    <asp:Label ID="LbFileCategoreINT" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.FileCategory") %>'></asp:Label>
                                    <asp:Label ID="LbFileCategorySTR" runat="server" Text=""></asp:Label>
                                </ItemTemplate>
                                <HeaderStyle Wrap="False" />
                                <HeaderStyle HorizontalAlign="Left" />
                            </asp:TemplateField>
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
                            <asp:TemplateField HeaderText="生效時間" SortExpression="EffectDate">
                                <ItemTemplate>
                                    <asp:Label ID="LblApplyTime" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.EffectDate","{0:yyyy-MM-dd}") %>'></asp:Label>
                                </ItemTemplate>
                                <HeaderStyle Wrap="False" />
                                <HeaderStyle HorizontalAlign="Left" />
                            </asp:TemplateField>
                            <asp:BoundField HeaderText="數量" />
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
                    <asp:Button ID="Button3" runat="server" Text="Button" />
                    <asp:Button ID="BtnSetCSShidd" runat="server" Text="Button" />
                    <asp:Button ID="BtnSetCSSshow" runat="server" Text="Button" />
                    <asp:Button ID="BtnSetFileCssShow" runat="server" Text="Button" />
                    <asp:Button ID="BtnSetFileCSSHid" runat="server" Text="Button" />
                    <asp:HiddenField ID="Hiddencursetcsscategoryindex" runat="server" />
                    <asp:HiddenField ID="Hiddencursetcssfileindex" runat="server" />
                    <asp:HiddenField ID="Hiddenparenetindex" runat="server" />
                    <asp:HiddenField ID="HiddenCategoryRowindex" runat="server" />
                    <asp:HiddenField ID="HiddenType" runat="server" />
                    <asp:HiddenField ID="HiddenCurType" runat="server" />
                    <asp:HiddenField ID="Hiddencurrowindex" runat="server" />
                    <asp:HiddenField ID="Hiddencurdeptname" runat="server" />
                </div>
            </td>
        </tr>
    </table>
    </form>
</body>
</html>
