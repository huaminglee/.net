#region 版本说明
/*****************************************************************************
 * 
 * 项    目 : 
 * 作    者 : 张李波 
 * 创建时间 : 2009-12-14 14:06:58 
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

namespace PengeSoft.CMS.BaseDatum
{
    /// <summary>
    /// Templet 模板的摘要说明。
    /// </summary>
    public class Templet : DataPacket
    {
        #region 私有字段

        private string _TempletId;      // ID
        private string _TempletContent;      // 内容
        private string _Owner;      // 所有者
        private string _TempletName;      // 模板名称
        private int _TempletProp;      // 模板属性
        private int _TempletType;      // 模板类型

        #endregion

        #region 属性定义

        /// <summary>
        /// ID 
        /// </summary>
        public string TempletId { get { return _TempletId; } set { _TempletId = value; } }
        /// <summary>
        /// 内容 
        /// </summary>
        public string TempletContent { get { return _TempletContent; } set { _TempletContent = value; } }
        /// <summary>
        /// 所有者 
        /// </summary>
        public string Owner { get { return _Owner; } set { _Owner = value; } }
        /// <summary>
        /// 模板名称 
        /// </summary>
        public string TempletName { get { return _TempletName; } set { _TempletName = value; } }
        /// <summary>
        /// 模板属性 
        /// </summary>
        public int TempletProp { get { return _TempletProp; } set { _TempletProp = value; } }
        /// <summary>
        /// 模板类型 
        /// </summary>
        public int TempletType { get { return _TempletType; } set { _TempletType = value; } }

        #endregion

        #region 重载公共函数

        /// <summary>
        /// 清除所有数据。
        /// </summary>
        public override void Clear()
        {
            base.Clear();

            _TempletId = null;
            _TempletContent = null;
            _Owner = null;
            _TempletName = null;
            _TempletProp = 0;
            _TempletType = 0;
        }

        /// <summary>
        /// 用指定节点序列化整个数据对象。
        /// </summary>
        /// <param name="node">用于序列化的 XmlNode 节点。</param>
        public override void XMLEncode(System.Xml.XmlNode node)
        {
            base.XMLEncode(node);

            WriteXmlAttrValue(node, "TempletId", _TempletId);
            WriteXmlAttrValue(node, "TempletContent", _TempletContent);
            WriteXmlAttrValue(node, "Owner", _Owner);
            WriteXmlAttrValue(node, "TempletName", _TempletName);
            WriteXmlAttrValue(node, "TempletProp", _TempletProp);
            WriteXmlAttrValue(node, "TempletType", _TempletType);
        }

        /// <summary>
        /// 用指定节点反序列化整个数据对象。
        /// </summary>
        /// <param name="node">用于反序列化的 XmlNode 节点。</param>
        public override void XMLDecode(System.Xml.XmlNode node)
        {
            base.XMLDecode(node);

            ReadXmlAttrValue(node, "TempletId", ref _TempletId);
            ReadXmlAttrValue(node, "TempletContent", ref _TempletContent);
            ReadXmlAttrValue(node, "Owner", ref _Owner);
            ReadXmlAttrValue(node, "TempletName", ref _TempletName);
            ReadXmlAttrValue(node, "TempletProp", ref _TempletProp);
            ReadXmlAttrValue(node, "TempletType", ref _TempletType);
        }

        /// <summary>
        /// 复制数据对象
        /// </summary>
        /// <param name="sou">源对象,需从DataPacket继承</param>
        public override void AssignFrom(DataPacket sou)
        {
            base.AssignFrom(sou);

            Templet s = sou as Templet;
            if (s != null)
            {
                _TempletId = s._TempletId;
                _TempletContent = s._TempletContent;
                _Owner = s._Owner;
                _TempletName = s._TempletName;
                _TempletProp = s._TempletProp;
                _TempletType = s._TempletType;
            }
        }

        #endregion
    }
}
