function CheckChanged(objID, VisibleFlag) {
    var ActionControl = document.getElementById(objID);
    if (VisibleFlag) {
       
        ActionControl.style.display = "block";
        ActionControl.style.visibility = "visible";
    }
    else {
        ActionControl.style.display = "none";
        ActionControl.style.visibility = "hidden";
    }
   
}
