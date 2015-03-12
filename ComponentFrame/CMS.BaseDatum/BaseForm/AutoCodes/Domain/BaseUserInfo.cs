#region �汾˵��
/*****************************************************************************
 * 
 * ��    Ŀ : 
 * ��    �� : ���ƺ 
 * ����ʱ�� : 2015/2/6 17:47:34 
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
    /// BaseUserInfo ��ժҪ˵����
    /// </summary>
    public class BaseUserInfo : DataPacket
    {
        #region ˽���ֶ�

        private string _Addr;      // ��ַ
        private string _Chief;      // ������
        private string _Contact;      // ��ϵ��
        private string _Detail;      // ����
        private string _EMail;      // EMail
        private string _Fax;      // ����
        private string _FullName;      // ȫ��
        private string _IMCode;      // IM��ַ(QQ,MSN,Skype��)
        private string _Job;      // ְ��
        private string _Mob;      // �ֻ�
        private string _NickName;      // �س�
        private string _Tel;      // �绰
        private string _Unit;      // ��λ����
        private string _Zip;      // �ʱ�
        private string _IDCard;      // ���֤��
        private string _WebUrl;      // ������ַ
        private string _Dept;      // ����
        private string _Memo;      // ��ע
        private bool _IsLocked;      // �Ƿ�ͣ��

        #endregion


        #region ���Զ���

        /// <summary>
        /// ��ַ 
        /// </summary>
        public string Addr { get { return _Addr; } set { _Addr = value; } }
        /// <summary>
        /// ������ 
        /// </summary>
        public string Chief { get { return _Chief; } set { _Chief = value; } }
        /// <summary>
        /// ��ϵ�� 
        /// </summary>
        public string Contact { get { return _Contact; } set { _Contact = value; } }
        /// <summary>
        /// ���� 
        /// </summary>
        public string Detail { get { return _Detail; } set { _Detail = value; } }
        /// <summary>
        /// EMail 
        /// </summary>
        public string EMail { get { return _EMail; } set { _EMail = value; } }
        /// <summary>
        /// ���� 
        /// </summary>
        public string Fax { get { return _Fax; } set { _Fax = value; } }
        /// <summary>
        /// ȫ�� 
        /// </summary>
        public string FullName { get { return _FullName; } set { _FullName = value; } }
        /// <summary>
        /// IM��ַ(QQ,MSN,Skype��) 
        /// </summary>
        public string IMCode { get { return _IMCode; } set { _IMCode = value; } }
        /// <summary>
        /// ְ�� 
        /// </summary>
        public string Job { get { return _Job; } set { _Job = value; } }
        /// <summary>
        /// �ֻ� 
        /// </summary>
        public string Mob { get { return _Mob; } set { _Mob = value; } }
        /// <summary>
        /// �س� 
        /// </summary>
        public string NickName { get { return _NickName; } set { _NickName = value; } }
        /// <summary>
        /// �绰 
        /// </summary>
        public string Tel { get { return _Tel; } set { _Tel = value; } }
        /// <summary>
        /// ��λ���� 
        /// </summary>
        public string Unit { get { return _Unit; } set { _Unit = value; } }
        /// <summary>
        /// �ʱ� 
        /// </summary>
        public string Zip { get { return _Zip; } set { _Zip = value; } }
        /// <summary>
        /// ���֤�� 
        /// </summary>
        public string IDCard { get { return _IDCard; } set { _IDCard = value; } }
        /// <summary>
        /// ������ַ 
        /// </summary>
        public string WebUrl { get { return _WebUrl; } set { _WebUrl = value; } }
        /// <summary>
        /// ���� 
        /// </summary>
        public string Dept { get { return _Dept; } set { _Dept = value; } }
        /// <summary>
        /// ��ע 
        /// </summary>
        public string Memo { get { return _Memo; } set { _Memo = value; } }
        /// <summary>
        /// �Ƿ�ͣ�� 
        /// </summary>
        public bool IsLocked { get { return _IsLocked; } set { _IsLocked = value; } }

        #endregion



        #region ���ع�������

        /// <summary>
        /// ����������ݡ�
        /// </summary>
        public override void Clear()
        {
            base.Clear();

            _Addr = null;
            _Chief = null;
            _Contact = null;
            _Detail = null;
            _EMail = null;
            _Fax = null;
            _FullName = null;
            _IMCode = null;
            _Job = null;
            _Mob = null;
            _NickName = null;
            _Tel = null;
            _Unit = null;
            _Zip = null;
            _IDCard = null;
            _WebUrl = null;
            _Dept = null;
            _Memo = null;
            _IsLocked = false;
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

            WriteXMLValue(node, "Addr", _Addr);
            WriteXMLValue(node, "Chief", _Chief);
            WriteXMLValue(node, "Contact", _Contact);
            WriteXMLValue(node, "Detail", _Detail);
            WriteXMLValue(node, "EMail", _EMail);
            WriteXMLValue(node, "Fax", _Fax);
            WriteXMLValue(node, "FullName", _FullName);
            WriteXMLValue(node, "IMCode", _IMCode);
            WriteXMLValue(node, "Job", _Job);
            WriteXMLValue(node, "Mob", _Mob);
            WriteXMLValue(node, "NickName", _NickName);
            WriteXMLValue(node, "Tel", _Tel);
            WriteXMLValue(node, "Unit", _Unit);
            WriteXMLValue(node, "Zip", _Zip);
            WriteXMLValue(node, "IDCard", _IDCard);
            WriteXMLValue(node, "WebUrl", _WebUrl);
            WriteXMLValue(node, "Dept", _Dept);
            WriteXMLValue(node, "Memo", _Memo);
            WriteXMLValue(node, "IsLocked", _IsLocked);
        }

        /// <summary>
        /// ��ָ���ڵ㷴���л��������ݶ���
        /// </summary>
        /// <param name="node">���ڷ����л��� XmlNode �ڵ㡣</param>
        public override void XMLDecode(System.Xml.XmlNode node)
        {
            base.XMLDecode(node);

            ReadXMLValue(node, "Addr", ref _Addr);
            ReadXMLValue(node, "Chief", ref _Chief);
            ReadXMLValue(node, "Contact", ref _Contact);
            ReadXMLValue(node, "Detail", ref _Detail);
            ReadXMLValue(node, "EMail", ref _EMail);
            ReadXMLValue(node, "Fax", ref _Fax);
            ReadXMLValue(node, "FullName", ref _FullName);
            ReadXMLValue(node, "IMCode", ref _IMCode);
            ReadXMLValue(node, "Job", ref _Job);
            ReadXMLValue(node, "Mob", ref _Mob);
            ReadXMLValue(node, "NickName", ref _NickName);
            ReadXMLValue(node, "Tel", ref _Tel);
            ReadXMLValue(node, "Unit", ref _Unit);
            ReadXMLValue(node, "Zip", ref _Zip);
            ReadXMLValue(node, "IDCard", ref _IDCard);
            ReadXMLValue(node, "WebUrl", ref _WebUrl);
            ReadXMLValue(node, "Dept", ref _Dept);
            ReadXMLValue(node, "Memo", ref _Memo);
            ReadXMLValue(node, "IsLocked", ref _IsLocked);
        }
#endif

        /// <summary>
        /// �������ݶ���
        /// </summary>
        /// <param name="sou">Դ����,���DataPacket�̳�</param>
        public override void AssignFrom(DataPacket sou)
        {
            base.AssignFrom(sou);

            BaseUserInfo s = sou as BaseUserInfo;
            if (s != null)
            {
                _Addr = s._Addr;
                _Chief = s._Chief;
                _Contact = s._Contact;
                _Detail = s._Detail;
                _EMail = s._EMail;
                _Fax = s._Fax;
                _FullName = s._FullName;
                _IMCode = s._IMCode;
                _Job = s._Job;
                _Mob = s._Mob;
                _NickName = s._NickName;
                _Tel = s._Tel;
                _Unit = s._Unit;
                _Zip = s._Zip;
                _IDCard = s._IDCard;
                _WebUrl = s._WebUrl;
                _Dept = s._Dept;
                _Memo = s._Memo;
                _IsLocked = s._IsLocked;
            }
        }

        #endregion
    }
}
