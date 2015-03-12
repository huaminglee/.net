using System;
using System.Data;
using System.Text;
using System.Collections.Generic;
using Maticsoft.DBUtility;//Please add references
namespace PDTech.OA.DAL
{
	/// <summary>
	/// 数据访问类:VIEW_PROJECT_STEP_USER
	/// </summary>
	public partial class VIEW_PROJECT_STEP_USER
	{
		public VIEW_PROJECT_STEP_USER()
		{}
		#region  BasicMethod
        /// <summary>
        /// 获取项目步骤信息
        /// </summary>
        /// <param name="where">条件</param>
        /// <param name="currentpage">当前页</param>
        /// <param name="pagesize">页显示数目</param>
        /// <param name="totalrecord">总条数</param>
        /// <returns></returns>
        public IList<Model.VIEW_PROJECT_STEP_USER> get_paging_project_stepList(Model.VIEW_PROJECT_STEP_USER where, int currentpage, int pagesize, out int totalrecord)
        {
            string condition = DAL_Helper.GetWhereCondition(where);
            string strSQL = string.Format(@"SELECT DISTINCT TOP (100) PERCENT OWNER_ID,PROJECT_TYPE,PROJECT_NAME,START_TIME,ARCHIVE_ID,ARCHIVE_TASK_ID,TASK_STATE,CURRENT_STATE,
CFULL_NAME,PROJECT_STATUS,PROJECT_ID,CREATE_TIME FROM VIEW_PROJECT_STEP_USER WHERE 1=1 {0} ", condition);
            PageDescribe pdes = new PageDescribe();
            pdes.CurrentPage = currentpage;
            pdes.PageSize = pagesize;
            DataTable dt = pdes.PageDescribes(strSQL, "CREATE_TIME", "DESC");
            totalrecord = pdes.RecordCount;
            return DAL_Helper.CommonFillList<Model.VIEW_PROJECT_STEP_USER>(dt);
        }
        /// <summary>
        /// 获取项目步骤信息--未分页
        /// </summary>
        /// <param name="where">条件</param>
        /// <param name="currentpage">当前页</param>
        /// <param name="pagesize">页显示数目</param>
        /// <param name="totalrecord">总条数</param>
        /// <returns></returns>
        public IList<Model.VIEW_PROJECT_STEP_USER> get_paging_project_stepList(Model.VIEW_PROJECT_STEP_USER where)
        {
            string condition = DAL_Helper.GetWhereCondition(where);
            string strSQL = string.Format(@"SELECT DISTINCT PROJECT_TYPE,PROJECT_NAME,START_TIME,
CFULL_NAME,PROJECT_STATUS,PROJECT_ID FROM VIEW_PROJECT_STEP_USER WHERE 1=1 {0} ", condition);
            DataTable dt = DbHelperSQL.GetTable(strSQL);
            return DAL_Helper.CommonFillList<Model.VIEW_PROJECT_STEP_USER>(dt);
        }

        /// <summary>
        /// 获取项目步骤信息
        /// </summary>
        /// <param name="where">条件</param>
        /// <param name="currentpage">当前页</param>
        /// <param name="pagesize">页显示数目</param>
        /// <param name="totalrecord">总条数</param>
        /// <returns></returns>
        public Model.VIEW_PROJECT_STEP_USER get_paging_project_info(Model.VIEW_PROJECT_STEP_USER where)
        {
            string condition = DAL_Helper.GetWhereCondition(where);
            string strSQL = string.Format(@"SELECT DISTINCT PROJECT_TYPE,PROJECT_NAME,START_TIME,ARCHIVE_ID,ARCHIVE_TASK_ID,
CFULL_NAME,PROJECT_STATUS,PROJECT_ID,TOP_RESPONSE_DEPT FROM VIEW_PROJECT_STEP_USER WHERE 1=1 {0} ", condition);
            DataTable dt = DbHelperSQL.GetTable(strSQL);
            if (dt.Rows.Count > 0)
            {
                return DAL_Helper.CommonFillList<Model.VIEW_PROJECT_STEP_USER>(dt)[0];
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

