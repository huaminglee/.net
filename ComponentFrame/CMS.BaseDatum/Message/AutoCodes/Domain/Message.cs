#region �汾˵��
/*****************************************************************************
 * 
 * ��    Ŀ : 
 * ��    �� : ���� 
 * ����ʱ�� : 2015/1/27 14:17:13 
 *
 * Copyright (C) 2008 - ��ҵ�����˾
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
    /// Message ϵͳ��Ϣ��ժҪ˵����
    /// </summary>
    public class Message : DataPacket
    {
        #region ˽���ֶ�

        private int _Guid;      // ��ʶ
        private string _Sender;      // ������
        private string _MessageContent;      // ��Ϣ����
        private DateTime _CreateDate;      // ����ʱ��
        private int _State;      // ��Ϣ״̬

        #endregion

        #region ���캯��

        /// <summary>
        /// ��ʼ����ʵ�� 
        /// </summary>
        public Message()
        {

        }

        #endregion

        #region ���Զ���

        /// <summary>
        /// ��ʶ 
        /// </summary>
        public int Guid { get { return _Guid; } set { _Guid = value; } }
        /// <summary>
        /// ������ 
        /// </summary>
        public string Sender { get { return _Sender; } set { _Sender = value; } }
        /// <summary>
        /// ��Ϣ���� 
        /// </summary>
        public string MessageContent { get { return _MessageContent; } set { _MessageContent = value; } }
        /// <summary>
        /// ����ʱ�� 
        /// </summary>
        public DateTime CreateDate { get { return _CreateDate; } set { _CreateDate = value; } }
        /// <summary>
        /// ��Ϣ״̬ 
        /// </summary>
        public int State { get { return _State; } set { _State = value; } }

        #endregion



        #region ���ع�������

        /// <summary>
        /// ����������ݡ�
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
        /// ��ָ���ڵ����л��������ݶ���
        /// </summary>
        /// <param name="node">�������л��� XmlNode �ڵ㡣</param>
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
        /// ��ָ���ڵ㷴���л��������ݶ���
        /// </summary>
        /// <param name="node">���ڷ����л��� XmlNode �ڵ㡣</param>
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
        /// �������ݶ���
        /// </summary>
        /// <param name="sou">Դ����,���DataPacket�̳�</param>
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

