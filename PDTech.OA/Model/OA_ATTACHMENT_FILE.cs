
using System;
namespace PDTech.OA.Model
{
	/// <summary>
	/// 附件文件表
	/// </summary>
	[Serializable]
	public partial class OA_ATTACHMENT_FILE
	{
		public OA_ATTACHMENT_FILE()
		{}
		#region Model
		private decimal? _attachment_file_id;
		private string _file_name;
		private string _file_type;
		private decimal? _file_size;
		private string _file_path;
		private string _file_hash;
		private string _ocr_content;
		private decimal? _ocr_status;
		private DateTime? _create_time;
		private decimal? _ref_id;
		private string _ref_type;
        private string _data1;
        private string _data2;
		/// <summary>
		/// 文件ID
		/// </summary>
		public decimal? ATTACHMENT_FILE_ID
		{
			set{ _attachment_file_id=value;}
			get{return _attachment_file_id;}
		}
		/// <summary>
		/// 文件名
		/// </summary>
		public string FILE_NAME
		{
			set{ _file_name=value;}
			get{return _file_name;}
		}
		/// <summary>
		/// 文件类型
		/// </summary>
		public string FILE_TYPE
		{
			set{ _file_type=value;}
			get{return _file_type;}
		}
		/// <summary>
		/// 文件大小(byte)
		/// </summary>
		public decimal? FILE_SIZE
		{
			set{ _file_size=value;}
			get{return _file_size;}
		}
		/// <summary>
		/// 文件存放物理路径
		/// </summary>
		public string FILE_PATH
		{
			set{ _file_path=value;}
			get{return _file_path;}
		}
		/// <summary>
		/// 文件内容的MD5,HASH
		/// </summary>
		public string FILE_HASH
		{
			set{ _file_hash=value;}
			get{return _file_hash;}
		}
		/// <summary>
		/// 文件内容字符
		/// </summary>
		public string OCR_CONTENT
		{
			set{ _ocr_content=value;}
			get{return _ocr_content;}
		}
		/// <summary>
		/// OCR处理结果0:未处理，1:成功处理，9:处理失败
		/// </summary>
		public decimal? OCR_STATUS
		{
			set{ _ocr_status=value;}
			get{return _ocr_status;}
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
		/// 附件归属ID,(公文ID 或 公告消息ID)
		/// </summary>
		public decimal? REF_ID
		{
			set{ _ref_id=value;}
			get{return _ref_id;}
		}
		/// <summary>
		/// 附件归属类型(OA_ARCHIVE,OA_MESSAGE)
		/// </summary>
		public string REF_TYPE
		{
			set{ _ref_type=value;}
			get{return _ref_type;}
		}
        /// <summary>
        /// 添加附件用户ID
        /// </summary>
        public decimal? CREATE_USER
        {
            get;
            set;
        }
        /// <summary>
        /// 扩展字段1
        /// </summary>
        public string DATA1
        {
            set { _data1 = value; }
            get { return _data1; }
        }
        /// <summary>
        /// 扩展字段2
        /// </summary>
        public string DATA2
        {
            set { _data2 = value; }
            get { return _data2; }
        }

        /// <summary>
        /// 附件上传人员名称
        /// </summary>
        public string FULL_NAME
        {
            get;
            set;
        }

		#endregion Model
        /// <summary>
        /// 排序字段[格式如：User_ID ASC,User_Name DESC]
        /// </summary>
        public string SortFields
        {
            get;
            set;
        }
        /// <summary>
        /// 自定义查询字段[格式: UserID = '10001' AND UserName= 'Mr.Zore' AND ID NOT (SELECT ID FROM XX)]
        /// </summary>
        public string Append
        {
            get;
            set;
        }
	}
}

