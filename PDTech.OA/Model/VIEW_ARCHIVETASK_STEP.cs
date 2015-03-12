using System;
namespace PDTech.OA.Model
{
	/// <summary>
	/// VIEW_ARCHIVETASK_STEP:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class VIEW_ARCHIVETASK_STEP
	{
		public VIEW_ARCHIVETASK_STEP()
		{}
		#region Model
        private decimal? _archive_id;
		private string _step_name;
		private string _full_name;
		private DateTime? _start_time;
		private DateTime? _end_time;
		private decimal? _task_state;
        private string _task_remark;
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
		public string FULL_NAME
		{
			set{ _full_name=value;}
			get{return _full_name;}
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
		public decimal? TASK_STATE
		{
			set{ _task_state=value;}
			get{return _task_state;}
		}
        public decimal? ARCHIVE_ID
        {
            set { _archive_id = value; }
            get { return _archive_id; }
        }
        public string TASK_REMARK
        {
            set { _task_remark = value; }
            get { return _task_remark; }
        }
        public string END_FLAG
        {
            get;
            set;
        }
        public decimal? ARCHIVE_TASK_ID
        {
            get;
            set;
        }
        public decimal? STEP_ID
        {
            get;
            set;
        }
        /// <summary>
        /// 办理人员部门id
        /// </summary>
        public decimal? DEPARTMENT_ID
        {
            get;
            set;
        }
        /// <summary>
        /// 公文类型ID
        /// </summary>
        public decimal? ARCHIVE_TYPE
        {
            get;
            set;
        }
        /// <summary>
        /// 关联风险处置单ID
        /// </summary>
        public decimal? RISK_HANDLE_ARCHIVE_ID
        {
            get;
            set;
        }
        public DateTime? LIMIT_TIME
        {
            get;
            set;
        }
        public decimal? TASK_TYPE
        {
            get;
            set;
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

