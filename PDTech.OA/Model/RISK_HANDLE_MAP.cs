using System;
namespace PDTech.OA.Model
{
	/// <summary>
	/// 风险处置单映射表
	/// </summary>
	[Serializable]
	public partial class RISK_HANDLE_MAP
	{
		public RISK_HANDLE_MAP()
		{}
		#region Model
		private decimal? _archive_id;
		private decimal? _archive_task_id;
		private decimal? _risk_handle_archive_id;
		/// <summary>
		/// 被处置的公文ID
		/// </summary>
		public decimal? ARCHIVE_ID
		{
			set{ _archive_id=value;}
			get{return _archive_id;}
		}
		/// <summary>
		/// 处置风险的任务ID
		/// </summary>
		public decimal? ARCHIVE_TASK_ID
		{
			set{ _archive_task_id=value;}
			get{return _archive_task_id;}
		}
		/// <summary>
		/// 风险处置单公文ID
		/// </summary>
		public decimal? RISK_HANDLE_ARCHIVE_ID
		{
			set{ _risk_handle_archive_id=value;}
			get{return _risk_handle_archive_id;}
		}
        public decimal? ARCHIVE_TYPE
        {
            get;
            set;
        }
		#endregion Model

	}
}

