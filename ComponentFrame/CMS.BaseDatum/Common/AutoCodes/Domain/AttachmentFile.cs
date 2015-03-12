#region 版本说明
/*****************************************************************************
 * 
 * 项    目 : 
 * 作    者 : 褚海峰 
 * 创建时间 : 2010-7-22 15:21:02 
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
    /// AttachmentFile 附件文件的摘要说明。
    /// </summary>
    public class AttachmentFile : DataPacket
    {
        #region 私有字段

        private string _FileId;      // 文件ID
        private byte[] _FileContent;      // 文件内容
        private string _OCRContent;      // OCR内容
        private string _FileType;      // 文件类型
        private int _IsOCRed;      // 是否OCR
        private DateTime _CreateTime;      // 添加时间

        #endregion

        #region 属性定义

        /// <summary>
        /// 文件ID 
        /// </summary>
        public string FileId { get { return _FileId; } set { _FileId = value; } }
        /// <summary>
        /// 文件内容 
        /// </summary>
        public byte[] FileContent { get { return _FileContent; } set { _FileContent = value; } }
        /// <summary>
        /// OCR内容 
        /// </summary>
        public string OCRContent { get { return _OCRContent; } set { _OCRContent = value; } }
        /// <summary>
        /// 文件类型 
        /// </summary>
        public string FileType { get { return _FileType; } set { _FileType = value; } }
        /// <summary>
        /// 是否OCR 
        /// </summary>
        public int IsOCRed { get { return _IsOCRed; } set { _IsOCRed = value; } }
        /// <summary>
        /// 添加时间 
        /// </summary>
        public DateTime CreateTime { get { return _CreateTime; } set { _CreateTime = value; } }

        #endregion

        #region 重载公共函数

        /// <summary>
        /// 清除所有数据。
        /// </summary>
        public override void Clear()
        {
            base.Clear();

            _FileId = null;
            _FileContent = new byte[0];
            _OCRContent = null;
            _FileType = null;
            _IsOCRed = 0;
            _CreateTime = DateTime.MinValue;
        }

        /// <summary>
        /// 用指定节点序列化整个数据对象。
        /// </summary>
        /// <param name="node">用于序列化的 XmlNode 节点。</param>
        public override void XMLEncode(System.Xml.XmlNode node)
        {
            base.XMLEncode(node);

            WriteXmlAttrValue(node, "FileId", _FileId);
            WriteXMLValue(node, "FileContent", _FileContent);
            WriteXMLValue(node, "OCRContent", _OCRContent);
            WriteXMLValue(node, "FileType", _FileType);
            WriteXMLValue(node, "IsOCRed", _IsOCRed);
            WriteXMLValue(node, "CreateTime", _CreateTime);
        }

        /// <summary>
        /// 用指定节点反序列化整个数据对象。
        /// </summary>
        /// <param name="node">用于反序列化的 XmlNode 节点。</param>
        public override void XMLDecode(System.Xml.XmlNode node)
        {
            base.XMLDecode(node);

            ReadXmlAttrValue(node, "FileId", ref _FileId);
            ReadXMLValue(node, "FileContent", ref _FileContent);
            ReadXMLValue(node, "OCRContent", ref _OCRContent);
            ReadXMLValue(node, "FileType", ref _FileType);
            ReadXMLValue(node, "IsOCRed", ref _IsOCRed);
            ReadXMLValue(node, "CreateTime", ref _CreateTime);
        }

        /// <summary>
        /// 复制数据对象
        /// </summary>
        /// <param name="sou">源对象,需从DataPacket继承</param>
        public override void AssignFrom(DataPacket sou)
        {
            base.AssignFrom(sou);

            AttachmentFile s = sou as AttachmentFile;
            if (s != null)
            {
                _FileId = s._FileId;
                _FileContent = (byte[])s._FileContent.Clone();
                _OCRContent = s._OCRContent;
                _FileType = s._FileType;
                _IsOCRed = s._IsOCRed;
                _CreateTime = s._CreateTime;
            }
        }

        #endregion
    }
}
