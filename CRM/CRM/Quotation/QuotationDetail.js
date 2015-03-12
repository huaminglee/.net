$(function() {

    if ($('#HiddenIsGoods').val() == "1") {
        InitGoodsInfo();

    }
    else {
        InitSampleInfo();
    }
    if ($('#HiddenCanAdd').val() == "True") {
        $('#TxtCustomerName').click(function() {
            InitCustomerComobobox();

        })
    }
    if ($('#HiddenIsFast').val() == 1) {
        InitContactComobobox($('#HiddenCustomerPKID').val());

    }
    if ($('#HiddenPKID').val() != 0) {
        document.getElementById("testremark").style.display = "inline";
    }
    //    $('#LbCusHistory').click(function() {
    //        var CustomerPKID = String(document.getElementById("HiddenCustomerPKID").value);
    //        if (CustomerPKID != 0) {
    //            window.open('/CRM/Forms/TestHistory.aspx?CustomerPKID=' + CustomerPKID,
    //	                                	'popupcal',
    //	                                   	'width=500,height=400,left=300,top=380');
    //        }
    //    });

});
function quotypechange() {
    var CheckChangeToGoods = document.getElementById("CheckChangeToGoods");
    if (CheckChangeToGoods.checked == true) {
        $('#Label7').html("產品信息");
        document.getElementById("divsampleadd").style.display = "none";
        document.getElementById("divgoods").style.display = "inline";
        InitGoodsInfo();

    }
    else {
        document.getElementById("divsampleadd").style.display = "inline";
        document.getElementById("divgoods").style.display = "none";
        $('#Label7').html("送檢物品及測試項目信息");
    }
}
function showreport() {
    var pkid = $('#HiddenPKID').val();
    if (pkid != 0) {
        window.open('/CRM/Quotation/ForReportView.aspx?pkid=' + pkid, 'popupcal', 'width=800,height=800,scrollbars=yes ,left=300,top=380');
    }
}
var CustomerData;
var IEwidth = $(window).width() < 1000 ? 980 : $(window).width() - 20;
var lastIndex = -1;
var lastIndexgoods = -1;
var ItemLastIndex = -1;
var Testi = 0; //當選擇測試項目信息時如果為第一次則加載項目信息
var filei = 0;  //當選擇附件信息時如果為第一次則加載附件信息
var mSamplerow = 0; //測試物品記錄總數
var mSamplerowgoods = 0;
var TestItemRow = 0; //測試項目記錄總數
var CanAdd = true; //是否可以編輯DataGrid (當倉庫接件后CanAdd為false)
var CanEditItem = true;
var ContactData;
var SubEditIndex = -1;
var SampleEditIndex = -1;
var Columnstring = "";
var NoeditString = "";
var HasCanAllow = false;
var EquipControlInfos;
var SampleClients;
var dialogInit = 0;
var SampleNumber = 0;
var IsInitItem = true;
var IsInitItemgoods = true;
var ServiceLastindex = new Array();           //每類最後編輯的index
function AndFor(row, index) {
    if (row.PKID > 0) {
        var s = '<a href="#" style="color:#86c440" title="為該樣品填寫測試項目信息" onclick="AddTestItem(' + index + ',' + row.PKID + ',' + row.Numbers + ')"><img  border="0" src="../Images/ico/plus.png"/>添加測試項目</a> ';

        return s;
    }
    else
        return "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;"
}
function TestItemHistory(row) {
    if (row.TestItemName != "") {
        var testitemname = "'" + encodeURI(row.TestItemName) + "'";
        var s = '<a href="#"  title="歷史報價" onclick="ShowHistory(' + testitemname + ')">查看歷史報價</a> ';
        return s;
    }
    else
        return "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;"
}
function ShowHistory(TestItemName) {
    if (TestItemName != "") {
        window.open('/CRM/Forms/TestHistory.aspx?TestItemName=' + TestItemName,
    	                                	'popupcal',
    	                                   	'width=500,height=400,left=300,top=380');
    }
}
function InitCustomerComobobox() {
    var selectCustomer = $('#HiddenCustomerName').val();
    if (CustomerData == undefined) {
        $.ajax({
            url: "QuotationDetail.aspx/GetMyCustomer",
            contentType: "application/json",
            type: "post",
            data: "",
            dataType: 'json',
            success: function(msg) {
                CustomerData = msg.d
                $('#TxtCustomerName').combobox({
                    width: '135',
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
                        var newstr = rowDate.value.substring(rowDate.value.indexOf("$") + 1, rowDate.value.length);
                        var substr = newstr.substring(newstr.indexOf("$") + 1, newstr.length);
                        var GradeIndex = rowDate.value.indexOf("$") + 1;
                        var TypeofPayindex = newstr.indexOf("$") + 1;

                        $('#LbCustomerGrade').html(newstr.substring(1, TypeofPayindex - 1) + "級");
                        if ($('#LbCustomerGrade').html() == "1 級") {
                            $('#HiddenCurrentCan').val($('#HiddenOne').val());
                        }
                        else if ($('#LbCustomerGrade').html() == "2 級") {
                            $('#HiddenCurrentCan').val($('#HiddenTwo').val());
                        }
                        else if ($('#LbCustomerGrade').html() == "3 級") {
                            $('#HiddenCurrentCan').val($('#HiddenThree').val());
                        }
                        else if ($('#LbCustomerGrade').html() == "4 級") {
                            $('#HiddenCurrentCan').val($('#HiddenFour').val());
                        }
                        else if ($('#LbCustomerGrade').html() == "5 級") {
                            $('#HiddenCurrentCan').val($('#HiddenFive').val());
                        }


                        if (substr == 2) {
                            $('#LbTypeOfPay').html('月結客戶');
                        }
                        else if (substr == 1) {
                            $('#LbTypeOfPay').html('預付款客戶');
                        }


                        $('#HiddenCustomerPKID').val(rowDate.value.substring(0, GradeIndex - 1));

                        $('#TxtCustomerName').val(rowDate.innerText);
                        $('#HiddenCustomerName').val(rowDate.innerText);

                        $.ajax({
                            url: "QuotationDetail.aspx/GetCustomerHisByCustomerPKID",
                            contentType: "application/json",
                            type: "post",
                            data: "{'CustomerPKID': '" + $('#HiddenCustomerPKID').val() + "'}",
                            dataType: 'json',
                            success: function(msg) {
                                var resul = msg.d;

                                $('#LbCusHistory').html(resul);
                                //                                $('#LbCusHistory').click(function() {
                                //                                    var CustomerPKID = String(document.getElementById("HiddenCustomerPKID").value);
                                //                                    if (CustomerPKID != 0) {
                                //                                        window.open('/CRM/Forms/TestHistory.aspx?CustomerPKID=' + CustomerPKID,
                                //	                                	'popupcal',
                                //	                                   	'width=500,height=400,left=300,top=380');
                                //                                    }
                                //                                });


                            }

                        });

                        InitContactComobobox(rowDate.value.substring(0, GradeIndex - 1));


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

function InitContactComobobox(CustomerPKID) {
    var selectContact = $('HiddenContactName').val();

    $.ajax({
        url: "QuotationDetail.aspx/GetContactByCustomerPKID",
        contentType: "application/json",
        type: "post",
        data: "{'CustomerPKID': '" + CustomerPKID + "'}",
        dataType: 'json',
        success: function(msg) {
            ContactData = msg.d
            $('#TxtContactName').combobox({
                width: '105',
                data: ContactData,
                required: true,
                valueField: 'Key',
                textField: 'Value',

                panelHeight: '200', editable: false, required: true,
                onLoadSuccess: function() {
                    //  $("#TxtContactName ").combobox('select', ContactData[0].innerText);
                    if (selectContact != undefined) {
                        $('#TxtContactName').combobox('setText', selectContact);


                    }
                },
                onSelect: function(rowDate) {
                    $('#HiddenContactName').val(rowDate.innerText);
                    $('#TxtContactName').val(rowDate.innerText);
                    var EmailIndex = rowDate.value.indexOf("$") + 1;
                    var IDindex = rowDate.value.indexOf("&") + 1;
                    var Faxindex = rowDate.value.indexOf("#") + 1;
                    var pkidindex = rowDate.value.indexOf("*") + 1;

                    $('#TxtContactPhone').val(rowDate.value.substring(0, EmailIndex - 1));
                    $('#HiddenContactPhone').val(rowDate.value.substring(0, EmailIndex - 1));
                    $('#TxtContactEmail').val(rowDate.value.substring(EmailIndex, IDindex - 1));
                    $('#HiddenContactEmail').val(rowDate.value.substring(EmailIndex, IDindex - 1));
                    $('#HiddenContactID').val(rowDate.value.substring(IDindex, Faxindex - 1));
                    $('#HiddenContactFax').val(rowDate.value.substring(Faxindex, pkidindex - 1));

                    var contactpkid = rowDate.value.substring(pkidindex, rowDate.value.length);
                    if (rowDate.value.substring(IDindex, Faxindex - 1) == '000000') {
                        if (confirm('該聯繫人還未填寫登陸名，將無法下載報告' + String.fromCharCode(10) + String.fromCharCode(10) + '確定---->忽略并繼續' + String.fromCharCode(10) + String.fromCharCode(10) + '取消---->修改該用戶信息')) {
                            $('#TxtContactName').val(rowDate.innerText);
                        }
                        else {
                            window.location.href = '../Forms/UserADVInfo.aspx?pkid=' + contactpkid.toString();
                        }
                    }


                },
                onChange: function(newValue, oldValue) {
                    $('#HiddenContactName').val("");
                    $('#TxtContactName').val("");
                    $('#TxtContactPhone').val("");
                    $('#HiddenContactPhone').val("");
                    $('#TxtContactEmail').val("");
                    $('#HiddenContactEmail').val("");
                    $('#HiddenContactID').val("");
                }
            });
        }
    });

}
function InitGoodsInfo() {
    var Columnstring = "";
    var iscustomer = $('#HiddenIsCustomer').val();
    var isleader = $('#HiddenIsLeader').val();
    if (Columnstring == "") {

        Columnstring = "[["
        Columnstring = Columnstring + "{ field:'PKID',hidden:true ,editor:{type:'text'}},"
        Columnstring = Columnstring + "{ field:'ServicePKID',hidden:true,editor:{type:'text'}},{field:'TestItemPKID',hidden:true,editor:{type:'text'}},"
        Columnstring = Columnstring + "{ field:'ServiceType',title:'實驗室',width:'100', editor:{type:'text'}},"
        Columnstring = Columnstring + "{ field:'TestItemName',title:'產品名稱',width:'100', editor:{type:'text'}},{field:'Numbers',title:'數量',width:'50',editor:{type: 'numberbox', options: { min: 1, required: true}  }},"
        Columnstring = Columnstring + "{ field:'Extend06',title:'單位',width:'50',editor:{type:'text',options:{disabled:true}}},"

        if (iscustomer == 0) {
            Columnstring = Columnstring + "{ field:'Extend04',title:'基本金',width:'50' ,editor:{type:'text',options:{disabled:true}}},{ field:'Extend01',title:'牌價單價',width:'50',editor:{type:'text',options:{disabled:true}} },{ field:'Paijia',title:'牌價總價',width:'50' ,editor:{type:'text',options:{disabled:true}}},"

        }
        Columnstring = Columnstring + "{field:'Shijidanjia',title:'實際單價',width:'50',editor:{type:'text',options:{disabled:true}}},{ field:'Shijizongjia',title:'實際報價',width:'50',editor:{type: 'numberbox', options: { min: 1, required: true}  }},"

        if (iscustomer == 0) {
            Columnstring = Columnstring + "{ field:'Extend03',hidden:true,editor:{type:'text',options:{disabled:true}}},"
            if (isleader == 1) {
                Columnstring = Columnstring + "{ field:'Extend02',title:'成本總價',width:'50',editor:{type:'text',options:{disabled:true}}},{ field:'Profit',title:'利潤率',width:'50',editor:{type:'text',options:{disabled:true}}},"
            }
            else if (isleader == 0) {
                Columnstring = Columnstring + "{ field:'Extend02',hidden:true,editor:{type:'text',options:{disabled:true}}},{ field:'Extend05',hidden:true,editor:{type:'text',options:{disabled:true}}},"
            }
        }
        if (iscustomer == 0) {
            Columnstring = Columnstring + "{ field:'PerYouhui',title:'優惠比例',width:'50',editor:{type:'text',options:{disabled:true}}},"
        }
        Columnstring = Columnstring + "{field:'Remark',title:'樣品數',hidden:true,width:'50',editor: 'text'},{field:'TestStandard',title:'備註',width:'50',editor: 'text'},"
        if (iscustomer == 0) {
            Columnstring = Columnstring + "{title:'歷史報價 ',field:'TestHistory', width:100,formatter:function(value,row,index) {return TestItemHistory(row);} },"
        }
        NoeditString = Columnstring;
        Columnstring = Columnstring.substring(0, Columnstring.length - 1);

        Columnstring = Columnstring + ']]';
        Columnstring = eval(Columnstring);
        GoodsInfo(Columnstring);
    }
    else {

        if (CanEditItem) {
            var ColumnInfo = NoeditString + EditString;
            ColumnInfo = ColumnInfo.substring(0, ColumnInfo.length - 1);
            ColumnInfo = eval(ColumnInfo + ']]');
            Columnstring = ColumnInfo;
        }
        GoodsInfo(Columnstring)
    }

}
function GoodsInfo(Columstring) {
    var Toolbar = "";
    CanAdd = $('#HiddenCanAdd').val() == "True";
    if (CanAdd) { Toolbar = "#GoodsButtons" }
    $('#GoodsTable').datagrid({
        width: IEwidth,
        height: 'auto',
        toolTip: CanAdd ? '雙擊進行編輯' : "",
        toolbar: Toolbar,
        url: $('#HiddenPKID').val() != "0" ? '../action/JqueryS.ashx?Method=GoodsInfo&PKID=' + $('#HiddenPKID').val() : "",
        columns: Columstring,
        onSelect: function(rowIndex) {
            if (lastIndexgoods != rowIndex) {
                $('#btndeletegoods').linkbutton('enable');
            }
        },
        onLoadSuccess: function(dateInfo) {


            mSamplerowgoods = dateInfo.rows.length;
            if (mSamplerowgoods > 0) {

                if (parseInt($('#HiddenStateorder').val()) == 1 || parseInt($('#HiddenStateorder').val()) == 3 || parseInt($('#HiddenStateorder').val()) == 5 || parseInt($('#HiddenStateorder').val()) == 6) {
                    if (IsInitItemgoods) {
                        IsExpand = true;
                        for (var index = 0; index < dateInfo.rows.length; index++) {
                            $('#GoodsTable').datagrid('expandRow', index);
                        }
                    }
                }
            }
        },
        onDblClickRow: function(rowIndex, row) {

            if (lastIndexgoods != rowIndex && CanEditItem) {
                if ($('#GoodsTable').datagrid('validateRow', lastIndexgoods)) {
                    $('#GoodsTable').datagrid('endEdit', lastIndexgoods);

                    $('#GoodsTable').datagrid('beginEdit', rowIndex);
                    $('#btnSavegoods').linkbutton('enable');
                    $('#btnCancelgoods').linkbutton('enable');

                    SaveGoods(1);
                }
            }
            lastIndexgoods = rowIndex;
        }

    });

}
function AddGoods() {//添加樣品信息,首先保存申請單信息

    //    document.getElementById('LinkGetPDF').style.display = "inline";
    var GoodsIndex = $('#GoodsTable').datagrid('getRows').length;
    for (var index = 0; index < GoodsIndex; index++) {
        $('#GoodsTable').datagrid('collapseRow', index);
        IsExpand = false;
    }
    var Result = $("form").form("validate");
    if (Result) {
        var applyPKID = $("#HiddenPKID").val();
        if (applyPKID == "0") {
            $.ajax({
                type: "POST",
                contentType: "application/json",
                url: "QuotationDetail.aspx/SaveQuotationInfo",
                data: "{'mQuotation':{'QuotationNO':'" + $('#TxtQuotationNO').val() + "','CustomerPKID':'" + $('#HiddenCustomerPKID').val() + "','CustomerName':'" + $('#HiddenCustomerName').val() + "','TestCategory':'" + $("input[name='RdoTestCategory']").val() + "','ContactName':'" + $('#HiddenContactName').val() + "','ContactPhone':'" + $('#HiddenContactPhone').val() + "','ContactEmail':'" + $('#HiddenContactEmail').val() + "','QuotaerName':'" + $('#TxtQuotater').val() + "','QuotaerPhone':'" + $('#TxtQuotaterPhone').val() + "','QuoteEmail':'" + $('#TxtQuotaterEmail').val() + "','QuoteDate':'" + $('#TxtQuotationDate').val() + "','HopeFinishDATE':'" + $('#TxtHopeFinishDate').val() + "','Extend04':'" + $('#HiddenQuoterFax').val() + "','Extend05':'" + $('#HiddenContactFax').val() + "'}}",
                dataType: 'json',
                success: function(msg) {
                    $("#HiddenPKID").val(msg.d);

                }
            });
        }

        if ($('#GoodsTable').datagrid('validateRow', lastIndexgoods)) {
            $('#GoodsTable').datagrid('endEdit', lastIndexgoods);
            $('#GoodsTable').datagrid('insertRow', { index: GoodsIndex,
                row: {
                    PKID: 0,
                    ServicePKID: 0,
                    TestItemPKID: 0,
                    ServiceType: '',
                    TestItemName: '',
                    Numbers: 1,
                    Extend06: '',
                    Extend04: '',
                    Extend01: '',
                    Paijia: 0,
                    Shijidanjia: 0,
                    Shijizongjia: 1,
                    Extend03: '',
                    Extend02: '',
                    Profit: 0,
                    Extend05: '',
                    PerYouhui: 0,
                    Remark: '',
                    TestStandard: '',
                    TestHistory: ''

                }
            });

            $('#btnSavegoods').linkbutton('enable');
            $('#btndeletegoods').linkbutton('enable');
            $('#GoodsTable').datagrid('beginEdit', GoodsIndex);
            lastIndexgoods = GoodsIndex;
            var row = $('#GoodsTable').datagrid('getSelected');
            InitLab();
            SetEditingGoods("#GoodsTable", lastIndexgoods, row);
        }
    }
}
function InitLab() {
    if (LabList == undefined) {
        $.ajax({
            type: "POST",
            contentType: "application/json",
            url: 'QuotationDetail.aspx/GetAllLab',
            dataType: 'json',
            async: false,
            success: function(msg) {
                LabList = msg.d;
            }
        });
    }
}
var LabList;
function SetEditingGoods(tableID, rowIndex, row) {
    var ServiceType = $(tableID).datagrid('getEditor', { index: rowIndex, field: 'ServiceType' });
    ServiceType.target.combobox({
        width: 100,
        panelHeight: 'auto',
        data: LabList,
        valueField: 'Key',
        textField: 'Value',
        editable: false,
        onSelect: function(RowDate) {
            InitGoodsxiangxi(RowDate.innerText, tableID, rowIndex, row);

            ServiceType.target.val(RowDate.innerText)
        }

    });
}
function InitGoodsxiangxi(ServiceName, tableID, rowIndex, row) {
    var TestItemPKID = $(tableID).datagrid('getEditor', { index: rowIndex, field: 'TestItemPKID' });
    var TestItemName = $(tableID).datagrid('getEditor', { index: rowIndex, field: 'TestItemName' });
    var Paijia = $(tableID).datagrid('getEditor', { index: rowIndex, field: 'Paijia' });
    var Extend03 = $(tableID).datagrid('getEditor', { index: rowIndex, field: 'Extend03' }); //成本單價
    var ServicePKID = $(tableID).datagrid('getEditor', { index: rowIndex, field: 'ServicePKID' });   //
    var Numbers = $(tableID).datagrid('getEditor', { index: rowIndex, field: 'Numbers' });
    var Extend06 = $(tableID).datagrid('getEditor', { index: rowIndex, field: 'Extend06' });
    var Extend05 = $(tableID).datagrid('getEditor', { index: rowIndex, field: 'Extend05' });
    var Extend04 = $(tableID).datagrid('getEditor', { index: rowIndex, field: 'Extend04' }); //基本金
    var Extend02 = $(tableID).datagrid('getEditor', { index: rowIndex, field: 'Extend02' });
    var Extend01 = $(tableID).datagrid('getEditor', { index: rowIndex, field: 'Extend01' });
    var Shijidanjia = $(tableID).datagrid('getEditor', { index: rowIndex, field: 'Shijidanjia' });
    var Shijizongjia = $(tableID).datagrid('getEditor', { index: rowIndex, field: 'Shijizongjia' });
    var Profit = $(tableID).datagrid('getEditor', { index: rowIndex, field: 'Profit' });
    var PerYouhui = $(tableID).datagrid('getEditor', { index: rowIndex, field: 'PerYouhui' });
    var Remark = $(tableID).datagrid('getEditor', { index: rowIndex, field: 'Remark' });
    var TestStandard = $(tableID).datagrid('getEditor', { index: rowIndex, field: 'TestStandard' });

    $.ajax({
        url: "QuotationDetail.aspx/GetGoodsItemByServiceName",
        contentType: "application/json",
        type: "post",
        data: "{'ServiceName': '" + ServiceName + "'}",
        dataType: 'json',
        success: function(msg) {
            var TestItemData = msg.d
            TestItemName.target.combobox({
                width: '105',
                data: TestItemData,
                required: true,
                valueField: 'Key',
                textField: 'Value',
                panelHeight: '200', editable: false, required: true,
                onLoadSuccess: function() {

                },
                onSelect: function(rowDate) {
                    var ItemIndex = rowDate.value.indexOf("$") + 1;
                    var CBunitIndex = rowDate.value.indexOf("&") + 1;
                    var PaijiaKaiIndex = rowDate.value.indexOf("#") + 1;
                    var PaijiaUnitIndex = rowDate.value.indexOf("*") + 1;
                    TestItemPKID.target.val(rowDate.value.substring(0, ItemIndex - 1));
                    Extend03.target.val(rowDate.value.substring(ItemIndex, CBunitIndex - 1));
                    Extend04.target.val(rowDate.value.substring(CBunitIndex, PaijiaKaiIndex - 1));
                    Extend01.target.val(rowDate.value.substring(PaijiaKaiIndex, PaijiaUnitIndex - 1));
                    Extend06.target.val(rowDate.value.substring(PaijiaUnitIndex, rowDate.value.length));
                    Numbers.target.val(0);
                    Shijizongjia.target.val(0);
                    Paijia.target.val(0);
                    PerYouhui.target.val(0);
                    TestItemName.target.val(rowDate.innerText);

                },
                onChange: function(newValue, oldValue) {

                }
            });
        }
    });
    Numbers.target.bind('change', function() {
        if (Extend04.target.val() >= Numbers.target.val() * Extend01.target.val()) {
            Paijia.target.val(Extend04.target.val());
        }
        else {
            Paijia.target.val(Numbers.target.val() * Extend01.target.val());
        }
        Shijidanjia.target.val(Shijizongjia.target.val() / Numbers.target.val());
        PerYouhui.target.val((Shijizongjia.target.val() / Paijia.target.val() * 100).toFixed(2) + '%')
    });
    Shijizongjia.target.bind('change', function() {
        Shijidanjia.target.val(Shijizongjia.target.val() / Numbers.target.val());
        PerYouhui.target.val((Shijizongjia.target.val() / Paijia.target.val() * 100).toFixed(2) + '%')
    });

}

function DeleteGoods() {//刪除樣品信息
    //        debugger;
    if (lastIndexgoods > -1) {

        $('#GoodsTable').datagrid('deleteRow', lastIndexgoods);
        lastIndexgoods = -1;
        $('#btnDeletegoods').linkbutton('disable');
        $('#btnSavegoods').linkbutton('disable');
        return;
    }
    var row = $('#GoodsTable').datagrid('getSelected');
    if (row) {
        $.messager.confirm('confirm', '確定要刪除選中的記錄嗎？', function(r) {
            if (r) {
                //                debugger;
                var index = $('#GoodsTable').datagrid('getRowIndex', row);
                $('#GoodsTable').datagrid('deleteRow', index);
                $.ajax({
                    type: "POST",
                    contentType: "application/json",
                    url: "QuotationDetail.aspx/DeleteGoods",
                    data: "{'SamplePKID':'" + row.PKID + "'}",
                    dataType: 'json'
                });

                $('#GoodsTable').datagrid('reload');
                IsExpand = true;
                $('#btndeletegoods').linkbutton('disable');
                lastIndexgoods = -1;
                IsInitItem = false;
                CaluteExpenseGoods();
                // CaluteExpense();
            }
        });
    }
}
function SaveGoods(IsUpdate) {//保存產品信息
    if ($('#GoodsTable').datagrid('validateRow', lastIndexgoods)) {
        $('#GoodsTable').datagrid('endEdit', lastIndexgoods);
        var rows = $('#GoodsTable').datagrid('getChanges');
        if (rows.length > 0) {
            var isReload = false;
            for (var i = 0; i < rows.length; i++) {

                var testnum = parseInt(rows[i].Numbers);
                var newpaijia = 0
                var newshijizongjia = 0;
                var newcbjia = 0;
                var Shijidanjia = 0;
                newshijizongjia = rows[i].Shijizongjia;
                Shijidanjia = (newshijizongjia / testnum).toFixed(0);
                if (testnum * rows[i].Extend01 < rows[i].Extend04) {
                    newpaijia = rows[i].Extend04;
                }
                else {
                    newpaijia = testnum * rows[i].Extend01;
                }
                var curyouhui = newshijizongjia / newpaijia;
                if (curyouhui < $('#HiddenMinYOUhui').val()) {
                    $('#HiddenMinYOUhui').val(curyouhui.toFixed(4));
                }
                newcbjia = testnum * parseInt(rows[i].Extend03);
                var teststand = '/';
                if (rows[i].TestStandard.Trim() != '') {
                    teststand = rows[i].TestStandard.Trim();
                }
                var remark = '/';
                if (rows[i].Remark.Trim() != '') {
                    remark = rows[i].Remark.Trim();
                }
                var testitempkid = parseInt(rows[i].TestItemPKID);


                var DataParam = "{'mGoodsInfo':{'PKID':'" + rows[i].PKID + "','QuotationPKID':'" + $('#HiddenPKID').val()

                    + "','TestItemName':'" + rows[i].TestItemName + "','ServiceType':'" + rows[i].ServiceType
                    + "','ServicePKID':'" + rows[i].ServicePKID + "','TestItemPKID':'" + rows[i].TestItemPKID
                    + "','Numbers':'" + rows[i].Numbers
                    + "','BasicMoney':'" + rows[i].BasicMoney
                    + "','Paijia':'" + newpaijia
                    + "','Remark':'" + rows[i].Remark
                    + "','Extend01':'" + rows[i].Extend01
                    + "','Extend02':'" + newcbjia
                     + "','Extend03':'" + rows[i].Extend03
                     + "','Extend04':'" + rows[i].Extend04
                     + "','Extend05':'" + rows[i].Extend05
                     + "','Extend06':'" + rows[i].Extend06
                    + "','Shijidanjia':'" + Shijidanjia
                    + "','Shijizongjia':'" + newshijizongjia
                    + "','Remark':'" + remark
                     + "','TestStandard':'" + teststand + "'}}",
                 DataParam = DataParam.replace(/undefined/g, '0');
                $.ajax({
                    type: "POST",
                    contentType: "application/json",
                    async: false,
                    url: "QuotationDetail.aspx/SaveGoodsInfo",
                    data: DataParam,
                    dataType: 'json',
                    success: function() {

                    }
                });
            }
            InitGoodsInfo();

            //                if (mSamplerowgoods == 0) {
            //                    $("#GoodsTable").datagrid('options').url = '../action/JqueryS.ashx?Method=GoodsInfo&PKID=' + $('#HiddenPKID').val();
            //                    IsInitItem = false;
            //                    $('#GoodsTable').datagrid('reload');
            //                }

            mSamplerowgoods = $('#GoodsTable').datagrid('getRows').length;
            $('#btnSavegoods').linkbutton('disable');
            $('#btnCancelgoods').linkbutton('disable');



            $('#GoodsTable').datagrid('acceptChanges');
            CaluteExpenseGoods();
            //  SaveUpdateAndCaluteteExpense();
            $('#btnSavegoods').linkbutton('disable');
            $('#btnCancelgoods').linkbutton('disable');
        }
    }
    curindex = lastIndexgoods;
    canexpen = 0;
    lastIndexgoods = -1;
    $('#btnAddgoods').linkbutton('enable');
    $('#GoodsTable').datagrid('expandRow', curindex);
    // $('#SampleTable').datagrid('expandRow', curindex);
    // document.getElementById ('afaddsample').click();
}
function CencelGoods() {//取消編輯樣品信息
    $('#GoodsTable').datagrid('cancelEdit', lastIndexgoods);
    $('#btnSavegoods').linkbutton('disable');
    $('#btnCancelgoods').linkbutton('disable');
    lastIndexgoods = -1;
}
function InitSampleInfo() {
    var Columnstring = "[["
    CanEditItem = $('#HiddenCanAdd').val() == "True";
    Columnstring = Columnstring + "{title:'No',field:'SampleXH',width:50,formatter:function(value,row,index){return (index+1)}},"
    if (CanEditItem) {
        Columnstring = Columnstring + "{title:'Add ',field:'Add', width:100,formatter:function(value,row,index) {return AndFor(row,index);} },"
    }
    Columnstring = Columnstring + "{ field:'PKID',hidden:true},{field:'QuotationPKID',hidden:true},"
    Columnstring = Columnstring + "{ field:'SampleName',title:'樣品名',width:'300',editor: { type: 'validatebox', options: {required: true} }},{field:'Numbers',title:'數量',width:'200',editor:{type: 'numberbox', options: {required: true} }}"


    Columnstring = Columnstring + ']]';
    Columnstring = eval(Columnstring);
    SampleInfo(Columnstring);
}

function SampleInfo(FieldInfo) {//綁定樣品信息
    var Toolbar = "";
    CanAdd = $('#HiddenCanAdd').val() == "True";
    if (CanAdd) { Toolbar = "#SampleButtons" }
    $('#SampleTable').datagrid({
        view: detailview,
        width: IEwidth,
        height: 'auto',
        toolTip: CanAdd ? '雙擊進行編輯' : "",
        toolbar: Toolbar,
        url: $('#HiddenPKID').val() != "0" ? '../action/JqueryS.ashx?Method=SampleInfo&PKID=' + $('#HiddenPKID').val() : "",
        columns: FieldInfo,
        onSelect: function(rowIndex) {
            if (lastIndex != rowIndex) {
                $('#btnDelete').linkbutton('enable');
            }
        },
        onLoadSuccess: function(dateInfo) {


            mSamplerow = dateInfo.rows.length;
            if (mSamplerow > 0) {

                if (parseInt($('#HiddenStateorder').val()) == 1 || parseInt($('#HiddenStateorder').val()) == 3 || parseInt($('#HiddenStateorder').val()) == 5 || parseInt($('#HiddenStateorder').val()) == 6) {
                    if (IsInitItem) {
                        IsExpand = true;
                        for (var index = 0; index < dateInfo.rows.length; index++) {
                            $('#SampleTable').datagrid('expandRow', index);
                        }
                    }
                }
            }
        },
        onDblClickRow: function(rowIndex, row) {
            if (SubEditIndex > -1) {
                $('#ddv-' + SampleEditIndex).datagrid('endEdit', SubEditIndex);
            }
            if (lastIndex != rowIndex && CanEditItem) {
                if ($('#SampleTable').datagrid('validateRow', lastIndex)) {
                    $('#SampleTable').datagrid('endEdit', lastIndex);

                    $('#SampleTable').datagrid('beginEdit', rowIndex);
                    $('#btnSave').linkbutton('enable');
                    $('#btnCancel').linkbutton('enable');

                    SaveSample(1);
                }
            }
            lastIndex = rowIndex;
        },
        detailFormatter: function(index, row) {
            return '<div style="padding:2px"><table id="ddv-' + index + '"></table></div>';
        },
        onExpandRow: function(index, row) {

            TestDetailInit('#ddv-' + index, index, row.PKID, row.Numbers, 0);


        }
    });
}

function TestDetailInit(tableID, index, SamplePKID, SampleNumber, ExistRow) { //測試項目信息初始化
    var EditString = "{field:'action', width:20,formatter:function(value, row, Subindex){ return EditItemFor(row," + index + ", Subindex ); } },"
    var iscustomer = $('#HiddenIsCustomer').val();
    var isleader = $('#HiddenIsLeader').val();
    if (Columnstring == "") {

        Columnstring = "[["
        Columnstring = Columnstring + "{ field:'SamplePKID',hidden:true ,editor:{type:'text'}},{ field:'PKID',hidden:true,editor:{type:'text'}},"
        Columnstring = Columnstring + "{ field:'ServicePKID',hidden:true,editor:{type:'text'}},{field:'TestItemPKID',hidden:true,editor:{type:'text'}},"
        Columnstring = Columnstring + "{ field:'ServiceType',title:'服務類別',width:'100', editor:{type:'text'}},"
        Columnstring = Columnstring + "{ field:'TestItemName',title:'測試項目',width:'100', editor:{type:'text'}},{field:'Numbers',title:'測試點數',width:'50',editor:{type: 'numberbox', options: { min: 1,precision: 1 , required: true}  }},"
        Columnstring = Columnstring + "{ field:'Extend06',title:'計價單位',width:'50',editor:{type:'text',options:{disabled:true}}},"

        if (iscustomer == 0) {
            Columnstring = Columnstring + "{ field:'Extend04',title:'基本金',width:'50' ,editor:{type:'text',options:{disabled:true}}},{ field:'Extend01',title:'牌價單價',width:'50',editor:{type:'text',options:{disabled:true}} },{ field:'Paijia',title:'牌價總價',width:'50' ,editor:{type:'text',options:{disabled:true}}},"

        }
        Columnstring = Columnstring + "{field:'Shijidanjia',title:'實際單價',width:'50',editor:{type:'text',options:{disabled:true}}},{ field:'Shijizongjia',title:'實際報價',width:'50',editor:{type: 'numberbox', options: { min: 1,precision: 3 ,required: true}  }},"

        if (iscustomer == 0) {
            Columnstring = Columnstring + "{ field:'Extend03',hidden:true,editor:{type:'text',options:{disabled:true}}},"
            if (isleader == 1) {
                Columnstring = Columnstring + "{ field:'Extend02',title:'成本總價',width:'50',editor:{type:'text',options:{disabled:true}}},{ field:'Profit',title:'利潤率',width:'50',editor:{type:'text',options:{disabled:true}}},"
            }
            else if (isleader == 0) {
                Columnstring = Columnstring + "{ field:'Extend02',hidden:true,editor:{type:'text',options:{disabled:true}}},{ field:'Extend05',hidden:true,editor:{type:'text',options:{disabled:true}}},"
            }
        }
        if (iscustomer == 0) {
            Columnstring = Columnstring + "{ field:'PerYouhui',title:'優惠比例',width:'50',editor:{type:'text',options:{disabled:true}}},"
        }
        Columnstring = Columnstring + "{field:'Remark',title:'樣品數',width:'50',editor: 'text'},{field:'TestStandard',title:'測試要求',width:'50',editor: 'text',styler: function(value,row,index){if (value.length >10){return 'background-color:#ffee00;color:red;';}}},"
        if (iscustomer == 0) {
            Columnstring = Columnstring + "{title:'歷史報價 ',field:'TestHistory', width:100,formatter:function(value,row,index) {return TestItemHistory(row);} },"
        }
        NoeditString = Columnstring;
        if (CanEditItem) {
            Columnstring = Columnstring + EditString;
        }
        Columnstring = Columnstring.substring(0, Columnstring.length - 1);

        Columnstring = Columnstring + ']]';
        Columnstring = eval(Columnstring);
        TestItemInit(tableID, index, SamplePKID, SampleNumber, ExistRow, Columnstring);
    }
    else {

        if (CanEditItem) {
            var ColumnInfo = NoeditString + EditString;
            ColumnInfo = ColumnInfo.substring(0, ColumnInfo.length - 1);
            ColumnInfo = eval(ColumnInfo + ']]');
            Columnstring = ColumnInfo;
        }
        TestItemInit(tableID, index, SamplePKID, SampleNumber, ExistRow, Columnstring);
    }

}
function TestItemInit(tableID, index, SamplePKID, SampleNumber, ExistRow, Columnstring) {
    var TestUrl = '../action/JqueryS.ashx?Method=GetTestItemBySamplePKID&SamplePKID=' + SamplePKID;

    $(tableID).datagrid({
        iconCls: 'icon-Manage',
        toolTip: CanEditItem ? '雙擊進行編輯' : "",
        nowrap: true,
        singleSelect: true,
        rownumbers: true,
        height: 'auto',
        idfield: 'PKID',
        url: TestUrl,

        width: IEwidth - 30,
        columns: Columnstring,
        onResize: function() {
            $('#SampleTable').datagrid('fixRowHeight');
            //$('#SampleTable').datagrid('fixDetailRowHeight', index);
        },
        onDblClickRow: function(subIndex, row) {
            if (lastIndex > -1) {
                if ($('#SampleTable').datagrid('validateRow', lastIndex)) {
                    $('#SampleTable').datagrid('endEdit', lastIndex);
                }
            }
            if (SubEditIndex != subIndex && CanEditItem) {
                if (SubEditIndex >= 0) {
                    if ($('#ddv-' + index).datagrid('validateRow', SubEditIndex)) {
                        $('#ddv-' + index).datagrid('endEdit', SubEditIndex);
                    } else {
                        return;
                    }
                }
                $('#ddv-' + index).datagrid('beginEdit', subIndex);


                $('#btnSave').linkbutton('enable');
                $('#btnCancel').linkbutton('enable');
            }
            $('#HidSamplePKID').val(row.SamplePKID);
            SubEditIndex = subIndex;
            SampleEditIndex = index;
            var rowIndex = subIndex;
            var TestItemPKID = $(tableID).datagrid('getEditor', { index: rowIndex, field: 'TestItemPKID' });
            var TestItemName = $(tableID).datagrid('getEditor', { index: rowIndex, field: 'TestItemName' });
            var Paijia = $(tableID).datagrid('getEditor', { index: rowIndex, field: 'Paijia' });
            var Extend03 = $(tableID).datagrid('getEditor', { index: rowIndex, field: 'Extend03' }); //成本單價
            var ServicePKID = $(tableID).datagrid('getEditor', { index: rowIndex, field: 'ServicePKID' });   //
            var Numbers = $(tableID).datagrid('getEditor', { index: rowIndex, field: 'Numbers' });
            var Extend06 = $(tableID).datagrid('getEditor', { index: rowIndex, field: 'Extend06' });
            var Extend05 = $(tableID).datagrid('getEditor', { index: rowIndex, field: 'Extend05' });
            var Extend04 = $(tableID).datagrid('getEditor', { index: rowIndex, field: 'Extend04' }); //基本金
            var Extend02 = $(tableID).datagrid('getEditor', { index: rowIndex, field: 'Extend02' });
            var Extend01 = $(tableID).datagrid('getEditor', { index: rowIndex, field: 'Extend01' });
            var Shijidanjia = $(tableID).datagrid('getEditor', { index: rowIndex, field: 'Shijidanjia' });
            var Shijizongjia = $(tableID).datagrid('getEditor', { index: rowIndex, field: 'Shijizongjia' });
            var Profit = $(tableID).datagrid('getEditor', { index: rowIndex, field: 'Profit' });
            var PerYouhui = $(tableID).datagrid('getEditor', { index: rowIndex, field: 'PerYouhui' });
            var Remark = $(tableID).datagrid('getEditor', { index: rowIndex, field: 'Remark' });
            var TestStandard = $(tableID).datagrid('getEditor', { index: rowIndex, field: 'TestStandard' });
            Numbers.target.bind('change', function() {
                if (Extend04.target.val() >= Numbers.target.val() * Extend01.target.val()) {
                    Paijia.target.val(Extend04.target.val());
                }
                else {
                    Paijia.target.val(Numbers.target.val() * Extend01.target.val());
                }
                Shijidanjia.target.val((Shijizongjia.target.val() / Numbers.target.val()).toFixed(1));
                PerYouhui.target.val((Shijizongjia.target.val() / Paijia.target.val() * 100).toFixed(2) + '%')
            });
            Shijizongjia.target.bind('change', function() {
                Shijidanjia.target.val((Shijizongjia.target.val() / Numbers.target.val()).toFixed(1));
                PerYouhui.target.val((Shijizongjia.target.val() / Paijia.target.val() * 100).toFixed(2) + '%')
            });

        },
        onLoadSuccess: function(dataInfo) {
            if (dataInfo.rows.length > 0) {
                if (ExistRow > 0) {
                    if (ExistRow == dataInfo.rows.length) {
                        TestItemRow = TestItemRow + 1;
                    }
                }
                else {
                    TestItemRow = TestItemRow + 1;
                }
            }
            setTimeout(function() {
                $('#SampleTable').datagrid('fixRowHeight');
                $('#SampleTable').datagrid('fixDetailRowHeight', index);
            }, 0);
        }
    });


}

function EditItemFor(row, index, Subindex) {
    return '<img  title="刪除" onclick="deleterow(' + index + ',' + Subindex + ');"   style="cursor:hand;"  src="../Images/ico/trash.png">';
}
function deleterow(index, subIndex) {
    $.messager.confirm('Confirm', '確定要刪除選中的記錄嗎?', function(r) {
        if (r) {
            var row = $('#ddv-' + index).datagrid('getSelected');
            $.ajax({
                type: "POST",
                contentType: "application/json",
                async: false,
                url: "QuotationDetail.aspx/DeleteTestItem",
                data: "{'TestItemPKID':'" + row.PKID + "'}",
                dataType: 'json'
            });
            CaluteExpense();
            $('#ddv-' + index).datagrid('deleteRow', subIndex);
            if ($('#ddv-' + index).datagrid('getRows').length == 0) {
                TestItemRow = TestItemRow - 1;
            }
            $('#SampleTable').datagrid('fixDetailRowHeight', index);
            $('#SampleTable').datagrid('fixRowHeight', index);

        }
    });
}
function AddSample() {//添加樣品信息,首先保存申請單信息
    if (SubEditIndex > -1) {
        if ($('#ddv-' + SampleEditIndex).datagrid('validateRow', SubEditIndex)) {
            $('#ddv-' + SampleEditIndex).datagrid('endEdit', SubEditIndex);
        }
    }
    //    document.getElementById('LinkGetPDF').style.display = "inline";
    var SampleIndex = $('#SampleTable').datagrid('getRows').length;
    for (var index = 0; index < SampleIndex; index++) {
        $('#SampleTable').datagrid('collapseRow', index);
        IsExpand = false;
    }
    var Result = $("form").form("validate");
    if (Result) {
        var applyPKID = $("#HiddenPKID").val();
        if (applyPKID == "0") {
            $.ajax({
                type: "POST",
                contentType: "application/json",
                url: "QuotationDetail.aspx/SaveQuotationInfo",
                data: "{'mQuotation':{'QuotationNO':'" + $('#TxtQuotationNO').val() + "','CustomerPKID':'" + $('#HiddenCustomerPKID').val() + "','CustomerName':'" + $('#HiddenCustomerName').val() + "','TestCategory':'" + $("input[name='RdoTestCategory']").val() + "','ContactName':'" + $('#HiddenContactName').val() + "','ContactPhone':'" + $('#HiddenContactPhone').val() + "','ContactEmail':'" + $('#HiddenContactEmail').val() + "','QuotaerName':'" + $('#TxtQuotater').val() + "','QuotaerPhone':'" + $('#TxtQuotaterPhone').val() + "','QuoteEmail':'" + $('#TxtQuotaterEmail').val() + "','QuoteDate':'" + $('#TxtQuotationDate').val() + "','HopeFinishDATE':'" + $('#TxtHopeFinishDate').val() + "','Extend04':'" + $('#HiddenQuoterFax').val() + "','Extend05':'" + $('#HiddenContactFax').val() + "'}}",
                dataType: 'json',
                success: function(msg) {
                    $("#HiddenPKID").val(msg.d);
                    document.getElementById("testremark").style.display = "inline";
                    parent.iFrameHeight();
                }
            });
        }

        if ($('#SampleTable').datagrid('validateRow', lastIndex)) {
            $('#SampleTable').datagrid('endEdit', lastIndex);
            $('#SampleTable').datagrid('insertRow', { index: SampleIndex,
                row: {
                    PKID: 0,
                    numbers: 1

                }
            });

            $('#btnSave').linkbutton('enable');
            $('#btnDelete').linkbutton('enable');
            $('#SampleTable').datagrid('beginEdit', SampleIndex);
            lastIndex = SampleIndex;

        }
    }
}


function DeleteSample() {//刪除樣品信息
    //        debugger;
    if (lastIndex > -1) {

        $('#SampleTable').datagrid('deleteRow', lastIndex);
        lastIndex = -1;
        $('#btnDelete').linkbutton('disable');
        $('#btnSave').linkbutton('disable');
        return;
    }
    var row = $('#SampleTable').datagrid('getSelected');
    if (row) {
        $.messager.confirm('confirm', '確定要刪除選中的記錄嗎？', function(r) {
            if (r) {
                //                debugger;
                var index = $('#SampleTable').datagrid('getRowIndex', row);
                $('#SampleTable').datagrid('deleteRow', index);
                $.ajax({
                    type: "POST",
                    contentType: "application/json",
                    url: "QuotationDetail.aspx/DeleteSample",
                    data: "{'SamplePKID':'" + row.PKID + "'}",
                    dataType: 'json'
                });

                var subRow = 0;
                try {
                    subRow = $('#ddv-' + index).datagrid('getRows').length;
                }
                catch (e) {
                    subRow = 0;
                }
                if (subRow > 0) {
                    TestItemRow = TestItemRow - 1;
                }

                $('#SampleTable').datagrid('reload');
                IsExpand = true;
                $('#btnDelete').linkbutton('disable');
                lastIndex = -1;
                IsInitItem = false;
                CaluteExpense();
            }
        });
    }
}
function SaveSample(IsUpdate) {//保存樣品信息
    if ($('#SampleTable').datagrid('validateRow', lastIndex)) {
        $('#SampleTable').datagrid('endEdit', lastIndex);
        var rows = $('#SampleTable').datagrid('getChanges');
        if (rows.length > 0) {
            var isReload = false;
            for (var i = 0; i < rows.length; i++) {
                var DataParam = "{'mSampleInfo':{'PKID':'" + rows[i].PKID + "','QuotationPKID':'" + $('#HiddenPKID').val()
                    + "','SampleName':'" + rows[i].SampleName

                    + "','Numbers':'" + (rows[i].Numbers == undefined ? 1 : rows[i].Numbers) + "' }}",
                 DataParam = DataParam.replace(/undefined/g, '0');
                $.ajax({
                    type: "POST",
                    contentType: "application/json",
                    async: false,
                    url: "QuotationDetail.aspx/SaveSampleInfo",
                    data: DataParam,
                    dataType: 'json', success: function(msg) {
                        if (IsUpdate == 0) {
                            if (mSamplerow > 0) {
                                if (rows[i].PKID == 0) {
                                    rows[i].PKID = msg.d;
                                    var refreshIndex = $('#SampleTable').datagrid('getRowIndex', rows[i])
                                    $('#SampleTable').datagrid('refreshRow', refreshIndex);
                                }
                            }
                        }
                    }
                });
            }
            if (IsUpdate == 0) {

                if (mSamplerow == 0) {
                    $("#SampleTable").datagrid('options').url = '../action/JqueryS.ashx?Method=SampleInfo&PKID=' + $('#HiddenPKID').val();
                    IsInitItem = false;
                    $('#SampleTable').datagrid('reload');
                }

                mSamplerow = $('#SampleTable').datagrid('getRows').length;
                $('#btnSave').linkbutton('disable');
                $('#btnCancel').linkbutton('disable');


            }
            $('#SampleTable').datagrid('acceptChanges');

            //  SaveUpdateAndCaluteteExpense();
            $('#btnSave').linkbutton('disable');
            $('#btnCancel').linkbutton('disable');
        }
        curindex = lastIndex;
        if (curindex == 0) {
            canexpen = 1;
        }
        lastIndex = -1;
        SaveUpdateTestDetail();
        $('#btnAdd').linkbutton('enable');
        $('#SampleTable').datagrid('expandRow', curindex);
    }

    // $('#SampleTable').datagrid('expandRow', curindex);
    // document.getElementById ('afaddsample').click();
}
var canexpen = 0;
var curindex = 0;
document.onmousemove = function move(event) {
    if (curindex == 0 && canexpen == 1) {
        $('#SampleTable').datagrid('expandRow', curindex);

        var dc = $.data(SampleTable, 'datagrid').dc;
        var expander = dc.body1.find('div.datagrid-row-expander[row-index=' + curindex + ']');
        if (expander.hasClass('datagrid-row-collapse')) {
            canexpen = 0;
        }
    }
}
function CencelSample() {//取消編輯樣品信息
    $('#SampleTable').datagrid('cancelEdit', lastIndex);
    $('#btnSave').linkbutton('disable');
    $('#btnCancel').linkbutton('disable');
    SubEditIndex = -1;
    lastIndex = -1;
}
function SetEditGetEquip(rowIndex, row) {
    var EquipControlNOEditor = $('#SampleTable').datagrid('getEditor', { index: rowIndex, field: 'SampleName' });
    var EquipClientEditor = $('#SampleTable').datagrid('getEditor', { index: rowIndex, field: 'SampleName' });

}
function AftAddsample() {
    $('#SampleTable').datagrid('expandRow', curindex);
}

function AddTestItem(index, SamplePKID, sampleS1) {

    var result = $("form").form("validate");
    if (result) {



        $('#HidSamplePKID').val(SamplePKID);
        var ItemIndex = $('#ddv-' + index).datagrid('getRows').length;
        SampleEditIndex = index;
        SubEditIndex = ItemIndex;
        if ($('#ddv-' + index).datagrid('validateRow', ItemLastIndex)) {
            $('#ddv-' + index).datagrid('endEdit', ItemLastIndex);
            $('#ddv-' + index).datagrid('appendRow', {
                PKID: 0,
                SamplePKID: SamplePKID,
                ServicePKID: 0,
                TestItemPKID: 0,
                ServiceType: '',
                TestItemName: '',
                Numbers: 0,
                Extend06: '',
                Extend04: '',
                Extend01: '',
                Paijia: 0,
                Shijidanjia: 0,
                Shijizongjia: 0,
                Extend03: '',
                Extend02: '',
                Profit: 0,
                Extend05: '',
                PerYouhui: 0,
                Remark: '',
                TestStandard: '',
                TestHistory: ''

            });
            $('#btnAdd').linkbutton('disable');
            $('#btnSave').linkbutton('enable');
            $('#btnDelete').linkbutton('enable');
            $('#ddv-' + index).datagrid('beginEdit', ItemIndex);
            ItemLastIndex = ItemIndex;
            var tableID = '#ddv-' + index;

            $(tableID).datagrid('selectRow', ItemLastIndex);
            $(tableID).datagrid('beginEdit', ItemLastIndex);
            var row = $(tableID).datagrid('getSelected');
            InitTestService();
            SetEditing(tableID, ItemLastIndex, row);
        }
        $('#SampleTable').datagrid('fixRowHeight');
    }
}
function InitTestService() {
    if (TestServiceList == undefined) {
        $.ajax({
            type: "POST",
            contentType: "application/json",
            url: 'QuotationDetail.aspx/GetAllTestService',
            dataType: 'json',
            async: false,
            success: function(msg) {
                TestServiceList = msg.d;
            }
        });
    }
}
var TestServiceList;
function SetEditing(tableID, rowIndex, row) {


    var ServiceType = $(tableID).datagrid('getEditor', { index: rowIndex, field: 'ServiceType' });
    var ServicePKID = $(tableID).datagrid('getEditor', { index: rowIndex, field: 'ServicePKID' });

    ServiceType.target.combobox({
        width: 100,
        panelHeight: 'auto',
        data: TestServiceList,
        valueField: 'Key',
        textField: 'Value',
        editable: false,
        onSelect: function(RowDate) {
            InitTestItem(RowDate.innerText, tableID, rowIndex, row);
            ServicePKID.target.val(RowDate.value);
            ServiceType.target.val(RowDate.innerText)
        }

    });
}

function InitTestItem(ServiceName, tableID, rowIndex, row) {
    var TestItemPKID = $(tableID).datagrid('getEditor', { index: rowIndex, field: 'TestItemPKID' });
    var TestItemName = $(tableID).datagrid('getEditor', { index: rowIndex, field: 'TestItemName' });
    var Paijia = $(tableID).datagrid('getEditor', { index: rowIndex, field: 'Paijia' });
    var Extend03 = $(tableID).datagrid('getEditor', { index: rowIndex, field: 'Extend03' }); //成本單價
    var ServicePKID = $(tableID).datagrid('getEditor', { index: rowIndex, field: 'ServicePKID' });   //
    var Numbers = $(tableID).datagrid('getEditor', { index: rowIndex, field: 'Numbers' });
    var Extend06 = $(tableID).datagrid('getEditor', { index: rowIndex, field: 'Extend06' });
    var Extend05 = $(tableID).datagrid('getEditor', { index: rowIndex, field: 'Extend05' });
    var Extend04 = $(tableID).datagrid('getEditor', { index: rowIndex, field: 'Extend04' }); //基本金
    var Extend02 = $(tableID).datagrid('getEditor', { index: rowIndex, field: 'Extend02' });
    var Extend01 = $(tableID).datagrid('getEditor', { index: rowIndex, field: 'Extend01' });
    var Shijidanjia = $(tableID).datagrid('getEditor', { index: rowIndex, field: 'Shijidanjia' });
    var Shijizongjia = $(tableID).datagrid('getEditor', { index: rowIndex, field: 'Shijizongjia' });
    var Profit = $(tableID).datagrid('getEditor', { index: rowIndex, field: 'Profit' });
    var PerYouhui = $(tableID).datagrid('getEditor', { index: rowIndex, field: 'PerYouhui' });
    var Remark = $(tableID).datagrid('getEditor', { index: rowIndex, field: 'Remark' });
    var TestStandard = $(tableID).datagrid('getEditor', { index: rowIndex, field: 'TestStandard' });

    $.ajax({
        url: $('#HiddenCustomerName').val() == '深圳市华耀检测技术服务有限公司' ? "QuotationDetail.aspx/GetVIPTestItemByServiceName" : "QuotationDetail.aspx/GetTestItemByServiceName",
        contentType: "application/json",
        type: "post",
        data: "{'ServiceName': '" + ServiceName + "'}",
        dataType: 'json',
        success: function(msg) {
            var TestItemData = msg.d
            TestItemName.target.combobox({
                width: '105',
                data: TestItemData,
                required: true,
                valueField: 'Key',
                textField: 'Value',
                panelHeight: '200', editable: true, required: true,
                onLoadSuccess: function() {

                },
                onSelect: function(rowDate) {
                    var ItemIndex = rowDate.value.indexOf("$") + 1;
                    var CBunitIndex = rowDate.value.indexOf("&") + 1;
                    var PaijiaKaiIndex = rowDate.value.indexOf("#") + 1;
                    var PaijiaUnitIndex = rowDate.value.indexOf("*") + 1;
                    TestItemPKID.target.val(rowDate.value.substring(0, ItemIndex - 1));
                    Extend03.target.val(rowDate.value.substring(ItemIndex, CBunitIndex - 1));
                    Extend04.target.val(parseFloat(rowDate.value.substring(CBunitIndex, PaijiaKaiIndex - 1)));
                    Extend01.target.val(parseFloat(rowDate.value.substring(PaijiaKaiIndex, PaijiaUnitIndex - 1)));
                    Extend06.target.val(rowDate.value.substring(PaijiaUnitIndex, rowDate.value.length));
                    if (parseInt(Extend04.target.val()) > parseInt(Extend01.target.val())) {
                        Paijia.target.val(Extend04.target.val());
                    }
                    else {
                        Paijia.target.val(rowDate.value.substring(PaijiaKaiIndex, PaijiaUnitIndex - 1));
                    }
                    Numbers.target.val(1);
                    Shijizongjia.target.val(1);
                    PerYouhui.target.val(0);
                    TestItemName.target.val(rowDate.innerText);

                },
                onChange: function(newValue, oldValue) {

                }
            });
        }
    });
    Numbers.target.bind('change', function() {
        if (Extend04.target.val() >= Numbers.target.val() * Extend01.target.val()) {
            Paijia.target.val(Extend04.target.val());
        }
        else {
            Paijia.target.val(Numbers.target.val() * Extend01.target.val());
        }
        Shijidanjia.target.val((Shijizongjia.target.val() / Numbers.target.val()).toFixed(1));
        PerYouhui.target.val((Shijizongjia.target.val() / Paijia.target.val() * 100).toFixed(2) + '%')
    });
    Shijizongjia.target.bind('change', function() {
        Shijidanjia.target.val((Shijizongjia.target.val() / Numbers.target.val()).toFixed(1));
        PerYouhui.target.val((Shijizongjia.target.val() / Paijia.target.val() * 100).toFixed(2) + '%')
    });

}

var servicelength = 0;
//function AddTestDetail(index, SamplePKID, sampleS1) {
//    SampleNumber = sampleS1;
//    if (dialogInit == '0') {
//        var Columnstring = "[["
//        Columnstring = Columnstring + "{title:'No',field:'SampleXH',width:50,formatter:function(value,row,index){return (index+1)}},"
//        Columnstring = Columnstring + "{ field:'LbServicePKID',title:'服務類別PKID',hidden:true},"
//        Columnstring = Columnstring + "{ field: 'LbServiceName',width:300, title: '服務類別' }"
//        Columnstring = Columnstring + ']]';
//        Columnstring = eval(Columnstring);
//        $('#DlgTestItem').datagrid({
//            width: 750,
//            height: 440,
//            view: detailview,
//            checkOnSelect: false,
//            url: '../action/JqueryS.ashx?Method=GetTestService',
//            columns: Columnstring,

//            detailFormatter: function(index, row) {
//                return '<div style="padding:2px"><table id="ddvitem-' + index + '"></table></div>';
//            },
//            onLoadSuccess: function(dateInfo) {
//                servicelength = dateInfo.rows.length;
//                for (var index = 0; index < dateInfo.rows.length; index++) {

//                    ServiceLastindex[index] = 0;
//                    $('#DlgTestItem').datagrid('collapseRow', index);
//                    IsExpand = false;
//                }
//            },
//            onExpandRow: function(index, row) {
//                ALLTestItemInit('#ddvitem-' + index, index, row.LbServiceName, 0);
//            }

//        });
//    }
//    $('#dlgTestItemDetail').dialog({
//        modal: true,
//        buttons: [{
//            text: 'Save',
//            iconCls: 'icon-ok',
//            plain: true,
//            handler: function() {

//                SaveInsertTestDetail();

//            }
//        }, { text: 'Cancel',
//            iconCls: 'icon-cancel',
//            plain: true,
//            handler: function() { $('#dlgTestItemDetail').dialog('close'); }

//}],
//            onMove: function(left, top) {
//                DialogMove(left, top, '#dlgTestItemDetail');
//            }
//        });
//        $('#dlgTestItemDetail').dialog('open');
//        $('#HidSamplePKID').val(SamplePKID);
//        dialogInit = 1;
//        SampleIndex = index;
//    }
//    var SubitemEditIndex = -1;
//    function ALLTestItemInit(tableID, index, LbServiceName, ExistRow) {
//        var TestUrl = '../action/JqueryS.ashx?Method=GetAllItemByLbServiceName&LbServiceName=' + encodeURI(LbServiceName);
//        var Columnstring = "[["
//        Columnstring = Columnstring + "{ field:'ck2',checkbox:true},{ field:'TestItemPKID',hidden:true},"
//        Columnstring = Columnstring + "{ field:'LbServicePKID',title:'服務類別PKID',hidden:true},"
//        Columnstring = Columnstring + "{ field:'PKID',title:'測試類別PKID',hidden:true},"
//        Columnstring = Columnstring + "{ field: 'LbServiceName', title: '服務類別', hidden:true },"
//        Columnstring = Columnstring + "{ field: 'TestItemName', title: '測試項目', width: 130, align: 'left', sortable: true },"
//        Columnstring = Columnstring + "{ field: 'CBbootfee', title: '成本開機價',hidden:true, align: 'left'},"
//        Columnstring = Columnstring + "{ field: 'CBunitfee', title: '成本單價',hidden:true, align: 'left' },"
//        Columnstring = Columnstring + "{ field: 'DWPJbootfee', title: '基本金', width: 50, align: 'left' },"
//        Columnstring = Columnstring + "{ field: 'DWPJunitfee', title: '牌價單價', width: 50, align: 'left' },"
//        Columnstring = Columnstring + "{ field: 'DWDJbootfee', title: '底價開幾價', hidden:true},"
//        Columnstring = Columnstring + "{ field: 'DWDJunitfee', title: '底價單價', hidden:true},"
//        Columnstring = Columnstring + "{ field: 'Numbers', title: '測試點數', width: 55, align: 'left', editor:{type: 'numberbox',options:{ min: 1, required: true }} },"
//        Columnstring = Columnstring + "{ field: 'Extend1', title: '測試單位', width: 50, align: 'left'},"
//        Columnstring = Columnstring + "{ field: 'Shijizongjia', title: '實際報價', width: 55, align: 'left', editor:{type: 'numberbox'},options:{required: true} },"

//        Columnstring = Columnstring + "{ field: 'TestStandard', title: '測試標準', width: 60, align: 'left', editor: 'text' },"
//        Columnstring = Columnstring + "{ field: 'Remark', title: '樣品數量', width: 60, align: 'left', editor: 'text' }"

//        Columnstring = Columnstring + ']]';
//        Columnstring = eval(Columnstring);
//        $(tableID).datagrid({
//            nowrap: true,
//            singleSelect: false,
//            rownumbers: true,
//            height: 'auto',
//            idfield: 'PKID',
//            checkOnSelect: false,
//            url: TestUrl,
//            width: 700,
//            columns: Columnstring,
//            onResize: function() {
//                $('#DlgTestItem').datagrid('fixRowHeight');
//                //$('#SampleTable').datagrid('fixDetailRowHeight', index);
//            },
//            onCheck: function(subIndex, row) {
//                if (SubitemEditIndex >= 0) {
//                    if ($('#ddvitem-' + index).datagrid('validateRow', SubitemEditIndex)) {
//                        $('#ddvitem-' + index).datagrid('endEdit', SubitemEditIndex);
//                    }
//                    else {
//                        document.getElementsByName('ck2')[subIndex].checked = false;
//                        return;
//                    }
//                }
//                $('#ddvitem-' + index).datagrid('beginEdit', subIndex);

//                SubitemEditIndex = subIndex;
//                ServiceLastindex[index] = subIndex;
//            },
//            onLoadSuccess: function(dataInfo) {
//                if (dataInfo.rows.length > 0) {
//                    if (ExistRow > 0) {
//                        if (ExistRow == dataInfo.rows.length) {
//                            TestItemRow = TestItemRow + 1;
//                        }
//                    }
//                    else {
//                        TestItemRow = TestItemRow + 1;
//                    }
//                }
//                setTimeout(function() {
//                    $('#DlgTestItem').datagrid('fixRowHeight');
//                    $('#DlgTestItem').datagrid('fixDetailRowHeight', index);
//                }, 0);
//            },

//            onUncheck: function(subIndex) {
//                $('#ddvitem-' + index).datagrid('cancelEdit', subIndex);
//            }
//        });
//    }

//    var ExpandIndex = -1;
//    function SaveInsertTestDetail() {//保存測試項目信息
//        var addlength = 0;
//        for (var index = 0; index < servicelength; index++) {
//            if (document.getElementById("ddvitem-" + index).style.display == "none") {
//                var rows = $('#ddvitem-' + index).datagrid('getChecked');
//                $('#ddvitem-' + index).datagrid("endEdit", ServiceLastindex[index]);
//                if (rows == '') { }
//                else {

//                    $('#DlgTestItem').datagrid('acceptChanges');


//                    for (var i = 0; i < rows.length; i++) {
//                        if (rows[i].Numbers == undefined || rows[i].Numbers == "") {
//                            alert('請填寫數量');
//                            return false;

//                        }
//                        if (rows[i].Shijizongjia == undefined || rows[i].Shijizongjia == "") {
//                            alert('請填寫實際報價');
//                            return false;
//                        }

//                    }

//                    for (var i = 0; i < rows.length; i++) {
//                        addlength++;
//                        var TestNumber = rows[i].Numbers == "" ? 1 : rows[i].Numbers;
//                        var TestExpense = 0;
//                        var CB = 0;

//                        var paijia = 0;
//                        var remark = rows[i].Remark == "" ? "/" : rows[i].Remark;
//                        var stand = rows[i].TestStandard == "" ? "/" : rows[i].TestStandard;
//                        TestExpense = parseInt(rows[i].Shijizongjia);

//                        var shijidanjia = (TestExpense / TestNumber).toFixed(0);

//                        if (TestNumber * rows[i].DWPJunitfee < rows[i].DWPJbootfee) {
//                            paijia = rows[i].DWPJbootfee;
//                        }
//                        else {
//                            paijia = TestNumber * rows[i].DWPJunitfee;
//                        }

//                        CB = parseInt(TestNumber * parseInt(rows[i].CBunitfee));
//                        //                        if (rows[i].CBbootfee == 0) {
//                        //                            CB = parseInt(TestNumber * parseInt(rows[i].CBunitfee))   //成本價
//                        //                        }
//                        //                        else {
//                        //                            CB = parseInt((TestNumber - 1) * parseInt(rows[i].CBunitfee)) + parseInt(rows[i].CBbootfee);
//                        //                        }



//                        $('#TxtPaijia').val(parseInt($('#TxtPaijia').val()) + parseInt(paijia));
//                        $('#TxtDangqiangzongjia').val(parseInt($('#TxtDangqiangzongjia').val()) + TestExpense);
//                        $('#HiddenShijibaojia').val(parseInt($('#HiddenShijibaojia').val()) + TestExpense);
//                        $('#HiddenPaijia').val(parseInt($('#HiddenPaijia').val()) + parseInt(paijia));
//                        var bili = parseInt($('#HiddenShijibaojia').val()) / parseInt($('#HiddenPaijia').val());
//                        $('#HiddenYouhuibili').val(bili.toFixed(4));

//                        var curyouhui = TestExpense / paijia;
//                        if (curyouhui < $('#HiddenMinYOUhui').val()) {
//                            $('#HiddenMinYOUhui').val(curyouhui.toFixed(4));
//                        }

//                        bili = (bili * 100);
//                        $('#LbYouhuibili').html(bili.toFixed(2) + "%");


//                        $('#HiddenCB').val(CB + parseInt($('#HiddenCB').val()));


//                        var DataParam = "{'mTestItemDetailInfo':{'PKID':'0','QuotationPKID':'" + $('#HiddenPKID').val()
//                    + "','SamplePKID':'" + $('#HidSamplePKID').val()
//                    + "','TestItemName':'" + rows[i].TestItemName + "','ServiceType':'" + rows[i].LbServiceName
//                    + "','ServicePKID':'" + rows[i].LbServicePKID + "','TestItemPKID':'" + rows[i].TestItemPKID
//                    + "','Numbers':'" + TestNumber
//                    + "','BasicMoney':'" + "0"
//                    + "','Paijia':'" + paijia
//                    + "','Extend01':'" + rows[i].DWPJunitfee
//                    + "','Extend02':'" + CB
//                    + "','Extend03':'" + rows[i].CBunitfee
//                    + "','Extend04':'" + rows[i].DWPJbootfee
//                    + "','Extend05':'" + rows[i].CBbootfee
//                    + "','Extend06':'" + rows[i].Extend1
//                    + "','Extend07':'" + " "
//                    + "','Extend08':'" + " "
//                    + "','Extend09':'" + " "
//                    + "','Extend10':'" + " "
//                    + "','Shijidanjia':'" + shijidanjia
//                    + "','Shijizongjia':'" + rows[i].Shijizongjia
//                    + "','Remark':'" + remark
//                     + "','TestStandard':'" + stand + "'}}",
//                 DataParam = DataParam.replace(/undefined/g, '/');
//                        $.ajax({
//                            type: "POST",
//                            contentType: "application/json",
//                            async: false,
//                            url: "QuotationDetail.aspx/SaveTestDetailInfo",
//                            data: DataParam,
//                            dataType: 'json'
//                        });
//                    }
//                    $('#ddvitem-' + index).datagrid('uncheckAll');
//                }
//            }

//        }
//        $('#dlgTestItemDetail').dialog('close');
//        var dc = $.data(SampleTable, 'datagrid').dc;
//        var expander = dc.body1.find('div.datagrid-row-expander[row-index=' + SampleIndex + ']');
//        if (expander.hasClass('datagrid-row-expand')) {
//            var ExitRow = 0;
//            try {
//                ExitRow = $('#ddv-' + SampleIndex).datagrid('getRows').length;
//                if (ExitRow > 0) {
//                    TestDetailInit('#ddv-' + SampleIndex, SampleIndex, $('#HidSamplePKID').val(), SampleNumber, addlength);
//                }
//            }
//            catch (e) {

//            }
//            $('#SampleTable').datagrid('expandRow', SampleIndex);
//        }
//        else {
//            TestDetailInit('#ddv-' + SampleIndex, SampleIndex, $('#HidSamplePKID').val(), SampleNumber, addlength);
//        }

//        ExpandIndex = SampleIndex;
//    }
function SaveUpdateTestDetail() {
    if (lastIndex > -1) {
        SaveSample(1);
    }
    if (SampleEditIndex > -1 && SubEditIndex > -1) {
        if ($('#ddv-' + SampleEditIndex).datagrid('validateRow', SubEditIndex)) {
            $('#ddv-' + SampleEditIndex).datagrid('endEdit', SubEditIndex);

        }
        var rowcount = $('#SampleTable').datagrid('getRows').length;
        if (rowcount > 0) {
            for (var index = 0; index < rowcount; index++) {
                var rows = $('#ddv-' + index).datagrid('getChanges');
                if (rows.length > 0) {
                    for (var i = 0; i < rows.length; i++) {
                        var testnum = parseInt(rows[i].Numbers);
                        var newpaijia = 0
                        var newshijizongjia = 0;
                        var newcbjia = 0;
                        var Shijidanjia = 0;

                        var ishanshui = 0;
                        var RDOishanshui = document.getElementById("RDOishanshui");
                        //得到所有radio
                        var vRbtidList = RDOishanshui.getElementsByTagName("INPUT");
                        for (var k = 0; k < vRbtidList.length; k++) {
                            if (vRbtidList[k].checked) {
                                //var text = vRbtid.cells[i].innerText;
                                ishanshui = vRbtidList[k].value;  
                            }
                        }
                       // newshijizongjia = rows[i].Shijizongjia;
                        if (ishanshui == 1) {
                            newshijizongjia = (rows[i].Shijizongjia / 1.06).toFixed(2);
                        }
                        else {
                            newshijizongjia = rows[i].Shijizongjia;
                        }
                        Shijidanjia = (newshijizongjia / testnum).toFixed(0);
                        if (testnum * rows[i].Extend01 < rows[i].Extend04) {
                            newpaijia = rows[i].Extend04;
                        }
                        else {
                            newpaijia = testnum * rows[i].Extend01;
                        }
                        var curyouhui = newshijizongjia / newpaijia;
                        if (curyouhui < $('#HiddenMinYOUhui').val()) {
                            $('#HiddenMinYOUhui').val(curyouhui.toFixed(4));
                        }
                        newcbjia = testnum * parseInt(rows[i].Extend03);
                        var teststand = '/';
                        if (rows[i].TestStandard.Trim() != '') {
                            teststand = rows[i].TestStandard.Trim();
                        }
                        var remark = '/';
                        if (rows[i].Remark.Trim() != '') {
                            remark = rows[i].Remark.Trim();
                        }
                        var testitempkid = parseInt(rows[i].TestItemPKID);
                        if (testitempkid > 0) {
                            var DataParam = "{'mTestItemDetailInfo':{'PKID':'" + rows[i].PKID + "','QuotationPKID':'" + $('#HiddenPKID').val()
                    + "','SamplePKID':'" + $('#HidSamplePKID').val()
                    + "','TestItemName':'" + rows[i].TestItemName + "','ServiceType':'" + rows[i].ServiceType
                    + "','ServicePKID':'" + rows[i].ServicePKID + "','TestItemPKID':'" + rows[i].TestItemPKID
                    + "','Numbers':'" + rows[i].Numbers
                    + "','BasicMoney':'" + rows[i].BasicMoney
                    + "','Paijia':'" + newpaijia
                    + "','Remark':'" + rows[i].Remark
                    + "','Extend01':'" + rows[i].Extend01
                    + "','Extend02':'" + newcbjia
                     + "','Extend03':'" + rows[i].Extend03
                     + "','Extend04':'" + rows[i].Extend04
                     + "','Extend05':'" + rows[i].Extend05
                     + "','Extend06':'" + rows[i].Extend06
                    + "','Shijidanjia':'" + Shijidanjia
                    + "','Shijizongjia':'" + newshijizongjia
                    + "','Remark':'" + remark
                     + "','TestStandard':'" + teststand + "'}}",
                 DataParam = DataParam.replace(/undefined/g, '0');
                            $.ajax({
                                type: "POST",
                                contentType: "application/json",
                                async: false,
                                url: "QuotationDetail.aspx/SaveTestDetailInfo",
                                data: DataParam,
                                dataType: 'json',
                                success: function() {

                                }
                            });
                        }
                        else if (testitempkid <= 0) {           //testitepkid<0說明為套餐
                            var DataParam = "{'mTestItemDetailInfo':{'PKID':'" + rows[i].PKID + "','QuotationPKID':'" + $('#HiddenPKID').val()
                    + "','SamplePKID':'" + $('#HidSamplePKID').val()
                    + "','TestItemName':'" + rows[i].TestItemName + "','ServiceType':'" + rows[i].ServiceType
                    + "','ServicePKID':'" + rows[i].ServicePKID + "','TestItemPKID':'" + rows[i].TestItemPKID
                    + "','Numbers':'" + rows[i].Numbers
                    + "','BasicMoney':'" + rows[i].BasicMoney
                    + "','Paijia':'" + newpaijia
                    + "','Remark':'" + rows[i].Remark
                    + "','Extend01':'" + rows[i].Extend01
                    + "','Extend02':'" + newcbjia
                     + "','Extend03':'" + rows[i].Extend03
                     + "','Extend04':'" + rows[i].Extend04
                     + "','Extend05':'" + rows[i].Extend05
                     + "','Extend06':'" + rows[i].Extend06
                    + "','Shijidanjia':'" + Shijidanjia
                    + "','Shijizongjia':'" + newshijizongjia
                    + "','Remark':'" + remark
                     + "','TestStandard':'" + teststand + "'}}",
                 DataParam = DataParam.replace(/undefined/g, '0');
                            $.ajax({
                                type: "POST",
                                contentType: "application/json",
                                async: false,
                                url: "QuotationDetail.aspx/SaveTaocanInfo",
                                data: DataParam,
                                dataType: 'json',
                                success: function() {

                                }
                            });
                        }
                    }
                }
                TestDetailInit('#ddv-' + SampleEditIndex, SampleEditIndex, $('#HidSamplePKID').val(), 0, 0);
                //  $('#ddv-' + index).datagrid('acceptChanges');
            }
            CaluteExpense();
        }
        SubEditIndex = -1;
        $('#btnSave').linkbutton('disable');
        $('#btnCancel').linkbutton('disable');
    }
}
function CaluteExpense() {

    $.ajax({
        type: "POST",
        contentType: "application/json",
        url: "QuotationDetail.aspx/GetSumExpense",
        data: "{'QuotationPKID':" + $('#HiddenPKID').val() + "}",
        dataType: 'json',
        async: false,
        success: function(Result) {
            Result = Result.d;
            var fengeIndex = Result.indexOf("$") + 1;
            var fenggeindex2 = Result.indexOf("&") + 1;
            var minyouhuiindex = Result.indexOf("#") + 1;

            $('#TxtPaijia').val(Result.substring(0, fengeIndex - 1));
            $('#TxtDangqiangzongjia').val(Result.substring(fengeIndex, fenggeindex2 - 1));
            $('#HiddenPaijia').val(Result.substring(0, fengeIndex - 1));
            $('#HiddenShijibaojia').val(Result.substring(fengeIndex, fenggeindex2 - 1));
            $('#HiddenCB').val(Result.substring(fenggeindex2, minyouhuiindex - 1));

            upminyouhui(Result.substring(minyouhuiindex, Result.length));

            if (parseInt($('#HiddenPaijia').val()) == 0) {
                bili = 0;
                $('#HiddenYouhuibili').val(0);
            }
            else {
                bili = parseInt($('#HiddenShijibaojia').val()) / parseInt($('#HiddenPaijia').val());
                $('#HiddenYouhuibili').val(bili.toFixed(4));
                bili = (bili * 100);
            }
            $('#LbYouhuibili').html(bili.toFixed(2) + "%");

        }
    });
}
function CaluteExpenseGoods() {

    $.ajax({
        type: "POST",
        contentType: "application/json",
        url: "QuotationDetail.aspx/GetSumExpenseGoods",
        data: "{'QuotationPKID':" + $('#HiddenPKID').val() + "}",
        dataType: 'json',
        async: false,
        success: function(Result) {
            Result = Result.d;
            var fengeIndex = Result.indexOf("$") + 1;
            var fenggeindex2 = Result.indexOf("&") + 1;
            var minyouhuiindex = Result.indexOf("#") + 1;

            $('#TxtPaijia').val(Result.substring(0, fengeIndex - 1));
            $('#TxtDangqiangzongjia').val(Result.substring(fengeIndex, fenggeindex2 - 1));
            $('#HiddenPaijia').val(Result.substring(0, fengeIndex - 1));
            $('#HiddenShijibaojia').val(Result.substring(fengeIndex, fenggeindex2 - 1));
            $('#HiddenCB').val(Result.substring(fenggeindex2, minyouhuiindex - 1));

            upminyouhui(Result.substring(minyouhuiindex, Result.length));

            if (parseInt($('#HiddenPaijia').val()) == 0) {
                bili = 0;
                $('#HiddenYouhuibili').val(0);
            }
            else {
                bili = parseInt($('#HiddenShijibaojia').val()) / parseInt($('#HiddenPaijia').val());
                $('#HiddenYouhuibili').val(bili.toFixed(4));
                bili = (bili * 100);
            }
            $('#LbYouhuibili').html(bili.toFixed(2) + "%");

        }
    });
}
function upminyouhui(minyouhui) {
    $('#HiddenMinYOUhui').val(minyouhui);
}

function DialogMove(left, top, dialogID) {
    var right, bottom;
    var bodyWidth = $("body").width();
    var bodyHeight = $("body").height();
    var dialogwidth = $(dialogID).width();
    var dialogHeight = $(dialogID).height();
    if (left < 0) {
        $(dialogID).dialog("move", { left: 0, top: top });
    } else if ((left + dialogwidth) > (bodyWidth)) {
        right = bodyWidth - dialogwidth - 50;
        $(dialogID).dialog("move", { left: right, top: top });
    }
    if (top < 0) {
        $(dialogID).dialog("move", { left: left, top: 0 });
    }
}
function jisuanbili() {
    $('#HiddenShijibaojia').val($('#TxtDangqiangzongjia').val());
    var bili = parseInt($('#HiddenShijibaojia').val()) / parseInt($('#HiddenPaijia').val());
    $('#HiddenYouhuibili').val(bili.toFixed(4));
    bili = (bili * 100);
    $('#LbYouhuibili').html(bili.toFixed(2) + "%");

}
var IsExpand = false;
function ExpandInfo(ImgObj) {

    var rowcount = $('#SampleTable').datagrid('getRows').length;
    if (rowcount > 0) {
        if (IsExpand) {
            IsExpand = false;
            for (var index = 0; index < rowcount; index++) {
                $('#SampleTable').datagrid('collapseRow', index);
                $('#SampleTable').datagrid('fixRowHeight', index);
            }
        }
        else {
            IsExpand = true
            for (var index = 0; index < rowcount; index++) {
                $('#SampleTable').datagrid('expandRow', index);
                $('#SampleTable').datagrid('fixRowHeight', index);
            }

        }
    }
}
function searchcustomer() {
    $('#BtnSearch').click();
}
function relodpage() {
    window.location.reload();
}
String.prototype.Trim = function() { return this.replace(/(^\s*)|(\s*$)/g, ""); }
String.prototype.LTrim = function() { return this.replace(/(^\s*)/g, ""); }
String.prototype.RTrim = function() { return this.replace(/(\s*$)/g, ""); }
function tecsupportchange() {
    var ddl = document.getElementById("DPLtecsupport");
    var index = document.getElementById("DPLtecsupport").selectedIndex;
    if (index != -1) {
        document.getElementById("HiddenTecSupport").value = ddl.options[index].value;

    }

}

document.onmousewheel = function(evt) {
    evt = evt ? evt : event;
    parent.iFrameHeight();
}

   