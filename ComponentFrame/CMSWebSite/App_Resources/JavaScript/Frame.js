// JScript 文件
function ___LeftFrameButtonOnClick(leftFrameButton)
{
    //debugger;
    if (top.MainBox.cols == "188,*")
    {
        leftFrameButton.src = "App_Resources/Images/Top_07.gif";
        top.MainBox.cols = "0,*";
    }
    else
    {
        leftFrameButton.src = "App_Resources/Images/Top_06.gif";
        top.MainBox.cols = "188,*";
    }
}
function ___LeftFrameButtonOnMsOver(leftFrameButton)
{
    leftFrameButton.className = "LeftButtonMove";
}
function ___LeftFrameButtonOnMsOut(leftFrameButton)
{
    leftFrameButton.className = "LeftButton";
}

function ___TopFrameButtonOnClick(topFrameButton, topLine0, topLine1)
{
    //debugger;
    if (top.TopBox.rows == "94,*")
    {
        top.TopBox.rows = "31,*";
        topLine0.style.display = "none";
        topLine1.style.display = "none";
    }
    else
    {
        top.TopBox.rows = "94,*";
        topLine0.style.display = "";
        topLine1.style.display = "";
    }
}
function ___TopFrameButtonOnMsOver(topFrameButton)
{
    topFrameButton.src = "App_Resources/Images/Top_11.gif";
}
function ___TopFrameButtonOnMsOut(topFrameButton)
{
    topFrameButton.src = "App_Resources/Images/Top_10.gif";
}

function ___FullFrameButtonOnClick(fullFrameButton, topLine0, topLine1)
{
    //debugger;
    if (top.TopBox.rows == "94,*" || top.MainBox.cols == "188,*")
    {
        top.TopBox.rows = "31,*";
        topLine0.style.display = "none";
        topLine1.style.display = "none";
        
        top.MainBox.cols = "0,*";
    }
    else
    {
        top.TopBox.rows = "94,*";
        topLine0.style.display = "";
        topLine1.style.display = "";
        
        top.MainBox.cols = "188,*";
    }
}
function ___FullFrameButtonOnMsOver(fullFrameButton)
{
    fullFrameButton.src = "App_Resources/Images/Top_09.gif";
}
function ___FullFrameButtonOnMsOut(fullFrameButton)
{
    fullFrameButton.src = "App_Resources/Images/Top_08.gif";
}


function ___SetPageTitleToTop(title) {
    if (top.TopFrame.document.getElementById("PageTitleShowBox")) {
        top.TopFrame.document.getElementById("PageTitleShowBox").innerHTML = document.title;
    }
}
function ___SetPageTopMenum(menum,menum2) {
//    if (top.TopFrame.document.getElementById(menum)) {
//        top.TopFrame.document.getElementById(menum).className = "TopMenuSelected";
//    }
//    if (top.TopFrame.document.getElementById(menum2)) {
//        top.TopFrame.document.getElementById(menum2).className = "TopMenuItem";
    //    }

    var tab = top.TopFrame.document.getElementById("___MainMenu___");
    for (var i = 0; i < tab.cells.length; i++) {
        var td = tab.cells[i];
        var title = td.innerHTML;
        if (title != "") {
            if (title == menum) {
                td.className = "TopMenuSelected";
            }
            else if (title = menum2) {
                td.className = "TopMenuItem";
            }
        }
    }
}

function ___SetPageTopMenumSelected(menum) {
    if (menum != "") {
        var tab = top.TopFrame.document.getElementById("___MainMenu___");
        for (var i = 0; i < tab.cells.length; i++) {
            var td = tab.cells[i];
            var title = td.innerHTML;
            if (title != "") {
                if (title == menum) {
                    td.className = "TopMenuSelected";
                }
                else {
                    td.className = "TopMenuItem";
                }
            }
        }
    }
}