using System;
using System.Data;
using System.Collections.Generic;
using Maticsoft.Common;
using PDTech.OA.Model;
namespace PDTech.OA.BLL
{
    /// <summary>
    /// 工作流步骤定义模板
    /// </summary>
    public partial class WORKFLOW_STEP
    {
        private readonly PDTech.OA.DAL.WORKFLOW_STEP dal = new PDTech.OA.DAL.WORKFLOW_STEP();
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
            return dal.GetStepInfo(sId);
        }

        /// <summary>
        /// 获取一条步骤信息
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public Model.WORKFLOW_STEP GetStepInfo(Model.WORKFLOW_STEP where)
        {
            return dal.GetStepInfo(where);
        }
        /// <summary>
        /// 获取步骤信息列表
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public IList<Model.WORKFLOW_STEP> get_worlflow_step(Model.WORKFLOW_STEP where)
        {
            return dal.get_worlflow_step(where);
        }
        /// <summary>
        /// 获取步骤信息列表
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public IList<Model.WORKFLOW_STEP> GetStepByArchiveType(decimal archive_type)
        {
            return dal.GetStepByArchiveType(archive_type);
        }
        #endregion  BasicMethod

        /// <summary>
        /// 风险步骤
        /// </summary>
        /// <param name="flow_template_id">风险模块ID</param>
        /// <returns>返回风险步骤</returns>
        public IList<Model.OA_RISK_STEP> GetRiskStep(string flow_template_id)
        {
            return dal.GetRiskStep(flow_template_id);
        }

        /// <summary>
        /// 查询风险步骤--水务项目
        /// </summary>
        /// <param name="project_type">模块类型</param>
        /// <returns>返回给风险步骤下拉框</returns>
        public IList<Model.OA_RISK_STEP> GetProjectStep(string project_type)
        {
            return dal.GetProjectStep(project_type);
        }
        /// <summary>
        /// 更新SW_PROJECT_STEP表
        /// </summary>
        /// <param name="projectid"></param>
        /// <param name="taskstepid"></param>
        public void UPsetpinfo(int projectid,int taskstepid,string nextstepuser,string curuser,DateTime limitime,DateTime remindtime)
        {
             dal.UPsetpinfo(projectid, taskstepid,nextstepuser,curuser,limitime,remindtime);
        }
        public void uplimittime(int projectid, int curstepid, DateTime limitime, DateTime remintime, string nextstepuser)
        {
            dal.uplimittime(projectid,curstepid, limitime, remintime,nextstepuser);
        }
    }
}