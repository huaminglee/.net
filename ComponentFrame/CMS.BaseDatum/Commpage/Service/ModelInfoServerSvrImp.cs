#region �汾˵��
/*****************************************************************************
 * 
 * ��    Ŀ : 
 * ��    �� : ���ƺ 
 * ����ʱ�� : 2014/11/18 13:18:33 
 *
 * Copyright (C) 2008 - ��ҵ�����˾
 * 
 *****************************************************************************/
#endregion

/*
      <!--ģ�����-->
      <component id="ModelInfoServerSvr" type="PengeSoft.CMS.BaseDatum.ModelInfoServerSvr, PengeSoft.CMS.BaseDatum" service="PengeSoft.CMS.BaseDatum.IModelInfoServerSvr, PengeSoft.CMS.BaseDatum" lifestyle="Singleton">
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
using IBatisNet.DataAccess;
using PengeSoft.db.IBatis;

namespace PengeSoft.CMS.BaseDatum
{
    /// <summary>
    /// ModelInfoServerSvrʵ�֡�    
    /// </summary>
    [PublishName("ModelInfoServer")]
    public class ModelInfoServerSvr : PengeSoft.Service.Auther.UserAutherImp, IModelInfoServerSvr
    {
        protected IDaoManager _daoManager = null;
        private IModelInfoDao _modelinfodao;
        #region ��������

        public override void FormActionList(AppActionList Acts)
        {
            base.FormActionList(Acts);

            // ����跢���Ĺ�����Ϣ
        }
        public ModelInfoServerSvr()
        {
            _daoManager = ServiceConfig.GetInstance().DaoManager;
            _modelinfodao = (IModelInfoDao)_daoManager.GetDao(typeof(IModelInfoDao));
        }

        public override void FormAttribsRec(PengeSoft.WorkZoneData.AppAttribBaseRec attr)
        {
            base.FormAttribsRec(attr);

            attr.Detail = "ģ�����";
        }

        #endregion

        #region IModelInfoServerSvr ����

        /// <summary>
        /// ��ȡģ������
        /// </summary>
        /// <param name="uTag">��¼��ʶ</param>
        /// <returns></returns>
        [PublishMethod]
        public int GetModelCount(string uTag)
        {
            if (CheckRight(uTag, "") == AutherCheckResult.OP_SUCESS)
            {
                return _modelinfodao.GetCount();
            }
            return 0;
        }

        /// <summary>
        /// ��ȡģ���б�
        /// </summary>
        /// <param name="uTag">��¼��ʶ</param>
        /// <param name="currentPage">��ǰҳ</param>
        /// <param name="PageSize">ҳ��С</param>
        /// <returns></returns>
        [PublishMethod]
        public ModelInfoList GetModelList(string uTag, int currentPage, int PageSize)
        {
            if (CheckRight(uTag, "") == AutherCheckResult.OP_SUCESS)
            {
                int start = 0;
                start = (currentPage - 1) * PageSize;
                DataList dlist = _modelinfodao.GetList(start, PageSize, null);
                ModelInfoList result = new ModelInfoList();
                result.AssignFrom(dlist);
                return result;
            }
            return null;
        }
        /// <summary>
        /// ����ģ��
        /// </summary>
        /// <param name="uTag"></param>
        /// <param name="modelInfo"></param>
        /// <returns></returns>
        [PublishMethod]
        public int AddModelInfo(string uTag, ModelInfo modelInfo)
        {
            if (CheckRight(uTag, "") == AutherCheckResult.OP_SUCESS)
            {
                _modelinfodao.Insert(modelInfo);
                return 0;
            }
            return -1;
        }

        /// <summary>
        /// ɾ��ģ��
        /// </summary>
        /// <param name="uTag"></param>
        /// <param name="mId"></param>
        /// <returns></returns>
        [PublishMethod]
        public void DelModelInfo(string uTag, int mId)
        {
            if (CheckRight(uTag, "") == AutherCheckResult.OP_SUCESS)
            {
                ModelInfo model = new ModelInfo();
                model.MId = mId;
                _modelinfodao.Delete(model);
            }
        }
        #endregion
    }
}