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
    /// NoticeList �����б��ժҪ˵����
    /// </summary>
    public class NoticeList:NorDataList
    {
        #region ���캯��

        /// <summary>
        /// ��ʼ����ʵ�� 
        /// </summary>
        public NoticeList()
        {
            ItemType = typeof(Notice);
        }

        /// <summary>
        /// ��ʼ����ʵ������ʵ��������ָ�����ϸ��Ƶ�Ԫ�ز��Ҿ����������Ƶ�Ԫ������ͬ�ĳ�ʼ������
        /// </summary>
        /// <param name="c"></param>
        public NoticeList(ICollection c)
            : base(c)
        {
            ItemType = typeof(Notice);
        }

        #endregion
    }
}

