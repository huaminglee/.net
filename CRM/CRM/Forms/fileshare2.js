$(function() {
    if ($('#HiddenCanSelectCus').val() == "1") {
        Initcustomer();
    }
});
var CustomerData;
function Initcustomer() {
    var selectCustomer = $('HiddenCustomerName').val();
    if (CustomerData == undefined) {
        $.ajax({
            url: "FileShare.aspx/GetAllCustomer",
            contentType: "application/json",
            type: "post",
            data: "",
            dataType: 'json',
            success: function(msg) {
                CustomerData = msg.d
                $('#Txtcustomer').combobox({
                    width: '300',
                    data: CustomerData,
                    required: true,
                    valueField: 'Key',
                    textField: 'Value',
                    panelHeight: '200', required: true,
                    onLoadSuccess: function() {
                        if (selectCustomer != undefined) {
                            $('#Txtcustomer').combobox('setText', selectCustomer);
                        }
                    },
                    onSelect: function(rowDate) {

                        $('#HiddenCustomerPKID').val(rowDate.value);
                        $('#HiddenCustomerName').val(rowDate.innerText);
                       
                         document.getElementById("Button2").click();

                    },
                    onChange: function(newValue, oldValue) {



                    }
                });
            }
        });
    }
}
function Getcustomeruseinfo(CustomerPKID) {
    $.ajax({
        url: "FileShare.aspx/GetCustomerUseinfo",
        contentType: "application/json",
        type: "post",
        data: "{'CustomerPKID': '" + CustomerPKID + "'}",
        dataType: 'json',
        success: function(msg) {
            $('#Lbtongji').html(msg.d);
        }
    });
}