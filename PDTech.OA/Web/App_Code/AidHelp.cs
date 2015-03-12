using System;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text.RegularExpressions;
using System.Text;
using System.Collections.Generic;
using System.Reflection;
using PDTech.OA.Model;
using System.Runtime.Serialization.Json;
using System.IO;
using System.Collections;
using System.Linq;

/// <summary>
/// AidHelp 的摘要说明
/// </summary>
public class AidHelp
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
    /// 泛型转换Json格式
    /// </summary>
    /// <param name="IList">待转换的泛型</param>
    /// <returns>转换后的Json</returns>
    public static string ObjectToJson<T>(string jsonName, IList<T> IL)
    {
        StringBuilder Json = new StringBuilder();
        Json.Append("{\"" + jsonName + "\":[");
        if (IL.Count > 0)
        {
            for (int i = 0; i < IL.Count; i++)
            {
                T obj = Activator.CreateInstance<T>();
                Type type = obj.GetType();
                PropertyInfo[] pis = type.GetProperties();
                Json.Append("{");
                for (int j = 0; j < pis.Length; j++)
                {
                    Json.Append("\"" + pis[j].Name.ToString() + "\":\"" + pis[j].GetValue(IL[i], null) + "\"");
                    if (j < pis.Length - 1)
                    {
                        Json.Append(",");
                    }
                }
                Json.Append("}");
                if (i < IL.Count - 1)
                {
                    Json.Append(",");
                }
            }
        }
        Json.Append("]}");
        return Json.ToString();
    }

    /// <summary>
    /// 生成ID(唯一)
    /// </summary>
    /// <returns>生成好的ID</returns>
    public static string CreatID()
    {
        return DateTime.Now.ToString("yyyyMMddhhmmssfff");//获取当前时间(含毫秒)
    }

    public static string toYyyy_MM_dd(string s)
    {
        if (string.IsNullOrEmpty(s))
            return null;
        else
            return Convert.ToDateTime(s).ToString("yyyy-MM-dd");//获取当前时间(含毫秒)
    }

    /// <summary>
    /// 生成ID(唯一)
    /// </summary>
    /// <param name="Strproof">生成ID时所需要的凭证</param>
    /// <returns>生成好的ID</returns>
    public static string CreatID(string Strproof)
    {
        return DateTime.Now.ToString("yyyyMMddhhmmssfff") + Strproof;//获取当前时间(含毫秒)并且拼接凭证
    }
    #region 各种验证
    #region 验证身份证号码否有效
    /**/
    /// <summary>
    /// 验证身份证是否有效
    /// </summary>
    /// <param name="Id"></param>
    /// <returns></returns>
    public static bool IsIDCard(string Id)
    {
        ///18 位身份证号码验证
        if (Id.Length == 18)
        {
            bool check = IsIDCard18(Id);
            return check;
        }
        ///15位身份证号码验证
        else if (Id.Length == 15)
        {
            bool check = IsIDCard15(Id);
            return check;
        }
        else
        {
            return false;
        }
    }
    /// <summary>
    ///18 位身份证号码验证
    /// </summary>
    /// <param name="Id"></param>
    /// <returns></returns>
    public static bool IsIDCard18(string Id)
    {
        long n = 0;
        if (long.TryParse(Id.Remove(17), out n) == false || n < Math.Pow(10, 16) || long.TryParse(Id.Replace('x', '0').Replace('X', '0'), out n) == false)
        {
            return false;//数字验证
        }
        string address = "11x22x35x44x53x12x23x36x45x54x13x31x37x46x61x14x32x41x50x62x15x33x42x51x63x21x34x43x52x64x65x71x81x82x91";
        if (address.IndexOf(Id.Remove(2)) == -1)
        {
            return false;//省份验证
        }
        string birth = Id.Substring(6, 8).Insert(6, "-").Insert(4, "-");
        DateTime time = new DateTime();
        if (DateTime.TryParse(birth, out time) == false)
        {
            return false;//生日验证
        }
        string[] arrVarifyCode = ("1,0,x,9,8,7,6,5,4,3,2").Split(',');
        string[] Wi = ("7,9,10,5,8,4,2,1,6,3,7,9,10,5,8,4,2").Split(',');
        char[] Ai = Id.Remove(17).ToCharArray();
        int sum = 0;
        for (int i = 0; i < 17; i++)
        {
            sum += int.Parse(Wi[i]) * int.Parse(Ai[i].ToString());
        }
        int y = -1;
        Math.DivRem(sum, 11, out y);
        if (arrVarifyCode[y] != Id.Substring(17, 1).ToLower())
        {
            return false;//校验码验证
        }
        return true;//符合GB11643-1999标准
    }
    /// <summary>
    /// 15位身份证号码验证
    /// </summary>
    /// <param name="Id"></param>
    /// <returns></returns>
    public static bool IsIDCard15(string Id)
    {
        long n = 0;
        if (long.TryParse(Id, out n) == false || n < Math.Pow(10, 14))
        {
            return false;//数字验证
        }
        string address = "11x22x35x44x53x12x23x36x45x54x13x31x37x46x61x14x32x41x50x62x15x33x42x51x63x21x34x43x52x64x65x71x81x82x91";
        if (address.IndexOf(Id.Remove(2)) == -1)
        {
            return false;//省份验证
        }
        string birth = Id.Substring(6, 6).Insert(4, "-").Insert(2, "-");
        DateTime time = new DateTime();
        if (DateTime.TryParse(birth, out time) == false)
        {
            return false;//生日验证
        }
        return true;//符合15位身份证标准
    }
    #endregion
    #region 验证手机号
    /**/
    /// <summary>
    /// 验证手机号
    /// </summary>
    /// <param name="source"></param>
    /// <returns></returns>
    public static bool IsMobile(string source)
    {
        return Regex.IsMatch(source, @"^1[345678]\d{9}$", RegexOptions.IgnoreCase);
    }

    /// <summary>
    /// 判断是否是座机号码
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    public static bool IsPhone(string phone)
    {
        string pattern = @"^(\d{3,4}-)?\d{6,8}$";
        Regex regex = new Regex(pattern);
        return regex.IsMatch(phone);
    }
    /// <summary>
    /// 判断是否是浮点数
    /// </summary>
    /// <param name="number"></param>
    /// <returns></returns>
    public static bool IsDecimal(string number)
    {
        string reg = @"^(-?\d+)(\.\d+)?$";
        Regex regex = new Regex(reg);
        return regex.IsMatch(number);
    }
    #endregion
    #region 验证是不是正常字符 数字
    /**/
    /// <summary>
    /// 验证是不是正常字符 数字
    /// </summary>
    /// <param name="source"></param>
    /// <returns></returns>
    public static bool IsNormalChar(string source)
    {
        return Regex.IsMatch(source, @"[\d]+", RegexOptions.IgnoreCase);
    }

    #endregion
    /**/
    /// <summary>
    /// 验证邮箱
    /// </summary>
    /// <param name="source"></param>
    /// <returns></returns>
    public static bool IsEmail(string source)
    {
        return Regex.IsMatch(source, @"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$", RegexOptions.IgnoreCase);
    }

    /// <summary>
    /// 生成jsonTree结构
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
                PersonTree cNode = new PersonTree() { id = CRow[i]["department_id"].ToString(), text = CRow[i]["department_name"].ToString(), state = "closed", status = "department", iconCls = "glyphicon glyphicon-folder-close", duid = CRow[i]["DEFAULT_USER"].ToString() };//组织子节点的json格式
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
        /***查询人员***/
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
    /// 从网站自定义配置文件中获取对应的节点列表
    /// </summary>
    /// <param name="sNodeName">节点名称</param>
    /// <returns></returns>
    public static DataTable GetDataTableFromConfig(string sNodeName)
    {
        return XmlHelper.GetNodeList(AppDomain.CurrentDomain.BaseDirectory + "App_Resources/Xml/SiteConfig.xml", sNodeName);
    }
    /// <summary>
    /// 过滤特殊字符
    /// 如果字符串为空，直接返回。
    /// </summary>
    /// <param name="str">需要过滤的字符串</param>
    /// <returns>过滤好的字符串</returns>
    public static string FilterSpecial(string str)
    {
        if (str == "")
        {
            return str;
        }
        else
        {

            str = Replace(str, "'delete", "");
            str = Replace(str, "'create", "");
            str = Replace(str, "'drop", "");
            str = Replace(str, "'delcare", "");
            str = Replace(str, "'or", "");
            str = Replace(str, "'alter", "");
            str = Replace(str, "'truncate", "");
            str = Replace(str, "'insert", null);
            str = Replace(str, "'DELETE", "");
            str = Replace(str, "'CREATE", "");
            str = Replace(str, "'DROP", "");
            str = Replace(str, "'DELCARE", "");
            str = Replace(str, "'OR", "");
            str = Replace(str, "'ALTER", "");
            str = Replace(str, "'TRUNCATE", "");
            str = Replace(str, "'INSERT", null);
            str = str.Replace("''", "");
            str = str.Replace(">=", "");
            str = str.Replace("=<", "");
            str = str.Replace(";", "");
            str = str.Replace("||", "");
            str = Replace(str, "\n", "<br/>");
            str = Replace(str, "\r\n", "<br/>");
            str = Replace(str, "?", "");
            str = Replace(str, "select", null);
            str = Replace(str, "insert", null);
            str = Replace(str, "update", null);
            str = Replace(str, "delete", null);
            str = Replace(str, "create", null);
            str = Replace(str, "drop", null);
            str = Replace(str, "delcare", null);
            str = Replace(str, "truncate", null);
            str = Replace(str, "alter", null);
            str = Replace(str, "SELECT", null);
            str = Replace(str, "INSERT", null);
            str = Replace(str, "UPDATE", null);
            str = Replace(str, "DELETE", null);
            str = Replace(str, "CREATE", null);
            str = Replace(str, "DROP", null);
            str = Replace(str, "DELCARE", null);
            str = Replace(str, "TRUNCATE", null);
            str = Replace(str, "ALTER", null);
            return str;
        }
    }

    public static string ShortTime(object obj)
    {
        if (obj == null || string.IsNullOrEmpty(obj.ToString()))
        {
            return "";
        }
        else
        {
            return new ConvertHelper(obj.ToString()).ToDateTime.Value.ToString("yyyy-MM-dd");
        }
    }
    public static string Replace(string Expression, string Find, string Replacement)
    {
        return Replace(Expression, Find, Replacement, StringComparison.OrdinalIgnoreCase);
    }

    public static string Replace(string Expression, string Find, string Replacement, StringComparison Compare)
    {
        if (string.IsNullOrEmpty(Expression) || string.IsNullOrEmpty(Find))
        {
            return Expression;
        }

        int iIndex = 0;
        int length = Expression.Length;
        int iFindLength = Find.Length;

        StringBuilder builder = new StringBuilder(length);

        while (iIndex < length)
        {
            int iFindIndex = Expression.IndexOf(Find, iIndex, Compare);
            if (iFindIndex < 0)
            {
                builder.Append(Expression.Substring(iIndex));
                break;
            }
            builder.Append(Expression.Substring(iIndex, iFindIndex - iIndex));
            builder.Append(Replacement);
            iIndex = iFindIndex + iFindLength;
        }
        return builder.ToString();
    }

    /// <summary>
    /// 构造流程步骤要打印的html
    /// </summary>
    /// <param name="arId">公文ID</param>
    /// <returns></returns>
    public static string get_PrintInfoListAll_Html(decimal arId, bool isshownotstart = true)
    {
        PDTech.OA.BLL.VIEW_PRINT_STEPDETAIL pBll = new PDTech.OA.BLL.VIEW_PRINT_STEPDETAIL();
        PDTech.OA.BLL.RISK_POINT_INFO rpiBll = new PDTech.OA.BLL.RISK_POINT_INFO();
        IList<PDTech.OA.Model.RISK_POINT_INFO> allRiskPoint = rpiBll.GetAllRiskPointInfo();
        decimal per_stepid = -1;///前一步骤ID
        IList<PDTech.OA.Model.VIEW_PRINT_STEPDETAIL> printList = pBll.get_PrintInfoListAll(new PDTech.OA.Model.VIEW_PRINT_STEPDETAIL() { ARCHIVE_ID = arId });
        StringBuilder sList = new StringBuilder();
        sList.Append(@" <table class='main_pntList' cellpadding='0px' cellspacing='0px' style='margin-left:20px;'>
                        <tr>
                            <td style='width:80px;'>风险点</td>
                            <td style='width:110px;'>步骤名称</td>
                            <td style='width:101px;'>办理人员</td>
                            <td style='width:238px;'>拟办意见</td>
                            <td style='width:100px;'>开始时间</td>
                            <td style='width:102px;'>完成时间</td>
                            <td style='width:100px;'>办理时限</td>
                            <td style='width:100px;'>办理状态</td>
                        </tr>");
        foreach (var item in printList)
        {
            string status_title = "";
            string tr_class = "";
            if (!isshownotstart && item.TASK_STATE==-1)
            {
                continue;
            }
            switch (item.TASK_STATE.ToString())
            {
                case "0":
                    tr_class = "green HandCss";
                    status_title = " 进行中";
                    break;
                case "1":
                    tr_class = "Orange HandCss";
                    status_title = " 已完成";
                    break;
                case "-1":
                    tr_class = "HandCss";
                    status_title = " 未开始";
                    break;


            }

            if ((!item.Equals(printList.First())) && item.STEP_ID != per_stepid)//相邻同一步骤+最后一步 不显示箭头符合
            {
                sList.Append("<tr>");
                sList.Append("<td colspan='8'><img src='/images/nextIcon.png' alt='下一步' style='height:20px;margin-left:20px; '/></td>");
                sList.Append("</tr>");
            }
            per_stepid = item.STEP_ID.Value;
            sList.Append(" <tr  class='" + tr_class + "'>");
            sList.Append(" <td valign=\"middle\" style='width:80px;text-align:left;'>");
            #region 获取步骤对应的风险点
            PDTech.OA.Model.RISK_POINT_INFO step_risk_point = null;
            if (allRiskPoint != null)
            {
                step_risk_point = allRiskPoint.Where(r => r.STEP_TYPE == "OA_WORKFLOW_STEP" && r.STEP_ID == item.STEP_ID.Value).FirstOrDefault();
            }
            if (step_risk_point != null)
            {
                string risk_title = "风险点：" + step_risk_point.RISK_POINT + "\n\n防范措施：" + step_risk_point.RISK_RESOLVE + "";
                string risk_icon = "";
                //配置提示样式
                switch (step_risk_point.RISK_LEVEL.Value.ToString())
                {
                    case "1":
                        risk_icon = "<b class='text-danger pull-right' style='font-size: 18px; '><span class='glyphicon glyphicon-star'></span><span class='glyphicon glyphicon-star'></span><span class='glyphicon glyphicon-star'></span></b>";
                        break;
                    case "2":
                        risk_icon = "<b class='text-danger pull-right' style='font-size: 18px;'><span class='glyphicon glyphicon-star'></span><span class='glyphicon glyphicon-star'></span></b>";
                        break;
                    case "3":
                        risk_icon = "<b class='text-danger pull-right' style='font-size: 18px; '><span class='glyphicon glyphicon-star'></span></b>";
                        break;
                }
                sList.Append(" <span class=\"AttitudeBtn\"; title=\"" + risk_title + "\">" + risk_icon + "</span>");
            }
            #endregion
            sList.Append(" </td>");
            sList.Append(" <td class=\"MCTableTr_Left\" valign=\"middle\" style='width:110px;text-align:center;'>");
            sList.Append(" <span class=\"AttitudeBtn\">" + item.PRINT_TITLE + "</span>");
            sList.Append(" </td>");
            sList.Append(" <td align=\"center\" style=\"width:101px;\">");
            sList.Append(item.FULL_NAME);
            sList.Append(" </td>");
            sList.Append(" <td align=\"center\" style=\"width:238px;\" >");
            sList.Append(item.TASK_REMARK);
            sList.Append(" </td>");
            sList.Append(" <td align=\"center\" style=\"width:100px;\">");
            sList.Append(AidHelp.ShortTime(item.START_TIME));
            sList.Append(" </td>");
            sList.Append(" <td align=\"center\" style=\"width:102px;\">");
            sList.Append(AidHelp.ShortTime(item.END_TIME));
            sList.Append(" </td>");
            sList.Append(" <td align=\"center\" style=\"width:100px;\">");
            sList.Append(AidHelp.ShortTime(item.LIMIT_TIME));
            sList.Append(" </td>");
            sList.Append(" <td align=\"center\" style=\"width:100px;\">");
            sList.Append(status_title);
            sList.Append(" </td>");
            sList.Append(" </tr>");
        }
        sList.Append("  </table>");
        return sList.ToString();
    }
    #endregion
}