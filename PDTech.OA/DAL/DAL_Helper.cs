/*----------------------------------------------------------------
    // Copyright (C) 2014 培德科技
    // 版权所有。 
    // 作者：邹远江 
    //
    // 文件名：DAL_Helper.cs
    // 文件功能描述：数据访问层工具
    // 创建标识：邹远江2014-06-20
    //
    // 修改标识：
    // 修改描述：
 //----------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Reflection;
using System.Data.OracleClient;
using System.Data.SqlClient;

namespace PDTech.OA.DAL
{
    public class DAL_Helper
    {

        public static void get_db_para_value(System.Data.OracleClient.OracleParameter[] p_s)
        {
            foreach (var item in p_s)
            {
                if (item.Value == null || (item.OracleType == OracleType.Clob && string.IsNullOrEmpty(item.Value.ToString())))
                    item.Value = DBNull.Value;
            }
        }

        public static void get_db_para_value(SqlParameter[] p_s)
        {
            foreach (var item in p_s)
            {
                if (item.Value == null || (item.SqlDbType == SqlDbType.Text && string.IsNullOrEmpty(item.Value.ToString())))
                    item.Value = DBNull.Value;
            }
        }

        #region 根据数据表构造泛型集合
        /// <summary>
        /// 根据数据表构造泛型集合
        /// </summary>
        /// <typeparam name="T">泛型</typeparam>
        /// <param name="dt">数据表</param>
        /// <returns>泛型实体集合</returns>
        public static IList<T> CommonFillList<T>(DataTable dt) where T : new()
        {
            //泛型集合
            IList<T> list = new List<T>(dt.Rows.Count);

            //循环插入
            foreach (DataRow item in dt.Rows)
            {
                list.Add(CommonFill<T>(item));
            }
            return list;
        }
        #endregion

        #region 由泛型实体构造查询字符串
        /// <summary>
        /// 由泛型实体构造查询字符串
        /// </summary>
        /// <typeparam name="T">泛型</typeparam>
        /// <param name="t">泛型实体Model对象</param>
        /// <returns>查询条件字符串</returns>
        public static string GetWhereCondition<T>(T t)
        {
            //构造查询条件
            StringBuilder where = new StringBuilder(512);
            Type type = typeof(T);
            if (t == null)
                return string.Empty;
            PropertyInfo sortproperty = null;
            string defaultorderby = string.Empty;
            foreach (PropertyInfo item in type.GetProperties())
            {
                if (string.IsNullOrEmpty(defaultorderby))
                {
                    if (item.Name.ToLower() != "sortfields" && item.Name.ToLower() != "append")
                    {
                        defaultorderby = item.Name;
                    }
                }
                //字段为空不拼接入查询条件
                if (item.GetValue(t, null) == null)
                    continue;

                //字符串类型
                if (item.PropertyType == typeof(string))
                {

                    //排序字段相关
                    if (item.Name.ToLower() == "sortfields")
                    {
                        sortproperty = item;
                        continue;
                    }
                    if (item.Name.ToLower() == "append")
                    {
                        where.AppendFormat(" AND ({0})", item.GetValue(t, null));
                        continue;
                    }
                    //匹配模糊查询  比如 地区编号AreaId add --- 2012-8-12
                    if (item.Name.ToLower() == "areaid")
                    {
                        where.AppendFormat(" AND {0} LIKE '{1}%'", item.Name, MyString.TrimEnd(item.GetValue(t, null).ToString(), "00"));
                        continue;
                    }

                    if (item.GetValue(t, null).ToString() == string.Empty)
                    {
                        continue;
                    }

                    //主键字段精确查询
                    if (item.Name.ToLower().Contains("id"))
                    {
                        where.AppendFormat(" AND {0} = '{1}'", item.Name, item.GetValue(t, null).ToString().Replace("'", ""));
                    }
                    else
                    {
                        where.AppendFormat(" AND {0} LIKE '%{1}%'", item.Name, item.GetValue(t, null).ToString().Replace("'", ""));
                    }
                }
                //实数类型
                if (item.PropertyType == typeof(double?))
                {
                    //如果以“to结尾的是小于等于这个数”
                    if (item.Name.ToLower().EndsWith("to"))
                    {
                        where.AppendFormat(" AND {0} <= {1}", item.Name.Replace("To", ""), item.GetValue(t, null));
                    }
                    //如果以“from结尾的是大于于等于这个数”
                    else if (item.Name.ToLower().EndsWith("from"))
                    {
                        where.AppendFormat(" AND {0} >= {1}", item.Name.Replace("From", ""), item.GetValue(t, null));
                    }
                    else//等于
                    {
                        where.AppendFormat(" AND {0} = {1}", item.Name, item.GetValue(t, null));
                    }

                }
                //实数类型
                if (item.PropertyType == typeof(decimal?))
                {
                    //如果以“to结尾的是小于等于这个数”
                    if (item.Name.ToLower().EndsWith("to"))
                    {
                        where.AppendFormat(" AND {0} <= {1}", item.Name.Substring(0, item.Name.Length - 2), item.GetValue(t, null));
                    }
                    //如果以“from结尾的是大于于等于这个数”
                    else if (item.Name.ToLower().EndsWith("from"))
                    {
                        where.AppendFormat(" AND {0} >= {1}", item.Name.Substring(0, item.Name.Length - 4), item.GetValue(t, null));
                    }
                    else//等于
                    {
                        where.AppendFormat(" AND {0} = {1}", item.Name, item.GetValue(t, null));
                    }

                }
                //整数类型
                if (item.PropertyType == typeof(int?))
                {
                    //如果以“to结尾的是小于等于这个数”
                    if (item.Name.ToLower().EndsWith("to"))
                    {
                        where.AppendFormat(" AND {0} <= {1}", item.Name.Substring(0, item.Name.Length - 2), item.GetValue(t, null));
                    }
                    //如果以“from结尾的是大于于等于这个数”
                    else if (item.Name.ToLower().EndsWith("from"))
                    {
                        where.AppendFormat(" AND {0} >= {1}", item.Name.Replace("From", ""), item.GetValue(t, null));
                    }
                    else//等于
                    {
                        where.AppendFormat(" AND {0} = {1}", item.Name, item.GetValue(t, null));
                    }

                }
                //日期类型
                if (item.PropertyType == typeof(DateTime?))
                {
                    //如果以“to结尾的是晚于等于这个日期”
                    if (item.Name.ToLower().EndsWith("to"))
                    {
                        where.AppendFormat(" AND {0} <= '{1}'", item.Name.Substring(0, item.Name.Length - 2), ((DateTime?)item.GetValue(t, null)).Value.ToShortDateString());
                    }
                    //如果以“from结尾的是早于等于日期”
                    else if (item.Name.ToLower().EndsWith("from"))
                    {
                        where.AppendFormat(" AND {0} >= '{1}'", item.Name.Substring(0, item.Name.Length - 4), ((DateTime?)item.GetValue(t, null)).Value.ToShortDateString());
                    }
                    else//等于
                    {
                        where.AppendFormat(" AND {0} = '{1}'", item.Name, ((DateTime?)item.GetValue(t, null)).Value.ToShortDateString());
                    }

                }
                //逻辑类型
                if (item.PropertyType == typeof(bool?))
                {
                    where.AppendFormat(" AND {0} = {1}", item.Name, (((bool?)item.GetValue(t, null)).Value ? 1 : 0));
                }
            }
            string orderby = string.Empty;
            if (sortproperty == null || string.IsNullOrEmpty(sortproperty.GetValue(t, null).ToString()))
            {
                orderby = defaultorderby;
            }
            else
            {
                orderby = sortproperty.GetValue(t, null).ToString();
            }
            where.AppendFormat(" ORDER BY {0}", orderby);
            return where.ToString();
        }
        /// <summary>
        /// 由泛型实体构造查询字符串
        /// </summary>
        /// <typeparam name="T">泛型</typeparam>
        /// <param name="t">泛型实体Model对象</param>
        /// <returns>查询条件字符串</returns>
        public static string GetWhereConditions<T>(T t)
        {
            //构造查询条件
            StringBuilder where = new StringBuilder(512);
            Type type = typeof(T);
            if (t == null)
                return string.Empty;
            PropertyInfo sortproperty = null;
            string defaultorderby = string.Empty;
            foreach (PropertyInfo item in type.GetProperties())
            {
                if (string.IsNullOrEmpty(defaultorderby))
                {
                    if (item.Name.ToLower() != "sortfields" && item.Name.ToLower() != "append")
                    {
                        defaultorderby = item.Name;
                    }
                }
                //字段为空不拼接入查询条件
                if (item.GetValue(t, null) == null)
                    continue;

                //字符串类型
                if (item.PropertyType == typeof(string))
                {
                    if (item.Name.ToLower() == "append")
                    {
                        where.AppendFormat(" AND ({0})", item.GetValue(t, null));
                        continue;
                    }
                    //匹配模糊查询  比如 地区编号AreaId add --- 2012-8-12
                    if (item.Name.ToLower() == "areaid")
                    {
                        where.AppendFormat(" AND {0} LIKE '{1}%'", item.Name, MyString.TrimEnd(item.GetValue(t, null).ToString(), "00"));
                        continue;
                    }

                    if (item.GetValue(t, null).ToString() == string.Empty)
                    {
                        continue;
                    }

                    //主键字段精确查询
                    if (item.Name.ToLower().Contains("id"))
                    {
                        where.AppendFormat(" AND {0} = '{1}'", item.Name, item.GetValue(t, null).ToString().Replace("'", ""));
                    }
                    else
                    {
                        where.AppendFormat(" AND {0} LIKE '%{1}%'", item.Name, item.GetValue(t, null).ToString().Replace("'", ""));
                    }
                }
                //实数类型
                if (item.PropertyType == typeof(double?))
                {
                    //如果以“to结尾的是小于等于这个数”
                    if (item.Name.ToLower().EndsWith("to"))
                    {
                        where.AppendFormat(" AND {0} <= {1}", item.Name.Replace("To", ""), item.GetValue(t, null));
                    }
                    //如果以“from结尾的是大于于等于这个数”
                    else if (item.Name.ToLower().EndsWith("from"))
                    {
                        where.AppendFormat(" AND {0} >= {1}", item.Name.Replace("From", ""), item.GetValue(t, null));
                    }
                    else//等于
                    {
                        where.AppendFormat(" AND {0} = {1}", item.Name, item.GetValue(t, null));
                    }

                }
                //实数类型
                if (item.PropertyType == typeof(decimal?))
                {
                    //如果以“to结尾的是小于等于这个数”
                    if (item.Name.ToLower().EndsWith("to"))
                    {
                        where.AppendFormat(" AND {0} <= {1}", item.Name.Substring(0, item.Name.Length - 2), item.GetValue(t, null));
                    }
                    //如果以“from结尾的是大于于等于这个数”
                    else if (item.Name.ToLower().EndsWith("from"))
                    {
                        where.AppendFormat(" AND {0} >= {1}", item.Name.Substring(0, item.Name.Length - 4), item.GetValue(t, null));
                    }
                    else//等于
                    {
                        where.AppendFormat(" AND {0} = {1}", item.Name, item.GetValue(t, null));
                    }

                }
                //整数类型
                if (item.PropertyType == typeof(int?))
                {
                    //如果以“to结尾的是小于等于这个数”
                    if (item.Name.ToLower().EndsWith("to"))
                    {
                        where.AppendFormat(" AND {0} <= {1}", item.Name.Substring(0, item.Name.Length - 2), item.GetValue(t, null));
                    }
                    //如果以“from结尾的是大于于等于这个数”
                    else if (item.Name.ToLower().EndsWith("from"))
                    {
                        where.AppendFormat(" AND {0} >= {1}", item.Name.Replace("From", ""), item.GetValue(t, null));
                    }
                    else//等于
                    {
                        where.AppendFormat(" AND {0} = {1}", item.Name, item.GetValue(t, null));
                    }

                }
                //日期类型
                if (item.PropertyType == typeof(DateTime?))
                {
                    //如果以“to结尾的是晚于等于这个日期”
                    if (item.Name.ToLower().EndsWith("to"))
                    {
                        where.AppendFormat(" AND {0} <= '{1}'", item.Name.Substring(0, item.Name.Length - 2), ((DateTime?)item.GetValue(t, null)).Value.ToShortDateString());
                    }
                    //如果以“from结尾的是早于等于日期”
                    else if (item.Name.ToLower().EndsWith("from"))
                    {
                        where.AppendFormat(" AND {0} >= '{1}'", item.Name.Substring(0, item.Name.Length - 4), ((DateTime?)item.GetValue(t, null)).Value.ToShortDateString());
                    }
                    else//等于
                    {
                        where.AppendFormat(" AND {0} = '{1}'", item.Name, ((DateTime?)item.GetValue(t, null)).Value.ToShortDateString());
                    }

                }
                //逻辑类型
                if (item.PropertyType == typeof(bool?))
                {
                    where.AppendFormat(" AND {0} = {1}", item.Name, (((bool?)item.GetValue(t, null)).Value ? 1 : 0));
                }
            }
            string orderby = string.Empty;
            if (sortproperty == null || string.IsNullOrEmpty(sortproperty.GetValue(t, null).ToString()))
            {
                orderby = defaultorderby;
            }
            else
            {
                orderby = sortproperty.GetValue(t, null).ToString();
            }
            return where.ToString();
        }

        /// <summary>
        /// 由泛型实体构造Oracle查询对象
        /// </summary>
        /// <typeparam name="T">泛型</typeparam>
        /// <param name="t">泛型实体Model对象</param>
        /// <returns>查询条件字符串+查询条件参数</returns>
        public static OracleSqlCondition GetWhereConditionPOracle<T>(T t)
        {
            OracleSqlCondition sCond = new OracleSqlCondition();
            //构造查询条件
            StringBuilder where = new StringBuilder(512);
            Type type = typeof(T);
            if (t == null)
                return sCond;
            PropertyInfo sortproperty = null;
            string defaultorderby = string.Empty;
            foreach (PropertyInfo item in type.GetProperties())
            {
                if (string.IsNullOrEmpty(defaultorderby))
                {
                    if (item.Name.ToLower() != "sortfields" && item.Name.ToLower() != "append")
                    {
                        defaultorderby = item.Name;
                    }
                }
                //字段为空不拼接入查询条件
                if (item.GetValue(t, null) == null)
                    continue;

                //字符串类型
                if (item.PropertyType == typeof(string))
                {
                    if (item.Name.ToLower() == "append")
                    {
                        where.AppendFormat(" AND ({0})", item.GetValue(t, null));
                        continue;
                    }
                    //匹配模糊查询  比如 地区编号AreaId add --- 2012-8-12
                    if (item.Name.ToLower() == "areaid")
                    {
                        where.AppendFormat(" AND {0} LIKE ':{0}%'", item.Name);
                        OracleParameter op = new OracleParameter(":" + item.Name, MyString.TrimEnd(item.GetValue(t, null).ToString(), "00"));
                        op.OracleType = OracleType.NVarChar;
                        sCond.oracleParaList.Add(op);
                        continue;
                    }

                    if (item.GetValue(t, null).ToString() == string.Empty)
                    {
                        continue;
                    }

                    //主键字段精确查询
                    if (item.Name.ToLower().Contains("id"))
                    {
                        where.AppendFormat(" AND {0} = ':{0}'", item.Name, item.GetValue(t, null).ToString().Replace("'", ""));
                        OracleParameter op = new OracleParameter(":" + item.Name, item.GetValue(t, null).ToString().Replace("'", ""));
                        op.OracleType = OracleType.NVarChar;
                        sCond.oracleParaList.Add(op);
                    }
                    else
                    {
                        where.AppendFormat(" AND {0} LIKE '%:{0}%'", item.Name);
                        OracleParameter op = new OracleParameter(":" + item.Name, item.GetValue(t, null).ToString().Replace("'", ""));
                        op.OracleType = OracleType.NVarChar;
                        sCond.oracleParaList.Add(op);
                    }
                }
                //实数类型
                if (item.PropertyType == typeof(double?))
                {
                    //如果以“to结尾的是小于等于这个数”
                    if (item.Name.ToLower().EndsWith("to"))
                    {
                        where.AppendFormat(" AND {0} <= :{0}", item.Name.Replace("To", ""));
                        OracleParameter op = new OracleParameter(":" + item.Name.Replace("To", ""), item.GetValue(t, null));
                        op.OracleType = OracleType.Double;
                        sCond.oracleParaList.Add(op);
                    }
                    //如果以“from结尾的是大于于等于这个数”
                    else if (item.Name.ToLower().EndsWith("from"))
                    {
                        where.AppendFormat(" AND {0} >= :{0}", item.Name.Replace("From", ""));
                        OracleParameter op = new OracleParameter(":" + item.Name.Replace("From", ""), item.GetValue(t, null));
                        op.OracleType = OracleType.Double;
                        sCond.oracleParaList.Add(op);
                    }
                    else//等于
                    {
                        where.AppendFormat(" AND {0} = :{0}", item.Name);
                        OracleParameter op = new OracleParameter(":" + item.Name, item.GetValue(t, null));
                        op.OracleType = OracleType.Double;
                        sCond.oracleParaList.Add(op);
                    }

                }
                //实数类型
                if (item.PropertyType == typeof(decimal?))
                {
                    //如果以“to结尾的是小于等于这个数”
                    if (item.Name.ToLower().EndsWith("to"))
                    {
                        where.AppendFormat(" AND {0} <= :{0}", item.Name.Substring(0, item.Name.Length - 2));
                        OracleParameter op = new OracleParameter(":" + item.Name.Substring(0, item.Name.Length - 2), item.GetValue(t, null));
                        op.OracleType = OracleType.Number;
                        sCond.oracleParaList.Add(op);
                    }
                    //如果以“from结尾的是大于于等于这个数”
                    else if (item.Name.ToLower().EndsWith("from"))
                    {
                        where.AppendFormat(" AND {0} >= :{0}", item.Name.Substring(0, item.Name.Length - 4));
                        OracleParameter op = new OracleParameter(":" + item.Name.Substring(0, item.Name.Length - 4), item.GetValue(t, null));
                        op.OracleType = OracleType.Number;
                        sCond.oracleParaList.Add(op);
                    }
                    else//等于
                    {
                        where.AppendFormat(" AND {0} = :{0}", item.Name);
                        OracleParameter op = new OracleParameter(":" + item.Name, item.GetValue(t, null));
                        op.OracleType = OracleType.Number;
                        sCond.oracleParaList.Add(op);
                    }

                }
                //整数类型
                if (item.PropertyType == typeof(int?))
                {
                    //如果以“to结尾的是小于等于这个数”
                    if (item.Name.ToLower().EndsWith("to"))
                    {
                        where.AppendFormat(" AND {0} <= :{0}", item.Name.Substring(0, item.Name.Length - 2));
                        OracleParameter op = new OracleParameter(":" + item.Name.Substring(0, item.Name.Length - 2), item.GetValue(t, null));
                        op.OracleType = OracleType.Int32;
                        sCond.oracleParaList.Add(op);
                    }
                    //如果以“from结尾的是大于于等于这个数”
                    else if (item.Name.ToLower().EndsWith("from"))
                    {
                        where.AppendFormat(" AND {0} >= :{0}", item.Name.Substring(0, item.Name.Length - 4));
                        OracleParameter op = new OracleParameter(":" + item.Name.Substring(0, item.Name.Length - 4), item.GetValue(t, null));
                        op.OracleType = OracleType.Int32;
                        sCond.oracleParaList.Add(op);
                    }
                    else//等于
                    {
                        where.AppendFormat(" AND {0} = :{0}", item.Name);
                        OracleParameter op = new OracleParameter(":" + item.Name, item.GetValue(t, null));
                        op.OracleType = OracleType.Int32;
                        sCond.oracleParaList.Add(op);
                    }

                }
                //日期类型
                if (item.PropertyType == typeof(DateTime?))
                {
                    //如果以“to结尾的是小于等于这个数”
                    if (item.Name.ToLower().EndsWith("to"))
                    {
                        where.AppendFormat(" AND {0} <= :{0}", item.Name.Substring(0, item.Name.Length - 2));
                        OracleParameter op = new OracleParameter(":" + item.Name.Substring(0, item.Name.Length - 2), ((DateTime?)item.GetValue(t, null)).Value);
                        op.OracleType = OracleType.DateTime;
                        sCond.oracleParaList.Add(op);
                    }
                    //如果以“from结尾的是大于于等于这个数”
                    else if (item.Name.ToLower().EndsWith("from"))
                    {
                        where.AppendFormat(" AND {0} >= :{0}", item.Name.Substring(0, item.Name.Length - 4));
                        OracleParameter op = new OracleParameter(":" + item.Name.Substring(0, item.Name.Length - 4), ((DateTime?)item.GetValue(t, null)).Value);
                        op.OracleType = OracleType.DateTime;
                        sCond.oracleParaList.Add(op);
                    }
                    else//等于
                    {
                        where.AppendFormat(" AND {0} = :{0}", item.Name);
                        OracleParameter op = new OracleParameter(":" + item.Name, ((DateTime?)item.GetValue(t, null)).Value);
                        op.OracleType = OracleType.DateTime;
                        sCond.oracleParaList.Add(op);
                    }

                }
                //逻辑类型
                if (item.PropertyType == typeof(bool?))
                {
                    where.AppendFormat(" AND {0} = {1}", item.Name, (((bool?)item.GetValue(t, null)).Value ? 1 : 0));
                }
            }
            string orderby = string.Empty;
            if (sortproperty == null || string.IsNullOrEmpty(sortproperty.GetValue(t, null).ToString()))
            {
                orderby = defaultorderby;
            }
            else
            {
                orderby = sortproperty.GetValue(t, null).ToString();
            }
            where.AppendFormat(" ORDER BY {0}", orderby);
            sCond.ConditionSqlStr = where.ToString();
            return sCond;
        }

        public static SqlCondition GetWhereConditionForSql<T>(T t)
        {
            SqlCondition sCond = new SqlCondition();
            //构造查询条件
            StringBuilder where = new StringBuilder(512);
            Type type = typeof(T);
            if (t == null)
                return sCond;
            PropertyInfo sortproperty = null;
            string defaultorderby = string.Empty;
            foreach (PropertyInfo item in type.GetProperties())
            {
                if (string.IsNullOrEmpty(defaultorderby))
                {
                    if (item.Name.ToLower() != "sortfields" && item.Name.ToLower() != "append")
                    {
                        defaultorderby = item.Name;
                    }
                }
                //字段为空不拼接入查询条件
                if (item.GetValue(t, null) == null)
                    continue;

                //字符串类型
                if (item.PropertyType == typeof(string))
                {
                    if (item.Name.ToLower() == "append")
                    {
                        where.AppendFormat(" AND ({0})", item.GetValue(t, null));
                        continue;
                    }
                    //匹配模糊查询  比如 地区编号AreaId add --- 2012-8-12
                    if (item.Name.ToLower() == "areaid")
                    {
                        where.AppendFormat(" AND {0} LIKE '@{0}%'", item.Name);
                        SqlParameter op = new SqlParameter("@" + item.Name, MyString.TrimEnd(item.GetValue(t, null).ToString(), "00"));
                        op.SqlDbType = SqlDbType.NVarChar;
                        sCond.sqlParaList.Add(op);
                        continue;
                    }

                    if (item.GetValue(t, null).ToString() == string.Empty)
                    {
                        continue;
                    }

                    //主键字段精确查询
                    if (item.Name.ToLower().Contains("id"))
                    {
                        where.AppendFormat(" AND {0} = '@{0}'", item.Name, item.GetValue(t, null).ToString().Replace("'", ""));
                        SqlParameter op = new SqlParameter("@" + item.Name, item.GetValue(t, null).ToString().Replace("'", ""));
                        op.SqlDbType = SqlDbType.NVarChar;
                        sCond.sqlParaList.Add(op);
                    }
                    else
                    {
                        where.AppendFormat(" AND {0} LIKE '%@{0}%'", item.Name);
                        SqlParameter op = new SqlParameter("@" + item.Name, item.GetValue(t, null).ToString().Replace("'", ""));
                        op.SqlDbType = SqlDbType.NVarChar;
                        sCond.sqlParaList.Add(op);
                    }
                }
                //实数类型
                if (item.PropertyType == typeof(double?))
                {
                    //如果以“to结尾的是小于等于这个数”
                    if (item.Name.ToLower().EndsWith("to"))
                    {
                        where.AppendFormat(" AND {0} <= @{0}", item.Name.Replace("To", ""));
                        SqlParameter op = new SqlParameter("@" + item.Name.Replace("To", ""), item.GetValue(t, null));
                        op.SqlDbType = SqlDbType.Float;
                        sCond.sqlParaList.Add(op);
                    }
                    //如果以“from结尾的是大于于等于这个数”
                    else if (item.Name.ToLower().EndsWith("from"))
                    {
                        where.AppendFormat(" AND {0} >= @{0}", item.Name.Replace("From", ""));
                        SqlParameter op = new SqlParameter("@" + item.Name.Replace("From", ""), item.GetValue(t, null));
                        op.SqlDbType = SqlDbType.Float;
                        sCond.sqlParaList.Add(op);
                    }
                    else//等于
                    {
                        where.AppendFormat(" AND {0} = @{0}", item.Name);
                        SqlParameter op = new SqlParameter("@" + item.Name, item.GetValue(t, null));
                        op.SqlDbType = SqlDbType.Float;
                        sCond.sqlParaList.Add(op);
                    }

                }
                //实数类型
                if (item.PropertyType == typeof(decimal?))
                {
                    //如果以“to结尾的是小于等于这个数”
                    if (item.Name.ToLower().EndsWith("to"))
                    {
                        where.AppendFormat(" AND {0} <= @{0}", item.Name.Substring(0, item.Name.Length - 2));
                        SqlParameter op = new SqlParameter("@" + item.Name.Substring(0, item.Name.Length - 2), item.GetValue(t, null));
                        op.SqlDbType = SqlDbType.Decimal;
                        sCond.sqlParaList.Add(op);
                    }
                    //如果以“from结尾的是大于于等于这个数”
                    else if (item.Name.ToLower().EndsWith("from"))
                    {
                        where.AppendFormat(" AND {0} >= @{0}", item.Name.Substring(0, item.Name.Length - 4));
                        SqlParameter op = new SqlParameter("@" + item.Name.Substring(0, item.Name.Length - 4), item.GetValue(t, null));
                        op.SqlDbType = SqlDbType.Decimal;
                        sCond.sqlParaList.Add(op);
                    }
                    else//等于
                    {
                        where.AppendFormat(" AND {0} = @{0}", item.Name);
                        SqlParameter op = new SqlParameter("@" + item.Name, item.GetValue(t, null));
                        op.SqlDbType = SqlDbType.Decimal;
                        sCond.sqlParaList.Add(op);
                    }

                }
                //整数类型
                if (item.PropertyType == typeof(int?))
                {
                    //如果以“to结尾的是小于等于这个数”
                    if (item.Name.ToLower().EndsWith("to"))
                    {
                        where.AppendFormat(" AND {0} <= @{0}", item.Name.Substring(0, item.Name.Length - 2));
                        SqlParameter op = new SqlParameter("@" + item.Name.Substring(0, item.Name.Length - 2), item.GetValue(t, null));
                        op.SqlDbType = SqlDbType.Int;
                        sCond.sqlParaList.Add(op);
                    }
                    //如果以“from结尾的是大于于等于这个数”
                    else if (item.Name.ToLower().EndsWith("from"))
                    {
                        where.AppendFormat(" AND {0} >= @{0}", item.Name.Substring(0, item.Name.Length - 4));
                        SqlParameter op = new SqlParameter("@" + item.Name.Substring(0, item.Name.Length - 4), item.GetValue(t, null));
                        op.SqlDbType = SqlDbType.Int;
                        sCond.sqlParaList.Add(op);
                    }
                    else//等于
                    {
                        where.AppendFormat(" AND {0} = @{0}", item.Name);
                        SqlParameter op = new SqlParameter("@" + item.Name, item.GetValue(t, null));
                        op.SqlDbType = SqlDbType.Int;
                        sCond.sqlParaList.Add(op);
                    }

                }
                //日期类型
                if (item.PropertyType == typeof(DateTime?))
                {
                    //如果以“to结尾的是小于等于这个数”
                    if (item.Name.ToLower().EndsWith("to"))
                    {
                        where.AppendFormat(" AND {0} <= @{0}", item.Name.Substring(0, item.Name.Length - 2));
                        SqlParameter op = new SqlParameter("@" + item.Name.Substring(0, item.Name.Length - 2), ((DateTime?)item.GetValue(t, null)).Value);
                        op.SqlDbType = SqlDbType.DateTime;
                        sCond.sqlParaList.Add(op);
                    }
                    //如果以“from结尾的是大于于等于这个数”
                    else if (item.Name.ToLower().EndsWith("from"))
                    {
                        where.AppendFormat(" AND {0} >= @{0}", item.Name.Substring(0, item.Name.Length - 4));
                        SqlParameter op = new SqlParameter("@" + item.Name.Substring(0, item.Name.Length - 4), ((DateTime?)item.GetValue(t, null)).Value);
                        op.SqlDbType = SqlDbType.DateTime;
                        sCond.sqlParaList.Add(op);
                    }
                    else//等于
                    {
                        where.AppendFormat(" AND {0} = @{0}", item.Name);
                        SqlParameter op = new SqlParameter("@" + item.Name, ((DateTime?)item.GetValue(t, null)).Value);
                        op.SqlDbType = SqlDbType.DateTime;
                        sCond.sqlParaList.Add(op);
                    }

                }
                //逻辑类型
                if (item.PropertyType == typeof(bool?))
                {
                    where.AppendFormat(" AND {0} = {1}", item.Name, (((bool?)item.GetValue(t, null)).Value ? 1 : 0));
                }
            }
            string orderby = string.Empty;
            if (sortproperty == null || string.IsNullOrEmpty(sortproperty.GetValue(t, null).ToString()))
            {
                orderby = defaultorderby;
            }
            else
            {
                orderby = sortproperty.GetValue(t, null).ToString();
            }
            where.AppendFormat(" ORDER BY {0}", orderby);
            sCond.ConditionSqlStr = where.ToString();
            return sCond;
        }

        /// 由泛型实体构造查询字符串
        /// </summary>
        /// <typeparam name="T">泛型</typeparam>
        /// <param name="t">泛型实体Model对象</param>
        /// <returns>查询条件字符串</returns>
        public static string GetWhereCondition<T>(T t, bool usesorderby)
        {
            //构造查询条件
            StringBuilder where = new StringBuilder(512);
            Type type = typeof(T);
            if (t == null)
                return string.Empty;
            PropertyInfo sortproperty = null;
            string defaultorderby = string.Empty;
            foreach (PropertyInfo item in type.GetProperties())
            {
                if (string.IsNullOrEmpty(defaultorderby))
                {
                    if (item.Name.ToLower() != "sortfields" && item.Name.ToLower() != "append")
                    {
                        defaultorderby = item.Name;
                    }
                }
                //字段为空不拼接入查询条件
                if (item.GetValue(t, null) == null)
                    continue;

                //字符串类型
                if (item.PropertyType == typeof(string))
                {

                    //排序字段相关
                    if (item.Name.ToLower() == "sortfields")
                    {
                        sortproperty = item;
                        continue;
                    }
                    if (item.Name.ToLower() == "append")
                    {
                        where.AppendFormat(" AND ({0})", item.GetValue(t, null));
                        continue;
                    }
                    //地区字段模糊查询 add by ligang 2009-05-18
                    if (item.Name.ToLower() == "areaid")
                    {
                        where.AppendFormat(" AND {0} LIKE '{1}%'", item.Name, MyString.TrimEnd(item.GetValue(t, null).ToString(), "00"));
                        continue;
                    }

                    if (item.GetValue(t, null).ToString() == string.Empty)
                    {
                        continue;
                    }

                    //主键字段精确查询
                    if (item.Name.ToLower().Contains("id"))
                    {
                        where.AppendFormat(" AND {0} = '{1}'", item.Name, item.GetValue(t, null).ToString().Replace("'", ""));
                    }
                    else
                    {
                        where.AppendFormat(" AND {0} LIKE '%{1}%'", item.Name, item.GetValue(t, null).ToString().Replace("'", ""));///匹配为模糊查询 影响索引
                    }
                }
                //实数类型
                if (item.PropertyType == typeof(double?))
                {
                    //如果以“to结尾的是小于等于这个数”
                    if (item.Name.ToLower().EndsWith("to"))
                    {
                        where.AppendFormat(" AND {0} <= {1}", item.Name.Replace("To", ""), item.GetValue(t, null));
                    }
                    //如果以“from结尾的是大于于等于这个数”
                    else if (item.Name.ToLower().EndsWith("from"))
                    {
                        where.AppendFormat(" AND {0} >= {1}", item.Name.Replace("From", ""), item.GetValue(t, null));
                    }
                    else//等于
                    {
                        where.AppendFormat(" AND {0} = {1}", item.Name, item.GetValue(t, null));
                    }

                }
                //实数类型
                if (item.PropertyType == typeof(decimal?))
                {
                    //如果以“to结尾的是小于等于这个数”
                    if (item.Name.ToLower().EndsWith("to"))
                    {
                        where.AppendFormat(" AND {0} <= {1}", item.Name.Substring(0, item.Name.Length - 2), item.GetValue(t, null));
                    }
                    //如果以“from结尾的是大于于等于这个数”
                    else if (item.Name.ToLower().EndsWith("from"))
                    {
                        where.AppendFormat(" AND {0} >= {1}", item.Name.Substring(0, item.Name.Length - 4), item.GetValue(t, null));
                    }
                    else//等于
                    {
                        where.AppendFormat(" AND {0} = {1}", item.Name, item.GetValue(t, null));
                    }

                }
                //整数类型
                if (item.PropertyType == typeof(int?))
                {
                    //如果以“to结尾的是小于等于这个数”
                    if (item.Name.ToLower().EndsWith("to"))
                    {
                        where.AppendFormat(" AND {0} <= {1}", item.Name.Substring(0, item.Name.Length - 2), item.GetValue(t, null));
                    }
                    //如果以“from结尾的是大于于等于这个数”
                    else if (item.Name.ToLower().EndsWith("from"))
                    {
                        where.AppendFormat(" AND {0} >= {1}", item.Name.Replace("From", ""), item.GetValue(t, null));
                    }
                    else//等于
                    {
                        where.AppendFormat(" AND {0} = {1}", item.Name, item.GetValue(t, null));
                    }

                }
                //日期类型
                if (item.PropertyType == typeof(DateTime?))
                {
                    //如果以“to结尾的是晚于等于这个日期”
                    if (item.Name.ToLower().EndsWith("to"))
                    {
                        where.AppendFormat(" AND {0} <= '{1}'", item.Name.Substring(0, item.Name.Length - 2), ((DateTime?)item.GetValue(t, null)).Value.ToShortDateString());
                    }
                    //如果以“from结尾的是早于等于日期”
                    else if (item.Name.ToLower().EndsWith("from"))
                    {
                        where.AppendFormat(" AND {0} >= '{1}'", item.Name.Substring(0, item.Name.Length - 4), ((DateTime?)item.GetValue(t, null)).Value.ToShortDateString());
                    }
                    else//等于
                    {
                        where.AppendFormat(" AND {0} = '{1}'", item.Name, ((DateTime?)item.GetValue(t, null)).Value.ToShortDateString());
                    }

                }
                //逻辑类型
                if (item.PropertyType == typeof(bool?))
                {
                    where.AppendFormat(" AND {0} = {1}", item.Name, (((bool?)item.GetValue(t, null)).Value ? 1 : 0));
                }


            }
            if (usesorderby)
            {
                string orderby = string.Empty;
                if (sortproperty == null || string.IsNullOrEmpty(sortproperty.GetValue(t, null).ToString()))
                {
                    orderby = defaultorderby;
                }
                else
                {
                    orderby = sortproperty.GetValue(t, null).ToString();
                }
                where.AppendFormat(" ORDER BY {0}", orderby);
            }

            return where.ToString();
        }
        #endregion
        #region 根据数据行构造泛型实体
        /// <summary>
        /// 根据数据行构造泛型实体
        /// </summary>
        /// <typeparam name="T">返回的实体类型</typeparam>
        /// <param name="dr">数据行</param>
        /// <returns></returns>
        public static T CommonFill<T>(DataRow dr) where T : new()
        {
            //构造泛型实体
            T result = new T();
            //获得泛型类型
            Type t = typeof(T);
            //属性集合
            PropertyInfo[] properties = t.GetProperties();
            //属性赋值
            foreach (var item in properties)
            {
                if (!dr.Table.Columns.Contains(item.Name))
                {
                    continue;
                }

                //字符串
                if (item.PropertyType == typeof(string))
                {
                    item.SetValue(result, new ConvertHelper(dr[item.Name]).String, null);
                }
                //整数（不可空）
                if (item.PropertyType == typeof(int))
                {
                    item.SetValue(result, new ConvertHelper(dr[item.Name]).ToInt32 ?? 0, null);
                }
                //整数（可空）
                if (item.PropertyType == typeof(int?))
                {
                    item.SetValue(result, new ConvertHelper(dr[item.Name]).ToInt32, null);
                }
                //布尔（不可空）
                if (item.PropertyType == typeof(bool))
                {
                    item.SetValue(result, new ConvertHelper(dr[item.Name]).ToBool ?? false, null);
                }

                //布尔（可空）
                if (item.PropertyType == typeof(bool?))
                {
                    item.SetValue(result, new ConvertHelper(dr[item.Name]).ToBool, null);
                }

                //时间（不可空）
                if (item.PropertyType == typeof(DateTime))
                {
                    item.SetValue(result, new ConvertHelper(dr[item.Name]).ToDateTime.GetValueOrDefault(DateTime.Now), null);
                }

                //时间（可空）
                if (item.PropertyType == typeof(DateTime?))
                {
                    item.SetValue(result, new ConvertHelper(dr[item.Name]).ToDateTime, null);
                }

                //实数（不可空）
                if (item.PropertyType == typeof(double))
                {
                    item.SetValue(result, new ConvertHelper(dr[item.Name]).ToDouble.Value, null);
                }

                //实数（可空）
                if (item.PropertyType == typeof(double?))
                {
                    item.SetValue(result, new ConvertHelper(dr[item.Name]).ToDouble, null);
                }

                //十进制实数（不可空）
                if (item.PropertyType == typeof(decimal))
                {
                    item.SetValue(result, new ConvertHelper(dr[item.Name]).ToDecimal.Value, null);
                }

                //十进制实数（可空）
                if (item.PropertyType == typeof(decimal?))
                {
                    item.SetValue(result, new ConvertHelper(dr[item.Name]).ToDecimal, null);
                }

            }
            return result;
        }
        #endregion


        #region  获取泛型实体信息
        /// <summary>
        /// 获取泛型实体信息
        /// </summary>
        /// <typeparam name="T">泛型</typeparam>
        /// <param name="t">泛型实体</param>
        /// <returns></returns>
        public static string GetModelInfo<T>(T t)
        {
            Type type = typeof(T);
            StringBuilder str = new StringBuilder(512);
            str.Append(string.Format("{0}:{{ ", type.Name));
            bool first = true;
            foreach (var item in type.GetProperties())
            {
                if (first)
                {
                    str.AppendFormat(@"{0}:{1}", item.Name, item.GetValue(t, null) ?? "NULL");
                    first = false;
                }
                else
                    str.AppendFormat(@", {0}:{1}", item.Name, item.GetValue(t, null) ?? "NULL");
            }
            str.Append(" }\r\n");
            return str.ToString();

        }
        #endregion
    }

    /// <summary>
    /// 查询条件构造
    /// </summary>
    public class OracleSqlCondition
    {
        /// <summary>
        /// 查询条件字符串
        /// </summary>
        public string ConditionSqlStr;
        /// <summary>
        /// 查询绑定参数
        /// </summary>
        public List<OracleParameter> oracleParaList = new List<OracleParameter>();
    }

    /// <summary>
    /// 查询条件构造
    /// </summary>
    public class SqlCondition
    {
        /// <summary>
        /// 查询条件字符串
        /// </summary>
        public string ConditionSqlStr;
        /// <summary>
        /// 查询绑定参数
        /// </summary>
        public List<SqlParameter> sqlParaList = new List<SqlParameter>();
    }
}
