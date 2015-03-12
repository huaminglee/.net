/**  版本信息模板在安装目录下，可自行修改。
* OA_EDAYQUESTION.cs
*
* 功 能： N/A
* 类 名： OA_EDAYQUESTION
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2014/7/24 15:01:39   N/A    初版
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
	/// 每日一题表
	/// </summary>
	[Serializable]
	public partial class OA_EDAYQUESTION
	{
		public OA_EDAYQUESTION()
		{}
		#region Model
		private decimal _eday_q_id;
		private string _edu_q_guid;
		private decimal? _answer_person;
		private string _answer;
		private DateTime? _answer_time;
		private decimal? _score;
		private decimal? _state;
		/// <summary>
		/// 主键ID
		/// </summary>
		public decimal EDAY_Q_ID
		{
			set{ _eday_q_id=value;}
			get{return _eday_q_id;}
		}
		/// <summary>
		/// 试题ID
		/// </summary>
		public string EDU_Q_GUID
		{
			set{ _edu_q_guid=value;}
			get{return _edu_q_guid;}
		}
		/// <summary>
		/// 答题人
		/// </summary>
		public decimal? ANSWER_PERSON
		{
			set{ _answer_person=value;}
			get{return _answer_person;}
		}
		/// <summary>
		/// 答案
		/// </summary>
		public string ANSWER
		{
			set{ _answer=value;}
			get{return _answer;}
		}
		/// <summary>
		/// 答题时间
		/// </summary>
		public DateTime? ANSWER_TIME
		{
			set{ _answer_time=value;}
			get{return _answer_time;}
		}
		/// <summary>
		/// 得分
		/// </summary>
		public decimal? SCORE
		{
			set{ _score=value;}
			get{return _score;}
		}
		/// <summary>
		/// 答题状态(1=回答正确，2=回答错误，3=未作答)
		/// </summary>
		public decimal? STATE
		{
			set{ _state=value;}
			get{return _state;}
		}
		#endregion Model

	}
}

