/**  版本信息模板在安装目录下，可自行修改。
* USER_DUTY_RESPONSIBILITY_MAP.cs
*
* 功 能： N/A
* 类 名： USER_DUTY_RESPONSIBILITY_MAP
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2014-6-23 16:26:17   N/A    初版
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
	/// 岗位职责映射表
	/// </summary>
	[Serializable]
	public partial class USER_DUTY_RESPONSIBILITY_MAP
	{
		public USER_DUTY_RESPONSIBILITY_MAP()
		{}
		#region Model
		private decimal? _user_id;
		private decimal? _duty_responsibility_id;
		/// <summary>
		/// 用户ID
		/// </summary>
		public decimal? USER_ID
		{
			set{ _user_id=value;}
			get{return _user_id;}
		}
		/// <summary>
		/// 岗位职责ID
		/// </summary>
		public decimal? DUTY_RESPONSIBILITY_ID
		{
			set{ _duty_responsibility_id=value;}
			get{return _duty_responsibility_id;}
		}
		#endregion Model

	}
}

