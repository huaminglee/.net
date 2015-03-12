using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;
using System.Collections.Generic;//Please add references
namespace PDTech.OA.DAL
{
	/// <summary>
	/// 数据访问类:ROLE_INFO
	/// </summary>
	public partial class ROLE_INFO
	{
		public ROLE_INFO()
		{}
        OPERATION_LOG log = new OPERATION_LOG();
        const string ROLE_CREATE = "ROLE_CREATE";
        const string ROLE_UP = "ROLE_UP";
		#region  BasicMethod

		/// <summary>
		/// 是否存在该记录
		/// </summary>
        public bool Exists(string ROLE_NAME)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from ROLE_INFO");
            strSql.Append(" where ROLE_NAME=@ROLE_NAME ");
			SqlParameter[] parameters = {
					new SqlParameter("@ROLE_NAME", SqlDbType.NVarChar)			};
            parameters[0].Value = ROLE_NAME;
            DAL_Helper.get_db_para_value(parameters);
			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string ROLE_NAME, decimal ROLE_ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from ROLE_INFO");
            strSql.Append(" where ROLE_NAME=@ROLE_NAME AND ROLE_ID<>@ROLE_ID");
            SqlParameter[] parameters = {
					new SqlParameter("@ROLE_NAME", SqlDbType.NVarChar),
                                           new SqlParameter("@ROLE_ID", SqlDbType.Decimal,4)};
            parameters[0].Value = ROLE_NAME;
            parameters[1].Value = ROLE_ID;
            DAL_Helper.get_db_para_value(parameters);
            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(PDTech.OA.Model.ROLE_INFO model,string HostName,string Ip,decimal operId)
		{
            if (Exists(model.ROLE_NAME))
            {
                return -1;
            }
            string reruneVal = "";
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into ROLE_INFO(");
			strSql.Append("ROLE_NAME,ROLE_DESC)");
			strSql.Append(" values (");
            strSql.Append("@ROLE_NAME,@ROLE_DESC) select @OUT_LOG_ID = SCOPE_IDENTITY() ");
            SqlParameter rid_out = new SqlParameter("@OUT_LOG_ID", SqlDbType.Int);
            rid_out.Direction = ParameterDirection.Output;
			SqlParameter[] parameters = {
					new SqlParameter("@ROLE_NAME", SqlDbType.VarChar,100),
					new SqlParameter("@ROLE_DESC", SqlDbType.VarChar,500),
                                           rid_out};
			parameters[0].Value = model.ROLE_NAME;
			parameters[1].Value = model.ROLE_DESC;
            DAL_Helper.get_db_para_value(parameters);
			int rows=DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
            reruneVal = rid_out.Value.ToString();
			if (rows > 0)
			{
                PDTech.OA.Model.OPERATION_LOG Qwhere = new Model.OPERATION_LOG();
                Qwhere.OPERATOR_USER = operId;
                Qwhere.OPERATION_TYPE = ROLE_CREATE;
                Qwhere.ENTITY_TYPE = (decimal)ENTITY_TYPE.角色;
                Qwhere.ENTITY_ID = decimal.Parse(reruneVal);
                Qwhere.HOST_IP = Ip;
                Qwhere.HOST_NAME = HostName;
                Qwhere.OPERATION_DESC = "新增角色:ROLE_NAME=" + model.ROLE_NAME + ",ROLE_DESC=" + model.ROLE_DESC+"...";
                Qwhere.OPERATION_DATA = "";
                log.Add(Qwhere);
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
		public int Update(PDTech.OA.Model.ROLE_INFO model,string HostName,string Ip,decimal operId)
		{
            if (Exists(model.ROLE_NAME, model.ROLE_ID))
            {
                return -1;
            }
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update ROLE_INFO set ");
			strSql.Append("ROLE_NAME=@ROLE_NAME,");
			strSql.Append("ROLE_DESC=@ROLE_DESC");
			strSql.Append(" where ROLE_ID=@ROLE_ID ");
			SqlParameter[] parameters = {
					new SqlParameter("@ROLE_NAME", SqlDbType.VarChar,100),
					new SqlParameter("@ROLE_DESC", SqlDbType.VarChar,500),
					new SqlParameter("@ROLE_ID", SqlDbType.Decimal,4)};
			parameters[0].Value = model.ROLE_NAME;
			parameters[1].Value = model.ROLE_DESC;
			parameters[2].Value = model.ROLE_ID;
            DAL_Helper.get_db_para_value(parameters);
			int rows=DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
			if (rows > 0)
			{

                PDTech.OA.Model.OPERATION_LOG Qwhere = new Model.OPERATION_LOG();
                Qwhere.OPERATOR_USER = operId;
                Qwhere.OPERATION_TYPE = ROLE_UP;
                Qwhere.ENTITY_TYPE = (decimal)ENTITY_TYPE.角色;
                Qwhere.ENTITY_ID = model.ROLE_ID;
                Qwhere.HOST_IP = Ip;
                Qwhere.HOST_NAME = HostName;
                Qwhere.OPERATION_DESC = "修改角色:ROLE_NAME=" + model.ROLE_NAME + ",ROLE_DESC=" + model.ROLE_DESC + "...";
                Qwhere.OPERATION_DATA = "";
                log.Add(Qwhere);
				return 1;
			}
			else
			{
				return 0;
			}
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(decimal ROLE_ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from ROLE_INFO ");
			strSql.Append(" where ROLE_ID=@ROLE_ID ");
			SqlParameter[] parameters = {
					new SqlParameter("@ROLE_ID", SqlDbType.Decimal,22)			};
			parameters[0].Value = ROLE_ID;

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
		public bool DeleteList(string ROLE_IDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from ROLE_INFO ");
			strSql.Append(" where ROLE_ID in ("+ROLE_IDlist + ")  ");
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
		public PDTech.OA.Model.ROLE_INFO GetModel(decimal ROLE_ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ROLE_ID,ROLE_NAME,ROLE_DESC from ROLE_INFO ");
			strSql.Append(" where ROLE_ID=@ROLE_ID ");
			SqlParameter[] parameters = {
					new SqlParameter("@ROLE_ID", SqlDbType.Decimal,22)			};
			parameters[0].Value = ROLE_ID;

			PDTech.OA.Model.ROLE_INFO model=new PDTech.OA.Model.ROLE_INFO();
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
		public PDTech.OA.Model.ROLE_INFO DataRowToModel(DataRow row)
		{
			PDTech.OA.Model.ROLE_INFO model=new PDTech.OA.Model.ROLE_INFO();
			if (row != null)
			{
				if(row["ROLE_ID"]!=null && row["ROLE_ID"].ToString()!="")
				{
					model.ROLE_ID=decimal.Parse(row["ROLE_ID"].ToString());
				}
				if(row["ROLE_NAME"]!=null)
				{
					model.ROLE_NAME=row["ROLE_NAME"].ToString();
				}
				if(row["ROLE_DESC"]!=null)
				{
					model.ROLE_DESC=row["ROLE_DESC"].ToString();
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
			strSql.Append("select ROLE_ID,ROLE_NAME,ROLE_DESC ");
			strSql.Append(" FROM ROLE_INFO ");
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
			strSql.Append("select count(1) FROM ROLE_INFO ");
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
        /// 获取角色信息列表-使用分页
        /// </summary>
        /// <param name="where"></param>
        /// <param name="currentpage"></param>
        /// <param name="pagesize"></param>
        /// <param name="totalrecord"></param>
        /// <returns></returns>
        public IList<Model.ROLE_INFO> get_Paging_RoleInfoList(Model.ROLE_INFO where, int currentpage, int pagesize, out int totalrecord)
        {
            string condition = DAL_Helper.GetWhereCondition(where);
            string strSQL = string.Format("SELECT TOP (100) PERCENT * FROM ROLE_INFO WHERE 1=1 {0} ", condition);
            PageDescribe pdes = new PageDescribe();
            pdes.CurrentPage = currentpage;
            pdes.PageSize = pagesize;
            DataTable dt = pdes.PageDescribes(strSQL);
            totalrecord = pdes.RecordCount;
            return DAL_Helper.CommonFillList<Model.ROLE_INFO>(dt);
        }
        /// <summary>
        /// 获取一条角色信息
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public Model.ROLE_INFO GetRoleInfo(decimal uId)
        {
            string strSQL = string.Format("SELECT * FROM ROLE_INFO WHERE ROLE_ID={0}", uId);
            DataTable dt = DbHelperSQL.GetTable(strSQL);
            if (dt.Rows.Count > 0)
            {
                return DAL_Helper.CommonFillList<Model.ROLE_INFO>(dt)[0];
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 获取全部角色信息---未分页
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public IList<Model.ROLE_INFO> get_RoleList(Model.ROLE_INFO where)
        {
            string condition = DAL_Helper.GetWhereCondition(where);
            string strSQL = string.Format("SELECT * FROM ROLE_INFO  WHERE 1=1 {0} ", condition);
            DataTable dt = DbHelperSQL.GetTable(strSQL);
            return DAL_Helper.CommonFillList<Model.ROLE_INFO>(dt);
        }

		#endregion  BasicMethod
		#region  ExtensionMethod

		#endregion  ExtensionMethod
	}
}

