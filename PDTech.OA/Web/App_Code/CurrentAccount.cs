using System;
using System.Collections;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

public class CurrentAccount
{
    //系统Session Key常量 
    private const string ACCOUNT = "Account";
    private const string Purview = "Ac_Purview";
    //常用的功能页面地址
    public static string URL_INDEX = "/login.aspx";
    private ArrayList myPurview;
    public static ArrayList MyPurview
    {
        get
        {
            ArrayList myPurviews = new CurrentAccount().myPurview;
            if (myPurviews == null)
                myPurviews = (ArrayList)HttpContext.Current.Session[Purview];
            return myPurviews;
        }
    }
    public static bool ISHavePurview(string right_code)
    {
        if (MyPurview == null)
        {
            Goto_Timeout();
            return false;
        }
        return MyPurview.Contains(right_code);
    }
    /// <summary>
    /// 获取当前用户的Id
    /// </summary>
    public static decimal USER_ID
    {
        get
        {
            return (decimal)GetUser().USER_ID;
        }
    }
    /// <summary>
    /// 获取当前用户的登录用户名
    /// </summary>
    public static string LOGIN_NAME
    {
        get
        {
            return GetUser().LOGIN_NAME;
        }
    }
    /// <summary>
    /// 获取当前用户的姓名
    /// </summary>
    public static string FULL_NAME
    {
        get
        {
            return GetUser().FULL_NAME;
        }
    }
    /// <summary>
    /// 获取当前用户的座机
    /// </summary>
    public static string PHONE
    {
        get
        {
            return GetUser().PHONE;
        }
    }
    /// <summary>
    /// 获取当前用户的手机
    /// </summary>
    public static string MOBILE
    {
        get
        {
            return GetUser().MOBILE;
        }
    }
    /// <summary>
    /// 获取当前用户的部门ID
    /// </summary>
    public static Int64 DEPARTMENT_ID
    {
        get
        {
            return (Int64)GetUser().DEPARTMENT_ID;
        }
    }
    /// <summary>
    /// 是否超时
    /// </summary>
    /// <returns></returns>
    public static bool IsTimeout()
    {
        PDTech.OA.Model.USER_INFO myAccount = (PDTech.OA.Model.USER_INFO)

HttpContext.Current.Session[ACCOUNT];
        if (myAccount == null)
        {
            HttpContext.Current.Response.Redirect(URL_INDEX, true);
            return true;
        }
        return false;
    }
    /// <summary>
    /// 获取当前用户实体
    /// </summary>
    /// <returns></returns>
    public static PDTech.OA.Model.USER_INFO GetUser()
    {

        PDTech.OA.Model.USER_INFO myAccount = (PDTech.OA.Model.USER_INFO)

HttpContext.Current.Session[ACCOUNT];

        if (myAccount == null)
        {
            Goto_Timeout();
            return null;
        }
        else
            return myAccount;

    }

    /// <summary>
    /// 当前登录用户的IP
    /// </summary>
    public static string ClientIP
    {
        get
        {
            return HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
        }
    }
    /// <summary>
    /// 当前登录用户的IP
    /// </summary>
    public static string ClientHostName
    {
        get
        {
            return HttpContext.Current.Request.ServerVariables["REMOTE_HOST"];
        }
    }

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
        HttpContext.Current.Response.Redirect(URL_INDEX, true);
        //System.Web.HttpContext.Current.Response.Write("<script>window.open(\"/Login.aspx\", \"_top\");</script>");
    }
    /// <summary>
    /// 退出登陆
    /// </summary>
    public static void Logout()
    {
        PDTech.OA.BLL.USER_INFO uBll = new PDTech.OA.BLL.USER_INFO();
        uBll.UpdateLogin_State(USER_ID, 0, ClientIP);
        //清楚用户session（清楚cookie将导致登录时无法记住密码）
        HttpContext.Current.Session.Clear();
        HttpContext.Current.Session.Abandon();
    }
    /// <summary>
    /// 将枚举类型绑定到下拉列表中
    /// </summary>
    /// <param name="enumType"></param>
    /// <param name="dropDownList"></param>
    public static void BindEnumDropDownList(Type enumType, DropDownList dropDownList)
    {
        if (!enumType.IsEnum)
        {
            throw new Exception("不能绑定非枚举类型");
        }

        var source = from a in enumType.GetFields()
                     where a.FieldType.IsEnum == true
                     select new { Name = a.Name, Value = (int)a.GetValue(null) };
        dropDownList.DataSource = source;
        dropDownList.DataValueField = "Value";
        dropDownList.DataTextField = "Name";
        dropDownList.DataBind();
    }
}