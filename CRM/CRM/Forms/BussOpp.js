$(document).ready(function() {
busspkid = document.getElementById("HiddenPKID").value;
});
var busspkid;
function addtomark() {
    window.open("../Forms/AddMarkPlan.aspx?bussopppkid=" + busspkid.toString(), "_blank", "width=500,height=650,left=400,top=150,resizable=no,scrollbars=yes");
}
function upgridmark() {
    document.getElementById("Button1").click();
}