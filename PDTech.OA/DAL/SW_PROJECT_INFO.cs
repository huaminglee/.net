using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using System.Collections.Generic;
using Maticsoft.DBUtility;
using System.Collections;//Please add references
namespace PDTech.OA.DAL
{
    /// <summary>
    /// 数据访问类:SW_PROJECT_INFO
    /// </summary>
    public partial class SW_PROJECT_INFO
    {
        public SW_PROJECT_INFO()
        { }
        #region  BasicMethod

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(decimal PROJECT_ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from SW_PROJECT_INFO");
            strSql.Append(" where PROJECT_ID=@PROJECT_ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@PROJECT_ID", SqlDbType.Decimal)			};
            parameters[0].Value = PROJECT_ID;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(PDTech.OA.Model.SW_PROJECT_INFO model, string HostName, string Ip, string Ids, int Is_szyd, out decimal Archive_ID, out decimal Project_Id,out decimal Task_id)
        {
            try
            {
                SqlParameter RESULTCODE = new SqlParameter("RESULTCODE", SqlDbType.Int);
                RESULTCODE.Direction = ParameterDirection.Output;
                SqlParameter O_SW_PROJECT_ID = new SqlParameter("O_SW_PROJECT_ID", SqlDbType.Int);
                O_SW_PROJECT_ID.Direction = ParameterDirection.Output;
                SqlParameter O_SW_ARCHIVE_ID = new SqlParameter("O_ARCHIVE_ID", SqlDbType.Int);
                O_SW_ARCHIVE_ID.Direction = ParameterDirection.Output;
                SqlParameter O_TASK_ID = new SqlParameter("O_TASK_ID", SqlDbType.Int);
                O_TASK_ID.Direction = ParameterDirection.Output;
                SqlParameter[] parameters = {
					new SqlParameter("P_CREATOR", SqlDbType.Decimal),
					new SqlParameter("P_PROJECT_NAME", SqlDbType.NVarChar),
					new SqlParameter("P_PROJECT_FUNDS", SqlDbType.NVarChar),
					new SqlParameter("P_FUNDS_TYPE", SqlDbType.NVarChar),
					new SqlParameter("P_START_TIME", SqlDbType.DateTime),
					new SqlParameter("P_PLAN_END_TIME", SqlDbType.DateTime),
					new SqlParameter("P_LAUNCH_TYPE", SqlDbType.Int),
					new SqlParameter("P_TOP_RESPONSE_DEPT", SqlDbType.NVarChar),
					new SqlParameter("P_OWNER_DEPT", SqlDbType.NVarChar),
                    new SqlParameter("P_PROJECT_BY", SqlDbType.NVarChar),
					new SqlParameter("P_PROJECT_STATUS", SqlDbType.NVarChar),
                    new SqlParameter("P_IS_SHOW_IN_SZYD", SqlDbType.Char),
					new SqlParameter("P_FILE_DEPT", SqlDbType.Int),
					new SqlParameter("P_REMARK", SqlDbType.Text),
					new SqlParameter("P_HOST_IP", SqlDbType.NVarChar),
                    new SqlParameter("P_HOST_NAME", SqlDbType.NVarChar),
                    new SqlParameter("P_PROJECT_ATTACHMENT_FILE_IDS", SqlDbType.NVarChar),
                                               RESULTCODE,O_SW_ARCHIVE_ID,O_SW_PROJECT_ID,O_TASK_ID};
                parameters[0].Value = model.CREATOR;
                parameters[1].Value = model.PROJECT_NAME;
                parameters[2].Value = model.PROJECT_FUNDS;
                parameters[3].Value = model.FUNDS_TYPE;
                parameters[4].Value = model.START_TIME;
                parameters[5].Value = model.PLAN_END_TIME;
                parameters[6].Value = model.LAUNCH_TYPE;
                parameters[7].Value = model.TOP_RESPONSE_DEPT;
                parameters[8].Value = model.OWNER_DEPT;
                parameters[9].Value = model.PROJECT_BY;
                parameters[10].Value = model.PROJECT_STATUS;
                parameters[11].Value = Is_szyd;
                parameters[12].Value = model.FILE_DEPT;
                parameters[13].Value = model.REMARK;
                parameters[14].Value = Ip;
                parameters[15].Value = HostName;
                parameters[16].Value = Ids;

                DAL_Helper.get_db_para_value(parameters);
                DbHelperSQL.RunProcedure_Add("PD_CREATE_SW_PROJECT", parameters);
                if (decimal.Parse(RESULTCODE.Value.ToString()) > 0)
                {
                    Archive_ID = (decimal)new ConvertHelper(O_SW_ARCHIVE_ID.Value).ToDecimal;
                    Project_Id = (decimal)new ConvertHelper(O_SW_PROJECT_ID.Value).ToDecimal;
                    Task_id = (decimal)new ConvertHelper(O_TASK_ID.Value).ToDecimal;
                    model.PROJECT_ID = Project_Id;
                    return true;
                }
                else
                {
                    Archive_ID = 0;
                    Project_Id = 0;
                    Task_id = 0;
                    return false;
                }
            }
            catch (Exception ex)
            {
                Archive_ID = 0;
                Project_Id = 0;
                Task_id = 0;
                return false;
            }
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(PDTech.OA.Model.SW_PROJECT_INFO model,decimal ArID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update SW_PROJECT_INFO set ");
            strSql.Append("PROJECT_NAME=@PROJECT_NAME,");
            strSql.Append("PROJECT_FUNDS=@PROJECT_FUNDS,");
            strSql.Append("FUNDS_TYPE=@FUNDS_TYPE,");
            strSql.Append("START_TIME=@START_TIME,");
            strSql.Append("PLAN_END_TIME=@PLAN_END_TIME,");
            strSql.Append("LAUNCH_TYPE=@LAUNCH_TYPE,");
            strSql.Append("TOP_RESPONSE_DEPT=@TOP_RESPONSE_DEPT,");
            strSql.Append("OWNER_DEPT=@OWNER_DEPT,");
            strSql.Append("PROJECT_BY=@PROJECT_BY,");
            strSql.Append("PROJECT_STATUS=@PROJECT_STATUS,");
            strSql.Append("FILE_DEPT=@FILE_DEPT,");
            strSql.Append("REMARK=@REMARK");
            strSql.Append(" where PROJECT_ID=@PROJECT_ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@PROJECT_NAME", SqlDbType.NVarChar),
					new SqlParameter("@PROJECT_FUNDS", SqlDbType.NVarChar),
					new SqlParameter("@FUNDS_TYPE", SqlDbType.NVarChar),
					new SqlParameter("@START_TIME", SqlDbType.DateTime),
					new SqlParameter("@PLAN_END_TIME", SqlDbType.DateTime),
					new SqlParameter("@LAUNCH_TYPE", SqlDbType.Decimal,4),
					new SqlParameter("@TOP_RESPONSE_DEPT", SqlDbType.NVarChar),
					new SqlParameter("@OWNER_DEPT", SqlDbType.NVarChar),
					new SqlParameter("@PROJECT_BY", SqlDbType.NVarChar),
					new SqlParameter("@PROJECT_STATUS", SqlDbType.Decimal,4),
					new SqlParameter("@FILE_DEPT", SqlDbType.Decimal,4),
					new SqlParameter("@REMARK", SqlDbType.Text),
					new SqlParameter("@PROJECT_ID", SqlDbType.BigInt)};
            parameters[0].Value = model.PROJECT_NAME;
            parameters[1].Value = model.PROJECT_FUNDS;
            parameters[2].Value = model.FUNDS_TYPE;
            parameters[3].Value = model.START_TIME;
            parameters[4].Value = model.PLAN_END_TIME;
            parameters[5].Value = model.LAUNCH_TYPE;
            parameters[6].Value = model.TOP_RESPONSE_DEPT;
            parameters[7].Value = model.OWNER_DEPT;
            parameters[8].Value = model.PROJECT_BY;
            parameters[9].Value = model.PROJECT_STATUS;
            parameters[10].Value = model.FILE_DEPT;
            parameters[11].Value = model.REMARK;
            parameters[12].Value = model.PROJECT_ID;
            DAL_Helper.get_db_para_value(parameters);

            String modSql = String.Format("UPDATE OA_ARCHIVE SET ARCHIVE_TITLE='{0}',ARCHIVE_CONTENT='{1}' WHERE ARCHIVE_ID={2}",model.PROJECT_NAME,model.REMARK,ArID);
            if (model.PROJECT_STATUS == 1)
            {
                string modArchive = string.Format(@"UPDATE OA_ARCHIVE SET CURRENT_STATE=2 WHERE ARCHIVE_ID IN (SELECT ARCHIVE_ID FROM ARCHIVE_PROJECT_MAP WHERE PROJECT_ID={0})", model.PROJECT_ID);
                DbHelperSQL.ExecuteSql(modArchive);
            }
            DbHelperSQL.ExecuteSql(modSql);
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
        public bool Delete(decimal PROJECT_ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from SW_PROJECT_INFO ");
            strSql.Append(" where PROJECT_ID=@PROJECT_ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@PROJECT_ID", SqlDbType.BigInt)			};
            parameters[0].Value = PROJECT_ID;

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
        /// 获取项目列表---未分页
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public IList<Model.SW_PROJECT_INFO> get_proList(Model.SW_PROJECT_INFO where)
        {
            string condition = DAL_Helper.GetWhereCondition(where);
            string strSQL = string.Format("SELECT * FROM SW_PROJECT_INFO WHERE 1=1 {0} ", condition);
            DataTable dt = DbHelperSQL.GetTable(strSQL);
            return DAL_Helper.CommonFillList<Model.SW_PROJECT_INFO>(dt);
        }

        /// <summary>
        /// 获取项目-使用分页
        /// </summary>
        /// <param name="where">条件[实体]</param>
        /// <param name="currentpage">当前页</param>
        /// <param name="pagesize">显示数目</param>
        /// <param name="totalrecord">总条数</param>
        /// <returns></returns>
        public IList<Model.SW_PROJECT_INFO> get_Paging_proList(Model.SW_PROJECT_INFO where, int currentpage, int pagesize, out int totalrecord)
        {
            string condition = DAL_Helper.GetWhereCondition(where);
            string strSQL = string.Format("SELECT TOP (100) PERCENT * FROM SW_PROJECT_INFO WHERE 1=1 {0} ", condition);
            PageDescribe pdes = new PageDescribe();
            pdes.CurrentPage = currentpage;
            pdes.PageSize = pagesize;
            DataTable dt = pdes.PageDescribes(strSQL);
            totalrecord = pdes.RecordCount;
            return DAL_Helper.CommonFillList<Model.SW_PROJECT_INFO>(dt);
        }
        /// <summary>
        /// 获取一条项目信息
        /// </summary>
        /// <param name="pId">项目ID</param>
        /// <returns></returns>
        public Model.SW_PROJECT_INFO get_proInfo(decimal pId)
        {
            string selSQL = string.Format(@"SELECT TOP (100) PERCENT * FROM SW_PROJECT_INFO WHERE 1=1 AND PROJECT_ID={0}", pId);
            DataTable dt = DbHelperSQL.GetTable(selSQL);
            if (dt.Rows.Count > 0)
            {
                return DAL_Helper.CommonFillList<Model.SW_PROJECT_INFO>(dt)[0];
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

