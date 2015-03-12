using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace PDTech.OA.Model
{
    /// <summary>
    /// 工作表，包含公文，公告，提案......
    /// </summary>
    [Serializable]
    public partial class OA_ARCHIVE
    {
        public OA_ARCHIVE()
        { }
        #region Model
        private decimal _archive_id;
        private decimal? _archive_type;
        private decimal? _archive_level;
        private decimal? _pri_level;
        private decimal? _is_secret;
        private string _archive_no;
        private decimal? _flow_template_id;
        private decimal? _current_step_id;
        private decimal? _current_state;
        private string _archive_title;
        private string _archive_content;
        private decimal? _creator;
        private decimal? _response_user;
        private DateTime? _create_time;
        private DateTime? _limit_time;
        private string _is_show_in_szyd;
        private decimal? _attribute_log;
        private DateTime? _receive_time;
        /// <summary>
        /// 公文ID
        /// </summary>
        public decimal ARCHIVE_ID
        {
            set { _archive_id = value; }
            get { return _archive_id; }
        }
        /// <summary>
        /// 公文类型,10：一般阅件，11：普通办件，12：单位发文，......20：领导批示件，21：党组会督办件，22：局长办公会督办件，23：新访督办件
        /// </summary>
        public decimal? ARCHIVE_TYPE
        {
            set { _archive_type = value; }
            get { return _archive_type; }
        }
        /// <summary>
        /// 公文级别，0:本部门。1:全局
        /// </summary>
        public decimal? ARCHIVE_LEVEL
        {
            set { _archive_level = value; }
            get { return _archive_level; }
        }
        /// <summary>
        /// 紧急程度0：普通、1：急件、2：特急
        /// </summary>
        public decimal? PRI_LEVEL
        {
            set { _pri_level = value; }
            get { return _pri_level; }
        }
        /// <summary>
        /// 是否涉密
        /// </summary>
        public decimal? IS_SECRET
        {
            set { _is_secret = value; }
            get { return _is_secret; }
        }
        /// <summary>
        /// 文件编号
        /// </summary>
        public string ARCHIVE_NO
        {
            set { _archive_no = value; }
            get { return _archive_no; }
        }
        /// <summary>
        /// 流程模板ID
        /// </summary>
        public decimal? FLOW_TEMPLATE_ID
        {
            set { _flow_template_id = value; }
            get { return _flow_template_id; }
        }
        /// <summary>
        /// 当前流程步骤ID
        /// </summary>
        public decimal? CURRENT_STEP_ID
        {
            set { _current_step_id = value; }
            get { return _current_step_id; }
        }
        /// <summary>
        /// 当前状态,0:新建、1:流转中、2:已完成、9:取消
        /// </summary>
        public decimal? CURRENT_STATE
        {
            set { _current_state = value; }
            get { return _current_state; }
        }
        /// <summary>
        /// 公文标题
        /// </summary>
        public string ARCHIVE_TITLE
        {
            set { _archive_title = value; }
            get { return _archive_title; }
        }
        /// <summary>
        /// 公文内容备注
        /// </summary>
        public string ARCHIVE_CONTENT
        {
            set { _archive_content = value; }
            get { return _archive_content; }
        }
        /// <summary>
        /// 创建人
        /// </summary>
        public decimal? CREATOR
        {
            set { _creator = value; }
            get { return _creator; }
        }
        /// <summary>
        /// 专管员
        /// </summary>
        public decimal? RESPONSE_USER
        {
            set { _response_user = value; }
            get { return _response_user; }
        }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime? CREATE_TIME
        {
            set { _create_time = value; }
            get { return _create_time; }
        }
        /// <summary>
        /// 完成时限
        /// </summary>
        public DateTime? LIMIT_TIME
        {
            set { _limit_time = value; }
            get { return _limit_time; }
        }
        /// <summary>
        /// 是否为三重一大事项1：为三重一大，其它值不是三重一大
        /// </summary>
        public string IS_SHOW_IN_SZYD
        {
            set { _is_show_in_szyd = value; }
            get { return _is_show_in_szyd; }
        }
        /// <summary>
        /// 扩展属性logID
        /// </summary>
        public decimal? ATTRIBUTE_LOG
        {
            set { _attribute_log = value; }
            get { return _attribute_log; }
        }
        /// <summary>
        /// 收文时间
        /// </summary>
        public DateTime? RECEIVE_TIME
        {
            set { _receive_time = value; }
            get { return _receive_time; }
        }
        /// <summary>
        /// 公文类型
        /// </summary>
        public string ARCHIVE_TYPE_NAME
        {
            get;
            set;
        }
        /// <summary>
        /// 创建人员的部门ID
        /// </summary>
        public decimal? DEPARTMENT_ID
        {
            get;
            set;
        }
        #endregion Model
        #region 自定义 成员

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

        #endregion
    }

    /// <summary>
    /// 三重一大（Json对象）
    /// </summary>
    [DataContract]
    public partial class OA_MAJOR
    {
        /***公文ID***/
        [DataMember(Order = 0)]
        public string archive_id { get; set; }

        /***公文类型***/
        [DataMember(Order = 1)]
        public string archive_type { get; set; }

        /***类型名称***/
        [DataMember(Order = 2)]
        public string type_name { get; set; }

        /***公文标题***/
        [DataMember(Order = 3)]
        public string archive_title { get; set; }

        /***创建时间***/
        [DataMember(Order = 4)]
        public string create_time { get; set; }

        /***紧急程度***/
        [DataMember(Order = 5)]
        public string pri_level { get; set; }

        /***附件数量***/
        [DataMember(Order = 6)]
        public string attachment_count { get; set; }

        /***创建人***/
        [DataMember(Order = 7)]
        public string creator { get; set; }

        /***当前步骤***/
        [DataMember(Order = 8)]
        public string current_step_id { get; set; }

        /***序号***/
        [DataMember(Order = 9)]
        public string rowno { get; set; }

        /***序号***/
        [DataMember(Order = 10)]
        public string sort_rowno { get; set; }
    }
}