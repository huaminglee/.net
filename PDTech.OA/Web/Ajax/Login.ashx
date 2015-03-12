<%@ WebHandler Language="C#" Class="Login" %>

using System;
using System.Web;
using System.Web.SessionState;
using System.Web.Security;
using System.Data;
using System.Collections.Generic;
/// <summary>
/// Creator：ZSX
/// Date：2014-6-21
/// Use：Login.aspx
/// Note：Allow Overload
/// </summary>
public class Login : IHttpHandler, IRequiresSessionState
{
    PDTech.OA.BLL.USER_INFO bll = new PDTech.OA.BLL.USER_INFO();
    DataTable dt;
    string uName;
    public void ProcessRequest(HttpContext context)
    {
        
        PDTech.OA.Model.USER_INFO Ac = new PDTech.OA.Model.USER_INFO();
        IList<PDTech.OA.Model.VIEW_USER_RIGHT> Ac_purview = new List<PDTech.OA.Model.VIEW_USER_RIGHT>();
        context.Response.ContentType = "text/plain";
        System.Collections.ArrayList Arr = new System.Collections.ArrayList();
        context.Session.Clear();//防止冗余，点击登录释放Session，
        HttpContext.Current.Session.Clear();
        int num = HttpContext.Current.Session.Count;
        uName = context.Request["uname"];
        //判断是否是重复提交
        if (context.Session["user_id"] == Ac.USER_ID.ToString())
        {
            context.Response.Write("已登录");
        }
        else
        {
            switch (bll.UserLogin(new PDTech.OA.Model.USER_INFO() { LOGIN_NAME = uName, LOGIN_PWD = FormsAuthentication.HashPasswordForStoringInConfigFile(context.Request["upwd"], "MD5").ToString(), IS_DISABLE = "0" }, out Ac, out Ac_purview, CurrentAccount.ClientIP))
            {
                case 1:
                    /***登录成功***/
                    foreach (var item in Ac_purview)
                    {
                        Arr.Add(item.RIGHT_CODE);
                    }
                    if (context.Application["userCount"] == null)
                    {
                        context.Application["userCount"] = 1;
                    }
                    else
                    {
                        context.Application["userCount"] = (int)context.Application["userCount"] + 1;
                    }
                    context.Session["Account"] = Ac;
                    context.Session["Ac_Purview"] = Arr;
                    context.Session["user_id"] = Ac.USER_ID;
                    context.Session["login_name"] = Ac.LOGIN_NAME;
                    context.Session["full_name"] = Ac.FULL_NAME;
                    context.Session["department_id"] = Ac.DEPARTMENT_ID;
                    context.Session["department_name"] = Ac.DEPARTMENT_NAME;

                    //判断是否显示每日一题页面
                    PDTech.OA.BLL.OA_EDAYQUESTION edayBll = new PDTech.OA.BLL.OA_EDAYQUESTION();
                    int count = edayBll.IsHasRecord(Ac.USER_ID.Value);

                    context.Response.Write("登录成功|" + count.ToString());//返回前台页面调用此ashx文件处
                    break;
                case 0:
                    /***登录失败***/
                    context.Response.Write("您输入的密码有误");
                    break;
                case -1:
                    /***登录失败***/
                    context.Response.Write("您输入的账号有误");
                    break;
            }
        }  
    }

    public bool IsReusable
    {
        get
        {
            return false;
        }
    }
}