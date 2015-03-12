using System;
namespace PDTech.OA.Model
{
	/// <summary>
	/// ROLE_RIGHT_MAP:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class ROLE_RIGHT_MAP
	{
		public ROLE_RIGHT_MAP()
		{}
		#region Model
		private decimal _role_id;
		private decimal _right_id;
		/// <summary>
		/// 
		/// </summary>
		public decimal ROLE_ID
		{
			set{ _role_id=value;}
			get{return _role_id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal RIGHT_ID
		{
			set{ _right_id=value;}
			get{return _right_id;}
		}
		#endregion Model

	}
}

