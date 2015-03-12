#region 版本说明
/*****************************************************************************
 * 
 * 项    目 : 
 * 作    者 : 张宏丹 
 * 创建时间 : 2014/8/27 13:30:06 
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
    /// Proposal 的摘要说明。
    /// </summary>
    public class Proposal : DataPacket
    {
        #region 私有字段

        private int _BelongYear;      // 所属年份
        private string _SessionNo;      // 界别号数
        private string _LeaderPerson;      // 领衔人员
        private int _PersonNums;      // 人数
        private string _SubjectCopy;      // 主题抄送
        private string _Cause;      // 案由
        private string _Summary;      // 摘要

        #endregion


        #region 属性定义

        /// <summary>
        /// 所属年份 
        /// </summary>
        public int BelongYear { get { return _BelongYear; } set { _BelongYear = value; } }
        /// <summary>
        /// 界别号数 
        /// </summary>
        public string SessionNo { get { return _SessionNo; } set { _SessionNo = value; } }
        /// <summary>
        /// 领衔人员 
        /// </summary>
        public string LeaderPerson { get { return _LeaderPerson; } set { _LeaderPerson = value; } }
        /// <summary>
        /// 人数 
        /// </summary>
        public int PersonNums { get { return _PersonNums; } set { _PersonNums = value; } }
        /// <summary>
        /// 主题抄送 
        /// </summary>
        public string SubjectCopy { get { return _SubjectCopy; } set { _SubjectCopy = value; } }
        /// <summary>
        /// 案由 
        /// </summary>
        public string Cause { get { return _Cause; } set { _Cause = value; } }
        /// <summary>
        /// 摘要 
        /// </summary>
        public string Summary { get { return _Summary; } set { _Summary = value; } }

        #endregion



        #region 重载公共函数

        /// <summary>
        /// 清除所有数据。
        /// </summary>
        public override void Clear()
        {
            base.Clear();

            _BelongYear = 0;
            _SessionNo = null;
            _LeaderPerson = null;
            _PersonNums = 0;
            _SubjectCopy = null;
            _Cause = null;
            _Summary = null;
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

            WriteXMLValue(node, "BelongYear", _BelongYear);
            WriteXMLValue(node, "SessionNo", _SessionNo);
            WriteXMLValue(node, "LeaderPerson", _LeaderPerson);
            WriteXMLValue(node, "PersonNums", _PersonNums);
            WriteXMLValue(node, "SubjectCopy", _SubjectCopy);
            WriteXMLValue(node, "Cause", _Cause);
            WriteXMLValue(node, "Summary", _Summary);
        }

        /// <summary>
        /// 用指定节点反序列化整个数据对象。
        /// </summary>
        /// <param name="node">用于反序列化的 XmlNode 节点。</param>
        public override void XMLDecode(System.Xml.XmlNode node)
        {
            base.XMLDecode(node);

            ReadXMLValue(node, "BelongYear", ref _BelongYear);
            ReadXMLValue(node, "SessionNo", ref _SessionNo);
            ReadXMLValue(node, "LeaderPerson", ref _LeaderPerson);
            ReadXMLValue(node, "PersonNums", ref _PersonNums);
            ReadXMLValue(node, "SubjectCopy", ref _SubjectCopy);
            ReadXMLValue(node, "Cause", ref _Cause);
            ReadXMLValue(node, "Summary", ref _Summary);
        }
#endif

        /// <summary>
        /// 复制数据对象
        /// </summary>
        /// <param name="sou">源对象,需从DataPacket继承</param>
        public override void AssignFrom(DataPacket sou)
        {
            base.AssignFrom(sou);

            Proposal s = sou as Proposal;
            if (s != null)
            {
                _BelongYear = s._BelongYear;
                _SessionNo = s._SessionNo;
                _LeaderPerson = s._LeaderPerson;
                _PersonNums = s._PersonNums;
                _SubjectCopy = s._SubjectCopy;
                _Cause = s._Cause;
                _Summary = s._Summary;
            }
        }

        #endregion
    }
}
