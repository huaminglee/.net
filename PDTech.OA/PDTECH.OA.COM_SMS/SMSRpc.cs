using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace PDTECH.OA.COM_SMS
{
    /// <summary>
    /// 短信发送基类
    /// </summary>
    public class SMSRpc
    {
        /// <summary>
        /// 发送短信
        /// </summary>
        /// <param name="mobileNo">手机号</param>
        /// <param name="smsContent">发送内容</param>
        /// <param name="resultMsg">返回消息</param>
        /// <returns>发送是否成功</returns>
        public virtual bool SendSMS(string mobileNo, string smsContent, out string resultMsg)
        {
            resultMsg = "失败";
            return false;
        }

        /// <summary>
        /// 链接设备
        /// </summary>
        /// <returns></returns>
        public virtual bool connection()
        {
            return false;
        }

        public static SMSRpc getRpc()
        {
            string RPC_TYPE = ConfigurationManager.AppSettings["RPC_TYPE"];
            if (RPC_TYPE == "1")
                return new COM_SMS();
            else if (RPC_TYPE == "2")
                return new ZucpRPC();

            return null;

        }
    }
}
