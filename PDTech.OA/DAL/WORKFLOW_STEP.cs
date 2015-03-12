using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using System.Collections.Generic;
using Maticsoft.DBUtility;//Please add references
namespace PDTech.OA.DAL
{
    /// <summary>
    /// 数据访问类:WORKFLOW_STEP
    /// </summary>
    public partial class WORKFLOW_STEP
    {
        public WORKFLOW_STEP()
        { }
        #region  BasicMethod

        /// <summary>
        /// 获取一条步骤信息
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public Model.WORKFLOW_STEP GetStepInfo(decimal sId)
        {
            string selSQL = string.Format(@"SELECT * FROM WORKFLOW_STEP WHERE STEP_ID={0}", sId);
            DataTable dt = DbHelperSQL.GetTable(selSQL);
            if (dt.Rows.Count > 0)
            {
                return DAL_Helper.CommonFillList<Model.WORKFLOW_STEP>(dt)[0];
            }
            else
            {
                return null;
            }
        }
        /// <summary>
        /// 获取一条步骤信息
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public Model.WORKFLOW_STEP GetStepInfo(Model.WORKFLOW_STEP where)
        {
            string condition = DAL_Helper.GetWhereCondition(where);
            string selSQL = string.Format(@"SELECT * FROM WORKFLOW_STEP WHERE 1=1 {0}", condition);
            DataTable dt = DbHelperSQL.GetTable(selSQL);
            if (dt.Rows.Count > 0)
            {
                return DAL_Helper.CommonFillList<Model.WORKFLOW_STEP>(dt)[0];
            }
            else
            {
                return null;
            }
        }
        /// <summary>
        /// 获取步骤信息列表
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public IList<Model.WORKFLOW_STEP> get_worlflow_step(Model.WORKFLOW_STEP where)
        {
            string condition = DAL_Helper.GetWhereCondition(where);
            string selSQL = string.Format(@"SELECT * FROM WORKFLOW_STEP WHERE 1=1 {0}", condition);
            DataTable dt = DbHelperSQL.GetTable(selSQL);
            return DAL_Helper.CommonFillList<Model.WORKFLOW_STEP>(dt);
        }

        /// <summary>
        /// 按模板获取步骤信息列表
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public IList<Model.WORKFLOW_STEP> GetStepsByTemplateID(int p_TemplateId)
        {
            string selSQL = string.Format(@"SELECT * FROM WORKFLOW_STEP WHERE FLOW_TEMPLATE_ID = {0}", p_TemplateId);
            DataTable dt = DbHelperSQL.GetTable(selSQL);
            return DAL_Helper.CommonFillList<Model.WORKFLOW_STEP>(dt);
        }

        /// <summary>
        /// 按公文类型获取步骤信息列表
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public IList<Model.WORKFLOW_STEP> GetStepByArchiveType(decimal p_ArchiveType)
        {
            string selSQL = string.Format(@"SELECT * FROM WORKFLOW_STEP WHERE FLOW_TEMPLATE_ID = (SELECT FLOW_TEMPLATE_ID FROM ARCHIVE_TYPE_FLOW_MAPPING WHERE ARCHIVE_TYPE = {0})", p_ArchiveType);
            DataTable dt = DbHelperSQL.GetTable(selSQL);
            return DAL_Helper.CommonFillList<Model.WORKFLOW_STEP>(dt);
        }
        #endregion  BasicMethod

        /// <summary>
        /// 查询风险步骤--日常办公公文
        /// </summary>
        /// <param name="flow_template_id">风险模块ID</param>
        /// <returns>返回给风险步骤下拉框</returns>
        public IList<Model.OA_RISK_STEP> GetRiskStep(string flow_template_id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select step_id,step_name from workflow_step where flow_template_id='" + flow_template_id + "' order by step_id asc");
            DataTable dt = DbHelperSQL.GetTable(strSql.ToString());
            if (dt.Rows.Count > 0)
            {
                return DAL_Helper.CommonFillList<Model.OA_RISK_STEP>(dt);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 查询风险步骤--水务项目
        /// </summary>
        /// <param name="project_type">模块类型</param>
        /// <returns>返回给风险步骤下拉框</returns>
        public IList<Model.OA_RISK_STEP> GetProjectStep(string project_type)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select step_id,step_name from sw_project_step_type where project_type='" + project_type + "' order by step_id asc");
            DataTable dt = DbHelperSQL.GetTable(strSql.ToString());
            if (dt.Rows.Count > 0)
            {
                return DAL_Helper.CommonFillList<Model.OA_RISK_STEP>(dt);
            }
            else
            {
                return null;
            }
        }
        public void UPsetpinfo(int projectid, int taskstepid,string nextstepuser,string curuser,DateTime limitime,DateTime remindtime)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(string.Format("update SW_PROJECT_STEP set END_TIME=GETDATE(),STEP_STATUS=9,OWNER={2} where PROJECT_ID={0} and STEP_ID={1}-329910", projectid, taskstepid, curuser));
            strSql.Append(string.Format(" update SW_PROJECT_STEP set START_TIME=GETDATE(),STEP_STATUS=1,OWNER={2},LIMIT_TIME='{3}',REMIND_TIME='{4}' where PROJECT_ID={0} and STEP_ID={1}-329909", projectid, taskstepid, nextstepuser, limitime.ToString(),remindtime.ToString()));
            DbHelperSQL.ExecuteSql(strSql.ToString());
        }
        public void uplimittime(int projectid, int curstepid, DateTime limitime, DateTime remintime, string nextstepuser)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(string.Format("update SW_PROJECT_STEP set LIMIT_TIME='{2}',REMIND_TIME='{3}',OWNER={4} where PROJECT_ID={0} and STEP_ID={1}-329910", projectid, curstepid, limitime.ToString(), remintime.ToString(), nextstepuser));
            DbHelperSQL.ExecuteSql(strSql.ToString());
        }
    }
}