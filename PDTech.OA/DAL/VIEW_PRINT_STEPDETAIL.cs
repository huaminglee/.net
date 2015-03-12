using System;
using System.Data;
using System.Text;
using System.Collections.Generic;
using Maticsoft.DBUtility;//Please add references
namespace PDTech.OA.DAL
{
	/// <summary>
	/// 数据访问类:VIEW_PRINT_STEPDETAIL
	/// </summary>
	public partial class VIEW_PRINT_STEPDETAIL
	{
		public VIEW_PRINT_STEPDETAIL()
		{}
		#region  BasicMethod
        /// <summary>
        /// 获取用户信息---未分页
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public IList<Model.VIEW_PRINT_STEPDETAIL> get_PrintInfoList(Model.VIEW_PRINT_STEPDETAIL where)
        {
            string condition = DAL_Helper.GetWhereCondition(where);
            string strSQL = string.Format(@"SELECT ARCHIVE_TASK_ID,PRINT_TITLE,IS_PRINT,TASK_REMARK,FULL_NAME,ARCHIVE_ID,STEP_ID,END_TIME 
FROM VIEW_PRINT_STEPDETAIL  WHERE 1=1 {0} ", condition);
            DataTable dt = DbHelperSQL.GetTable(strSQL);
            return DAL_Helper.CommonFillList<Model.VIEW_PRINT_STEPDETAIL>(dt);
        }

        /// <summary>
        /// 获取用户信息---未分页
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public IList<Model.VIEW_PRINT_STEPDETAIL> get_PrintInfoListAll(Model.VIEW_PRINT_STEPDETAIL where)
        {
            string strSQL = string.Format(@"SELECT ARCHIVE_TASK_ID,PRINT_TITLE,IS_PRINT,TASK_REMARK,FULL_NAME,ARCHIVE_ID,STEP_ID,END_TIME,STEP_NAME,TASK_STATE,
LIMIT_TIME,START_TIME,DEPARTMENT_NAME
FROM VIEW_PRINT_STEPDETAIL  WHERE ARCHIVE_ID={0}
UNION
select NULL AS ARCHIVE_TASK_ID,PRINT_TITLE,'1' AS IS_PRINT, 
NULL AS TASK_REMARK,
NULL AS FULL_NAME,
NULL AS ARCHIVE_ID,
ws.STEP_ID,
NULL AS END_TIME,
 STEP_NAME ,-1 AS TASK_STATE,NULL AS LIMIT_TIME,NULL AS  START_TIME,NULL AS  DEPARTMENT_NAME
from WORKFLOW_STEP ws where ws.FLOW_TEMPLATE_ID = (select o.FLOW_TEMPLATE_ID from OA_ARCHIVE o where o.archive_id={0})
and WS.STEP_ID not in (select OAT.CURRENT_STEP_ID from OA_ARCHIVE_TASK oat where OAT.archive_id ={0} AND OAT.task_type = 0) 
AND ws.IS_PRINT=1 ORDER BY STEP_ID ASC", where.ARCHIVE_ID);
            DataTable dt = DbHelperSQL.GetTable(strSQL);
            return DAL_Helper.CommonFillList<Model.VIEW_PRINT_STEPDETAIL>(dt);
        }
		#endregion  BasicMethod
		#region  ExtensionMethod

		#endregion  ExtensionMethod
	}
}

