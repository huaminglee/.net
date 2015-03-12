using System;
namespace PDTech.OA.Model
{
	/// <summary>
	/// USER_RIGHT_MAP:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class USER_RIGHT_MAP
	{
		public USER_RIGHT_MAP()
		{}
		#region Model
		private decimal? _user_id;
		private decimal? _right_id;
		/// <summary>
		/// 用户ID
		/// </summary>
		public decimal? USER_ID
		{
			set{ _user_id=value;}
			get{return _user_id;}
		}
		/// <summary>
		/// 权限ID
		/// </summary>
		public decimal? RIGHT_ID
		{
			set{ _right_id=value;}
			get{return _right_id;}
		}
		#endregion Model

	}
}

