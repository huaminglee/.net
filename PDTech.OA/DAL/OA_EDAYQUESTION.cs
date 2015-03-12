/**  版本信息模板在安装目录下，可自行修改。
* OA_EDAYQUESTION.cs
*
* 功 能： N/A
* 类 名： OA_EDAYQUESTION
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2014/7/24 15:01:39   N/A    初版
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
using System.Data.SqlClient;
using Maticsoft.DBUtility;
using System.Collections.Generic;//Please add references
namespace PDTech.OA.DAL
{
	/// <summary>
	/// 数据访问类:OA_EDAYQUESTION
	/// </summary>
	public partial class OA_EDAYQUESTION
	{
		public OA_EDAYQUESTION()
		{}
		#region  BasicMethod

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(decimal EDAY_Q_ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from OA_EDAYQUESTION");
			strSql.Append(" where EDAY_Q_ID=@EDAY_Q_ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@EDAY_Q_ID", SqlDbType.Decimal,22)			};
			parameters[0].Value = EDAY_Q_ID;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(PDTech.OA.Model.OA_EDAYQUESTION model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into OA_EDAYQUESTION(");
			strSql.Append("EDU_Q_GUID,ANSWER_PERSON,ANSWER,ANSWER_TIME,SCORE,STATE)");
			strSql.Append(" values (");
			strSql.Append("@EDU_Q_GUID,@ANSWER_PERSON,@ANSWER,@ANSWER_TIME,@SCORE,@STATE)");
            SqlParameter[] parameters = {
					new SqlParameter("@EDU_Q_GUID", SqlDbType.NVarChar),
					new SqlParameter("@ANSWER_PERSON", SqlDbType.Decimal,4),
					new SqlParameter("@ANSWER", SqlDbType.Char,1),
					new SqlParameter("@ANSWER_TIME", SqlDbType.DateTime),
					new SqlParameter("@SCORE", SqlDbType.Decimal,4),
					new SqlParameter("@STATE", SqlDbType.Decimal,4)};
			//parameters[0].Value = model.EDAY_Q_ID;
			parameters[0].Value = model.EDU_Q_GUID;
			parameters[1].Value = model.ANSWER_PERSON;
			parameters[2].Value = model.ANSWER;
			parameters[3].Value = model.ANSWER_TIME;
			parameters[4].Value = model.SCORE;
			parameters[5].Value = model.STATE;

			int rows=DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
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
		public bool Update(PDTech.OA.Model.OA_EDAYQUESTION model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update OA_EDAYQUESTION set ");
			strSql.Append("EDU_Q_GUID=@EDU_Q_GUID,");
			strSql.Append("ANSWER_PERSON=@ANSWER_PERSON,");
			strSql.Append("ANSWER=@ANSWER,");
			strSql.Append("ANSWER_TIME=@ANSWER_TIME,");
			strSql.Append("SCORE=@SCORE,");
			strSql.Append("STATE=@STATE");
			strSql.Append(" where EDAY_Q_ID=@EDAY_Q_ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@EDU_Q_GUID", SqlDbType.NVarChar),
					new SqlParameter("@ANSWER_PERSON", SqlDbType.Decimal,4),
					new SqlParameter("@ANSWER", SqlDbType.Char,1),
					new SqlParameter("@ANSWER_TIME", SqlDbType.DateTime),
					new SqlParameter("@SCORE", SqlDbType.Decimal,4),
					new SqlParameter("@STATE", SqlDbType.Decimal,4),
					new SqlParameter("@EDAY_Q_ID", SqlDbType.Decimal,4)};
			parameters[0].Value = model.EDU_Q_GUID;
			parameters[1].Value = model.ANSWER_PERSON;
			parameters[2].Value = model.ANSWER;
			parameters[3].Value = model.ANSWER_TIME;
			parameters[4].Value = model.SCORE;
			parameters[5].Value = model.STATE;
			parameters[6].Value = model.EDAY_Q_ID;

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
		public bool Delete(decimal EDAY_Q_ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from OA_EDAYQUESTION ");
			strSql.Append(" where EDAY_Q_ID=@EDAY_Q_ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@EDAY_Q_ID", SqlDbType.Decimal,22)			};
			parameters[0].Value = EDAY_Q_ID;

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
		public bool DeleteList(string EDAY_Q_IDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from OA_EDAYQUESTION ");
			strSql.Append(" where EDAY_Q_ID in ("+EDAY_Q_IDlist + ")  ");
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
		public PDTech.OA.Model.OA_EDAYQUESTION GetModel(decimal EDAY_Q_ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select EDAY_Q_ID,EDU_Q_GUID,ANSWER_PERSON,ANSWER,ANSWER_TIME,SCORE,STATE from OA_EDAYQUESTION ");
			strSql.Append(" where EDAY_Q_ID=@EDAY_Q_ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@EDAY_Q_ID", SqlDbType.Decimal,22)			};
			parameters[0].Value = EDAY_Q_ID;

			PDTech.OA.Model.OA_EDAYQUESTION model=new PDTech.OA.Model.OA_EDAYQUESTION();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				return DataRowToModel(ds.Tables[0].Rows[0]);
			}
			else
			{
				return null;
			}
		}

        public PDTech.OA.Model.OA_EDAYQUESTION DataRowToSingle(DataRow row)
        {
            PDTech.OA.Model.OA_EDAYQUESTION model = new PDTech.OA.Model.OA_EDAYQUESTION();
            if (row != null)
            {
                if (row["ANSWER_PERSON"] != null && row["ANSWER_PERSON"].ToString() != "")
                {
                    model.ANSWER_PERSON = decimal.Parse(row["ANSWER_PERSON"].ToString());
                }
            }
            return model;
        }

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public PDTech.OA.Model.OA_EDAYQUESTION DataRowToModel(DataRow row)
		{
			PDTech.OA.Model.OA_EDAYQUESTION model=new PDTech.OA.Model.OA_EDAYQUESTION();
			if (row != null)
			{
				if(row["EDAY_Q_ID"]!=null && row["EDAY_Q_ID"].ToString()!="")
				{
					model.EDAY_Q_ID=decimal.Parse(row["EDAY_Q_ID"].ToString());
				}
				if(row["EDU_Q_GUID"]!=null)
				{
					model.EDU_Q_GUID=row["EDU_Q_GUID"].ToString();
				}
				if(row["ANSWER_PERSON"]!=null && row["ANSWER_PERSON"].ToString()!="")
				{
					model.ANSWER_PERSON=decimal.Parse(row["ANSWER_PERSON"].ToString());
				}
				if(row["ANSWER"]!=null)
				{
					model.ANSWER=row["ANSWER"].ToString();
				}
				if(row["ANSWER_TIME"]!=null && row["ANSWER_TIME"].ToString()!="")
				{
					model.ANSWER_TIME=DateTime.Parse(row["ANSWER_TIME"].ToString());
				}
				if(row["SCORE"]!=null && row["SCORE"].ToString()!="")
				{
					model.SCORE=decimal.Parse(row["SCORE"].ToString());
				}
				if(row["STATE"]!=null && row["STATE"].ToString()!="")
				{
					model.STATE=decimal.Parse(row["STATE"].ToString());
				}
			}
			return model;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select EDAY_Q_ID,EDU_Q_GUID,ANSWER_PERSON,ANSWER,ANSWER_TIME,SCORE,STATE ");
			strSql.Append(" FROM OA_EDAYQUESTION ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			return DbHelperSQL.Query(strSql.ToString());
		}
        public DataTable GetTongji(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  COUNT(*) AS Anscount,sum([STATE]) as StateCount ");
            strSql.Append(" FROM OA_EDAYQUESTION ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
                strSql.Append(" GROUP BY ANSWER_PERSON");
               
            }
            return DbHelperSQL.Query(strSql.ToString()).Tables[0];
        }

        public DataSet GetUidList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ANSWER_PERSON ");
            strSql.Append(" FROM OA_EDAYQUESTION where 1=1 ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(strWhere);
            }
            strSql.Append(" group by ANSWER_PERSON ");
            return DbHelperSQL.Query(strSql.ToString());
        }

		/// <summary>
		/// 获取记录总数
		/// </summary>
		public int GetRecordCount(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) FROM OA_EDAYQUESTION ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
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
        /// 当天是否已经存在答题记录
        /// </summary>
        /// <returns></returns>
        public int IsHasRecord(decimal userId)
        {
            StringBuilder strSql = new StringBuilder();
            //strSql.Append("select count(1) FROM OA_EDAYQUESTION where ANSWER_PERSON = " + userId.ToString() + " and STATE = 1 and to_char(ANSWER_TIME,'yyyy-MM-dd') = to_char(sysdate,'yyyy-MM-dd')");
            strSql.Append("select count(1) FROM OA_EDAYQUESTION where ANSWER_PERSON = " + userId.ToString() + " and convert(varchar(10),ANSWER_TIME,110) = convert(varchar(10),GETDATE(),110)");
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
        public IList<Model.OA_EDAYQUESTION> Get_Paging_List(decimal userId, string title, int PageSize, int PageIndex, out int totalrecord)
        {
            //string condition = DAL_Helper.GetWhereCondition(where);
            string strSQL = string.Empty;
            if ((int)userId > 0)
            {
                if (!string.IsNullOrEmpty(title))
                {
                    strSQL = string.Format("SELECT  TOP (100) PERCENT * from OA_EDAYQUESTION WHERE ANSWER_PERSON = {0} AND EDU_Q_GUID in (select EDU_Q_GUID from OA_EDUQUESTION where TITLE like '%{1}%') order by EDAY_Q_ID ", userId, title);
                }
                else
                {
                    strSQL = string.Format("SELECT  TOP (100) PERCENT * from OA_EDAYQUESTION WHERE ANSWER_PERSON = {0} order by EDAY_Q_ID ", userId);
                }
            }
            else
            {
                if (!string.IsNullOrEmpty(title))
                {
                    strSQL = string.Format("SELECT  TOP (100) PERCENT * from OA_EDAYQUESTION WHERE EDU_Q_GUID in (select EDU_Q_GUID from OA_EDUQUESTION where TITLE like '%{0}%') order by EDAY_Q_ID ", title);
                }
                else
                {
                    strSQL = string.Format("SELECT  TOP (100) PERCENT * from OA_EDAYQUESTION order by EDAY_Q_ID ");
                }
            }
            PageDescribe pdes = new PageDescribe();
            pdes.CurrentPage = PageIndex;
            pdes.PageSize = PageSize;
            DataTable dt = pdes.PageDescribes(strSQL, "EDAY_Q_ID","DESC");
            totalrecord = pdes.RecordCount;
            return DAL_Helper.CommonFillList<Model.OA_EDAYQUESTION>(dt);
        }

        public IList<Model.OA_EDAYQUESTION> Get_Paging_List(string title, decimal departmentId, decimal userId, string sDate, string eDate, decimal state, int PageSize, int PageIndex, out int totalrecord)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT  TOP (100) PERCENT * from OA_EDAYQUESTION WHERE 1=1 ");
            if (!string.IsNullOrEmpty(title))
            {
                strSql.Append(" and EDU_Q_GUID in (select EDU_Q_GUID from OA_EDUQUESTION where TITLE like '%" + title + "%') ");
            }
            if ((int)departmentId > 0)
            {
                strSql.Append(" and ANSWER_PERSON in (select USER_ID from USER_INFO where DEPARTMENT_ID = " + departmentId + ") ");
            }
            if ((int)userId > 0)
            {
                strSql.Append(" and ANSWER_PERSON = " + userId);
            }
            if (!string.IsNullOrEmpty(sDate))
            {
                strSql.Append(" and ANSWER_TIME >= convert(varchar(20),'" + sDate + " 00:00:01',120) ");
            }
            if (!string.IsNullOrEmpty(sDate))
            {
                strSql.Append(" and ANSWER_TIME <= convert(varchar(20),'" + eDate + " 23:59:59',120) ");
            }
            if ((int)state > 0)
            {
                strSql.Append(" and STATE = " + state);
            }
            strSql.Append(" order by EDAY_Q_ID ");

            PageDescribe pdes = new PageDescribe();
            pdes.CurrentPage = PageIndex;
            pdes.PageSize = PageSize;
            DataTable dt = pdes.PageDescribes(strSql.ToString(), "EDAY_Q_ID","DESC");
            totalrecord = pdes.RecordCount;
            return DAL_Helper.CommonFillList<Model.OA_EDAYQUESTION>(dt);
        }


		#endregion  BasicMethod
		#region  ExtensionMethod

		#endregion  ExtensionMethod
	}
}

