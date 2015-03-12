<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Statistics.aspx.vb" Inherits="CRM.Statistics" %>

<%@ Register Assembly="System.Web.DataVisualization, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../CSS/newaction.css" rel="stylesheet" type="text/css" />

    <script src="../NewScript/My97DatePicker/WdatePicker.js" type="text/javascript"></script>

    </head>
<body>
    <form id="form1" runat="server">
    <div>
        <table>
            <tr>
                <td style="margin-left: 40px">
                    起始時間<asp:TextBox ID="TxtStartDate" class="text-input" runat="server"></asp:TextBox>
                </td>
                <td>
                    結束時間<asp:TextBox ID="TxtEndDate" class="text-input" runat="server"></asp:TextBox>
                </td>
                <td>
                    業務員<asp:DropDownList ID="DPLQuoter" runat="server" Width="150">
                    </asp:DropDownList>
                </td>
                <td>
                    客戶<asp:TextBox ID="TxtCustomers" class="text-input" runat="server"></asp:TextBox>
                </td>
                <td>
                    </td>
                <td>
                    <asp:Button ID="BtnSearch" class="button" runat="server" Text="搜尋" />
                    <asp:Button ID="BtnExcel" class="button" runat="server" Text="導出" />
                </td>
            </tr>
        </table>
    </div>
   
    <div>
        <table width="100%" border="1" cellpadding="0" cellspacing="0" bordercolordark="#FFFFFF"
            bordercolor="#999999">
            <tr>
                <td bgcolor="#E6E6E6" height="50" width="49%">
                    <asp:Image ID="Image3" runat="server" Style="vertical-align: middle" 
                        ImageUrl="~/Images/ico/percent.png" />
                    <asp:Label ID="Label8" runat="server" Text="客戶測試比例" Font-Bold="True" Font-Size="14px"></asp:Label>
                </td>
                <td >
                    &nbsp;</td>
                <td bgcolor="#E6E6E6" height="50" width="49%">
                    <asp:Image ID="Image2" runat="server" Style="vertical-align: middle" 
                        ImageUrl="~/Images/ico/percent2.png" />
                    <asp:Label ID="Label1" runat="server" Text="測試項目比例" Font-Bold="True" Font-Size="14px"></asp:Label>
                </td>
            </tr>
            <tr>
                <td width="400px">
                    <asp:Chart ID="Chart2" runat="server" Palette="SeaGreen" BackColor="DarkGray"
                        Height="296px" Width="400px" BorderDashStyle="Solid" BackGradientStyle="TopBottom"
                        BorderWidth="2" BorderColor="26, 59, 105" IsSoftShadows="False" 
                        ImageLocation="~/TempImages/ChartPic_#SEQ(300,3)">
                        <Legends>
                            <asp:Legend TitleFont="Microsoft Sans Serif, 8pt, style=Bold" BackColor="Transparent"
                                IsEquallySpacedItems="True" Font="Trebuchet MS, 8pt, style=Bold" IsTextAutoFit="False"
                                Name="Default">
                            </asp:Legend>
                        </Legends>
                        <BorderSkin SkinStyle="Emboss"></BorderSkin>
                        <Series>
                            <asp:Series ChartArea="Area1" XValueType="Double" Name="Series1" ChartType="Pie"
                                Font="Trebuchet MS, 8.25pt, style=Bold" CustomProperties="DoughnutRadius=25, PieDrawingStyle=Concave, CollectedLabel=Other, MinimumRelativePieSize=20"
                                MarkerStyle="Circle" BorderColor="64, 64, 64, 64" Color="180, 65, 140, 240" YValueType="Double"
                                Label="#PERCENT{P1}">
                              
                            </asp:Series>
                        </Series>
                        <ChartAreas>
                            <asp:ChartArea Name="Area1" BorderColor="64, 64, 64, 64" BackSecondaryColor="Transparent"
                                BackColor="Transparent" ShadowColor="Transparent" BackGradientStyle="TopBottom">
                                <AxisY2>
                                    <MajorGrid Enabled="False" />
                                    <MajorTickMark Enabled="False" />
                                </AxisY2>
                                <AxisX2>
                                    <MajorGrid Enabled="False" />
                                    <MajorTickMark Enabled="False" />
                                </AxisX2>
                                <Area3DStyle PointGapDepth="900" Rotation="162" IsRightAngleAxes="False" WallWidth="25"
                                    IsClustered="False" />
                                <AxisY LineColor="64, 64, 64, 64">
                                    <LabelStyle Font="Trebuchet MS, 8.25pt, style=Bold" />
                                    <MajorGrid LineColor="64, 64, 64, 64" Enabled="False" />
                                    <MajorTickMark Enabled="False" />
                                </AxisY>
                                <AxisX LineColor="64, 64, 64, 64">
                                    <LabelStyle Font="Trebuchet MS, 8.25pt, style=Bold" />
                                    <MajorGrid LineColor="64, 64, 64, 64" Enabled="False" />
                                    <MajorTickMark Enabled="False" />
                                </AxisX>
                            </asp:ChartArea>
                        </ChartAreas>
                    </asp:Chart>
                </td>
                <td >
                    &nbsp;</td>
                <td>
                    &nbsp;
                    <asp:Chart ID="Chart3" runat="server" Palette="SemiTransparent" BackColor="DarkGray"
                        Height="296px" Width="400px" BorderDashStyle="Solid" BackGradientStyle="TopBottom"
                        BorderWidth="2" BorderColor="26, 59, 105" IsSoftShadows="False" 
                        ImageLocation="~/TempImages/ChartPic_#SEQ(300,3)">
                        <Legends>
                            <asp:Legend TitleFont="Microsoft Sans Serif, 8pt, style=Bold" BackColor="Transparent"
                                IsEquallySpacedItems="True" Font="Trebuchet MS, 8pt, style=Bold" IsTextAutoFit="False"
                                Name="Default">
                            </asp:Legend>
                        </Legends>
                        <BorderSkin SkinStyle="Emboss"></BorderSkin>
                        <Series>
                            <asp:Series ChartArea="Area1" XValueType="Double" Name="Series1" ChartType="Pie"
                                Font="Trebuchet MS, 8.25pt, style=Bold" CustomProperties="DoughnutRadius=25, PieDrawingStyle=Concave, CollectedLabel=Other, MinimumRelativePieSize=20"
                                MarkerStyle="Circle" BorderColor="64, 64, 64, 64" Color="180, 65, 140, 240" YValueType="Double"
                                Label="#PERCENT{P1}">
                              
                            </asp:Series>
                        </Series>
                        <ChartAreas>
                            <asp:ChartArea Name="Area1" BorderColor="64, 64, 64, 64" BackSecondaryColor="Transparent"
                                BackColor="Transparent" ShadowColor="Transparent" BackGradientStyle="TopBottom">
                                <AxisY2>
                                    <MajorGrid Enabled="False" />
                                    <MajorTickMark Enabled="False" />
                                </AxisY2>
                                <AxisX2>
                                    <MajorGrid Enabled="False" />
                                    <MajorTickMark Enabled="False" />
                                </AxisX2>
                                <Area3DStyle PointGapDepth="900" Rotation="162" IsRightAngleAxes="False" WallWidth="25"
                                    IsClustered="False" />
                                <AxisY LineColor="64, 64, 64, 64">
                                    <LabelStyle Font="Trebuchet MS, 8.25pt, style=Bold" />
                                    <MajorGrid LineColor="64, 64, 64, 64" Enabled="False" />
                                    <MajorTickMark Enabled="False" />
                                </AxisY>
                                <AxisX LineColor="64, 64, 64, 64">
                                    <LabelStyle Font="Trebuchet MS, 8.25pt, style=Bold" />
                                    <MajorGrid LineColor="64, 64, 64, 64" Enabled="False" />
                                    <MajorTickMark Enabled="False" />
                                </AxisX>
                            </asp:ChartArea>
                        </ChartAreas>
                    </asp:Chart>
                </td>
            </tr>
            <tr>
                <td bgcolor="#E6E6E6" height="50" width="49%">
                    <asp:Image ID="Image4" runat="server" Style="vertical-align: middle" 
                        ImageUrl="~/Images/ico/percent3.png" />
                    <asp:Label ID="Label3" runat="server" Text="業務員報價比例" Font-Bold="True" Font-Size="14px"></asp:Label></td>
                <td >
                    &nbsp;</td>
                <td bgcolor="#E6E6E6" height="50" width="49%">
                    <asp:Image ID="Image5" runat="server" Style="vertical-align: middle" 
                        ImageUrl="~/Images/ico/zhutu.png" />
                    <asp:Label ID="Label4" runat="server" Text="按月份統計" Font-Bold="True" Font-Size="14px"></asp:Label></td>
            </tr>
            <tr>
                <td width="400px">
                    <asp:Chart ID="Chart4" runat="server" Palette="SemiTransparent" BackColor="DarkGray"
                        Height="296px" Width="400px" BorderDashStyle="Solid" BackGradientStyle="TopBottom"
                        BorderWidth="2" BorderColor="26, 59, 105" IsSoftShadows="False" 
                        ImageLocation="~/TempImages/ChartPic_#SEQ(300,3)">
                        <Legends>
                            <asp:Legend TitleFont="Microsoft Sans Serif, 8pt, style=Bold" BackColor="Transparent"
                                IsEquallySpacedItems="True" Font="Trebuchet MS, 8pt, style=Bold" IsTextAutoFit="False"
                                Name="Default">
                            </asp:Legend>
                        </Legends>
                        <BorderSkin SkinStyle="Emboss"></BorderSkin>
                        <Series>
                            <asp:Series ChartArea="Area1" XValueType="Double" Name="Series1" ChartType="Pie"
                                Font="Trebuchet MS, 8.25pt, style=Bold" CustomProperties="DoughnutRadius=25, PieDrawingStyle=Concave, CollectedLabel=Other, MinimumRelativePieSize=20"
                                MarkerStyle="Circle" BorderColor="64, 64, 64, 64" Color="180, 65, 140, 240" YValueType="Double"
                                Label="#PERCENT{P1}">
                              
                            </asp:Series>
                        </Series>
                        <ChartAreas>
                            <asp:ChartArea Name="Area1" BorderColor="64, 64, 64, 64" BackSecondaryColor="Transparent"
                                BackColor="Transparent" ShadowColor="Transparent" BackGradientStyle="TopBottom">
                                <AxisY2>
                                    <MajorGrid Enabled="False" />
                                    <MajorTickMark Enabled="False" />
                                </AxisY2>
                                <AxisX2>
                                    <MajorGrid Enabled="False" />
                                    <MajorTickMark Enabled="False" />
                                </AxisX2>
                                <Area3DStyle PointGapDepth="900" Rotation="162" IsRightAngleAxes="False" WallWidth="25"
                                    IsClustered="False" />
                                <AxisY LineColor="64, 64, 64, 64">
                                    <LabelStyle Font="Trebuchet MS, 8.25pt, style=Bold" />
                                    <MajorGrid LineColor="64, 64, 64, 64" Enabled="False" />
                                    <MajorTickMark Enabled="False" />
                                </AxisY>
                                <AxisX LineColor="64, 64, 64, 64">
                                    <LabelStyle Font="Trebuchet MS, 8.25pt, style=Bold" />
                                    <MajorGrid LineColor="64, 64, 64, 64" Enabled="False" />
                                    <MajorTickMark Enabled="False" />
                                </AxisX>
                            </asp:ChartArea>
                        </ChartAreas>
                    </asp:Chart>
                </td>
                <td >
                    &nbsp;</td>
                <td>
                    <asp:Chart ID="Chart1" runat="server" BackColor="Silver" 
                        BackGradientStyle="TopBottom" BorderColor="181, 64, 1" BorderDashStyle="Solid" 
                        BorderWidth="2" Height="296px" 
                        ImageLocation="~\TempImages\ChartPic_#SEQ(300,3)" ImageType="Png" 
                        Palette="BrightPastel" Width="400px">
                        <Titles>
                            <asp:Title Alignment="TopLeft" Font="Trebuchet MS, 14.25pt, style=Bold" 
                                ForeColor="26, 59, 105" ShadowColor="32, 0, 0, 0" ShadowOffset="3" 
                                Text="月份報價統計">
                            </asp:Title>
                        </Titles>
                        <Legends>
                            <asp:Legend BackColor="Transparent" Enabled="False" 
                                Font="Trebuchet MS, 8.25pt, style=Bold" IsTextAutoFit="False" Name="Default">
                            </asp:Legend>
                        </Legends>
                        <BorderSkin SkinStyle="Emboss" />
                        <Series>
                            <asp:Series BorderColor="180, 26, 59, 105" ChartArea="ChartArea1" 
                                Color="#009933" IsValueShownAsLabel="True" Name="Series 1">
                            </asp:Series>
                        </Series>
                        <ChartAreas>
                            <asp:ChartArea BackColor="OldLace" BackGradientStyle="TopBottom" 
                                BackSecondaryColor="White" BorderColor="64, 64, 64, 64" BorderDashStyle="Solid" 
                                Name="ChartArea1" ShadowColor="Transparent">
                                <Area3DStyle Inclination="15" IsClustered="False" IsRightAngleAxes="False" 
                                    Perspective="10" Rotation="10" WallWidth="0" />
                                <AxisY IsLabelAutoFit="False" LineColor="64, 64, 64, 64" Title="報價金額：￥">
                                    <LabelStyle Font="Trebuchet MS, 8.25pt, style=Bold" />
                                    <MajorGrid LineColor="64, 64, 64, 64" />
                                </AxisY>
                                <AxisX IsLabelAutoFit="False" LineColor="64, 64, 64, 64" Title="月份">
                                    <LabelStyle Font="Trebuchet MS, 8.25pt, style=Bold" IsStaggered="True" />
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
        <asp:Image ID="Image1" runat="server" ImageUrl="~/Images/Icons/information.png" />
        &nbsp;&nbsp;&nbsp; 沒有找到相關記錄，請嘗試其他選項。</div>
    <div>
        <asp:Panel ID="Panel1" runat="server">
        
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" Width="100%"
            ShowFooter="True">
            <Columns>
                <asp:TemplateField ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left">
                    <ItemTemplate>
                        <asp:Label ID="Label2" runat="server" Text='<%# DataBinder.Eval(Container,"DataItem.XH") %>'></asp:Label>
                        <asp:Label ID="lbPKID" runat="server" Text='<%# DataBinder.Eval(Container,"DataItem.PKID").ToString() %>'
                            Visible="False"></asp:Label>
                        <asp:Label ID="lblDocUniqueID" runat="server" Text='<%# DataBinder.Eval(Container,"DataItem.eFlowDocID").ToString() %>'
                            Visible="False"></asp:Label>
                        <asp:HyperLink ID="HLDetail" Visible ="false"  Target="_self" runat="server" ToolTip="編輯" ImageUrl="../Images/ico/pen.png">查看</asp:HyperLink>
                    </ItemTemplate>
                    <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                    <ItemStyle HorizontalAlign="Left"></ItemStyle>
                </asp:TemplateField>
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
                    HeaderStyle-HorizontalAlign="Left"/>
                <asp:BoundField DataField="Extend06" HeaderText="成本價" ItemStyle-HorizontalAlign="Left"
                    HeaderStyle-HorizontalAlign="Left">
                    <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                    <ItemStyle HorizontalAlign="Left"></ItemStyle>
                </asp:BoundField>
                <asp:BoundField DataField="profit" HeaderText="利潤率" ItemStyle-HorizontalAlign="Left"
                    HeaderStyle-HorizontalAlign="Left"/>
            </Columns>
        </asp:GridView>
        </asp:Panel>
    </div>
    </form>
</body>
</html>
