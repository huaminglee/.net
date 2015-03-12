using System;
using System.Data;
using System.Collections.Generic;
using Maticsoft.Common;
using PDTech.OA.Model;
namespace PDTech.OA.BLL
{
	/// <summary>
	/// VIEW_OUTMESSAGE
	/// </summary>
	public partial class VIEW_OUTMESSAGE
	{
		private readonly PDTech.OA.DAL.VIEW_OUTMESSAGE dal=new PDTech.OA.DAL.VIEW_OUTMESSAGE();
		public VIEW_OUTMESSAGE()
		{}
		#region  BasicMethod

		/// <summary>
        /// 获取并返回符合条件的公告列表
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public IList<Model.VIEW_OUTMESSAGE> get_outmessageList(Model.VIEW_OUTMESSAGE where)
        {
            return dal.get_outmessageList(where);
        }
         /// <summary>
        /// 获取公告信息列表-使用分页
        /// </summary>
        /// <param name="where"></param>
        /// <param name="currentpage"></param>
        /// <param name="pagesize"></param>
        /// <param name="totalrecord"></param>
        /// <returns></returns>
        public IList<Model.VIEW_OUTMESSAGE> get_Paging_outMsgList(Model.VIEW_OUTMESSAGE where, int currentpage, int pagesize, out int totalrecord)
        {
            return dal.get_Paging_outMsgList(where, currentpage, pagesize, out totalrecord);
        }

		#endregion  BasicMethod
		#region  ExtensionMethod

		#endregion  ExtensionMethod
	}
}

