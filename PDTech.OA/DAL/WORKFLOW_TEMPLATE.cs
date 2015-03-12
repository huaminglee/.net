using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using Maticsoft.DBUtility;

namespace PDTech.OA.DAL
{
    /// <summary>
    /// 数据访问类:WORKFLOW_TEMPLATE
    /// </summary>
    public partial class WORKFLOW_TEMPLATE
    {
        public WORKFLOW_TEMPLATE()
        { }
        #region  BasicMethod

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(decimal FLOW_TEMPLATE_ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from WORKFLOW_TEMPLATE");
            strSql.Append(" where FLOW_TEMPLATE_ID=@FLOW_TEMPLATE_ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@FLOW_TEMPLATE_ID", SqlDbType.BigInt)			};
            parameters[0].Value = FLOW_TEMPLATE_ID;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(PDTech.OA.Model.WORKFLOW_TEMPLATE model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into WORKFLOW_TEMPLATE(");
            strSql.Append("FLOW_TEMPLATE_ID,FLOW_TEMPLATE_NAME)");
            strSql.Append(" values (");
            strSql.Append("@FLOW_TEMPLATE_ID,@FLOW_TEMPLATE_NAME)");
            SqlParameter[] parameters = {
					new SqlParameter("@FLOW_TEMPLATE_ID", SqlDbType.BigInt),
					new SqlParameter("@FLOW_TEMPLATE_NAME", SqlDbType.NVarChar)};
            parameters[0].Value = model.FLOW_TEMPLATE_ID;
            parameters[1].Value = model.FLOW_TEMPLATE_NAME;

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
        /// 更新一条数据
        /// </summary>
        public bool Update(PDTech.OA.Model.WORKFLOW_TEMPLATE model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update WORKFLOW_TEMPLATE set ");
            strSql.Append("FLOW_TEMPLATE_NAME=@FLOW_TEMPLATE_NAME");
            strSql.Append(" where FLOW_TEMPLATE_ID=@FLOW_TEMPLATE_ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@FLOW_TEMPLATE_NAME", SqlDbType.NVarChar),
					new SqlParameter("@FLOW_TEMPLATE_ID", SqlDbType.BigInt)};
            parameters[0].Value = model.FLOW_TEMPLATE_NAME;
            parameters[1].Value = model.FLOW_TEMPLATE_ID;

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
        public bool Delete(decimal FLOW_TEMPLATE_ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from WORKFLOW_TEMPLATE ");
            strSql.Append(" where FLOW_TEMPLATE_ID=@FLOW_TEMPLATE_ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@FLOW_TEMPLATE_ID", SqlDbType.BigInt)			};
            parameters[0].Value = FLOW_TEMPLATE_ID;

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


        #endregion  BasicMethod

        /// <summary>
        /// 查询风险模块--日常办公公文
        /// </summary>
        /// <returns>返回给风险模块下拉框</returns>
        public IList<Model.OA_RISK_MODULE> GetRiskModule()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select flow_template_id,flow_template_name from workflow_template order by flow_template_id asc");
            DataTable dt = DbHelperSQL.GetTable(strSql.ToString());
            if (dt.Rows.Count > 0)
            {
                return DAL_Helper.CommonFillList<Model.OA_RISK_MODULE>(dt);
            }
            else
            {
                return null;
            }
        }
    }
}