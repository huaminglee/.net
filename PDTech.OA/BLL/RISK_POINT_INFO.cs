using System.Collections.Generic;
using System.Data;

namespace PDTech.OA.BLL
{
	/// <summary>
	/// 风险防控点定义维护表
	/// </summary>
	public partial class RISK_POINT_INFO
	{
		private readonly PDTech.OA.DAL.RISK_POINT_INFO dal=new PDTech.OA.DAL.RISK_POINT_INFO();

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(PDTech.OA.Model.RISK_POINT_INFO model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(PDTech.OA.Model.RISK_POINT_INFO model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(decimal RISK_POINT_ID)
		{
			
			return dal.Delete(RISK_POINT_ID);
		}

        /// <summary>
        /// 查询风险防控（当前类型，当前步骤）
        /// </summary>
        /// <param name="step_type">步骤类型</param>
        /// <param name="step_id">步骤ID</param>
        /// <returns>返回风险防控</returns>
        public DataTable GetRiskPointInfo(string step_type, string step_id)
        {
            return dal.GetRiskPointInfo(step_type, step_id);
        }

        /// <summary>
        /// 查询风险防控
        /// </summary>
        /// <param name="strWhere">查询条件</param>
        /// <param name="currentPage">当前页面</param>
        /// <param name="pageSize">每页条数</param>
        /// <param name="totalNum">总条数</param>
        /// <returns>返回风险防控列表</returns>
        public IList<Model.RISK_POINT> GetRiskPointInfo(string strWhere, string currentPage, string pageSize, out int totalNum)
        {
            return dal.GetRiskPointInfo(strWhere, currentPage, pageSize, out totalNum);
        }

        /// <summary>
        /// 获取所有风险防控点定义
        /// </summary>
        /// <returns></returns>
        public IList<Model.RISK_POINT_INFO> GetAllRiskPointInfo()
        {
            return dal.GetAllRiskPointInfo();
        }
	}
}