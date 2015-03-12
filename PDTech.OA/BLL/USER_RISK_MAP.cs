using System;
using System.Data;
using System.Collections.Generic;
using Maticsoft.Common;
using PDTech.OA.Model;
namespace PDTech.OA.BLL
{
    /// <summary>
    /// USER_RISK_MAP
    /// </summary>
    public partial class USER_RISK_MAP
    {
        private readonly PDTech.OA.DAL.USER_RISK_MAP dal = new PDTech.OA.DAL.USER_RISK_MAP();
        public USER_RISK_MAP()
        { }
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(PDTech.OA.Model.USER_RISK_MAP model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(PDTech.OA.Model.USER_RISK_MAP model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        /// <param name="duty_risk_id">风险ID</param>
        /// <returns>是否删除成功</returns>
        public bool Delete(decimal duty_risk_id)
        {
            return dal.Delete(duty_risk_id);
        }
    }
}