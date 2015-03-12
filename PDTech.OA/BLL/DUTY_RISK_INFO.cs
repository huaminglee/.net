using System;
using System.Data;
using System.Collections.Generic;

namespace PDTech.OA.BLL
{
    /// <summary>
    /// DUTY_RISK_INFO
    /// </summary>
    public partial class DUTY_RISK_INFO
    {
        private readonly PDTech.OA.DAL.DUTY_RISK_INFO dal = new PDTech.OA.DAL.DUTY_RISK_INFO();
        public DUTY_RISK_INFO()
        { }
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(PDTech.OA.Model.DUTY_RISK_INFO model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(PDTech.OA.Model.DUTY_RISK_INFO model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(decimal DUTY_RISK_ID)
        {
            return dal.Delete(DUTY_RISK_ID);
        }

        #region  ExtensionMethod
        /// <summary>
        /// 查询岗位风险
        /// </summary>
        /// <param name="uId">用户ID</param>
        /// <returns>返回当前用户的岗位风险</returns>
        public IList<Model.DUTY_RISK> GetRiskInfo(string uId)
        {
            return dal.GetRiskInfo(uId);
        }

        /// <summary>
        /// 查询岗位风险（当前用户的所有）
        /// </summary>
        /// <param name="uId">用户ID</param>
        /// <returns>返回当前用户的所有岗位风险</returns>
        public IList<Model.DUTY_RISK> GetRiskInfoMore(string uId)
        {
            return dal.GetRiskInfoMore(uId);
        }

        /// <summary>
        /// 查询岗位风险（所有）
        /// </summary>
        /// <param name="strWhere">查询条件</param>
        /// <param name="currentPage">当前页面</param>
        /// <param name="pageSize">每页条数</param>
        /// <param name="totalNum">总条数</param>
        /// <returns>返回岗位风险</returns>
        public IList<Model.DUTY_RISK> GetAllRiskInfo(string strWhere, string currentPage, string pageSize, out int totalNum)
        {
            return dal.GetAllRiskInfo(strWhere, currentPage, pageSize, out totalNum);
        }
        #endregion  ExtensionMethod
    }
}