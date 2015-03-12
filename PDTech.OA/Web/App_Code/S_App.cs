using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using PDTech.OA.Model;

/// <summary>独立静态公共方法类(可当做Helper工具类使用) 
/// Creator：ZSX
/// Date：2014-6-21
/// Use：Check MD5（eg：Login.aspx）
/// Note：Allow Overload
/// </summary>
public class S_App
{
    /// <summary>
    /// 过滤HTML标签
    /// </summary>
    /// <param name="Htmlstring">需要过滤的字符串</param>
    /// <returns>过滤后的字符串</returns>
    public static string FilterHTML(string Htmlstring)
    {
        //删除脚本  
        Htmlstring = Regex.Replace(Htmlstring, @"<script[^>]*?>.*?</script>", "", RegexOptions.IgnoreCase);
        //删除HTML  
        Htmlstring = Regex.Replace(Htmlstring, @"<(.[^>]*)>", "", RegexOptions.IgnoreCase);
        Htmlstring = Regex.Replace(Htmlstring, @"([\r\n])[\s]+", "", RegexOptions.IgnoreCase);
        Htmlstring = Regex.Replace(Htmlstring, @"-->", "", RegexOptions.IgnoreCase);
        Htmlstring = Regex.Replace(Htmlstring, @"<!--.*", "", RegexOptions.IgnoreCase);

        Htmlstring = Regex.Replace(Htmlstring, @"&(quot|#34);", "\"", RegexOptions.IgnoreCase);
        Htmlstring = Regex.Replace(Htmlstring, @"&(amp|#38);", "&", RegexOptions.IgnoreCase);
        Htmlstring = Regex.Replace(Htmlstring, @"&(lt|#60);", "<", RegexOptions.IgnoreCase);
        Htmlstring = Regex.Replace(Htmlstring, @"&(gt|#62);", ">", RegexOptions.IgnoreCase);
        Htmlstring = Regex.Replace(Htmlstring, @"&(nbsp|#160);", "   ", RegexOptions.IgnoreCase);
        Htmlstring = Regex.Replace(Htmlstring, @"&(iexcl|#161);", "\xa1", RegexOptions.IgnoreCase);
        Htmlstring = Regex.Replace(Htmlstring, @"&(cent|#162);", "\xa2", RegexOptions.IgnoreCase);
        Htmlstring = Regex.Replace(Htmlstring, @"&(pound|#163);", "\xa3", RegexOptions.IgnoreCase);
        Htmlstring = Regex.Replace(Htmlstring, @"&(copy|#169);", "\xa9", RegexOptions.IgnoreCase);
        Htmlstring = Regex.Replace(Htmlstring, @"&#(\d+);", "", RegexOptions.IgnoreCase);

        Htmlstring.Replace("<", "");
        Htmlstring.Replace(">", "");
        Htmlstring.Replace("\r\n", "");
        Htmlstring = HttpContext.Current.Server.HtmlEncode(Htmlstring).Trim();

        return Htmlstring;
    }

    /// <summary>
    /// 截取字符串
    /// </summary>
    /// <param name="str">需要截取的字符串</param>
    /// <param name="length">截取长度</param>
    /// <returns>截取后的字符串</returns>
    public static string Substr(string str, int length)
    {
        if (str.Length > length)
        {
            str = str.Substring(0, length) + ". . .";
        }
        return str;
    }

    /// <summary>
    /// DataTable转换Json格式
    /// </summary>
    /// <param name="dt">待转换的DataTable</param>
    /// <returns>转换后的Json</returns>
    public static string ToJson(DataTable dt)
    {
        StringBuilder jsonBuilder = new StringBuilder();
        jsonBuilder.Append("{\"");
        jsonBuilder.Append(dt.TableName.ToString());
        jsonBuilder.Append("\":[");
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            jsonBuilder.Append("{");
            for (int j = 0; j < dt.Columns.Count; j++)
            {
                jsonBuilder.Append("\"");
                jsonBuilder.Append(dt.Columns[j].ColumnName);
                jsonBuilder.Append("\":\"");
                jsonBuilder.Append(dt.Rows[i][j].ToString());
                jsonBuilder.Append("\",");
            }
            jsonBuilder.Remove(jsonBuilder.Length - 1, 1);
            jsonBuilder.Append("},");
        }
        jsonBuilder.Remove(jsonBuilder.Length - 1, 1);
        jsonBuilder.Append("]");
        jsonBuilder.Append("}");
        return jsonBuilder.ToString();
    }

    /// <summary>
    /// 生成jsonTree结构（单层）
    /// </summary>
    /// <param name="dtArchiveType">公文类型数据源</param>
    /// <param name="id">父节点ID</param>
    /// <param name="rootNode">根目录</param>
    public static void GetDataString(DataTable dtArchiveType, string id, ARCHIVE_TYPE rootNode)
    {
        DataRow[] CRow = dtArchiveType.Select("parent_id=" + id);//内存中查询根目录下有多少子节点
        if (CRow.Length > 0)
        {
            rootNode.children = new List<ARCHIVE_TYPE>();//创建子节点
            for (int i = 0; i < CRow.Length; i++)
            {
                ARCHIVE_TYPE cNode = new ARCHIVE_TYPE() { id = CRow[i]["archive_type"].ToString(), text = CRow[i]["type_name"].ToString(), iconCls = "glyphicon glyphicon-folder-close" };//组织子节点的json格式
                rootNode.children.Add(cNode);
            }
        }
    }

    /// <summary>
    /// 生成jsonTree结构（双层）
    /// </summary>
    /// <param name="dtDept">部门数据源</param>
    /// <param name="dtUser">用户数据源</param>
    /// <param name="id">父节点ID</param>
    /// <param name="rootNode">根目录</param>
    public static void GetDataString(DataTable dtDept, DataTable dtUser, string id, PersonTree rootNode)
    {
        DataRow[] CRow = dtDept.Select("parent_id=" + id);//内存中查询根目录下有多少子节点
        if (CRow.Length > 0)
        {
            rootNode.children = new List<PersonTree>();//创建子节点
            for (int i = 0; i < CRow.Length; i++)
            {
                PersonTree cNode = new PersonTree() { id = CRow[i]["department_id"].ToString(), text = CRow[i]["department_name"].ToString(), state = "closed", status = "department", iconCls = "glyphicon glyphicon-folder-close" };//组织子节点的json格式
                GetDataString(dtDept, dtUser, CRow[i]["department_id"].ToString(), cNode);//递归创建子节点
                DataRow[] CCheckRows = dtDept.Select("parent_id=" + CRow[i]["department_id"].ToString());
                DataRow[] uCheckRows = dtUser.Select("department_id=" + CRow[i]["department_id"].ToString());
                /***当前当前用户所在部门***/
                if (CurrentAccount.DEPARTMENT_ID == (Int64)CRow[i]["department_id"])
                {
                    cNode.state = "open";
                }
                /***部门中有人员和部门中有子部门***/
                if ((CCheckRows.Length + uCheckRows.Length) > 0)
                {
                    rootNode.children.Add(cNode);
                }
            }
        }
        DataRow[] uRows = dtUser.Select("department_id=" + id);
        if (uRows.Length > 0)
        {
            if (rootNode.children == null)
            {
                rootNode.children = new List<PersonTree>();
            }
            foreach (var item in uRows)
            {
                PersonTree uNode = new PersonTree() { id = item["user_id"].ToString(), text = item["full_name"].ToString(), status = "person", iconCls = "glyphicon glyphicon-user" };
                rootNode.children.Add(uNode);
            }
        }
    }

    /// <summary>
    /// 生成jsonTree结构（本地文件夹）
    /// </summary>
    /// <param name="di">待查找的本地文件夹目录</param>
    /// <param name="rootFolder">根目录</param>
    public static void GetDirectorInfo(DirectoryInfo di, FolderTree rootFolder)
    {
        /***遍历指定目录，并获取子文件夹***/
        foreach (var item in di.GetDirectories())
        {
            if (rootFolder.children == null)
            {
                rootFolder.children = new List<FolderTree>();
            }
            FolderTree ftCurr = new FolderTree() { text = item.Name, fullPath = item.FullName, iconCls = "glyphicon glyphicon-folder-close" };
            rootFolder.children.Add(ftCurr);
            GetDirectorInfo(item, ftCurr);
        }
    }

    /// <summary>
    /// 对象转换成json
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="jsonObject">需要格式化的对象</param>
    /// <returns>Json字符串</returns>
    public static string DataContractJsonSerialize<T>(T jsonObject)
    {
        DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(T));
        string json = null;
        using (MemoryStream ms = new MemoryStream()) //定义一个stream用来存发序列化之后的内容
        {
            serializer.WriteObject(ms, jsonObject);
            json = Encoding.UTF8.GetString(ms.ToArray()); //将stream读取成一个字符串形式的数据，并且返回
            ms.Close();
        }
        return json;
    }

    /// <summary>
    /// 字符JavaScript编码
    /// </summary>
    /// <param name="input">需要转义的字符串</param>
    /// <returns></returns>
    public static string javaScriptEscape(string input)
    {
        if (string.IsNullOrEmpty(input))
        {
            return input;
        }
        StringBuilder filtered = new StringBuilder();
        char[] inputCharArray = input.ToCharArray();
        char prevChar = '\u0000';
        char c;
        for (int i = 0; i < input.Length; i++)
        {
            c = inputCharArray[i];
            if (c == '"')
            {
                filtered.Append("\\\"");
            }
            else if (c == '\'')
            {
                filtered.Append("\\'");
            }
            else if (c == '\\')
            {
                filtered.Append("\\\\");
            }
            else if (c == '\t')
            {
                filtered.Append("\\t");
            }
            else if (c == '\n')
            {
                if (prevChar != '\r')
                {
                    filtered.Append("\\n");
                }
            }
            else if (c == '\r')
            {
                filtered.Append("\\n");
            }
            else if (c == '\f')
            {
                filtered.Append("\\f");
            }
            else if (c == '/')
            {
                filtered.Append("\\/");
            }
            else
            {
                filtered.Append(c);
            }
            prevChar = c;
        }
        return filtered.ToString();
    }

    /// <summary>
    /// 字符JavaScript编码
    /// </summary>
    /// <param name="input">需要转义的字符串</param>
    /// <returns></returns>
    public static string javaScriptFilter(string input)
    {
        if (string.IsNullOrEmpty(input))
        {
            return input;
        }
        StringBuilder filtered = new StringBuilder();
        char[] inputCharArray = input.ToCharArray();
        char prevChar = '\u0000';
        char c;
        for (int i = 0; i < input.Length; i++)
        {
            c = inputCharArray[i];
            if (c == '"')
            {
                filtered.Append("");
            }
            else if (c == '<')
            {
                filtered.Append("");
            }
            else if (c == '>')
            {
                filtered.Append("");
            }
            else
            {
                filtered.Append(c);
            }
            prevChar = c;
        }
        return filtered.ToString();
    }

    /// <summary>
    /// 显示标题（通常用于行政审批）
    /// </summary>
    /// <param name="type">类型ID</param>
    /// <returns>返回标题</returns>
    public static string ShowTitle(string type)
    {
        string strTitle = "";
        switch (type)
        {
            case "10":
                strTitle = "一般阅件";
                break;
            case "11":
                strTitle = "普通办件";
                break;
            case "12":
                strTitle = "单位发文";
                break;
            case "20":
                strTitle = "领导批示件";
                break;
            case "21":
                strTitle = "党组会督办";
                break;
            case "22":
                strTitle = "局长办公会督办";
                break;
            case "23":
                strTitle = "信访督办件";
                break;
            case "24":
                strTitle = "建议提案";
                break;
            case "32":
                strTitle = "人事任免";
                break;
            case "33":
                strTitle = "水务工程项目";
                break;
            case "40":
                strTitle = "取水许可";
                break;
            case "41":
                strTitle = "排水许可";
                break;
            case "42":
                strTitle = "水土保持";
                break;
            case "43":
                strTitle = "涉水项目";
                break;
            case "44":
                strTitle = "用水计划";
                break;
            case "51":
                strTitle = "风险处置单";
                break;
            case "61":
                strTitle = "财政预决算";
                break;
            case "62":
                strTitle = "三公经费";
                break;
            case "71":
                strTitle = "三重一大";
                break;
        }
        return strTitle;
    }

    public static void UpdateCookie(string cookie_name, string cookie_value)
    {
        HttpCookie cookie = HttpContext.Current.Request.Cookies.Get(cookie_name);
        if (cookie == null)
        {
            cookie = new HttpCookie(cookie_name);
            //SWFUpload 的Demo中给的代码有问题，需要加上cookie.Expires 设置才可以
            cookie.Expires = DateTime.Now.AddYears(1);
            HttpContext.Current.Request.Cookies.Add(cookie);
        }
        cookie.Value = cookie_value;
        HttpContext.Current.Request.Cookies.Set(cookie);
    }
}