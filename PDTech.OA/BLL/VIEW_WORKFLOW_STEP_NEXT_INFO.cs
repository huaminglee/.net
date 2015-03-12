using System;
using System.Data;
using System.Collections.Generic;
using Maticsoft.Common;
using System.Collections.Generic;
using PDTech.OA.Model;
namespace PDTech.OA.BLL
{
	/// <summary>
	/// VIEW_WORKFLOW_STEP_NEXT_INFO
	/// </summary>
	public partial class VIEW_WORKFLOW_STEP_NEXT_INFO
	{
		private readonly PDTech.OA.DAL.VIEW_WORKFLOW_STEP_NEXT_INFO dal=new PDTech.OA.DAL.VIEW_WORKFLOW_STEP_NEXT_INFO();
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
            return dal.Get_ViewInfo(Model);
        }
		#endregion  BasicMethod
		#region  ExtensionMethod

		#endregion  ExtensionMethod
	}
}

