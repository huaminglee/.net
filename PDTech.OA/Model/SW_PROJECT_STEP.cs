using System;
using System.Runtime.Serialization;

namespace PDTech.OA.Model
{
    /// <summary>
    /// 项目步骤记录表
    /// </summary>
    [Serializable]
    public partial class SW_PROJECT_STEP
    {
        public SW_PROJECT_STEP()
        { }
        #region Model
        private decimal? _project_step_id;
        private decimal? _project_id;
        private decimal? _step_id;
        private DateTime? _start_time;
        private DateTime? _end_time;
        private decimal? _owner;
        private decimal? _step_status;
        private decimal? _attribute_log;
        /// <summary>
        /// 
        /// </summary>
        public decimal? PROJECT_STEP_ID
        {
            set { _project_step_id = value; }
            get { return _project_step_id; }
        }
        /// <summary>
        /// 项目ID
        /// </summary>
        public decimal? PROJECT_ID
        {
            set { _project_id = value; }
            get { return _project_id; }
        }
        /// <summary>
        /// 步骤ID
        /// </summary>
        public decimal? STEP_ID
        {
            set { _step_id = value; }
            get { return _step_id; }
        }
        /// <summary>
        /// 步骤开始时间
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
        /// 该步骤负责人
        /// </summary>
        public decimal? OWNER
        {
            set { _owner = value; }
            get { return _owner; }
        }
        /// <summary>
        /// 步骤当前状态0:未开始 1:进行中 9:已完成
        /// </summary>
        public decimal? STEP_STATUS
        {
            set { _step_status = value; }
            get { return _step_status; }
        }
        /// <summary>
        /// 扩展属性ID
        /// </summary>
        public decimal? ATTRIBUTE_LOG
        {
            set { _attribute_log = value; }
            get { return _attribute_log; }
        }
        /// <summary>
        /// 步骤备注
        /// </summary>
        public string REMARK
        {
            get;
            set;
        }
        /// <summary>
        /// 计划完成时间
        /// </summary>
        public DateTime? PLAN_ENDTIME
        {
            get;
            set;
        }
        #endregion Model
    }

    /// <summary>
    /// 超期预警--水务项目（Json对象）
    /// </summary>
    [DataContract]
    public partial class SW_EXPIRE_WATER
    {
        /***序号***/
        [DataMember(Order = 0)]
        public string rowno { get; set; }

        /***项目ID***/
        [DataMember(Order = 1)]
        public string project_id { get; set; }

        /***步骤ID***/
        [DataMember(Order = 2)]
        public string project_step_id { get; set; }

        /***水务项目名称***/
        [DataMember(Order = 3)]
        public string project_name { get; set; }

        /***水务项目类型***/
        [DataMember(Order = 4)]
        public string file_dept_name { get; set; }

        /***创建人***/
        [DataMember(Order = 5)]
        public string creator { get; set; }

        /***承办人***/
        [DataMember(Order = 6)]
        public string owner { get; set; }
        /***承办部门***/
        [DataMember(Order = 6)]
        public string owner_dept { get; set; }

        /***开始时间***/
        [DataMember(Order = 7)]
        public string start_time { get; set; }

        /***步骤名称***/
        [DataMember(Order = 8)]
        public string step_name { get; set; }

        /***完成时限***/
        [DataMember(Order = 9)]
        public string limit_time { get; set; }

        /***生成风险处置单的公文ID***/
        [DataMember(Order = 10)]
        public string risk_handle_archive_id { get; set; }
    }

    /// <summary>
    /// 风险项目--水务项目（Json对象）
    /// </summary>
    [DataContract]
    public partial class SW_RISK_WATER : SW_EXPIRE_WATER
    {
        /***风险点***/
        [DataMember(Order = 11)]
        public string risk_point { get; set; }

        /***风险等级***/
        [DataMember(Order = 12)]
        public string level_name { get; set; }
    }
}