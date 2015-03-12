using System;
using System.Collections.Generic;
using System.Text;

namespace PDTech.OA.Model
{
    [Serializable]
    public class Pro_TASKHandle
    {
        /// <summary>
        /// 当前任务ID
        /// </summary>
        public decimal? P_TASK_ID
        {
            get;
            set;
        }
        /// <summary>
        /// 下一步骤ID
        /// </summary>
        public decimal? P_NEXT_STEP_ID
        {
            get;
            set;
        }
        /// <summary>
        /// 跳过下一步原因 如果有
        /// </summary>
        public string P_SKIPP_REMARK
        {
            get;
            set;
        }
        /// <summary>
        /// 下一个任务的用户ID
        /// </summary>
        public string P_NEXT_USER_LIST
        {
            get;
            set;
        }
        /// <summary>
        /// 当前任务备注和说明
        /// </summary>
        public string P_TASK_REMARK
        {
            get;
            set;
        }
        /// <summary>
        /// 任务时限
        /// </summary>
        public DateTime? P_LIMIT_TIME
        {
            get;
            set;
        }
        /// <summary>
        /// 是否立即发送短信 1:发送 0:不发送
        /// </summary>
        public decimal? P_IS_SEND_SMS_NOW
        {
            get;
            set;
        }
        /// <summary>
        /// 工作到期之前是否发送短信 1:发送 0:不发送
        /// </summary>
        public decimal? P_IS_SEND_SMS_LIMIT
        {
            get;
            set;
        }
        /// <summary>
        /// 工作到期之前发送短信时间
        /// </summary>
        public DateTime? P_SMS_LIMIT_TIME
        {
            get;
            set;
        }
        /// <summary>
        /// 短信接收人类型1:下一步操作人员、2:当前和下一步操作人员
        /// </summary>
        public decimal? P_SMS_TO_USER_TYPE
        {
            get;
            set;
        }
        /// <summary>
        /// 0表示失败，其它表示成功
        /// </summary>
        public decimal? RESULTCODE
        {
            get;
            set;
        }
        /// <summary>
        /// 盖章时需要保护的数据
        /// </summary>
        public string P_PROTECT_DATA
        {
            get;
            set;
        }
    }
}
