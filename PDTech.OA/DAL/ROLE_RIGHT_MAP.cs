using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;
using System.Collections.Generic;
using System.Collections;//Please add references
namespace PDTech.OA.DAL
{
	/// <summary>
	/// 数据访问类:ROLE_RIGHT_MAP
	/// </summary>
	public partial class ROLE_RIGHT_MAP
	{
		public ROLE_RIGHT_MAP()
		{}
        OPERATION_LOG log = new OPERATION_LOG();
        const string ROLE_RIGHT_UP = "ROLE_RIGHT_UP";
		#region  BasicMethod



		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(PDTech.OA.Model.ROLE_RIGHT_MAP model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into ROLE_RIGHT_MAP(");
			strSql.Append("ROLE_ID,RIGHT_ID)");
			strSql.Append(" values (");
			strSql.Append("@ROLE_ID,@RIGHT_ID)");
			SqlParameter[] parameters = {
					new SqlParameter("@ROLE_ID", SqlDbType.Decimal,4),
					new SqlParameter("@RIGHT_ID", SqlDbType.Decimal,4)};
			parameters[0].Value = model.ROLE_ID;
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
		public bool Update(PDTech.OA.Model.ROLE_RIGHT_MAP model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update ROLE_RIGHT_MAP set ");
			strSql.Append("ROLE_ID=@ROLE_ID,");
			strSql.Append("RIGHT_ID=@RIGHT_ID");
			strSql.Append(" where ");
			SqlParameter[] parameters = {
					new SqlParameter("@ROLE_ID", SqlDbType.Decimal,4),
					new SqlParameter("@RIGHT_ID", SqlDbType.Decimal,4)};
			parameters[0].Value = model.ROLE_ID;
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
			strSql.Append("delete from ROLE_RIGHT_MAP ");
            strSql.Append(" where");
			SqlParameter[] parameters = {
			};
            DAL_Helper.get_db_para_value(parameters);
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
        /// 删除角色-权限关系数据
        /// </summary>
        /// <returns></returns>
        public bool DeleteBy_RoleId(decimal rId)
        {
            //该表无主键信息，请自定义主键/条件字段
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from ROLE_RIGHT_MAP ");
            strSql.Append(" where ROLE_ID=@ROLE_ID");
            SqlParameter[] parameters = {
                                               	new SqlParameter("@ROLE_ID", SqlDbType.Decimal,4),
			};
            parameters[0].Value = rId;
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
		/// 得到一个对象实体
		/// </summary>
		public PDTech.OA.Model.ROLE_RIGHT_MAP GetModel()
		{
			//该表无主键信息，请自定义主键/条件字段
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ROLE_ID,RIGHT_ID from ROLE_RIGHT_MAP ");
			strSql.Append(" where ");
			SqlParameter[] parameters = {
			};

			PDTech.OA.Model.ROLE_RIGHT_MAP model=new PDTech.OA.Model.ROLE_RIGHT_MAP();
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
		public PDTech.OA.Model.ROLE_RIGHT_MAP DataRowToModel(DataRow row)
		{
			PDTech.OA.Model.ROLE_RIGHT_MAP model=new PDTech.OA.Model.ROLE_RIGHT_MAP();
			if (row != null)
			{
				if(row["ROLE_ID"]!=null && row["ROLE_ID"].ToString()!="")
				{
					model.ROLE_ID=decimal.Parse(row["ROLE_ID"].ToString());
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
			strSql.Append("select ROLE_ID,RIGHT_ID ");
			strSql.Append(" FROM ROLE_RIGHT_MAP ");
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
			strSql.Append("select count(1) FROM ROLE_RIGHT_MAP ");
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
        /// 事务添加角色权限
        /// </summary>
        /// <param name="kList"></param>
        /// <param name="user_Id"></param>
        /// <returns></returns>
        public int ExecuteSqlTran(IList<PDTech.OA.Model.ROLE_RIGHT_MAP> List, string HostName, string Ip, decimal operId)
        {
            int Flag = 0;
            try
            {
                string rIDArr = "";
                ArrayList SQLStringList = new ArrayList();
                string delSQL=string.Format(@"delete from ROLE_RIGHT_MAP ");
                delSQL += string.Format(" where ROLE_ID={0}", List[0].ROLE_ID);
                SQLStringList.Add(delSQL);
                foreach (var item in List)
                {
                    string strSql = string.Format(@"insert into ROLE_RIGHT_MAP(");
                    strSql+=string.Format(@"ROLE_ID,RIGHT_ID)");
                    strSql+=string.Format(" values (");
                    strSql+=string.Format("{0},{1})",item.ROLE_ID,item.RIGHT_ID);
                    rIDArr += item.RIGHT_ID.ToString() + ",";
                    SQLStringList.Add(strSql); 
                }
                DbHelperSQL.ExecuteSqlTran(SQLStringList);
                PDTech.OA.Model.OPERATION_LOG Qwhere = new Model.OPERATION_LOG();
                Qwhere.OPERATOR_USER = operId;
                Qwhere.OPERATION_TYPE = ROLE_RIGHT_UP;
                Qwhere.ENTITY_TYPE = (decimal)ENTITY_TYPE.角色;
                Qwhere.ENTITY_ID = decimal.Parse(List[0].ROLE_ID.ToString());
                Qwhere.HOST_IP = Ip;
                Qwhere.HOST_NAME = HostName;
                Qwhere.OPERATION_DESC = "修改角色权限:ROLE_ID=" + List[0].ROLE_ID.ToString() + "的角色权限被修改为" + rIDArr + "...";
                Qwhere.OPERATION_DATA = "";
                log.Add(Qwhere);
                return Flag = 1;
            }
            catch (Exception ex)
            { Flag = -1; }
            return Flag;
        }

        /// <summary>
        /// 获取全部角色权限绑定数据---未分页
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public IList<Model.ROLE_RIGHT_MAP> get_rPurviewList(decimal rId)
        {
            string strSQL = string.Format("SELECT * FROM ROLE_RIGHT_MAP  WHERE 1=1 AND ROLE_ID={0} ", rId);
            DataTable dt = DbHelperSQL.GetTable(strSQL);
            return DAL_Helper.CommonFillList<Model.ROLE_RIGHT_MAP>(dt);
        }
		#endregion  BasicMethod
		#region  ExtensionMethod

		#endregion  ExtensionMethod
	}
}

