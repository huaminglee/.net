
using System;
namespace PDTech.OA.Model
{
	/// <summary>
	/// 模板信息表，包含办理意见，人员抄送，领导批示......
	/// </summary>
	[Serializable]
	public partial class TEMPLATE_INFO
	{
		public TEMPLATE_INFO()
		{}
		#region Model
		private decimal? _template_id;
		private string _template_type;
		private string _template_jc;
		private string _template_value;
		/// <summary>
		/// 模板ID
		/// </summary>
		public decimal? TEMPLATE_ID
		{
			set{ _template_id=value;}
			get{return _template_id;}
		}
		/// <summary>
		/// 模板类型,如办理意见，领导批示，
		/// </summary>
		public string TEMPLATE_TYPE
		{
			set{ _template_type=value;}
			get{return _template_type;}
		}
		/// <summary>
		/// 模板简称
		/// </summary>
		public string TEMPLATE_JC
		{
			set{ _template_jc=value;}
			get{return _template_jc;}
		}
		/// <summary>
		/// 模板值
		/// </summary>
		public string TEMPLATE_VALUE
		{
			set{ _template_value=value;}
			get{return _template_value;}
		}
        /// <summary>
        /// 创建
        /// </summary>
        public decimal? TEMPLATE_OWNER
        {
            get;
            set;
        }
        /// <summary>
        /// 所属人员姓名
        /// </summary>
        public string FULL_NAME
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

