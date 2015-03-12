#region �汾˵��
/*****************************************************************************
 * 
 * ��    Ŀ : 
 * ��    �� : ���ƺ 
 * ����ʱ�� : 2014/11/18 11:29:20 
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
    /// IModelInfoServerSvr �ӿڶ��塣    
    /// </summary>
    [PublishName("ModelInfoServer")]
    public interface IModelInfoServerSvr : PengeSoft.Service.Auther.IUserAuther
    {
        /// <summary>
        /// ��ȡģ������
        /// </summary>
        /// <param name="uTag">��¼��ʶ</param>
        /// <returns></returns>
        [PublishMethod]
        int GetModelCount(string uTag);
        /// <summary>
        /// ��ȡģ���б�
        /// </summary>
        /// <param name="uTag">��¼��ʶ</param>
        /// <param name="currentPage">��ǰҳ</param>
        /// <param name="PageSize">ҳ��С</param>
        /// <returns></returns>
        [PublishMethod]
        ModelInfoList GetModelList(string uTag, int currentPage, int PageSize);
        /// <summary>
        /// ����ģ��
        /// </summary>
        /// <param name="uTag"></param>
        /// <param name="modelInfo"></param>
        /// <returns></returns>
        [PublishMethod]
        int AddModelInfo(string uTag, ModelInfo modelInfo);
        /// <summary>
        /// ɾ��ģ��
        /// </summary>
        /// <param name="uTag"></param>
        /// <param name="mId"></param>
        /// <returns></returns>
        [PublishMethod]
        void DelModelInfo(string uTag, int mId);
    }
}