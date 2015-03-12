#region �汾˵��
/*****************************************************************************
 * 
 * ��    Ŀ : 
 * ��    �� : ���ƺ 
 * ����ʱ�� : 2014/11/18 13:18:41 
 *
 * Copyright (C) 2008 - ��ҵ�����˾
 * 
 *****************************************************************************/
#endregion

/*
      <!--Ƥ������-->
      <component id="SkinServerSvr" type="PengeSoft.CMS.BaseDatum.SkinServerSvr, PengeSoft.CMS.BaseDatum" service="PengeSoft.CMS.BaseDatum.ISkinServerSvr, PengeSoft.CMS.BaseDatum" lifestyle="Singleton">
        <parameters>
        </parameters>
      </component>
*/
using System;
using System.Collections;
using System.Text;
using System.Threading;
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
    /// SkinServerSvrʵ�֡�    
    /// </summary>
    [PublishName("SkinServer")]
    public class SkinServerSvr : PengeSoft.Service.Auther.UserAutherImp, ISkinServerSvr
    {
        protected IDaoManager _daoManager = null;
        private ISkinInfoDao _skininfodal;
        #region ��������

        public override void FormActionList(AppActionList Acts)
        {
            base.FormActionList(Acts);

            // ����跢���Ĺ�����Ϣ
        }
        public SkinServerSvr()
        {
            _daoManager = ServiceConfig.GetInstance().DaoManager;
            _skininfodal = (ISkinInfoDao)_daoManager.GetDao(typeof(ISkinInfoDao));
        }

        public override void FormAttribsRec(PengeSoft.WorkZoneData.AppAttribBaseRec attr)
        {
            base.FormAttribsRec(attr);

            attr.Detail = "Ƥ������";
        }

        #endregion

        #region ISkinServerSvr ����

        /// <summary>
        /// ��ѯ�û�Ƥ����Ϣ   
        /// </summary>
        /// <param name="UserID">�û�id</param>
        [PublishMethod]
        public SkinInfo GetUserSkinInfo(string uTag, string UserID)
        {
            if (CheckRight(uTag, "") == AutherCheckResult.OP_SUCESS)
            {
                SkinInfo skin = new SkinInfo();
                skin.Uid = UserID;
                Thread.Sleep(200);
                if (_skininfodal.GetDetail("MyGetDetail", skin) != null)
                {
                    skin.AssignFrom(_skininfodal.GetDetail("MyGetDetail", skin));
                }
                return skin;
            }
            return null;
        }

        /// <summary>
        /// ����û�Ƥ����Ϣ   
        /// </summary>
        /// <param name="UserID">�û�id</param>
        /// <param name="TSkinInfo">Ƥ����Ϣ</param>
        [PublishMethod]
        public string AddUserSkinInfo(string uTag, string UserID, string TSkinInfo)
        {
            if (CheckRight(uTag, "") == AutherCheckResult.OP_SUCESS)
            {
                SkinInfo skin = new SkinInfo();
                skin.JsonText = TSkinInfo;
                return _skininfodal.Insert(skin).ToString();
            }
            return null;
        }

        /// <summary>
        /// �����û�Ƥ����Ϣ   
        /// </summary>
        /// <param name="TSkinInfo">Ƥ����Ϣ</param>
        /// <param name="UserID">�û�id</param>
        [PublishMethod]
        public string UpdateUserSkinInfo(string uTag, string TSkinInfo, string UserID)
        {
            if (CheckRight(uTag, "") == AutherCheckResult.OP_SUCESS)
            {
                SkinInfo skin = new SkinInfo();
                skin.JsonText = TSkinInfo;
                skin.Uid = UserID;
                return _skininfodal.Update("MyUpdateSkinInfo", skin).ToString();
            }
            return null;
        }

        #endregion
    }
}