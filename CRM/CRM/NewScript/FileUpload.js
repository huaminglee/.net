$().ready(function() {
    $('#divCreate').jqm({ trigger: '#create' });
    $('#divRename').jqm({ trigger: '#rename' });
    $('#divDelete').jqm({ trigger: '#delete' });
    $('#divUpload').jqm({ trigger: '#upload' });
    $('#divCopy').jqm({ trigger: '#copy' });
    $('#divPaste').jqm({ trigger: '#paste' });
    $('#divCut').jqm({ trigger: '#cut' });
    $('#divErr').jqm();
    $('#divEditFile').jqm();


});
function Download() {
    $('#ImageTestDown').click();
   
}