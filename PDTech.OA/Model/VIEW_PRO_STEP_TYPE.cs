using System;
namespace PDTech.OA.Model
{
	/// <summary>
	/// VIEW_PRO_STEP_TYPE:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class VIEW_PRO_STEP_TYPE
	{
		public VIEW_PRO_STEP_TYPE()
		{}
		#region Model
		private decimal? _project_step_id;
		private decimal? _project_id;
		private decimal? _step_id;
		private DateTime? _start_time;
		private DateTime? _end_time;
		private decimal? _owner;
		private decimal? _step_status;
		private decimal? _attribute_log;
		private string _step_name;
		private decimal? _project_type;
		/// <summary>
		/// 项目任务步骤ID
		/// </summary>
		public decimal? PROJECT_STEP_ID
		{
			set{ _project_step_id=value;}
			get{return _project_step_id;}
		}
		/// <summary>
		/// 项目ID
		/// </summary>
		public decimal? PROJECT_ID
		{
			set{ _project_id=value;}
			get{return _project_id;}
		}
		/// <summary>
		/// 步骤ID
		/// </summary>
		public decimal? STEP_ID
		{
			set{ _step_id=value;}
			get{return _step_id;}
		}
		/// <summary>
		/// 开始时间
		/// </summary>
		public DateTime? START_TIME
		{
			set{ _start_time=value;}
			get{return _start_time;}
		}
		/// <summary>
		/// 结束时间
		/// </summary>
		public DateTime? END_TIME
		{
			set{ _end_time=value;}
			get{return _end_time;}
		}
		/// <summary>
		/// 代办人员ID
		/// </summary>
		public decimal? OWNER
		{
			set{ _owner=value;}
			get{return _owner;}
		}
		/// <summary>
        /// 任务完成状态　0 未开始 1 办理中  9 已完成
		/// </summary>
		public decimal? STEP_STATUS
		{
			set{ _step_status=value;}
			get{return _step_status;}
		}
		/// <summary>
		/// 扩展属性ID
		/// </summary>
		public decimal? ATTRIBUTE_LOG
		{
			set{ _attribute_log=value;}
			get{return _attribute_log;}
		}
		/// <summary>
		/// 步骤名称
		/// </summary>
		public string STEP_NAME
		{
			set{ _step_name=value;}
			get{return _step_name;}
		}
		/// <summary>
		/// 类型
		/// </summary>
		public decimal? PROJECT_TYPE
		{
			set{ _project_type=value;}
			get{return _project_type;}
		}
        /// <summary>
        /// 待办人员名称
        /// </summary>
        public string FULL_NAME
        {
            get;
            set;
        }
        /// <summary>
        /// 步骤URl地址
        /// </summary>
        public string URL
        {
            get;
            set;
        }
        /// <summary>
        /// 项目步骤备注
        /// </summary>
        public string REMARK
        {
            get;
            set;
        }
        /// <summary>
        /// 是否是开始步骤
        /// </summary>
        public string START_FLAG
        {
            get;
            set;
        }
        /// <summary>
        /// 计划完成时间
        /// </summary>
        public DateTime? PLAN_ENDTIME
        {
            get;
            set;
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? CHECK_STEP_ID
        {
            get;
            set;
        }
        /// <summary>
        /// 必要上一步的完成状态
        /// </summary>
        public decimal? P_STEP_STATUS
        {
            get;
            set;
        }
        /// <summary>
        /// 必要上一步的名称
        /// </summary>
        public string P_STEP_NAME
        {
            get;
            set;
        }
        /// <summary>
        /// 待办人员部门ID
        /// </summary>
        public decimal? DEPARTMENT_ID
        {
            get;
            set;
        }
        /// <summary>
        /// 部门名称
        /// </summary>
        public string DEPARTMENT_NAME
        {
            get;
            set;
        }
        /// <summary>
        /// 风险处置单ID
        /// </summary>
        public decimal? RISK_HANDLE_ARCHIVE_ID
        {
            get;
            set;
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? LIMIT_TIME
        {
            get;
            set;
        }
		#endregion Model

	}
}

