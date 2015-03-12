using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace PDTech.OA.DAL
{
    public class TestAnswer
    {
        public IList<PDTech.OA.Model.TestAnswer> Get_Paging_List(decimal userId, string title, int pageSize, int pageIndex, out int record)
        {
            string strSQL = string.Empty;
            if (!string.IsNullOrEmpty(title))
            {
                strSQL = string.Format(@"select distinct(a.EDU_A_GUID) as AnswerGuid,c.EDU_T_GUID as TestGuid,c.TESTNAME as TestName,
                                        c.TESTCOUNT as TestCount,c.SCORE as TestScore,a.answertime as AnswerTime 
                                        from OA_TEST_ANSWER a 
                                        left join OA_QUESTION_TEST_MAP b on a.EDU_MAP_GUID = b.EDU_MAP_GUID
                                        left join OA_EDUTEST c on c.EDU_T_GUID = b.edu_t_guid
                                        where a.ANSWER_ID = {0} and c.TESTNAME like '%{1}%' ", userId, title);
            }
            else
            {
                strSQL = string.Format(@"select distinct(a.EDU_A_GUID) as AnswerGuid,c.EDU_T_GUID as TestGuid,c.TESTNAME as TestName,
                                        c.TESTCOUNT as TestCount,c.SCORE as TestScore,a.answertime as AnswerTime 
                                        from OA_TEST_ANSWER a 
                                        left join OA_QUESTION_TEST_MAP b on a.EDU_MAP_GUID = b.EDU_MAP_GUID
                                        left join OA_EDUTEST c on c.EDU_T_GUID = b.edu_t_guid
                                        where a.ANSWER_ID = {0} ", userId);
            }
            PageDescribe pdes = new PageDescribe();
            pdes.CurrentPage = pageIndex;
            pdes.PageSize = pageSize;
            DataTable dt = pdes.PageDescribes(strSQL, "answertime", "asc");
            record = pdes.RecordCount;
            return DAL_Helper.CommonFillList<Model.TestAnswer>(dt);
        }
    }
}
