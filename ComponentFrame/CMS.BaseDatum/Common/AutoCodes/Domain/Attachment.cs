#region 版本说明
/*****************************************************************************
 * 
 * 项    目 : 
 * 作    者 : 陈锐(开发) 
 * 创建时间 : 2010-4-27 下午 01:45:21 
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
    /// Attachment 附件的摘要说明。
    /// </summary>
    public class Attachment : DataPacket
    {
        #region 私有字段

        private string _AttachmentId;      // ID
        private DateTime _CreateTime;      // 添加时间
        private string _Creator;      // 添加人
        private string _FileName;      // 文件名称
        private double _FileSize;      // 文件大小
        private string _RefID;      // 外键标识
        private string _RefType;      // 外键类型
        private string _FileId;      // 文件ID

        #endregion

        #region 属性定义

        /// <summary>
        /// ID 
        /// </summary>
        public string AttachmentId { get { return _AttachmentId; } set { _AttachmentId = value; } }
        /// <summary>
        /// 添加时间 
        /// </summary>
        public DateTime CreateTime { get { return _CreateTime; } set { _CreateTime = value; } }
        /// <summary>
        /// 添加人 
        /// </summary>
        public string Creator { get { return _Creator; } set { _Creator = value; } }
        /// <summary>
        /// 文件名称 
        /// </summary>
        public string FileName { get { return _FileName; } set { _FileName = value; } }
        /// <summary>
        /// 文件大小 
        /// </summary>
        public double FileSize { get { return _FileSize; } set { _FileSize = value; } }
        /// <summary>
        /// 外键标识 
        /// </summary>
        public string RefID { get { return _RefID; } set { _RefID = value; } }
        /// <summary>
        /// 外键类型 (oa_archive,oa_conference,oa_message)
        /// </summary>
        public string RefType { get { return _RefType; } set { _RefType = value; } }
        /// <summary>
        /// 文件ID 
        /// </summary>
        public string FileId { get { return _FileId; } set { _FileId = value; } }

        #endregion

        #region 重载公共函数

        /// <summary>
        /// 清除所有数据。
        /// </summary>
        public override void Clear()
        {
            base.Clear();

            _AttachmentId = null;
            _CreateTime = DateTime.MinValue;
            _Creator = null;
            _FileName = null;
            _FileSize = 0;
            _RefID = null;
            _RefType = null;
            _FileId = null;
        }

        /// <summary>
        /// 用指定节点序列化整个数据对象。
        /// </summary>
        /// <param name="node">用于序列化的 XmlNode 节点。</param>
        public override void XMLEncode(System.Xml.XmlNode node)
        {
            base.XMLEncode(node);

            WriteXmlAttrValue(node, "AttachmentId", _AttachmentId);
            WriteXmlAttrValue(node, "CreateTime", _CreateTime);
            WriteXmlAttrValue(node, "Creator", _Creator);
            WriteXmlAttrValue(node, "FileName", _FileName);
            WriteXmlAttrValue(node, "FileSize", _FileSize);
            WriteXmlAttrValue(node, "RefID", _RefID);
            WriteXmlAttrValue(node, "RefType", _RefType);
            WriteXmlAttrValue(node, "FileId", _FileId);
        }

        /// <summary>
        /// 用指定节点反序列化整个数据对象。
        /// </summary>
        /// <param name="node">用于反序列化的 XmlNode 节点。</param>
        public override void XMLDecode(System.Xml.XmlNode node)
        {
            base.XMLDecode(node);

            ReadXmlAttrValue(node, "AttachmentId", ref _AttachmentId);
            ReadXmlAttrValue(node, "CreateTime", ref _CreateTime);
            ReadXmlAttrValue(node, "Creator", ref _Creator);
            ReadXmlAttrValue(node, "FileName", ref _FileName);
            ReadXmlAttrValue(node, "FileSize", ref _FileSize);
            ReadXmlAttrValue(node, "RefID", ref _RefID);
            ReadXmlAttrValue(node, "RefType", ref _RefType);
            ReadXmlAttrValue(node, "FileId", ref _FileId);
        }

        /// <summary>
        /// 复制数据对象
        /// </summary>
        /// <param name="sou">源对象,需从DataPacket继承</param>
        public override void AssignFrom(DataPacket sou)
        {
            base.AssignFrom(sou);

            Attachment s = sou as Attachment;
            if (s != null)
            {
                _AttachmentId = s._AttachmentId;
                _CreateTime = s._CreateTime;
                _Creator = s._Creator;
                _FileName = s._FileName;
                _FileSize = s._FileSize;
                _RefID = s._RefID;
                _RefType = s._RefType;
                _FileId = s._FileId;
            }
        }

        #endregion
    }
}
