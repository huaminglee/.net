using System;
namespace PDTech.OA.Model
{
	/// <summary>
	/// 水务项目基础信息表
	/// </summary>
	[Serializable]
	public partial class SW_PROJECT_INFO
	{
		public SW_PROJECT_INFO()
		{}
		#region Model
		private decimal? _project_id;
		private string _project_name;
		private string _project_funds;
		private string _funds_type;
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
		/// <summary>
		/// 项目ID
		/// </summary>
		public decimal? PROJECT_ID
		{
			set{ _project_id=value;}
			get{return _project_id;}
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
		public string PROJECT_FUNDS
		{
			set{ _project_funds=value;}
			get{return _project_funds;}
		}
		/// <summary>
		/// 资金来源关联资金来源类型表(下拉选择)如：市财政，省财政
		/// </summary>
		public string FUNDS_TYPE
		{
			set{ _funds_type=value;}
			get{return _funds_type;}
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
		/// 系统中创建时间默认为sysdate
		/// </summary>
		public DateTime? CREATE_TIME
		{
			set{ _create_time=value;}
			get{return _create_time;}
		}
		/// <summary>
		/// 项目开始时间
		/// </summary>
		public DateTime? START_TIME
		{
			set{ _start_time=value;}
			get{return _start_time;}
		}
		/// <summary>
		/// 预计完成时间
		/// </summary>
		public DateTime? PLAN_END_TIME
		{
			set{ _plan_end_time=value;}
			get{return _plan_end_time;}
		}
		/// <summary>
		/// 实际完成时间
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
		#endregion Model

	}
}

