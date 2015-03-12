var content = document.getElementById("Content");
var left = document.getElementById("Left");
var main = document.getElementById("Main");
var right = document.getElementById("Right");
var top1 = document.getElementById("Top");
var footer = document.getElementById("Footer");
var dot = document.getElementById("Dot");
var content = document.getElementById("Content");
var maintop = document.getElementById("MainTop");
var body = document.documentElement;
var Obj = null


function Compare(ob1, ob2, ob3) {
    if (ob3 != null) {
        if (ob1.clientHeight >= ob2.clientHeight && ob1.clientHeight >= ob3.clientHeight) { return ob1.clientHeight; }
        if (ob2.clientHeight >= ob1.clientHeight && ob2.clientHeight >= ob3.clientHeight) { return ob2.clientHeight; }
        if (ob3.clientHeight >= ob1.clientHeight && ob3.clientHeight >= ob2.clientHeight) { return ob3.clientHeight; }
    }
    else {
        if (ob1.clientHeight > ob2.clientHeight) { return ob1.clientHeight; }
        else { return ob2.clientHeight; }
    }

}
////使dot可拖动以改变左右区域大小/////////////////////////          
//body.onmouseup=MUp
//body.onmousemove=MMove
//dot.onmousedown=MDown
//////////////////////////////

//maintop.style.width = main.scrollWidth;

//if (dot != null) { dot.onclick = Dot; }

//if (Compare(left, main, right) < 600) { left.style.height = "600px"; }
//if (left.clientHeight != Compare(left, main, right)) { left.style.height = Compare(left, main, right) + "px"; }
//if (main.clientHeight != Compare(left, main, right)) { main.style.height = Compare(left, main, right) + "px"; }
//if (right.clientHeight != Compare(left, main, right)) { right.style.height = Compare(left, main, right) + "px"; }
//if (dot != null) { dot.style.height = Compare(left, main, right) + "px"; }

function GrdRowON(e) {
    var row;
    var str;
    var str_p;
    e = e || window.event;

    if (document.all)
    { str = "e.srcElement"; str_p = ".parentElement"; }
    else { str = "e.target"; str_p = ".parentNode"; }

    for (var i = 0; i < 6; i++) {
        if (eval(str).tagName != "TR") {
            if (eval(str).tagName == "TH") { break; }
            if (eval(str).tagName == "TABLE") { break; }
            str += str_p;
        }

        else {
            row = eval(str); break;
        }
    }

    if (row != null)
    { row.className = "GridRowSelect" }
}


function GrdRowOut(tb) {
    if (tb == null) return;
    if (tb.getElementsByTagName("TR").length <= 0) return;
    for (var i = 1; i < tb.getElementsByTagName("TR").length; i++) {
        if (i % 2 == 1) {
            var obj = tb.getElementsByTagName("TR")[i]
            obj.className = "GridItem"; //
        }
        else {
            var obj = tb.getElementsByTagName("TR")[i]
            obj.className = "GridAlterItem"
        }
    }
}

function Dot() {
    if (left.style.display != "none") {
        left.style.display = "none";
        main.style.width = "99%";
        SetCookie("Dot","0")            
        
    }
    else {
        left.style.display = "block"
        main.style.width = "";
        maintop.style.width = main.offsetWidth;
       SetCookie("Dot","1")
    }

}

function MDown() {
    Obj = dot
    dot.setCapture()
    pX = event.x - dot.offsetLeft;
}

function MMove() {
    if (Obj != null) {
        if (event.x - pX > 8)
        { left.style.width = (event.x - pX) > content.offsetWidth ? content.offsetWidth - 8 : event.x - pX - 8 }
        main.style.width = (content.offsetWidth - left.offsetWidth - 8) > 0 ? (content.offsetWidth - left.offsetWidth - 8) : 0
    }
}

function MUp() {
    if (Obj != null) {
        Obj.releaseCapture();
        Obj = null;
    }
}

function SetCookie(name, value)
{
    var Days = 1; 
    var exp = new Date();  
    exp.setTime(exp.getTime() + Days * 24 * 60 * 60 * 1000);
    document.cookie = name + "=" + escape(value) + ";expires=" + exp.toGMTString();
}
function getCookie(name)
{
    var arr = document.cookie.match(new RegExp("(^| )" + name + "=([^;]*)(;|$)"));
    if (arr != null) return unescape(arr[2]); return null;

}
function delCookie(name)
{
    var exp = new Date();
    exp.setTime(exp.getTime() - 1);
    var cval = getCookie(name);
    if (cval != null) document.cookie = name + "=" + cval + ";expires=" + exp.toGMTString();
}