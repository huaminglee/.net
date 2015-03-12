#region 版本说明
/*****************************************************************************
 * 
 * 项    目 : 
 * 作    者 : 张李波 
 * 创建时间 : 2009-12-1 9:51:22 
 *
 * Copyright (C) 2008 - 鹏业软件公司
 * 
 *****************************************************************************/
#endregion

/*
      <!---->
      <component id="TempletServiceSvr" type="PengeSoft.CMS.BaseDatum.TempletServiceSvr, PengeSoft.CMS.BaseDatum" service="PengeSoft.CMS.BaseDatum.ITempletServiceSvr, PengeSoft.CMS.BaseDatum" lifestyle="Singleton">
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
using PengeSoft.db;

namespace PengeSoft.CMS.BaseDatum
{
    /// <summary>
    /// TempletSvrSvr实现。
    /// </summary>
    [PublishName("TempletSvr")]
    public class TempletServiceSvr : ApplicationBase, ITempletServiceSvr
    {
        #region 服务描述
        private IDaoManager _daoManager = null;
        private ITempletDao _TempletDao = null;
        private IPersonalTempletDao _PersonalTempletDao = null;

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

        public TempletServiceSvr()
        {
            _daoManager = ServiceConfig.GetInstance().DaoManager;
            _TempletDao = (ITempletDao)_daoManager.GetDao(typeof(ITempletDao));
            _PersonalTempletDao = (IPersonalTempletDao)_daoManager.GetDao(typeof(IPersonalTempletDao));
        }

        #endregion

        //添加人员模板内容
        private PersonalTempletList InsertPersonalTempletList(PersonalTempletList personList, string refID)
        {
            for (int i = 0; i < personList.Count; i++)
            {
                PersonalTemplet person = personList[i] as PersonalTemplet;
                if (person != null)
                {
                    person.ID = Guid.NewGuid().ToString();
                    person.RefID = refID;

                    _PersonalTempletDao.Insert(person);
                }
            }
            return personList;
        }

        /// <summary>
        /// 得到含有内容的人员模板
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        private Templet GetPersonalTempletWithContent(Templet item)
        {
            if (item != null && item.TempletType == (int)ETempletType.人员模板)
            {
                PersonalTempletQueryPara param = new PersonalTempletQueryPara();
                param.SetRefID(item.TempletId);
                item.TempletContent = _PersonalTempletDao.QueryList(param, 0, -1).XMLText;
            }
            return item;
        }

        /// <summary>
        /// 得到含有内容的模板
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        private TempletList GetTempletListWithContent(TempletList list)
        {
            foreach (Templet templet in list)
            {
                GetPersonalTempletWithContent(templet);
            }

            return list;
        }

        #region ITempletSvrSvr 函数

        /// <summary>
        /// 添加模板   
        /// </summary>
        public void AddTemplet(Templet templet)
        {
            //若是人员模板，存到从表中
            string content = "";
            if (templet.TempletType == (int)ETempletType.人员模板)
            {
                content = templet.TempletContent;
                templet.TempletContent = "";
            }

            if (string.IsNullOrEmpty(templet.TempletId))
                templet.TempletId = Guid.NewGuid().ToString();
            _TempletDao.Insert(templet);

            if (!string.IsNullOrEmpty(content))
            {
                PersonalTempletList personList = new PersonalTempletList();
                personList.XMLText = content;

                //for (int i = 0; i < personList.Count; i++)
                //{
                //    PersonalTemplet person = personList[0] as PersonalTemplet;
                //    if (person != null)
                //    {
                //        person.ID = Guid.NewGuid().ToString();
                //        person.RefID = templet.TempletId;

                //        _PersonalTempletDao.Insert(person);
                //    }
                //}

                personList = InsertPersonalTempletList(personList, templet.TempletId);

                templet.TempletContent = personList.XMLText;

            }            
        }

        /// <summary>
        /// 修改模板   
        /// </summary>
        public void ChangeTemplet(Templet templet)
        {
            string content = "";
            PersonalTempletList personList = new PersonalTempletList();
            if (templet.TempletType == (int)ETempletType.人员模板)
            {
                content = templet.TempletContent;
                personList.XMLText = content;

                _TempletDao.Delete("DeletePersonalTempletByRefID", templet);
            }
            _TempletDao.Update(templet);

            personList = InsertPersonalTempletList(personList, templet.TempletId);
            templet.TempletContent = personList.XMLText;
        }

        /// <summary>
        /// 删除模板   
        /// </summary>
        public void DeleteTemplet(string guid)
        {
            Templet item = new Templet();
            item.TempletId = guid;

            _TempletDao.Delete("DeletePersonalTempletByRefID", item);
            _TempletDao.Delete(item);
        }

        /// <summary>
        /// 删除模板列表   
        /// </summary>
        public void DeleteTempletList(StringList guidList)
        {
            foreach (string strguid in guidList)
            {
                Templet item = new Templet();
                item.TempletId = strguid;

                _TempletDao.Delete("DeletePersonalTempletByRefID", item);
                _TempletDao.Delete(item);
            }
        }

        /// <summary>
        /// 获取模板   
        /// </summary>
        public Templet GetTemplet(string guid)
        {
            Templet item = new Templet();
            item.TempletId = guid;

            item = _TempletDao.GetDetail(item) as Templet;

            item = GetPersonalTempletWithContent(item);
            return item;
        }


        /// <summary>
        /// 查询条数   
        /// </summary>
        /// <param name="param">条件</param>
        [PublishMethod("param")]
        public int QueryTempletCount(TempletQueryPara param)
        {
            return _TempletDao.QueryCount(param);
        }

        /// <summary>
        /// 查询列表   
        /// </summary>
        /// <param name="param">查询条件</param>
        /// <param name="star">开始位置</param>
        /// <param name="PageSize">页大小</param>
        /// <param name="isAll">摘要选项</param>
        [PublishMethod("param")]
        public TempletList QueryTempletList(TempletQueryPara param, int star, int PageSize, bool isAll)
        {
            TempletList list = new TempletList();
            DataList datalist;
            if (isAll)
                datalist = QueryListAll(param, star, PageSize);
            else
                datalist = QueryListDetail(param, star, PageSize);

            
            list.AddFrom(datalist);
            //list.Sort(new ComparerTemplet(TempletQueryPara.OrderByTempletContent));

            return list;
        }


        public TempletList QueryAttudeTempletList(TempletQueryPara param, int star, int PageSize)
        {
            TempletList list = new TempletList();
            DataList datalist;
            datalist= _TempletDao.QueryList("QueryAttudeTempletList", param, star, PageSize);

            list.AddFrom(datalist);
            //list.Sort(new ComparerTemplet(TempletQueryPara.OrderByTempletContent));

            return list;
        }


         /// <summary>
        /// 查询意见列表（扩展）   
        /// </summary>
        /// <param name="param">查询条件</param>
        /// <param name="star">开始位置</param>
        /// <param name="PageSize">页大小</param>
        private DataList QueryAttudeTempletList(Hashtable param, int star, int PageSize)
        {
           return  _TempletDao.QueryList("QueryAttudeTempletList", param, star, PageSize);
        }

        private int QueryAttudeTempletCount(Hashtable param)
        {
            return _TempletDao.QueryCount("QueryAttudeTempletCount", param);
        }
        
        

        /// <summary>
        /// 取得 IBatis DaoManager 实例   
        /// </summary>
        public IDaoManager GetDaoManager()
        {
            return _daoManager;
        }

        private DataList QueryListAll(Hashtable param, int start, int pageSize)
        {
            TempletList list = new TempletList();
            DataList datalist;

            datalist = _TempletDao.QueryList(param, start, pageSize, true);
            list.XMLText = datalist.XMLText;
            return GetTempletListWithContent(list);
        }


        private DataList QueryListDetail(Hashtable param, int start, int pageSize)
        {
            return _TempletDao.QueryList(param, start, pageSize, false);
        }




        /// <summary>
        /// 分页列表   
        /// </summary>
        public IPagedList QueryTempletPagedList(TempletQueryPara param, int pageSize, int pageIndex, bool isAll)
        {
            if (isAll)
            {
                return new PagedDataList(QueryListAll, _TempletDao.QueryCount, param, pageSize, pageIndex);
            }
            else
            {
                return new PagedDataList(QueryListDetail, QueryAttudeTempletCount, param, pageSize, pageIndex);
            }
        }

        /// <summary>
        /// 查询意见列表，扩展
        /// </summary>
        /// <param name="param"></param>
        /// <param name="pageSize"></param>
        /// <param name="pageIndex"></param>
        /// <returns></returns>
        public IPagedList QueryTempletPagedListEx(TempletQueryPara param, int pageSize, int pageIndex)
        {
            DataList list = QueryAttudeTempletList(param, 0, -1);

                return new PagedDataList(QueryAttudeTempletList, _TempletDao.QueryCount, param, pageSize, pageIndex);
        }

        #endregion
    }
}