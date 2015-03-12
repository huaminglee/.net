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

maintop.style.width = main.scrollWidth;

if (dot != null) { dot.onclick = Dot; }

if (Compare(left, main, right) < 600) { main.style.height = (window.screen.height - 400) + "px"; }

if (left.clientHeight != Compare(left, main, right)) { left.style.height = Compare(left, main, right) + "px"; }
if (main.clientHeight != Compare(left, main, right)) { main.style.height = Compare(left, main, right) + "px"; }
if (right.clientHeight != Compare(left, main, right)) { right.style.height = Compare(left, main, right) + "px"; }
if (dot != null) { dot.style.height = Compare(left, main, right) + "px"; }
document.body.onunload = function() {
if (event.clientX <0 && event.clientY < 0 ) {
   delCookie("Dot")
}  


}

if (getCookie("Dot") != null) {

    if (getCookie("Dot") == '1') {
        left.style.display = "block"
        main.style.width = "";
        maintop.style.width = main.offsetWidth;
    }
    if (getCookie("Dot") == '0') {
        if (left.style.display != "none") {
            left.style.display = "none";
            main.style.width = "99%";
        }
    }
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