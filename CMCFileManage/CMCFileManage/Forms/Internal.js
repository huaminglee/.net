function BindCategory(rowindex, deptname) {
    $('#Hiddencurrowindex').val(rowindex);
    $('#Hiddencurdeptname').val(deptname);
    document.getElementById("Button3").click();
}
function deptchangeshow(childid, rowindex) {
    if (document.getElementById(childid).style.display == "none") {
        document.getElementById("Hiddencursetcsscategoryindex").value = rowindex;
        document.getElementById("BtnSetCSSshow").click();
    }
    else {
        document.getElementById("Hiddencursetcsscategoryindex").value = rowindex;
        document.getElementById("BtnSetCSShidd").click();
    }
}