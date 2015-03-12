function ___CreateMainMenu(topMenuBox, menuFileName) {
    //debugger;
    var xmlDoc = ___CreateXmlDoc(menuFileName);
    var root = xmlDoc.documentElement;

    var result = "<table border='0' cellpadding='0' cellspacing='0' id='___MainMenu___' menuitemcount='" + root.childNodes.length + "'><tr>";
    result += "<td width=30></td>";
    for (var i = 0; i < root.childNodes.length; i++) {
        var classCss = "TopMenuItem";
        if (i == 0)
            classCss = "TopMenuSelected";
        result += "<td id='___MenuItem" + String(i) + "___' class='" + classCss + "' onmouseover='___Top_Mouse_Over(this)' onmouseout='___Top_Mouse_Out(this)' onclick=\"___Top_SelectMenu(this," + String(i) + ",'')\">" + ___ReadNodeAttrib(root.childNodes[i], "Title") + "</td>";
    }
    result += "</tr></table>";
    topMenuBox.innerHTML = result;
}
function ___Top_Mouse_Over(menuItem) {
    if (menuItem.className == "TopMenuSelected") return;
    menuItem.className = "TopMenuMoveItem";
}
function ___Top_Mouse_Out(menuItem) {
    if (menuItem.className == "TopMenuSelected") return;
    menuItem.className = "TopMenuItem";
}

function ___Top_SelectMenu(menuItem, menuTitle, showLeft, uri) {
    var menu = document.getElementById("___MainMenu___");
    if (menu) {
        var t = document.getElementById("___MainMenu___").getElementsByTagName("td");
        var len = t.length;
        for (var i = 0; i < len; i++) {
            if (t[i].className == "TopMenuSelected") {
                t[i].className = "TopMenuItem";
                break;
            }
        }
        menuItem.className = "TopMenuSelected";
        
        if (uri != "undefind" && uri != "#" && uri != "") {
            top.MainFrame.location = uri;
        }

        if (!isNaN(showLeft)) {
            if (showLeft == 0) {
                top.MainBox.cols = "0,0,*";
                return;
            }
            else if (showLeft == 1) {
                top.MainBox.cols = "230,9,*";
            }
        }
        top.LeftFrame.location = 'Board.aspx?Action=LeftMenu&menuTitle=' + menuTitle;
    }
}

function ___CreateLeftMenu(leftMenuBox, menuFileName) {
    var index = location.href;
    index = index.substr(index.lastIndexOf("?") + 1);
    var xmlDoc = ___CreateXmlDoc(menuFileName);
    var root = xmlDoc.documentElement.childNodes[Number(index)];
    var result = "<table id='___LeftMenu___' leftmenucount='" + root.childNodes.length + "' border='0' cellpadding='0' cellspacing='0' width='100%'>";

    for (var i = 0; i < root.childNodes.length; i++) {
        var node = root.childNodes[i];
        var pic = "Left_04.gif";
        var displayStyle = " style='display:none;' ";
        if (i == 0) {
            pic = "Left_05.gif";
            displayStyle = " ";
        }
        //Menuitem  start
        result += "<tr><td class='LeftMainMenuItem'>";
        result += "<table border='0' onclick='___Left_SelectMenu(" + i + ")' onmouseover='___Left_ChildMenu_Over(___LeftMenuItemText" + i + "___)' onmouseout='___Left_ChildMenu_Out(___LeftMenuItemText" + i + "___)' cellpadding='0' cellspacing='0' width='100%'><tr>";
        //result += "<td height='23' width='30' nowrap align='center'><img src='App_Resources/Images/Left_03.gif' /></td>";
        result += "<td width='100%' id='___LeftMenuItemText" + i + "___' class='LeftMainMenuItemText'>" + ___ReadNodeAttrib(node, "Title") + "</td>";
        //result += "<td width='30' nowrap align='center'><img id='___CtrPic" + i + "___' src='App_Resources/Images/" + pic + "' /></td>";
        result += "</tr></table>";
        result += " </td></tr>";
        //menuitem end
        //MenuContent start
        result += "<tr id='___MenuContent" + i + "___' " + displayStyle + "><td>";
        result += "<table border='0' cellpadding='0' cellspacing='2' width='98%'>";
        for (var j = 0; j < node.childNodes.length; j++) {
            var picidx = String(j + 1);
            while (picidx.length < 3) picidx = "0" + picidx;
            //result += "<tr><td height='20' width='30' nowrap align='center'><img width='18' height='18' src='App_Resources/Images/" + picidx + ".gif' /></td>";
            result += "<td width='100%' class='LeftChildItem' onclick=\"___Left_SelectMenuItem('" + ___ReadNodeAttrib(node.childNodes[j], "Uri") + "')\" onmouseover='___Left_MenuItem_Over(this)' onmouseout='___Left_MenuItem_Out(this)'>" + ___ReadNodeAttrib(node.childNodes[j], "Title") + "</td></tr>";
        }
        result += "</table>";
        result += "</td></tr>";
        //MenuContent end
    }

    result += "</table>";
    leftMenuBox.innerHTML = result;
}
function ___Left_ChildMenu_Over(menuItem) {
    menuItem.className = "LeftMainMenuItemTextMove";
}
function ___Left_ChildMenu_Out(menuItem) {
    menuItem.className = "LeftMainMenuItemText";
}
function ___Left_MenuItem_Over(menuItem) {
    if (menuItem.className == "LeftSelectItem") return;
    menuItem.className = "LeftChildItemMove";
}
function ___Left_MenuItem_Out(menuItem) {
    if (menuItem.className == "LeftSelectItem") return;
    menuItem.className = "LeftChildItem";
}
function ___Left_SelectMenuItem(uri, menuItem) {
    var t = document.getElementById("___LeftMenu___").getElementsByTagName("td");
    var len = t.length;
    for (var i = 0; i < len; i++) {
        if (t[i].className == "LeftSelectItem") {
            t[i].className = "LeftChildItem";
            break;
        }
    }
    menuItem.className = "LeftSelectItem";
    
    if (uri == "") {
        alert("请在MenuConfig.xml中配置链接地址！");
        return;
    }
    top.MainFrame.location = uri;
}

function ___Left_SelectSecMenuItem(uri, menuItem) {
    var t = document.getElementById("___LeftMenu___").getElementsByTagName("td");
    var len = t.length;
    for (var i = 0; i < len; i++) {
        if (t[i].className == "LeftSelectItem") {
            t[i].className = "LeftChildItem";
            break;
        }
    }
   // menuItem.className = "LeftSelectItem";

    if (uri == "") {
        alert("请在MenuConfig.xml中配置链接地址！");
        return;
    }

    if (uri.length > 4 && uri.substring(0, 4).toLowerCase() == "http") {
        TransferToThrdSystem(uri);
    }
    else {
        top.MainFrame.location = uri;
    }    
}

function ___Left_SelectMenu(menuIndex) {
    var menu = document.getElementById("___LeftMenu___");
    if (menu) {
        var itemCount = Number(menu.leftmenucount);
        for (var i = 0; i < itemCount; i++) {
            if (i != menuIndex) {
                var menuContent = document.getElementById("___MenuContent" + i + "___");
                if (menuContent.style.display != "none") {
                    menuContent.style.display = "none";
                    //document.getElementById("___CtrPic" + i + "___").src = "App_Resources/Images/Left_04.gif";
                }
            }
        }
        var selectedItem = document.getElementById("___MenuContent" + menuIndex + "___");
        if (selectedItem.style.display != "none") {
            selectedItem.style.display = "none";
            //document.getElementById("___CtrPic" + menuIndex + "___").src = "App_Resources/Images/Left_04.gif";
        }
        else {
            selectedItem.style.display = "";
            //document.getElementById("___CtrPic" + menuIndex + "___").src = "App_Resources/Images/Left_05.gif";
        }
    }
}