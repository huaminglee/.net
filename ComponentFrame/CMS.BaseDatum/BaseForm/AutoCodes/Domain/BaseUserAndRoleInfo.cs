#region 版本说明
/*****************************************************************************
 * 
 * 项    目 : 
 * 作    者 : 李金坪 
 * 创建时间 : 2015/2/13 9:56:41 
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
    /// BaseUserAndRoleInfo 的摘要说明。
    /// </summary>
    public class BaseUserAndRoleInfo:DataPacket
    {
        #region 私有字段
        
        private int      _SID      ;      // SID
        private string   _FullName ;      // FullName
        private string   _LoginID  ;      // LoginID

        #endregion


        #region 属性定义

        /// <summary>
        /// SID 
        /// </summary>
        public int      SID       { get { return _SID      ;} set { _SID       = value; } }
        /// <summary>
        /// FullName 
        /// </summary>
        public string   FullName  { get { return _FullName ;} set { _FullName  = value; } }
        /// <summary>
        /// LoginID 
        /// </summary>
        public string   LoginID   { get { return _LoginID  ;} set { _LoginID   = value; } }

        #endregion
        
  

        #region 重载公共函数

        /// <summary>
        /// 清除所有数据。
        /// </summary>
        public override void Clear()
        {
            base.Clear ();

            _SID       = 0;
            _FullName  = null;
            _LoginID   = null;
        }
        

#if SILVERLIGHT
#else
        /// <summary>
        /// 用指定节点序列化整个数据对象。
        /// </summary>
        /// <param name="node">用于序列化的 XmlNode 节点。</param>
        public override void XMLEncode(System.Xml.XmlNode node)
        {
            base.XMLEncode (node);

            WriteXMLValue(node, "SID", _SID);
            WriteXMLValue(node, "FullName", _FullName);
            WriteXMLValue(node, "LoginID", _LoginID);
        }

        /// <summary>
        /// 用指定节点反序列化整个数据对象。
        /// </summary>
        /// <param name="node">用于反序列化的 XmlNode 节点。</param>
        public override void XMLDecode(System.Xml.XmlNode node)
        {
            base.XMLDecode (node);

            ReadXMLValue(node, "SID", ref _SID);
            ReadXMLValue(node, "FullName", ref _FullName);
            ReadXMLValue(node, "LoginID", ref _LoginID);
        }
#endif

        /// <summary>
        /// 复制数据对象
        /// </summary>
        /// <param name="sou">源对象,需从DataPacket继承</param>
        public override void AssignFrom(DataPacket sou)
        {
            base.AssignFrom (sou);

            BaseUserAndRoleInfo s = sou as BaseUserAndRoleInfo;
            if (s != null)
            {
                _SID       = s._SID      ;
                _FullName  = s._FullName ;
                _LoginID   = s._LoginID  ;
            }
        }

        #endregion
    }
}

