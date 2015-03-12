#region �汾˵��
/*****************************************************************************
 * 
 * ��    Ŀ : 
 * ��    �� : ���ƺ 
 * ����ʱ�� : 2014/11/20 14:48:13 
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
    /// ModelInfo ģ���ժҪ˵����
    /// </summary>
    public class ModelInfo : DataPacket
    {
        #region ˽���ֶ�

        private int _MId;      // ģ��id
        private string _MName;      // ģ������
        private int _DRow;      // ��ʼλ��x
        private int _DCol;      // ��ʼλ��y
        private int _Sizex;      // ��
        private int _Sizey;      // ��
        private int _MinSizex;      // ��С��
        private int _MinSizey;      // ��С��
        private int _MaxSizex;      // ����
        private int _MaxSizey;      // ����
        private string _RightLevel;      // Ȩ�޵ȼ�
        private string _Pico;      // ͼ��
        private string _BelongPage;      // ҳ��
        private string _MContent;      // ģ������
        private string _Remark;      // ��ע
        private string _ExtendFields1;      // ��չ�ֶ�1
        private string _ExtendFields2;      // ��չ�ֶ�2
        private string _ExtendFields3;      // ��չ�ֶ�3

        #endregion


        #region ���Զ���

        /// <summary>
        /// ģ��id 
        /// </summary>
        public int MId { get { return _MId; } set { _MId = value; } }
        /// <summary>
        /// ģ������ 
        /// </summary>
        public string MName { get { return _MName; } set { _MName = value; } }
        /// <summary>
        /// ��ʼλ��x 
        /// </summary>
        public int DRow { get { return _DRow; } set { _DRow = value; } }
        /// <summary>
        /// ��ʼλ��y 
        /// </summary>
        public int DCol { get { return _DCol; } set { _DCol = value; } }
        /// <summary>
        /// �� 
        /// </summary>
        public int Sizex { get { return _Sizex; } set { _Sizex = value; } }
        /// <summary>
        /// �� 
        /// </summary>
        public int Sizey { get { return _Sizey; } set { _Sizey = value; } }
        /// <summary>
        /// ��С�� 
        /// </summary>
        public int MinSizex { get { return _MinSizex; } set { _MinSizex = value; } }
        /// <summary>
        /// ��С�� 
        /// </summary>
        public int MinSizey { get { return _MinSizey; } set { _MinSizey = value; } }
        /// <summary>
        /// ���� 
        /// </summary>
        public int MaxSizex { get { return _MaxSizex; } set { _MaxSizex = value; } }
        /// <summary>
        /// ���� 
        /// </summary>
        public int MaxSizey { get { return _MaxSizey; } set { _MaxSizey = value; } }
        /// <summary>
        /// Ȩ�޵ȼ� 
        /// </summary>
        public string RightLevel { get { return _RightLevel; } set { _RightLevel = value; } }
        /// <summary>
        /// ͼ�� 
        /// </summary>
        public string Pico { get { return _Pico; } set { _Pico = value; } }
        /// <summary>
        /// ҳ�� 
        /// </summary>
        public string BelongPage { get { return _BelongPage; } set { _BelongPage = value; } }
        /// <summary>
        /// ģ������ 
        /// </summary>
        public string MContent { get { return _MContent; } set { _MContent = value; } }
        /// <summary>
        /// ��ע 
        /// </summary>
        public string Remark { get { return _Remark; } set { _Remark = value; } }
        /// <summary>
        /// ��չ�ֶ�1 
        /// </summary>
        public string ExtendFields1 { get { return _ExtendFields1; } set { _ExtendFields1 = value; } }
        /// <summary>
        /// ��չ�ֶ�2 
        /// </summary>
        public string ExtendFields2 { get { return _ExtendFields2; } set { _ExtendFields2 = value; } }
        /// <summary>
        /// ��չ�ֶ�3 
        /// </summary>
        public string ExtendFields3 { get { return _ExtendFields3; } set { _ExtendFields3 = value; } }

        #endregion



        #region ���ع�������

        /// <summary>
        /// ����������ݡ�
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
        /// ��ָ���ڵ����л��������ݶ���
        /// </summary>
        /// <param name="node">�������л��� XmlNode �ڵ㡣</param>
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
        /// ��ָ���ڵ㷴���л��������ݶ���
        /// </summary>
        /// <param name="node">���ڷ����л��� XmlNode �ڵ㡣</param>
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
        /// �������ݶ���
        /// </summary>
        /// <param name="sou">Դ����,���DataPacket�̳�</param>
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
