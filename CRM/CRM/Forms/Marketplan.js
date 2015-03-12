$(document).ready(function() {
    markpkid = document.getElementById("HiddenPKID").value;
});
function upgridopp() {
    document.getElementById("Button1").click();
}
function upgridmember() {
    document.getElementById("Button2").click();
}
var markpkid;
function addbussopp() {

    window.open("../Forms/AddBussOPP.aspx?Markplanpkid=" + markpkid.toString(), "_blank", "width=500,height=650,left=400,top=150,resizable=no,scrollbars=yes");
}
function opaddcontact() {

    window.open("../Forms/AddContact.aspx?Markplanpkid=" + markpkid.toString(), "_blank", "width=500,height=650,left=400,top=0,resizable=no,scrollbars=yes");
}
function opaddcustom() {

    window.open("../Forms/AddCustomer.aspx?Markplanpkid=" + markpkid.toString(), "_blank", "width=500,height=650,left=400,top=0,resizable=no,scrollbars=yes");
}