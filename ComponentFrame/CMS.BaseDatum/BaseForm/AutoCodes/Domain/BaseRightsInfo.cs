#region �汾˵��
/*****************************************************************************
 * 
 * ��    Ŀ : 
 * ��    �� : ���ƺ 
 * ����ʱ�� : 2015/2/11 13:20:02 
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
    /// BaseRightsInfo ��ժҪ˵����
    /// </summary>
    public class BaseRightsInfo : DataPacket
    {
        #region ˽���ֶ�

        private string _Detail;      // ����
        private string _AddAttrib;      // ��������
        private int _ActID;      // ActID
        private int _ParentID;      // ���ڵ�id
        private int _Deep;      // Deep

        #endregion


        #region ���Զ���

        /// <summary>
        /// ���� 
        /// </summary>
        public string Detail { get { return _Detail; } set { _Detail = value; } }
        /// <summary>
        /// �������� 
        /// </summary>
        public string AddAttrib { get { return _AddAttrib; } set { _AddAttrib = value; } }
        /// <summary>
        /// ActID 
        /// </summary>
        public int ActID { get { return _ActID; } set { _ActID = value; } }
        /// <summary>
        /// ���ڵ�id 
        /// </summary>
        public int ParentID { get { return _ParentID; } set { _ParentID = value; } }
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

            _Detail = null;
            _AddAttrib = null;
            _ActID = 0;
            _ParentID = 0;
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

            WriteXMLValue(node, "Detail", _Detail);
            WriteXMLValue(node, "AddAttrib", _AddAttrib);
            WriteXMLValue(node, "ActID", _ActID);
            WriteXMLValue(node, "ParentID", _ParentID);
            WriteXMLValue(node, "Deep", _Deep);
        }

        /// <summary>
        /// ��ָ���ڵ㷴���л��������ݶ���
        /// </summary>
        /// <param name="node">���ڷ����л��� XmlNode �ڵ㡣</param>
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
        /// �������ݶ���
        /// </summary>
        /// <param name="sou">Դ����,���DataPacket�̳�</param>
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
