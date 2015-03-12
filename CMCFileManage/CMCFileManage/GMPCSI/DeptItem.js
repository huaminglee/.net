function Addnew() {
    var deptpkid = String(document.getElementById("HidDeptPKID").value);
    if (deptpkid != 0) {
        window.open('/CMCFileManage/GMPCSI/AddnewItem.aspx?Type=1&DeptPKID=' + deptpkid,
		'popupcal',
		'width=350,height=100,left=300,top=380');
    }
}
function refreshview() {
    document.getElementById("btn1").click();

}

function Addmulnew() {
    var deptpkid = String(document.getElementById("HidDeptPKID").value);
    if (deptpkid != 0) {
        window.open('/CMCFileManage/GMPCSI/AddnewItem.aspx?Type=2&DeptPKID=' + deptpkid,
		'popupcal',
		'width=350,height=100,left=300,top=380');
    }
}
