#region 版本说明
/*****************************************************************************
 * 
 * 项    目 : 
 * 作    者 : 罗坤 
 * 创建时间 : 2015/1/21 14:12:18 
 *
 * Copyright (C) 2008 - 鹏业软件公司
 * 
 *****************************************************************************/
#endregion

/*
      <!--公告服务-->
      <component id="NoticeServiceSvr" type="PengeSoft.CMS.BaseDatum.NoticeServiceSvr, PengeSoft.CMS.BaseDatum" service="PengeSoft.CMS.BaseDatum.INoticeServiceSvr, PengeSoft.CMS.BaseDatum" lifestyle="Singleton">
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
using System.Web;
using PengeSoft.Common;
using PengeSoft.Service.Auther;

namespace PengeSoft.CMS.BaseDatum 
{
    /// <summary>
    /// NoticeServiceSvr实现。公告服务    
    /// </summary>
    [PublishName("NoticeService")]
    public class NoticeServiceSvr : UserAutherImp, INoticeServiceSvr 
    {
        #region 私有字段

        private IDaoManager _daoManager = null;
        private INoticeDao _NoticeDao = null;

        #endregion
        #region 服务描述

        public override void FormActionList(AppActionList Acts)
        {
            base.FormActionList(Acts);

            // 添加需发布的功能信息
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        public NoticeServiceSvr() 
        {
            _daoManager = ServiceConfig.GetInstance().DaoManager;
            _NoticeDao = (INoticeDao)_daoManager.GetDao(typeof(INoticeDao));
         }

        public override void FormAttribsRec(PengeSoft.WorkZoneData.AppAttribBaseRec attr)
        {
            base.FormAttribsRec(attr);

            attr.Detail = "公告管理";
        }

        #endregion

        #region INoticeServiceSvr 函数

        /// <summary>
        /// 发布公告   
        /// </summary>
        /// <param name="uTag">用户登录码</param>
        /// <param name="title">公告标题</param>
        /// <param name="content">公告内容</param>
        /// <param name="author">发布人</param>
        [PublishMethod]
        public int Announcement(string uTag, string title, string content, string author)
        {
            //首先验证用户登录
            int checkresult = CheckRight(uTag, "");
            if (checkresult == PengeSoft.Auther.RightCheck.AutherCheckResult.OP_SUCESS)
            {
                Notice notice = new Notice();
                notice.Title = title;
                notice.Content = content;
                notice.Author = author;
                notice.CreateDate = DateTime.Now;
                //首先检查公告标题是否已存在
                if (_NoticeDao.QueryCountByTitle(notice.Title) > 0)
                {
                    //返回1表示此标题已存在
                    return 1;
                }
                else if (_NoticeDao.Insert(notice) != null)
                {
                    //返回0表示发布成功
                    return 0;
                }
                else
                {
                    //返回-1表示发布失败
                    return -1;
                }
            }
            else
            {
                return checkresult;
            }
        }
        /// <summary>
        /// 查询公告详情   
        /// </summary>
        /// <param name="uTag">用户登录码</param>
        /// <param name="Guid">公告编号</param>
        [PublishMethod]
        public Notice GetNotice(string uTag, int Guid)
        {
            Notice notice = new Notice();
            //首先验证用户登录
            if (CheckRight(uTag, "") == PengeSoft.Auther.RightCheck.AutherCheckResult.OP_SUCESS)
            {
                notice.Guid = Guid;
                //根据Guid查询公告详情
                notice.AssignFrom(_NoticeDao.GetDetail(notice, true));
            }
            return notice;
        }
        /// <summary>
        /// 查询公告列表   
        /// </summary>
        /// <param name="uTag">用户登录码</param>
        /// <param name="count">查询条数</param>
        [PublishMethod]
        public NoticeList QueryNoticeList(string uTag, int count)
        {
            NoticeList result = new NoticeList();
            //首先验证用户登录
            if (CheckRight(uTag, "") == PengeSoft.Auther.RightCheck.AutherCheckResult.OP_SUCESS)
            {
                //获取指定数量的公告消息
                DataList dlist = _NoticeDao.GetNoticeListByCount(count, NoticeQueryPara.OrderByCreateDate_desc);
                if (dlist.Count > 0)
                {
                    result.AssignFrom(dlist);
                }
            }
            return result;
        }

        /// <summary>
        /// 查询公告分页列表   
        /// </summary>
        /// <param name="uTag">用户登录码</param>
        /// <param name="param">查询参数</param>
        /// <param name="pageIndex">页数</param>
        /// <param name="pageSize">页大小</param>
        [PublishMethod]
        public NoticeList QueryNoticePageList(string uTag, string param, int pageIndex, int pageSize)
        {
            NoticeList result = new NoticeList();
            //首先验证用户登录
            if (CheckRight(uTag, "") == PengeSoft.Auther.RightCheck.AutherCheckResult.OP_SUCESS)
            {
                Notice parmData = new Notice();
                parmData.Title = "%" + param + "%";

                int start = (pageIndex - 1) * pageSize;
                DataList dlist = _NoticeDao.QueryList(parmData, start, pageSize, NoticeQueryPara.OrderByCreateDate_desc);
                if (dlist.Count > 0)
                {
                    result.AssignFrom(dlist);
                }               
            }
            return result;
        }

        /// <summary>
        /// 查询公告数量   
        /// </summary>
        /// <param name="uTag">用户登录码</param>
        /// <param name="param">查询参数</param>
        [PublishMethod]
        public int QueryNoticeCount(string uTag, string param)
        {
            //首先验证用户登录
            if (CheckRight(uTag, "") == PengeSoft.Auther.RightCheck.AutherCheckResult.OP_SUCESS)
            {
                Notice parmData = new Notice();
                parmData.Title = "%" +param + "%";
                return _NoticeDao.QueryCount(parmData);
            }
            else
            {
                return 0;
            }
        }

        /// <summary>
        /// 删除公告列表   
        /// </summary>
        /// <param name="uTag">用户登录码</param>
        /// <param name="guidList">公告标识列表</param>
        [PublishMethod]
        public void DeleteNoticeList(string uTag, string guidList)
        {
            //首先验证用户登录
            if (CheckRight(uTag, "") == PengeSoft.Auther.RightCheck.AutherCheckResult.OP_SUCESS)
            {
                Notice parmData = null;
                string[] dels = guidList.Split(new char[] { ',' });
                foreach (var item in dels)
                {
                    parmData = new Notice();
                    parmData.Guid = int.Parse(item);
                    _NoticeDao.Delete(parmData);
                }
            }
        }

        #endregion
    }
}