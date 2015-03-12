using System.Collections.Generic;

namespace PDTech.OA.BLL
{
    /// <summary>
    /// 项目步骤记录表
    /// </summary>
    public partial class SW_PROJECT_STEP
    {
        private readonly PDTech.OA.DAL.SW_PROJECT_STEP dal = new PDTech.OA.DAL.SW_PROJECT_STEP();
        public SW_PROJECT_STEP()
        { }
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(decimal PROJECT_STEP_ID)
        {
            return dal.Exists(PROJECT_STEP_ID);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(PDTech.OA.Model.SW_PROJECT_STEP model)
        {
            return dal.Update(model);
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool FirstUpdate(PDTech.OA.Model.SW_PROJECT_STEP model)
        {
            return dal.FirstUpdate(model);
        }


        /// <summary>
        /// 审核
        /// </summary>
        public bool FirstAudit(decimal attID, IList<PDTech.OA.Model.ATTRIBUTES> AttList)
        {
            return dal.FirstAudit(attID, AttList);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(decimal PROJECT_STEP_ID)
        {

            return dal.Delete(PROJECT_STEP_ID);
        }

        #endregion  BasicMethod

        /// <summary>
        /// 查询超期预警（水务项目）
        /// </summary>
        /// <param name="strWhere">查询条件</param>
        /// <param name="currentPage">当前页面</param>
        /// <param name="pageSize">每页条数</param>
        /// <param name="totalNum">总条数</param>
        /// <returns>返回超期预警</returns>
        public IList<Model.SW_EXPIRE_WATER> GetExpireWater(string strWhere, string currentPage, string pageSize, out int totalNum)
        {
            return dal.GetExpireWater(strWhere, currentPage, pageSize, out totalNum);
        }

        /// <summary>
        /// 查询风险项目（水务项目）
        /// </summary>
        /// <param name="strWhere">查询条件</param>
        /// <param name="currentPage">当前页面</param>
        /// <param name="pageSize">每页条数</param>
        /// <param name="totalNum">总条数</param>
        /// <returns>返回风险项目</returns>
        public IList<Model.SW_RISK_WATER> GetRiskWater(string strWhere, string currentPage, string pageSize, out int totalNum)
        {
            return dal.GetRiskWater(strWhere, currentPage, pageSize, out totalNum);
        }
    }
}