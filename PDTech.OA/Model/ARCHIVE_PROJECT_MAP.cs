
using System;
namespace PDTech.OA.Model
{
	/// <summary>
	/// 公文项目关联表
	/// </summary>
	[Serializable]
	public partial class ARCHIVE_PROJECT_MAP
	{
		public ARCHIVE_PROJECT_MAP()
		{}
		#region Model
		private decimal? _archive_id;
		private decimal? _project_id;
		/// <summary>
		/// 公文ID
		/// </summary>
		public decimal? ARCHIVE_ID
		{
			set{ _archive_id=value;}
			get{return _archive_id;}
		}
		/// <summary>
		/// 项目ID
		/// </summary>
		public decimal? PROJECT_ID
		{
			set{ _project_id=value;}
			get{return _project_id;}
		}
		#endregion Model

	}
}

