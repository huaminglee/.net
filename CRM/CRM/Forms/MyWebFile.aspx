<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="MyWebFile.aspx.vb" Inherits="CRM.MyWebFile" %>

<%@ Register Src="../UCtl/UcUserFileManage.ascx" TagName="UcUserFileManage" TagPrefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../CSS/WebFileManager.css" rel="stylesheet" type="text/css" />

    <script src="../NewScript/jquery-1.7.2.min.js" type="text/javascript"></script>

    <script src="../NewScript/jqModal.js" type="text/javascript"></script>

    <script src="../NewScript/uploadScript/swfobject.js" type="text/javascript"></script>

    <script src="../NewScript/uploadScript/jquery.uploadify.min.js" type="text/javascript"></script>

    <script src="../NewScript/FileUpload.js" type="text/javascript"></script>

    <script src="../NewScript/UIHelper.js" type="text/javascript"></script>

    <script type="text/javascript">
        $(document).ready(function() {
            $("#uploadify").uploadify({
                'uploader': '../NewScript/uploadScript/uploadify.swf',
                'script': 'FileUPHandler.ashx',
                'cancelImg': '../Images/delete.gif',
                'folder': 'ioasoa',
                'queueID': 'fileQueue',
                'auto': false,
                'multi': true,
                'onAllComplete': function() {
                    window.location = $("#Curpath")[0].href;

                }
            });

        });
        
    </script>

</head>
<body>
    <form id="form1" runat="server">
    <div>
        <uc1:UcUserFileManage ID="UcUserFileManage1" runat="server" />
    </div>
    </form>
</body>
</html>
