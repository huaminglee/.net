/**  版本信息模板在安装目录下，可自行修改。
* OA_EDUQUESTION.cs
*
* 功 能： N/A
* 类 名： OA_EDUQUESTION
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2014/7/22 15:35:35   N/A    初版
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
	/// 试题表
	/// </summary>
	[Serializable]
	public partial class OA_EDUQUESTION
	{
		public OA_EDUQUESTION()
		{}
		#region Model
		private string _edu_q_guid;
		private string _title;
		private string _answer;
		private string _optiona;
		private string _optionb;
		private string _optionc;
		private string _optiond;
		private DateTime? _createtime;
		private decimal? _score;
		private decimal? _weight;
		/// <summary>
		/// 试题主键
		/// </summary>
		public string EDU_Q_GUID
		{
			set{ _edu_q_guid=value;}
			get{return _edu_q_guid;}
		}
		/// <summary>
		/// 试题题目
		/// </summary>
		public string TITLE
		{
			set{ _title=value;}
			get{return _title;}
		}
		/// <summary>
		/// 试题答案
		/// </summary>
		public string ANSWER
		{
			set{ _answer=value;}
			get{return _answer;}
		}
		/// <summary>
		/// A选项
		/// </summary>
		public string OPTIONA
		{
			set{ _optiona=value;}
			get{return _optiona;}
		}
		/// <summary>
		/// B选项
		/// </summary>
		public string OPTIONB
		{
			set{ _optionb=value;}
			get{return _optionb;}
		}
		/// <summary>
		/// C选项
		/// </summary>
		public string OPTIONC
		{
			set{ _optionc=value;}
			get{return _optionc;}
		}
		/// <summary>
		/// D选项
		/// </summary>
		public string OPTIOND
		{
			set{ _optiond=value;}
			get{return _optiond;}
		}
		/// <summary>
		/// 创建时间
		/// </summary>
		public DateTime? CREATETIME
		{
			set{ _createtime=value;}
			get{return _createtime;}
		}
		/// <summary>
		/// 分值
		/// </summary>
		public decimal? SCORE
		{
			set{ _score=value;}
			get{return _score;}
		}
		/// <summary>
		/// 权值
		/// </summary>
		public decimal? WEIGHT
		{
			set{ _weight=value;}
			get{return _weight;}
		}
		#endregion Model

	}
}

