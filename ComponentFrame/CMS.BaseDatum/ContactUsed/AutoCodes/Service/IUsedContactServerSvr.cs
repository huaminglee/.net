#region 版本说明
/*****************************************************************************
 * 
 * 项    目 : 
 * 作    者 : 李金坪 
 * 创建时间 : 2014/9/19 17:37:20 
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
    /// IUsedContactServerSvr 接口定义。    
    /// </summary>
    public interface IUsedContactServerSvr : IApplication
    {
        /// <summary>
        /// 添加记录   
        /// </summary>
        /// <param name="COwner">所有人</param>
        /// <param name="ContactUserID">联系人ID</param>
        /// <param name="ContactUserXM">联系人姓名</param>
        /// <param name="TaskName">任务名称</param>
        /// <param name="StepName">步骤名称</param>
        /// <param name="UseTimes">次数</param>
        /// <param name="Ctype">类型：1人员，2部门</param>
        void AddRecord(string COwner, string ContactUserID, string ContactUserXM, string TaskName, string StepName,int Ctype);
        /// <summary>
        /// 获取常用联系人   
        /// </summary>
        /// <param name="Cowner">所有人</param>
        /// <param name="TaskName">任务名</param>
        /// <param name="StepName">步骤名</param>
        UseContactList GetContactsList(string Cowner, string TaskName, string StepName);

    }
}