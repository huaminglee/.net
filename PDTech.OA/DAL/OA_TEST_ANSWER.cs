/**  版本信息模板在安装目录下，可自行修改。
* OA_TEST_ANSWER.cs
*
* 功 能： N/A
* 类 名： OA_TEST_ANSWER
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2014/7/22 15:35:44   N/A    初版
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
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace PDTech.OA.DAL
{
    /// <summary>
    /// 数据访问类:OA_TEST_ANSWER
    /// </summary>
    public partial class OA_TEST_ANSWER
    {
        public OA_TEST_ANSWER()
        { }
        #region  BasicMethod

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string EDU_A_GUID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from OA_TEST_ANSWER");
            strSql.Append(" where EDU_A_GUID=@EDU_A_GUID ");
            SqlParameter[] parameters = {
					new SqlParameter("@EDU_A_GUID", SqlDbType.NVarChar)			};
            parameters[0].Value = EDU_A_GUID;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(PDTech.OA.Model.OA_TEST_ANSWER model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into OA_TEST_ANSWER(");
            strSql.Append("EDU_A_GUID,EDU_MAP_GUID,ANSWER_ID,SELECTEDOPTION,ANSWERTIME,SCORE)");
            strSql.Append(" values (");
            strSql.Append("@EDU_A_GUID,@EDU_MAP_GUID,@ANSWER_ID,@SELECTEDOPTION,@ANSWERTIME,@SCORE)");
            SqlParameter[] parameters = {
					new SqlParameter("@EDU_A_GUID", SqlDbType.NVarChar),
					new SqlParameter("@EDU_MAP_GUID", SqlDbType.NVarChar),
					new SqlParameter("@ANSWER_ID", SqlDbType.Decimal,4),
					new SqlParameter("@SELECTEDOPTION", SqlDbType.Char,1),
					new SqlParameter("@ANSWERTIME", SqlDbType.DateTime),
					new SqlParameter("@SCORE", SqlDbType.Decimal,4)};
            parameters[0].Value = model.EDU_A_GUID;
            parameters[1].Value = model.EDU_MAP_GUID;
            parameters[2].Value = model.ANSWER_ID;
            parameters[3].Value = model.SELECTEDOPTION;
            parameters[4].Value = model.ANSWERTIME;
            parameters[5].Value = model.SCORE;

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
        public bool Update(PDTech.OA.Model.OA_TEST_ANSWER model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update OA_TEST_ANSWER set ");
            strSql.Append("EDU_MAP_GUID=@EDU_MAP_GUID,");
            strSql.Append("ANSWER_ID=@ANSWER_ID,");
            strSql.Append("SELECTEDOPTION=@SELECTEDOPTION,");
            strSql.Append("ANSWERTIME=@ANSWERTIME,");
            strSql.Append("SCORE=@SCORE");
            strSql.Append(" where EDU_A_GUID=@EDU_A_GUID ");
            SqlParameter[] parameters = {
					new SqlParameter("@EDU_MAP_GUID", SqlDbType.NVarChar),
					new SqlParameter("@ANSWER_ID", SqlDbType.Decimal,4),
					new SqlParameter("@SELECTEDOPTION", SqlDbType.Char,1),
					new SqlParameter("@ANSWERTIME", SqlDbType.DateTime),
					new SqlParameter("@SCORE", SqlDbType.Decimal,4),
					new SqlParameter("@EDU_A_GUID", SqlDbType.NVarChar)};
            parameters[0].Value = model.EDU_MAP_GUID;
            parameters[1].Value = model.ANSWER_ID;
            parameters[2].Value = model.SELECTEDOPTION;
            parameters[3].Value = model.ANSWERTIME;
            parameters[4].Value = model.SCORE;
            parameters[5].Value = model.EDU_A_GUID;

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
        public bool Delete(string EDU_A_GUID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from OA_TEST_ANSWER ");
            strSql.Append(" where EDU_A_GUID=@EDU_A_GUID ");
            SqlParameter[] parameters = {
					new SqlParameter("@EDU_A_GUID", SqlDbType.NVarChar)			};
            parameters[0].Value = EDU_A_GUID;

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
        public bool DeleteList(string EDU_A_GUIDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from OA_TEST_ANSWER ");
            strSql.Append(" where EDU_A_GUID in (" + EDU_A_GUIDlist + ")  ");
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
        public PDTech.OA.Model.OA_TEST_ANSWER GetModel(string EDU_A_GUID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select EDU_A_GUID,EDU_MAP_GUID,ANSWER_ID,SELECTEDOPTION,ANSWERTIME,SCORE from OA_TEST_ANSWER ");
            strSql.Append(" where EDU_A_GUID=@EDU_A_GUID ");
            SqlParameter[] parameters = {
					new SqlParameter("@EDU_A_GUID", SqlDbType.NVarChar)			};
            parameters[0].Value = EDU_A_GUID;

            PDTech.OA.Model.OA_TEST_ANSWER model = new PDTech.OA.Model.OA_TEST_ANSWER();
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


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public PDTech.OA.Model.OA_TEST_ANSWER DataRowToModel(DataRow row)
        {
            PDTech.OA.Model.OA_TEST_ANSWER model = new PDTech.OA.Model.OA_TEST_ANSWER();
            if (row != null)
            {
                if (row["EDU_A_GUID"] != null)
                {
                    model.EDU_A_GUID = row["EDU_A_GUID"].ToString();
                }
                if (row["EDU_MAP_GUID"] != null)
                {
                    model.EDU_MAP_GUID = row["EDU_MAP_GUID"].ToString();
                }
                if (row["ANSWER_ID"] != null && row["ANSWER_ID"].ToString() != "")
                {
                    model.ANSWER_ID = decimal.Parse(row["ANSWER_ID"].ToString());
                }
                if (row["SELECTEDOPTION"] != null)
                {
                    model.SELECTEDOPTION = row["SELECTEDOPTION"].ToString();
                }
                if (row["ANSWERTIME"] != null && row["ANSWERTIME"].ToString() != "")
                {
                    model.ANSWERTIME = DateTime.Parse(row["ANSWERTIME"].ToString());
                }
                if (row["SCORE"] != null && row["SCORE"].ToString() != "")
                {
                    model.SCORE = decimal.Parse(row["SCORE"].ToString());
                }
            }
            return model;
        }

        public PDTech.OA.Model.OA_TEST_ANSWER DataRowToTotal(DataRow row)
        {
            PDTech.OA.Model.OA_TEST_ANSWER model = new PDTech.OA.Model.OA_TEST_ANSWER();
            if (row != null)
            {
                if (row["EDU_A_GUID"] != null)
                {
                    model.EDU_A_GUID = row["EDU_A_GUID"].ToString();
                }
                if (row["ANSWER_ID"] != null && row["ANSWER_ID"].ToString() != "")
                {
                    model.ANSWER_ID = decimal.Parse(row["ANSWER_ID"].ToString());
                }
                if (row["ANSWERTIME"] != null && row["ANSWERTIME"].ToString() != "")
                {
                    model.ANSWERTIME = DateTime.Parse(row["ANSWERTIME"].ToString());
                }
                if (row["SCORE"] != null && row["SCORE"].ToString() != "")
                {
                    model.SCORE = decimal.Parse(row["SCORE"].ToString());
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
            strSql.Append("select EDU_A_GUID,EDU_MAP_GUID,ANSWER_ID,SELECTEDOPTION,ANSWERTIME,SCORE ");
            strSql.Append(" FROM OA_TEST_ANSWER ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }

        public DataSet GetTotalList(string testId)
        {
            string sql = string.Format(@"select EDU_A_GUID,ANSWER_ID,ANSWERTIME,sum(SCORE) as SCORE from OA_TEST_ANSWER where EDU_MAP_GUID in 
                (select EDU_MAP_GUID from OA_QUESTION_TEST_MAP where EDU_T_GUID = '{0}')
                group by EDU_A_GUID,ANSWER_ID,ANSWERTIME order by ANSWERTIME ", testId);
            return DbHelperSQL.Query(sql);
        }

        /// <summary>
        /// 获取记录总数
        /// </summary>
        public int GetRecordCount(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) FROM OA_TEST_ANSWER ");
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

        public int GetIsAnswerCount(decimal? uid, string tid)
        {
            string sql = string.Format(@"select count(1) from OA_TEST_ANSWER where answer_id = {0} and EDU_MAP_GUID in 
                    (select EDU_MAP_GUID from OA_QUESTION_TEST_MAP where EDU_T_GUID = '{1}') ", uid, tid);
            object obj = DbHelperSQL.GetSingle(sql);
            if (obj == null)
            {
                return 0;
            }
            else
            {
                return Convert.ToInt32(obj);
            }
        }

        public string GetAnswerIdByTestId(decimal? uid, string tid)
        {
            string sql = string.Format(@"select distinct edu_a_guid from OA_TEST_ANSWER where answer_id = {0} and EDU_MAP_GUID in 
                    (select EDU_MAP_GUID from OA_QUESTION_TEST_MAP where EDU_T_GUID = '{1}')", uid, tid);
            DataSet ds = DbHelperSQL.Query(sql);
            if (ds.Tables[0].Rows.Count > 0)
            {
                return ds.Tables[0].Rows[0][0].ToString();
            }
            else
            {
                return "";
            }
        }

        public decimal GetTotalScore(decimal userId, string testId, string answerId)
        {
            string strSQL = string.Empty;
            strSQL = string.Format(@"select sum(SCORE) from OA_TEST_ANSWER where EDU_A_GUID = '{0}' 
                                    and ANSWER_ID = {1} and EDU_MAP_GUID in
                                    (select distinct EDU_MAP_GUID from OA_QUESTION_TEST_MAP 
                                    where EDU_T_GUID = '{2}')", answerId, userId, testId);

            object obj = DbHelperSQL.GetSingle(strSQL);
            if (obj == null)
            {
                return 0;
            }
            else
            {
                return Convert.ToDecimal(obj);
            }
        }

        public string GetSelectOption(decimal userId, string testId, string answerId, string questionId)
        {
            string strSQL = string.Empty;
            strSQL = string.Format(@"select SELECTEDOPTION from OA_TEST_ANSWER where EDU_A_GUID = '{0}' 
                                    and ANSWER_ID = {1} and EDU_MAP_GUID =
                                    (select EDU_MAP_GUID from OA_QUESTION_TEST_MAP 
                                    where EDU_T_GUID = '{2}'
                                    and EDU_Q_GUID = '{3}')", answerId, userId, testId, questionId);

            DataSet ds = DbHelperSQL.Query(strSQL);
            if (ds.Tables[0].Rows.Count > 0)
            {
                return ds.Tables[0].Rows[0][0].ToString();
            }
            else
            {
                return "";
            }
        }

        #endregion  BasicMethod
        #region  ExtensionMethod

        #endregion  ExtensionMethod
    }
}

