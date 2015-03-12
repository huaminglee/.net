/**  版本信息模板在安装目录下，可自行修改。
* API_MESSAGES.cs
*
* 功 能： N/A
* 类 名： API_MESSAGES
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2014-7-11 15:35:20   N/A    初版
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
	/// 外部接口表
	/// </summary>
	[Serializable]
	public partial class API_MESSAGES
	{
		public API_MESSAGES()
		{}
		#region Model
		private decimal _api_message_id;
		private string _message_type;
		private string _from_type;
		private decimal? _from_id;
		private string _to_type;
		private decimal? _to_id;
		private DateTime _insert_time;
		private DateTime? _try_time;
		private decimal? _trials;
		private string _response;
		private string _data1;
		private string _data2;
		private string _data3;
		private string _data4;
		private decimal _message_stat;
		private decimal? _creator;
		private string _data5;
		/// <summary>
		/// 对外接口消息ID主键
		/// </summary>
		public decimal API_MESSAGE_ID
		{
			set{ _api_message_id=value;}
			get{return _api_message_id;}
		}
		/// <summary>
		/// 接口消息类型eg: COM_SMS:串口短信、.....
		/// </summary>
		public string MESSAGE_TYPE
		{
			set{ _message_type=value;}
			get{return _message_type;}
		}
		/// <summary>
		/// 消息来源类型如(OA_ARCHIVE,OA_MESSAGE)
		/// </summary>
		public string FROM_TYPE
		{
			set{ _from_type=value;}
			get{return _from_type;}
		}
		/// <summary>
		/// 任务来源ID，
		/// </summary>
		public decimal? FROM_ID
		{
			set{ _from_id=value;}
			get{return _from_id;}
		}
		/// <summary>
		/// 消息接收者类型如(OA_USER系统用户，其它外部系统)
		/// </summary>
		public string TO_TYPE
		{
			set{ _to_type=value;}
			get{return _to_type;}
		}
		/// <summary>
		/// 消息接收方ID
		/// </summary>
		public decimal? TO_ID
		{
			set{ _to_id=value;}
			get{return _to_id;}
		}
		/// <summary>
		/// 消息生成时间
		/// </summary>
		public DateTime INSERT_TIME
		{
			set{ _insert_time=value;}
			get{return _insert_time;}
		}
		/// <summary>
		/// 预计消息发送时间
		/// </summary>
		public DateTime? TRY_TIME
		{
			set{ _try_time=value;}
			get{return _try_time;}
		}
		/// <summary>
		/// 消息发送次数
		/// </summary>
		public decimal? TRIALS
		{
			set{ _trials=value;}
			get{return _trials;}
		}
		/// <summary>
		/// 消息发送回执
		/// </summary>
		public string RESPONSE
		{
			set{ _response=value;}
			get{return _response;}
		}
		/// <summary>
		/// 扩展数据1:如可用做存储发送消息的内容
		/// </summary>
		public string DATA1
		{
			set{ _data1=value;}
			get{return _data1;}
		}
		/// <summary>
		/// 扩展数据2
		/// </summary>
		public string DATA2
		{
			set{ _data2=value;}
			get{return _data2;}
		}
		/// <summary>
		/// 扩展数据3
		/// </summary>
		public string DATA3
		{
			set{ _data3=value;}
			get{return _data3;}
		}
		/// <summary>
		/// 扩展数据4
		/// </summary>
		public string DATA4
		{
			set{ _data4=value;}
			get{return _data4;}
		}
		/// <summary>
		/// 消息状态0：待发送 1：已发送
		/// </summary>
		public decimal MESSAGE_STAT
		{
			set{ _message_stat=value;}
			get{return _message_stat;}
		}
		/// <summary>
		/// 创建人
		/// </summary>
		public decimal? CREATOR
		{
			set{ _creator=value;}
			get{return _creator;}
		}
		/// <summary>
		/// 扩展数据5
		/// </summary>
		public string DATA5
		{
			set{ _data5=value;}
			get{return _data5;}
		}
		#endregion Model

	}
}

