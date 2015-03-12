using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenentTestData
{
   public class GenertMeeting
    {
        PDTech.OA.BLL.OA_MEETING meetBll = new PDTech.OA.BLL.OA_MEETING();
        PDTech.OA.BLL.USER_INFO userBll = new PDTech.OA.BLL.USER_INFO();
        PDTech.OA.BLL.MEETING_ROOM_INFO roomBll = new PDTech.OA.BLL.MEETING_ROOM_INFO();

        public void Genert_meeting()
        {
            List<PDTech.OA.Model.USER_INFO> list = userBll.GetModelList("");
            List<PDTech.OA.Model.MEETING_ROOM_INFO> roomList = roomBll.GetModelList("");
            Random rand = new Random();
            for (int i = 1; i <= 10000; i++)
            {
                PDTech.OA.Model.OA_MEETING meetModel = new PDTech.OA.Model.OA_MEETING();
                int sender = rand.Next(list.Count);
                meetModel.SENDER = sender;
                meetModel.TITLE = "会议_" + i.ToString();
                meetModel.CONTENT = "会议内容_" + i.ToString();
                int roomId = rand.Next(roomList.Count);
                meetModel.MEETING_ROOM_ID = roomList[roomId].MEETING_ROOM_ID;
                meetModel.LOCATION = roomList[roomId].MEETING_ROOM_NAME;
                meetModel.START_TIME = DateTime.Now.AddDays(i);
                meetModel.END_TIME = DateTime.Now.AddDays(i).AddHours(1);
                meetModel.DEPT = "部门" + i.ToString();
                int hostUser = rand.Next(list.Count);
                meetModel.HOST_USER = hostUser;
                meetModel.OTHER_PERS = "";
                meetModel.REMARK = "";
                List<int> tempList = new List<int>();
                do
                {
                    int reciever = rand.Next(list.Count);
                    if (!tempList.Contains(reciever))
                    {
                        tempList.Add(reciever);
                    }
                }while(tempList.Count != 3);
                string recievers = tempList[0].ToString() + "," + tempList[1].ToString() + "," + tempList[2].ToString();
                bool r = meetBll.Add(meetModel, "", recievers, 0, "", "");
            }
        }
    }
}
