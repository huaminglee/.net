#region 版本说明
/*****************************************************************************
 * 
 * 项    目 : 
 * 作    者 : 李金坪 
 * 创建时间 : 2014/8/22 19:34:12 
 *
 * Copyright (C) 2008 - 鹏业软件公司
 * 
 *****************************************************************************/
#endregion

/*
      <!---->
      <component id="DoAttitudeServerSvr" type="PengeSoft.CMS.BaseDatum.DoAttitudeServerSvr, PengeSoft.CMS.BaseDatum" service="PengeSoft.CMS.BaseDatum.IDoAttitudeServerSvr, PengeSoft.CMS.BaseDatum" lifestyle="Singleton">
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
    /// DoAttitudeServerSvr实现。    
    /// </summary>
    public class DoAttitudeServerSvr : ApplicationBase, IDoAttitudeServerSvr
    {
        protected IDaoManager _daoManager = null;
        protected IDoAttitudeDao _Doattitudedao;
        public DoAttitudeServerSvr()
        {
            _daoManager = ServiceConfig.GetInstance().DaoManager;
            _Doattitudedao = (IDoAttitudeDao)_daoManager.GetDao(typeof(IDoAttitudeDao));
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

        #region IDoAttitudeServerSvr 函数

        /// <summary>
        /// 获取意见列表   
        /// </summary>
        /// <param name="FormID"></param>
        public DoAttitudeList GetListByFormID(string FormID)
        {
            DoAttitudeList list = new DoAttitudeList();
            DoAttitudeQueryPara para=new DoAttitudeQueryPara();
            para.SetFormID(FormID);
            para.SetOrderByField("CreateTime");
            DataList dlist= _Doattitudedao.QueryList( para, 0, 100) ;
            list.AddCopyFrom(dlist);
            return list;


        }

        /// <summary>
        /// 添加   
        /// </summary>
        /// <param name="attitude"></param>
        public void AddNew(DoAttitude attitude)
        {
            _Doattitudedao.Insert(attitude);
        }

        /// <summary>
        /// 删除   
        /// </summary>
        /// <param name="attitude"></param>
        public void Delinfo(DoAttitude attitude)
        {
            _Doattitudedao.Delete(attitude);
        }

        /// <summary>
        /// 修改   
        /// </summary>
        /// <param name="attitude"></param>
        public void Updinfo(DoAttitude attitude)
        {
            _Doattitudedao.Update(attitude);
        }

        #endregion
    }
}