/**  版本信息模板在安装目录下，可自行修改。
* OA_EDUQUESTION.cs
*
* 功 能： N/A
* 类 名： OA_EDUQUESTION
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2014/7/22 15:35:35   N/A    初版
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
	/// 数据访问类:OA_EDUQUESTION
	/// </summary>
	public partial class OA_EDUQUESTION
	{
		public OA_EDUQUESTION()
		{}
		#region  BasicMethod

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string EDU_Q_GUID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from OA_EDUQUESTION");
			strSql.Append(" where EDU_Q_GUID=@EDU_Q_GUID ");
            SqlParameter[] parameters = {
					new SqlParameter("@EDU_Q_GUID", SqlDbType.NVarChar)			};
			parameters[0].Value = EDU_Q_GUID;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(PDTech.OA.Model.OA_EDUQUESTION model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into OA_EDUQUESTION(");
			strSql.Append("EDU_Q_GUID,TITLE,ANSWER,OPTIONA,OPTIONB,OPTIONC,OPTIOND,CREATETIME,SCORE,WEIGHT)");
			strSql.Append(" values (");
            strSql.Append("@EDU_Q_GUID,@TITLE,@ANSWER,@OPTIONA,@OPTIONB,@OPTIONC,@OPTIOND,@CREATETIME,@SCORE,@WEIGHT)");
            SqlParameter[] parameters = {
					new SqlParameter("@EDU_Q_GUID", SqlDbType.NVarChar),
					new SqlParameter("@TITLE", SqlDbType.NVarChar),
					new SqlParameter("@ANSWER", SqlDbType.Char,1),
					new SqlParameter("@OPTIONA", SqlDbType.NVarChar),
					new SqlParameter("@OPTIONB", SqlDbType.NVarChar),
					new SqlParameter("@OPTIONC", SqlDbType.NVarChar),
					new SqlParameter("@OPTIOND", SqlDbType.NVarChar),
					new SqlParameter("@CREATETIME", SqlDbType.DateTime),
					new SqlParameter("@SCORE", SqlDbType.Decimal,4),
					new SqlParameter("@WEIGHT", SqlDbType.Decimal,4)};
			parameters[0].Value = model.EDU_Q_GUID;
			parameters[1].Value = model.TITLE;
			parameters[2].Value = model.ANSWER;
			parameters[3].Value = model.OPTIONA;
			parameters[4].Value = model.OPTIONB;
			parameters[5].Value = model.OPTIONC;
			parameters[6].Value = model.OPTIOND;
			parameters[7].Value = model.CREATETIME;
			parameters[8].Value = model.SCORE;
			parameters[9].Value = model.WEIGHT;

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
        /// 批量添加
        /// </summary>
        /// <param name="list"></param>
        public void BatchAdd(List<PDTech.OA.Model.OA_EDUQUESTION> list)
        {
            IList<sqlTrasExcuteComm> commandList = null;
            if(list != null && list.Count > 0)
            {
                commandList = new List<sqlTrasExcuteComm>();
                foreach (PDTech.OA.Model.OA_EDUQUESTION model in list)
                {
                    StringBuilder strSql=new StringBuilder();
			        strSql.Append("insert into OA_EDUQUESTION(");
			        strSql.Append("EDU_Q_GUID,TITLE,ANSWER,OPTIONA,OPTIONB,OPTIONC,OPTIOND,CREATETIME,SCORE,WEIGHT)");
			        strSql.Append(" values (");
                    strSql.Append("@EDU_Q_GUID,@TITLE,@ANSWER,@OPTIONA,@OPTIONB,@OPTIONC,@OPTIOND,@CREATETIME,@SCORE,@WEIGHT)");
                    SqlParameter[] parameters = {
					        new SqlParameter("@EDU_Q_GUID", SqlDbType.NVarChar),
					        new SqlParameter("@TITLE", SqlDbType.NVarChar),
					        new SqlParameter("@ANSWER", SqlDbType.Char,1),
					        new SqlParameter("@OPTIONA", SqlDbType.NVarChar),
					        new SqlParameter("@OPTIONB", SqlDbType.NVarChar),
					        new SqlParameter("@OPTIONC", SqlDbType.NVarChar),
					        new SqlParameter("@OPTIOND", SqlDbType.NVarChar),
					        new SqlParameter("@CREATETIME", SqlDbType.DateTime),
					        new SqlParameter("@SCORE", SqlDbType.Decimal,4),
					        new SqlParameter("@WEIGHT", SqlDbType.Decimal,4)};
			        parameters[0].Value = model.EDU_Q_GUID;
			        parameters[1].Value = model.TITLE;
			        parameters[2].Value = model.ANSWER;
			        parameters[3].Value = model.OPTIONA;
			        parameters[4].Value = model.OPTIONB;
			        parameters[5].Value = model.OPTIONC;
			        parameters[6].Value = model.OPTIOND;
			        parameters[7].Value = model.CREATETIME;
			        parameters[8].Value = model.SCORE;
			        parameters[9].Value = model.WEIGHT;

                    sqlTrasExcuteComm trasComm = new sqlTrasExcuteComm();
                    trasComm.commandText = strSql.ToString();
                    trasComm.type = CommandType.Text;
                    trasComm.parameters = parameters;
                    commandList.Add(trasComm);
                }
                DbHelperSQL.ExecuteSqlTran(commandList);
            }
        }

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(PDTech.OA.Model.OA_EDUQUESTION model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update OA_EDUQUESTION set ");
			strSql.Append("TITLE=@TITLE,");
			strSql.Append("ANSWER=@ANSWER,");
			strSql.Append("OPTIONA=@OPTIONA,");
			strSql.Append("OPTIONB=@OPTIONB,");
			strSql.Append("OPTIONC=@OPTIONC,");
			strSql.Append("OPTIOND=@OPTIOND,");
			//strSql.Append("CREATETIME=:CREATETIME,");
			strSql.Append("SCORE=@SCORE,");
			strSql.Append("WEIGHT=@WEIGHT");
			strSql.Append(" where EDU_Q_GUID=@EDU_Q_GUID ");
            SqlParameter[] parameters = {
					new SqlParameter("@TITLE", SqlDbType.NVarChar),
					new SqlParameter("@ANSWER", SqlDbType.Char,1),
					new SqlParameter("@OPTIONA", SqlDbType.NVarChar),
					new SqlParameter("@OPTIONB", SqlDbType.NVarChar),
					new SqlParameter("@OPTIONC", SqlDbType.NVarChar),
					new SqlParameter("@OPTIOND", SqlDbType.NVarChar),
					new SqlParameter("@SCORE", SqlDbType.Decimal,4),
					new SqlParameter("@WEIGHT", SqlDbType.Decimal,4),
					new SqlParameter("@EDU_Q_GUID", SqlDbType.NVarChar)};
			parameters[0].Value = model.TITLE;
			parameters[1].Value = model.ANSWER;
			parameters[2].Value = model.OPTIONA;
			parameters[3].Value = model.OPTIONB;
			parameters[4].Value = model.OPTIONC;
			parameters[5].Value = model.OPTIOND;
			//parameters[6].Value = model.CREATETIME;
			parameters[6].Value = model.SCORE;
			parameters[7].Value = model.WEIGHT;
			parameters[8].Value = model.EDU_Q_GUID;

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
		public bool Delete(string EDU_Q_GUID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from OA_EDUQUESTION ");
			strSql.Append(" where EDU_Q_GUID=@EDU_Q_GUID ");
            SqlParameter[] parameters = {
					new SqlParameter("@EDU_Q_GUID", SqlDbType.NVarChar)			};
			parameters[0].Value = EDU_Q_GUID;

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
		public bool DeleteList(string EDU_Q_GUIDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from OA_EDUQUESTION ");
			strSql.Append(" where EDU_Q_GUID in ("+EDU_Q_GUIDlist + ")  ");
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
		public PDTech.OA.Model.OA_EDUQUESTION GetModel(string EDU_Q_GUID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select EDU_Q_GUID,TITLE,ANSWER,OPTIONA,OPTIONB,OPTIONC,OPTIOND,CREATETIME,SCORE,WEIGHT from OA_EDUQUESTION ");
			strSql.Append(" where EDU_Q_GUID=@EDU_Q_GUID ");
            SqlParameter[] parameters = {
					new SqlParameter("@EDU_Q_GUID", SqlDbType.NVarChar)			};
			parameters[0].Value = EDU_Q_GUID;

			PDTech.OA.Model.OA_EDUQUESTION model=new PDTech.OA.Model.OA_EDUQUESTION();
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


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public PDTech.OA.Model.OA_EDUQUESTION DataRowToModel(DataRow row)
		{
			PDTech.OA.Model.OA_EDUQUESTION model=new PDTech.OA.Model.OA_EDUQUESTION();
			if (row != null)
			{
				if(row["EDU_Q_GUID"]!=null)
				{
					model.EDU_Q_GUID=row["EDU_Q_GUID"].ToString();
				}
				if(row["TITLE"]!=null)
				{
					model.TITLE=row["TITLE"].ToString();
				}
				if(row["ANSWER"]!=null)
				{
					model.ANSWER=row["ANSWER"].ToString();
				}
				if(row["OPTIONA"]!=null)
				{
					model.OPTIONA=row["OPTIONA"].ToString();
				}
				if(row["OPTIONB"]!=null)
				{
					model.OPTIONB=row["OPTIONB"].ToString();
				}
				if(row["OPTIONC"]!=null)
				{
					model.OPTIONC=row["OPTIONC"].ToString();
				}
				if(row["OPTIOND"]!=null)
				{
					model.OPTIOND=row["OPTIOND"].ToString();
				}
				if(row["CREATETIME"]!=null && row["CREATETIME"].ToString()!="")
				{
					model.CREATETIME=DateTime.Parse(row["CREATETIME"].ToString());
				}
				if(row["SCORE"]!=null && row["SCORE"].ToString()!="")
				{
					model.SCORE=decimal.Parse(row["SCORE"].ToString());
				}
				if(row["WEIGHT"]!=null && row["WEIGHT"].ToString()!="")
				{
					model.WEIGHT=decimal.Parse(row["WEIGHT"].ToString());
				}
			}
			return model;
		}

        /// <summary>
        /// 随机获取一道试题
        /// </summary>
        /// <returns></returns>
        public DataTable GetRoundObj()
        {
            string sql = "select * from (select ROW_NUMBER() OVER (ORDER BY EDU_Q_GUID) AS sort_rowno, * from (select * from OA_EDUQUESTION) as a) as b where b.sort_rowno=(select cast(ceiling(rand() * (select COUNT(1) from OA_EDUQUESTION oe)) as int))";
            return DbHelperSQL.GetTable(sql);
        }

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select EDU_Q_GUID,TITLE,ANSWER,OPTIONA,OPTIONB,OPTIONC,OPTIOND,CREATETIME,SCORE,WEIGHT ");
			strSql.Append(" FROM OA_EDUQUESTION ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			return DbHelperSQL.Query(strSql.ToString());
		}

        public DataSet GetTestList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(@"select a.*,b.MAP_INDEX from OA_EDUQUESTION a left join OA_QUESTION_TEST_MAP b
                    on a.EDU_Q_GUID = b.EDU_Q_GUID left join OA_EDUTEST c on b.EDU_T_GUID = c.EDU_T_GUID ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by b.MAP_INDEX ");
            return DbHelperSQL.Query(strSql.ToString());
        }

		/// <summary>
		/// 获取记录总数
		/// </summary>
		public int GetRecordCount(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) FROM OA_EDUQUESTION ");
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
        /// 分页获取数据列表
        /// </summary>
        public IList<Model.OA_EDUQUESTION> Get_Paging_List_ByCondition(string strwhere, int PageSize, int PageIndex, out int totalrecord)
        {
            //string condition = DAL_Helper.GetWhereCondition(where);
            string strSQL = string.Empty;
            if (!string.IsNullOrEmpty(strwhere))
            {
                strSQL = string.Format(@"select top (21-(select COUNT(*)
from OA_EDAYQUESTION 
where {0})) * from OA_EDUQUESTION where EDU_Q_GUID not in (select distinct EDU_Q_GUID from OA_EDAYQUESTION where {0} )"
                    , strwhere);  
            }
            else
            {
                strSQL = string.Format(" select * from OA_EDUQUESTION where EDU_Q_GUID not in (select distinct EDU_Q_GUID from OA_EDAYQUESTION)   ");
            }
            PageDescribe pdes = new PageDescribe();
            pdes.CurrentPage = PageIndex;
            pdes.PageSize = PageSize;
            DataTable dt = pdes.PageDescribes(strSQL);
            totalrecord = pdes.RecordCount;
            return DAL_Helper.CommonFillList<Model.OA_EDUQUESTION>(dt);
        }
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public IList<Model.OA_EDUQUESTION> Get_Paging_List(string title, int PageSize, int PageIndex, out int totalrecord)
        {
            //string condition = DAL_Helper.GetWhereCondition(where);
            string strSQL = string.Empty;
            if (!string.IsNullOrEmpty(title))
            {
                strSQL = string.Format("SELECT * from OA_EDUQUESTION WHERE TITLE like '%{0}%' ", title);  
            }
            else
            {
                strSQL = string.Format("SELECT * from OA_EDUQUESTION ", title);
            }
            PageDescribe pdes = new PageDescribe();
            pdes.CurrentPage = PageIndex;
            pdes.PageSize = PageSize;
            DataTable dt = pdes.PageDescribes(strSQL, "createtime", "desc");
            totalrecord = pdes.RecordCount;
            return DAL_Helper.CommonFillList<Model.OA_EDUQUESTION>(dt);
        }

        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public IList<Model.OA_EDUQUESTION> Get_Paging_List(decimal userId, string testId, int PageSize, int PageIndex, out int totalrecord)
        {
            string strSQL = string.Empty;
            strSQL = string.Format(@"SELECT  TOP (100) PERCENT a.*,u.MAP_INDEX from OA_EDUQUESTION a
                                    join 
                                    (select EDU_Q_GUID,MAP_INDEX from OA_QUESTION_TEST_MAP where EDU_T_GUID = '{0}' 
                                    and EDU_MAP_GUID in (select EDU_MAP_GUID from OA_TEST_ANSWER where ANSWER_ID = {1})) u 
                                    on u.EDU_Q_GUID = a.EDU_Q_GUID order by MAP_INDEX", testId, userId);
            PageDescribe pdes = new PageDescribe();
            pdes.CurrentPage = PageIndex;
            pdes.PageSize = PageSize;
            DataTable dt = pdes.PageDescribes(strSQL);
            totalrecord = pdes.RecordCount;
            return DAL_Helper.CommonFillList<Model.OA_EDUQUESTION>(dt);
        }

        public IList<Model.OA_EDUQUESTION> Get_Paging_TestList(string quesIds, int PageSize, int PageIndex, out int totalrecord)
        {
            string strSQL = string.Empty;
            if (!string.IsNullOrEmpty(quesIds))
            {
                strSQL = string.Format("SELECT * from OA_EDUQUESTION WHERE EDU_Q_GUID in ({0}) ", quesIds);
            }
            else
            {
                strSQL = string.Format("SELECT * from OA_EDUQUESTION ");
            }
            PageDescribe pdes = new PageDescribe();
            pdes.CurrentPage = PageIndex;
            pdes.PageSize = PageSize;
            DataTable dt = pdes.PageDescribes(strSQL,"createtime", "desc");
            totalrecord = pdes.RecordCount;
            return DAL_Helper.CommonFillList<Model.OA_EDUQUESTION>(dt);
        }


		#endregion  BasicMethod
		#region  ExtensionMethod

		#endregion  ExtensionMethod
	}
}

