using System;
using System.Runtime.Serialization;

namespace PDTech.OA.Model
{
    /// <summary>
    /// DUTY_RISK_INFO:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class DUTY_RISK_INFO
    {
        public DUTY_RISK_INFO()
        { }
        #region Model
        private decimal _duty_risk_id;
        private string _duty_name;
        private string _risk_name;
        private string _risk_level;
        private string _avoid_metoh;
        private decimal _department_id;
        /// <summary>
        /// 岗位风险ID
        /// </summary>
        public decimal DUTY_RISK_ID
        {
            set { _duty_risk_id = value; }
            get { return _duty_risk_id; }
        }
        /// <summary>
        /// 岗位名称
        /// </summary>
        public string DUTY_NAME
        {
            set { _duty_name = value; }
            get { return _duty_name; }
        }
        /// <summary>
        /// 风险名称
        /// </summary>
        public string RISK_NAME
        {
            set { _risk_name = value; }
            get { return _risk_name; }
        }
        /// <summary>
        /// 风险等级1：一级、2：二级、3：三级
        /// </summary>
        public string RISK_LEVEL
        {
            set { _risk_level = value; }
            get { return _risk_level; }
        }
        /// <summary>
        /// 防范措施
        /// </summary>
        public string AVOID_METOH
        {
            set { _avoid_metoh = value; }
            get { return _avoid_metoh; }
        }
        /// <summary>
        /// 部门ID
        /// </summary>
        public decimal DEPARTMENT_ID
        {
            set { _department_id = value; }
            get { return _department_id; }
        }
        #endregion Model
    }

    /// <summary>
    /// 岗位风险（Json对象）
    /// </summary>
    [DataContract]
    public partial class DUTY_RISK
    {
        /***序号***/
        [DataMember(Order = 0)]
        public string rowno { get; set; }

        /***风险ID***/
        [DataMember(Order = 1)]
        public string duty_risk_id { get; set; }

        /***部门名称***/
        [DataMember(Order = 2)]
        public string department_name { get; set; }

        /***岗位名称***/
        [DataMember(Order = 3)]
        public string duty_name { get; set; }

        /***风险名称***/
        [DataMember(Order = 4)]
        public string risk_name { get; set; }

        /***防范措施***/
        [DataMember(Order = 5)]
        public string avoid_metoh { get; set; }

        /***风险等级（1：一级、2：二级、3：三级）***/
        [DataMember(Order = 6)]
        public string risk_level { get; set; }
    }
}