

/*填加選定的項目,針對ListBox
ActiveControlName : 控件名稱
AddData:填加的數據,允許為數組(Value1^Text1,Value2^Text2......)
*/
function AddSelectedItem(ActiveControlID, HideAuthID, AddDataList) {
    var ActiveControl = document.getElementById(ActiveControlID);
    if (ActiveControl == null) { return; }
    var HideAuth = document.getElementById(HideAuthID);
    HideAuth.value = "";
    var oldItemCount = ActiveControl.options.length;

    var flag = false;

    var AddData = AddDataList.split(",");
    for (var i = 0; i < AddData.length; i++) {

        flag = false;
        var selectText = AddData[i].substring(0, AddData[i].indexOf("^"));
        var selectID = AddData[i].substring(AddData[i].indexOf("^") + 1);

        for (var j = 0; j < oldItemCount; j++) {
            if (selectID == ActiveControl.options[j].value) {
                flag = true;
                break;
            }
        }

        if (!flag) {
            var oOption = document.createElement("OPTION");
            ActiveControl.options.add(oOption);
            oOption.innerText = selectText;
            oOption.value = selectID;

        }
    }

    HideAuth.value += AddDataList;

}

function ShowActionInfo(oCheckBox,ActionID) 
{

    var ActionControl = document.getElementById(ActionID);
    
    if (oCheckBox == null)
    {
        return;
    }
    if (oCheckBox.checked) 
    {
       
        ActionControl.style.display = "block";
        ActionControl.style.visibility = "visible";
    }
    else 
    {
        ActionControl.style.display = "none";
        ActionControl.style.visibility = "hidden";
     }
}

    function changeNav(RilID, TrID) 
    {
       
        var mTr = TrID.substring(0, TrID.length - 1);
        for (var j = 0; j < RilID.cells.length; j++) {
            var TrObj = document.getElementById(mTr + j);
            if (RilID.cells(j).children[0].checked) {
                
               TrObj.style.display = "block";
               TrObj.style.visibility = "visible";
           }
            else
            {
                TrObj.style.display = "none";
                TrObj.style.visibility = "hidden";
            }
        }
        return;
    }
    function PageLayoutByRoles(DDlControlID,HideControlID,ControlArray) {
        var DDlControl = document.getElementById(DDlControlID);
        if (DDlControl == null) 
        {
            return;
        }
        else 
         {
            var HideControl = document.getElementById(HideControlID);
            HideControl.value = DDlControl.options[DDlControl.selectedIndex].value;
            var SelectValue = DDlControl.options[DDlControl.selectedIndex].value; 
            var TrDirControl = document.getElementById(ControlArray[0]);  
            switch (SelectValue)
            {
            //直接主管
            case "5":
               
                TrDirControl.style.display = "block";
                TrDirControl.style.visibility = "visible";
                break; 
                //特定步驟
            case "7":
                TrDirControl.style.display = "none";
                TrDirControl.style.visibility = "hidden";
                var TrStateControl = document.getElementById(ControlArray[1]);
                  TrStateControl.style.display = "block";
                  TrStateControl.style.visibility = "visible";
                  break;
              default:
                  if (ControlArray != null && ControlArray.length > 0) {
                      for (var j = 0; j < ControlArray.length; j++) {
                          var TrControl = document.getElementById(ControlArray[j]);
                          TrControl.style.display = "none";
                          TrControl.style.visibility = "hidden";
                      }            
                  }
              
            }
         }
     }

    

     function ChangeDirInfo(RilID, HidTypeID,TrID,ListControlID,HideListID) {
         var RioContrl = document.getElementById(RilID);
         var TrObj = document.getElementById(TrID);
         var HidTypeControl = document.getElementById(HidTypeID);
         for (var j = 0; j < RioContrl.cells.length; j++) {
             if (RioContrl.cells(j).children[0].checked) {
                     HidTypeControl.value = j;
                     TrObj.style.display = "block";
                     TrObj.style.visibility = "visible";
                     if (j == 0) {
                             var mListControl = document.getElementById(ListControlID);
                             var mHideList = document.getElementById(HideListID);
                             var InnerText = "[LC]當前人員";
                             var ItemValue = "50_" + 0;
                             var flag = false;
                             for (var k = 0; k < mListControl.options.length; k++) {
                                 var m = mListControl.options[k].value;
                                 if (ItemValue == m)
                                 {flag = true; break; }
                                 
                             }
                             if (!flag) {
                                 if (confirm("是否確定設定為當前人員的直接主管?")) {
                                 var oOption = document.createElement("OPTION");
                                 mListControl.options.add(oOption);
                                 oOption.innerText = InnerText;
                                 oOption.value = ItemValue;
                                 if (mHideList.value == null || mHideList.value == "") {
                                     mHideList.value = InnerText + "^" + ItemValue;
                                 }
                                 else {
                                     mHideList.value = mHideList.value + "," + InnerText + "^" + ItemValue;
                                 }
                             }
                         }
                     } 
             }
         }
     }

     function changeNav(RilID, TrID) {

         var mTr = TrID.substring(0, TrID.length - 1);
         for (var j = 0; j < RilID.cells.length; j++) {
             var TrObj = document.getElementById(mTr + j);
             if (RilID.cells(j).children[0].checked) {

                 TrObj.style.display = "block";
                 TrObj.style.visibility = "visible";
             }
             else {
                 TrObj.style.display = "none";
                 TrObj.style.visibility = "hidden";
             }
         }
         return;
     }

    
    function GetDLlSelectValue(DropStateID, txtStateID) {
        var DropState = document.getElementById(DropStateID);
        var txtState = document.getElementById(txtStateID);
        for (var i = 0; i < DropState.options.length; i++) {
            if (DropState.options[i].selected == true)
            { txtState.value = DropState.options[i].value }
        }
    }

    function CheckState(CheckDataIDArray,ErrorLabID) {
        //開始狀態：手動 不能批量審核
        if (CheckDataIDArray != null && CheckDataIDArray.length > 0) {
            var LblError = document.getElementById(ErrorLabID);
            LblError.innerText = "";
            var StartType = document.getElementById(CheckDataIDArray[0]);
            var RunTimeAction = document.getElementById(CheckDataIDArray[1]);
            var CountNum = document.getElementById(CheckDataIDArray[2]);
            var BatchAuditFlag = document.getElementById(CheckDataIDArray[3]);
            var Result=true;
            if (StartType.cells(0).children[0].children[0].checked) {  //開始狀態

                if (RunTimeAction.cells(1).children[0].checked) {   //自動
                    LblError.innerText = "開始狀態只能選擇手動辦理動作";
                    RunTimeAction.cells(0).children[0].checked = true;
                    Result = false;
                }
                if (parseInt(CountNum.value) > 1)
                 {
                     LblError.innerText += "\r\n開始狀態:簽核人數只能為1";
                     CountNum.value = "1";
                    Result= false;
                 }
                if (BatchAuditFlag.cells(1).children[0].checked) {
                    LblError.innerText += "\r\n開始狀態:不能進行批量審核";
                    BatchAuditFlag.cells(0).children[0].checked = true;
                    Result= false;
                }
                return Result;
            }
            else if (StartType.cells(1).children[0].children[0].checked) {  //運行狀態
             if (RunTimeAction.cells(1).children[0].checked) {   //自動
               if (parseInt(CountNum.value) > 1){
                
                   LblError.innerText = "辦理動作為自動時,簽核人數只能為1";
                   CountNum.value = "1";
                    Result= false;
                }
            }
            if (BatchAuditFlag.cells(1).children[0].checked) {
                if (parseInt(CountNum.value) > 1) {

                    LblError.innerText += "\r\n批量審核時：簽核人數只能為1";
                    BatchAuditFlag.cells(0).children[0].checked = true;
                    Result = false;
                }
            }
               return  Result;
            }

        }
             return true;
        }
        function ReturnOverPKID(RioControl, HidSelectValue) {
            if (RioControl.checked) {
                window.returnValue = HidSelectValue;
                closeSelf();
            }
        }
        