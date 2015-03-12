#region 版本说明
/*****************************************************************************
 * 
 * 项    目 : 
 * 作    者 : 李金坪 
 * 创建时间 : 2014/11/18 11:30:07 
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
using PengeSoft.Service.Auther;

namespace PengeSoft.CMS.BaseDatum
{
    /// <summary>
    /// ILayoutInfoServerSvr 接口定义。    
    /// </summary>
    [PublishName("LayoutInfoServer")]
    public interface ILayoutInfoServerSvr : PengeSoft.Service.Auther.IUserAuther
    {
        /// <summary>
        /// 获取用户布局信息  如无相关布局信息则返回默认布局信息 
        /// </summary>
        /// <param name="UserID">用户id</param>
        /// <param name="PageName">页面名称</param>
        /// <param name="RoleName">权限等级</param>
        [PublishMethod]
        LayoutInfo GetUserLayoutinfo(string uTag, string UserID, string PageName, string RoleName);

        /// <summary>
        /// 新增用户布局信息(创建时间传null)   
        /// </summary>
        /// <param name="UserID">用户id</param>
        /// <param name="PageName">页面名称</param>
        /// <param name="MLayoutInfo">布局信息</param>
        [PublishMethod]
        string AddUserLayoutinf(string uTag, string UserID, string PageName, string MLayoutInfo);

        /// <summary>
        /// 更新用户布局信息   
        /// </summary>
        /// <param name="UserID">用户id</param>
        /// <param name="PageName">页面名称</param>
        /// <param name="MLayoutInfo">布局信息</param>
        [PublishMethod]
        string UpdateUserLayoutinf(string uTag, string UserID, string PageName, string MLayoutInfo);
        /// <summary>
        /// 获取布局总数
        /// </summary>
        /// <param name="uTag"></param>
        /// <param name="PageName"></param>
        /// <param name="LayType"></param>
        /// <param name="uID"></param>
        /// <returns></returns>
        [PublishMethod]
        int GetLayoutInfoListCount(string uTag, string PageName, string LayType, string uID);
        /// <summary>
        /// 获取布局模板列表   
        /// </summary>
        /// <param name="PageName">页面名</param>
        /// <param name="LayType">模板类型（布局模板或详细模板）</param>
        /// <param name="uID">用户id</param>
        [PublishMethod]
        LayoutInfoList GetLayoutInfoList(string uTag, string PageName, string LayType, string uID, int currentPage, int PageSize);
        /// <summary>
        /// 获取布局信息
        /// </summary>
        /// <param name="uTag"></param>
        /// <param name="lid"></param>
        /// <returns></returns>
        [PublishMethod]
        LayoutInfo GetUserLayoutinfobyid(string uTag, int lid); 
        /// <summary>
        /// 删除布局信息   
        /// </summary>
        /// <param name="lid"></param>
        [PublishMethod]
        void DelLayputinfo(string uTag, int lid);
    }
}