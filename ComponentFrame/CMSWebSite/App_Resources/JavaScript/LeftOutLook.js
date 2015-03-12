/*****************************************************************
Copyright (C) 2006 鹏业软件
版权所有。 

文件名：LeftOutLook.js
文件功能描述：outlook菜单管理

 
创建标识：gj 20091125

修改标识：
修改描述：

修改标识：
修改描述：
********************************************************************/

//数据项
    function item(caption, level, url,bgImg) {
        this.level = level;
        this.url = url;
        this.caption = caption;
        this.backgroundImage = bgImg;
        
        this.otherclass = " nowrap ";
    }

    function outlook(id,target) {
        this.titleList = new Array();
        this.itemList = new Array();
        this.unfoldTitleIndex = 0;  //展开标题的索引
        this.timedelay = 50;
        this.inc = 10;
        this.id = id;
        this.target = target;
    }
    
    //添加标题
    outlook.prototype.addTitle = function(title,bgImg) {
       
        this.itemList[this.titleList.length] = new Array();
        this.titleList[this.titleList.length] = new item(title, 1, "",bgImg);

        return (this.titleList.length - 1);
    }

    //添加菜单项。返回-1表示有错误
    outlook.prototype.addItem = function(titleID, caption, url,bgImg) {
        if (titleID >= 0 && titleID <= this.titleList.length) {
            var index = this.itemList[titleID].length - 1;
            this.itemList[titleID][index + 1] = new item(caption, 2, url,bgImg);
            return (index);
        }

        return -1;
    }

    //UI表现。
    outlook.prototype.getOutLine = function() {
        var tbody = document.createElement("tbody");

        for (i = 0; i < this.titleList.length; i++) {
            //创建一个单元格（放置标题）
            var td = document.createElement("td");
            td.id = this.id + "title_" + i;

            td.style.whiteSpace = "nowrap";
            td.align = "center";
            td.style.cursor = "hand";
            td.style.backgroundColor = "#E5F2FA";
            td.style.padding = "8px";
            td.style.borderWidth = 0;
            td.style.borderStyle = "none";
            td.style.backgroundImage = "url(" + this.titleList[i].backgroundImage + ")";
            td.style.backgroundRepeat = "no-repeat";
            td.style.backgroundPosition = "left top";
            if (i != this.unfoldTitleIndex) {
                td.style.color = "#000000";
                td.style.borderColor = "navy";
            }
            else {
                td.style.color = "blue";
                td.style.borderColor = "navy";
            }

            td.index = i;
            td.divName = this.id.toString();

            //标题文本
            var tdText = document.createTextNode(this.titleList[i].caption);
            td.appendChild(tdText);

            //标题事件
            td.onclick = switchOutBar;
            //td.onmouseover = mouseoverChangeColor;
            //td.onmouseout = mouseoutChangeColor;

            //创建行对象（标题行）
            var tr = document.createElement("tr");
            tr.appendChild(td);
            tbody.appendChild(tr);

            //创建一个单元格（放置菜单项）
            td = document.createElement("td");

            td.align = "center";
            td.style.borderWidth = 0;
            td.id = this.id + "content_" + i;
            td.style.width = "100%";
            if (i != this.unfoldTitleIndex) {
                td.style.display = "none";
                td.style.height = "0%";
            }
            else {
                td.style.display = "";
                td.style.height = "100%";
            }

            //创建一个div（放置菜单项）
            var divElement = document.createElement("div");
            divElement.id = this.id + "divItem_" + i;
            divElement.style.overflow = "hidden";
            divElement.style.width = "100%";
            divElement.style.height = "100%";
            divElement.style.borderWidth = 0;

            //循环创建菜单项
            for (j = 0; j < this.itemList[i].length; j++) {

                var a = document.createElement("a");
                a.href = this.itemList[i][j].url;
                a.target = this.target;
                a.style.display = "block";
                a.style.padding = "5px";
                a.innerText = this.itemList[i][j].caption;
                
                //鼠标事件
                a.onmouseover = amouseoverbgColor;
                a.onmouseout = amouseoutbgColor;

                var span = document.createElement("span");
                span.style.backgroundImage = "url(" + this.itemList[i][j].backgroundImage + ")";
                span.style.backgroundRepeat = "no-repeat";
                span.style.backgroundPosition = "left center";
                span.style.paddingLeft = "30";
                span.appendChild(a);
                divElement.appendChild(span);
            }

            td.appendChild(divElement);

            tr = document.createElement("tr");
            tr.appendChild(td);
            tbody.appendChild(tr);
        }

        var table = document.createElement("table");
        table.style.borderWidth = 0;
        table.style.padding = "0";
        table.style.height = "100%";
        table.style.width = "100%";
        table.align = "center";
        table.setAttribute("cellPadding", 0);
        table.setAttribute("cellSpacing", 0);
        table.appendChild(tbody);

        return table;
    }

    //显示outlook
    outlook.prototype.show = function(holdElement) {
        var divElement = document.createElement("div");
        divElement.id = this.id;
        divElement.style.width = "100%";
        divElement.style.height = "100%";
        divElement.style.borderColor = "#C3EDFF";
        divElement.style.borderWidth = 1;
        divElement.style.borderStyle = "solid";
        divElement.unfoldTitleIndex = 0;
        divElement.appendChild(this.getOutLine());
        holdElement.appendChild(divElement);
    }

    //双击标题动画，展开下级菜单
    function switchOutBar() {
        var obj = document.getElementById(this.divName);

        //前一个展开的菜单
        var oldindex = obj.unfoldTitleIndex;

        this.unfoldTitleIndex = this.index;
        obj.unfoldTitleIndex = this.index;

        if (this.index != oldindex) {
            //原来的关闭，当前的打开
            var oldElement = document.getElementById(this.divName + "title_" + oldindex);
            var currElement = document.getElementById(this.divName + "title_" + this.index);
            
            oldElement.style.border = "1px none gray";
            //oldElement.style.background = "#E5F2FA";
            oldElement.style.color = "#000000";
            oldElement.style.textalign = "center";
            var oldImag = oldElement.style.backgroundImage;
            oldElement.style.backgroundImage = currElement.style.backgroundImage ;

            
            
            currElement.style.border = "1px none white";
            //currElement.style.background = "#E5F2FA";
            currElement.style.color = "#000000";
            currElement.style.textalign = "center";
            currElement.style.backgroundImage = oldImag;
            
            smoothout(this.divName + "content_" + this.index, this.divName + "content_" + oldindex, 0);
        }
    }
    
    function smoothout(currIndex, oldIndex,stat) {
        if (stat == 0) {
          //第一次运行

            document.all(currIndex).style.height = "0%";
            document.all(currIndex).style.display = "";
            setTimeout("smoothout('" + currIndex + "','" + oldIndex + "'," + 10 + ")", 50);
        }
        else {
            //这里完成动画
            stat += 10;
            if (stat > 100) stat = 100;

            document.all(currIndex).style.height = stat + "%";
            document.all(oldIndex).style.height = (100 - stat) + "%";

            if (stat < 100) {
                setTimeout("smoothout('" + currIndex + "','" + oldIndex + "'," + stat + ")", 50);
            }
            else {
                //运行结束
                document.all(oldIndex).style.display = "none";
            }
        }
    }

    //鼠标移进标题 更改背景颜色
    function mouseoverChangeColor() {
        this.style.background = "#C3EDFF";
    }

    //鼠标移出标题 恢复背景颜色
    function mouseoutChangeColor() {
        this.style.background = "#E5F2FA";
    }

    //鼠标移进菜单项 更改背景颜色
    function amouseoverbgColor() {
        this.style.backgroundColor = "#E9E7EC";
    }

    //鼠标移出菜单项 恢复背景颜色
    function amouseoutbgColor() {
        this.style.backgroundColor = "white";
    }

///////////////////////////////////////////
// 调用示例
//   <SCRIPT>
//    var t;
//    var outlookbar = new outlook("kk","mainFram");

    //    t = outlookbar.addTitle('知识共享','背景图片.jpeg');
    //    outlookbar.addItem(t, '知识查询', 'javascript:;','背景图片.jpeg')
    //    outlookbar.addItem(t, '企业知识', 'javascript:;','背景图片.jpeg')
    //    outlookbar.addItem(t, '知识收藏', 'javascript:;','背景图片.jpeg')
    //    outlookbar.addItem(t, '知识订阅', 'javascript:;','背景图片.jpeg')

    //    t = outlookbar.addTitle('知识采集','背景图片.jpeg')
    //    outlookbar.addItem(t, '知识编辑', 'javascript:;','背景图片.jpeg')
    //    outlookbar.addItem(t, '待办事项', 'javascript:;','背景图片.jpeg')
    //    outlookbar.addItem(t, '已办事项', 'javascript:;','背景图片.jpeg')
    //    t = outlookbar.addTitle('台账','背景图片.jpeg')
    //    outlookbar.addItem(t, '知识台账', 'javascript:;','背景图片.jpeg')
    //    outlookbar.addItem(t, '项目台账', 'javascript:;','背景图片.jpeg')
    //
    //    t = outlookbar.addTitle('系统管理','背景图片.jpeg')
    //    outlookbar.addItem(t, '流程管理', 'javascript:;','背景图片.jpeg')
//    
//    var d = document.getElementById("outLookBarShow");
//    outlookbar.show(d);
// 
//</SCRIPT>