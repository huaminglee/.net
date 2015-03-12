#region 版本说明
/*****************************************************************************
 * 
 * 项    目 : 
 * 作    者 : 张李波 
 * 创建时间 : 2009-12-4 17:27:03 
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
    /// ITempletServiceSvr 接口定义。模板服务    
    /// </summary>
    [PublishName("TempletService")]
    public interface ITempletServiceSvr : IApplication
    {
        /// <summary>
        /// 添加模板   
        /// </summary>
        void AddTemplet(Templet templet);

        /// <summary>
        /// 修改模板   
        /// </summary>
        void ChangeTemplet(Templet templet);

        /// <summary>
        /// 删除模板   
        /// </summary>
        void DeleteTemplet(string guid);

        /// <summary>
        /// 删除模板列表   
        /// </summary>
        void DeleteTempletList(StringList guidList);

        /// <summary>
        /// 获取模板   
        /// </summary>
        Templet GetTemplet(string guid);

        /// <summary>
        /// 查询条数   
        /// </summary>
        /// <param name="param">条件</param>
        [PublishMethod("param")]
        int QueryTempletCount(TempletQueryPara param);

        /// <summary>
        /// 查询列表   
        /// </summary>
        /// <param name="param">查询条件</param>
        /// <param name="star">开始位置</param>
        /// <param name="PageSize">页大小</param>
        /// <param name="isAll">摘要选项</param>
        [PublishMethod("param")]
        TempletList QueryTempletList(TempletQueryPara param, int star, int PageSize, bool isAll);

        /// <summary>
        /// 查询列表   
        /// </summary>
        /// <param name="param">查询条件</param>
        /// <param name="star">开始位置</param>
        /// <param name="PageSize">页大小</param>
        [PublishMethod("param")]
        TempletList QueryAttudeTempletList(TempletQueryPara param, int star, int PageSize);


        /// <summary>
        /// 取得 IBatis DaoManager 实例   
        /// </summary>
        IDaoManager GetDaoManager();

        /// <summary>
        /// 分页列表   
        /// </summary>
        IPagedList QueryTempletPagedList(TempletQueryPara param, int pageSize, int pageIndex, bool isAll);

        IPagedList QueryTempletPagedListEx(TempletQueryPara param, int pageSize, int pageIndex);

    }
}