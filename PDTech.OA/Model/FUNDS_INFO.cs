using System;
namespace PDTech.OA.Model
{
	/// <summary>
	/// 资金来源基础信息表
	/// </summary>
	[Serializable]
	public partial class FUNDS_INFO
	{
		public FUNDS_INFO()
		{}
		#region Model
		private decimal? _funds_id;
		private string _funds_name;
		/// <summary>
		/// 资金来源ID
		/// </summary>
		public decimal? FUNDS_ID
		{
			set{ _funds_id=value;}
			get{return _funds_id;}
		}
		/// <summary>
		/// 资金来源名称
		/// </summary>
		public string FUNDS_NAME
		{
			set{ _funds_name=value;}
			get{return _funds_name;}
		}
		#endregion Model

	}
}

