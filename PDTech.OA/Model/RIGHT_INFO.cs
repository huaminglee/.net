using System;
namespace PDTech.OA.Model
{
	/// <summary>
	/// RIGHT_INFO:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class RIGHT_INFO
	{
		public RIGHT_INFO()
		{}
		#region Model
		private decimal _right_id;
		private string _right_code;
		private string _right_name;
		private decimal? _parent_id;
		private decimal? _sort_num;
		private string _right_desc;
        private string _parent_name;
		/// <summary>
		/// RIGHT_ID_SEQ.NEXTVAL
		/// </summary>
		public decimal RIGHT_ID
		{
			set{ _right_id=value;}
			get{return _right_id;}
		}
		/// <summary>
		/// 权限编码
		/// </summary>
		public string RIGHT_CODE
		{
			set{ _right_code=value;}
			get{return _right_code;}
		}
		/// <summary>
		/// 权限名
		/// </summary>
		public string RIGHT_NAME
		{
			set{ _right_name=value;}
			get{return _right_name;}
		}
		/// <summary>
		/// 上级权限
		/// </summary>
		public decimal? PARENT_ID
		{
			set{ _parent_id=value;}
			get{return _parent_id;}
		}
		/// <summary>
		/// 排序ID
		/// </summary>
		public decimal? SORT_NUM
		{
			set{ _sort_num=value;}
			get{return _sort_num;}
		}
		/// <summary>
		/// 描述
		/// </summary>
		public string RIGHT_DESC
		{
			set{ _right_desc=value;}
			get{return _right_desc;}
		}
        public string PARENT_NAME
        {
            set { _parent_name = value; }
            get { return _parent_name; }
        }
		#endregion Model
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
	}
}

