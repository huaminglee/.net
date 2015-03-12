using System;
namespace PDTech.OA.Model
{
	/// <summary>
	/// VIEW_ARCHIVE_FILE_TASK:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class VIEW_ARCHIVE_FILE_TASK
	{
		public VIEW_ARCHIVE_FILE_TASK()
		{}
		#region Model
		private decimal _archive_task_id;
		private decimal? _owner_id;
		private string _task_remark;
		private decimal? _task_state;
		private decimal? _task_type;
		private decimal? _previous_task_id;
		private DateTime? _start_time;
		private DateTime? _end_time;
		private decimal _archive_id;
		private decimal? _archive_type;
		private decimal? _archive_level;
		private decimal? _pri_level;
		private decimal? _is_secret;
		private string _archive_no;
		private decimal? _flow_template_id;
		private decimal? _current_step_id;
		private decimal? _current_state;
		private string _archive_title;
		private string _archive_content;
		private decimal? _creator;
		private decimal? _response_user;
		private DateTime? _create_time;
		private DateTime? _limit_time;
		private string _is_show_in_szyd;
		private decimal? _attribute_log;
		private DateTime? _receive_time;
		private decimal? _attachment_count;
        private string _full_name;
        private string _step_name;
		/// <summary>
		/// 
		/// </summary>
		public decimal ARCHIVE_TASK_ID
		{
			set{ _archive_task_id=value;}
			get{return _archive_task_id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? OWNER_ID
		{
			set{ _owner_id=value;}
			get{return _owner_id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string TASK_REMARK
		{
			set{ _task_remark=value;}
			get{return _task_remark;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? TASK_STATE
		{
			set{ _task_state=value;}
			get{return _task_state;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? TASK_TYPE
		{
			set{ _task_type=value;}
			get{return _task_type;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? PREVIOUS_TASK_ID
		{
			set{ _previous_task_id=value;}
			get{return _previous_task_id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? START_TIME
		{
			set{ _start_time=value;}
			get{return _start_time;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? END_TIME
		{
			set{ _end_time=value;}
			get{return _end_time;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal ARCHIVE_ID
		{
			set{ _archive_id=value;}
			get{return _archive_id;}
		}
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
		public decimal? ARCHIVE_LEVEL
		{
			set{ _archive_level=value;}
			get{return _archive_level;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? PRI_LEVEL
		{
			set{ _pri_level=value;}
			get{return _pri_level;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? IS_SECRET
		{
			set{ _is_secret=value;}
			get{return _is_secret;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ARCHIVE_NO
		{
			set{ _archive_no=value;}
			get{return _archive_no;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? FLOW_TEMPLATE_ID
		{
			set{ _flow_template_id=value;}
			get{return _flow_template_id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? CURRENT_STEP_ID
		{
			set{ _current_step_id=value;}
			get{return _current_step_id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? CURRENT_STATE
		{
			set{ _current_state=value;}
			get{return _current_state;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ARCHIVE_TITLE
		{
			set{ _archive_title=value;}
			get{return _archive_title;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ARCHIVE_CONTENT
		{
			set{ _archive_content=value;}
			get{return _archive_content;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? CREATOR
		{
			set{ _creator=value;}
			get{return _creator;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? RESPONSE_USER
		{
			set{ _response_user=value;}
			get{return _response_user;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? CREATE_TIME
		{
			set{ _create_time=value;}
			get{return _create_time;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? LIMIT_TIME
		{
			set{ _limit_time=value;}
			get{return _limit_time;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string IS_SHOW_IN_SZYD
		{
			set{ _is_show_in_szyd=value;}
			get{return _is_show_in_szyd;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? ATTRIBUTE_LOG
		{
			set{ _attribute_log=value;}
			get{return _attribute_log;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? RECEIVE_TIME
		{
			set{ _receive_time=value;}
			get{return _receive_time;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? ATTACHMENT_COUNT
		{
			set{ _attachment_count=value;}
			get{return _attachment_count;}
		}
        public string FULL_NAME
        {
            set { _full_name = value; }
            get { return _full_name; }
        }
        public string STEP_NAME
        {
            set { _step_name = value; }
            get { return _step_name; }
        }
        public string ARCHIVE_TYPE_NAME
        {
            set;
            get;
        }
        public string DEPARTMENT_NAME
        {
            get;
            set;
        }
		#endregion Model
        #region 自定义 成员

        /// <summary>
        /// 排序字段[格式如：User_ID ASC,User_Name DESC]
        /// </summary>
        public string SortFields
        {
            get;
            set;
        }

        /// <summary>
        /// 自定义查询字段[格式: UserID = '10001' AND UserName= 'Mr.Zore' AND ID NOT (SELECT ID FROM XX)]
        /// </summary>
        public string Append
        {
            get;
            set;
        }

        #endregion
	}
}

