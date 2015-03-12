using System;

namespace PDTech.OA.Model
{
	/// <summary>
	/// VIEW_USER_RIGHT:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class VIEW_USER_RIGHT
	{
		public VIEW_USER_RIGHT()
		{}
		#region Model
		private decimal? _user_id;
		private string _right_code;
		/// <summary>
		/// 
		/// </summary>
		public decimal? USER_ID
		{
			set{ _user_id=value;}
			get{return _user_id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string RIGHT_CODE
		{
			set{ _right_code=value;}
			get{return _right_code;}
		}
		#endregion Model

	}
}

