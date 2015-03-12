using System;
using System.Runtime.Serialization;

namespace PDTech.OA.Model
{
    /// <summary>
    /// 工作流步骤定义模板
    /// </summary>
    [Serializable]
    public partial class WORKFLOW_STEP
    {
        public WORKFLOW_STEP()
        { }
        #region Model
        private decimal? _step_id;
        private decimal? _flow_template_id;
        private string _step_name;
        private decimal? _next_step_id;
        private string _is_skip;
        private string _from_id;
        private string _right_code;
        private string _is_need_response_user;
        private string _is_return_to_response_user;
        private string _is_copy_to_response_user;
        private decimal? _start_new_flow_id;
        private string _end_flag;
        private string _limit_time_flag;
        private string _start_flag;
        private string _is_allow_multi_receive;
        private string _is_print;
        private string _print_title;
        private string _is_need_sign;
        /// <summary>
        /// 流程步骤ID，主键
        /// </summary>
        public decimal? STEP_ID
        {
            set { _step_id = value; }
            get { return _step_id; }
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
        /// 流程步骤名称
        /// </summary>
        public string STEP_NAME
        {
            set { _step_name = value; }
            get { return _step_name; }
        }
        /// <summary>
        /// 下一步流程ID
        /// </summary>
        public decimal? NEXT_STEP_ID
        {
            set { _next_step_id = value; }
            get { return _next_step_id; }
        }
        /// <summary>
        /// 是否允许跳过下一步骤1：允许跳过，其它为不允许，默认为不允许
        /// </summary>
        public string IS_SKIP
        {
            set { _is_skip = value; }
            get { return _is_skip; }
        }
        /// <summary>
        /// 表单ID
        /// </summary>
        public string FROM_ID
        {
            set { _from_id = value; }
            get { return _from_id; }
        }
        /// <summary>
        /// 当前步骤的操作权限编码
        /// </summary>
        public string RIGHT_CODE
        {
            set { _right_code = value; }
            get { return _right_code; }
        }
        /// <summary>
        /// 是否指定专管员1:需要指定专管员，0:不用指定专管员
        /// </summary>
        public string IS_NEED_RESPONSE_USER
        {
            set { _is_need_response_user = value; }
            get { return _is_need_response_user; }
        }
        /// <summary>
        /// 该步骤是否默认返回到专管员
        /// </summary>
        public string IS_RETURN_TO_RESPONSE_USER
        {
            set { _is_return_to_response_user = value; }
            get { return _is_return_to_response_user; }
        }
        /// <summary>
        /// 该步骤是否默认抄送给专管员
        /// </summary>
        public string IS_COPY_TO_RESPONSE_USER
        {
            set { _is_copy_to_response_user = value; }
            get { return _is_copy_to_response_user; }
        }
        /// <summary>
        /// 启动新工作流的模板ID，如果不允许则为空
        /// </summary>
        public decimal? START_NEW_FLOW_ID
        {
            set { _start_new_flow_id = value; }
            get { return _start_new_flow_id; }
        }
        /// <summary>
        /// 是否是完结步骤
        /// </summary>
        public string END_FLAG
        {
            set { _end_flag = value; }
            get { return _end_flag; }
        }
        /// <summary>
        /// 该步骤默认是否需要指定完成时限,新建公文时完成时限为公文的完成时限
        /// </summary>
        public string LIMIT_TIME_FLAG
        {
            set { _limit_time_flag = value; }
            get { return _limit_time_flag; }
        }
        /// <summary>
        /// 开始步骤1:表示为流程开始步骤
        /// </summary>
        public string START_FLAG
        {
            set { _start_flag = value; }
            get { return _start_flag; }
        }
        /// <summary>
        /// 是否支持多人协同处理1：支持，其它为不支持
        /// </summary>
        public string IS_ALLOW_MULTI_RECEIVE
        {
            set { _is_allow_multi_receive = value; }
            get { return _is_allow_multi_receive; }
        }
        /// <summary>
        /// 该流程步骤是否打印1:打印 其它不打印
        /// </summary>
        public string IS_PRINT
        {
            set { _is_print = value; }
            get { return _is_print; }
        }
        /// <summary>
        /// 流程步骤打印标题
        /// </summary>
        public string PRINT_TITLE
        {
            set { _print_title = value; }
            get { return _print_title; }
        }
        /// <summary>
        /// 是否参与签名1：需要参与签名，0：不用参与签名
        /// </summary>
        public string IS_NEED_SIGN
        {
            set { _is_need_sign = value; }
            get { return _is_need_sign; }
        }

        /// <summary>
        /// 当前步骤是否默认是可循环步骤(如派件)1:为可循环
        /// </summary>
        public string IS_LOOP_STEP
        {
            set;
            get;
        }
        /// <summary>
        /// 该步骤是否允许退回到上一步 1:为可退回，返回到上一步
        /// </summary>
        public string IS_ALLOW_REVERT
        {
            set;
            get;
        }
        #endregion Model
    }

    /// <summary>
    /// 风险步骤--日常办公公文（Json对象）
    /// </summary>
    [DataContract]
    public partial class OA_RISK_STEP
    {
        /***步骤ID***/
        [DataMember(Order = 0)]
        public int step_id { get; set; }

        /***步骤名称***/
        [DataMember(Order = 1)]
        public string step_name { get; set; }
    }
}