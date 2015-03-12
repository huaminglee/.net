/**  版本信息模板在安装目录下，可自行修改。
* OA_TEST_ANSWER.cs
*
* 功 能： N/A
* 类 名： OA_TEST_ANSWER
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2014/7/22 15:35:44   N/A    初版
*
* Copyright (c) 2012 Maticsoft Corporation. All rights reserved.
*┌──────────────────────────────────┐
*│　此技术信息为本公司机密信息，未经本公司书面同意禁止向第三方披露．　│
*│　版权所有：动软卓越（北京）科技有限公司　　　　　　　　　　　　　　│
*└──────────────────────────────────┘
*/
using System;
namespace PDTech.OA.Model
{
	/// <summary>
	/// 答题表
	/// </summary>
	[Serializable]
	public partial class OA_TEST_ANSWER
	{
		public OA_TEST_ANSWER()
		{}
		#region Model
		private string _edu_a_guid;
		private string _edu_map_guid;
		private decimal? _answer_id;
		private string _selectedoption;
		private DateTime? _answertime;
		private decimal? _score;
		/// <summary>
		/// 作答ID
		/// </summary>
		public string EDU_A_GUID
		{
			set{ _edu_a_guid=value;}
			get{return _edu_a_guid;}
		}
		/// <summary>
		/// 外键，哪张试卷的哪道题
		/// </summary>
		public string EDU_MAP_GUID
		{
			set{ _edu_map_guid=value;}
			get{return _edu_map_guid;}
		}
		/// <summary>
		/// 作答人
		/// </summary>
		public decimal? ANSWER_ID
		{
			set{ _answer_id=value;}
			get{return _answer_id;}
		}
		/// <summary>
		/// 选择的答案
		/// </summary>
		public string SELECTEDOPTION
		{
			set{ _selectedoption=value;}
			get{return _selectedoption;}
		}
		/// <summary>
		/// 作答时间
		/// </summary>
		public DateTime? ANSWERTIME
		{
			set{ _answertime=value;}
			get{return _answertime;}
		}
		/// <summary>
		/// 得分
		/// </summary>
		public decimal? SCORE
		{
			set{ _score=value;}
			get{return _score;}
		}
		#endregion Model

	}
}

