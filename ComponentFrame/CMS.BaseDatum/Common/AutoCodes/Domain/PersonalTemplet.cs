#region 版本说明
/*****************************************************************************
 * 
 * 项    目 : 
 * 作    者 : 冯兴彬 
 * 创建时间 : 2010-5-27 10:23:16 
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
    /// PersonalTemplet 的摘要说明。
    /// </summary>
    public class PersonalTemplet : DataPacket
    {
        #region 私有字段

        private string _PersonalId;      // 人员模板ID
        private string _PersonalName;      // 人员名称
        private int _PersonType;      // 人员类型
        private string _ID;      // 主键
        private string _RefID;      // 引用标识

        #endregion

        #region 属性定义

        /// <summary>
        /// 人员模板ID 
        /// </summary>
        public string PersonalId { get { return _PersonalId; } set { _PersonalId = value; } }
        /// <summary>
        /// 人员名称 
        /// </summary>
        public string PersonalName { get { return _PersonalName; } set { _PersonalName = value; } }
        /// <summary>
        /// 人员类型 
        /// </summary>
        public int PersonType { get { return _PersonType; } set { _PersonType = value; } }
        /// <summary>
        /// 主键 
        /// </summary>
        public string ID { get { return _ID; } set { _ID = value; } }
        /// <summary>
        /// 引用标识 
        /// </summary>
        public string RefID { get { return _RefID; } set { _RefID = value; } }

        #endregion

        #region 重载公共函数

        /// <summary>
        /// 清除所有数据。
        /// </summary>
        public override void Clear()
        {
            base.Clear();

            _PersonalId = null;
            _PersonalName = null;
            _PersonType = 0;
            _ID = null;
            _RefID = null;
        }

        /// <summary>
        /// 用指定节点序列化整个数据对象。
        /// </summary>
        /// <param name="node">用于序列化的 XmlNode 节点。</param>
        public override void XMLEncode(System.Xml.XmlNode node)
        {
            base.XMLEncode(node);

            WriteXMLValue(node, "PersonalId", _PersonalId);
            WriteXMLValue(node, "PersonalName", _PersonalName);
            WriteXMLValue(node, "PersonType", _PersonType);
            WriteXMLValue(node, "ID", _ID);
            WriteXMLValue(node, "RefID", _RefID);
        }

        /// <summary>
        /// 用指定节点反序列化整个数据对象。
        /// </summary>
        /// <param name="node">用于反序列化的 XmlNode 节点。</param>
        public override void XMLDecode(System.Xml.XmlNode node)
        {
            base.XMLDecode(node);

            ReadXMLValue(node, "PersonalId", ref _PersonalId);
            ReadXMLValue(node, "PersonalName", ref _PersonalName);
            ReadXMLValue(node, "PersonType", ref _PersonType);
            ReadXMLValue(node, "ID", ref _ID);
            ReadXMLValue(node, "RefID", ref _RefID);
        }

        /// <summary>
        /// 复制数据对象
        /// </summary>
        /// <param name="sou">源对象,需从DataPacket继承</param>
        public override void AssignFrom(DataPacket sou)
        {
            base.AssignFrom(sou);

            PersonalTemplet s = sou as PersonalTemplet;
            if (s != null)
            {
                _PersonalId = s._PersonalId;
                _PersonalName = s._PersonalName;
                _PersonType = s._PersonType;
                _ID = s._ID;
                _RefID = s._RefID;
            }
        }

        #endregion
    }
}

