#region �汾˵��
/*****************************************************************************
 * 
 * ��    Ŀ : 
 * ��    �� : ���˱� 
 * ����ʱ�� : 2010-5-13 14:41:51 
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

namespace PengeSoft.CMS.BaseDatum
{
    /// <summary>
    /// AttachmentFileList ��ժҪ˵����
    /// </summary>
    public class AttachmentFileList:NorDataList 
    {

        #region ���캯��

        /// <summary>
        /// ��ʼ����ʵ�� 
        /// </summary>
        public AttachmentFileList()
        {
            ItemType = typeof(AttachmentFile);
        }

        /// <summary>
        /// ��ʼ����ʵ������ʵ��������ָ�����ϸ��Ƶ�Ԫ�ز��Ҿ����������Ƶ�Ԫ������ͬ�ĳ�ʼ������
        /// </summary>
        /// <param name="c"></param>
        public AttachmentFileList(ICollection c)
            : base(c)
        {
            ItemType = typeof(AttachmentFile);
        }

        #endregion
    }
}

