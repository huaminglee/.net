#region 版本说明
/*****************************************************************************
 * 
 * 项    目 : 
 * 作    者 : 李金坪 
 * 创建时间 : 2014/9/19 17:07:10 
 *
 * Copyright (C) 2008 - 鹏业软件公司
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
    /// AttachmentServiceAllSvr实现。    
    /// </summary>
    public class AttachmentServiceAllSvr : ApplicationBase, IAttachmentServiceAllSvr 
    {
        #region 服务描述
        private IDaoManager _daoManager = null;
        private IAttachmentFileDao _AttachmentFileDao = null;
        private IAttachmentDao _AttachmentDao = null;
        public override void FormActionList(AppActionList Acts)
        {
            base.FormActionList(Acts);

            // 添加需发布的功能信息
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

        #region IAttachmentServiceAllSvr 函数
        #region 附件文件 函数

        /// <summary>
        /// 添加附件文件   
        /// </summary>
        /// <param name="item">附件文件对象</param>
        public void AddAttachmentFile(AttachmentFile item)
        {
            item.CreateTime = DateTime.Now;
            _AttachmentFileDao.Insert(item);
        }

        /// <summary>
        /// 删除附件文件   
        /// </summary>
        /// <param name="fileId">附件文件id</param>
        public void DeleteAttachmentFile(string fileId)
        {
            AttachmentFile attachmentFile = new AttachmentFile();
            attachmentFile.FileId = fileId;
            _AttachmentFileDao.Delete(attachmentFile);
        }

        /// <summary>
        /// 获取附件文件   
        /// </summary>
        /// <param name="fileId">附件文件ID</param>
        public AttachmentFile GetAttachmentFile(string fileId)
        {
            AttachmentFile attachmentFile = new AttachmentFile();
            attachmentFile.FileId = fileId;
            return _AttachmentFileDao.GetDetail(attachmentFile) as AttachmentFile;
        }

        /// <summary>
        /// 更新附件（OCR内容）   
        /// </summary>
        /// <param name="item">附件内容对象</param>
        [PublishMethod("item")]
        public void ChangeOCRContent(AttachmentFile item)
        {
            item.IsOCRed = (int)EAttachmentFileIsOCR.Yes;
            _AttachmentFileDao.Update("UpdateAttachmentFileOCRContent", item);
        }

        /// <summary>
        /// 查询附件列表   
        /// </summary>
        /// <param name="param">查询条件</param>
        /// <param name="start">起始记录</param>
        /// <param name="pagesize">页大小</param>
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
        #region 附件信息 函数

        /// <summary>
        /// 添加附件   
        /// </summary>
        public void AddAttachment(Attachment item)
        {
            _AttachmentDao.Insert(item);
        }

        /// <summary>
        /// 删除附件   
        /// </summary>
        public void DeleteAttachment(string guid)
        {
            Attachment item = new Attachment();
            item.AttachmentId = guid;
            _AttachmentDao.Delete(item);
        }

        /// <summary>
        /// 删除附件列表   
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
        /// 删除附件列表   
        /// </summary>
        public void DeleteAttachmentList(AttachmentList attachmentList)
        {
            foreach (Attachment attachment in attachmentList)
            {
                _AttachmentDao.Delete(attachment);
            }
        }

        /// <summary>
        /// 获取附件   
        /// </summary>
        public Attachment GetAttachment(string guid)
        {
            Attachment item = new Attachment();
            item.AttachmentId = guid;

            return _AttachmentDao.GetDetail(item) as Attachment;
        }

        /// <summary>
        /// 查询条数   
        /// </summary>
        /// <param name="param">查询条件</param>
        [PublishMethod("param")]
        public int QueryAttachmentCount(AttachmentQueryPara param)
        {
            return _AttachmentDao.QueryCount(param);
        }

        /// <summary>
        /// 查询列表   
        /// </summary>
        /// <param name="param">查询条件</param>
        /// <param name="start">开始位置</param>
        /// <param name="PageSize">页大小</param>
        /// <param name="isAll">摘要参数</param>
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
        /// 取得 IBatis DaoManager 实例   
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
        /// 分页方法   
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
        /// 根据外键取附件列表
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
        /// 修改外键引用
        /// </summary>
        /// <param name="attachment"></param>
        public void ModifyAttachmentRef(Attachment attachment, string refID, string refType)
        {
            attachment.RefID = refID;
            attachment.RefType = refType;
            _AttachmentDao.Update(attachment);
        }

        /// <summary>
        /// 修改外键引用
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
        /// 查询是否含有附件
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
        /// 查询附件是否存在
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
