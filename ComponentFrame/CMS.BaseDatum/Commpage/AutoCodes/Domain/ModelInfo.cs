#region 版本说明
/*****************************************************************************
 * 
 * 项    目 : 
 * 作    者 : 李金坪 
 * 创建时间 : 2014/11/20 14:48:13 
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
    /// ModelInfo 模块的摘要说明。
    /// </summary>
    public class ModelInfo : DataPacket
    {
        #region 私有字段

        private int _MId;      // 模块id
        private string _MName;      // 模块名称
        private int _DRow;      // 初始位置x
        private int _DCol;      // 初始位置y
        private int _Sizex;      // 宽
        private int _Sizey;      // 高
        private int _MinSizex;      // 最小宽
        private int _MinSizey;      // 最小高
        private int _MaxSizex;      // 最大宽
        private int _MaxSizey;      // 最大高
        private string _RightLevel;      // 权限等级
        private string _Pico;      // 图标
        private string _BelongPage;      // 页面
        private string _MContent;      // 模块内容
        private string _Remark;      // 备注
        private string _ExtendFields1;      // 扩展字段1
        private string _ExtendFields2;      // 扩展字段2
        private string _ExtendFields3;      // 扩展字段3

        #endregion


        #region 属性定义

        /// <summary>
        /// 模块id 
        /// </summary>
        public int MId { get { return _MId; } set { _MId = value; } }
        /// <summary>
        /// 模块名称 
        /// </summary>
        public string MName { get { return _MName; } set { _MName = value; } }
        /// <summary>
        /// 初始位置x 
        /// </summary>
        public int DRow { get { return _DRow; } set { _DRow = value; } }
        /// <summary>
        /// 初始位置y 
        /// </summary>
        public int DCol { get { return _DCol; } set { _DCol = value; } }
        /// <summary>
        /// 宽 
        /// </summary>
        public int Sizex { get { return _Sizex; } set { _Sizex = value; } }
        /// <summary>
        /// 高 
        /// </summary>
        public int Sizey { get { return _Sizey; } set { _Sizey = value; } }
        /// <summary>
        /// 最小宽 
        /// </summary>
        public int MinSizex { get { return _MinSizex; } set { _MinSizex = value; } }
        /// <summary>
        /// 最小高 
        /// </summary>
        public int MinSizey { get { return _MinSizey; } set { _MinSizey = value; } }
        /// <summary>
        /// 最大宽 
        /// </summary>
        public int MaxSizex { get { return _MaxSizex; } set { _MaxSizex = value; } }
        /// <summary>
        /// 最大高 
        /// </summary>
        public int MaxSizey { get { return _MaxSizey; } set { _MaxSizey = value; } }
        /// <summary>
        /// 权限等级 
        /// </summary>
        public string RightLevel { get { return _RightLevel; } set { _RightLevel = value; } }
        /// <summary>
        /// 图标 
        /// </summary>
        public string Pico { get { return _Pico; } set { _Pico = value; } }
        /// <summary>
        /// 页面 
        /// </summary>
        public string BelongPage { get { return _BelongPage; } set { _BelongPage = value; } }
        /// <summary>
        /// 模块内容 
        /// </summary>
        public string MContent { get { return _MContent; } set { _MContent = value; } }
        /// <summary>
        /// 备注 
        /// </summary>
        public string Remark { get { return _Remark; } set { _Remark = value; } }
        /// <summary>
        /// 扩展字段1 
        /// </summary>
        public string ExtendFields1 { get { return _ExtendFields1; } set { _ExtendFields1 = value; } }
        /// <summary>
        /// 扩展字段2 
        /// </summary>
        public string ExtendFields2 { get { return _ExtendFields2; } set { _ExtendFields2 = value; } }
        /// <summary>
        /// 扩展字段3 
        /// </summary>
        public string ExtendFields3 { get { return _ExtendFields3; } set { _ExtendFields3 = value; } }

        #endregion



        #region 重载公共函数

        /// <summary>
        /// 清除所有数据。
        /// </summary>
        public override void Clear()
        {
            base.Clear();

            _MId = 0;
            _MName = null;
            _DRow = 0;
            _DCol = 0;
            _Sizex = 0;
            _Sizey = 0;
            _MinSizex = 0;
            _MinSizey = 0;
            _MaxSizex = 0;
            _MaxSizey = 0;
            _RightLevel = null;
            _Pico = null;
            _BelongPage = null;
            _MContent = null;
            _Remark = null;
            _ExtendFields1 = null;
            _ExtendFields2 = null;
            _ExtendFields3 = null;
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

            WriteXMLValue(node, "MId", _MId);
            WriteXMLValue(node, "MName", _MName);
            WriteXMLValue(node, "DRow", _DRow);
            WriteXMLValue(node, "DCol", _DCol);
            WriteXMLValue(node, "Sizex", _Sizex);
            WriteXMLValue(node, "Sizey", _Sizey);
            WriteXMLValue(node, "MinSizex", _MinSizex);
            WriteXMLValue(node, "MinSizey", _MinSizey);
            WriteXMLValue(node, "MaxSizex", _MaxSizex);
            WriteXMLValue(node, "MaxSizey", _MaxSizey);
            WriteXMLValue(node, "RightLevel", _RightLevel);
            WriteXMLValue(node, "Pico", _Pico);
            WriteXMLValue(node, "BelongPage", _BelongPage);
            WriteXMLValue(node, "MContent", _MContent);
            WriteXMLValue(node, "Remark", _Remark);
            WriteXMLValue(node, "ExtendFields1", _ExtendFields1);
            WriteXMLValue(node, "ExtendFields2", _ExtendFields2);
            WriteXMLValue(node, "ExtendFields3", _ExtendFields3);
        }

        /// <summary>
        /// 用指定节点反序列化整个数据对象。
        /// </summary>
        /// <param name="node">用于反序列化的 XmlNode 节点。</param>
        public override void XMLDecode(System.Xml.XmlNode node)
        {
            base.XMLDecode(node);

            ReadXMLValue(node, "MId", ref _MId);
            ReadXMLValue(node, "MName", ref _MName);
            ReadXMLValue(node, "DRow", ref _DRow);
            ReadXMLValue(node, "DCol", ref _DCol);
            ReadXMLValue(node, "Sizex", ref _Sizex);
            ReadXMLValue(node, "Sizey", ref _Sizey);
            ReadXMLValue(node, "MinSizex", ref _MinSizex);
            ReadXMLValue(node, "MinSizey", ref _MinSizey);
            ReadXMLValue(node, "MaxSizex", ref _MaxSizex);
            ReadXMLValue(node, "MaxSizey", ref _MaxSizey);
            ReadXMLValue(node, "RightLevel", ref _RightLevel);
            ReadXMLValue(node, "Pico", ref _Pico);
            ReadXMLValue(node, "BelongPage", ref _BelongPage);
            ReadXMLValue(node, "MContent", ref _MContent);
            ReadXMLValue(node, "Remark", ref _Remark);
            ReadXMLValue(node, "ExtendFields1", ref _ExtendFields1);
            ReadXMLValue(node, "ExtendFields2", ref _ExtendFields2);
            ReadXMLValue(node, "ExtendFields3", ref _ExtendFields3);
        }
#endif

        /// <summary>
        /// 复制数据对象
        /// </summary>
        /// <param name="sou">源对象,需从DataPacket继承</param>
        public override void AssignFrom(DataPacket sou)
        {
            base.AssignFrom(sou);

            ModelInfo s = sou as ModelInfo;
            if (s != null)
            {
                _MId = s._MId;
                _MName = s._MName;
                _DRow = s._DRow;
                _DCol = s._DCol;
                _Sizex = s._Sizex;
                _Sizey = s._Sizey;
                _MinSizex = s._MinSizex;
                _MinSizey = s._MinSizey;
                _MaxSizex = s._MaxSizex;
                _MaxSizey = s._MaxSizey;
                _RightLevel = s._RightLevel;
                _Pico = s._Pico;
                _BelongPage = s._BelongPage;
                _MContent = s._MContent;
                _Remark = s._Remark;
                _ExtendFields1 = s._ExtendFields1;
                _ExtendFields2 = s._ExtendFields2;
                _ExtendFields3 = s._ExtendFields3;
            }
        }

        #endregion
    }
}
