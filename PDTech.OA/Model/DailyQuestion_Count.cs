using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PDTech.OA.Model
{
    public class DailyQuestion_Count
    {
        /// <summary>
        /// 员工编号
        /// </summary>
        public decimal UserId
        {
            get;
            set;
        }
        /// <summary>
        /// 员工姓名
        /// </summary>
        public string UserName
        {
            get;
            set;
        }
        /// <summary>
        /// 共答题数
        /// </summary>
        public int TotalCount
        {
            get;
            set;
        }
        /// <summary>
        /// 回答正确的数量
        /// </summary>
        public int CorrectCount
        {
            get;
            set;
        }
        /// <summary>
        /// 回答错误的数量
        /// </summary>
        public int ErrorCount
        {
            get;
            set;
        }
        /// <summary>
        /// 未作答的数量
        /// </summary>
        public int SkipCount
        {
            get;
            set;
        }
        /// <summary>
        /// 正确率
        /// </summary>
        public string CorrectRate
        {
            get
            {
                if (TotalCount == 0)
                {
                    return "--";
                }
                else
                {
                    if (CorrectCount == 0)
                    {
                        return "0";
                    }
                    else
                    {
                        return Math.Round(((double)CorrectCount / ((double)CorrectCount + (double)ErrorCount) * 100), 2).ToString() + "%";
                    }
                }  
            }
        }
        /// <summary>
        /// 错误率
        /// </summary>
        public string ErrorRate
        {
            get
            {
                if (TotalCount == 0)
                {
                    return "--";
                }
                else
                {
                    if (ErrorCount == 0)
                    {
                        return "0";
                    }
                    else
                    {
                        return Math.Round(((double)ErrorCount / ((double)CorrectCount + (double)ErrorCount) * 100), 2).ToString() + "%";
                    }
                } 
            }
        }
        /// <summary>
        /// 跳过率
        /// </summary>
        public string SkipRate
        {
            get
            {
                if (TotalCount == 0)
                {
                    return "--";
                }
                else
                {
                    if (SkipCount == 0)
                    {
                        return "0";
                    }
                    else
                    {
                        return Math.Round(((double)SkipCount / (double)TotalCount * 100), 2).ToString() + "%";
                    }
                }
            }
        }
    }
}
