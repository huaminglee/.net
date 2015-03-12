/**  版本信息模板在安装目录下，可自行修改。
* API_MESSAGES.cs
*
* 功 能： N/A
* 类 名： API_MESSAGES
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2014-7-11 15:35:20   N/A    初版
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
using System.Data.SqlClient;//Please add references
namespace PDTech.OA.DAL
{
	/// <summary>
	/// 数据访问类:API_MESSAGES
	/// </summary>
	public partial class API_MESSAGES
	{
		public API_MESSAGES()
		{}
		#region  BasicMethod

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(decimal API_MESSAGE_ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from API_MESSAGES");
			strSql.Append(" where API_MESSAGE_ID=@API_MESSAGE_ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@API_MESSAGE_ID", SqlDbType.Decimal,22)			};
			parameters[0].Value = API_MESSAGE_ID;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(PDTech.OA.Model.API_MESSAGES model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into API_MESSAGES(");
			strSql.Append("API_MESSAGE_ID,MESSAGE_TYPE,FROM_TYPE,FROM_ID,TO_TYPE,TO_ID,INSERT_TIME,TRY_TIME,TRIALS,RESPONSE,DATA1,DATA2,DATA3,DATA4,MESSAGE_STAT,CREATOR,DATA5)");
			strSql.Append(" values (");
			strSql.Append("@API_MESSAGE_ID,@MESSAGE_TYPE,@FROM_TYPE,@FROM_ID,@TO_TYPE,@TO_ID,@INSERT_TIME,@TRY_TIME,@TRIALS,@RESPONSE,@DATA1,@DATA2,@DATA3,@DATA4,@MESSAGE_STAT,@CREATOR,@DATA5)");
            SqlParameter[] parameters = {
					new SqlParameter("@API_MESSAGE_ID", SqlDbType.Decimal,4),
					new SqlParameter("@MESSAGE_TYPE", SqlDbType.NVarChar),
					new SqlParameter("@FROM_TYPE", SqlDbType.NVarChar),
					new SqlParameter("@FROM_ID", SqlDbType.Decimal,4),
					new SqlParameter("@TO_TYPE", SqlDbType.NVarChar),
					new SqlParameter("@TO_ID", SqlDbType.Decimal,4),
					new SqlParameter("@INSERT_TIME", SqlDbType.DateTime),
					new SqlParameter("@TRY_TIME", SqlDbType.DateTime),
					new SqlParameter("@TRIALS", SqlDbType.Decimal,4),
					new SqlParameter("@RESPONSE", SqlDbType.NVarChar),
					new SqlParameter("@DATA1", SqlDbType.NVarChar),
					new SqlParameter("@DATA2", SqlDbType.NVarChar),
					new SqlParameter("@DATA3", SqlDbType.NVarChar),
					new SqlParameter("@DATA4", SqlDbType.NVarChar),
					new SqlParameter("@MESSAGE_STAT", SqlDbType.Decimal,4),
					new SqlParameter("@CREATOR", SqlDbType.Decimal,4),
					new SqlParameter("@DATA5", SqlDbType.NVarChar)};
			parameters[0].Value = model.API_MESSAGE_ID;
			parameters[1].Value = model.MESSAGE_TYPE;
			parameters[2].Value = model.FROM_TYPE;
			parameters[3].Value = model.FROM_ID;
			parameters[4].Value = model.TO_TYPE;
			parameters[5].Value = model.TO_ID;
			parameters[6].Value = model.INSERT_TIME;
			parameters[7].Value = model.TRY_TIME;
			parameters[8].Value = model.TRIALS;
			parameters[9].Value = model.RESPONSE;
			parameters[10].Value = model.DATA1;
			parameters[11].Value = model.DATA2;
			parameters[12].Value = model.DATA3;
			parameters[13].Value = model.DATA4;
			parameters[14].Value = model.MESSAGE_STAT;
			parameters[15].Value = model.CREATOR;
			parameters[16].Value = model.DATA5;

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
		public bool Update(PDTech.OA.Model.API_MESSAGES model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update API_MESSAGES set ");
			strSql.Append("MESSAGE_TYPE=@MESSAGE_TYPE,");
			strSql.Append("FROM_TYPE=@FROM_TYPE,");
			strSql.Append("FROM_ID=@FROM_ID,");
			strSql.Append("TO_TYPE=@TO_TYPE,");
			strSql.Append("TO_ID=@TO_ID,");
			strSql.Append("INSERT_TIME=@INSERT_TIME,");
			strSql.Append("TRY_TIME=@TRY_TIME,");
			strSql.Append("TRIALS=@TRIALS,");
			strSql.Append("RESPONSE=@RESPONSE,");
			strSql.Append("DATA1=@DATA1,");
			strSql.Append("DATA2=@DATA2,");
			strSql.Append("DATA3=@DATA3,");
			strSql.Append("DATA4=@DATA4,");
			strSql.Append("MESSAGE_STAT=@MESSAGE_STAT,");
			strSql.Append("CREATOR=@CREATOR,");
			strSql.Append("DATA5=@DATA5");
			strSql.Append(" where API_MESSAGE_ID=@API_MESSAGE_ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@MESSAGE_TYPE", SqlDbType.NVarChar),
					new SqlParameter("@FROM_TYPE", SqlDbType.NVarChar),
					new SqlParameter("@FROM_ID", SqlDbType.Decimal,4),
					new SqlParameter("@TO_TYPE", SqlDbType.NVarChar),
					new SqlParameter("@TO_ID", SqlDbType.Decimal,4),
					new SqlParameter("@INSERT_TIME", SqlDbType.DateTime),
					new SqlParameter("@TRY_TIME", SqlDbType.DateTime),
					new SqlParameter("@TRIALS", SqlDbType.Decimal,4),
					new SqlParameter("@RESPONSE", SqlDbType.NVarChar),
					new SqlParameter("@DATA1", SqlDbType.NVarChar),
					new SqlParameter("@DATA2", SqlDbType.NVarChar),
					new SqlParameter("@DATA3", SqlDbType.NVarChar),
					new SqlParameter("@DATA4", SqlDbType.NVarChar),
					new SqlParameter("@MESSAGE_STAT", SqlDbType.Decimal,4),
					new SqlParameter("@CREATOR", SqlDbType.Decimal,4),
					new SqlParameter("@DATA5", SqlDbType.NVarChar),
					new SqlParameter("@API_MESSAGE_ID", SqlDbType.Decimal,4)};
			parameters[0].Value = model.MESSAGE_TYPE;
			parameters[1].Value = model.FROM_TYPE;
			parameters[2].Value = model.FROM_ID;
			parameters[3].Value = model.TO_TYPE;
			parameters[4].Value = model.TO_ID;
			parameters[5].Value = model.INSERT_TIME;
			parameters[6].Value = model.TRY_TIME;
			parameters[7].Value = model.TRIALS;
			parameters[8].Value = model.RESPONSE;
			parameters[9].Value = model.DATA1;
			parameters[10].Value = model.DATA2;
			parameters[11].Value = model.DATA3;
			parameters[12].Value = model.DATA4;
			parameters[13].Value = model.MESSAGE_STAT;
			parameters[14].Value = model.CREATOR;
			parameters[15].Value = model.DATA5;
			parameters[16].Value = model.API_MESSAGE_ID;

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
        public bool UpdateMessage(PDTech.OA.Model.API_MESSAGES model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update API_MESSAGES set ");
            strSql.Append("TRY_TIME=@TRY_TIME,");
            strSql.Append("TRIALS=@TRIALS,");
            strSql.Append("RESPONSE=@RESPONSE,");
            strSql.Append("MESSAGE_STAT=@MESSAGE_STAT");
            strSql.Append(" where API_MESSAGE_ID=@API_MESSAGE_ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@TRY_TIME", SqlDbType.DateTime),
					new SqlParameter("@TRIALS", SqlDbType.Decimal,4),
					new SqlParameter("@RESPONSE", SqlDbType.NVarChar),
					new SqlParameter("@MESSAGE_STAT", SqlDbType.Decimal,4),
					new SqlParameter("@API_MESSAGE_ID", SqlDbType.Decimal,4)};
            parameters[0].Value = model.TRY_TIME;
            parameters[1].Value = model.TRIALS;
            parameters[2].Value = model.RESPONSE;
            parameters[3].Value = model.MESSAGE_STAT;
            parameters[4].Value = model.API_MESSAGE_ID;

            DAL_Helper.get_db_para_value(parameters);
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
		public bool Delete(decimal API_MESSAGE_ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from API_MESSAGES ");
			strSql.Append(" where API_MESSAGE_ID=@API_MESSAGE_ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@API_MESSAGE_ID", SqlDbType.Decimal,22)			};
			parameters[0].Value = API_MESSAGE_ID;

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
		public bool DeleteList(string API_MESSAGE_IDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from API_MESSAGES ");
			strSql.Append(" where API_MESSAGE_ID in ("+API_MESSAGE_IDlist + ")  ");
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
		public PDTech.OA.Model.API_MESSAGES GetModel(decimal API_MESSAGE_ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select API_MESSAGE_ID,MESSAGE_TYPE,FROM_TYPE,FROM_ID,TO_TYPE,TO_ID,INSERT_TIME,TRY_TIME,TRIALS,RESPONSE,DATA1,DATA2,DATA3,DATA4,MESSAGE_STAT,CREATOR,DATA5 from API_MESSAGES ");
			strSql.Append(" where API_MESSAGE_ID=@API_MESSAGE_ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@API_MESSAGE_ID", SqlDbType.Decimal,22)			};
			parameters[0].Value = API_MESSAGE_ID;

			PDTech.OA.Model.API_MESSAGES model=new PDTech.OA.Model.API_MESSAGES();
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
		public PDTech.OA.Model.API_MESSAGES DataRowToModel(DataRow row)
		{
			PDTech.OA.Model.API_MESSAGES model=new PDTech.OA.Model.API_MESSAGES();
			if (row != null)
			{
				if(row["API_MESSAGE_ID"]!=null && row["API_MESSAGE_ID"].ToString()!="")
				{
					model.API_MESSAGE_ID=decimal.Parse(row["API_MESSAGE_ID"].ToString());
				}
				if(row["MESSAGE_TYPE"]!=null)
				{
					model.MESSAGE_TYPE=row["MESSAGE_TYPE"].ToString();
				}
				if(row["FROM_TYPE"]!=null)
				{
					model.FROM_TYPE=row["FROM_TYPE"].ToString();
				}
				if(row["FROM_ID"]!=null && row["FROM_ID"].ToString()!="")
				{
					model.FROM_ID=decimal.Parse(row["FROM_ID"].ToString());
				}
				if(row["TO_TYPE"]!=null)
				{
					model.TO_TYPE=row["TO_TYPE"].ToString();
				}
				if(row["TO_ID"]!=null && row["TO_ID"].ToString()!="")
				{
					model.TO_ID=decimal.Parse(row["TO_ID"].ToString());
				}
				if(row["INSERT_TIME"]!=null && row["INSERT_TIME"].ToString()!="")
				{
					model.INSERT_TIME=DateTime.Parse(row["INSERT_TIME"].ToString());
				}
				if(row["TRY_TIME"]!=null && row["TRY_TIME"].ToString()!="")
				{
					model.TRY_TIME=DateTime.Parse(row["TRY_TIME"].ToString());
				}
				if(row["TRIALS"]!=null && row["TRIALS"].ToString()!="")
				{
					model.TRIALS=decimal.Parse(row["TRIALS"].ToString());
				}
				if(row["RESPONSE"]!=null)
				{
					model.RESPONSE=row["RESPONSE"].ToString();
				}
				if(row["DATA1"]!=null)
				{
					model.DATA1=row["DATA1"].ToString();
				}
				if(row["DATA2"]!=null)
				{
					model.DATA2=row["DATA2"].ToString();
				}
				if(row["DATA3"]!=null)
				{
					model.DATA3=row["DATA3"].ToString();
				}
				if(row["DATA4"]!=null)
				{
					model.DATA4=row["DATA4"].ToString();
				}
				if(row["MESSAGE_STAT"]!=null && row["MESSAGE_STAT"].ToString()!="")
				{
					model.MESSAGE_STAT=decimal.Parse(row["MESSAGE_STAT"].ToString());
				}
				if(row["CREATOR"]!=null && row["CREATOR"].ToString()!="")
				{
					model.CREATOR=decimal.Parse(row["CREATOR"].ToString());
				}
				if(row["DATA5"]!=null)
				{
					model.DATA5=row["DATA5"].ToString();
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
			strSql.Append("select API_MESSAGE_ID,MESSAGE_TYPE,FROM_TYPE,FROM_ID,TO_TYPE,TO_ID,INSERT_TIME,TRY_TIME,TRIALS,RESPONSE,DATA1,DATA2,DATA3,DATA4,MESSAGE_STAT,CREATOR,DATA5 ");
			strSql.Append(" FROM API_MESSAGES ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
            return DbHelperSQL.Query(strSql.ToString());
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
        public DataSet GetList(int limit, string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select TOP {0} API_MESSAGE_ID,MESSAGE_TYPE,FROM_TYPE,FROM_ID,TO_TYPE,TO_ID,INSERT_TIME,TRY_TIME,TRIALS,RESPONSE,DATA1,DATA2,DATA3,DATA4,MESSAGE_STAT,CREATOR,DATA5 ");
			strSql.Append(" FROM API_MESSAGES ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
            return DbHelperSQL.Query(string.Format(strSql.ToString(),limit));
		}

		/// <summary>
		/// 获取记录总数
		/// </summary>
		public int GetRecordCount(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) FROM API_MESSAGES ");
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

