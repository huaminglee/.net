/**  版本信息模板在安装目录下，可自行修改。
* OA_RISKEDUCATION.cs
*
* 功 能： N/A
* 类 名： OA_RISKEDUCATION
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2014/7/22 15:35:19   N/A    初版
*
* Copyright (c) 2012 Maticsoft Corporation. All rights reserved.
*┌──────────────────────────────────┐
*│　此技术信息为本公司机密信息，未经本公司书面同意禁止向第三方披露．　│
*│　版权所有：动软卓越（北京）科技有限公司　　　　　　　　　　　　　　│
*└──────────────────────────────────┘
*/
using System;
using System.Runtime.Serialization;
namespace PDTech.OA.Model
{
	/// <summary>
	/// 教育任务表
	/// </summary>
	[Serializable]
	public partial class OA_RISKEDUCATION
	{
		public OA_RISKEDUCATION()
		{}
		#region Model
        private decimal? _education_id;
		private string _title;
		private string _filetype;
		private string _remark;
		private decimal? _creator;
		private DateTime? _createtime;
		private string _company;
        private decimal? _testcount;
        private decimal? _score;
        private DateTime? _hopefinishtime;
        private DateTime? _finishtime;
		/// <summary>
		/// 教育任务ID
		/// </summary>
        public decimal? EDUCATION_ID
		{
            set { _education_id = value; }
            get { return _education_id; }
		}
		/// <summary>
		/// 标题
		/// </summary>
		public string TITLE
		{
			set{ _title=value;}
			get{return _title;}
		}
		/// <summary>
		/// 类型
		/// </summary>
		public string FILETYPE
		{
			set{ _filetype=value;}
			get{return _filetype;}
		}
		/// <summary>
		/// 备注
		/// </summary>
		public string REMARK
		{
			set{ _remark=value;}
			get{return _remark;}
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
		public DateTime? CREATETIME
		{
			set{ _createtime=value;}
			get{return _createtime;}
		}
		/// <summary>
		/// 来文单位
		/// </summary>
		public string COMPANY
		{
			set{ _company=value;}
			get{return _company;}
		}
        /// <summary>
        /// 期望完成日期
        /// </summary>
        public DateTime? HOPEFINISHTIME
        {
            set { _hopefinishtime = value; }
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

     [DataContract]
    public partial class OA_EXPIRE_EDUTASK
    {
         [DataMember(Order = 0)]
         public string rowno { get; set; }
         [DataMember(Order = 1)]
         public string TITLE { get; set; }
         [DataMember(Order = 2)]
         public string FILETYPE { get; set; }
         [DataMember(Order = 3)]
         public string CREATOR { get; set; }
         [DataMember(Order = 4)]
         public string CREATETIME { get; set; }
          [DataMember(Order = 5)]
         public string COMPANY { get; set; }
         [DataMember(Order = 6)]
          public string HOPEFINISHTIME { get; set; }
         
    }
     [DataContract]
     public partial class OA_EXPIRE_ONLINETEST
     {
         [DataMember(Order = 0)]
         public string rowno { get; set; }
          [DataMember(Order = 1)]
         public string TESTNAME { get; set; }
          [DataMember(Order = 2)]
          public string TESTCOUNT { get; set; }
          [DataMember(Order = 3)]
          public string SCORE { get; set; }
          [DataMember(Order = 4)]
          public string CREATOR { get; set; }
          [DataMember(Order = 5)]
          public string CREATETIME { get; set; }
          [DataMember(Order = 6)]
          public string HOPEFINISHTIME { get; set; }
         
     }
}

