using System;
using System.Data;
using System.Text;
using System.Collections.Generic;
using Maticsoft.DBUtility;//Please add references
namespace PDTech.OA.DAL
{
	/// <summary>
	/// 数据访问类:VIEW_PRO_STEP_TYPE
	/// </summary>
	public partial class VIEW_PRO_STEP_TYPE
	{
		public VIEW_PRO_STEP_TYPE()
		{}
		#region  BasicMethod
        /// <summary>
        /// 获取符合条件的项目任务信息
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public IList<Model.VIEW_PRO_STEP_TYPE> get_viewStepAndType(Model.VIEW_PRO_STEP_TYPE where)
        {
            string condition = DAL_Helper.GetWhereCondition(where);
            string selSQL = string.Format(@"SELECT * FROM VIEW_PRO_STEP_TYPE WHERE 1=1 {0}",condition);
            DataTable dt = DbHelperSQL.GetTable(selSQL);
            return DAL_Helper.CommonFillList<Model.VIEW_PRO_STEP_TYPE>(dt);
        }
        /// <summary>
        /// 获取项目步骤及步骤类型信息
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public Model.VIEW_PRO_STEP_TYPE getviewstepAndtype(Model.VIEW_PRO_STEP_TYPE where)
        {
            string condition = DAL_Helper.GetWhereCondition(where);
            string selSQL = string.Format(@"SELECT * FROM VIEW_PRO_STEP_TYPE WHERE 1=1 {0}",condition);
            DataTable dt = DbHelperSQL.GetTable(selSQL);
            if(dt.Rows.Count>0)
            {
                return DAL_Helper.CommonFillList<Model.VIEW_PRO_STEP_TYPE>(dt)[0];
            }
            else
            {
                return null;
            }
        }
		#endregion  BasicMethod
		#region  ExtensionMethod

		#endregion  ExtensionMethod
	}
}

