#region 版本说明
/*****************************************************************************
 * 
 * 项    目 : 
 * 作    者 : 陈锐(开发) 
 * 创建时间 : 2010-4-27 下午 01:23:35 
 *
 * Copyright (C) 2008 - 鹏业软件公司
 * 
 *****************************************************************************/
#endregion

/*
      <!---->
      <component id="AttachmentFileServiceSvr" type="PengeSoft.CMS.BaseDatum.AttachmentFileServiceSvr, PengeSoft.CMS.BaseDatum" service="CMS.BaseDatum.IAttachmentFileServiceSvr, CMS.BaseDatum" lifestyle="Singleton">
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
using PengeSoft.db.IBatis;
using IBatisNet.DataAccess;

namespace PengeSoft.CMS.BaseDatum
{
    /// <summary>
    /// AttachmentFileServiceSvr实现。附件文件服务    
    /// </summary>
    public class AttachmentFileServiceSvr : ApplicationBase, IAttachmentFileServiceSvr
    {
        #region 服务描述


        private IDaoManager _daoManager = null;
        private IAttachmentFileDao _AttachmentFileDao = null;

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

        public AttachmentFileServiceSvr()
        {
            _daoManager = ServiceConfig.GetInstance().DaoManager;
            _AttachmentFileDao = (IAttachmentFileDao)_daoManager.GetDao(typeof(IAttachmentFileDao));
        }

        #endregion

        #region IAttachmentFileServiceSvr 函数

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
            rec=  _AttachmentFileDao.QueryList(param, start, pagesize);
            AttachmentFileList list = new AttachmentFileList();
            if (rec != null)
                list.AddFrom(rec);
            return list;
        }

        #endregion
    }
}