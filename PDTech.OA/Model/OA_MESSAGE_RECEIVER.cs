using System;
using System.Runtime.Serialization;

namespace PDTech.OA.Model
{
    /// <summary>
    /// 公告消息接收情况
    /// </summary>
    [Serializable]
    public partial class OA_MESSAGE_RECEIVER
    {
        public OA_MESSAGE_RECEIVER()
        { }
        #region Model
        private decimal? _message_id;
        private decimal? _receiver_id;
        private decimal? _read_status;
        private DateTime? _read_time;
        /// <summary>
        /// 消息ID
        /// </summary>
        public decimal? MESSAGE_ID
        {
            set { _message_id = value; }
            get { return _message_id; }
        }
        /// <summary>
        /// 接收人
        /// </summary>
        public decimal? RECEIVER_ID
        {
            set { _receiver_id = value; }
            get { return _receiver_id; }
        }
        /// <summary>
        /// 已读状态0:未读，1:已读
        /// </summary>
        public decimal? READ_STATUS
        {
            set { _read_status = value; }
            get { return _read_status; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? READ_TIME
        {
            set { _read_time = value; }
            get { return _read_time; }
        }
        #endregion Model
    }

    /// <summary>
    /// 未读公告消息（Json对象）
    /// </summary>
    [DataContract]
    public partial class OA_BULLETIN
    {
        /***公告ID***/
        [DataMember(Order = 0)]
        public string message_id { get; set; }

        /***公告标题***/
        [DataMember(Order = 1)]
        public string message_title { get; set; }

        /***发送时间***/
        [DataMember(Order = 2)]
        public string message_send_time { get; set; }

        /***发送人***/
        [DataMember(Order = 3)]
        public string message_sender { get; set; }

        /***阅读状态***/
        [DataMember(Order = 4)]
        public string read_status { get; set; }

        /***类型名称（首页显示公告+会议）***/
        [DataMember(Order = 5)]
        public string type_name { get; set; }
    }

    /// <summary>
    /// 未读和已读公告消息（Json对象）
    /// </summary>
    [DataContract]
    public partial class OA_ALL_BULLETIN : OA_BULLETIN
    {
        /***序号***/
        [DataMember(Order = 6)]
        public string rowno { get; set; }
    }
}