/**  版本信息模板在安装目录下，可自行修改。
* OA_QUESTION_TEST_MAP.cs
*
* 功 能： N/A
* 类 名： OA_QUESTION_TEST_MAP
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2014/7/22 15:35:52   N/A    初版
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
	/// 数据访问类:OA_QUESTION_TEST_MAP
	/// </summary>
	public partial class OA_QUESTION_TEST_MAP
	{
		public OA_QUESTION_TEST_MAP()
		{}
		#region  BasicMethod

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string EDU_MAP_GUID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from OA_QUESTION_TEST_MAP");
			strSql.Append(" where EDU_MAP_GUID=@EDU_MAP_GUID ");
			SqlParameter[] parameters = {
					new SqlParameter("@EDU_MAP_GUID", SqlDbType.NVarChar)			};
			parameters[0].Value = EDU_MAP_GUID;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(PDTech.OA.Model.OA_QUESTION_TEST_MAP model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into OA_QUESTION_TEST_MAP(");
            strSql.Append("EDU_MAP_GUID,EDU_Q_GUID,EDU_T_GUID,MAP_INDEX)");
			strSql.Append(" values (");
            strSql.Append("@EDU_MAP_GUID,@EDU_Q_GUID,@EDU_T_GUID,@MAP_INDEX)");
			SqlParameter[] parameters = {
					new SqlParameter("@EDU_MAP_GUID", SqlDbType.NVarChar),
					new SqlParameter("@EDU_Q_GUID", SqlDbType.NVarChar),
					new SqlParameter("@EDU_T_GUID", SqlDbType.NVarChar),
                    new SqlParameter("@MAP_INDEX", SqlDbType.Decimal,4)};
			parameters[0].Value = model.EDU_MAP_GUID;
			parameters[1].Value = model.EDU_Q_GUID;
			parameters[2].Value = model.EDU_T_GUID;
            parameters[3].Value = model.MAP_INDEX;

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
		public bool Update(PDTech.OA.Model.OA_QUESTION_TEST_MAP model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update OA_QUESTION_TEST_MAP set ");
			strSql.Append("EDU_Q_GUID=@EDU_Q_GUID,");
			strSql.Append("EDU_T_GUID=@EDU_T_GUID");
            strSql.Append("MAP_INDEX=@MAP_INDEX");
			strSql.Append(" where EDU_MAP_GUID=@EDU_MAP_GUID ");
			SqlParameter[] parameters = {
					new SqlParameter("@EDU_Q_GUID", SqlDbType.NVarChar),
					new SqlParameter("@EDU_T_GUID", SqlDbType.NVarChar),
                    new SqlParameter("@MAP_INDEX", SqlDbType.Decimal,4),
					new SqlParameter("@EDU_MAP_GUID", SqlDbType.NVarChar)};
			parameters[0].Value = model.EDU_Q_GUID;
			parameters[1].Value = model.EDU_T_GUID;
            parameters[2].Value = model.MAP_INDEX;
			parameters[3].Value = model.EDU_MAP_GUID;

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
		/// 删除一条数据
		/// </summary>
		public bool Delete(string EDU_MAP_GUID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from OA_QUESTION_TEST_MAP ");
			strSql.Append(" where EDU_MAP_GUID=@EDU_MAP_GUID ");
			SqlParameter[] parameters = {
					new SqlParameter("@EDU_MAP_GUID", SqlDbType.NVarChar)			};
			parameters[0].Value = EDU_MAP_GUID;

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
		public bool DeleteList(string EDU_MAP_GUIDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from OA_QUESTION_TEST_MAP ");
			strSql.Append(" where EDU_MAP_GUID in ("+EDU_MAP_GUIDlist + ")  ");
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
		public PDTech.OA.Model.OA_QUESTION_TEST_MAP GetModel(string EDU_MAP_GUID)
		{
			
			StringBuilder strSql=new StringBuilder();
            strSql.Append("select EDU_MAP_GUID,EDU_Q_GUID,EDU_T_GUID,MAP_INDEX from OA_QUESTION_TEST_MAP ");
			strSql.Append(" where EDU_MAP_GUID=@EDU_MAP_GUID ");
			SqlParameter[] parameters = {
					new SqlParameter("@EDU_MAP_GUID", SqlDbType.NVarChar)			};
			parameters[0].Value = EDU_MAP_GUID;

			PDTech.OA.Model.OA_QUESTION_TEST_MAP model=new PDTech.OA.Model.OA_QUESTION_TEST_MAP();
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
		public PDTech.OA.Model.OA_QUESTION_TEST_MAP DataRowToModel(DataRow row)
		{
			PDTech.OA.Model.OA_QUESTION_TEST_MAP model=new PDTech.OA.Model.OA_QUESTION_TEST_MAP();
			if (row != null)
			{
				if(row["EDU_MAP_GUID"]!=null)
				{
					model.EDU_MAP_GUID=row["EDU_MAP_GUID"].ToString();
				}
				if(row["EDU_Q_GUID"]!=null)
				{
					model.EDU_Q_GUID=row["EDU_Q_GUID"].ToString();
				}
				if(row["EDU_T_GUID"]!=null)
				{
					model.EDU_T_GUID=row["EDU_T_GUID"].ToString();
				}
                if (row["MAP_INDEX"] != null)
                {
                    model.MAP_INDEX = decimal.Parse(row["MAP_INDEX"].ToString());
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
            strSql.Append("select EDU_MAP_GUID,EDU_Q_GUID,EDU_T_GUID,MAP_INDEX ");
			strSql.Append(" FROM OA_QUESTION_TEST_MAP ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
            strSql.Append(" order by map_index ");
			return DbHelperSQL.Query(strSql.ToString());
		}

		/// <summary>
		/// 获取记录总数
		/// </summary>
		public int GetRecordCount(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) FROM OA_QUESTION_TEST_MAP ");
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

