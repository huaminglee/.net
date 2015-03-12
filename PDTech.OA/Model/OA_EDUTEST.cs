/**  版本信息模板在安装目录下，可自行修改。
* OA_EDUTEST.cs
*
* 功 能： N/A
* 类 名： OA_EDUTEST
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2014/7/22 15:35:27   N/A    初版
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
	/// 试卷表
	/// </summary>
	[Serializable]
	public partial class OA_EDUTEST
	{
		public OA_EDUTEST()
		{}
		#region Model
		private string _edu_t_guid;
		private string _testname;
		private decimal? _creator;
		private DateTime? _createtime;
        private DateTime? _hopefinishtime;
        private DateTime? _finishtime;
        private decimal? _testcount;
        private decimal? _score;
		/// <summary>
		/// 试卷主键
		/// </summary>
		public string EDU_T_GUID
		{
			set{ _edu_t_guid=value;}
			get{return _edu_t_guid;}
		}
		/// <summary>
		/// 试卷名称
		/// </summary>
		public string TESTNAME
		{
			set{ _testname=value;}
			get{return _testname;}
		}
		/// <summary>
		/// 试卷创建人
		/// </summary>
		public decimal? CREATOR
		{
			set{ _creator=value;}
			get{return _creator;}
		}
		/// <summary>
		/// 试卷创建时间
		/// </summary>
		public DateTime? CREATETIME
		{
			set{ _createtime=value;}
			get{return _createtime;}
		}
        /// <summary>
        /// 试题总数
        /// </summary>
        public decimal? TESTCOUNT
        {
            set { _testcount = value; }
            get { return _testcount; }
        }
        /// <summary>
        /// 试卷总分
        /// </summary>
        public decimal? SCORE
        {
            set { _score = value; }
            get { return _score; }
        }
        /// <summary>
        /// 期望完成日期
        /// </summary>
        public DateTime? HOPEFINISHTIME
        {
            set{_hopefinishtime=value;}
            get { return _hopefinishtime; }
        }
        /// <summary>
        /// 实际完成日期
        /// </summary>
        public DateTime? FINISHTIME
        {
            set { _finishtime = value; }
            get { return _finishtime; }
        }
		#endregion Model

	}
}

