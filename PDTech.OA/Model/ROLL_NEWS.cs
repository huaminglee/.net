/**  版本信息模板在安装目录下，可自行修改。
* ROLL_NEWS.cs
*
* 功 能： N/A
* 类 名： ROLL_NEWS
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2014/8/6 15:00:47   N/A    初版
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
	/// 滚动新闻表
	/// </summary>
	[Serializable]
	public partial class ROLL_NEWS
	{
		public ROLL_NEWS()
		{}
		#region Model
		private decimal _news_id;
		private string _news_title;
		private string _news_content;
		private decimal? _creator;
		private DateTime? _create_time;
		private decimal? _is_rolling;
		/// <summary>
		/// 新闻ID
		/// </summary>
		public decimal NEWS_ID
		{
			set{ _news_id=value;}
			get{return _news_id;}
		}
		/// <summary>
		/// 新闻标题
		/// </summary>
		public string NEWS_TITLE
		{
			set{ _news_title=value;}
			get{return _news_title;}
		}
		/// <summary>
		/// 新闻内容
		/// </summary>
		public string NEWS_CONTENT
		{
			set{ _news_content=value;}
			get{return _news_content;}
		}
		/// <summary>
		/// 创建人
		/// </summary>
		public decimal? CREATOR
		{
			set{ _creator=value;}
			get{return _creator;}
		}
		/// <summary>
		/// 创建时间
		/// </summary>
		public DateTime? CREATE_TIME
		{
			set{ _create_time=value;}
			get{return _create_time;}
		}
		/// <summary>
		/// 是否滚动(0=不滚动，1=滚动)
		/// </summary>
		public decimal? IS_ROLLING
		{
			set{ _is_rolling=value;}
			get{return _is_rolling;}
		}
		#endregion Model

	}
}

