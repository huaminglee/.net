#region 版本说明
/*****************************************************************************
 * 
 * 项    目 : 
 * 作    者 : 李金坪 
 * 创建时间 : 2014/11/18 13:18:41 
 *
 * Copyright (C) 2008 - 鹏业软件公司
 * 
 *****************************************************************************/
#endregion

/*
      <!--皮肤管理-->
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
    /// SkinServerSvr实现。    
    /// </summary>
    [PublishName("SkinServer")]
    public class SkinServerSvr : PengeSoft.Service.Auther.UserAutherImp, ISkinServerSvr
    {
        protected IDaoManager _daoManager = null;
        private ISkinInfoDao _skininfodal;
        #region 服务描述

        public override void FormActionList(AppActionList Acts)
        {
            base.FormActionList(Acts);

            // 添加需发布的功能信息
        }
        public SkinServerSvr()
        {
            _daoManager = ServiceConfig.GetInstance().DaoManager;
            _skininfodal = (ISkinInfoDao)_daoManager.GetDao(typeof(ISkinInfoDao));
        }

        public override void FormAttribsRec(PengeSoft.WorkZoneData.AppAttribBaseRec attr)
        {
            base.FormAttribsRec(attr);

            attr.Detail = "皮肤管理";
        }

        #endregion

        #region ISkinServerSvr 函数

        /// <summary>
        /// 查询用户皮肤信息   
        /// </summary>
        /// <param name="UserID">用户id</param>
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
        /// 添加用户皮肤信息   
        /// </summary>
        /// <param name="UserID">用户id</param>
        /// <param name="TSkinInfo">皮肤信息</param>
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
        /// 更新用户皮肤信息   
        /// </summary>
        /// <param name="TSkinInfo">皮肤信息</param>
        /// <param name="UserID">用户id</param>
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