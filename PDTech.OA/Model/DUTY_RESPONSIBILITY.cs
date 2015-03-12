using System;
using System.Runtime.Serialization;

namespace PDTech.OA.Model
{
    /// <summary>
    /// 岗位职责
    /// </summary>
    [Serializable]
    public partial class DUTY_RESPONSIBILITY
    {
        public DUTY_RESPONSIBILITY()
        { }
        #region Model
        private decimal _duty_responsibility_id;
        private string _duty_name;
        private string _responsibility;
        private decimal? _department_id;
        /// <summary>
        /// 岗位职责
        /// </summary>
        public decimal DUTY_RESPONSIBILITY_ID
        {
            set { _duty_responsibility_id = value; }
            get { return _duty_responsibility_id; }
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
        /// 岗位职责
        /// </summary>
        public string RESPONSIBILITY
        {
            set { _responsibility = value; }
            get { return _responsibility; }
        }
        /// <summary>
        /// 部门ID
        /// </summary>
        public decimal? DEPARTMENT_ID
        {
            set { _department_id = value; }
            get { return _department_id; }
        }
        #endregion Model
    }

    /// <summary>
    /// 所有岗位职责（Json对象）
    /// </summary>
    [DataContract]
    public partial class RESPONSIBILITY
    {
        /***序号***/
        [DataMember(Order = 0)]
        public string rowno { get; set; }

        /***职责ID***/
        [DataMember(Order = 1)]
        public string duty_responsibility_id { get; set; }

        /***所在单位***/
        [DataMember(Order = 2)]
        public string department_name { get; set; }

        /***岗位名称***/
        [DataMember(Order = 3)]
        public string duty_name { get; set; }

        /***岗位职责***/
        [DataMember(Order = 4)]
        public string responsibility { get; set; }
    }
}