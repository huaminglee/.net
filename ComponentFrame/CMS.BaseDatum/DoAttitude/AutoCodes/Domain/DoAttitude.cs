#region 版本说明
/*****************************************************************************
 * 
 * 项    目 : 
 * 作    者 : 李金坪 
 * 创建时间 : 2014/8/18 15:01:27 
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
    /// DoAttitude 的摘要说明。
    /// </summary>
    public class DoAttitude:DataPacket
    {
        #region 私有字段
        
        private string     _AttitudeId     ;      // 意见ID
        private string     _FormID         ;      // 表单ID
        private string     _StateName      ;      // 步骤
        private string     _Creator        ;      // 人员
        private string     _Department     ;      // 部门
        private DateTime   _CreateTime     ;      // 时间
        private string     _ArchiveContent ;      // 内容
        private string     _TaskID         ;      // 任务ID
        private string     _WorkID         ;      // 工作ID

        #endregion


        #region 属性定义

        /// <summary>
        /// 意见ID 
        /// </summary>
        public string     AttitudeId      { get { return _AttitudeId     ;} set { _AttitudeId      = value; } }
        /// <summary>
        /// 表单ID 
        /// </summary>
        public string     FormID          { get { return _FormID         ;} set { _FormID          = value; } }
        /// <summary>
        /// 步骤 
        /// </summary>
        public string     StateName       { get { return _StateName      ;} set { _StateName       = value; } }
        /// <summary>
        /// 人员 
        /// </summary>
        public string     Creator         { get { return _Creator        ;} set { _Creator         = value; } }
        /// <summary>
        /// 部门 
        /// </summary>
        public string     Department      { get { return _Department     ;} set { _Department      = value; } }
        /// <summary>
        /// 时间 
        /// </summary>
        public DateTime   CreateTime      { get { return _CreateTime     ;} set { _CreateTime      = value; } }
        /// <summary>
        /// 内容 
        /// </summary>
        public string     ArchiveContent  { get { return _ArchiveContent ;} set { _ArchiveContent  = value; } }
        /// <summary>
        /// 任务ID 
        /// </summary>
        public string     TaskID          { get { return _TaskID         ;} set { _TaskID          = value; } }
        /// <summary>
        /// 工作ID 
        /// </summary>
        public string     WorkID          { get { return _WorkID         ;} set { _WorkID          = value; } }

        #endregion
        
  

        #region 重载公共函数

        /// <summary>
        /// 清除所有数据。
        /// </summary>
        public override void Clear()
        {
            base.Clear ();

            _AttitudeId      = null;
            _FormID          = null;
            _StateName       = null;
            _Creator         = null;
            _Department      = null;
            _CreateTime      = DateTime.MinValue;
            _ArchiveContent  = null;
            _TaskID          = null;
            _WorkID          = null;
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

            WriteXMLValue(node, "AttitudeId", _AttitudeId);
            WriteXMLValue(node, "FormID", _FormID);
            WriteXMLValue(node, "StateName", _StateName);
            WriteXMLValue(node, "Creator", _Creator);
            WriteXMLValue(node, "Department", _Department);
            WriteXMLValue(node, "CreateTime", _CreateTime);
            WriteXMLValue(node, "ArchiveContent", _ArchiveContent);
            WriteXMLValue(node, "TaskID", _TaskID);
            WriteXMLValue(node, "WorkID", _WorkID);
        }

        /// <summary>
        /// 用指定节点反序列化整个数据对象。
        /// </summary>
        /// <param name="node">用于反序列化的 XmlNode 节点。</param>
        public override void XMLDecode(System.Xml.XmlNode node)
        {
            base.XMLDecode (node);

            ReadXMLValue(node, "AttitudeId", ref _AttitudeId);
            ReadXMLValue(node, "FormID", ref _FormID);
            ReadXMLValue(node, "StateName", ref _StateName);
            ReadXMLValue(node, "Creator", ref _Creator);
            ReadXMLValue(node, "Department", ref _Department);
            ReadXMLValue(node, "CreateTime", ref _CreateTime);
            ReadXMLValue(node, "ArchiveContent", ref _ArchiveContent);
            ReadXMLValue(node, "TaskID", ref _TaskID);
            ReadXMLValue(node, "WorkID", ref _WorkID);
        }
#endif

        /// <summary>
        /// 复制数据对象
        /// </summary>
        /// <param name="sou">源对象,需从DataPacket继承</param>
        public override void AssignFrom(DataPacket sou)
        {
            base.AssignFrom (sou);

            DoAttitude s = sou as DoAttitude;
            if (s != null)
            {
                _AttitudeId      = s._AttitudeId     ;
                _FormID          = s._FormID         ;
                _StateName       = s._StateName      ;
                _Creator         = s._Creator        ;
                _Department      = s._Department     ;
                _CreateTime      = s._CreateTime     ;
                _ArchiveContent  = s._ArchiveContent ;
                _TaskID          = s._TaskID         ;
                _WorkID          = s._WorkID         ;
            }
        }

        #endregion
    }
}
