using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Configuration;

namespace PDTECH.OA.COM_SMS
{
    public class ZucpRPC : SMSRpc
    {

        string rrid = "001";// %% zucp（漫道科技短信发送成功后的返回码,必须是数字）
        CNNWebClient client = new CNNWebClient() {  Timeout=10 };

        /// <summary>
        /// 发送短信
        /// </summary>
        /// <param name="mobileNo">手机号</param>
        /// <param name="smsContent">发送内容</param>
        /// <param name="resultMsg">返回消息</param>
        /// <returns>发送是否成功</returns>
        override public bool SendSMS(string mobileNo, string smsContent, out string resultMsg)
        {
            string ZucpSendUrl = ConfigurationManager.AppSettings["ZucpSendUrl"];
            string ZucpUID = ConfigurationManager.AppSettings["ZucpUID"];
            string ZucpPWD = ConfigurationManager.AppSettings["ZucpPWD"];
            List<string> req_par = new List<string>();
            req_par.Add("sn=" + System.Web.HttpUtility.UrlEncode(ZucpUID, Encoding.GetEncoding("GB2312")));
            req_par.Add("pwd=" + System.Web.HttpUtility.UrlEncode(S_APP.MD5HASH(ZucpUID + ZucpPWD, Encoding.GetEncoding("GB2312")), Encoding.GetEncoding("GB2312")));//pwd需要MD5(SN+pwd)加密，取32位大写
            req_par.Add("rrid=" + System.Web.HttpUtility.UrlEncode(rrid, Encoding.GetEncoding("GB2312")));
            req_par.Add("mobile=" + System.Web.HttpUtility.UrlEncode(mobileNo, Encoding.GetEncoding("GB2312")));
            req_par.Add("content=" + System.Web.HttpUtility.UrlEncode(smsContent, Encoding.GetEncoding("GB2312")));
            try
            {
                using (System.IO.Stream stream = client.OpenRead(ZucpSendUrl + "?" + string.Join("&", req_par.ToArray())))
                {
                    using (System.IO.StreamReader reader = new System.IO.StreamReader(stream, System.Text.Encoding.GetEncoding("gb2312")))
                    {
                        resultMsg = reader.ReadToEnd();
                        reader.Close();
                    }
                    stream.Close();
                }
            }
            catch(Exception ex)
            {
                resultMsg = ex.Message;
                Program.Logger.Debug(smsContent, ex);
            }
            return mapResult(resultMsg);
        }

        

        override public bool connection()
        {
            return true;
        }

        private bool mapResult(string resString)
        {
            //# 1	没有需要取得的数据
            //# -2 	帐号/密码不正确
            //# -4	余额不足
            //# -5	数据格式错误
            //# -6	参数有误
            //# -7	权限受限
            //# -8	流量控制错误
            //# -9	扩展码权限错误
            //# -10	内容长度长
            //# -11	内部数据库错误
            //# -12	序列号状态错误
            //# -13	没有提交增值内容
            //# -14	服务器写文件失败
            //# -15	文件内容base64编码错误
            //# -17	没有权限
            //# -18	需等待上次的提交返回
            //# -19	禁止同时使用多个接口地址
            //# -20	提交过多
            //# -22	Ip鉴权失败 

            if (resString == rrid)
                return true;
            else
                return false;
        }
    }

    public class CNNWebClient : WebClient
    {

        private int _timeOut = 10;

        /// <summary>
        /// 过期时间
        /// </summary>
        public int Timeout
        {
            get
            {
                return _timeOut;
            }
            set
            {
                if (value <= 0)
                    _timeOut = 10;
                _timeOut = value;
            }
        }

        /// <summary>
        /// 重写GetWebRequest,添加WebRequest对象超时时间
        /// </summary>
        /// <param name="address"></param>
        /// <returns></returns>
        protected override WebRequest GetWebRequest(Uri address)
        {
            HttpWebRequest request = (HttpWebRequest)base.GetWebRequest(address);
            request.Timeout = 1000 * Timeout;
            request.ReadWriteTimeout = 1000 * Timeout;
            return request;
        }
    }
}
