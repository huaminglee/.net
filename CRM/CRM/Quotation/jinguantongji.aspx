<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="jinguantongji.aspx.vb"
    Inherits="CRM.jinguantongji" %>

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
        統計條件：
        廠區:<asp:DropDownList ID="DPLchangqu" runat="server"  >
            <asp:ListItem Value="LH">龍華檢測中心</asp:ListItem>
            <asp:ListItem Value="WH">武漢檢測中心</asp:ListItem>
            <asp:ListItem Value="CD">成都檢測中心</asp:ListItem>
           <asp:ListItem Value="CQ">重慶檢測中心</asp:ListItem> 
           <asp:ListItem Value="ZZ">鄭州檢測中心</asp:ListItem>
            <asp:ListItem Value="YT">煙台檢測中心</asp:ListItem>
            <asp:ListItem Value="KS">吳淞江檢測中心</asp:ListItem>
            <asp:ListItem Value="GL">觀瀾檢測中心</asp:ListItem>
            <asp:ListItem Value="NN">南寧檢測中心</asp:ListItem>
        </asp:DropDownList>
        起始時間：<asp:TextBox ID="TxtStartDate" class="text-input" runat="server" 
            Width="100px"></asp:TextBox>
        結束時間：<asp:TextBox ID="TxtEndDate" class="text-input" runat="server" 
            Width="100px"></asp:TextBox>
        實驗室<asp:DropDownList ID="DPLServiceType" runat="server">
        </asp:DropDownList>
        <asp:TextBox ID="TxtSearch" class="text-input" runat="server"></asp:TextBox>
        <asp:Button ID="BtnSearch" class="button" runat="server" Text="搜尋" />
        &nbsp;<asp:Button ID="BtnExcel" class="button" runat="server" Text="導出" />
    </div>
     <div id="emptyinfo" runat="server" visible="false" style="width: 100%; height: 30px;
                        background-color: #DBE3FF; line-height: 30px; overflow: hidden;">
                        <asp:Image ID="Image3" runat="server" ImageUrl="~/Images/Icons/information.png" />
                        &nbsp;&nbsp;&nbsp; 沒有找到相關數據，請嘗試其他選項。</div>
    <div>
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" Width="100%"
            ShowFooter="True">
            <Columns>
                <asp:BoundField DataField="XH" HeaderText="序號" ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left">
                    <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                    <ItemStyle HorizontalAlign="Left"></ItemStyle>
                </asp:BoundField>
                <asp:BoundField DataField="QuotationNO" HeaderText="報價單號" ItemStyle-HorizontalAlign="Left"
                    HeaderStyle-HorizontalAlign="Left">
                    <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                    <ItemStyle HorizontalAlign="Left"></ItemStyle>
                </asp:BoundField>
                <asp:TemplateField HeaderText="當前狀態">
                    <ItemTemplate>
                        <asp:Label ID="LbReportPKID" Visible ="false"  runat="server" Text='<%# DataBinder.Eval(Container,"DataItem.ReportPKID") %>'></asp:Label>
                        <asp:Label ID="LbEflowdocid"  Visible ="false"  runat="server" Text='<%# DataBinder.Eval(Container,"DataItem.ReportEflowdocid") %>'></asp:Label>
                        <asp:Label ID="LbDuizhang" Visible="false" runat="server" Text='<%# DataBinder.Eval(Container,"DataItem.DuizhangTime") %>'>
                        </asp:Label>
                        <asp:Label ID="LbInvoiceDotime" runat="server" Visible="false" Text='<%# DataBinder.Eval(Container,"DataItem.InvoiceDotime") %>'>
                        </asp:Label>
                        <asp:Label ID="LbStateName" Visible="false" runat="server" Text='<%# DataBinder.Eval(Container,"DataItem.StateName") %>'>
                        </asp:Label>
                        <asp:Label ID="LbCurState" runat="server" Text=""></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="TestNO" HeaderText="測試編號" ItemStyle-HorizontalAlign="Left"
                    HeaderStyle-HorizontalAlign="Left">
                    <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                    <ItemStyle HorizontalAlign="Left"></ItemStyle>
                </asp:BoundField>
                <asp:BoundField DataField="ServiceType" HeaderText="服務類別" ItemStyle-HorizontalAlign="Left"
                    HeaderStyle-HorizontalAlign="Left">
                    <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                    <ItemStyle HorizontalAlign="Left"></ItemStyle>
                </asp:BoundField>
                <asp:BoundField DataField="TestItemName" HeaderText="測試項目" HeaderStyle-HorizontalAlign="Left"
                    ItemStyle-HorizontalAlign="Left">
                    <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                    <ItemStyle HorizontalAlign="Left"></ItemStyle>
                </asp:BoundField>
                <asp:BoundField DataField="CustomerName" HeaderText="客戶名稱" ItemStyle-HorizontalAlign="Left"
                    HeaderStyle-HorizontalAlign="Left">
                    <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                    <ItemStyle HorizontalAlign="Left"></ItemStyle>
                </asp:BoundField>
                <asp:BoundField DataField="QuotaerName" HeaderText="報價人" ItemStyle-HorizontalAlign="Left"
                    HeaderStyle-HorizontalAlign="Left">
                    <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                    <ItemStyle HorizontalAlign="Left"></ItemStyle>
                </asp:BoundField>
                <asp:BoundField DataField="TongjiTime" HeaderText="測試完成日期" DataFormatString="{0:yy-MM-dd}"
                    ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left">
                    <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                    <ItemStyle HorizontalAlign="Left"></ItemStyle>
                </asp:BoundField>
                <asp:BoundField DataField="ItemShijizongjia" HeaderText="未稅報價" ItemStyle-HorizontalAlign="right"
                    HeaderStyle-HorizontalAlign="right">
                    <HeaderStyle HorizontalAlign="Right"></HeaderStyle>
                    <ItemStyle HorizontalAlign="Right"></ItemStyle>
                </asp:BoundField>
                <asp:TemplateField HeaderText="發票" ItemStyle-HorizontalAlign="Right">
                <ItemTemplate >
                    <asp:Label ID="LbIsneedfapiao" Visible ="false"  runat="server" Text='<%# DataBinder.Eval(Container,"DataItem.ISneedFapiao") %>'></asp:Label>
                    <asp:Label ID="LbIsneedfapiaoshow" runat="server" Text =""></asp:Label>
                </ItemTemplate>
                
<ItemStyle HorizontalAlign="Right"></ItemStyle>
                
                </asp:TemplateField>
                <asp:TemplateField HeaderText="含稅報價" ItemStyle-HorizontalAlign="Right" 
                    HeaderStyle-HorizontalAlign="Right">
                    <ItemTemplate>
                        <asp:Label ID="LbHanshui" runat="server" Text=""></asp:Label>
                    </ItemTemplate>
                    <HeaderStyle HorizontalAlign="Right"></HeaderStyle>
                    <ItemStyle HorizontalAlign="Right"></ItemStyle>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="經管統計" HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right">
                <ItemTemplate >
                    <asp:Label ID="LbFinal" runat="server" Text=""></asp:Label>
                </ItemTemplate>
                
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>
    </form>
</body>
</html>
