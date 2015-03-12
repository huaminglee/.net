using System;
namespace PDTech.OA.Model
{
	/// <summary>
	/// 风险类型定义表
	/// </summary>
	[Serializable]
	public partial class RISK_TYPE_INFO
	{
		public RISK_TYPE_INFO()
		{}
		#region Model
		private decimal? _risk_type_id;
		private string _risk_type_name;
		private string _ramark;
		private string _data1;
		/// <summary>
		/// ID
		/// </summary>
		public decimal? RISK_TYPE_ID
		{
			set{ _risk_type_id=value;}
			get{return _risk_type_id;}
		}
		/// <summary>
		/// 风险类型如 超期风险、违规风险
		/// </summary>
		public string RISK_TYPE_NAME
		{
			set{ _risk_type_name=value;}
			get{return _risk_type_name;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string RAMARK
		{
			set{ _ramark=value;}
			get{return _ramark;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string DATA1
		{
			set{ _data1=value;}
			get{return _data1;}
		}
		#endregion Model

	}
}

