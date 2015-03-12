using System;
namespace PDTech.OA.Model
{
	/// <summary>
	/// ATTRIBUTES:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class ATTRIBUTES
	{
		public ATTRIBUTES()
		{}
		#region Model
		private decimal _attribute_id;
		private decimal _log_id;
		private string _key;
		private string _value;
		/// <summary>
		/// ATTRIBUTES_ID_SEQ.NEXTVAL 
		/// </summary>
		public decimal ATTRIBUTE_ID
		{
			set{ _attribute_id=value;}
			get{return _attribute_id;}
		}
		/// <summary>
		/// 部门，人员,流程对应的日志id
		/// </summary>
		public decimal LOG_ID
		{
			set{ _log_id=value;}
			get{return _log_id;}
		}
		/// <summary>
		/// 属性名
		/// </summary>
		public string KEY
		{
			set{ _key=value;}
			get{return _key;}
		}
		/// <summary>
		/// 属性值
		/// </summary>
		public string VALUE
		{
			set{ _value=value;}
			get{return _value;}
		}
		#endregion Model

	}
}

