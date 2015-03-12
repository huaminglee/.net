function dpllayerchange() {
    var ddl = document.getElementById("DPLNewGrade");
    var index = document.getElementById("DPLNewGrade").selectedIndex;

    if (ddl.options[index].text == "交易客戶") {
        document.getElementById("Txtlevel").style.display = "inline";
        document.getElementById("Lbji").style.display = "inline";
    }
    else {
        document.getElementById("Txtlevel").style.display = "none";
        document.getElementById("Lbji").style.display = "none";
    }
}