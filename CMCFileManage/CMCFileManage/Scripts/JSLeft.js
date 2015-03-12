function Expand(div) {
    var ddiv = document.getElementById(div)
    if (ddiv.style.display == 'none') {
        ddiv.style.display = 'block'
    }
    else { ddiv.style.display = 'none' }

}

function CheckChanged() {
    var frm = document.Form1;
    frm = document.forms.item(0)
    var boolAllChecked;
    var e;

    boolAllChecked = true;
    for (i = 0; i < frm.length; i++) {

        e = frm.elements[i];
        if (e.type == 'checkbox' && e.name.indexOf('CheckAll') != -1)

            if (e.checked == false) {
            boolAllChecked = false;
            break;
        }
    }
    for (i = 0; i < frm.length; i++) {


        e = frm.elements[i];

        if (e.type == 'checkbox' && e.name.indexOf('chkDelete') != -1) {

            if (boolAllChecked == false)
                e.checked = false;
            else
                e.checked = true;

            SelectRow(e);

        }
    }
}
function SelectRow(oCheckBox) {
    //	var oCheckBox = event.srcElement;

    var oTR = oCheckBox;
    while (oTR.tagName != "TR")
    { oTR = oTR.parentElement; }

    if (oCheckBox.checked) {
        oTR.style.cssText = "background-color: #d6deec"
        oCheckBox.style.cssText = oTR.style.cssText
    }
    else {
        oTR.style.cssText = oCheckBox.parentElement.style.cssText
        oCheckBox.style.cssText = oTR.style.cssText
    }
}
function Tr_ondblclick(href) {

    window.location.href = href;
}

function SelectDisable() {
    var tab = document.getElementById("div1")
    var ob = tab.getElementsByTagName("SELECT")
    alert(ob.length)
    for (var i = 0; i < ob.length; i++) {
        ob.item(i).setAttribute("disabled", "disabled")
    }
}

function show(_this) {
    document.getElementById("enlarge_images").innerHTML = "<img src='" + _this.src + "'  >";
}
function hide(_this) {
    document.getElementById("enlarge_images").innerHTML = "";
}
function move_layer(event) {

    event = event || window.event;
    if (enlarge_images != null) {
        enlarge_images.style.left = event.clientX + document.body.scrollLeft + 10;
        enlarge_images.style.top = event.clientY + document.body.scrollTop + 10;
    }

}





function IsNum(source, arguments) {
    var Num = document.getElementById("TxtNeedAmount")
    if (isNaN(Num.value) || Num.value == "")
        arguments.IsValid = false;
    else arguments.IsValid = true;

}


function ReAdd() {
    var txtHide = document.getElementById("TxtLstRecommendUse");
    var lstList = document.getElementById("LstRecommendUseList");
    var lstRe = document.getElementById("LstRecommendUse");
    var Rstr = lstList.options.item(lstList.selectedIndex).value;
    txtHide.value += Rstr + ",";
    var opt = new Option(Rstr, Rstr);
    lstRe.add(opt)
    lstList.remove(lstList.selectedIndex)


}
function ReRemove() {
    var txtHide = document.getElementById("TxtLstRecommendUse");
    var lstList = document.getElementById("LstRecommendUseList");
    var lstRe = document.getElementById("LstRecommendUse");
    var Rstr = lstRe.options.item(lstRe.selectedIndex).value;
    txtHide.value = txtHide.value.replace(Rstr + ",", "");
    var opt = new Option(Rstr, Rstr);
    lstList.add(opt)
    lstRe.remove(lstRe.selectedIndex)

}
function RemoveList() {
    // Dim i As Integer = IIf(s.LastIndexOf("<=") <> -1, s.LastIndexOf("<="), s.LastIndexOf(">="))
    var txtLim = document.getElementById("TxtLstLimitUse")
    var listBox = document.getElementById("LstLimitUse")
    var listlim = document.getElementById("LstLimitUseList")

    var str = txtLim.value;

    if (listBox.selectedIndex == -1) return;

    var Rstr = listBox.options.item(listBox.selectedIndex).value;
    //var Lstr = "";
    var i
    txtLim.value = str.replace(Rstr + ",", "");
//    alert(txtLim.value)
    if (Rstr.lastIndexOf("<=") != -1) {
        i = Rstr.lastIndexOf("<=");
    }
    else {
        i = Rstr.lastIndexOf(">=");
    }
    if (i > 0) {
        var listr = Rstr.substring(0, i);
        var opt = new Option(listr, listr);
        listlim.add(opt);
    }
    listBox.remove(listBox.selectedIndex);
}


function Conf() {
    var txtName = document.getElementById("Text1")
    var DDL = document.getElementById("DropDownList1")
    var txtNum = document.getElementById("TxtLimitNum");
    var txtLim = document.getElementById("TxtLstLimitUse")
    var listBox = document.getElementById("LstLimitUse")
    var listlim = document.getElementById("LstLimitUseList")
    if (txtNum.value != "" && txtName.value != "") {
        var val = txtName.value + DDL.options.item(DDL.selectedIndex).value + txtNum.value
        txtLim.value += val + ',';
        listBox.add(new Option(val, val));
        var opt = new Option(txtName.value, txtName.value)

        listlim.remove(listlim.selectedIndex);

        hideD('light2');
        txtName.value = "";
        txtNum.value = "";
    }
    else {
        alert("數值不能為空！");
      
        txtNum.value = "";
    }
}

function LoadList() {
    var txtLim = document.getElementById("TxtLstLimitUse")
    var listBox = document.getElementById("LstLimitUse")
    var strL = txtLim.value.split(",");

    for (i = 0; i < strL.length - 1; i++) {

        var option = new Option(strL[i], strL[i]);
        listBox.add(option)
    }
}

function showD(tag) {
    var light = document.getElementById(tag);
    var fade = document.getElementById('fade');
    var list = document.getElementById('LstLimitUseList');
    var txt = document.getElementById("Text1")
    light.style.display = 'block';
    fade.style.display = 'block';
    fade.style.height = document.body.offsetHeight;
    light.style.top = document.documentElement.scrollTop + (document.documentElement.clientHeight / 3) - 110;
    txt.value = list.options.item(list.selectedIndex).value;

}
function hideD(tag) {
    var light = document.getElementById(tag);
    var fade = document.getElementById('fade');
    light.style.display = 'none';
    fade.style.display = 'none';
}
var sInitColor = null;

function callColorDlg() {
    var dlgHelper = document.getElementById("dlgHelper");
    if (sInitColor == null)
    //display   color   dialog   box   
        var sColor = dlgHelper.ChooseColorDlg();
    else
        var sColor = dlgHelper.ChooseColorDlg(sInitColor);
    //change   decimal   to   hex
    sColor = sColor.toString(16);
    if (sColor.length < 6) {

        var sTempString = "000000".substring(0, 6 - sColor.length);
        sColor = sTempString.concat(sColor);
    }

    //document.Form1.lblColorShow.style  equal Null Unknow

    document.getElementById("TxtColor").style.backgroundColor = "#" + sColor;
    document.getElementById("hideColor").value = "#" + sColor;

}

function imgCallColor_onclick() {
    callColorDlg();
}

function showDL(tag,a) {
    var light = document.getElementById(tag);
    var fade = document.getElementById('fade');
    var txt = document.getElementById("ctl00_ContentPlaceHolder1_hiddenChagePKID")
  
    light.style.display = 'block';
    fade.style.display = 'block';
    fade.style.height = document.body.offsetHeight;
    light.style.top = document.documentElement.scrollTop + (document.documentElement.clientHeight / 3) - 80;
    txt.value = a.title;

}
function hideDL(tag) {
    var light = document.getElementById(tag);
    var fade = document.getElementById('fade');
    light.style.display = 'none';
    fade.style.display = 'none';
    var txt = document.getElementById("ctl00_ContentPlaceHolder1_hiddenChagePKID")
    txt.value = '';
}