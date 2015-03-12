#region 版本说明
/*****************************************************************************
 * 
 * 项    目 : 
 * 作    者 : 李金坪 
 * 创建时间 : 2014/11/18 13:25:38 
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
    /// SkinInfo 皮肤对象的摘要说明。
    /// </summary>
    public class SkinInfo : DataPacket
    {
        #region 私有字段

        private int _SId;      // 皮肤id
        private string _Uid;      // 用户
        private string _Sname;      // 使用皮肤名称
        private string _Remark;      // 备注
        private DateTime _CreateTime;      // 开始使用时间
        private string _ExtendFields1;      // 扩展字段1
        private string _ExtendFields2;      // 扩展字段2
        private string _ExtendFields3;      // 扩展字段3

        #endregion


        #region 属性定义

        /// <summary>
        /// 皮肤id 
        /// 皮肤id 
        /// </summary>
        public int SId { get { return _SId; } set { _SId = value; } }
        /// <summary>
        /// 用户 
        /// 用户 
        /// </summary>
        public string Uid { get { return _Uid; } set { _Uid = value; } }
        /// <summary>
        /// 使用皮肤名称 
        /// 使用皮肤名称 
        /// </summary>
        public string Sname { get { return _Sname; } set { _Sname = value; } }
        /// <summary>
        /// 备注 
        /// 备注 
        /// </summary>
        public string Remark { get { return _Remark; } set { _Remark = value; } }
        /// <summary>
        /// 开始使用时间 
        /// 开始使用时间 
        /// </summary>
        public DateTime CreateTime { get { return _CreateTime; } set { _CreateTime = value; } }
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

        #endregion



        #region 重载公共函数

        /// <summary>
        /// 清除所有数据。
        /// </summary>
        public override void Clear()
        {
            base.Clear();

            _SId = 0;
            _Uid = null;
            _Sname = null;
            _Remark = null;
            _CreateTime = DateTime.MinValue;
            _ExtendFields1 = null;
            _ExtendFields2 = null;
            _ExtendFields3 = null;
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

            WriteXMLValue(node, "SId", _SId);
            WriteXMLValue(node, "Uid", _Uid);
            WriteXMLValue(node, "Sname", _Sname);
            WriteXMLValue(node, "Remark", _Remark);
            WriteXMLValue(node, "CreateTime", _CreateTime);
            WriteXMLValue(node, "ExtendFields1", _ExtendFields1);
            WriteXMLValue(node, "ExtendFields2", _ExtendFields2);
            WriteXMLValue(node, "ExtendFields3", _ExtendFields3);
        }

        /// <summary>
        /// 用指定节点反序列化整个数据对象。
        /// </summary>
        /// <param name="node">用于反序列化的 XmlNode 节点。</param>
        public override void XMLDecode(System.Xml.XmlNode node)
        {
            base.XMLDecode(node);

            ReadXMLValue(node, "SId", ref _SId);
            ReadXMLValue(node, "Uid", ref _Uid);
            ReadXMLValue(node, "Sname", ref _Sname);
            ReadXMLValue(node, "Remark", ref _Remark);
            ReadXMLValue(node, "CreateTime", ref _CreateTime);
            ReadXMLValue(node, "ExtendFields1", ref _ExtendFields1);
            ReadXMLValue(node, "ExtendFields2", ref _ExtendFields2);
            ReadXMLValue(node, "ExtendFields3", ref _ExtendFields3);
        }
#endif

        /// <summary>
        /// 复制数据对象
        /// </summary>
        /// <param name="sou">源对象,需从DataPacket继承</param>
        public override void AssignFrom(DataPacket sou)
        {
            base.AssignFrom(sou);

            SkinInfo s = sou as SkinInfo;
            if (s != null)
            {
                _SId = s._SId;
                _Uid = s._Uid;
                _Sname = s._Sname;
                _Remark = s._Remark;
                _CreateTime = s._CreateTime;
                _ExtendFields1 = s._ExtendFields1;
                _ExtendFields2 = s._ExtendFields2;
                _ExtendFields3 = s._ExtendFields3;
            }
        }

        #endregion
    }
}
