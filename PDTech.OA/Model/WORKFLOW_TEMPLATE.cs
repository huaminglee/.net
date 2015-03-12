using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace PDTech.OA.Model
{
    /// <summary>
    /// 流程模板定义表
    /// </summary>
    [Serializable]
    public partial class WORKFLOW_TEMPLATE
    {
        public WORKFLOW_TEMPLATE()
        { }
        #region Model
        private decimal _flow_template_id;
        private string _flow_template_name;
        /// <summary>
        /// 流程模板ID
        /// </summary>
        public decimal FLOW_TEMPLATE_ID
        {
            set { _flow_template_id = value; }
            get { return _flow_template_id; }
        }
        /// <summary>
        /// 流程模板名称
        /// </summary>
        public string FLOW_TEMPLATE_NAME
        {
            set { _flow_template_name = value; }
            get { return _flow_template_name; }
        }
        #endregion Model
    }

    /// <summary>
    /// 流程模板 包含具体流程步骤
    /// </summary>
    [Serializable]
    public partial class WORKFLOW_TEMPLATE_MODEL : WORKFLOW_TEMPLATE
    {
        public WORKFLOW_TEMPLATE_MODEL()
        { }
        #region Model
        private List<WORKFLOW_STEP> steps = new List<WORKFLOW_STEP>();

        /// <summary>
        /// 流程包含的步骤
        /// </summary>
        public List<WORKFLOW_STEP> Steps
        {
            get { return steps; }
            set { steps = value; }
        }
        #endregion Model
    }

    /// <summary>
    /// 风险模块--日常办公公文（Json对象）
    /// </summary>
    [DataContract]
    public partial class OA_RISK_MODULE
    {
        /***模块ID***/
        [DataMember(Order = 0)]
        public string flow_template_id { get; set; }

        /***模块名称***/
        [DataMember(Order = 1)]
        public string flow_template_name { get; set; }
    }
}