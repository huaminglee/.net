using System;

namespace PDTech.OA.Model.VIEW
{
    [Serializable]
    public class VIEW_ARCHIVE_STEMP
    {
        /// <summary>
        /// 公文ID
        /// </summary>
        public decimal? ARCHIVE_ID
        {
            get;
            set;
        }
        /// <summary>
        /// 步骤模板ID
        /// </summary>
        public decimal? FLOW_TEMPLATE_ID
        {
            get;
            set;
        }
        /// <summary>
        /// 当前办理人员名称
        /// </summary>
        public string FULL_NAME
        {
            get;
            set;
        }
        /// <summary>
        /// 当前步骤名称
        /// </summary>
        public string STEP_NAME
        {
            get;
            set;
        }
        /// <summary>
        /// 当前步骤ID
        /// </summary>
        public decimal? CURRENT_STEP_ID
        {
            get;
            set;
        }
    }
}
