using System;
namespace PDTech.OA.Model
{
	/// <summary>
	/// VIEW_PROJECT_STEP_USER:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class VIEW_PROJECT_STEP_USER
	{
		public VIEW_PROJECT_STEP_USER()
		{}
		#region Model
        private decimal? _owner_id;
        private decimal? _task_state;
        private decimal? _current_state;
        private decimal? _archive_task_id;
        private decimal? _archive_id;
		private decimal? _project_id;
		private string _project_name;
		private decimal? _project_funds;
		private decimal? _funds_type;
		private decimal? _creator;
		private DateTime? _create_time;
		private DateTime? _start_time;
		private DateTime? _plan_end_time;
		private DateTime? _end_time;
		private decimal? _launch_type;
		private string _top_response_dept;
		private string _owner_dept;
		private string _project_by;
		private decimal? _project_status;
		private decimal? _file_dept;
		private string _remark;
		private decimal? _attribute_log;
		private string _cfull_name;
		private string _step_name;
		private string _ifull_name;
		/// <summary>
		/// 项目ID
		/// </summary>
		public decimal? PROJECT_ID
		{
			set{ _project_id=value;}
			get{return _project_id;}
		}
        /// <summary>
        /// 当前状态,0:新建、1:流转中、2:已完成、9:取消
        /// </summary>
        public decimal? CURRENT_STATE
        {
            set { _current_state = value; }
            get { return _current_state; }
        }
        /// <summary>
        /// 待办人员
        /// </summary>
        public decimal? OWNER_ID
        {
            set { _owner_id = value; }
            get { return _owner_id; }
        }
        /// <summary>
        /// 任务状态0:未处理(待办)、1:已处理
        /// </summary>
        public decimal? TASK_STATE
        {
            set { _task_state = value; }
            get { return _task_state; }
        }
        /// <summary>
        /// 任务ID
        /// </summary>
        public decimal? ARCHIVE_TASK_ID
        {
            set { _archive_task_id = value; }
            get { return _archive_task_id; }
        }
        /// <summary>
        /// 公文ID
        /// </summary>
        public decimal? ARCHIVE_ID
        {
            set { _archive_id = value; }
            get { return _archive_id; }
        }
		/// <summary>
		/// 项目名称
		/// </summary>
		public string PROJECT_NAME
		{
			set{ _project_name=value;}
			get{return _project_name;}
		}
		/// <summary>
		/// 资金总额
		/// </summary>
		public decimal? PROJECT_FUNDS
		{
			set{ _project_funds=value;}
			get{return _project_funds;}
		}
		/// <summary>
		/// 资金来源
		/// </summary>
		public decimal? FUNDS_TYPE
		{
			set{ _funds_type=value;}
			get{return _funds_type;}
		}
		/// <summary>
		/// 创建人ID
		/// </summary>
		public decimal? CREATOR
		{
			set{ _creator=value;}
			get{return _creator;}
		}
		/// <summary>
		/// 创建时间
		/// </summary>
		public DateTime? CREATE_TIME
		{
			set{ _create_time=value;}
			get{return _create_time;}
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
		/// 计划完成时间
		/// </summary>
		public DateTime? PLAN_END_TIME
		{
			set{ _plan_end_time=value;}
			get{return _plan_end_time;}
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
        /// 组织方式 1:市级组织 2:区县组织 9:其它
		/// </summary>
		public decimal? LAUNCH_TYPE
		{
			set{ _launch_type=value;}
			get{return _launch_type;}
		}
		/// <summary>
        /// 局机关牵头处室(可选择部门或手工填写)
		/// </summary>
		public string TOP_RESPONSE_DEPT
		{
			set{ _top_response_dept=value;}
			get{return _top_response_dept;}
		}
		/// <summary>
        /// 主办单位(可选择部门 或者手工填写)
		/// </summary>
		public string OWNER_DEPT
		{
			set{ _owner_dept=value;}
			get{return _owner_dept;}
		}
		/// <summary>
        /// 立项依据
		/// </summary>
		public string PROJECT_BY
		{
			set{ _project_by=value;}
			get{return _project_by;}
		}
		/// <summary>
        /// 项目状态0:未完成、1：已完成
		/// </summary>
		public decimal? PROJECT_STATUS
		{
			set{ _project_status=value;}
			get{return _project_status;}
		}
		/// <summary>
        /// 归档处室(只有2种) 1:规计处、2:财务处
		/// </summary>
		public decimal? FILE_DEPT
		{
			set{ _file_dept=value;}
			get{return _file_dept;}
		}
		/// <summary>
        /// 备注
		/// </summary>
		public string REMARK
		{
			set{ _remark=value;}
			get{return _remark;}
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
		/// 创建人名称
		/// </summary>
		public string CFULL_NAME
		{
			set{ _cfull_name=value;}
			get{return _cfull_name;}
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
		/// 步骤负责人名称
		/// </summary>
		public string IFULL_NAME
		{
			set{ _ifull_name=value;}
			get{return _ifull_name;}
		}
        /// <summary>
        /// 步骤负责人ID
        /// </summary>
        public decimal? OWNER
        {
            get;
            set;
        }
        /// <summary>
        /// 项目类型 1：规计处备案项目 2：财务处备案项目）
        /// </summary>
        public decimal? PROJECT_TYPE
        {
            get;
            set;
        }
        /// <summary>
        /// 检测必要步骤是否完成
        /// </summary>
        public decimal? CHECK_STEP_ID
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

