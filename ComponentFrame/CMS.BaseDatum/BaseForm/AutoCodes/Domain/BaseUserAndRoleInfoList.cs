#region �汾˵��
/*****************************************************************************
 * 
 * ��    Ŀ : 
 * ��    �� : ���ƺ 
 * ����ʱ�� : 2015/2/13 9:56:49 
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
    /// BaseUserAndRoleInfoList ��ժҪ˵����
    /// </summary>
    public class BaseUserAndRoleInfoList:NorDataList
    {
        #region ���캯��

        /// <summary>
        /// ��ʼ����ʵ�� 
        /// </summary>
        public BaseUserAndRoleInfoList()
        {
            ItemType = typeof(BaseUserAndRoleInfo);
        }

        /// <summary>
        /// ��ʼ����ʵ������ʵ��������ָ�����ϸ��Ƶ�Ԫ�ز��Ҿ����������Ƶ�Ԫ������ͬ�ĳ�ʼ������
        /// </summary>
        /// <param name="c"></param>
        public BaseUserAndRoleInfoList(ICollection c)
            : base(c)
        {
            ItemType = typeof(BaseUserAndRoleInfo);
        }

        #endregion
    }
}

