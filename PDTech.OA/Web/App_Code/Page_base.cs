using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Page_base 的摘要说明
/// </summary>
public class Page_base
{
    


    /// <summary>
    /// 跳转到超时页面
    /// </summary>
    public static void Goto_Timeout()
    {
        //清除缓存
        HttpContext.Current.Response.Buffer = true;
        HttpContext.Current.Response.ExpiresAbsolute = DateTime.Now.AddDays(-1);
        HttpContext.Current.Response.Expires = 0;
        HttpContext.Current.Response.CacheControl = "no-cache";
        HttpContext.Current.Response.Redirect("/login.aspx", true);
    }
}