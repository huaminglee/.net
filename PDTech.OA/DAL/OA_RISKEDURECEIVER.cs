/**  版本信息模板在安装目录下，可自行修改。
* OA_RISKEDURECEIVER.cs
*
* 功 能： N/A
* 类 名： OA_RISKEDURECEIVER
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2014/7/22 15:35:10   N/A    初版
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
	/// 数据访问类:OA_RISKEDURECEIVER
	/// </summary>
	public partial class OA_RISKEDURECEIVER
	{
		public OA_RISKEDURECEIVER()
		{}
		#region  BasicMethod

		/// <summary>
		/// 是否存在该记录
		/// </summary>
        public bool Exists(decimal? EDUCATION_ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from OA_RISKEDURECEIVER");
            strSql.Append(" where EDUCATION_ID=@EDUCATION_ID ");
			SqlParameter[] parameters = {
					new SqlParameter("@EDUCATION_ID", SqlDbType.Decimal,4)			};
            parameters[0].Value = EDUCATION_ID;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(PDTech.OA.Model.OA_RISKEDURECEIVER model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into OA_RISKEDURECEIVER(");
            strSql.Append("EDUCATION_ID,RECEIVER_ID,READ_STATUS,READ_TIME)");
			strSql.Append(" values (");
            strSql.Append("@EDUCATION_ID,@RECEIVER_ID,@READ_STATUS,@READ_TIME)");
			SqlParameter[] parameters = {
					new SqlParameter("@EDUCATION_ID", SqlDbType.Decimal,4),
					new SqlParameter("@RECEIVER_ID", SqlDbType.Decimal,4),
					new SqlParameter("@READ_STATUS", SqlDbType.Decimal,4),
					new SqlParameter("@READ_TIME", SqlDbType.DateTime)};
			parameters[0].Value = model.EDUCATION_ID;
			parameters[1].Value = model.RECEIVER_ID;
			parameters[2].Value = model.READ_STATUS;
			parameters[3].Value = model.READ_TIME;

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
		public bool Update(PDTech.OA.Model.OA_RISKEDURECEIVER model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update OA_RISKEDURECEIVER set ");
			strSql.Append("RECEIVER_ID=@RECEIVER_ID,");
			strSql.Append("READ_STATUS=@READ_STATUS,");
			strSql.Append("READ_TIME=@READ_TIME");
            strSql.Append(" where EDUCATION_ID=@EDUCATION_ID ");
			SqlParameter[] parameters = {
					new SqlParameter("@RECEIVER_ID", SqlDbType.Decimal,4),
					new SqlParameter("@READ_STATUS", SqlDbType.Decimal,4),
					new SqlParameter("@READ_TIME", SqlDbType.DateTime),
					new SqlParameter("@EDUCATION_ID", SqlDbType.Decimal,4)};
			parameters[0].Value = model.RECEIVER_ID;
			parameters[1].Value = model.READ_STATUS;
			parameters[2].Value = model.READ_TIME;
			parameters[3].Value = model.EDUCATION_ID;

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
        public bool UpdateState(PDTech.OA.Model.OA_RISKEDURECEIVER model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update OA_RISKEDURECEIVER set ");
            strSql.Append("READ_STATUS=@READ_STATUS,");
            strSql.Append("READ_TIME=@READ_TIME,");
            strSql.Append("READ_COUNT=@READ_COUNT");
            strSql.Append(" where EDUCATION_ID=@EDUCATION_ID ");
            strSql.Append(" and RECEIVER_ID=@RECEIVER_ID");
            SqlParameter[] parameters = {
					new SqlParameter("@READ_STATUS", SqlDbType.Decimal,4),
					new SqlParameter("@READ_TIME", SqlDbType.DateTime),
                    new SqlParameter("@READ_COUNT", SqlDbType.Decimal,4),
					new SqlParameter("@EDUCATION_ID", SqlDbType.Decimal,4),
                    new SqlParameter("@RECEIVER_ID", SqlDbType.Decimal,4)};    
            parameters[0].Value = model.READ_STATUS;
            parameters[1].Value = model.READ_TIME;
            parameters[2].Value = model.READ_COUNT;
            parameters[3].Value = model.EDUCATION_ID;
            parameters[4].Value = model.RECEIVER_ID;

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

        public bool UpdateReadCount(decimal? EDUCATION_ID, decimal? RECEIVER_ID)
        {
            string sql = string.Format("update OA_RISKEDURECEIVER set READ_COUNT=READ_COUNT+1 where EDUCATION_ID = {0} and RECEIVER_ID = {1}", EDUCATION_ID, RECEIVER_ID);
            int rows = DbHelperSQL.ExecuteSql(sql);
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
        public bool Delete(decimal? EDUCATION_ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from OA_RISKEDURECEIVER ");
            strSql.Append(" where EDUCATION_ID=@EDUCATION_ID ");
			SqlParameter[] parameters = {
					new SqlParameter("@EDUCATION_ID", SqlDbType.Decimal,4)			};
            parameters[0].Value = EDUCATION_ID;

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
        public bool DeleteList(string EDUCATION_IDlist)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from OA_RISKEDURECEIVER ");
            strSql.Append(" where EDUCATION_ID in (" + EDUCATION_IDlist + ")  ");
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
        public PDTech.OA.Model.OA_RISKEDURECEIVER GetModel(decimal? EDUCATION_ID)
		{
			
			StringBuilder strSql=new StringBuilder();
            strSql.Append("select EDUCATION_ID,RECEIVER_ID,READ_STATUS,READ_TIME,READ_COUNT from OA_RISKEDURECEIVER ");
            strSql.Append(" where EDUCATION_ID=@EDUCATION_ID ");
			SqlParameter[] parameters = {
					new SqlParameter("@EDUCATION_ID", SqlDbType.Decimal,4)			};
            parameters[0].Value = EDUCATION_ID;

			PDTech.OA.Model.OA_RISKEDURECEIVER model=new PDTech.OA.Model.OA_RISKEDURECEIVER();
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
        public PDTech.OA.Model.OA_RISKEDURECEIVER GetModel(decimal? EDUCATION_ID, decimal userID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select EDUCATION_ID,RECEIVER_ID,READ_STATUS,READ_TIME,READ_COUNT from OA_RISKEDURECEIVER ");
            strSql.Append(" where EDUCATION_ID=@EDUCATION_ID ");
            strSql.Append(" and RECEIVER_ID=@RECEIVER_ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@EDUCATION_ID", SqlDbType.Decimal,4),
                    new SqlParameter("@RECEIVER_ID", SqlDbType.Decimal)};
            parameters[0].Value = EDUCATION_ID;
            parameters[1].Value = userID;

            PDTech.OA.Model.OA_RISKEDURECEIVER model = new PDTech.OA.Model.OA_RISKEDURECEIVER();
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
		public PDTech.OA.Model.OA_RISKEDURECEIVER DataRowToModel(DataRow row)
		{
			PDTech.OA.Model.OA_RISKEDURECEIVER model=new PDTech.OA.Model.OA_RISKEDURECEIVER();
			if (row != null)
			{
                if (row["EDUCATION_ID"] != null)
				{
                    model.EDUCATION_ID = decimal.Parse(row["EDUCATION_ID"].ToString());
				}
				if(row["RECEIVER_ID"]!=null && row["RECEIVER_ID"].ToString()!="")
				{
					model.RECEIVER_ID=decimal.Parse(row["RECEIVER_ID"].ToString());
				}
				if(row["READ_STATUS"]!=null && row["READ_STATUS"].ToString()!="")
				{
					model.READ_STATUS=decimal.Parse(row["READ_STATUS"].ToString());
				}
				if(row["READ_TIME"]!=null && row["READ_TIME"].ToString()!="")
				{
					model.READ_TIME=DateTime.Parse(row["READ_TIME"].ToString());
				}
                if (row["READ_COUNT"] != null && row["READ_COUNT"].ToString() != "")
                {
                    model.READ_COUNT = decimal.Parse(row["READ_COUNT"].ToString());
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
            strSql.Append("select EDUCATION_ID,RECEIVER_ID,READ_STATUS,READ_TIME,READ_COUNT ");
			strSql.Append(" FROM OA_RISKEDURECEIVER ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			return DbHelperSQL.Query(strSql.ToString());
		}

		/// <summary>
		/// 获取记录总数
		/// </summary>
		public int GetRecordCount(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) FROM OA_RISKEDURECEIVER ");
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

		#endregion  BasicMethod
		#region  ExtensionMethod

		#endregion  ExtensionMethod
	}
}

