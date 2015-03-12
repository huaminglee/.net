$(function() {
$('#SelectUserDialog').parent().bgiframe();
$('#SelectUserDialog').bgiframe();
});
function dpllayerchange() {
    var ddl = document.getElementById("DPLFileLayer");
    var index = document.getElementById("DPLFileLayer").selectedIndex;
    if (index != -1) {
        document.getElementById("HidFileLayer").value = ddl.options[index].text;
        if (ddl.options[index].text == "QM") {
            document.getElementById("Lbfilecate").style.display = "none";
            document.getElementById("DPLFileCategory").style.display = "none";
            document.getElementById("LbIso").style.display = "none";
            document.getElementById("DPLiso").style.display = "none";

        }
        else if (ddl.options[index].text == "QP") {
            document.getElementById("Lbfilecate").style.display = "none";
            document.getElementById("DPLFileCategory").style.display = "none";
            document.getElementById("LbIso").style.display = "inline";
            document.getElementById("DPLiso").style.display = "inline";
        }
        else if (ddl.options[index].text == "WI") {
            document.getElementById("Lbfilecate").style.display = "inline";
            document.getElementById("DPLFileCategory").style.display = "inline";
            document.getElementById("LbIso").style.display = "none";
            document.getElementById("DPLiso").style.display = "none";
        }
        else if (ddl.options[index].text == "QF") {
            document.getElementById("Lbfilecate").style.display = "none";
            document.getElementById("DPLFileCategory").style.display = "none";
            document.getElementById("LbIso").style.display = "none";
            document.getElementById("DPLiso").style.display = "none";
        }
        if ((getArgs('ischange') == '1') || document.getElementById("Hiddenischange").value == "1") {
            InitfileComobobox('LBFileNo', 'TxtFileName');
        }
    }
    else {
        var nulldata;
        $.ajax({
            url: "AddQCFileDetail.aspx/ReturnNullData",
            contentType: "application/json",
            type: "post",
            data: "",
            dataType: 'json',
            success: function(msg) {
                nulldata = msg.d;
                $('#LBFileNo').combobox({
                    width: '155',
                    data: nulldata,
                    required: true,
                    panelHeight: "200",
                    valueField: 'Key',
                    textField: 'Value',
                    onLoadSuccess: function() {
                        $('#LBFileNo').combobox('setText', "");

                    }
                });
            }
        });
    }

}
function getArgs(strParame) {
    var args = new Object();
    var query = location.search.substring(1); // Get query string
    var pairs = query.split("&"); // Break at ampersand
    for (var i = 0; i < pairs.length; i++) {
        var pos = pairs[i].indexOf('='); // Look for "name=value"
        if (pos == -1) continue; // If not found, skip
        var argname = pairs[i].substring(0, pos); // Extract the name
        var value = pairs[i].substring(pos + 1); // Extract the value
        value = decodeURIComponent(value); // Decode it, if needed
        args[argname] = value; // Store as a property
    }
    return args[strParame]; // Return the object
}


function LabTechniqueChargeCHANGE() {
    var ddl = document.getElementById("DPLLabTechniqueCharge");
    var index = document.getElementById("DPLLabTechniqueCharge").selectedIndex;
    document.getElementById("HidLabTechniqueCharge").value = ddl.options[index].value;

}
function deptchange() {
    var ddl = document.getElementById("DPLApplyDepth");
    var index = document.getElementById("DPLApplyDepth").selectedIndex;
    document.getElementById("HidApplyDeptText").value = ddl.options[index].text;
    document.getElementById("HidApplyDeptValue").value = ddl.options[index].value;
    if ((getArgs('ischange') == '1') || document.getElementById("Hiddenischange").value == "1") {
        $.ajax({
            url: "AddQCFileDetail.aspx/GetFileLayer",
            contentType: "application/json",
            type: "post",
            data: "{'ApplyDept': '" + ddl.options[index].text + "'}",
            dataType: 'json',
            success: function(msg) {
                var distValue = msg.d;
                if (distValue != undefined) {
                    var oldlength = document.getElementById('DPLFileLayer').all.length;
                    for (var k = 0; k < oldlength; k++) {
                        document.getElementById('DPLFileLayer').remove(0);
                    }
                    var distQL = distValue.split(",");
                    for (var i = 0; i < distQL.length; i++) {
                        var text = distQL[i];
                        document.getElementById('DPLFileLayer').add(new Option(text, text)); //绑定DropDownList的value值，text值

                    }
                }
                else {
                    var oldlength = document.getElementById('DPLFileLayer').all.length;
                    for (var k = 0; k < oldlength; k++) {
                        document.getElementById('DPLFileLayer').remove(0);
                    }
                }
                dpllayerchange();
            }
        });

    }
}
function isteachchange() {
    var vRbtid = document.getElementById("RdBIsTeach");
    var vRbtidList = vRbtid.getElementsByTagName("INPUT");
    for (var i = 0; i < vRbtidList.length; i++) {
        if (vRbtidList[i].checked) {
            var text = vRbtid.cells[i].innerText;
            var value = vRbtidList[i].value;
            if (text == "是") {
                document.getElementById("TxtTeachDept").style.display = "inline";
                document.getElementById("HidIsteach").value = "1";
            }
            else {
                document.getElementById("TxtTeachDept").style.display = "none";
                document.getElementById("HidIsteach").value = "0";
            }
        }
    }


}
function filecategorychange() {
    var ddl = document.getElementById("DPLFileCategory");
    var index = document.getElementById("DPLFileCategory").selectedIndex;
    document.getElementById("HidFileCategoryText").value = ddl.options[index].text;
    document.getElementById("HidFileCategoryValue").value = ddl.options[index].value;

}
function isochange() {
    var ddl = document.getElementById("DPLiso");
    var index = document.getElementById("DPLiso").selectedIndex;
    document.getElementById("HidISO").value = ddl.options[index].text;
}

function fenfachange(chbname, divname, hidfenfadanwei) {
    var chb = document.getElementById(chbname);
    var fenfa = parseInt(document.getElementById("Hidfenfadanwei").value);
    if (chb.checked == true) {
        document.getElementById(divname).style.display = "inline";
        fenfa = fenfa + parseInt(hidfenfadanwei);
        document.getElementById("Hidfenfadanwei").value = fenfa;
    }
    else {
        document.getElementById(divname).style.display = "none";
        fenfa = fenfa - parseInt(hidfenfadanwei);
        document.getElementById("Hidfenfadanwei").value = fenfa;
    }
}
function huishouchange(chbname, divname, hidfenfadanwei) {
    var chb = document.getElementById(chbname);
    var fenfa = parseInt(document.getElementById("Hidhuishoudanwei").value);
    if (chb.checked == true) {
        document.getElementById(divname).style.display = "inline";
        fenfa = fenfa + parseInt(hidfenfadanwei);
        document.getElementById("Hidhuishoudanwei").value = fenfa;
    }
    else {
        document.getElementById(divname).style.display = "none";
        fenfa = fenfa - parseInt(hidfenfadanwei);
        document.getElementById("Hidhuishoudanwei").value = fenfa;
    }
}
function huiqianchange(chbname, divname) {
    var chb1 = document.getElementById(chbname);
    if (chb1.checked == true) {
        document.getElementById(divname).style.display = "inline";
    }
    else {
        document.getElementById(divname).style.display = "none";
    }

}
var CodeData;
function InitfileComobobox(combocname, txtname) { //綁定文件編號
    var mSelectCode = $('#HidFileBH').val();
    var applydept = $('#HidApplyDeptText').val();
    var FileLayer = $('#HidFileLayer').val();
    // if (CodeData == undefined) {
    $.ajax({
        url: "AddQCFileDetail.aspx/GetFileInfo",
        contentType: "application/json",
        type: "post",
        data: "{'ApplyDept': '" + applydept + "','FileLayer':'" + FileLayer + "'}",
        dataType: 'json',
        success: function(msg) {
            CodeData = msg.d
            $('#' + combocname).combobox({
                width: '155',
                data: CodeData,
                required: true,
                panelHeight: "200",
                valueField: 'Key',
                textField: 'Value',
                //                onLoadSuccess: function() {
                //                    if (mSelectCode != "") {
                //                        $('#' + combocname).combobox('setText', mSelectCode);
                //                    }

                //                },
                onSelect: function(rowDate) {
                    var DepIndex = rowDate.value.indexOf("$") + 1;

                    $('#TxtFileName').val(rowDate.value.substring(DepIndex, rowDate.value.length));
                    $('#HidFilename').val(rowDate.value.substring(DepIndex, rowDate.value.length));
                    $('#LBFileNo').val("");
                    $('#HidFileBH').val(rowDate.innerText);
                },
                onChange: function(newValue, oldValue) {
                    $('#HidFileBH').val("");
                    $('#LBFileNo').val("");
                    // $('#TxtFileName').val("");

                }
            });
        }
    });
    //    }
    //    else {
    //        $('#' + combocname).combobox({
    //            width: '106',
    //            data: CodeData,
    //            required: true,
    //            panelHeight: "200",
    //            valueField: 'Key',
    //            textField: 'Value',
    //            onLoadSuccess: function() {
    //                if (mSelectCode != "") {
    //                    $('#' + combocname).combobox('setText', mSelectCode);
    //                }

    //            },
    //            onSelect: function(rowDate) {

    //                $('#hidExpenseCode').val(rowDate.innerText);
    //                var DepIndex = rowDate.value.indexOf("$") + 1;
    //                $('#' + txtname).val(rowDate.value.substring(DepIndex, rowDate.value.length));
    //                $('#' + "Hidden" + combocname).val(rowDate.innerText)
    //            },
    //            onChange: function(newValue, oldValue) {
    //                $('#' + "Hidden" + combocname).val("");
    //                $('#' + txtname).val("");


    //            }
    //        });

    //    }
}
function checkchange(oCheckBox) {
    var oTR = oCheckBox;
    var fenfa = parseInt(document.getElementById("Hidfenfadanwei").value);

    oTR = oTR.parentElement.parentElement;
    if (oCheckBox.checked) {
        oTR.children[1].className = "cssvisible";
        //        fenfa = fenfa + parseInt(Math.pow(2, parseInt(oCheckBox.id.substring(13, 15))));
        //        document.getElementById("Hidfenfadanwei").value = fenfa;
    }
    else {
        oTR.children[1].className = "cssnovisible";
        //        fenfa = fenfa - parseInt(Math.pow(2, parseInt(oCheckBox.id.substring(13, 15))));
        //        document.getElementById("Hidfenfadanwei").value = fenfa;
    }

}
function hscheckchange(oCheckBox) {
    var oTR = oCheckBox;
    var huishou = parseInt(document.getElementById("Hidhuishoudanwei").value);

    oTR = oTR.parentElement.parentElement;
    if (oCheckBox.checked) {
        oTR.children[1].className = "cssvisible";
        huishou = huishou + parseInt(Math.pow(2, parseInt(oCheckBox.id.substring(13, 15))));
        document.getElementById("Hidhuishoudanwei").value = huishou;
    }
    else {
        oTR.children[1].className = "cssnovisible";
        huishou = huishou - parseInt(Math.pow(2, parseInt(oCheckBox.id.substring(13, 15))));
        document.getElementById("Hidhuishoudanwei").value = huishou;
    }

}
function doPrint() {


    $("#LbApplyDept").html($("#HidApplyDeptText").val())
    document.getElementById("LbApplyDept").style.display = "inline";
    document.getElementById("DPLApplyDepth").style.display = "none";
    $("#LbApplyuser").html($("#TxtApplyUser").val())
    document.getElementById("LbApplyuser").style.display = "inline";
    document.getElementById("TxtApplyUser").style.display = "none";
    $("#LbApplyDate").html($("#TxtApplyDate").val())
    document.getElementById("LbApplyDate").style.display = "inline";
    document.getElementById("TxtApplyDate").style.display = "none";
    $("#LbFileVersion").html($("#TxtFileVersion").val())
    document.getElementById("LbFileVersion").style.display = "inline";
    document.getElementById("TxtFileVersion").style.display = "none";
    $("#LbTotalPage").html($("#TxtToTalPage").val())
    document.getElementById("LbTotalPage").style.display = "inline";
    document.getElementById("TxtToTalPage").style.display = "none";
    $("#LbFileName").html($("#TxtFileName").val())
    document.getElementById("LbFileName").style.display = "inline";
    document.getElementById("TxtFileName").style.display = "none";
    $("#LbFileLayer").html($("#HidFileLayer").val())
    document.getElementById("LbFileLayer").style.display = "inline";
    document.getElementById("DPLFileLayer").style.display = "none";
    $("#LbFileNOvalue").html($("#LBFileNo").val())
    document.getElementById("LbFileNOvalue").style.display = "inline";
    document.getElementById("LBFileNo").style.display = "none";
    $("#LbChangeReason").html($("#TxtChangeReason").val())
    document.getElementById("LbChangeReason").style.display = "inline";
    document.getElementById("TxtChangeReason").style.display = "none";
    $("#LbChangePreDes").html($("#TxtChangePreDes").val())
    document.getElementById("LbChangePreDes").style.display = "inline";
    document.getElementById("TxtChangePreDes").style.display = "none";
    $("#LbChangeBehDes").html($("#TxtChangeBehDes").val())
    document.getElementById("LbChangeBehDes").style.display = "inline";
    document.getElementById("TxtChangeBehDes").style.display = "none";
    $("#LbChangeBehDes").html($("#TxtChangeBehDes").val())
    document.getElementById("LbChangeBehDes").style.display = "inline";
    document.getElementById("TxtChangeBehDes").style.display = "none";
    var ddl = document.getElementById("DPLLabTechniqueCharge");
    var index = document.getElementById("DPLLabTechniqueCharge").selectedIndex;
    $("#LbLabTechniqueCharge").html(ddl.options[index].text);
    document.getElementById("LbLabTechniqueCharge").style.display = "inline";
    document.getElementById("DPLLabTechniqueCharge").style.display = "none";
    $("#LbPaperNumValue").html($("#LbPaperNum").val())
    document.getElementById("LbPaperNumValue").style.display = "inline";
    document.getElementById("LbPaperNum").style.display = "none";
    if ($("#HidFileLayer").val() == "QP") {
        $("#LbIsovalue").html($("#HidISO").val())
        document.getElementById("LbIsovalue").style.display = "inline";
        document.getElementById("DPLiso").style.display = "none";
    }
    else if ($("#HidFileLayer").val() == "WI") {
        $("#LbFileCategory").html($("#HidFileCategoryText").val())
        document.getElementById("LbFileCategory").style.display = "inline";
        document.getElementById("DPLFileCategory").style.display = "none";
    }
    document.getElementById("kg1").style.display = "none";
    document.getElementById("kg2").style.display = "none";
    document.getElementById("fd1").style.display = "none";
    document.getElementById("print2").style.display = "none";

    bdhtml = window.document.body.innerHTML;
    var oldhtml = bdhtml;

    sprnstr = "<!--startprint-->";
    eprnstr = "<!--endprint-->";
    prnhtml = bdhtml.substr(bdhtml.indexOf(sprnstr) + 17);
    prnhtml = prnhtml.substring(0, prnhtml.indexOf(eprnstr));
    window.document.body.innerHTML = prnhtml;
    PageSetup_Null();
    window.print();
    // window.document.body.innerHTML=oldhtml 
    // PageSetup_Default();
}

var hkey_root, hkey_path, hkey_key
hkey_root = "HKEY_CURRENT_USER"
hkey_path = "\\Software\\Microsoft\\Internet Explorer\\PageSetup\\"

// 设置页眉页脚为空
function PageSetup_Null() {
    try {
        var RegWsh = new ActiveXObject("WScript.Shell");
        hkey_key = "header";
        RegWsh.RegWrite(hkey_root + hkey_path + hkey_key, "");
        hkey_key = "footer";
        RegWsh.RegWrite(hkey_root + hkey_path + hkey_key, "");
    }
    catch (e) { }
}
// 设置页眉页脚为默认值
function PageSetup_Default() {
    try {
        var RegWsh = new ActiveXObject("WScript.Shell");
        hkey_key = "header";
        RegWsh.RegWrite(hkey_root + hkey_path + hkey_key, "&w&b页码，&p/&P");
        hkey_key = "footer";
        RegWsh.RegWrite(hkey_root + hkey_path + hkey_key, "&u&b&d");
    }
    catch (e) { }
} 


