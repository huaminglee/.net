#region �汾˵��
/*****************************************************************************
 * 
 * ��    Ŀ : 
 * ��    �� : ���ƺ 
 * ����ʱ�� : 2015/1/19 13:56:45 
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
    /// IQuickUseRecordSSvr �ӿڶ��塣    
    /// </summary>
    [PublishName("QuickUseRecordS")]
    public interface IQuickUseRecordSSvr : PengeSoft.Service.Auther.IUserAuther
    {
        /// <summary>
        /// ���ʹ�ô���   
        /// </summary>
        /// <param name="Uid">�û�id</param>
        /// <param name="Qid">���id</param>
        [PublishMethod]
        void AddQuickUse(string uTag, string Uid, int Qid, int Qtype);

        /// <summary>
        /// �Ƴ�����   
        /// </summary>
        /// <param name="Uid">�û�id</param>
        /// <param name="Qid">���id</param>
        [PublishMethod]
        void DelQuickUse(string uTag, string Uid, int Qid);

        /// <summary>
        /// ��ѯ�������   
        /// </summary>
        /// <param name="Uid">�û�id</param>
        /// <param name="Qtype">����</param>
        /// <param name="QNeedRecords">����</param>
        [PublishMethod]
        QuickentryList GetUsualQuick(string uTag, string Uid, int Qtype, int QNeedRecords);

    }
}
