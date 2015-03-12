#region �汾˵��
/*****************************************************************************
 * 
 * ��    Ŀ : 
 * ��    �� : ���� 
 * ����ʱ�� : 2015/1/21 14:12:18 
 *
 * Copyright (C) 2008 - ��ҵ�����˾
 * 
 *****************************************************************************/
#endregion

/*
      <!--�������-->
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
    /// NoticeServiceSvrʵ�֡��������    
    /// </summary>
    [PublishName("NoticeService")]
    public class NoticeServiceSvr : UserAutherImp, INoticeServiceSvr 
    {
        #region ˽���ֶ�

        private IDaoManager _daoManager = null;
        private INoticeDao _NoticeDao = null;

        #endregion
        #region ��������

        public override void FormActionList(AppActionList Acts)
        {
            base.FormActionList(Acts);

            // ����跢���Ĺ�����Ϣ
        }

        /// <summary>
        /// ���캯��
        /// </summary>
        public NoticeServiceSvr() 
        {
            _daoManager = ServiceConfig.GetInstance().DaoManager;
            _NoticeDao = (INoticeDao)_daoManager.GetDao(typeof(INoticeDao));
         }

        public override void FormAttribsRec(PengeSoft.WorkZoneData.AppAttribBaseRec attr)
        {
            base.FormAttribsRec(attr);

            attr.Detail = "�������";
        }

        #endregion

        #region INoticeServiceSvr ����

        /// <summary>
        /// ��������   
        /// </summary>
        /// <param name="uTag">�û���¼��</param>
        /// <param name="title">�������</param>
        /// <param name="content">��������</param>
        /// <param name="author">������</param>
        [PublishMethod]
        public int Announcement(string uTag, string title, string content, string author)
        {
            //������֤�û���¼
            int checkresult = CheckRight(uTag, "");
            if (checkresult == PengeSoft.Auther.RightCheck.AutherCheckResult.OP_SUCESS)
            {
                Notice notice = new Notice();
                notice.Title = title;
                notice.Content = content;
                notice.Author = author;
                notice.CreateDate = DateTime.Now;
                //���ȼ�鹫������Ƿ��Ѵ���
                if (_NoticeDao.QueryCountByTitle(notice.Title) > 0)
                {
                    //����1��ʾ�˱����Ѵ���
                    return 1;
                }
                else if (_NoticeDao.Insert(notice) != null)
                {
                    //����0��ʾ�����ɹ�
                    return 0;
                }
                else
                {
                    //����-1��ʾ����ʧ��
                    return -1;
                }
            }
            else
            {
                return checkresult;
            }
        }
        /// <summary>
        /// ��ѯ��������   
        /// </summary>
        /// <param name="uTag">�û���¼��</param>
        /// <param name="Guid">������</param>
        [PublishMethod]
        public Notice GetNotice(string uTag, int Guid)
        {
            Notice notice = new Notice();
            //������֤�û���¼
            if (CheckRight(uTag, "") == PengeSoft.Auther.RightCheck.AutherCheckResult.OP_SUCESS)
            {
                notice.Guid = Guid;
                //����Guid��ѯ��������
                notice.AssignFrom(_NoticeDao.GetDetail(notice, true));
            }
            return notice;
        }
        /// <summary>
        /// ��ѯ�����б�   
        /// </summary>
        /// <param name="uTag">�û���¼��</param>
        /// <param name="count">��ѯ����</param>
        [PublishMethod]
        public NoticeList QueryNoticeList(string uTag, int count)
        {
            NoticeList result = new NoticeList();
            //������֤�û���¼
            if (CheckRight(uTag, "") == PengeSoft.Auther.RightCheck.AutherCheckResult.OP_SUCESS)
            {
                //��ȡָ�������Ĺ�����Ϣ
                DataList dlist = _NoticeDao.GetNoticeListByCount(count, NoticeQueryPara.OrderByCreateDate_desc);
                if (dlist.Count > 0)
                {
                    result.AssignFrom(dlist);
                }
            }
            return result;
        }

        /// <summary>
        /// ��ѯ�����ҳ�б�   
        /// </summary>
        /// <param name="uTag">�û���¼��</param>
        /// <param name="param">��ѯ����</param>
        /// <param name="pageIndex">ҳ��</param>
        /// <param name="pageSize">ҳ��С</param>
        [PublishMethod]
        public NoticeList QueryNoticePageList(string uTag, string param, int pageIndex, int pageSize)
        {
            NoticeList result = new NoticeList();
            //������֤�û���¼
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
        /// ��ѯ��������   
        /// </summary>
        /// <param name="uTag">�û���¼��</param>
        /// <param name="param">��ѯ����</param>
        [PublishMethod]
        public int QueryNoticeCount(string uTag, string param)
        {
            //������֤�û���¼
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
        /// ɾ�������б�   
        /// </summary>
        /// <param name="uTag">�û���¼��</param>
        /// <param name="guidList">�����ʶ�б�</param>
        [PublishMethod]
        public void DeleteNoticeList(string uTag, string guidList)
        {
            //������֤�û���¼
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