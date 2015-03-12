using System;
using System.Runtime.Serialization;

namespace PDTech.OA.Model
{
    /// <summary>
    /// 风险防控点定义维护表
    /// </summary>
    [Serializable]
    public partial class RISK_POINT_INFO
    {
        public RISK_POINT_INFO()
        { }
        #region Model
        private decimal _risk_point_id;
        private string _step_type;
        private decimal _step_id;
        private decimal? _risk_level;
        private string _risk_point;
        private string _risk_resolve;
        private string _remark;
        /// <summary>
        /// 风险防控点ID
        /// </summary>
        public decimal RISK_POINT_ID
        {
            set { _risk_point_id = value; }
            get { return _risk_point_id; }
        }
        /// <summary>
        /// 风险模块类型目前分2类OA_WORKFLOW_STEP和SW_PROJECT_STEP
        /// </summary>
        public string STEP_TYPE
        {
            set { _step_type = value; }
            get { return _step_type; }
        }
        /// <summary>
        /// 步骤ID
        /// </summary>
        public decimal STEP_ID
        {
            set { _step_id = value; }
            get { return _step_id; }
        }
        /// <summary>
        /// 风险等级 1:一级 2：二级 3：三级
        /// </summary>
        public decimal? RISK_LEVEL
        {
            set { _risk_level = value; }
            get { return _risk_level; }
        }
        /// <summary>
        /// 风险点
        /// </summary>
        public string RISK_POINT
        {
            set { _risk_point = value; }
            get { return _risk_point; }
        }
        /// <summary>
        /// 风险预防措施
        /// </summary>
        public string RISK_RESOLVE
        {
            set { _risk_resolve = value; }
            get { return _risk_resolve; }
        }
        /// <summary>
        /// 其它备注
        /// </summary>
        public string REMARK
        {
            set { _remark = value; }
            get { return _remark; }
        }
        #endregion Model
    }

    /// <summary>
    /// 风险防控点（Json对象）
    /// </summary>
    [DataContract]
    public partial class RISK_POINT
    {
        /***风险防控ID***/
        [DataMember(Order = 0)]
        public string risk_point_id { get; set; }

        /***步骤ID***/
        [DataMember(Order = 1)]
        public string step_id { get; set; }

        /***风险模块类型（OA_WORKFLOW_STEP和SW_PROJECT_STEP）***/
        [DataMember(Order = 2)]
        public string step_type { get; set; }

        /***类型名称***/
        [DataMember(Order = 3)]
        public string type_name { get; set; }

        /***风险等级（1，2，3）***/
        [DataMember(Order = 4)]
        public string risk_level { get; set; }

        /***等级名称（一级，二级，三级）***/
        [DataMember(Order = 5)]
        public string level_name { get; set; }

        /***风险点***/
        [DataMember(Order = 6)]
        public string risk_point { get; set; }

        /***风险预防措施***/
        [DataMember(Order = 7)]
        public string risk_resolve { get; set; }

        /***备注***/
        [DataMember(Order = 8)]
        public string remark { get; set; }

        /***序号***/
        [DataMember(Order = 9)]
        public string rowno { get; set; }
    }
}