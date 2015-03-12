#region 版本说明
/*****************************************************************************
 * 
 * 项    目 : 
 * 作    者 : 李金坪 
 * 创建时间 : 2014/11/27 14:11:12 
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
    /// LayoutInfo 布局信息的摘要说明。
    /// </summary>
    public class LayoutInfo : DataPacket
    {
        #region 私有字段

        private int _LID;      // id
        private string _LName;      // 布局名称
        private string _LModelList;      // 模块列表
        private string _LayType;      // 布局类型（区分详细模板和布局模板）
        private string _TempType;      // 模板类型（区分默认和用户专有）
        private string _Owner;      // 所属人员或权限
        private string _BelongPage;      // 所属页面
        private int _Isusing;      // 是否正在使用
        private string _Remark;      // 备注
        private string _ExtendFields1;      // 扩展字段1
        private string _ExtendFields2;      // 扩展字段2
        private string _ExtendFields3;      // 扩展字段3
        private DateTime _CreateTime;      // 开始使用时间

        #endregion


        #region 属性定义

        /// <summary>
        /// id 
        /// </summary>
        public int LID { get { return _LID; } set { _LID = value; } }
        /// <summary>
        /// 布局名称 
        /// </summary>
        public string LName { get { return _LName; } set { _LName = value; } }
        /// <summary>
        /// 模块列表 
        /// </summary>
        public string LModelList { get { return _LModelList; } set { _LModelList = value; } }
        /// <summary>
        /// 布局类型（区分详细模板和布局模板） 
        /// </summary>
        public string LayType { get { return _LayType; } set { _LayType = value; } }
        /// <summary>
        /// 模板类型（区分默认和用户专有） 
        /// </summary>
        public string TempType { get { return _TempType; } set { _TempType = value; } }
        /// <summary>
        /// 所属人员或权限 
        /// </summary>
        public string Owner { get { return _Owner; } set { _Owner = value; } }
        /// <summary>
        /// 所属页面 
        /// </summary>
        public string BelongPage { get { return _BelongPage; } set { _BelongPage = value; } }
        /// <summary>
        /// 是否正在使用 
        /// </summary>
        public int Isusing { get { return _Isusing; } set { _Isusing = value; } }
        /// <summary>
        /// 备注 
        /// </summary>
        public string Remark { get { return _Remark; } set { _Remark = value; } }
        /// <summary>
        /// 扩展字段1 
        /// </summary>
        public string ExtendFields1 { get { return _ExtendFields1; } set { _ExtendFields1 = value; } }
        /// <summary>
        /// 扩展字段2 
        /// </summary>
        public string ExtendFields2 { get { return _ExtendFields2; } set { _ExtendFields2 = value; } }
        /// <summary>
        /// 扩展字段3 
        /// </summary>
        public string ExtendFields3 { get { return _ExtendFields3; } set { _ExtendFields3 = value; } }
        /// <summary>
        /// 开始使用时间 
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

            _LID = 0;
            _LName = null;
            _LModelList = null;
            _LayType = null;
            _TempType = null;
            _Owner = null;
            _BelongPage = null;
            _Isusing = 1;
            _Remark = null;
            _ExtendFields1 = null;
            _ExtendFields2 = null;
            _ExtendFields3 = null;
            _CreateTime = DateTime.MinValue;
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

            WriteXMLValue(node, "LID", _LID);
            WriteXMLValue(node, "LName", _LName);
            WriteXMLValue(node, "LModelList", _LModelList);
            WriteXMLValue(node, "LayType", _LayType);
            WriteXMLValue(node, "TempType", _TempType);
            WriteXMLValue(node, "Owner", _Owner);
            WriteXMLValue(node, "BelongPage", _BelongPage);
            WriteXMLValue(node, "Isusing", _Isusing);
            WriteXMLValue(node, "Remark", _Remark);
            WriteXMLValue(node, "ExtendFields1", _ExtendFields1);
            WriteXMLValue(node, "ExtendFields2", _ExtendFields2);
            WriteXMLValue(node, "ExtendFields3", _ExtendFields3);
            WriteXMLValue(node, "CreateTime", _CreateTime);
        }

        /// <summary>
        /// 用指定节点反序列化整个数据对象。
        /// </summary>
        /// <param name="node">用于反序列化的 XmlNode 节点。</param>
        public override void XMLDecode(System.Xml.XmlNode node)
        {
            base.XMLDecode(node);

            ReadXMLValue(node, "LID", ref _LID);
            ReadXMLValue(node, "LName", ref _LName);
            ReadXMLValue(node, "LModelList", ref _LModelList);
            ReadXMLValue(node, "LayType", ref _LayType);
            ReadXMLValue(node, "TempType", ref _TempType);
            ReadXMLValue(node, "Owner", ref _Owner);
            ReadXMLValue(node, "BelongPage", ref _BelongPage);
            ReadXMLValue(node, "Isusing", ref _Isusing);
            ReadXMLValue(node, "Remark", ref _Remark);
            ReadXMLValue(node, "ExtendFields1", ref _ExtendFields1);
            ReadXMLValue(node, "ExtendFields2", ref _ExtendFields2);
            ReadXMLValue(node, "ExtendFields3", ref _ExtendFields3);
            ReadXMLValue(node, "CreateTime", ref _CreateTime);
        }
#endif

        /// <summary>
        /// 复制数据对象
        /// </summary>
        /// <param name="sou">源对象,需从DataPacket继承</param>
        public override void AssignFrom(DataPacket sou)
        {
            base.AssignFrom(sou);

            LayoutInfo s = sou as LayoutInfo;
            if (s != null)
            {
                _LID = s._LID;
                _LName = s._LName;
                _LModelList = s._LModelList;
                _LayType = s._LayType;
                _TempType = s._TempType;
                _Owner = s._Owner;
                _BelongPage = s._BelongPage;
                _Isusing = s._Isusing;
                _Remark = s._Remark;
                _ExtendFields1 = s._ExtendFields1;
                _ExtendFields2 = s._ExtendFields2;
                _ExtendFields3 = s._ExtendFields3;
                _CreateTime = s._CreateTime;
            }
        }

        #endregion
    }
}
