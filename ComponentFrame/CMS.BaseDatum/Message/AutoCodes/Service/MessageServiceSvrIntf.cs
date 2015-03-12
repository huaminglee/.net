#region 版本说明
/*****************************************************************************
 * 
 * 项    目 : 
 * 作    者 : 罗坤 
 * 创建时间 : 2015/1/23 13:13:46 
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
    /// IMessageServiceSvr 接口定义。系统消息服务    
    /// </summary>
    [PublishName("MessageService")]
    public interface IMessageServiceSvr : IApplication
    {
        /// <summary>
        /// 发送消息   
        /// </summary>
        /// <param name="uTag">用户登录码</param>
        /// <param name="Recipients">接收人列表</param>
        /// <param name="Message">消息内容</param>
        [PublishMethod]
        int SendMessage(string uTag, string Recipients, string Message);

        /// <summary>
        /// 获取消息   
        /// </summary>
        /// <param name="uTag">用户登录码</param>
        /// <param name="Guid">消息ID</param>
        [PublishMethod]
        Message GetMessage(string uTag, int Guid);

        /// <summary>
        /// 查询消息总数   
        /// </summary>
        /// <param name="uTag">用户登录码</param>
        /// <param name="StateCode">消息状态码</param>
        [PublishMethod]
        int QueryMessageCount(string uTag, int StateCode);

        /// <summary>
        /// 查询消息分页列表   
        /// </summary>
        /// <param name="uTag">用户登录码</param>
        /// <param name="StateCode">消息状态码</param>
        /// <param name="pageIndex">起始页</param>
        /// <param name="pageSize">页大小</param>
        [PublishMethod]
        MessageList QueryMessagePageList(string uTag, int StateCode, int pageIndex, int pageSize);

        /// <summary>
        /// 标记消息列表   
        /// </summary>
        /// <param name="uTag">用户登录码</param>
        /// <param name="MessageGuids">消息ID列表</param>
        /// <param name="StateCode">消息状态码</param>
        [PublishMethod]
        void MarkMessageList(string uTag, string MessageGuids, int StateCode);

        /// <summary>
        /// 标记消息   
        /// </summary>
        /// <param name="uTag">用户登录码</param>
        /// <param name="Guid">消息ID</param>
        /// <param name="StateCode">消息状态码</param>
        [PublishMethod]
        void MarkMessage(string uTag, int Guid, int StateCode);

        /// <summary>
        /// 删除消息列表   
        /// </summary>
        /// <param name="uTag">用户登录码</param>
        /// <param name="MessageGuids">消息标识列表</param>
        [PublishMethod]
        void DeleteMessageList(string uTag, string MessageGuids);
    }
}
