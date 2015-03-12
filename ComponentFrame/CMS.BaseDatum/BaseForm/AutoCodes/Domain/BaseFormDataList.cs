#region 版本说明
/*****************************************************************************
 * 
 * 项    目 : 
 * 作    者 : 李金坪 
 * 创建时间 : 2014/8/22 17:06:33 
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
    /// BaseFormDataList 的摘要说明。
    /// </summary>
    public class BaseFormDataList : NorDataList
    {
        #region 构造函数

        /// <summary>
        /// 初始化新实例 
        /// </summary>
        public BaseFormDataList()
        {
            ItemType = typeof(BaseFormData);
        }

        /// <summary>
        /// 初始化新实例，该实例包含从指定集合复制的元素并且具有与所复制的元素数相同的初始容量。
        /// </summary>
        /// <param name="c"></param>
        public BaseFormDataList(ICollection c)
            : base(c)
        {
            ItemType = typeof(BaseFormData);
        }

        #endregion
    }
}
