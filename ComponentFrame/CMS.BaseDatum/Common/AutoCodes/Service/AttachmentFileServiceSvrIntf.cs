#region 版本说明
/*****************************************************************************
 * 
 * 项    目 : 
 * 作    者 : 陈锐(开发) 
 * 创建时间 : 2010-4-27 下午 01:23:18 
 *
 * Copyright (C) 2008 - 鹏业软件公司
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
    /// IAttachmentFileServiceSvr 接口定义。附件文件服务    
    /// </summary>
    public interface IAttachmentFileServiceSvr : IApplication
    {
        /// <summary>
        /// 添加附件文件   
        /// </summary>
        /// <param name="item">附件文件对象</param>
        void AddAttachmentFile(AttachmentFile item);

        /// <summary>
        /// 删除附件文件   
        /// </summary>
        /// <param name="fileId">附件文件id</param>
        void DeleteAttachmentFile(string fileId);

        /// <summary>
        /// 获取附件文件   
        /// </summary>
        /// <param name="fileId">附件文件ID</param>
        AttachmentFile GetAttachmentFile(string fileId);

        /// <summary>
        /// 更新附件（OCR内容）   
        /// </summary>
        /// <param name="item">附件内容对象</param>
        [PublishMethod("item")]
        void ChangeOCRContent(AttachmentFile item);

        /// <summary>
        /// 查询附件列表   
        /// </summary>
        /// <param name="param">查询条件</param>
        /// <param name="start">起始记录</param>
        /// <param name="pagesize">页大小</param>
        AttachmentFileList QueryAttachmentFileList(AttachmentFileQueryPara param, int start, int pagesize);
    }
}