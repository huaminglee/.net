using System;
using System.Data;
using System.Text;
using System.Collections.Generic;
using Maticsoft.DBUtility;//Please add references
namespace PDTech.OA.DAL
{
	/// <summary>
	/// 数据访问类:VIEW_PROJECT_USER
	/// </summary>
	public partial class VIEW_PROJECT_USER
	{
		public VIEW_PROJECT_USER()
		{}
		#region  BasicMethod

        /// <summary>
        /// 获取项目信息
        /// </summary>
        /// <param name="where">条件</param>
        /// <param name="currentpage">当前页</param>
        /// <param name="pagesize">页显示数目</param>
        /// <param name="totalrecord">总条数</param>
        /// <returns></returns>
        public IList<Model.VIEW_PROJECT_USER> get_paging_projectList(Model.VIEW_PROJECT_USER where, int currentpage, int pagesize, out int totalrecord)
        {
            string condition = DAL_Helper.GetWhereCondition(where);
            string strSQL = string.Format("SELECT TOP (100) PERCENT * FROM VIEW_PROJECT_USER WHERE 1=1 {0} ", condition);
            PageDescribe pdes = new PageDescribe();
            pdes.CurrentPage = currentpage;
            pdes.PageSize = pagesize;
            DataTable dt = pdes.PageDescribes(strSQL);
            totalrecord = pdes.RecordCount;
            return DAL_Helper.CommonFillList<Model.VIEW_PROJECT_USER>(dt);
        }

		#endregion  BasicMethod
		#region  ExtensionMethod

		#endregion  ExtensionMethod
	}
}

