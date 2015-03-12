using System;
using System.Data;
using System.Text;
using System.Collections.Generic;
using Maticsoft.DBUtility;//Please add references
namespace PDTech.OA.DAL
{
	/// <summary>
	/// 数据访问类:VIEW_WORKFLOW_STEP_NEXT_INFO
	/// </summary>
	public partial class VIEW_WORKFLOW_STEP_NEXT_INFO
	{
		public VIEW_WORKFLOW_STEP_NEXT_INFO()
		{}
		#region  BasicMethod

        /// <summary>
        /// 获取一条信息
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public Model.VIEW_WORKFLOW_STEP_NEXT_INFO Get_ViewInfo(Model.VIEW_WORKFLOW_STEP_NEXT_INFO Model)
        {
            string condition = DAL_Helper.GetWhereCondition(Model);
            string strSQL = string.Format("SELECT * FROM VIEW_WORKFLOW_STEP_NEXT_INFO  WHERE 1=1 {0}", condition);
            DataTable dt = DbHelperSQL.GetTable(strSQL);
            if (dt.Rows.Count > 0)
            {
                return DAL_Helper.CommonFillList<Model.VIEW_WORKFLOW_STEP_NEXT_INFO>(dt)[0];
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

