#region 版本说明
/*****************************************************************************
 * 
 * 项    目 : 
 * 作    者 : 冯兴彬 
 * 创建时间 : 2010-5-13 14:41:51 
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
    /// AttachmentFileList 的摘要说明。
    /// </summary>
    public class AttachmentFileList:NorDataList 
    {

        #region 构造函数

        /// <summary>
        /// 初始化新实例 
        /// </summary>
        public AttachmentFileList()
        {
            ItemType = typeof(AttachmentFile);
        }

        /// <summary>
        /// 初始化新实例，该实例包含从指定集合复制的元素并且具有与所复制的元素数相同的初始容量。
        /// </summary>
        /// <param name="c"></param>
        public AttachmentFileList(ICollection c)
            : base(c)
        {
            ItemType = typeof(AttachmentFile);
        }

        #endregion
    }
}

