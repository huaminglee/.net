#region 版本说明
/*****************************************************************************
 * 
 * 项    目 : 
 * 作    者 : 冯兴彬 
 * 创建时间 : 2009-12-15 9:31:48 
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

namespace PengeSoft.CMS.BaseDatum
{
    /// <summary>
    /// PersonalTempletList 人员模板列表的摘要说明。
    /// </summary>
    public class PersonalTempletList:NorDataList 
    {

        #region 构造函数

        /// <summary>
        /// 初始化新实例 
        /// </summary>
        public PersonalTempletList()
        {
          
            ItemType = typeof(PersonalTemplet);
        }

        /// <summary>
        /// 初始化新实例，该实例包含从指定集合复制的元素并且具有与所复制的元素数相同的初始容量。
        /// </summary>
        /// <param name="c"></param>
        public PersonalTempletList(ICollection c)
            : base(c)
        {
           
            ItemType = typeof(PersonalTemplet);
        }

        #endregion
    }
}

