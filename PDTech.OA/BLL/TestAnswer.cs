using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PDTech.OA.BLL
{
    public class TestAnswer
    {
        private readonly PDTech.OA.DAL.TestAnswer dal = new PDTech.OA.DAL.TestAnswer();

        public IList<PDTech.OA.Model.TestAnswer> Get_Paging_List(decimal userId, string title, int pageSize, int pageIndex, out int record)
        {
            return dal.Get_Paging_List(userId, title, pageSize, pageIndex, out record);
        }
    }
}
