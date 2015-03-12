var sealClassId="CLSID:C1FB7513-9A44-4C64-B653-63C6965D7F4C";
var obj;
var i=0;
var x=0;
var y=0;

//动态盖章
function doAddSeal(protectedData, sealPosition, x, y) {
    //创建一个Object对象(印章)
    obj = document.createElement("object");
    obj.width = 158;
    obj.height = 158;
    var mt = document.body.appendChild(obj);
    document.getElementById(sealPosition).appendChild(mt);

    //Obj的初始位置
    obj.style.left = 10 + "px";
    obj.style.top = 10 + "px";

    obj.style.position = "absolute";  //绝对位置
    obj.classid = sealClassId;
    obj.Authority = 0;  //限定用户的操作类型：0=用户只能查看；1=用户可以签章；2=用户可以签名；3=禁止移动 ；4=可撤消；8=可移动印章
    obj.ProtectedData = protectedData; // 受保护的值
    //alert(protectedData);

    //印章的显示模式
    obj.DrawModeUnsign = 0;   //指定操作未完成时控件显示的图案：0=空白
    obj.DrawMode = 18;    //指定控件的显示模式

    //触发签章或签名、批注的方法；为'true'时签章，否则为签名或批注。
    obj.SignSeal(true);

    //印章的位置
    obj.style.left = x + "px";
    obj.style.top = y + "px";

    //赋值
    document.getElementById("sealdata").value = obj.SignedData;//印章数据
    document.getElementById("hidProtectedData").value = obj.ProtectedData;//受保护的数据

    return true;
}

//动态签名
function doAddSign(protectedData, sealPosition, x, y)
{
    obj = document.createElement("object");  //创建一个Object对象(印章)
	obj.width = 158;
	obj.height = 158;
	var mt = document.body.appendChild(obj);
	document.getElementById(sealPosition).appendChild(mt);
	//Obj的初始位置
	obj.style.left = 10 + "px";
	obj.style.top = 10 + "px";
	
	obj.style.position = "absolute";  //绝对位置
	obj.classid = sealClassId;
	obj.Authority = 0;   //限定用户的操作类型：0=用户只能查看；1=用户可以签章；2=用户可以签名；3=禁止移动 ；4=可撤消；8=可移动印章
	obj.ProtectedData = protectedData;   //受保护的值
	
	//印章的显示模式
	obj.DrawModeUnsign = 0;   //指定操作未完成时控件显示的图案：0=空白
	obj.DrawMode = 18;    //指定控件的显示模式
	//触发签章或签名、批注的方法；为'true'时签章，否则为签名或批注。
	obj.SignSeal(false);
	
	//印章的位置
	obj.style.left = x + "px";
	obj.style.top = y + "px";
	
	//赋值
	document.getElementById("sealdata").value = obj.SignedData;//印章数据
	document.getElementById("hidProtectedData").value = obj.ProtectedData;//受保护的数据
}



