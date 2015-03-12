#region �汾˵��
/*****************************************************************************
 * 
 * ��    Ŀ : 
 * ��    �� : ���� 
 * ����ʱ�� : 2015/1/23 13:13:46 
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
    /// IMessageServiceSvr �ӿڶ��塣ϵͳ��Ϣ����    
    /// </summary>
    [PublishName("MessageService")]
    public interface IMessageServiceSvr : IApplication
    {
        /// <summary>
        /// ������Ϣ   
        /// </summary>
        /// <param name="uTag">�û���¼��</param>
        /// <param name="Recipients">�������б�</param>
        /// <param name="Message">��Ϣ����</param>
        [PublishMethod]
        int SendMessage(string uTag, string Recipients, string Message);

        /// <summary>
        /// ��ȡ��Ϣ   
        /// </summary>
        /// <param name="uTag">�û���¼��</param>
        /// <param name="Guid">��ϢID</param>
        [PublishMethod]
        Message GetMessage(string uTag, int Guid);

        /// <summary>
        /// ��ѯ��Ϣ����   
        /// </summary>
        /// <param name="uTag">�û���¼��</param>
        /// <param name="StateCode">��Ϣ״̬��</param>
        [PublishMethod]
        int QueryMessageCount(string uTag, int StateCode);

        /// <summary>
        /// ��ѯ��Ϣ��ҳ�б�   
        /// </summary>
        /// <param name="uTag">�û���¼��</param>
        /// <param name="StateCode">��Ϣ״̬��</param>
        /// <param name="pageIndex">��ʼҳ</param>
        /// <param name="pageSize">ҳ��С</param>
        [PublishMethod]
        MessageList QueryMessagePageList(string uTag, int StateCode, int pageIndex, int pageSize);

        /// <summary>
        /// �����Ϣ�б�   
        /// </summary>
        /// <param name="uTag">�û���¼��</param>
        /// <param name="MessageGuids">��ϢID�б�</param>
        /// <param name="StateCode">��Ϣ״̬��</param>
        [PublishMethod]
        void MarkMessageList(string uTag, string MessageGuids, int StateCode);

        /// <summary>
        /// �����Ϣ   
        /// </summary>
        /// <param name="uTag">�û���¼��</param>
        /// <param name="Guid">��ϢID</param>
        /// <param name="StateCode">��Ϣ״̬��</param>
        [PublishMethod]
        void MarkMessage(string uTag, int Guid, int StateCode);

        /// <summary>
        /// ɾ����Ϣ�б�   
        /// </summary>
        /// <param name="uTag">�û���¼��</param>
        /// <param name="MessageGuids">��Ϣ��ʶ�б�</param>
        [PublishMethod]
        void DeleteMessageList(string uTag, string MessageGuids);
    }
}
