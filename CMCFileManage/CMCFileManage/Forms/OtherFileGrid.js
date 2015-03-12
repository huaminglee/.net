function BindQy(rowindex, deptname) {
    $('#Hiddencurrowindex').val(rowindex);
    $('#Hiddencurdeptname').val(deptname);
    document.getElementById("Button3").click();
}
function deptchangeshow(childid, rowindex) {
    if (document.getElementById(childid).style.display == "none") {
        document.getElementById("HiddencursetcssQyindex").value = rowindex;
        document.getElementById("BtnSetCSSshow").click();
    }
    else {
        document.getElementById("HiddencursetcssQyindex").value = rowindex;
        document.getElementById("BtnSetCSShidd").click();
    }
}
function BindoutFile(rowindex, buttonid) {
    $('#HiddenQyRowindex').val(rowindex);
    document.getElementById(buttonid).click();
}
function qychangeshow(fatherindex, index, childid) {
    document.getElementById("Hiddenparenetindex").value = fatherindex;
    if (document.getElementById(childid).style.display == "none") {
        document.getElementById("HiddenztRowindex").value = index;
        document.getElementById("BtnSetztcssshow").click();
    }
    else {
        document.getElementById("HiddenztRowindex").value = index;
        document.getElementById("BtnSetztcsshid").click();
    }
}
