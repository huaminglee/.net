#region �汾˵��
/*****************************************************************************
 * 
 * ��    Ŀ : 
 * ��    �� : ���ƺ 
 * ����ʱ�� : 2014/11/18 13:18:19 
 *
 * Copyright (C) 2008 - ��ҵ�����˾
 * 
 *****************************************************************************/
#endregion

/*
      <!--������Ϣ-->
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
    /// LayoutInfoServerSvrʵ�֡�    
    /// </summary>
    [PublishName("LayoutInfoServer")]
    public class LayoutInfoServerSvr : PengeSoft.Service.Auther.UserAutherImp, ILayoutInfoServerSvr
    {
        PengeSoft.Service.Auther.IUserAuther auther;
        IRightCheck _rightcheck;
        protected IDaoManager _daoManager = null;
        private ILayoutInfoDao _layoutinfodao;        
        private IWindsorContainer _container;

         
        #region ��������

        public override void FormActionList(AppActionList Acts)
        {
            base.FormActionList(Acts);

            // ����跢���Ĺ�����Ϣ
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

            attr.Detail = "������Ϣ";
        }

        #endregion

        #region ILayoutInfoServerSvr ����

        /// <summary>
        /// ��ȡ�û�������Ϣ  ������ز�����Ϣ�򷵻�Ĭ�ϲ�����Ϣ 
        /// </summary>
        /// <param name="UserID">�û�id</param>
        /// <param name="PageName">ҳ������</param>
        /// <param name="RoleName">Ȩ�޵ȼ�</param>
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
        /// �����û�������Ϣ   
        /// </summary>
        /// <param name="UserID">�û�id</param>
        /// <param name="PageName">ҳ������</param>
        /// <param name="MLayoutInfo">������Ϣ</param>
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
                _layoutinfodao.Update("upoldinfo", nlayoutinfo);//�޸���ǰ��isusing=0;
                object result = _layoutinfodao.Insert(nlayoutinfo);
                return nlayoutinfo.LID.ToString();
            }
            return null;
        }

        /// <summary>
        /// �����û�������Ϣ   
        /// </summary>
        /// <param name="UserID">�û�id</param>
        /// <param name="PageName">ҳ������</param>
        /// <param name="MLayoutInfo">������Ϣ</param>
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
        /// ��ȡ��������
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
                //    if (LayType == "1")//����ģ��
                //    {
                //        para.SetOwner(uID);//��Ϊ�趨Ȩ��
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
        /// ɾ��������Ϣ   
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
        /// ��ȡ����ģ���б�   
        /// </summary>
        /// <param name="PageName">ҳ����</param>
        /// <param name="LayType">ģ�����ͣ�����ģ�����ϸģ�壩</param>
        /// <param name="uID">�û�id</param>
        [PublishMethod]
        public LayoutInfoList GetLayoutInfoList(string uTag, string PageName, string LayType, string uID, int currentPage, int PageSize)
        {
            if (CheckRight(uTag, "") == AutherCheckResult.OP_SUCESS)
            {
                LayoutInfoList result = new LayoutInfoList();
                LayoutInfoQueryPara para = new LayoutInfoQueryPara();
                //if (!string.IsNullOrEmpty(uID))
                //{
                //    if (LayType == "1")//����ģ��
                //    {
                //        para.SetOwner(uID);//��Ϊ�趨Ȩ��
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