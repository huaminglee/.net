#region 版本说明
/*****************************************************************************
 * 
 * 项    目 : 
 * 作    者 : 李金坪 
 * 创建时间 : 2014/9/17 11:29:09 
 *
 * Copyright (C) 2008 - 鹏业软件公司
 * 
 *****************************************************************************/
#endregion

/*
      <!---->
      <component id="UsedContactServerSvr" type="PengeSoft.CMS.BaseDatum.UsedContactServerSvr, PengeSoft.CMS.BaseDatum" service="PengeSoft.CMS.BaseDatum.IUsedContactServerSvr, PengeSoft.CMS.BaseDatum" lifestyle="Singleton">
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
    /// UsedContactServerSvr实现。    
    /// </summary>
    public class UsedContactServerSvr : ApplicationBase, IUsedContactServerSvr
    {
        protected IDaoManager _daoManager = null;
        protected IUsedContactsDao _usedcontactdao;
        public UsedContactServerSvr()
        {
            _daoManager = ServiceConfig.GetInstance().DaoManager;
            _usedcontactdao = (IUsedContactsDao)_daoManager.GetDao(typeof(IUsedContactsDao));

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

        #region IUsedContactServerSvr 函数

        /// <summary>
        /// 添加记录   
        /// </summary>
        /// <param name="COwner">所有人</param>
        /// <param name="ContactUserID">联系人ID</param>
        /// <param name="ContactUserXM">联系人姓名</param>
        /// <param name="TaskName">任务名称</param>
        /// <param name="StepName">步骤名称</param>
        /// <param name="UseTimes">次数</param>
        /// <param name="Ctype">类型：1人员，2部门</param>
        public void AddRecord(string COwner, string ContactUserID, string ContactUserXM, string TaskName, string StepName,int Ctype)
        {
            UsedContacts usecontactinfo = new UsedContacts();
            usecontactinfo.ContactUserID = ContactUserID;
            usecontactinfo.ContactUserXM = ContactUserXM;
            usecontactinfo.COwner = COwner;
            usecontactinfo.CType = Ctype;
            usecontactinfo.TaskName = TaskName;
            usecontactinfo.StepName = StepName;
            usecontactinfo.UseTimes = 1;
            if (GetrecordCount(COwner, ContactUserID, TaskName, StepName) > 0)
            {                 
                _usedcontactdao.ExcuteQuery("AddTimes",usecontactinfo);
            }
            else
            {
                _usedcontactdao.Insert(usecontactinfo);
            }
            
        }
        private int GetrecordCount(string COwner, string ContactUserID, string TaskName, string StepName)
        {
            UsedContactsQueryPara para = new UsedContactsQueryPara();
            para.SetCOwner(COwner);
            para.SetContactUserID(ContactUserID);
            para.SetTaskName(TaskName);
            para.SetStepName(StepName);
            return _usedcontactdao.QueryCount(para);
        }

        /// <summary>
        /// 获取常用联系人   
        /// </summary>
        /// <param name="Cowner">所有人</param>
        /// <param name="TaskName">任务名</param>
        /// <param name="StepName">步骤名</param>
        public UseContactList GetContactsList(string Cowner, string TaskName, string StepName)
        {
            UsedContactsQueryPara para=new UsedContactsQueryPara();
            para.SetCOwner(Cowner);
            para.SetTaskName(TaskName);
            para.SetStepName(StepName);
            para.SetOrderByField("UseTimes");
            DataList list = _usedcontactdao.QueryList(para, 0, -1);
            UseContactList plist = new UseContactList();
            plist.Mowner = Cowner;
            plist.AssignFrom(list);
            return plist;
        }

        #endregion
    }
}