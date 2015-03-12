

function ___OpenModalWindow(url,width,height,showScroll,showStatus,allowResize,inArg)
{
    var showStyle = "dialogWidth:415px;dialogHeight:420px;scroll:no;status:no;resizable:no;";
    showStyle += "dialogWidth:" + width + "px;";
    showStyle += "dialogHeight:" + height + "px;";
    showStyle += "scroll:" + (showScroll ? "yes;" : "no;");
    showStyle += "status:" + (showStatus ? "yes;" : "no;");
    showStyle += "resizable:" + (allowResize ? "yes;" : "no;");
    if (url.indexOf("?") >= 0)
        url += "&Temp__Data__=" + String(Math.random());
    else
        url += "?Temp__Data__=" + String(Math.random());
    url = encodeURI(url);
    return window.showModalDialog(url, inArg, showStyle);
}


function ___SetWindowRreturnValue(returnValue)
{
    window.returnValue = returnValue;
}

function ___SelectTabPage(tabHeadBox, tabPageCtr)
{
    if(tabHeadBox.className == "TabItemSelected")return;
    var row = tabHeadBox.parentElement;
    var selectedIndex = -1;
    for(var i=0;i<row.cells.length-1;i++)
    {
        if (row.cells[i].className == "TabItemSelected")
        {
            row.cells[i].className = "TabItem";
            selectedIndex = i;
            break;
        }
    }
    tabHeadBox.className = "TabItemSelected";
    if (selectedIndex != -1)
        tabPageCtr.rows[selectedIndex].style.display = "none";
    tabPageCtr.rows[tabHeadBox.cellIndex].style.display = "";
}

function ___WindowInit()
{
    if (document.readyState=='complete')
    {
        var inCtrs = document.getElementsByTagName("INPUT");
        var arCtrs = document.getElementsByTagName("TEXTAREA");
        if (inCtrs)
        {
            for(var i=0;i<inCtrs.length;i++)
            {
                if (inCtrs[i].type.toLowerCase() == "text" && inCtrs[i].className.toLowerCase() == "notifytextboxcss")
                {
                    inCtrs[i].onfocus = ___NotifyTextBox_OnFocus;
                    inCtrs[i].onblur = ___NotifyTextBox_OnBlur;
                }
            }
        }
        if (arCtrs)
        {
            for(var i=0;i<arCtrs.length;i++)
            {
                if (arCtrs[i].className.toLowerCase() == "notifytextboxcss")
                {
                    arCtrs[i].onfocus = ___NotifyTextBox_OnFocus;
                    arCtrs[i].onblur = ___NotifyTextBox_OnBlur;
                }
            }
        }
        window.focus();
    }
    else
    {
        window.setTimeout(___WindowInit, 200);
    }
}
function ___NotifyTextBox_OnFocus()
{
    var ctr = event.srcElement;
    if (ctr.className.toLowerCase() == "notifytextboxcss" && !ctr.readOnly && !ctr.disabled)
    {
        ctr.className = "NotifyTextBoxSelectedCSS";
    }
}
function ___NotifyTextBox_OnBlur()
{
    var ctr = event.srcElement;
    if (ctr.className.toLowerCase() == "notifytextboxselectedcss" && !ctr.readOnly && !ctr.disabled)
    {
        ctr.className = "NotifyTextBoxCSS";
    }
}


function resizeDiv(id, attid, btid, height) {
    var divheight = 110;
    var resizediv = document.getElementById(id);
    if (resizediv) {
        if (height) {
            divheight = height;
        }
        resizediv.style.height = document.documentElement.offsetHeight - divheight > 52 ? document.documentElement.offsetHeight - divheight : 52;

        resizediv.style.width = document.documentElement.offsetWidth * 0.9;
    }

    var attdiv = document.getElementById(attid);
    if (attdiv) {
        attdiv.style.width = document.documentElement.offsetWidth * 0.9 / 0.95;
    }

    var buttondiv = document.getElementById(btid);
    if (buttondiv) {
        buttondiv.style.width = document.documentElement.offsetWidth * 0.9;
    }
}

function openFile(id, filename) {
    window.open('Board.aspx?Action=Common/ucOpenFile&Guid=' + id + '&FileName=' + escape(filename));
    return false;
}


function RefreshMenuData() {
    top.frames["TopFrame"].GetNewTask();
}

function PageSetup_Null() {
    try {
        var HKEY_Root, HKEY_Path, HKEY_Key;
        HKEY_Root = "HKEY_CURRENT_USER";
        HKEY_Path = "\\Software\\Microsoft\\Internet Explorer\\PageSetup\\";

        var Wsh = new ActiveXObject("WScript.Shell");
        HKEY_Key = "header";
        Wsh.RegWrite(HKEY_Root + HKEY_Path + HKEY_Key, "");
        HKEY_Key = "footer";
        Wsh.RegWrite(HKEY_Root + HKEY_Path + HKEY_Key, "");
    }
    catch (e)
    { }

}

function AttitudeTooltip() {
    alert('该文件正文已经归档,不能再填写意见,如需填写请和机要室联系');
    return false;
}



function SetScrollPositionForArchive(allcnt, cnt) {
    if (allcnt > 14) {
        document.getElementById('divtree').scrollTop = (document.getElementById('divtree').scrollHeight) / allcnt * cnt;
    }
}
//window.onload = ___WindowInit;
function fixPNG(myImage) {
    var arVersion = navigator.appVersion.split("MSIE");
    var version = parseFloat(arVersion[1]);
    if ((version >= 5.5) && (version < 7) && (document.body.filters)) {
        var imgID = (myImage.id) ? "id='" + myImage.id + "' " : "";
        var imgClass = (myImage.className) ? "class='" + myImage.className + "' " : "";
        var imgTitle = (myImage.title) ? "title='" + myImage.title + "' " : "title='" + myImage.alt + "' ";
        var imgStyle = "display:inline-block;" + myImage.style.cssText;
        var strNewHTML = "<span " + imgID + imgClass + imgTitle + " style=\"width:" + myImage.width + "px; height:" + myImage.height + "px;" + imgStyle + ";filter:progid:DXImageTransform.Microsoft.AlphaImageLoader(src=\'" + myImage.src + "\', sizingMethod='scale');\"></span>";
        myImage.outerHTML = strNewHTML
    }
} 
