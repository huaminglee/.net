/**  版本信息模板在安装目录下，可自行修改。
* VIEW_USER_RIGHT.cs
*
* 功 能： N/A
* 类 名： VIEW_USER_RIGHT
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2014-6-26 11:55:54   N/A    初版
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
	/// VIEW_USER_RIGHT
	/// </summary>
	public partial class VIEW_USER_RIGHT
	{
		private readonly PDTech.OA.DAL.VIEW_USER_RIGHT dal=new PDTech.OA.DAL.VIEW_USER_RIGHT();
		public VIEW_USER_RIGHT()
		{}
		#region  BasicMethod

		 /// <summary>
        /// 获取用户权限Code---未分页
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public IList<Model.VIEW_USER_RIGHT> get_ViewList(Model.VIEW_USER_RIGHT where)
        {
            return dal.get_ViewList(where);
        }
		#endregion  BasicMethod
		#region  ExtensionMethod

		#endregion  ExtensionMethod
	}
}

