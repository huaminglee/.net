<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="ShowPDF.aspx.vb" Inherits="CMCFileManage.ShowPDF" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="application/pdf; charset=utf-8" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <center>
        <tr>
            <td>
                <p  >
                    <object id="pdf1" width="100%" height="700px" classid="CLSID:CA8A9780-280D-11CF-A24D-444553540000">
                        <param name="_Version" value="327680">
                        <param name="_ExtentX" value="2646">
                        <param name="_ExtentY" value="1323">
                        <param name="_StockProps" value="0">
                        <param name="SRC" value='<asp:Literal ID="Literal1" runat="server"></asp:Literal>'>
                        <%--<param name="SRC" value='WI-113-008 A武漢HALT 氮氣系統操作調整程序.pdf' />--%>
                    </object>
                </p>
            </td>
        </tr>
    </center>
    </form>
</body>
</html>
