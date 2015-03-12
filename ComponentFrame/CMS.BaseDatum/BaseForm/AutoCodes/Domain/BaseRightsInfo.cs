#region 版本说明
/*****************************************************************************
 * 
 * 项    目 : 
 * 作    者 : 李金坪 
 * 创建时间 : 2015/2/11 13:20:02 
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
    /// BaseRightsInfo 的摘要说明。
    /// </summary>
    public class BaseRightsInfo : DataPacket
    {
        #region 私有字段

        private string _Detail;      // 描述
        private string _AddAttrib;      // 附加属性
        private int _ActID;      // ActID
        private int _ParentID;      // 父节点id
        private int _Deep;      // Deep

        #endregion


        #region 属性定义

        /// <summary>
        /// 描述 
        /// </summary>
        public string Detail { get { return _Detail; } set { _Detail = value; } }
        /// <summary>
        /// 附加属性 
        /// </summary>
        public string AddAttrib { get { return _AddAttrib; } set { _AddAttrib = value; } }
        /// <summary>
        /// ActID 
        /// </summary>
        public int ActID { get { return _ActID; } set { _ActID = value; } }
        /// <summary>
        /// 父节点id 
        /// </summary>
        public int ParentID { get { return _ParentID; } set { _ParentID = value; } }
        /// <summary>
        /// Deep 
        /// </summary>
        public int Deep { get { return _Deep; } set { _Deep = value; } }

        #endregion



        #region 重载公共函数

        /// <summary>
        /// 清除所有数据。
        /// </summary>
        public override void Clear()
        {
            base.Clear();

            _Detail = null;
            _AddAttrib = null;
            _ActID = 0;
            _ParentID = 0;
            _Deep = 0;
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

            WriteXMLValue(node, "Detail", _Detail);
            WriteXMLValue(node, "AddAttrib", _AddAttrib);
            WriteXMLValue(node, "ActID", _ActID);
            WriteXMLValue(node, "ParentID", _ParentID);
            WriteXMLValue(node, "Deep", _Deep);
        }

        /// <summary>
        /// 用指定节点反序列化整个数据对象。
        /// </summary>
        /// <param name="node">用于反序列化的 XmlNode 节点。</param>
        public override void XMLDecode(System.Xml.XmlNode node)
        {
            base.XMLDecode(node);

            ReadXMLValue(node, "Detail", ref _Detail);
            ReadXMLValue(node, "AddAttrib", ref _AddAttrib);
            ReadXMLValue(node, "ActID", ref _ActID);
            ReadXMLValue(node, "ParentID", ref _ParentID);
            ReadXMLValue(node, "Deep", ref _Deep);
        }
#endif

        /// <summary>
        /// 复制数据对象
        /// </summary>
        /// <param name="sou">源对象,需从DataPacket继承</param>
        public override void AssignFrom(DataPacket sou)
        {
            base.AssignFrom(sou);

            BaseRightsInfo s = sou as BaseRightsInfo;
            if (s != null)
            {
                _Detail = s._Detail;
                _AddAttrib = s._AddAttrib;
                _ActID = s._ActID;
                _ParentID = s._ParentID;
                _Deep = s._Deep;
            }
        }

        #endregion
    }
}
