$(document).ready(function() {

    $('#NewItem').click(function() {
        var linkurl = "../Forms/CustomerDetail.aspx?add=1";
        window.location = linkurl;
    });
})
function searchcustomer() {
    var btnsearch = document.getElementById("BtnSearch")
    btnsearch .click()
}