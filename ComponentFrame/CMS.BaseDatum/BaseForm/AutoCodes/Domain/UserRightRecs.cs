#region 版本说明
/*****************************************************************************
 * 
 * 项    目 : 
 * 作    者 : 李金坪 
 * 创建时间 : 2015/2/11 13:14:41 
 *
 * Copyright (C) 2008 - 鹏业软件公司
 * 
 *****************************************************************************/
#endregion

using System;
using System.Collections;
using System.Text;
using PengeSoft.Data;
using PengeSoft.WorkZoneData;
using PengeSoft.db;

namespace PengeSoft.CMS.BaseDatum
{
    /// <summary>
    /// UserRightRecs 的摘要说明。
    /// </summary>
    public class UserRightRecs:NorDataList
    {
        #region 构造函数

        /// <summary>
        /// 初始化新实例 
        /// </summary>
        public UserRightRecs()
        {
            ItemType = typeof(UserRightRec);
        }

        /// <summary>
        /// 初始化新实例，该实例包含从指定集合复制的元素并且具有与所复制的元素数相同的初始容量。
        /// </summary>
        /// <param name="c"></param>
        public UserRightRecs(ICollection c)
            : base(c)
        {
            ItemType = typeof(UserRightRec);
        }

        #endregion
    }
}

