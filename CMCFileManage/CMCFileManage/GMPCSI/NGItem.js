function Addnew() {
    var DeptItemPKID = String(document.getElementById("HidDeptItemPKID").value);
    if (DeptItemPKID != 0) {
        window.open('/CMCFileManage/GMPCSI/AddNewNGItem.aspx?DeptItemPKID=' + DeptItemPKID,
		'popupcal',
		'width=350,height=100,left=300,top=380');
    }
}
function refreshview() {
    document.getElementById("btn1").click();

}