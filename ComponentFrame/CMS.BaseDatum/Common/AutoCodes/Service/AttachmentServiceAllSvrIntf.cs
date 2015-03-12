#region �汾˵��
/*****************************************************************************
 * 
 * ��    Ŀ : 
 * ��    �� : ���ƺ 
 * ����ʱ�� : 2014/9/19 17:07:15 
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
using PengeSoft.db;
using IBatisNet.DataAccess;

namespace PengeSoft.CMS.BaseDatum 
{
    /// <summary>
    /// IAttachmentServiceAllSvr �ӿڶ��塣    
    /// </summary>
    public interface IAttachmentServiceAllSvr : IApplication
    {
        /// <summary>
        /// ��Ӹ����ļ�   
        /// </summary>
        /// <param name="item">�����ļ�����</param>
        void AddAttachmentFile(AttachmentFile item);

        /// <summary>
        /// ɾ�������ļ�   
        /// </summary>
        /// <param name="fileId">�����ļ�id</param>
        void DeleteAttachmentFile(string fileId);

        /// <summary>
        /// ��ȡ�����ļ�   
        /// </summary>
        /// <param name="fileId">�����ļ�ID</param>
        AttachmentFile GetAttachmentFile(string fileId);

        /// <summary>
        /// ���¸�����OCR���ݣ�   
        /// </summary>
        /// <param name="item">�������ݶ���</param>
        [PublishMethod("item")]
        void ChangeOCRContent(AttachmentFile item);

        /// <summary>
        /// ��ѯ�����б�   
        /// </summary>
        /// <param name="param">��ѯ����</param>
        /// <param name="start">��ʼ��¼</param>
        /// <param name="pagesize">ҳ��С</param>
        AttachmentFileList QueryAttachmentFileList(AttachmentFileQueryPara param, int start, int pagesize);
        /// <summary>
        /// ��Ӹ���   
        /// </summary>
        void AddAttachment(Attachment item);

        /// <summary>
        /// ɾ������   
        /// </summary>
        void DeleteAttachment(string guid);

        /// <summary>
        /// ɾ�������б�   
        /// </summary>
        void DeleteAttachmentList(StringList guidList);

        /// <summary>
        /// ɾ�������б�   
        /// </summary>
        void DeleteAttachmentList(AttachmentList attachmentList);

        /// <summary>
        /// ��ȡ����   
        /// </summary>
        Attachment GetAttachment(string guid);

        /// <summary>
        /// ��ѯ����   
        /// </summary>
        /// <param name="param">��ѯ����</param>
        [PublishMethod("param")]
        int QueryAttachmentCount(AttachmentQueryPara param);

        /// <summary>
        /// ��ѯ�б�   
        /// </summary>
        /// <param name="param">��ѯ����</param>
        /// <param name="start">��ʼλ��</param>
        /// <param name="PageSize">ҳ��С</param>
        /// <param name="isAll">ժҪ����</param>
        [PublishMethod("param")]
        AttachmentList QueryAttachmentList(AttachmentQueryPara param, int start, int PageSize, bool isAll);

        /// <summary>
        /// ȡ�� IBatis DaoManager ʵ��   
        /// </summary>
        IDaoManager GetDaoManager();

        /// <summary>
        /// ��ҳ����   
        /// </summary>
        IPagedList QueryAttachmentPagedList(AttachmentQueryPara param, int pageSize, int pageIndex, bool isAll);

        /// <summary>
        /// �����⼮ȡ�����б�
        /// </summary>
        /// <param name="refID"></param>
        /// <returns></returns>
        AttachmentList QueryAttachmentListByRefID(string refID, string fileName);
        AttachmentList QueryAttachmentListByRefIDandType(string refID, string reftype);
        /// <summary>
        /// �޸��������
        /// </summary>
        /// <param name="attachment"></param>
        void ModifyAttachmentRef(Attachment attachment, string refID, string refType);

        /// <summary>
        /// �޸��������
        /// </summary>
        /// <param name="attachment"></param>
        void ModifyAttachmentListRef(AttachmentList attachmentList, string refID, string refType);

        /// <summary>
        /// ��ѯ�Ƿ��и���
        /// </summary>
        /// <param name="refid"></param>
        /// <returns></returns>
        bool HasAttachment(string refid);

        /// <summary>
        /// ��ѯ�����Ƿ����
        /// </summary>
        /// <param name="guid"></param>
        /// <returns></returns>
        bool ExistAttachment(string guid);
    }
}
