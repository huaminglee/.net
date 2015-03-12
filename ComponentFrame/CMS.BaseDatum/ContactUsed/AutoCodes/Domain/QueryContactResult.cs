#region 版本说明
/*****************************************************************************
 * 
 * 项    目 : 
 * 作    者 : 李金坪 
 * 创建时间 : 2014/9/17 11:14:39 
 *
 * Copyright (C) 2008 - 鹏业软件公司
 * 
 *****************************************************************************/
#endregion

using System;
using System.Collections;
using System.Text;
using PengeSoft.Data;
using PengeSoft.WorkZoneData;
using PengeSoft.db;

namespace PengeSoft.CMS.BaseDatum
{
    /// <summary>
    /// QueryContactResult 的摘要说明。
    /// </summary>
    public class QueryContactResult : DataPacket
    {
        #region 私有字段

        private int _usecount;      // 使用次数
        private string _ContactUserID;      // 联系人ID
        private string _ContactUserXM;      // 联系人姓名

        #endregion


        #region 属性定义

        /// <summary>
        /// 使用次数 
        /// </summary>
        public int usecount { get { return _usecount; } set { _usecount = value; } }
        /// <summary>
        /// 联系人ID 
        /// </summary>
        public string ContactUserID { get { return _ContactUserID; } set { _ContactUserID = value; } }
        /// <summary>
        /// 联系人姓名 
        /// </summary>
        public string ContactUserXM { get { return _ContactUserXM; } set { _ContactUserXM = value; } }

        #endregion



        #region 重载公共函数

        /// <summary>
        /// 清除所有数据。
        /// </summary>
        public override void Clear()
        {
            base.Clear();

            _usecount = 0;
            _ContactUserID = null;
            _ContactUserXM = null;
        }


#if SILVERLIGHT
#else
        /// <summary>
        /// 用指定节点序列化整个数据对象。
        /// </summary>
        /// <param name="node">用于序列化的 XmlNode 节点。</param>
        public override void XMLEncode(System.Xml.XmlNode node)
        {
            base.XMLEncode(node);

            WriteXMLValue(node, "usecount", _usecount);
            WriteXMLValue(node, "ContactUserID", _ContactUserID);
            WriteXMLValue(node, "ContactUserXM", _ContactUserXM);
        }

        /// <summary>
        /// 用指定节点反序列化整个数据对象。
        /// </summary>
        /// <param name="node">用于反序列化的 XmlNode 节点。</param>
        public override void XMLDecode(System.Xml.XmlNode node)
        {
            base.XMLDecode(node);

            ReadXMLValue(node, "usecount", ref _usecount);
            ReadXMLValue(node, "ContactUserID", ref _ContactUserID);
            ReadXMLValue(node, "ContactUserXM", ref _ContactUserXM);
        }
#endif

        /// <summary>
        /// 复制数据对象
        /// </summary>
        /// <param name="sou">源对象,需从DataPacket继承</param>
        public override void AssignFrom(DataPacket sou)
        {
            base.AssignFrom(sou);

            QueryContactResult s = sou as QueryContactResult;
            if (s != null)
            {
                _usecount = s._usecount;
                _ContactUserID = s._ContactUserID;
                _ContactUserXM = s._ContactUserXM;
            }
        }

        #endregion
    }
}
