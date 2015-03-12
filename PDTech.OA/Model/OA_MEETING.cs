/**  版本信息模板在安装目录下，可自行修改。
* OA_MEETING.cs
*
* 功 能： N/A
* 类 名： OA_MEETING
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2014-7-16 9:31:23   N/A    初版
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
	/// 公告消息表
	/// </summary>
	[Serializable]
	public partial class OA_MEETING
	{
		public OA_MEETING()
		{}
		#region Model
		private decimal _meeting_id;
		private string _title;
		private string _content;
		private decimal? _sender;
		private DateTime? _create_time;
		private decimal? _state;
		private decimal? _meeting_room_id;
		private string _location;
		private DateTime? _start_time;
		private DateTime? _end_time;
		private string _dept;
		private decimal? _host_user;
		private string _other_pers;
		private string _remark;
		/// <summary>
		/// 会议ID
		/// </summary>
		public decimal MEETING_ID
		{
			set{ _meeting_id=value;}
			get{return _meeting_id;}
		}
		/// <summary>
        /// 会议名称
		/// </summary>
		public string TITLE
		{
			set{ _title=value;}
			get{return _title;}
		}
		/// <summary>
		/// 会议内容
		/// </summary>
		public string CONTENT
		{
			set{ _content=value;}
			get{return _content;}
		}
		/// <summary>
		/// 会议发起人
		/// </summary>
		public decimal? SENDER
		{
			set{ _sender=value;}
			get{return _sender;}
		}
		/// <summary>
		/// 会议发起时间
		/// </summary>
		public DateTime? CREATE_TIME
		{
			set{ _create_time=value;}
			get{return _create_time;}
		}
		/// <summary>
		/// 会议状态0：编辑中(未发送)，1：已发送，9：已取消
		/// </summary>
		public decimal? STATE
		{
			set{ _state=value;}
			get{return _state;}
		}
		/// <summary>
		/// 会议室ID
		/// </summary>
		public decimal? MEETING_ROOM_ID
		{
			set{ _meeting_room_id=value;}
			get{return _meeting_room_id;}
		}
		/// <summary>
		/// 会议地址(如果MEETING_ROOM_ID) 不为空,则用会议室名称，否则采用手工输入的会议地点
		/// </summary>
		public string LOCATION
		{
			set{ _location=value;}
			get{return _location;}
		}
		/// <summary>
		/// 会议开始时间
		/// </summary>
		public DateTime? START_TIME
		{
			set{ _start_time=value;}
			get{return _start_time;}
		}
		/// <summary>
		/// 会议结束时间
		/// </summary>
		public DateTime? END_TIME
		{
			set{ _end_time=value;}
			get{return _end_time;}
		}
		/// <summary>
		/// 承办部门
		/// </summary>
		public string DEPT
		{
			set{ _dept=value;}
			get{return _dept;}
		}
		/// <summary>
		/// 主持人
		/// </summary>
		public decimal? HOST_USER
		{
			set{ _host_user=value;}
			get{return _host_user;}
		}
		/// <summary>
		/// 其它非本局人员(文本输入)
		/// </summary>
		public string OTHER_PERS
		{
			set{ _other_pers=value;}
			get{return _other_pers;}
		}
		/// <summary>
		/// 备注
		/// </summary>
		public string REMARK
		{
			set{ _remark=value;}
			get{return _remark;}
		}
		#endregion Model

	}
}

