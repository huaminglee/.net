// JScript 文件
function ___GetSourceElementIDFromSender(sender)
{
    var result = false;
    try
    {
        result = sender._postBackSettings.sourceElement.id;
    }
    catch(e)
    {}
    return result;
}
