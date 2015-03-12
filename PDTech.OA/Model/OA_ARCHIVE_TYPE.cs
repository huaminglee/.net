using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace PDTech.OA.Model
{
    /// <summary>
    /// 公文类型定义字典表
    /// </summary>
    [Serializable]
    public partial class OA_ARCHIVE_TYPE
    {
        public OA_ARCHIVE_TYPE()
        { }
        #region Model
        private decimal _archive_type;
        private string _type_name;
        private string _group_name;
        /// <summary>
        /// 公文类型ID 公文类型,10：一般阅件，11：普通办件，12：单位发文，......20：领导批示件，21：党组会督办件，22：局长办公会督办件，23：新访督办件......24：建议提案，32：人事任免
        /// </summary>
        public decimal ARCHIVE_TYPE
        {
            set { _archive_type = value; }
            get { return _archive_type; }
        }
        /// <summary>
        /// 公文类型名称
        /// </summary>
        public string TYPE_NAME
        {
            set { _type_name = value; }
            get { return _type_name; }
        }
        /// <summary>
        /// 分组名称
        /// </summary>
        public string GROUP_NAME
        {
            set { _group_name = value; }
            get { return _group_name; }
        }
        #endregion Model
    }

    /// <summary>
    /// 公文类型（Tree）
    /// </summary>
    [DataContract]
    public partial class ARCHIVE_TYPE
    {
        /***类型ID***/
        [DataMember(Order = 0)]
        public string id { get; set; }

        /***父级ID***/
        [DataMember(Order = 1)]
        public string parentId { get; set; }

        /***类型名称***/
        [DataMember(Order = 2)]
        public string text { get; set; }

        /***分组名称***/
        [DataMember(Order = 3)]
        public string group_name { get; set; }

        /***样式***/
        [DataMember(Order = 4)]
        public string iconCls { get; set; }

        /***子节点***/
        [DataMember(Order = 5)]
        public List<ARCHIVE_TYPE> children { get; set; }
    }

    /// <summary>
    /// 公文类型（下拉框）
    /// </summary>
    [DataContract]
    public partial class ARCHIVE_TYPE_OPTION
    {
        /***类型ID***/
        [DataMember(Order = 0)]
        public string archive_type { get; set; }

        /***类型名称***/
        [DataMember(Order = 1)]
        public string type_name { get; set; }
    }
}