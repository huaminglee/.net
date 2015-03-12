#region �汾˵��
/*****************************************************************************
 * 
 * ��    Ŀ : 
 * ��    �� : ���ƺ 
 * ����ʱ�� : 2015/2/13 9:56:41 
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
    /// BaseUserAndRoleInfo ��ժҪ˵����
    /// </summary>
    public class BaseUserAndRoleInfo:DataPacket
    {
        #region ˽���ֶ�
        
        private int      _SID      ;      // SID
        private string   _FullName ;      // FullName
        private string   _LoginID  ;      // LoginID

        #endregion


        #region ���Զ���

        /// <summary>
        /// SID 
        /// </summary>
        public int      SID       { get { return _SID      ;} set { _SID       = value; } }
        /// <summary>
        /// FullName 
        /// </summary>
        public string   FullName  { get { return _FullName ;} set { _FullName  = value; } }
        /// <summary>
        /// LoginID 
        /// </summary>
        public string   LoginID   { get { return _LoginID  ;} set { _LoginID   = value; } }

        #endregion
        
  

        #region ���ع�������

        /// <summary>
        /// ����������ݡ�
        /// </summary>
        public override void Clear()
        {
            base.Clear ();

            _SID       = 0;
            _FullName  = null;
            _LoginID   = null;
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

            WriteXMLValue(node, "SID", _SID);
            WriteXMLValue(node, "FullName", _FullName);
            WriteXMLValue(node, "LoginID", _LoginID);
        }

        /// <summary>
        /// ��ָ���ڵ㷴���л��������ݶ���
        /// </summary>
        /// <param name="node">���ڷ����л��� XmlNode �ڵ㡣</param>
        public override void XMLDecode(System.Xml.XmlNode node)
        {
            base.XMLDecode (node);

            ReadXMLValue(node, "SID", ref _SID);
            ReadXMLValue(node, "FullName", ref _FullName);
            ReadXMLValue(node, "LoginID", ref _LoginID);
        }
#endif

        /// <summary>
        /// �������ݶ���
        /// </summary>
        /// <param name="sou">Դ����,���DataPacket�̳�</param>
        public override void AssignFrom(DataPacket sou)
        {
            base.AssignFrom (sou);

            BaseUserAndRoleInfo s = sou as BaseUserAndRoleInfo;
            if (s != null)
            {
                _SID       = s._SID      ;
                _FullName  = s._FullName ;
                _LoginID   = s._LoginID  ;
            }
        }

        #endregion
    }
}

