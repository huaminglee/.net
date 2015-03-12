#region 版本说明
/*****************************************************************************
 * 
 * 项    目 : 
 * 作    者 : 罗坤 
 * 创建时间 : 2015/1/27 14:17:13 
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
    /// Message 系统消息的摘要说明。
    /// </summary>
    public class Message : DataPacket
    {
        #region 私有字段

        private int _Guid;      // 标识
        private string _Sender;      // 发送人
        private string _MessageContent;      // 消息内容
        private DateTime _CreateDate;      // 发送时间
        private int _State;      // 消息状态

        #endregion

        #region 构造函数

        /// <summary>
        /// 初始化新实例 
        /// </summary>
        public Message()
        {

        }

        #endregion

        #region 属性定义

        /// <summary>
        /// 标识 
        /// </summary>
        public int Guid { get { return _Guid; } set { _Guid = value; } }
        /// <summary>
        /// 发送人 
        /// </summary>
        public string Sender { get { return _Sender; } set { _Sender = value; } }
        /// <summary>
        /// 消息内容 
        /// </summary>
        public string MessageContent { get { return _MessageContent; } set { _MessageContent = value; } }
        /// <summary>
        /// 发送时间 
        /// </summary>
        public DateTime CreateDate { get { return _CreateDate; } set { _CreateDate = value; } }
        /// <summary>
        /// 消息状态 
        /// </summary>
        public int State { get { return _State; } set { _State = value; } }

        #endregion



        #region 重载公共函数

        /// <summary>
        /// 清除所有数据。
        /// </summary>
        public override void Clear()
        {
            base.Clear();

            _Guid = 0;
            _Sender = null;
            _MessageContent = null;
            _CreateDate = DateTime.MinValue;
            _State = 0;
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

            WriteXMLValue(node, "Guid", _Guid);
            WriteXMLValue(node, "Sender", _Sender);
            WriteXMLValue(node, "MessageContent", _MessageContent);
            WriteXMLValue(node, "CreateDate", _CreateDate);
            WriteXMLValue(node, "State", _State);
        }

        /// <summary>
        /// 用指定节点反序列化整个数据对象。
        /// </summary>
        /// <param name="node">用于反序列化的 XmlNode 节点。</param>
        public override void XMLDecode(System.Xml.XmlNode node)
        {
            base.XMLDecode(node);

            ReadXMLValue(node, "Guid", ref _Guid);
            ReadXMLValue(node, "Sender", ref _Sender);
            ReadXMLValue(node, "MessageContent", ref _MessageContent);
            ReadXMLValue(node, "CreateDate", ref _CreateDate);
            ReadXMLValue(node, "State", ref _State);
        }
#endif

        /// <summary>
        /// 复制数据对象
        /// </summary>
        /// <param name="sou">源对象,需从DataPacket继承</param>
        public override void AssignFrom(DataPacket sou)
        {
            base.AssignFrom(sou);

            Message s = sou as Message;
            if (s != null)
            {
                _Guid = s._Guid;
                _Sender = s._Sender;
                _MessageContent = s._MessageContent;
                _CreateDate = s._CreateDate;
                _State = s._State;
            }
        }

        #endregion
    }
}

