$(function() {
    InitCustomerComobobox();
});
var CustomerData;
function InitCustomerComobobox() {
    var selectCustomer = $('HiddenCustomerName').val();
    if (CustomerData == undefined) {
        $.ajax({
            url: "AddSampleReceived.aspx/GetCustomers",
            contentType: "application/json",
            type: "post",
            data: "",
            dataType: 'json',
            success: function(msg) {
                CustomerData = msg.d
                $('#TxtCustomerName').combobox({
                    width: '400',
                    data: CustomerData,
                    required: true,
                    valueField: 'Key',
                    textField: 'Value',
                    panelHeight: '200', required: true,
                    onLoadSuccess: function() {
                        if (selectCustomer != undefined) {
                            $('#TxtCustomerName').combobox('setText', selectCustomer);
                        }
                    },
                    onSelect: function(rowDate) {

                        var PersonInchargeIndex = rowDate.value.indexOf("$") + 1;
                        var emailIndex = rowDate.value.indexOf("#") + 1;
                        var personsidindex = rowDate.value.indexOf("￥") + 1;

                        $('#HiddenCustomerPKID').val(rowDate.value.substring(0, PersonInchargeIndex - 1));
                        $('#LbPersonIncharge').html(rowDate.value.substring(PersonInchargeIndex, emailIndex - 1));
                        $('#HiddenPersonIncharge').val(rowDate.value.substring(PersonInchargeIndex, emailIndex - 1));
                        $('#LbEmail').html(rowDate.value.substring(emailIndex, personsidindex - 1));
                        $('#HiddenEmail').val(rowDate.value.substring(emailIndex, personsidindex - 1));
                        $('#HiddenPersonSid').val(rowDate.value.substring(personsidindex, rowDate.value.length));

                        $('#TxtCustomerName').val(rowDate.innerText);
                        $('#HiddenCustomerName').val(rowDate.innerText);

                    },
                    onChange: function(newValue, oldValue) {
                        $('#HiddenCustomerName').val("");
                        $('#TxtCustomerName').val("");

                    }
                });
            }
        });
    }
}