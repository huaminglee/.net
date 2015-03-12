using System;
using System.Data;
using System.Collections.Generic;
using Maticsoft.Common;
using PDTech.OA.Model;
namespace PDTech.OA.BLL
{
	/// <summary>
	/// VIEW_PRO_STEP_TYPE
	/// </summary>
	public partial class VIEW_PRO_STEP_TYPE
	{
		private readonly PDTech.OA.DAL.VIEW_PRO_STEP_TYPE dal=new PDTech.OA.DAL.VIEW_PRO_STEP_TYPE();
		public VIEW_PRO_STEP_TYPE()
		{}
		#region  BasicMethod

		 /// <summary>
        /// 获取符合条件的项目任务信息
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public IList<Model.VIEW_PRO_STEP_TYPE> get_viewStepAndType(Model.VIEW_PRO_STEP_TYPE where)
        {
            return dal.get_viewStepAndType(where);
        }

         /// <summary>
        /// 获取项目步骤及步骤类型信息
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public Model.VIEW_PRO_STEP_TYPE getviewstepAndtype(Model.VIEW_PRO_STEP_TYPE where)
        {
            return dal.getviewstepAndtype(where);
        }

		#endregion  BasicMethod
		#region  ExtensionMethod

		#endregion  ExtensionMethod
	}
}

