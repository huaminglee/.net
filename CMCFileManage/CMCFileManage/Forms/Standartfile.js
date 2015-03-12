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
    document.getElementById("HiddenQyRowindex").value = rowindex;
    document.getElementById(buttonid).click();
}
function bindzt(rowindex, buttonid) {
    document.getElementById("HiddenQyRowindex").value = rowindex;
    document.getElementById(buttonid).click();
}
function Bindzz(rowindex, buttonid) {
    document.getElementById("HiddenztRowindex").value = rowindex;
    document.getElementById(buttonid).click();
}
function Bindfile(rowindex, buttonid) {
    document.getElementById("HiddenzzRowindex").value = rowindex;
    document.getElementById(buttonid).click();
}

function qychangeshow(fatherindex, index, childid) {
    document.getElementById("Hiddenparenetindex").value = fatherindex;
    if (document.getElementById(childid).style.display == "none") {
        document.getElementById("Hiddencursetcssfileindex").value = index;
        document.getElementById("BtnSetFileCssShow").click();
    }
    else {
        document.getElementById("Hiddencursetcssfileindex").value = index;
        document.getElementById("BtnSetFileCSSHid").click();
    }
}
function ztchangeshow(fatherindex, index, childid) {
    
    if (document.getElementById(childid).style.display == "none") {
        document.getElementById("HiddenzzRowindex").value = index;
        document.getElementById("BtnSetzzcssshow").click();
    }
    else {
        document.getElementById("HiddenzzRowindex").value = index;
        document.getElementById("BtnSetzzcsshid").click();
    }
}
function changeshow( childid) {
    if (document.getElementById(childid).style.display == "none") {
        document.getElementById(childid).style.display="inline"
    }
    else {
        document.getElementById(childid).style.display = "none"
    }
}