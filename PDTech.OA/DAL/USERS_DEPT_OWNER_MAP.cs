/**  版本信息模板在安装目录下，可自行修改。
* USERS_DEPT_OWNER_MAP.cs
*
* 功 能： N/A
* 类 名： USERS_DEPT_OWNER_MAP
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2014-9-23 13:30:48   N/A    初版
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
using System.Collections;
using System.Collections.Generic;//Please add references
namespace PDTech.OA.DAL
{
	/// <summary>
	/// 数据访问类:USERS_DEPT_OWNER_MAP
	/// </summary>
	public partial class USERS_DEPT_OWNER_MAP
	{
		public USERS_DEPT_OWNER_MAP()
		{}
		#region  BasicMethod



		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(PDTech.OA.Model.USERS_DEPT_OWNER_MAP model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into USERS_DEPT_OWNER_MAP(");
			strSql.Append("USER_ID,DEPARTMENT_ID)");
			strSql.Append(" values (");
			strSql.Append("@USER_ID,@DEPARTMENT_ID)");
			SqlParameter[] parameters = {
					new SqlParameter("@USER_ID", SqlDbType.Int,4),
					new SqlParameter("@DEPARTMENT_ID", SqlDbType.Int,4)};
			parameters[0].Value = model.USER_ID;
			parameters[1].Value = model.DEPARTMENT_ID;

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
		public bool Update(PDTech.OA.Model.USERS_DEPT_OWNER_MAP model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update USERS_DEPT_OWNER_MAP set ");
			strSql.Append("USER_ID=@USER_ID,");
			strSql.Append("DEPARTMENT_ID=@DEPARTMENT_ID");
			strSql.Append(" where ");
			SqlParameter[] parameters = {
					new SqlParameter("@USER_ID", SqlDbType.Int,4),
					new SqlParameter("@DEPARTMENT_ID", SqlDbType.Int,4)};
			parameters[0].Value = model.USER_ID;
			parameters[1].Value = model.DEPARTMENT_ID;

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
		public bool Delete()
		{
			//该表无主键信息，请自定义主键/条件字段
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from USERS_DEPT_OWNER_MAP ");
			strSql.Append(" where ");
			SqlParameter[] parameters = {
			};

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
		/// 得到一个对象实体
		/// </summary>
		public PDTech.OA.Model.USERS_DEPT_OWNER_MAP GetModel()
		{
			//该表无主键信息，请自定义主键/条件字段
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 USER_ID,DEPARTMENT_ID from USERS_DEPT_OWNER_MAP ");
			strSql.Append(" where ");
			SqlParameter[] parameters = {
			};

			PDTech.OA.Model.USERS_DEPT_OWNER_MAP model=new PDTech.OA.Model.USERS_DEPT_OWNER_MAP();
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
		public PDTech.OA.Model.USERS_DEPT_OWNER_MAP DataRowToModel(DataRow row)
		{
			PDTech.OA.Model.USERS_DEPT_OWNER_MAP model=new PDTech.OA.Model.USERS_DEPT_OWNER_MAP();
			if (row != null)
			{
				if(row["USER_ID"]!=null && row["USER_ID"].ToString()!="")
				{
					model.USER_ID=int.Parse(row["USER_ID"].ToString());
				}
				if(row["DEPARTMENT_ID"]!=null && row["DEPARTMENT_ID"].ToString()!="")
				{
					model.DEPARTMENT_ID=int.Parse(row["DEPARTMENT_ID"].ToString());
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
			strSql.Append("select USER_ID,DEPARTMENT_ID ");
			strSql.Append(" FROM USERS_DEPT_OWNER_MAP ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			return DbHelperSQL.Query(strSql.ToString());
		}

		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public DataSet GetList(int Top,string strWhere,string filedOrder)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ");
			if(Top>0)
			{
				strSql.Append(" top "+Top.ToString());
			}
			strSql.Append(" USER_ID,DEPARTMENT_ID ");
			strSql.Append(" FROM USERS_DEPT_OWNER_MAP ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			strSql.Append(" order by " + filedOrder);
			return DbHelperSQL.Query(strSql.ToString());
		}

		/// <summary>
		/// 获取记录总数
		/// </summary>
		public int GetRecordCount(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) FROM USERS_DEPT_OWNER_MAP ");
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
		public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("SELECT * FROM ( ");
			strSql.Append(" SELECT ROW_NUMBER() OVER (");
			if (!string.IsNullOrEmpty(orderby.Trim()))
			{
				strSql.Append("order by T." + orderby );
			}
			else
			{
				strSql.Append("order by T. desc");
			}
			strSql.Append(")AS Row, T.*  from USERS_DEPT_OWNER_MAP T ");
			if (!string.IsNullOrEmpty(strWhere.Trim()))
			{
				strSql.Append(" WHERE " + strWhere);
			}
			strSql.Append(" ) TT");
			strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
			return DbHelperSQL.Query(strSql.ToString());
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
					new SqlParameter("@PageSize", SqlDbType.Int),
					new SqlParameter("@PageIndex", SqlDbType.Int),
					new SqlParameter("@IsReCount", SqlDbType.Bit),
					new SqlParameter("@OrderType", SqlDbType.Bit),
					new SqlParameter("@strWhere", SqlDbType.VarChar,1000),
					};
			parameters[0].Value = "USERS_DEPT_OWNER_MAP";
			parameters[1].Value = "";
			parameters[2].Value = PageSize;
			parameters[3].Value = PageIndex;
			parameters[4].Value = 0;
			parameters[5].Value = 0;
			parameters[6].Value = strWhere;	
			return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
		}*/


        /// <summary>
        /// 事务添加领导分管部门
        /// </summary>
        /// <param name="List">分管部门对象</param>
        /// <param name="uId">被修改人员ID</param>
        /// <param name="HostName">计算机名</param>
        /// <param name="Ip">IP</param>
        /// <param name="operId">操作人员</param>
        /// <returns></returns>
        public int ExecuteSqlTran(IList<PDTech.OA.Model.USERS_DEPT_OWNER_MAP> List, string uId, string HostName, string Ip, decimal operId)
        {
            int Flag = 0;
            try
            {
                string RightArr = "";
                ArrayList SQLStringList = new ArrayList();
                string delSQL = string.Format(@"delete from USERS_DEPT_OWNER_MAP ");
                delSQL += string.Format(" where USER_ID={0}", uId);
                SQLStringList.Add(delSQL);
                foreach (var item in List)
                {
                    string strSql = string.Format(@"insert into USERS_DEPT_OWNER_MAP(");
                    strSql += string.Format(@"USER_ID,DEPARTMENT_ID)");
                    strSql += string.Format(" values (");
                    strSql += string.Format("{0},{1})", item.USER_ID, item.DEPARTMENT_ID);
                    RightArr += item.DEPARTMENT_ID.ToString() + ",";
                    SQLStringList.Add(strSql);
                }
                DbHelperSQL.ExecuteSqlTran(SQLStringList);
                return Flag = 1;
            }
            catch (Exception ex)
            { Flag = -1; }
            return Flag;
        }
		#endregion  BasicMethod
		#region  ExtensionMethod

		#endregion  ExtensionMethod
	}
}

