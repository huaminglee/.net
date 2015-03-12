#region 版本说明
/*****************************************************************************
 * 
 * 项    目 : 
 * 作    者 : 李金坪 
 * 创建时间 : 2015/2/11 17:57:30 
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
    /// BaseDeptInfo 的摘要说明。
    /// </summary>
    public class BaseDeptInfo : DataPacket
    {
        #region 私有字段
        private int _SID;              // 部门id
        private string _LoginID;       // 部门标识
        private int _ParentID;      // 父节点id        
        private string _FullName;      // 全名
        private string _Detail;        // 描述
        private int _Deep;             // Deep

        #endregion


        #region 属性定义

        /// <summary>
        /// 部门id 
        /// </summary>
        public int SID { get { return _SID; } set { _SID = value; } }
        /// <summary>
        /// 部门标识 
        /// </summary>
        public string LoginID { get { return _LoginID; } set { _LoginID = value; } }
        /// <summary>
        /// 父节点id 
        /// </summary>
        public int ParentID { get { return _ParentID; } set { _ParentID = value; } }
        /// <summary>
        /// 全名 
        /// </summary>
        public string FullName { get { return _FullName; } set { _FullName = value; } }
        /// <summary>
        /// 描述 
        /// </summary>
        public string Detail { get { return _Detail; } set { _Detail = value; } }
        /// <summary>
        /// Deep 
        /// </summary>
        public int Deep { get { return _Deep; } set { _Deep = value; } }

        #endregion



        #region 重载公共函数

        /// <summary>
        /// 清除所有数据。
        /// </summary>
        public override void Clear()
        {
            base.Clear();
            _SID = 0;
            _LoginID = null;
            _ParentID = 0;
            _FullName = null;
            _Detail = null;
            _Deep = 0;
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
            WriteXMLValue(node, "SID", _SID);
            WriteXMLValue(node, "LoginID", _LoginID);
            WriteXMLValue(node, "ParentID", _ParentID);
            WriteXMLValue(node, "FullName", _FullName);
            WriteXMLValue(node, "Detail", _Detail);
            WriteXMLValue(node, "Deep", _Deep);
        }

        /// <summary>
        /// 用指定节点反序列化整个数据对象。
        /// </summary>
        /// <param name="node">用于反序列化的 XmlNode 节点。</param>
        public override void XMLDecode(System.Xml.XmlNode node)
        {
            base.XMLDecode(node);
            ReadXMLValue(node, "SID", ref _SID);
            ReadXMLValue(node, "LoginID", ref _LoginID);
            ReadXMLValue(node, "ParentID", ref _ParentID);
            ReadXMLValue(node, "FullName", ref _FullName);
            ReadXMLValue(node, "Detail", ref _Detail);
            ReadXMLValue(node, "Deep", ref _Deep);
        }
#endif

        /// <summary>
        /// 复制数据对象
        /// </summary>
        /// <param name="sou">源对象,需从DataPacket继承</param>
        public override void AssignFrom(DataPacket sou)
        {
            base.AssignFrom(sou);

            BaseDeptInfo s = sou as BaseDeptInfo;
            if (s != null)
            {
                _SID = s._SID;
                _LoginID = s._LoginID;
                _ParentID = s._ParentID;
                _FullName = s._FullName;
                _Detail = s._Detail;
                _Deep = s._Deep;
            }
        }

        #endregion
    }
}
