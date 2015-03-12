#region 版本说明
/*****************************************************************************
 * 
 * 项    目 : 
 * 作    者 : 李金坪 
 * 创建时间 : 2014/9/19 17:07:15 
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
using PengeSoft.db;
using IBatisNet.DataAccess;

namespace PengeSoft.CMS.BaseDatum 
{
    /// <summary>
    /// IAttachmentServiceAllSvr 接口定义。    
    /// </summary>
    public interface IAttachmentServiceAllSvr : IApplication
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
        /// <summary>
        /// 添加附件   
        /// </summary>
        void AddAttachment(Attachment item);

        /// <summary>
        /// 删除附件   
        /// </summary>
        void DeleteAttachment(string guid);

        /// <summary>
        /// 删除附件列表   
        /// </summary>
        void DeleteAttachmentList(StringList guidList);

        /// <summary>
        /// 删除附件列表   
        /// </summary>
        void DeleteAttachmentList(AttachmentList attachmentList);

        /// <summary>
        /// 获取附件   
        /// </summary>
        Attachment GetAttachment(string guid);

        /// <summary>
        /// 查询条数   
        /// </summary>
        /// <param name="param">查询条件</param>
        [PublishMethod("param")]
        int QueryAttachmentCount(AttachmentQueryPara param);

        /// <summary>
        /// 查询列表   
        /// </summary>
        /// <param name="param">查询条件</param>
        /// <param name="start">开始位置</param>
        /// <param name="PageSize">页大小</param>
        /// <param name="isAll">摘要参数</param>
        [PublishMethod("param")]
        AttachmentList QueryAttachmentList(AttachmentQueryPara param, int start, int PageSize, bool isAll);

        /// <summary>
        /// 取得 IBatis DaoManager 实例   
        /// </summary>
        IDaoManager GetDaoManager();

        /// <summary>
        /// 分页方法   
        /// </summary>
        IPagedList QueryAttachmentPagedList(AttachmentQueryPara param, int pageSize, int pageIndex, bool isAll);

        /// <summary>
        /// 根据外籍取附件列表
        /// </summary>
        /// <param name="refID"></param>
        /// <returns></returns>
        AttachmentList QueryAttachmentListByRefID(string refID, string fileName);
        AttachmentList QueryAttachmentListByRefIDandType(string refID, string reftype);
        /// <summary>
        /// 修改外键引用
        /// </summary>
        /// <param name="attachment"></param>
        void ModifyAttachmentRef(Attachment attachment, string refID, string refType);

        /// <summary>
        /// 修改外键引用
        /// </summary>
        /// <param name="attachment"></param>
        void ModifyAttachmentListRef(AttachmentList attachmentList, string refID, string refType);

        /// <summary>
        /// 查询是否含有附件
        /// </summary>
        /// <param name="refid"></param>
        /// <returns></returns>
        bool HasAttachment(string refid);

        /// <summary>
        /// 查询附件是否存在
        /// </summary>
        /// <param name="guid"></param>
        /// <returns></returns>
        bool ExistAttachment(string guid);
    }
}
