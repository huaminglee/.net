using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

/// <summary>
/// BasePage 的摘要说明
/// </summary>
public class BasePage : System.Web.UI.Page
{
	public BasePage()
	{
		//
		// TODO: 在此处添加构造函数逻辑
		//
        HttpContext.Current.Response.Expires = -1;
	}

    public static string Language
    {
        get
        {
            if (HttpContext.Current.Session["Language"] == null)
                return "CH";
            else
                return HttpContext.Current.Session["Language"] as string;
        }
        set
        {
            if (HttpContext.Current.Session["Language"] == null)
                HttpContext.Current.Session.Add("Language", value);
            else
                HttpContext.Current.Session["Language"] = value;
        }
    }

    public static string getGUID(string ID)
    {
        byte[] buffer1 = Encoding.ASCII.GetBytes("_GUID" + ID + "wb");
        HashAlgorithm algorithm1 = new SHA1Managed();
        byte[] buffer2 = algorithm1.ComputeHash(buffer1);
        string text1 = Convert.ToBase64String(buffer2);
        if (text1.EndsWith("="))
        {
            text1 = text1.Substring(0, text1.Length - 1);
        }
        text1 = text1.Replace("/", "").Replace("'", "").Replace("+", "");
        return text1.Replace(@"\", "");
    }

    public string getGUID2(string ID)
    {
        byte[] buffer1 = Encoding.ASCII.GetBytes(ID);
        HashAlgorithm algorithm1 = new SHA1Managed();
        byte[] buffer2 = algorithm1.ComputeHash(buffer1);
        string text1 = Convert.ToBase64String(buffer2);
        if (text1.EndsWith("="))
        {
            text1 = text1.Substring(0, text1.Length - 1);
        }
        text1 = text1.Replace("/", "").Replace("'", "");
        //text1 = text1.Substring(0,16);
        return text1.Replace(@"\", "");
    }
}