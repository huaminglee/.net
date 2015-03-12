using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PDTech.OA.Model
{
    public class TestAnswer
    {
        /// <summary>
        /// 试卷ID
        /// </summary>
        public string TestGuid
        {
            get;
            set;
        }
        /// <summary>
        /// 试卷名称
        /// </summary>
        public string TestName
        {
            get;
            set;
        }
        /// <summary>
        /// 试题总数
        /// </summary>
        public decimal TestCount
        {
            get;
            set;
        }
        /// <summary>
        /// 试卷总分
        /// </summary>
        public decimal TestScore
        {
            get;
            set;
        }
        /// <summary>
        /// 作答ID
        /// </summary>
        public string AnswerGuid
        {
            get;
            set;
        }
        /// <summary>
        /// 作答时间
        /// </summary>
        public DateTime? AnswerTime
        {
            get;
            set;
        }
    }
}
