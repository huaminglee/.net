#region �汾˵��
/*****************************************************************************
 * 
 * ��    Ŀ : 
 * ��    �� : ���ƺ 
 * ����ʱ�� : 2015/1/20 9:30:11 
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
    /// QuickUseRecord ��ժҪ˵����
    /// </summary>
    public class QuickUseRecord : NorDataList
    {
        #region ˽���ֶ�

        private string _Uid;      // �û�id
        private int _Qid;      // ���id
        private int _UseTimes;      // ʹ�ô���
        private int _Qtype;      // �������

        #endregion

        #region ���캯��

        /// <summary>
        /// ��ʼ����ʵ�� 
        /// </summary>
        public QuickUseRecord()
        {
            UseTimes = 1;
        }

        /// <summary>
        /// ��ʼ����ʵ������ʵ��������ָ�����ϸ��Ƶ�Ԫ�ز��Ҿ����������Ƶ�Ԫ������ͬ�ĳ�ʼ������
        /// </summary>
        /// <param name="c"></param>
        public QuickUseRecord(ICollection c)
            : base(c)
        {
            UseTimes = 1;
        }

        #endregion

        #region ���Զ���

        /// <summary>
        /// �û�id 
        /// </summary>
        public string Uid { get { return _Uid; } set { _Uid = value; } }
        /// <summary>
        /// ���id 
        /// </summary>
        public int Qid { get { return _Qid; } set { _Qid = value; } }
        /// <summary>
        /// ʹ�ô��� 
        /// </summary>
        public int UseTimes { get { return _UseTimes; } set { _UseTimes = value; } }
        /// <summary>
        /// ������� 
        /// </summary>
        public int Qtype { get { return _Qtype; } set { _Qtype = value; } }

        #endregion



        #region ���ع�������

        /// <summary>
        /// ����������ݡ�
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
        /// ��ָ���ڵ����л��������ݶ���
        /// </summary>
        /// <param name="node">�������л��� XmlNode �ڵ㡣</param>
        public override void XMLEncode(System.Xml.XmlNode node)
        {
            base.XMLEncode(node);

            WriteXMLValue(node, "Uid", _Uid);
            WriteXMLValue(node, "Qid", _Qid);
            WriteXMLValue(node, "UseTimes", _UseTimes);
            WriteXMLValue(node, "Qtype", _Qtype);
        }

        /// <summary>
        /// ��ָ���ڵ㷴���л��������ݶ���
        /// </summary>
        /// <param name="node">���ڷ����л��� XmlNode �ڵ㡣</param>
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
        /// �������ݶ���
        /// </summary>
        /// <param name="sou">Դ����,���DataPacket�̳�</param>
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
