using System;
using System.Runtime.Serialization;

namespace PDTech.OA.Model
{
    /// <summary>
    /// OA_FAVORITE:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class OA_FAVORITE
    {
        public OA_FAVORITE()
        { }
        #region Model
        private decimal _favorite_id;
        private decimal _user_id;
        private string _ref_type;
        private decimal _ref_id;
        private DateTime? _create_time;
        /// <summary>
        /// 收藏ID主键
        /// </summary>
        public decimal FAVORITE_ID
        {
            set { _favorite_id = value; }
            get { return _favorite_id; }
        }
        /// <summary>
        /// 收藏用户ID
        /// </summary>
        public decimal USER_ID
        {
            set { _user_id = value; }
            get { return _user_id; }
        }
        /// <summary>
        /// 收藏类型(OA_ARCHIVE,OA_MESSAGE,OA_MEETING)
        /// </summary>
        public string REF_TYPE
        {
            set { _ref_type = value; }
            get { return _ref_type; }
        }
        /// <summary>
        /// 收藏对象ID
        /// </summary>
        public decimal REF_ID
        {
            set { _ref_id = value; }
            get { return _ref_id; }
        }
        /// <summary>
        /// 收藏时间
        /// </summary>
        public DateTime? CREATE_TIME
        {
            set { _create_time = value; }
            get { return _create_time; }
        }
        #endregion Model
    }

    /// <summary>
    /// 收藏夹（Json对象）
    /// </summary>
    [DataContract]
    public partial class FAVORITE
    {
        /***序号***/
        [DataMember(Order = 0)]
        public string rowno { get; set; }

        /***收藏ID***/
        [DataMember(Order = 1)]
        public string favorite_id { get; set; }

        /***公文ID***/
        [DataMember(Order = 2)]
        public string archive_id { get; set; }

        /***公文类型***/
        [DataMember(Order = 3)]
        public string archive_type { get; set; }

        /***公文标题***/
        [DataMember(Order = 4)]
        public string archive_title { get; set; }

        /***公文创建时间***/
        [DataMember(Order = 5)]
        public string create_time { get; set; }

        /***公文办理状态***/
        [DataMember(Order = 6)]
        public string current_state { get; set; }

        /***创建人***/
        [DataMember(Order = 7)]
        public string creator { get; set; }
    }
}