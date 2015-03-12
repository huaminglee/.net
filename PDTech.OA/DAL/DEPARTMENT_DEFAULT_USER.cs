using System;
using System.Data;
using System.Text;
using System.Data.OracleClient;
using Maticsoft.DBUtility;
using System.Collections.Generic;
using System.Collections;
using System.Data.SqlClient;//Please add references

namespace PDTech.OA.DAL
{
	/// <summary>
	/// 数据访问类:DEPARTMENT_DEFAULT_USER
	/// </summary>
	public partial class DEPARTMENT_DEFAULT_USER
	{
		public DEPARTMENT_DEFAULT_USER()
		{}
		#region  BasicMethod



		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(PDTech.OA.Model.DEPARTMENT_DEFAULT_USER model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into DEPARTMENT_DEFAULT_USER(");
			strSql.Append("DEPARTMENT_ID,USER_ID)");
			strSql.Append(" values (");
			strSql.Append("@DEPARTMENT_ID,@USER_ID)");
            SqlParameter[] parameters = {
					new SqlParameter("@DEPARTMENT_ID", SqlDbType.Decimal,4),
					new SqlParameter("@USER_ID", SqlDbType.Decimal,4)};
			parameters[0].Value = model.DEPARTMENT_ID;
			parameters[1].Value = model.USER_ID;

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
		public bool Update(PDTech.OA.Model.DEPARTMENT_DEFAULT_USER model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update DEPARTMENT_DEFAULT_USER set ");
			strSql.Append("DEPARTMENT_ID=@DEPARTMENT_ID,");
			strSql.Append("USER_ID=@USER_ID");
			strSql.Append(" where ");
            SqlParameter[] parameters = {
					new SqlParameter("@DEPARTMENT_ID", SqlDbType.Decimal,4),
					new SqlParameter("@USER_ID", SqlDbType.Decimal,4)};
			parameters[0].Value = model.DEPARTMENT_ID;
			parameters[1].Value = model.USER_ID;

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
		public bool Delete()
		{
			//该表无主键信息，请自定义主键/条件字段
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from DEPARTMENT_DEFAULT_USER ");
			strSql.Append(" where ");
            SqlParameter[] parameters = {
			};

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
		/// 得到一个对象实体
		/// </summary>
		public PDTech.OA.Model.DEPARTMENT_DEFAULT_USER GetModel()
		{
			//该表无主键信息，请自定义主键/条件字段
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select DEPARTMENT_ID,USER_ID from DEPARTMENT_DEFAULT_USER ");
			strSql.Append(" where ");
            SqlParameter[] parameters = {
			};

			PDTech.OA.Model.DEPARTMENT_DEFAULT_USER model=new PDTech.OA.Model.DEPARTMENT_DEFAULT_USER();
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
		public PDTech.OA.Model.DEPARTMENT_DEFAULT_USER DataRowToModel(DataRow row)
		{
			PDTech.OA.Model.DEPARTMENT_DEFAULT_USER model=new PDTech.OA.Model.DEPARTMENT_DEFAULT_USER();
			if (row != null)
			{
				if(row["DEPARTMENT_ID"]!=null && row["DEPARTMENT_ID"].ToString()!="")
				{
					model.DEPARTMENT_ID=decimal.Parse(row["DEPARTMENT_ID"].ToString());
				}
				if(row["USER_ID"]!=null && row["USER_ID"].ToString()!="")
				{
					model.USER_ID=decimal.Parse(row["USER_ID"].ToString());
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
			strSql.Append("select DEPARTMENT_ID,USER_ID ");
			strSql.Append(" FROM DEPARTMENT_DEFAULT_USER ");
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
			strSql.Append("select count(1) FROM DEPARTMENT_DEFAULT_USER ");
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
        /// 事务添加部门默认指定人员
        /// </summary>
        /// <param name="kList"></param>
        /// <param name="user_Id"></param>
        /// <returns></returns>
        public int ExecuteSqlTran(IList<PDTech.OA.Model.DEPARTMENT_DEFAULT_USER> List)
        {
            int Flag = 0;
            try
            {
                ArrayList SQLStringList = new ArrayList();
                string delSQL = string.Format(@"DELETE FROM DEPARTMENT_DEFAULT_USER ");
                delSQL += string.Format(" WHERE DEPARTMENT_ID={0}", List[0].DEPARTMENT_ID);
                SQLStringList.Add(delSQL);
                foreach (var item in List)
                {
                    string strSql = string.Format(@"insert into DEPARTMENT_DEFAULT_USER(");
                    strSql += string.Format(@"DEPARTMENT_ID,USER_ID)");
                    strSql += string.Format(" values (");
                    strSql += string.Format("{0},{1})", item.DEPARTMENT_ID, item.USER_ID);
                    SQLStringList.Add(strSql);
                }
                DbHelperSQL.ExecuteSqlTran(SQLStringList);
                return Flag = 1;
            }
            catch (Exception ex)
            { Flag = -1; }
            return Flag;
        }

        /// <summary>
        /// 获取全部部门信息
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public Model.DEPARTMENT_DEFAULT_USER get_uDeptList(decimal deptId)
        {
            string strSQL = string.Format("SELECT * FROM DEPARTMENT_DEFAULT_USER WHERE DEPARTMENT_ID={0}", deptId);
            DataTable dt = DbHelperSQL.GetTable(strSQL);
            if (dt.Rows.Count > 0)
            {
                return DAL_Helper.CommonFillList<Model.DEPARTMENT_DEFAULT_USER>(dt)[0];
            }
            else
            {
                return null;
            }
        }
		#endregion  BasicMethod
		#region  ExtensionMethod

		#endregion  ExtensionMethod
	}
}

