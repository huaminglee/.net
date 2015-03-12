using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;
using System.Collections.Generic;//Please add references
namespace PDTech.OA.DAL
{
	/// <summary>
	/// 数据访问类:RIGHT_INFO
	/// </summary>
	public partial class RIGHT_INFO
	{
        OPERATION_LOG log = new OPERATION_LOG();
        const string RIGHT_CREATE = "RIGHT_CREATE";
        const string RIGHT_UP = "RIGHT_UP";
		public RIGHT_INFO()
		{}
		#region  BasicMethod

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(decimal RIGHT_ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from RIGHT_INFO");
			strSql.Append(" where RIGHT_ID=@RIGHT_ID ");
			SqlParameter[] parameters = {
					new SqlParameter("@RIGHT_ID", SqlDbType.Decimal,22)			};
			parameters[0].Value = RIGHT_ID;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string RIGHT_CODE)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from RIGHT_INFO");
            strSql.Append(" where RIGHT_CODE=@RIGHT_CODE ");
            SqlParameter[] parameters = {
					new SqlParameter("@RIGHT_CODE", SqlDbType.VarChar,20)			};
            parameters[0].Value = RIGHT_CODE;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(PDTech.OA.Model.RIGHT_INFO model,string HostName,string Ip,decimal operId)
		{
            int intFlag = 0;
            try
            {
                if (Exists(model.RIGHT_CODE))
                {
                    return -2;
                }
                string reruneVal = "";
                StringBuilder strSql = new StringBuilder();
                strSql.Append("insert into RIGHT_INFO(");
                strSql.Append("RIGHT_CODE,RIGHT_NAME,PARENT_ID,SORT_NUM,RIGHT_DESC)");
                strSql.Append(" values (");
                strSql.Append("@RIGHT_CODE,@RIGHT_NAME,@PARENT_ID,@SORT_NUM,@RIGHT_DESC) select @OUT_LOG_ID = SCOPE_IDENTITY() ");
                SqlParameter rid_out = new SqlParameter("@OUT_LOG_ID", SqlDbType.Int);
                rid_out.Direction = ParameterDirection.Output;
                SqlParameter[] parameters = {
					new SqlParameter("@RIGHT_CODE", SqlDbType.VarChar,20),
					new SqlParameter("@RIGHT_NAME", SqlDbType.VarChar,100),
					new SqlParameter("@PARENT_ID", SqlDbType.Decimal,4),
					new SqlParameter("@SORT_NUM", SqlDbType.Decimal,4),
					new SqlParameter("@RIGHT_DESC", SqlDbType.VarChar,500),
                                               rid_out};
                parameters[0].Value = model.RIGHT_CODE;
                parameters[1].Value = model.RIGHT_NAME;
                parameters[2].Value = model.PARENT_ID;
                parameters[3].Value = model.SORT_NUM;
                parameters[4].Value = model.RIGHT_DESC;
                DAL_Helper.get_db_para_value(parameters);
                int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
                reruneVal = rid_out.Value.ToString();
                if (rows > 0)
                {
                    PDTech.OA.Model.OPERATION_LOG Qwhere = new Model.OPERATION_LOG();
                    Qwhere.OPERATOR_USER = operId;
                    Qwhere.OPERATION_TYPE =RIGHT_CREATE;
                    Qwhere.ENTITY_TYPE = (decimal)ENTITY_TYPE.权限;
                    Qwhere.ENTITY_ID = decimal.Parse(reruneVal);
                    Qwhere.HOST_IP = Ip;
                    Qwhere.HOST_NAME = HostName;
                    Qwhere.OPERATION_DESC = "新增权限:RIGHT_NAME=" + model.RIGHT_NAME + ",RIGHT_DESC=" + model.RIGHT_DESC + "...";
                    Qwhere.OPERATION_DATA = "";
                    log.Add(Qwhere);
                    intFlag = 1;
                }
                else
                {
                    intFlag =0;
                }
            }
            catch (Exception ex)
            {
               return  -1;
            }
            return intFlag;
		}
		/// <summary>
		/// 更新一条数据
		/// </summary>
        public int Update(PDTech.OA.Model.RIGHT_INFO model, string HostName, string Ip, decimal operId)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update RIGHT_INFO set ");
			strSql.Append("RIGHT_NAME=@RIGHT_NAME,");
			strSql.Append("PARENT_ID=@PARENT_ID,");
			strSql.Append("SORT_NUM=@SORT_NUM,");
			strSql.Append("RIGHT_DESC=@RIGHT_DESC");
			strSql.Append(" where RIGHT_ID=@RIGHT_ID ");
			SqlParameter[] parameters = {
					new SqlParameter("@RIGHT_NAME", SqlDbType.VarChar,100),
					new SqlParameter("@PARENT_ID", SqlDbType.Decimal,4),
					new SqlParameter("@SORT_NUM", SqlDbType.Decimal,4),
					new SqlParameter("@RIGHT_DESC", SqlDbType.VarChar,500),
					new SqlParameter("@RIGHT_ID", SqlDbType.Decimal,4)};
			parameters[0].Value = model.RIGHT_NAME;
			parameters[1].Value = model.PARENT_ID;
			parameters[2].Value = model.SORT_NUM;
			parameters[3].Value = model.RIGHT_DESC;
			parameters[4].Value = model.RIGHT_ID;
            DAL_Helper.get_db_para_value(parameters);
			int rows=DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
			if (rows > 0)
			{
                PDTech.OA.Model.OPERATION_LOG Qwhere = new Model.OPERATION_LOG();
                Qwhere.OPERATOR_USER = operId;
                Qwhere.OPERATION_TYPE = RIGHT_UP;
                Qwhere.ENTITY_TYPE = (decimal)ENTITY_TYPE.权限;
                Qwhere.ENTITY_ID = model.RIGHT_ID;
                Qwhere.HOST_IP = Ip;
                Qwhere.HOST_NAME = HostName;
                Qwhere.OPERATION_DESC = "修改权限信息:RIGHT_NAME=" + model.RIGHT_NAME + ",RIGHT_DESC=" + model.RIGHT_DESC + "...";
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
		public bool Delete(decimal RIGHT_ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from RIGHT_INFO ");
			strSql.Append(" where RIGHT_ID=@RIGHT_ID ");
			SqlParameter[] parameters = {
					new SqlParameter("@RIGHT_ID", SqlDbType.Decimal,22)			};
			parameters[0].Value = RIGHT_ID;

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
		public bool DeleteList(string RIGHT_IDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from RIGHT_INFO ");
			strSql.Append(" where RIGHT_ID in ("+RIGHT_IDlist + ")  ");
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
		public PDTech.OA.Model.RIGHT_INFO GetModel(decimal RIGHT_ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select RIGHT_ID,RIGHT_CODE,RIGHT_NAME,PARENT_ID,SORT_NUM,RIGHT_DESC from RIGHT_INFO ");
			strSql.Append(" where RIGHT_ID=@RIGHT_ID ");
			SqlParameter[] parameters = {
					new SqlParameter("@RIGHT_ID", SqlDbType.Decimal,22)			};
			parameters[0].Value = RIGHT_ID;

			PDTech.OA.Model.RIGHT_INFO model=new PDTech.OA.Model.RIGHT_INFO();
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
		public PDTech.OA.Model.RIGHT_INFO DataRowToModel(DataRow row)
		{
			PDTech.OA.Model.RIGHT_INFO model=new PDTech.OA.Model.RIGHT_INFO();
			if (row != null)
			{
				if(row["RIGHT_ID"]!=null && row["RIGHT_ID"].ToString()!="")
				{
					model.RIGHT_ID=decimal.Parse(row["RIGHT_ID"].ToString());
				}
				if(row["RIGHT_CODE"]!=null)
				{
					model.RIGHT_CODE=row["RIGHT_CODE"].ToString();
				}
				if(row["RIGHT_NAME"]!=null)
				{
					model.RIGHT_NAME=row["RIGHT_NAME"].ToString();
				}
				if(row["PARENT_ID"]!=null && row["PARENT_ID"].ToString()!="")
				{
					model.PARENT_ID=decimal.Parse(row["PARENT_ID"].ToString());
				}
				if(row["SORT_NUM"]!=null && row["SORT_NUM"].ToString()!="")
				{
					model.SORT_NUM=decimal.Parse(row["SORT_NUM"].ToString());
				}
				if(row["RIGHT_DESC"]!=null)
				{
					model.RIGHT_DESC=row["RIGHT_DESC"].ToString();
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
			strSql.Append("select RIGHT_ID,RIGHT_CODE,RIGHT_NAME,PARENT_ID,SORT_NUM,RIGHT_DESC ");
			strSql.Append(" FROM RIGHT_INFO ");
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
			strSql.Append("select count(1) FROM RIGHT_INFO ");
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
        /// 获取权限信息---未分页
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public IList<Model.RIGHT_INFO> get_RiInfoList(Model.RIGHT_INFO where)
        {
            string condition = DAL_Helper.GetWhereCondition(where);
            string strSQL = string.Format("SELECT RI.*,(SELECT RIGHT_NAME FROM RIGHT_INFO WHERE RIGHT_ID=RI.PARENT_ID)PARENT_NAME FROM RIGHT_INFO RI WHERE 1=1 {0} ", condition);
            DataTable dt = DbHelperSQL.GetTable(strSQL);
            return DAL_Helper.CommonFillList<Model.RIGHT_INFO>(dt);
        }
        /// <summary>
        /// 获取权限信息--返回dataTable
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public DataTable get_RightInfoTab(Model.RIGHT_INFO where)
        {
            string condition = DAL_Helper.GetWhereCondition(where);
            string strSQL = string.Format("SELECT RI.*,(SELECT RIGHT_NAME FROM RIGHT_INFO WHERE RIGHT_ID=RI.PARENT_ID)PARENT_NAME FROM RIGHT_INFO RI WHERE 1=1 {0} ", condition);
            DataTable dt = DbHelperSQL.GetTable(strSQL);
            return dt;
        }
        /// <summary>
        /// 获取一条权限信息
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public Model.RIGHT_INFO GetRightInfo(decimal uId)
        {
            string strSQL = string.Format("SELECT RI.*,(SELECT RIGHT_NAME FROM RIGHT_INFO WHERE RIGHT_ID=RI.PARENT_ID)PARENT_NAME FROM RIGHT_INFO RI WHERE RIGHT_ID={0}", uId);
            DataTable dt = DbHelperSQL.GetTable(strSQL);
            if (dt.Rows.Count > 0)
            {
                return DAL_Helper.CommonFillList<Model.RIGHT_INFO>(dt)[0];
            }
            else
            {
                return null;
            }
        }
        /// <summary>
        /// 获取权限信息-使用分页
        /// </summary>
        /// <param name="where"></param>
        /// <param name="currentpage"></param>
        /// <param name="pagesize"></param>
        /// <param name="totalrecord"></param>
        /// <returns></returns>
        public IList<Model.RIGHT_INFO> get_Paging_RightInfoList(Model.RIGHT_INFO where, int currentpage, int pagesize, out int totalrecord)
        {
            string condition = DAL_Helper.GetWhereCondition(where);
            string strSQL = string.Format("SELECT TOP (100) PERCENT RI.*,(SELECT RIGHT_NAME FROM RIGHT_INFO WHERE RIGHT_ID=RI.PARENT_ID)PARENT_NAME FROM RIGHT_INFO RI WHERE 1=1 {0} ", condition);
            PageDescribe pdes = new PageDescribe();
            pdes.CurrentPage = currentpage;
            pdes.PageSize = pagesize;
            DataTable dt = pdes.PageDescribes(strSQL);
            totalrecord = pdes.RecordCount;
            return DAL_Helper.CommonFillList<Model.RIGHT_INFO>(dt);
        }
		#endregion  BasicMethod
		#region  ExtensionMethod

		#endregion  ExtensionMethod
	}
}

