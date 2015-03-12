#region �汾˵��
/*****************************************************************************
 * 
 * ��    Ŀ : 
 * ��    �� : ���ƺ 
 * ����ʱ�� : 2014/9/19 17:07:10 
 *
 * Copyright (C) 2008 - ��ҵ�����˾
 * 
 *****************************************************************************/
#endregion

/*
      <!---->
      <component id="AttachmentServiceAllSvr" type="PengeSoft.CMS.BaseDatum.AttachmentServiceAllSvr, PengeSoft.CMS.BaseDatum" service="PengeSoft.CMS.BaseDatum.IAttachmentServiceAllSvr, PengeSoft.CMS.BaseDatum" lifestyle="Singleton">
        <parameters>
        </parameters>
      </component>
*/
using System;
using System.Collections;
using System.Text;
using Castle.Windsor;
using PengeSoft.Data;
using PengeSoft.Enterprise.Appication;
using PengeSoft.WorkZoneData;
using PengeSoft.Common.Exceptions;
using PengeSoft.Auther.RightCheck;
using PengeSoft.Service;
using IBatisNet.DataAccess;
using PengeSoft.db.IBatis;
using PengeSoft.db;

namespace PengeSoft.CMS.BaseDatum 
{
    /// <summary>
    /// AttachmentServiceAllSvrʵ�֡�    
    /// </summary>
    public class AttachmentServiceAllSvr : ApplicationBase, IAttachmentServiceAllSvr 
    {
        #region ��������
        private IDaoManager _daoManager = null;
        private IAttachmentFileDao _AttachmentFileDao = null;
        private IAttachmentDao _AttachmentDao = null;
        public override void FormActionList(AppActionList Acts)
        {
            base.FormActionList(Acts);

            // ����跢���Ĺ�����Ϣ
        }

        public override void FormAttribsRec(PengeSoft.WorkZoneData.AppAttribBaseRec attr)
        {
            base.FormAttribsRec(attr);

            attr.Detail = "";
        }
        public AttachmentServiceAllSvr()
        {
            _daoManager = ServiceConfig.GetInstance().DaoManager;
            _AttachmentFileDao = (IAttachmentFileDao)_daoManager.GetDao(typeof(IAttachmentFileDao));
            _AttachmentDao = (IAttachmentDao)_daoManager.GetDao(typeof(IAttachmentDao));

        }
        #endregion

        #region IAttachmentServiceAllSvr ����
        #region �����ļ� ����

        /// <summary>
        /// ��Ӹ����ļ�   
        /// </summary>
        /// <param name="item">�����ļ�����</param>
        public void AddAttachmentFile(AttachmentFile item)
        {
            item.CreateTime = DateTime.Now;
            _AttachmentFileDao.Insert(item);
        }

        /// <summary>
        /// ɾ�������ļ�   
        /// </summary>
        /// <param name="fileId">�����ļ�id</param>
        public void DeleteAttachmentFile(string fileId)
        {
            AttachmentFile attachmentFile = new AttachmentFile();
            attachmentFile.FileId = fileId;
            _AttachmentFileDao.Delete(attachmentFile);
        }

        /// <summary>
        /// ��ȡ�����ļ�   
        /// </summary>
        /// <param name="fileId">�����ļ�ID</param>
        public AttachmentFile GetAttachmentFile(string fileId)
        {
            AttachmentFile attachmentFile = new AttachmentFile();
            attachmentFile.FileId = fileId;
            return _AttachmentFileDao.GetDetail(attachmentFile) as AttachmentFile;
        }

        /// <summary>
        /// ���¸�����OCR���ݣ�   
        /// </summary>
        /// <param name="item">�������ݶ���</param>
        [PublishMethod("item")]
        public void ChangeOCRContent(AttachmentFile item)
        {
            item.IsOCRed = (int)EAttachmentFileIsOCR.Yes;
            _AttachmentFileDao.Update("UpdateAttachmentFileOCRContent", item);
        }

        /// <summary>
        /// ��ѯ�����б�   
        /// </summary>
        /// <param name="param">��ѯ����</param>
        /// <param name="start">��ʼ��¼</param>
        /// <param name="pagesize">ҳ��С</param>
        public AttachmentFileList QueryAttachmentFileList(AttachmentFileQueryPara param, int start, int pagesize)
        {
            DataList rec = null;
            rec = _AttachmentFileDao.QueryList(param, start, pagesize);
            AttachmentFileList list = new AttachmentFileList();
            if (rec != null)
                list.AddFrom(rec);
            return list;
        }

        #endregion
        #region ������Ϣ ����

        /// <summary>
        /// ��Ӹ���   
        /// </summary>
        public void AddAttachment(Attachment item)
        {
            _AttachmentDao.Insert(item);
        }

        /// <summary>
        /// ɾ������   
        /// </summary>
        public void DeleteAttachment(string guid)
        {
            Attachment item = new Attachment();
            item.AttachmentId = guid;
            _AttachmentDao.Delete(item);
        }

        /// <summary>
        /// ɾ�������б�   
        /// </summary>
        public void DeleteAttachmentList(StringList guidList)
        {
            foreach (string strguid in guidList)
            {
                Attachment item = new Attachment();
                item.AttachmentId = strguid;
                _AttachmentDao.Delete(item);
            }
        }

        /// <summary>
        /// ɾ�������б�   
        /// </summary>
        public void DeleteAttachmentList(AttachmentList attachmentList)
        {
            foreach (Attachment attachment in attachmentList)
            {
                _AttachmentDao.Delete(attachment);
            }
        }

        /// <summary>
        /// ��ȡ����   
        /// </summary>
        public Attachment GetAttachment(string guid)
        {
            Attachment item = new Attachment();
            item.AttachmentId = guid;

            return _AttachmentDao.GetDetail(item) as Attachment;
        }

        /// <summary>
        /// ��ѯ����   
        /// </summary>
        /// <param name="param">��ѯ����</param>
        [PublishMethod("param")]
        public int QueryAttachmentCount(AttachmentQueryPara param)
        {
            return _AttachmentDao.QueryCount(param);
        }

        /// <summary>
        /// ��ѯ�б�   
        /// </summary>
        /// <param name="param">��ѯ����</param>
        /// <param name="start">��ʼλ��</param>
        /// <param name="PageSize">ҳ��С</param>
        /// <param name="isAll">ժҪ����</param>
        [PublishMethod("param")]
        public AttachmentList QueryAttachmentList(AttachmentQueryPara param, int start, int PageSize, bool isAll)
        {
            AttachmentList list = new AttachmentList();
            DataList datalist;

            if (isAll)
                datalist = QueryListAll(param, start, PageSize);
            else
                datalist = QueryListDetail(param, start, PageSize);
            list.AddFrom(datalist);

            return list;
        }

        /// <summary>
        /// ȡ�� IBatis DaoManager ʵ��   
        /// </summary>
        public IDaoManager GetDaoManager()
        {
            return _daoManager;
        }

        private DataList QueryListAll(Hashtable param, int start, int pageSize)
        {
            return _AttachmentDao.QueryList(param, start, pageSize, true);
        }


        private DataList QueryListDetail(Hashtable param, int start, int pageSize)
        {
            return _AttachmentDao.QueryList(param, start, pageSize, false);
        }



        /// <summary>
        /// ��ҳ����   
        /// </summary>
        public IPagedList QueryAttachmentPagedList(AttachmentQueryPara param, int pageSize, int pageIndex, bool isAll)
        {
            if (isAll)
            {
                return new PagedDataList(QueryListAll, _AttachmentDao.QueryCount, param, pageSize, pageIndex);
            }
            else
            {
                return new PagedDataList(QueryListDetail, _AttachmentDao.QueryCount, param, pageSize, pageIndex);
            }
        }

        /// <summary>
        /// �������ȡ�����б�
        /// </summary>
        /// <param name="refID"></param>
        /// <returns></returns>
        public AttachmentList QueryAttachmentListByRefID(string refID, string fileName)
        {
            AttachmentQueryPara param = new AttachmentQueryPara();
            param.SetRefID(refID);

            if (!string.IsNullOrEmpty(fileName))
                param.SetFileName("%" + fileName + "%");
            param.SetOrderByField(AttachmentQueryPara.OrderByCreateTime);

            AttachmentList list = new AttachmentList();

            DataList dataList = _AttachmentDao.QueryList(param, 0, -1, false);
            list.XMLText = dataList.XMLText;
            return list;
        }
        public AttachmentList QueryAttachmentListByRefIDandType(string refID, string reftype)
        {
            AttachmentQueryPara param = new AttachmentQueryPara();
            param.SetRefID(refID);
            param.SetRefType(reftype);
            param.SetOrderByField(AttachmentQueryPara.OrderByCreateTime);

            AttachmentList list = new AttachmentList();

            DataList dataList = _AttachmentDao.QueryList(param, 0, -1, false);
            list.XMLText = dataList.XMLText;
            return list;
        }

        /// <summary>
        /// �޸��������
        /// </summary>
        /// <param name="attachment"></param>
        public void ModifyAttachmentRef(Attachment attachment, string refID, string refType)
        {
            attachment.RefID = refID;
            attachment.RefType = refType;
            _AttachmentDao.Update(attachment);
        }

        /// <summary>
        /// �޸��������
        /// </summary>
        /// <param name="attachment"></param>
        public void ModifyAttachmentListRef(AttachmentList attachmentList, string refID, string refType)
        {
            foreach (Attachment attachment in attachmentList)
            {
                ModifyAttachmentRef(attachment, refID, refType);
            }
        }

        /// <summary>
        /// ��ѯ�Ƿ��и���
        /// </summary>
        /// <param name="refid"></param>
        /// <returns></returns>
        public bool HasAttachment(string refid)
        {
            Hashtable table = new Hashtable();
            table.Add("value", refid);
            return _AttachmentDao.QueryCount("HasAttachment", table) > 0;
        }

        /// <summary>
        /// ��ѯ�����Ƿ����
        /// </summary>
        /// <param name="guid"></param>
        /// <returns></returns>
        public bool ExistAttachment(string guid)
        {
            AttachmentQueryPara para = new AttachmentQueryPara();
            para.SetAttachmentId(guid);
            return _AttachmentDao.QueryCount(para) > 0;
        }

        #endregion

        #endregion
    }
}
