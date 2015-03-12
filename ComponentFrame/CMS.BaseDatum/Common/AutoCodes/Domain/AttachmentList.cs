#region 版本说明
/*****************************************************************************
 * 
 * 项    目 : 
 * 作    者 : 张李波 
 * 创建时间 : 2009-12-1 9:03:26 
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
    /// AttachmentList 的摘要说明。
    /// </summary>
    public class AttachmentList : NorDataList
    {

        #region 构造函数

        /// <summary>
        /// 初始化新实例 
        /// </summary>
        public AttachmentList()
        {
           
            ItemType = typeof(Attachment);
        }

        /// <summary>
        /// 初始化新实例，该实例包含从指定集合复制的元素并且具有与所复制的元素数相同的初始容量。
        /// </summary>
        /// <param name="c"></param>
        public AttachmentList(ICollection c)
            : base(c)
        {
           
            ItemType = typeof(Attachment);
        }

        #endregion
    }
}
