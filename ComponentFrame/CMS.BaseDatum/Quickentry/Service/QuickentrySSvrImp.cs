#region 版本说明
/*****************************************************************************
 * 
 * 项    目 : 
 * 作    者 : 李金坪 
 * 创建时间 : 2015/1/19 13:57:14 
 *
 * Copyright (C) 2008 - 鹏业软件公司
 * 
 *****************************************************************************/
#endregion

/*
      <!---->
      <component id="QuickentrySSvr" type="PengeSoft.CMS.BaseDatum.QuickentrySSvr, PengeSoft.CMS.BaseDatum" service="PengeSoft.CMS.BaseDatum.IQuickentrySSvr, PengeSoft.CMS.BaseDatum" lifestyle="Singleton">
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
using PengeSoft.Common;
using PengeSoft.db.IBatis;

namespace PengeSoft.CMS.BaseDatum 
{
    /// <summary>
    /// QuickentrySSvr实现。    
    /// </summary>
    [PublishName("QuickentryS")]
    public class QuickentrySSvr : PengeSoft.Service.Auther.UserAutherImp, IQuickentrySSvr 
    {
        protected IDaoManager _daoManager = null;
        private IQuickentryDao _quickentrydao;
        private IWindsorContainer _container;

        #region 服务描述
        public QuickentrySSvr()
        {
            _container = ComponentManager.GetInstance();            
            _daoManager = ServiceConfig.GetInstance().DaoManager;
            _quickentrydao = (IQuickentryDao)_daoManager.GetDao(typeof(IQuickentryDao));

        }

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

        #region IQuickentrySSvr 函数

        /// <summary>
        /// 新增入口   
        /// </summary>
        /// <param name="Quickentry">入口对象</param>
        [PublishMethod("Quickentry")]
        public void AddQuickentry(string uTag, string QName, String QRemark, string QPico, string QTarget, int DefaultSort, int QType)
        {
            if (CheckRight(uTag, "") == AutherCheckResult.OP_SUCESS)
            {
                Quickentry rec=new Quickentry();
                rec.QName=QName;
                rec.QRemark=QRemark;
                rec.QPico=QPico;
                rec.QRemark=QRemark;
                rec.DefaultSort=DefaultSort;
                rec.QType = QType;
                _quickentrydao.Insert(rec);
            }
            
        }

        /// <summary>
        /// 修改入口   
        /// </summary>
        /// <param name="Qid">入口id</param>
        /// <param name="QuickentryInfo">入口对象</param>
        [PublishMethod("QuickentryInfo")]
        public void UpdateQuickentry(string uTag, int Qid, string QName, String QRemark, string QPico, string QTarget, int DefaultSort, int QType)
        {
            if (CheckRight(uTag, "") == AutherCheckResult.OP_SUCESS)
            {
                Quickentry rec = new Quickentry();
                rec.QId = Qid;
                rec=  _quickentrydao.GetDetail(rec) as Quickentry;
                rec.QName = QName;
                rec.QRemark = QRemark;
                rec.QPico = QPico;
                rec.QRemark = QRemark;
                rec.DefaultSort = DefaultSort;
                rec.QType = QType;
                _quickentrydao.Update(rec);
            }
        }

        /// <summary>
        /// 删除   
        /// </summary>
        /// <param name="Qid">入口id</param>
        [PublishMethod]
        public void DelQuickentry(string uTag, int Qid)
        {
            if (CheckRight(uTag, "") == AutherCheckResult.OP_SUCESS)
            {
                Quickentry rec = new Quickentry();
                rec.QId = Qid;

                _quickentrydao.Delete(rec);
            }
        }

        /// <summary>
        /// 查询默认列表   
        /// </summary>
        /// <param name="Qtype">入口类型</param>
        /// <param name="NeedRecords">条数</param>
        [PublishMethod]
        public QuickentryList GetDefaultList(string uTag, int Qtype, int NeedRecords, int[] qids)
        {
            if (CheckRight(uTag, "") == AutherCheckResult.OP_SUCESS)
            {
                QuickentryList result = new QuickentryList();
                QuickentryQueryPara pata = new QuickentryQueryPara();
                pata.SetQType(Qtype);
                if (qids.Length > 0)
                {
                    pata.SetQId_NotIn(qids);
                }

                DataList dlist = _quickentrydao.QueryList(pata, 0, NeedRecords);
                if (dlist.Count > 0)
                {
                    result.AssignFrom(dlist);
                }
                return result;
            }
            return null;
        }
        

        #endregion
    }
}
