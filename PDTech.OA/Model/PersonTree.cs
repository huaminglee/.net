using System.Collections.Generic;
using System.Runtime.Serialization;

namespace PDTech.OA.Model
{
    /// <summary>
    /// 岗位人员Tree的实体类
    /// </summary>
    [DataContract]
    public class PersonTree
    {
        /***ID***/
        [DataMember(Order = 0)]
        public string id { get; set; }

        /***父级ID***/
        [DataMember(Order = 1)]
        public string parentId { get; set; }

        /***显示文本***/
        [DataMember(Order = 2)]
        public string text { get; set; }

        /***是否被勾选（checked是关键字，需要指定序列化成员名称或方法名前加“@”）***/
        [DataMember(Order = 3, Name = "checked")]
        public bool isChecked { get; set; }

        /***样式***/
        [DataMember(Order = 4)]
        public string iconCls { get; set; }

        /***是否展开节点***/
        [DataMember(Order = 5)]
        public string state { get; set; }

        /***状态（值：person，department）***/
        [DataMember(Order = 6)]
        public string status { get; set; }

        /***默认指定人员***/
        [DataMember(Order = 7)]
        public string duid { get; set; }

        /***子节点***/
        [DataMember(Order = 8)]
        public List<PersonTree> children { get; set; }
    }
}