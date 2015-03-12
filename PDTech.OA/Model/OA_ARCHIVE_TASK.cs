using System;
using System.Runtime.Serialization;

namespace PDTech.OA.Model
{
    /// <summary>
    /// 公文任务表
    /// </summary>
    [Serializable]
    public partial class OA_ARCHIVE_TASK
    {
        public OA_ARCHIVE_TASK()
        { }
        #region Model
        private decimal? _archive_task_id;
        private decimal? _archive_id;
        private decimal? _owner_id;
        private decimal? _current_step_id;
        private string _task_remark;
        private decimal? _task_state;
        private decimal? _task_type;
        private decimal? _previous_task_id;
        private DateTime? _start_time;
        private DateTime? _end_time;
        private DateTime? _limit_time;
        private string _sing_data;
        /// <summary>
        /// 任务ID
        /// </summary>
        public decimal? ARCHIVE_TASK_ID
        {
            set { _archive_task_id = value; }
            get { return _archive_task_id; }
        }
        /// <summary>
        /// 公文ID
        /// </summary>
        public decimal? ARCHIVE_ID
        {
            set { _archive_id = value; }
            get { return _archive_id; }
        }
        /// <summary>
        /// 待办人员
        /// </summary>
        public decimal? OWNER_ID
        {
            set { _owner_id = value; }
            get { return _owner_id; }
        }
        /// <summary>
        /// 当前流程步骤
        /// </summary>
        public decimal? CURRENT_STEP_ID
        {
            set { _current_step_id = value; }
            get { return _current_step_id; }
        }
        /// <summary>
        /// 批示或说明
        /// </summary>
        public string TASK_REMARK
        {
            set { _task_remark = value; }
            get { return _task_remark; }
        }
        /// <summary>
        /// 任务状态0:未处理(待办)、1:已处理
        /// </summary>
        public decimal? TASK_STATE
        {
            set { _task_state = value; }
            get { return _task_state; }
        }
        /// <summary>
        /// 任务类型0：办理任务，1：抄送任务
        /// </summary>
        public decimal? TASK_TYPE
        {
            set { _task_type = value; }
            get { return _task_type; }
        }
        /// <summary>
        /// 上一步任务ID
        /// </summary>
        public decimal? PREVIOUS_TASK_ID
        {
            set { _previous_task_id = value; }
            get { return _previous_task_id; }
        }
        /// <summary>
        /// 开始时间
        /// </summary>
        public DateTime? START_TIME
        {
            set { _start_time = value; }
            get { return _start_time; }
        }
        /// <summary>
        /// 结束时间
        /// </summary>
        public DateTime? END_TIME
        {
            set { _end_time = value; }
            get { return _end_time; }
        }
        /// <summary>
        /// 当前步骤完成时限
        /// </summary>
        public DateTime? LIMIT_TIME
        {
            set { _limit_time = value; }
            get { return _limit_time; }
        }
        /// <summary>
        /// 电子签名内容，未签章时为空
        /// </summary>
        public string Sing_data
        {
            get { return _sing_data; }
            set { _sing_data = value; }
        }
        /// <summary>
        /// 开始预警时间
        /// </summary>
        public DateTime? REMIND_TIME
        {
            set;
            get;
        }
        #endregion Model
    }

    /// <summary>
    /// 待办事项（Json对象）
    /// </summary>
    [DataContract]
    public partial class OA_READY_WORK
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

        /***任务ID***/
        [DataMember(Order = 4)]
        public string archive_task_id { get; set; }

        /***开始时间***/
        [DataMember(Order = 5)]
        public string start_time { get; set; }

        /***是否过期***/
        [DataMember(Order = 6)]
        public string is_expire { get; set; }

        /***提醒时间***/
        [DataMember(Order = 7)]
        public string remind_time { get; set; }

        /***是否抄送（0：未抄送，1：已抄送）***/
        [DataMember(Order = 8)]
        public string task_type { get; set; }
       /// <summary>
       /// 办理时限
       /// </summary>
        [DataMember(Order = 9)]
        public string limit_time { get; set; }
    }

    /// <summary>
    /// 超期预警（Json对象）
    /// </summary>
    [DataContract]
    public partial class OA_EXPIRE_DOCUMENT : OA_READY_WORK
    {
        /***序号***/
        [DataMember(Order = 9)]
        public string rowno { get; set; }

        /***发送人***/
        [DataMember(Order = 10)]
        public string creator { get; set; }

        /***承办人***/
        [DataMember(Order = 11)]
        public string owner { get; set; }
        /***承办部门***/
        [DataMember(Order = 11)]
        public string owner_dept { get; set; }

        /***步骤名称***/
        [DataMember(Order = 12)]
        public string step_name { get; set; }

        /***生成风险处置单的公文ID***/
        [DataMember(Order = 14)]
        public string risk_handle_archive_id { get; set; }

    }

    /// <summary>
    /// 风险项目（Json对象）
    /// </summary>
    [DataContract]
    public partial class OA_RISK_DOCUMENT : OA_EXPIRE_DOCUMENT
    {
        /***风险点***/
        [DataMember(Order = 15)]
        public string risk_point { get; set; }

        /***风险等级***/
        [DataMember(Order = 16)]
        public string level_name { get; set; }

        /***办理时限***/
        [DataMember(Order = 17)]
        public string plan_endtime { get; set; }
    }

    /// <summary>
    /// 顶部提示待处理工作数量
    /// </summary>
    public partial class OA_READY_WORK_COUNT
    {
        /// <summary>
        /// 日常公文
        /// </summary>
        public int RCBG = 0;
        /// <summary>
        /// 督办工作
        /// </summary>
        public int DBGZ = 0;
        /// <summary>
        /// 公告消息
        /// </summary>
        public int GGXX = 0;
        /// <summary>
        /// 建议提案
        /// </summary>
        public int JYTA = 0;
        /// <summary>
        /// 人事任免
        /// </summary>
        public int RSRM = 0;
        /// <summary>
        /// 水务工程项目
        /// </summary>
        public int SWGCXM = 0;
        /// <summary>
        /// 会议通知
        /// </summary>
        public int HYTZ = 0;
        /// <summary>
        /// 行政审批
        /// </summary>
        public int XZSP = 0;
        /// <summary>
        /// 风险处置单
        /// </summary>
        public int FXCZD = 0;
        /// <summary>
        /// 超期风险处置
        /// </summary>
        public int CQFXCZD = 0;
        /// <summary>
        /// 教育任务
        /// </summary>
        public int JYRW = 0;
        /// <summary>
        /// 在线考试
        /// </summary>
        public int ZXKS = 0;
    }
}