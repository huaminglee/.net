#region 版本说明
/*****************************************************************************
 * 
 * 项    目 : 
 * 作    者 : 李金坪 
 * 创建时间 : 2015/2/6 17:47:34 
 *
 * Copyright (C) 2008 - 鹏业软件公司
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
    /// BaseUserInfo 的摘要说明。
    /// </summary>
    public class BaseUserInfo : DataPacket
    {
        #region 私有字段

        private string _Addr;      // 地址
        private string _Chief;      // 负责人
        private string _Contact;      // 联系人
        private string _Detail;      // 描述
        private string _EMail;      // EMail
        private string _Fax;      // 传真
        private string _FullName;      // 全名
        private string _IMCode;      // IM地址(QQ,MSN,Skype等)
        private string _Job;      // 职务
        private string _Mob;      // 手机
        private string _NickName;      // 呢称
        private string _Tel;      // 电话
        private string _Unit;      // 单位名称
        private string _Zip;      // 邮编
        private string _IDCard;      // 身份证号
        private string _WebUrl;      // 个人网址
        private string _Dept;      // 部门
        private string _Memo;      // 备注
        private bool _IsLocked;      // 是否停用

        #endregion


        #region 属性定义

        /// <summary>
        /// 地址 
        /// </summary>
        public string Addr { get { return _Addr; } set { _Addr = value; } }
        /// <summary>
        /// 负责人 
        /// </summary>
        public string Chief { get { return _Chief; } set { _Chief = value; } }
        /// <summary>
        /// 联系人 
        /// </summary>
        public string Contact { get { return _Contact; } set { _Contact = value; } }
        /// <summary>
        /// 描述 
        /// </summary>
        public string Detail { get { return _Detail; } set { _Detail = value; } }
        /// <summary>
        /// EMail 
        /// </summary>
        public string EMail { get { return _EMail; } set { _EMail = value; } }
        /// <summary>
        /// 传真 
        /// </summary>
        public string Fax { get { return _Fax; } set { _Fax = value; } }
        /// <summary>
        /// 全名 
        /// </summary>
        public string FullName { get { return _FullName; } set { _FullName = value; } }
        /// <summary>
        /// IM地址(QQ,MSN,Skype等) 
        /// </summary>
        public string IMCode { get { return _IMCode; } set { _IMCode = value; } }
        /// <summary>
        /// 职务 
        /// </summary>
        public string Job { get { return _Job; } set { _Job = value; } }
        /// <summary>
        /// 手机 
        /// </summary>
        public string Mob { get { return _Mob; } set { _Mob = value; } }
        /// <summary>
        /// 呢称 
        /// </summary>
        public string NickName { get { return _NickName; } set { _NickName = value; } }
        /// <summary>
        /// 电话 
        /// </summary>
        public string Tel { get { return _Tel; } set { _Tel = value; } }
        /// <summary>
        /// 单位名称 
        /// </summary>
        public string Unit { get { return _Unit; } set { _Unit = value; } }
        /// <summary>
        /// 邮编 
        /// </summary>
        public string Zip { get { return _Zip; } set { _Zip = value; } }
        /// <summary>
        /// 身份证号 
        /// </summary>
        public string IDCard { get { return _IDCard; } set { _IDCard = value; } }
        /// <summary>
        /// 个人网址 
        /// </summary>
        public string WebUrl { get { return _WebUrl; } set { _WebUrl = value; } }
        /// <summary>
        /// 部门 
        /// </summary>
        public string Dept { get { return _Dept; } set { _Dept = value; } }
        /// <summary>
        /// 备注 
        /// </summary>
        public string Memo { get { return _Memo; } set { _Memo = value; } }
        /// <summary>
        /// 是否停用 
        /// </summary>
        public bool IsLocked { get { return _IsLocked; } set { _IsLocked = value; } }

        #endregion



        #region 重载公共函数

        /// <summary>
        /// 清除所有数据。
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
        /// 用指定节点序列化整个数据对象。
        /// </summary>
        /// <param name="node">用于序列化的 XmlNode 节点。</param>
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
        /// 用指定节点反序列化整个数据对象。
        /// </summary>
        /// <param name="node">用于反序列化的 XmlNode 节点。</param>
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
        /// 复制数据对象
        /// </summary>
        /// <param name="sou">源对象,需从DataPacket继承</param>
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
