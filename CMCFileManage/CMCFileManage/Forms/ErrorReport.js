var CodeData;
$(function() {
    $('#TxtQulocation').click(function() {
        var mSelectCode = $('#HidQulocation').val();
        if (CodeData == undefined) {
            $.ajax({
                url: "ErrorReportDetail.aspx/GetQuloctionList",
                contentType: "application/json",
                type: "post",
                data: "",
                dataType: 'json',
                success: function(msg) {
                    CodeData = msg.d
                    $('#TxtQulocation').combobox({
                        width: '106',
                        data: CodeData,
                        required: true,
                        panelHeight: "200",
                        toolTip: '按下Ctrl實現多選',
                        multiple: true,
                        valueField: 'Value',
                        textField: 'Value',
                        onChange: function(rowDate) {
                        $('#TxtQulocation').val(rowDate)
                        $('#HidQulocation').val(rowDate);
                        }
                    });
                    $('#TxtQulocation').combobox('setText', "請選擇");
                }
            });
        }
        else {
            $('#TxtQulocation').combobox({
                width: '106',
                data: CodeData,
                required: true,
                panelHeight: "200",
                valueField: 'Key',
                textField: 'Value',
                onChange: function(rowDate) {
                    $('#TxtQulocation').val(rowDate.value)
                    $('#HidQulocation').val(rowDate.value);
                }
            });
            $('#TxtQulocation').combobox('setText', "請選擇");
        }
    });
});