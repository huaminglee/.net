
function BindFile(deptname, rowindex, buttonid) {
    $('#HiddenCategoryRowindex').val(rowindex);
    document.getElementById(buttonid).click();
}
function categorychangeshow(fatherindex, index, childid) {
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
function BindSiFile(rowindex, deptname) {
    document.getElementById("Hiddencurdeptname").value = deptname;
    document.getElementById("Hiddencurrowindex").value = rowindex;
    document.getElementById("BtnBindSiBydeptname").click();
}
function fourdeptchangeshow(childid, rowindex) {
    if (document.getElementById(childid).style.display == "none") {
        document.getElementById("Hiddensetcssfourfileindex").value = rowindex;
        document.getElementById("BtnFourcssShoe").click();
    }
    else {
        document.getElementById("Hiddensetcssfourfileindex").value = rowindex;
        document.getElementById("BtnFourcssHid").click();
    }
}