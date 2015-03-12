#region 版本说明
/*****************************************************************************
 * 
 * 项    目 : 
 * 作    者 : 李金坪 
 * 创建时间 : 2014/9/22 10:00:22 
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
    /// UsedContacts 的摘要说明。
    /// </summary>
    public class UsedContacts : DataPacket
    {
        #region 私有字段

        private string _COwner;      // 所有人
        private string _ContactUserID;      // 联系人ID
        private string _ContactUserXM;      // 联系人姓名
        private string _TaskName;      // 任务名
        private string _StepName;      // 步骤名
        private int _UseTimes;      // 次数
        private int _CType;      // 类型

        #endregion

        #region 构造函数

        /// <summary>
        /// 初始化新实例 
        /// </summary>
        public UsedContacts()
        {
           
        }

        #endregion

        #region 属性定义

        /// <summary>
        /// 所有人 
        /// </summary>
        public string COwner { get { return _COwner; } set { _COwner = value; } }
        /// <summary>
        /// 联系人ID 
        /// </summary>
        public string ContactUserID { get { return _ContactUserID; } set { _ContactUserID = value; } }
        /// <summary>
        /// 联系人姓名 
        /// </summary>
        public string ContactUserXM { get { return _ContactUserXM; } set { _ContactUserXM = value; } }
        /// <summary>
        /// 任务名 
        /// </summary>
        public string TaskName { get { return _TaskName; } set { _TaskName = value; } }
        /// <summary>
        /// 步骤名 
        /// </summary>
        public string StepName { get { return _StepName; } set { _StepName = value; } }
        /// <summary>
        /// 次数 
        /// </summary>
        public int UseTimes { get { return _UseTimes; } set { _UseTimes = value; } }
        /// <summary>
        /// 类型 
        /// </summary>
        public int CType { get { return _CType; } set { _CType = value; } }

        #endregion



        #region 重载公共函数

        /// <summary>
        /// 清除所有数据。
        /// </summary>
        public override void Clear()
        {
            base.Clear();

            _COwner = null;
            _ContactUserID = null;
            _ContactUserXM = null;
            _TaskName = null;
            _StepName = null;
            _UseTimes = 0;
            _CType = 0;
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

            WriteXMLValue(node, "COwner", _COwner);
            WriteXMLValue(node, "ContactUserID", _ContactUserID);
            WriteXMLValue(node, "ContactUserXM", _ContactUserXM);
            WriteXMLValue(node, "TaskName", _TaskName);
            WriteXMLValue(node, "StepName", _StepName);
            WriteXMLValue(node, "UseTimes", _UseTimes);
            WriteXMLValue(node, "CType", _CType);
        }

        /// <summary>
        /// 用指定节点反序列化整个数据对象。
        /// </summary>
        /// <param name="node">用于反序列化的 XmlNode 节点。</param>
        public override void XMLDecode(System.Xml.XmlNode node)
        {
            base.XMLDecode(node);

            ReadXMLValue(node, "COwner", ref _COwner);
            ReadXMLValue(node, "ContactUserID", ref _ContactUserID);
            ReadXMLValue(node, "ContactUserXM", ref _ContactUserXM);
            ReadXMLValue(node, "TaskName", ref _TaskName);
            ReadXMLValue(node, "StepName", ref _StepName);
            ReadXMLValue(node, "UseTimes", ref _UseTimes);
            ReadXMLValue(node, "CType", ref _CType);
        }
#endif

        /// <summary>
        /// 复制数据对象
        /// </summary>
        /// <param name="sou">源对象,需从DataPacket继承</param>
        public override void AssignFrom(DataPacket sou)
        {
            base.AssignFrom(sou);

            UsedContacts s = sou as UsedContacts;
            if (s != null)
            {
                _COwner = s._COwner;
                _ContactUserID = s._ContactUserID;
                _ContactUserXM = s._ContactUserXM;
                _TaskName = s._TaskName;
                _StepName = s._StepName;
                _UseTimes = s._UseTimes;
                _CType = s._CType;
            }
        }

        #endregion
    }
}
