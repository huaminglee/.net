/**  版本信息模板在安装目录下，可自行修改。
* OA_QUESTION_TEST_MAP.cs
*
* 功 能： N/A
* 类 名： OA_QUESTION_TEST_MAP
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2014/7/22 15:35:52   N/A    初版
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
	/// 试题和试卷关联表
	/// </summary>
	[Serializable]
	public partial class OA_QUESTION_TEST_MAP
	{
		public OA_QUESTION_TEST_MAP()
		{}
		#region Model
		private string _edu_map_guid;
		private string _edu_q_guid;
		private string _edu_t_guid;
        private decimal? _map_index;
		/// <summary>
		/// 试题和试卷关联主键
		/// </summary>
		public string EDU_MAP_GUID
		{
			set{ _edu_map_guid=value;}
			get{return _edu_map_guid;}
		}
		/// <summary>
		/// 试题ID
		/// </summary>
		public string EDU_Q_GUID
		{
			set{ _edu_q_guid=value;}
			get{return _edu_q_guid;}
		}
		/// <summary>
		/// 试卷ID
		/// </summary>
		public string EDU_T_GUID
		{
			set{ _edu_t_guid=value;}
			get{return _edu_t_guid;}
		}
        /// <summary>
        /// 试题在试卷中属于第几题
        /// </summary>
        public decimal? MAP_INDEX
        {
            set { _map_index = value; }
            get { return _map_index; }
        }
		#endregion Model

	}
}

