#region �汾˵��
/*****************************************************************************
 * 
 * ��    Ŀ : 
 * ��    �� : ���˱� 
 * ����ʱ�� : 2009-12-15 9:31:48 
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
    /// PersonalTempletList ��Աģ���б��ժҪ˵����
    /// </summary>
    public class PersonalTempletList:NorDataList 
    {

        #region ���캯��

        /// <summary>
        /// ��ʼ����ʵ�� 
        /// </summary>
        public PersonalTempletList()
        {
          
            ItemType = typeof(PersonalTemplet);
        }

        /// <summary>
        /// ��ʼ����ʵ������ʵ��������ָ�����ϸ��Ƶ�Ԫ�ز��Ҿ����������Ƶ�Ԫ������ͬ�ĳ�ʼ������
        /// </summary>
        /// <param name="c"></param>
        public PersonalTempletList(ICollection c)
            : base(c)
        {
           
            ItemType = typeof(PersonalTemplet);
        }

        #endregion
    }
}

