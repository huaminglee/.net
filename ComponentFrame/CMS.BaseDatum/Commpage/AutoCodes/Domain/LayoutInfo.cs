#region �汾˵��
/*****************************************************************************
 * 
 * ��    Ŀ : 
 * ��    �� : ���ƺ 
 * ����ʱ�� : 2014/11/27 14:11:12 
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
    /// LayoutInfo ������Ϣ��ժҪ˵����
    /// </summary>
    public class LayoutInfo : DataPacket
    {
        #region ˽���ֶ�

        private int _LID;      // id
        private string _LName;      // ��������
        private string _LModelList;      // ģ���б�
        private string _LayType;      // �������ͣ�������ϸģ��Ͳ���ģ�壩
        private string _TempType;      // ģ�����ͣ�����Ĭ�Ϻ��û�ר�У�
        private string _Owner;      // ������Ա��Ȩ��
        private string _BelongPage;      // ����ҳ��
        private int _Isusing;      // �Ƿ�����ʹ��
        private string _Remark;      // ��ע
        private string _ExtendFields1;      // ��չ�ֶ�1
        private string _ExtendFields2;      // ��չ�ֶ�2
        private string _ExtendFields3;      // ��չ�ֶ�3
        private DateTime _CreateTime;      // ��ʼʹ��ʱ��

        #endregion


        #region ���Զ���

        /// <summary>
        /// id 
        /// </summary>
        public int LID { get { return _LID; } set { _LID = value; } }
        /// <summary>
        /// �������� 
        /// </summary>
        public string LName { get { return _LName; } set { _LName = value; } }
        /// <summary>
        /// ģ���б� 
        /// </summary>
        public string LModelList { get { return _LModelList; } set { _LModelList = value; } }
        /// <summary>
        /// �������ͣ�������ϸģ��Ͳ���ģ�壩 
        /// </summary>
        public string LayType { get { return _LayType; } set { _LayType = value; } }
        /// <summary>
        /// ģ�����ͣ�����Ĭ�Ϻ��û�ר�У� 
        /// </summary>
        public string TempType { get { return _TempType; } set { _TempType = value; } }
        /// <summary>
        /// ������Ա��Ȩ�� 
        /// </summary>
        public string Owner { get { return _Owner; } set { _Owner = value; } }
        /// <summary>
        /// ����ҳ�� 
        /// </summary>
        public string BelongPage { get { return _BelongPage; } set { _BelongPage = value; } }
        /// <summary>
        /// �Ƿ�����ʹ�� 
        /// </summary>
        public int Isusing { get { return _Isusing; } set { _Isusing = value; } }
        /// <summary>
        /// ��ע 
        /// </summary>
        public string Remark { get { return _Remark; } set { _Remark = value; } }
        /// <summary>
        /// ��չ�ֶ�1 
        /// </summary>
        public string ExtendFields1 { get { return _ExtendFields1; } set { _ExtendFields1 = value; } }
        /// <summary>
        /// ��չ�ֶ�2 
        /// </summary>
        public string ExtendFields2 { get { return _ExtendFields2; } set { _ExtendFields2 = value; } }
        /// <summary>
        /// ��չ�ֶ�3 
        /// </summary>
        public string ExtendFields3 { get { return _ExtendFields3; } set { _ExtendFields3 = value; } }
        /// <summary>
        /// ��ʼʹ��ʱ�� 
        /// </summary>
        public DateTime CreateTime { get { return _CreateTime; } set { _CreateTime = value; } }

        #endregion



        #region ���ع�������

        /// <summary>
        /// ����������ݡ�
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
        /// ��ָ���ڵ����л��������ݶ���
        /// </summary>
        /// <param name="node">�������л��� XmlNode �ڵ㡣</param>
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
        /// ��ָ���ڵ㷴���л��������ݶ���
        /// </summary>
        /// <param name="node">���ڷ����л��� XmlNode �ڵ㡣</param>
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
        /// �������ݶ���
        /// </summary>
        /// <param name="sou">Դ����,���DataPacket�̳�</param>
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
