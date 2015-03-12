#region 版本说明
/*****************************************************************************
 * 
 * 项    目 : 
 * 作    者 : 李金坪 
 * 创建时间 : 2015/1/19 13:55:06 
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
    /// Quickentry 的摘要说明。
    /// </summary>
    public class Quickentry:DataPacket
    {
        #region 私有字段
        
        private int      _QId         ;      // id
        private string   _QName       ;      // 名称
        private string   _QRemark     ;      // 说明
        private string   _QPico       ;      // 图标
        private string   _QTarget     ;      // 指向
        private int      _DefaultSort ;      // 默认排序
        private int      _QType       ;      // 类型

        #endregion


        #region 属性定义

        /// <summary>
        /// id 
        /// </summary>
        public int      QId          { get { return _QId         ;} set { _QId          = value; } }
        /// <summary>
        /// 名称 
        /// </summary>
        public string   QName        { get { return _QName       ;} set { _QName        = value; } }
        /// <summary>
        /// 说明 
        /// </summary>
        public string   QRemark      { get { return _QRemark     ;} set { _QRemark      = value; } }
        /// <summary>
        /// 图标 
        /// </summary>
        public string   QPico        { get { return _QPico       ;} set { _QPico        = value; } }
        /// <summary>
        /// 指向 
        /// </summary>
        public string   QTarget      { get { return _QTarget     ;} set { _QTarget      = value; } }
        /// <summary>
        /// 默认排序 
        /// </summary>
        public int      DefaultSort  { get { return _DefaultSort ;} set { _DefaultSort  = value; } }
        /// <summary>
        /// 类型 
        /// 1:快捷入口；2：统计入口 
        /// </summary>
        public int      QType        { get { return _QType       ;} set { _QType        = value; } }

        #endregion
        
  

        #region 重载公共函数

        /// <summary>
        /// 清除所有数据。
        /// </summary>
        public override void Clear()
        {
            base.Clear ();

            _QId          = 0;
            _QName        = null;
            _QRemark      = null;
            _QPico        = null;
            _QTarget      = null;
            _DefaultSort  = 0;
            _QType        = 0;
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

            WriteXMLValue(node, "QId", _QId);
            WriteXMLValue(node, "QName", _QName);
            WriteXMLValue(node, "QRemark", _QRemark);
            WriteXMLValue(node, "QPico", _QPico);
            WriteXMLValue(node, "QTarget", _QTarget);
            WriteXMLValue(node, "DefaultSort", _DefaultSort);
            WriteXMLValue(node, "QType", _QType);
        }

        /// <summary>
        /// 用指定节点反序列化整个数据对象。
        /// </summary>
        /// <param name="node">用于反序列化的 XmlNode 节点。</param>
        public override void XMLDecode(System.Xml.XmlNode node)
        {
            base.XMLDecode (node);

            ReadXMLValue(node, "QId", ref _QId);
            ReadXMLValue(node, "QName", ref _QName);
            ReadXMLValue(node, "QRemark", ref _QRemark);
            ReadXMLValue(node, "QPico", ref _QPico);
            ReadXMLValue(node, "QTarget", ref _QTarget);
            ReadXMLValue(node, "DefaultSort", ref _DefaultSort);
            ReadXMLValue(node, "QType", ref _QType);
        }
#endif

        /// <summary>
        /// 复制数据对象
        /// </summary>
        /// <param name="sou">源对象,需从DataPacket继承</param>
        public override void AssignFrom(DataPacket sou)
        {
            base.AssignFrom (sou);

            Quickentry s = sou as Quickentry;
            if (s != null)
            {
                _QId          = s._QId         ;
                _QName        = s._QName       ;
                _QRemark      = s._QRemark     ;
                _QPico        = s._QPico       ;
                _QTarget      = s._QTarget     ;
                _DefaultSort  = s._DefaultSort ;
                _QType        = s._QType       ;
            }
        }

        #endregion
    }
}

