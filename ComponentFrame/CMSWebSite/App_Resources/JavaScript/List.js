// JScript 文件
function ___InitList(tab, rowCss, selectedRowCss, isHaveCkb, rowDblClickFun)
{
    tab.selectedIndex = -1;
    tab.selectedRowCss = selectedRowCss;
    tab.rowCss = rowCss;
    tab.isHaveCkb = isHaveCkb;
    
    for(var i=0;i<tab.rows.length-1;i++)
    {
        tab.rows[i + 1].className = rowCss;
        tab.rows[i + 1].onmouseover = ___ListRowOnMouseOver;
        tab.rows[i + 1].onmouseout = ___ListRowOnMouseOut;
        tab.rows[i + 1].onclick = ___ListRowOnClick;
        if (tab.isHaveCkb)
            tab.rows[i + 1].ckb = ___GetCheckBoxByRow(tab.rows[i + 1]);
        if (rowDblClickFun)
            tab.rows[i + 1].ondblclick = rowDblClickFun;
    }
    if (tab.isHaveCkb)
    {
        tab.headCkb = ___GetCheckBoxByRow(tab.rows[0]);
        tab.headCkb.onclick = ___ListCKBFull;
    }
}
function ___ListRowOnMouseOver()
{
    var row = ___GetEventRow(event);
    var tab = ___GetTableByEle(row);
    row.className = tab.selectedRowCss;
}
function ___ListRowOnMouseOut() {

    var row = ___GetEventRow(event);
    var tab = ___GetTableByEle(row);
    if (tab.selectedIndex != row.rowIndex - 1)
    {
        row.className = tab.rowCss;
    }
}
function ___ListRowOnClick()
{
    //debugger;
    var eObj = event.srcElement;
    if (eObj.tagName.toLowerCase() == "input" && eObj.type.toLowerCase() == "checkbox")
        return;
    var row = ___GetEventRow(event);
    var tab = ___GetTableByEle(row);
    if (row.rowIndex - 1 == tab.selectedIndex)
    {
        //row.className = tab.rowCss;
        //row.ckb.checked = false;
        //tab.selectedIndex = -1;
        return;
    }
    if (tab.selectedIndex >= 0)
        tab.rows[tab.selectedIndex + 1].className = tab.rowCss;
    tab.selectedIndex = row.rowIndex - 1;
    row.className = tab.selectedRowCss;
    
    if (tab.isHaveCkb)
    {
        for(var i=0;i<tab.rows.length-1;i++)
        {
            tab.rows[i + 1].ckb.checked = (tab.selectedIndex == i);
        }
    }
}
function ___GetEventRow(event)
{
    var row = event.srcElement;
    while(row.tagName.toLowerCase() != "tr")
        row = row.parentElement;
    
    return row;
}
function ___GetTableByEle(ele)
{
    var tab = ele.parentElement;
    while (tab.tagName.toLowerCase() != "table")
        tab = tab.parentElement;
    return tab;
}
function ___GetCheckBoxByRow(row)
{
    var cell = row.cells[0];
    var ckb = false;
    for(var i=0;i<cell.childNodes.length;i++)
    {
        var node = cell.childNodes[i];
        if (node.nodeType == 1 && node.tagName.toLowerCase() == "input" && node.type.toLowerCase()=="checkbox")
        {
            ckb = node;
            break;
        }
    }
    return ckb;
}
function ___ListCKBFull()
{
    var ckb = event.srcElement;
    var tab = ___GetTableByEle(ckb)
    for(var i=0;i<tab.rows.length-1;i++)
    {
        tab.rows[i + 1].ckb.checked = ckb.checked;
    }
    if (!ckb.checked && tab.selectedIndex >= 0)
    {
        tab.rows[tab.selectedIndex + 1].className = tab.rowCss;
        tab.selectedIndex = -1;
    }
}
function ___GetArrayValue(valArray, index)
{
    var result = "";
    if (valArray && valArray.length > index)
        result = valArray[index];
    return result;
}
//取得由背景选中的行，如果未选中则返回"Null"
function ___GetListSelectedRow(listTab)
{
    var result = false;
    if (listTab.selectedIndex >= 0)
        result = listTab.rows[listTab.selectedIndex + 1];
    return result;
}
//取得由CheckBox选中的行的数组，如果未选中则返回"Null"
function ___GetListCheckedRows(listTab)
{
    var result = new Array();
    var j=0;
    for(var i=0;i<listTab.rows.length-1;i++)
    {
        if (listTab.rows[i + 1].ckb.checked)
        {
            result[j++] = listTab.rows[i + 1];
        }
    }
    return result;
}
//删除由CheckBox选中的行
function ___DeleteRowByChecked(listTab)
{
    //debugger;
    var rows = ___GetListCheckedRows(listTab);
    if (rows || rows.length <= 0)
    {
        alert("没有选中要操作的行！");
        return ;
    }
    for(var i=rows.length - 1;i>=0;i--)
    {
        listTab.deleteRow(rows[i].rowIndex);
    }
    listTab.selectedIndex = -1;
}
//删除指定的行，注意：此处的index应该是表行的rowIndex属性减一
function ___DeleteRowByIndex(listTab,index)
{
    if (index < 0)
        return;
    var rowIndex = index + 1;
    if (listTab.rows.length > rowIndex)
    {
        listTab.rows.deleteRow[rowIndex];
    }
}
//增加一个新行
function ___AddRowToTable(listTab,rowHeight,rowDblClickFun,valArray)
{
    //debugger;
    var row = listTab.insertRow(listTab.rows.length);
    row.className = listTab.rowCss;
    row.onmouseover = ___ListRowOnMouseOver;
    row.onmouseout = ___ListRowOnMouseOut;
    row.onclick = ___ListRowOnClick;
    if (rowDblClickFun)
        row.ondblclick = rowDblClickFun;
    for(var i=0;i<listTab.rows[0].cells.length;i++)
    {
        var cell = row.insertCell(i);
        cell.height=rowHeight;
        if (i==0 && listTab.isHaveCkb)
        {
            var ckbID = listTab.id + "__Line_Ckb_" + String(row.rowIndex);
            cell.innerHTML = "<input type='checkbox' id='" + ckbID + "' />";
            cell.align = "center";
            row.ckb = ___GetCheckBoxByRow(row);
        }
        if (valArray)
        {
            if (i == 0)
            {
                if (!listTab.isHaveCkb)
                    cell.innerHTML = ___GetArrayValue(valArray,i);
            }
            else
            {
                if (listTab.isHaveCkb)
                    cell.innerHTML = ___GetArrayValue(valArray,i-1);
                else
                    cell.innerHTML = ___GetArrayValue(valArray,i);
            }
        }
    }
}
//更新一行的值
function ___UpdateRowToTable(row, valArray)
{
    if (!valArray)
        return;
    var listTab = ___GetTableByEle(row);
    for(var i=0;i<row.cells.length;i++)
    {
        if (i == 0)
        {
            if (!listTab.isHaveCkb)
                row.cells[i].innerHTML = ___GetArrayValue(valArray,i);
        }
        else
        {
            if (listTab.isHaveCkb)
                row.cells[i].innerHTML = ___GetArrayValue(valArray,i-1);
            else
                row.cells[i].innerHTML = ___GetArrayValue(valArray,i);
        }
    }
}

//$(function() {
//    $("#NoBorderText.TableCss :text").css("border", "none");
//    $("#NoBorderText.TableCss textarea").css("border", "none");
//});

//if ($) {
//    $(function() {
//        $("input:disabled").attr("disabled", "").css({ background: "#F0F5FB", border: "1px solid #7F9DB9" }).focus(function() { this.blur(); });
//    });
//}