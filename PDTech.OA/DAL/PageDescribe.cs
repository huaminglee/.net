using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Maticsoft.DBUtility;

namespace PDTech.OA.DAL
{
    public class PageDescribe
    {
        /// <summary>
        /// 当前页索引
        /// </summary>
        public int CurrentPage { get; set; }
        /// <summary>
        /// 当前页显示条数
        /// </summary>
        public int PageSize { get; set; }
        /// <summary>
        /// 符合条件总条数
        /// </summary>
        public int RecordCount { get; set; }
        /// <summary>
        /// 表名称
        /// </summary>
        public string tableName { get; set; }
        /// <summary>
        /// 返回值
        /// </summary>
        public int TotalCount { get; set; }
        public DataTable PageDescribes(string safeSql)
        {
            try
            {
                int sIndex = PageSize * (CurrentPage - 1) + 1;
                int eIndex = PageSize * (CurrentPage);
                string sqlSum = string.Format(@"SELECT COUNT(1) FROM ({0}) T", safeSql);
                RecordCount = DbHelperSQL.GetScalar(sqlSum);
                string SQL = string.Format(@"SELECT * FROM 
                                        (SELECT ROW_NUMBER() OVER (ORDER BY a.temp_order_by) AS sort_rowno,* FROM
                                        (
                                           SELECT temp_order_by =0,B.* FROM ({0}) B
                                        ) A
                                    ) C
                                        WHERE sort_rowno between {1} AND {2}", safeSql, sIndex, eIndex);
                DataTable dt = DbHelperSQL.Query(SQL).Tables[0];
                return dt;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        /// <summary>
        /// 分页
        /// </summary>
        /// <param name="safeSql"></param>
        /// <param name="sortField">指定排序字段</param>
        /// <param name="sortType">排序类型</param>
        /// <returns></returns>
        public DataTable PageDescribes(string safeSql,string sortField, string sortType)
        {
            try
            {
                int sIndex = PageSize * (CurrentPage - 1) + 1;
                int eIndex = PageSize * (CurrentPage);
                string sqlSum = string.Format(@"SELECT COUNT(1) FROM ({0}) T", safeSql);
                RecordCount = DbHelperSQL.GetScalar(sqlSum);
                string SQL = string.Format(@"SELECT * FROM 
                                        (
                                        SELECT ROW_NUMBER() OVER (ORDER BY {0} {1}) AS sort_rowno,* FROM ({2}) B
                                        )A
                                        WHERE sort_rowno between {3} AND {4}", sortField, sortType, safeSql, sIndex, eIndex);
                DataTable dt = DbHelperSQL.Query(SQL).Tables[0];
                return dt;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}