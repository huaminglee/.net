#region �汾˵��
/*****************************************************************************
 * 
 * ��    Ŀ : 
 * ��    �� : ���ƺ 
 * ����ʱ�� : 2015/2/11 17:57:30 
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
    /// BaseDeptInfo ��ժҪ˵����
    /// </summary>
    public class BaseDeptInfo : DataPacket
    {
        #region ˽���ֶ�
        private int _SID;              // ����id
        private string _LoginID;       // ���ű�ʶ
        private int _ParentID;      // ���ڵ�id        
        private string _FullName;      // ȫ��
        private string _Detail;        // ����
        private int _Deep;             // Deep

        #endregion


        #region ���Զ���

        /// <summary>
        /// ����id 
        /// </summary>
        public int SID { get { return _SID; } set { _SID = value; } }
        /// <summary>
        /// ���ű�ʶ 
        /// </summary>
        public string LoginID { get { return _LoginID; } set { _LoginID = value; } }
        /// <summary>
        /// ���ڵ�id 
        /// </summary>
        public int ParentID { get { return _ParentID; } set { _ParentID = value; } }
        /// <summary>
        /// ȫ�� 
        /// </summary>
        public string FullName { get { return _FullName; } set { _FullName = value; } }
        /// <summary>
        /// ���� 
        /// </summary>
        public string Detail { get { return _Detail; } set { _Detail = value; } }
        /// <summary>
        /// Deep 
        /// </summary>
        public int Deep { get { return _Deep; } set { _Deep = value; } }

        #endregion



        #region ���ع�������

        /// <summary>
        /// ����������ݡ�
        /// </summary>
        public override void Clear()
        {
            base.Clear();
            _SID = 0;
            _LoginID = null;
            _ParentID = 0;
            _FullName = null;
            _Detail = null;
            _Deep = 0;
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
            WriteXMLValue(node, "SID", _SID);
            WriteXMLValue(node, "LoginID", _LoginID);
            WriteXMLValue(node, "ParentID", _ParentID);
            WriteXMLValue(node, "FullName", _FullName);
            WriteXMLValue(node, "Detail", _Detail);
            WriteXMLValue(node, "Deep", _Deep);
        }

        /// <summary>
        /// ��ָ���ڵ㷴���л��������ݶ���
        /// </summary>
        /// <param name="node">���ڷ����л��� XmlNode �ڵ㡣</param>
        public override void XMLDecode(System.Xml.XmlNode node)
        {
            base.XMLDecode(node);
            ReadXMLValue(node, "SID", ref _SID);
            ReadXMLValue(node, "LoginID", ref _LoginID);
            ReadXMLValue(node, "ParentID", ref _ParentID);
            ReadXMLValue(node, "FullName", ref _FullName);
            ReadXMLValue(node, "Detail", ref _Detail);
            ReadXMLValue(node, "Deep", ref _Deep);
        }
#endif

        /// <summary>
        /// �������ݶ���
        /// </summary>
        /// <param name="sou">Դ����,���DataPacket�̳�</param>
        public override void AssignFrom(DataPacket sou)
        {
            base.AssignFrom(sou);

            BaseDeptInfo s = sou as BaseDeptInfo;
            if (s != null)
            {
                _SID = s._SID;
                _LoginID = s._LoginID;
                _ParentID = s._ParentID;
                _FullName = s._FullName;
                _Detail = s._Detail;
                _Deep = s._Deep;
            }
        }

        #endregion
    }
}
