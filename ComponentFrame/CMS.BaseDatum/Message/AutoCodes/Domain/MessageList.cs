#region �汾˵��
/*****************************************************************************
 * 
 * ��    Ŀ : 
 * ��    �� : ���� 
 * ����ʱ�� : 2015/1/23 11:25:03 
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
    /// MessageList ��Ϣ�б��ժҪ˵����
    /// </summary>
    public class MessageList:NorDataList
    {
        #region ���캯��

        /// <summary>
        /// ��ʼ����ʵ�� 
        /// </summary>
        public MessageList()
        {
            ItemType = typeof(Message);
        }

        /// <summary>
        /// ��ʼ����ʵ������ʵ��������ָ�����ϸ��Ƶ�Ԫ�ز��Ҿ����������Ƶ�Ԫ������ͬ�ĳ�ʼ������
        /// </summary>
        /// <param name="c"></param>
        public MessageList(ICollection c)
            : base(c)
        {
            ItemType = typeof(Message);
        }

        #endregion
    }
}

