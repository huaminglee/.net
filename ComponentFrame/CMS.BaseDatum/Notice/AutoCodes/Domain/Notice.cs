#region 版本说明
/*****************************************************************************
 * 
 * 项    目 : 
 * 作    者 : 罗坤 
 * 创建时间 : 2015/1/21 14:12:15 
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
    /// Notice 系统公告的摘要说明。
    /// </summary>
    public class Notice:DataPacket
    {
        #region 私有字段
        
        private int        _Guid       ;      // 标识
        private string     _Title      ;      // 公告标题
        private string     _Content    ;      // 公告内容
        private string     _Author     ;      // 发布人
        private DateTime   _CreateDate ;      // 发布时间

        #endregion

        #region 构造函数

        /// <summary>
        /// 初始化新实例 
        /// </summary>
        public Notice()
        {
        }

        #endregion

        #region 属性定义

        /// <summary>
        /// 标识 
        /// </summary>
        public int        Guid        { get { return _Guid       ;} set { _Guid        = value; } }
        /// <summary>
        /// 公告标题 
        /// </summary>
        public string     Title       { get { return _Title      ;} set { _Title       = value; } }
        /// <summary>
        /// 公告内容 
        /// </summary>
        public string     Content     { get { return _Content    ;} set { _Content     = value; } }
        /// <summary>
        /// 发布人 
        /// </summary>
        public string     Author      { get { return _Author     ;} set { _Author      = value; } }
        /// <summary>
        /// 发布时间 
        /// </summary>
        public DateTime   CreateDate  { get { return _CreateDate ;} set { _CreateDate  = value; } }

        #endregion
        
  

        #region 重载公共函数

        /// <summary>
        /// 清除所有数据。
        /// </summary>
        public override void Clear()
        {
            base.Clear ();

            _Guid        = 0;
            _Title       = null;
            _Content     = null;
            _Author      = null;
            _CreateDate  = DateTime.MinValue;
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

            WriteXMLValue(node, "Guid", _Guid);
            WriteXMLValue(node, "Title", _Title);
            WriteXMLValue(node, "Content", _Content);
            WriteXMLValue(node, "Author", _Author);
            WriteXMLValue(node, "CreateDate", _CreateDate);
        }

        /// <summary>
        /// 用指定节点反序列化整个数据对象。
        /// </summary>
        /// <param name="node">用于反序列化的 XmlNode 节点。</param>
        public override void XMLDecode(System.Xml.XmlNode node)
        {
            base.XMLDecode (node);

            ReadXMLValue(node, "Guid", ref _Guid);
            ReadXMLValue(node, "Title", ref _Title);
            ReadXMLValue(node, "Content", ref _Content);
            ReadXMLValue(node, "Author", ref _Author);
            ReadXMLValue(node, "CreateDate", ref _CreateDate);
        }
#endif

        /// <summary>
        /// 复制数据对象
        /// </summary>
        /// <param name="sou">源对象,需从DataPacket继承</param>
        public override void AssignFrom(DataPacket sou)
        {
            base.AssignFrom (sou);

            Notice s = sou as Notice;
            if (s != null)
            {
                _Guid        = s._Guid       ;
                _Title       = s._Title      ;
                _Content     = s._Content    ;
                _Author      = s._Author     ;
                _CreateDate  = s._CreateDate ;
            }
        }

        #endregion
    }
}

