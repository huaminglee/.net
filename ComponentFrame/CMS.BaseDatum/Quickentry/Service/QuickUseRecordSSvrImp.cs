#region 版本说明
/*****************************************************************************
 * 
 * 项    目 : 
 * 作    者 : 李金坪 
 * 创建时间 : 2015/1/19 13:57:17 
 *
 * Copyright (C) 2008 - 鹏业软件公司
 * 
 *****************************************************************************/
#endregion

/*
      <!---->
      <component id="QuickUseRecordSSvr" type="PengeSoft.CMS.BaseDatum.QuickUseRecordSSvr, PengeSoft.CMS.BaseDatum" service="PengeSoft.CMS.BaseDatum.IQuickUseRecordSSvr, PengeSoft.CMS.BaseDatum" lifestyle="Singleton">
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
using PengeSoft.db.IBatis;
using PengeSoft.Common;
using IBatisNet.DataAccess;

namespace PengeSoft.CMS.BaseDatum
{
    /// <summary>
    /// QuickUseRecordSSvr实现。    
    /// </summary>
    [PublishName("QuickUseRecordS")]
    public class QuickUseRecordSSvr : PengeSoft.Service.Auther.UserAutherImp, IQuickUseRecordSSvr
    {
        protected IDaoManager _daoManager = null;
        private IQuickUseRecordDao _quickuserecorddao;
        private IWindsorContainer _container;
        #region 服务描述
        public QuickUseRecordSSvr()
        {
            _container = ComponentManager.GetInstance();
            _daoManager = ServiceConfig.GetInstance().DaoManager;
            _quickuserecorddao = (IQuickUseRecordDao)_daoManager.GetDao(typeof(IQuickUseRecordDao));

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

        #region IQuickUseRecordSSvr 函数

        /// <summary>
        /// 添加使用次数   
        /// </summary>
        /// <param name="Uid">用户id</param>
        /// <param name="Qid">入口id</param>
        [PublishMethod]
        public void AddQuickUse(string uTag, string Uid, int Qid, int Qtype)
        {
            if (CheckRight(uTag, "") == AutherCheckResult.OP_SUCESS)
            {
                QuickUseRecordQueryPara para = new QuickUseRecordQueryPara();
                para.SetQid(Qid);
                para.SetUid(Uid);
                para.SetQtype(Qtype);
                _quickuserecorddao.QueryCount("AddUseTimes", para);
            }
        }

        /// <summary>
        /// 移除常用   
        /// </summary>
        /// <param name="Uid">用户id</param>
        /// <param name="Qid">入口id</param>
        [PublishMethod]
        public void DelQuickUse(string uTag, string Uid, int Qid)
        {
            if (CheckRight(uTag, "") == AutherCheckResult.OP_SUCESS)
            {
                QuickUseRecordQueryPara para = new QuickUseRecordQueryPara();
                para.SetQid(Qid);
                para.SetUid(Uid);
                _quickuserecorddao.QueryCount("DeleteQuickUseRecordByPara", para);
            }
        }

        /// <summary>
        /// 查询常用入口   
        /// </summary>
        /// <param name="Uid">用户id</param>
        /// <param name="Qtype">类型</param>
        /// <param name="QNeedRecords">数量</param>
        [PublishMethod]
        public QuickentryList GetUsualQuick(string uTag, string Uid, int Qtype, int QNeedRecords)
        {
            if (CheckRight(uTag, "") == AutherCheckResult.OP_SUCESS)
            {
                QuickentryList result = new QuickentryList();
                QuickUseRecordQueryPara para = new QuickUseRecordQueryPara();
                para.SetUseTimes(QNeedRecords);
                para.SetUid(Uid);
                para.SetQtype(Qtype);
                para.SetOrderByField("UseTimes_D");
                DataList dlist = _quickuserecorddao.QueryList("MyQueryQuickUseRecordList", para, 0, QNeedRecords);
                if (dlist.Count > 0) result.AssignFrom(dlist);
                if (result.Count < QNeedRecords)
                {
                    int[] curqids = new int[result.Count];
                    if (result.Count > 0)
                    {
                        int i = 0;
                        foreach (Quickentry qres in result)
                        {
                            curqids[i] = qres.QId;
                            i++;
                        }
                    }
                    int needdefault = QNeedRecords - result.Count;
                    QuickentrySSvr qsvr = new QuickentrySSvr();
                    QuickentryList addresult = qsvr.GetDefaultList(uTag, Qtype, needdefault, curqids);
                    if (addresult.Count > 0)
                    {
                        foreach (Quickentry quickinstance in addresult)
                        {
                            result.Add(quickinstance);
                        }
                    }
                }
                return result;

            }
            return null;
        }
        #endregion
    }
}
