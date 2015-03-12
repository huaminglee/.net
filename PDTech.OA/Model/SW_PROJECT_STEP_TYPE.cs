using System;
using System.Runtime.Serialization;

namespace PDTech.OA.Model
{
    /// <summary>
    /// 项目步骤定义表
    /// </summary>
    [Serializable]
    public partial class SW_PROJECT_STEP_TYPE
    {
        public SW_PROJECT_STEP_TYPE()
        { }
        #region Model
        private decimal _step_id;
        private decimal? _project_type;
        private string _step_name;
        /// <summary>
        /// 步骤ID
        /// </summary>
        public decimal STEP_ID
        {
            set { _step_id = value; }
            get { return _step_id; }
        }
        /// <summary>
        /// 项目类型(1：规计处备案项目、2：财务处备案项目）
        /// </summary>
        public decimal? PROJECT_TYPE
        {
            set { _project_type = value; }
            get { return _project_type; }
        }
        /// <summary>
        /// 步骤名称
        /// </summary>
        public string STEP_NAME
        {
            set { _step_name = value; }
            get { return _step_name; }
        }
        #endregion Model
    }
}