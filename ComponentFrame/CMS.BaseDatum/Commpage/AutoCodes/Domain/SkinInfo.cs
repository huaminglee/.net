#region �汾˵��
/*****************************************************************************
 * 
 * ��    Ŀ : 
 * ��    �� : ���ƺ 
 * ����ʱ�� : 2014/11/18 13:25:38 
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
    /// SkinInfo Ƥ�������ժҪ˵����
    /// </summary>
    public class SkinInfo : DataPacket
    {
        #region ˽���ֶ�

        private int _SId;      // Ƥ��id
        private string _Uid;      // �û�
        private string _Sname;      // ʹ��Ƥ������
        private string _Remark;      // ��ע
        private DateTime _CreateTime;      // ��ʼʹ��ʱ��
        private string _ExtendFields1;      // ��չ�ֶ�1
        private string _ExtendFields2;      // ��չ�ֶ�2
        private string _ExtendFields3;      // ��չ�ֶ�3

        #endregion


        #region ���Զ���

        /// <summary>
        /// Ƥ��id 
        /// Ƥ��id 
        /// </summary>
        public int SId { get { return _SId; } set { _SId = value; } }
        /// <summary>
        /// �û� 
        /// �û� 
        /// </summary>
        public string Uid { get { return _Uid; } set { _Uid = value; } }
        /// <summary>
        /// ʹ��Ƥ������ 
        /// ʹ��Ƥ������ 
        /// </summary>
        public string Sname { get { return _Sname; } set { _Sname = value; } }
        /// <summary>
        /// ��ע 
        /// ��ע 
        /// </summary>
        public string Remark { get { return _Remark; } set { _Remark = value; } }
        /// <summary>
        /// ��ʼʹ��ʱ�� 
        /// ��ʼʹ��ʱ�� 
        /// </summary>
        public DateTime CreateTime { get { return _CreateTime; } set { _CreateTime = value; } }
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

        #endregion



        #region ���ع�������

        /// <summary>
        /// ����������ݡ�
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
        /// ��ָ���ڵ����л��������ݶ���
        /// </summary>
        /// <param name="node">�������л��� XmlNode �ڵ㡣</param>
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
        /// ��ָ���ڵ㷴���л��������ݶ���
        /// </summary>
        /// <param name="node">���ڷ����л��� XmlNode �ڵ㡣</param>
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
        /// �������ݶ���
        /// </summary>
        /// <param name="sou">Դ����,���DataPacket�̳�</param>
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
