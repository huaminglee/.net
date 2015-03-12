using System;
using System.Data;
using System.Collections.Generic;
using PDTech.OA.Model;
namespace PDTech.OA.BLL
{
	/// <summary>
	/// VIEW_ARCHIVE_TYPE_STEP
	/// </summary>
	public partial class VIEW_ARCHIVE_TYPE_STEP
	{
		private readonly PDTech.OA.DAL.VIEW_ARCHIVE_TYPE_STEP dal=new PDTech.OA.DAL.VIEW_ARCHIVE_TYPE_STEP();
		public VIEW_ARCHIVE_TYPE_STEP()
		{}
		#region  BasicMethod

        /// <summary>
        /// 获取一条信息
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public Model.VIEW_ARCHIVE_TYPE_STEP Get_ViewInfo(Model.VIEW_ARCHIVE_TYPE_STEP Model)
        {
            return dal.Get_ViewInfo(Model);
        }
        /// <summary>
        /// 获取步骤信息--返回dataTable
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public DataTable get_vStepTab(Model.VIEW_ARCHIVE_TYPE_STEP where)
        {
            return dal.get_vStepTab(where);
        }
        /// <summary>
        /// 获取步骤绑定数据---未分页
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public IList<Model.VIEW_ARCHIVE_TYPE_STEP> get_vStepList(Model.VIEW_ARCHIVE_TYPE_STEP where)
        {
            return dal.get_vStepList(where);
        }
		#endregion  BasicMethod
		#region  ExtensionMethod

		#endregion  ExtensionMethod
	}
}

