using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// 分页代码
/// </summary>
public class PageNumbers
{
    private int pagecount;
    private int startPosition;
    private string url;
    private int _index;
    public PageNumbers()
    {
        PageCount = 20;
        init();
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="PageSize">每页显示条数</param>
    public PageNumbers(int PageSize)
    {
        PageCount = PageSize;
        init();
    }

    private void init()
    {
        HttpContext current = HttpContext.Current;
        string index = current.Request.QueryString["index"];
        if (!TypeParse.IsNumeric(index))
        {
            index = "1";
        }
        _index = int.Parse(index);
        if (_index < 1)
            _index = 1;

        startPosition = (_index - 1) * PageCount;


        url = current.Request.Url.AbsoluteUri;
    }

    /// <summary>
    /// 当前页的起始数取数
    /// </summary>
    public int StartPosition
    {
        get
        {
            return startPosition;
        }
        set { startPosition = value; }
    }
    /// <summary>
    /// 当分页时 每页显示的记录条数
    /// </summary>
    public int PageCount
    {
        get
        {
            return pagecount;
        }
        set
        {
            pagecount = value;
            startPosition = (_index - 1) * pagecount;
        }
    }
    /// <summary>
    /// 当前的页码
    /// </summary>
    public int PageIndex
    {
        get { return _index; }
        set
        {
            _index = value;
            if (_index < 1)
                _index = 1;
            startPosition = (_index - 1) * pagecount;
        }
    }

    /// <summary>
    /// 加载页码HTML字串
    /// </summary>
    /// <param name="filecount">总条数</param>
    /// <param name="info">显示文字</param>
    /// <returns></returns>
    public string getPageCode(int filecount, string info)
    {

        int index = PageIndex;//当前页码
        int count = (filecount - 1) / PageCount + 1;

        string page = url;
        if (page.IndexOf("?") == -1)
        {
            page = page + "?";
        }
        else if (!page.EndsWith("&"))
        {
            page += "&";
        }

        var j = page.IndexOf("?index=");

        if (j == -1)
        {
            j = page.IndexOf("&index=");
        }

        if (j > -1)
        {
            int i = page.IndexOf("&", j + 1);

            string nowcode = page.Substring(j + 1, i - j - 1);

            nowcode = nowcode.Replace("index=", "");
            if (CNPUBLIC.IsNumeric(nowcode))
                index = int.Parse(nowcode);//从url中取得当前页码

            page = page.Remove(j + 1, i - j);
        }

        string S = "<div class=\"pagination\"><ul>";

        S += "<li class=\"infocss\">共有<span style=\"color:Red\">" + filecount + "</span>" + info + "</li>";

        if (filecount == 0)
        {
            S += "<li class=\"disablepage\">上一页</li>";//&lt;&lt;
        }
        else if (index == 1)
        {
            S += "<li class=\"disablepage\">上一页</li>";
        }
        else
        {
            S += "<li class=\"nextpage\"><a href=\"#\" onclick=\"document.location='" + page + "index=" + (index - 1) + "'\">上一页</a></li>";
        }


        if (count < 12)
        {
            for (int i = 1; i <= count; i++)
            {
                if (index == i)
                {
                    S += "<li class=\"currentpage\">" + index + "</li>";
                }
                else
                {
                    S += "<li><a href=\"#\" onclick=\"document.location='" + page + "index=" + i + "'\">" + i + "</a></li>";
                }
            }
        }
        else
        {
            int e;
            if (index < 7)
            {
                e = 9;
                for (int i = 1; i <= e; i++)
                {
                    if (index == i)
                    {
                        S += "<li class=\"currentpage\">" + index + "</li>";
                    }
                    else
                    {
                        S += "<li><a href=\"#\" onclick=\"document.location='" + page + "index=" + i + "'\">" + i + "</a></li>";
                    }
                }
                S += "<li>...<a href=\"#\" onclick=\"document.location='" + page + "index=" + (count - 1) + "'\">" + (count - 1) + "</a></li>";
                S += "<li><a href=\"#\" onclick=\"document.location='" + page + "index=" + count + "'\">" + count + "</a></li>";
            }
            else if ((count - index) < 6)
            {
                S += "<li><a href=\"#\" onclick=\"document.location='" + page + "index=1'\">1</a></li>";
                S += "<li><a href=\"#\" onclick=\"document.location='" + page + "index=2'\">2</a>...</li>";


                e = index - 3;
                for (int i = e; i <= count; i++)
                {
                    if (index == i)
                    {
                        S += "<li class=\"currentpage\">" + index + "</li>";
                    }
                    else
                    {
                        S += "<li><a href=\"#\" onclick=\"document.location='" + page + "index=" + i + "'\">" + i + "</a></li>";
                    }
                }
            }
            else
            {
                S += "<li><a href=\"#\" onclick=\"document.location='" + page + "index=1'\">1</a></li>";
                S += "<li><a href=\"#\" onclick=\"document.location='" + page + "index=2'\">2</a>...</li>";


                e = index - 3;
                for (int i = e; i <= (e + 6); i++)
                {
                    if (index == i)
                    {
                        S += "<li class=\"currentpage\">" + index + "</li>";
                    }
                    else
                    {
                        S += "<li><a href=\"#\" onclick=\"document.location='" + page + "index=" + i + "'\">" + i + "</a></li>";
                    }
                }

                S += "<li>...<a href=\"#\" onclick=\"document.location='" + page + "index=" + (count - 1) + "'\">" + (count - 1) + "</a></li>";
                S += "<li><a href=\"#\" onclick=\"document.location='" + page + "index=" + count + "'\">" + count + "</a></li>";
            }
        }

        if (filecount == 0)
        {
            S += "<li class=\"disablepage\">下一页</li>";//&gt;&gt;
        }
        else if (index == count)
        {
            S += "<li class=\"disablepage\">下一页</li>";
        }
        else
        {
            S += "<li class=\"nextpage\"><a href=\"#\" onclick=\"document.location='" + page + "index=" + (index + 1) + "'\">下一页</a></li>";
        }
        S += "</ul></div>";
        return S;
    }
}