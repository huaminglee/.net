/**  版本信息模板在安装目录下，可自行修改。
* DEPARTMENT_DEFAULT_USER.cs
*
* 功 能： N/A
* 类 名： DEPARTMENT_DEFAULT_USER
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2014-6-26 9:19:44   N/A    初版
*
* Copyright (c) 2012 Maticsoft Corporation. All rights reserved.
*┌──────────────────────────────────┐
*│　此技术信息为本公司机密信息，未经本公司书面同意禁止向第三方披露．　│
*│　版权所有：动软卓越（北京）科技有限公司　　　　　　　　　　　　　　│
*└──────────────────────────────────┘
*/
using System;
namespace PDTech.OA.Model
{
	/// <summary>
	/// 部门默认公文接收人
	/// </summary>
	[Serializable]
	public partial class DEPARTMENT_DEFAULT_USER
	{
		public DEPARTMENT_DEFAULT_USER()
		{}
		#region Model
		private decimal? _department_id;
		private decimal? _user_id;
		/// <summary>
		/// 部门ID
		/// </summary>
		public decimal? DEPARTMENT_ID
		{
			set{ _department_id=value;}
			get{return _department_id;}
		}
		/// <summary>
		/// 默认公文接收人
		/// </summary>
		public decimal? USER_ID
		{
			set{ _user_id=value;}
			get{return _user_id;}
		}
		#endregion Model

	}
}

