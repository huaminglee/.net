function SetMemberSelectedText(TextboxControlClientID, HiddenControlClientID, Result) {
    var TextboxControl = document.getElementById(TextboxControlClientID);
    var HiddenIDControl = document.getElementById(HiddenControlClientID);

    if ((TextboxControl != null) && (HiddenIDControl != null) && (Result.length > 0)) {
        var ResultList = Result.split("*");
        var ItemList = ResultList[0];
        var SelectedItemList = ItemList.split(":");
        var SelectedItemName = SelectedItemList[0];

        if (SelectedItemList[1] != "") {
            var TmpResult = SelectedItemList[1].split("^");
            TextboxControl.innerText = TmpResult[1];
            TextboxControl.value = TmpResult[1];
            HiddenIDControl.value = TmpResult[1] + "^" + SelectedItemName + "_" + TmpResult[0];

        }
    }
} //解析從彈出窗口返回的計算數據


function CleanMemberSelectedText(TextboxControlClientID, HiddenControlClientID) {
    var TextboxControl = document.getElementById(TextboxControlClientID);
    var HiddenIDControl = document.getElementById(HiddenControlClientID);

    if ((TextboxControl != null) && (HiddenIDControl != null)) {
        HiddenIDControl.value = "";
        TextboxControl.innerText = "";
        TextboxControl.value = "";
    }
} //清空數據

function SetMemberSelected(ListControlClientID, HiddenControlClientID, HidSelectID, Result) {
    var ListControl = document.getElementById(ListControlClientID);
    var HiddenIDControl = document.getElementById(HiddenControlClientID);
    var HidSelectInfo = document.getElementById(HidSelectID);
    ListControl.options.length = 0;
    HiddenIDControl.value = "";
    HidSelectInfo.value = "";
    if ((ListControl != null) && (HiddenIDControl != null)) {
        if (ListControl.options.length == 0 && HiddenIDControl.value != "") {
            HiddenIDControl.value = "";
        }

        var ResultList = Result.split("*");
        for (var i = 0; i < ResultList.length; i++) {
            var ItemList = ResultList[i];
            var SelectedItemList = ItemList.split(":");

            var SelectedItemName = SelectedItemList[0];

            var SelectedItemValueList = null;
            if (SelectedItemList[1] != "") {
                SelectedItemValueList = SelectedItemList[1].split(",");
            }
            var SecondSelectedItemValueList = null;

            if (SelectedItemList[2] != "") {
                SecondSelectedItemValueList = SelectedItemList[2].split(",");
            }

            if (SelectedItemValueList != null) {
                for (var j = 0; j < SelectedItemValueList.length; j++) {
                    var flag = false;
                    var SelectItemData = SelectedItemValueList[j].split("^");
                    var InnerText = SelectItemData[1];

                    var ItemValue = SelectedItemName + "_" + SelectItemData[0];

                    for (var k = 0; k < ListControl.options.length; k++) {
                        var m = ListControl.options[k].value;
                        if (ItemValue == m)
                        { flag = true }

                    }
                    if (!flag) {
                        var oOption = document.createElement("OPTION");
                        ListControl.options.add(oOption);
                        oOption.innerText = InnerText;
                        oOption.value = ItemValue;
                        //添加已選擇的信息
                        
                            
                            HidSelectInfo.value += ItemValue + ",";
                      

                        if (HiddenIDControl.value == null || HiddenIDControl.value == "") {
                            HiddenIDControl.value = SelectItemData[1] + "^" + SelectedItemName + "_" + SelectItemData[0];
                        }
                        else {
                            HiddenIDControl.value = HiddenIDControl.value + "," + SelectItemData[1] + "^" + SelectedItemName + "_" + SelectItemData[0];
                        }
                    }
                }
            }
        }
    }
} //解析從彈出窗口返回的計算數據


function SetDropDownListChangeValue(DDlControlID, HideControlID) {
    var DDlControl = document.getElementById(DDlControlID);
    if (DDlControl == null) {
        return;
    }
    else {
        var HideControl = document.getElementById(HideControlID);
        HideControl.value = DDlControl.options[DDlControl.selectedIndex].value;
    }
}


/*刪除選定的項目*/
function DeleteItem(ListControlClientID, HiddenClientID, HidSelectID) {

    var ListControl = document.getElementById(ListControlClientID);
    var hiddenIDList = document.getElementById(HiddenClientID);

    if ((ListControl == null) || (hiddenIDList == null)) { return }

    if (ListControl.selectedIndex != -1) {
        var CurListItemValue = hiddenIDList.value.split(",");
        var newListItem = "";
        for (var i = 0; i < CurListItemValue.length; i++) {
            if (ListControl.selectedIndex != i) {
                newListItem += CurListItemValue[i] + ",";
            }
        }
        if (newListItem != null) {
            hiddenIDList.value = newListItem.substring(0, newListItem.length - 1);
        }
        else {
            hiddenIDList.value = "";
        }
        if (HidSelectID != '') {
            var HidSelectInfo = document.getElementById(HidSelectID);
            HidSelectInfo.value = HidSelectInfo.value.replace(ListControl.options[ListControl.selectedIndex].value + ",", "");
        }
        ListControl.remove(ListControl.selectedIndex);
    }
    else {
        window.alert("請至少選擇一筆資料!");
    }
}

/*上移選定的項目*/
function UpSelectedItem(ActiveControlName) {
    var ActiveControl = document.getElementById(ActiveControlName);
    if (ActiveControl == null) { return }

    if (ActiveControl.selectedIndex == 0) {
        window.alert("已移動至開始位置!");
    }
    else if (ActiveControl.selectedIndex == -1) {
        window.alert("請至少選擇一筆項目資料!");
    }
    else {
        var curIndex = ActiveControl.selectedIndex;
        var oOption = ActiveControl.options[curIndex];
        ActiveControl.remove(ActiveControl.selectedIndex);
        ActiveControl.options.add(oOption, curIndex - 1);
    }
}

/*下移選定的項目*/
function DownSelectedItem(ActiveControlName) {
    var ActiveControl = document.getElementById(ActiveControlName);
    if (ActiveControl == null) { return }

    if (ActiveControl.selectedIndex == ActiveControl.options.length - 1) {
        window.alert("已移動至最後位置!");
    }
    else if (ActiveControl.selectedIndex == -1) {
        window.alert("請至少選擇一筆項目資料!");
    }
    else {
        var curIndex = ActiveControl.selectedIndex;
        var oOption = ActiveControl.options[curIndex];
        ActiveControl.remove(ActiveControl.selectedIndex);
        ActiveControl.options.add(oOption, curIndex + 1);
    }
}
//將DropDownList選擇的信息加入LisrBox
//TypeInfo:為加入ListBox的類型人員：0:未設定;1;部門：2;角色：3群組：4;......
function AddEditArea(DropEditID, EditControlID, HideAuthID, TypeInfo) {

    var DropControl = document.getElementById(DropEditID);
    if ((DropControl.selectedIndex == -1) || (DropControl.selectedIndex == 0)) {
        window.alert("請選擇你要填加的權限控制名稱");
        return;
    }
    var selectedOption = DropControl.options[DropControl.selectedIndex];
    var AddData;
    if (TypeInfo == '7') {
        AddData = TypeInfo + ":" + selectedOption.value + "^[S]" + selectedOption.text + ":";
    }
    else {
        AddData = TypeInfo + ":" + selectedOption.value + "^" + selectedOption.text + ":";
    }

    SetMemberSelected(EditControlID, HideAuthID, '', AddData);
    DropControl.selectedIndex = 0;
}
//將InputText值加入ListBox
function AddTextToList(InputID, EditControlID, HidInfoID) {
    var InputControl = document.getElementById(InputID);
    if (InputControl.value == "") {
        window.alert("請設定你的自定義動作名稱");
        return;
    }
    var AddData = "0:" + InputControl.value + "^" + InputControl.value + ":";
    SetMemberSelected(EditControlID, HidInfoID, '', AddData);
    InputControl.value = "";
}