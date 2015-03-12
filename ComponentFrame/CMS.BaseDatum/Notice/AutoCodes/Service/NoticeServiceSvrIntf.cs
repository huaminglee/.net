#region 版本说明
/*****************************************************************************
 * 
 * 项    目 : 
 * 作    者 : 罗坤 
 * 创建时间 : 2015/1/21 14:12:18 
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
    /// INoticeServiceSvr 接口定义。公告服务    
    /// </summary>
    [PublishName("NoticeService")]
    public interface INoticeServiceSvr : IApplication
    {
        /// <summary>
        /// 发布公告   
        /// </summary>
        /// <param name="uTag">用户登录码</param>
        /// <param name="title">公告标题</param>
        /// <param name="content">公告内容</param>
        /// <param name="author">发布人</param>
        [PublishMethod]
        int Announcement(string uTag, string title, string content, string author);

        /// <summary>
        /// 查询公告详情   
        /// </summary>
        /// <param name="uTag">用户登录码</param>
        /// <param name="Guid">公告编号</param>
        [PublishMethod]
        Notice GetNotice(string uTag, int Guid);

        /// <summary>
        /// 查询公告列表   
        /// </summary>
        /// <param name="uTag">用户登录码</param>
        /// <param name="count">查询条数</param>
        [PublishMethod]
        NoticeList QueryNoticeList(string uTag, int count);

        /// <summary>
        /// 查询公告分页列表   
        /// </summary>
        /// <param name="uTag">用户登录码</param>
        /// <param name="param">查询参数</param>
        /// <param name="pageIndex">页数</param>
        /// <param name="pageSize">页大小</param>
        [PublishMethod]
        NoticeList QueryNoticePageList(string uTag, string param, int pageIndex, int pageSize);

        /// <summary>
        /// 查询公告数量   
        /// </summary>
        /// <param name="uTag">用户登录码</param>
        /// <param name="param">查询参数</param>
        [PublishMethod]
        int QueryNoticeCount(string uTag, string param);

        /// <summary>
        /// 删除公告列表   
        /// </summary>
        /// <param name="uTag">用户登录码</param>
        /// <param name="guidList">公告标识列表</param>
        [PublishMethod]
        void DeleteNoticeList(string uTag, string guidList);

    }
}
