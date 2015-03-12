#region 版本说明
/*****************************************************************************
 * 
 * 项    目 : 
 * 作    者 : 李金坪 
 * 创建时间 : 2014/8/22 17:27:00 
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
using PengeSoft.db;

namespace PengeSoft.CMS.BaseDatum
{
    /// <summary>
    /// IBaseFormDataServerSvr 接口定义。    
    /// </summary>
    public interface IBaseFormDataServerSvr : IApplication
    {
        /// <summary>
        /// 获取意见列表   
        /// </summary>
        /// <param name="FormID">表单ID</param>
        DoAttitudeList GetAttitudelist(string FormID);

        /// <summary>
        /// 获取附件列表   
        /// </summary>
        /// <param name="FormID">表单ID</param>
        AttachmentList GetAttachments(string FormID, string reftype);

        /// <summary>
        /// 查询信息   
        /// </summary>
        /// <param name="FormID"></param>
        BaseFormData GetinfoByID(string FormID);

        /// <summary>
        /// 添加   
        /// </summary>
        /// <param name="baseforminfo"></param>
        void AddNewInfo(BaseFormData baseforminfo);

        /// <summary>
        /// 修改   
        /// </summary>
        /// <param name="baseforminfo"></param>
        int UpdateInfo(string baseformid ,BaseFormData baseforminfo);

        /// <summary>
        /// 删除   
        /// </summary>
        /// <param name="baseforminfo"></param>
        void DelInfo(string baseformid);

        /// <summary>
        /// 查询列表   
        /// </summary>
        /// <param name="para">参数</param>
        /// <param name="start"></param>
        /// <param name="pagesize"></param>
        /// <param name="iswithattachment"></param>
        IPagedList GetBaseForminfoList(BaseFormDataQueryPara para, int start, int pagesize);
        /// <summary>
        /// 查记录数
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        int QueryListCount(BaseFormDataQueryPara param);
        IPagedList GetBaseForminfoListex(BaseFormDataQueryPara para, int start, int pagesize);

        BaseFormData GetinfoByWorkID(string workID);
        /// <summary>
        /// 查询收藏夹公文
        /// </summary>
        /// <param name="param"></param>
        /// <param name="pageSize"></param>
        /// <param name="pageIndex"></param>
        /// <returns></returns>
        IPagedList QueryBasePagedListInFavorite(QueryParameter param, int pageSize, int pageIndex);
        /// <summary>
        /// 添加处理意见
        /// </summary>
        /// <param name="doattitude"></param>
        void AddAttitude(DoAttitude doattitude);
    }
}