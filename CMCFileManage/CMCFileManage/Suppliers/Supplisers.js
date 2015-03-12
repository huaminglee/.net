function addcheck() {
    var supplierpkid = String(document.getElementById("HiddenPKID").value);
    if (supplierpkid != 0) {
       var o= window.open('/CMCFileManage/Suppliers/AddCheckRecord.aspx?supplierpkid=' + supplierpkid,
		'popupcal',
		'width=600,height=300,left=400,top=300');
       o.focus();
   }
    
}
function refreshview() {
    document.getElementById("btn1").click();

}