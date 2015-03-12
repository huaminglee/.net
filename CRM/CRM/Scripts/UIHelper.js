
///====================DataGrid Script========================
function CheckChanged() {
    var frm = document.forms(0);
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
        if (e.type == 'checkbox' && e.name.indexOf('ChkSelect') != -1) {
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

function ClearOtherCheck(oCheck) {
    var frm = document.forms(0);
    var e;

    if (oCheck.checked == true) {
        for (i = 0; i < frm.length; i++) {
            e = frm.elements[i];
            if (e.type == 'checkbox' && e.id != oCheck.id) {
                e.checked = false;
                SelectRow(e);
            }
        }
    }
}

function DeleteConfirm(Msg) {
    var frm = document.forms(0);
    var e;

    for (i = 0; i < frm.length; i++) {
        e = frm.elements[i];
        if (e.type == 'checkbox' && e.name.indexOf('ChkSelect') != -1 && e.checked == true) {
            return confirm(Msg);
        }
    }
    window.alert("請至少選擇一筆!");
    return false;
}

var oldBackgroundColor;
var oldForeColor;

function hideElement(elmID) {
    var obj;
    obj = window.document.getElementById(elmID);
    if (obj) {

        obj.style.visibility = "hidden";
    }
} //隱藏頁面元素

function showElement(elmID) {
    var obj;
    obj = window.document.getElementById(elmID);
    if (obj) {
        obj.style.visibility = "visible";
    }
}  //顯示頁面元素

function CoverMe() {
    var oImgs = document.body.all.tags("IMG");
    for (i = 0; i < oImgs.length; i++) {
        if (oImgs[i].DownDivID) {
            oDownDiv = document.getElementById(oImgs[i].DownDivID);
            if (oDownDiv) {
                oImgs[i].style.height = oDownDiv.offsetHeight;
                oImgs[i].style.width = oDownDiv.offsetWidth;
                pos = getAbsolutePos(oDownDiv);
                oImgs[i].style.top = pos.yPos;
                oImgs[i].style.left = pos.xPos;
            }
        }
    }
}

function getAbsolutePos(el) {
    if (el) {
        var obj = new Object();

        obj.xPos = el.offsetLeft;
        obj.yPos = el.offsetTop;
        tempEl = el.offsetParent;
        while (tempEl != null) {
            obj.xPos += tempEl.offsetLeft;
            obj.yPos += tempEl.offsetTop;
            tempEl = tempEl.offsetParent;
        }
        return obj;
    }
}

function disableTheSubmit() {
    var objs = document.getElementsByTagName('INPUT');
    for (var i = 0; i < objs.length; i++) {
        if (objs[i].type.toLowerCase() == 'submit') {
            objs[i].disabled = true;
        }
    }
} //禁止所有的提交按鈕執行，用於屏蔽重復提交


function TreeSingleSelect(treeID,checkNode)
{
    if(!treeID)
    return;
    var objs = document.getElementsByTagName("input");
    for(var i=0;i<objs.length;i++)
    {
        if(objs[i].type=='checkbox')
        {
            var obj=objs[i];
            if(obj.id.indexOf(treeID)!=-1)
            {
                if(obj!=checkNode)
                {
                    obj.checked=false;
                }
            }
        }
    }
}

function SetTreeNodeClickHander(treeID)
{
    var objs = document.getElementsByTagName("input");
    for(var i=0;i<objs.length;i++)
    {
        if(objs[i].type=='checkbox')
        {
            var obj=objs[i];
            if(obj.id.indexOf(treeID)!=-1)
            {
                objs[i].onclick=function(){TreeSingleSelect(treeID,this);};
            }
        }
    }
}