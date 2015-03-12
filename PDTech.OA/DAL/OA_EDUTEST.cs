/**  版本信息模板在安装目录下，可自行修改。
* OA_EDUTEST.cs
*
* 功 能： N/A
* 类 名： OA_EDUTEST
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2014/7/22 15:35:27   N/A    初版
*
* Copyright (c) 2012 Maticsoft Corporation. All rights reserved.
*┌──────────────────────────────────┐
*│　此技术信息为本公司机密信息，未经本公司书面同意禁止向第三方披露．　│
*│　版权所有：动软卓越（北京）科技有限公司　　　　　　　　　　　　　　│
*└──────────────────────────────────┘
*/
using System;
using System.Data;
using System.Text;
using System.Data.OracleClient;
using Maticsoft.DBUtility;
using System.Collections.Generic;
using System.Data.SqlClient;//Please add references
namespace PDTech.OA.DAL
{
    /// <summary>
    /// 数据访问类:OA_EDUTEST
    /// </summary>
    public partial class OA_EDUTEST
    {
        public OA_EDUTEST()
        { }
        #region  BasicMethod

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string EDU_T_GUID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from OA_EDUTEST");
            strSql.Append(" where EDU_T_GUID=@EDU_T_GUID ");
            SqlParameter[] parameters = {
					new SqlParameter("@EDU_T_GUID", SqlDbType.NVarChar)			};
            parameters[0].Value = EDU_T_GUID;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(PDTech.OA.Model.OA_EDUTEST model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into OA_EDUTEST(");
            strSql.Append("EDU_T_GUID,TESTNAME,CREATOR,CREATETIME,TESTCOUNT,SCORE,HOPEFINISHTIME,FINISHTIME)");
            strSql.Append(" values (");
            strSql.Append("@EDU_T_GUID,@TESTNAME,@CREATOR,@CREATETIME,@TESTCOUNT,@SCORE,@HOPEFINISHTIME,@FINISHTIME)");
            SqlParameter[] parameters = {
					new SqlParameter("@EDU_T_GUID", SqlDbType.NVarChar),
					new SqlParameter("@TESTNAME", SqlDbType.NVarChar),
					new SqlParameter("@CREATOR", SqlDbType.Decimal,4),
					new SqlParameter("@CREATETIME", SqlDbType.DateTime),
                    new SqlParameter("@TESTCOUNT", SqlDbType.Decimal,4),
                    new SqlParameter("@SCORE", SqlDbType.Decimal,4),
                    new SqlParameter("@HOPEFINISHTIME", SqlDbType.DateTime),
                    new SqlParameter("@FINISHTIME", SqlDbType.DateTime)};
            parameters[0].Value = model.EDU_T_GUID;
            parameters[1].Value = model.TESTNAME;
            parameters[2].Value = model.CREATOR;
            parameters[3].Value = model.CREATETIME;
            parameters[4].Value = model.TESTCOUNT;
            parameters[5].Value = model.SCORE;
            parameters[6].Value = model.HOPEFINISHTIME;
            parameters[7].Value = model.FINISHTIME;

            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(PDTech.OA.Model.OA_EDUTEST model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update OA_EDUTEST set ");
            strSql.Append("TESTNAME=@TESTNAME,");
            strSql.Append("CREATOR=@CREATOR,");
            strSql.Append("CREATETIME=@CREATETIME, ");
            strSql.Append("TESTCOUNT=@TESTCOUNT, ");
            strSql.Append("SCORE=@SCORE, ");
            strSql.Append("HOPEFINISHTIME=@HOPEFINISHTIME, ");
            strSql.Append("FINISHTIME=@FINISHTIME ");
            strSql.Append(" where EDU_T_GUID=@EDU_T_GUID ");
            SqlParameter[] parameters = {
					new SqlParameter("@TESTNAME", SqlDbType.NVarChar),
					new SqlParameter("@CREATOR", SqlDbType.Decimal,4),
					new SqlParameter("@CREATETIME", SqlDbType.DateTime),
                    new SqlParameter("@TESTCOUNT", SqlDbType.Decimal,4),
                    new SqlParameter("@SCORE", SqlDbType.Decimal,4),
					new SqlParameter("@EDU_T_GUID", SqlDbType.NVarChar),
                    new SqlParameter("@HOPEFINISHTIME", SqlDbType.DateTime),
                    new SqlParameter("@FINISHTIME", SqlDbType.DateTime)};
            parameters[0].Value = model.TESTNAME;
            parameters[1].Value = model.CREATOR;
            parameters[2].Value = model.CREATETIME;
            parameters[3].Value = model.TESTCOUNT;
            parameters[4].Value = model.SCORE;
            parameters[5].Value = model.EDU_T_GUID;
            parameters[6].Value = model.HOPEFINISHTIME;
            parameters[7].Value = model.FINISHTIME;

            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(string EDU_T_GUID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from OA_EDUTEST ");
            strSql.Append(" where EDU_T_GUID=@EDU_T_GUID ");
            SqlParameter[] parameters = {
					new SqlParameter("@EDU_T_GUID", SqlDbType.NVarChar)			};
            parameters[0].Value = EDU_T_GUID;

            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 批量删除数据
        /// </summary>
        public bool DeleteList(string EDU_T_GUIDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from OA_EDUTEST ");
            strSql.Append(" where EDU_T_GUID in (" + EDU_T_GUIDlist + ")  ");
            int rows = DbHelperSQL.ExecuteSql(strSql.ToString());
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public PDTech.OA.Model.OA_EDUTEST GetModel(string EDU_T_GUID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select EDU_T_GUID,TESTNAME,CREATOR,CREATETIME,TESTCOUNT,SCORE,HOPEFINISHTIME,FINISHTIME from OA_EDUTEST ");
            strSql.Append(" where EDU_T_GUID=@EDU_T_GUID ");
            SqlParameter[] parameters = {
					new SqlParameter("@EDU_T_GUID", SqlDbType.NVarChar)			};
            parameters[0].Value = EDU_T_GUID;

            PDTech.OA.Model.OA_EDUTEST model = new PDTech.OA.Model.OA_EDUTEST();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                return DataRowToModel(ds.Tables[0].Rows[0]);
            }
            else
            {
                return null;
            }
        }
        public IList<Model.OA_EXPIRE_ONLINETEST> Get_exprePaging_List(string strWhere, string currentPage, string pageSize, out int totalNum)
        {
            string strSQL = string.Format(@"select TOP (100) PERCENT ROW_NUMBER() OVER (ORDER BY C.CREATETIME desc) AS rowno,TESTNAME,
            TESTCOUNT,SCORE,CREATOR,CREATETIME,HOPEFINISHTIME
           from OA_EDUTEST c where  c.EDU_T_GUID  in  
           (select distinct EDU_T_GUID from OA_QUESTION_TEST_MAP d where d.EDU_MAP_GUID not in 
           (select EDU_MAP_GUID from OA_TEST_ANSWER e  where {0} )) and c.HOPEFINISHTIME<GETDATE() ", strWhere);
            PageDescribe pdes = new PageDescribe();
            pdes.CurrentPage = int.Parse(currentPage);
            pdes.PageSize = int.Parse(pageSize);
            DataTable dt = pdes.PageDescribes(strSQL, "rowno", "DESC");
            totalNum = pdes.RecordCount;
            if (dt.Rows.Count > 0)
            {
                return DAL_Helper.CommonFillList<Model.OA_EXPIRE_ONLINETEST>(dt);
            }
            else
            {
                return null;
            }


        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public PDTech.OA.Model.OA_EDUTEST DataRowToModel(DataRow row)
        {
            PDTech.OA.Model.OA_EDUTEST model = new PDTech.OA.Model.OA_EDUTEST();
            if (row != null)
            {
                if (row["EDU_T_GUID"] != null)
                {
                    model.EDU_T_GUID = row["EDU_T_GUID"].ToString();
                }
                if (row["TESTNAME"] != null)
                {
                    model.TESTNAME = row["TESTNAME"].ToString();
                }
                if (row["CREATOR"] != null && row["CREATOR"].ToString() != "")
                {
                    model.CREATOR = decimal.Parse(row["CREATOR"].ToString());
                }
                if (row["CREATETIME"] != null && row["CREATETIME"].ToString() != "")
                {
                    model.CREATETIME = DateTime.Parse(row["CREATETIME"].ToString());
                }
                if (row["TESTCOUNT"] != null && row["TESTCOUNT"].ToString() != "")
                {
                    model.TESTCOUNT = decimal.Parse(row["TESTCOUNT"].ToString());
                }
                if (row["SCORE"] != null && row["SCORE"].ToString() != "")
                {
                    model.SCORE = decimal.Parse(row["SCORE"].ToString());
                }
                if (row["HOPEFINISHTIME"] != null)
                {
                    model.HOPEFINISHTIME = DateTime.Parse(row["HOPEFINISHTIME"].ToString());
                }
                if (row["FINISHTIME"] != null)
                {
                    model.FINISHTIME = DateTime.Parse(row["FINISHTIME"].ToString());
                }
            }
            return model;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select EDU_T_GUID,TESTNAME,CREATOR,CREATETIME,TESTCOUNT,SCORE,HOPEFINISHTIME,FINISHTIME ");
            strSql.Append(" FROM OA_EDUTEST ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获取记录总数
        /// </summary>
        public int GetRecordCount(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) FROM OA_EDUTEST ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            object obj = DbHelperSQL.GetSingle(strSql.ToString());
            if (obj == null)
            {
                return 0;
            }
            else
            {
                return Convert.ToInt32(obj);
            }
        }

        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public IList<Model.OA_EDUTEST> Get_Paging_List(string title, int PageSize, int PageIndex, out int totalrecord, string isshowexpire="")
        {
            //string condition = DAL_Helper.GetWhereCondition(where);
            string strSQL = string.Empty;
            
            if (isshowexpire!="")
            {
                strSQL = string.Format(@"select  TOP (100) PERCENT * from OA_EDUTEST c where  c.EDU_T_GUID  in  
           (select distinct EDU_T_GUID from OA_QUESTION_TEST_MAP d where d.EDU_MAP_GUID not in 
           (select EDU_MAP_GUID from OA_TEST_ANSWER e  where e.ANSWER_ID={0} )) and c.HOPEFINISHTIME<GETDATE() ", isshowexpire);
            }
            else
            {
                if (!string.IsNullOrEmpty(title))
                {
                    strSQL = string.Format("SELECT  TOP (100) PERCENT * from OA_EDUTEST WHERE TESTNAME like '%{0}%' order by CREATETIME ", title);
                }
                else
                {
                    strSQL = string.Format("SELECT  TOP (100) PERCENT * from OA_EDUTEST order by CREATETIME ", title);
                }
            }
            PageDescribe pdes = new PageDescribe();
            pdes.CurrentPage = PageIndex;
            pdes.PageSize = PageSize;
            DataTable dt = pdes.PageDescribes(strSQL);
            totalrecord = pdes.RecordCount;
            return DAL_Helper.CommonFillList<Model.OA_EDUTEST>(dt);
        }

        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public IList<Model.OA_EDUTEST> Get_Paging_TestList(decimal userId, string title, int PageSize, int PageIndex, out int totalrecord)
        {
            //string condition = DAL_Helper.GetWhereCondition(where);
            string strSQL = string.Empty;
            if (!string.IsNullOrEmpty(title))
            {
                strSQL = string.Format(@"SELECT  TOP (100) PERCENT * from OA_EDUTEST WHERE TESTNAME like '%{0}%'
                                        and EDU_T_GUID in (select EDU_T_GUID from OA_QUESTION_TEST_MAP 
                                        where EDU_MAP_GUID in (select EDU_MAP_GUID from OA_TEST_ANSWER where ANSWER_ID = {1})) 
                                        order by CREATETIME ", title, userId);
            }
            else
            {
                strSQL = string.Format(@"SELECT  TOP (100) PERCENT * from OA_EDUTEST where EDU_T_GUID in (select EDU_T_GUID from OA_QUESTION_TEST_MAP 
                                        where EDU_MAP_GUID in (select EDU_MAP_GUID from OA_TEST_ANSWER where ANSWER_ID = {0}))
                                        order by CREATETIME ", userId);
            }
            PageDescribe pdes = new PageDescribe();
            pdes.CurrentPage = PageIndex;
            pdes.PageSize = PageSize;
            DataTable dt = pdes.PageDescribes(strSQL);
            totalrecord = pdes.RecordCount;
            return DAL_Helper.CommonFillList<Model.OA_EDUTEST>(dt);
        }


        #endregion  BasicMethod
        #region  ExtensionMethod

        #endregion  ExtensionMethod
    }
}

