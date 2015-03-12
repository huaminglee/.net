#region 版本说明
/*****************************************************************************
 * 
 * 项    目 : 
 * 作    者 : 李金坪 
 * 创建时间 : 2014/8/22 17:27:20 
 *
 * Copyright (C) 2008 - 鹏业软件公司
 * 
 *****************************************************************************/
#endregion

/*
      <!---->
      <component id="BaseFormDataServerSvr" type="PengeSoft.CMS.BaseDatum.BaseFormDataServerSvr, PengeSoft.CMS.BaseDatum" service="PengeSoft.CMS.BaseDatum.IBaseFormDataServerSvr, PengeSoft.CMS.BaseDatum" lifestyle="Singleton">
        <parameters>
        </parameters>
      </component>
*/
using System;
using System.Collections;
using System.Text;
using Castle.Windsor;
using PengeSoft.Data;
using PengeSoft.Enterprise.Appication;
using PengeSoft.WorkZoneData;
using PengeSoft.Common.Exceptions;
using PengeSoft.Auther.RightCheck;
using PengeSoft.Service;
using PengeSoft.db;
using IBatisNet.DataAccess;
using PengeSoft.db.IBatis;

namespace PengeSoft.CMS.BaseDatum
{
    /// <summary>
    /// BaseFormDataServerSvr实现。    
    /// </summary>
    public class BaseFormDataServerSvr : ApplicationBase, IBaseFormDataServerSvr
    {
        protected IDaoManager _daoManager = null;
        protected IDoAttitudeServerSvr _Doattitudesvr;
        protected IAttachmentServiceAllSvr _AttachmentServiceSvr = null;
        private IBaseFormDataDao _BaseFormdao;
        public BaseFormDataServerSvr(IDoAttitudeServerSvr iDoAttitudeServerSvr, IAttachmentServiceAllSvr attachmentServiceSvr)
        {

            _Doattitudesvr = iDoAttitudeServerSvr;
            _AttachmentServiceSvr = attachmentServiceSvr;
            _daoManager = ServiceConfig.GetInstance().DaoManager;
            _BaseFormdao = (IBaseFormDataDao)_daoManager.GetDao(typeof(IBaseFormDataDao));

        }
        #region 服务描述

        public override void FormActionList(AppActionList Acts)
        {
            base.FormActionList(Acts);

            // 添加需发布的功能信息
        }

        public override void FormAttribsRec(PengeSoft.WorkZoneData.AppAttribBaseRec attr)
        {
            base.FormAttribsRec(attr);

            attr.Detail = "";
        }

        #endregion

        #region IBaseFormDataServerSvr 函数

        /// <summary>
        /// 获取意见列表   
        /// </summary>
        /// <param name="FormID">表单ID</param>
        public DoAttitudeList GetAttitudelist(string FormID)
        {
            return _Doattitudesvr.GetListByFormID(FormID);
        }

        /// <summary>
        /// 获取附件列表   
        /// </summary>
        /// <param name="FormID">表单ID</param>
        public AttachmentList GetAttachments(string FormID,string reftype)
        {
            return _AttachmentServiceSvr.QueryAttachmentListByRefIDandType(FormID, reftype);
        }

        /// <summary>
        /// 查询信息   
        /// </summary>
        /// <param name="FormID"></param>
        public BaseFormData GetinfoByID(string formID)
        {
            BaseFormData baseforminfo = _BaseFormdao.GetDetail(new BaseFormData() { FormID = formID }) as BaseFormData;
            if (baseforminfo != null)
            {
                baseforminfo.Attitudes = _Doattitudesvr.GetListByFormID(formID);
                baseforminfo.Attachments = _AttachmentServiceSvr.QueryAttachmentListByRefIDandType(formID, "oa_archive");
                if (baseforminfo.Attachments == null)
                {
                    baseforminfo.Attachments = new AttachmentList();
                }
                return baseforminfo;
            }
            return null;
        }
        public BaseFormData GetinfoByWorkID(string workID)
        {
            BaseFormData baseforminfo = _BaseFormdao.GetDetail("GetDetailByWorkID", new BaseFormData() { WorkID = workID }) as BaseFormData;
            return baseforminfo;
        }

        /// <summary>
        /// 添加   
        /// </summary>
        /// <param name="baseforminfo"></param>
        public void AddNewInfo(BaseFormData baseforminfo)
        {
            _BaseFormdao.Insert(baseforminfo);
        }

        /// <summary>
        /// 修改   
        /// </summary>
        /// <param name="baseforminfo"></param>
        public int UpdateInfo(string baseformid, BaseFormData baseforminfo)
        {
            baseforminfo.FormID = baseformid;
            return _BaseFormdao.Update(baseforminfo);
        }

        /// <summary>
        /// 删除   
        /// </summary>
        /// <param name="baseforminfo"></param>
        public void DelInfo(string  baseformid)
        {
            BaseFormData baseforminfo = new BaseFormData();
            baseforminfo.FormID = baseformid;
            _BaseFormdao.Delete(baseforminfo);
        }

        /// <summary>
        /// 查询列表   
        /// </summary>
        /// <param name="para">参数</param>
        /// <param name="start"></param>
        /// <param name="pagesize"></param>
        /// <param name="iswithattachment"></param>
        public IPagedList GetBaseForminfoList(BaseFormDataQueryPara para, int start, int pagesize)
        {
            IDataProviderEx dao = _BaseFormdao;
            if (dao != null)
            {
                return new PagedDataList(QueryListDetail, dao.QueryCount, para, pagesize, start);
            }
            return null;
        }
        public IPagedList GetBaseForminfoListex(BaseFormDataQueryPara para, int start, int pagesize)
        {
            IDataProviderEx dao = _BaseFormdao;
            if (dao != null)
            {
                return new PagedDataList(QuertListDetailex, QueryListCountex, para, pagesize, start);
            }
            return null;
        }

        public int QueryListCount(BaseFormDataQueryPara param)
        {
            int count = 0;
            IDataProviderEx dao = _BaseFormdao;
            if (dao != null)
            {
                count = dao.QueryCount(param);
            }

            return count;
        }
        #endregion
        private DataList QueryListDetail(Hashtable param, int start, int pageSize)
        {
            DataList list = null;
            IDataProviderEx dataProviderEx = _BaseFormdao;
            if (dataProviderEx != null)
            {
                list = dataProviderEx.QueryList(param, start, pageSize, false);
            }

            return list;
        }
        private DataList QuertListDetailex(Hashtable param, int start, int pageSize)
        {
            DataList list = null;
            IDataProviderEx dataProviderEx = _BaseFormdao;
            if (dataProviderEx != null)
            {
                list = dataProviderEx.QueryList("QueryBaseFormDataListWithRuntask",param, start, pageSize);
            }

            return list;
            
        }
        public int QueryListCountex(Hashtable param)
        {
            int count = 0;
            IDataProviderEx dao = _BaseFormdao;
            if (dao != null)
            {
                count = dao.QueryCount("QueryBaseFormDataCountex", param);
            }

            return count;
        }
        public void AddAttitude(DoAttitude doattitude)
        {
            _Doattitudesvr.AddNew(doattitude);
        }

        #region 收藏夹

        /// <summary>
        /// 查询被收藏的公文列表
        /// </summary>
        /// <param name="param">查询参数</param>
        /// <param name="start"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public DataList QueryBaseListInFavorite(Hashtable param, int start, int pageSize)
        {
            DataList list = _BaseFormdao.QueryList("QueryBaseFormDataListInFavorite", param, start, pageSize);
            return list;
        }

        /// <summary>
        /// 查询被收藏的公文个数
        /// </summary>
        /// <param name="param">查询参数</param>
        /// <returns></returns>
        public int QueryBaseCountInFavorite(Hashtable param)
        {
            return _BaseFormdao.QueryCount("QueryBaseFormDataCountInFavorite", param);
        }

        /// <summary>
        /// 查询被收藏公文列表分页
        /// </summary>
        /// <param name="param"></param>
        /// <param name="pageSize"></param>
        /// <param name="pageIndex"></param>
        /// <returns></returns>
        public IPagedList QueryBasePagedListInFavorite(QueryParameter param, int pageSize, int pageIndex)
        {
            return new PagedDataList(QueryBaseListInFavorite, QueryBaseCountInFavorite, param, pageSize, pageIndex);
        }

        #endregion
       
    }
}