#region 版本说明
/*****************************************************************************
 * 
 * 项    目 : 
 * 作    者 : 李金坪 
 * 创建时间 : 2014/9/22 9:46:42 
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
    /// UseContactList 的摘要说明。
    /// </summary>
    public class UseContactList : NorDataList
    {
        #region 私有字段

        private string _Mowner;      // 所有人

        #endregion

        #region 构造函数

        /// <summary>
        /// 初始化新实例 
        /// </summary>
        public UseContactList()
        {
            ItemType = typeof(UsedContacts);
        }

        /// <summary>
        /// 初始化新实例，该实例包含从指定集合复制的元素并且具有与所复制的元素数相同的初始容量。
        /// </summary>
        /// <param name="c"></param>
        public UseContactList(ICollection c)
            : base(c)
        {
            ItemType = typeof(UsedContacts);
        }

        #endregion

        #region 属性定义

        /// <summary>
        /// 所有人 
        /// </summary>
        public string Mowner { get { return _Mowner; } set { _Mowner = value; } }

        #endregion



        #region 重载公共函数

        /// <summary>
        /// 清除所有数据。
        /// </summary>
        public override void Clear()
        {
            base.Clear();

            _Mowner = null;
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

            WriteXMLValue(node, "Mowner", _Mowner);
        }

        /// <summary>
        /// 用指定节点反序列化整个数据对象。
        /// </summary>
        /// <param name="node">用于反序列化的 XmlNode 节点。</param>
        public override void XMLDecode(System.Xml.XmlNode node)
        {
            base.XMLDecode(node);

            ReadXMLValue(node, "Mowner", ref _Mowner);
        }
#endif

        /// <summary>
        /// 复制数据对象
        /// </summary>
        /// <param name="sou">源对象,需从DataPacket继承</param>
        public override void AssignFrom(DataPacket sou)
        {
            base.AssignFrom(sou);

            UseContactList s = sou as UseContactList;
            if (s != null)
            {
                _Mowner = s._Mowner;
            }
        }

        #endregion
    }
}
