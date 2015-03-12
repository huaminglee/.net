using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Configuration;

namespace PDTECH.OA.COM_SMS
{
    class COM_SMS : SMSRpc
    {
        [DllImport("sms.dll", EntryPoint = "Sms_Connection")]
        public static extern uint Sms_Connection(string CopyRight, uint Com_Port, uint Com_BaudRate, out string Mobile_Type, out string CopyRightToCOM);

        [DllImport("sms.dll", EntryPoint = "Sms_Disconnection")]
        public static extern uint Sms_Disconnection();

        [DllImport("sms.dll", EntryPoint = "Sms_Send")]
        public static extern uint Sms_Send(string Sms_TelNum, string Sms_Text);

        [DllImport("sms.dll", EntryPoint = "Sms_Receive")]
        public static extern uint Sms_Receive(string Sms_Type, out string Sms_Text);

        [DllImport("sms.dll", EntryPoint = "Sms_Delete")]
        public static extern uint Sms_Delete(string Sms_Index);

        [DllImport("sms.dll", EntryPoint = "Sms_AutoFlag")]
        public static extern uint Sms_AutoFlag();

        [DllImport("sms.dll", EntryPoint = "Sms_NewFlag")]
        public static extern uint Sms_NewFlag();

        /// <summary>
        /// 发送短信
        /// </summary>
        /// <param name="mobileNo">手机号</param>
        /// <param name="smsContent">发送内容</param>
        /// <param name="resultMsg">返回消息</param>
        /// <returns>发送是否成功</returns>
        override public bool SendSMS(string mobileNo, string smsContent, out string resultMsg)
        {
            uint ob = Sms_Send(mobileNo, smsContent);
            if (ob == 1)
            {
                resultMsg = "发送成功";
                return true;
            }
            else
            {
                resultMsg = "发送失败";
                return false;
            }
        }


        override public bool connection()
        {
            String TypeStr = "";
            String CopyRightToCOM = "";
            String CopyRightStr = "";
            string portNo = ConfigurationManager.AppSettings["PortNum"];
            try
            {

                if (Sms_Connection(CopyRightStr, uint.Parse(portNo), 9600, out TypeStr, out CopyRightToCOM) == 1) ///5为串口号，0为红外接口，1,2,3,...为串口
                {
                    Program.Logger.Info("链接成功：" + TypeStr);
                    return true;
                }
                else
                {
                    Program.Logger.Error("链接不上");
                }
            }
            catch (Exception ex)
            {

                Program.Logger.Error("链接不上", ex);
            }
            return false;
        }
    }
}
