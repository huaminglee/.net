/**  版本信息模板在安装目录下，可自行修改。
* SYS_BASE_INFO.cs
*
* 功 能： N/A
* 类 名： SYS_BASE_INFO
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2014-6-26 9:19:28   N/A    初版
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
	/// 系统基础信息维护，如来文单位，发文单位，文种。。。。。
	/// </summary>
	[Serializable]
	public partial class SYS_BASE_INFO
	{
		public SYS_BASE_INFO()
		{}
		#region Model
		private decimal _sys_base_id;
		private string _sys_type;
		private string _base_jc;
		private string _base_name;
		/// <summary>
		/// 系统基础信息定义表
		/// </summary>
		public decimal SYS_BASE_ID
		{
			set{ _sys_base_id=value;}
			get{return _sys_base_id;}
		}
		/// <summary>
		/// 基础信息类型
		/// </summary>
		public string SYS_TYPE
		{
			set{ _sys_type=value;}
			get{return _sys_type;}
		}
		/// <summary>
		/// 信息简称
		/// </summary>
		public string BASE_JC
		{
			set{ _base_jc=value;}
			get{return _base_jc;}
		}
		/// <summary>
		/// 基础信息名称，如来文单位，发文单位，文种，
		/// </summary>
		public string BASE_NAME
		{
			set{ _base_name=value;}
			get{return _base_name;}
		}
		#endregion Model

	}
}

