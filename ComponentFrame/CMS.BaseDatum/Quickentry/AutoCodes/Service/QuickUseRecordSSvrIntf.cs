#region 版本说明
/*****************************************************************************
 * 
 * 项    目 : 
 * 作    者 : 李金坪 
 * 创建时间 : 2015/1/19 13:56:45 
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
    /// IQuickUseRecordSSvr 接口定义。    
    /// </summary>
    [PublishName("QuickUseRecordS")]
    public interface IQuickUseRecordSSvr : PengeSoft.Service.Auther.IUserAuther
    {
        /// <summary>
        /// 添加使用次数   
        /// </summary>
        /// <param name="Uid">用户id</param>
        /// <param name="Qid">入口id</param>
        [PublishMethod]
        void AddQuickUse(string uTag, string Uid, int Qid, int Qtype);

        /// <summary>
        /// 移除常用   
        /// </summary>
        /// <param name="Uid">用户id</param>
        /// <param name="Qid">入口id</param>
        [PublishMethod]
        void DelQuickUse(string uTag, string Uid, int Qid);

        /// <summary>
        /// 查询常用入口   
        /// </summary>
        /// <param name="Uid">用户id</param>
        /// <param name="Qtype">类型</param>
        /// <param name="QNeedRecords">数量</param>
        [PublishMethod]
        QuickentryList GetUsualQuick(string uTag, string Uid, int Qtype, int QNeedRecords);

    }
}
