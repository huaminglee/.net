using System;
using System.Data;
using System.Collections.Generic;
using PDTech.OA.DAL;
using PDTech.OA.Model;

namespace PDTech.OA.BLL
{
	/// <summary>
	/// VIEW_RISK_ATT
	/// </summary>
	public partial class VIEW_RISK_ATT
	{
        private readonly PDTech.OA.DAL.VIEW_RISK_ATT dal = new PDTech.OA.DAL.VIEW_RISK_ATT();
		public VIEW_RISK_ATT()
		{}
		#region  BasicMethod

        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public IList<PDTech.OA.Model.VIEW_RISK_ATT> get_viewList(Model.VIEW_RISK_ATT where, int currentpage, int pagesize, out int totalrecord)
        {
            return dal.get_viewList(where, currentpage,pagesize,out totalrecord);
        }
        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public IList<PDTech.OA.Model.VIEW_RISK_ATT> get_viewList(Model.VIEW_RISK_ATT where)
        {
            return dal.get_viewList(where);
        }
         /// <summary>
        /// 获取部门
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public IList<PDTech.OA.Model.VIEW_RISK_ATT> getDeptNum(Model.VIEW_RISK_ATT where)
        {
            return dal.getDeptNum(where);
        }
		#endregion  BasicMethod
		#region  ExtensionMethod

		#endregion  ExtensionMethod
	}
}

