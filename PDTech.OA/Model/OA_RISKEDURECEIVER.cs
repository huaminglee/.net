/**  版本信息模板在安装目录下，可自行修改。
* OA_RISKEDURECEIVER.cs
*
* 功 能： N/A
* 类 名： OA_RISKEDURECEIVER
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2014/7/22 15:35:10   N/A    初版
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
	/// 教育任务接收表
	/// </summary>
	[Serializable]
	public partial class OA_RISKEDURECEIVER
	{
		public OA_RISKEDURECEIVER()
		{}
		#region Model
        private decimal? _education_id;
		private decimal? _receiver_id;
		private decimal? _read_status;
		private DateTime? _read_time;
        private decimal? _reda_count;
		/// <summary>
		/// 教育任务ID
		/// </summary>
        public decimal? EDUCATION_ID
		{
            set { _education_id = value; }
            get { return _education_id; }
		}
		/// <summary>
		/// 接收人ID
		/// </summary>
		public decimal? RECEIVER_ID
		{
			set{ _receiver_id=value;}
			get{return _receiver_id;}
		}
		/// <summary>
		/// 已读状态0:未读，1:已读
		/// </summary>
		public decimal? READ_STATUS
		{
			set{ _read_status=value;}
			get{return _read_status;}
		}
		/// <summary>
		/// 阅读时间
		/// </summary>
		public DateTime? READ_TIME
		{
			set{ _read_time=value;}
			get{return _read_time;}
		}
        /// <summary>
        /// 阅读次数
        /// </summary>
        public decimal? READ_COUNT
        {
            set { _reda_count = value; }
            get { return _reda_count; }
        }
		#endregion Model

	}
}

