using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PDTech.OA.BLL
{
    public class TestOnline
    {
        private readonly PDTech.OA.DAL.TestOnline dal = new PDTech.OA.DAL.TestOnline();

        public IList<PDTech.OA.Model.TestOnline> Get_Paging_List(string title, int pageSize, int pageIndex, out int record)
        {
            return dal.Get_Paging_List(title, pageSize, pageIndex, out record);
        }
    }
}
