#region �汾˵��
/*****************************************************************************
 * 
 * ��    Ŀ : 
 * ��    �� : ���ƺ 
 * ����ʱ�� : 2014/11/18 11:32:41 
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
    /// LayoutInfoList ��ժҪ˵����
    /// </summary>
    public class LayoutInfoList : NorDataList
    {
        #region ���캯��

        /// <summary>
        /// ��ʼ����ʵ�� 
        /// </summary>
        public LayoutInfoList()
        {
            ItemType = typeof(LayoutInfo);
        }

        /// <summary>
        /// ��ʼ����ʵ������ʵ��������ָ�����ϸ��Ƶ�Ԫ�ز��Ҿ����������Ƶ�Ԫ������ͬ�ĳ�ʼ������
        /// </summary>
        /// <param name="c"></param>
        public LayoutInfoList(ICollection c)
            : base(c)
        {
            ItemType = typeof(LayoutInfo);
        }

        #endregion
    }
}
