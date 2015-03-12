using System;
using System.Data;
using System.Collections.Generic;
using Maticsoft.Common;
using Maticsoft.Model;
namespace PDTech.OA.BLL
{
	/// <summary>
	/// VIEW_RISK_COUNT
	/// </summary>
	public partial class VIEW_RISK_COUNT
	{
        private readonly PDTech.OA.DAL.VIEW_RISK_COUNT dal = new PDTech.OA.DAL.VIEW_RISK_COUNT();
		public VIEW_RISK_COUNT()
		{}
		#region  BasicMethod
        /// <summary>
        /// 获取风险处置
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public IList<Model.VIEW_RISK_COUNT> get_ViewList(Model.VIEW_RISK_COUNT where)
        {
            return dal.get_ViewList(where);
        }

		#endregion  BasicMethod
		#region  ExtensionMethod

		#endregion  ExtensionMethod
	}
}

