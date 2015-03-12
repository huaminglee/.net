#region 版本说明
/*****************************************************************************
 * 
 * 项    目 : 
 * 作    者 : 李金坪 
 * 创建时间 : 2014/11/18 13:18:19 
 *
 * Copyright (C) 2008 - 鹏业软件公司
 * 
 *****************************************************************************/
#endregion

/*
      <!--布局信息-->
      <component id="LayoutInfoServerSvr" type="PengeSoft.CMS.BaseDatum.LayoutInfoServerSvr, PengeSoft.CMS.BaseDatum" service="PengeSoft.CMS.BaseDatum.ILayoutInfoServerSvr, PengeSoft.CMS.BaseDatum" lifestyle="Singleton">
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
using PengeSoft.Service.Auther;
using PengeSoft.Client;
using PengeSoft.Auther;
using IBatisNet.DataAccess;
using PengeSoft.db.IBatis;
using PengeSoft.Common;
using System.Web;

namespace PengeSoft.CMS.BaseDatum
{
    
    /// <summary>
    /// LayoutInfoServerSvr实现。    
    /// </summary>
    [PublishName("LayoutInfoServer")]
    public class LayoutInfoServerSvr : PengeSoft.Service.Auther.UserAutherImp, ILayoutInfoServerSvr
    {
        PengeSoft.Service.Auther.IUserAuther auther;
        IRightCheck _rightcheck;
        protected IDaoManager _daoManager = null;
        private ILayoutInfoDao _layoutinfodao;        
        private IWindsorContainer _container;

         
        #region 服务描述

        public override void FormActionList(AppActionList Acts)
        {
            base.FormActionList(Acts);

            // 添加需发布的功能信息
        }
        public LayoutInfoServerSvr(IRightCheck irig)
        {
            _rightcheck = irig;
            
            _container = ComponentManager.GetInstance();
            auther = RometeClientManager.GetClient("http://118.122.92.139:8989/Service/UserAuther.assx", typeof(PengeSoft.Service.Auther.IUserAuther), 60000) as PengeSoft.Service.Auther.IUserAuther;
            _daoManager = ServiceConfig.GetInstance().DaoManager;
            _layoutinfodao = (ILayoutInfoDao)_daoManager.GetDao(typeof(ILayoutInfoDao));
        }
        public override void FormAttribsRec(PengeSoft.WorkZoneData.AppAttribBaseRec attr)
        {
            base.FormAttribsRec(attr);

            attr.Detail = "布局信息";
        }

        #endregion

        #region ILayoutInfoServerSvr 函数

        /// <summary>
        /// 获取用户布局信息  如无相关布局信息则返回默认布局信息 
        /// </summary>
        /// <param name="UserID">用户id</param>
        /// <param name="PageName">页面名称</param>
        /// <param name="RoleName">权限等级</param>
        [PublishMethod]
        public LayoutInfo GetUserLayoutinfo(string uTag, string UserID, string PageName, string RoleName)
        {
            LayoutInfo result = new LayoutInfo();
            LayoutInfoQueryPara para=new LayoutInfoQueryPara();
            para.SetOwner(UserID);
            para.SetBelongPage (PageName);
            para.SetTempType("2");
            para.SetIsusing(1);
            DataList dlist = _layoutinfodao.QueryList(para, 0,1) ;
            if (dlist.Count > 0)
            {
                result.AssignFrom(dlist[0]);
            }
            else
            {
                para = new LayoutInfoQueryPara();
                para.SetOwner(RoleName);
                para.SetBelongPage(PageName);
                para.SetTempType("1");
                DataList dlist2 = _layoutinfodao.QueryList(para, 0, 1);
                if (dlist2.Count > 0)
                {
                    result.AssignFrom(dlist2[0]);
                }
            }

            return result;
        }

        [PublishMethod]
        public LayoutInfo GetUserLayoutinfobyid(string uTag, int lid)
        {
            if (CheckRight(uTag, "") == AutherCheckResult.OP_SUCESS)
            {
                LayoutInfo result = new LayoutInfo();
                result.LID = lid;
                result.AssignFrom(_layoutinfodao.GetDetail(result));
                return result;
            }
            return null;
        }
        /// <summary>
        /// 新增用户布局信息   
        /// </summary>
        /// <param name="UserID">用户id</param>
        /// <param name="PageName">页面名称</param>
        /// <param name="MLayoutInfo">布局信息</param>
        [PublishMethod]
        public string AddUserLayoutinf(string uTag, string UserID, string PageName, string MLayoutInfo)
        {
            if (CheckRight(uTag, "") == AutherCheckResult.OP_SUCESS)
            {
                LayoutInfo nlayoutinfo = new LayoutInfo();
                nlayoutinfo.JsonText = MLayoutInfo;
                nlayoutinfo.Owner = UserID;
                nlayoutinfo.BelongPage = PageName;
                nlayoutinfo.Isusing = 1;
                _layoutinfodao.Update("upoldinfo", nlayoutinfo);//修改以前的isusing=0;
                object result = _layoutinfodao.Insert(nlayoutinfo);
                return nlayoutinfo.LID.ToString();
            }
            return null;
        }

        /// <summary>
        /// 更新用户布局信息   
        /// </summary>
        /// <param name="UserID">用户id</param>
        /// <param name="PageName">页面名称</param>
        /// <param name="MLayoutInfo">布局信息</param>
        [PublishMethod]
        public string UpdateUserLayoutinf(string uTag, string UserID, string PageName, string MLayoutInfo)
        {
            if (CheckRight(uTag, "") == AutherCheckResult.OP_SUCESS)
            {
                LayoutInfo nlayoutinfo = new LayoutInfo();
                nlayoutinfo.JsonText = MLayoutInfo;
                nlayoutinfo.Owner = UserID;
                nlayoutinfo.BelongPage = PageName;
                if (nlayoutinfo.LID != 0)
                {
                    return _layoutinfodao.Update(nlayoutinfo).ToString();
                }
                _layoutinfodao.Update("MyUpdate", nlayoutinfo);
                return nlayoutinfo.LID.ToString();
            }
            return null;
        }
        /// <summary>
        /// 获取布局总数
        /// </summary>
        /// <param name="uTag"></param>
        /// <param name="PageName"></param>
        /// <param name="LayType"></param>
        /// <param name="uID"></param>
        /// <returns></returns>
        [PublishMethod]
        public int GetLayoutInfoListCount(string uTag, string PageName, string LayType, string uID)
        {
            if (CheckRight(uTag, "") == AutherCheckResult.OP_SUCESS)
            {
                LayoutInfoQueryPara para = new LayoutInfoQueryPara();
                //if (!string.IsNullOrEmpty(uID))
                //{
                //    if (LayType == "1")//布局模板
                //    {
                //        para.SetOwner(uID);//改为设定权限
                //    }
                //    else
                //    {
                //        para.SetOwner(uID);
                //    }

                //}
                para.SetLayType(LayType);
                para.SetIsusing(1);
                if (!string.IsNullOrEmpty(PageName))
                {
                    para.SetBelongPage(PageName);
                }
                return _layoutinfodao.QueryCount(para);
            }
            return 0;
        }
        /// <summary>
        /// 删除布局信息   
        /// </summary>
        /// <param name="lid"></param>
        [PublishMethod]
        public void DelLayputinfo(string uTag,int lid)
        {
            if (CheckRight(uTag, "") == AutherCheckResult.OP_SUCESS)
            {
                LayoutInfo result = new LayoutInfo();
                result.LID = lid;
                _layoutinfodao.Delete(result);
            }
           
        }
        /// <summary>
        /// 获取布局模板列表   
        /// </summary>
        /// <param name="PageName">页面名</param>
        /// <param name="LayType">模板类型（布局模板或详细模板）</param>
        /// <param name="uID">用户id</param>
        [PublishMethod]
        public LayoutInfoList GetLayoutInfoList(string uTag, string PageName, string LayType, string uID, int currentPage, int PageSize)
        {
            if (CheckRight(uTag, "") == AutherCheckResult.OP_SUCESS)
            {
                LayoutInfoList result = new LayoutInfoList();
                LayoutInfoQueryPara para = new LayoutInfoQueryPara();
                //if (!string.IsNullOrEmpty(uID))
                //{
                //    if (LayType == "1")//布局模板
                //    {
                //        para.SetOwner(uID);//改为设定权限
                //    }
                //    else
                //    {
                //        para.SetOwner(uID);
                //    }

                //}
                para.SetLayType(LayType);
                para.SetIsusing(1);
                if (!string.IsNullOrEmpty(PageName))
                {
                    para.SetBelongPage(PageName);
                }
                int start = 0;
                start = (currentPage - 1) * PageSize;

                DataList dlist = _layoutinfodao.QueryList(para, start, PageSize);
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