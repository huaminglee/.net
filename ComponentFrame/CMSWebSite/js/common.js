//转换数据库中DateTime字段类型
function timeFormatter(value) {
    if (value!=null&&value != "undefined") {
        return value.replace("T", " ").split(".")[0];
    }
    return null;
}

//获取url中"?"符后的字串
function GetRequest() {
    var url = location.search; 
    var theRequest = new Object();
    if (url.indexOf("?") != -1) {
        var str = url.substr(1);
        strs = str.split("&");
        for (var i = 0; i < strs.length; i++) {
            theRequest[strs[i].split("=")[0]] = unescape(strs[i].split("=")[1]);
        }
    }
    return theRequest;
}
//替换文本中的URL为链接
function replaceReg(reg, str) {
    return str.replace(reg, "<a href='$1' target='_blank'>$1</a>");
}
//用正则分析法获取URL参数
function getQueryString(name) {
    var reg = new RegExp("(^|&)" + name + "=([^&]*)(&|$)", "i");
    var r = window.location.search.substr(1).match(reg);
    if (r != null) return unescape(r[2]); return null;
}
//全部选中
function checkAll() {
    var code_Value = document.all["checkboxMain"]; // 控制选中与取消  
    var code_Values = document.all['checkboxitem'];  // 所有的checkbox项
    if (code_Value.checked == true) {
        if (code_Values.length) {
            for (var i = 0; i < code_Values.length; i++) {
                code_Values[i].checked = true;
            }
        }
        else {
            code_Values.checked = true;
        }
    }
    else {
        //取消选中
        uncheckAll();
    }
}
//取消选中  
function uncheckAll() {
    var code_Values = document.all['checkboxitem'];
    if (code_Values.length) {
        for (var i = 0; i < code_Values.length; i++) {
            code_Values[i].checked = false;
        }
    } else {
        code_Values.checked = false;
    }
}
//检查是否有选择
function checkItem() {
    var isChecked = false;
    var code_Values = document.all['checkboxitem'];
    if (code_Values.length) {
        for (var i = 0; i < code_Values.length; i++) {
            if (code_Values[i].checked) {
                isChecked = true;
            }
        }
    }
    else {
        isChecked = code_Values.checked;
    }
    return isChecked;
}