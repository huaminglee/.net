/**  版本信息模板在安装目录下，可自行修改。
* OPERATION_LOG.cs
*
* 功 能： N/A
* 类 名： OPERATION_LOG
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2014-6-27 14:30:09   N/A    初版
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
	/// OPERATION_LOG
	/// </summary>
	public partial class OPERATION_LOG
	{
		private readonly PDTech.OA.DAL.OPERATION_LOG dal=new PDTech.OA.DAL.OPERATION_LOG();
		public OPERATION_LOG()
		{}
		#region  BasicMethod
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(decimal LOG_ID)
		{
			return dal.Exists(LOG_ID);
		}

		
         /// <summary>
        /// 获取一条信息
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public Model.OPERATION_LOG GetLogInfo(decimal lId)
        {
            return dal.GetLogInfo(lId);
        }

        /// <summary>
        /// 获取用户信息-使用分页
        /// </summary>
        /// <param name="where"></param>
        /// <param name="currentpage"></param>
        /// <param name="pagesize"></param>
        /// <param name="totalrecord"></param>
        /// <returns></returns>
        public IList<Model.OPERATION_LOG> get_Paging_LogInfoList(Model.OPERATION_LOG where, int currentpage, int pagesize, out int totalrecord)
        {
            return dal.get_Paging_LogInfoList(where, currentpage, pagesize, out totalrecord);
        }

        /// <summary>
        /// 获取用户信息-使用分页
        /// </summary>
        /// <param name="where"></param>
        /// <param name="currentpage"></param>
        /// <param name="pagesize"></param>
        /// <param name="totalrecord"></param>
        /// <returns></returns>
        public IList<Model.OPERATION_LOG> get_Paging_LogInfoList(string strSQL, int currentpage, int pagesize, out int totalrecord)
        {
            return dal.get_Paging_LogInfoList(strSQL, currentpage, pagesize, out totalrecord);
        }
		#endregion  BasicMethod
		#region  ExtensionMethod

		#endregion  ExtensionMethod
	}
}

