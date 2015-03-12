using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;

namespace PDTech.OA.Model
{
    /// <summary>
    /// 文件Tree的实体类
    /// </summary>
    [DataContract]
    public class FileTree
    {
        /***显示文本***/
        [DataMember(Order = 0)]
        public string text { get; set; }

        /***修改时间***/
        [DataMember(Order = 1)]
        public string modifyTime { get; set; }

        /***相对路径***/
        [DataMember(Order = 2)]
        public string relativePath { get; set; }
    }
}