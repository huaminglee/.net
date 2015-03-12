#region �汾˵��
/*****************************************************************************
 * 
 * ��    Ŀ : 
 * ��    �� : ���ƺ 
 * ����ʱ�� : 2014/11/18 13:19:20 
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
    /// ISkinServerSvr �ӿڶ��塣    
    /// </summary>
    [PublishName("SkinServer")]
    public interface ISkinServerSvr : PengeSoft.Service.Auther.IUserAuther
    {
        /// <summary>
        /// ��ѯ�û�Ƥ����Ϣ   
        /// </summary>
        /// <param name="UserID">�û�id</param>
        [PublishMethod]
        SkinInfo GetUserSkinInfo(string uTag, string UserID);

        /// <summary>
        /// ����û�Ƥ����Ϣ   
        /// </summary>
        /// <param name="UserID">�û�id</param>
        /// <param name="TSkinInfo">Ƥ����Ϣ</param>
        [PublishMethod]
        string AddUserSkinInfo(string uTag, string UserID, string TSkinInfo);

        /// <summary>
        /// �����û�Ƥ����Ϣ   
        /// </summary>
        /// <param name="TSkinInfo">Ƥ����Ϣ</param>
        /// <param name="UserID">�û�id</param>
        [PublishMethod]
        string UpdateUserSkinInfo(string uTag, string TSkinInfo, string UserID);

    }
}