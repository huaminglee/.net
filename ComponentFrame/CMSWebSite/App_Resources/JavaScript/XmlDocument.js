// JScript 文件
function ___CreateXmlDoc(xmlfile)
{
    var xmlDoc;
    if(window.ActiveXObject)
    {
        xmlDoc = new ActiveXObject('Microsoft.XMLDOM');
        xmlDoc.async = false;
        xmlDoc.load(xmlfile);
    }
    else if (document.implementation&&document.implementation.createDocument)
    {
        xmlDoc = document.implementation.createDocument('', '', null);
        xmlDoc.load(xmlfile);
    }
    else
    {
        alert("您的浏览器不支持xml文件读取,于是本页面禁止您的操作,推荐使用IE5.0以上可以解决此问题!");
    }
    return xmlDoc;
}
function ___ReadNodeAttrib(node, attribName)
{
    return node.attributes.getNamedItem(attribName).text;
}
function ___ReadNodeText(node)
{
    var result = node.innerText;
    if (!result)
        result = node.text;
    return result;
}

