#region 版本说明
/*****************************************************************************
 * 
 * 项    目 : 
 * 作    者 : 罗坤 
 * 创建时间 : 2015/1/23 13:13:22 
 *
 * Copyright (C) 2008 - 鹏业软件公司
 * 
 *****************************************************************************/
#endregion

/*
      <!--系统消息服务-->
      <component id="MessageServiceSvr" type="PengeSoft.CMS.BaseDatum.MessageServiceSvr, PengeSoft.CMS.BaseDatum" service="PengeSoft.CMS.BaseDatum.IMessageServiceSvr, PengeSoft.CMS.BaseDatum" lifestyle="Singleton">
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
using PengeSoft.Service.Auther;

namespace PengeSoft.CMS.BaseDatum 
{
    /// <summary>
    /// MessageServiceSvr实现。系统消息服务    
    /// </summary>
    [PublishName("MessageService")]
    public class MessageServiceSvr : UserAutherImp, IMessageServiceSvr
    {
        #region 私有字段
        private IDaoManager _daoManager = null;
        private IMessageDao _Messagedao = null;
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
        public MessageServiceSvr() 
        {
            _daoManager = ServiceConfig.GetInstance().DaoManager;
            _Messagedao = (IMessageDao)_daoManager.GetDao(typeof(IMessageDao));
         }

        public override void FormAttribsRec(PengeSoft.WorkZoneData.AppAttribBaseRec attr)
        {
            base.FormAttribsRec(attr);

            attr.Detail = "系统消息服务";
        }

        #endregion

        #region IMessageServiceSvr 函数

        /// <summary>
        /// 发送消息   
        /// </summary>
        /// <param name="uTag">用户登录码</param>
        /// <param name="Recipients">接收人列表</param>
        /// <param name="Message">消息内容</param>
        [PublishMethod]
        public int SendMessage(string uTag, string Recipients, string Message)
        {
            string uId, uKey;
            int checkresult = CheckRight(uTag, "", out uId, out  uKey);

            //首先验证用户登录
            if (checkresult == PengeSoft.Auther.RightCheck.AutherCheckResult.OP_SUCESS)
            {
                Hashtable insertParam = new Hashtable();
                insertParam["Recipients"] = Recipients;
                insertParam["Sender"] = uId;
                insertParam["Message"] = Message;
                insertParam["CreateDate"] = DateTime.Now;
                //调用存储过程来执行插入
                return _Messagedao.InsertMessages(insertParam);
            }
            else
            {
                return checkresult;
            }
        }

        /// <summary>
        /// 获取消息   
        /// </summary>
        /// <param name="uTag">用户登录码</param>
        /// <param name="Guid">消息ID</param>
        [PublishMethod]
        public Message GetMessage(string uTag, int Guid)
        {
            Message data = new Message();
            //首先验证用户登录
            if (CheckRight(uTag, "") == PengeSoft.Auther.RightCheck.AutherCheckResult.OP_SUCESS)
            {
                data.Guid = Guid;
                data.AssignFrom(_Messagedao.GetDetail(data));
            }
            return data;
        }

        /// <summary>
        /// 查询消息总数   
        /// </summary>
        /// <param name="uTag">用户登录码</param>
        /// <param name="StateCode">消息状态码 1：未读 0：已读  -1:所有</param>
        [PublishMethod]
        public int QueryMessageCount(string uTag, int StateCode)
        {
            //首先验证用户登录
            string uId,uKey;
            int checkresult = CheckRight(uTag, "", out uId,out  uKey);
            
            if (checkresult == PengeSoft.Auther.RightCheck.AutherCheckResult.OP_SUCESS)
            {
                Hashtable queryParam = new Hashtable();
                queryParam["UID"] = uId;
                if (StateCode != -1)
                {
                    queryParam["State"] = StateCode;
                }
                return _Messagedao.QueryMessageCount(queryParam);
            }
            else
            {
                return 0;
            }
        }

        /// <summary>
        /// 查询消息分页列表   
        /// </summary>
        /// <param name="uTag">用户登录码</param>
        /// <param name="StateCode">消息状态码</param>
        /// <param name="pageIndex">起始页</param>
        /// <param name="pageSize">页大小</param>       
        [PublishMethod]
        public MessageList QueryMessagePageList(string uTag, int StateCode, int pageIndex, int pageSize)
        {
            MessageList result = new MessageList();
            //首先验证用户登录
            string uId, uKey;
            int checkresult = CheckRight(uTag, "", out uId, out  uKey);
            if (checkresult == PengeSoft.Auther.RightCheck.AutherCheckResult.OP_SUCESS)
            {
                Hashtable parmData = new Hashtable();
                parmData["UID"] = uId;
                if (StateCode != -1)
                {
                    parmData["State"] = StateCode;
                }

                int start = (pageIndex - 1) * pageSize;
                DataList dlist = _Messagedao.QueryMessageList(parmData, start, pageSize);
                if (dlist.Count > 0)
                {
                    result.AssignFrom(dlist);
                }
            }
            return result;
        }

        /// <summary>
        /// 标记消息列表   
        /// </summary>
        /// <param name="uTag">用户登录码</param>
        /// <param name="MessageGuids">消息ID列表</param>
        /// <param name="StateCode">消息状态码</param>
        [PublishMethod]
        public void MarkMessageList(string uTag,string MessageGuids, int StateCode)
        {
            //首先验证用户登录
            int checkresult = CheckRight(uTag, "");
            if (checkresult == PengeSoft.Auther.RightCheck.AutherCheckResult.OP_SUCESS)
            {
                string[] dels = MessageGuids.Split(new char[] { ',' });
                foreach (var item in dels)
                {
                    MarkMessage(uTag,int.Parse(item), StateCode);
                }
            }
        }

        /// <summary>
        /// 标记消息   
        /// </summary>
        /// <param name="uTag">用户登录码</param>
        /// <param name="Guid">消息ID</param>
        /// <param name="StateCode">消息状态码</param>
        [PublishMethod]
        public void MarkMessage(string uTag, int Guid, int StateCode)
        {
            //首先验证用户登录
            string uId, uKey;
            int checkresult = CheckRight(uTag, "", out uId, out  uKey);
            if (checkresult == PengeSoft.Auther.RightCheck.AutherCheckResult.OP_SUCESS)
            {
                Hashtable markParam = new Hashtable();
                markParam["Guid"] = Guid;
                markParam["UID"] = uId;
                markParam["State"] = StateCode;
                _Messagedao.UpdateMessage(markParam);
            }
        }

        /// <summary>
        /// 删除消息列表   
        /// </summary>
        /// <param name="uTag">用户登录码</param>
        /// <param name="MessageGuids">消息标识列表</param>
        [PublishMethod]
        public void DeleteMessageList(string uTag, string MessageGuids)
        {
            //首先验证用户登录
            string uId, uKey;
            int checkresult = CheckRight(uTag, "", out uId, out  uKey);
            if (checkresult == PengeSoft.Auther.RightCheck.AutherCheckResult.OP_SUCESS)
            {
                Hashtable delParam;
                string[] dels = MessageGuids.Split(new char[] { ',' });
                foreach (var item in dels)
                {
                    delParam = new Hashtable();
                    delParam["Guid"] = item;
                    delParam["UID"] = uId;
                    _Messagedao.DeleteMessage(delParam);
                }
            }
        }

        #endregion
    }
}
