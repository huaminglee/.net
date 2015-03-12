using System;
using System.Data;
using System.Collections.Generic;
using Maticsoft.Common;
using PDTech.OA.Model;
namespace PDTech.OA.BLL
{
    /// <summary>
    /// 流程模板定义表
    /// </summary>
    public partial class WORKFLOW_TEMPLATE
    {
        private readonly PDTech.OA.DAL.WORKFLOW_TEMPLATE dal = new PDTech.OA.DAL.WORKFLOW_TEMPLATE();
        public WORKFLOW_TEMPLATE()
        { }
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(decimal FLOW_TEMPLATE_ID)
        {
            return dal.Exists(FLOW_TEMPLATE_ID);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(PDTech.OA.Model.WORKFLOW_TEMPLATE model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(PDTech.OA.Model.WORKFLOW_TEMPLATE model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(decimal FLOW_TEMPLATE_ID)
        {

            return dal.Delete(FLOW_TEMPLATE_ID);
        }


        #endregion  BasicMethod

        /// <summary>
        /// 查询风险模块--日常办公公文
        /// </summary>
        /// <returns>返回给下拉框</returns>
        public IList<Model.OA_RISK_MODULE> GetRiskModule()
        {
            return dal.GetRiskModule();
        }
    }
}