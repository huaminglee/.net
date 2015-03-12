using System;
using System.Data;
using System.Text;
using System.Collections.Generic;
using Maticsoft.DBUtility;//Please add references
namespace PDTech.OA.DAL
{
	/// <summary>
	/// 数据访问类:VIEW_ARCHIVE_FILE_TASK
	/// </summary>
	public partial class VIEW_ARCHIVE_FILE_TASK
	{
		public VIEW_ARCHIVE_FILE_TASK()
		{}
		#region  BasicMethod

        /// <summary>
        /// 获取任务信息-使用分页
        /// </summary>
        /// <param name="where"></param>
        /// <param name="currentpage"></param>
        /// <param name="pagesize"></param>
        /// <param name="totalrecord"></param>
        /// <returns></returns>
        public IList<Model.VIEW_ARCHIVE_FILE_TASK> get_Paging_taskInfoList(Model.VIEW_ARCHIVE_FILE_TASK where, int currentpage, int pagesize, out int totalrecord)
        {
            string condition = DAL_Helper.GetWhereCondition(where);
            string strSQL = string.Format("SELECT TOP (100) PERCENT * FROM VIEW_ARCHIVE_FILE_TASK WHERE 1=1 {0} ", condition);
            PageDescribe pdes = new PageDescribe();
            pdes.CurrentPage = currentpage;
            pdes.PageSize = pagesize;
            DataTable dt = pdes.PageDescribes(strSQL, "START_TIME","DESC");
            totalrecord = pdes.RecordCount;
            return DAL_Helper.CommonFillList<Model.VIEW_ARCHIVE_FILE_TASK>(dt);
        }

		#endregion  BasicMethod
		#region  ExtensionMethod
        public DataTable getArchiveTongji(string strwhere,string ftype)
        {
            string strSQL = string.Format("SELECT COUNT(1) as Totalnum,{0} FROM VIEW_ARCHIVE_FILE_TASK WHERE 1=1 {1} group by {0} ORDER BY Totalnum DESC", ftype, strwhere);
            DataTable dt = DbHelperSQL.GetTable(strSQL);
            return dt;
        }
        public DataTable getArchiveunfinished(string strwhere)
        {
            string strSQL = string.Format("select COUNT(1) as Unfinishednum from VIEW_ARCHIVE_FILE_TASK where TASK_STATE=0 and {0} ", strwhere);
            DataTable dt = DbHelperSQL.GetTable(strSQL);
            return dt;
        }
		#endregion  ExtensionMethod
	}
}

