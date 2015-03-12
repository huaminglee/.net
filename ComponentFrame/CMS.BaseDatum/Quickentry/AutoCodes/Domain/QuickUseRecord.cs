#region 版本说明
/*****************************************************************************
 * 
 * 项    目 : 
 * 作    者 : 李金坪 
 * 创建时间 : 2015/1/20 9:30:11 
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
    /// QuickUseRecord 的摘要说明。
    /// </summary>
    public class QuickUseRecord : NorDataList
    {
        #region 私有字段

        private string _Uid;      // 用户id
        private int _Qid;      // 入口id
        private int _UseTimes;      // 使用次数
        private int _Qtype;      // 入口类型

        #endregion

        #region 构造函数

        /// <summary>
        /// 初始化新实例 
        /// </summary>
        public QuickUseRecord()
        {
            UseTimes = 1;
        }

        /// <summary>
        /// 初始化新实例，该实例包含从指定集合复制的元素并且具有与所复制的元素数相同的初始容量。
        /// </summary>
        /// <param name="c"></param>
        public QuickUseRecord(ICollection c)
            : base(c)
        {
            UseTimes = 1;
        }

        #endregion

        #region 属性定义

        /// <summary>
        /// 用户id 
        /// </summary>
        public string Uid { get { return _Uid; } set { _Uid = value; } }
        /// <summary>
        /// 入口id 
        /// </summary>
        public int Qid { get { return _Qid; } set { _Qid = value; } }
        /// <summary>
        /// 使用次数 
        /// </summary>
        public int UseTimes { get { return _UseTimes; } set { _UseTimes = value; } }
        /// <summary>
        /// 入口类型 
        /// </summary>
        public int Qtype { get { return _Qtype; } set { _Qtype = value; } }

        #endregion



        #region 重载公共函数

        /// <summary>
        /// 清除所有数据。
        /// </summary>
        public override void Clear()
        {
            base.Clear();

            _Uid = null;
            _Qid = 0;
            _UseTimes = 0;
            _Qtype = 0;
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

            WriteXMLValue(node, "Uid", _Uid);
            WriteXMLValue(node, "Qid", _Qid);
            WriteXMLValue(node, "UseTimes", _UseTimes);
            WriteXMLValue(node, "Qtype", _Qtype);
        }

        /// <summary>
        /// 用指定节点反序列化整个数据对象。
        /// </summary>
        /// <param name="node">用于反序列化的 XmlNode 节点。</param>
        public override void XMLDecode(System.Xml.XmlNode node)
        {
            base.XMLDecode(node);

            ReadXMLValue(node, "Uid", ref _Uid);
            ReadXMLValue(node, "Qid", ref _Qid);
            ReadXMLValue(node, "UseTimes", ref _UseTimes);
            ReadXMLValue(node, "Qtype", ref _Qtype);
        }
#endif

        /// <summary>
        /// 复制数据对象
        /// </summary>
        /// <param name="sou">源对象,需从DataPacket继承</param>
        public override void AssignFrom(DataPacket sou)
        {
            base.AssignFrom(sou);

            QuickUseRecord s = sou as QuickUseRecord;
            if (s != null)
            {
                _Uid = s._Uid;
                _Qid = s._Qid;
                _UseTimes = s._UseTimes;
                _Qtype = s._Qtype;
            }
        }

        #endregion
    }
}
