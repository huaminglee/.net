using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PDTech.OA.Model
{
    /// <summary>
    /// 在线考试
    /// </summary>
    public class TestOnline
    {
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
        /// 试卷题目列表
        /// </summary>
        public List<Question> QuestionCollection
        {
            get;
            set;
        }
        /// <summary>
        /// 作答时间
        /// </summary>
        public DateTime? ReplyTime
        {
            get;
            set;
        }
    }

    /// <summary>
    /// 试题
    /// </summary>
    public class Question
    {
        /// <summary>
        /// 试题ID
        /// </summary>
        public string QuestionID
        {
            get;
            set;
        }
        /// <summary>
        /// 题目
        /// </summary>
        public string Title
        {
            get;
            set;
        }
        /// <summary>
        /// 选项A
        /// </summary>
        public string OptionA
        {
            get;
            set;
        }
        /// <summary>
        /// 选项B
        /// </summary>
        public string OptionB
        {
            get;
            set;
        }
        /// <summary>
        /// 选项C
        /// </summary>
        public string OptionC
        {
            get;
            set;
        }
        /// <summary>
        /// 选项D
        /// </summary>
        public string OptionD
        {
            get;
            set;
        }
        /// <summary>
        /// 正确答案
        /// </summary>
        public string CorrectResult
        {
            get;
            set;
        }
        /// <summary>
        /// 分值
        /// </summary>
        public decimal QuestionValue
        {
            get;
            set;
        }
        /// <summary>
        /// 选择的答案
        /// </summary>
        public string SelectValue
        {
            get;
            set;
        }
        /// <summary>
        /// 得分
        /// </summary>
        public decimal Score
        {
            get;
            set;
        }
    }
}
