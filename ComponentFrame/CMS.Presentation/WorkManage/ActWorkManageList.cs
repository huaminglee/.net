using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PengeSoft.CMS.BaseDatum;
using System.Web;
using PengeSoft.db;
using PengeSoft.WorkZoneData;
using System.Collections;
using PengeSoft.Data;
using PengeSoft.Web;
using PengeSoft.WorkFlow;
namespace PengeSoft.CMS.Presentation
{
    public class ActWorkManageList : ActBaseFormList
    {
      
        public ActWorkManageList(HttpContext ctx)
            : base(ctx)
        {
            
        }

        /// <summary>
        /// 时间段
        /// </summary>
        public string DateSpan { get; set; }

        /// <summary>
        /// 处理工作类型
        /// </summary>
        public int FlowType { get; set; }
        /// <summary>
        /// 是否超期预警
        /// </summary>
        public bool isWarning { get; set; }
        /// <summary>
        /// 是否风险项目
        /// </summary>
        public bool isItemwarning { get; set; }
        /// <summary>
        /// 公文标题
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// 公文编号
        /// </summary>
        public string FileNo { get; set; }
        /// <summary>
        /// 开始时间
        /// </summary>
        public DateTime startdate { get; set; }
        /// <summary>
        /// 结束时间
        /// </summary>
        public DateTime enddate { get; set; }
        /// <summary>
        /// 所属部门
        /// </summary>
        public string owndept { get; set; }
        /// <summary>
        /// 风险处置
        /// </summary>
        public int RiskDeal { get; set; }
        #region

        protected override PengeSoft.db.QueryParameter CreateQueryParamater()
        {
            BaseFormDataQueryPara param = new BaseFormDataQueryPara();
            if (isWarning)
            {
                int[] stype = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14 };
                param.SetSType_In(stype);
            }
            else if (isItemwarning)
            {
                int[] stype = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14 };
                param.SetSType_In(stype);
                
            }
            else
            {
                param.SetSType(FormType);
            }
            if (!String.IsNullOrEmpty(Title))
            {
                param.SetTitle(Title);
            }
            if (!String.IsNullOrEmpty(FileNo))
            {
                param.SetFileNo(FileNo);
            }
            if (startdate != DateTime.MinValue)
            {
             
            }
           
            //param.SetPermissionLevel(1);  //权限条件
            //param.SetPermissionRole("admin");
            return param;
        }

        protected override PengeSoft.db.IPagedList CreatePagedList(PengeSoft.db.QueryParameter param)
        {
            if (isWarning)
            {
                return Getinfolistex(param as BaseFormDataQueryPara, PageSize, PageIndex); 
            }
            else
            {
                return Getinfolist(param as BaseFormDataQueryPara, PageSize, PageIndex);
            }

           
        }

        
        #endregion       
    }
}


