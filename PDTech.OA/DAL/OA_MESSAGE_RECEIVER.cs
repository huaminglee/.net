using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Maticsoft.DBUtility;

namespace PDTech.OA.DAL
{
    /// <summary>
    /// 数据访问类:OA_MESSAGE_RECEIVER
    /// </summary>
    public partial class OA_MESSAGE_RECEIVER
    {
        public OA_MESSAGE_RECEIVER()
        { }
        #region  BasicMethod
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(IList<PDTech.OA.Model.OA_MESSAGE_RECEIVER> List)
        {
            try
            {
                ArrayList SQLStringList = new ArrayList();
                foreach (var item in List)
                {
                    string strSql = string.Format(@"update OA_MESSAGE_RECEIVER set READ_STATUS=1,READ_TIME=getdate() WHERE 1=1 AND READ_STATUS=0 AND MESSAGE_ID={0} AND RECEIVER_ID={1}", item.MESSAGE_ID, item.RECEIVER_ID);
                    SQLStringList.Add(strSql);
                }
                DbHelperSQL.ExecuteSqlTran(SQLStringList);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        #endregion  BasicMethod
        #region  ExtensionMethod
        /// <summary>
        /// 查询公告消息（已读）
        /// </summary>
        /// <param name="uId">用户ID</param>
        /// <returns>返回公告消息</returns>
        public IList<Model.OA_BULLETIN> GetBulletin(string uId)
        {
            StringBuilder strSql = new StringBuilder();
            //strSql.Append("select message.* from(select om.message_id,om.message_title,omr.read_status,");
            //strSql.Append("to_char(om.message_send_time,'yyyy-mm-dd') as message_send_time,'公告' as type_name,");
            //strSql.Append("(select full_name from user_info where user_id=om.message_sender) as message_sender ");
            //strSql.Append("from oa_message om,oa_message_receiver omr ");
            //strSql.Append("where om.message_id=omr.message_id and omr.receiver_id=" + uId + " and omr.read_status=0 ");
            //strSql.Append("union all ");
            //strSql.Append("select omt.meeting_id,omt.title,omtr.read_status,");
            //strSql.Append("to_char(omt.create_time,'yyyy-mm-dd') as create_time,'会议' as type_name,");
            //strSql.Append("(select full_name from user_info where user_id=omt.sender) as sender ");
            //strSql.Append("from oa_meeting omt,oa_meeting_receiver omtr ");
            //strSql.Append("where omt.meeting_id=omtr.meeting_id and omtr.receiver_id=" + uId + " and omtr.read_status=0 ");
            //strSql.Append("order by read_status asc,message_send_time desc) message where rownum < 6");
            strSql.Append("select top 5 message.* from(select om.message_id,om.message_title,omr.read_status,");
            strSql.Append("convert(varchar(10),om.message_send_time,101) as message_send_time,'公告' as type_name,");
            strSql.Append("(select full_name from user_info where user_id=om.message_sender) as message_sender ");
            strSql.Append("from oa_message om,oa_message_receiver omr ");
            strSql.Append("where om.message_id=omr.message_id and omr.receiver_id=" + uId);
            strSql.Append("union all ");
            strSql.Append("select omt.meeting_id,omt.title,omtr.read_status,");
            strSql.Append("convert(varchar(10),omt.create_time,101) as message_send_time,'会议' as type_name,");
            strSql.Append("(select full_name from user_info where user_id=omt.sender) as sender ");
            strSql.Append("from oa_meeting omt,oa_meeting_receiver omtr ");
            strSql.Append("where omt.meeting_id=omtr.meeting_id and omtr.receiver_id=" + uId + ") message ");
            strSql.Append("order by read_status asc, message_send_time desc");
            DataTable dt = DbHelperSQL.Query(strSql.ToString()).Tables[0];
            if (dt.Rows.Count > 0)
            {
                return DAL_Helper.CommonFillList<Model.OA_BULLETIN>(dt);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 查询公告消息（未读和已读）
        /// </summary>
        /// <param name="uId">用户ID</param>
        /// <param name="strWhere">查询条件</param>
        /// <param name="currentPage">当前页面</param>
        /// <param name="pageSize">每页条数</param>
        /// <param name="totalNum">总条数</param>
        /// <returns>返回公告消息</returns>
        public IList<Model.OA_ALL_BULLETIN> GetAllBulletin(string uId, string strWhere, string currentPage, string pageSize, out int totalNum)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select TOP (100) PERCENT rank() over(order by omr.read_status asc,om.message_send_time desc) as rowno,");
            strSql.Append("om.message_id,om.message_title,");
            strSql.Append("CASE omr.read_status WHEN 0 THEN '未读' WHEN 1 THEN '已读' ELSE '其它' END as read_status,");
            strSql.Append("convert(varchar(10),om.message_send_time,20) as message_send_time ");
            strSql.Append("from oa_message om join oa_message_receiver omr on omr.message_id=om.message_id ");
            strSql.Append("where omr.receiver_id='" + uId + "' ");
            if (strWhere != "" && strWhere != null)
            {
                strSql.Append(strWhere);
            }
            /***组织分页***/
            PageDescribe pd = new PageDescribe();
            pd.CurrentPage = int.Parse(currentPage);//当前页索引
            pd.PageSize = int.Parse(pageSize);//当前页显示条数
            DataTable dt = pd.PageDescribes(strSql.ToString());
            totalNum = pd.RecordCount;
            if (dt.Rows.Count > 0)
            {
                return DAL_Helper.CommonFillList<Model.OA_ALL_BULLETIN>(dt);
            }
            else
            {
                return null;
            }
        }
        #endregion  ExtensionMethod
    }
}