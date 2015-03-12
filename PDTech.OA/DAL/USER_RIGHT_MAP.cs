﻿using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;
using System.Collections.Generic;
using System.Collections;//Please add references

namespace PDTech.OA.DAL
{
	/// <summary>
	/// 数据访问类:USER_RIGHT_MAP
	/// </summary>
	public partial class USER_RIGHT_MAP
	{
		public USER_RIGHT_MAP()
		{}
        OPERATION_LOG log = new OPERATION_LOG();
        const string USER_RIGHT_UP = "USER_RIGHT_UP";
		#region  BasicMethod



		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(PDTech.OA.Model.USER_RIGHT_MAP model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into USER_RIGHT_MAP(");
			strSql.Append("USER_ID,RIGHT_ID)");
			strSql.Append(" values (");
			strSql.Append("@USER_ID,@RIGHT_ID)");
			SqlParameter[] parameters = {
					new SqlParameter("@USER_ID", SqlDbType.Decimal),
					new SqlParameter("@RIGHT_ID", SqlDbType.Decimal)};
			parameters[0].Value = model.USER_ID;
			parameters[1].Value = model.RIGHT_ID;

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
		public bool Update(PDTech.OA.Model.USER_RIGHT_MAP model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update USER_RIGHT_MAP set ");
			strSql.Append("USER_ID=@USER_ID,");
			strSql.Append("RIGHT_ID=@RIGHT_ID");
			strSql.Append(" where ");
			SqlParameter[] parameters = {
					new SqlParameter("@USER_ID", SqlDbType.Decimal),
					new SqlParameter("@RIGHT_ID", SqlDbType.Decimal)};
			parameters[0].Value = model.USER_ID;
			parameters[1].Value = model.RIGHT_ID;

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
			strSql.Append("delete from USER_RIGHT_MAP ");
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
		public PDTech.OA.Model.USER_RIGHT_MAP GetModel()
		{
			//该表无主键信息，请自定义主键/条件字段
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select USER_ID,RIGHT_ID from USER_RIGHT_MAP ");
			strSql.Append(" where ");
			SqlParameter[] parameters = {
			};

			PDTech.OA.Model.USER_RIGHT_MAP model=new PDTech.OA.Model.USER_RIGHT_MAP();
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
		public PDTech.OA.Model.USER_RIGHT_MAP DataRowToModel(DataRow row)
		{
			PDTech.OA.Model.USER_RIGHT_MAP model=new PDTech.OA.Model.USER_RIGHT_MAP();
			if (row != null)
			{
				if(row["USER_ID"]!=null && row["USER_ID"].ToString()!="")
				{
					model.USER_ID=decimal.Parse(row["USER_ID"].ToString());
				}
				if(row["RIGHT_ID"]!=null && row["RIGHT_ID"].ToString()!="")
				{
					model.RIGHT_ID=decimal.Parse(row["RIGHT_ID"].ToString());
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
			strSql.Append("select USER_ID,RIGHT_ID ");
			strSql.Append(" FROM USER_RIGHT_MAP ");
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
			strSql.Append("select count(1) FROM USER_RIGHT_MAP ");
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
        /// 获取全部用户权限绑定数据---未分页
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public IList<Model.USER_RIGHT_MAP> get_uPurviewList(Model.USER_RIGHT_MAP where)
        {
            string condition = DAL_Helper.GetWhereCondition(where);
            string strSQL = string.Format("SELECT * FROM USER_RIGHT_MAP  WHERE 1=1 {0} ", condition);
            DataTable dt = DbHelperSQL.GetTable(strSQL);
            return DAL_Helper.CommonFillList<Model.USER_RIGHT_MAP>(dt);
        }

        /// <summary>
        /// 事务添加用户权限
        /// </summary>
        /// <param name="kList"></param>
        /// <param name="user_Id"></param>
        /// <returns></returns>
        public int ExecuteSqlTran(IList<PDTech.OA.Model.USER_RIGHT_MAP> List, string HostName, string Ip, decimal operId)
        {
            int Flag = 0;
            try
            {
                string RightArr = "";
                ArrayList SQLStringList = new ArrayList();
                string delSQL = string.Format(@"delete from USER_RIGHT_MAP ");
                delSQL += string.Format(" where USER_ID={0}", List[0].USER_ID);
                SQLStringList.Add(delSQL);
                foreach (var item in List)
                {
                    string strSql = string.Format(@"insert into USER_RIGHT_MAP(");
                    strSql += string.Format(@"USER_ID,RIGHT_ID)");
                    strSql += string.Format(" values (");
                    strSql += string.Format("{0},{1})", item.USER_ID, item.RIGHT_ID);
                    RightArr += item.RIGHT_ID.ToString() + ",";
                    SQLStringList.Add(strSql);
                }
                DbHelperSQL.ExecuteSqlTran(SQLStringList);
                PDTech.OA.Model.OPERATION_LOG Qwhere = new Model.OPERATION_LOG();
                Qwhere.OPERATOR_USER = operId;
                Qwhere.OPERATION_TYPE =USER_RIGHT_UP;
                Qwhere.ENTITY_TYPE = (decimal)ENTITY_TYPE.用户; ;
                Qwhere.ENTITY_ID = decimal.Parse(List[0].USER_ID.ToString());
                Qwhere.HOST_IP = Ip;
                Qwhere.HOST_NAME = HostName;
                Qwhere.OPERATION_DESC = "修改用户权限:USER_ID=" + List[0].USER_ID.ToString() + "的用户权限被修改为:" + RightArr + "...";
                Qwhere.OPERATION_DATA = "";
                log.Add(Qwhere);
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

