#region �汾˵��
/*****************************************************************************
 * 
 * ��    Ŀ : 
 * ��    �� : ���� 
 * ����ʱ�� : 2015/1/21 14:12:18 
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
    /// INoticeServiceSvr �ӿڶ��塣�������    
    /// </summary>
    [PublishName("NoticeService")]
    public interface INoticeServiceSvr : IApplication
    {
        /// <summary>
        /// ��������   
        /// </summary>
        /// <param name="uTag">�û���¼��</param>
        /// <param name="title">�������</param>
        /// <param name="content">��������</param>
        /// <param name="author">������</param>
        [PublishMethod]
        int Announcement(string uTag, string title, string content, string author);

        /// <summary>
        /// ��ѯ��������   
        /// </summary>
        /// <param name="uTag">�û���¼��</param>
        /// <param name="Guid">������</param>
        [PublishMethod]
        Notice GetNotice(string uTag, int Guid);

        /// <summary>
        /// ��ѯ�����б�   
        /// </summary>
        /// <param name="uTag">�û���¼��</param>
        /// <param name="count">��ѯ����</param>
        [PublishMethod]
        NoticeList QueryNoticeList(string uTag, int count);

        /// <summary>
        /// ��ѯ�����ҳ�б�   
        /// </summary>
        /// <param name="uTag">�û���¼��</param>
        /// <param name="param">��ѯ����</param>
        /// <param name="pageIndex">ҳ��</param>
        /// <param name="pageSize">ҳ��С</param>
        [PublishMethod]
        NoticeList QueryNoticePageList(string uTag, string param, int pageIndex, int pageSize);

        /// <summary>
        /// ��ѯ��������   
        /// </summary>
        /// <param name="uTag">�û���¼��</param>
        /// <param name="param">��ѯ����</param>
        [PublishMethod]
        int QueryNoticeCount(string uTag, string param);

        /// <summary>
        /// ɾ�������б�   
        /// </summary>
        /// <param name="uTag">�û���¼��</param>
        /// <param name="guidList">�����ʶ�б�</param>
        [PublishMethod]
        void DeleteNoticeList(string uTag, string guidList);

    }
}
