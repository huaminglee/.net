using System;
using System.Data;
using System.Text;
using System.Collections.Generic;
using Maticsoft.DBUtility;//Please add references
namespace PDTech.OA.DAL
{
	/// <summary>
	/// 数据访问类:VIEW_RISK_COUNT
	/// </summary>
	public partial class VIEW_RISK_COUNT
	{
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
            string condition = DAL_Helper.GetWhereCondition(where);
            string selSQL = string.Format(@"SELECT * FROM VIEW_RISK_COUNT WHERE 1=1 {0}",condition);
            DataTable dt = DbHelperSQL.GetTable(selSQL);
            return DAL_Helper.CommonFillList<Model.VIEW_RISK_COUNT>(dt);
        }

		#endregion  BasicMethod
		#region  ExtensionMethod

		#endregion  ExtensionMethod
	}
}

