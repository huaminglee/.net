using System;
using System.Data;
using System.Collections.Generic;
using Maticsoft.Common;
using PDTech.OA.Model;
namespace PDTech.OA.BLL
{
	/// <summary>
	/// VIEW_ARCHIVETASK_STEP
	/// </summary>
	public partial class VIEW_ARCHIVETASK_STEP
	{
		private readonly PDTech.OA.DAL.VIEW_ARCHIVETASK_STEP dal=new PDTech.OA.DAL.VIEW_ARCHIVETASK_STEP();
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
            return dal.get_ArchiveTask_StepList(where);
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
            return dal.get_Paging_ArchiveTask_StepList(where, currentpage, pagesize, out totalrecord);
        }
        /// <summary>
        /// 获取步骤
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public Model.VIEW_ARCHIVETASK_STEP get_StempInfo(Model.VIEW_ARCHIVETASK_STEP where)
        {
            return dal.get_StempInfo(where);
        }
		#endregion  BasicMethod
		#region  ExtensionMethod

		#endregion  ExtensionMethod
	}
}

