/**  版本信息模板在安装目录下，可自行修改。
* ROLL_NEWS.cs
*
* 功 能： N/A
* 类 名： ROLL_NEWS
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2014/8/6 15:00:47   N/A    初版
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
using Maticsoft.DBUtility;
using System.Collections.Generic;
using System.Data.SqlClient;//Please add references
namespace PDTech.OA.DAL
{
	/// <summary>
	/// 数据访问类:ROLL_NEWS
	/// </summary>
	public partial class ROLL_NEWS
	{
		public ROLL_NEWS()
		{}
		#region  BasicMethod

		/// <summary>
		/// 是否存在该记录
		/// </summary>
        public bool Exists(string NEWS_TITLE)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from ROLL_NEWS");
            strSql.Append(" where NEWS_TITLE=@NEWS_TITLE ");
			SqlParameter[] parameters = {
					new SqlParameter("@NEWS_TITLE", SqlDbType.NVarChar)			};
            parameters[0].Value = NEWS_TITLE;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string NEWS_TITLE, decimal NEWS_ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from ROLL_NEWS");
            strSql.Append(" where NEWS_TITLE=@NEWS_TITLE AND NEWS_ID<>@NEWS_ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@NEWS_TITLE", SqlDbType.NVarChar),
                                           new SqlParameter("@NEWS_ID", SqlDbType.Decimal,4)	};
            parameters[0].Value = NEWS_TITLE;
            parameters[1].Value = NEWS_ID;
            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(PDTech.OA.Model.ROLL_NEWS model)
		{
            if (Exists(model.NEWS_TITLE))
            {
                return -1;
            }
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into ROLL_NEWS(");
			strSql.Append("NEWS_TITLE,NEWS_CONTENT,CREATOR,CREATE_TIME,IS_ROLLING)");
			strSql.Append(" values (");
			strSql.Append("@NEWS_TITLE,@NEWS_CONTENT,@CREATOR,@CREATE_TIME,@IS_ROLLING)");
			SqlParameter[] parameters = {
					//new SqlParameter("@NEWS_ID", SqlDbType.Decimal,4),
					new SqlParameter("@NEWS_TITLE", SqlDbType.NVarChar),
					new SqlParameter("@NEWS_CONTENT", SqlDbType.Text),
					new SqlParameter("@CREATOR", SqlDbType.Decimal,4),
					new SqlParameter("@CREATE_TIME", SqlDbType.DateTime),
					new SqlParameter("@IS_ROLLING", SqlDbType.Decimal,4)};
			//parameters[0].Value = model.NEWS_ID;
			parameters[0].Value = model.NEWS_TITLE;
			parameters[1].Value = model.NEWS_CONTENT;
			parameters[2].Value = model.CREATOR;
			parameters[3].Value = model.CREATE_TIME;
			parameters[4].Value = model.IS_ROLLING;

			int rows=DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
			if (rows > 0)
			{
				return 1;
			}
			else
			{
				return 0;
			}
		}
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public int Update(PDTech.OA.Model.ROLL_NEWS model)
		{
            if (Exists(model.NEWS_TITLE, model.NEWS_ID))
            {
                return -1;
            }
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update ROLL_NEWS set ");
			strSql.Append("NEWS_TITLE=@NEWS_TITLE,");
			strSql.Append("NEWS_CONTENT=@NEWS_CONTENT,");
			strSql.Append("CREATOR=@CREATOR,");
			strSql.Append("CREATE_TIME=@CREATE_TIME,");
			strSql.Append("IS_ROLLING=@IS_ROLLING");
			strSql.Append(" where NEWS_ID=@NEWS_ID ");
			SqlParameter[] parameters = {
					new SqlParameter("@NEWS_TITLE", SqlDbType.NVarChar),
					new SqlParameter("@NEWS_CONTENT", SqlDbType.Text),
					new SqlParameter("@CREATOR", SqlDbType.Decimal,4),
					new SqlParameter("@CREATE_TIME", SqlDbType.DateTime),
					new SqlParameter("@IS_ROLLING", SqlDbType.Decimal,4),
					new SqlParameter("@NEWS_ID", SqlDbType.Decimal,4)};
			parameters[0].Value = model.NEWS_TITLE;
			parameters[1].Value = model.NEWS_CONTENT;
			parameters[2].Value = model.CREATOR;
			parameters[3].Value = model.CREATE_TIME;
			parameters[4].Value = model.IS_ROLLING;
			parameters[5].Value = model.NEWS_ID;

			int rows=DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
			if (rows > 0)
			{
				return 1;
			}
			else
			{
				return 0;
			}
		}

        public bool Update(string NEWS_IDlist, decimal isRolling)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update ROLL_NEWS set IS_ROLLING = " + isRolling.ToString());
            strSql.Append(" where NEWS_ID in (" + NEWS_IDlist + ")  ");
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
		/// 删除一条数据
		/// </summary>
		public bool Delete(decimal NEWS_ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from ROLL_NEWS ");
			strSql.Append(" where NEWS_ID=@NEWS_ID ");
			SqlParameter[] parameters = {
					new SqlParameter("@NEWS_ID", SqlDbType.Decimal,22)			};
			parameters[0].Value = NEWS_ID;

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
		/// 批量删除数据
		/// </summary>
		public bool DeleteList(string NEWS_IDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from ROLL_NEWS ");
			strSql.Append(" where NEWS_ID in ("+NEWS_IDlist + ")  ");
			int rows=DbHelperSQL.ExecuteSql(strSql.ToString());
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
		public PDTech.OA.Model.ROLL_NEWS GetModel(decimal NEWS_ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select NEWS_ID,NEWS_TITLE,NEWS_CONTENT,CREATOR,CREATE_TIME,IS_ROLLING from ROLL_NEWS ");
			strSql.Append(" where NEWS_ID=@NEWS_ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@NEWS_ID", SqlDbType.Decimal,22)			};
			parameters[0].Value = NEWS_ID;

			PDTech.OA.Model.ROLL_NEWS model=new PDTech.OA.Model.ROLL_NEWS();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
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
		public PDTech.OA.Model.ROLL_NEWS DataRowToModel(DataRow row)
		{
			PDTech.OA.Model.ROLL_NEWS model=new PDTech.OA.Model.ROLL_NEWS();
			if (row != null)
			{
				if(row["NEWS_ID"]!=null && row["NEWS_ID"].ToString()!="")
				{
					model.NEWS_ID=decimal.Parse(row["NEWS_ID"].ToString());
				}
				if(row["NEWS_TITLE"]!=null)
				{
					model.NEWS_TITLE=row["NEWS_TITLE"].ToString();
				}
                if (row["NEWS_CONTENT"] != null)
                {
                    model.NEWS_CONTENT = row["NEWS_CONTENT"].ToString();
                }
				if(row["CREATOR"]!=null && row["CREATOR"].ToString()!="")
				{
					model.CREATOR=decimal.Parse(row["CREATOR"].ToString());
				}
				if(row["CREATE_TIME"]!=null && row["CREATE_TIME"].ToString()!="")
				{
					model.CREATE_TIME=DateTime.Parse(row["CREATE_TIME"].ToString());
				}
				if(row["IS_ROLLING"]!=null && row["IS_ROLLING"].ToString()!="")
				{
					model.IS_ROLLING=decimal.Parse(row["IS_ROLLING"].ToString());
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
            strSql.Append("select NEWS_ID,NEWS_TITLE,NEWS_CONTENT,CREATOR,CREATE_TIME,IS_ROLLING ");
			strSql.Append(" FROM ROLL_NEWS ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
            strSql.Append(" order by NEWS_ID ");
			return DbHelperSQL.Query(strSql.ToString());
		}

		/// <summary>
		/// 获取记录总数
		/// </summary>
		public int GetRecordCount(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) FROM ROLL_NEWS ");
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

        public IList<Model.ROLL_NEWS> Get_Paging_List(string title, int currentpage, int pagesize, out int totalrecord)
        {
            string strSQL = string.Empty;
            if (!string.IsNullOrEmpty(title))
            {
                strSQL = string.Format("SELECT TOP (100) PERCENT * from ROLL_NEWS WHERE NEWS_TITLE like '%{0}%' order by NEWS_ID desc ", title);
            }
            else
            {
                strSQL = string.Format("SELECT TOP (100) PERCENT * from ROLL_NEWS order by NEWS_ID desc ");
            }
            PageDescribe pdes = new PageDescribe();
            pdes.CurrentPage = currentpage;
            pdes.PageSize = pagesize;
            DataTable dt = pdes.PageDescribes(strSQL);
            totalrecord = pdes.RecordCount;
            return DAL_Helper.CommonFillList<Model.ROLL_NEWS>(dt);
        }

		/*
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		{
			SqlParameter[] parameters = {
					new SqlParameter("@tblName", SqlDbType.VarChar, 255),
					new SqlParameter("@fldName", SqlDbType.VarChar, 255),
					new SqlParameter("@PageSize", SqlDbType.Number),
					new SqlParameter("@PageIndex", SqlDbType.Number),
					new SqlParameter("@IsReCount", SqlDbType.Clob),
					new SqlParameter("@OrderType", SqlDbType.Clob),
					new SqlParameter("@strWhere", SqlDbType.VarChar,1000),
					};
			parameters[0].Value = "ROLL_NEWS";
			parameters[1].Value = "NEWS_ID";
			parameters[2].Value = PageSize;
			parameters[3].Value = PageIndex;
			parameters[4].Value = 0;
			parameters[5].Value = 0;
			parameters[6].Value = strWhere;	
			return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
		}*/

		#endregion  BasicMethod
		#region  ExtensionMethod

		#endregion  ExtensionMethod
	}
}

