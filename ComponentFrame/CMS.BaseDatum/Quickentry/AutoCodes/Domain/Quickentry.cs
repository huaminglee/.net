#region �汾˵��
/*****************************************************************************
 * 
 * ��    Ŀ : 
 * ��    �� : ���ƺ 
 * ����ʱ�� : 2015/1/19 13:55:06 
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
    /// Quickentry ��ժҪ˵����
    /// </summary>
    public class Quickentry:DataPacket
    {
        #region ˽���ֶ�
        
        private int      _QId         ;      // id
        private string   _QName       ;      // ����
        private string   _QRemark     ;      // ˵��
        private string   _QPico       ;      // ͼ��
        private string   _QTarget     ;      // ָ��
        private int      _DefaultSort ;      // Ĭ������
        private int      _QType       ;      // ����

        #endregion


        #region ���Զ���

        /// <summary>
        /// id 
        /// </summary>
        public int      QId          { get { return _QId         ;} set { _QId          = value; } }
        /// <summary>
        /// ���� 
        /// </summary>
        public string   QName        { get { return _QName       ;} set { _QName        = value; } }
        /// <summary>
        /// ˵�� 
        /// </summary>
        public string   QRemark      { get { return _QRemark     ;} set { _QRemark      = value; } }
        /// <summary>
        /// ͼ�� 
        /// </summary>
        public string   QPico        { get { return _QPico       ;} set { _QPico        = value; } }
        /// <summary>
        /// ָ�� 
        /// </summary>
        public string   QTarget      { get { return _QTarget     ;} set { _QTarget      = value; } }
        /// <summary>
        /// Ĭ������ 
        /// </summary>
        public int      DefaultSort  { get { return _DefaultSort ;} set { _DefaultSort  = value; } }
        /// <summary>
        /// ���� 
        /// 1:�����ڣ�2��ͳ����� 
        /// </summary>
        public int      QType        { get { return _QType       ;} set { _QType        = value; } }

        #endregion
        
  

        #region ���ع�������

        /// <summary>
        /// ����������ݡ�
        /// </summary>
        public override void Clear()
        {
            base.Clear ();

            _QId          = 0;
            _QName        = null;
            _QRemark      = null;
            _QPico        = null;
            _QTarget      = null;
            _DefaultSort  = 0;
            _QType        = 0;
        }
        

#if SILVERLIGHT
#else
        /// <summary>
        /// ��ָ���ڵ����л��������ݶ���
        /// </summary>
        /// <param name="node">�������л��� XmlNode �ڵ㡣</param>
        public override void XMLEncode(System.Xml.XmlNode node)
        {
            base.XMLEncode (node);

            WriteXMLValue(node, "QId", _QId);
            WriteXMLValue(node, "QName", _QName);
            WriteXMLValue(node, "QRemark", _QRemark);
            WriteXMLValue(node, "QPico", _QPico);
            WriteXMLValue(node, "QTarget", _QTarget);
            WriteXMLValue(node, "DefaultSort", _DefaultSort);
            WriteXMLValue(node, "QType", _QType);
        }

        /// <summary>
        /// ��ָ���ڵ㷴���л��������ݶ���
        /// </summary>
        /// <param name="node">���ڷ����л��� XmlNode �ڵ㡣</param>
        public override void XMLDecode(System.Xml.XmlNode node)
        {
            base.XMLDecode (node);

            ReadXMLValue(node, "QId", ref _QId);
            ReadXMLValue(node, "QName", ref _QName);
            ReadXMLValue(node, "QRemark", ref _QRemark);
            ReadXMLValue(node, "QPico", ref _QPico);
            ReadXMLValue(node, "QTarget", ref _QTarget);
            ReadXMLValue(node, "DefaultSort", ref _DefaultSort);
            ReadXMLValue(node, "QType", ref _QType);
        }
#endif

        /// <summary>
        /// �������ݶ���
        /// </summary>
        /// <param name="sou">Դ����,���DataPacket�̳�</param>
        public override void AssignFrom(DataPacket sou)
        {
            base.AssignFrom (sou);

            Quickentry s = sou as Quickentry;
            if (s != null)
            {
                _QId          = s._QId         ;
                _QName        = s._QName       ;
                _QRemark      = s._QRemark     ;
                _QPico        = s._QPico       ;
                _QTarget      = s._QTarget     ;
                _DefaultSort  = s._DefaultSort ;
                _QType        = s._QType       ;
            }
        }

        #endregion
    }
}

