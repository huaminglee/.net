// JScript 文件
function __vid_RegexCheckByIgnoreCase ( CtrID, RegexStr, ErrText )
{
	var val = true;
	var rex = new RegExp (RegexStr, "i");
	
	var ctr = __vid_GetControl (CtrID);
	if (!rex.test (ctr.value))
	{
		alert (ErrText);
		ctr.focus ();
		val = false;
	}
	return val;
}
//提到控件对象    控件ID
function __vid_GetControl( CtrID )
{
    return document.all( CtrID );
}

function GetEntity(CtrID)
{
	return eval("document.all." + CtrID);
}
/*检查日期*/
function CheckDate(CtrID, HelpStr)
{
	var e = GetEntity (CtrID);
	return CheckDataEx(e, HelpStr)
}

function checkfile (ctrId, errorText)
{
	var filePattern = "(\.rar|\.doc|\.txt|\.xls)$"; //扫描件文件类型
	return __vid_RegexCheckByIgnoreCase (ctrId, filePattern, errorText)
}

function checkpic (ctrId, errorText)
{
	var filePattern = "(\.jpg|\.gif|\.bmp|\.jpe|\.jpge|\.png)$"; //扫描件图片类型
	
	return __vid_RegexCheckByIgnoreCase (ctrId, filePattern, errorText)
}  


function checkpicJpg (ctrId, errorText)
{
	var filePattern = "(\.jpg)$"; //扫描件图片类型
	
	return __vid_RegexCheckByIgnoreCase (ctrId, filePattern, errorText)
}  

function CheckDataEx(Ctr, HelpStr)
{
	var e = Ctr;
	var str = e.value;
	var retVal = false;
	var reg=/^(\d{2,4})(\-|\/|\.|年)(\d{1,2})(\-|\/|\.|月)(\d{1,2})(\-|\/|\.|日|$)/;
	var r=reg.exec(str);
	if(r==null)
	{
		retVal = false;
	}
	else
	{
		var d=new Date(r[1],r[3]-1,r[5]);
		if(d.getFullYear()==r[1] && (d.getMonth()+1)==r[3] && d.getDate()==r[5])
		{
			retVal = true;//r[1]+"年"+r[3]+"月"+r[5]+"日";
		}
		else
		{
			retVal = false;
		}
	}
	if (!retVal)
	{
		alert(HelpStr + "\n参考格式：2000年12月31日、2000/12/31、2000.12.31、2000-12-31");
		//e.focus();
	}
	return retVal;
}


	
// 检查国内电话号码和传真
function CheckPhoneNum(PhoneNum)
{
	var Reg = /^\d{3}-?\d{6,8}|\d{4}-?\d{6,8}|\d{6,8}$/;
	var Result = false;
	
	if (Reg.test(PhoneNum))
	{
		Result = true;
	}
	else
	{
		Result = false;
	}

	return Result; 
}

// 检查手机号码
function CheckMobileNum(MobileNum)
{
	var Reg = /^(13\d|159)\d{8}$/;
	var Result = false;
	
	if(Reg.test(MobileNum))
	{
		Result = true;
	}
	else
	{
		Result = false;
	}
	
	return Result;
}

// 检查邮政编码
function CheckPostalcode(Postalcode)
{
	var Reg = /^[1-9]\d{5}$/;
	var Result = false;
	
	if (Reg.test(Postalcode))
	{
		Result = true;
	}
	else
	{
		Result = false;
	}

	return Result; 
}

// 检查电子邮箱
function CheckEmail(CID,HelpStr)
{
    
	var Reg = /^\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$/;
	var Result = false;
	
	if (Reg.test(CID.value))
	{	    
		Result = true;
	}
	else
	{
	    alert(HelpStr);
	    CID.focus();
		Result = false;
	}
	return Result; 
}

// 检查身份证号码
function CheckIdentity(CID)
	{
	    var Identity = CID.value;
		var Reg = /^-?(\d{15}|\d{17}(\d|x|X))$/;		
		if (Reg.test(Identity))
		{
			var num = Identity.length;	
			if(num == 15)
			{		
				var myYear = parseInt(Identity.substring(6,8));			
				if(myYear<10)
				{
					alert("身份证中的年份不正确！");	
					CID.focus();
					return false;		
				}
				var myMonth = parseInt(Identity.substring(8,10));
				if(myMonth >12)
				{
					alert("身份证中的月份不正确！");
					CID.focus();
					return false;									
				}
				var myDay = parseInt(Identity.substring(10,12));
				if(myDay >31)
				{
					alert("身份证中的日期不正确！");
					CID.focus();
					return false;					
				}
				return true;
				
			}
			else
			{				
				var theYear = parseInt(Identity.substring(6,10));
				if(theYear<1900 || theYear>2000)
				{
					alert("身份证中的年份不正确！");
					CID.focus();	
					return false;					
				}
				var theMonth = parseInt(Identity.substring(10,12));				
				if(theMonth>12)
				{
					alert("身份证中的月份不正确！");
					CID.focus();
					return false;					
				}
				var theDay = parseInt(Identity.substring(12,14));
				if(theDay >31)
				{
					alert("身份证中的日期不正确！");
					CID.focus();
					return false;					
				}
				return true;
			}			
		}
		else
		{
			if (Identity == "")
			{
				alert("身份证号码不能为空！");
				CID.focus();
				return false;
				
			}
			else
			{
				alert("身份证号码格式不正确！");
				CID.focus();
				return false;
				
			}
		}
	
}

// 检查正浮点数和整数
function CheckDecimal(CID,HelpStr)
{	
    var Result = true;
    var regSpace = /\s/g; 
    
    CID.value= CID.value.replace(regSpace, "");
    if(CID.value=="")
    {
        Result = false;
		alert(HelpStr);
		CID.focus();
		return Result;
    }
    var Reg = /^([1-9]\d*\.\d*|0\.\d*[1-9]\d*|0?\.0+|[1-9]\d*|0)$/;
	
	if (!Reg.test(CID.value))
	{
		Result = false;
		alert(HelpStr);
		CID.focus();
	}	
	return Result; 
}

// 检查浮点数和整数
function CheckALLDecimal(CID,HelpStr)
{	
    var Result = true;
    var Reg = /^([1-9]\d*\.\d*|0\.\d*[1-9]\d*|0?\.0+|[1-9]\d*|0)$/;
	
	if (!Reg.test(CID.value))
	{
		Result = false;
		alert(HelpStr);
		CID.focus();
	}	
	return Result; 
}
//检查浮点数和整数，可以为空
function CheckDecimalAllowNull(CID,HelpStr)
{
    var Result = true;
    var Reg = /^([1-9]\d*\.\d*|0\.\d*[1-9]\d*|0?\.0+|[1-9]\d*|0)$/;
    
	if(CID.value=="")
	    return Result;
	    
	if (!Reg.test(CID.value))
	{
		Result = false;
		alert(HelpStr);
		CID.focus();
	}	
	return Result;
}
// 检查整数
function CheckInt(Int)
{
	var Reg = /^([1-9]\d*|0)$/;
	var Result = false;
	
	if (Reg.test(Int))
	{
		Result = true;
	}
	else
	{
		Result = false;
	}

	return Result; 
}

// 检查正整数（包括0）
function CheckAllInt(Int)
{
	var Reg = /^-?([1-9]\d*|0)$/;
	var Result = false;
	
	if (Reg.test(Int))
	{
		Result = true;
	}
	else
	{
		Result = false;
	}

	return Result; 
}
//检查上传文件格式
function CheckFile( file )
{
	var filePattern = new RegExp("(\.jpg|\.gif|\.bmp|\.jpe|\.jpge|\.png|\.rar|\.zip|\.doc)$", "i");
	if (!filePattern.test (file.value))
	{
		alert("附件的文件格式只能是图片类型或压缩格式的文件(ZIP\\RAR)或word文档,请重新上传");
		return false;
	}
	return true ;
}

//重写方法，并显示提示框
//CID 被检查控件的名称,HelpeStr提示框内容
function CheckIntNum(CID,HelpeStr)
{
    var retval = true;
    
    var regSpace = /\s/g;  
    CIDInt=document.getElementById(CID);
    CIDInt.value=CIDInt.value.replace(regSpace, "");
    
    if(CIDInt.value=="")
    {
		alert(HelpStr);
		CIDInt.focus();
		return false;
    }
	
	retval	   = CheckInt(document.getElementById(CID).value);
	if(!retval)
	{
		alert(HelpeStr);
		document.getElementById(CID).focus();				
	}	
	return retval; 
}


function CheckDecimalNum(CID,HelpeStr)
{	

	var e = document.getElementById(CID);
	
	var Reg =  /^[+-]?\d+(?:\.\d{2})?$/;
	
	var Result = false;
	
	if (Reg.test(CID))
	{
		Result = true;
	}
	else
	{
		Result = false;
		alert(HelpeStr);
		e.focus();
		
	}
	return Result; 	
}

//CID 对象,id:对象的名称，用于提示语句,preNum：小数点前面的数据,backNum:小数点后面的数据
function CheckOtherNum(obj,preNum,backNum)
{			
	var rex = "^[0-9]{0,"+preNum+"}.[0-9]{0,"+backNum+"}$";	
	if(obj.search(rex) != -1)
	{
	   return true;
	}
	else
	{
		return false ;		
	}
}
//检查下拉框
function CheckDropDown(CID,HelpStr)
{
	var Result = true;
	if(CID.selectedIndex <=0)
	{
		Result = false;
		alert(HelpStr);		
		CID.focus();
	}
	return Result;
}
//检查文本框不为空
function CheckTextBox(CID,HelpStr)
{	
//    var regSpace = /\s/g; 
//    CID=CID.replace(regSpace, "")
	var Result = true;
	if(CID.value.replace(/^\s+|\s+$/,"") == "")
	{
		Result = false;
		alert(HelpStr);
		CID.focus();
	}
	return Result;
}

//文本框 必填项检查
function mustFillItemCheckText(elementID, errorMsg) {
    if (document.getElementById(elementID).value == "") {
        alert("请输入[" + errorMsg + "]！");
        document.getElementById(elementID).focus();
        return false;
    }
    return true;
}


// 根据正则表达式进行检查,忽略大小写
function CheckByRegex(str, regTxt, mess)
{
    var reg = new RegExp(regTxt,"i");
	if (!reg.test(str))
	{
		alert (mess);
		return false;
	}
	return true;
}

function checkFromImg(ctrId, errorText) {
    var filePattern = "(\.jpg|\.gif|\.bmp|\.jpe|\.jpge|\.png|\.tif)$"; //扫描件图片类型

    return __vid_RegexCheckByIgnoreCase(ctrId, filePattern, errorText)
}


function CheckStrongPwd(password) {
    var StrExp = /[a-z]|[A-Z]/;
    var NumExp = /[0-9]/;

    if (password.length < 6) {
        return false;
    }
    else if (!StrExp.test(password)) {
        return false;
    }
    else if (!NumExp.test(password)) {
        return false;
    }

    return true; 
}
  

window.onload = function  focusInput()
{   
     var elements = document.getElementsByTagName("input");
     for (var i=0; i < elements.length; i++)
     {
           if(elements[i].type=='text')
            {
                elements[i].onmouseover = function() {this.className='focusInput';};  
                elements[i].onmouseout = function() {this.className='normalInput';};       
                elements[i].onfocus = function() { this.className = 'focusInput'; };
                elements[i].onblur = function() { this.className = 'normalInput';};               
                       
            }
             
       }

   }
   