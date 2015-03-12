#region 版本说明
/*****************************************************************************
 * 
 * 项    目 : 
 * 作    者 : 李金坪 
 * 创建时间 : 2014/11/18 13:19:20 
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
    /// ISkinServerSvr 接口定义。    
    /// </summary>
    [PublishName("SkinServer")]
    public interface ISkinServerSvr : PengeSoft.Service.Auther.IUserAuther
    {
        /// <summary>
        /// 查询用户皮肤信息   
        /// </summary>
        /// <param name="UserID">用户id</param>
        [PublishMethod]
        SkinInfo GetUserSkinInfo(string uTag, string UserID);

        /// <summary>
        /// 添加用户皮肤信息   
        /// </summary>
        /// <param name="UserID">用户id</param>
        /// <param name="TSkinInfo">皮肤信息</param>
        [PublishMethod]
        string AddUserSkinInfo(string uTag, string UserID, string TSkinInfo);

        /// <summary>
        /// 更新用户皮肤信息   
        /// </summary>
        /// <param name="TSkinInfo">皮肤信息</param>
        /// <param name="UserID">用户id</param>
        [PublishMethod]
        string UpdateUserSkinInfo(string uTag, string TSkinInfo, string UserID);

    }
}