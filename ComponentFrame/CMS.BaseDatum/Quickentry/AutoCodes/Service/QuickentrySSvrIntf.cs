#region �汾˵��
/*****************************************************************************
 * 
 * ��    Ŀ : 
 * ��    �� : ���ƺ 
 * ����ʱ�� : 2015/1/19 13:56:42 
 *
 * Copyright (C) 2008 - ��ҵ�����˾
 * 
 *****************************************************************************/
#endregion

using System;
using System.Collections;
using System.Text;
using PengeSoft.Data;
using PengeSoft.Enterprise.Appication;
using PengeSoft.WorkZoneData;
using PengeSoft.Service;

namespace PengeSoft.CMS.BaseDatum 
{
    /// <summary>
    /// IQuickentrySSvr �ӿڶ��塣    
    /// </summary>
    [PublishName("QuickentryS")]
    public interface IQuickentrySSvr : PengeSoft.Service.Auther.IUserAuther
    {
        /// <summary>
        /// �������   
        /// </summary>
        /// <param name="Quickentry">��ڶ���</param>
        [PublishMethod("Quickentry")]
        void AddQuickentry(string uTag, string QName, String QRemark, string QPico, string QTarget, int DefaultSort, int QType);

        /// <summary>
        /// �޸����   
        /// </summary>
        /// <param name="Qid">���id</param>
        /// <param name="QuickentryInfo">��ڶ���</param>
        [PublishMethod("QuickentryInfo")]
        void UpdateQuickentry(string uTag, int Qid, string QName, String QRemark, string QPico, string QTarget, int DefaultSort, int QType);

        /// <summary>
        /// ɾ��   
        /// </summary>
        /// <param name="Qid">���id</param>
        [PublishMethod]
        void DelQuickentry(string uTag, int Qid);

        /// <summary>
        /// ��ѯĬ���б�   
        /// </summary>
        /// <param name="Qtype">�������</param>
        /// <param name="NeedRecords">����</param>
        [PublishMethod]
        QuickentryList GetDefaultList(string uTag, int Qtype, int NeedRecords, int[] qids);

    }
}
