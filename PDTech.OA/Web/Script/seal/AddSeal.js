var sealClassId="CLSID:C1FB7513-9A44-4C64-B653-63C6965D7F4C";
var obj;
var i=0;
var x=0;
var y=0;

//��̬����
function doAddSeal(protectedData, sealPosition, x, y) {
    //����һ��Object����(ӡ��)
    obj = document.createElement("object");
    obj.width = 158;
    obj.height = 158;
    var mt = document.body.appendChild(obj);
    document.getElementById(sealPosition).appendChild(mt);

    //Obj�ĳ�ʼλ��
    obj.style.left = 10 + "px";
    obj.style.top = 10 + "px";

    obj.style.position = "absolute";  //����λ��
    obj.classid = sealClassId;
    obj.Authority = 0;  //�޶��û��Ĳ������ͣ�0=�û�ֻ�ܲ鿴��1=�û�����ǩ�£�2=�û�����ǩ����3=��ֹ�ƶ� ��4=�ɳ�����8=���ƶ�ӡ��
    obj.ProtectedData = protectedData; // �ܱ�����ֵ
    //alert(protectedData);

    //ӡ�µ���ʾģʽ
    obj.DrawModeUnsign = 0;   //ָ������δ���ʱ�ؼ���ʾ��ͼ����0=�հ�
    obj.DrawMode = 18;    //ָ���ؼ�����ʾģʽ

    //����ǩ�»�ǩ������ע�ķ�����Ϊ'true'ʱǩ�£�����Ϊǩ������ע��
    obj.SignSeal(true);

    //ӡ�µ�λ��
    obj.style.left = x + "px";
    obj.style.top = y + "px";

    //��ֵ
    document.getElementById("sealdata").value = obj.SignedData;//ӡ������
    document.getElementById("hidProtectedData").value = obj.ProtectedData;//�ܱ���������

    return true;
}

//��̬ǩ��
function doAddSign(protectedData, sealPosition, x, y)
{
    obj = document.createElement("object");  //����һ��Object����(ӡ��)
	obj.width = 158;
	obj.height = 158;
	var mt = document.body.appendChild(obj);
	document.getElementById(sealPosition).appendChild(mt);
	//Obj�ĳ�ʼλ��
	obj.style.left = 10 + "px";
	obj.style.top = 10 + "px";
	
	obj.style.position = "absolute";  //����λ��
	obj.classid = sealClassId;
	obj.Authority = 0;   //�޶��û��Ĳ������ͣ�0=�û�ֻ�ܲ鿴��1=�û�����ǩ�£�2=�û�����ǩ����3=��ֹ�ƶ� ��4=�ɳ�����8=���ƶ�ӡ��
	obj.ProtectedData = protectedData;   //�ܱ�����ֵ
	
	//ӡ�µ���ʾģʽ
	obj.DrawModeUnsign = 0;   //ָ������δ���ʱ�ؼ���ʾ��ͼ����0=�հ�
	obj.DrawMode = 18;    //ָ���ؼ�����ʾģʽ
	//����ǩ�»�ǩ������ע�ķ�����Ϊ'true'ʱǩ�£�����Ϊǩ������ע��
	obj.SignSeal(false);
	
	//ӡ�µ�λ��
	obj.style.left = x + "px";
	obj.style.top = y + "px";
	
	//��ֵ
	document.getElementById("sealdata").value = obj.SignedData;//ӡ������
	document.getElementById("hidProtectedData").value = obj.ProtectedData;//�ܱ���������
}



