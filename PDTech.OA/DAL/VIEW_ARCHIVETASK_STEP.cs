using System;
using System.Data;
using System.Text;
using System.Collections.Generic;
using Maticsoft.DBUtility;//Please add references

namespace PDTech.OA.DAL
{
	/// <summary>
	/// 数据访问类:VIEW_ARCHIVETASK_STEP
	/// </summary>
	public partial class VIEW_ARCHIVETASK_STEP
	{
		public VIEW_ARCHIVETASK_STEP()
		{}
		#region  BasicMethod
        /// <summary>
        /// 获取流程---未分页
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public IList<Model.VIEW_ARCHIVETASK_STEP> get_ArchiveTask_StepList(Model.VIEW_ARCHIVETASK_STEP where)
        {
            string condition = DAL_Helper.GetWhereCondition(where);
            string strSQL = string.Format(@"SELECT STEP_NAME,FULL_NAME,START_TIME,END_TIME,TASK_STATE,ARCHIVE_ID,END_FLAG 
FROM VIEW_ARCHIVETASK_STEP WHERE 1=1 {0} ", condition);
            DataTable dt = DbHelperSQL.GetTable(strSQL);
            return DAL_Helper.CommonFillList<Model.VIEW_ARCHIVETASK_STEP>(dt);
        }
        /// <summary>
        /// 获取流程-使用分页
        /// </summary>
        /// <param name="where"></param>
        /// <param name="currentpage"></param>
        /// <param name="pagesize"></param>
        /// <param name="totalrecord"></param>
        /// <returns></returns>
        public IList<Model.VIEW_ARCHIVETASK_STEP> get_Paging_ArchiveTask_StepList(Model.VIEW_ARCHIVETASK_STEP where, int currentpage, int pagesize, out int totalrecord)
        {
            string condition = DAL_Helper.GetWhereCondition(where);
            string strSQL = string.Format(@"SELECT TOP (100) PERCENT * FROM VIEW_ARCHIVETASK_STEP WHERE 1=1 {0} ", condition);
            PageDescribe pdes = new PageDescribe();
            pdes.CurrentPage = currentpage;
            pdes.PageSize = pagesize;
            DataTable dt = pdes.PageDescribes(strSQL);
            totalrecord = pdes.RecordCount;
            return DAL_Helper.CommonFillList<Model.VIEW_ARCHIVETASK_STEP>(dt);
        }
        /// <summary>
        /// 获取步骤
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public Model.VIEW_ARCHIVETASK_STEP get_StempInfo(Model.VIEW_ARCHIVETASK_STEP where)
        {
            string condition = DAL_Helper.GetWhereCondition(where);
            string strSQL = string.Format(@"SELECT *
FROM VIEW_ARCHIVETASK_STEP WHERE 1=1 {0} ", condition);
            DataTable dt = DbHelperSQL.GetTable(strSQL);
            if (dt.Rows.Count > 0)
            {
                return DAL_Helper.CommonFillList<Model.VIEW_ARCHIVETASK_STEP>(dt)[0];
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

