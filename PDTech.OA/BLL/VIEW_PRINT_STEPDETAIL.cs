using System;
using System.Data;
using System.Collections.Generic;
using Maticsoft.Common;
using PDTech.OA.Model;
namespace PDTech.OA.BLL
{
	/// <summary>
	/// VIEW_PRINT_STEPDETAIL
	/// </summary>
	public partial class VIEW_PRINT_STEPDETAIL
	{
		private readonly PDTech.OA.DAL.VIEW_PRINT_STEPDETAIL dal=new PDTech.OA.DAL.VIEW_PRINT_STEPDETAIL();
		public VIEW_PRINT_STEPDETAIL()
		{}
		#region  BasicMethod

        /// <summary>
        /// 获取用户信息---未分页
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public IList<Model.VIEW_PRINT_STEPDETAIL> get_PrintInfoList(Model.VIEW_PRINT_STEPDETAIL where)
        {
            return dal.get_PrintInfoList(where);
        }
        /// <summary>
        /// 获取用户信息---未分页
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public IList<Model.VIEW_PRINT_STEPDETAIL> get_PrintInfoListAll(Model.VIEW_PRINT_STEPDETAIL where)
        {
            return dal.get_PrintInfoListAll(where);
        }
		#endregion  BasicMethod
		#region  ExtensionMethod

		#endregion  ExtensionMethod
	}
}

