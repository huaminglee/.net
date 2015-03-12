using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenentTestData
{
    public class GenertMessage
    {
        PDTech.OA.BLL.OA_MESSAGE msgBll = new PDTech.OA.BLL.OA_MESSAGE();
        PDTech.OA.BLL.USER_INFO userBll = new PDTech.OA.BLL.USER_INFO();

        public void Genert_message()
        {
            List<PDTech.OA.Model.USER_INFO> list = userBll.GetModelList("");
            Random rand = new Random();
            for (int i = 1; i <= 10000; i++)
            {
                PDTech.OA.Model.OA_MESSAGE msgModel = new PDTech.OA.Model.OA_MESSAGE();
                int sender = rand.Next(list.Count);
                msgModel.MESSAGE_SENDER = sender;
                msgModel.MESSAGE_TITLE = "公告_" + i.ToString();
                msgModel.MESSAGE_CONTENT = "公告内容_" + i.ToString();
                List<int> tempList = new List<int>();
                do
                {
                    int reciever = rand.Next(list.Count);
                    if (!tempList.Contains(reciever))
                    {
                        tempList.Add(reciever);
                    }
                } while (tempList.Count != 3);
                string recievers = tempList[0].ToString() + "," + tempList[1].ToString() + "," + tempList[2].ToString();
                bool r = msgBll.Add(msgModel, "", recievers, 0, "", "");
            }
        }
    }
}
