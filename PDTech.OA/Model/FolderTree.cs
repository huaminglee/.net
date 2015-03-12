using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;

namespace PDTech.OA.Model
{
    /// <summary>
    /// 文件夹Tree的实体类
    /// </summary>
    [DataContract]
    public class FolderTree
    {
        /***显示文本***/
        [DataMember(Order = 0)]
        public string text { get; set; }

        /***完整路径***/
        [DataMember(Order = 1)]
        public string fullPath { get; set; }

        /***样式***/
        [DataMember(Order = 2)]
        public string iconCls { get; set; }

        /***子节点***/
        [DataMember(Order = 3)]
        public List<FolderTree> children { get; set; }
    }
}