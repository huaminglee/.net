#region 版本说明
/*****************************************************************************
 * 
 * 项    目 : 
 * 作    者 : 张李波 
 * 创建时间 : 2009-12-4 16:34:46 
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
using IBatisNet.DataAccess;
using PengeSoft.db;

namespace PengeSoft.CMS.BaseDatum
{
    /// <summary>
    /// IAttachmentServiceSvr 接口定义。附件服务    
    /// </summary>
    [PublishName("AttachmentService")]
    public interface IAttachmentServiceSvr : IApplication
    {
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