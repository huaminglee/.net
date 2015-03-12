using System;
namespace PDTech.OA.Model
{
	/// <summary>
	/// VIEW_RISK_ORCHIVE_PROJECT:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class VIEW_RISK_ORCHIVE_PROJECT
	{
		public VIEW_RISK_ORCHIVE_PROJECT()
		{}
		#region Model
		private decimal? _archive_id;
		private decimal? _archive_type;
		private decimal? _attribute_log;
		private string _archive_title;
		private DateTime? _start_time;
		private DateTime? _limit_time;
		private decimal? _remind_type;
		private decimal? _user_id;
		private decimal? _status;
		private decimal? _step_id;
		private string _step_name;
		private string _full_name;
		private string _department_name;
		/// <summary>
		/// 公文ID或者项目ID
		/// </summary>
		public decimal? ARCHIVE_ID
		{
			set{ _archive_id=value;}
			get{return _archive_id;}
		}
		/// <summary>
		/// 类型
		/// </summary>
		public decimal? ARCHIVE_TYPE
		{
			set{ _archive_type=value;}
			get{return _archive_type;}
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
		/// 标题
		/// </summary>
		public string ARCHIVE_TITLE
		{
			set{ _archive_title=value;}
			get{return _archive_title;}
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
		/// 办理时限
		/// </summary>
		public DateTime? LIMIT_TIME
		{
			set{ _limit_time=value;}
			get{return _limit_time;}
		}
		/// <summary>
		/// 提醒类型
		/// </summary>
		public decimal? REMIND_TYPE
		{
			set{ _remind_type=value;}
			get{return _remind_type;}
		}
		/// <summary>
		/// UserID
		/// </summary>
		public decimal? USER_ID
		{
			set{ _user_id=value;}
			get{return _user_id;}
		}
		/// <summary>
		/// 状态
		/// </summary>
		public decimal? STATUS
		{
			set{ _status=value;}
			get{return _status;}
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
		/// 步骤名称
		/// </summary>
		public string STEP_NAME
		{
			set{ _step_name=value;}
			get{return _step_name;}
		}
		/// <summary>
		/// 待处理人员名称
		/// </summary>
		public string FULL_NAME
		{
			set{ _full_name=value;}
			get{return _full_name;}
		}
		/// <summary>
		/// 部门
		/// </summary>
		public string DEPARTMENT_NAME
		{
			set{ _department_name=value;}
			get{return _department_name;}
		}
        /// <summary>
        /// 类型名称
        /// </summary>
        public string ARCHIVE_TYPE_NAME
        {
            get;
            set;
        }
        public decimal? OVER_TIME_RISK_REMIND_ID
        {
            get;
            set;
        }
        /// <summary>
        /// 责任人ID
        /// </summary>
        public decimal? RESPONSE_USER_ID
        {
            get;
            set;
        }
        /// <summary>
        /// 责任人
        /// </summary>
        public string RES_USER
        {
            get;
            set;
        }
        /// <summary>
        /// 责任处室
        /// </summary>
        public string RES_DEPT
        {
            get;
            set;
        }
        /// <summary>
        /// 提醒类型名称
        /// </summary>
        public string REMIND_TYPE_NAME
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

