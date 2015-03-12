/**  版本信息模板在安装目录下，可自行修改。
* VIEW_PROJECT_STEP_USER.cs
*
* 功 能： N/A
* 类 名： VIEW_PROJECT_STEP_USER
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2014/7/25 10:53:22   N/A    初版
*
* Copyright (c) 2012 Maticsoft Corporation. All rights reserved.
*┌──────────────────────────────────┐
*│　此技术信息为本公司机密信息，未经本公司书面同意禁止向第三方披露．　│
*│　版权所有：动软卓越（北京）科技有限公司　　　　　　　　　　　　　　│
*└──────────────────────────────────┘
*/
using System;
using System.Data;
using System.Collections.Generic;
using Maticsoft.Common;
using PDTech.OA.Model;
namespace PDTech.OA.BLL
{
	/// <summary>
	/// VIEW_PROJECT_STEP_USER
	/// </summary>
	public partial class VIEW_PROJECT_STEP_USER
	{
		private readonly PDTech.OA.DAL.VIEW_PROJECT_STEP_USER dal=new PDTech.OA.DAL.VIEW_PROJECT_STEP_USER();
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
            return dal.get_paging_project_stepList(where, currentpage, pagesize, out totalrecord);
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
            return dal.get_paging_project_stepList(where);
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
            return dal.get_paging_project_info(where);
        }
		#endregion  BasicMethod
		#region  ExtensionMethod

		#endregion  ExtensionMethod
	}
}

