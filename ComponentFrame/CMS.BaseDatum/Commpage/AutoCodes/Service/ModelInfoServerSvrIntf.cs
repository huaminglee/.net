#region 版本说明
/*****************************************************************************
 * 
 * 项    目 : 
 * 作    者 : 李金坪 
 * 创建时间 : 2014/11/18 11:29:20 
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
    /// IModelInfoServerSvr 接口定义。    
    /// </summary>
    [PublishName("ModelInfoServer")]
    public interface IModelInfoServerSvr : PengeSoft.Service.Auther.IUserAuther
    {
        /// <summary>
        /// 获取模块总数
        /// </summary>
        /// <param name="uTag">登录标识</param>
        /// <returns></returns>
        [PublishMethod]
        int GetModelCount(string uTag);
        /// <summary>
        /// 获取模块列表
        /// </summary>
        /// <param name="uTag">登录标识</param>
        /// <param name="currentPage">当前页</param>
        /// <param name="PageSize">页大小</param>
        /// <returns></returns>
        [PublishMethod]
        ModelInfoList GetModelList(string uTag, int currentPage, int PageSize);
        /// <summary>
        /// 新增模块
        /// </summary>
        /// <param name="uTag"></param>
        /// <param name="modelInfo"></param>
        /// <returns></returns>
        [PublishMethod]
        int AddModelInfo(string uTag, ModelInfo modelInfo);
        /// <summary>
        /// 删除模块
        /// </summary>
        /// <param name="uTag"></param>
        /// <param name="mId"></param>
        /// <returns></returns>
        [PublishMethod]
        void DelModelInfo(string uTag, int mId);
    }
}