using System;
using System.Data;
using System.Collections.Generic;
using Maticsoft.Common;
using PDTech.OA.Model;
namespace PDTech.OA.BLL
{
	/// <summary>
	/// VIEW_PROJECT_USER
	/// </summary>
	public partial class VIEW_PROJECT_USER
	{
		private readonly PDTech.OA.DAL.VIEW_PROJECT_USER dal=new PDTech.OA.DAL.VIEW_PROJECT_USER();
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
            return dal.get_paging_projectList(where, currentpage, pagesize, out totalrecord);
        }
		#endregion  BasicMethod
		#region  ExtensionMethod

		#endregion  ExtensionMethod
	}
}

