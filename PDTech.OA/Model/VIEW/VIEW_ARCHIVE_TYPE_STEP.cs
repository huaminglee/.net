using System;
namespace PDTech.OA.Model
{
	/// <summary>
	/// VIEW_ARCHIVE_TYPE_STEP:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class VIEW_ARCHIVE_TYPE_STEP
	{
		public VIEW_ARCHIVE_TYPE_STEP()
		{}
		#region Model
		private decimal? _archive_type;
		private decimal _step_id;
		private decimal _flow_template_id;
		private string _step_name;
		private decimal? _next_step_id;
		private string _is_skip;
		private string _from_id;
		private string _right_code;
		private string _is_need_response_user;
		private string _is_return_to_response_user;
		private string _is_copy_to_response_user;
		private decimal? _start_new_flow_id;
		private string _end_flag;
		private string _limit_time_flag;
		private string _start_flag;
		private string _is_allow_multi_receive;
		private string _next_step_name;
		/// <summary>
		/// 
		/// </summary>
		public decimal? ARCHIVE_TYPE
		{
			set{ _archive_type=value;}
			get{return _archive_type;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal STEP_ID
		{
			set{ _step_id=value;}
			get{return _step_id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal FLOW_TEMPLATE_ID
		{
			set{ _flow_template_id=value;}
			get{return _flow_template_id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string STEP_NAME
		{
			set{ _step_name=value;}
			get{return _step_name;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? NEXT_STEP_ID
		{
			set{ _next_step_id=value;}
			get{return _next_step_id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string IS_SKIP
		{
			set{ _is_skip=value;}
			get{return _is_skip;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string FROM_ID
		{
			set{ _from_id=value;}
			get{return _from_id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string RIGHT_CODE
		{
			set{ _right_code=value;}
			get{return _right_code;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string IS_NEED_RESPONSE_USER
		{
			set{ _is_need_response_user=value;}
			get{return _is_need_response_user;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string IS_RETURN_TO_RESPONSE_USER
		{
			set{ _is_return_to_response_user=value;}
			get{return _is_return_to_response_user;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string IS_COPY_TO_RESPONSE_USER
		{
			set{ _is_copy_to_response_user=value;}
			get{return _is_copy_to_response_user;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? START_NEW_FLOW_ID
		{
			set{ _start_new_flow_id=value;}
			get{return _start_new_flow_id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string END_FLAG
		{
			set{ _end_flag=value;}
			get{return _end_flag;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string LIMIT_TIME_FLAG
		{
			set{ _limit_time_flag=value;}
			get{return _limit_time_flag;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string START_FLAG
		{
			set{ _start_flag=value;}
			get{return _start_flag;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string IS_ALLOW_MULTI_RECEIVE
		{
			set{ _is_allow_multi_receive=value;}
			get{return _is_allow_multi_receive;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string NEXT_STEP_NAME
		{
			set{ _next_step_name=value;}
			get{return _next_step_name;}
		}
		#endregion Model

	}
}

