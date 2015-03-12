using System;
namespace PDTech.OA.Model
{
    /// <summary>
    /// VIEW_PRINT_STEPDETAIL:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class VIEW_PRINT_STEPDETAIL
    {
        public VIEW_PRINT_STEPDETAIL()
        { }
        #region Model
        private decimal? _archive_task_id;
        private string _print_title;
        private string _is_print;
        private string _task_remark;
        private string _full_name;
        private decimal? _archive_id;
        private decimal? _step_id;
        private DateTime? _end_time;
        private decimal? _task_state;
        private string _step_name;
        /// <summary>
        /// 
        /// </summary>
        public decimal? ARCHIVE_TASK_ID
        {
            set { _archive_task_id = value; }
            get { return _archive_task_id; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string PRINT_TITLE
        {
            set { _print_title = value; }
            get { return _print_title; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string IS_PRINT
        {
            set { _is_print = value; }
            get { return _is_print; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string TASK_REMARK
        {
            set { _task_remark = value; }
            get { return _task_remark; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string FULL_NAME
        {
            set { _full_name = value; }
            get { return _full_name; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? ARCHIVE_ID
        {
            set { _archive_id = value; }
            get { return _archive_id; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? STEP_ID
        {
            set { _step_id = value; }
            get { return _step_id; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? END_TIME
        {
            set { _end_time = value; }
            get { return _end_time; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? TASK_STATE
        {
            set { _task_state = value; }
            get { return _task_state; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string STEP_NAME
        {
            set { _step_name = value; }
            get { return _step_name; }
        }
        public DateTime? LIMIT_TIME
        {
            get;
            set;
        }
        public DateTime? START_TIME
        {
            get;
            set;
        }
        public string DEPARTMENT_NAME
        {
            get;
            set;
        }
        #endregion Model

    }
}

