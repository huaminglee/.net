using System;
namespace PDTech.OA.Model
{
	/// <summary>
	/// ROLE_INFO:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class ROLE_INFO
	{
		public ROLE_INFO()
		{}
		#region Model
		private decimal _role_id;
		private string _role_name;
		private string _role_desc;
		/// <summary>
		/// ROLE_ID_SEQ.NEXTVAL
		/// </summary>
		public decimal ROLE_ID
		{
			set{ _role_id=value;}
			get{return _role_id;}
		}
		/// <summary>
		/// 角色名称
		/// </summary>
		public string ROLE_NAME
		{
			set{ _role_name=value;}
			get{return _role_name;}
		}
		/// <summary>
		/// 描述
		/// </summary>
		public string ROLE_DESC
		{
			set{ _role_desc=value;}
			get{return _role_desc;}
		}
		#endregion Model

	}
}

