#region 版本说明
/*****************************************************************************
 * 
 * 项    目 : 
 * 作    者 : 李金坪 
 * 创建时间 : 2014/8/22 19:33:46 
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
    /// IDoAttitudeServerSvr 接口定义。    
    /// </summary>
    public interface IDoAttitudeServerSvr : IApplication
    {
        /// <summary>
        /// 获取意见列表   
        /// </summary>
        /// <param name="FormID"></param>
        DoAttitudeList GetListByFormID(string FormID);

        /// <summary>
        /// 添加   
        /// </summary>
        /// <param name="attitude"></param>
        void AddNew(DoAttitude attitude);

        /// <summary>
        /// 删除   
        /// </summary>
        /// <param name="attitude"></param>
        void Delinfo(DoAttitude attitude);

        /// <summary>
        /// 修改   
        /// </summary>
        /// <param name="attitude"></param>
        void Updinfo(DoAttitude attitude);

    }
}