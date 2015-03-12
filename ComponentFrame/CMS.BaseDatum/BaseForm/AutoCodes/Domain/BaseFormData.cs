#region 版本说明
/*****************************************************************************
 * 
 * 项    目 : 
 * 作    者 : 李金坪 
 * 创建时间 : 2014/12/29 16:44:57 
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
    /// BaseFormData 的摘要说明。
    /// </summary>
    public class BaseFormData : DataPacket
    {
        #region 私有字段

        private string _FormID;      // 表单ID
        private string _Creator;      // 创建人
        private DateTime _CreateDate;      // 创建日期
        private DateTime _FinishDate;      // 结案日期
        private int _Status;      // 状态
        private string _TaskID;      // 任务ID
        private string _WorkID;      // 工作流ID
        private int _SType;      // 表单类型
        private DoAttitudeList _Attitudes;      // 办理意见
        private AttachmentList _Attachments;      // 附件
        private int _Uurgency;      // 紧急程度
        private int _IsSecret;      // 是否涉密
        private string _SecretLevel;      // 涉密等级
        private string _FileNo;      // 文件编号
        private string _Title;      // 标题
        private string _SLevel;      // 级别
        private DateTime _RequestFinishDate;      // 完成时限
        private DateTime _ReceiveDate;      // 收文日期
        private int _IsSpecial;      // 是否三重一大
        private string _SendUnit;      // 来文单位
        private string _DocType;      // 文种
        private string _Remark;      // 备注
        private string _CurStep;      // 当前状态
        private string _CurRunner;      // 当前处理人员
        private string _ExpanField;      // 特殊字段

        #endregion

        #region 构造函数

        /// <summary>
        /// 初始化新实例 
        /// </summary>
        public BaseFormData()
        {
            _Attitudes = new DoAttitudeList();
            _Attachments = new AttachmentList();
        }

        #endregion

        #region 属性定义

        /// <summary>
        /// 表单ID 
        /// </summary>
        public string FormID { get { return _FormID; } set { _FormID = value; } }
        /// <summary>
        /// 创建人 
        /// </summary>
        public string Creator { get { return _Creator; } set { _Creator = value; } }
        /// <summary>
        /// 创建日期 
        /// </summary>
        public DateTime CreateDate { get { return _CreateDate; } set { _CreateDate = value; } }
        /// <summary>
        /// 结案日期 
        /// </summary>
        public DateTime FinishDate { get { return _FinishDate; } set { _FinishDate = value; } }
        /// <summary>
        /// 状态 
        /// </summary>
        public int Status { get { return _Status; } set { _Status = value; } }
        /// <summary>
        /// 任务ID 
        /// </summary>
        public string TaskID { get { return _TaskID; } set { _TaskID = value; } }
        /// <summary>
        /// 工作流ID 
        /// </summary>
        public string WorkID { get { return _WorkID; } set { _WorkID = value; } }
        /// <summary>
        /// 表单类型 
        /// </summary>
        public int SType { get { return _SType; } set { _SType = value; } }
        /// <summary>
        /// 办理意见 
        /// </summary>
        public DoAttitudeList Attitudes { get { return _Attitudes; } set { _Attitudes = value; } }
        /// <summary>
        /// 附件 
        /// </summary>
        public AttachmentList Attachments { get { return _Attachments; } set { _Attachments = value; } }
        /// <summary>
        /// 紧急程度 
        /// </summary>
        public int Uurgency { get { return _Uurgency; } set { _Uurgency = value; } }
        /// <summary>
        /// 是否涉密 
        /// </summary>
        public int IsSecret { get { return _IsSecret; } set { _IsSecret = value; } }
        /// <summary>
        /// 涉密等级 
        /// </summary>
        public string SecretLevel { get { return _SecretLevel; } set { _SecretLevel = value; } }
        /// <summary>
        /// 文件编号 
        /// </summary>
        public string FileNo { get { return _FileNo; } set { _FileNo = value; } }
        /// <summary>
        /// 标题 
        /// </summary>
        public string Title { get { return _Title; } set { _Title = value; } }
        /// <summary>
        /// 级别 
        /// </summary>
        public string SLevel { get { return _SLevel; } set { _SLevel = value; } }
        /// <summary>
        /// 完成时限 
        /// </summary>
        public DateTime RequestFinishDate { get { return _RequestFinishDate; } set { _RequestFinishDate = value; } }
        /// <summary>
        /// 收文日期 
        /// </summary>
        public DateTime ReceiveDate { get { return _ReceiveDate; } set { _ReceiveDate = value; } }
        /// <summary>
        /// 是否三重一大 
        /// </summary>
        public int IsSpecial { get { return _IsSpecial; } set { _IsSpecial = value; } }
        /// <summary>
        /// 来文单位 
        /// </summary>
        public string SendUnit { get { return _SendUnit; } set { _SendUnit = value; } }
        /// <summary>
        /// 文种 
        /// </summary>
        public string DocType { get { return _DocType; } set { _DocType = value; } }
        /// <summary>
        /// 备注 
        /// </summary>
        public string Remark { get { return _Remark; } set { _Remark = value; } }
        /// <summary>
        /// 当前状态 
        /// </summary>
        public string CurStep { get { return _CurStep; } set { _CurStep = value; } }
        /// <summary>
        /// 当前处理人员 
        /// </summary>
        public string CurRunner { get { return _CurRunner; } set { _CurRunner = value; } }
        /// <summary>
        /// 特殊字段 
        /// </summary>
        public string ExpanField { get { return _ExpanField; } set { _ExpanField = value; } }

        #endregion



        #region 重载公共函数

        /// <summary>
        /// 清除所有数据。
        /// </summary>
        public override void Clear()
        {
            base.Clear();

            _FormID = null;
            _Creator = null;
            _CreateDate = DateTime.MinValue;
            _FinishDate = DateTime.MinValue;
            _Status = 0;
            _TaskID = null;
            _WorkID = null;
            _SType = 0;
            _Attitudes.Clear();
            _Attachments.Clear();
            _Uurgency = 0;
            _IsSecret = 0;
            _SecretLevel = null;
            _FileNo = null;
            _Title = null;
            _SLevel = null;
            _RequestFinishDate = DateTime.MinValue;
            _ReceiveDate = DateTime.MinValue;
            _IsSpecial = 0;
            _SendUnit = null;
            _DocType = null;
            _Remark = null;
            _CurStep = null;
            _CurRunner = null;
            _ExpanField = null;
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

            WriteXMLValue(node, "FormID", _FormID);
            WriteXMLValue(node, "Creator", _Creator);
            WriteXMLValue(node, "CreateDate", _CreateDate);
            WriteXMLValue(node, "FinishDate", _FinishDate);
            WriteXMLValue(node, "Status", _Status);
            WriteXMLValue(node, "TaskID", _TaskID);
            WriteXMLValue(node, "WorkID", _WorkID);
            WriteXMLValue(node, "SType", _SType);
            WriteXMLValue(node, "Attitudes", _Attitudes);
            WriteXMLValue(node, "Attachments", _Attachments);
            WriteXMLValue(node, "Uurgency", _Uurgency);
            WriteXMLValue(node, "IsSecret", _IsSecret);
            WriteXMLValue(node, "SecretLevel", _SecretLevel);
            WriteXMLValue(node, "FileNo", _FileNo);
            WriteXMLValue(node, "Title", _Title);
            WriteXMLValue(node, "SLevel", _SLevel);
            WriteXMLValue(node, "RequestFinishDate", _RequestFinishDate);
            WriteXMLValue(node, "ReceiveDate", _ReceiveDate);
            WriteXMLValue(node, "IsSpecial", _IsSpecial);
            WriteXMLValue(node, "SendUnit", _SendUnit);
            WriteXMLValue(node, "DocType", _DocType);
            WriteXMLValue(node, "Remark", _Remark);
            WriteXMLValue(node, "CurStep", _CurStep);
            WriteXMLValue(node, "CurRunner", _CurRunner);
            WriteXMLValue(node, "ExpanField", _ExpanField);
        }

        /// <summary>
        /// 用指定节点反序列化整个数据对象。
        /// </summary>
        /// <param name="node">用于反序列化的 XmlNode 节点。</param>
        public override void XMLDecode(System.Xml.XmlNode node)
        {
            base.XMLDecode(node);

            ReadXMLValue(node, "FormID", ref _FormID);
            ReadXMLValue(node, "Creator", ref _Creator);
            ReadXMLValue(node, "CreateDate", ref _CreateDate);
            ReadXMLValue(node, "FinishDate", ref _FinishDate);
            ReadXMLValue(node, "Status", ref _Status);
            ReadXMLValue(node, "TaskID", ref _TaskID);
            ReadXMLValue(node, "WorkID", ref _WorkID);
            ReadXMLValue(node, "SType", ref _SType);
            ReadXMLValue(node, "Attitudes", _Attitudes);
            ReadXMLValue(node, "Attachments", _Attachments);
            ReadXMLValue(node, "Uurgency", ref _Uurgency);
            ReadXMLValue(node, "IsSecret", ref _IsSecret);
            ReadXMLValue(node, "SecretLevel", ref _SecretLevel);
            ReadXMLValue(node, "FileNo", ref _FileNo);
            ReadXMLValue(node, "Title", ref _Title);
            ReadXMLValue(node, "SLevel", ref _SLevel);
            ReadXMLValue(node, "RequestFinishDate", ref _RequestFinishDate);
            ReadXMLValue(node, "ReceiveDate", ref _ReceiveDate);
            ReadXMLValue(node, "IsSpecial", ref _IsSpecial);
            ReadXMLValue(node, "SendUnit", ref _SendUnit);
            ReadXMLValue(node, "DocType", ref _DocType);
            ReadXMLValue(node, "Remark", ref _Remark);
            ReadXMLValue(node, "CurStep", ref _CurStep);
            ReadXMLValue(node, "CurRunner", ref _CurRunner);
            ReadXMLValue(node, "ExpanField", ref _ExpanField);
        }
#endif

        /// <summary>
        /// 复制数据对象
        /// </summary>
        /// <param name="sou">源对象,需从DataPacket继承</param>
        public override void AssignFrom(DataPacket sou)
        {
            base.AssignFrom(sou);

            BaseFormData s = sou as BaseFormData;
            if (s != null)
            {
                _FormID = s._FormID;
                _Creator = s._Creator;
                _CreateDate = s._CreateDate;
                _FinishDate = s._FinishDate;
                _Status = s._Status;
                _TaskID = s._TaskID;
                _WorkID = s._WorkID;
                _SType = s._SType;
                _Attitudes.AssignFrom(s._Attitudes);
                _Attachments.AssignFrom(s._Attachments);
                _Uurgency = s._Uurgency;
                _IsSecret = s._IsSecret;
                _SecretLevel = s._SecretLevel;
                _FileNo = s._FileNo;
                _Title = s._Title;
                _SLevel = s._SLevel;
                _RequestFinishDate = s._RequestFinishDate;
                _ReceiveDate = s._ReceiveDate;
                _IsSpecial = s._IsSpecial;
                _SendUnit = s._SendUnit;
                _DocType = s._DocType;
                _Remark = s._Remark;
                _CurStep = s._CurStep;
                _CurRunner = s._CurRunner;
                _ExpanField = s._ExpanField;
            }
        }

        #endregion
    }
}
