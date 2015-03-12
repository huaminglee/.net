using System;
namespace PDTech.OA.Model
{
	/// <summary>
	/// USER_ROLE_MAP:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class USER_ROLE_MAP
	{
		public USER_ROLE_MAP()
		{}
		#region Model
		private decimal _user_id;
		private decimal _role_id;
		/// <summary>
		/// 用户ID
		/// </summary>
		public decimal USER_ID
		{
			set{ _user_id=value;}
			get{return _user_id;}
		}
		/// <summary>
		/// 角色ID
		/// </summary>
		public decimal ROLE_ID
		{
			set{ _role_id=value;}
			get{return _role_id;}
		}
		#endregion Model

	}
}

