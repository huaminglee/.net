using System;
namespace PDTech.OA.Model
{
	/// <summary>
	/// 会议室信息表
	/// </summary>
	[Serializable]
	public partial class MEETING_ROOM_INFO
	{
		public MEETING_ROOM_INFO()
		{}
		#region Model
		private decimal _meeting_room_id;
		private string _meeting_room_name;
		private string _room_desc;
		/// <summary>
		/// 会议室主键ID
		/// </summary>
		public decimal MEETING_ROOM_ID
		{
			set{ _meeting_room_id=value;}
			get{return _meeting_room_id;}
		}
		/// <summary>
		/// 会议室名称
		/// </summary>
		public string MEETING_ROOM_NAME
		{
			set{ _meeting_room_name=value;}
			get{return _meeting_room_name;}
		}
		/// <summary>
		/// 备注
		/// </summary>
		public string ROOM_DESC
		{
			set{ _room_desc=value;}
			get{return _room_desc;}
		}
		#endregion Model

	}
}

