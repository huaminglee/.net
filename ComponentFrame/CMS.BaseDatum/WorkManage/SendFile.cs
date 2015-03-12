#region �汾˵��
/*****************************************************************************
 * 
 * ��    Ŀ : 
 * ��    �� : �ź굤 
 * ����ʱ�� : 2014/8/25 20:41:05 
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
    /// SendFile ���Ĵ����ժҪ˵����
    /// </summary>
    public class SendFile:DataPacket 
    {
        #region ˽���ֶ�
        
        private string  _FileDept  ;      // ���ĵ�λ
        private string  _Draft     ;      // ���
        private string  _IsOnLine  ;      // �Ƿ���������
        private string  _Register  ;      // �Ƿ�淶���ļ�����
        private string  _Print     ;      // ��ӡ
        private string  _Check     ;      // �˶�
        private string  _QingYang  ;      // ��������
        private string  _FileCount ;      // ����
        private string  _MainSend  ;      // ����
        private string  _CCSend    ;      // ����

        #endregion


        #region ���Զ���

        /// <summary>
        /// ���ĵ�λ 
        /// </summary>
        public string  FileDept   { get { return _FileDept  ;} set { _FileDept   = value; } }
        /// <summary>
        /// ��� 
        /// </summary>
        public string  Draft      { get { return _Draft     ;} set { _Draft      = value; } }
        /// <summary>
        /// �Ƿ��������� 
        /// </summary>
        public string  IsOnLine   { get { return _IsOnLine  ;} set { _IsOnLine   = value; } }
        /// <summary>
        /// �Ƿ�淶���ļ����� 
        /// </summary>
        public string  Register   { get { return _Register  ;} set { _Register   = value; } }
        /// <summary>
        /// ��ӡ 
        /// </summary>
        public string  Print      { get { return _Print     ;} set { _Print      = value; } }
        /// <summary>
        /// �˶� 
        /// </summary>
        public string  Check      { get { return _Check     ;} set { _Check      = value; } }
        /// <summary>
        /// �������� 
        /// </summary>
        public string  QingYang   { get { return _QingYang  ;} set { _QingYang   = value; } }
        /// <summary>
        /// ���� 
        /// </summary>
        public string  FileCount  { get { return _FileCount ;} set { _FileCount  = value; } }
        /// <summary>
        /// ���� 
        /// </summary>
        public string  MainSend   { get { return _MainSend  ;} set { _MainSend   = value; } }
        /// <summary>
        /// ���� 
        /// </summary>
        public string  CCSend     { get { return _CCSend    ;} set { _CCSend     = value; } }

        #endregion
        
  

        #region ���ع�������

        /// <summary>
        /// ����������ݡ�
        /// </summary>
        public override void Clear()
        {
            base.Clear ();

            _FileDept   = null;
            _Draft      = null;
            _IsOnLine   = null;
            _Register   = null;
            _Print      = null;
            _Check      = null;
            _QingYang   = null;
            _FileCount  = null;
            _MainSend   = null;
            _CCSend     = null;
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

            WriteXMLValue(node, "FileDept", _FileDept);
            WriteXMLValue(node, "Draft", _Draft);
            WriteXMLValue(node, "IsOnLine", _IsOnLine);
            WriteXMLValue(node, "Register", _Register);
            WriteXMLValue(node, "Print", _Print);
            WriteXMLValue(node, "Check", _Check);
            WriteXMLValue(node, "QingYang", _QingYang);
            WriteXMLValue(node, "FileCount", _FileCount);
            WriteXMLValue(node, "MainSend", _MainSend);
            WriteXMLValue(node, "CCSend", _CCSend);
        }

        /// <summary>
        /// ��ָ���ڵ㷴���л��������ݶ���
        /// </summary>
        /// <param name="node">���ڷ����л��� XmlNode �ڵ㡣</param>
        public override void XMLDecode(System.Xml.XmlNode node)
        {
            base.XMLDecode (node);

            ReadXMLValue(node, "FileDept", ref _FileDept);
            ReadXMLValue(node, "Draft", ref _Draft);
            ReadXMLValue(node, "IsOnLine", ref _IsOnLine);
            ReadXMLValue(node, "Register", ref _Register);
            ReadXMLValue(node, "Print", ref _Print);
            ReadXMLValue(node, "Check", ref _Check);
            ReadXMLValue(node, "QingYang", ref _QingYang);
            ReadXMLValue(node, "FileCount", ref _FileCount);
            ReadXMLValue(node, "MainSend", ref _MainSend);
            ReadXMLValue(node, "CCSend", ref _CCSend);
        }
#endif

        /// <summary>
        /// �������ݶ���
        /// </summary>
        /// <param name="sou">Դ����,���DataPacket�̳�</param>
        public override void AssignFrom(DataPacket sou)
        {
            base.AssignFrom (sou);

            SendFile s = sou as SendFile;
            if (s != null)
            {
                _FileDept   = s._FileDept  ;
                _Draft      = s._Draft     ;
                _IsOnLine   = s._IsOnLine  ;
                _Register   = s._Register  ;
                _Print      = s._Print     ;
                _Check      = s._Check     ;
                _QingYang   = s._QingYang  ;
                _FileCount  = s._FileCount ;
                _MainSend   = s._MainSend  ;
                _CCSend     = s._CCSend    ;
            }
        }

        #endregion
    }
}

