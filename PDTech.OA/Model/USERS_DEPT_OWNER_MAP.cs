/**  版本信息模板在安装目录下，可自行修改。
* USERS_DEPT_OWNER_MAP.cs
*
* 功 能： N/A
* 类 名： USERS_DEPT_OWNER_MAP
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2014-9-23 13:30:48   N/A    初版
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
	/// 领导分管部门映射表
	/// </summary>
	[Serializable]
	public partial class USERS_DEPT_OWNER_MAP
	{
		public USERS_DEPT_OWNER_MAP()
		{}
		#region Model
		private int _user_id;
		private int _department_id;
		/// <summary>
		/// 用户ID
		/// </summary>
		public int USER_ID
		{
			set{ _user_id=value;}
			get{return _user_id;}
		}
		/// <summary>
		/// 下属部门ID
		/// </summary>
		public int DEPARTMENT_ID
		{
			set{ _department_id=value;}
			get{return _department_id;}
		}
		#endregion Model

	}
}

