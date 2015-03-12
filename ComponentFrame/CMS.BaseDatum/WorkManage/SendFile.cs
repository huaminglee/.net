#region 版本说明
/*****************************************************************************
 * 
 * 项    目 : 
 * 作    者 : 张宏丹 
 * 创建时间 : 2014/8/25 20:41:05 
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
    /// SendFile 发文处理的摘要说明。
    /// </summary>
    public class SendFile:DataPacket 
    {
        #region 私有字段
        
        private string  _FileDept  ;      // 拟文单位
        private string  _Draft     ;      // 拟稿
        private string  _IsOnLine  ;      // 是否上网发布
        private string  _Register  ;      // 是否规范性文件备案
        private string  _Print     ;      // 打印
        private string  _Check     ;      // 核对
        private string  _QingYang  ;      // 清样复核
        private string  _FileCount ;      // 份数
        private string  _MainSend  ;      // 主送
        private string  _CCSend    ;      // 抄送

        #endregion


        #region 属性定义

        /// <summary>
        /// 拟文单位 
        /// </summary>
        public string  FileDept   { get { return _FileDept  ;} set { _FileDept   = value; } }
        /// <summary>
        /// 拟稿 
        /// </summary>
        public string  Draft      { get { return _Draft     ;} set { _Draft      = value; } }
        /// <summary>
        /// 是否上网发布 
        /// </summary>
        public string  IsOnLine   { get { return _IsOnLine  ;} set { _IsOnLine   = value; } }
        /// <summary>
        /// 是否规范性文件备案 
        /// </summary>
        public string  Register   { get { return _Register  ;} set { _Register   = value; } }
        /// <summary>
        /// 打印 
        /// </summary>
        public string  Print      { get { return _Print     ;} set { _Print      = value; } }
        /// <summary>
        /// 核对 
        /// </summary>
        public string  Check      { get { return _Check     ;} set { _Check      = value; } }
        /// <summary>
        /// 清样复核 
        /// </summary>
        public string  QingYang   { get { return _QingYang  ;} set { _QingYang   = value; } }
        /// <summary>
        /// 份数 
        /// </summary>
        public string  FileCount  { get { return _FileCount ;} set { _FileCount  = value; } }
        /// <summary>
        /// 主送 
        /// </summary>
        public string  MainSend   { get { return _MainSend  ;} set { _MainSend   = value; } }
        /// <summary>
        /// 抄送 
        /// </summary>
        public string  CCSend     { get { return _CCSend    ;} set { _CCSend     = value; } }

        #endregion
        
  

        #region 重载公共函数

        /// <summary>
        /// 清除所有数据。
        /// </summary>
        public override void Clear()
        {
            base.Clear ();

            _FileDept   = null;
            _Draft      = null;
            _IsOnLine   = null;
            _Register   = null;
            _Print      = null;
            _Check      = null;
            _QingYang   = null;
            _FileCount  = null;
            _MainSend   = null;
            _CCSend     = null;
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

            WriteXMLValue(node, "FileDept", _FileDept);
            WriteXMLValue(node, "Draft", _Draft);
            WriteXMLValue(node, "IsOnLine", _IsOnLine);
            WriteXMLValue(node, "Register", _Register);
            WriteXMLValue(node, "Print", _Print);
            WriteXMLValue(node, "Check", _Check);
            WriteXMLValue(node, "QingYang", _QingYang);
            WriteXMLValue(node, "FileCount", _FileCount);
            WriteXMLValue(node, "MainSend", _MainSend);
            WriteXMLValue(node, "CCSend", _CCSend);
        }

        /// <summary>
        /// 用指定节点反序列化整个数据对象。
        /// </summary>
        /// <param name="node">用于反序列化的 XmlNode 节点。</param>
        public override void XMLDecode(System.Xml.XmlNode node)
        {
            base.XMLDecode (node);

            ReadXMLValue(node, "FileDept", ref _FileDept);
            ReadXMLValue(node, "Draft", ref _Draft);
            ReadXMLValue(node, "IsOnLine", ref _IsOnLine);
            ReadXMLValue(node, "Register", ref _Register);
            ReadXMLValue(node, "Print", ref _Print);
            ReadXMLValue(node, "Check", ref _Check);
            ReadXMLValue(node, "QingYang", ref _QingYang);
            ReadXMLValue(node, "FileCount", ref _FileCount);
            ReadXMLValue(node, "MainSend", ref _MainSend);
            ReadXMLValue(node, "CCSend", ref _CCSend);
        }
#endif

        /// <summary>
        /// 复制数据对象
        /// </summary>
        /// <param name="sou">源对象,需从DataPacket继承</param>
        public override void AssignFrom(DataPacket sou)
        {
            base.AssignFrom (sou);

            SendFile s = sou as SendFile;
            if (s != null)
            {
                _FileDept   = s._FileDept  ;
                _Draft      = s._Draft     ;
                _IsOnLine   = s._IsOnLine  ;
                _Register   = s._Register  ;
                _Print      = s._Print     ;
                _Check      = s._Check     ;
                _QingYang   = s._QingYang  ;
                _FileCount  = s._FileCount ;
                _MainSend   = s._MainSend  ;
                _CCSend     = s._CCSend    ;
            }
        }

        #endregion
    }
}

