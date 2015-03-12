using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace PDTech.OA.DAL
{
    public class TestOnline
    {
        public IList<PDTech.OA.Model.TestOnline> Get_Paging_List(string title, int pageSize, int pageIndex, out int record)
        {
            string strSQL = string.Empty;
            if (!string.IsNullOrEmpty(title))
            {
                strSQL = string.Format("SELECT TOP (100) PERCENT * from OA_EDUTEST WHERE TESTNAME like '%{0}%' order by CREATETIME ", title);
            }
            else
            {
                strSQL = string.Format("SELECT TOP (100) PERCENT * from OA_EDUTEST order by CREATETIME ", title);
            }
            PageDescribe pdes = new PageDescribe();
            pdes.CurrentPage = pageIndex;
            pdes.PageSize = pageSize;
            DataTable dt = pdes.PageDescribes(strSQL);
            record = pdes.RecordCount;
            return DAL_Helper.CommonFillList<Model.TestOnline>(dt);
        }
    }
}
