function CheckChanged()                                                  
{
    var frm = document.forms(0); 
	var boolAllChecked;
	boolAllChecked=true;
	for(i=0;i< frm.length;i++)
	{
		e=frm.elements[i];
  		if( e.type=='checkbox' && e.name.indexOf('CheckAll') != -1 )
		if(e.checked== false)
		{                                                      
			boolAllChecked=false;                                        
			break;                                          
		}                                                 
	}                                                            
	for(i=0;i< frm.length;i++)                                
	{                                                         
		e=frm.elements[i];                                              
		if ( e.type=='checkbox' && e.name.indexOf('chkDelete') != -1 )    
		{                                                                 
			if( boolAllChecked==false)                                     
				e.checked= false ;
			else                                                        
				e.checked= true;
			SelectRow(e)   
		}                                                             
	}                                                           
 }                    
 
function SelectRow(oCheckBox)
{
	var oTR = oCheckBox;
	while (oTR.tagName != "TR")
		{oTR = oTR.parentElement;}

	if(oCheckBox.checked) 
	{
		oCheckBox.style.cssText = oTR.style.cssText
		oTR.style.cssText = "background-color: LightSteelBlue"
	
	}
	else 
	{
		oTR.style.cssText = oCheckBox.style.cssText
	}
}

function CheckCSISelect(oRadioList,CtlTitle)
{
var IsShow=document.getElementById(CtlTitle+"_Datagrid1");
  if (IsShow!=null)
  {
	for (var i=0;i<oRadioList.all.length;i++)
	{
		if (oRadioList.all(i).id.indexOf(oRadioList.id)!=-1)
		{
			if (oRadioList.all(i).checked)
			{
				if (((oRadioList.all(i).value=='4')||(oRadioList.all(i).value=='5')))
				{
					IsShow.style.display="block";
					IsShow.style.visibility="visible";
				}
				if (((oRadioList.all(i).value!='5')&&(oRadioList.all(i).value!='4')))
				
				{
					IsShow.style.display="none";
					IsShow.style.visibility="hidden";
				}
			}
		}
}
parent.iFrameHeight();
  }
  
}

function DisPlayInput(oCheckBox,OInput)
{
	var InputEmail=document.getElementById(OInput);
	if (oCheckBox.checked)
	{
		InputEmail.style.display="block";
		InputEmail.style.visibility="visible";
	}
	else
	{
		InputEmail.style.display="none";
		InputEmail.style.visibility="hidden";
	}
}