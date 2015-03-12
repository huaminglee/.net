using System;
using System.Data;
using System.Collections.Generic;
using Maticsoft.Common;
using PDTech.OA.Model;
namespace PDTech.OA.BLL
{
	/// <summary>
	/// VIEW_USER_MSGINFO
	/// </summary>
	public partial class VIEW_USER_MSGINFO
	{
		private readonly PDTech.OA.DAL.VIEW_USER_MSGINFO dal=new PDTech.OA.DAL.VIEW_USER_MSGINFO();
		public VIEW_USER_MSGINFO()
		{}
		#region  BasicMethod

        /// <summary>
        /// 获取公告信息列表---未分页
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public IList<Model.VIEW_USER_MSGINFO> get_MsgList(Model.VIEW_USER_MSGINFO model)
        {
            return dal.get_MsgList(model);
        }

        /// <summary>
        /// 获取符合条件的公告信息
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public Model.VIEW_USER_MSGINFO get_MsgInfo(Model.VIEW_USER_MSGINFO model)
        {
            return dal.get_MsgInfo(model);
        }
        /// <summary>
        /// 获取符合条件的公告信息
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public Model.VIEW_USER_MSGINFO get_MsgInfo(decimal msgID)
        {
            return dal.get_MsgInfo(msgID);
        }

        /// <summary>
        /// 获取公告信息列表-使用分页
        /// </summary>
        /// <param name="where"></param>
        /// <param name="currentpage"></param>
        /// <param name="pagesize"></param>
        /// <param name="totalrecord"></param>
        /// <returns></returns>
        public IList<Model.VIEW_USER_MSGINFO> get_Paging_MsgInfoList(Model.VIEW_USER_MSGINFO where, int currentpage, int pagesize, out int totalrecord)
        {
            return dal.get_Paging_MsgInfoList(where, currentpage, pagesize, out totalrecord);
        }

		#endregion  BasicMethod
		#region  ExtensionMethod

		#endregion  ExtensionMethod
	}
}

