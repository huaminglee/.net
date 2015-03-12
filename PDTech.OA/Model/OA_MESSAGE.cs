using System;
namespace PDTech.OA.Model
{
	/// <summary>
	/// OA_MESSAGE:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class OA_MESSAGE
	{
		public OA_MESSAGE()
		{}
		#region Model
		private decimal _message_id;
		private string _message_title;
		private string _message_content;
		private decimal? _message_sender;
		private DateTime? _message_send_time;
		private decimal? _message_state;
		/// <summary>
		/// 
		/// </summary>
		public decimal MESSAGE_ID
		{
			set{ _message_id=value;}
			get{return _message_id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string MESSAGE_TITLE
		{
			set{ _message_title=value;}
			get{return _message_title;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string MESSAGE_CONTENT
		{
			set{ _message_content=value;}
			get{return _message_content;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? MESSAGE_SENDER
		{
			set{ _message_sender=value;}
			get{return _message_sender;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? MESSAGE_SEND_TIME
		{
			set{ _message_send_time=value;}
			get{return _message_send_time;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? MESSAGE_STATE
		{
			set{ _message_state=value;}
			get{return _message_state;}
		}
		#endregion Model

	}
}

