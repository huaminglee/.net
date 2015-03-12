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
	/// 数据访问类:DEPARTMENT
	/// </summary>
	public partial class DEPARTMENT
	{
		public DEPARTMENT()
		{}
        OPERATION_LOG log = new OPERATION_LOG();
        const string DEPT_CREATE = "DEPT_CREATE";
        const string DEPT_UP = "DEPT_UP";
		#region  BasicMethod

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(decimal DEPARTMENT_ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from DEPARTMENT");
			strSql.Append(" where DEPARTMENT_ID=@DEPARTMENT_ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@DEPARTMENT_ID", SqlDbType.Decimal,22)			};
			parameters[0].Value = DEPARTMENT_ID;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}

        public object get_db_para_value(object in_p)
        {
            if (in_p == null)
                return DBNull.Value;
            else
                return in_p;
        }

		/// <summary>
		/// 增加一条数据
		/// </summary>
        public bool Add(PDTech.OA.Model.DEPARTMENT model, string HostName, string Ip, decimal operId)
		{
            string reruneVal = "";
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into DEPARTMENT(");
			strSql.Append("DEPARTMENT_NAME,DEPARTMENT_JC,REMARK,DEPARTMENT_LEVEL,PARENT_ID,ATTRIBUTE_LOG,SORT_NUM,OUT_RELATED_ID,IS_DISABLE)");
			strSql.Append(" values (");
            strSql.Append("@DEPARTMENT_NAME,@DEPARTMENT_JC,@REMARK,@DEPARTMENT_LEVEL,@PARENT_ID,@ATTRIBUTE_LOG,@SORT_NUM,@OUT_RELATED_ID,@IS_DISABLE);select @OUT_LOG_ID = SCOPE_IDENTITY() ");
            SqlParameter uid_out = new SqlParameter("@OUT_LOG_ID", SqlDbType.Int);
            uid_out.Direction = ParameterDirection.Output;
            SqlParameter[] parameters = {
					new SqlParameter("@DEPARTMENT_NAME", SqlDbType.VarChar,100),
					new SqlParameter("@DEPARTMENT_JC", SqlDbType.VarChar,100),
					new SqlParameter("@REMARK", SqlDbType.VarChar,500),
					new SqlParameter("@DEPARTMENT_LEVEL", SqlDbType.Decimal,4),
					new SqlParameter("@PARENT_ID", SqlDbType.Decimal,4),
					new SqlParameter("@ATTRIBUTE_LOG", SqlDbType.Decimal,4),
					new SqlParameter("@SORT_NUM", SqlDbType.Decimal,4),
					new SqlParameter("@OUT_RELATED_ID", SqlDbType.VarChar,50),
					new SqlParameter("@IS_DISABLE", SqlDbType.Char,1),
                                       uid_out };
            parameters[0].Value = get_db_para_value(model.DEPARTMENT_NAME);
            parameters[1].Value = get_db_para_value(model.DEPARTMENT_JC);
			parameters[2].Value = get_db_para_value(model.REMARK);
			parameters[3].Value = get_db_para_value(model.DEPARTMENT_LEVEL.HasValue);
            parameters[4].Value = get_db_para_value(model.PARENT_ID);
            parameters[5].Value = get_db_para_value(model.ATTRIBUTE_LOG);
            parameters[6].Value = get_db_para_value(model.SORT_NUM);
            parameters[7].Value = get_db_para_value(model.OUT_RELATED_ID);
            parameters[8].Value = get_db_para_value(model.IS_DISABLE);
            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
            reruneVal = uid_out.Value.ToString();
			if (rows > 0)
			{
                PDTech.OA.Model.OPERATION_LOG Qwhere = new Model.OPERATION_LOG();
                Qwhere.OPERATOR_USER = operId;
                Qwhere.OPERATION_TYPE = DEPT_CREATE;
                Qwhere.ENTITY_TYPE = (decimal)ENTITY_TYPE.部门;
                Qwhere.ENTITY_ID = decimal.Parse(reruneVal);
                Qwhere.HOST_IP = Ip;
                Qwhere.HOST_NAME = HostName;
                Qwhere.OPERATION_DESC = "新增数据:DEPARTMENT_NAME=" + model.DEPARTMENT_NAME + ",DEPARTMENT_JC=" + model.DEPARTMENT_JC + ",REMARK=" + model.REMARK + ",SORT_NUM=" + model.SORT_NUM + "...";
                Qwhere.OPERATION_DATA = "";
                log.Add(Qwhere);
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
        public bool Update(PDTech.OA.Model.DEPARTMENT model, string HostName, string Ip, decimal operId)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update DEPARTMENT set ");
			strSql.Append("DEPARTMENT_NAME=@DEPARTMENT_NAME,");
			strSql.Append("DEPARTMENT_JC=@DEPARTMENT_JC,");
			strSql.Append("REMARK=@REMARK,");
			strSql.Append("DEPARTMENT_LEVEL=@DEPARTMENT_LEVEL,");
			strSql.Append("PARENT_ID=@PARENT_ID,");
			strSql.Append("ATTRIBUTE_LOG=@ATTRIBUTE_LOG,");
			strSql.Append("SORT_NUM=@SORT_NUM,");
			strSql.Append("OUT_RELATED_ID=@OUT_RELATED_ID,");
			strSql.Append("IS_DISABLE=@IS_DISABLE");
			strSql.Append(" where DEPARTMENT_ID=@DEPARTMENT_ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@DEPARTMENT_NAME", SqlDbType.VarChar,100),
					new SqlParameter("@DEPARTMENT_JC", SqlDbType.VarChar,100),
					new SqlParameter("@REMARK", SqlDbType.VarChar,500),
					new SqlParameter("@DEPARTMENT_LEVEL", SqlDbType.Decimal,4),
					new SqlParameter("@PARENT_ID", SqlDbType.Decimal,4),
					new SqlParameter("@ATTRIBUTE_LOG", SqlDbType.Decimal,4),
					new SqlParameter("@SORT_NUM", SqlDbType.Decimal,4),
					new SqlParameter("@OUT_RELATED_ID", SqlDbType.VarChar,50),
					new SqlParameter("@IS_DISABLE", SqlDbType.Char,1),
					new SqlParameter("@DEPARTMENT_ID", SqlDbType.Decimal,4)};
            parameters[0].Value = get_db_para_value(model.DEPARTMENT_NAME);
            parameters[1].Value = get_db_para_value(model.DEPARTMENT_JC);
            parameters[2].Value = get_db_para_value(model.REMARK);
            parameters[3].Value = get_db_para_value(model.DEPARTMENT_LEVEL);
            parameters[4].Value = get_db_para_value(model.PARENT_ID);
            parameters[5].Value = get_db_para_value(model.ATTRIBUTE_LOG);
            parameters[6].Value = get_db_para_value(model.SORT_NUM);
            parameters[7].Value = get_db_para_value(model.OUT_RELATED_ID);
            parameters[8].Value = get_db_para_value(model.IS_DISABLE);
            parameters[9].Value = get_db_para_value(model.DEPARTMENT_ID);

			int rows=DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
			if (rows > 0)
			{
                PDTech.OA.Model.OPERATION_LOG Qwhere = new Model.OPERATION_LOG();
                Qwhere.OPERATOR_USER = operId;
                Qwhere.OPERATION_TYPE = DEPT_UP;
                Qwhere.ENTITY_TYPE = (decimal)ENTITY_TYPE.部门;
                Qwhere.ENTITY_ID = model.DEPARTMENT_ID;
                Qwhere.HOST_IP = Ip;
                Qwhere.HOST_NAME = HostName;
                Qwhere.OPERATION_DESC = "修改数据:DEPARTMENT_NAME=" + model.DEPARTMENT_NAME + ",DEPARTMENT_JC=" + model.DEPARTMENT_JC + ",REMARK=" + model.REMARK + ",SORT_NUM=" + model.SORT_NUM+"...";
                Qwhere.OPERATION_DATA = "";
                log.Add(Qwhere);
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
		public bool Delete(decimal DEPARTMENT_ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from DEPARTMENT ");
			strSql.Append(" where DEPARTMENT_ID=@DEPARTMENT_ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@DEPARTMENT_ID", SqlDbType.Decimal,22)			};
			parameters[0].Value = DEPARTMENT_ID;

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
		public bool DeleteList(string DEPARTMENT_IDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from DEPARTMENT ");
			strSql.Append(" where DEPARTMENT_ID in ("+DEPARTMENT_IDlist + ")  ");
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
		public PDTech.OA.Model.DEPARTMENT GetModel(decimal DEPARTMENT_ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select DEPARTMENT_ID,DEPARTMENT_NAME,DEPARTMENT_JC,REMARK,DEPARTMENT_LEVEL,PARENT_ID,ATTRIBUTE_LOG,SORT_NUM,OUT_RELATED_ID,IS_DISABLE from DEPARTMENT ");
			strSql.Append(" where DEPARTMENT_ID=@DEPARTMENT_ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@DEPARTMENT_ID", SqlDbType.Decimal,22)			};
			parameters[0].Value = DEPARTMENT_ID;

			PDTech.OA.Model.DEPARTMENT model=new PDTech.OA.Model.DEPARTMENT();
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
		public PDTech.OA.Model.DEPARTMENT DataRowToModel(DataRow row)
		{
			PDTech.OA.Model.DEPARTMENT model=new PDTech.OA.Model.DEPARTMENT();
			if (row != null)
			{
				if(row["DEPARTMENT_ID"]!=null && row["DEPARTMENT_ID"].ToString()!="")
				{
					model.DEPARTMENT_ID=decimal.Parse(row["DEPARTMENT_ID"].ToString());
				}
				if(row["DEPARTMENT_NAME"]!=null)
				{
					model.DEPARTMENT_NAME=row["DEPARTMENT_NAME"].ToString();
				}
				if(row["DEPARTMENT_JC"]!=null)
				{
					model.DEPARTMENT_JC=row["DEPARTMENT_JC"].ToString();
				}
				if(row["REMARK"]!=null)
				{
					model.REMARK=row["REMARK"].ToString();
				}
				if(row["DEPARTMENT_LEVEL"]!=null && row["DEPARTMENT_LEVEL"].ToString()!="")
				{
					model.DEPARTMENT_LEVEL=decimal.Parse(row["DEPARTMENT_LEVEL"].ToString());
				}
				if(row["PARENT_ID"]!=null && row["PARENT_ID"].ToString()!="")
				{
					model.PARENT_ID=decimal.Parse(row["PARENT_ID"].ToString());
				}
				if(row["ATTRIBUTE_LOG"]!=null && row["ATTRIBUTE_LOG"].ToString()!="")
				{
					model.ATTRIBUTE_LOG=decimal.Parse(row["ATTRIBUTE_LOG"].ToString());
				}
				if(row["SORT_NUM"]!=null && row["SORT_NUM"].ToString()!="")
				{
					model.SORT_NUM=decimal.Parse(row["SORT_NUM"].ToString());
				}
				if(row["OUT_RELATED_ID"]!=null)
				{
					model.OUT_RELATED_ID=row["OUT_RELATED_ID"].ToString();
				}
				if(row["IS_DISABLE"]!=null)
				{
					model.IS_DISABLE=row["IS_DISABLE"].ToString();
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
			strSql.Append("select DEPARTMENT_ID,DEPARTMENT_NAME,DEPARTMENT_JC,REMARK,DEPARTMENT_LEVEL,PARENT_ID,ATTRIBUTE_LOG,SORT_NUM,OUT_RELATED_ID,IS_DISABLE ");
			strSql.Append(" FROM DEPARTMENT ");
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
			strSql.Append("select count(1) FROM DEPARTMENT ");
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
        /// 获取全部部门信息---未分页
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public IList<Model.DEPARTMENT> get_DeptList(Model.DEPARTMENT where)
        {
            string condition = DAL_Helper.GetWhereCondition(where);
            string strSQL = string.Format("SELECT * FROM DEPARTMENT  WHERE 1=1 {0} ", condition);
            DataTable dt = DbHelperSQL.GetTable(strSQL);
            return DAL_Helper.CommonFillList<Model.DEPARTMENT>(dt);
        }

        /// <summary>
        /// 获取全部部门信息--返回dataTable
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public DataTable get_DeptTab(Model.DEPARTMENT where)
        {
            string condition = DAL_Helper.GetWhereCondition(where);
            string strSQL = string.Format("SELECT de.*,(SELECT DEPARTMENT_NAME from DEPARTMENT where DEPARTMENT_ID= DE.PARENT_ID) PARENT_NAME FROM DEPARTMENT de WHERE 1=1 {0} ", condition);
            DataTable dt = DbHelperSQL.GetTable(strSQL);
            return dt;
        }
        /// <summary>
        /// 获取全部部门信息
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public Model.DEPARTMENT GetDeptInfo(decimal deptId)
        {
            string strSQL = string.Format("SELECT de.*,(SELECT DEPARTMENT_NAME from DEPARTMENT where DEPARTMENT_ID= DE.PARENT_ID) PARENT_NAME FROM DEPARTMENT de WHERE DEPARTMENT_ID={0}", deptId);
            DataTable dt = DbHelperSQL.GetTable(strSQL);
            if (dt.Rows.Count> 0)
            {
                return DAL_Helper.CommonFillList<Model.DEPARTMENT>(dt)[0];
            }
            else
            {
                return null;
            }
        }
        /// <summary>
        /// 获取全部部门信息-使用分页
        /// </summary>
        /// <param name="where"></param>
        /// <param name="currentpage"></param>
        /// <param name="pagesize"></param>
        /// <param name="totalrecord"></param>
        /// <returns></returns>
        public IList<Model.DEPARTMENT> get_Paging_DeptList(Model.DEPARTMENT where, int currentpage, int pagesize, out int totalrecord)
        {
            string condition = DAL_Helper.GetWhereCondition(where);
            string strSQL = string.Format("SELECT  TOP (100) PERCENT * FROM DEPARTMENT  WHERE 1=1 {0} ", condition);
            PageDescribe pdes = new PageDescribe();
            pdes.CurrentPage = currentpage;
            pdes.PageSize = pagesize;
            DataTable dt = pdes.PageDescribes(strSQL);
            totalrecord = pdes.RecordCount;
            return DAL_Helper.CommonFillList<Model.DEPARTMENT>(dt);
        }
        /// <summary>
        /// 修改部门是否显示
        /// </summary>
        /// <param name="deptId">部门ID</param>
        /// <param name="disType">修改值</param>
        /// <returns></returns>
        public int ModDisable(decimal deptId,string disType)
        {
            int result=0;
            string ModSQL = string.Format(@"UPDATE DEPARTMENT SET IS_DISABLE='{0}' WHERE DEPARTMENT_ID={1}", disType, deptId);
            result = DbHelperSQL.ExecuteSql(ModSQL);
            return result;
        }
        /// <summary>
        /// 查询部门单位_默认人员
        /// </summary>
        /// <returns>部门单位</returns>
        public DataTable GetDepartment_DefaultUser()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from VIEW_DEPARTMENT_DEFAULT_USER ORDER BY SORT_NUM ASC");
            return DbHelperSQL.GetTable(strSql.ToString());
        }
        /// <summary>
        /// 获取SEQ
        /// </summary>
        /// <returns></returns>
        public int getSEQ()
        {
            int result = 0;
            string ModSQL = string.Format(@"SELECT RISK_HANDLE_NO_SEQ.NEXTVAL FROM DUAL");
            result = DbHelperSQL.GetScalar(ModSQL);
            return result;
        }
		#endregion  BasicMethod
		#region  ExtensionMethod

		#endregion  ExtensionMethod
	}
}

