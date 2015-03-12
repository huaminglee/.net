/**  版本信息模板在安装目录下，可自行修改。
* OA_MEETING_RECEIVER.cs
*
* 功 能： N/A
* 类 名： OA_MEETING_RECEIVER
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2014-7-16 9:31:12   N/A    初版
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
	/// 公告消息接收情况
	/// </summary>
	[Serializable]
	public partial class OA_MEETING_RECEIVER
	{
		public OA_MEETING_RECEIVER()
		{}
		#region Model
		private decimal? _meeting_id;
		private decimal? _receiver_id;
		private decimal? _read_status;
		private DateTime? _read_time;
		/// <summary>
		/// 会议ID
		/// </summary>
		public decimal? MEETING_ID
		{
			set{ _meeting_id=value;}
			get{return _meeting_id;}
		}
		/// <summary>
		/// 接收人
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
		/// 公告阅读时间
		/// </summary>
		public DateTime? READ_TIME
		{
			set{ _read_time=value;}
			get{return _read_time;}
		}
		#endregion Model

	}
}

