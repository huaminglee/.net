/// <reference path="../NewDept.aspx" />
/// <reference path="../NewDept.aspx" />
/// <reference path="../NewDept.aspx" />
//只能输入0~9
function check_isnum() {
    if ((window.event.keyCode > 95 && window.event.keyCode < 106)
    || (window.event.keyCode > 47 && window.event.keyCode < 59)
    || window.event.keyCode == 8
    || window.event.keyCode == 9
    || window.event.keyCode == 46
    || window.event.keyCode == 37
    || window.event.keyCode == 38
    || window.event.keyCode == 39
    || window.event.keyCode == 40) {

        return true;
    }
    else {

        return false;
    }
}
//只能输入0~9或者 .
function check_isdecimal() {
    if ((window.event.keyCode > 95 && window.event.keyCode < 106)
    || (window.event.keyCode > 47 && window.event.keyCode < 59)
    || window.event.keyCode == 8
    || window.event.keyCode == 9
    || window.event.keyCode == 46
    || window.event.keyCode == 37
    || window.event.keyCode == 39
    || window.event.keyCode == 110
    || window.event.keyCode == 190
    ) {
        return true;
    }
    else {
        return false;
    }
}
//只能输入0~9或者 -
function check_isphone() {
    if ((window.event.keyCode > 95 && window.event.keyCode < 106)
    || (window.event.keyCode > 47 && window.event.keyCode < 59)
    || window.event.keyCode == 8
    || window.event.keyCode == 9
    || window.event.keyCode == 46
    || window.event.keyCode == 37
    || window.event.keyCode == 39
    || window.event.keyCode == 229
    || window.event.keyCode == 189
    ) {
        return true;
    }
    else {
        return false;
    }
}
//owner_obj  当前CheckBox对象，调用时直接写this
//table_obj  包含所有需要查询的checkbox的对象，例如table的id等
//chkall_obj 全选CheckBoxID
function SelectAllCheckboxes(owner_obj, table_obj, chkall_obj)///全选事件
{

    var allCount = AllChkCount(table_obj);
    var checkedCount = ForCheckedCount(table_obj);
    var allCheckObj = document.getElementById(table_obj);

    var i = allCheckObj.getElementsByTagName("input").length;

    for (j = 1; j < i; j++) {

        if (allCheckObj.getElementsByTagName("input")[j].type == "checkbox") {
            if (document.getElementById(chkall_obj).checked == true) {
                if (allCheckObj.getElementsByTagName("input")[j].checked == false) {
                    if (allCheckObj.getElementsByTagName("input")[j].disabled == false) {

                        allCheckObj.getElementsByTagName("input")[j].checked = true;
                        checkedCount++;
                    }
                }
            }
            else {
                if (allCheckObj.getElementsByTagName("input")[j].checked == true) {
                    if (allCheckObj.getElementsByTagName("input")[j].disabled == false) {

                        allCheckObj.getElementsByTagName("input")[j].checked = false;
                        checkedCount--;
                    }
                }
            }
        }
    }
}
//owner_obj  当前CheckBox对象，调用时直接写this
//table_obj  包含所有需要查询的checkbox的对象，例如table的id等
//chkall_obj 全选CheckBoxID
function chkChecked(owner_obj, table_obj, chkall_obj)///单选事件
{
    var allCount = AllChkCount(table_obj);
    var checkedCount = ForCheckedCount(table_obj);
    if (owner_obj.checked == true) {
        if (checkedCount == allCount) {
            document.getElementById(chkall_obj).checked = true;
        }
    }
    else {
        document.getElementById(chkall_obj).checked = false;
    }
}
//------table内checkbox全选取消20080909-------
//var allChecked;//全选是否被被勾选
//var checkedCount=0;//被勾选的数量
//var allCount;//数据总数
//var allCheckObj;//Table
function AllChkCount(obj)///计算数据总数
{
    var allCount = 0;
    var allCheckObj = document.getElementById(obj);
    var inputs = allCheckObj.getElementsByTagName("input")
    for (j = 0; j < inputs.length; j++) {
        if (inputs[j].type == "checkbox") {
            if (inputs[j].disabled == false) {
                allCount++;
            }
        }
    }
    return allCount = allCount - 1;//减去页面非数据行的数量
}

function ForCheckedCount(obj) {
    var checkedCount = 0;
    var allCheckObj = document.getElementById(obj);
    var inputs = allCheckObj.getElementsByTagName("input")
    for (j = 1; j < inputs.length; j++) {
        if (inputs[j].type == "checkbox") {
            if (inputs[j].disabled == false && inputs[j].checked) {
                checkedCount++;
            }
        }
    }
    return checkedCount;
}