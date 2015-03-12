#region �汾˵��
/*****************************************************************************
 * 
 * ��    Ŀ : 
 * ��    �� : ���ƺ 
 * ����ʱ�� : 2014/11/18 11:30:07 
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
using PengeSoft.Service.Auther;

namespace PengeSoft.CMS.BaseDatum
{
    /// <summary>
    /// ILayoutInfoServerSvr �ӿڶ��塣    
    /// </summary>
    [PublishName("LayoutInfoServer")]
    public interface ILayoutInfoServerSvr : PengeSoft.Service.Auther.IUserAuther
    {
        /// <summary>
        /// ��ȡ�û�������Ϣ  ������ز�����Ϣ�򷵻�Ĭ�ϲ�����Ϣ 
        /// </summary>
        /// <param name="UserID">�û�id</param>
        /// <param name="PageName">ҳ������</param>
        /// <param name="RoleName">Ȩ�޵ȼ�</param>
        [PublishMethod]
        LayoutInfo GetUserLayoutinfo(string uTag, string UserID, string PageName, string RoleName);

        /// <summary>
        /// �����û�������Ϣ(����ʱ�䴫null)   
        /// </summary>
        /// <param name="UserID">�û�id</param>
        /// <param name="PageName">ҳ������</param>
        /// <param name="MLayoutInfo">������Ϣ</param>
        [PublishMethod]
        string AddUserLayoutinf(string uTag, string UserID, string PageName, string MLayoutInfo);

        /// <summary>
        /// �����û�������Ϣ   
        /// </summary>
        /// <param name="UserID">�û�id</param>
        /// <param name="PageName">ҳ������</param>
        /// <param name="MLayoutInfo">������Ϣ</param>
        [PublishMethod]
        string UpdateUserLayoutinf(string uTag, string UserID, string PageName, string MLayoutInfo);
        /// <summary>
        /// ��ȡ��������
        /// </summary>
        /// <param name="uTag"></param>
        /// <param name="PageName"></param>
        /// <param name="LayType"></param>
        /// <param name="uID"></param>
        /// <returns></returns>
        [PublishMethod]
        int GetLayoutInfoListCount(string uTag, string PageName, string LayType, string uID);
        /// <summary>
        /// ��ȡ����ģ���б�   
        /// </summary>
        /// <param name="PageName">ҳ����</param>
        /// <param name="LayType">ģ�����ͣ�����ģ�����ϸģ�壩</param>
        /// <param name="uID">�û�id</param>
        [PublishMethod]
        LayoutInfoList GetLayoutInfoList(string uTag, string PageName, string LayType, string uID, int currentPage, int PageSize);
        /// <summary>
        /// ��ȡ������Ϣ
        /// </summary>
        /// <param name="uTag"></param>
        /// <param name="lid"></param>
        /// <returns></returns>
        [PublishMethod]
        LayoutInfo GetUserLayoutinfobyid(string uTag, int lid); 
        /// <summary>
        /// ɾ��������Ϣ   
        /// </summary>
        /// <param name="lid"></param>
        [PublishMethod]
        void DelLayputinfo(string uTag, int lid);
    }
}