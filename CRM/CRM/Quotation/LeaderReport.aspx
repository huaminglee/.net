<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="LeaderReport.aspx.vb"
    Inherits="CRM.LeaderReport" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" type="text/css" href="../CSS/newaction.css" />

    <script src="../NewScript/My97DatePicker/WdatePicker.js" type="text/javascript"></script>

</head>
<body>
    <form id="form1" runat="server">
    <div>
        統計條件： 起始時間：</asp:Label><asp:TextBox ID="TxtStartDate" class="text-input" runat="server"></asp:TextBox>
        結束時間：<asp:TextBox ID="TxtEndDate" class="text-input" runat="server"></asp:TextBox>
        統計單位：<asp:RadioButtonList ID="RadioButtonList1" runat="server" RepeatDirection="Horizontal"
            RepeatLayout="Flow">
            <asp:ListItem Value="5">年</asp:ListItem>
            <asp:ListItem Value="4">季</asp:ListItem>
            <asp:ListItem Value="3">月</asp:ListItem>
            <asp:ListItem Value="2">周</asp:ListItem>
            <asp:ListItem Selected="True" Value="1">日</asp:ListItem>
        </asp:RadioButtonList>
        <asp:Button ID="BtnGet" class="button" runat="server" Text="統計" />
        <asp:Button ID="BtnExcel" runat="server" class="button" Text="導出" />
    </div>
    <div style="clear: both">
    </div>
    <div>
        <table width="100%" border="1" cellpadding="0" cellspacing="0" bordercolordark="#FFFFFF"
            bordercolor="#999999">
            <tr>
                <td bgcolor="#E6E6E6" height="50" width="49%">
                    <asp:Image ID="Image3" runat="server" Style="vertical-align: middle" ImageUrl="~/Images/ico/line.png" />
                    <asp:Label ID="Label8" runat="server" Text="檢測中心報價單金額統計" Font-Bold="True" Font-Size="14px"></asp:Label>
                </td>
                <td>
                    &nbsp;
                </td>
                <td>
                    <asp:Image ID="Image1" runat="server" Style="vertical-align: middle" ImageUrl="~/Images/ico/line2.png" />
                    <asp:Label ID="Label1" runat="server" Text="檢測中心報價數量統計" Font-Bold="True" Font-Size="14px"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Chart ID="Chart1" runat="server" Palette="Berry" BackColor="Silver" ImageType="Png"
                        ImageLocation="~/TempImages/ChartPic_#SEQ(300,3)" Width="400px" Height="296px"
                        BorderDashStyle="Solid" BackGradientStyle="TopBottom" BorderWidth="2" BorderColor="181, 64, 1">
                        <Legends>
                            <asp:Legend Enabled="False" IsTextAutoFit="False" Name="Default" BackColor="Transparent"
                                Font="Trebuchet MS, 8.25pt, style=Bold">
                            </asp:Legend>
                        </Legends>
                        <BorderSkin SkinStyle="Emboss"></BorderSkin>
                        <Series>
                            <asp:Series MarkerSize="8" BorderWidth="3" XValueType="Double" Name="Series1" ChartType="Line"
                                MarkerStyle="Circle" ShadowColor="Black" BorderColor="180, 26, 59, 105" Color="220, 65, 140, 240"
                                ShadowOffset="2" YValueType="Double">
                            </asp:Series>
                        </Series>
                        <ChartAreas>
                            <asp:ChartArea Name="ChartArea1" BorderColor="64, 64, 64, 64" BorderDashStyle="Solid"
                                BackSecondaryColor="White" BackColor="OldLace" ShadowColor="Transparent" BackGradientStyle="TopBottom">
                                <Area3DStyle Rotation="25" Perspective="9" LightStyle="Realistic" Inclination="40"
                                    IsRightAngleAxes="False" WallWidth="3" IsClustered="False" />
                                <AxisY LineColor="64, 64, 64, 64" Title="￥">
                                    <LabelStyle Font="Trebuchet MS, 8.25pt, style=Bold" />
                                    <MajorGrid LineColor="64, 64, 64, 64" />
                                </AxisY>
                                <AxisX LineColor="64, 64, 64, 64" Title="月">
                                    <LabelStyle Font="Trebuchet MS, 8.25pt, style=Bold" />
                                    <MajorGrid LineColor="64, 64, 64, 64" />
                                </AxisX>
                            </asp:ChartArea>
                        </ChartAreas>
                    </asp:Chart>
                </td>
                <td>
                    &nbsp;
                </td>
                <td>
                    &nbsp;
                    <asp:Chart ID="Chart2" runat="server" Palette="Berry" BackColor="DarkGray" ImageType="Png"
                        ImageLocation="~/TempImages/ChartPic_#SEQ(300,3)" Width="400px" Height="296px"
                        BorderDashStyle="Solid" BackGradientStyle="TopBottom" BorderWidth="2" BorderColor="181, 64, 1">
                        <Legends>
                            <asp:Legend Enabled="false" IsTextAutoFit="False" Name="Default" BackColor="Transparent"
                                Font="Trebuchet MS, 8.25pt, style=Bold">
                            </asp:Legend>
                        </Legends>
                        <BorderSkin SkinStyle="Emboss"></BorderSkin>
                        <Series>
                            <asp:Series MarkerSize="8" BorderWidth="3" XValueType="Double" Name="Series1" ChartType="Line"
                                MarkerStyle="Circle" ShadowColor="Black" BorderColor="#990033" Color="#CC0000"
                                ShadowOffset="2" YValueType="Double">
                            </asp:Series>
                        </Series>
                        <ChartAreas>
                            <asp:ChartArea Name="ChartArea1" BorderColor="64, 64, 64, 64" BorderDashStyle="Solid"
                                BackSecondaryColor="White" BackColor="OldLace" ShadowColor="Transparent" BackGradientStyle="TopBottom">
                                <Area3DStyle Rotation="25" Perspective="9" LightStyle="Realistic" Inclination="40"
                                    IsRightAngleAxes="False" WallWidth="3" IsClustered="False" />
                                <AxisY LineColor="64, 64, 64, 64" Title="件">
                                    <LabelStyle Font="Trebuchet MS, 8.25pt, style=Bold" />
                                    <MajorGrid LineColor="64, 64, 64, 64" />
                                </AxisY>
                                <AxisX LineColor="64, 64, 64, 64" Title="月">
                                    <LabelStyle Font="Trebuchet MS, 8.25pt, style=Bold" />
                                    <MajorGrid LineColor="64, 64, 64, 64" />
                                </AxisX>
                            </asp:ChartArea>
                        </ChartAreas>
                    </asp:Chart>
                </td>
            </tr>
        </table>
    </div>
    <div id="emptyinfo" runat="server" visible="false" style="width: 100%; height: 30px;
        background-color: #DBE3FF; line-height: 30px; overflow: hidden;">
        <asp:Image ID="Image2" runat="server" ImageUrl="~/Images/Icons/information.png" />
        &nbsp;&nbsp;&nbsp; 沒有找到相關記錄，請嘗試其他選項。</div>
    <div>
        <asp:Panel ID="Panel1" runat="server">
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" Width="100%"
                ShowFooter="True">
                <Columns>
                    <asp:BoundField DataField="XH" HeaderText="序號" />
                    <asp:BoundField DataField="QuotationNO" HeaderText="報價單號" ItemStyle-HorizontalAlign="Left"
                        HeaderStyle-HorizontalAlign="Left">
                        <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                        <ItemStyle HorizontalAlign="Left"></ItemStyle>
                    </asp:BoundField>
                    <asp:BoundField DataField="QuotaerName" HeaderText="報價人" ItemStyle-HorizontalAlign="Left"
                        HeaderStyle-HorizontalAlign="Left">
                        <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                        <ItemStyle HorizontalAlign="Left"></ItemStyle>
                    </asp:BoundField>
                    <asp:BoundField DataField="CustomerName" HeaderText="公司名" ItemStyle-HorizontalAlign="Left"
                        HeaderStyle-HorizontalAlign="Left">
                        <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                        <ItemStyle HorizontalAlign="Left"></ItemStyle>
                    </asp:BoundField>
                    <asp:BoundField DataField="ContactName" HeaderText="聯繫人" ItemStyle-HorizontalAlign="Left"
                        HeaderStyle-HorizontalAlign="Left">
                        <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                        <ItemStyle HorizontalAlign="Left"></ItemStyle>
                    </asp:BoundField>
                    <asp:BoundField DataField="Shijizongjia" HeaderText="報價" ItemStyle-HorizontalAlign="Left"
                        HeaderStyle-HorizontalAlign="Left">
                        <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                        <ItemStyle HorizontalAlign="Left"></ItemStyle>
                    </asp:BoundField>
                    <asp:BoundField DataField="Paijia" HeaderText="牌價" ItemStyle-HorizontalAlign="Left"
                        HeaderStyle-HorizontalAlign="Left">
                        <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                        <ItemStyle HorizontalAlign="Left"></ItemStyle>
                    </asp:BoundField>
                    <asp:BoundField DataField="youhui" HeaderText="優惠比例" ItemStyle-HorizontalAlign="Left"
                        HeaderStyle-HorizontalAlign="Left">
                        <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                        <ItemStyle HorizontalAlign="Left"></ItemStyle>
                    </asp:BoundField>
                    <asp:BoundField DataField="Extend06" HeaderText="成本價" ItemStyle-HorizontalAlign="Left"
                        HeaderStyle-HorizontalAlign="Left">
                        <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                        <ItemStyle HorizontalAlign="Left"></ItemStyle>
                    </asp:BoundField>
                    <asp:BoundField DataField="profit" HeaderText="利潤率" ItemStyle-HorizontalAlign="Left"
                        HeaderStyle-HorizontalAlign="Left">
                        <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                        <ItemStyle HorizontalAlign="Left"></ItemStyle>
                    </asp:BoundField>
                </Columns>
            </asp:GridView>
        </asp:Panel>
    </div>
    </form>
</body>
</html>
