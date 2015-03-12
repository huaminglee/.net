/*----------------------------------------------------------------
    // Copyright (C) 2014 培德科技
    // 版权所有。 
    // 作者：邹远江 
    //
    // 文件名：MyString.cs
    // 文件功能描述：防注入和过滤工具
    // 创建标识：邹远江2014-06-20
    //
    // 修改标识：
    // 修改描述：
 //----------------------------------------------------------------*/

using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;


namespace PDTech.OA.DAL
{
    public class MyString
    {
        /// <summary>
        /// 过滤非法的字符串,防止数据库注入
        /// </summary>
        /// <param name="sSql"></param>
        /// <returns></returns>
        public static string CheckSQLstring(string sSql)
        {
            sSql = sSql.Replace("exec", "");
            sSql = sSql.Replace("delete", "");
            sSql = sSql.Replace(";", "");
            sSql = sSql.Replace("master", "");
            sSql = sSql.Replace("'", "");
            sSql = sSql.Replace("truncate", "");
            sSql = sSql.Replace("declare", "");
            sSql = sSql.Replace("create", "");
            sSql = sSql.Replace("xp_", "no");
            sSql = sSql.Replace("script", "");
            sSql = sSql.Replace("*", "");
            sSql = sSql.Replace("<", "");
            sSql = sSql.Replace("=", "");
            sSql = sSql.Replace(">", "");
            return sSql;
        }


        /// <summary>
        /// 转义SQL中的限制符号
        /// </summary>
        /// <param name="InPut"></param>
        /// <returns></returns>
        public static string SQL_ESC(string InPut)
        {
            StringBuilder OutPut = new StringBuilder();
            OutPut.Append(InPut);
            OutPut.Replace("[", "[[]");
            OutPut.Replace("%", "[%]");
            OutPut.Replace("_", "[_]");
            OutPut.Replace("'", "''");

            return OutPut.ToString().Trim();
        }


        /// <summary>
        /// 转换arraylist数组为逗号分割的字符串
        /// </summary>
        /// <param name="ar"></param>
        /// <returns></returns>
        public static string ArraylistToString(ArrayList ar)
        {
            if (ar.Count == 0) { return ""; }
            string retstr = string.Empty;
            for (int i = 0; i < ar.Count; i++)
            {
                retstr += ar[i].ToString().Trim() + ",";
            }
            if (retstr.Substring(retstr.Length - 1, 1) == ",") retstr = retstr.Substring(0, retstr.Length - 1);
            return retstr;

        }

        /// <summary>
        /// 转换arraylist数组为split分割的字符串
        /// </summary>
        /// <param name="ar"></param>
        /// <param name="split"></param>
        /// <returns></returns>
        public static string ArraylistToString(ArrayList ar, string split)
        {
            if (ar.Count == 0) { return ""; }
            string retstr = string.Empty;
            for (int i = 0; i < ar.Count; i++)
            {
                retstr += ar[i].ToString().Trim() + split;
            }
            if (retstr.Substring(retstr.Length - split.Length, split.Length) == split) retstr = retstr.Substring(0, retstr.Length - split.Length);
            return retstr;
        }

        /// <summary>
        /// 布尔类型转换为整型
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static int Bool2Int(object obj)
        {
            if (Convert.ToBoolean(obj) == true)
                return 1;
            else
                return 0;
        }

        /// <summary>
        /// 去除原字符串结尾处的所有替换字符串
        /// 如：原字符串"sdlfjdcdcd",替换字符串"cd" 返回"sdlfjd"
        /// </summary>
        /// <param name="strSrc"></param>
        /// <param name="strTrim"></param>
        /// <returns></returns>
        public static string TrimEnd(string strSrc, string strTrim)
        {
            if (strSrc.EndsWith(strTrim))
            {
                string strDes = strSrc.Substring(0, strSrc.Length - strTrim.Length);
                return TrimEnd(strDes, strTrim);
            }
            return strSrc;
        }

    }
}
