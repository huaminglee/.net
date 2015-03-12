#region 版本说明
/*****************************************************************************
 * 
 * 项    目 : 
 * 作    者 : 李金坪 
 * 创建时间 : 2015/1/19 13:56:42 
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
    /// IQuickentrySSvr 接口定义。    
    /// </summary>
    [PublishName("QuickentryS")]
    public interface IQuickentrySSvr : PengeSoft.Service.Auther.IUserAuther
    {
        /// <summary>
        /// 新增入口   
        /// </summary>
        /// <param name="Quickentry">入口对象</param>
        [PublishMethod("Quickentry")]
        void AddQuickentry(string uTag, string QName, String QRemark, string QPico, string QTarget, int DefaultSort, int QType);

        /// <summary>
        /// 修改入口   
        /// </summary>
        /// <param name="Qid">入口id</param>
        /// <param name="QuickentryInfo">入口对象</param>
        [PublishMethod("QuickentryInfo")]
        void UpdateQuickentry(string uTag, int Qid, string QName, String QRemark, string QPico, string QTarget, int DefaultSort, int QType);

        /// <summary>
        /// 删除   
        /// </summary>
        /// <param name="Qid">入口id</param>
        [PublishMethod]
        void DelQuickentry(string uTag, int Qid);

        /// <summary>
        /// 查询默认列表   
        /// </summary>
        /// <param name="Qtype">入口类型</param>
        /// <param name="NeedRecords">条数</param>
        [PublishMethod]
        QuickentryList GetDefaultList(string uTag, int Qtype, int NeedRecords, int[] qids);

    }
}
