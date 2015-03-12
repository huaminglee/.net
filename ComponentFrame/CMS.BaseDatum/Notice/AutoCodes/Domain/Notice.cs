#region �汾˵��
/*****************************************************************************
 * 
 * ��    Ŀ : 
 * ��    �� : ���� 
 * ����ʱ�� : 2015/1/21 14:12:15 
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
    /// Notice ϵͳ�����ժҪ˵����
    /// </summary>
    public class Notice:DataPacket
    {
        #region ˽���ֶ�
        
        private int        _Guid       ;      // ��ʶ
        private string     _Title      ;      // �������
        private string     _Content    ;      // ��������
        private string     _Author     ;      // ������
        private DateTime   _CreateDate ;      // ����ʱ��

        #endregion

        #region ���캯��

        /// <summary>
        /// ��ʼ����ʵ�� 
        /// </summary>
        public Notice()
        {
        }

        #endregion

        #region ���Զ���

        /// <summary>
        /// ��ʶ 
        /// </summary>
        public int        Guid        { get { return _Guid       ;} set { _Guid        = value; } }
        /// <summary>
        /// ������� 
        /// </summary>
        public string     Title       { get { return _Title      ;} set { _Title       = value; } }
        /// <summary>
        /// �������� 
        /// </summary>
        public string     Content     { get { return _Content    ;} set { _Content     = value; } }
        /// <summary>
        /// ������ 
        /// </summary>
        public string     Author      { get { return _Author     ;} set { _Author      = value; } }
        /// <summary>
        /// ����ʱ�� 
        /// </summary>
        public DateTime   CreateDate  { get { return _CreateDate ;} set { _CreateDate  = value; } }

        #endregion
        
  

        #region ���ع�������

        /// <summary>
        /// ����������ݡ�
        /// </summary>
        public override void Clear()
        {
            base.Clear ();

            _Guid        = 0;
            _Title       = null;
            _Content     = null;
            _Author      = null;
            _CreateDate  = DateTime.MinValue;
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

            WriteXMLValue(node, "Guid", _Guid);
            WriteXMLValue(node, "Title", _Title);
            WriteXMLValue(node, "Content", _Content);
            WriteXMLValue(node, "Author", _Author);
            WriteXMLValue(node, "CreateDate", _CreateDate);
        }

        /// <summary>
        /// ��ָ���ڵ㷴���л��������ݶ���
        /// </summary>
        /// <param name="node">���ڷ����л��� XmlNode �ڵ㡣</param>
        public override void XMLDecode(System.Xml.XmlNode node)
        {
            base.XMLDecode (node);

            ReadXMLValue(node, "Guid", ref _Guid);
            ReadXMLValue(node, "Title", ref _Title);
            ReadXMLValue(node, "Content", ref _Content);
            ReadXMLValue(node, "Author", ref _Author);
            ReadXMLValue(node, "CreateDate", ref _CreateDate);
        }
#endif

        /// <summary>
        /// �������ݶ���
        /// </summary>
        /// <param name="sou">Դ����,���DataPacket�̳�</param>
        public override void AssignFrom(DataPacket sou)
        {
            base.AssignFrom (sou);

            Notice s = sou as Notice;
            if (s != null)
            {
                _Guid        = s._Guid       ;
                _Title       = s._Title      ;
                _Content     = s._Content    ;
                _Author      = s._Author     ;
                _CreateDate  = s._CreateDate ;
            }
        }

        #endregion
    }
}

