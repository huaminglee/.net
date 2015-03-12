using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace PDTECH.OA.COM_SMS
{
    /// <summary>
    /// 短信发送处理
    /// </summary>
    public class SMSCore
    {
        public void ProcessSMS()
        {
            SMSRpc rpc = SMSRpc.getRpc();
            if (rpc.connection())
            {
                PDTech.OA.BLL.API_MESSAGES messageBll = new PDTech.OA.BLL.API_MESSAGES();
                while (true)
                {
                    List<PDTech.OA.Model.API_MESSAGES> messages = messageBll.GetModelList(100, "MESSAGE_TYPE ='COM_SMS' AND message_stat='0' AND TRY_TIME IS NOT NULL AND TRY_TIME<GETDATE()");//获取待发消息
                    if (messages == null || messages.Count == 0)
                    {
                        Program.Logger.Info("所有消息发送完成!");
                        break;
                    }
                    foreach (var item in messages)
                    {
                        if (checkIsMobileNo(item.DATA2))
                        {
                            string result = "";
                            bool ob = rpc.SendSMS(item.DATA2, item.DATA1, out result);
                            if (ob)
                            {
                                Program.Logger.Info("发送成功、手机号：<" + item.DATA2 + ">、发送内容：" + item.DATA1);
                                item.MESSAGE_STAT = 1;
                                item.RESPONSE = "1";
                                item.TRIALS = item.TRIALS.Value + 1;
                                item.TRY_TIME = System.DateTime.Now;
                                messageBll.UpdateMessage(item);
                            }
                            else
                            {
                                Program.Logger.Info("发送失败、手机号：<" + item.DATA2 + ">、发送内容：" + item.DATA1);
                                item.MESSAGE_STAT = 0;
                                item.RESPONSE = result;
                                item.TRY_TIME = getTryTime(item);
                                item.TRIALS = item.TRIALS.Value + 1;
                                messageBll.UpdateMessage(item);
                            }
                        }
                    }
                }
            }
            else
            { }
        }

        private DateTime getTryTime(PDTech.OA.Model.API_MESSAGES m)
        {
            int nextTimeSecend = 0;//下次重试时间单位秒
            if (m.TRIALS == 0)
            {
                nextTimeSecend = 30;
            }
            else if (m.TRIALS < 3)
            {
                nextTimeSecend = 60;
            }
            else if (m.TRIALS < 8)
            {
                nextTimeSecend = 60 * 10;
            }
            else
            {
                return DateTime.MaxValue;
            }
            return DateTime.Now.AddSeconds(nextTimeSecend);

        }


        private bool checkIsMobileNo(string p_mobileNo)
        {
            string pattern = @"(^1[3-8]\d{9}$)";
            return System.Text.RegularExpressions.Regex.IsMatch(p_mobileNo, pattern);
        }
    }
}
