using System;
using System.Data;
using System.Collections.Generic;
using Maticsoft.Common;
using PDTech.OA.Model;
namespace PDTech.OA.BLL
{
	/// <summary>
	/// VIEW_RISK_ORCHIVE_PROJECT
	/// </summary>
	public partial class VIEW_RISK_ORCHIVE_PROJECT
	{
		private readonly PDTech.OA.DAL.VIEW_RISK_ORCHIVE_PROJECT dal=new PDTech.OA.DAL.VIEW_RISK_ORCHIVE_PROJECT();
		public VIEW_RISK_ORCHIVE_PROJECT()
		{}
		#region  BasicMethod

		/// <summary>
        /// 获取信息---分页
        /// </summary>
        /// <param name="where"></param>
        /// <param name="currentpage"></param>
        /// <param name="pagesize"></param>
        /// <param name="totalrecord"></param>
        /// <returns></returns>
        public IList<Model.VIEW_RISK_ORCHIVE_PROJECT> get_paging_viewList(Model.VIEW_RISK_ORCHIVE_PROJECT where, int currentpage, int pagesize, out int totalrecord)
        {
            return dal.get_paging_viewList(where, currentpage, pagesize, out totalrecord);
        }

        /// <summary>
        /// 获取信息---未分页
        /// </summary>
        /// <param name="where"></param>
        /// <param name="currentpage"></param>
        /// <param name="pagesize"></param>
        /// <param name="totalrecord"></param>
        /// <returns></returns>
        public IList<Model.VIEW_RISK_ORCHIVE_PROJECT> get_paging_viewList(Model.VIEW_RISK_ORCHIVE_PROJECT where)
        {
            return dal.get_paging_viewList(where);
        }
         /// <summary>
        /// 获取信息
        /// </summary>
        /// <param name="where"></param>
        /// <param name="currentpage"></param>
        /// <param name="pagesize"></param>
        /// <param name="totalrecord"></param>
        /// <returns></returns>
        public Model.VIEW_RISK_ORCHIVE_PROJECT get_paging_viewInfo(Model.VIEW_RISK_ORCHIVE_PROJECT where)
        {
            return dal.get_paging_viewInfo(where);
        }

		#endregion  BasicMethod
		#region  ExtensionMethod

		#endregion  ExtensionMethod
	}
}

